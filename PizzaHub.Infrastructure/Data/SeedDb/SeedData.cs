using Microsoft.AspNetCore.Identity;
using PizzaHub.Infrastructure.Data.Models;

namespace PizzaHub.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
        public Restaurant Restaurant { get; set; }

        public IdentityUser CustomerUser { get; set; }

        public IdentityUser CourierUser { get; set; }

        public IdentityUser AdminUser { get; set; }

        public Customer Customer { get; set; }
        public Courier Courier { get; set; }
        public Admin Admin { get; set; }

        public MenuItem FirstItem { get; set; }
        public MenuItem SecondItem { get; set; }
        public MenuItem ThirdItem { get; set; }

        public OrderStatus FirstStatus { get; set; }
        public OrderStatus SecondStatus { get; set; }
        public OrderStatus ThirdStatus { get; set; }
        public OrderStatus ForthStatus { get; set; }

        public IdentityRole AdminRole { get; set; }

        public IdentityRole CourierRole { get; set; }

        public IdentityRole CustomerRole { get; set; }

        public IdentityUserRole<string> UserCustomer { get; set; }
        public IdentityUserRole<string> UserCourier { get; set; }

        public IdentityUserRole<string> UserAdmin { get; set; }

        public SeedData()
        {
            SeedUsers();
            SeedCustomer();
            SeedCourier();
            SeedAdmin();
            SeedRestaurant();
            SeedMenuItems();
            SeedOrderStatuses();
            SeedRoles();
            SeedUserRoles();
        }

        
        private void SeedOrderStatuses()
        {
            FirstStatus = new OrderStatus()
            {
                Id = 1,
                Name = "In Progress"
            };

            SecondStatus = new OrderStatus()
            {
                Id = 2,
                Name = "Out for Delivery"
            };

            ThirdStatus = new OrderStatus()
            {
                Id = 3,
                Name = "Delivered"
            };

            ForthStatus = new OrderStatus()
            {
                Id = 4,
                Name = "Canceled"
            };
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            AdminUser = new IdentityUser()
            {
                Id = "00000856-c198-4129-b3f3-b893d8395082",
                UserName = "admin@mail.com",
                NormalizedUserName = "admin@mail.com",
                Email = "admin@mail.com",
                NormalizedEmail = "admin@mail.com"
            };

            AdminUser.PasswordHash =
                hasher.HashPassword(AdminUser, "admin123");

            CourierUser = new IdentityUser()
            {
                Id = "11111856-c198-4129-b3f3-b893d8395082",
                UserName = "courier@mail.com",
                NormalizedUserName = "courier@mail.com",
                Email = "courier@mail.com",
                NormalizedEmail = "courier@mail.com"
            };

            CourierUser.PasswordHash =
                hasher.HashPassword(CourierUser, "courier123");

            CustomerUser = new IdentityUser()
            {
                Id = "222220ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "customer@mail.com",
                NormalizedUserName = "customer@mail.com",
                Email = "customer@mail.com",
                NormalizedEmail = "customer@mail.com"
            };

            CustomerUser.PasswordHash =
                hasher.HashPassword(CustomerUser, "customer123");
        }

        private void SeedCustomer()
        {
            Customer = new Customer()
            {
                Id = 1,
                UserId = "222220ce-d726-4fc8-83d9-d6b3ac1f591e"
            };

        }

        private void SeedAdmin()
        {
            Admin = new Admin()
            {
                Id = 1,
                UserId = "00000856-c198-4129-b3f3-b893d8395082",
                RestaurantId = 1
            };
        }
        private void SeedCourier()
        {
            Courier = new Courier()
            {
                Id = 1,
                UserId = "11111856-c198-4129-b3f3-b893d8395082",
            };
        }

        private void SeedRestaurant()
        { 
            Restaurant = new Restaurant()
            {
                Id = 1,
                Name = "PizzaHub",
                AdminId = Admin.Id,
            };
            
        }
        private void SeedMenuItems()
        {

            FirstItem = new MenuItem()
            {
                Id = 1,
                Name = "Margherita",
                Ingredients = "Pizza Dough, Tomatoes, Fresh Mozzarella Balls, Fresh Basil, Olive Oil & Salt",
                ImageUrl = "https://media.istockphoto.com/id/1168754685/photo/pizza-margarita-with-cheese-top-view-isolated-on-white-background.jpg?s=612x612&w=0&k=20&c=psLRwd-hX9R-S_iYU-sihB4Jx2aUlUr26fkVrxGDfNg=",
                Price = 9.99M,
                RestaurantId = 1,
            };

            SecondItem = new MenuItem()
            {
                Id = 2,
                Name = "Pepperoni",
                Ingredients = "Pizza Dough, Tomatoes, Crushed Red Pepper Flakes, Sliced Pepperoni, Crushed Tomatoes with Basil, Olive Oil & Salt",
                ImageUrl = "https://media.istockphoto.com/id/1413684626/photo/classic-pepperoni-pizza-with-cut-slices-isolated-on-white.jpg?s=612x612&w=0&k=20&c=498sVNGAyb7IQb9T9z5X9pnnv0YZpDWgWWKZeDO6lKw=",
                Price = 13.50M,
                RestaurantId = 1,
            };

            ThirdItem = new MenuItem()
            {
                Id = 3,
                Name = "Toscana",
                Ingredients = "Pizza Dough, Tomatoes, Cheese, Mushrooms, Diced Chicken, Mixed Peppers, Olive Oil & Salt",
                ImageUrl = "https://media.istockphoto.com/id/635675852/photo/pizza-on-white-background.jpg?s=612x612&w=0&k=20&c=3z6N8hYH4yNRK8EbGJ4Pt7vszNw7dL_l8QwnNUz2Z_o=",
                Price = 14.99M,
                RestaurantId = 1,
            };

            
        }
        private void SeedUserRoles()
        {
            UserAdmin = new IdentityUserRole<string>
            {
                UserId = "00000856-c198-4129-b3f3-b893d8395082",
                RoleId = "00000856-0000-0000-0000-b893d8395082"
            };

            UserCourier = new IdentityUserRole<string>
            {
                UserId = "11111856-c198-4129-b3f3-b893d8395082",
                RoleId = "22222222-2222-2222-2222-b893d8395082"
            };

            UserCustomer = new IdentityUserRole<string>
            {
                UserId = "222220ce-d726-4fc8-83d9-d6b3ac1f591e",
                RoleId = "11111111-1111-1111-1111-b893d8395082"
            };
        }

        private void SeedRoles()
        {
            AdminRole = new IdentityRole
            {
                Id = "00000856-0000-0000-0000-b893d8395082",
                Name = "Admin",
                NormalizedName = "ADMIN"
            };

            CustomerRole = new IdentityRole
            {
                Id = "11111111-1111-1111-1111-b893d8395082",
                Name = "Customer",
                NormalizedName = "CUSTOMER"
            };

            CourierRole = new IdentityRole
            {
                Id = "22222222-2222-2222-2222-b893d8395082",
                Name = "Courier",
                NormalizedName = "COURIER"
            };
        }

    }
}
