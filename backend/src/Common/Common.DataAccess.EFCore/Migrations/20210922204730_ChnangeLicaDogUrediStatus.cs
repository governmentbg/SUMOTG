using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class ChnangeLicaDogUrediStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "Status_U",
                schema: "dbo",
                table: "lica_dogovor_olduredi",
                type: "smallint",
                unicode: false,
                fixedLength: true,
                maxLength: 1,
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(string),
                oldType: "char(1)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Status",
                schema: "dbo",
                table: "lica_dogovor_olduredi",
                type: "smallint",
                unicode: false,
                fixedLength: true,
                maxLength: 1,
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(string),
                oldType: "char(1)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 1,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status_U",
                schema: "dbo",
                table: "lica_dogovor_olduredi",
                type: "char(1)",
                unicode: false,
                fixedLength: true,
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "dbo",
                table: "lica_dogovor_olduredi",
                type: "char(1)",
                unicode: false,
                fixedLength: true,
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 1);
        }
    }
}
