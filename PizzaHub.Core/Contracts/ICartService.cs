using PizzaHub.Core.ViewModels;
using PizzaHub.Core.ViewModels.Cart;
using PizzaHub.Infrastructure.Data.Models;

namespace PizzaHub.Core.Contracts
{
    public interface ICartService
    {
        //TODO fix pizzaId name to itemId
        Task<bool> AddToCartAsync(int pizzaId, string userId, int quantity);
        Task<ICollection<CartItemViewModel>> MyCartAsync(int customerId);
        Task<bool> DeleteFromCartAsync(int itemId, int customerId);
        Task<bool> IncreaseCartQuantityAsync(int customerId, int itemId);
        Task<bool> DecreaseCartQuantityAsync(int customerId, int itemId);
        Task<decimal> CalculateTotalCartSum(int customerId);
        Task<decimal> CalculateItemCartSum(int customerId, int itemId);
    }
}
