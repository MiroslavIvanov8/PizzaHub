namespace PizzaHub.Core.ViewModels.MenuItem
{
    public class OrderMenuItemWithQuantityViewmodel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
