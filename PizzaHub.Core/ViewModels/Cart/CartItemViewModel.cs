namespace PizzaHub.Core.ViewModels.Cart
{
    public class CartItemViewModel
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
