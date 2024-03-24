using PizzaHub.Areas.Admin.Models.Order;
using PizzaHub.Core.ViewModels.Order;

namespace PizzaHub.Core.Contracts
{
    public interface IAdminService
    {
        Task MarkOrderAcceptedAsync(int orderId);
        Task<IEnumerable<AdminOrderViewmodel>> GetAllOrdersAsync(string status,int days, int currentPage = 1 , int ordersPerPage = 10);

        Task<IEnumerable<AdminOrderViewmodel>> GetPendingOrdersAsync(int currentPage = 1 , int ordersPerPage = 10);
    }
}
