using Microsoft.EntityFrameworkCore.Migrations;

namespace app_babybay.Migrations
{
    public partial class V13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Anuncios",
                type: "int",
                nullable: true);   Deixqar essa linha comentada*/

            migrationBuilder.AddColumn<string>(
                name: "NomeInteressado",
                table: "Anuncios",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Anuncios");

            migrationBuilder.DropColumn(
                name: "NomeInteressado",
                table: "Anuncios");
        }
    }
}
