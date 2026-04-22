using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class KorekciqLicaDogovor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lica_dogovor_lica",
                schema: "dbo",
                table: "lica_dogovor");

            migrationBuilder.DropColumn(
                name: "U_Nom",
                schema: "dbo",
                table: "lica_dogovor");

            migrationBuilder.AlterColumn<int>(
                name: "Id_L",
                schema: "dbo",
                table: "lica_dogovor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Faza",
                schema: "dbo",
                table: "lica_dogovor",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_lica_dogovor_lica",
                schema: "dbo",
                table: "lica_dogovor",
                column: "Id_L",
                principalSchema: "dbo",
                principalTable: "lica",
                principalColumn: "ID_L",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lica_dogovor_lica",
                schema: "dbo",
                table: "lica_dogovor");

            migrationBuilder.AlterColumn<int>(
                name: "Id_L",
                schema: "dbo",
                table: "lica_dogovor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<short>(
                name: "Faza",
                schema: "dbo",
                table: "lica_dogovor",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AddColumn<string>(
                name: "U_Nom",
                schema: "dbo",
                table: "lica_dogovor",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_lica_dogovor_lica",
                schema: "dbo",
                table: "lica_dogovor",
                column: "Id_L",
                principalSchema: "dbo",
                principalTable: "lica",
                principalColumn: "ID_L",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
