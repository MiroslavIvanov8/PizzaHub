namespace PizzaHub.Core.Interfaces.Restaurant
{
    using Microsoft.EntityFrameworkCore;

    using ViewModels.MenuItem;
    using Infrastructure;
    using PizzaHub.Core.Contracts.Restaurant;

    public class RestaurantService : IRestaurantService
    {
        private readonly PizzaHubDbContext dbContext;

        public RestaurantService(PizzaHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<MenuItemViewModel>> GetMenu()
        {
            return await dbContext.MenuItems.Select(i => new MenuItemViewModel()
            {
                Id = i.Id,
                Name = i.Name,
                ImageUrl = i.ImageUrl,
                Price = i.Price
            })
                .ToListAsync();
        }
    }
}
