using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class add_filedsprofilaktika : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Broi",
                schema: "dbo",
                table: "mon_profilaktika",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                schema: "dbo",
                table: "mon_profilaktika",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OtchetData",
                schema: "dbo",
                table: "mon_profilaktika",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Broi",
                schema: "dbo",
                table: "mon_profilaktika");

            migrationBuilder.DropColumn(
                name: "Model",
                schema: "dbo",
                table: "mon_profilaktika");

            migrationBuilder.DropColumn(
                name: "OtchetData",
                schema: "dbo",
                table: "mon_profilaktika");
        }
    }
}
