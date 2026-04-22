using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class ChangedFieldNameCenaMonDemon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ObshtaCenaDDS",
                schema: "dbo",
                table: "mon_dogovor",
                newName: "CenaDDS");

            migrationBuilder.RenameColumn(
                name: "ObshtaCenaBezDDS",
                schema: "dbo",
                table: "mon_dogovor",
                newName: "CenaBezDDS");

            migrationBuilder.RenameColumn(
                name: "Obsht_Srok_grf",
                schema: "dbo",
                table: "mon_dogovor",
                newName: "SrokGrafik");

            migrationBuilder.RenameColumn(
                name: "ObshtaCenaDDS",
                schema: "dbo",
                table: "dem_dogovor",
                newName: "CenaDDS");

            migrationBuilder.RenameColumn(
                name: "ObshtaCenaBezDDS",
                schema: "dbo",
                table: "dem_dogovor",
                newName: "CenaBezDDS");

            migrationBuilder.RenameColumn(
                name: "Obsht_Srok_grf",
                schema: "dbo",
                table: "dem_dogovor",
                newName: "SrokGrafik");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SrokGrafik",
                schema: "dbo",
                table: "mon_dogovor",
                newName: "Obsht_Srok_grf");

            migrationBuilder.RenameColumn(
                name: "CenaDDS",
                schema: "dbo",
                table: "mon_dogovor",
                newName: "ObshtaCenaDDS");

            migrationBuilder.RenameColumn(
                name: "CenaBezDDS",
                schema: "dbo",
                table: "mon_dogovor",
                newName: "ObshtaCenaBezDDS");

            migrationBuilder.RenameColumn(
                name: "SrokGrafik",
                schema: "dbo",
                table: "dem_dogovor",
                newName: "Obsht_Srok_grf");

            migrationBuilder.RenameColumn(
                name: "CenaDDS",
                schema: "dbo",
                table: "dem_dogovor",
                newName: "ObshtaCenaDDS");

            migrationBuilder.RenameColumn(
                name: "CenaBezDDS",
                schema: "dbo",
                table: "dem_dogovor",
                newName: "ObshtaCenaBezDDS");
        }
    }
}
