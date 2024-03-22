using PizzaHub.Areas.Admin.Models.Order;

namespace PizzaHub.Core.ViewModels.Order
{
    public class AllPendingTodayOrdersViewModel
    {
        public AllPendingTodayOrdersViewModel()
        {
            this.Orders = new HashSet<AdminOrderViewmodel>();
        }
        public int OrdersPerPage { get; } = 10;
        public int CurrentPage { get; set; } = 1;
        public int TotalOrdersToday { get; set; }

        public IEnumerable<AdminOrderViewmodel> Orders { get; set; }
    }
}
