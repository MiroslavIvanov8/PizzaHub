using HouseRentingSystem.Infrastructure.Data.Common;
using PizzaHub.Core.Contracts;
using PizzaHub.Infrastructure.Data.Models;

namespace PizzaHub.Core.Interfaces
{
    public class CourierService : ICourierService
    {
        private readonly IRepository repository;

        public CourierService(IRepository repository)
        {
            this.repository = repository;
        }
        public async Task<bool> CreateApplicationRequestAsync(string userId, string phoneNumber, string description)
        {
            try
            {
                CourierApplicationRequest request = new CourierApplicationRequest()
                {
                    UserId = userId,
                    Description = description,
                    PhoneNumber = phoneNumber
                };

                await this.repository.AddAsync(request);
                await this.repository.SaveChangesAsync();

                return true; 
            }
            catch (Exception ex)
            {
                return false; 
            }
        }
    }
}
