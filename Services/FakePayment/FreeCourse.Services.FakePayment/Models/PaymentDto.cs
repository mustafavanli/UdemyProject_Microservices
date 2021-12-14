﻿namespace FreeCourse.Services.FakePayment.Models
{
    public class PaymentDto
    {
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public string CVV { get; set; }
        public string TotalPrice { get; set; }
        public OrderDto Order { get; set; }
    }
}
