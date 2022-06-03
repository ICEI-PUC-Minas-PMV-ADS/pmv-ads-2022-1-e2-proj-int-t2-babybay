using Microsoft.EntityFrameworkCore.Migrations;

namespace app_babybay.Migrations
{
    public partial class V12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnunciooId",
                table: "Trocas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "InteresseTroca",
                table: "Produtos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Trocas_AnunciooId",
                table: "Trocas",
                column: "AnunciooId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trocas_Anuncios_AnunciooId",
                table: "Trocas",
                column: "AnunciooId",
                principalTable: "Anuncios",
                principalColumn: "AnuncioId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trocas_Anuncios_AnunciooId",
                table: "Trocas");

            migrationBuilder.DropIndex(
                name: "IX_Trocas_AnunciooId",
                table: "Trocas");

            migrationBuilder.DropColumn(
                name: "AnunciooId",
                table: "Trocas");

            migrationBuilder.DropColumn(
                name: "InteresseTroca",
                table: "Produtos");
        }
    }
}
