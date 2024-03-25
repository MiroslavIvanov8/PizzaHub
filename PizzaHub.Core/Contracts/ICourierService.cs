using PizzaHub.Infrastructure.Data.Models;

namespace PizzaHub.Core.Contracts
{
    public interface ICourierService
    {
        Task<bool> CreateApplicationRequestAsync(string userId, string phoneNumber, string description);
    }
}
