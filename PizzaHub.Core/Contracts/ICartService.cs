using PizzaHub.Core.ViewModels;
using PizzaHub.Core.ViewModels.Cart;
using PizzaHub.Infrastructure.Data.Models;

namespace PizzaHub.Core.Contracts
{
    public interface ICartService
    {
        Task<CustomerCart> AddToCartAsync(int pizzaId, string userId, int quantity);

        Task<ICollection<CartItemViewModel>> MyCartAsync(int customerId);
    }
}
