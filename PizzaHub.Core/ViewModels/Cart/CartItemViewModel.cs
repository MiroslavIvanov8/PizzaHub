namespace PizzaHub.Core.ViewModels.Cart
{
    public class CartItemViewModel
    {
        public int ItemId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
