using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaHub.Infrastructure.Migrations
{
    public partial class PaymentMethodTableAddedWithRelationToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentMethodId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
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

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cash" },
                    { 2, "Card" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentMethodId",
                table: "Orders",
                column: "PaymentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_PaymentMethods_PaymentMethodId",
                table: "Orders",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PaymentMethods_PaymentMethodId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PaymentMethodId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentMethodId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000856-0000-0000-0000-b893d8395082",
                column: "ConcurrencyStamp",
                value: "f84053ad-eddd-4ef9-9908-b4b7df43615c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-b893d8395082",
                column: "ConcurrencyStamp",
                value: "935dbdea-caca-40b1-889a-cfb65f02cfce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-b893d8395082",
                column: "ConcurrencyStamp",
                value: "ccc414d0-8774-43cc-a8a4-b33411ea5248");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b7251a9-1520-49ed-a884-360ae557c80e", "AQAAAAEAACcQAAAAEDq/upyO1/QtOkkke18Mys4N3hL2V4KMZ/6b6GC1C3PWCTlbOf2Bw/RraD8vc0ROWg==", "f68f9ef5-5bfb-4c9e-b2ce-5a25018043c5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f188005-273f-46f8-8fb6-3ff61e040a76", "AQAAAAEAACcQAAAAEOEHlQgCA7NZMxQFPO0CCdO+hOiE1orfLbePlC9iy73+I7N086z49BvnsJLAzpntsQ==", "7649fdb4-f306-4b35-9e2d-708b59f3a934" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "222220ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e14d2ed2-6f2f-4385-8c3d-aa9231efb40a", "AQAAAAEAACcQAAAAEF49WzhZHMdHTQktCWL1lYc8ATzDhaLkTvigWoqKfRIC8De9cXplVlDk8NaWPjjqEw==", "36a4779b-91bd-4d2a-9b9a-adb590be3812" });
        }
    }
}
