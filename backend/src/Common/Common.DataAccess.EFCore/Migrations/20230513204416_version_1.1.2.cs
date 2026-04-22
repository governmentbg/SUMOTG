using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class version_112 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PNomer",
                schema: "dbo",
                table: "mon_profilaktika",
                type: "int",
                fixedLength: true,
                maxLength: 99999,
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PNomer",
                schema: "dbo",
                table: "mon_profilaktika");
        }
    }
}
