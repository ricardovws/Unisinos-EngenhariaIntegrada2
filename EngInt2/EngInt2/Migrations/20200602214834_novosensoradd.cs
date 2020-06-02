using Microsoft.EntityFrameworkCore.Migrations;

namespace EngInt2.Migrations
{
    public partial class novosensoradd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UmidadeSolo",
                table: "SensorTemperaturaUmidade",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UmidadeSolo",
                table: "SensorTemperaturaUmidade");
        }
    }
}
