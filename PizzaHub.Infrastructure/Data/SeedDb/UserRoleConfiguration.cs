using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PizzaHub.Infrastructure.Data.SeedDb
{
    internal class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            var data = new SeedData();

            builder.HasData(new IdentityUserRole<string>[] { data.UserAdmin, data.UserCourier, data.UserCustomer });
        }
    }
}
