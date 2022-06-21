using Microsoft.EntityFrameworkCore.Migrations;

namespace app_babybay.Migrations
{
    public partial class V14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {    
            migrationBuilder.AddColumn<int>(
                name: "PropostaAnuncioTroca",
                table: "Anuncios",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {       
            migrationBuilder.DropColumn(
                name: "PropostaAnuncioTroca",
                table: "Anuncios");
        }
    }
}
