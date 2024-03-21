using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaHub.Core.ViewModels.MenuItem;

namespace PizzaHub.Core.ViewModels.Order
{
    public class AdminOrderViewmodel
    {
        public AdminOrderViewmodel()
        {
            this.OrderItems = new List<OrderMenuItemWithQuantityViewmodel>();
        }

        public int Id { get; set; }
        public string Restaurant { get; set; } = null!;
        public string Customer { get; set; } = null!;
        public string Address { get; set; } = null!;

        public string Status { get; set; } = null!;
        public decimal Amount { get; set; }

        public string CreatedOn { get; set; } = null!;

        public IEnumerable<OrderMenuItemWithQuantityViewmodel> OrderItems { get; set; }
    }
}
