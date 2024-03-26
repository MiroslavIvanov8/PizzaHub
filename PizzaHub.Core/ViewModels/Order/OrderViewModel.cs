﻿
namespace PizzaHub.Core.ViewModels.Order
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            this.OrderItems = new List<string>();
        }

        public int Id { get; set; }
        public string Restaurant { get; set; } = null!;
        public string Status { get; set; } = null!;
        public decimal Amount { get; set; }
        public string CreatedOn { get; set; } = null!;
        public int Quantity { get; set; }

        public IEnumerable<string> OrderItems { get; set; }

    }
}
