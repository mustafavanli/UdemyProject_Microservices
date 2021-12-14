namespace FreeCourse.Services.API.Dtos
{
    public class CourseUpdateDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public FeatureDto Feature { get; set; }
        public string Picture { get; set; }
    }
}
