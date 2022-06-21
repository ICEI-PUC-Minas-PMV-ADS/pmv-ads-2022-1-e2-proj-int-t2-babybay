using Microsoft.EntityFrameworkCore.Migrations;

namespace app_babybay.Migrations
{
    public partial class V16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {        
            migrationBuilder.AddColumn<int>(
                name: "PropostaAnuncioBabycoin",
                table: "Anuncios",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropostaAnuncioBabycoin",
                table: "Anuncios");

        }
    }
}
