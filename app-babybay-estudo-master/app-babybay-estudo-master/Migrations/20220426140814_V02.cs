using Microsoft.EntityFrameworkCore.Migrations;

namespace app_babybay.Migrations
{
    public partial class V02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GuardaRoupaId",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GuardaRoupas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QntdProduto = table.Column<int>(type: "int", nullable: false),
                    ProdutoFavorito = table.Column<bool>(type: "bit", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuardaRoupas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuardaRoupas_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_GuardaRoupaId",
                table: "Produtos",
                column: "GuardaRoupaId");

            migrationBuilder.CreateIndex(
                name: "IX_GuardaRoupas_ProdutoId",
                table: "GuardaRoupas",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_GuardaRoupas_GuardaRoupaId",
                table: "Produtos",
                column: "GuardaRoupaId",
                principalTable: "GuardaRoupas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_GuardaRoupas_GuardaRoupaId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "GuardaRoupas");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_GuardaRoupaId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "GuardaRoupaId",
                table: "Produtos");
        }
    }
}
