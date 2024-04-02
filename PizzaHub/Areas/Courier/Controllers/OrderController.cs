using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaHub.Core.Contracts;
using PizzaHub.Core.ViewModels.Order;
using PizzaHub.Extensions;

namespace PizzaHub.Areas.Courier.Controllers
{
    [Area("Courier")]
    [Authorize(Roles = "Courier")]
    public class OrderController : Controller
    {
        private readonly ICourierService courierService;
        public OrderController(ICourierService courierService)
        {
            this.courierService = courierService;
        }

        [HttpGet]
        public async Task<IActionResult> PickOrders([FromQuery]AllOrdersViewModel model)
        {
            OrderQueryServiceModel inProgressOrders = await this.courierService.ShowInProgressOrdersAsync(model.CurrentPage,model.OrdersPerPage);

            model.Orders = inProgressOrders.Orders;
            model.TotalOrders = inProgressOrders.OrdersCount;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> PickOrder(int id)
        {
            int courierId = await this.courierService.GetCourierId(User.GetUserId());
            bool result = await this.courierService.PickOrderAsync(id, courierId);

            if (result == false)
            {
                return BadRequest();
            }

            return RedirectToAction("PickOrders");
        }
    }
}
