using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiblioLink.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablaLibros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Autores = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    ISBN = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Editorial = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    AnioPublicacion = table.Column<int>(type: "INTEGER", nullable: false),
                    UbicacionFisica = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CantidadTotal = table.Column<int>(type: "INTEGER", nullable: false),
                    CantidadDisponible = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.Id);
                    table.CheckConstraint("CK_Libros_Stock", "CantidadDisponible >= 0 AND CantidadDisponible <= CantidadTotal");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libros_ISBN",
                table: "Libros",
                column: "ISBN",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libros");
        }
    }
}
