using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace app_babybay.Migrations
{
    public partial class V10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AnuncioCurtido",
                table: "Anuncios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ContadorCurtidas",
                table: "Anuncios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
              name: "Date",
              table: "Anuncios",
              type: "datetime2",   
             nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnuncioCurtido",
                table: "Anuncios");

            migrationBuilder.DropColumn(
                name: "ContadorCurtidas",
                table: "Anuncios");
        }
    }
}
