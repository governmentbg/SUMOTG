using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class RenameColumnGarancia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GarCardData",
                schema: "dbo",
                table: "mon_porychka",
                newName: "GaranciaData");

            migrationBuilder.AddColumn<string>(
                name: "GaranciaCard",
                schema: "dbo",
                table: "mon_porychka",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GaranciaCard",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.RenameColumn(
                name: "GaranciaData",
                schema: "dbo",
                table: "mon_porychka",
                newName: "GarCardData");
        }
    }
}
