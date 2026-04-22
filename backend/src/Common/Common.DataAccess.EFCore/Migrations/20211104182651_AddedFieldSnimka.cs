using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class AddedFieldSnimka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Snimka",
                schema: "dbo",
                table: "mon_porychka",
                type: "nvarchar(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Snimka",
                schema: "dbo",
                table: "dem_porychka",
                type: "nvarchar(MAX)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Snimka",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "Snimka",
                schema: "dbo",
                table: "dem_porychka");
        }
    }
}
