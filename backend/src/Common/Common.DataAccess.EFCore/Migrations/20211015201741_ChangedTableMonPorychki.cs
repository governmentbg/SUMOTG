using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class ChangedTableMonPorychki : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mon_porychka_lica",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropForeignKey(
                name: "FK_mon_porychka_mon_dogovor",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropTable(
                name: "mon_grafik",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mon_otchet",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_porychka_m_IDM",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropIndex(
                name: "IX_mon_porychka_id_L",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropIndex(
                 name: "IX_mon_porychka_Id_firma",
                 schema: "dbo",
                 table: "mon_porychka");

            migrationBuilder.DropIndex(
                name: "IX_mon_porychka_IdFirmaMn",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "IDM",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "A_Raion",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "Broi_U",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "Faza",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "IDENT",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "IME",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "IdFirmaMn",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "Id_SP_NET",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "Id_kn",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "Nomer_poreden_M",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "U_nom",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "id_L",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "vypros",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.RenameColumn(
                name: "Status_dp",
                schema: "dbo",
                table: "mon_porychka",
                newName: "StatusP");

            migrationBuilder.RenameColumn(
                name: "Start_date",
                schema: "dbo",
                table: "mon_porychka",
                newName: "StartData");

            migrationBuilder.RenameColumn(
                name: "OT_Data",
                schema: "dbo",
                table: "mon_porychka",
                newName: "ProtData");

            migrationBuilder.RenameColumn(
                name: "DO_data",
                schema: "dbo",
                table: "mon_porychka",
                newName: "MonData");

            migrationBuilder.AddColumn<int>(
                name: "IdUred",
                schema: "dbo",
                table: "mon_porychka",
                type: "int",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "IDPorachkaBody",
                schema: "dbo",
                table: "mon_porychka",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Broi",
                schema: "dbo",
                table: "mon_porychka",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndData",
                schema: "dbo",
                table: "mon_porychka",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FabrNomer",
                schema: "dbo",
                table: "mon_porychka",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdDogovorLice",
                schema: "dbo",
                table: "mon_porychka",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPorachkaMain",
                schema: "dbo",
                table: "mon_porychka",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProtNomer",
                schema: "dbo",
                table: "mon_porychka",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "StatusG",
                schema: "dbo",
                table: "mon_porychka",
                type: "smallint",
                unicode: false,
                fixedLength: true,
                maxLength: 1,
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "StatusM",
                schema: "dbo",
                table: "mon_porychka",
                type: "smallint",
                unicode: false,
                fixedLength: true,
                maxLength: 1,
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_porychka_IDPorachkaBody",
                schema: "dbo",
                table: "mon_porychka",
                column: "IDPorachkaBody");

            migrationBuilder.CreateTable(
                name: "mon_porychkamain",
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
                    table.PrimaryKey("PK_porychka_main_IDPorachka", x => x.IDPorachkamain);
                    table.ForeignKey(
                        name: "FK_mon_porychkamain_mon_dogovor",
                        column: x => x.IdDogovorFirma,
                        principalSchema: "dbo",
                        principalTable: "mon_dogovor",
                        principalColumn: "IdFirmaMn",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mon_porychka_IdDogovorLice",
                schema: "dbo",
                table: "mon_porychka",
                column: "IdDogovorLice");

            migrationBuilder.CreateIndex(
                name: "IX_mon_porychka_IdPorachkaMain",
                schema: "dbo",
                table: "mon_porychka",
                column: "IdPorachkaMain");

            migrationBuilder.CreateIndex(
                name: "IX_mon_porychkamain_IdDogovorFirma",
                schema: "dbo",
                table: "mon_porychkamain",
                column: "IdDogovorFirma");

            migrationBuilder.AddForeignKey(
                name: "FK_mon_porychka_dogovor_lica",
                schema: "dbo",
                table: "mon_porychka",
                column: "IdDogovorLice",
                principalSchema: "dbo",
                principalTable: "lica_dogovor",
                principalColumn: "Id_dog_L",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mon_porychka_mon_porychka_main",
                schema: "dbo",
                table: "mon_porychka",
                column: "IdPorachkaMain",
                principalSchema: "dbo",
                principalTable: "mon_porychkamain",
                principalColumn: "IDPorachkamain",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mon_porychka_dogovor_lica",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropForeignKey(
                name: "FK_mon_porychka_mon_porychka_main",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropTable(
                name: "mon_porychkamain",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_porychka_IDPorachkaBody",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropIndex(
                name: "IX_mon_porychka_IdDogovorLice",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropIndex(
                name: "IX_mon_porychka_IdPorachkaMain",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "IDPorachkaBody",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "Broi",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "EndData",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "FabrNomer",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "IdDogovorLice",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "IdPorachkaMain",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "ProtNomer",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "StatusG",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.DropColumn(
                name: "StatusM",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.RenameColumn(
                name: "StatusP",
                schema: "dbo",
                table: "mon_porychka",
                newName: "Status_dp");

            migrationBuilder.RenameColumn(
                name: "StartData",
                schema: "dbo",
                table: "mon_porychka",
                newName: "Start_date");

            migrationBuilder.RenameColumn(
                name: "ProtData",
                schema: "dbo",
                table: "mon_porychka",
                newName: "OT_Data");

            migrationBuilder.RenameColumn(
                name: "MonData",
                schema: "dbo",
                table: "mon_porychka",
                newName: "DO_data");

            migrationBuilder.RenameColumn(
                name: "IdUred",
                schema: "dbo",
                table: "mon_porychka",
                newName: "IDM");

            migrationBuilder.AddColumn<int>(
                name: "IDM",
                schema: "dbo",
                table: "mon_porychka",
                type: "int",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "A_Raion",
                schema: "dbo",
                table: "mon_porychka",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Broi_U",
                schema: "dbo",
                table: "mon_porychka",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Faza",
                schema: "dbo",
                table: "mon_porychka",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IDENT",
                schema: "dbo",
                table: "mon_porychka",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IME",
                schema: "dbo",
                table: "mon_porychka",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdFirmaMn",
                schema: "dbo",
                table: "mon_porychka",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id_SP_NET",
                schema: "dbo",
                table: "mon_porychka",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id_kn",
                schema: "dbo",
                table: "mon_porychka",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Nomer_poreden_M",
                schema: "dbo",
                table: "mon_porychka",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "U_nom",
                schema: "dbo",
                table: "mon_porychka",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id_L",
                schema: "dbo",
                table: "mon_porychka",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "vypros",
                schema: "dbo",
                table: "mon_porychka",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_porychka_m_IDM",
                schema: "dbo",
                table: "mon_porychka",
                column: "IDM");

            migrationBuilder.CreateTable(
                name: "mon_grafik",
                schema: "dbo",
                columns: table => new
                {
                    Id_GRAFIK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    A_Raion = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    AP = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Blok = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Broi_U = table.Column<int>(type: "int", nullable: true),
                    DO_data = table.Column<DateTime>(type: "date", nullable: true),
                    etaj = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Faza = table.Column<short>(type: "smallint", nullable: true),
                    Fime = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    GIME = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    IdFirmaMn = table.Column<int>(type: "int", nullable: true),
                    Id_kn = table.Column<int>(type: "int", nullable: true),
                    id_L = table.Column<int>(type: "int", nullable: true),
                    Id_SP_NET = table.Column<int>(type: "int", nullable: true),
                    IDENT = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IDM = table.Column<int>(type: "int", nullable: true),
                    IME = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    JK = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    koga = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    KV = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    NM = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Nomer = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Nomer_poreden_M = table.Column<int>(type: "int", nullable: false),
                    OT_Data = table.Column<DateTime>(type: "date", nullable: true),
                    PIME = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Status = table.Column<short>(type: "smallint", maxLength: 1, nullable: false),
                    Status_dp = table.Column<short>(type: "smallint", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    tel = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    U_nom = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    UL = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    user = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    vh = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    vypros = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grafik_m_Id_GRAFIK", x => x.Id_GRAFIK);
                    table.ForeignKey(
                        name: "FK_mon_grafik_mon_porychka",
                        column: x => x.IDM,
                        principalSchema: "dbo",
                        principalTable: "mon_porychka",
                        principalColumn: "IDM",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mon_otchet",
                schema: "dbo",
                columns: table => new
                {
                    ID_OTCHET = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Broi_U = table.Column<int>(type: "int", nullable: true),
                    data_montazj = table.Column<DateTime>(type: "datetime", nullable: true),
                    DO_data = table.Column<DateTime>(type: "date", nullable: true),
                    fabr_nomer = table.Column<byte[]>(type: "varbinary(50)", maxLength: 50, nullable: true),
                    Faza = table.Column<short>(type: "smallint", nullable: true),
                    gar_nomer = table.Column<byte[]>(type: "varbinary(50)", maxLength: 50, nullable: true),
                    Id_GRAFIK = table.Column<int>(type: "int", nullable: true),
                    IDM = table.Column<int>(type: "int", nullable: false),
                    koga = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    NA_DATA = table.Column<DateTime>(type: "date", nullable: true),
                    Nomer_poreden_M = table.Column<int>(type: "int", nullable: false),
                    OT_Data = table.Column<DateTime>(type: "date", nullable: true),
                    Status = table.Column<short>(type: "smallint", maxLength: 1, nullable: false),
                    Status_dp = table.Column<short>(type: "smallint", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    user = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_otchet_m_ID_OTCHET", x => x.ID_OTCHET);
                    table.ForeignKey(
                        name: "FK_mon_otchet_mon_porychka",
                        column: x => x.IDM,
                        principalSchema: "dbo",
                        principalTable: "mon_porychka",
                        principalColumn: "IDM",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mon_porychka_id_L",
                schema: "dbo",
                table: "mon_porychka",
                column: "id_L");

            migrationBuilder.CreateIndex(
                name: "IX_mon_porychka_IdFirmaMn",
                schema: "dbo",
                table: "mon_porychka",
                column: "IdFirmaMn");

            migrationBuilder.CreateIndex(
                name: "IX_mon_grafik_IDM",
                schema: "dbo",
                table: "mon_grafik",
                column: "IDM");

            migrationBuilder.CreateIndex(
                name: "IX_mon_otchet_IDM",
                schema: "dbo",
                table: "mon_otchet",
                column: "IDM");

            migrationBuilder.AddForeignKey(
                name: "FK_mon_porychka_lica",
                schema: "dbo",
                table: "mon_porychka",
                column: "id_L",
                principalSchema: "dbo",
                principalTable: "lica",
                principalColumn: "ID_L",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mon_porychka_mon_dogovor",
                schema: "dbo",
                table: "mon_porychka",
                column: "IdFirmaMn",
                principalSchema: "dbo",
                principalTable: "mon_dogovor",
                principalColumn: "IdFirmaMn",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
