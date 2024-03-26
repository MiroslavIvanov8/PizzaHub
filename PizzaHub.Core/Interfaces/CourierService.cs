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
                if (await this.IsApplicantInLegalAge(userId))
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

                return false;
            }
            catch (Exception ex)
            {
                return false; 
            }
        }

        public async Task<bool> IsApplicantInLegalAge(string userId)
        {
            ApplicationUser? user = await this.repository.AllReadOnly<ApplicationUser>()
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user != null)
            {
                
                DateTime legalAgeDate = DateTime.Today.AddYears(-18);
                
                return user.BirthDate <= legalAgeDate;
            }

            // Return false if user is not found
            return false;
        }
    }
}
