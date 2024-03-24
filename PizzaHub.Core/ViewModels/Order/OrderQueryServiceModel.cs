namespace PizzaHub.Core.ViewModels.Order
{
    public class OrderQueryServiceModel
    {
        public OrderQueryServiceModel()
        {
            this.Orders = new HashSet<AdminOrderViewmodel>();
        }
        public int OrdersCount { get; set; }
        public IEnumerable<AdminOrderViewmodel> Orders { get; set; }
    }
}
