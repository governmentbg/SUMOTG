using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class ChangedStatusType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Text",
                schema: "dbo",
                table: "n_nmn_obshti",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70,
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Status_DD",
                schema: "dbo",
                table: "lica_dokumenti",
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
                table: "lica_dokumenti",
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
                name: "Status_U",
                schema: "dbo",
                table: "lica_dogovor_uredi",
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
                table: "lica_dogovor_uredi",
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
                name: "Status_DL",
                schema: "dbo",
                table: "lica_dogovor",
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
                table: "lica_dogovor",
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
                name: "Text",
                schema: "dbo",
                table: "n_nmn_obshti",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status_DD",
                schema: "dbo",
                table: "lica_dokumenti",
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
                table: "lica_dokumenti",
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
                name: "Status_U",
                schema: "dbo",
                table: "lica_dogovor_uredi",
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
                table: "lica_dogovor_uredi",
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
                name: "Status_DL",
                schema: "dbo",
                table: "lica_dogovor",
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
                table: "lica_dogovor",
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
