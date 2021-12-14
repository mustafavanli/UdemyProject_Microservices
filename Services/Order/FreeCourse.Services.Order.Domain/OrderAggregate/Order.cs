using FreeCourse.Services.Order.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCourse.Services.Order.Domain.OrderAggregate
{
    public class Order:Entity,IAggregateRoot
    {
        public DateTime CreatedTime { get;private set; }
        public Address Address { get; private set; }
        public Guid BuyerId { get; private set; }
        private readonly List<OrderItem> _orderItems;

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;
        public Order()
        {

        }
        public Order(Address adress, Guid buyerId)  
        {
            _orderItems = new List<OrderItem>();
            CreatedTime = DateTime.Now;
            Address = adress;
            BuyerId = buyerId;
        }

        public void AddOrderItem(Guid productId,string productName,string pictureUrl,double price)
        {
            var existProduct = _orderItems.Any(x => x.ProductId == productId);
            if (!existProduct)
            {
                var newOrderItem = new OrderItem(productId,productName,pictureUrl,price);
                _orderItems.Add(newOrderItem);
            }
        }

        public double GetTotalPrice => _orderItems.Sum(x => x.Price);

    }
}
