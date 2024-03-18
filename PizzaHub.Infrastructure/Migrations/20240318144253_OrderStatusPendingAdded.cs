using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaHub.Infrastructure.Migrations
{
    public partial class OrderStatusPendingAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000856-0000-0000-0000-b893d8395082",
                column: "ConcurrencyStamp",
                value: "7bcb5509-bb9f-4840-90c9-678281c71c79");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-b893d8395082",
                column: "ConcurrencyStamp",
                value: "188714b7-b142-4400-a9cf-a2d3239368eb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-b893d8395082",
                column: "ConcurrencyStamp",
                value: "edf88f2d-0d04-4e5a-a0bf-517fb282da41");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61406e7b-fcd2-4f50-a045-d370bc195bd8", "AQAAAAEAACcQAAAAEO7o7wc42J5JdE/v7jbWvqpz1UKPPMOfTAeaEMtDuygZMdagJKdfYsDqjq+MXYX+jQ==", "2402f394-3145-46f6-acbd-e14564065e09" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5238300a-f5a8-4f67-ad4a-6fb1758a55f4", "AQAAAAEAACcQAAAAEJhbFDblDWHm55vMY6zNJTtd4FCskavOVPVm2BDp56HmbRPZ0u5pt82PmaPE+YOybA==", "fae0c5f7-6a3d-41ed-8673-ea3e63a4b8a8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "222220ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81329c52-a7d0-4d26-9a8f-bd4ab2c25912", "AQAAAAEAACcQAAAAEH0+IJE2VA7N7xXKPDXRq9tasv02jspoB2k4l1qL1lKkJIY/iHlsQwHCAcMIaTqOcA==", "63907c08-0cec-44c1-a74c-3a5f3ba4fa96" });

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Pending" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 5);

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
    }
}
