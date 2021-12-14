using FreeCourse.Services.Order.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCourse.Services.Order.Domain.OrderAggregate
{
    public class OrderItem:Entity
    {
        public Guid ProductId { get;private set; }
        public string ProductName { get; private set; }
        public string PictureUrl { get; private set; }
        public double Price { get; private set; }
        public OrderItem()
        {

        }
        public OrderItem(Guid productId, string productName, string pictureUrl, double price)
        {
            ProductId = productId;
            ProductName = productName;
            PictureUrl = pictureUrl;
            Price = price;
        }

        public void UpdateOrderItem(string productName,string pictureUrl,double price)
        {
            ProductName = productName;
            PictureUrl = pictureUrl;
            Price = price;

        }
    }
}
