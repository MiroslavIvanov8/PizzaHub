using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaHub.Core.ViewModels.MenuItem;
using PizzaHub.Core.ViewModels.Order;

namespace PizzaHub.Core.Contracts
{
    public interface ICustomerService
    {
        Task<int> GetCustomerIdAsync(string userId);
        Task<bool> CustomerExistsAsync(string userId);
        Task<IEnumerable<OrderViewModel>> ShowOrdersAsync(int userId);
    }
}
