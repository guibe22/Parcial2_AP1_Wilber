using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Parcial2_AP1_Wilber.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empacados",
                columns: table => new
                {
                    EmpacadoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Concepto = table.Column<string>(type: "TEXT", nullable: false),
                    Producido = table.Column<int>(type: "INTEGER", nullable: false),
                    CantidadUtilizada = table.Column<int>(type: "INTEGER", nullable: false),
                    CantidadProducida = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empacados", x => x.EmpacadoId);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Costo = table.Column<double>(type: "REAL", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: false),
                    Categoria = table.Column<string>(type: "TEXT", nullable: false),
                    Existencia = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "DetalleEmpacados",
                columns: table => new
                {
                    DetalleEmpacadosId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmpacadosId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleEmpacados", x => x.DetalleEmpacadosId);
                    table.ForeignKey(
                        name: "FK_DetalleEmpacados_Empacados_EmpacadosId",
                        column: x => x.EmpacadosId,
                        principalTable: "Empacados",
                        principalColumn: "EmpacadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Categoria", "Costo", "Descripcion", "Existencia", "Precio" },
                values: new object[,]
                {
                    { 1, "Normal", 10.0, "Mani", 100, 25.0 },
                    { 2, "Normal", 50.0, "Pistachos", 100, 120.0 },
                    { 3, "Normal", 25.0, "Pasas", 100, 50.0 },
                    { 4, "Normal", 25.0, "Ciruelas", 100, 50.0 },
                    { 5, "Empacado", 100.0, "Mixto", 0, 150.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleEmpacados_EmpacadosId",
                table: "DetalleEmpacados",
                column: "EmpacadosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleEmpacados");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Empacados");
        }
    }
}
