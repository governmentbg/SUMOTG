using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class AddedUserStatusField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
               name: "status",
               schema: "dbo",
               table: "Users",
               type: "smallint",
               nullable: false,
               defaultValue: 0);

            migrationBuilder.RenameColumn(
                name: "status",
                schema: "dbo",
                table: "Users",
                newName: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
              name: "Status",
              schema: "dbo",
              table: "Users");
        }
    }
}
