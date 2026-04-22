using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class AddedForeignKeyFormulqrUrediLica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lica_formuliar_uredi_lica_formuliar",
                schema: "dbo",
                table: "lica_formuliar_uredi");

            migrationBuilder.DropIndex(
                name: "IX_lica_formuliar_uredi_Id_formuliar",
                schema: "dbo",
                table: "lica_formuliar_uredi");

            migrationBuilder.CreateIndex(
                name: "IX_lica_formuliar_uredi_Id_L",
                schema: "dbo",
                table: "lica_formuliar_uredi",
                column: "Id_L");

            migrationBuilder.AddForeignKey(
                name: "FK_lica_formuliar_uredi_lica",
                schema: "dbo",
                table: "lica_formuliar_uredi",
                column: "Id_L",
                principalSchema: "dbo",
                principalTable: "lica",
                principalColumn: "ID_L",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lica_formuliar_uredi_lica",
                schema: "dbo",
                table: "lica_formuliar_uredi");

            migrationBuilder.DropIndex(
                name: "IX_lica_formuliar_uredi_Id_L",
                schema: "dbo",
                table: "lica_formuliar_uredi");

            migrationBuilder.CreateIndex(
                name: "IX_lica_formuliar_uredi_Id_formuliar",
                schema: "dbo",
                table: "lica_formuliar_uredi",
                column: "Id_formuliar");

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
    }
}
