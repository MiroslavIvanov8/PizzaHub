using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaHub.Infrastructure.Migrations
{
    public partial class CustomerCartAddedQuantityColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "CustomerCart",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "CustomerCart");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000856-0000-0000-0000-b893d8395082",
                column: "ConcurrencyStamp",
                value: "35ccd8fe-c8fb-409b-bfd3-8f6bad9441bf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-b893d8395082",
                column: "ConcurrencyStamp",
                value: "0a0f7a34-d4de-406f-989f-3448571807ef");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-b893d8395082",
                column: "ConcurrencyStamp",
                value: "20608177-74f8-4c1c-9474-2eb0e13799c3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46c68d0a-c8a5-464d-b0a0-cedc0ddd9f39", "AQAAAAEAACcQAAAAEIzfOdtT/EkMUXsn5NRF6YK7c7jdI8gCKV9MqsVJJl810iYldvIUUcHKCvPwNpt0Zg==", "1dd558d5-2684-46b1-a39f-21f62f60aa8a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e132490-9c84-49e1-84dd-7b9de097bf41", "AQAAAAEAACcQAAAAEP6ng8IkH1gy7F7H4i8MmX+aUHfkvV17T65kzJl5II2zGobRAHumcuirDOy8y2jIqA==", "4ba0c90c-896c-4fea-8582-5f68e84cd981" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "222220ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8d75f77-a8f8-415f-9e16-cd357a0cac34", "AQAAAAEAACcQAAAAEM8ZORkc0zHoqb4/hVlqC7kZaARZXs5c9GieIjG2LAfgyxZ5g7jvjvPVZVJS8bIgCA==", "af25ffb0-75cd-48c4-b26f-3ce187257ab9" });
        }
    }
}
