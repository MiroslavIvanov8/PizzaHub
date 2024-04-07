using Microsoft.AspNetCore.Mvc;
using PizzaHub.Core.Contracts;
using PizzaHub.Extensions;

namespace PizzaHub.Controllers.Api
{
    [Route("api/cart")]
    [ApiController]
    public class CartApiController : ControllerBase
    {
        private readonly ICartService cartService;
        private readonly ICustomerService customerService;

        public CartApiController(ICartService cartService, ICustomerService customerService)
        {
            this.cartService = cartService;
            this.customerService = customerService;
        }

        [HttpGet("increase")]
        public async Task<IActionResult> IncreaseAsync(int itemId)
        {
            int customerId = await this.customerService.GetCustomerIdAsync(User.GetUserId());
            bool result = await this.cartService.IncreaseCartQuantityAsync(customerId, itemId);
            if (result == false)
            {
                return BadRequest();
            }

            
            return Ok(new {totalSum = 22 ,itemPrice = 6});
        }

        //[HttpPost]
        //public Task<IActionResult> DecreaseAsync(int customerId, int itemId)
        //{
        //    return Ok();
        //}
    }
}
