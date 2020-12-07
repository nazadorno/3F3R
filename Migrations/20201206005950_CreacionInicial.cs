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
                    Plaza = table.Column<string>(type: "TEXT", nullable: false),
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
                    CP = table.Column<int>(type: "INTEGER", nullable: false),
                    Localidad = table.Column<string>(type: "TEXT", nullable: true),
                    Calle = table.Column<string>(type: "TEXT", nullable: true),
                    PuestoCP = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zonas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Zonas_Puestos_PuestoCP",
                        column: x => x.PuestoCP,
                        principalTable: "Puestos",
                        principalColumn: "CP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zonas_PuestoCP",
                table: "Zonas",
                column: "PuestoCP");
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
