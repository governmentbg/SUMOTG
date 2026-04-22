IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[dem_dogovor] (
        [Id_firma_DM] int NOT NULL IDENTITY,
        [Faza] smallint NULL,
        [EIK] varchar(14) NULL,
        [Name_F] varchar(100) NULL,
        [ADRES] varchar(100) NULL,
        [Reg_Index] varchar(15) NULL,
        [Data_reg_N] date NULL,
        [Nom_dg_vSUDSO] int NULL,
        [Maneger] varchar(60) NULL,
        [Ime_mger] varchar(50) NULL,
        [Nachalna data] date NULL,
        [Obsht_Srok_grf] int NULL,
        [Obshta_cena(bez DDS)] decimal(9,2) NULL,
        [Obshta_CENA(s DDS)] decimal(9,2) NULL,
        [Porychka_Nomer] int NULL,
        [STATUS_DM] char(1) NULL,
        [Status] char(1) NULL,
        [koga] datetime2(0) NULL,
        [user] varchar(128) NULL,
        CONSTRAINT [PK_dgv_za_demontaj_Id_firma_DM] PRIMARY KEY ([Id_firma_DM])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[lica] (
        [ID_L] int NOT NULL IDENTITY,
        [Faza] smallint NOT NULL,
        [U_nom] nvarchar(15) NULL,
        [Predstavitel] nvarchar(1) NULL,
        [ID_Predstavitel] int NULL,
        [v_lice] nchar(1) NULL,
        [v_ident] nvarchar(1) NULL,
        [IDENT] nvarchar(10) NULL,
        [IME] nvarchar(20) NULL,
        [PIME] nvarchar(20) NULL,
        [Fime] nvarchar(25) NULL,
        [GIME] nvarchar(60) NULL,
        [N_LK] nvarchar(15) NULL,
        [Data_izdavane] date NULL,
        [A_Raion] nvarchar(2) NULL,
        [NM] nvarchar(5) NULL,
        [KV] nvarchar(25) NULL,
        [JK] nvarchar(25) NULL,
        [UL] nvarchar(30) NULL,
        [Nomer] nvarchar(4) NULL,
        [Blok] nvarchar(4) NULL,
        [vh] nvarchar(2) NULL,
        [etaj] nvarchar(2) NULL,
        [AP] nvarchar(3) NULL,
        [e_mail] nvarchar(30) NULL,
        [tel] nvarchar(15) NULL,
        [PK] nvarchar(5) NULL,
        [V8] char(1) NULL,
        [Status_L] nvarchar(1) NULL,
        [Status] nvarchar(1) NULL,
        [user] nvarchar(30) NULL,
        [koga] datetime2(0) NULL,
        [Status_F] nvarchar(1) NULL,
        [Tochki1] numeric(10,2) NULL,
        [Tochki2] numeric(10,2) NULL,
        [Tochki3] numeric(10,2) NULL,
        [Tochki4] numeric(10,2) NULL,
        [Tochki5] numeric(10,2) NULL,
        CONSTRAINT [PK_lica_ID_L] PRIMARY KEY ([ID_L])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[lica_dogovor_olduredi] (
        [ID_OLDUREDI_DGL] int NOT NULL IDENTITY,
        [Id_L] int NULL,
        [Vypros] varchar(6) NULL,
        [Id_KT] int NULL,
        [Broi] int NULL,
        [Status_U] char(1) NULL,
        [Status] char(1) NULL,
        [user] varchar(128) NULL,
        [Koga] datetime2(0) NULL,
        CONSTRAINT [PK_olduredi_dg_l_ID_OLDUREDI_DGL] PRIMARY KEY ([ID_OLDUREDI_DGL])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[mon_dogovor] (
        [ID_FIRMA] int NOT NULL IDENTITY,
        [Faza] smallint NULL,
        [EIK] nvarchar(14) NULL,
        [Name_F] nvarchar(100) NULL,
        [ADRES] nvarchar(100) NULL,
        [Reg_Index] nvarchar(15) NULL,
        [Data_reg_N] date NULL,
        [Nom_dg_vSUDSO] int NULL,
        [Maneger] nvarchar(60) NULL,
        [Ime_mger] nvarchar(50) NULL,
        [Nachalna data] date NULL,
        [Obsht_Srok_grf] int NULL,
        [Obshta_cena(bez DDS)] decimal(9,2) NULL,
        [Obshta_CENA(s DDS)] decimal(9,2) NULL,
        [Nomer_porychka] int NULL,
        [STATUS_DM] char(1) NULL,
        [Status] char(1) NULL,
        [koga] datetime2(0) NULL,
        [user] nvarchar(128) NULL,
        CONSTRAINT [PK_dgv_dostavchici_ID_FIRMA] PRIMARY KEY ([ID_FIRMA])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[n_jk] (
        [nkod] nvarchar(5) NOT NULL,
        [nime] nvarchar(45) NULL,
        [kod_nmn] varchar(2) NULL,
        CONSTRAINT [PK_n_jk_nkod] PRIMARY KEY ([nkod])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[n_kmetstva] (
        [nkod] nvarchar(10) NOT NULL,
        [nime] nvarchar(45) NULL,
        CONSTRAINT [PK_n_kmetstva_nkod] PRIMARY KEY ([nkod])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[n_kvartali] (
        [nkod] nvarchar(5) NOT NULL,
        [nime] nvarchar(45) NULL,
        [kod_nmn] varchar(2) NULL,
        CONSTRAINT [PK_n_kvartali_nkod] PRIMARY KEY ([nkod])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[n_nmn_obshti] (
        [id_kn] int NOT NULL,
        [status] char(1) NULL,
        [Faza] char(1) NULL,
        [vypros] nvarchar(6) NULL,
        [kod_nmn] nvarchar(2) NULL,
        [Kod_pozicia] nvarchar(4) NULL,
        [Text] nvarchar(70) NULL,
        CONSTRAINT [PK_n_nmn_obshti_id_kn] PRIMARY KEY ([id_kn])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[n_ns_mesta] (
        [nkod] nvarchar(5) NOT NULL,
        [nime] nvarchar(45) NULL,
        [Kmetstvo] nvarchar(8) NULL,
        [kod_nmn] varchar(2) NULL,
        CONSTRAINT [PK_n_ns_mesta_nkod] PRIMARY KEY ([nkod])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[n_raioni] (
        [NKOD] nvarchar(2) NOT NULL,
        [NIME] nvarchar(45) NULL,
        [Z_Code] int NULL,
        [kod_nmn] varchar(2) NULL
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[n_shablon_f] (
        [ID_N] int NOT NULL,
        [Faza] char(1) NULL,
        [Vypros] nvarchar(5) NULL,
        [TBL_vBD] nvarchar(2) NULL,
        [Poleta] int NULL,
        [Text] nvarchar(60) NULL,
        [Status] char(1) NULL,
        CONSTRAINT [PK_shablon_f_ID_N] PRIMARY KEY ([ID_N])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[n_spisyk_nmn] (
        [kod_nmn] nvarchar(2) NOT NULL,
        [Status] char(1) NULL,
        [Faza] smallint NULL,
        [Vypros] nvarchar(6) NULL,
        [Tablica_vBazata] nvarchar(30) NULL,
        [Ime] nvarchar(40) NULL,
        [Komentar] nvarchar(40) NULL,
        CONSTRAINT [PK_n_spisyk_nmn_kod_nmn] PRIMARY KEY ([kod_nmn])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[n_statusi] (
        [Id_St] int NOT NULL IDENTITY,
        [Faza] smallint NULL,
        [Table_name] nvarchar(40) NULL,
        [Status_name] nvarchar(10) NULL,
        [Status_Code] nvarchar(2) NULL,
        [Text] nvarchar(30) NULL,
        [Rolia] char(1) NULL,
        [Status] char(1) NULL,
        [Komentar] nvarchar(60) NULL,
        [kod_nmn] nvarchar(2) NULL,
        CONSTRAINT [PK_n_statusi_Id_St] PRIMARY KEY ([Id_St])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[n_ulicii] (
        [nkod] nvarchar(5) NOT NULL,
        [wnasm_nkod] nvarchar(5) NULL,
        [wnuli_nkod] nvarchar(5) NULL,
        [nime] nvarchar(50) NULL,
        [kod_nmn] varchar(2) NULL,
        CONSTRAINT [PK_n_ulicii_nkod] PRIMARY KEY ([nkod])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[Roles] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[Users] (
        [Id] int NOT NULL IDENTITY,
        [Login] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NULL,
        [FirstName] nvarchar(max) NULL,
        [LastName] nvarchar(max) NULL,
        [Email] nvarchar(max) NOT NULL,
        [Age] int NULL,
        [Street] nvarchar(max) NULL,
        [City] nvarchar(max) NULL,
        [ZipCode] nvarchar(max) NULL,
        [Lat] float NULL,
        [Lng] float NULL,
        [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[dem_dgv_olduredi] (
        [ID_SP_DM] int NOT NULL IDENTITY,
        [Faza] smallint NULL,
        [Id_firma_dm] int NULL,
        [ID_kn] int NULL,
        [Vypros] varchar(6) NULL,
        [Ed_cena] decimal(7,2) NULL,
        [Broi] int NULL,
        [Total_cena] decimal(9,2) NULL,
        [Status_DS] char(1) NULL,
        [Status] char(1) NULL,
        [User] varchar(128) NULL,
        [Koga] datetime2(0) NULL,
        CONSTRAINT [PK_olduredi_dgv_dm_ID_SP_DM] PRIMARY KEY ([ID_SP_DM]),
        CONSTRAINT [FK_dem_dgv_olduredi_dem_dogovor] FOREIGN KEY ([Id_firma_dm]) REFERENCES [dbo].[dem_dogovor] ([Id_firma_DM]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[dem_porychka] (
        [IDDM] int NOT NULL IDENTITY,
        [Faza] smallint NULL,
        [Nomer_poreden_DM] int NULL,
        [OT_Data] date NULL,
        [U_nom] nvarchar(15) NULL,
        [Id_firma_dm] int NULL,
        [Id_SP_NET] int NULL,
        [vypros] nvarchar(6) NULL,
        [Id_kn] int NULL,
        [Broi_U] int NULL,
        [id_L] int NULL,
        [IDENT] nvarchar(10) NULL,
        [IME] nvarchar(20) NULL,
        [A_Raion] nvarchar(2) NULL,
        [Start_data] date NULL,
        [Status_dp] char(1) NULL,
        [Status] nvarchar(1) NULL,
        [user] nvarchar(30) NULL,
        [koga] datetime2(0) NULL,
        [DO_data] date NULL,
        CONSTRAINT [PK_oldporychka_dm_IDDM] PRIMARY KEY ([IDDM]),
        CONSTRAINT [FK_dem_oldporychka_dem_dogovor] FOREIGN KEY ([Id_firma_dm]) REFERENCES [dbo].[dem_dogovor] ([Id_firma_DM]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[dem_rajoni] (
        [ID_rec] int NOT NULL IDENTITY,
        [FAZA] smallint NULL,
        [ID_FIRMA_DM] int NULL,
        [NKOD] nvarchar(2) NULL,
        [Status] char(1) NULL,
        CONSTRAINT [PK_demontaj_rajoni_ID_rec] PRIMARY KEY ([ID_rec]),
        CONSTRAINT [FK_dem_rajoni_dem_dogovor] FOREIGN KEY ([ID_FIRMA_DM]) REFERENCES [dbo].[dem_dogovor] ([Id_firma_DM]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[lica_dogovor] (
        [Id_dog_L] int NOT NULL IDENTITY,
        [Id_L] int NULL,
        [Faza] smallint NULL,
        [U_Nom] nvarchar(15) NULL,
        [Reg_N] nvarchar(15) NULL,
        [Data_reg_N] date NULL,
        [Status_DL] char(1) NULL,
        [Status] char(1) NULL,
        [user] nvarchar(128) NULL,
        [koga] datetime2(0) NULL,
        CONSTRAINT [PK_dogovor_lica_Id_dog_L] PRIMARY KEY ([Id_dog_L]),
        CONSTRAINT [FK_lica_dogovor_lica] FOREIGN KEY ([Id_L]) REFERENCES [dbo].[lica] ([ID_L]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[lica_dokumenti] (
        [Id_Dok] int NOT NULL IDENTITY,
        [Id_L] int NULL,
        [Faza] smallint NULL,
        [U_NOM] nvarchar(15) NULL,
        [Vypros] nvarchar(5) NULL,
        [ID_KN] int NULL,
        [Kod_Dok] nvarchar(4) NULL,
        [Text_Dok] nvarchar(60) NULL,
        [Status_DD] char(1) NULL,
        [Status] char(1) NULL,
        [User] nvarchar(128) NULL,
        [Koga] datetime2(0) NULL,
        CONSTRAINT [PK_dokumenti_Id_Dok] PRIMARY KEY ([Id_Dok]),
        CONSTRAINT [FK_lica_dokumenti_lica] FOREIGN KEY ([Id_L]) REFERENCES [dbo].[lica] ([ID_L]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[lica_formuliar] (
        [ID_Formuliar] int NOT NULL IDENTITY,
        [Id_L] int NULL,
        [U_nom] varchar(15) NOT NULL,
        [faza] smallint NOT NULL,
        [Reg_date] datetime2(0) NULL,
        [Acster] varchar(20) NULL,
        [Acst_date] datetime2(0) NULL,
        [Status] char(1) NULL,
        [Status_F] char(1) NULL,
        CONSTRAINT [PK_formuliar_ID_Formuliar] PRIMARY KEY ([ID_Formuliar]),
        CONSTRAINT [FK_lica_formuliar_lica] FOREIGN KEY ([Id_L]) REFERENCES [dbo].[lica] ([ID_L]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[mon_dgv_podizpylniteli] (
        [ID_PodIZP] int NOT NULL IDENTITY,
        [ID_FIRMA] int NOT NULL,
        [EIK] varchar(14) NULL,
        [Name_F] varchar(100) NULL,
        [ADRES] varchar(100) NULL,
        [Maneger] varchar(60) NULL,
        [Ime_mger] varchar(50) NULL,
        [STATUS_DM] char(1) NULL,
        [Status] char(1) NULL,
        [user] varchar(128) NULL,
        [koga] datetime2(0) NULL,
        CONSTRAINT [FK_mon_dgv_podizpylniteli_mon_dogovor] FOREIGN KEY ([ID_FIRMA]) REFERENCES [dbo].[mon_dogovor] ([ID_FIRMA]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[mon_dgv_uredi] (
        [Id_Sp_dost] int NOT NULL IDENTITY,
        [Faza] smallint NULL,
        [Id_firma] int NULL,
        [ID_kn] int NULL,
        [Vypros] nvarchar(6) NULL,
        [Ed_cena] decimal(7,2) NULL,
        [Broi] int NULL,
        [Total_cena] decimal(9,2) NULL,
        [G_meseci] int NULL,
        [Broj_ostatyk] int NULL,
        [Status_DS] char(1) NULL,
        [Status] char(1) NULL,
        [User] nvarchar(128) NULL,
        [Koga] datetime2(0) NULL,
        [Cena_ostatyk] decimal(9,2) NULL,
        CONSTRAINT [PK_uredi_dgv_dost_Id_Sp_dost] PRIMARY KEY ([Id_Sp_dost]),
        CONSTRAINT [FK_mon_dgv_uredi_mon_dogovor] FOREIGN KEY ([Id_firma]) REFERENCES [dbo].[mon_dogovor] ([ID_FIRMA]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[mon_porychka] (
        [IDM] int NOT NULL IDENTITY,
        [Faza] smallint NULL,
        [Nomer_poreden_M] int NULL,
        [OT_Data] date NULL,
        [U_nom] nvarchar(15) NULL,
        [Id_firma] int NULL,
        [Id_SP_NET] int NULL,
        [vypros] nvarchar(6) NULL,
        [Id_kn] int NULL,
        [Broi_U] int NULL,
        [id_L] int NULL,
        [IDENT] nvarchar(10) NULL,
        [IME] nvarchar(20) NULL,
        [A_Raion] nvarchar(2) NULL,
        [Start_date] date NULL,
        [DO_data] date NULL,
        [Status_dp] char(1) NULL,
        [Status] nvarchar(1) NULL,
        [user] nvarchar(30) NULL,
        [koga] datetime2(0) NULL,
        CONSTRAINT [PK_porychka_m_IDM] PRIMARY KEY ([IDM]),
        CONSTRAINT [FK_mon_porychka_lica] FOREIGN KEY ([id_L]) REFERENCES [dbo].[lica] ([ID_L]) ON DELETE NO ACTION,
        CONSTRAINT [FK_mon_porychka_mon_dogovor] FOREIGN KEY ([Id_firma]) REFERENCES [dbo].[mon_dogovor] ([ID_FIRMA]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[mon_rajoni] (
        [ID_rec] int NOT NULL IDENTITY,
        [FAZA] smallint NULL,
        [Id_firma] int NULL,
        [NKOD] nvarchar(2) NULL,
        [Status] char(1) NULL,
        CONSTRAINT [PK_dostavchik_rajoni_ID_rec] PRIMARY KEY ([ID_rec]),
        CONSTRAINT [FK_mon_rajoni_mon_dogovor] FOREIGN KEY ([Id_firma]) REFERENCES [dbo].[mon_dogovor] ([ID_FIRMA]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[Settings] (
        [Id] int NOT NULL,
        [ThemeName] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Settings] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Settings_Users_Id] FOREIGN KEY ([Id]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[UserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [ClaimType] nvarchar(max) NOT NULL,
        [ClaimValue] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_UserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_UserClaims_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[UserPhotos] (
        [Id] int NOT NULL,
        [Image] varbinary(max) NOT NULL,
        CONSTRAINT [PK_UserPhotos] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_UserPhotos_Users_Id] FOREIGN KEY ([Id]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[UserRoles] (
        [UserId] int NOT NULL,
        [RoleId] int NOT NULL,
        CONSTRAINT [PK_UserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[lica_dogovor_uredi] (
        [Id_Ured_DG] int NOT NULL IDENTITY,
        [ID_DOG_L] int NULL,
        [Id_L] int NULL,
        [Vypros] varchar(6) NULL,
        [Id_KT] int NULL,
        [Broi] int NULL,
        [Status_U] char(1) NULL,
        [Status] char(1) NULL,
        [user] varchar(128) NULL,
        [Koga] datetime2(0) NULL,
        CONSTRAINT [PK_uredi_dg_l_Id_Ured_DG] PRIMARY KEY ([Id_Ured_DG]),
        CONSTRAINT [FK_lica_dogovor_uredi_lica_dogovor] FOREIGN KEY ([ID_DOG_L]) REFERENCES [dbo].[lica_dogovor] ([Id_dog_L]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[lica_formuliar_danni] (
        [Id_Vyprosnik] int NOT NULL IDENTITY,
        [ID_Formuliar] int NULL,
        [u_nom] nvarchar(15) NULL,
        [faza] smallint NULL,
        [Vypros] nvarchar(6) NULL,
        [Ukazatel] smallint NULL,
        [Chislo] int NULL,
        [Text] nvarchar(60) NULL,
        [DA_NE] nvarchar(2) NULL,
        [N_NMN_FK] int NULL,
        [kod_n] nvarchar(4) NULL,
        [Text_N] nvarchar(70) NULL,
        CONSTRAINT [PK_f_vypr_danni_Id_Vyprosnik] PRIMARY KEY ([Id_Vyprosnik]),
        CONSTRAINT [FK_lica_formuliar_danni_lica_formuliar] FOREIGN KEY ([ID_Formuliar]) REFERENCES [dbo].[lica_formuliar] ([ID_Formuliar]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[lica_formuliar_uredi] (
        [Id_ured_F] int NOT NULL IDENTITY,
        [Id_formuliar] int NULL,
        [Id_L] int NULL,
        [Vypros] nvarchar(5) NULL,
        [Id_KT] int NULL,
        [Broi] int NULL,
        [Status_U] char(1) NULL,
        [Status] char(1) NULL,
        [user] int NULL,
        [Koga] datetime2(0) NULL,
        CONSTRAINT [PK_uredi_f_Id_ured_F] PRIMARY KEY ([Id_ured_F]),
        CONSTRAINT [FK_lica_formuliar_uredi_lica_formuliar] FOREIGN KEY ([Id_formuliar]) REFERENCES [dbo].[lica_formuliar] ([ID_Formuliar]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[mon_grafik] (
        [Id_GRAFIK] int NOT NULL IDENTITY,
        [IDM] int NULL,
        [Faza] smallint NULL,
        [Nomer_poreden_M] int NOT NULL,
        [OT_Data] date NULL,
        [DO_data] date NULL,
        [U_nom] nvarchar(15) NULL,
        [Id_firma] int NULL,
        [Id_SP_NET] int NULL,
        [vypros] nvarchar(6) NULL,
        [Id_kn] int NULL,
        [Broi_U] int NULL,
        [id_L] int NULL,
        [IDENT] nvarchar(10) NULL,
        [IME] nvarchar(20) NULL,
        [PIME] nvarchar(20) NULL,
        [Fime] nvarchar(25) NULL,
        [GIME] nvarchar(60) NULL,
        [A_Raion] nvarchar(2) NULL,
        [NM] nvarchar(5) NULL,
        [KV] nvarchar(25) NULL,
        [JK] nvarchar(25) NULL,
        [UL] nvarchar(30) NULL,
        [Nomer] nvarchar(4) NULL,
        [Blok] nvarchar(4) NULL,
        [vh] nvarchar(2) NULL,
        [etaj] nvarchar(2) NULL,
        [AP] nvarchar(3) NULL,
        [tel] nvarchar(15) NULL,
        [Status_dp] char(1) NULL,
        [Status] nvarchar(1) NULL,
        [user] nvarchar(30) NULL,
        [koga] datetime2(0) NULL,
        CONSTRAINT [PK_grafik_m_Id_GRAFIK] PRIMARY KEY ([Id_GRAFIK]),
        CONSTRAINT [FK_mon_grafik_mon_porychka] FOREIGN KEY ([IDM]) REFERENCES [dbo].[mon_porychka] ([IDM]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE TABLE [dbo].[mon_otchet] (
        [ID_OTCHET] int NOT NULL IDENTITY,
        [Id_GRAFIK] int NULL,
        [IDM] int NOT NULL,
        [Faza] smallint NULL,
        [Nomer_poreden_M] int NOT NULL,
        [OT_Data] date NULL,
        [DO_data] date NULL,
        [NA_DATA] date NULL,
        [Broi_U] int NULL,
        [Status_dp] char(1) NULL,
        [Status] nvarchar(1) NULL,
        [user] nvarchar(30) NULL,
        [koga] datetime2(0) NULL,
        [data_montazj] datetime NULL,
        [fabr_nomer] varbinary(50) NULL,
        [gar_nomer] varbinary(50) NULL,
        CONSTRAINT [PK_otchet_m_ID_OTCHET] PRIMARY KEY ([ID_OTCHET]),
        CONSTRAINT [FK_mon_otchet_mon_porychka] FOREIGN KEY ([IDM]) REFERENCES [dbo].[mon_porychka] ([IDM]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE INDEX [IX_dem_dgv_olduredi_Id_firma_dm] ON [dbo].[dem_dgv_olduredi] ([Id_firma_dm]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE INDEX [IX_dem_porychka_Id_firma_dm] ON [dbo].[dem_porychka] ([Id_firma_dm]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE INDEX [IX_dem_rajoni_ID_FIRMA_DM] ON [dbo].[dem_rajoni] ([ID_FIRMA_DM]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE INDEX [IX_lica_dogovor_Id_L] ON [dbo].[lica_dogovor] ([Id_L]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE INDEX [IX_lica_dogovor_uredi_ID_DOG_L] ON [dbo].[lica_dogovor_uredi] ([ID_DOG_L]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE INDEX [IX_lica_dokumenti_Id_L] ON [dbo].[lica_dokumenti] ([Id_L]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE INDEX [IX_lica_formuliar_Id_L] ON [dbo].[lica_formuliar] ([Id_L]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE INDEX [IX_lica_formuliar_danni_ID_Formuliar] ON [dbo].[lica_formuliar_danni] ([ID_Formuliar]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE INDEX [IX_lica_formuliar_uredi_Id_formuliar] ON [dbo].[lica_formuliar_uredi] ([Id_formuliar]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE INDEX [IX_mon_dgv_podizpylniteli_ID_FIRMA] ON [dbo].[mon_dgv_podizpylniteli] ([ID_FIRMA]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE INDEX [IX_mon_dgv_uredi_Id_firma] ON [dbo].[mon_dgv_uredi] ([Id_firma]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE INDEX [IX_mon_grafik_IDM] ON [dbo].[mon_grafik] ([IDM]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE INDEX [IX_mon_otchet_IDM] ON [dbo].[mon_otchet] ([IDM]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE INDEX [IX_mon_porychka_Id_firma] ON [dbo].[mon_porychka] ([Id_firma]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE INDEX [IX_mon_porychka_id_L] ON [dbo].[mon_porychka] ([id_L]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE INDEX [IX_mon_rajoni_Id_firma] ON [dbo].[mon_rajoni] ([Id_firma]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE INDEX [IX_UserClaims_UserId] ON [dbo].[UserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    CREATE INDEX [IX_UserRoles_RoleId] ON [dbo].[UserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210809171154_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210809171154_Initial', N'5.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210817153204_AddedSpravkiTable')
BEGIN
    CREATE TABLE [dbo].[n_spravki] (
        [Id] int NOT NULL IDENTITY,
        [Status] smallint NOT NULL,
        [Faza] smallint NOT NULL,
        [Ime] nvarchar(max) NULL,
        [Komentar] nvarchar(max) NULL,
        [Tip] smallint NOT NULL,
        CONSTRAINT [PK_n_spravki] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210817153204_AddedSpravkiTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210817153204_AddedSpravkiTable', N'5.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210821203756_AddedObhvatTable')
BEGIN
    CREATE TABLE [dbo].[Obhvat] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_Obhvat] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210821203756_AddedObhvatTable')
BEGIN
    CREATE TABLE [dbo].[UserObhvat] (
        [UserId] int NOT NULL,
        [ObhvatId] int NOT NULL,
        CONSTRAINT [PK_UserObhvat] PRIMARY KEY ([UserId], [ObhvatId]),
        CONSTRAINT [FK_UserObhvat_Obhvat_ObhvatId] FOREIGN KEY ([ObhvatId]) REFERENCES [dbo].[Obhvat] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_UserObhvat_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210821203756_AddedObhvatTable')
BEGIN
    CREATE INDEX [IX_UserObhvat_ObhvatId] ON [dbo].[UserObhvat] ([ObhvatId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210821203756_AddedObhvatTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210821203756_AddedObhvatTable', N'5.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210823172841_ShangedStatusType')
BEGIN
    ALTER TABLE [dbo].[n_ulicii] ADD [Status] smallint NOT NULL DEFAULT CAST(0 AS smallint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210823172841_ShangedStatusType')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[n_statusi]') AND [c].[name] = N'Status');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[n_statusi] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [dbo].[n_statusi] ALTER COLUMN [Status] smallint NOT NULL;
    ALTER TABLE [dbo].[n_statusi] ADD DEFAULT CAST(0 AS smallint) FOR [Status];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210823172841_ShangedStatusType')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[n_statusi]') AND [c].[name] = N'Faza');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[n_statusi] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [dbo].[n_statusi] ALTER COLUMN [Faza] smallint NOT NULL;
    ALTER TABLE [dbo].[n_statusi] ADD DEFAULT CAST(0 AS smallint) FOR [Faza];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210823172841_ShangedStatusType')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[n_spisyk_nmn]') AND [c].[name] = N'Status');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[n_spisyk_nmn] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [dbo].[n_spisyk_nmn] ALTER COLUMN [Status] smallint NOT NULL;
    ALTER TABLE [dbo].[n_spisyk_nmn] ADD DEFAULT CAST(0 AS smallint) FOR [Status];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210823172841_ShangedStatusType')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[n_spisyk_nmn]') AND [c].[name] = N'Faza');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[n_spisyk_nmn] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [dbo].[n_spisyk_nmn] ALTER COLUMN [Faza] smallint NOT NULL;
    ALTER TABLE [dbo].[n_spisyk_nmn] ADD DEFAULT CAST(0 AS smallint) FOR [Faza];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210823172841_ShangedStatusType')
BEGIN
    ALTER TABLE [dbo].[n_raioni] ADD [Status] smallint NOT NULL DEFAULT CAST(0 AS smallint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210823172841_ShangedStatusType')
BEGIN
    ALTER TABLE [dbo].[n_ns_mesta] ADD [Status] smallint NOT NULL DEFAULT CAST(0 AS smallint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210823172841_ShangedStatusType')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[n_nmn_obshti]') AND [c].[name] = N'status');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[n_nmn_obshti] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [dbo].[n_nmn_obshti] ALTER COLUMN [status] smallint NOT NULL;
    ALTER TABLE [dbo].[n_nmn_obshti] ADD DEFAULT CAST(0 AS smallint) FOR [status];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210823172841_ShangedStatusType')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[n_nmn_obshti]') AND [c].[name] = N'Faza');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[n_nmn_obshti] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [dbo].[n_nmn_obshti] ALTER COLUMN [Faza] smallint NOT NULL;
    ALTER TABLE [dbo].[n_nmn_obshti] ADD DEFAULT CAST(0 AS smallint) FOR [Faza];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210823172841_ShangedStatusType')
BEGIN
    ALTER TABLE [dbo].[n_kvartali] ADD [Status] smallint NOT NULL DEFAULT CAST(0 AS smallint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210823172841_ShangedStatusType')
BEGIN
    ALTER TABLE [dbo].[n_kmetstva] ADD [Status] smallint NOT NULL DEFAULT CAST(0 AS smallint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210823172841_ShangedStatusType')
BEGIN
    ALTER TABLE [dbo].[n_jk] ADD [Status] smallint NOT NULL DEFAULT CAST(0 AS smallint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210823172841_ShangedStatusType')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica]') AND [c].[name] = N'Status');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [dbo].[lica] ALTER COLUMN [Status] smallint NOT NULL;
    ALTER TABLE [dbo].[lica] ADD DEFAULT CAST(0 AS smallint) FOR [Status];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210823172841_ShangedStatusType')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210823172841_ShangedStatusType', N'5.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    DROP TABLE [dbo].[lica_formuliar_danni];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_formuliar]') AND [c].[name] = N'Acst_date');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_formuliar] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [dbo].[lica_formuliar] DROP COLUMN [Acst_date];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_formuliar]') AND [c].[name] = N'Acster');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_formuliar] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [dbo].[lica_formuliar] DROP COLUMN [Acster];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica]') AND [c].[name] = N'Fime');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [dbo].[lica] DROP COLUMN [Fime];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica]') AND [c].[name] = N'GIME');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [dbo].[lica] DROP COLUMN [GIME];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica]') AND [c].[name] = N'ID_Predstavitel');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [dbo].[lica] DROP COLUMN [ID_Predstavitel];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica]') AND [c].[name] = N'PIME');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [dbo].[lica] DROP COLUMN [PIME];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica]') AND [c].[name] = N'Predstavitel');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica] DROP CONSTRAINT [' + @var13 + '];');
    ALTER TABLE [dbo].[lica] DROP COLUMN [Predstavitel];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[mon_rajoni] DROP CONSTRAINT [FK_mon_rajoni_mon_dogovor];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[mon_porychka] DROP CONSTRAINT [FK_mon_porychka_mon_dogovor];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[mon_dgv_uredi] DROP CONSTRAINT [FK_mon_dgv_uredi_mon_dogovor];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[mon_dgv_podizpylniteli] DROP CONSTRAINT [FK_mon_dgv_podizpylniteli_mon_dogovor];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[mon_dogovor] DROP CONSTRAINT [PK_dgv_dostavchici_ID_FIRMA];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    EXEC sp_rename N'[dbo].[mon_dogovor].[ID_FIRMA]', N'IdFirmaMn', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    EXEC sp_rename N'[dbo].[mon_rajoni].[Id_firma]', N'IdFirmaMn', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    EXEC sp_rename N'[dbo].[mon_porychka].[Id_firma]', N'IdFirmaMn', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    EXEC sp_rename N'[dbo].[mon_grafik].[Id_firma]', N'IdFirmaMn', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    EXEC sp_rename N'[dbo].[mon_dgv_uredi].[Id_firma]', N'IdFirmaMn', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    EXEC sp_rename N'[dbo].[mon_dgv_podizpylniteli].[ID_FIRMA]', N'IdFirmaMn', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[mon_dogovor] ADD CONSTRAINT [PK_dgv_dostavchici_ID_FIRMA] PRIMARY KEY ([IdFirmaMn]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[mon_rajoni] ADD CONSTRAINT [FK_mon_rajoni_mon_dogovor] FOREIGN KEY ([IdFirmaMn]) REFERENCES [dbo].[mon_dogovor] ([IdFirmaMn]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[mon_porychka] ADD CONSTRAINT [FK_mon_porychka_mon_dogovor] FOREIGN KEY ([IdFirmaMn]) REFERENCES [dbo].[mon_dogovor] ([IdFirmaMn]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[mon_dgv_uredi] ADD CONSTRAINT [FK_mon_dgv_uredi_mon_dogovor] FOREIGN KEY ([IdFirmaMn]) REFERENCES [dbo].[mon_dogovor] ([IdFirmaMn]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[mon_dgv_podizpylniteli] ADD CONSTRAINT [FK_mon_dgv_podizpylniteli_mon_dogovor] FOREIGN KEY ([IdFirmaMn]) REFERENCES [dbo].[mon_dogovor] ([IdFirmaMn]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    CREATE INDEX [IX_mon_dgv_podizpylniteli_ID_FIRMAMN] ON [dbo].[mon_dgv_podizpylniteli] ([IdFirmaMn]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    CREATE INDEX [IX_mon_dgv_uredi_IdFirmaNm] ON [dbo].[mon_dgv_uredi] ([IdFirmaMn]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    CREATE INDEX [IX_mon_porychka_IdFirmaMn] ON [dbo].[mon_porychka] ([IdFirmaMn]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    CREATE INDEX [IX_mon_rajoni_IdFirmaMn] ON [dbo].[mon_rajoni] ([IdFirmaMn]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    EXEC sp_rename N'[dbo].[mon_dgv_podizpylniteli].[STATUS_DM]', N'Status_DM', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[mon_dogovor] ADD [IdFirma] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    DECLARE @var14 sysname;
    SELECT @var14 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_formuliar]') AND [c].[name] = N'Status_F');
    IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_formuliar] DROP CONSTRAINT [' + @var14 + '];');
    ALTER TABLE [dbo].[lica_formuliar] ALTER COLUMN [Status_F] smallint NOT NULL;
    ALTER TABLE [dbo].[lica_formuliar] ADD DEFAULT CAST(0 AS smallint) FOR [Status_F];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    DECLARE @var15 sysname;
    SELECT @var15 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_formuliar]') AND [c].[name] = N'Status');
    IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_formuliar] DROP CONSTRAINT [' + @var15 + '];');
    ALTER TABLE [dbo].[lica_formuliar] ALTER COLUMN [Status] smallint NOT NULL;
    ALTER TABLE [dbo].[lica_formuliar] ADD DEFAULT CAST(0 AS smallint) FOR [Status];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [Koga] datetime2 NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [User] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V11] smallint NOT NULL DEFAULT CAST(0 AS smallint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V12] smallint NOT NULL DEFAULT CAST(0 AS smallint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V13] smallint NOT NULL DEFAULT CAST(0 AS smallint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V14] smallint NOT NULL DEFAULT CAST(0 AS smallint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V15] smallint NOT NULL DEFAULT CAST(0 AS smallint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V16] smallint NOT NULL DEFAULT CAST(0 AS smallint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V17] smallint NOT NULL DEFAULT CAST(0 AS smallint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V20] smallint NOT NULL DEFAULT CAST(0 AS smallint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V211] decimal(18,2) NOT NULL DEFAULT 0.0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V212] decimal(18,2) NOT NULL DEFAULT 0.0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V213] decimal(18,2) NOT NULL DEFAULT 0.0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V22] smallint NOT NULL DEFAULT CAST(0 AS smallint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V23] smallint NOT NULL DEFAULT CAST(0 AS smallint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V24] smallint NOT NULL DEFAULT CAST(0 AS smallint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V25] smallint NOT NULL DEFAULT CAST(0 AS smallint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V26] smallint NOT NULL DEFAULT CAST(0 AS smallint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V27] smallint NOT NULL DEFAULT CAST(0 AS smallint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V28] smallint NOT NULL DEFAULT CAST(0 AS smallint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V30] smallint NOT NULL DEFAULT CAST(0 AS smallint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V31] smallint NOT NULL DEFAULT CAST(0 AS smallint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V32] smallint NOT NULL DEFAULT CAST(0 AS smallint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V33] smallint NOT NULL DEFAULT CAST(0 AS smallint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V34] smallint NOT NULL DEFAULT CAST(0 AS smallint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V35] smallint NOT NULL DEFAULT CAST(0 AS smallint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V36] smallint NOT NULL DEFAULT CAST(0 AS smallint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V37] smallint NOT NULL DEFAULT CAST(0 AS smallint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V38] smallint NOT NULL DEFAULT CAST(0 AS smallint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V391] decimal(18,2) NOT NULL DEFAULT 0.0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V392] decimal(18,2) NOT NULL DEFAULT 0.0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V401] decimal(18,2) NOT NULL DEFAULT 0.0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V402] decimal(18,2) NOT NULL DEFAULT 0.0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V41] decimal(18,2) NOT NULL DEFAULT 0.0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V421] decimal(18,2) NOT NULL DEFAULT 0.0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V422] decimal(18,2) NOT NULL DEFAULT 0.0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [V423] decimal(18,2) NOT NULL DEFAULT 0.0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [nV10] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [nV19] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [nV29] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [nV8] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [nV9] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    DECLARE @var16 sysname;
    SELECT @var16 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica]') AND [c].[name] = N'Status_L');
    IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica] DROP CONSTRAINT [' + @var16 + '];');
    ALTER TABLE [dbo].[lica] ALTER COLUMN [Status_L] smallint NOT NULL;
    ALTER TABLE [dbo].[lica] ADD DEFAULT CAST(0 AS smallint) FOR [Status_L];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    DECLARE @var17 sysname;
    SELECT @var17 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica]') AND [c].[name] = N'Status_F');
    IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica] DROP CONSTRAINT [' + @var17 + '];');
    ALTER TABLE [dbo].[lica] ALTER COLUMN [Status_F] smallint NOT NULL;
    ALTER TABLE [dbo].[lica] ADD DEFAULT CAST(0 AS smallint) FOR [Status_F];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[lica] ADD [Zona] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[dem_dogovor] ADD [IdFirma] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    CREATE TABLE [dbo].[firmi] (
        [IdFirma] int NOT NULL IDENTITY,
        [Faza] smallint NOT NULL,
        [VidFirma] nvarchar(max) NULL,
        [EIK] nvarchar(max) NULL,
        [Ime] nvarchar(max) NULL,
        [Adres] nvarchar(max) NULL,
        [NomDgSUDSO] nvarchar(max) NULL,
        [Manager] nvarchar(max) NULL,
        [MName] nvarchar(max) NULL,
        [StatusDm] smallint NOT NULL,
        [Status] smallint NOT NULL,
        [User] nvarchar(max) NULL,
        [Koga] datetime2 NULL,
        CONSTRAINT [PK_firmi_IDFirma] PRIMARY KEY ([IdFirma])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    CREATE TABLE [dbo].[LicaFormuliarFirma] (
        [Id] int NOT NULL IDENTITY,
        [IdL] int NULL,
        [Faza] smallint NULL,
        [UNom] nvarchar(max) NULL,
        [VidFirma] nvarchar(max) NULL,
        [Ident] nvarchar(max) NULL,
        [KodKID] nvarchar(max) NULL,
        [Ime] nvarchar(max) NULL,
        [ARaion] nvarchar(max) NULL,
        [Nm] nvarchar(max) NULL,
        [Kv] nvarchar(max) NULL,
        [Jk] nvarchar(max) NULL,
        [Ul] nvarchar(max) NULL,
        [Nomer] nvarchar(max) NULL,
        [Blok] nvarchar(max) NULL,
        [Vh] nvarchar(max) NULL,
        [Etaj] nvarchar(max) NULL,
        [Ap] nvarchar(max) NULL,
        [EMail] nvarchar(max) NULL,
        [Tel] nvarchar(max) NULL,
        [Pk] nvarchar(max) NULL,
        [TipFirma] nvarchar(max) NULL,
        [StatusL] smallint NOT NULL,
        [StatusF] smallint NOT NULL,
        [Status] smallint NOT NULL,
        [User] nvarchar(max) NULL,
        [Koga] datetime2 NULL,
        [IdLNavigationIdL] int NULL,
        CONSTRAINT [PK_LicaFormuliarFirma] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_LicaFormuliarFirma_lica_IdLNavigationIdL] FOREIGN KEY ([IdLNavigationIdL]) REFERENCES [dbo].[lica] ([ID_L]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    CREATE TABLE [dbo].[LicaFormuliarKolektiv] (
        [Id] int NOT NULL IDENTITY,
        [IdL] int NULL,
        [Faza] smallint NULL,
        [VIdent] nvarchar(max) NULL,
        [Ident] nvarchar(max) NULL,
        [Ime] nvarchar(max) NULL,
        [ARaion] nvarchar(max) NULL,
        [Nm] nvarchar(max) NULL,
        [Kv] nvarchar(max) NULL,
        [Jk] nvarchar(max) NULL,
        [Ul] nvarchar(max) NULL,
        [Nomer] nvarchar(max) NULL,
        [Blok] nvarchar(max) NULL,
        [Vh] nvarchar(max) NULL,
        [Etaj] nvarchar(max) NULL,
        [Ap] nvarchar(max) NULL,
        [EMail] nvarchar(max) NULL,
        [Tel] nvarchar(max) NULL,
        [Pk] nvarchar(max) NULL,
        [StatusL] smallint NOT NULL,
        [Status] smallint NOT NULL,
        [User] nvarchar(max) NULL,
        [Koga] datetime2 NULL,
        [IdLNavigationIdL] int NULL,
        CONSTRAINT [PK_LicaFormuliarKolektiv] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_LicaFormuliarKolektiv_lica_IdLNavigationIdL] FOREIGN KEY ([IdLNavigationIdL]) REFERENCES [dbo].[lica] ([ID_L]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    CREATE INDEX [IX_dem_dogovor_IdFirma] ON [dbo].[dem_dogovor] ([IdFirma]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    CREATE INDEX [IX_LicaFormuliarFirma_IdLNavigationIdL] ON [dbo].[LicaFormuliarFirma] ([IdLNavigationIdL]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    CREATE INDEX [IX_LicaFormuliarKolektiv_IdLNavigationIdL] ON [dbo].[LicaFormuliarKolektiv] ([IdLNavigationIdL]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[dem_dogovor] ADD CONSTRAINT [FK_demon_dogovor_firmi] FOREIGN KEY ([IdFirma]) REFERENCES [dbo].[firmi] ([IdFirma]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    ALTER TABLE [dbo].[mon_dogovor] ADD CONSTRAINT [FK_mon_dogovor_firmi] FOREIGN KEY ([IdFirma]) REFERENCES [dbo].[firmi] ([IdFirma]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824122813_ChangedFormuliarTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210824122813_ChangedFormuliarTable', N'5.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824134038_RemoveTableLicaUrediOld')
BEGIN
    ALTER TABLE [dbo].[LicaFormuliarFirma] DROP CONSTRAINT [FK_LicaFormuliarFirma_lica_IdLNavigationIdL];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824134038_RemoveTableLicaUrediOld')
BEGIN
    ALTER TABLE [dbo].[LicaFormuliarKolektiv] DROP CONSTRAINT [FK_LicaFormuliarKolektiv_lica_IdLNavigationIdL];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824134038_RemoveTableLicaUrediOld')
BEGIN
    DROP TABLE [dbo].[lica_dogovor_olduredi];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824134038_RemoveTableLicaUrediOld')
BEGIN
    ALTER TABLE [dbo].[LicaFormuliarKolektiv] DROP CONSTRAINT [PK_LicaFormuliarKolektiv];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824134038_RemoveTableLicaUrediOld')
BEGIN
    ALTER TABLE [dbo].[LicaFormuliarFirma] DROP CONSTRAINT [PK_LicaFormuliarFirma];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824134038_RemoveTableLicaUrediOld')
BEGIN
    EXEC sp_rename N'[dbo].[LicaFormuliarKolektiv]', N'lica_formuliar_kolektiv';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824134038_RemoveTableLicaUrediOld')
BEGIN
    EXEC sp_rename N'[dbo].[LicaFormuliarFirma]', N'lica_formuliar_firma';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824134038_RemoveTableLicaUrediOld')
BEGIN
    EXEC sp_rename N'[dbo].[lica_formuliar_kolektiv].[IX_LicaFormuliarKolektiv_IdLNavigationIdL]', N'IX_lica_formuliar_kolektiv_IdLNavigationIdL', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824134038_RemoveTableLicaUrediOld')
BEGIN
    EXEC sp_rename N'[dbo].[lica_formuliar_firma].[IX_LicaFormuliarFirma_IdLNavigationIdL]', N'IX_lica_formuliar_firma_IdLNavigationIdL', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824134038_RemoveTableLicaUrediOld')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar_kolektiv] ADD CONSTRAINT [PK_lica_formuliar_kolektiv] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824134038_RemoveTableLicaUrediOld')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar_firma] ADD CONSTRAINT [PK_lica_formuliar_firma] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824134038_RemoveTableLicaUrediOld')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar_firma] ADD CONSTRAINT [FK_lica_formuliar_firma_lica_IdLNavigationIdL] FOREIGN KEY ([IdLNavigationIdL]) REFERENCES [dbo].[lica] ([ID_L]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824134038_RemoveTableLicaUrediOld')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar_kolektiv] ADD CONSTRAINT [FK_lica_formuliar_kolektiv_lica_IdLNavigationIdL] FOREIGN KEY ([IdLNavigationIdL]) REFERENCES [dbo].[lica] ([ID_L]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210824134038_RemoveTableLicaUrediOld')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210824134038_RemoveTableLicaUrediOld', N'5.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210826212949_AddedColumnsFormulqr')
BEGIN
    DECLARE @var18 sysname;
    SELECT @var18 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_formuliar]') AND [c].[name] = N'V423');
    IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_formuliar] DROP CONSTRAINT [' + @var18 + '];');
    ALTER TABLE [dbo].[lica_formuliar] ALTER COLUMN [V423] decimal(10,2) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210826212949_AddedColumnsFormulqr')
BEGIN
    DECLARE @var19 sysname;
    SELECT @var19 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_formuliar]') AND [c].[name] = N'V422');
    IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_formuliar] DROP CONSTRAINT [' + @var19 + '];');
    ALTER TABLE [dbo].[lica_formuliar] ALTER COLUMN [V422] decimal(10,2) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210826212949_AddedColumnsFormulqr')
BEGIN
    DECLARE @var20 sysname;
    SELECT @var20 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_formuliar]') AND [c].[name] = N'V421');
    IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_formuliar] DROP CONSTRAINT [' + @var20 + '];');
    ALTER TABLE [dbo].[lica_formuliar] ALTER COLUMN [V421] decimal(10,2) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210826212949_AddedColumnsFormulqr')
BEGIN
    DECLARE @var21 sysname;
    SELECT @var21 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_formuliar]') AND [c].[name] = N'V402');
    IF @var21 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_formuliar] DROP CONSTRAINT [' + @var21 + '];');
    ALTER TABLE [dbo].[lica_formuliar] ALTER COLUMN [V402] decimal(10,2) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210826212949_AddedColumnsFormulqr')
BEGIN
    DECLARE @var22 sysname;
    SELECT @var22 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_formuliar]') AND [c].[name] = N'V401');
    IF @var22 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_formuliar] DROP CONSTRAINT [' + @var22 + '];');
    ALTER TABLE [dbo].[lica_formuliar] ALTER COLUMN [V401] decimal(10,2) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210826212949_AddedColumnsFormulqr')
BEGIN
    DECLARE @var23 sysname;
    SELECT @var23 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_formuliar]') AND [c].[name] = N'V392');
    IF @var23 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_formuliar] DROP CONSTRAINT [' + @var23 + '];');
    ALTER TABLE [dbo].[lica_formuliar] ALTER COLUMN [V392] decimal(10,2) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210826212949_AddedColumnsFormulqr')
BEGIN
    DECLARE @var24 sysname;
    SELECT @var24 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_formuliar]') AND [c].[name] = N'V391');
    IF @var24 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_formuliar] DROP CONSTRAINT [' + @var24 + '];');
    ALTER TABLE [dbo].[lica_formuliar] ALTER COLUMN [V391] decimal(10,2) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210826212949_AddedColumnsFormulqr')
BEGIN
    DECLARE @var25 sysname;
    SELECT @var25 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_formuliar]') AND [c].[name] = N'V213');
    IF @var25 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_formuliar] DROP CONSTRAINT [' + @var25 + '];');
    ALTER TABLE [dbo].[lica_formuliar] ALTER COLUMN [V213] decimal(10,2) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210826212949_AddedColumnsFormulqr')
BEGIN
    DECLARE @var26 sysname;
    SELECT @var26 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_formuliar]') AND [c].[name] = N'V212');
    IF @var26 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_formuliar] DROP CONSTRAINT [' + @var26 + '];');
    ALTER TABLE [dbo].[lica_formuliar] ALTER COLUMN [V212] decimal(10,2) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210826212949_AddedColumnsFormulqr')
BEGIN
    DECLARE @var27 sysname;
    SELECT @var27 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_formuliar]') AND [c].[name] = N'V211');
    IF @var27 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_formuliar] DROP CONSTRAINT [' + @var27 + '];');
    ALTER TABLE [dbo].[lica_formuliar] ALTER COLUMN [V211] decimal(10,2) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210826212949_AddedColumnsFormulqr')
BEGIN
    ALTER TABLE [dbo].[lica] ADD [Tochki6] decimal(18,2) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210826212949_AddedColumnsFormulqr')
BEGIN
    ALTER TABLE [dbo].[lica] ADD [Tochki7] decimal(18,2) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210826212949_AddedColumnsFormulqr')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210826212949_AddedColumnsFormulqr', N'5.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210830220202_ChangedStatusType')
BEGIN
    DECLARE @var28 sysname;
    SELECT @var28 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[n_nmn_obshti]') AND [c].[name] = N'Text');
    IF @var28 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[n_nmn_obshti] DROP CONSTRAINT [' + @var28 + '];');
    ALTER TABLE [dbo].[n_nmn_obshti] ALTER COLUMN [Text] nvarchar(200) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210830220202_ChangedStatusType')
BEGIN
    DECLARE @var29 sysname;
    SELECT @var29 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_dokumenti]') AND [c].[name] = N'Status_DD');
    IF @var29 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_dokumenti] DROP CONSTRAINT [' + @var29 + '];');
    ALTER TABLE [dbo].[lica_dokumenti] ALTER COLUMN [Status_DD] smallint NOT NULL;
    ALTER TABLE [dbo].[lica_dokumenti] ADD DEFAULT CAST(0 AS smallint) FOR [Status_DD];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210830220202_ChangedStatusType')
BEGIN
    DECLARE @var30 sysname;
    SELECT @var30 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_dokumenti]') AND [c].[name] = N'Status');
    IF @var30 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_dokumenti] DROP CONSTRAINT [' + @var30 + '];');
    ALTER TABLE [dbo].[lica_dokumenti] ALTER COLUMN [Status] smallint NOT NULL;
    ALTER TABLE [dbo].[lica_dokumenti] ADD DEFAULT CAST(0 AS smallint) FOR [Status];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210830220202_ChangedStatusType')
BEGIN
    DECLARE @var31 sysname;
    SELECT @var31 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_dogovor_uredi]') AND [c].[name] = N'Status_U');
    IF @var31 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_dogovor_uredi] DROP CONSTRAINT [' + @var31 + '];');
    ALTER TABLE [dbo].[lica_dogovor_uredi] ALTER COLUMN [Status_U] smallint NOT NULL;
    ALTER TABLE [dbo].[lica_dogovor_uredi] ADD DEFAULT CAST(0 AS smallint) FOR [Status_U];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210830220202_ChangedStatusType')
BEGIN
    DECLARE @var32 sysname;
    SELECT @var32 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_dogovor_uredi]') AND [c].[name] = N'Status');
    IF @var32 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_dogovor_uredi] DROP CONSTRAINT [' + @var32 + '];');
    ALTER TABLE [dbo].[lica_dogovor_uredi] ALTER COLUMN [Status] smallint NOT NULL;
    ALTER TABLE [dbo].[lica_dogovor_uredi] ADD DEFAULT CAST(0 AS smallint) FOR [Status];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210830220202_ChangedStatusType')
BEGIN
    DECLARE @var33 sysname;
    SELECT @var33 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_dogovor]') AND [c].[name] = N'Status_DL');
    IF @var33 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_dogovor] DROP CONSTRAINT [' + @var33 + '];');
    ALTER TABLE [dbo].[lica_dogovor] ALTER COLUMN [Status_DL] smallint NOT NULL;
    ALTER TABLE [dbo].[lica_dogovor] ADD DEFAULT CAST(0 AS smallint) FOR [Status_DL];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210830220202_ChangedStatusType')
BEGIN
    DECLARE @var34 sysname;
    SELECT @var34 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_dogovor]') AND [c].[name] = N'Status');
    IF @var34 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_dogovor] DROP CONSTRAINT [' + @var34 + '];');
    ALTER TABLE [dbo].[lica_dogovor] ALTER COLUMN [Status] smallint NOT NULL;
    ALTER TABLE [dbo].[lica_dogovor] ADD DEFAULT CAST(0 AS smallint) FOR [Status];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210830220202_ChangedStatusType')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210830220202_ChangedStatusType', N'5.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210831110339_ChangeStatusTypes')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] DROP CONSTRAINT [FK_lica_formuliar_lica];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210831110339_ChangeStatusTypes')
BEGIN
    DECLARE @var35 sysname;
    SELECT @var35 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica]') AND [c].[name] = N'U_nom');
    IF @var35 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica] DROP CONSTRAINT [' + @var35 + '];');
    ALTER TABLE [dbo].[lica] DROP COLUMN [U_nom];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210831110339_ChangeStatusTypes')
BEGIN
    DECLARE @var36 sysname;
    SELECT @var36 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica]') AND [c].[name] = N'V8');
    IF @var36 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica] DROP CONSTRAINT [' + @var36 + '];');
    ALTER TABLE [dbo].[lica] DROP COLUMN [V8];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210831110339_ChangeStatusTypes')
BEGIN
    DROP INDEX [IX_lica_formuliar_Id_L] ON [dbo].[lica_formuliar];
    DECLARE @var37 sysname;
    SELECT @var37 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_formuliar]') AND [c].[name] = N'Id_L');
    IF @var37 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_formuliar] DROP CONSTRAINT [' + @var37 + '];');
    ALTER TABLE [dbo].[lica_formuliar] ALTER COLUMN [Id_L] int NOT NULL;
    ALTER TABLE [dbo].[lica_formuliar] ADD DEFAULT 0 FOR [Id_L];
    CREATE INDEX [IX_lica_formuliar_Id_L] ON [dbo].[lica_formuliar] ([Id_L]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210831110339_ChangeStatusTypes')
BEGIN
    DECLARE @var38 sysname;
    SELECT @var38 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica]') AND [c].[name] = N'v_lice');
    IF @var38 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica] DROP CONSTRAINT [' + @var38 + '];');
    ALTER TABLE [dbo].[lica] ALTER COLUMN [v_lice] int NOT NULL;
    ALTER TABLE [dbo].[lica] ADD DEFAULT 0 FOR [v_lice];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210831110339_ChangeStatusTypes')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD CONSTRAINT [FK_lica_formuliar_lica] FOREIGN KEY ([Id_L]) REFERENCES [dbo].[lica] ([ID_L]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210831110339_ChangeStatusTypes')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210831110339_ChangeStatusTypes', N'5.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210901132558_AddedNewTables')
BEGIN
    DROP TABLE [dbo].[n_kvartali];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210901132558_AddedNewTables')
BEGIN
    DECLARE @var39 sysname;
    SELECT @var39 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_formuliar_firma]') AND [c].[name] = N'VidFirma');
    IF @var39 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_formuliar_firma] DROP CONSTRAINT [' + @var39 + '];');
    ALTER TABLE [dbo].[lica_formuliar_firma] ALTER COLUMN [VidFirma] int NOT NULL;
    ALTER TABLE [dbo].[lica_formuliar_firma] ADD DEFAULT 0 FOR [VidFirma];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210901132558_AddedNewTables')
BEGIN
    DECLARE @var40 sysname;
    SELECT @var40 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_formuliar_firma]') AND [c].[name] = N'TipFirma');
    IF @var40 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_formuliar_firma] DROP CONSTRAINT [' + @var40 + '];');
    ALTER TABLE [dbo].[lica_formuliar_firma] ALTER COLUMN [TipFirma] int NOT NULL;
    ALTER TABLE [dbo].[lica_formuliar_firma] ADD DEFAULT 0 FOR [TipFirma];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210901132558_AddedNewTables')
BEGIN
    DECLARE @var41 sysname;
    SELECT @var41 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_formuliar_firma]') AND [c].[name] = N'IdL');
    IF @var41 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_formuliar_firma] DROP CONSTRAINT [' + @var41 + '];');
    ALTER TABLE [dbo].[lica_formuliar_firma] ALTER COLUMN [IdL] int NOT NULL;
    ALTER TABLE [dbo].[lica_formuliar_firma] ADD DEFAULT 0 FOR [IdL];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210901132558_AddedNewTables')
BEGIN
    DECLARE @var42 sysname;
    SELECT @var42 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_formuliar_firma]') AND [c].[name] = N'Faza');
    IF @var42 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_formuliar_firma] DROP CONSTRAINT [' + @var42 + '];');
    ALTER TABLE [dbo].[lica_formuliar_firma] ALTER COLUMN [Faza] smallint NOT NULL;
    ALTER TABLE [dbo].[lica_formuliar_firma] ADD DEFAULT CAST(0 AS smallint) FOR [Faza];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210901132558_AddedNewTables')
BEGIN
    CREATE TABLE [dbo].[n_uredi] (
        [Id] int NOT NULL IDENTITY,
        [Faza] smallint NOT NULL,
        [nkod] nvarchar(4) NULL,
        [nime] nvarchar(45) NULL,
        [MaxBr] int NOT NULL,
        [MaxRad] int NOT NULL,
        [Status] smallint NOT NULL,
        CONSTRAINT [PK_n_uredi_id] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210901132558_AddedNewTables')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210901132558_AddedNewTables', N'5.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210903091749_ChangedTablesLicaUredi')
BEGIN
    ALTER TABLE [dbo].[lica_dokumenti] DROP CONSTRAINT [FK_lica_dokumenti_lica];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210903091749_ChangedTablesLicaUredi')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar_uredi] DROP CONSTRAINT [FK_lica_formuliar_uredi_lica_formuliar];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210903091749_ChangedTablesLicaUredi')
BEGIN
    DECLARE @var43 sysname;
    SELECT @var43 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_formuliar_uredi]') AND [c].[name] = N'Vypros');
    IF @var43 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_formuliar_uredi] DROP CONSTRAINT [' + @var43 + '];');
    ALTER TABLE [dbo].[lica_formuliar_uredi] DROP COLUMN [Vypros];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210903091749_ChangedTablesLicaUredi')
BEGIN
    DECLARE @var44 sysname;
    SELECT @var44 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_dokumenti]') AND [c].[name] = N'Kod_Dok');
    IF @var44 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_dokumenti] DROP CONSTRAINT [' + @var44 + '];');
    ALTER TABLE [dbo].[lica_dokumenti] DROP COLUMN [Kod_Dok];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210903091749_ChangedTablesLicaUredi')
BEGIN
    DECLARE @var45 sysname;
    SELECT @var45 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_dokumenti]') AND [c].[name] = N'U_NOM');
    IF @var45 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_dokumenti] DROP CONSTRAINT [' + @var45 + '];');
    ALTER TABLE [dbo].[lica_dokumenti] DROP COLUMN [U_NOM];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210903091749_ChangedTablesLicaUredi')
BEGIN
    DECLARE @var46 sysname;
    SELECT @var46 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_dokumenti]') AND [c].[name] = N'Vypros');
    IF @var46 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_dokumenti] DROP CONSTRAINT [' + @var46 + '];');
    ALTER TABLE [dbo].[lica_dokumenti] DROP COLUMN [Vypros];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210903091749_ChangedTablesLicaUredi')
BEGIN
    DECLARE @var47 sysname;
    SELECT @var47 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[n_uredi]') AND [c].[name] = N'nime');
    IF @var47 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[n_uredi] DROP CONSTRAINT [' + @var47 + '];');
    ALTER TABLE [dbo].[n_uredi] ALTER COLUMN [nime] nvarchar(200) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210903091749_ChangedTablesLicaUredi')
BEGIN
    DECLARE @var48 sysname;
    SELECT @var48 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[n_statusi]') AND [c].[name] = N'Status_Code');
    IF @var48 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[n_statusi] DROP CONSTRAINT [' + @var48 + '];');
    ALTER TABLE [dbo].[n_statusi] ALTER COLUMN [Status_Code] smallint NOT NULL;
    ALTER TABLE [dbo].[n_statusi] ADD DEFAULT CAST(0 AS smallint) FOR [Status_Code];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210903091749_ChangedTablesLicaUredi')
BEGIN
    DECLARE @var49 sysname;
    SELECT @var49 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_formuliar_uredi]') AND [c].[name] = N'Status_U');
    IF @var49 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_formuliar_uredi] DROP CONSTRAINT [' + @var49 + '];');
    ALTER TABLE [dbo].[lica_formuliar_uredi] ALTER COLUMN [Status_U] smallint NOT NULL;
    ALTER TABLE [dbo].[lica_formuliar_uredi] ADD DEFAULT CAST(0 AS smallint) FOR [Status_U];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210903091749_ChangedTablesLicaUredi')
BEGIN
    DECLARE @var50 sysname;
    SELECT @var50 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_formuliar_uredi]') AND [c].[name] = N'Status');
    IF @var50 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_formuliar_uredi] DROP CONSTRAINT [' + @var50 + '];');
    ALTER TABLE [dbo].[lica_formuliar_uredi] ALTER COLUMN [Status] smallint NOT NULL;
    ALTER TABLE [dbo].[lica_formuliar_uredi] ADD DEFAULT CAST(0 AS smallint) FOR [Status];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210903091749_ChangedTablesLicaUredi')
BEGIN
    DROP INDEX [IX_lica_formuliar_uredi_Id_formuliar] ON [dbo].[lica_formuliar_uredi];
    DECLARE @var51 sysname;
    SELECT @var51 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_formuliar_uredi]') AND [c].[name] = N'Id_formuliar');
    IF @var51 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_formuliar_uredi] DROP CONSTRAINT [' + @var51 + '];');
    ALTER TABLE [dbo].[lica_formuliar_uredi] ALTER COLUMN [Id_formuliar] int NOT NULL;
    ALTER TABLE [dbo].[lica_formuliar_uredi] ADD DEFAULT 0 FOR [Id_formuliar];
    CREATE INDEX [IX_lica_formuliar_uredi_Id_formuliar] ON [dbo].[lica_formuliar_uredi] ([Id_formuliar]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210903091749_ChangedTablesLicaUredi')
BEGIN
    DECLARE @var52 sysname;
    SELECT @var52 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_formuliar_uredi]') AND [c].[name] = N'Id_L');
    IF @var52 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_formuliar_uredi] DROP CONSTRAINT [' + @var52 + '];');
    ALTER TABLE [dbo].[lica_formuliar_uredi] ALTER COLUMN [Id_L] int NOT NULL;
    ALTER TABLE [dbo].[lica_formuliar_uredi] ADD DEFAULT 0 FOR [Id_L];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210903091749_ChangedTablesLicaUredi')
BEGIN
    DECLARE @var53 sysname;
    SELECT @var53 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_formuliar_uredi]') AND [c].[name] = N'Id_KT');
    IF @var53 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_formuliar_uredi] DROP CONSTRAINT [' + @var53 + '];');
    ALTER TABLE [dbo].[lica_formuliar_uredi] ALTER COLUMN [Id_KT] int NOT NULL;
    ALTER TABLE [dbo].[lica_formuliar_uredi] ADD DEFAULT 0 FOR [Id_KT];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210903091749_ChangedTablesLicaUredi')
BEGIN
    DECLARE @var54 sysname;
    SELECT @var54 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_formuliar_uredi]') AND [c].[name] = N'Broi');
    IF @var54 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_formuliar_uredi] DROP CONSTRAINT [' + @var54 + '];');
    ALTER TABLE [dbo].[lica_formuliar_uredi] ALTER COLUMN [Broi] int NOT NULL;
    ALTER TABLE [dbo].[lica_formuliar_uredi] ADD DEFAULT 0 FOR [Broi];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210903091749_ChangedTablesLicaUredi')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar] ADD [nV18] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210903091749_ChangedTablesLicaUredi')
BEGIN
    DROP INDEX [IX_lica_dokumenti_Id_L] ON [dbo].[lica_dokumenti];
    DECLARE @var55 sysname;
    SELECT @var55 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_dokumenti]') AND [c].[name] = N'Id_L');
    IF @var55 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_dokumenti] DROP CONSTRAINT [' + @var55 + '];');
    ALTER TABLE [dbo].[lica_dokumenti] ALTER COLUMN [Id_L] int NOT NULL;
    ALTER TABLE [dbo].[lica_dokumenti] ADD DEFAULT 0 FOR [Id_L];
    CREATE INDEX [IX_lica_dokumenti_Id_L] ON [dbo].[lica_dokumenti] ([Id_L]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210903091749_ChangedTablesLicaUredi')
BEGIN
    DECLARE @var56 sysname;
    SELECT @var56 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_dokumenti]') AND [c].[name] = N'ID_KN');
    IF @var56 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_dokumenti] DROP CONSTRAINT [' + @var56 + '];');
    ALTER TABLE [dbo].[lica_dokumenti] ALTER COLUMN [ID_KN] int NOT NULL;
    ALTER TABLE [dbo].[lica_dokumenti] ADD DEFAULT 0 FOR [ID_KN];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210903091749_ChangedTablesLicaUredi')
BEGIN
    DECLARE @var57 sysname;
    SELECT @var57 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_dokumenti]') AND [c].[name] = N'Faza');
    IF @var57 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_dokumenti] DROP CONSTRAINT [' + @var57 + '];');
    ALTER TABLE [dbo].[lica_dokumenti] ALTER COLUMN [Faza] smallint NOT NULL;
    ALTER TABLE [dbo].[lica_dokumenti] ADD DEFAULT CAST(0 AS smallint) FOR [Faza];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210903091749_ChangedTablesLicaUredi')
BEGIN
    ALTER TABLE [dbo].[lica_dokumenti] ADD CONSTRAINT [FK_lica_dokumenti_lica] FOREIGN KEY ([Id_L]) REFERENCES [dbo].[lica] ([ID_L]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210903091749_ChangedTablesLicaUredi')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar_uredi] ADD CONSTRAINT [FK_lica_formuliar_uredi_lica_formuliar] FOREIGN KEY ([Id_formuliar]) REFERENCES [dbo].[lica_formuliar] ([ID_Formuliar]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210903091749_ChangedTablesLicaUredi')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210903091749_ChangedTablesLicaUredi', N'5.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210903124835_ChangetLicaUrediStatusType')
BEGIN
    DECLARE @var58 sysname;
    SELECT @var58 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_formuliar_uredi]') AND [c].[name] = N'user');
    IF @var58 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_formuliar_uredi] DROP CONSTRAINT [' + @var58 + '];');
    ALTER TABLE [dbo].[lica_formuliar_uredi] ALTER COLUMN [user] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210903124835_ChangetLicaUrediStatusType')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210903124835_ChangetLicaUrediStatusType', N'5.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210904221010_ChangetTableDefinition')
BEGIN
    DECLARE @var59 sysname;
    SELECT @var59 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_formuliar_kolektiv]') AND [c].[name] = N'IdL');
    IF @var59 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_formuliar_kolektiv] DROP CONSTRAINT [' + @var59 + '];');
    ALTER TABLE [dbo].[lica_formuliar_kolektiv] ALTER COLUMN [IdL] int NOT NULL;
    ALTER TABLE [dbo].[lica_formuliar_kolektiv] ADD DEFAULT 0 FOR [IdL];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210904221010_ChangetTableDefinition')
BEGIN
    DECLARE @var60 sysname;
    SELECT @var60 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[lica_formuliar_kolektiv]') AND [c].[name] = N'Faza');
    IF @var60 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[lica_formuliar_kolektiv] DROP CONSTRAINT [' + @var60 + '];');
    ALTER TABLE [dbo].[lica_formuliar_kolektiv] ALTER COLUMN [Faza] smallint NOT NULL;
    ALTER TABLE [dbo].[lica_formuliar_kolektiv] ADD DEFAULT CAST(0 AS smallint) FOR [Faza];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210904221010_ChangetTableDefinition')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210904221010_ChangetTableDefinition', N'5.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210905111808_AddedForeignKeyFormulqrUrediLica')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar_uredi] DROP CONSTRAINT [FK_lica_formuliar_uredi_lica_formuliar];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210905111808_AddedForeignKeyFormulqrUrediLica')
BEGIN
    DROP INDEX [IX_lica_formuliar_uredi_Id_formuliar] ON [dbo].[lica_formuliar_uredi];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210905111808_AddedForeignKeyFormulqrUrediLica')
BEGIN
    CREATE INDEX [IX_lica_formuliar_uredi_Id_L] ON [dbo].[lica_formuliar_uredi] ([Id_L]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210905111808_AddedForeignKeyFormulqrUrediLica')
BEGIN
    ALTER TABLE [dbo].[lica_formuliar_uredi] ADD CONSTRAINT [FK_lica_formuliar_uredi_lica] FOREIGN KEY ([Id_L]) REFERENCES [dbo].[lica] ([ID_L]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210905111808_AddedForeignKeyFormulqrUrediLica')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210905111808_AddedForeignKeyFormulqrUrediLica', N'5.0.8');
END;
GO

COMMIT;
GO

