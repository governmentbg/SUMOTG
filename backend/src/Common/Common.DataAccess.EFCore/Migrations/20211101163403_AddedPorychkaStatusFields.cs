using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class AddedPorychkaStatusFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusPM",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.RenameColumn(
                name: "StatusPM",
                schema: "dbo",
                table: "mon_porychka",
                newName: "StatusM");

            migrationBuilder.AddColumn<string>(
                name: "Nime2",
                schema: "dbo",
                table: "n_uredi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nkod2",
                schema: "dbo",
                table: "n_uredi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vid",
                schema: "dbo",
                table: "n_uredi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "StatusG",
                schema: "dbo",
                table: "mon_porychka",
                type: "smallint",
                unicode: false,
                fixedLength: true,
                maxLength: 1,
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "StatusG",
                schema: "dbo",
                table: "dem_porychka",
                type: "smallint",
                unicode: false,
                fixedLength: true,
                maxLength: 1,
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "StatusM",
                schema: "dbo",
                table: "dem_porychka",
                type: "smallint",
                unicode: false,
                fixedLength: true,
                maxLength: 1,
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nime2",
                schema: "dbo",
                table: "n_uredi");

            migrationBuilder.DropColumn(
                name: "Nkod2",
                schema: "dbo",
                table: "n_uredi");

            migrationBuilder.DropColumn(
                name: "Vid",
                schema: "dbo",
                table: "n_uredi");

            migrationBuilder.DropColumn(
                name: "StatusG",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "StatusG",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropColumn(
                name: "StatusM",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.RenameColumn(
                name: "StatusM",
                schema: "dbo",
                table: "mon_porychka",
                newName: "StatusPM");

            migrationBuilder.AddColumn<short>(
                name: "StatusPM",
                schema: "dbo",
                table: "dem_porychka",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }
    }
}
