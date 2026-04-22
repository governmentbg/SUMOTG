using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class AddedObhvatTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Obhvat",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obhvat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserObhvat",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ObhvatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserObhvat", x => new { x.UserId, x.ObhvatId });
                    table.ForeignKey(
                        name: "FK_UserObhvat_Obhvat_ObhvatId",
                        column: x => x.ObhvatId,
                        principalSchema: "dbo",
                        principalTable: "Obhvat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserObhvat_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserObhvat_ObhvatId",
                schema: "dbo",
                table: "UserObhvat",
                column: "ObhvatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserObhvat",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Obhvat",
                schema: "dbo");
        }
    }
}
