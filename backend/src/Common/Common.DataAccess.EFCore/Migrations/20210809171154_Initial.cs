using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "dem_dogovor",
                schema: "dbo",
                columns: table => new
                {
                    Id_firma_DM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100, 1"),
                    Faza = table.Column<short>(type: "smallint", nullable: true),
                    EIK = table.Column<string>(type: "varchar(14)", unicode: false, maxLength: 14, nullable: true),
                    Name_F = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ADRES = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Reg_Index = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Data_reg_N = table.Column<DateTime>(type: "date", nullable: true),
                    Nom_dg_vSUDSO = table.Column<int>(type: "int", nullable: true),
                    Maneger = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    Ime_mger = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Nachalnadata = table.Column<DateTime>(name: "Nachalna data", type: "date", nullable: true),
                    Obsht_Srok_grf = table.Column<int>(type: "int", nullable: true),
                    Obshta_cenabezDDS = table.Column<decimal>(name: "Obshta_cena(bez DDS)", type: "decimal(9,2)", nullable: true),
                    Obshta_CENAsDDS = table.Column<decimal>(name: "Obshta_CENA(s DDS)", type: "decimal(9,2)", nullable: true),
                    Porychka_Nomer = table.Column<int>(type: "int", nullable: true),
                    STATUS_DM = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Status = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    koga = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    user = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dgv_za_demontaj_Id_firma_DM", x => x.Id_firma_DM);
                });

            migrationBuilder.CreateTable(
                name: "lica",
                schema: "dbo",
                columns: table => new
                {
                    ID_L = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Faza = table.Column<short>(type: "smallint", nullable: false),
                    U_nom = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Predstavitel = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    ID_Predstavitel = table.Column<int>(type: "int", nullable: true),
                    v_lice = table.Column<string>(type: "nchar(1)", fixedLength: true, maxLength: 1, nullable: true),
                    v_ident = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IDENT = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IME = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PIME = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fime = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    GIME = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    N_LK = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Data_izdavane = table.Column<DateTime>(type: "date", nullable: true),
                    A_Raion = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    NM = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    KV = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    JK = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    UL = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Nomer = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Blok = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    vh = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    etaj = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    AP = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    e_mail = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    tel = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    PK = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    V8 = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Status_L = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    user = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    koga = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Status_F = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Tochki1 = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    Tochki2 = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    Tochki3 = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    Tochki4 = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    Tochki5 = table.Column<decimal>(type: "numeric(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lica_ID_L", x => x.ID_L);
                });

            migrationBuilder.CreateTable(
                name: "lica_dogovor_olduredi",
                schema: "dbo",
                columns: table => new
                {
                    ID_OLDUREDI_DGL = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_L = table.Column<int>(type: "int", nullable: true),
                    Vypros = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: true),
                    Id_KT = table.Column<int>(type: "int", nullable: true),
                    Broi = table.Column<int>(type: "int", nullable: true),
                    Status_U = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Status = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    user = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    Koga = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_olduredi_dg_l_ID_OLDUREDI_DGL", x => x.ID_OLDUREDI_DGL);
                });

            migrationBuilder.CreateTable(
                name: "mon_dogovor",
                schema: "dbo",
                columns: table => new
                {
                    ID_FIRMA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Faza = table.Column<short>(type: "smallint", nullable: true),
                    EIK = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    Name_F = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ADRES = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Reg_Index = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Data_reg_N = table.Column<DateTime>(type: "date", nullable: true),
                    Nom_dg_vSUDSO = table.Column<int>(type: "int", nullable: true),
                    Maneger = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Ime_mger = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Nachalnadata = table.Column<DateTime>(name: "Nachalna data", type: "date", nullable: true),
                    Obsht_Srok_grf = table.Column<int>(type: "int", nullable: true),
                    Obshta_cenabezDDS = table.Column<decimal>(name: "Obshta_cena(bez DDS)", type: "decimal(9,2)", nullable: true),
                    Obshta_CENAsDDS = table.Column<decimal>(name: "Obshta_CENA(s DDS)", type: "decimal(9,2)", nullable: true),
                    Nomer_porychka = table.Column<int>(type: "int", nullable: true),
                    STATUS_DM = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Status = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    koga = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    user = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dgv_dostavchici_ID_FIRMA", x => x.ID_FIRMA);
                });

            migrationBuilder.CreateTable(
                name: "n_jk",
                schema: "dbo",
                columns: table => new
                {
                    nkod = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    nime = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    kod_nmn = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_n_jk_nkod", x => x.nkod);
                });

            migrationBuilder.CreateTable(
                name: "n_kmetstva",
                schema: "dbo",
                columns: table => new
                {
                    nkod = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    nime = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_n_kmetstva_nkod", x => x.nkod);
                });

            migrationBuilder.CreateTable(
                name: "n_kvartali",
                schema: "dbo",
                columns: table => new
                {
                    nkod = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    nime = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    kod_nmn = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_n_kvartali_nkod", x => x.nkod);
                });

            migrationBuilder.CreateTable(
                name: "n_nmn_obshti",
                schema: "dbo",
                columns: table => new
                {
                    id_kn = table.Column<int>(type: "int", nullable: false)
                                 .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Faza = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    vypros = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    kod_nmn = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Kod_pozicia = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Text = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_n_nmn_obshti_id_kn", x => x.id_kn);
                });

            migrationBuilder.CreateTable(
                name: "n_ns_mesta",
                schema: "dbo",
                columns: table => new
                {
                    nkod = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    nime = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    Kmetstvo = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    kod_nmn = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_n_ns_mesta_nkod", x => x.nkod);
                });

            migrationBuilder.CreateTable(
                name: "n_raioni",
                schema: "dbo",
                columns: table => new
                {
                    NKOD = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    NIME = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    Z_Code = table.Column<int>(type: "int", nullable: true),
                    kod_nmn = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "n_shablon_f",
                schema: "dbo",
                columns: table => new
                {
                    ID_N = table.Column<int>(type: "int", nullable: false),
                    Faza = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Vypros = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    TBL_vBD = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Poleta = table.Column<int>(type: "int", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Status = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shablon_f_ID_N", x => x.ID_N);
                });

            migrationBuilder.CreateTable(
                name: "n_spisyk_nmn",
                schema: "dbo",
                columns: table => new
                {
                    kod_nmn = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Status = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Faza = table.Column<short>(type: "smallint", nullable: true),
                    Vypros = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Tablica_vBazata = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Ime = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Komentar = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_n_spisyk_nmn_kod_nmn", x => x.kod_nmn);
                });

            migrationBuilder.CreateTable(
                name: "n_statusi",
                schema: "dbo",
                columns: table => new
                {
                    Id_St = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Faza = table.Column<short>(type: "smallint", nullable: true),
                    Table_name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Status_name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Status_Code = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Text = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Rolia = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Status = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Komentar = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    kod_nmn = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_n_statusi_Id_St", x => x.Id_St);
                });

            migrationBuilder.CreateTable(
                name: "n_ulicii",
                schema: "dbo",
                columns: table => new
                {
                    nkod = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    wnasm_nkod = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    wnuli_nkod = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    nime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    kod_nmn = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_n_ulicii_nkod", x => x.nkod);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lat = table.Column<double>(type: "float", nullable: true),
                    Lng = table.Column<double>(type: "float", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dem_dgv_olduredi",
                schema: "dbo",
                columns: table => new
                {
                    ID_SP_DM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Faza = table.Column<short>(type: "smallint", nullable: true),
                    Id_firma_dm = table.Column<int>(type: "int", nullable: true),
                    ID_kn = table.Column<int>(type: "int", nullable: true),
                    Vypros = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: true),
                    Ed_cena = table.Column<decimal>(type: "decimal(7,2)", nullable: true),
                    Broi = table.Column<int>(type: "int", nullable: true),
                    Total_cena = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    Status_DS = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Status = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    User = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    Koga = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_olduredi_dgv_dm_ID_SP_DM", x => x.ID_SP_DM);
                    table.ForeignKey(
                        name: "FK_dem_dgv_olduredi_dem_dogovor",
                        column: x => x.Id_firma_dm,
                        principalSchema: "dbo",
                        principalTable: "dem_dogovor",
                        principalColumn: "Id_firma_DM",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dem_porychka",
                schema: "dbo",
                columns: table => new
                {
                    IDDM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Faza = table.Column<short>(type: "smallint", nullable: true),
                    Nomer_poreden_DM = table.Column<int>(type: "int", nullable: true),
                    OT_Data = table.Column<DateTime>(type: "date", nullable: true),
                    U_nom = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Id_firma_dm = table.Column<int>(type: "int", nullable: true),
                    Id_SP_NET = table.Column<int>(type: "int", nullable: true),
                    vypros = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Id_kn = table.Column<int>(type: "int", nullable: true),
                    Broi_U = table.Column<int>(type: "int", nullable: true),
                    id_L = table.Column<int>(type: "int", nullable: true),
                    IDENT = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IME = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    A_Raion = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Start_data = table.Column<DateTime>(type: "date", nullable: true),
                    Status_dp = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    user = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    koga = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    DO_data = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oldporychka_dm_IDDM", x => x.IDDM);
                    table.ForeignKey(
                        name: "FK_dem_oldporychka_dem_dogovor",
                        column: x => x.Id_firma_dm,
                        principalSchema: "dbo",
                        principalTable: "dem_dogovor",
                        principalColumn: "Id_firma_DM",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dem_rajoni",
                schema: "dbo",
                columns: table => new
                {
                    ID_rec = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FAZA = table.Column<short>(type: "smallint", nullable: true),
                    ID_FIRMA_DM = table.Column<int>(type: "int", nullable: true),
                    NKOD = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Status = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_demontaj_rajoni_ID_rec", x => x.ID_rec);
                    table.ForeignKey(
                        name: "FK_dem_rajoni_dem_dogovor",
                        column: x => x.ID_FIRMA_DM,
                        principalSchema: "dbo",
                        principalTable: "dem_dogovor",
                        principalColumn: "Id_firma_DM",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "lica_dogovor",
                schema: "dbo",
                columns: table => new
                {
                    Id_dog_L = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_L = table.Column<int>(type: "int", nullable: true),
                    Faza = table.Column<short>(type: "smallint", nullable: true),
                    U_Nom = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Reg_N = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Data_reg_N = table.Column<DateTime>(type: "date", nullable: true),
                    Status_DL = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Status = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    user = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    koga = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dogovor_lica_Id_dog_L", x => x.Id_dog_L);
                    table.ForeignKey(
                        name: "FK_lica_dogovor_lica",
                        column: x => x.Id_L,
                        principalSchema: "dbo",
                        principalTable: "lica",
                        principalColumn: "ID_L",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "lica_dokumenti",
                schema: "dbo",
                columns: table => new
                {
                    Id_Dok = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_L = table.Column<int>(type: "int", nullable: true),
                    Faza = table.Column<short>(type: "smallint", nullable: true),
                    U_NOM = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Vypros = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    ID_KN = table.Column<int>(type: "int", nullable: true),
                    Kod_Dok = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Text_Dok = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Status_DD = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Status = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    User = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Koga = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dokumenti_Id_Dok", x => x.Id_Dok);
                    table.ForeignKey(
                        name: "FK_lica_dokumenti_lica",
                        column: x => x.Id_L,
                        principalSchema: "dbo",
                        principalTable: "lica",
                        principalColumn: "ID_L",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "lica_formuliar",
                schema: "dbo",
                columns: table => new
                {
                    ID_Formuliar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_L = table.Column<int>(type: "int", nullable: true),
                    U_nom = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    faza = table.Column<short>(type: "smallint", nullable: false),
                    Reg_date = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Acster = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Acst_date = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Status = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Status_F = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_formuliar_ID_Formuliar", x => x.ID_Formuliar);
                    table.ForeignKey(
                        name: "FK_lica_formuliar_lica",
                        column: x => x.Id_L,
                        principalSchema: "dbo",
                        principalTable: "lica",
                        principalColumn: "ID_L",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mon_dgv_podizpylniteli",
                schema: "dbo",
                columns: table => new
                {
                    ID_PodIZP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_FIRMA = table.Column<int>(type: "int", nullable: false),
                    EIK = table.Column<string>(type: "varchar(14)", unicode: false, maxLength: 14, nullable: true),
                    Name_F = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ADRES = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Maneger = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    Ime_mger = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    STATUS_DM = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Status = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    user = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    koga = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_mon_dgv_podizpylniteli_mon_dogovor",
                        column: x => x.ID_FIRMA,
                        principalSchema: "dbo",
                        principalTable: "mon_dogovor",
                        principalColumn: "ID_FIRMA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mon_dgv_uredi",
                schema: "dbo",
                columns: table => new
                {
                    Id_Sp_dost = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Faza = table.Column<short>(type: "smallint", nullable: true),
                    Id_firma = table.Column<int>(type: "int", nullable: true),
                    ID_kn = table.Column<int>(type: "int", nullable: true),
                    Vypros = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Ed_cena = table.Column<decimal>(type: "decimal(7,2)", nullable: true),
                    Broi = table.Column<int>(type: "int", nullable: true),
                    Total_cena = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    G_meseci = table.Column<int>(type: "int", nullable: true),
                    Broj_ostatyk = table.Column<int>(type: "int", nullable: true),
                    Status_DS = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Status = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    User = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Koga = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Cena_ostatyk = table.Column<decimal>(type: "decimal(9,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uredi_dgv_dost_Id_Sp_dost", x => x.Id_Sp_dost);
                    table.ForeignKey(
                        name: "FK_mon_dgv_uredi_mon_dogovor",
                        column: x => x.Id_firma,
                        principalSchema: "dbo",
                        principalTable: "mon_dogovor",
                        principalColumn: "ID_FIRMA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mon_porychka",
                schema: "dbo",
                columns: table => new
                {
                    IDM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Faza = table.Column<short>(type: "smallint", nullable: true),
                    Nomer_poreden_M = table.Column<int>(type: "int", nullable: true),
                    OT_Data = table.Column<DateTime>(type: "date", nullable: true),
                    U_nom = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Id_firma = table.Column<int>(type: "int", nullable: true),
                    Id_SP_NET = table.Column<int>(type: "int", nullable: true),
                    vypros = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Id_kn = table.Column<int>(type: "int", nullable: true),
                    Broi_U = table.Column<int>(type: "int", nullable: true),
                    id_L = table.Column<int>(type: "int", nullable: true),
                    IDENT = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IME = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    A_Raion = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Start_date = table.Column<DateTime>(type: "date", nullable: true),
                    DO_data = table.Column<DateTime>(type: "date", nullable: true),
                    Status_dp = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    user = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    koga = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_porychka_m_IDM", x => x.IDM);
                    table.ForeignKey(
                        name: "FK_mon_porychka_lica",
                        column: x => x.id_L,
                        principalSchema: "dbo",
                        principalTable: "lica",
                        principalColumn: "ID_L",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mon_porychka_mon_dogovor",
                        column: x => x.Id_firma,
                        principalSchema: "dbo",
                        principalTable: "mon_dogovor",
                        principalColumn: "ID_FIRMA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mon_rajoni",
                schema: "dbo",
                columns: table => new
                {
                    ID_rec = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FAZA = table.Column<short>(type: "smallint", nullable: true),
                    Id_firma = table.Column<int>(type: "int", nullable: true),
                    NKOD = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Status = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dostavchik_rajoni_ID_rec", x => x.ID_rec);
                    table.ForeignKey(
                        name: "FK_mon_rajoni_mon_dogovor",
                        column: x => x.Id_firma,
                        principalSchema: "dbo",
                        principalTable: "mon_dogovor",
                        principalColumn: "ID_FIRMA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ThemeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Settings_Users_Id",
                        column: x => x.Id,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPhotos",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPhotos_Users_Id",
                        column: x => x.Id,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lica_dogovor_uredi",
                schema: "dbo",
                columns: table => new
                {
                    Id_Ured_DG = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_DOG_L = table.Column<int>(type: "int", nullable: true),
                    Id_L = table.Column<int>(type: "int", nullable: true),
                    Vypros = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: true),
                    Id_KT = table.Column<int>(type: "int", nullable: true),
                    Broi = table.Column<int>(type: "int", nullable: true),
                    Status_U = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Status = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    user = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    Koga = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uredi_dg_l_Id_Ured_DG", x => x.Id_Ured_DG);
                    table.ForeignKey(
                        name: "FK_lica_dogovor_uredi_lica_dogovor",
                        column: x => x.ID_DOG_L,
                        principalSchema: "dbo",
                        principalTable: "lica_dogovor",
                        principalColumn: "Id_dog_L",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "lica_formuliar_danni",
                schema: "dbo",
                columns: table => new
                {
                    Id_Vyprosnik = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Formuliar = table.Column<int>(type: "int", nullable: true),
                    u_nom = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    faza = table.Column<short>(type: "smallint", nullable: true),
                    Vypros = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Ukazatel = table.Column<short>(type: "smallint", nullable: true),
                    Chislo = table.Column<int>(type: "int", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    DA_NE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    N_NMN_FK = table.Column<int>(type: "int", nullable: true),
                    kod_n = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Text_N = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_f_vypr_danni_Id_Vyprosnik", x => x.Id_Vyprosnik);
                    table.ForeignKey(
                        name: "FK_lica_formuliar_danni_lica_formuliar",
                        column: x => x.ID_Formuliar,
                        principalSchema: "dbo",
                        principalTable: "lica_formuliar",
                        principalColumn: "ID_Formuliar",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "lica_formuliar_uredi",
                schema: "dbo",
                columns: table => new
                {
                    Id_ured_F = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_formuliar = table.Column<int>(type: "int", nullable: true),
                    Id_L = table.Column<int>(type: "int", nullable: true),
                    Vypros = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Id_KT = table.Column<int>(type: "int", nullable: true),
                    Broi = table.Column<int>(type: "int", nullable: true),
                    Status_U = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Status = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    user = table.Column<int>(type: "int", nullable: true),
                    Koga = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uredi_f_Id_ured_F", x => x.Id_ured_F);
                    table.ForeignKey(
                        name: "FK_lica_formuliar_uredi_lica_formuliar",
                        column: x => x.Id_formuliar,
                        principalSchema: "dbo",
                        principalTable: "lica_formuliar",
                        principalColumn: "ID_Formuliar",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mon_grafik",
                schema: "dbo",
                columns: table => new
                {
                    Id_GRAFIK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDM = table.Column<int>(type: "int", nullable: true),
                    Faza = table.Column<short>(type: "smallint", nullable: true),
                    Nomer_poreden_M = table.Column<int>(type: "int", nullable: false),
                    OT_Data = table.Column<DateTime>(type: "date", nullable: true),
                    DO_data = table.Column<DateTime>(type: "date", nullable: true),
                    U_nom = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Id_firma = table.Column<int>(type: "int", nullable: true),
                    Id_SP_NET = table.Column<int>(type: "int", nullable: true),
                    vypros = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Id_kn = table.Column<int>(type: "int", nullable: true),
                    Broi_U = table.Column<int>(type: "int", nullable: true),
                    id_L = table.Column<int>(type: "int", nullable: true),
                    IDENT = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IME = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PIME = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fime = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    GIME = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    A_Raion = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    NM = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    KV = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    JK = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    UL = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Nomer = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Blok = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    vh = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    etaj = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    AP = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    tel = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Status_dp = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    user = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    koga = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grafik_m_Id_GRAFIK", x => x.Id_GRAFIK);
                    table.ForeignKey(
                        name: "FK_mon_grafik_mon_porychka",
                        column: x => x.IDM,
                        principalSchema: "dbo",
                        principalTable: "mon_porychka",
                        principalColumn: "IDM",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mon_otchet",
                schema: "dbo",
                columns: table => new
                {
                    ID_OTCHET = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_GRAFIK = table.Column<int>(type: "int", nullable: true),
                    IDM = table.Column<int>(type: "int", nullable: false),
                    Faza = table.Column<short>(type: "smallint", nullable: true),
                    Nomer_poreden_M = table.Column<int>(type: "int", nullable: false),
                    OT_Data = table.Column<DateTime>(type: "date", nullable: true),
                    DO_data = table.Column<DateTime>(type: "date", nullable: true),
                    NA_DATA = table.Column<DateTime>(type: "date", nullable: true),
                    Broi_U = table.Column<int>(type: "int", nullable: true),
                    Status_dp = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    user = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    koga = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    data_montazj = table.Column<DateTime>(type: "datetime", nullable: true),
                    fabr_nomer = table.Column<byte[]>(type: "varbinary(50)", maxLength: 50, nullable: true),
                    gar_nomer = table.Column<byte[]>(type: "varbinary(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_otchet_m_ID_OTCHET", x => x.ID_OTCHET);
                    table.ForeignKey(
                        name: "FK_mon_otchet_mon_porychka",
                        column: x => x.IDM,
                        principalSchema: "dbo",
                        principalTable: "mon_porychka",
                        principalColumn: "IDM",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dem_dgv_olduredi_Id_firma_dm",
                schema: "dbo",
                table: "dem_dgv_olduredi",
                column: "Id_firma_dm");

            migrationBuilder.CreateIndex(
                name: "IX_dem_porychka_Id_firma_dm",
                schema: "dbo",
                table: "dem_porychka",
                column: "Id_firma_dm");

            migrationBuilder.CreateIndex(
                name: "IX_dem_rajoni_ID_FIRMA_DM",
                schema: "dbo",
                table: "dem_rajoni",
                column: "ID_FIRMA_DM");

            migrationBuilder.CreateIndex(
                name: "IX_lica_dogovor_Id_L",
                schema: "dbo",
                table: "lica_dogovor",
                column: "Id_L");

            migrationBuilder.CreateIndex(
                name: "IX_lica_dogovor_uredi_ID_DOG_L",
                schema: "dbo",
                table: "lica_dogovor_uredi",
                column: "ID_DOG_L");

            migrationBuilder.CreateIndex(
                name: "IX_lica_dokumenti_Id_L",
                schema: "dbo",
                table: "lica_dokumenti",
                column: "Id_L");

            migrationBuilder.CreateIndex(
                name: "IX_lica_formuliar_Id_L",
                schema: "dbo",
                table: "lica_formuliar",
                column: "Id_L");

            migrationBuilder.CreateIndex(
                name: "IX_lica_formuliar_danni_ID_Formuliar",
                schema: "dbo",
                table: "lica_formuliar_danni",
                column: "ID_Formuliar");

            migrationBuilder.CreateIndex(
                name: "IX_lica_formuliar_uredi_Id_formuliar",
                schema: "dbo",
                table: "lica_formuliar_uredi",
                column: "Id_formuliar");

            migrationBuilder.CreateIndex(
                name: "IX_mon_dgv_podizpylniteli_ID_FIRMA",
                schema: "dbo",
                table: "mon_dgv_podizpylniteli",
                column: "ID_FIRMA");

            migrationBuilder.CreateIndex(
                name: "IX_mon_dgv_uredi_Id_firma",
                schema: "dbo",
                table: "mon_dgv_uredi",
                column: "Id_firma");

            migrationBuilder.CreateIndex(
                name: "IX_mon_grafik_IDM",
                schema: "dbo",
                table: "mon_grafik",
                column: "IDM");

            migrationBuilder.CreateIndex(
                name: "IX_mon_otchet_IDM",
                schema: "dbo",
                table: "mon_otchet",
                column: "IDM");

            migrationBuilder.CreateIndex(
                name: "IX_mon_porychka_Id_firma",
                schema: "dbo",
                table: "mon_porychka",
                column: "Id_firma");

            migrationBuilder.CreateIndex(
                name: "IX_mon_porychka_id_L",
                schema: "dbo",
                table: "mon_porychka",
                column: "id_L");

            migrationBuilder.CreateIndex(
                name: "IX_mon_rajoni_Id_firma",
                schema: "dbo",
                table: "mon_rajoni",
                column: "Id_firma");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "dbo",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "dbo",
                table: "UserRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dem_dgv_olduredi",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "dem_porychka",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "dem_rajoni",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "lica_dogovor_olduredi",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "lica_dogovor_uredi",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "lica_dokumenti",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "lica_formuliar_danni",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "lica_formuliar_uredi",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mon_dgv_podizpylniteli",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mon_dgv_uredi",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mon_grafik",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mon_otchet",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mon_rajoni",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "n_jk",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "n_kmetstva",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "n_kvartali",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "n_nmn_obshti",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "n_ns_mesta",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "n_raioni",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "n_shablon_f",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "n_spisyk_nmn",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "n_statusi",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "n_ulicii",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Settings",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserPhotos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "dem_dogovor",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "lica_dogovor",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "lica_formuliar",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mon_porychka",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "lica",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mon_dogovor",
                schema: "dbo");
        }
    }
}
