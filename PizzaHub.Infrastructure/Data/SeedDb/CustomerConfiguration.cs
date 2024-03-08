using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaHub.Infrastructure.Data.Models;

namespace PizzaHub.Infrastructure.Data.SeedDb
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            var data = new SeedData();

            builder.HasData(new Customer[] { data.Customer});
        }
    }
}
