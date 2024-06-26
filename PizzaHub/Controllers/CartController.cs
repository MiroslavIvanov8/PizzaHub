﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaHub.Core.Contracts;
using PizzaHub.Core.ViewModels.Cart;
using PizzaHub.Core.ViewModels.MenuItem;
using PizzaHub.Extensions;

using static PizzaHub.Infrastructure.Constants.MessageConstants.SuccessMessages;
namespace PizzaHub.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CartController : Controller
    {
        private readonly ICartService cartService;
        private readonly ICustomerService customerService;
        private readonly IRestaurantService restaurantService;
        public CartController(ICartService cartService, ICustomerService customerService, IRestaurantService restaurantService)
        {
            this.cartService = cartService;
            this.customerService = customerService;
            this.restaurantService = restaurantService;
           
        }
        

        public async Task<IActionResult> Add(int itemId, int quantity)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Login");
            }

            bool result = await this.cartService.AddToCartAsync(itemId, User.GetUserId(), quantity);

            if (result == false)
            {
                return BadRequest();
            }

            MenuItemViewModel model = await this.restaurantService.GetItemAsync(itemId);

            if (model != null)
            {
                TempData["AddedToCart"] = AddedToCartMessage + quantity + "x  " + model.Name;
            }

            return RedirectToAction("Menu", "Restaurant");
        }

        [HttpGet]
        public async Task<IActionResult> MyCart()
        {
            int customerId = await this.customerService.GetCustomerIdAsync(User.GetUserId());

            ICollection<CartItemViewModel> models = await this.cartService.MyCartAsync(customerId);

            return View(models);
        }

    }
}
