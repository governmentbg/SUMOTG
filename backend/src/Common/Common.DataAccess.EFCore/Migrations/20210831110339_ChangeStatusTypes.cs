using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class ChangeStatusTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lica_formuliar_lica",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "U_nom",
                schema: "dbo",
                table: "lica");

            migrationBuilder.DropColumn(
                name: "V8",
                schema: "dbo",
                table: "lica");

            migrationBuilder.AlterColumn<int>(
                name: "Id_L",
                schema: "dbo",
                table: "lica_formuliar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "v_lice",
                schema: "dbo",
                table: "lica",
                type: "int",
                fixedLength: true,
                maxLength: 1,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nchar(1)",
                oldFixedLength: true,
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_lica_formuliar_lica",
                schema: "dbo",
                table: "lica_formuliar",
                column: "Id_L",
                principalSchema: "dbo",
                principalTable: "lica",
                principalColumn: "ID_L",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lica_formuliar_lica",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.AlterColumn<int>(
                name: "Id_L",
                schema: "dbo",
                table: "lica_formuliar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "v_lice",
                schema: "dbo",
                table: "lica",
                type: "nchar(1)",
                fixedLength: true,
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldFixedLength: true,
                oldMaxLength: 1);

            migrationBuilder.AddColumn<string>(
                name: "U_nom",
                schema: "dbo",
                table: "lica",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "V8",
                schema: "dbo",
                table: "lica",
                type: "char(1)",
                unicode: false,
                fixedLength: true,
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_lica_formuliar_lica",
                schema: "dbo",
                table: "lica_formuliar",
                column: "Id_L",
                principalSchema: "dbo",
                principalTable: "lica",
                principalColumn: "ID_L",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
