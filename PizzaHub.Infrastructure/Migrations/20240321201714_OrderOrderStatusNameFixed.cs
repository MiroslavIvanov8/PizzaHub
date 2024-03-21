using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaHub.Infrastructure.Migrations
{
    public partial class OrderOrderStatusNameFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Orders",
                newName: "OrderStatusId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000856-0000-0000-0000-b893d8395082",
                column: "ConcurrencyStamp",
                value: "cbd53f31-0dc1-47c8-ba08-88bdfbb84045");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-b893d8395082",
                column: "ConcurrencyStamp",
                value: "c54a42da-caf2-43c1-b806-765fe8056e37");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-b893d8395082",
                column: "ConcurrencyStamp",
                value: "47fdfa99-01c8-40c2-99aa-97869eed9296");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "949c2b43-f2e6-42d8-8845-7c16ed52a5d1", "AQAAAAEAACcQAAAAEDYT0kqV11naaZS+93O0zGSNbCoyh1MYBs8s1BhRw47wsKqfYa6vJr/WMJ9ELNYJWQ==", "0ebd0d0c-967a-48f9-b8cb-708b1209e2aa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7be1f661-8b5d-47d6-9b51-061f7281fc62", "AQAAAAEAACcQAAAAEHPfJFLnT61DwRnGhvvv2xlKn3io2AMWfyhAOu47+/xgE0DhaYHt9cZX30Y0tNFL6A==", "c4cb930a-9bff-4f01-acdf-73d1d6fd7db9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "222220ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f0edab6-a63a-48fb-a446-d7cbdbc83a6b", "AQAAAAEAACcQAAAAEKV6XCtYkVMyOcD7mS6T9MOqMGwx18bbOfxk/O6igyPLSoyQa7wVCcGy9A+vCyP3Tg==", "192cc12f-f8ee-459b-9d72-900e3dcf4ff1" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStatuses_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId",
                principalTable: "OrderStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStatuses_OrderStatusId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrderStatusId",
                table: "Orders",
                newName: "StatusId");

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
