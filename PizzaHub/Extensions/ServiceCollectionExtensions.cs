namespace PizzaHub.Extensions
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using Core.Services;
    using Authorization;
    using Infrastructure;
    using Core.Contracts;
    using Infrastructure.Common;
    using Infrastructure.Data.Models;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICourierService, CourierService>();

            services.AddScoped<ISendGridEmailSender, SendGridEmailSender>(provider =>
            {
                var apiKey =
                    Environment.GetEnvironmentVariable(
                        "SENDGRID_API_KEY"); 
                return new SendGridEmailSender(apiKey);
            });

            services.AddScoped<IAuthorizationHandler, CustomerOnlyAuthorizationHandler>();
            
            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        { 
            var connectionString = config.GetConnectionString("PizzaHubDbContextConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<PizzaHubDbContext>(options =>
                {
                    options.UseSqlServer(connectionString);
                    options.UseLazyLoadingProxies();
                }
            );
            services.AddScoped<IRepository, Repository>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                    options.SignIn.RequireConfirmedAccount = true;
                        //config.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
                    options.Password.RequireDigit = 
                        config.GetValue<bool>("Identity:Password:RequireDigit");
                    options.Password.RequireNonAlphanumeric =
                        config.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                    options.Password.RequireUppercase =
                        config.GetValue<bool>("Identity:Password:RequireUppercase");
                })
                .AddRoles<IdentityRole>()
                .AddDefaultTokenProviders()
                .AddDefaultUI()
                .AddEntityFrameworkStores<PizzaHubDbContext>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CustomerOnlyPolicy", policy =>
                    policy.Requirements.Add(new CustomerOnlyRequirement()));
            });

            services.AddRazorPages();

            return services;
        }
    }
}
