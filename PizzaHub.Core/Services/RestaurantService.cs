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

        public async Task<IEnumerable<MenuItemViewModel>> GetMenuAsync(string searchTerm)
        {
            var models = await this.repository.AllReadOnly<MenuItem>()
                .Where(i => i.IsDeleted == false)
                .Select(i => new MenuItemViewModel()
            {
                Id = i.Id,
                Name = i.Name,
                Ingredients = i.Ingredients,
                ImageUrl = i.ImageUrl,
                Price = i.Price
            })
                .ToListAsync();

            if (searchTerm != null)
            {
                searchTerm = searchTerm.ToLower();

                models = models.Where(m => m.Name.ToLower().Contains(searchTerm) ||
                                           m.Ingredients.ToLower().Contains(searchTerm))
                    .ToList();
            }


            return models;
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

        public async Task<IEnumerable<MenuItemWithImageAndQuantity>> ShowBestSellersAsync()
        {
            var bestSellers = await this.repository
                .AllReadOnly<OrderItem>()
                .GroupBy(oi => oi.MenuItemId)
                .Select(g => new
                {
                    MenuItemId = g.Key,
                    Quantity = g.Sum(oi => oi.Quantity)

                })
                .OrderByDescending(x => x.Quantity)
                .Take(3)
                .ToListAsync();

            var bestSellingItems =this.repository
                .AllReadOnly<MenuItem>()
                .ToList()
                .Where(mi => bestSellers.Any(bs => bs.MenuItemId == mi.Id))
                .Select(mi => new MenuItemWithImageAndQuantity()
                {
                    Id = mi.Id,
                    Name = mi.Name,
                    ImageUrl = mi.ImageUrl
                })
                .ToList();
            
            return bestSellingItems;
        }
    }
}
