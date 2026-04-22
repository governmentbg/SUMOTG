using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class ChangedTableDemPorychki : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dem_oldporychka_dem_dogovor",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropPrimaryKey(
                name: "PK_oldporychka_dm_IDDM",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropIndex(
                name: "IX_dem_porychka_Id_firma_dm",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropColumn(
                name: "A_Raion",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropColumn(
                name: "Broi_U",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropColumn(
                name: "DO_data",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropColumn(
                name: "Faza",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropColumn(
                name: "IDENT",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropColumn(
                name: "IME",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropColumn(
                name: "Id_SP_NET",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropColumn(
                name: "Id_firma_dm",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropColumn(
                name: "Id_kn",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropColumn(
                name: "Nomer_poreden_DM",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropColumn(
                name: "OT_Data",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropColumn(
                name: "U_nom",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropColumn(
                name: "vypros",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropColumn(
                name: "IDDM",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.RenameColumn(
                name: "Start_data",
                schema: "dbo",
                table: "dem_porychka",
                newName: "StartData");

            migrationBuilder.RenameColumn(
                name: "id_L",
                schema: "dbo",
                table: "dem_porychka",
                newName: "IdLiceDogovorNavigationIdDogL");

            migrationBuilder.RenameColumn(
                name: "Status_dp",
                schema: "dbo",
                table: "dem_porychka",
                newName: "StatusD");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartData",
                schema: "dbo",
                table: "dem_porychka",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdUred",
                schema: "dbo",
                table: "dem_porychka",
                type: "int",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "IdPorachkaBody",
                schema: "dbo",
                table: "dem_porychka",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Broi",
                schema: "dbo",
                table: "dem_porychka",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DemData",
                schema: "dbo",
                table: "dem_porychka",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndData",
                schema: "dbo",
                table: "dem_porychka",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdDogovorLice",
                schema: "dbo",
                table: "dem_porychka",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPorachkaMain",
                schema: "dbo",
                table: "dem_porychka",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<short>(
                name: "StatusG",
                schema: "dbo",
                table: "dem_porychka",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "StatusP",
                schema: "dbo",
                table: "dem_porychka",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_oldporychka_dm_IDBody",
                schema: "dbo",
                table: "dem_porychka",
                column: "IdPorachkaBody");

            migrationBuilder.CreateTable(
                name: "dem_porychkamain",
                schema: "dbo",
                columns: table => new
                {
                    IDPorachkamain = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Faza = table.Column<short>(type: "smallint", nullable: false),
                    Nomer = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdFirma = table.Column<int>(type: "int", nullable: false),
                    IdDogovorFirma = table.Column<int>(type: "int", nullable: false),
                    ARaion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<short>(type: "smallint", maxLength: 1, nullable: false),
                    user = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    koga = table.Column<DateTime>(type: "datetime", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_demporychka_main_IDPorachka", x => x.IDPorachkamain);
                    table.ForeignKey(
                        name: "FK_dem_porychkamain_dem_dogovor",
                        column: x => x.IdDogovorFirma,
                        principalSchema: "dbo",
                        principalTable: "dem_dogovor",
                        principalColumn: "Id_firma_DM",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dem_porychka_IdLiceDogovorNavigationIdDogL",
                schema: "dbo",
                table: "dem_porychka",
                column: "IdLiceDogovorNavigationIdDogL");

            migrationBuilder.CreateIndex(
                name: "IX_dem_porychka_IdPorachkaMain",
                schema: "dbo",
                table: "dem_porychka",
                column: "IdPorachkaMain");

            migrationBuilder.CreateIndex(
                name: "IX_dem_porychkamain_IdDogovorFirma",
                schema: "dbo",
                table: "dem_porychkamain",
                column: "IdDogovorFirma");

            migrationBuilder.AddForeignKey(
                name: "FK_dem_porychka_lica_dogovor_IdLiceDogovorNavigationIdDogL",
                schema: "dbo",
                table: "dem_porychka",
                column: "IdLiceDogovorNavigationIdDogL",
                principalSchema: "dbo",
                principalTable: "lica_dogovor",
                principalColumn: "Id_dog_L",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_dem_porychkamain_dem_porychka",
                schema: "dbo",
                table: "dem_porychka",
                column: "IdPorachkaMain",
                principalSchema: "dbo",
                principalTable: "dem_porychkamain",
                principalColumn: "IDPorachkamain",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dem_porychka_lica_dogovor_IdLiceDogovorNavigationIdDogL",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropForeignKey(
                name: "FK_dem_porychkamain_dem_porychka",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropTable(
                name: "dem_porychkamain",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_oldporychka_dm_IDBody",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropIndex(
                name: "IX_dem_porychka_IdLiceDogovorNavigationIdDogL",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropIndex(
                name: "IX_dem_porychka_IdPorachkaMain",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropColumn(
                name: "IdPorachkaBody",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropColumn(
                name: "Broi",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropColumn(
                name: "DemData",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropColumn(
                name: "EndData",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropColumn(
                name: "IdDogovorLice",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropColumn(
                name: "IdPorachkaMain",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropColumn(
                name: "StatusG",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropColumn(
                name: "StatusP",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.RenameColumn(
                name: "StartData",
                schema: "dbo",
                table: "dem_porychka",
                newName: "Start_data");

            migrationBuilder.RenameColumn(
                name: "StatusD",
                schema: "dbo",
                table: "dem_porychka",
                newName: "Status_dp");

            migrationBuilder.RenameColumn(
                name: "IdUred",
                schema: "dbo",
                table: "dem_porychka",
                newName: "IDDM");

            migrationBuilder.RenameColumn(
                name: "IdLiceDogovorNavigationIdDogL",
                schema: "dbo",
                table: "dem_porychka",
                newName: "id_L");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start_data",
                schema: "dbo",
                table: "dem_porychka",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IDDM",
                schema: "dbo",
                table: "dem_porychka",
                type: "int",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "A_Raion",
                schema: "dbo",
                table: "dem_porychka",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Broi_U",
                schema: "dbo",
                table: "dem_porychka",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DO_data",
                schema: "dbo",
                table: "dem_porychka",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Faza",
                schema: "dbo",
                table: "dem_porychka",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IDENT",
                schema: "dbo",
                table: "dem_porychka",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IME",
                schema: "dbo",
                table: "dem_porychka",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id_SP_NET",
                schema: "dbo",
                table: "dem_porychka",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id_firma_dm",
                schema: "dbo",
                table: "dem_porychka",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id_kn",
                schema: "dbo",
                table: "dem_porychka",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Nomer_poreden_DM",
                schema: "dbo",
                table: "dem_porychka",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OT_Data",
                schema: "dbo",
                table: "dem_porychka",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "U_nom",
                schema: "dbo",
                table: "dem_porychka",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "vypros",
                schema: "dbo",
                table: "dem_porychka",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_oldporychka_dm_IDDM",
                schema: "dbo",
                table: "dem_porychka",
                column: "IDDM");

            migrationBuilder.CreateIndex(
                name: "IX_dem_porychka_Id_firma_dm",
                schema: "dbo",
                table: "dem_porychka",
                column: "Id_firma_dm");

            migrationBuilder.AddForeignKey(
                name: "FK_dem_oldporychka_dem_dogovor",
                schema: "dbo",
                table: "dem_porychka",
                column: "Id_firma_dm",
                principalSchema: "dbo",
                principalTable: "dem_dogovor",
                principalColumn: "Id_firma_DM",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
