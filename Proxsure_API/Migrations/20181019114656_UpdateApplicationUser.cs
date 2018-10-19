using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proxsure_API.Migrations
{
    public partial class UpdateApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SuscriptionStartDate",
                table: "Suscriptions");

            migrationBuilder.RenameColumn(
                name: "SuscriptionStartDate",
                table: "User",
                newName: "Sus_StartDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sus_StartDate",
                table: "User",
                newName: "SuscriptionStartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "SuscriptionStartDate",
                table: "Suscriptions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
