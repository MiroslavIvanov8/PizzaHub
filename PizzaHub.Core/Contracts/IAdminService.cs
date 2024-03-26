using PizzaHub.Core.ViewModels.Courier;

namespace PizzaHub.Core.Contracts
{
    
    using ViewModels.Order;
    using Infrastructure.Enums;

    public interface IAdminService
    {
        Task MarkOrderAcceptedAsync(int orderId);
        Task<OrderQueryServiceModel> GetAllOrdersAsync(string status,FilterDays filterDays, int currentPage = 1 , int ordersPerPage = 10);

        Task<OrderQueryServiceModel> GetPendingOrdersAsync(int currentPage = 1 , int ordersPerPage = 10);

        Task<IEnumerable<CourierApplicantModel>> GetAllCourierApplicantsAsync();
        Task<CourierApplicantModel> GetCourierApplicant(int id);

    }
}
