using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaHub.Infrastructure.Migrations
{
    public partial class OrderHasCollectionOfOrderItemsAddedVirtualPropsToAllModels : Migration
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

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000856-0000-0000-0000-b893d8395082",
                column: "ConcurrencyStamp",
                value: "a1b67036-fe61-4f83-8683-15f8e33f1607");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-b893d8395082",
                column: "ConcurrencyStamp",
                value: "4d11fc94-d23b-4888-a92f-4b71d8178939");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-b893d8395082",
                column: "ConcurrencyStamp",
                value: "97f7b218-b16f-4971-801a-cfbca5753bae");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8f51c8a-de0c-499f-b9ca-3cbaa9517a6d", "AQAAAAEAACcQAAAAEJaWCHEMYT1xVJNU1nZEQsbl8fN6SukEccDMXmPeFmKnI/3z69twCqTS1tjwH/Z56A==", "e3ca884d-49d1-40d3-b40c-3154dc017bc5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b8f4c88-65d2-48a7-a9bf-ee965c2df14b", "AQAAAAEAACcQAAAAEAoT0ESkFAAfFOtc33CYv15k6pqOS9/c867D2Bo7F0qimAo52t555+aKLiJUBMIogQ==", "732b1b18-df75-4144-8d2d-bd8191aafcf2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "222220ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae378fdb-52b8-4690-994d-ce55940800e2", "AQAAAAEAACcQAAAAEENQEVhJbsr5/9b3hh8gNCGIgVKI8RCvYFxsGguYcBOVnuM2swc71mbLgl56YhY1DQ==", "41dad85e-5553-42d4-9e92-f9f8677b8b8d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
