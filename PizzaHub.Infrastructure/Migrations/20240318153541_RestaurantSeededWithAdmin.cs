using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaHub.Infrastructure.Migrations
{
    public partial class RestaurantSeededWithAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000856-0000-0000-0000-b893d8395082",
                column: "ConcurrencyStamp",
                value: "bcc7c374-dbd5-4fbe-b5af-5816607714cb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-b893d8395082",
                column: "ConcurrencyStamp",
                value: "9c1d68ad-3393-426e-9da8-3dee972d3057");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-b893d8395082",
                column: "ConcurrencyStamp",
                value: "7fb1f4d1-c005-40e0-81c4-063c6438a1e0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23931bef-2156-44ad-825a-85cbb4c527d9", "AQAAAAEAACcQAAAAEObCxFI/DAnockWKAWt1NOaeaoH6BhLNvKqmgW5bdj6aG71zmXO23tccUMNw7G+p5A==", "56563d81-82c8-47d5-9eb4-0abe3b4dc04d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5874f58-ae45-413c-8cbc-3e1207285735", "AQAAAAEAACcQAAAAEKdUG7upmHKdy9gDCnP5yEpA2nmq2ylXTHjQnLjuiGW8nae3M21cs1NEKXvfResCNw==", "8b9dcd3f-fdbf-4c79-9ba2-08fd2f3a26c4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "222220ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3ba7d83-3be6-487c-b6d6-86b0e9698268", "AQAAAAEAACcQAAAAEAVfOLxUrqVxVx+fOE1v9UpRuRfQE+UzTCpVK9gHSn8rqt5jn5W7Hmq44vYJ6Hp+uQ==", "fd65a1bc-f77f-411a-a1e4-4c503b6958a7" });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "PizzaHub" });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "RestaurantId", "UserId" },
                values: new object[] { 1, 1, "00000856-c198-4129-b3f3-b893d8395082" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000856-0000-0000-0000-b893d8395082",
                column: "ConcurrencyStamp",
                value: "60533d28-a208-48ad-896d-8ed1c942f6de");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-b893d8395082",
                column: "ConcurrencyStamp",
                value: "1945e331-5015-46ee-ad33-7f799782e3c0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-b893d8395082",
                column: "ConcurrencyStamp",
                value: "0036cc04-8d2b-4fb2-8512-cab0c68a7e2a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc031ca6-8520-4d67-a0ec-ebe6bc82b860", "AQAAAAEAACcQAAAAEII1xtyOPlAzf/Wp4xg1IUtmTBZV49MjO5uLWaHXSxHMDwvF1fio7dFFrKV5jcvepQ==", "f0d7a5e1-1c49-458b-9b81-814a383aaca1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e736baa3-1652-41e1-9b1c-9f395b3e7535", "AQAAAAEAACcQAAAAEFzKPn/6sU9WJ45094pr6ehq5/yYeRBZLDeUIan7Xhrve1fc8blSj8y+ImKgQV4W7A==", "d1f8dab6-821d-4d0c-a4f1-e4813d11f69f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "222220ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c76ca4fe-e4e9-4be5-b175-9dff2f2ec6d2", "AQAAAAEAACcQAAAAEAP9uxiu+WSZFIjbYHxY/Nk1Qq2z+gF03prkPjCfWEd1IzZOpRSiKY54kT8tCilBLA==", "00f10a4f-53d3-4a89-a928-d2be4da2ec5d" });
        }
    }
}
