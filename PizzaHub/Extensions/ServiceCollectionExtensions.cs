﻿using Microsoft.AspNetCore.Identity.UI.Services;
using PizzaHub.Core.Contracts.Messages;
using PizzaHub.Core.Interfaces.Messages;
using IEmailSender = Microsoft.AspNetCore.Identity.UI.Services.IEmailSender;

namespace PizzaHub.Extensions
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using Infrastructure;
    using PizzaHub.Core.Contracts.Restaurant;
    using PizzaHub.Core.Interfaces.Restaurant;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<ISenderEmail, EmailSender>();
            
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
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
                {
                    options.SignIn.RequireConfirmedAccount =
                        config.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
                    options.Password.RequireDigit = config.GetValue<bool>("Identity:Password:RequireDigit");
                    options.Password.RequireNonAlphanumeric =
                        config.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                    options.Password.RequireUppercase = config.GetValue<bool>("Identity:Password:RequireUppercase");
                })
                .AddDefaultTokenProviders()
                .AddDefaultUI()
                .AddEntityFrameworkStores<PizzaHubDbContext>();
            services.AddRazorPages();

            return services;
        }
    }
}
