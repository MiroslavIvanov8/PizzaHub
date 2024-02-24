namespace PizzaHub.Extensions
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using PizzaHub.Data;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<PizzaHubDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services.AddDefaultIdentity<IdentityUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = config.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
                    options.Password.RequireDigit = config.GetValue<bool>("Identity:Password:RequireDigit");
                    options.Password.RequireNonAlphanumeric = config.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                    options.Password.RequireUppercase = config.GetValue<bool>("Identity:Password:RequireUppercase");
                })
                .AddEntityFrameworkStores<PizzaHubDbContext>();
            return services;
        }
    }
}
