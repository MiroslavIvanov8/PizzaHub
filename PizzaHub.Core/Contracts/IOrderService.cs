using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHub.Core.Contracts
{
    public interface IOrderService
    {
        Task<bool> CreateOrderFromCartAsync(int customerId, string address, string paymentMethod);
        Task<IEnumerable<string>> GetOrderItemNamesAsync(int orderId);
    }
}
