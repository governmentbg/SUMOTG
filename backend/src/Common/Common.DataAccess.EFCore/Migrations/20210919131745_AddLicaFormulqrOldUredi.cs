using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class AddLicaFormulqrOldUredi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "kod_nmn",
                schema: "dbo",
                table: "n_jk");

            migrationBuilder.CreateTable(
                name: "lica_formuliar_olduredi",
                schema: "dbo",
                columns: table => new
                {
                    Id_ured_F = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_formuliar = table.Column<int>(type: "int", nullable: false),
                    Id_L = table.Column<int>(type: "int", nullable: false),
                    Id_KT = table.Column<int>(type: "int", nullable: false),
                    Broi = table.Column<int>(type: "int", nullable: false),
                    Status_U = table.Column<short>(type: "smallint", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    Status = table.Column<short>(type: "smallint", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    user = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Koga = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_olduredi_f_Id_ured_F", x => x.Id_ured_F);
                    table.ForeignKey(
                        name: "FK_lica_formuliar_olduredi_lica",
                        column: x => x.Id_L,
                        principalSchema: "dbo",
                        principalTable: "lica",
                        principalColumn: "ID_L",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_lica_formuliar_olduredi_Id_L",
                schema: "dbo",
                table: "lica_formuliar_olduredi",
                column: "Id_L");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lica_formuliar_olduredi",
                schema: "dbo");

            migrationBuilder.AddColumn<string>(
                name: "kod_nmn",
                schema: "dbo",
                table: "n_jk",
                type: "varchar(2)",
                unicode: false,
                maxLength: 2,
                nullable: true);
        }
    }
}
