using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaHub.Infrastructure.Migrations
{
    public partial class RolesSeedWithAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00000856-0000-0000-0000-b893d8395082", "3dd3c982-97ee-4a33-a5a5-1637e5cc0f3f", "Admin", "ADMIN" },
                    { "22222222-2222-2222-2222-b893d8395082", "f652eea6-582f-4261-a859-9b7b99fbb815", "Courier", "COURIER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "882d06b3-8018-4fc9-97d3-7176f4d6d61d", "AQAAAAEAACcQAAAAEAzgEwCswxaOmAGO/U5sO22kliFj42BtzbK2SLOmXxr3BLTPAoOymE25+sT9NzUzGw==", "f17f5ff3-6bfa-47e1-8685-420909178c9d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1af872c8-5c6a-4231-9a00-e54f12f539a4", "AQAAAAEAACcQAAAAEGAtbG2iBvXuDBi9VEsiAFRG4YT+5GkMN7G0EtxkkciCO1VuM2Uvu7Fe9Ssh44xGRg==", "04dd190d-5a83-4135-88fe-7318c8b211cc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "222220ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8da7cafa-b180-491c-b1f9-2fa021f8be54", "AQAAAAEAACcQAAAAEMuYptxaePe+IOiDyNVIavJNgJWT9kQR5QCIvOH8TpHsq6gP1drOGzKce7Ae0xQ+gQ==", "87e45867-d316-46e7-a53c-917181284d0b" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "00000856-0000-0000-0000-b893d8395082", "00000856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "22222222-2222-2222-2222-b893d8395082", "11111856-c198-4129-b3f3-b893d8395082" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "00000856-0000-0000-0000-b893d8395082", "00000856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "22222222-2222-2222-2222-b893d8395082", "11111856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000856-0000-0000-0000-b893d8395082");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-b893d8395082");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "94a83269-a1c3-45d4-91ba-e541c516e8ab", "AQAAAAEAACcQAAAAEPeT7kuZguyvx+i6VDOm7UcaaG/EjU5MF5JwLruEzUggzJMKc+cpbl7Rw1oxPEkkhg==", "12581f5a-9834-4980-853a-74018c3c6da4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c38ae4d-1938-4d7c-b864-253908254a28", "AQAAAAEAACcQAAAAENj04fnKjOiNZpxKl/XLkUxQMP9TVfansKkjpzqHKMS7bVUuFns8vVblrfd+8L2rDg==", "128af750-c88c-4647-8064-a59254876f35" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "222220ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52277328-14bf-4140-8d3c-61f2539c2cfb", "AQAAAAEAACcQAAAAEKPsHgm3UmHzBKWoyI+5Zeo0eZsFKAYgApiJeGa0B3WYa3kQTc8pF7gPqOaLKpS0sw==", "6b7279ea-2cad-43c0-a019-8938db5d7ef1" });
        }
    }
}
