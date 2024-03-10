using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaHub.Infrastructure.Data.Models;

namespace PizzaHub.Infrastructure.Data.SeedDb
{
    public class PaymentMethodsConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            var data = new SeedData();

            builder.HasData(new PaymentMethod[] { data.WithCash, data.WithCard});
        }
    }
}
