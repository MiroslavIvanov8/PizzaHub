using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaHub.Infrastructure.Migrations
{
    public partial class RemovedOrderPaymentMethodNavigationalPropertyLeftOnlyEnumId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PaymentMethods_PaymentMethodId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PaymentMethodId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000856-0000-0000-0000-b893d8395082",
                column: "ConcurrencyStamp",
                value: "dd08e75b-e12b-45ce-846b-93d99dd93cb1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-b893d8395082",
                column: "ConcurrencyStamp",
                value: "e59b3eb2-a372-4c22-ae6b-55b9da932c62");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-b893d8395082",
                column: "ConcurrencyStamp",
                value: "7f9d31d9-3931-440e-855c-7cca85bed7b1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0405bba7-e70f-420d-b0c9-671d66e59d00", "AQAAAAEAACcQAAAAEMtO1JonvztpsfXaPNrmMKczqnw36051niPOAzfNeU12kyYKtjIcmYG7i77H+thxDQ==", "f415a803-a117-418a-89b1-c0f3261f5be4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "198d5e59-624e-4407-be33-68cd2199a67d", "AQAAAAEAACcQAAAAECd+32ndi51TD01of1wAGfGjwKh9VNAAkehdfn0E3irOS73oei89l1uTgsb15VDfZA==", "33f2213d-8024-4994-b067-6d4b1a425c54" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "222220ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55ecdfdb-b1c1-4803-98a3-77d6736fd4ea", "AQAAAAEAACcQAAAAEJ0Y0T73DvqbuGeOJ29eb4Obcnyp9h8zwS8oVqAK/15cI+e8ya6UNsdjpTF8ExzOUQ==", "ba4d4b91-adb8-4f7f-b900-5932fb1b05d7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000856-0000-0000-0000-b893d8395082",
                column: "ConcurrencyStamp",
                value: "59010c42-15f4-4549-94eb-30c91c2eeec1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-b893d8395082",
                column: "ConcurrencyStamp",
                value: "3eb3fb5e-6a62-47fb-9b46-95cf0219e456");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-b893d8395082",
                column: "ConcurrencyStamp",
                value: "0e82a591-b182-4c46-aebc-720e4808685b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5bede36-e6d0-4f20-9a3e-890686237c37", "AQAAAAEAACcQAAAAECZilxE630G60yeaGOqzy0lLjH0tXJ5+lwScRpedZ7+oesKR/IzT9H2lCW6jSj4W1Q==", "24ca37eb-deb6-42fe-8e73-a61bb1e5bf02" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05c77637-6c9b-411b-a32d-5888de134be2", "AQAAAAEAACcQAAAAENvzCi9y3iOVKvScMW2EIvtPY1+Ao6nsCTxdZtLaV35bypkKwWiZKcujD2qhwX7+5w==", "b4db5e7a-f4bd-4e77-bfb9-f0ba136b7fdf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "222220ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25ae3b35-d34f-4e7f-9ba0-76f66c6c1642", "AQAAAAEAACcQAAAAEP4HYaMvFM51iQjN61kYFFqH2px08E493T1SAXPHAXNfSItqCp/8BgUPRGc/o4jT+Q==", "93d683ca-02a7-4433-8f59-caae8ed0157e" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentMethodId",
                table: "Orders",
                column: "PaymentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_PaymentMethods_PaymentMethodId",
                table: "Orders",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id");
        }
    }
}
