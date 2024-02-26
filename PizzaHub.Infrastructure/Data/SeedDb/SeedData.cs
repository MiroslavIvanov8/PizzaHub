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


        public SeedData()
        {
            SeedUsers();
            SeedCustomer();
            SeedCourier();
            SeedAdmin();
            SeedRestaurant();
            SeedMenuItems();

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
                ImageUrl = "https://i.ytimg.com/vi/4VSW29yWPlA/hqdefault.jpg",
                Price = 9.99M,
                RestaurantId = 1,
            };

            SecondItem = new MenuItem()
            {
                Id = 2,
                Name = "Pepperoni",
                Ingredients = "Pizza Dough, Tomatoes, Crushed Red Pepper Flakes, Sliced Pepperoni, Crushed Tomatoes with Basil, Olive Oil & Salt",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTqrokvH7PmBozzFJT-k4Jar8oiBvAQZMAbevgZh_ACbQpBWxoAKsdPzfUjiqlUFe54thw&usqp=CAU",
                Price = 13.50M,
                RestaurantId = 1,
            };

            ThirdItem = new MenuItem()
            {
                Id = 3,
                Name = "Toscana",
                Ingredients = "Pizza Dough, Tomatoes, Cheese, Mushrooms, Diced Chicken, Mixed Peppers, Olive Oil & Salt",
                ImageUrl = "https://thumbs.dreamstime.com/z/toscana-pizza-wooden-plate-isolated-white-background-218130024.jpg",
                Price = 14.99M,
                RestaurantId = 1,
            };

            
        }
    }
}
