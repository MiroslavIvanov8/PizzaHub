using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaHub.Areas.Admin.Models.Order;
using PizzaHub.Core.ViewModels.MenuItem;
using PizzaHub.Core.ViewModels.Order;

namespace PizzaHub.Core.Contracts
{
    public interface IOrderService
    {
        Task<bool> CreateOrderFromCartAsync(int customerId, string address, string paymentMethod);
        Task<IEnumerable<string>> GetOrderItemNamesAsync(int orderId);
        Task<IEnumerable<OrderMenuItemWithQuantityViewModel>> GetOrderMenuItemWithQuantityViewmodelAsync(int orderId);

        Task<IEnumerable<string>> GetStatusNamesAsync();
    }
}
