using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaHub.Infrastructure.Migrations
{
    public partial class AdminRestaurantRelationFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Restaurants_RestaurantId",
                table: "Admins");

            migrationBuilder.DropIndex(
                name: "IX_Admins_RestaurantId",
                table: "Admins");

            migrationBuilder.AlterColumn<int>(
                name: "AdminId",
                table: "Restaurants",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Admins_AdminId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_AdminId",
                table: "Restaurants");

            migrationBuilder.AlterColumn<string>(
                name: "AdminId",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_RestaurantId",
                table: "Admins",
                column: "RestaurantId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Restaurants_RestaurantId",
                table: "Admins",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
