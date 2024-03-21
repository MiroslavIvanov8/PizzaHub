using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaHub.Infrastructure.Migrations
{
    public partial class RemovedFromOrderReceiptNavigationalProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000856-0000-0000-0000-b893d8395082",
                column: "ConcurrencyStamp",
                value: "59010c42-15f4-4549-94eb-30c91c2eeec1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-b893d8395082",
                column: "ConcurrencyStamp",
                value: "3eb3fb5e-6a62-47fb-9b46-95cf0219e456");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-b893d8395082",
                column: "ConcurrencyStamp",
                value: "0e82a591-b182-4c46-aebc-720e4808685b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5bede36-e6d0-4f20-9a3e-890686237c37", "AQAAAAEAACcQAAAAECZilxE630G60yeaGOqzy0lLjH0tXJ5+lwScRpedZ7+oesKR/IzT9H2lCW6jSj4W1Q==", "24ca37eb-deb6-42fe-8e73-a61bb1e5bf02" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05c77637-6c9b-411b-a32d-5888de134be2", "AQAAAAEAACcQAAAAENvzCi9y3iOVKvScMW2EIvtPY1+Ao6nsCTxdZtLaV35bypkKwWiZKcujD2qhwX7+5w==", "b4db5e7a-f4bd-4e77-bfb9-f0ba136b7fdf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "222220ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25ae3b35-d34f-4e7f-9ba0-76f66c6c1642", "AQAAAAEAACcQAAAAEP4HYaMvFM51iQjN61kYFFqH2px08E493T1SAXPHAXNfSItqCp/8BgUPRGc/o4jT+Q==", "93d683ca-02a7-4433-8f59-caae8ed0157e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000856-0000-0000-0000-b893d8395082",
                column: "ConcurrencyStamp",
                value: "42c0f97b-cf96-4d27-81fe-2bb0be2b4105");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-b893d8395082",
                column: "ConcurrencyStamp",
                value: "37c2d770-7a8f-4334-b3cd-be649241129a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-b893d8395082",
                column: "ConcurrencyStamp",
                value: "73d7bcb4-c4cd-42b8-90a1-a048fd287d88");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dadfb6d7-8171-4071-ad1d-4aca9d1b9264", "AQAAAAEAACcQAAAAEPN6VPgIJQzAA7Eco51kMh94kQkE6FKgQlVDj6MyOL9f47LBUCTldvEwC+Q20hJLgg==", "0c411a6f-057d-45ee-9511-38c36ebb72a9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "712b9742-a072-4d13-bdfd-9aaba9488f7d", "AQAAAAEAACcQAAAAELkLf6iuOgVbpQd9hbfDzhrS75WbooEjMxoXPd/q+7O4F1Al5HvRNczqLrtCp0wzyg==", "d6a95cc9-1221-4694-86a6-b5c5dbd74030" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "222220ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50eb513a-fa7c-4d3d-9107-c44b51f19707", "AQAAAAEAACcQAAAAEA7GCi3GVayDLsLiMrDvmqX0zdvRIbyFYbywRJQLKRhkCDWgs9KRYCxbncfimGqGlg==", "94945c7f-e757-49c7-bf3c-48d9adbe0ebf" });
        }
    }
}
