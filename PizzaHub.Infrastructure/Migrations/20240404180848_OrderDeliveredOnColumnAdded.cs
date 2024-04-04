using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaHub.Infrastructure.Migrations
{
    public partial class OrderDeliveredOnColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveredOn",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000856-0000-0000-0000-b893d8395082",
                column: "ConcurrencyStamp",
                value: "694d02a6-5bc8-4f81-a982-d9f5532c6172");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-b893d8395082",
                column: "ConcurrencyStamp",
                value: "91d4d763-fa92-4ab5-b593-4d882227714e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-b893d8395082",
                column: "ConcurrencyStamp",
                value: "cf21205d-0024-4d3e-84c7-54b07fedb52b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c28c061-f34b-440e-9b7b-1d93636f4cf0", "AQAAAAEAACcQAAAAECkh9UPNmS1Ln9t/3Ci1XkHxDQAGvUsaNW8QRiDG+to5Ggh9XWxGkmMfN2jghaOqiA==", "f3e61d55-30d8-4915-972d-e331b245f6cb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81edefce-5446-4d00-ba06-3c45460218a9", "AQAAAAEAACcQAAAAEL5Pgj07Q+yy4NnfTOGp0aPZ8qCGGmedlHFDSWLeis9EcIq5uU1Ptnm7mlEtE0Qe9Q==", "074dac38-ba63-47ea-84b0-766ea12da061" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22222222-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8306ad7c-3d86-4c18-a69b-f44a81c2baea", "AQAAAAEAACcQAAAAEKwpb/66DEts5crj3Rxhu6KI3w81YQelGvX1M4x3WAGCcXVEqALB2f/VeUrLH+wvwg==", "411a0d5e-c53d-407f-866f-f7be095e57dc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveredOn",
                table: "Orders");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4763ef67-a992-49d0-b421-8c4339015c88", "AQAAAAEAACcQAAAAEFmIorgJPSZItkBkfOlDjf8dTdZlv9BGHjYBOw++vTMPEvfHUwXudT2ZkVFoGBc6UA==", "f753af80-31e8-4147-9c1a-acf1bf78f7ae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "800e6f90-e1cd-4e36-9924-0e395780885d", "AQAAAAEAACcQAAAAEMfPodUgwkhlYHjsZcB8wFWhPoWvvoheMBVlcyELY+mjvT6W6M2L1memGWbENv1r7A==", "b1df61d6-9477-45fd-9f6c-e34df22a9465" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22222222-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67008edb-839e-4b35-8389-f2989c2e5837", "AQAAAAEAACcQAAAAEJQD9kAidhQmHVW8OVBxAdvRIyx6NbNJgxwX7Rmqu7k4yU9QlvfidjUNHRdCKQ4AtA==", "b72f781b-6fe9-40b1-8c9c-d6c98c69c70e" });
        }
    }
}
