using Microsoft.AspNetCore.Identity;
using PizzaHub.Infrastructure.Data.Models;

namespace PizzaHub.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
        public Restaurant Restaurant { get; set; }

        public ApplicationUser CustomerUser { get; set; }

        public ApplicationUser CourierUser { get; set; }

        public ApplicationUser AdminUser { get; set; }

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
        public OrderStatus FifthStatus { get; set; }

        public IdentityRole AdminRole { get; set; }

        public IdentityRole CourierRole { get; set; }

        public IdentityRole CustomerRole { get; set; }

        public IdentityUserRole<string> UserCustomer { get; set; }
        public IdentityUserRole<string> UserCourier { get; set; }

        public IdentityUserRole<string> UserAdmin { get; set; }

        public PaymentMethod WithCard { get; set; }
        public PaymentMethod WithCash { get; set; }

        public SeedData()
        {
            SeedUsers();
            SeedCustomer();
            SeedCourier();
            SeedAdmin();
            SeedRestaurant();
            SeedOrderStatuses();
            SeedRoles();
            SeedUserRoles();
            SeedPaymentMethods();
            SeedMenuItems();
        }
        
        private void SeedOrderStatuses()
        {
            FirstStatus = new OrderStatus()
            {
                Id = 1,
                Name = "Pending"
            };

            SecondStatus = new OrderStatus()
            {
                Id = 2,
                Name = "In Progress"
            };

            ThirdStatus = new OrderStatus()
            {
                Id = 3,
                Name = "Out for Delivery"
            };

            ForthStatus = new OrderStatus()
            {
                Id = 4,
                Name = "Delivered"
            };
            FifthStatus = new OrderStatus()
            {
                Id = 5,
                Name = "Canceled"
            };
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            AdminUser = new ApplicationUser()
            {
                Id = "00000000-c198-4129-b3f3-b893d8395082",
                FirstName = "Mister",
                LastName = "Admin",
                BirthDate = new DateTime(1998, 10, 1), 
                UserName = "admin@mail.com",
                NormalizedUserName = "admin@mail.com",
                Email = "admin@mail.com",
                EmailConfirmed = true,
                NormalizedEmail = "admin@mail.com"
            };

            AdminUser.PasswordHash =
                hasher.HashPassword(AdminUser, "admin123");

            CourierUser = new ApplicationUser()
            {
                Id = "22222222-c198-4129-b3f3-b893d8395082",
                FirstName = "Mister",
                LastName = "Courier",
                BirthDate = new DateTime(1998, 10, 1),
                UserName = "courier@mail.com",
                NormalizedUserName = "courier@mail.com",
                Email = "courier@mail.com",
                EmailConfirmed = true,
                NormalizedEmail = "courier@mail.com"
            };

            CourierUser.PasswordHash =
                hasher.HashPassword(CourierUser, "courier123");

            CustomerUser = new ApplicationUser()
            {
                Id = "11111111-d726-4fc8-83d9-d6b3ac1f591e",
                FirstName = "Mister",
                LastName = "Customer",
                BirthDate = new DateTime(1998, 10, 1),
                UserName = "customer@mail.com",
                NormalizedUserName = "customer@mail.com",
                Email = "customer@mail.com",
                EmailConfirmed = true,
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
                UserId = "11111111-d726-4fc8-83d9-d6b3ac1f591e"
            };

        }

        private void SeedAdmin()
        {
            Admin = new Admin()
            {
                Id = 1,
                UserId = "00000000-c198-4129-b3f3-b893d8395082",
                RestaurantId = 1
            };
        }
        private void SeedCourier()
        {
            Courier = new Courier()
            {
                Id = 1,
                UserId = "22222222-c198-4129-b3f3-b893d8395082",
            };
        }

        private void SeedRestaurant()
        {
            Restaurant = new Restaurant()
            {
                Id = 1,
                Name = "PizzaHub",
                Admins = new List<Admin>()
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
                UserId = "00000000-c198-4129-b3f3-b893d8395082",
                RoleId = "00000856-0000-0000-0000-b893d8395082"
            };

            UserCourier = new IdentityUserRole<string>
            {
                UserId = "22222222-c198-4129-b3f3-b893d8395082",
                RoleId = "22222222-2222-2222-2222-b893d8395082"
            };

            UserCustomer = new IdentityUserRole<string>
            {
                UserId = "11111111-d726-4fc8-83d9-d6b3ac1f591e",
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


        private void SeedPaymentMethods()
        {
            WithCash = new PaymentMethod()
            {
                Id = 1,
                Name = "Cash"
            };

            WithCard = new PaymentMethod()
            {
                Id = 2,
                Name = "Card"
            };
        }

    }
}
