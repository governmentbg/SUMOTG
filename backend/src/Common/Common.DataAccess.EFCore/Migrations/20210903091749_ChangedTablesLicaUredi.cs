using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class ChangedTablesLicaUredi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lica_dokumenti_lica",
                schema: "dbo",
                table: "lica_dokumenti");

            migrationBuilder.DropForeignKey(
                name: "FK_lica_formuliar_uredi_lica_formuliar",
                schema: "dbo",
                table: "lica_formuliar_uredi");

            migrationBuilder.DropColumn(
                name: "Vypros",
                schema: "dbo",
                table: "lica_formuliar_uredi");

            migrationBuilder.DropColumn(
                name: "Kod_Dok",
                schema: "dbo",
                table: "lica_dokumenti");

            migrationBuilder.DropColumn(
                name: "U_NOM",
                schema: "dbo",
                table: "lica_dokumenti");

            migrationBuilder.DropColumn(
                name: "Vypros",
                schema: "dbo",
                table: "lica_dokumenti");

            migrationBuilder.AlterColumn<string>(
                name: "nime",
                schema: "dbo",
                table: "n_uredi",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(45)",
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Status_Code",
                schema: "dbo",
                table: "n_statusi",
                type: "smallint",
                maxLength: 2,
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Status_U",
                schema: "dbo",
                table: "lica_formuliar_uredi",
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
                table: "lica_formuliar_uredi",
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

            migrationBuilder.AlterColumn<int>(
                name: "Id_formuliar",
                schema: "dbo",
                table: "lica_formuliar_uredi",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id_L",
                schema: "dbo",
                table: "lica_formuliar_uredi",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id_KT",
                schema: "dbo",
                table: "lica_formuliar_uredi",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Broi",
                schema: "dbo",
                table: "lica_formuliar_uredi",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "nV18",
                schema: "dbo",
                table: "lica_formuliar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id_L",
                schema: "dbo",
                table: "lica_dokumenti",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID_KN",
                schema: "dbo",
                table: "lica_dokumenti",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Faza",
                schema: "dbo",
                table: "lica_dokumenti",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_lica_dokumenti_lica",
                schema: "dbo",
                table: "lica_dokumenti",
                column: "Id_L",
                principalSchema: "dbo",
                principalTable: "lica",
                principalColumn: "ID_L",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_lica_formuliar_uredi_lica_formuliar",
                schema: "dbo",
                table: "lica_formuliar_uredi",
                column: "Id_formuliar",
                principalSchema: "dbo",
                principalTable: "lica_formuliar",
                principalColumn: "ID_Formuliar",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lica_dokumenti_lica",
                schema: "dbo",
                table: "lica_dokumenti");

            migrationBuilder.DropForeignKey(
                name: "FK_lica_formuliar_uredi_lica_formuliar",
                schema: "dbo",
                table: "lica_formuliar_uredi");

            migrationBuilder.DropColumn(
                name: "nV18",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.AlterColumn<string>(
                name: "nime",
                schema: "dbo",
                table: "n_uredi",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status_Code",
                schema: "dbo",
                table: "n_statusi",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Status_U",
                schema: "dbo",
                table: "lica_formuliar_uredi",
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
                table: "lica_formuliar_uredi",
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

            migrationBuilder.AlterColumn<int>(
                name: "Id_formuliar",
                schema: "dbo",
                table: "lica_formuliar_uredi",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id_L",
                schema: "dbo",
                table: "lica_formuliar_uredi",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id_KT",
                schema: "dbo",
                table: "lica_formuliar_uredi",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Broi",
                schema: "dbo",
                table: "lica_formuliar_uredi",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Vypros",
                schema: "dbo",
                table: "lica_formuliar_uredi",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id_L",
                schema: "dbo",
                table: "lica_dokumenti",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ID_KN",
                schema: "dbo",
                table: "lica_dokumenti",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<short>(
                name: "Faza",
                schema: "dbo",
                table: "lica_dokumenti",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AddColumn<string>(
                name: "Kod_Dok",
                schema: "dbo",
                table: "lica_dokumenti",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "U_NOM",
                schema: "dbo",
                table: "lica_dokumenti",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vypros",
                schema: "dbo",
                table: "lica_dokumenti",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_lica_dokumenti_lica",
                schema: "dbo",
                table: "lica_dokumenti",
                column: "Id_L",
                principalSchema: "dbo",
                principalTable: "lica",
                principalColumn: "ID_L",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_lica_formuliar_uredi_lica_formuliar",
                schema: "dbo",
                table: "lica_formuliar_uredi",
                column: "Id_formuliar",
                principalSchema: "dbo",
                principalTable: "lica_formuliar",
                principalColumn: "ID_Formuliar",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
