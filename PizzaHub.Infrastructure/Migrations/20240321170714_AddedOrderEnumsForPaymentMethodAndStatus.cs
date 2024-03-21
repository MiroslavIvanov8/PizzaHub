using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaHub.Infrastructure.Migrations
{
    public partial class AddedOrderEnumsForPaymentMethodAndStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStatuses_StatusId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_StatusId",
                table: "Orders");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000856-0000-0000-0000-b893d8395082",
                column: "ConcurrencyStamp",
                value: "72c669b9-6797-48b4-81c8-ace6418de62b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-b893d8395082",
                column: "ConcurrencyStamp",
                value: "bd1fd1ee-5ad1-4374-98c3-5dacdd01f8c4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-b893d8395082",
                column: "ConcurrencyStamp",
                value: "e36b4e43-79d0-4701-9060-e5f434feacfd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "018f81e5-c159-4ba5-8290-8a19f7806bae", "AQAAAAEAACcQAAAAEBUjcaAOIDFBKOVu4gey5kDPnRon8hHKcz/WBAsCdO5nMBeOPY7HZPyaXFWBmaVIFw==", "3a9d6abc-c2ae-4e96-b749-dd0b530276ee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf94ce8b-e39f-4845-a87d-19626442270c", "AQAAAAEAACcQAAAAEJfKujlDjHcPwZ9wEvknmoP+heTidnVmbD6M/0FkQEx1923jmtuMhut9KEp7si3GBg==", "4915f454-e023-4902-bc50-94148a548d88" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "222220ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a657187f-88d8-40ef-825d-bb5951c6e9e3", "AQAAAAEAACcQAAAAEBIWoQE1GJHSDLGKvg1fo+6feen1mJAL7xDxOEKGiBsTYF2Q+x9ltsH9oCMN13Z8Yw==", "52b0f505-4c86-48f4-b500-fe5aabeadf5f" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusId",
                table: "Orders",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStatuses_StatusId",
                table: "Orders",
                column: "StatusId",
                principalTable: "OrderStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
