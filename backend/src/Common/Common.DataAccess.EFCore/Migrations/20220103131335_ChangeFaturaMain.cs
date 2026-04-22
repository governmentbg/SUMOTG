using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class ChangeFaturaMain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DogData",
                schema: "dbo",
                table: "Facturi_Main");

            migrationBuilder.DropColumn(
                name: "DogNomer",
                schema: "dbo",
                table: "Facturi_Main");

            migrationBuilder.AddColumn<int>(
                name: "idDogovorFirma",
                schema: "dbo",
                table: "Facturi_Main",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idDogovorFirma",
                schema: "dbo",
                table: "Facturi_Main");

            migrationBuilder.AddColumn<DateTime>(
                name: "DogData",
                schema: "dbo",
                table: "Facturi_Main",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DogNomer",
                schema: "dbo",
                table: "Facturi_Main",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true);
        }
    }
}
