using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentingSystemMVC.Data.Migrations
{
    public partial class EmptyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d7ddf06-ab1f-49d9-9312-a63669fc7f59");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "16c3ef47-184c-4159-9045-e571c48489c8", 0, "ef1ffe4d-e3f0-48e8-b098-6ddc4bdff29a", "user@abv.bg", true, false, null, "USER@ABV.BG", "USER", "AQAAAAEAACcQAAAAELqxz+m/d42gXU57Ufmo4XxPv6moIR5N2KNq/x3KmYDVww3G8Q8JmTqqz5PqbXLlAQ==", null, false, "7d03d657-b6df-45d5-a57a-715ba6741ed6", false, "user" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "16c3ef47-184c-4159-9045-e571c48489c8");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "16c3ef47-184c-4159-9045-e571c48489c8");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "16c3ef47-184c-4159-9045-e571c48489c8");

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
    }
}
