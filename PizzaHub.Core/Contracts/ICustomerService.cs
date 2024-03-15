using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaHub.Core.ViewModels.Order;

namespace PizzaHub.Core.Contracts
{
    public interface ICustomerService
    {
        Task<int> GetCustomerId(string userId);
        Task<bool> CustomerExists(string userId);

        Task<IEnumerable<OrderViewModel>> ShowOrders(int userId);
    }
}
