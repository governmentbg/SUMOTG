using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class AddedFakturiTwoFileds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ForPeriod",
                schema: "dbo",
                table: "Facturi_Main",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VidPayment",
                schema: "dbo",
                table: "Facturi_Main",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForPeriod",
                schema: "dbo",
                table: "Facturi_Main");

            migrationBuilder.DropColumn(
                name: "VidPayment",
                schema: "dbo",
                table: "Facturi_Main");
        }
    }
}
