using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColTurismoAPI.Migrations
{
    public partial class CampofotoTurista : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Turista",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Turista");
        }
    }
}
