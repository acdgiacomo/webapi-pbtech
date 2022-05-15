using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PBTech.WebAPI.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AlternateKey_Email",
                table: "Usuarios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AlternateKey_Email",
                table: "Usuarios",
                column: "Email");
        }
    }
}
