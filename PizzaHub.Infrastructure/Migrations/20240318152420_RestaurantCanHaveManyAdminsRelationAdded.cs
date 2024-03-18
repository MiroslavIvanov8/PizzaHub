using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaHub.Infrastructure.Migrations
{
    public partial class RestaurantCanHaveManyAdminsRelationAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Admins_AdminId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_AdminId",
                table: "Restaurants");

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Restaurants");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "Admins",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000856-0000-0000-0000-b893d8395082",
                column: "ConcurrencyStamp",
                value: "60533d28-a208-48ad-896d-8ed1c942f6de");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-b893d8395082",
                column: "ConcurrencyStamp",
                value: "1945e331-5015-46ee-ad33-7f799782e3c0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-b893d8395082",
                column: "ConcurrencyStamp",
                value: "0036cc04-8d2b-4fb2-8512-cab0c68a7e2a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc031ca6-8520-4d67-a0ec-ebe6bc82b860", "AQAAAAEAACcQAAAAEII1xtyOPlAzf/Wp4xg1IUtmTBZV49MjO5uLWaHXSxHMDwvF1fio7dFFrKV5jcvepQ==", "f0d7a5e1-1c49-458b-9b81-814a383aaca1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e736baa3-1652-41e1-9b1c-9f395b3e7535", "AQAAAAEAACcQAAAAEFzKPn/6sU9WJ45094pr6ehq5/yYeRBZLDeUIan7Xhrve1fc8blSj8y+ImKgQV4W7A==", "d1f8dab6-821d-4d0c-a4f1-e4813d11f69f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "222220ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c76ca4fe-e4e9-4be5-b175-9dff2f2ec6d2", "AQAAAAEAACcQAAAAEAP9uxiu+WSZFIjbYHxY/Nk1Qq2z+gF03prkPjCfWEd1IzZOpRSiKY54kT8tCilBLA==", "00f10a4f-53d3-4a89-a928-d2be4da2ec5d" });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_RestaurantId",
                table: "Admins",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Restaurants_RestaurantId",
                table: "Admins",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Restaurants_RestaurantId",
                table: "Admins");

            migrationBuilder.DropIndex(
                name: "IX_Admins_RestaurantId",
                table: "Admins");

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Restaurants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "Admins",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "RestaurantId", "UserId" },
                values: new object[] { 1, 1, "00000856-c198-4129-b3f3-b893d8395082" });

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
                table: "Restaurants",
                columns: new[] { "Id", "AdminId", "Name" },
                values: new object[] { 1, 1, "PizzaHub" });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_AdminId",
                table: "Restaurants",
                column: "AdminId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Admins_AdminId",
                table: "Restaurants",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
