using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class AddedTimeStampCollectInfoTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedOn",
                schema: "dbo",
                table: "form_collecting_info",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComputedColumnSql: "getutcdate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedOn",
                schema: "dbo",
                table: "form_collecting_info",
                type: "datetime2",
                nullable: false,
                computedColumnSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
