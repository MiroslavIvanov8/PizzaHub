using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaHub.Areas.Admin.Models.Order;

namespace PizzaHub.Core.ViewModels.Order
{
    public class AllTodayOrdersViewModel
    {
        public AllTodayOrdersViewModel()
        {
            this.Orders = new HashSet<ShowOrderViewModel>();
        }
        public int OrdersPerPage { get; } = 10;
        public int CurrentPage { get; set; } = 1;
        public int TotalOrdersToday { get; set; }

        public IEnumerable<ShowOrderViewModel> Orders { get; set; }
    }
}
