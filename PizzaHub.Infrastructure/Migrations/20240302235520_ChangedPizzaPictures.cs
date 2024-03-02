using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaHub.Infrastructure.Migrations
{
    public partial class ChangedPizzaPictures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000856-0000-0000-0000-b893d8395082",
                column: "ConcurrencyStamp",
                value: "f0d88667-e683-4df2-8425-47f881129cfd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-b893d8395082",
                column: "ConcurrencyStamp",
                value: "199f7c88-fe76-44d0-a2da-f8cfb7d2f72b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78de100c-3408-44c6-a9df-d2da2574f845", "AQAAAAEAACcQAAAAEHibO4dhxyda5a4z+TLtwOEuKdxHOTxGto+HzJK1sXBNp4cQIuHvK1hqbE1JmWK8Hg==", "5d8ae76b-81e7-4b4b-b380-8705cf5552a2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "431dca8d-1107-488f-8566-cbd5559703da", "AQAAAAEAACcQAAAAEAdj9q+gIPVdIRQPgTwzXzAY9MlMaotEuXeaq6uJglNh66ukkb58I57ifPJZwssvQg==", "6f035020-b576-4936-a830-ae31741c0ee0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "222220ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78cc30a5-386a-4c2d-be0c-3e0f9ee45753", "AQAAAAEAACcQAAAAELZhNm3ydTZNZ7k2b7jsYYn5/yRWc7EBqOG4LG4rJJk0mpX1XZXl7MxWdnb1jKTDVQ==", "c7796ec3-8094-48f0-a115-bf34667636bd" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://media.istockphoto.com/id/1168754685/photo/pizza-margarita-with-cheese-top-view-isolated-on-white-background.jpg?s=612x612&w=0&k=20&c=psLRwd-hX9R-S_iYU-sihB4Jx2aUlUr26fkVrxGDfNg=");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://media.istockphoto.com/id/1413684626/photo/classic-pepperoni-pizza-with-cut-slices-isolated-on-white.jpg?s=612x612&w=0&k=20&c=498sVNGAyb7IQb9T9z5X9pnnv0YZpDWgWWKZeDO6lKw=");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://media.istockphoto.com/id/635675852/photo/pizza-on-white-background.jpg?s=612x612&w=0&k=20&c=3z6N8hYH4yNRK8EbGJ4Pt7vszNw7dL_l8QwnNUz2Z_o=");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000856-0000-0000-0000-b893d8395082",
                column: "ConcurrencyStamp",
                value: "3dd3c982-97ee-4a33-a5a5-1637e5cc0f3f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-b893d8395082",
                column: "ConcurrencyStamp",
                value: "f652eea6-582f-4261-a859-9b7b99fbb815");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "882d06b3-8018-4fc9-97d3-7176f4d6d61d", "AQAAAAEAACcQAAAAEAzgEwCswxaOmAGO/U5sO22kliFj42BtzbK2SLOmXxr3BLTPAoOymE25+sT9NzUzGw==", "f17f5ff3-6bfa-47e1-8685-420909178c9d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1af872c8-5c6a-4231-9a00-e54f12f539a4", "AQAAAAEAACcQAAAAEGAtbG2iBvXuDBi9VEsiAFRG4YT+5GkMN7G0EtxkkciCO1VuM2Uvu7Fe9Ssh44xGRg==", "04dd190d-5a83-4135-88fe-7318c8b211cc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "222220ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8da7cafa-b180-491c-b1f9-2fa021f8be54", "AQAAAAEAACcQAAAAEMuYptxaePe+IOiDyNVIavJNgJWT9kQR5QCIvOH8TpHsq6gP1drOGzKce7Ae0xQ+gQ==", "87e45867-d316-46e7-a53c-917181284d0b" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://i.ytimg.com/vi/4VSW29yWPlA/hqdefault.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTqrokvH7PmBozzFJT-k4Jar8oiBvAQZMAbevgZh_ACbQpBWxoAKsdPzfUjiqlUFe54thw&usqp=CAU");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://thumbs.dreamstime.com/z/toscana-pizza-wooden-plate-isolated-white-background-218130024.jpg");
        }
    }
}
