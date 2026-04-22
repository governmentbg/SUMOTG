using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class AddedSpravkiTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "n_spravki",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    Faza = table.Column<short>(type: "smallint", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Komentar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tip = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_n_spravki", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "n_spravki",
                schema: "dbo");
        }
    }
}
