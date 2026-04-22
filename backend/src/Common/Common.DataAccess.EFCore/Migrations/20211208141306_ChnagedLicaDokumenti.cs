using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class ChnagedLicaDokumenti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Faza",
                schema: "dbo",
                table: "lica_dokumenti");

            migrationBuilder.DropColumn(
                name: "Status_DD",
                schema: "dbo",
                table: "lica_dokumenti");

            migrationBuilder.DropColumn(
                name: "Text_Dok",
                schema: "dbo",
                table: "lica_dokumenti");

            migrationBuilder.RenameColumn(
                name: "ID_KN",
                schema: "dbo",
                table: "lica_dokumenti",
                newName: "DocType");

            migrationBuilder.AddColumn<string>(
                name: "DocDescription",
                schema: "dbo",
                table: "lica_dokumenti",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                schema: "dbo",
                table: "lica_dokumenti",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SavedFileName",
                schema: "dbo",
                table: "lica_dokumenti",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocDescription",
                schema: "dbo",
                table: "lica_dokumenti");

            migrationBuilder.DropColumn(
                name: "FileName",
                schema: "dbo",
                table: "lica_dokumenti");

            migrationBuilder.DropColumn(
                name: "SavedFileName",
                schema: "dbo",
                table: "lica_dokumenti");

            migrationBuilder.RenameColumn(
                name: "DocType",
                schema: "dbo",
                table: "lica_dokumenti",
                newName: "ID_KN");

            migrationBuilder.AddColumn<short>(
                name: "Faza",
                schema: "dbo",
                table: "lica_dokumenti",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "Status_DD",
                schema: "dbo",
                table: "lica_dokumenti",
                type: "smallint",
                unicode: false,
                fixedLength: true,
                maxLength: 1,
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<string>(
                name: "Text_Dok",
                schema: "dbo",
                table: "lica_dokumenti",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);
        }
    }
}
