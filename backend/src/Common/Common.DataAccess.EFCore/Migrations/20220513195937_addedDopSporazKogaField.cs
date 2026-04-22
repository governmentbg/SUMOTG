using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class addedDopSporazKogaField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Koga",
                schema: "dbo",
                table: "lica_dopsporazumeniq",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User",
                schema: "dbo",
                table: "lica_dopsporazumeniq",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Koga",
                schema: "dbo",
                table: "lica_dopsporazumeniq");

            migrationBuilder.DropColumn(
                name: "User",
                schema: "dbo",
                table: "lica_dopsporazumeniq");
        }
    }
}
