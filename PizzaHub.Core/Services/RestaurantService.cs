using Microsoft.EntityFrameworkCore;
using PizzaHub.Core.Contracts;
using PizzaHub.Core.ViewModels.MenuItem;
using PizzaHub.Infrastructure.Common;
using PizzaHub.Infrastructure.Data.Models;

namespace PizzaHub.Core.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRepository repository;

        public RestaurantService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<MenuItemViewModel>> GetMenuAsync()
        {
            return await this.repository.AllReadOnly<MenuItem>().Select(i => new MenuItemViewModel()
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
            MenuItemViewModel? model = await this.repository.AllReadOnly<MenuItem>()
                .Select(i => new MenuItemViewModel()
                {
                    Id = i.Id,
                    Name = i.Name,
                    ImageUrl = i.ImageUrl,
                    Price = i.Price
                }).FirstOrDefaultAsync(i => i.Id == id);

            return model;
        }

        public async Task<bool> MenuItemExistsAsync(int id)
        {
            return await this.repository.AllReadOnly<MenuItem>().AnyAsync(m => m.Id == id);
        }
    }
}
