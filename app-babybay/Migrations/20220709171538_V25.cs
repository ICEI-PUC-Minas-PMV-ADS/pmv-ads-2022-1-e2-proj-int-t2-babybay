using Microsoft.EntityFrameworkCore.Migrations;

namespace app_babybay.Migrations
{
    public partial class V25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnunciosCurtidos",
                columns: table  => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AnuncioCod = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                },
           constraints: table =>
           {
               table.PrimaryKey("PK_AnunciosCurtidos", x => x.Id);
               table.ForeignKey(
                   name: "FK_AnunciosCurtidos_Usuarios_UsuarioId",
                   column: x => x.UsuarioId,
                   principalTable: "Usuarios",
                   principalColumn: "Id",
                   onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                   name: "FK_AnunciosCurtidos_Anuncios_AnuncioCod",
                   column: x => x.AnuncioCod,
                   principalTable: "Anuncios",
                   principalColumn: "AnuncioId",
                   onDelete: ReferentialAction.Restrict);
           });

            migrationBuilder.CreateIndex(
             name: "IX_AnunciosCurtidos_UsuarioId",
             table: "AnunciosCurtidos",
             column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_AnunciosCurtidos_AnuncioCod",
                table: "AnunciosCurtidos",
                column: "AnuncioCod");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
              name: "AnunciosCurtidos");
        }
    }
}
