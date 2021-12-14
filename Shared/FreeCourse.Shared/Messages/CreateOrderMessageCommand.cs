using System;
using System.Collections.Generic;
using System.Text;

namespace FreeCourse.Shared.Messages
{
    public class CreateOrderMessageCommand
    {

        public Guid BuyerId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string Line { get; set; }
        public CreateOrderMessageCommand()
        {
            OrderItems = new List<OrderItem>();
        }
    }
    public class OrderItem
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
        public double Price { get; set; }
    }
}
