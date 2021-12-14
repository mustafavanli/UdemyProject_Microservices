namespace FreeCourse.Services.API.Dtos
{
    public class CourseCreateDto
    {
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public FeatureDto Feature { get; set; }
    }
}
