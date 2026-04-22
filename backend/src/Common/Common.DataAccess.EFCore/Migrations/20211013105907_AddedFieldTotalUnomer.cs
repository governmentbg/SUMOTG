using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class AddedFieldTotalUnomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UNomer",
                schema: "dbo",
                table: "lica_formuliar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<short>(
                name: "Total",
                schema: "dbo",
                table: "lica",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UNomer",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "Total",
                schema: "dbo",
                table: "lica");
        }
    }
}
