using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaHub.Infrastructure.Migrations
{
    public partial class OrderItemsTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    MenuItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
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
                value: "b06476d5-203b-4c2c-9144-a4fa8ef90c34");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-b893d8395082",
                column: "ConcurrencyStamp",
                value: "99368dbd-2cd2-4f51-82fc-82ec2c2ecf8d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-b893d8395082",
                column: "ConcurrencyStamp",
                value: "7855978a-2111-4f93-a9f2-adfaa3dfb228");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f7fed8b-5da6-4323-848c-6e1e52d5f716", "AQAAAAEAACcQAAAAELtdovMvEGs5I0JZ3ibwy5ujjtnFFbZxV7oA2V8TCz5jRM5VvZSYLoqLadk6nTKu4Q==", "df0adc91-fa10-4e7c-b3b0-4b862a148772" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d8448f0-a1a7-4477-bd2e-11bb91f32939", "AQAAAAEAACcQAAAAEKuqeZGqnxqx172lrGAgHjk0kdvjri4MV0qAMT/9ABEMkPknp4Qc6CjYOetyk33uWA==", "031139fa-df13-43a3-aee9-05e7c5e29d38" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "222220ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38354684-cfe4-4945-a770-dc6fa087680a", "AQAAAAEAACcQAAAAELhGt5IcbIXzHYwrsTYTBT0p8MMEfTTeQgr+gw3kFWtgub+62fEKm1oaFz6VMB4caQ==", "5d06defa-16fd-4cfe-9a21-de079b669649" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_MenuItemId",
                table: "OrderItems",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

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
        }
    }
}
