using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class AddedTableNKid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BroiPorychki",
                schema: "dbo",
                table: "mon_dogovor");

            migrationBuilder.DropColumn(
                name: "BroiPorychki",
                schema: "dbo",
                table: "dem_dogovor");

            migrationBuilder.AddColumn<int>(
                name: "BroiPorychki",
                schema: "dbo",
                table: "mon_dgv_uredi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BroiPorychki",
                schema: "dbo",
                table: "dem_dgv_olduredi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "n_kid",
                schema: "dbo",
                columns: table => new
                {
                    nkod = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    nime = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_n_kid_id", x => x.nkod);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "n_kid",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "BroiPorychki",
                schema: "dbo",
                table: "mon_dgv_uredi");

            migrationBuilder.DropColumn(
                name: "BroiPorychki",
                schema: "dbo",
                table: "dem_dgv_olduredi");

            migrationBuilder.AddColumn<int>(
                name: "BroiPorychki",
                schema: "dbo",
                table: "mon_dogovor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BroiPorychki",
                schema: "dbo",
                table: "dem_dogovor",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
