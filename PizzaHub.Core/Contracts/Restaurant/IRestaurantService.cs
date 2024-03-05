using PizzaHub.Core.ViewModels.MenuItem;

namespace PizzaHub.Core.Contracts.Restaurant
{
    public interface IRestaurantService
    {
        public Task<IEnumerable<MenuItemViewModel>> GetMenu();
    }
}
