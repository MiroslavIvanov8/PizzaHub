using Microsoft.AspNetCore.Mvc;
using PizzaHub.Core.Contracts;

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
        public async Task<IActionResult> ShowOrders(int customerId)
        {
            return View(await this.customerService.ShowOrders(customerId));
        }
    }
}
