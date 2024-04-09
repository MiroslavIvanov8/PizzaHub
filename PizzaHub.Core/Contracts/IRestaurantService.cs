using PizzaHub.Core.ViewModels.MenuItem;

namespace PizzaHub.Core.Contracts
{
    public interface IRestaurantService
    {
        public Task<IEnumerable<MenuItemViewModel>> GetMenuAsync(string? searchTerm);

        public Task<MenuItemViewModel> GetItemAsync(int id);

        public Task<bool> MenuItemExistsAsync(int id);

        public Task<IEnumerable<MenuItemWithImageAndQuantity>> ShowBestSellersAsync();

    }
}
