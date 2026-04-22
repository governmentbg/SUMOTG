using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class version_111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "status",
                schema: "dbo",
                table: "filtri_adresi",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "facturi_dokumenti",
                schema: "dbo",
                columns: table => new
                {
                    Id_Dok = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFactura = table.Column<int>(type: "int", nullable: false),
                    DocType = table.Column<int>(type: "int", nullable: false),
                    DocDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SavedFileName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Status = table.Column<short>(type: "smallint", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    User = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Koga = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fakturi_dok_Id_Dok", x => x.Id_Dok);
                    table.ForeignKey(
                        name: "FK_factura_docs_factura_main",
                        column: x => x.IdFactura,
                        principalSchema: "dbo",
                        principalTable: "Facturi_Main",
                        principalColumn: "IdFactura",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_facturi_dokumenti_IdFactura",
                schema: "dbo",
                table: "facturi_dokumenti",
                column: "IdFactura");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "facturi_dokumenti",
                schema: "dbo");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                schema: "dbo",
                table: "filtri_adresi",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");
        }
    }
}
