using AutoMapper;
using FreeCourse.Services.API.Dtos;
using FreeCourse.Services.API.Models;
using FreeCourse.Services.API.Settings;
using FreeCourse.Shared.Dtos;
using FreeCourse.Shared.Messages;
using MongoDB.Driver;

namespace FreeCourse.Services.API.Services
{
    public class CourseService: ICourseService
    {
        private readonly IMongoCollection<Course> _courseCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;
        private readonly MassTransit.IPublishEndpoint _publishEndpoint;

        public CourseService(IMapper mapper,IDatabaseSettings databaseSettings, MassTransit.IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _courseCollection = database.GetCollection<Course>(databaseSettings.CourseCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<Shared.Dtos.Response<List<CourseDto>>> GetAllAsync()
        {
            var courses = await _courseCollection.Find(x=>true).ToListAsync();
            if (courses.Any())
            {
                foreach (var course in courses)
                {
                    course.Category = await _categoryCollection.Find(x=>x.Id==course.CategoryId).FirstAsync();
                }
                return Response<List<CourseDto>>.Success(_mapper.Map<List<CourseDto>>(courses),200);
            }
            else
            {
                courses = new List<Course>();
            }
            return Response<List<CourseDto>>.Success(_mapper.Map<List<CourseDto>>(courses),200);
        }
        public async Task<Response<CourseDto>> GetByIdAsync(Guid id)
        {

            var course = await _courseCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (course==null)
            {
                return Response<CourseDto>.Fail("Course not found ", 404);
            }
            else
            {
                course.Category = await _categoryCollection.Find(x=>x.Id == course.CategoryId).FirstAsync();
                return Response<CourseDto>.Success(_mapper.Map<CourseDto>(course),200);
            }

        }
        public async Task<Response<List<CourseDto>>> GetAllByUserIdAsync(Guid UserId)
        {
            var courses = await _courseCollection.Find(x=>x.UserId==UserId).ToListAsync();
            if (courses.Any())
            {
                foreach (var course in courses)
                {
                    course.Category = await _categoryCollection.Find(x => x.Id == course.CategoryId).FirstAsync();
                }
            }
            else
            {
                courses = new List<Course>();
            }
            return Response<List<CourseDto>>.Success(_mapper.Map<List<CourseDto>>(courses), 200);

        }
        public async Task<Response<CourseDto>> CreateAsync(CourseCreateDto courseCreateDto)
        {
            var newCourse = _mapper.Map<Course>(courseCreateDto);
            newCourse.CreatedTime = DateTime.Now;


            await _courseCollection.InsertOneAsync(newCourse);
            
            return Response<CourseDto>.Success(_mapper.Map<CourseDto>(newCourse),200);
        }
        public async Task<Response<NoContent>> CourseUpdateAsync(CourseUpdateDto courseUpdateDto)
        {
            var updateCourse = _mapper.Map<Course>(courseUpdateDto);
            var result = await _courseCollection.FindOneAndReplaceAsync(x=>x.Id == courseUpdateDto.Id, updateCourse);
            if (result==null)
            {
                return Response<NoContent>.Fail("Course not found",404);
            }

            await _publishEndpoint.Publish<CourseNameChangedEvent>(new CourseNameChangedEvent { CourseId = courseUpdateDto.Id,UpdatedName = courseUpdateDto.Name});
            return Response<NoContent>.Success(204);
        }
        public async Task<Response<NoContent>> DeleteAsync(Guid id)
        {
            var result = await _courseCollection.DeleteOneAsync(x=>x.Id == id);
            if (result.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("Course not found",204);

            }

        }
    }
}
