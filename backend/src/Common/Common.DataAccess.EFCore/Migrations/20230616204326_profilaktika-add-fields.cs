using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class profilaktikaaddfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdL",
                schema: "dbo",
                table: "mon_profilaktika",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Period",
                schema: "dbo",
                table: "mon_profilaktika",
                type: "int",
                maxLength: 5,
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdL",
                schema: "dbo",
                table: "mon_profilaktika");

            migrationBuilder.DropColumn(
                name: "Period",
                schema: "dbo",
                table: "mon_profilaktika");
        }
    }
}
