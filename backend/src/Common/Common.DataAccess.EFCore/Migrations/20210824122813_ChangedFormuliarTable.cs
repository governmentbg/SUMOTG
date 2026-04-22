using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class ChangedFormuliarTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lica_formuliar_danni",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "Acst_date",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "Acster",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "Fime",
                schema: "dbo",
                table: "lica");

            migrationBuilder.DropColumn(
                name: "GIME",
                schema: "dbo",
                table: "lica");

            migrationBuilder.DropColumn(
                name: "ID_Predstavitel",
                schema: "dbo",
                table: "lica");

            migrationBuilder.DropColumn(
                name: "PIME",
                schema: "dbo",
                table: "lica");

            migrationBuilder.DropColumn(
                name: "Predstavitel",
                schema: "dbo",
                table: "lica");

            migrationBuilder.DropForeignKey (
                     name: "FK_mon_rajoni_mon_dogovor",
                     schema: "dbo",
                     table: "mon_rajoni"
                 );

            migrationBuilder.DropForeignKey(
                     name: "FK_mon_porychka_mon_dogovor",
                     schema: "dbo",
                     table: "mon_porychka"
                 );

            migrationBuilder.DropForeignKey(
                     name: "FK_mon_dgv_uredi_mon_dogovor",
                     schema: "dbo",
                     table: "mon_dgv_uredi"
                 );

            migrationBuilder.DropForeignKey(
                     name: "FK_mon_dgv_podizpylniteli_mon_dogovor",
                     schema: "dbo",
                     table: "mon_dgv_podizpylniteli"
                 );

            migrationBuilder.DropPrimaryKey(
                     name: "PK_dgv_dostavchici_ID_FIRMA",
                     schema: "dbo",
                     table: "mon_dogovor"
                 );

            

            migrationBuilder.RenameColumn(
                name: "ID_FIRMA",
                schema: "dbo",
                table: "mon_dogovor",
                newName: "IdFirmaMn");

            migrationBuilder.RenameColumn(
                name: "Id_firma",
                schema: "dbo",
                table: "mon_rajoni",
                newName: "IdFirmaMn");
 
            migrationBuilder.RenameColumn(
                name: "Id_firma",
                schema: "dbo",
                table: "mon_porychka",
                newName: "IdFirmaMn");

            migrationBuilder.RenameColumn(
                name: "Id_firma",
                schema: "dbo",
                table: "mon_grafik",
                newName: "IdFirmaMn");

            migrationBuilder.RenameColumn(
                 name: "Id_firma",
                 schema: "dbo",
                 table: "mon_dgv_uredi",
                 newName: "IdFirmaMn");

            migrationBuilder.RenameColumn(
                 name: "ID_FIRMA",
                 schema: "dbo",
                 table: "mon_dgv_podizpylniteli",
                 newName: "IdFirmaMn");

            migrationBuilder.AddPrimaryKey(
                      name: "PK_dgv_dostavchici_ID_FIRMA",
                      schema: "dbo",
                      table: "mon_dogovor",
                      column: "IdFirmaMn"
                  );

            migrationBuilder.AddForeignKey(
                    name: "FK_mon_rajoni_mon_dogovor",
                    schema: "dbo",
                    table: "mon_rajoni",
                    column: "IdFirmaMn",
                    principalSchema: "dbo",
                    principalTable: "mon_dogovor",
                    principalColumn: "IdFirmaMn",
                    onDelete: ReferentialAction.Cascade
                );

            migrationBuilder.AddForeignKey(
                    name: "FK_mon_porychka_mon_dogovor",
                    schema: "dbo",
                    table: "mon_porychka",
                    column: "IdFirmaMn",
                    principalSchema: "dbo",
                    principalTable: "mon_dogovor",
                    principalColumn: "IdFirmaMn",
                    onDelete: ReferentialAction.Cascade
                 );

            migrationBuilder.AddForeignKey(
                    name: "FK_mon_dgv_uredi_mon_dogovor",
                    schema: "dbo",
                    table: "mon_dgv_uredi",
                    column: "IdFirmaMn",
                    principalSchema: "dbo",
                    principalTable: "mon_dogovor",
                    principalColumn: "IdFirmaMn",
                    onDelete: ReferentialAction.Cascade
                 );

            migrationBuilder.AddForeignKey(
                    name: "FK_mon_dgv_podizpylniteli_mon_dogovor",
                    schema: "dbo",
                    table: "mon_dgv_podizpylniteli",
                    column: "IdFirmaMn",
                    principalSchema: "dbo",
                    principalTable: "mon_dogovor",
                    principalColumn: "IdFirmaMn",
                    onDelete: ReferentialAction.Cascade
                 );

            migrationBuilder.CreateIndex(
                name: "IX_mon_dgv_podizpylniteli_ID_FIRMAMN",
                schema: "dbo",
                table: "mon_dgv_podizpylniteli",
                column: "IdFirmaMn"
            );

            migrationBuilder.CreateIndex(
                name: "IX_mon_dgv_uredi_IdFirmaNm",
                schema: "dbo",
                table: "mon_dgv_uredi",
                column: "IdFirmaMn");

            migrationBuilder.CreateIndex(
                name: "IX_mon_porychka_IdFirmaMn",
                schema: "dbo",
                table: "mon_porychka",
                column: "IdFirmaMn");

            migrationBuilder.CreateIndex(
                name: "IX_mon_rajoni_IdFirmaMn",
                schema: "dbo",
                table: "mon_rajoni",
                column: "IdFirmaMn");


            migrationBuilder.RenameColumn(
                name: "STATUS_DM",
                schema: "dbo",
                table: "mon_dgv_podizpylniteli",
                newName: "Status_DM");

            migrationBuilder.AddColumn<int>(
                name: "IdFirma",
                schema: "dbo",
                table: "mon_dogovor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<short>(
                name: "Status_F",
                schema: "dbo",
                table: "lica_formuliar",
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
                table: "lica_formuliar",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "Koga",
                schema: "dbo",
                table: "lica_formuliar",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User",
                schema: "dbo",
                table: "lica_formuliar",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "V11",
                schema: "dbo",
                table: "lica_formuliar",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "V12",
                schema: "dbo",
                table: "lica_formuliar",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "V13",
                schema: "dbo",
                table: "lica_formuliar",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "V14",
                schema: "dbo",
                table: "lica_formuliar",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "V15",
                schema: "dbo",
                table: "lica_formuliar",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "V16",
                schema: "dbo",
                table: "lica_formuliar",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "V17",
                schema: "dbo",
                table: "lica_formuliar",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "V20",
                schema: "dbo",
                table: "lica_formuliar",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<decimal>(
                name: "V211",
                schema: "dbo",
                table: "lica_formuliar",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "V212",
                schema: "dbo",
                table: "lica_formuliar",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "V213",
                schema: "dbo",
                table: "lica_formuliar",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<short>(
                name: "V22",
                schema: "dbo",
                table: "lica_formuliar",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "V23",
                schema: "dbo",
                table: "lica_formuliar",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "V24",
                schema: "dbo",
                table: "lica_formuliar",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "V25",
                schema: "dbo",
                table: "lica_formuliar",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "V26",
                schema: "dbo",
                table: "lica_formuliar",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "V27",
                schema: "dbo",
                table: "lica_formuliar",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "V28",
                schema: "dbo",
                table: "lica_formuliar",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "V30",
                schema: "dbo",
                table: "lica_formuliar",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "V31",
                schema: "dbo",
                table: "lica_formuliar",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "V32",
                schema: "dbo",
                table: "lica_formuliar",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "V33",
                schema: "dbo",
                table: "lica_formuliar",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "V34",
                schema: "dbo",
                table: "lica_formuliar",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "V35",
                schema: "dbo",
                table: "lica_formuliar",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "V36",
                schema: "dbo",
                table: "lica_formuliar",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "V37",
                schema: "dbo",
                table: "lica_formuliar",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "V38",
                schema: "dbo",
                table: "lica_formuliar",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<decimal>(
                name: "V391",
                schema: "dbo",
                table: "lica_formuliar",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "V392",
                schema: "dbo",
                table: "lica_formuliar",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "V401",
                schema: "dbo",
                table: "lica_formuliar",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "V402",
                schema: "dbo",
                table: "lica_formuliar",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "V41",
                schema: "dbo",
                table: "lica_formuliar",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "V421",
                schema: "dbo",
                table: "lica_formuliar",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "V422",
                schema: "dbo",
                table: "lica_formuliar",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "V423",
                schema: "dbo",
                table: "lica_formuliar",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "nV10",
                schema: "dbo",
                table: "lica_formuliar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "nV19",
                schema: "dbo",
                table: "lica_formuliar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "nV29",
                schema: "dbo",
                table: "lica_formuliar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "nV8",
                schema: "dbo",
                table: "lica_formuliar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "nV9",
                schema: "dbo",
                table: "lica_formuliar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<short>(
                name: "Status_L",
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

            migrationBuilder.AlterColumn<short>(
                name: "Status_F",
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

            migrationBuilder.AddColumn<string>(
                name: "Zona",
                schema: "dbo",
                table: "lica",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdFirma",
                schema: "dbo",
                table: "dem_dogovor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "firmi",
                schema: "dbo",
                columns: table => new
                {
                    IdFirma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Faza = table.Column<short>(type: "smallint", nullable: false),
                    VidFirma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EIK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomDgSUDSO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusDm = table.Column<short>(type: "smallint", nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Koga = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_firmi_IDFirma", x => x.IdFirma);
                });

            migrationBuilder.CreateTable(
                name: "LicaFormuliarFirma",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdL = table.Column<int>(type: "int", nullable: true),
                    Faza = table.Column<short>(type: "smallint", nullable: true),
                    UNom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VidFirma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ident = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KodKID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ARaion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Jk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ul = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nomer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Blok = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Etaj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipFirma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusL = table.Column<short>(type: "smallint", nullable: false),
                    StatusF = table.Column<short>(type: "smallint", nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Koga = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdLNavigationIdL = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicaFormuliarFirma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LicaFormuliarFirma_lica_IdLNavigationIdL",
                        column: x => x.IdLNavigationIdL,
                        principalSchema: "dbo",
                        principalTable: "lica",
                        principalColumn: "ID_L",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LicaFormuliarKolektiv",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdL = table.Column<int>(type: "int", nullable: true),
                    Faza = table.Column<short>(type: "smallint", nullable: true),
                    VIdent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ident = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ARaion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Jk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ul = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nomer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Blok = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Etaj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusL = table.Column<short>(type: "smallint", nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Koga = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdLNavigationIdL = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicaFormuliarKolektiv", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LicaFormuliarKolektiv_lica_IdLNavigationIdL",
                        column: x => x.IdLNavigationIdL,
                        principalSchema: "dbo",
                        principalTable: "lica",
                        principalColumn: "ID_L",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dem_dogovor_IdFirma",
                schema: "dbo",
                table: "dem_dogovor",
                column: "IdFirma");

            migrationBuilder.CreateIndex(
                name: "IX_LicaFormuliarFirma_IdLNavigationIdL",
                schema: "dbo",
                table: "LicaFormuliarFirma",
                column: "IdLNavigationIdL");

            migrationBuilder.CreateIndex(
                name: "IX_LicaFormuliarKolektiv_IdLNavigationIdL",
                schema: "dbo",
                table: "LicaFormuliarKolektiv",
                column: "IdLNavigationIdL");

            migrationBuilder.AddForeignKey(
                name: "FK_demon_dogovor_firmi",
                schema: "dbo",
                table: "dem_dogovor",
                column: "IdFirma",
                principalSchema: "dbo",
                principalTable: "firmi",
                principalColumn: "IdFirma",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mon_dogovor_firmi",
                schema: "dbo",
                table: "mon_dogovor",
                column: "IdFirma",
                principalSchema: "dbo",
                principalTable: "firmi",
                principalColumn: "IdFirma",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_demon_dogovor_firmi",
                schema: "dbo",
                table: "dem_dogovor");

            migrationBuilder.DropForeignKey(
                name: "FK_mon_dogovor_firmi",
                schema: "dbo",
                table: "mon_dogovor");

            migrationBuilder.DropTable(
                name: "firmi",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LicaFormuliarFirma",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LicaFormuliarKolektiv",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_dem_dogovor_IdFirma",
                schema: "dbo",
                table: "dem_dogovor");

            migrationBuilder.DropColumn(
                name: "IdFirmaMn",
                schema: "dbo",
                table: "mon_dogovor");

            migrationBuilder.DropColumn(
                name: "Koga",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "User",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V11",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V12",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V13",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V14",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V15",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V16",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V17",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V20",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V211",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V212",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V213",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V22",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V23",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V24",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V25",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V26",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V27",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V28",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V30",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V31",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V32",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V33",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V34",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V35",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V36",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V37",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V38",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V391",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V392",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V401",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V402",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V41",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V421",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V422",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "V423",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "nV10",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "nV19",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "nV29",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "nV8",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "nV9",
                schema: "dbo",
                table: "lica_formuliar");

            migrationBuilder.DropColumn(
                name: "Zona",
                schema: "dbo",
                table: "lica");

            migrationBuilder.DropColumn(
                name: "IdFirma",
                schema: "dbo",
                table: "dem_dogovor");

            migrationBuilder.RenameColumn(
                name: "IdFirmaMn",
                schema: "dbo",
                table: "mon_rajoni",
                newName: "Id_firma");

            migrationBuilder.RenameIndex(
                name: "IX_mon_rajoni_IdFirmaMn",
                schema: "dbo",
                table: "mon_rajoni",
                newName: "IX_mon_rajoni_Id_firma");

            migrationBuilder.RenameColumn(
                name: "IdFirmaMn",
                schema: "dbo",
                table: "mon_porychka",
                newName: "Id_firma");

            migrationBuilder.RenameIndex(
                name: "IX_mon_porychka_IdFirmaMn",
                schema: "dbo",
                table: "mon_porychka",
                newName: "IX_mon_porychka_Id_firma");

            migrationBuilder.RenameColumn(
                name: "IdFirmaMn",
                schema: "dbo",
                table: "mon_grafik",
                newName: "Id_firma");

            migrationBuilder.RenameColumn(
                name: "IdFirmaNm",
                schema: "dbo",
                table: "mon_dgv_uredi",
                newName: "Id_firma");

            migrationBuilder.RenameIndex(
                name: "IX_mon_dgv_uredi_IdFirmaNm",
                schema: "dbo",
                table: "mon_dgv_uredi",
                newName: "IX_mon_dgv_uredi_Id_firma");

            migrationBuilder.RenameColumn(
                name: "Status_DM",
                schema: "dbo",
                table: "mon_dgv_podizpylniteli",
                newName: "STATUS_DM");

            migrationBuilder.RenameColumn(
                name: "IdFirmaMn",
                schema: "dbo",
                table: "mon_dgv_podizpylniteli",
                newName: "ID_FIRMA");

            migrationBuilder.RenameIndex(
                name: "IX_mon_dgv_podizpylniteli_IdFirmaMn",
                schema: "dbo",
                table: "mon_dgv_podizpylniteli",
                newName: "IX_mon_dgv_podizpylniteli_ID_FIRMA");

            migrationBuilder.AlterColumn<int>(
                name: "ID_FIRMA",
                schema: "dbo",
                table: "mon_dogovor",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Status_F",
                schema: "dbo",
                table: "lica_formuliar",
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
                table: "lica_formuliar",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "Acst_date",
                schema: "dbo",
                table: "lica_formuliar",
                type: "datetime2(0)",
                precision: 0,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Acster",
                schema: "dbo",
                table: "lica_formuliar",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status_L",
                schema: "dbo",
                table: "lica",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Status_F",
                schema: "dbo",
                table: "lica",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldMaxLength: 1);

            migrationBuilder.AddColumn<string>(
                name: "Fime",
                schema: "dbo",
                table: "lica",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GIME",
                schema: "dbo",
                table: "lica",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID_Predstavitel",
                schema: "dbo",
                table: "lica",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PIME",
                schema: "dbo",
                table: "lica",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Predstavitel",
                schema: "dbo",
                table: "lica",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "lica_formuliar_danni",
                schema: "dbo",
                columns: table => new
                {
                    Id_Vyprosnik = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chislo = table.Column<int>(type: "int", nullable: true),
                    DA_NE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    faza = table.Column<short>(type: "smallint", nullable: true),
                    ID_Formuliar = table.Column<int>(type: "int", nullable: true),
                    kod_n = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    N_NMN_FK = table.Column<int>(type: "int", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Text_N = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    u_nom = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Ukazatel = table.Column<short>(type: "smallint", nullable: true),
                    Vypros = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_f_vypr_danni_Id_Vyprosnik", x => x.Id_Vyprosnik);
                    table.ForeignKey(
                        name: "FK_lica_formuliar_danni_lica_formuliar",
                        column: x => x.ID_Formuliar,
                        principalSchema: "dbo",
                        principalTable: "lica_formuliar",
                        principalColumn: "ID_Formuliar",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_lica_formuliar_danni_ID_Formuliar",
                schema: "dbo",
                table: "lica_formuliar_danni",
                column: "ID_Formuliar");
        }
    }
}
