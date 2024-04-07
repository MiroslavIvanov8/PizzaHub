using PizzaHub.Core.ViewModels.Order;

namespace PizzaHub.Core.ViewModels.MenuItem
{
    public class OrderMenuItemWithQuantityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
