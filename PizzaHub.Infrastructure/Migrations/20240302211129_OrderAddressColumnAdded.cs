using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaHub.Infrastructure.Migrations
{
    public partial class OrderAddressColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

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
        }
    }
}
