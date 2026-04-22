using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class ChangedLicaV1315Decimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "V15",
                schema: "dbo",
                table: "lica_formuliar",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<decimal>(
                name: "V14",
                schema: "dbo",
                table: "lica_formuliar",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<decimal>(
                name: "V13",
                schema: "dbo",
                table: "lica_formuliar",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "V15",
                schema: "dbo",
                table: "lica_formuliar",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<short>(
                name: "V14",
                schema: "dbo",
                table: "lica_formuliar",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<short>(
                name: "V13",
                schema: "dbo",
                table: "lica_formuliar",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
