using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaHub.Infrastructure.Migrations
{
    public partial class SeedingDomainTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "00000856-c198-4129-b3f3-b893d8395082", 0, "ebb36f54-b6ff-4e04-9224-71e7bcd1a990", "admin@mail.com", false, false, null, "admin@mail.com", "admin@mail.com", "AQAAAAEAACcQAAAAEBu5Xjiv/GJY5xdek3gb686bkQRA4Q1QJ7awcOaClizOaxf3mVtWbdpR2WT9ddZfhw==", null, false, "165ba727-0bbe-4af3-8e2f-0185e958454a", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "11111856-c198-4129-b3f3-b893d8395082", 0, "c819ade5-e010-419e-a9ee-e132208c8f6f", "courier@mail.com", false, false, null, "courier@mail.com", "courier@mail.com", "AQAAAAEAACcQAAAAEMfmECKzrl0o1l7a9swGS4Qln8kjHNo7acmXUBV6TyRzzN0FzoeEeYWTHNAaAeqqkA==", null, false, "f74089dc-1797-4922-ac65-ac0739ff5c96", false, "courier@mail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "222220ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "bd6cb1f5-a515-4e45-929c-be23b97ab66a", "customer@mail.com", false, false, null, "customer@mail.com", "customer@mail.com", "AQAAAAEAACcQAAAAEHDwVlD1IAgwlWkLPMkj89XumwX7rDnXY7ObBHPRyTUJXj7S01XkXD7qV8BEsMaNEg==", null, false, "af99db39-e2da-47e5-be32-e781182de959", false, "customer@mail.com" });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "RestaurantId", "UserId" },
                values: new object[] { 1, 1, "00000856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Couriers",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, "11111856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, "222220ce-d726-4fc8-83d9-d6b3ac1f591e" });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "AdminId", "Name" },
                values: new object[] { 1, 1, "PizzaHub" });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "ImageUrl", "Ingredients", "Name", "OrderId", "Price", "RestaurantId" },
                values: new object[] { 1, "https://i.ytimg.com/vi/4VSW29yWPlA/hqdefault.jpg", "Pizza Dough, Tomatoes, Fresh Mozzarella Balls, Fresh Basil, Olive Oil & Salt", "Margherita", null, 9.99m, 1 });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "ImageUrl", "Ingredients", "Name", "OrderId", "Price", "RestaurantId" },
                values: new object[] { 2, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTqrokvH7PmBozzFJT-k4Jar8oiBvAQZMAbevgZh_ACbQpBWxoAKsdPzfUjiqlUFe54thw&usqp=CAU", "Pizza Dough, Tomatoes, Crushed Red Pepper Flakes, Sliced Pepperoni, Crushed Tomatoes with Basil, Olive Oil & Salt", "Pepperoni", null, 13.50m, 1 });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "ImageUrl", "Ingredients", "Name", "OrderId", "Price", "RestaurantId" },
                values: new object[] { 3, "https://thumbs.dreamstime.com/z/toscana-pizza-wooden-plate-isolated-white-background-218130024.jpg", "Pizza Dough, Tomatoes, Cheese, Mushrooms, Diced Chicken, Mixed Peppers, Olive Oil & Salt", "Toscana", null, 14.99m, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Couriers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "222220ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000856-c198-4129-b3f3-b893d8395082");
        }
    }
}
