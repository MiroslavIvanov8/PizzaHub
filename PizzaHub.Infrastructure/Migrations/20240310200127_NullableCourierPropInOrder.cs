using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaHub.Infrastructure.Migrations
{
    public partial class NullableCourierPropInOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.AlterColumn<int>(
                name: "CourierId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "MenuItems",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000856-0000-0000-0000-b893d8395082",
                column: "ConcurrencyStamp",
                value: "a0c9c09d-9f09-4640-9360-eb35fefa8d33");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-b893d8395082",
                column: "ConcurrencyStamp",
                value: "ba3e3256-7507-455a-bcad-2a2bfb478c5e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-b893d8395082",
                column: "ConcurrencyStamp",
                value: "aff08e44-be02-43b8-a894-3c8166989fee");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "80f0589a-cb79-46f8-93b2-8b50c83b612f", "AQAAAAEAACcQAAAAEL6EuX8884D/BJX+fJYtZXs366BYt3h7mV+lleFXXB88zWD9SMWPmsLcbxu3PyBPQg==", "9db31623-324d-49f8-a5be-c54475ef5f22" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61193d3a-655c-45b5-bda8-b30c5b99f494", "AQAAAAEAACcQAAAAEB8Bi0FiBz0tKINHoWb8yfcLr4qM1+l8eokkiI1fiPCDXCwii2iDOvADiaAl7pJ2ug==", "96103f4e-15b9-4ce6-a8ef-5e65c82ffcd9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "222220ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3054010c-4661-4bf9-a1c5-55e1674a2bfd", "AQAAAAEAACcQAAAAEODPJ85Qlx5eHP5dO6WS3k17V+pOyZ//f02KvP3UCMwPvDtZEqlrkelnNXB8gj5oOw==", "b395e411-2496-4225-bef7-229dc58c8564" });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_OrderId",
                table: "MenuItems",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Orders_OrderId",
                table: "MenuItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Orders_OrderId",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_OrderId",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "MenuItems");

            migrationBuilder.AlterColumn<int>(
                name: "CourierId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuItemId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000856-0000-0000-0000-b893d8395082",
                column: "ConcurrencyStamp",
                value: "cc06768a-9795-4ae9-81da-9f23816fa4c4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-b893d8395082",
                column: "ConcurrencyStamp",
                value: "76685253-f317-461a-9c41-4a620d6c954b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-b893d8395082",
                column: "ConcurrencyStamp",
                value: "36783812-f12f-4333-9f2e-aebe5bb9e3ea");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "237ee40c-4f26-45a9-9ea7-f0426a67d539", "AQAAAAEAACcQAAAAEEop4vmx9V/7jSoCmNIgfkRFNagzZwi3ldg1xCLuylb4tResbXHmPEAr+pf3W8B1QQ==", "86a2458f-3cb1-46da-a0a7-7bfb0cc5e2f0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46d5b6e4-3da2-4a52-885e-3ed4b253ecd5", "AQAAAAEAACcQAAAAEBSlhccGfkS4/XLRBe5j19Ie2nIu99Q3eq9OtHkhSuNZvqbbJIbe6IzV8keHgZ7y9w==", "21fa262e-f94e-4008-bca1-a3202d637b52" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "222220ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "adbca63e-a9cd-4747-a8f2-7f52d2079044", "AQAAAAEAACcQAAAAEH83XkorTsY8hnTXL3v7NmClC5hOoQyfcgKd2CYjBztx3O7rfWwfOMglmTYXA3hNSw==", "801f28a6-731c-4468-bb63-d377111dc270" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_MenuItemId",
                table: "OrderItem",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");
        }
    }
}
