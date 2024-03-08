using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PizzaHub.Core.Contracts;
using PizzaHub.Infrastructure.Data.Models;

namespace PizzaHub.Core.Interfaces
{
    public class OrderService : IOrderService
    {
        private readonly IOrderService orderService;

        public OrderService(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        public Task<int> Create(int customerId,int pizzaId, int quantity)
        {
            Order order = new Order()
            {
                CustomerId = customerId,

            };

            return null;
        }
    }
}
