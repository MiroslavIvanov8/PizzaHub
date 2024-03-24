﻿using PizzaHub.Areas.Admin.Models.Order;
using PizzaHub.Infrastructure.Enums;

namespace PizzaHub.Core.ViewModels.Order
{
    public class AllOrdersViewModel
    {
        public AllOrdersViewModel()
        {
            this.Orders = new HashSet<AdminOrderViewmodel>();
        }

        public string Status { get; set; } = "All";
        public FilterDays FilterDays { get; set; }  
        public int OrdersPerPage { get; } = 10;
        public int CurrentPage { get; set; } = 1;
        public int TotalOrders { get; set; }

        public IEnumerable<string> Statuses { get; set; }
        public IEnumerable<int> DaysRange { get; set; }
        public IEnumerable<AdminOrderViewmodel> Orders { get; set; }
    }
}