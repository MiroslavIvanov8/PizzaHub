using HouseRentingSystem.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
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
                if (await this.repository.AllReadOnly<CourierApplicationRequest>().AnyAsync(r => r.UserId == userId))
                {
                    return false;
                }

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
