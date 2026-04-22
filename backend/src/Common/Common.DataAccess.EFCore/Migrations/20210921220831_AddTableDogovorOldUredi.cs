using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class AddTableDogovorOldUredi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lica_dogovor_uredi_lica_dogovor",
                schema: "dbo",
                table: "lica_dogovor_uredi");

            migrationBuilder.DropColumn(
                name: "Vypros",
                schema: "dbo",
                table: "lica_dogovor_uredi");

            migrationBuilder.AlterColumn<int>(
                name: "Id_L",
                schema: "dbo",
                table: "lica_dogovor_uredi",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id_KT",
                schema: "dbo",
                table: "lica_dogovor_uredi",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID_DOG_L",
                schema: "dbo",
                table: "lica_dogovor_uredi",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Broi",
                schema: "dbo",
                table: "lica_dogovor_uredi",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "lica_dogovor_olduredi",
                schema: "dbo",
                columns: table => new
                {
                    Id_Ured_DG = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_DOG_L = table.Column<int>(type: "int", nullable: false),
                    Id_L = table.Column<int>(type: "int", nullable: false),
                    Id_KT = table.Column<int>(type: "int", nullable: false),
                    Broi = table.Column<int>(type: "int", nullable: false),
                    Status_U = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Status = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    user = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    Koga = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uredi_dg_l_Id_OldUred_DG", x => x.Id_Ured_DG);
                    table.ForeignKey(
                        name: "FK_lica_dogovor_olduredi_lica_dogovor",
                        column: x => x.ID_DOG_L,
                        principalSchema: "dbo",
                        principalTable: "lica_dogovor",
                        principalColumn: "Id_dog_L",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_lica_dogovor_olduredi_ID_DOG_L",
                schema: "dbo",
                table: "lica_dogovor_olduredi",
                column: "ID_DOG_L");

            migrationBuilder.AddForeignKey(
                name: "FK_lica_dogovor_uredi_lica_dogovor",
                schema: "dbo",
                table: "lica_dogovor_uredi",
                column: "ID_DOG_L",
                principalSchema: "dbo",
                principalTable: "lica_dogovor",
                principalColumn: "Id_dog_L",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lica_dogovor_uredi_lica_dogovor",
                schema: "dbo",
                table: "lica_dogovor_uredi");

            migrationBuilder.DropTable(
                name: "lica_dogovor_olduredi",
                schema: "dbo");

            migrationBuilder.AlterColumn<int>(
                name: "Id_L",
                schema: "dbo",
                table: "lica_dogovor_uredi",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id_KT",
                schema: "dbo",
                table: "lica_dogovor_uredi",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ID_DOG_L",
                schema: "dbo",
                table: "lica_dogovor_uredi",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Broi",
                schema: "dbo",
                table: "lica_dogovor_uredi",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Vypros",
                schema: "dbo",
                table: "lica_dogovor_uredi",
                type: "varchar(6)",
                unicode: false,
                maxLength: 6,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_lica_dogovor_uredi_lica_dogovor",
                schema: "dbo",
                table: "lica_dogovor_uredi",
                column: "ID_DOG_L",
                principalSchema: "dbo",
                principalTable: "lica_dogovor",
                principalColumn: "Id_dog_L",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
