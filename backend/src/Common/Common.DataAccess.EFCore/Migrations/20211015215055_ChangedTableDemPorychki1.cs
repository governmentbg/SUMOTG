using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class ChangedTableDemPorychki1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dem_porychka_lica_dogovor_IdLiceDogovorNavigationIdDogL",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropIndex(
                name: "IX_dem_porychka_IdLiceDogovorNavigationIdDogL",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropColumn(
                name: "IdLiceDogovorNavigationIdDogL",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.AlterColumn<DateTime>(
                name: "koga",
                schema: "dbo",
                table: "mon_porychkamain",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldPrecision: 0,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "koga",
                schema: "dbo",
                table: "mon_porychka",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldPrecision: 0,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartData",
                schema: "dbo",
                table: "mon_porychka",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MonData",
                schema: "dbo",
                table: "mon_porychka",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndData",
                schema: "dbo",
                table: "mon_porychka",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "GarCardData",
                schema: "dbo",
                table: "mon_porychka",
                type: "datetime",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "koga",
                schema: "dbo",
                table: "mon_dogovor",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldPrecision: 0,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NachalnaData",
                schema: "dbo",
                table: "mon_dogovor",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Data_reg_N",
                schema: "dbo",
                table: "mon_dogovor",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "koga",
                schema: "dbo",
                table: "dem_porychkamain",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldPrecision: 0,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_dem_porychka_IdDogovorLice",
                schema: "dbo",
                table: "dem_porychka",
                column: "IdDogovorLice");

            migrationBuilder.AddForeignKey(
                name: "FK_dem_porychka_lice_dogovor",
                schema: "dbo",
                table: "dem_porychka",
                column: "IdDogovorLice",
                principalSchema: "dbo",
                principalTable: "lica_dogovor",
                principalColumn: "Id_dog_L",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dem_porychka_lice_dogovor",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropIndex(
                name: "IX_dem_porychka_IdDogovorLice",
                schema: "dbo",
                table: "dem_porychka");

            migrationBuilder.DropColumn(
                name: "GarCardData",
                schema: "dbo",
                table: "mon_porychka");

            migrationBuilder.AlterColumn<DateTime>(
                name: "koga",
                schema: "dbo",
                table: "mon_porychkamain",
                type: "datetime2(0)",
                precision: 0,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "koga",
                schema: "dbo",
                table: "mon_porychka",
                type: "datetime2(0)",
                precision: 0,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartData",
                schema: "dbo",
                table: "mon_porychka",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MonData",
                schema: "dbo",
                table: "mon_porychka",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndData",
                schema: "dbo",
                table: "mon_porychka",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "koga",
                schema: "dbo",
                table: "mon_dogovor",
                type: "datetime2(0)",
                precision: 0,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NachalnaData",
                schema: "dbo",
                table: "mon_dogovor",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Data_reg_N",
                schema: "dbo",
                table: "mon_dogovor",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "koga",
                schema: "dbo",
                table: "dem_porychkamain",
                type: "datetime2(0)",
                precision: 0,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdLiceDogovorNavigationIdDogL",
                schema: "dbo",
                table: "dem_porychka",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_dem_porychka_IdLiceDogovorNavigationIdDogL",
                schema: "dbo",
                table: "dem_porychka",
                column: "IdLiceDogovorNavigationIdDogL");

            migrationBuilder.AddForeignKey(
                name: "FK_dem_porychka_lica_dogovor_IdLiceDogovorNavigationIdDogL",
                schema: "dbo",
                table: "dem_porychka",
                column: "IdLiceDogovorNavigationIdDogL",
                principalSchema: "dbo",
                principalTable: "lica_dogovor",
                principalColumn: "Id_dog_L",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
