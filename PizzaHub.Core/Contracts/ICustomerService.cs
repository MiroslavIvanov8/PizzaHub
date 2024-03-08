using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHub.Core.Contracts
{
    public interface ICustomerService
    {
        Task<int> GetCustomerId(string userId);
        Task<bool> CustomerExists(string userId);
    }
}
