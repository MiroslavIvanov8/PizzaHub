using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaHub.Infrastructure.Migrations
{
    public partial class TableOrderItemsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    MenuItemId = table.Column<int>(type: "int", nullable: false),
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
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ed003bc-660e-4d52-97f3-6419d440a4b9", "AQAAAAEAACcQAAAAECCOR3RgKgA7dCuEdiyxzm4EqQs2jUG14+bYYDmV+dt3aEgZEC06J+Efdff/IivcBA==", "be9db993-7ac2-4118-a8c0-713f1e72d29e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e1275fb-65c7-47be-831e-2f1ddb2c6a41", "AQAAAAEAACcQAAAAEJ3yoMN7ZgUfhANHqoaS7vK6SuuMz5xSI7pUyUrwXbbXT8/J7s3EiWLJjxuangcIXQ==", "566b730b-5d3c-4373-a87d-91b87e96f557" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "222220ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fce75b1-2e4c-408f-a6d8-00a23f6a9c30", "AQAAAAEAACcQAAAAEPh9f6wpx9bJ8DMIdjJGk4vMLpim+JibUFvklTSoB9WY4WDB341DglSQr5Do/mQfnw==", "71ba3331-80f4-41c0-aca5-cc8ac5596fa5" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_MenuItemId",
                table: "OrderItem",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "MenuItems",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ebb36f54-b6ff-4e04-9224-71e7bcd1a990", "AQAAAAEAACcQAAAAEBu5Xjiv/GJY5xdek3gb686bkQRA4Q1QJ7awcOaClizOaxf3mVtWbdpR2WT9ddZfhw==", "165ba727-0bbe-4af3-8e2f-0185e958454a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c819ade5-e010-419e-a9ee-e132208c8f6f", "AQAAAAEAACcQAAAAEMfmECKzrl0o1l7a9swGS4Qln8kjHNo7acmXUBV6TyRzzN0FzoeEeYWTHNAaAeqqkA==", "f74089dc-1797-4922-ac65-ac0739ff5c96" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "222220ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd6cb1f5-a515-4e45-929c-be23b97ab66a", "AQAAAAEAACcQAAAAEHDwVlD1IAgwlWkLPMkj89XumwX7rDnXY7ObBHPRyTUJXj7S01XkXD7qV8BEsMaNEg==", "af99db39-e2da-47e5-be32-e781182de959" });

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
    }
}
