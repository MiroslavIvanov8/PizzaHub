using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaHub.Infrastructure.Migrations
{
    public partial class OrderStatusTableAndSeedCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e3c106f-4ee6-425e-97cd-9fc42b6e596f", "AQAAAAEAACcQAAAAEB4lOacia8pUha/nYRN4c3cPpSeV1kcpDT561ERGBfVePjlNXEtMR0W5imRWbnLhjw==", "ac1839de-b545-47cf-b253-0109960b0ff3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d85b2407-cdc8-4dcc-bb1c-535ed6bf0759", "AQAAAAEAACcQAAAAENBoPQOLVg13M2IihxlV3ovLSptaIQ9bzXDBaWbBhnnIo65xw04lb4kO3K+DGytUWA==", "06d8d148-9b3c-41c5-a364-39a77a917424" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "222220ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c6836ea-5e90-4cec-a7e5-1c848d85c288", "AQAAAAEAACcQAAAAEGZenP1hWiUOxR64hxLwgYJ2KMCVfBo/J2Kga6Kh0U+FYv6JiWRFHLSRf7NAGb+DEQ==", "e7e78422-c76c-41c3-b9b3-9f6e0ae552b9" });

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "In Progress" },
                    { 2, "Out for Delivery" },
                    { 3, "Delivered" },
                    { 4, "Canceled" }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStatuses_StatusId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Orders_StatusId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Orders");

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
        }
    }
}
