using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _5544___Group_4_TALLER.Migrations
{
    /// <inheritdoc />
    public partial class MigraciondeDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipo",
                columns: table => new
                {
                    EquipoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Presupuesto = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipo", x => x.EquipoID);
                });

            migrationBuilder.CreateTable(
                name: "Jugador",
                columns: table => new
                {
                    JugadorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroCamiseta = table.Column<int>(type: "int", nullable: false),
                    Goles = table.Column<int>(type: "int", nullable: false),
                    Asistencias = table.Column<int>(type: "int", nullable: false),
                    Sueldo = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugador", x => x.JugadorID);
                    table.ForeignKey(
                        name: "FK_Jugador_Equipo_EquipoID",
                        column: x => x.EquipoID,
                        principalTable: "Equipo",
                        principalColumn: "EquipoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Partido",
                columns: table => new
                {
                    PartidoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jugados = table.Column<int>(type: "int", nullable: false),
                    Ganados = table.Column<int>(type: "int", nullable: false),
                    Empatados = table.Column<int>(type: "int", nullable: false),
                    Perdidos = table.Column<int>(type: "int", nullable: false),
                    EquipoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partido", x => x.PartidoID);
                    table.ForeignKey(
                        name: "FK_Partido_Equipo_EquipoID",
                        column: x => x.EquipoID,
                        principalTable: "Equipo",
                        principalColumn: "EquipoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TablaPosiciones",
                columns: table => new
                {
                    TablaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Puntos = table.Column<int>(type: "int", nullable: false),
                    PartidosJugados = table.Column<int>(type: "int", nullable: false),
                    DiferenciaGol = table.Column<int>(type: "int", nullable: false),
                    PosicionActual = table.Column<int>(type: "int", nullable: false),
                    EquipoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablaPosiciones", x => x.TablaID);
                    table.ForeignKey(
                        name: "FK_TablaPosiciones_Equipo_EquipoID",
                        column: x => x.EquipoID,
                        principalTable: "Equipo",
                        principalColumn: "EquipoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jugador_EquipoID",
                table: "Jugador",
                column: "EquipoID");

            migrationBuilder.CreateIndex(
                name: "IX_Partido_EquipoID",
                table: "Partido",
                column: "EquipoID");

            migrationBuilder.CreateIndex(
                name: "IX_TablaPosiciones_EquipoID",
                table: "TablaPosiciones",
                column: "EquipoID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jugador");

            migrationBuilder.DropTable(
                name: "Partido");

            migrationBuilder.DropTable(
                name: "TablaPosiciones");

            migrationBuilder.DropTable(
                name: "Equipo");
        }
    }
}
