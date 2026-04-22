using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class added_nkod_filed_n_spravki : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nkod",
                schema: "dbo",
                table: "n_spravki",
                type: "decimal(10,2)",
                maxLength: 5,
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nkod",
                schema: "dbo",
                table: "n_spravki");
        }
    }
}
