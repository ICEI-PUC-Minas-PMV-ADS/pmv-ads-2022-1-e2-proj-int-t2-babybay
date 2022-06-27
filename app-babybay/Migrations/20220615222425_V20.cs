using Microsoft.EntityFrameworkCore.Migrations;

namespace app_babybay.Migrations
{
    public partial class V20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnuncioId",
                table: "Suportes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Suportes_AnuncioId",
                table: "Suportes",
                column: "AnuncioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suportes_Anuncios_AnuncioId",
                table: "Suportes",
                column: "AnuncioId",
                principalTable: "Anuncios",
                principalColumn: "AnuncioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suportes_Anuncios_AnuncioId",
                table: "Suportes");

            migrationBuilder.DropIndex(
                name: "IX_Suportes_AnuncioId",
                table: "Suportes");

            migrationBuilder.DropColumn(
                name: "AnuncioId",
                table: "Suportes");
        }
    }
}
