using Microsoft.EntityFrameworkCore.Migrations;

namespace Proxsure_Auth.Migrations
{
    public partial class AddingSuscriptionToApplicationDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Suscription_SuscriptionId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suscription",
                table: "Suscription");

            migrationBuilder.RenameTable(
                name: "Suscription",
                newName: "Suscriptions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suscriptions",
                table: "Suscriptions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Suscriptions_SuscriptionId",
                table: "User",
                column: "SuscriptionId",
                principalTable: "Suscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Suscriptions_SuscriptionId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suscriptions",
                table: "Suscriptions");

            migrationBuilder.RenameTable(
                name: "Suscriptions",
                newName: "Suscription");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suscription",
                table: "Suscription",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Suscription_SuscriptionId",
                table: "User",
                column: "SuscriptionId",
                principalTable: "Suscription",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
