using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaHub.Infrastructure.Migrations
{
    public partial class AddedCourierApplicationRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationRequests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000856-0000-0000-0000-b893d8395082",
                column: "ConcurrencyStamp",
                value: "e4afe884-2e3b-4b91-a32c-9d971d02bfdc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-b893d8395082",
                column: "ConcurrencyStamp",
                value: "a71f1a47-1ef3-47ba-8f60-750cfe16692f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-b893d8395082",
                column: "ConcurrencyStamp",
                value: "676cbb10-2383-4d8f-9c0e-986be3e89d6f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a229b327-8a7c-438f-a0b9-14f95e6b9ed6", "AQAAAAEAACcQAAAAEJaS/ASnEQQ+s/PPlaHI2bUEK/bDBVyjGzwzizjPfUxPwNPeXTDd9lX+WWoxgY3myw==", "9cea473f-de38-4ef9-9ce5-f5815065be39" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8c42009-98ea-4fc6-9905-e57692512ba5", "AQAAAAEAACcQAAAAEMgSsZlffHITnGp1gyexXEcgL61elA+6oQ3MgbVo1+BmP0Sk9WyWtRquCV/QMNMuDg==", "223a7611-0432-4cc1-bad2-81f1988ed19c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22222222-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c35f00b3-78c1-41b6-8e72-34c58e4a91b0", "AQAAAAEAACcQAAAAENbY5KXwMwpeLZB5ez1C19seAYB8ha3J6UywNdHUkxh5vUCaElu7+l8Ujm1qL5FPaw==", "c52ffab8-c1cb-452d-acb7-9c897a18fc2e" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationRequests_UserId",
                table: "ApplicationRequests",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationRequests");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000856-0000-0000-0000-b893d8395082",
                column: "ConcurrencyStamp",
                value: "1a655d52-8594-4a18-83c0-7e77e5b17bbf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-b893d8395082",
                column: "ConcurrencyStamp",
                value: "17190389-215f-43b5-a608-5f1b3abd154a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-b893d8395082",
                column: "ConcurrencyStamp",
                value: "c0b4a4b0-856c-4b1e-b23d-a24e882e2f01");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bbbb8fea-4df9-4e4b-8aee-1870be38b85f", "AQAAAAEAACcQAAAAEH/mXD2TOThEIytZD5EEsXJNCxmuId5Zv2Zx7tICFrczVPp80SG4oMk5S4FOj1QDlg==", "3483c6ef-2bab-4672-98f7-6e55e8619ae0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8d0ce04-1082-46b7-81af-cf1258e02514", "AQAAAAEAACcQAAAAEM5BgEcPaIoTTrsyaiMyp8HkrGrehc0HEHBOaFmSHx4NAUU0YG9HnNC2fZUBL1nrzQ==", "0e0efddf-51b4-403e-823a-bb544bfb12e9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22222222-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bffeda61-2be9-4a95-9fbc-56ef55136b65", "AQAAAAEAACcQAAAAEJD56p4AfpST1Z4jqZh7kcvcdLAYRWJKFWRqWmXpQlKyGCJVQ7HYm+q/BExFPZOxdg==", "bca00f7d-fb61-483b-b058-69241910469c" });
        }
    }
}
