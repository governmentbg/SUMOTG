using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class AddPrimaryKeyNRaioni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Z_Code",
                schema: "dbo",
                table: "n_raioni");

            migrationBuilder.DropColumn(
                name: "kod_nmn",
                schema: "dbo",
                table: "n_raioni");

            migrationBuilder.AddPrimaryKey(
                name: "PK_n_raioni_nkod",
                schema: "dbo",
                table: "n_raioni",
                column: "NKOD");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_n_raioni_nkod",
                schema: "dbo",
                table: "n_raioni");

            migrationBuilder.AddColumn<int>(
                name: "Z_Code",
                schema: "dbo",
                table: "n_raioni",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "kod_nmn",
                schema: "dbo",
                table: "n_raioni",
                type: "varchar(2)",
                unicode: false,
                maxLength: 2,
                nullable: true);
        }
    }
}
