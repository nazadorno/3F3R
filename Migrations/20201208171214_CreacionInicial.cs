using Microsoft.EntityFrameworkCore.Migrations;

namespace _3F3R.Migrations
{
    public partial class CreacionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Puestos",
                columns: table => new
                {
                    CP = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Latitud = table.Column<double>(type: "REAL", nullable: false),
                    Longitud = table.Column<double>(type: "REAL", nullable: false),
                    Plaza = table.Column<string>(type: "TEXT", nullable: true),
                    Calle = table.Column<string>(type: "TEXT", nullable: true),
                    Altura = table.Column<int>(type: "INTEGER", nullable: false),
                    Horarios = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puestos", x => x.CP);
                });

            migrationBuilder.CreateTable(
                name: "Zonas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Latitud = table.Column<double>(type: "REAL", nullable: false),
                    Longitud = table.Column<double>(type: "REAL", nullable: false),
                    CP = table.Column<int>(type: "INTEGER", nullable: false),
                    Localidad = table.Column<string>(type: "TEXT", nullable: true),
                    Calle = table.Column<string>(type: "TEXT", nullable: true),
                    Altura = table.Column<int>(type: "INTEGER", nullable: false),
                    PuestoCercanoCP = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zonas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Zonas_Puestos_PuestoCercanoCP",
                        column: x => x.PuestoCercanoCP,
                        principalTable: "Puestos",
                        principalColumn: "CP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zonas_PuestoCercanoCP",
                table: "Zonas",
                column: "PuestoCercanoCP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zonas");

            migrationBuilder.DropTable(
                name: "Puestos");
        }
    }
}
