using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proxsure_API.Migrations
{
    public partial class RemovingStartDateFromSuscription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SuscriptionStartDate",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SuscriptionStartDate",
                table: "User");
        }
    }
}
