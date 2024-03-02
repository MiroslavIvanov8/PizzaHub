namespace PizzaHub.Core.Interfaces
{
    using Microsoft.EntityFrameworkCore;

    using Contracts;
    using ViewModels.MenuItem;
    using Infrastructure;

    public class RestaurantService : IRestaurantService
    {
        private readonly PizzaHubDbContext dbContext;

        public RestaurantService(PizzaHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<MenuItemViewModel>> GetMenu()
        {
            return await this.dbContext.MenuItems.Select(i => new MenuItemViewModel()
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
