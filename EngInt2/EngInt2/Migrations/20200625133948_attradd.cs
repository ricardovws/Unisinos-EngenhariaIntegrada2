using Microsoft.EntityFrameworkCore.Migrations;

namespace EngInt2.Migrations
{
    public partial class attradd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "temperaturaTerminar",
                table: "Configuracoes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "umidadeTerminar",
                table: "Configuracoes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "temperaturaTerminar",
                table: "Configuracoes");

            migrationBuilder.DropColumn(
                name: "umidadeTerminar",
                table: "Configuracoes");
        }
    }
}
