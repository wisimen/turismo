using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColTurismoAPI.Migrations
{
    public partial class CreacionTablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hoteles",
                columns: table => new
                {
                    CodHotel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    NumPlazas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoteles", x => x.CodHotel);
                });

            migrationBuilder.CreateTable(
                name: "Sucursal",
                columns: table => new
                {
                    CodSucursal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursal", x => x.CodSucursal);
                });

            migrationBuilder.CreateTable(
                name: "Turista",
                columns: table => new
                {
                    CodTurista = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turista", x => x.CodTurista);
                });

            migrationBuilder.CreateTable(
                name: "Vuelo",
                columns: table => new
                {
                    NumeroVuelo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    Hora = table.Column<TimeSpan>(type: "time", nullable: false),
                    Origen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PlazaTotal = table.Column<int>(type: "int", nullable: false),
                    PlazaTurista = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vuelo", x => x.NumeroVuelo);
                });

            migrationBuilder.CreateTable(
                name: "ContratoSucursal",
                columns: table => new
                {
                    CodSucursal = table.Column<int>(type: "int", nullable: false),
                    CodTurista = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratoSucursal", x => new { x.CodSucursal, x.CodTurista });
                    table.ForeignKey(
                        name: "FK_ContratoSucursal_Sucursal_CodSucursal",
                        column: x => x.CodSucursal,
                        principalTable: "Sucursal",
                        principalColumn: "CodSucursal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratoSucursal_Turista_CodTurista",
                        column: x => x.CodTurista,
                        principalTable: "Turista",
                        principalColumn: "CodTurista",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservaHotel",
                columns: table => new
                {
                    CodHotel = table.Column<int>(type: "int", nullable: false),
                    CodTurista = table.Column<int>(type: "int", nullable: false),
                    CodReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Regimen = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaHotel", x => new { x.CodTurista, x.CodHotel });
                    table.ForeignKey(
                        name: "FK_ReservaHotel_Hoteles_CodHotel",
                        column: x => x.CodHotel,
                        principalTable: "Hoteles",
                        principalColumn: "CodHotel",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservaHotel_Turista_CodTurista",
                        column: x => x.CodTurista,
                        principalTable: "Turista",
                        principalColumn: "CodTurista",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservaVuelo",
                columns: table => new
                {
                    NumeroVuelo = table.Column<int>(type: "int", nullable: false),
                    CodTurista = table.Column<int>(type: "int", nullable: false),
                    Clase = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaVuelo", x => new { x.NumeroVuelo, x.CodTurista });
                    table.ForeignKey(
                        name: "FK_ReservaVuelo_Turista_CodTurista",
                        column: x => x.CodTurista,
                        principalTable: "Turista",
                        principalColumn: "CodTurista",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservaVuelo_Vuelo_NumeroVuelo",
                        column: x => x.NumeroVuelo,
                        principalTable: "Vuelo",
                        principalColumn: "NumeroVuelo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContratoSucursal_CodTurista",
                table: "ContratoSucursal",
                column: "CodTurista");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaHotel_CodHotel",
                table: "ReservaHotel",
                column: "CodHotel");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaVuelo_CodTurista",
                table: "ReservaVuelo",
                column: "CodTurista");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContratoSucursal");

            migrationBuilder.DropTable(
                name: "ReservaHotel");

            migrationBuilder.DropTable(
                name: "ReservaVuelo");

            migrationBuilder.DropTable(
                name: "Sucursal");

            migrationBuilder.DropTable(
                name: "Hoteles");

            migrationBuilder.DropTable(
                name: "Turista");

            migrationBuilder.DropTable(
                name: "Vuelo");
        }
    }
}
