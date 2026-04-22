using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class RenamedFieldStatusU : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status_U",
                schema: "dbo",
                table: "lica_dogovor_olduredi",
                newName: "Status_DU");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status_DU",
                schema: "dbo",
                table: "lica_dogovor_olduredi",
                newName: "Status_U");
        }
    }
}
