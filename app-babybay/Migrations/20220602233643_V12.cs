using Microsoft.EntityFrameworkCore.Migrations;

namespace app_babybay.Migrations
{
    public partial class V12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnuncioId",
                table: "Trocas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trocas_AnuncioId",
                table: "Trocas",
                column: "AnuncioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trocas_Anuncios_AnuncioId",
                table: "Trocas",
                column: "AnuncioId",
                principalTable: "Anuncios",
                principalColumn: "AnuncioId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trocas_Anuncios_AnuncioId",
                table: "Trocas");

            migrationBuilder.DropIndex(
                name: "IX_Trocas_AnuncioId",
                table: "Trocas");

            migrationBuilder.DropColumn(
                name: "AnuncioId",
                table: "Trocas");
        }
    }
}
