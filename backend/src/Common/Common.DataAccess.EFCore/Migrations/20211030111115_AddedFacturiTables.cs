using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class AddedFacturiTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdFactura",
                schema: "dbo",
                table: "mon_porychka",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                schema: "dbo",
                table: "mon_dgv_uredi",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdFactura",
                schema: "dbo",
                table: "dem_porychka",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Facturi_Main",
                schema: "dbo",
                columns: table => new
                {
                    IdFactura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VidFirma = table.Column<int>(type: "int", nullable: false),
                    IdFirma = table.Column<int>(type: "int", nullable: false),
                    FacNomer = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    FacData = table.Column<DateTime>(type: "datetime", nullable: false),
                    DogNomer = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    DogData = table.Column<DateTime>(type: "datetime", nullable: false),
                    Suma = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DDS = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    BroiFiles = table.Column<short>(type: "smallint", nullable: false),
                    Status = table.Column<short>(type: "smallint", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_factura_main_IdFactura", x => x.IdFactura);
                    table.ForeignKey(
                        name: "FK_facturi_main_firmi",
                        column: x => x.IdFirma,
                        principalSchema: "dbo",
                        principalTable: "firmi",
                        principalColumn: "IdFirma",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facturi_Rows",
                schema: "dbo",
                columns: table => new
                {
                    IdRow = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFactura = table.Column<int>(type: "int", nullable: true),
                    IdKn = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    Ed_cena = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    Broi = table.Column<int>(type: "int", nullable: false),
                    Suma = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Status = table.Column<short>(type: "smallint", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facturirows_IdRow", x => x.IdRow);
                    table.ForeignKey(
                        name: "FK_factura_rows_factura_main",
                        column: x => x.IdFactura,
                        principalSchema: "dbo",
                        principalTable: "Facturi_Main",
                        principalColumn: "IdFactura",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Facturi_Main_IdFirma",
                schema: "dbo",
                table: "Facturi_Main",
                column: "IdFirma");

            migrationBuilder.CreateIndex(
                name: "IX_Facturi_Rows_IdFactura",
                schema: "dbo",
                table: "Facturi_Rows",
                column: "IdFactura");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facturi_Rows",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Facturi_Main",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "IdFactura",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "Model",
                schema: "dbo",
                table: "mon_dgv_uredi");

            migrationBuilder.DropColumn(
                name: "IdFactura",
                schema: "dbo",
                table: "dem_porychka");
        }
    }
}
