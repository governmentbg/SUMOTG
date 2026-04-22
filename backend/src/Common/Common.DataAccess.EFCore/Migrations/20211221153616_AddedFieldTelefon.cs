using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class AddedFieldTelefon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "dbo",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "dbo",
                table: "Users",
                newName: "Telefon");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameColumn(
                name: "Telefon",
                schema: "dbo",
                table: "Users",
                newName: "LastName");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                schema: "dbo",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
