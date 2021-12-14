namespace FreeCourse.Services.FakePayment.Models
{
    public class OrderDto
    {
        public Guid BuyerId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public AddressDto Adress { get; set; }
        public OrderDto()
        {
            OrderItems = new List<OrderItemDto>(); 
        }
    }
    public class AddressDto
    {
        public string Province { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string Line { get; set; }

    }
    public class OrderItemDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
        public double Price { get; set; }

    }
}
