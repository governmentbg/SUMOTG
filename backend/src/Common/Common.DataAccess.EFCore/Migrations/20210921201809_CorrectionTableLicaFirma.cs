using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class CorrectionTableLicaFirma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lica_formuliar_firma_lica_IdLNavigationIdL",
                schema: "dbo",
                table: "lica_formuliar_firma");

            migrationBuilder.DropIndex(
                name: "IX_lica_formuliar_firma_IdLNavigationIdL",
                schema: "dbo",
                table: "lica_formuliar_firma");

            migrationBuilder.DropColumn(
                name: "IdLNavigationIdL",
                schema: "dbo",
                table: "lica_formuliar_firma");

            migrationBuilder.DropColumn(
                name: "UNom",
                schema: "dbo",
                table: "lica_formuliar_firma");

            migrationBuilder.CreateIndex(
                name: "IX_lica_formuliar_firma_IdL",
                schema: "dbo",
                table: "lica_formuliar_firma",
                column: "IdL");

            migrationBuilder.AddForeignKey(
                name: "FK_lica_formuliar_firma_lica",
                schema: "dbo",
                table: "lica_formuliar_firma",
                column: "IdL",
                principalSchema: "dbo",
                principalTable: "lica",
                principalColumn: "ID_L",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lica_formuliar_firma_lica",
                schema: "dbo",
                table: "lica_formuliar_firma");

            migrationBuilder.DropIndex(
                name: "IX_lica_formuliar_firma_IdL",
                schema: "dbo",
                table: "lica_formuliar_firma");

            migrationBuilder.AddColumn<int>(
                name: "IdLNavigationIdL",
                schema: "dbo",
                table: "lica_formuliar_firma",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UNom",
                schema: "dbo",
                table: "lica_formuliar_firma",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_lica_formuliar_firma_IdLNavigationIdL",
                schema: "dbo",
                table: "lica_formuliar_firma",
                column: "IdLNavigationIdL");

            migrationBuilder.AddForeignKey(
                name: "FK_lica_formuliar_firma_lica_IdLNavigationIdL",
                schema: "dbo",
                table: "lica_formuliar_firma",
                column: "IdLNavigationIdL",
                principalSchema: "dbo",
                principalTable: "lica",
                principalColumn: "ID_L",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
