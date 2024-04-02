using PizzaHub.Core.ViewModels.MenuItem;

namespace PizzaHub.Core.ViewModels.Order
{
    public class DetailedOrderViewModel
    {
        public DetailedOrderViewModel()
        {
            OrderItems = new List<OrderMenuItemWithQuantityViewModel>();
        }

        public int Id { get; set; }
        public string Restaurant { get; set; } = null!;
        public string Customer { get; set; } = null!;
        public string Address { get; set; } = null!;

        public string Status { get; set; } = null!;
        public decimal Amount { get; set; }

        public string CreatedOn { get; set; } = null!;

        public IEnumerable<OrderMenuItemWithQuantityViewModel> OrderItems { get; set; }
    }
}
