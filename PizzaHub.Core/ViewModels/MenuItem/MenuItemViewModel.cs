namespace PizzaHub.Core.ViewModels.MenuItem
{
    public class MenuItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
