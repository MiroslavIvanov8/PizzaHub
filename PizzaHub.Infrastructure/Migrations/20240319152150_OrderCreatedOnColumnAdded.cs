using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaHub.Infrastructure.Migrations
{
    public partial class OrderCreatedOnColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000856-0000-0000-0000-b893d8395082",
                column: "ConcurrencyStamp",
                value: "72c669b9-6797-48b4-81c8-ace6418de62b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-b893d8395082",
                column: "ConcurrencyStamp",
                value: "bd1fd1ee-5ad1-4374-98c3-5dacdd01f8c4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-b893d8395082",
                column: "ConcurrencyStamp",
                value: "e36b4e43-79d0-4701-9060-e5f434feacfd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "018f81e5-c159-4ba5-8290-8a19f7806bae", "AQAAAAEAACcQAAAAEBUjcaAOIDFBKOVu4gey5kDPnRon8hHKcz/WBAsCdO5nMBeOPY7HZPyaXFWBmaVIFw==", "3a9d6abc-c2ae-4e96-b749-dd0b530276ee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf94ce8b-e39f-4845-a87d-19626442270c", "AQAAAAEAACcQAAAAEJfKujlDjHcPwZ9wEvknmoP+heTidnVmbD6M/0FkQEx1923jmtuMhut9KEp7si3GBg==", "4915f454-e023-4902-bc50-94148a548d88" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "222220ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a657187f-88d8-40ef-825d-bb5951c6e9e3", "AQAAAAEAACcQAAAAEBIWoQE1GJHSDLGKvg1fo+6feen1mJAL7xDxOEKGiBsTYF2Q+x9ltsH9oCMN13Z8Yw==", "52b0f505-4c86-48f4-b500-fe5aabeadf5f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000856-0000-0000-0000-b893d8395082",
                column: "ConcurrencyStamp",
                value: "bcc7c374-dbd5-4fbe-b5af-5816607714cb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-b893d8395082",
                column: "ConcurrencyStamp",
                value: "9c1d68ad-3393-426e-9da8-3dee972d3057");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-b893d8395082",
                column: "ConcurrencyStamp",
                value: "7fb1f4d1-c005-40e0-81c4-063c6438a1e0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23931bef-2156-44ad-825a-85cbb4c527d9", "AQAAAAEAACcQAAAAEObCxFI/DAnockWKAWt1NOaeaoH6BhLNvKqmgW5bdj6aG71zmXO23tccUMNw7G+p5A==", "56563d81-82c8-47d5-9eb4-0abe3b4dc04d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5874f58-ae45-413c-8cbc-3e1207285735", "AQAAAAEAACcQAAAAEKdUG7upmHKdy9gDCnP5yEpA2nmq2ylXTHjQnLjuiGW8nae3M21cs1NEKXvfResCNw==", "8b9dcd3f-fdbf-4c79-9ba2-08fd2f3a26c4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "222220ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3ba7d83-3be6-487c-b6d6-86b0e9698268", "AQAAAAEAACcQAAAAEAVfOLxUrqVxVx+fOE1v9UpRuRfQE+UzTCpVK9gHSn8rqt5jn5W7Hmq44vYJ6Hp+uQ==", "fd65a1bc-f77f-411a-a1e4-4c503b6958a7" });
        }
    }
}
