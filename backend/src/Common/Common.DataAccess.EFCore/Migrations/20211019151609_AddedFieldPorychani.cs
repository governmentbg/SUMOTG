using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class AddedFieldPorychani : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndData",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.RenameColumn(
                name: "StartData",
                schema: "dbo",
                table: "mon_porychka",
                newName: "DoData");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndData",
                schema: "dbo",
                table: "mon_porychkamain",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartData",
                schema: "dbo",
                table: "mon_porychkamain",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Porychani",
                schema: "dbo",
                table: "lica_dogovor_uredi",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndData",
                schema: "dbo",
                table: "mon_porychkamain");

            migrationBuilder.DropColumn(
                name: "StartData",
                schema: "dbo",
                table: "mon_porychkamain");

            migrationBuilder.DropColumn(
                name: "Porychani",
                schema: "dbo",
                table: "lica_dogovor_uredi");

            migrationBuilder.RenameColumn(
                name: "DoData",
                schema: "dbo",
                table: "mon_porychka",
                newName: "StartData");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndData",
                schema: "dbo",
                table: "mon_porychka",
                type: "datetime",
                nullable: true);
        }
    }
}
