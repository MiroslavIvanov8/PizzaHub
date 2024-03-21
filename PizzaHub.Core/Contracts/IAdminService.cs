using PizzaHub.Core.ViewModels.Order;

namespace PizzaHub.Core.Contracts
{
    public interface IAdminService
    {
        Task MarkOrderAcceptedAsync(int orderId);
        Task<IEnumerable<ShowOrderViewModel>> ShowTodayOrdersAsync();
    }
}
