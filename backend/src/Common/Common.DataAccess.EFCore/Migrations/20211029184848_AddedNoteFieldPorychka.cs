using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class AddedNoteFieldPorychka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusP",
                schema: "dbo",
                table: "dem_porychka",
                newName: "StatusPM");

            migrationBuilder.AddColumn<string>(
                name: "DoChas",
                schema: "dbo",
                table: "mon_porychka",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                schema: "dbo",
                table: "mon_porychka",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                schema: "dbo",
                table: "mon_porychka",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtChas",
                schema: "dbo",
                table: "mon_porychka",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoChas",
                schema: "dbo",
                table: "dem_porychka",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                schema: "dbo",
                table: "dem_porychka",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtChas",
                schema: "dbo",
                table: "dem_porychka",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoChas",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "Model",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "Note",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "OtChas",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "DoChas",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropColumn(
                name: "Note",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropColumn(
                name: "OtChas",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.RenameColumn(
                name: "StatusPM",
                schema: "dbo",
                table: "dem_porychka",
                newName: "StatusP");
        }
    }
}
