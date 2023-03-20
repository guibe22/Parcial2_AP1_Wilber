using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcial2_AP1_Wilber.Migrations
{
    /// <inheritdoc />
    public partial class Empacados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empacados",
                columns: table => new
                {
                    EmpacadosId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Concepto = table.Column<string>(type: "TEXT", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empacados", x => x.EmpacadosId);
                });

            migrationBuilder.CreateTable(
                name: "DetalleEmpacados",
                columns: table => new
                {
                    DetalleEmpacadosId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmpacadosId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleEmpacados", x => x.DetalleEmpacadosId);
                    table.ForeignKey(
                        name: "FK_DetalleEmpacados_Empacados_EmpacadosId",
                        column: x => x.EmpacadosId,
                        principalTable: "Empacados",
                        principalColumn: "EmpacadosId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Empacados");
        }
    }
}
