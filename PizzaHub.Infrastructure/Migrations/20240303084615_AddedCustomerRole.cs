using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaHub.Infrastructure.Migrations
{
    public partial class AddedCustomerRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000856-0000-0000-0000-b893d8395082",
                column: "ConcurrencyStamp",
                value: "d1fc5438-7562-445b-ad23-ccbf94aa2096");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-b893d8395082",
                column: "ConcurrencyStamp",
                value: "e59b7012-4622-4ef6-adc8-725378b0f0cd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "11111111-1111-1111-1111-b893d8395082", "54f920d7-345e-4054-91bd-bbdcda0179db", "Customer", "CUSTOMER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1399f24f-b425-4aab-80fc-3d5f75b94d97", "AQAAAAEAACcQAAAAEGtQuc6EMMeA7UBxuCpj3jkw9F8W7LuSJGFPbGAQvUwyzfsRjtXMqH4HybR0NE3Byg==", "d5474a87-aaef-4816-82b8-fddabdfd037c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14d255ba-2594-46bb-9455-117b33a471f8", "AQAAAAEAACcQAAAAEF+Q51EWdOlSjNkWhLD3idmP/zLMAAJEt2HZT7Ys+oC3jM0m7EvEWhFGSfQzsaHOBQ==", "a00f08ed-65b3-47db-869d-f9a476d6ad49" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "222220ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8ae2a57-fbff-4c1e-abfa-5c1f1834bae9", "AQAAAAEAACcQAAAAEMTGFLIAkrINLP3DrXVVXKTcniAhzUAhEzZzuaT0QIepmlTwxmtQ6GhfSryxty0eyQ==", "c120a29f-eb12-43b4-b4a4-0a18d92d653f" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "11111111-1111-1111-1111-b893d8395082", "222220ce-d726-4fc8-83d9-d6b3ac1f591e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "11111111-1111-1111-1111-b893d8395082", "222220ce-d726-4fc8-83d9-d6b3ac1f591e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-b893d8395082");

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
        }
    }
}
