using PizzaHub.Areas.Admin.Models.Order;

namespace PizzaHub.Core.ViewModels.Order
{
    public class AllOrdersViewModel
    {
        public AllOrdersViewModel()
        {
            this.Orders = new HashSet<AdminOrderViewmodel>();
        }

        public string Status { get; set; } = "All";
        public int Days { get; set; } = 0;
        public int OrdersPerPage { get; } = 10;
        public int CurrentPage { get; set; } = 1;
        public int TotalOrdersToday { get; set; }

        public IEnumerable<AdminOrderViewmodel> Orders { get; set; }
    }
}
