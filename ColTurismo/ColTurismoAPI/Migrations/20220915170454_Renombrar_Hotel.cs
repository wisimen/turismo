using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColTurismoAPI.Migrations
{
    public partial class Renombrar_Hotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservaHotel_Hoteles_CodHotel",
                table: "ReservaHotel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hoteles",
                table: "Hoteles");

            migrationBuilder.RenameTable(
                name: "Hoteles",
                newName: "Hotel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hotel",
                table: "Hotel",
                column: "CodHotel");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaHotel_Hotel_CodHotel",
                table: "ReservaHotel",
                column: "CodHotel",
                principalTable: "Hotel",
                principalColumn: "CodHotel",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservaHotel_Hotel_CodHotel",
                table: "ReservaHotel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hotel",
                table: "Hotel");

            migrationBuilder.RenameTable(
                name: "Hotel",
                newName: "Hoteles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hoteles",
                table: "Hoteles",
                column: "CodHotel");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaHotel_Hoteles_CodHotel",
                table: "ReservaHotel",
                column: "CodHotel",
                principalTable: "Hoteles",
                principalColumn: "CodHotel",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
