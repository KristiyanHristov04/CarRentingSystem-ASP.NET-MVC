using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentingSystemMVC.Data.Migrations
{
    public partial class AddedForeignKeyFromCarsToUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Cars",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5b5a5df0-89da-401f-bd6a-be50dceb212d", 0, "59a17b26-4343-461f-abf2-1d9240025ad4", "user@abv.bg", false, false, null, "USER@ABV.BG", "USER", "AQAAAAEAACcQAAAAEOcL9fSwtAbw0+otmISVHwC/py3V/mUgj6xE5/6PWhQ+zmVvlceorwh5RKoAIIYg6g==", null, false, "e5fffa87-bf65-4c91-9dbb-805af57b976c", false, "user" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "5b5a5df0-89da-401f-bd6a-be50dceb212d");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "5b5a5df0-89da-401f-bd6a-be50dceb212d");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_UserId",
                table: "Cars",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_UserId",
                table: "Cars",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_UserId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_UserId",
                table: "Cars");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5b5a5df0-89da-401f-bd6a-be50dceb212d");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cars");
        }
    }
}
