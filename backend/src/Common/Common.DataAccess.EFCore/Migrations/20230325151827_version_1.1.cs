using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class version_11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Garancia",
                schema: "dbo",
                table: "mon_dgv_uredi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Profilaktika",
                schema: "dbo",
                table: "mon_dgv_uredi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                schema: "dbo",
                table: "lica_dogovor_uredi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SrokDogovor",
                schema: "dbo",
                table: "lica_dogovor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SrokSobstvenost",
                schema: "dbo",
                table: "lica_dogovor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "filtri_adresi",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tip = table.Column<short>(type: "smallint", nullable: false),
                    A_Raion = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    NM = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    KV = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    JK = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    UL = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Nomer = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    Blok = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    vh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    etaj = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PK = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_filtri_adress_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lica_dogovor_uredi_arhiv",
                schema: "dbo",
                columns: table => new
                {
                    Id_Ured_DG = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_DOG_L = table.Column<int>(type: "int", nullable: false),
                    Id_L = table.Column<int>(type: "int", nullable: false),
                    Id_KT = table.Column<int>(type: "int", nullable: false),
                    Broi = table.Column<int>(type: "int", nullable: false),
                    Status_U = table.Column<short>(type: "smallint", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    Status = table.Column<short>(type: "smallint", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    user = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    Koga = table.Column<DateTime>(type: "datetime", nullable: true),
                    Porychani = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_arh_uredi_dg_l_Id_Ured_DG", x => x.Id_Ured_DG);
                    table.ForeignKey(
                        name: "FK_lica_dogovor_uredi_arhiv_lica_dogovor",
                        column: x => x.ID_DOG_L,
                        principalSchema: "dbo",
                        principalTable: "lica_dogovor",
                        principalColumn: "Id_dog_L",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mon_profilaktika",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPorachkaMain = table.Column<int>(type: "int", nullable: false),
                    IdDogovorLice = table.Column<int>(type: "int", nullable: false),
                    IdUred = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status_PF = table.Column<int>(type: "int", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    User = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Koga = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profilaktika_Idt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mon_profilaktika_lica_dogovor",
                        column: x => x.IdDogovorLice,
                        principalSchema: "dbo",
                        principalTable: "lica_dogovor",
                        principalColumn: "Id_dog_L",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mon_profilaktika_porychka_main",
                        column: x => x.IdPorachkaMain,
                        principalSchema: "dbo",
                        principalTable: "mon_porychkamain",
                        principalColumn: "IDPorachkamain",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "n_fp4_tablica3",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    nime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Koeficient = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Status = table.Column<short>(type: "smallint", unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_n_fp4tablica3_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "n_uredi_budget",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_n_uredi_budget_id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nuredi_budget_nuredi",
                        column: x => x.Id,
                        principalSchema: "dbo",
                        principalTable: "n_uredi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_lica_dogovor_uredi_arhiv_ID_DOG_L",
                schema: "dbo",
                table: "lica_dogovor_uredi_arhiv",
                column: "ID_DOG_L");

            migrationBuilder.CreateIndex(
                name: "IX_mon_profilaktika_IdDogovorLice",
                schema: "dbo",
                table: "mon_profilaktika",
                column: "IdDogovorLice");

            migrationBuilder.CreateIndex(
                name: "IX_mon_profilaktika_IdPorachkaMain",
                schema: "dbo",
                table: "mon_profilaktika",
                column: "IdPorachkaMain");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "filtri_adresi",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "lica_dogovor_uredi_arhiv",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mon_profilaktika",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "n_fp4_tablica3",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "n_uredi_budget",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "Garancia",
                schema: "dbo",
                table: "mon_dgv_uredi");

            migrationBuilder.DropColumn(
                name: "Profilaktika",
                schema: "dbo",
                table: "mon_dgv_uredi");

            migrationBuilder.DropColumn(
                name: "Comment",
                schema: "dbo",
                table: "lica_dogovor_uredi");

            migrationBuilder.DropColumn(
                name: "SrokDogovor",
                schema: "dbo",
                table: "lica_dogovor");

            migrationBuilder.DropColumn(
                name: "SrokSobstvenost",
                schema: "dbo",
                table: "lica_dogovor");
        }
    }
}
