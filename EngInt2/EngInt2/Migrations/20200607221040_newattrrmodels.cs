using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EngInt2.Migrations
{
    public partial class newattrrmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "horarioAgora",
                table: "Configuracoes");

            migrationBuilder.RenameColumn(
                name: "horarioParaLigar",
                table: "Configuracoes",
                newName: "horarioInicial");

            migrationBuilder.RenameColumn(
                name: "horarioParaDesligar",
                table: "Configuracoes",
                newName: "horarioFinal");

            migrationBuilder.AddColumn<bool>(
                name: "statusReferencia",
                table: "Configuracoes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "tempoDesligado",
                table: "Configuracoes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "tempoLigado",
                table: "Configuracoes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "statusReferencia",
                table: "Configuracoes");

            migrationBuilder.DropColumn(
                name: "tempoDesligado",
                table: "Configuracoes");

            migrationBuilder.DropColumn(
                name: "tempoLigado",
                table: "Configuracoes");

            migrationBuilder.RenameColumn(
                name: "horarioInicial",
                table: "Configuracoes",
                newName: "horarioParaLigar");

            migrationBuilder.RenameColumn(
                name: "horarioFinal",
                table: "Configuracoes",
                newName: "horarioParaDesligar");

            migrationBuilder.AddColumn<DateTime>(
                name: "horarioAgora",
                table: "Configuracoes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
