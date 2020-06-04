using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EngInt2.Migrations
{
    public partial class novoAtributoDeTempo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "horarioAgora",
                table: "Configuracoes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "horarioParaDesligar",
                table: "Configuracoes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "horarioParaLigar",
                table: "Configuracoes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "horarioAgora",
                table: "Configuracoes");

            migrationBuilder.DropColumn(
                name: "horarioParaDesligar",
                table: "Configuracoes");

            migrationBuilder.DropColumn(
                name: "horarioParaLigar",
                table: "Configuracoes");
        }
    }
}
