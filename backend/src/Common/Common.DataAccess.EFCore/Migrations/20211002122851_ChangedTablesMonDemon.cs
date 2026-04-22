using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class ChangedTablesMonDemon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dem_dgv_olduredi_dem_dogovor",
                schema: "dbo",
                table: "dem_dgv_olduredi");

            migrationBuilder.DropColumn(
                name: "ADRES",
                schema: "dbo",
                table: "mon_dogovor");

            migrationBuilder.DropColumn(
                name: "EIK",
                schema: "dbo",
                table: "mon_dogovor");

            migrationBuilder.DropColumn(
                name: "Ime_mger",
                schema: "dbo",
                table: "mon_dogovor");

            migrationBuilder.DropColumn(
                name: "Maneger",
                schema: "dbo",
                table: "mon_dogovor");

            migrationBuilder.DropColumn(
                name: "Name_F",
                schema: "dbo",
                table: "mon_dogovor");

            migrationBuilder.DropColumn(
                name: "Nomer_porychka",
                schema: "dbo",
                table: "mon_dogovor");

            migrationBuilder.DropColumn(
                name: "Broj_ostatyk",
                schema: "dbo",
                table: "mon_dgv_uredi");

            migrationBuilder.DropColumn(
                name: "Cena_ostatyk",
                schema: "dbo",
                table: "mon_dgv_uredi");

            migrationBuilder.DropColumn(
                name: "G_meseci",
                schema: "dbo",
                table: "mon_dgv_uredi");

            migrationBuilder.DropColumn(
                name: "Total_cena",
                schema: "dbo",
                table: "mon_dgv_uredi");

            migrationBuilder.DropColumn(
                name: "Vypros",
                schema: "dbo",
                table: "mon_dgv_uredi");

            migrationBuilder.DropColumn(
                name: "ADRES",
                schema: "dbo",
                table: "dem_dogovor");

            migrationBuilder.DropColumn(
                name: "EIK",
                schema: "dbo",
                table: "dem_dogovor");

            migrationBuilder.DropColumn(
                name: "Ime_mger",
                schema: "dbo",
                table: "dem_dogovor");

            migrationBuilder.DropColumn(
                name: "Maneger",
                schema: "dbo",
                table: "dem_dogovor");

            migrationBuilder.DropColumn(
                name: "Name_F",
                schema: "dbo",
                table: "dem_dogovor");

            migrationBuilder.DropColumn(
                name: "Porychka_Nomer",
                schema: "dbo",
                table: "dem_dogovor");

            migrationBuilder.DropColumn(
                name: "Total_cena",
                schema: "dbo",
                table: "dem_dgv_olduredi");

            migrationBuilder.DropColumn(
                name: "Vypros",
                schema: "dbo",
                table: "dem_dgv_olduredi");

            migrationBuilder.RenameColumn(
                name: "Obshta_cena(bez DDS)",
                schema: "dbo",
                table: "mon_dogovor",
                newName: "ObshtaCenaBezDDS");

            migrationBuilder.RenameColumn(
                name: "Obshta_CENA(s DDS)",
                schema: "dbo",
                table: "mon_dogovor",
                newName: "ObshtaCenaDDS");

            migrationBuilder.RenameColumn(
                name: "Nachalna data",
                schema: "dbo",
                table: "mon_dogovor",
                newName: "NachalnaData");

            migrationBuilder.RenameIndex(
                name: "IX_mon_dgv_uredi_IdFirmaNm",
                schema: "dbo",
                table: "mon_dgv_uredi",
                newName: "IX_mon_dgv_uredi_IdFirmaMn");

            migrationBuilder.RenameColumn(
                name: "NomDgSUDSO",
                schema: "dbo",
                table: "firmi",
                newName: "nkid");

            migrationBuilder.RenameColumn(
                name: "Adres",
                schema: "dbo",
                table: "firmi",
                newName: "Vh");

            migrationBuilder.RenameColumn(
                name: "Obshta_cena(bez DDS)",
                schema: "dbo",
                table: "dem_dogovor",
                newName: "ObshtaCenaBezDDS");

            migrationBuilder.RenameColumn(
                name: "Obshta_CENA(s DDS)",
                schema: "dbo",
                table: "dem_dogovor",
                newName: "ObshtaCenaDDS");

            migrationBuilder.RenameColumn(
                name: "Nachalna data",
                schema: "dbo",
                table: "dem_dogovor",
                newName: "NachalnaData");

            migrationBuilder.RenameColumn(
                name: "Data_reg_N",
                schema: "dbo",
                table: "dem_dogovor",
                newName: "DataRegN");

            migrationBuilder.AlterColumn<int>(
                name: "Obsht_Srok_grf",
                schema: "dbo",
                table: "mon_dogovor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Nom_dg_vSUDSO",
                schema: "dbo",
                table: "mon_dogovor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Faza",
                schema: "dbo",
                table: "mon_dogovor",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ObshtaCenaBezDDS",
                schema: "dbo",
                table: "mon_dogovor",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ObshtaCenaDDS",
                schema: "dbo",
                table: "mon_dogovor",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BroiPorychki",
                schema: "dbo",
                table: "mon_dogovor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ID_kn",
                schema: "dbo",
                table: "mon_dgv_uredi",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Faza",
                schema: "dbo",
                table: "mon_dgv_uredi",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Ed_cena",
                schema: "dbo",
                table: "mon_dgv_uredi",
                type: "decimal(7,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Broi",
                schema: "dbo",
                table: "mon_dgv_uredi",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ARaion",
                schema: "dbo",
                table: "firmi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ap",
                schema: "dbo",
                table: "firmi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Blok",
                schema: "dbo",
                table: "firmi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EMail",
                schema: "dbo",
                table: "firmi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Etaj",
                schema: "dbo",
                table: "firmi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Jk",
                schema: "dbo",
                table: "firmi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Kv",
                schema: "dbo",
                table: "firmi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nm",
                schema: "dbo",
                table: "firmi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nomer",
                schema: "dbo",
                table: "firmi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pk",
                schema: "dbo",
                table: "firmi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rolq",
                schema: "dbo",
                table: "firmi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tel",
                schema: "dbo",
                table: "firmi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ul",
                schema: "dbo",
                table: "firmi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Obsht_Srok_grf",
                schema: "dbo",
                table: "dem_dogovor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Nom_dg_vSUDSO",
                schema: "dbo",
                table: "dem_dogovor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Faza",
                schema: "dbo",
                table: "dem_dogovor",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ObshtaCenaBezDDS",
                schema: "dbo",
                table: "dem_dogovor",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ObshtaCenaDDS",
                schema: "dbo",
                table: "dem_dogovor",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BroiPorychki",
                schema: "dbo",
                table: "dem_dogovor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id_firma_dm",
                schema: "dbo",
                table: "dem_dgv_olduredi",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID_kn",
                schema: "dbo",
                table: "dem_dgv_olduredi",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Faza",
                schema: "dbo",
                table: "dem_dgv_olduredi",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Ed_cena",
                schema: "dbo",
                table: "dem_dgv_olduredi",
                type: "decimal(7,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Broi",
                schema: "dbo",
                table: "dem_dgv_olduredi",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_dem_dgv_olduredi_dem_dogovor",
                schema: "dbo",
                table: "dem_dgv_olduredi",
                column: "Id_firma_dm",
                principalSchema: "dbo",
                principalTable: "dem_dogovor",
                principalColumn: "Id_firma_DM",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dem_dgv_olduredi_dem_dogovor",
                schema: "dbo",
                table: "dem_dgv_olduredi");

            migrationBuilder.DropColumn(
                name: "BroiPorychki",
                schema: "dbo",
                table: "mon_dogovor");

            migrationBuilder.DropColumn(
                name: "ARaion",
                schema: "dbo",
                table: "firmi");

            migrationBuilder.DropColumn(
                name: "Ap",
                schema: "dbo",
                table: "firmi");

            migrationBuilder.DropColumn(
                name: "Blok",
                schema: "dbo",
                table: "firmi");

            migrationBuilder.DropColumn(
                name: "EMail",
                schema: "dbo",
                table: "firmi");

            migrationBuilder.DropColumn(
                name: "Etaj",
                schema: "dbo",
                table: "firmi");

            migrationBuilder.DropColumn(
                name: "Jk",
                schema: "dbo",
                table: "firmi");

            migrationBuilder.DropColumn(
                name: "Kv",
                schema: "dbo",
                table: "firmi");

            migrationBuilder.DropColumn(
                name: "Nm",
                schema: "dbo",
                table: "firmi");

            migrationBuilder.DropColumn(
                name: "Nomer",
                schema: "dbo",
                table: "firmi");

            migrationBuilder.DropColumn(
                name: "Pk",
                schema: "dbo",
                table: "firmi");

            migrationBuilder.DropColumn(
                name: "Rolq",
                schema: "dbo",
                table: "firmi");

            migrationBuilder.DropColumn(
                name: "Tel",
                schema: "dbo",
                table: "firmi");

            migrationBuilder.DropColumn(
                name: "Ul",
                schema: "dbo",
                table: "firmi");

            migrationBuilder.DropColumn(
                name: "BroiPorychki",
                schema: "dbo",
                table: "dem_dogovor");

            migrationBuilder.RenameColumn(
                name: "ObshtaCenaDDS",
                schema: "dbo",
                table: "mon_dogovor",
                newName: "Obshta_CENA(s DDS)");

            migrationBuilder.RenameColumn(
                name: "ObshtaCenaBezDDS",
                schema: "dbo",
                table: "mon_dogovor",
                newName: "Obshta_cena(bez DDS)");

            migrationBuilder.RenameColumn(
                name: "NachalnaData",
                schema: "dbo",
                table: "mon_dogovor",
                newName: "Nachalna data");

            migrationBuilder.RenameColumn(
                name: "nkid",
                schema: "dbo",
                table: "firmi",
                newName: "NomDgSUDSO");

            migrationBuilder.RenameColumn(
                name: "Vh",
                schema: "dbo",
                table: "firmi",
                newName: "Adres");

            migrationBuilder.RenameColumn(
                name: "ObshtaCenaDDS",
                schema: "dbo",
                table: "dem_dogovor",
                newName: "Obshta_CENA(s DDS)");

            migrationBuilder.RenameColumn(
                name: "ObshtaCenaBezDDS",
                schema: "dbo",
                table: "dem_dogovor",
                newName: "Obshta_cena(bez DDS)");

            migrationBuilder.RenameColumn(
                name: "NachalnaData",
                schema: "dbo",
                table: "dem_dogovor",
                newName: "Nachalna data");

            migrationBuilder.RenameColumn(
                name: "DataRegN",
                schema: "dbo",
                table: "dem_dogovor",
                newName: "Data_reg_N");

            migrationBuilder.AlterColumn<int>(
                name: "Obsht_Srok_grf",
                schema: "dbo",
                table: "mon_dogovor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Nom_dg_vSUDSO",
                schema: "dbo",
                table: "mon_dogovor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<short>(
                name: "Faza",
                schema: "dbo",
                table: "mon_dogovor",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<decimal>(
                name: "Obshta_CENA(s DDS)",
                schema: "dbo",
                table: "mon_dogovor",
                type: "decimal(9,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Obshta_cena(bez DDS)",
                schema: "dbo",
                table: "mon_dogovor",
                type: "decimal(9,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AddColumn<string>(
                name: "ADRES",
                schema: "dbo",
                table: "mon_dogovor",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EIK",
                schema: "dbo",
                table: "mon_dogovor",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ime_mger",
                schema: "dbo",
                table: "mon_dogovor",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Maneger",
                schema: "dbo",
                table: "mon_dogovor",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_F",
                schema: "dbo",
                table: "mon_dogovor",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Nomer_porychka",
                schema: "dbo",
                table: "mon_dogovor",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID_kn",
                schema: "dbo",
                table: "mon_dgv_uredi",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<short>(
                name: "Faza",
                schema: "dbo",
                table: "mon_dgv_uredi",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<decimal>(
                name: "Ed_cena",
                schema: "dbo",
                table: "mon_dgv_uredi",
                type: "decimal(7,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Broi",
                schema: "dbo",
                table: "mon_dgv_uredi",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Broj_ostatyk",
                schema: "dbo",
                table: "mon_dgv_uredi",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Cena_ostatyk",
                schema: "dbo",
                table: "mon_dgv_uredi",
                type: "decimal(9,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "G_meseci",
                schema: "dbo",
                table: "mon_dgv_uredi",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Total_cena",
                schema: "dbo",
                table: "mon_dgv_uredi",
                type: "decimal(9,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vypros",
                schema: "dbo",
                table: "mon_dgv_uredi",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Obsht_Srok_grf",
                schema: "dbo",
                table: "dem_dogovor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Nom_dg_vSUDSO",
                schema: "dbo",
                table: "dem_dogovor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<short>(
                name: "Faza",
                schema: "dbo",
                table: "dem_dogovor",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<decimal>(
                name: "Obshta_CENA(s DDS)",
                schema: "dbo",
                table: "dem_dogovor",
                type: "decimal(9,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Obshta_cena(bez DDS)",
                schema: "dbo",
                table: "dem_dogovor",
                type: "decimal(9,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AddColumn<string>(
                name: "ADRES",
                schema: "dbo",
                table: "dem_dogovor",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EIK",
                schema: "dbo",
                table: "dem_dogovor",
                type: "varchar(14)",
                unicode: false,
                maxLength: 14,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ime_mger",
                schema: "dbo",
                table: "dem_dogovor",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Maneger",
                schema: "dbo",
                table: "dem_dogovor",
                type: "varchar(60)",
                unicode: false,
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_F",
                schema: "dbo",
                table: "dem_dogovor",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Porychka_Nomer",
                schema: "dbo",
                table: "dem_dogovor",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id_firma_dm",
                schema: "dbo",
                table: "dem_dgv_olduredi",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ID_kn",
                schema: "dbo",
                table: "dem_dgv_olduredi",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<short>(
                name: "Faza",
                schema: "dbo",
                table: "dem_dgv_olduredi",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<decimal>(
                name: "Ed_cena",
                schema: "dbo",
                table: "dem_dgv_olduredi",
                type: "decimal(7,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Broi",
                schema: "dbo",
                table: "dem_dgv_olduredi",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "Total_cena",
                schema: "dbo",
                table: "dem_dgv_olduredi",
                type: "decimal(9,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vypros",
                schema: "dbo",
                table: "dem_dgv_olduredi",
                type: "varchar(6)",
                unicode: false,
                maxLength: 6,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_dem_dgv_olduredi_dem_dogovor",
                schema: "dbo",
                table: "dem_dgv_olduredi",
                column: "Id_firma_dm",
                principalSchema: "dbo",
                principalTable: "dem_dogovor",
                principalColumn: "Id_firma_DM",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
