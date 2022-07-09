using Microsoft.EntityFrameworkCore.Migrations;

namespace app_babybay.Migrations
{
    public partial class V26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnuncioCurtido",
                table: "Anuncios");

            migrationBuilder.AddColumn<int>(
                name: "AnuncioCurtidoId",
                table: "Anuncios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            /*migrationBuilder.AddColumn<int>(
                            name: "AnuncioCurtidoId",
                            table: "Anuncios",
                            type: "int",
                            nullable: false,
                            defaultValue: 0);
                        migrationBuilder.CreateTable(
                            name: "AnunciosCurtidos",
                            columns: table => new
                            {
                                Id = table.Column<int>(type: "int", nullable: false)
                                    .Annotation("SqlServer:Identity", "1, 1"),
                                UsuarioId = table.Column<int>(type: "int", nullable: false)
                            },
                            constraints: table =>
                            {
                                table.PrimaryKey("PK_AnunciosCurtidos", x => x.Id);
                                table.ForeignKey(
                                    name: "FK_AnunciosCurtidos_Usuarios_UsuarioId",
                                    column: x => x.UsuarioId,
                                    principalTable: "Usuarios",
                                    principalColumn: "Id",
                                    onDelete: ReferentialAction.Cascade);
                            });

                        migrationBuilder.CreateIndex(
                            name: "IX_Anuncios_AnuncioCurtidoId",
                            table: "Anuncios",
                            column: "AnuncioCurtidoId");

                        migrationBuilder.CreateIndex(
                            name: "IX_AnunciosCurtidos_UsuarioId",
                            table: "AnunciosCurtidos",
                            column: "UsuarioId");

                        migrationBuilder.AddForeignKey(
                            name: "FK_Anuncios_AnunciosCurtidos_AnuncioCurtidoId",
                            table: "Anuncios",
                            column: "AnuncioCurtidoId",
                            principalTable: "AnunciosCurtidos",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade);
                    }

                    protected override void Down(MigrationBuilder migrationBuilder)
                    {
                        migrationBuilder.DropForeignKey(
                            name: "FK_Anuncios_AnunciosCurtidos_AnuncioCurtidoId",
                            table: "Anuncios");

                        migrationBuilder.DropTable(
                            name: "AnunciosCurtidos");

                        migrationBuilder.DropIndex(
                            name: "IX_Anuncios_AnuncioCurtidoId",
                            table: "Anuncios");

                        migrationBuilder.DropColumn(
                            name: "AnuncioCurtidoId",
                            table: "Anuncios");

                        migrationBuilder.AddColumn<bool>(
                            name: "AnuncioCurtido",
                            table: "Anuncios",
                            type: "bit",
                            nullable: false,
                            defaultValue: false);
                    }
                }*/
        }
    }
}
