using Castle.Core.Resource;
using HouseRentingSystem.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using PizzaHub.Core.Contracts;
using PizzaHub.Core.ViewModels.Cart;
using PizzaHub.Infrastructure.Data.Models;

namespace PizzaHub.Core.Interfaces
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

        public async Task<CustomerCart> AddToCartAsync(int itemId, string userId , int quantity)
        {
            if (!await this.customerService.CustomerExistsAsync(userId))
            {
                return null;
            }

            if (!await this.restaurantService.MenuItemExistsAsync(itemId))
            {
                return null;
            }

            int customerId = await this.customerService.GetCustomerIdAsync(userId);

            // check if there is an existing item in the cart if so just add the new quantity to the existing record
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

                    return existingItem;
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

                return cc;
            }

            return null;
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
        public async Task<decimal> UpdateQuantityAsync(int itemId, int newQuantity, int customerId)
        {
            var itemToUpdate = await this.repository
                                                    .All<CustomerCart>()
                                                    .Where(cc => cc.MenuItemId == itemId && cc.CustomerId == customerId)
                                                    .FirstOrDefaultAsync();
            if (itemToUpdate != null)
            {
                itemToUpdate.Quantity = newQuantity;
                await this.repository.SaveChangesAsync();
            }

            // Calculate the total amount of the cart
            decimal totalAmount = await this.repository
                    .AllReadOnly<CustomerCart>()
                    .Where(cc => cc.CustomerId == customerId)
                    .Include(cc => cc.MenuItem)
                    .SumAsync(cc => cc.Quantity * cc.MenuItem.Price);

            return totalAmount;
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
