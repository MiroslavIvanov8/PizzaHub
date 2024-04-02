namespace PizzaHub.Core.ViewModels.Order
{
    public class OrderQueryServiceModel
    {
        public OrderQueryServiceModel()
        {
            this.Orders = new HashSet<DetailedOrderViewModel>();
        }
        public int OrdersCount { get; set; }
        public IEnumerable<DetailedOrderViewModel> Orders { get; set; }
    }
}
