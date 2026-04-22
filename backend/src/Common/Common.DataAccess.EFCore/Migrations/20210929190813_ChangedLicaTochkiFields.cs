using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class ChangedLicaTochkiFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE lica SET Tochki1 = 0 WHERE Tochki1 IS NULL");
            migrationBuilder.Sql("UPDATE lica SET Tochki2 = 0 WHERE Tochki2 IS NULL");
            migrationBuilder.Sql("UPDATE lica SET Tochki3 = 0 WHERE Tochki3 IS NULL");
            migrationBuilder.Sql("UPDATE lica SET Tochki4 = 0 WHERE Tochki4 IS NULL");
            migrationBuilder.Sql("UPDATE lica SET Tochki5 = 0 WHERE Tochki5 IS NULL");
            migrationBuilder.Sql("UPDATE lica SET Tochki6 = 0 WHERE Tochki6 IS NULL");
            migrationBuilder.Sql("UPDATE lica SET Tochki7 = 0 WHERE Tochki7 IS NULL");

            migrationBuilder.AlterColumn<short>(
                name: "Tochki7",
                schema: "dbo",
                table: "lica",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Tochki6",
                schema: "dbo",
                table: "lica",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Tochki5",
                schema: "dbo",
                table: "lica",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Tochki4",
                schema: "dbo",
                table: "lica",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Tochki3",
                schema: "dbo",
                table: "lica",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Tochki2",
                schema: "dbo",
                table: "lica",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Tochki1",
                schema: "dbo",
                table: "lica",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Tochki7",
                schema: "dbo",
                table: "lica",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<decimal>(
                name: "Tochki6",
                schema: "dbo",
                table: "lica",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<decimal>(
                name: "Tochki5",
                schema: "dbo",
                table: "lica",
                type: "numeric(10,2)",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<decimal>(
                name: "Tochki4",
                schema: "dbo",
                table: "lica",
                type: "numeric(10,2)",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<decimal>(
                name: "Tochki3",
                schema: "dbo",
                table: "lica",
                type: "numeric(10,2)",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<decimal>(
                name: "Tochki2",
                schema: "dbo",
                table: "lica",
                type: "numeric(10,2)",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<decimal>(
                name: "Tochki1",
                schema: "dbo",
                table: "lica",
                type: "numeric(10,2)",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");
        }
    }
}
