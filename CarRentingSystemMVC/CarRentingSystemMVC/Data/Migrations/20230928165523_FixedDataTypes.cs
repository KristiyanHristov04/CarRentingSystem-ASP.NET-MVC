using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentingSystemMVC.Data.Migrations
{
    public partial class FixedDataTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4da1afa-aa7a-463a-b5c5-a468e4a4e58e");

            migrationBuilder.AlterColumn<string>(
                name: "CreditCardCVV",
                table: "Rents",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8d7ddf06-ab1f-49d9-9312-a63669fc7f59", 0, "3ef1d0c7-cae0-4981-b026-57c078270781", "user@abv.bg", true, false, null, "USER@ABV.BG", "USER", "AQAAAAEAACcQAAAAEKJBb2E+t0PRtHoxlf4ttVa2957RPFheCwSc0fiRHpU/JHxW/nuavCTM2AhY9CxXKw==", null, false, "98463cd2-0fa3-4cbf-9f83-01e748b4820a", false, "user" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "8d7ddf06-ab1f-49d9-9312-a63669fc7f59");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "8d7ddf06-ab1f-49d9-9312-a63669fc7f59");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d7ddf06-ab1f-49d9-9312-a63669fc7f59");

            migrationBuilder.AlterColumn<int>(
                name: "CreditCardCVV",
                table: "Rents",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e4da1afa-aa7a-463a-b5c5-a468e4a4e58e", 0, "b8c1c661-7fa4-4532-a85a-ff9151f70888", "user@abv.bg", true, false, null, "USER@ABV.BG", "USER", "AQAAAAEAACcQAAAAEO7k1KvGzJM55DUQ2gTxvta8lu3tAUrSlDWpbkVFMjGszQO8LbI5Q0Iij8v/PvAuSg==", null, false, "42598ad9-5179-4ae2-b40a-b3c9b28a6f32", false, "user" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "e4da1afa-aa7a-463a-b5c5-a468e4a4e58e");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "e4da1afa-aa7a-463a-b5c5-a468e4a4e58e");
        }
    }
}
