namespace FreeCourse.Services.Basket.Dtos
{
    public class BasketItemDto
    {
        public int Quantity { get; set; }
        public Guid CourseId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
