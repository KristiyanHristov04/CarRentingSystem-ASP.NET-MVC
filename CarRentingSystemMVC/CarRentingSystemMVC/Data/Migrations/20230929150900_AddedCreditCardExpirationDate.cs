using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentingSystemMVC.Data.Migrations
{
    public partial class AddedCreditCardExpirationDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "Rents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "Rents");

        }
    }
}
