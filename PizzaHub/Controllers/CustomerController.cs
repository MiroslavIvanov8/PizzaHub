using Microsoft.AspNetCore.Mvc;
using PizzaHub.Core.Contracts;
using PizzaHub.Extensions;

namespace PizzaHub.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;
        

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> ShowPastOrders()
        {
            int customerId = await this.customerService.GetCustomerIdAsync(User.GetUserId());

            return View(await this.customerService.ShowPastOrdersAsync(customerId));
        }

        [HttpGet]
        public async Task<IActionResult> TrackOrders()
        {
            int customerId = await this.customerService.GetCustomerIdAsync(User.GetUserId());

            return View(await this.customerService.ShowOngoingOrdersAsync(customerId));
        }
    }
}
