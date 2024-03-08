using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHub.Core.Contracts
{
    public interface IOrderService
    {
        Task<int> Create(int customerId, int pizzaId, int quantity);
    }
}
