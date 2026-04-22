using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class added_fields_isexpired_unsigned : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "unsigned",
                schema: "dbo",
                table: "mon_porychka",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "isexpired",
                schema: "dbo",
                table: "lica_dogovor",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "unsigned",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "isexpired",
                schema: "dbo",
                table: "lica_dogovor");
        }
    }
}
