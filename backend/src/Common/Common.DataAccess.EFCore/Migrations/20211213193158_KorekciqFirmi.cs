using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class KorekciqFirmi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ap",
                schema: "dbo",
                table: "firmi");

            migrationBuilder.DropColumn(
                name: "Blok",
                schema: "dbo",
                table: "firmi");

            migrationBuilder.DropColumn(
                name: "Etaj",
                schema: "dbo",
                table: "firmi");

            migrationBuilder.DropColumn(
                name: "Jk",
                schema: "dbo",
                table: "firmi");

            migrationBuilder.DropColumn(
                name: "Kv",
                schema: "dbo",
                table: "firmi");

            migrationBuilder.DropColumn(
                name: "Nm",
                schema: "dbo",
                table: "firmi");

            migrationBuilder.DropColumn(
                name: "Nomer",
                schema: "dbo",
                table: "firmi");

            migrationBuilder.DropColumn(
                name: "Ul",
                schema: "dbo",
                table: "firmi");

            migrationBuilder.RenameColumn(
                name: "Vh",
                schema: "dbo",
                table: "firmi",
                newName: "Adres");

            migrationBuilder.CreateTable(
                name: "Attachments",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDog = table.Column<int>(type: "int", nullable: false),
                    DocType = table.Column<int>(type: "int", nullable: false),
                    DocDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SavedFileName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<short>(type: "smallint", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    User = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Koga = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attachments_Id", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments",
                schema: "dbo");

            migrationBuilder.RenameColumn(
                name: "Adres",
                schema: "dbo",
                table: "firmi",
                newName: "Vh");

            migrationBuilder.AddColumn<string>(
                name: "Ap",
                schema: "dbo",
                table: "firmi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Blok",
                schema: "dbo",
                table: "firmi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Etaj",
                schema: "dbo",
                table: "firmi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Jk",
                schema: "dbo",
                table: "firmi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Kv",
                schema: "dbo",
                table: "firmi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nm",
                schema: "dbo",
                table: "firmi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nomer",
                schema: "dbo",
                table: "firmi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ul",
                schema: "dbo",
                table: "firmi",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
