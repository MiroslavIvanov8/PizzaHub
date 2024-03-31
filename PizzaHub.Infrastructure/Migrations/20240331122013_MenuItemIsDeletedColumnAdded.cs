using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaHub.Infrastructure.Migrations
{
    public partial class MenuItemIsDeletedColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MenuItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000856-0000-0000-0000-b893d8395082",
                column: "ConcurrencyStamp",
                value: "61b056ec-f107-40a9-8371-c6fed3604c64");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-b893d8395082",
                column: "ConcurrencyStamp",
                value: "1bce71b8-9d4c-4666-a780-7d7a293c86dc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-b893d8395082",
                column: "ConcurrencyStamp",
                value: "be492713-a7fa-4240-9eaf-42d5278cf6a0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4763ef67-a992-49d0-b421-8c4339015c88", true, "AQAAAAEAACcQAAAAEFmIorgJPSZItkBkfOlDjf8dTdZlv9BGHjYBOw++vTMPEvfHUwXudT2ZkVFoGBc6UA==", "f753af80-31e8-4147-9c1a-acf1bf78f7ae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash", "SecurityStamp" },
                values: new object[] { "800e6f90-e1cd-4e36-9924-0e395780885d", true, "AQAAAAEAACcQAAAAEMfPodUgwkhlYHjsZcB8wFWhPoWvvoheMBVlcyELY+mjvT6W6M2L1memGWbENv1r7A==", "b1df61d6-9477-45fd-9f6c-e34df22a9465" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22222222-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67008edb-839e-4b35-8389-f2989c2e5837", true, "AQAAAAEAACcQAAAAEJQD9kAidhQmHVW8OVBxAdvRIyx6NbNJgxwX7Rmqu7k4yU9QlvfidjUNHRdCKQ4AtA==", "b72f781b-6fe9-40b1-8c9c-d6c98c69c70e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MenuItems");

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
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a229b327-8a7c-438f-a0b9-14f95e6b9ed6", false, "AQAAAAEAACcQAAAAEJaS/ASnEQQ+s/PPlaHI2bUEK/bDBVyjGzwzizjPfUxPwNPeXTDd9lX+WWoxgY3myw==", "9cea473f-de38-4ef9-9ce5-f5815065be39" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8c42009-98ea-4fc6-9905-e57692512ba5", false, "AQAAAAEAACcQAAAAEMgSsZlffHITnGp1gyexXEcgL61elA+6oQ3MgbVo1+BmP0Sk9WyWtRquCV/QMNMuDg==", "223a7611-0432-4cc1-bad2-81f1988ed19c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22222222-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c35f00b3-78c1-41b6-8e72-34c58e4a91b0", false, "AQAAAAEAACcQAAAAENbY5KXwMwpeLZB5ez1C19seAYB8ha3J6UywNdHUkxh5vUCaElu7+l8Ujm1qL5FPaw==", "c52ffab8-c1cb-452d-acb7-9c897a18fc2e" });
        }
    }
}
