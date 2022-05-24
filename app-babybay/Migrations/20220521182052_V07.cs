using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace app_babybay.Migrations
{
    public partial class V07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)   // Deixar essa migration comentada, está dando conflito
        {                      

            migrationBuilder.CreateTable(
                name: "Anuncios",
                columns: table => new
                {
                    AnuncioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anuncios", x => x.AnuncioId);
                    table.ForeignKey(
                        name: "FK_Anuncios_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Anuncios_Usuarios_UsuarioId",
                       column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

           migrationBuilder.CreateIndex(
               name: "IX_Anuncios_ProdutoId",
               table: "Anuncios",
               column: "ProdutoId");
 
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "Anuncios");

            migrationBuilder.DropColumn(
                name: "ProdutoCurtido",
                table: "Produtos");

        }
    }
}
