using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCourse.Services.Order.Application.Dtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public AddressDto Address { get; set; }
        public Guid BuyerId { get; set; }

        private  List<OrderItemDto> OrderItems { get; set; }
    }
}
