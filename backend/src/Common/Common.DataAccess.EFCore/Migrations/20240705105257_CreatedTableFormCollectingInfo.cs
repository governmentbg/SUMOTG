using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class CreatedTableFormCollectingInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "form_collecting_info",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Familiq = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    A_Raion = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    NM = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    KV = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    JK = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    UL = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Nomer = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    Blok = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    vh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    etaj = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PK = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    e_mail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    tel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    v1 = table.Column<short>(type: "smallint", nullable: false),
                    v101 = table.Column<short>(type: "smallint", nullable: false),
                    v2 = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_form_collecting_info_Id", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "form_collecting_info",
                schema: "dbo");
        }
    }
}
