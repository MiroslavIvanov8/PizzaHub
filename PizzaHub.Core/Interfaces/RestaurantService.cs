namespace PizzaHub.Core.Interfaces
{
    using Microsoft.EntityFrameworkCore;

    using ViewModels.MenuItem;
    using Infrastructure;
    using PizzaHub.Core.Contracts;

    public class RestaurantService : IRestaurantService
    {
        private readonly PizzaHubDbContext dbContext;

        public RestaurantService(PizzaHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<MenuItemViewModel>> GetMenuAsync()
        {
            return await dbContext.MenuItems.Select(i => new MenuItemViewModel()
            {
                Id = i.Id,
                Name = i.Name,
                Ingredients = i.Ingredients,
                ImageUrl = i.ImageUrl,
                Price = i.Price
            })
                .ToListAsync();
        }

        public async Task<MenuItemViewModel> GetItemAsync(int id)
        { 
            MenuItemViewModel? model = await this.dbContext.MenuItems
                .Select(i => new MenuItemViewModel()
                {
                    Id = i.Id,
                    Name = i.Name,
                    ImageUrl = i.ImageUrl,
                    Price = i.Price
                }).FirstOrDefaultAsync(i => i.Id == id);

            return model;
        }

        public async Task<bool> MenuItemExists(int id)
        {
            return await this.dbContext.MenuItems.AnyAsync(m => m.Id == id);
        }
    }
}
