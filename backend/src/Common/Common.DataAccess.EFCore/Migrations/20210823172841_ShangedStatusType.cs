using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class ShangedStatusType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "Status",
                schema: "dbo",
                table: "n_ulicii",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AlterColumn<short>(
                name: "Status",
                schema: "dbo",
                table: "n_statusi",
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
                name: "Faza",
                schema: "dbo",
                table: "n_statusi",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Status",
                schema: "dbo",
                table: "n_spisyk_nmn",
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
                name: "Faza",
                schema: "dbo",
                table: "n_spisyk_nmn",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Status",
                schema: "dbo",
                table: "n_raioni",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "Status",
                schema: "dbo",
                table: "n_ns_mesta",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AlterColumn<short>(
                name: "status",
                schema: "dbo",
                table: "n_nmn_obshti",
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
                name: "Faza",
                schema: "dbo",
                table: "n_nmn_obshti",
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

            migrationBuilder.AddColumn<short>(
                name: "Status",
                schema: "dbo",
                table: "n_kvartali",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "Status",
                schema: "dbo",
                table: "n_kmetstva",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "Status",
                schema: "dbo",
                table: "n_jk",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AlterColumn<short>(
                name: "Status",
                schema: "dbo",
                table: "lica",
                type: "smallint",
                maxLength: 1,
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                schema: "dbo",
                table: "n_ulicii");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "dbo",
                table: "n_raioni");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "dbo",
                table: "n_ns_mesta");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "dbo",
                table: "n_kvartali");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "dbo",
                table: "n_kmetstva");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "dbo",
                table: "n_jk");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "dbo",
                table: "n_statusi",
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

            migrationBuilder.AlterColumn<short>(
                name: "Faza",
                schema: "dbo",
                table: "n_statusi",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "dbo",
                table: "n_spisyk_nmn",
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

            migrationBuilder.AlterColumn<short>(
                name: "Faza",
                schema: "dbo",
                table: "n_spisyk_nmn",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                schema: "dbo",
                table: "n_nmn_obshti",
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
                name: "Faza",
                schema: "dbo",
                table: "n_nmn_obshti",
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
                table: "lica",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldMaxLength: 1);
        }
    }
}
