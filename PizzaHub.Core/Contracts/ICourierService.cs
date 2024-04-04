using PizzaHub.Core.ViewModels.Order;
using PizzaHub.Infrastructure.Data.Models;

namespace PizzaHub.Core.Contracts
{
    public interface ICourierService
    {
        Task<bool> CreateApplicationRequestAsync(string userId, string phoneNumber, string description);

        Task<bool> IsApplicantInLegalAge(string userId);

        Task<OrderQueryServiceModel> ShowInProgressOrdersAsync(int currentPage, int ordersPerPage);
        Task<bool> PickOrderAsync(int orderId, int courierId);
        Task<int> GetCourierId(string userId);
        Task<IEnumerable<DetailedOrderViewModel>> ShowPickedOrdersAsync(int courierId);

        Task<bool> MarkOrderDelivered(int orderId);
    }
}
