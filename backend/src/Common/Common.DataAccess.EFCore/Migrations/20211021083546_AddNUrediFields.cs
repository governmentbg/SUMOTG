using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class AddNUrediFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaxRad",
                schema: "dbo",
                table: "n_uredi",
                newName: "DopRad");

            migrationBuilder.AddColumn<short>(
                name: "KolectForm",
                schema: "dbo",
                table: "n_uredi",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KolectForm",
                schema: "dbo",
                table: "n_uredi");

            migrationBuilder.RenameColumn(
                name: "DopRad",
                schema: "dbo",
                table: "n_uredi",
                newName: "MaxRad");
        }
    }
}
