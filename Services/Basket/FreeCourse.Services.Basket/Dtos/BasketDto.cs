﻿namespace FreeCourse.Services.Basket.Dtos
{
    public class BasketDto
    {
        public Guid UserId { get; set; }
        public string DiscountCode { get; set; }
        public List<BasketItemDto> basketItems { get; set; }
        public decimal TotalPrice { get => basketItems.Sum(x => x.Price * x.Quantity); }

    }
}
