using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Parcial2_AP1_Wilber.Migrations
{
    /// <inheritdoc />
    public partial class incial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    Costo = table.Column<double>(type: "REAL", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: false),
                    Existencia = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Costo", "Descripcion", "Existencia", "Precio" },
                values: new object[,]
                {
                    { 1, 10.0, "Mani", 100, 25.0 },
                    { 2, 50.0, "Pistachos", 100, 120.0 },
                    { 3, 25.0, "Pasas", 100, 50.0 },
                    { 4, 25.0, "Ciruelas", 100, 50.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
