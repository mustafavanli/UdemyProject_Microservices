using FreeCourse.Services.API.Dtos;
using FreeCourse.Shared.Dtos;

namespace FreeCourse.Services.API.Services
{
    public interface ICourseService
    {
        Task<Response<List<CourseDto>>> GetAllAsync();
        Task<Response<CourseDto>> GetByIdAsync(Guid id);
        Task<Response<List<CourseDto>>> GetAllByUserIdAsync(Guid UserId);
        Task<Response<CourseDto>> CreateAsync(CourseCreateDto courseCreateDto);
        Task<Response<NoContent>> CourseUpdateAsync(CourseUpdateDto courseUpdateDto);
        Task<Response<NoContent>> DeleteAsync(Guid id);
    }
}
