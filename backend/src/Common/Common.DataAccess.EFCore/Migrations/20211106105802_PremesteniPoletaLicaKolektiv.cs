using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class PremesteniPoletaLicaKolektiv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lica_formuliar_kolektiv_lica_IdLNavigationIdL",
                schema: "dbo",
                table: "lica_formuliar_kolektiv");

            migrationBuilder.DropPrimaryKey(
                name: "PK_lica_formuliar_kolektiv",
                schema: "dbo",
                table: "lica_formuliar_kolektiv");

            migrationBuilder.DropIndex(
                name: "IX_lica_formuliar_kolektiv_IdLNavigationIdL",
                schema: "dbo",
                table: "lica_formuliar_kolektiv");

            migrationBuilder.DropColumn(
                name: "Faza",
                schema: "dbo",
                table: "lica_formuliar_kolektiv");

            migrationBuilder.DropColumn(
                name: "IdLNavigationIdL",
                schema: "dbo",
                table: "lica_formuliar_kolektiv");

            migrationBuilder.DropColumn(
                name: "AP",
                schema: "dbo",
                table: "lica");

            migrationBuilder.DropColumn(
                name: "A_Raion",
                schema: "dbo",
                table: "lica");

            migrationBuilder.DropColumn(
                name: "Blok",
                schema: "dbo",
                table: "lica");

            migrationBuilder.DropColumn(
                name: "Data_izdavane",
                schema: "dbo",
                table: "lica");

            migrationBuilder.DropColumn(
                name: "IDENT",
                schema: "dbo",
                table: "lica");

            migrationBuilder.DropColumn(
                name: "IME",
                schema: "dbo",
                table: "lica");

            migrationBuilder.DropColumn(
                name: "JK",
                schema: "dbo",
                table: "lica");

            migrationBuilder.DropColumn(
                name: "KV",
                schema: "dbo",
                table: "lica");

            migrationBuilder.DropColumn(
                name: "NM",
                schema: "dbo",
                table: "lica");

            migrationBuilder.DropColumn(
                name: "N_LK",
                schema: "dbo",
                table: "lica");

            migrationBuilder.DropColumn(
                name: "Nomer",
                schema: "dbo",
                table: "lica");

            migrationBuilder.DropColumn(
                name: "PK",
                schema: "dbo",
                table: "lica");

            migrationBuilder.DropColumn(
                name: "Status_F",
                schema: "dbo",
                table: "lica");

            migrationBuilder.DropColumn(
                name: "Status_L",
                schema: "dbo",
                table: "lica");

            migrationBuilder.DropColumn(
                name: "UL",
                schema: "dbo",
                table: "lica");

            migrationBuilder.DropColumn(
                name: "V7",
                schema: "dbo",
                table: "lica");

            migrationBuilder.DropColumn(
                name: "Zona",
                schema: "dbo",
                table: "lica");

            migrationBuilder.DropColumn(
                name: "e_mail",
                schema: "dbo",
                table: "lica");

            migrationBuilder.DropColumn(
                name: "etaj",
                schema: "dbo",
                table: "lica");

            migrationBuilder.DropColumn(
                name: "nV8",
                schema: "dbo",
                table: "lica");

            migrationBuilder.DropColumn(
                name: "tel",
                schema: "dbo",
                table: "lica");

            migrationBuilder.DropColumn(
                name: "v_ident",
                schema: "dbo",
                table: "lica");

            migrationBuilder.DropColumn(
                name: "vh",
                schema: "dbo",
                table: "lica");

            migrationBuilder.RenameColumn(
                name: "Vh",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                newName: "vh");

            migrationBuilder.RenameColumn(
                name: "Ul",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                newName: "UL");

            migrationBuilder.RenameColumn(
                name: "Tel",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                newName: "tel");

            migrationBuilder.RenameColumn(
                name: "Pk",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                newName: "PK");

            migrationBuilder.RenameColumn(
                name: "Nm",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                newName: "NM");

            migrationBuilder.RenameColumn(
                name: "Kv",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                newName: "KV");

            migrationBuilder.RenameColumn(
                name: "Koga",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                newName: "koga");

            migrationBuilder.RenameColumn(
                name: "Jk",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                newName: "JK");

            migrationBuilder.RenameColumn(
                name: "Ime",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                newName: "IME");

            migrationBuilder.RenameColumn(
                name: "Ident",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                newName: "IDENT");

            migrationBuilder.RenameColumn(
                name: "Etaj",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                newName: "etaj");

            migrationBuilder.RenameColumn(
                name: "Ap",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                newName: "AP");

            migrationBuilder.RenameColumn(
                name: "VIdent",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                newName: "v_ident");

            migrationBuilder.RenameColumn(
                name: "EMail",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                newName: "e_mail");

            migrationBuilder.RenameColumn(
                name: "ARaion",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                newName: "A_Raion");

            migrationBuilder.RenameColumn(
                name: "koga",
                schema: "dbo",
                table: "lica",
                newName: "Koga");

            migrationBuilder.AlterColumn<string>(
                name: "vh",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UL",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "tel",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PK",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nomer",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NM",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KV",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "koga",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "datetime2(0)",
                precision: 0,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JK",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IME",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IDENT",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "etaj",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Blok",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AP",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "e_mail",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "A_Raion",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Data_izdavane",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "N_LK",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "V7",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Zona",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "nV8",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Koga",
                schema: "dbo",
                table: "lica",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldPrecision: 0,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_lica_formuliar_kolektiv_Id",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_lica_formuliar_kolektiv_IdL",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                column: "IdL");

            migrationBuilder.AddForeignKey(
                name: "FK_lica_formuliar_kolektiv_lica",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                column: "IdL",
                principalSchema: "dbo",
                principalTable: "lica",
                principalColumn: "ID_L",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lica_formuliar_kolektiv_lica",
                schema: "dbo",
                table: "lica_formuliar_kolektiv");

            migrationBuilder.DropPrimaryKey(
                name: "PK_lica_formuliar_kolektiv_Id",
                schema: "dbo",
                table: "lica_formuliar_kolektiv");

            migrationBuilder.DropIndex(
                name: "IX_lica_formuliar_kolektiv_IdL",
                schema: "dbo",
                table: "lica_formuliar_kolektiv");

            migrationBuilder.DropColumn(
                name: "Data_izdavane",
                schema: "dbo",
                table: "lica_formuliar_kolektiv");

            migrationBuilder.DropColumn(
                name: "N_LK",
                schema: "dbo",
                table: "lica_formuliar_kolektiv");

            migrationBuilder.DropColumn(
                name: "V7",
                schema: "dbo",
                table: "lica_formuliar_kolektiv");

            migrationBuilder.DropColumn(
                name: "Zona",
                schema: "dbo",
                table: "lica_formuliar_kolektiv");

            migrationBuilder.DropColumn(
                name: "nV8",
                schema: "dbo",
                table: "lica_formuliar_kolektiv");

            migrationBuilder.RenameColumn(
                name: "vh",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                newName: "Vh");

            migrationBuilder.RenameColumn(
                name: "tel",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                newName: "Tel");

            migrationBuilder.RenameColumn(
                name: "koga",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                newName: "Koga");

            migrationBuilder.RenameColumn(
                name: "etaj",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                newName: "Etaj");

            migrationBuilder.RenameColumn(
                name: "UL",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                newName: "Ul");

            migrationBuilder.RenameColumn(
                name: "PK",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                newName: "Pk");

            migrationBuilder.RenameColumn(
                name: "NM",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                newName: "Nm");

            migrationBuilder.RenameColumn(
                name: "KV",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                newName: "Kv");

            migrationBuilder.RenameColumn(
                name: "JK",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                newName: "Jk");

            migrationBuilder.RenameColumn(
                name: "IME",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                newName: "Ime");

            migrationBuilder.RenameColumn(
                name: "IDENT",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                newName: "Ident");

            migrationBuilder.RenameColumn(
                name: "AP",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                newName: "Ap");

            migrationBuilder.RenameColumn(
                name: "v_ident",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                newName: "VIdent");

            migrationBuilder.RenameColumn(
                name: "e_mail",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                newName: "EMail");

            migrationBuilder.RenameColumn(
                name: "A_Raion",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                newName: "ARaion");

            migrationBuilder.RenameColumn(
                name: "Koga",
                schema: "dbo",
                table: "lica",
                newName: "koga");

            migrationBuilder.AlterColumn<string>(
                name: "Vh",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tel",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Koga",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldPrecision: 0,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Etaj",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ul",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Pk",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nomer",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(35)",
                oldMaxLength: 35,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nm",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Kv",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Jk",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ime",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ident",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Blok",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ap",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EMail",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ARaion",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Faza",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<int>(
                name: "IdLNavigationIdL",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "koga",
                schema: "dbo",
                table: "lica",
                type: "datetime2(0)",
                precision: 0,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AP",
                schema: "dbo",
                table: "lica",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "A_Raion",
                schema: "dbo",
                table: "lica",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Blok",
                schema: "dbo",
                table: "lica",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Data_izdavane",
                schema: "dbo",
                table: "lica",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IDENT",
                schema: "dbo",
                table: "lica",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IME",
                schema: "dbo",
                table: "lica",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JK",
                schema: "dbo",
                table: "lica",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KV",
                schema: "dbo",
                table: "lica",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NM",
                schema: "dbo",
                table: "lica",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "N_LK",
                schema: "dbo",
                table: "lica",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nomer",
                schema: "dbo",
                table: "lica",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PK",
                schema: "dbo",
                table: "lica",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Status_F",
                schema: "dbo",
                table: "lica",
                type: "smallint",
                maxLength: 1,
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "Status_L",
                schema: "dbo",
                table: "lica",
                type: "smallint",
                maxLength: 1,
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<string>(
                name: "UL",
                schema: "dbo",
                table: "lica",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "V7",
                schema: "dbo",
                table: "lica",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Zona",
                schema: "dbo",
                table: "lica",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "e_mail",
                schema: "dbo",
                table: "lica",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "etaj",
                schema: "dbo",
                table: "lica",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "nV8",
                schema: "dbo",
                table: "lica",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "tel",
                schema: "dbo",
                table: "lica",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "v_ident",
                schema: "dbo",
                table: "lica",
                type: "int",
                maxLength: 1,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "vh",
                schema: "dbo",
                table: "lica",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_lica_formuliar_kolektiv",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_lica_formuliar_kolektiv_IdLNavigationIdL",
                schema: "dbo",
                table: "lica_formuliar_kolektiv",
                column: "IdLNavigationIdL");

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
    }
}
