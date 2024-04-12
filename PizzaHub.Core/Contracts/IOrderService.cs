using PizzaHub.Core.ViewModels.MenuItem;
using PizzaHub.Core.ViewModels.Order;
using PizzaHub.Infrastructure.Data.Models;

namespace PizzaHub.Core.Contracts
{
    public interface IOrderService
    {
        Task<bool> CreateOrderFromCartAsync(int customerId, string address, string paymentMethod);
        Task<IEnumerable<string>> GetOrderItemNamesAsync(int orderId);
        Task<IEnumerable<OrderMenuItemWithQuantityViewModel>> GetOrderMenuItemWithQuantityViewmodelAsync(int orderId);

        Task<IEnumerable<string>> GetStatusNamesAsync();
        Task<Order?> GetOrderAsync(int id);
        Task<DetailedOrderViewModel?> GetDetailedOrderViewModelAsync(int id);
        Task<IEnumerable<DetailedOrderViewModel>> GetAllDetailedOrdersViewModelAsync(IEnumerable<Order> orders);
    }
}
