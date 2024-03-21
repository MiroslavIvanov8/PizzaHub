using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaHub.Core.ViewModels.MenuItem;
using PizzaHub.Core.ViewModels.Order;

namespace PizzaHub.Core.Contracts
{
    public interface IOrderService
    {
        Task<bool> CreateOrderFromCartAsync(int customerId, string address, string paymentMethod);
        Task<IEnumerable<string>> GetOrderItemNamesAsync(int orderId);
        Task<IEnumerable<OrderMenuItemWithQuantityViewmodel>> GetOrderMenuItemWithQuantityViewmodelAsync(int orderId);
        Task<IEnumerable<AdminOrderViewmodel>> GetPendingOrdersAsync();
        
    }
}
