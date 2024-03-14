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
            if (!await this.customerService.CustomerExists(userId))
            {
                return null;
            }

            if (!await this.restaurantService.MenuItemExists(itemId))
            {
                return null;
            }

            int customerId = await this.customerService.GetCustomerId(userId);

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

        public async Task<ICollection<CartItemViewModel>> MyCartAsync(int customerId)
        {
            ICollection<CartItemViewModel> cartItems = await this.repository.All<CustomerCart>()
                .Where(ci => ci.CustomerId == customerId)
                .Select(i => new CartItemViewModel()
                {
                    Name = i.MenuItem.Name,
                    Price = i.MenuItem.Price,
                    Quantity = i.Quantity
                }).ToListAsync();

            return cartItems;
        }
    }
}
