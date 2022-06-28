using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaMG.Migrations
{
    public partial class migration280622 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "Contacto",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "Categoria",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "Contacto");

            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "Categoria");
        }
    }
}
