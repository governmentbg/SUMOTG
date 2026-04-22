using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class AddRemoveFieldsFormCollectingInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KV",
                schema: "dbo",
                table: "form_collecting_info");

            migrationBuilder.AddColumn<string>(
                name: "descript",
                schema: "dbo",
                table: "form_collecting_info",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<short>(
                name: "status",
                schema: "dbo",
                table: "form_collecting_info",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "descript",
                schema: "dbo",
                table: "form_collecting_info");

            migrationBuilder.DropColumn(
                name: "status",
                schema: "dbo",
                table: "form_collecting_info");

            migrationBuilder.AddColumn<string>(
                name: "KV",
                schema: "dbo",
                table: "form_collecting_info",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);
        }
    }
}
