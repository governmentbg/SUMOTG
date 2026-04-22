using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class AddedSequncesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_factura_rows_factura_main",
                schema: "dbo",
                table: "Facturi_Rows");

            migrationBuilder.AlterColumn<int>(
                name: "IdFactura",
                schema: "dbo",
                table: "Facturi_Rows",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FacData",
                schema: "dbo",
                table: "Facturi_Main",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.CreateTable(
                name: "Sequences",
                schema: "dbo",
                columns: table => new
                {
                    seqname = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    seqval = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sequences", x => x.seqname);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_factura_rows_factura_main",
                schema: "dbo",
                table: "Facturi_Rows",
                column: "IdFactura",
                principalSchema: "dbo",
                principalTable: "Facturi_Main",
                principalColumn: "IdFactura",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_factura_rows_factura_main",
                schema: "dbo",
                table: "Facturi_Rows");

            migrationBuilder.DropTable(
                name: "Sequences",
                schema: "dbo");

            migrationBuilder.AlterColumn<int>(
                name: "IdFactura",
                schema: "dbo",
                table: "Facturi_Rows",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FacData",
                schema: "dbo",
                table: "Facturi_Main",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_factura_rows_factura_main",
                schema: "dbo",
                table: "Facturi_Rows",
                column: "IdFactura",
                principalSchema: "dbo",
                principalTable: "Facturi_Main",
                principalColumn: "IdFactura",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
