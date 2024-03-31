using PizzaHub.Core.ViewModels.Courier;
using PizzaHub.Core.ViewModels.MenuItem;
using PizzaHub.Infrastructure.Data.Models;

namespace PizzaHub.Core.Contracts
{
    
    using ViewModels.Order;
    using Infrastructure.Enums;

    public interface IAdminService
    {
        Task<MenuItemFormModel?> GetMenuItemFormAsync(int id);
        Task MarkOrderAcceptedAsync(int orderId);
        Task<OrderQueryServiceModel> GetAllOrdersAsync(string status,FilterDays filterDays, int currentPage = 1 , int ordersPerPage = 10);

        Task<OrderQueryServiceModel> GetPendingOrdersAsync(int currentPage = 1 , int ordersPerPage = 10);

        Task<IEnumerable<CourierApplicantModel>> GetAllCourierApplicantsAsync();
        Task<CourierApplicantModel> GetCourierApplicantsAsync(int id);

        Task<bool> ApproveCourierApplicationAsync(int id);

        Task<bool> DeclineCourierApplicationAsync(int id);

        Task<int> AddMenuItemAsync(MenuItemFormModel model);
        Task<int> EditMenuItemAsync(MenuItemFormModel model);
    }
}
