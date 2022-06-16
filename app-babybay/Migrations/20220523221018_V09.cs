using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace app_babybay.Migrations
{
    public partial class V09 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SuporteId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Suportes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    TextoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextoSuporte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suportes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suportes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_SuporteId",
                table: "Usuarios",
                column: "SuporteId");

            migrationBuilder.CreateIndex(
                name: "IX_Suportes_UsuarioId",
                table: "Suportes",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Suportes_SuporteId",
                table: "Usuarios",
                column: "SuporteId",
                principalTable: "Suportes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Suportes_SuporteId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Suportes");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_SuporteId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "SuporteId",
                table: "Usuarios");
        }
    }
}
