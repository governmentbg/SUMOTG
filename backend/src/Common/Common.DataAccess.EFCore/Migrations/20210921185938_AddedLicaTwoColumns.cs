using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class AddedLicaTwoColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nV8",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.AddColumn<int>(
                name: "IdTitulqr",
                schema: "dbo",
                table: "lica",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "V7",
                schema: "dbo",
                table: "lica",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "nV8",
                schema: "dbo",
                table: "lica",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdTitulqr",
                schema: "dbo",
                table: "lica");

            migrationBuilder.DropColumn(
                name: "V7",
                schema: "dbo",
                table: "lica");

            migrationBuilder.DropColumn(
                name: "nV8",
                schema: "dbo",
                table: "lica");

            migrationBuilder.AddColumn<int>(
                name: "nV8",
                schema: "dbo",
                table: "lica_formuliar",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
