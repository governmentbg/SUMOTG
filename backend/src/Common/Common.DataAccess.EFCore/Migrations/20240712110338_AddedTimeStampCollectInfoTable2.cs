using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class AddedTimeStampCollectInfoTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublishedOn",
                schema: "dbo",
                table: "form_collecting_info");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "dbo",
                table: "form_collecting_info",
                type: "datetime",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "dbo",
                table: "form_collecting_info");

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedOn",
                schema: "dbo",
                table: "form_collecting_info",
                type: "datetime2",
                nullable: true);
        }
    }
}
