using Microsoft.EntityFrameworkCore;
using PizzaHub.Core.Contracts;
using PizzaHub.Core.ViewModels.Cart;
using PizzaHub.Infrastructure.Common;
using PizzaHub.Infrastructure.Data.Models;

namespace PizzaHub.Core.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository repository;
        private readonly IRestaurantService restaurantService;
        private readonly ICustomerService customerService;
        

        public CartService(IRepository repository,
            IRestaurantService restaurantService,
            ICustomerService customerService)
        {
            this.repository = repository;
            this.restaurantService = restaurantService;
            this.customerService = customerService;
        }

        public async Task<bool> AddToCartAsync(int itemId, string userId , int quantity)
        {
            if (!await this.customerService.CustomerExistsAsync(userId))
            {
                return false;
            }

            if (!await this.restaurantService.MenuItemExistsAsync(itemId))
            {
                return false;
            }

            int customerId = await this.customerService.GetCustomerIdAsync(userId);

            if (await this.repository.AllReadOnly<CustomerCart>()
                    .AnyAsync(cc => cc.CustomerId == customerId && cc.MenuItemId == itemId))
            {
                CustomerCart? existingItem = await this.repository.All<CustomerCart>()
                    .Where(cc => cc.CustomerId == customerId && cc.MenuItemId == itemId)
                    .FirstOrDefaultAsync();

                if (existingItem != null)
                {
                    existingItem.Quantity += quantity;

                    await this.repository.SaveChangesAsync();

                    return true;
                }
            }

            else
            {
                CustomerCart cc = new CustomerCart()
                {
                    CustomerId = customerId,
                    MenuItemId = itemId,
                    Quantity = quantity
                };

                await this.repository.AddAsync(cc);

                await repository.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<ICollection<CartItemViewModel>> MyCartAsync(int customerId)
        {
            ICollection<CartItemViewModel> cartItems = await this.repository.All<CustomerCart>()
                .Where(ci => ci.CustomerId == customerId)
                .Select(i => new CartItemViewModel()
                {   
                    ItemId = i.MenuItemId,
                    Name = i.MenuItem.Name,
                    Price = i.MenuItem.Price,
                    Quantity = i.Quantity
                }).ToListAsync();

            return cartItems;
        }
        
        public async Task<bool> IncreaseCartQuantityAsync(int customerId, int itemId)
        {
            CustomerCart? cartItem = await this.repository.
                All<CustomerCart>()
                .FirstOrDefaultAsync(cc => cc.CustomerId == customerId && cc.MenuItemId == itemId);

            if (cartItem != null)
            {
                cartItem.Quantity++;
                await this.repository.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> DecreaseCartQuantityAsync(int customerId, int itemId)
        {
            CustomerCart? cartItem = await this.repository.
                All<CustomerCart>()
                .FirstOrDefaultAsync(cc => cc.CustomerId == customerId && cc.MenuItemId == itemId);

            if (cartItem != null)
            {
                cartItem.Quantity--;
                await this.repository.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<decimal> CalculateTotalCartSum(int customerId)
        {
            decimal totalCartSum = await this.repository
                                             .AllReadOnly<CustomerCart>()
                                             .Where(cc => cc.CustomerId == customerId)
                                             .SumAsync(i => i.MenuItem.Price * i.Quantity);

            return totalCartSum;
        }

        public async Task<decimal> CalculateItemCartSum(int customerId, int itemId)
        {
            decimal itemCartSum = await this.repository
                .AllReadOnly<CustomerCart>()
                .Where(cc => cc.CustomerId == customerId && cc.MenuItemId == itemId)
                .SumAsync(i => i.MenuItem.Price * i.Quantity);

            return itemCartSum;
        }

        public async Task<bool> DeleteFromCartAsync(int itemId, int customerId)
        {
            var itemToRemove = await this.repository
                .All<CustomerCart>()
                .Where(cc => cc.MenuItemId == itemId && cc.CustomerId == customerId)
                .FirstOrDefaultAsync();

            if (itemToRemove != null)
            {
                bool result = await this.repository.Remove(itemToRemove);

                return true;
            }

            return false;

        }

        
    }
}
