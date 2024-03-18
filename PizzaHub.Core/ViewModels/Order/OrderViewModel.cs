
namespace PizzaHub.Core.ViewModels.Order
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            this.OrderItems = new List<string>();
        }

        public int Id { get; set; }
        public string Restaurant { get; set; }
        public string Status { get; set; }
        public decimal Amount { get; set; }

        public IEnumerable<string> OrderItems { get; set; }
    }
}
