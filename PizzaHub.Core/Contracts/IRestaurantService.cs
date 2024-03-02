using PizzaHub.Core.ViewModels.MenuItem;

namespace PizzaHub.Core.Contracts
{
    public interface IRestaurantService
    {
        public Task<IEnumerable<MenuItemViewModel>> GetMenu();
    }
}
