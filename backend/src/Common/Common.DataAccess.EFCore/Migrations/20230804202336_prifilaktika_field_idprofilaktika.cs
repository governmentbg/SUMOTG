using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class prifilaktika_field_idprofilaktika : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idprofilaktika",
                schema: "dbo",
                table: "mon_profilaktika",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idprofilaktika",
                schema: "dbo",
                table: "mon_profilaktika");
        }
    }
}
