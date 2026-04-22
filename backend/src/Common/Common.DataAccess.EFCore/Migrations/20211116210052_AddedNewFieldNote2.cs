using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class AddedNewFieldNote2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rolia",
                schema: "dbo",
                table: "n_statusi");

            migrationBuilder.AddColumn<string>(
                name: "Note2",
                schema: "dbo",
                table: "mon_porychka",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BrDopSp",
                schema: "dbo",
                table: "lica_dogovor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Comentar",
                schema: "dbo",
                table: "lica_dogovor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note2",
                schema: "dbo",
                table: "dem_porychka",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
 
            migrationBuilder.DropColumn(
                name: "Note2",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "BrDopSp",
                schema: "dbo",
                table: "lica_dogovor");

            migrationBuilder.DropColumn(
                name: "Comentar",
                schema: "dbo",
                table: "lica_dogovor");

            migrationBuilder.DropColumn(
                name: "Note2",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.AddColumn<string>(
                name: "Rolia",
                schema: "dbo",
                table: "n_statusi",
                type: "char(1)",
                unicode: false,
                fixedLength: true,
                maxLength: 1,
                nullable: true);
        }
    }
}
