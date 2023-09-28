using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentingSystemMVC.Data.Migrations
{
    public partial class AddedManyThings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreditCardCVV = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarBrand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CarModel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Days = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rents_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            
            migrationBuilder.CreateIndex(
                name: "IX_Rents_UserId",
                table: "Rents",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rents");

            //migrationBuilder.DeleteData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "b538390a-8d29-4091-a3d6-8c5a83399458");

            //migrationBuilder.InsertData(
            //    table: "AspNetUsers",
            //    columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
            //    values: new object[] { "5b5a5df0-89da-401f-bd6a-be50dceb212d", 0, "59a17b26-4343-461f-abf2-1d9240025ad4", "user@abv.bg", true, false, null, "USER@ABV.BG", "USER", "AQAAAAEAACcQAAAAEOcL9fSwtAbw0+otmISVHwC/py3V/mUgj6xE5/6PWhQ+zmVvlceorwh5RKoAIIYg6g==", null, false, "e5fffa87-bf65-4c91-9dbb-805af57b976c", false, "user" });

            //migrationBuilder.UpdateData(
            //    table: "Cars",
            //    keyColumn: "Id",
            //    keyValue: 1,
            //    column: "UserId",
            //    value: "5b5a5df0-89da-401f-bd6a-be50dceb212d");

            //migrationBuilder.UpdateData(
            //    table: "Cars",
            //    keyColumn: "Id",
            //    keyValue: 2,
            //    column: "UserId",
            //    value: "5b5a5df0-89da-401f-bd6a-be50dceb212d");
        }
    }
}
