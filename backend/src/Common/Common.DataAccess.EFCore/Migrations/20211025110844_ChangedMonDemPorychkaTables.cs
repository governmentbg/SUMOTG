using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class ChangedMonDemPorychkaTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusG",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "StatusM",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "EndData",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropColumn(
                name: "StartData",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropColumn(
                name: "StatusD",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropColumn(
                name: "StatusG",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.RenameColumn(
                name: "StatusP",
                schema: "dbo",
                table: "mon_porychka",
                newName: "StatusPM");

            migrationBuilder.AddColumn<short>(
                name: "StatusPM",
                schema: "dbo",
                table: "mon_porychkamain",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndData",
                schema: "dbo",
                table: "dem_porychkamain",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartData",
                schema: "dbo",
                table: "dem_porychkamain",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "StatusDM",
                schema: "dbo",
                table: "dem_porychkamain",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DoData",
                schema: "dbo",
                table: "dem_porychka",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusPM",
                schema: "dbo",
                table: "mon_porychkamain");

            migrationBuilder.DropColumn(
                name: "EndData",
                schema: "dbo",
                table: "dem_porychkamain");

            migrationBuilder.DropColumn(
                name: "StartData",
                schema: "dbo",
                table: "dem_porychkamain");

            migrationBuilder.DropColumn(
                name: "StatusDM",
                schema: "dbo",
                table: "dem_porychkamain");

            migrationBuilder.DropColumn(
                name: "DoData",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.RenameColumn(
                name: "StatusPM",
                schema: "dbo",
                table: "mon_porychka",
                newName: "StatusP");

            migrationBuilder.AddColumn<short>(
                name: "StatusG",
                schema: "dbo",
                table: "mon_porychka",
                type: "smallint",
                unicode: false,
                fixedLength: true,
                maxLength: 1,
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "StatusM",
                schema: "dbo",
                table: "mon_porychka",
                type: "smallint",
                unicode: false,
                fixedLength: true,
                maxLength: 1,
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndData",
                schema: "dbo",
                table: "dem_porychka",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartData",
                schema: "dbo",
                table: "dem_porychka",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "StatusD",
                schema: "dbo",
                table: "dem_porychka",
                type: "smallint",
                unicode: false,
                fixedLength: true,
                maxLength: 1,
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "StatusG",
                schema: "dbo",
                table: "dem_porychka",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }
    }
}
