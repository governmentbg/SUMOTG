using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class AddedNewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "n_kvartali",
                schema: "dbo");

            migrationBuilder.AlterColumn<int>(
                name: "VidFirma",
                schema: "dbo",
                table: "lica_formuliar_firma",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TipFirma",
                schema: "dbo",
                table: "lica_formuliar_firma",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdL",
                schema: "dbo",
                table: "lica_formuliar_firma",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Faza",
                schema: "dbo",
                table: "lica_formuliar_firma",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "n_uredi",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Faza = table.Column<short>(type: "smallint", nullable: false),
                    nkod = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    nime = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    MaxBr = table.Column<int>(type: "int", nullable: false),
                    MaxRad = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_n_uredi_id", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "n_uredi",
                schema: "dbo");

            migrationBuilder.AlterColumn<string>(
                name: "VidFirma",
                schema: "dbo",
                table: "lica_formuliar_firma",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "TipFirma",
                schema: "dbo",
                table: "lica_formuliar_firma",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdL",
                schema: "dbo",
                table: "lica_formuliar_firma",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<short>(
                name: "Faza",
                schema: "dbo",
                table: "lica_formuliar_firma",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.CreateTable(
                name: "n_kvartali",
                schema: "dbo",
                columns: table => new
                {
                    nkod = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    kod_nmn = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    nime = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_n_kvartali_nkod", x => x.nkod);
                });
        }
    }
}
