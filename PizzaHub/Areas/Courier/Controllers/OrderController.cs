using Microsoft.AspNetCore.Mvc;
using PizzaHub.Areas.Admin.Models.Order;
using PizzaHub.Core.Contracts;
using PizzaHub.Core.ViewModels.Order;
using PizzaHub.Extensions;

using static PizzaHub.Infrastructure.Constants.MessageConstants.AppEmailConstants;
using static PizzaHub.Infrastructure.Constants.MessageConstants.SuccessMessages;
namespace PizzaHub.Areas.Courier.Controllers
{
    public class OrderController : CourierBaseController
    {
        private readonly ICourierService courierService;
        private readonly IOrderService orderService;

        public OrderController(ICourierService courierService, IOrderService orderService)
        {
            this.courierService = courierService;
            this.orderService = orderService;
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

        [HttpGet]
        public async Task<IActionResult> ShowPickedOrders()
        {
            var pickedOrders = await this.courierService.ShowPickedOrdersAsync(await this.courierService.GetCourierId(User.GetUserId()));
            
            return View(pickedOrders);
        }

        [HttpGet]
        public async Task<IActionResult> ViewOrderDetails(int orderId)
        {
            DetailedOrderViewModel? detailedOrder = await this.orderService.GetDetailedOrderViewModelAsync(orderId);

            if (detailedOrder == null)
            {
                return BadRequest();
            }

            return View(detailedOrder);
        }

        [HttpGet]
        public async Task<IActionResult> ShowTodayDelivered()
        {
            int courierId = await this.courierService.GetCourierId(User.GetUserId());

            IEnumerable<ShowOrderViewModel> ordersToday = await this.courierService.ShowTodayDelivered(courierId);

            return View(ordersToday);
        }
    }
}
