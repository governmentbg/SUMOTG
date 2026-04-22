using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class AddedPaymentTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dem_payments",
                schema: "dbo",
                columns: table => new
                {
                    ID_rec = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPay = table.Column<int>(type: "int", nullable: false),
                    ID_FIRMA_DM = table.Column<int>(type: "int", nullable: false),
                    SumaBezDDS = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    SumaDDS = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_demontaj_payments_ID_rec", x => x.ID_rec);
                    table.ForeignKey(
                        name: "FK_dem_payments_dem_dogovor",
                        column: x => x.ID_FIRMA_DM,
                        principalSchema: "dbo",
                        principalTable: "dem_dogovor",
                        principalColumn: "Id_firma_DM",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lica_dopsporazumeniq",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_L = table.Column<int>(type: "int", nullable: false),
                    IdDopSp = table.Column<int>(type: "int", nullable: false),
                    RegNomer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Komentar = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_licadopsporaz_Id_Dok", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lica_dopsporazumeniq_lica",
                        column: x => x.Id_L,
                        principalSchema: "dbo",
                        principalTable: "lica",
                        principalColumn: "ID_L",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mon_payments",
                schema: "dbo",
                columns: table => new
                {
                    ID_rec = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPay = table.Column<int>(type: "int", nullable: false),
                    ID_FIRMA_MN = table.Column<int>(type: "int", nullable: false),
                    SumaBezDDS = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    SumaDDS = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_montaj_payments_ID_rec", x => x.ID_rec);
                    table.ForeignKey(
                        name: "FK_mon_payments_dem_dogovor",
                        column: x => x.ID_FIRMA_MN,
                        principalSchema: "dbo",
                        principalTable: "mon_dogovor",
                        principalColumn: "IdFirmaMn",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dem_payments_ID_FIRMA_DM",
                schema: "dbo",
                table: "dem_payments",
                column: "ID_FIRMA_DM");

            migrationBuilder.CreateIndex(
                name: "IX_lica_dopsporazumeniq_Id_L",
                schema: "dbo",
                table: "lica_dopsporazumeniq",
                column: "Id_L");

            migrationBuilder.CreateIndex(
                name: "IX_mon_payments_ID_FIRMA_MN",
                schema: "dbo",
                table: "mon_payments",
                column: "ID_FIRMA_MN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dem_payments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "lica_dopsporazumeniq",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mon_payments",
                schema: "dbo");
        }
    }
}
