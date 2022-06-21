using Microsoft.EntityFrameworkCore.Migrations;

namespace app_babybay.Migrations
{
    public partial class V18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropostaAnuncioBabycoin",
                table: "Anuncios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PropostaAnuncioBabycoin",
                table: "Anuncios",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
