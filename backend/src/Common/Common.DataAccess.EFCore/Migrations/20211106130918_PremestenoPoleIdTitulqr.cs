using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class PremestenoPoleIdTitulqr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdTitulqr",
                schema: "dbo",
                table: "lica");

            migrationBuilder.AddColumn<short>(
                name: "IsTitulqr",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTitulqr",
                schema: "dbo",
                table: "lica_formuliar_kolektiv");

            migrationBuilder.AddColumn<int>(
                name: "IdTitulqr",
                schema: "dbo",
                table: "lica",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
