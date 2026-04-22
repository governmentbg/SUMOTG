using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class RemoveTableLicaUrediOld : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LicaFormuliarFirma_lica_IdLNavigationIdL",
                schema: "dbo",
                table: "LicaFormuliarFirma");

            migrationBuilder.DropForeignKey(
                name: "FK_LicaFormuliarKolektiv_lica_IdLNavigationIdL",
                schema: "dbo",
                table: "LicaFormuliarKolektiv");

            migrationBuilder.DropTable(
                name: "lica_dogovor_olduredi",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LicaFormuliarKolektiv",
                schema: "dbo",
                table: "LicaFormuliarKolektiv");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LicaFormuliarFirma",
                schema: "dbo",
                table: "LicaFormuliarFirma");

            migrationBuilder.RenameTable(
                name: "LicaFormuliarKolektiv",
                schema: "dbo",
                newName: "lica_formuliar_kolektiv",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "LicaFormuliarFirma",
                schema: "dbo",
                newName: "lica_formuliar_firma",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_LicaFormuliarKolektiv_IdLNavigationIdL",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                newName: "IX_lica_formuliar_kolektiv_IdLNavigationIdL");

            migrationBuilder.RenameIndex(
                name: "IX_LicaFormuliarFirma_IdLNavigationIdL",
                schema: "dbo",
                table: "lica_formuliar_firma",
                newName: "IX_lica_formuliar_firma_IdLNavigationIdL");

            migrationBuilder.AddPrimaryKey(
                name: "PK_lica_formuliar_kolektiv",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_lica_formuliar_firma",
                schema: "dbo",
                table: "lica_formuliar_firma",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_lica_formuliar_firma_lica_IdLNavigationIdL",
                schema: "dbo",
                table: "lica_formuliar_firma",
                column: "IdLNavigationIdL",
                principalSchema: "dbo",
                principalTable: "lica",
                principalColumn: "ID_L",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_lica_formuliar_kolektiv_lica_IdLNavigationIdL",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                column: "IdLNavigationIdL",
                principalSchema: "dbo",
                principalTable: "lica",
                principalColumn: "ID_L",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lica_formuliar_firma_lica_IdLNavigationIdL",
                schema: "dbo",
                table: "lica_formuliar_firma");

            migrationBuilder.DropForeignKey(
                name: "FK_lica_formuliar_kolektiv_lica_IdLNavigationIdL",
                schema: "dbo",
                table: "lica_formuliar_kolektiv");

            migrationBuilder.DropPrimaryKey(
                name: "PK_lica_formuliar_kolektiv",
                schema: "dbo",
                table: "lica_formuliar_kolektiv");

            migrationBuilder.DropPrimaryKey(
                name: "PK_lica_formuliar_firma",
                schema: "dbo",
                table: "lica_formuliar_firma");

            migrationBuilder.RenameTable(
                name: "lica_formuliar_kolektiv",
                schema: "dbo",
                newName: "LicaFormuliarKolektiv",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "lica_formuliar_firma",
                schema: "dbo",
                newName: "LicaFormuliarFirma",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_lica_formuliar_kolektiv_IdLNavigationIdL",
                schema: "dbo",
                table: "LicaFormuliarKolektiv",
                newName: "IX_LicaFormuliarKolektiv_IdLNavigationIdL");

            migrationBuilder.RenameIndex(
                name: "IX_lica_formuliar_firma_IdLNavigationIdL",
                schema: "dbo",
                table: "LicaFormuliarFirma",
                newName: "IX_LicaFormuliarFirma_IdLNavigationIdL");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LicaFormuliarKolektiv",
                schema: "dbo",
                table: "LicaFormuliarKolektiv",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LicaFormuliarFirma",
                schema: "dbo",
                table: "LicaFormuliarFirma",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "lica_dogovor_olduredi",
                schema: "dbo",
                columns: table => new
                {
                    ID_OLDUREDI_DGL = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Broi = table.Column<int>(type: "int", nullable: true),
                    Id_KT = table.Column<int>(type: "int", nullable: true),
                    Id_L = table.Column<int>(type: "int", nullable: true),
                    Koga = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Status = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Status_U = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    user = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    Vypros = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_olduredi_dg_l_ID_OLDUREDI_DGL", x => x.ID_OLDUREDI_DGL);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_LicaFormuliarFirma_lica_IdLNavigationIdL",
                schema: "dbo",
                table: "LicaFormuliarFirma",
                column: "IdLNavigationIdL",
                principalSchema: "dbo",
                principalTable: "lica",
                principalColumn: "ID_L",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LicaFormuliarKolektiv_lica_IdLNavigationIdL",
                schema: "dbo",
                table: "LicaFormuliarKolektiv",
                column: "IdLNavigationIdL",
                principalSchema: "dbo",
                principalTable: "lica",
                principalColumn: "ID_L",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
