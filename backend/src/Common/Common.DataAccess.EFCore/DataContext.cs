/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using Common.DataAccess.EFCore.Configuration;
using Common.DataAccess.EFCore.Configuration.System;
using Common.Entities;
using Common.Entities.Demontaz;
using Common.Entities.Fakturi;
using Common.Entities.Montaz;
using Common.Entities.Nomenclatures;
using Common.Entities.Spravki;
using Common.Entities.Views;
using Common.Entities.Views.Spravki;
using Microsoft.EntityFrameworkCore;

namespace Common.DataAccess.EFCore
{
    public class DataContext : DbContext
    {
        public ContextSession Session { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }
        public DbSet<UserPhoto> UserPhotos { get; set; }
        public DbSet<Settings> Settings { get; set; }

        public DbSet<DemDgvOlduredi> DemDgvOlduredis { get; set; }
        public DbSet<DemDogovor> DemDogovors { get; set; }
        public DbSet<DemPorychkaMain> DemPorychkaMain { get; set; }
        public DbSet<DemPorychka> DemPorychkas { get; set; }
        public DbSet<DemRajoni> DemRajonis { get; set; }
        public DbSet<DemPayments> DemPayments { get; set; }

        public DbSet<Lica> Licas { get; set; }
        public DbSet<LicaDogovor> LicaDogovors { get; set; }
        public DbSet<LicaDogovorUredi> LicaDogovorUredis { get; set; }
        public DbSet<LicaDogovorUrediArhiv> LicaDogovorUredisArhiv { get; set; }

        public DbSet<LicaDogovorOldUredi> LicaDogovorOldUredis { get; set; }
        public DbSet<LicaDokumenti> LicaDokumentis { get; set; }
        public DbSet<LicaFormuliar> LicaFormuliars { get; set; }
        public DbSet<LicaFormuliarUredi> LicaFormuliarUredis { get; set; }
        public DbSet<LicaFormuliarOldUredi> LicaFormuliarOldUredis { get; set; }
        public DbSet<LicaDopSporazumeniq> LicaDopSporazumeniq { get; set; }

        public DbSet<MonDogovor> MonDogovors { get; set; }
        public DbSet<MonDgvUredi> MonDgvUredis { get; set; }
        public DbSet<MonPorychkaMain> MonPorychkaMain { get; set; }
        public DbSet<MonPorychka> MonPorychkas { get; set; }
        public DbSet<MonRajoni> MonRajonis { get; set; }
        public DbSet<MonPayments> MonPayments { get; set; }
        public DbSet<Profilaktika> Profilaktika { get; set; }

        public DbSet<NJk> NJks { get; set; }
        public DbSet<NKmetstva> NKmetstvas { get; set; }
        public DbSet<NNmnObshti> NNmnObshtis { get; set; }
        public DbSet<NNsMestum> NNsMesta { get; set; }
        public DbSet<NRaioni> NRaionis { get; set; }
        public DbSet<NShablonF> NShablonFs { get; set; }
        public DbSet<NSpisykNmn> NSpisykNmns { get; set; }
        public DbSet<NStatusi> NStatusis { get; set; }
        public DbSet<NUlicii> NUliciis { get; set; }
        public DbSet<NSpravki> NSpravki { get; set; }
        public DbSet<NUredi> NUredi { get; set; }
        public DbSet<NKid> NKid { get; set; }
        public DbSet<NFp4Tablica3> NFp4Tablica3 { get; set; }
        public DbSet<NUrediBudget> NUrediBudget { get; set; }

        public DbSet<Obhvat> Obhvat { get; set; }
        public DbSet<UserObhvat> UserObhvat { get; set; }
        public DbSet<Firmi> Firmi { get; set; }
        public DbSet<LicaFormuliarFirma> LicaFormuliarFirma { get; set; }
        public DbSet<LicaFormuliarKolektiv> LicaFormuliarKolektiv { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<FacturiMain> FacturiMain { get; set; }
        public DbSet<FacturiRows> FacturiRows { get; set; }
        public DbSet<FacturiDokumenti> FacturiDokumenti { get; set; }

        public DbSet<NOditLog> NOditLog { get; set; }
        public DbSet<OditLog> OditLog { get; set; }
        public DbSet<ViewOpos> ViewOpos { get; set; }
        public DbSet<ViewAdres> ViewAdres { get; set; }
        public DbSet<ViewStatusi> ViewStatusi { get; set; }        
        public DbSet<Attachments> Attachments { get; set; }
        public DbSet<Sequnces> Sequnces { get; set; }
        public DbSet<ViewLicaDogovorUrediVid> ViewLicaDogovorUrediVid { get; set; }
        public DbSet<vwSpravka14> vwSpravka14 { get; set; }

        public DbSet<FiltriAdres> FiltriAdres { get; set; }
        public DbSet<FormCollectingInfo> FormCollectingInfo { get; set; }

        //views
        public DbSet<ViewFormulqr> ViewFormulqr { get; set; }
        public DbSet<ViewListFormulqr> ViewListFormulqr { get; set; }
        public DbSet<ViewPersons> ViewPersons { get; set; }
        public DbSet<ViewUser> ViewUser { get; set; }
        public DbSet<ViewLiceDogovor> ViewLiceDogovor { get; set; }
        public DbSet<ViewSpravka1> ViewSpravka1 { get; set; }
        public DbSet<ViewSpravka2> ViewSpravka2 { get; set; }
        public DbSet<ViewSpravka4> ViewSpravka4 { get; set; }
        public DbSet<ViewFirmiIzpalniteli> ViewFirmiIzpalniteli { get; set; }
        public DbSet<ViewFirmDogovor> ViewFirmDogovor { get; set; }
        public DbSet<ViewDogovorUredi> ViewDogovorUredi { get; set; }
        public DbSet<ViewOrder> ViewOrder { get; set; }
        public DbSet<ViewUrediOrder> ViewUrediOrder { get; set; }
        public DbSet<ViewMonOrderItem> ViewMonOrderItem { get; set; }
        public DbSet<ViewNUlici> ViewNUlici { get; set; }
        public DbSet<ViewDogovorPrint> ViewDogovorPrint { get; set; }
        public DbSet<ViewLica> ViewLica { get; set; }
        public DbSet<ViewLicaDocumenti> ViewLicaDocumenti { get; set; }
        public DbSet<ViewPersUrediOrder> ViewPersUrediOrder { get; set; }
        public DbSet<ViewOposPortret> ViewOposPortret { get; set; }
        public DbSet<ViewResult> ViewResult { get; set; }
        public DbSet<ViewRadiatoriZaPrekodirane> ViewRadiatoriZaPrekodirane { get; set; }
        public DbSet<ViewSpravka5> ViewSpravka5 { get; set; }
        public DbSet<ViewSpravka24> ViewSpravka24 { get; set; }
        public DbSet<ViewSpravka25> ViewSpravka25 { get; set; }
        public DbSet<ViewSpravka50> ViewSpravka50 { get; set; }
        public DbSet<ViewSpravka51> ViewSpravka51 { get; set; }
        public DbSet<ViewSpravka52> ViewSpravka52 { get; set; }
        public DbSet<ViewSpravka53> ViewSpravka53 { get; set; }
        public DbSet<ViewSpravka54> ViewSpravka54 { get; set; }
        public DbSet<ViewSpravka55> ViewSpravka55 { get; set; }
        public DbSet<ViewFiltriAdres> ViewFiltriAdres { get; set; }
        public DbSet<ViewSpravka60> ViewSpravka60 { get; set; }
        public DbSet<ViewSpravka70> ViewSpravka70 { get; set; }
        public DbSet<ViewSpravka78> ViewSpravka78 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
            modelBuilder.ApplyConfiguration(new UserRoleConfig());
            modelBuilder.ApplyConfiguration(new UserClaimConfig());
            modelBuilder.ApplyConfiguration(new UserPhotoConfig());
            modelBuilder.ApplyConfiguration(new SettingsConfig());
            modelBuilder.ApplyConfiguration(new ObhvatConfig());
            modelBuilder.ApplyConfiguration(new UserObhvatConfig());

            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<DemDgvOlduredi>(entity =>
            {
                entity.HasKey(e => e.IdSpDm)
                    .HasName("PK_olduredi_dgv_dm_ID_SP_DM");

                entity.ToTable("dem_dgv_olduredi");

                entity.Property(e => e.IdSpDm).HasColumnName("ID_SP_DM");

                entity.Property(e => e.EdCena)
                    .HasColumnType("decimal(7, 2)")
                    .HasColumnName("Ed_cena");

                entity.Property(e => e.IdFirmaDm).HasColumnName("Id_firma_dm");

                entity.Property(e => e.IdKn).HasColumnName("ID_kn");


                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StatusDs)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Status_DS")
                    .IsFixedLength(true);

                entity.Property(e => e.User)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFirmaDmNavigation)
                    .WithMany(p => p.DemDgvOlduredis)
                    .HasForeignKey(d => d.IdFirmaDm)
                    .HasConstraintName("FK_dem_dgv_olduredi_dem_dogovor");
            });

            modelBuilder.Entity<DemDogovor>(entity =>
            {
                entity.HasKey(e => e.IdFirmaDm)
                    .HasName("PK_dgv_za_demontaj_Id_firma_DM");

                entity.ToTable("dem_dogovor");

                entity.Property(e => e.IdFirmaDm).HasColumnName("Id_firma_DM");


                entity.Property(e => e.DataRegN)
                    .HasColumnType("date")
                    .HasColumnName("DataRegN");

                entity.Property(e => e.Koga)
                    .HasColumnType("datetime")
                    .HasColumnName("koga");

                entity.Property(e => e.NachalnaData)
                    .HasColumnType("date")
                    .HasColumnName("NachalnaData");

                entity.Property(e => e.NomDgVSudso)
                    .HasColumnName("Nom_dg_vSUDSO");

                entity.Property(e => e.ObshtSrokGrf)
                    .HasColumnName("SrokGrafik");

                entity.Property(e => e.ObshtaCenaBezDds)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("CenaBezDDS");

                entity.Property(e => e.ObshtaCenaSDds)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("CenaDDS");


                entity.Property(e => e.RegIndex)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Reg_Index");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StatusDm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS_DM")
                    .IsFixedLength(true);

                entity.Property(e => e.User)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("user");

                entity.HasOne(d => d.IdFirmaNavigation)
                     .WithMany(p => p.FirmiDogovorDeMontzj)
                     .HasForeignKey(d => d.IdFirma)
                     .HasConstraintName("FK_demon_dogovor_firmi");

            });

            modelBuilder.Entity<DemPorychkaMain>(entity =>
            {
                entity.HasKey(e => e.IdPorachkaMain)
                    .HasName("PK_demporychka_main_IDPorachka");

                entity.ToTable("dem_porychkamain");

                entity.Property(e => e.IdPorachkaMain)
                    .HasColumnName("IDPorachkamain");

                entity.Property(e => e.Data)
                    .HasColumnType("datetime")
                    .HasColumnName("Data");

                entity.Property(e => e.IdDogovorFirma)
                    .HasColumnName("IdDogovorFirma");

                entity.Property(e => e.User)
                            .HasMaxLength(30)
                            .HasColumnName("user");

                entity.Property(e => e.Koga)
                    .HasColumnType("datetime")
                    .HasColumnName("koga");

                entity.Property(e => e.Nomer)
                    .HasColumnName("Nomer");

                entity.Property(e => e.Status)
                    .HasMaxLength(1);


                entity.HasOne(d => d.IdDogFirmaNavigation)
                    .WithMany(p => p.DemPorychkaMain)
                    .HasForeignKey(d => d.IdDogovorFirma)
                    .HasConstraintName("FK_dem_porychkamain_dem_dogovor");

            });

            modelBuilder.Entity<DemPorychka>(entity =>
            {
                entity.HasKey(e => e.IdPorachkaBody)
                    .HasName("PK_oldporychka_dm_IDBody");

                entity.ToTable("dem_porychka");

                entity.Property(e => e.IdPorachkaBody)
                    .HasColumnName("IdPorachkaBody");

                entity.Property(e => e.Broi)
                    .HasColumnName("Broi");

                entity.Property(e => e.IdUred)
                    .HasColumnName("IdUred");

                entity.Property(e => e.IdDogovorLice)
                    .HasColumnName("IdDogovorLice");

                entity.Property(e => e.StatusG)
                     .HasMaxLength(1)
                     .IsUnicode(false)
                     .HasColumnName("StatusG")
                     .IsFixedLength(true);

                entity.Property(e => e.StatusM)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("StatusM")
                    .IsFixedLength(true);

                entity.Property(e => e.Status)
                    .HasMaxLength(1);

                entity.Property(e => e.DoChas)
                     .HasColumnType("varchar")
                     .HasMaxLength(50);

                entity.Property(e => e.Note)
                    .HasColumnType("varchar")
                    .HasMaxLength(500);

                entity.Property(e => e.Note2)
                    .HasColumnType("varchar")
                    .HasMaxLength(500);

                entity.Property(e => e.User)
                    .HasMaxLength(30)
                    .HasColumnName("user");

                entity.Property(e => e.Koga)
                    .HasColumnType("datetime")
                    .HasColumnName("koga");

                entity.HasOne(d => d.IdLiceDogovorNavigation)
                     .WithMany(p => p.DemPorychkas)
                     .HasForeignKey(d => d.IdDogovorLice)
                     .HasConstraintName("FK_dem_porychka_lice_dogovor");

                entity.HasOne(d => d.IdMainNavigation)
                    .WithMany(p => p.DemPorychki)
                    .HasForeignKey(d => d.IdPorachkaMain)
                    .HasConstraintName("FK_dem_porychkamain_dem_porychka");
            });

            modelBuilder.Entity<DemRajoni>(entity =>
            {
                entity.HasKey(e => e.IdRec)
                    .HasName("PK_demontaj_rajoni_ID_rec");

                entity.ToTable("dem_rajoni");

                entity.Property(e => e.IdRec).HasColumnName("ID_rec");

                entity.Property(e => e.Faza).HasColumnName("FAZA");

                entity.Property(e => e.IdFirmaDm).HasColumnName("ID_FIRMA_DM");

                entity.Property(e => e.Nkod)
                    .HasMaxLength(2)
                    .HasColumnName("NKOD");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdFirmaDmNavigation)
                    .WithMany(p => p.DemRajonis)
                    .HasForeignKey(d => d.IdFirmaDm)
                    .HasConstraintName("FK_dem_rajoni_dem_dogovor");
            });

            modelBuilder.Entity<DemPayments>(entity =>
            {
                entity.HasKey(e => e.IdRec)
                    .HasName("PK_demontaj_payments_ID_rec");

                entity.ToTable("dem_payments");

                entity.Property(e => e.IdRec).HasColumnName("ID_rec");

                entity.Property(e => e.IdFirmaDm).HasColumnName("ID_FIRMA_DM");

                entity.Property(e => e.SumaBezDds)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("SumaBezDDS");

                entity.Property(e => e.SumaSDds)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("SumaDDS");

                entity.HasOne(d => d.IdFirmaDmNavigation)
                    .WithMany(p => p.DemPayments)
                    .HasForeignKey(d => d.IdFirmaDm)
                    .HasConstraintName("FK_dem_payments_dem_dogovor");
            });


            modelBuilder.Entity<Lica>(entity =>
            {
                entity.HasKey(e => e.IdL)
                    .HasName("PK_lica_ID_L");

                entity.ToTable("lica");

                entity.Property(e => e.IdL)
                    .HasColumnName("ID_L");

                entity.Property(e => e.VLice)
                    .HasMaxLength(1)
                    .HasColumnName("v_lice")
                    .IsFixedLength(true);

                entity.Property(e => e.Status)
                    .HasMaxLength(1);

                entity.Property(e => e.Tochki1).HasColumnType("smallint");

                entity.Property(e => e.Tochki2).HasColumnType("smallint");

                entity.Property(e => e.Tochki3).HasColumnType("smallint");

                entity.Property(e => e.Tochki4).HasColumnType("smallint");

                entity.Property(e => e.Tochki5).HasColumnType("smallint");

                entity.Property(e => e.Tochki6).HasColumnType("smallint");

                entity.Property(e => e.Tochki7).HasColumnType("smallint");

                entity.Property(e => e.User)
                    .HasMaxLength(30)
                    .HasColumnName("user");
            });

            modelBuilder.Entity<LicaDogovor>(entity =>
            {
                entity.HasKey(e => e.IdDogL)
                    .HasName("PK_dogovor_lica_Id_dog_L");

                entity.ToTable("lica_dogovor");

                entity.Property(e => e.IdDogL).HasColumnName("Id_dog_L");

                entity.Property(e => e.DataRegN)
                    .HasColumnType("date")
                    .HasColumnName("Data_reg_N");

                entity.Property(e => e.IdL).HasColumnName("Id_L");

                entity.Property(e => e.Koga)
                    .HasColumnType("datetime")
                    .HasColumnName("koga");

                entity.Property(e => e.RegN)
                    .HasMaxLength(15)
                    .HasColumnName("Reg_N");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StatusDl)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Status_DL")
                    .IsFixedLength(true);

                entity.Property(e => e.User)
                    .HasMaxLength(128)
                    .HasColumnName("user");

                entity.Property(e => e.BrDopSp)
                    .HasColumnType("varchar")
                    .HasMaxLength(250)
                    .HasColumnName("BrDopSp");

                entity.Property(e => e.Comentar)
                    .HasColumnType("varchar")
                    .HasMaxLength(2000)
                    .HasColumnName("Comentar");


                entity.HasOne(d => d.IdLNavigation)
                    .WithMany(p => p.LicaDogovors)
                    .HasForeignKey(d => d.IdL)
                    .HasConstraintName("FK_lica_dogovor_lica");
            });


            modelBuilder.Entity<LicaDogovorUredi>(entity =>
            {
                entity.HasKey(e => e.IdUredDg)
                    .HasName("PK_uredi_dg_l_Id_Ured_DG");

                entity.ToTable("lica_dogovor_uredi");

                entity.Property(e => e.IdUredDg).HasColumnName("Id_Ured_DG");

                entity.Property(e => e.IdDogL).HasColumnName("ID_DOG_L");

                entity.Property(e => e.IdKt).HasColumnName("Id_KT");

                entity.Property(e => e.IdL).HasColumnName("Id_L");

                entity.Property(e => e.Koga)
                    .HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StatusU)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Status_U")
                    .IsFixedLength(true);

                entity.Property(e => e.User)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("user");

                entity.HasOne(d => d.IdDogLNavigation)
                    .WithMany(p => p.LicaDogovorUredis)
                    .HasForeignKey(d => d.IdDogL)
                    .HasConstraintName("FK_lica_dogovor_uredi_lica_dogovor");
            });

            modelBuilder.Entity<LicaDogovorUrediArhiv>(entity =>
            {
                entity.HasKey(e => e.IdUredDg)
                    .HasName("PK_arh_uredi_dg_l_Id_Ured_DG");

                entity.ToTable("lica_dogovor_uredi_arhiv");

                entity.Property(e => e.IdUredDg).HasColumnName("Id_Ured_DG");

                entity.Property(e => e.IdDogL).HasColumnName("ID_DOG_L");

                entity.Property(e => e.IdKt).HasColumnName("Id_KT");

                entity.Property(e => e.IdL).HasColumnName("Id_L");

                entity.Property(e => e.Koga)
                    .HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StatusU)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Status_U")
                    .IsFixedLength(true);

                entity.Property(e => e.User)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("user");

                entity.HasOne(d => d.IdDogLNavigation)
                    .WithMany(p => p.LicaDogovorUredisArhiv)
                    .HasForeignKey(d => d.IdDogL)
                    .HasConstraintName("FK_lica_dogovor_uredi_arhiv_lica_dogovor");
            });

            modelBuilder.Entity<LicaDogovorOldUredi>(entity =>
            {
                entity.HasKey(e => e.IdOldurediDgl)
                    .HasName("PK_uredi_dg_l_Id_OldUred_DG");

                entity.ToTable("lica_dogovor_olduredi");

                entity.Property(e => e.IdOldurediDgl).HasColumnName("Id_Ured_DG");

                entity.Property(e => e.IdDogL).HasColumnName("ID_DOG_L");

                entity.Property(e => e.IdKt).HasColumnName("Id_KT");

                entity.Property(e => e.IdL).HasColumnName("Id_L");

                entity.Property(e => e.Koga)
                    .HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StatusDU)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Status_DU")
                    .IsFixedLength(true);

                entity.Property(e => e.User)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("user");

                entity.HasOne(d => d.IdDogLNavigation)
                    .WithMany(p => p.LicaDogovorOldUredis)
                    .HasForeignKey(d => d.IdDogL)
                    .HasConstraintName("FK_lica_dogovor_olduredi_lica_dogovor");
            });

            modelBuilder.Entity<LicaDokumenti>(entity =>
            {
                entity.HasKey(e => e.IdDok)
                    .HasName("PK_dokumenti_Id_Dok");

                entity.ToTable("lica_dokumenti");

                entity.Property(e => e.IdDok).HasColumnName("Id_Dok");

                entity.Property(e => e.DocType).HasColumnName("DocType");

                entity.Property(e => e.IdL).HasColumnName("Id_L");

                entity.Property(e => e.Koga)
                    .HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FileName)
                    .HasMaxLength(200);

                entity.Property(e => e.SavedFileName)
                    .HasMaxLength(200);

                entity.Property(e => e.DocDescription)
                    .HasMaxLength(500)
                    .HasColumnName("DocDescription");
 
                entity.Property(e => e.User).HasMaxLength(128);

                entity.HasOne(d => d.IdLNavigation)
                    .WithMany(p => p.LicaDokumentis)
                    .HasForeignKey(d => d.IdL)
                    .HasConstraintName("FK_lica_dokumenti_lica");
            });

            modelBuilder.Entity<LicaFormuliar>(entity =>
            {
                entity.HasKey(e => e.IdFormuliar)
                    .HasName("PK_formuliar_ID_Formuliar");

                entity.ToTable("lica_formuliar");

                entity.Property(e => e.IdFormuliar).HasColumnName("ID_Formuliar");

                entity.Property(e => e.Faza).HasColumnName("faza");

                entity.Property(e => e.IdL).HasColumnName("Id_L");

                entity.Property(e => e.RegDate)
                    .HasPrecision(0)
                    .HasColumnName("Reg_date");

                entity.Property(e => e.V211)
                     .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.V212)
                     .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.V213)
                     .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.V391)
                       .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.V392)
                       .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.V401)
                       .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.V402)
                       .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.V421)
                       .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.V422)
                       .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.V423)
                       .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StatusF)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Status_F")
                    .IsFixedLength(true);

                entity.Property(e => e.UNom)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("U_nom");

                entity.Property(e => e.comentar)
                    .HasColumnType("varchar")
                    .HasMaxLength(2000)
                    .HasColumnName("Comentar");

                entity.HasOne(d => d.IdLNavigation)
                    .WithMany(p => p.LicaFormuliars)
                    .HasForeignKey(d => d.IdL)
                    .HasConstraintName("FK_lica_formuliar_lica");
            });

 
            modelBuilder.Entity<LicaFormuliarUredi>(entity =>
            {
                entity.HasKey(e => e.IdUredF)
                    .HasName("PK_uredi_f_Id_ured_F");

                entity.ToTable("lica_formuliar_uredi");

                entity.Property(e => e.IdUredF).HasColumnName("Id_ured_F");

                entity.Property(e => e.IdFormuliar).HasColumnName("Id_formuliar");

                entity.Property(e => e.IdKt).HasColumnName("Id_KT");

                entity.Property(e => e.IdL).HasColumnName("Id_L");

                entity.Property(e => e.Koga)
                    .HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StatusU)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Status_U")
                    .IsFixedLength(true);

                entity.Property(e => e.User).HasColumnName("user");

                entity.HasOne(d => d.IdLNavigation)
                    .WithMany(p => p.LicaFormuliarUredis)
                    .HasForeignKey(d => d.IdL)
                    .HasConstraintName("FK_lica_formuliar_uredi_lica");
            });

            modelBuilder.Entity<MonDgvUredi>(entity =>
            {
                entity.HasKey(e => e.IdSpDost)
                    .HasName("PK_uredi_dgv_dost_Id_Sp_dost");

                entity.ToTable("mon_dgv_uredi");

                entity.Property(e => e.IdSpDost).HasColumnName("Id_Sp_dost");

                entity.Property(e => e.EdCena)
                    .HasColumnType("decimal(7, 2)")
                    .HasColumnName("Ed_cena");

                entity.Property(e => e.IdFirmaMn)
                    .HasColumnName("IdFirmaMn");

                entity.Property(e => e.IdKn).HasColumnName("ID_kn");

                entity.Property(e => e.Koga)
                    .HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StatusDs)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Status_DS")
                    .IsFixedLength(true);

                entity.Property(e => e.User).HasMaxLength(128);

                entity.Property(e => e.Model)
                        .HasColumnType("varchar")
                        .HasMaxLength(30);

                entity.HasOne(d => d.IdFirmaMnNavigation)
                    .WithMany(p => p.MonDgvUredis)
                    .HasForeignKey(d => d.IdFirmaMn)
                    .HasConstraintName("FK_mon_dgv_uredi_mon_dogovor");
            });

            modelBuilder.Entity<MonDogovor>(entity =>
            {
                entity.HasKey(e => e.IdFirmaMn)
                    .HasName("PK_dgv_dostavchici_ID_FIRMA");

                entity.ToTable("mon_dogovor");

                entity.Property(e => e.IdFirma)
                    .HasColumnName("IdFirma");


                entity.Property(e => e.DataRegN)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_reg_N");

                entity.Property(e => e.Koga)
                    .HasColumnType("datetime")
                    .HasColumnName("koga");

                entity.Property(e => e.NachalnaData)
                    .HasColumnType("datetime")
                    .HasColumnName("NachalnaData");

                entity.Property(e => e.NomDgVSudso)
                    .HasColumnName("Nom_dg_vSUDSO");

                entity.Property(e => e.ObshtSrokGrf)
                    .HasColumnName("SrokGrafik");

                entity.Property(e => e.ObshtaCenaBezDds)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("CenaBezDDS");

                entity.Property(e => e.ObshtaCenaSDds)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("CenaDDS");

                entity.Property(e => e.RegIndex)
                    .HasMaxLength(15)
                    .HasColumnName("Reg_Index");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StatusDm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS_DM")
                    .IsFixedLength(true);

                entity.Property(e => e.User)
                    .HasMaxLength(128)
                    .HasColumnName("user");

                entity.HasOne(d => d.IdFirmaNavigation)
                     .WithMany(p => p.FirmiDogovorMontzj)
                     .HasForeignKey(d => d.IdFirma)
                     .HasConstraintName("FK_mon_dogovor_firmi");

            });

            modelBuilder.Entity<MonPorychkaMain>(entity =>
            {
                entity.HasKey(e => e.IdPorachkaMain)
                    .HasName("PK_porychka_main_IDPorachka");

                entity.ToTable("mon_porychkamain");

                entity.Property(e => e.IdPorachkaMain)
                    .HasColumnName("IDPorachkamain");

                entity.Property(e => e.Data)
                    .HasColumnType("date")
                    .HasColumnName("Data");

                entity.Property(e => e.IdDogovorFirma)
                    .HasColumnName("IdDogovorFirma");

                entity.Property(e => e.User)
                            .HasMaxLength(30)
                            .HasColumnName("user");

                entity.Property(e => e.Koga)
                    .HasColumnType("datetime")
                    .HasColumnName("koga");

                entity.Property(e => e.Nomer)
                    .HasColumnName("Nomer");

                entity.Property(e => e.Status)
                    .HasMaxLength(1);

                entity.Property(e => e.StartData)
                     .HasColumnType("datetime")
                     .HasColumnName("StartData");

                entity.Property(e => e.EndData)
                    .HasColumnType("datetime")
                    .HasColumnName("EndData");

                entity.Property(e => e.ARaion)
                    .HasColumnType("varchar")
                    .HasMaxLength(5);

                entity.HasOne(d => d.IdDogFirmaNavigation)
                    .WithMany(p => p.MonPorychkaMain)
                    .HasForeignKey(d => d.IdDogovorFirma)
                    .HasConstraintName("FK_mon_porychkamain_mon_dogovor");

            });


            modelBuilder.Entity<MonPorychka>(entity =>
            {
                entity.HasKey(e => e.IdPorachkaBody)
                    .HasName("PK_porychka_IDPorachkaBody");

                entity.ToTable("mon_porychka");

                entity.Property(e => e.IdPorachkaBody)
                    .HasColumnName("IDPorachkaBody");


                entity.Property(e => e.IdPorachkaMain)
                    .HasColumnName("IdPorachkaMain");

                entity.Property(e => e.IdDogovorLice)
                    .HasColumnName("IdDogovorLice");

                entity.Property(e => e.IdUred)
                    .HasColumnName("IdUred");

                entity.Property(e => e.Broi)
                    .HasColumnName("Broi");

                entity.Property(e => e.Koga)
                    .HasColumnType("datetime")
                    .HasColumnName("koga");

                entity.Property(e => e.Status)
                    .HasMaxLength(1);

                entity.Property(e => e.StatusG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("StatusG")
                    .IsFixedLength(true);

                entity.Property(e => e.StatusM)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("StatusM")
                    .IsFixedLength(true);

                entity.Property(e => e.DoData)
                    .HasColumnType("datetime")
                    .HasColumnName("DoData");

                entity.Property(e => e.MonData)
                    .HasColumnType("datetime")
                    .HasColumnName("MonData");

                entity.Property(e => e.FabrNomer)
                    .HasColumnType("varchar")
                    .HasMaxLength(500)
                    .HasColumnName("FabrNomer");

                entity.Property(e => e.GarCard)
                    .HasColumnType("varchar")
                    .HasMaxLength(500)
                    .HasColumnName("GaranciaCard");

                entity.Property(e => e.GarCardData)
                    .HasColumnType("datetime")
                    .HasColumnName("GaranciaData");

                entity.Property(e => e.ProtNomer)
                    .HasColumnType("varchar")
                    .HasMaxLength(500)
                    .HasColumnName("ProtNomer");

                entity.Property(e => e.DoChas)
                    .HasColumnType("varchar")
                    .HasMaxLength(50);

                entity.Property(e => e.Model)
                    .HasColumnType("varchar")
                    .HasMaxLength(500);

                entity.Property(e => e.Note)
                    .HasColumnType("varchar")
                    .HasMaxLength(500);

                entity.Property(e => e.Note2)
                    .HasColumnType("varchar")
                    .HasMaxLength(500);

                entity.Property(e => e.ProtData)
                    .HasColumnType("date")
                    .HasColumnName("ProtData");

                entity.Property(e => e.User)
                    .HasMaxLength(30)
                    .HasColumnName("user");

                entity.HasOne(d => d.IdMainNavigation)
                    .WithMany(p => p.MonPorychki)
                    .HasForeignKey(d => d.IdPorachkaMain)
                    .HasConstraintName("FK_mon_porychka_mon_porychka_main");

                entity.HasOne(d => d.IdLNavigation)
                    .WithMany(p => p.MonPorychkas)
                    .HasForeignKey(d => d.IdDogovorLice)
                    .HasConstraintName("FK_mon_porychka_dogovor_lica");
            });

            modelBuilder.Entity<MonRajoni>(entity =>
            {
                entity.HasKey(e => e.IdRec)
                    .HasName("PK_dostavchik_rajoni_ID_rec");

                entity.ToTable("mon_rajoni");

                entity.Property(e => e.IdRec).HasColumnName("ID_rec");

                entity.Property(e => e.Faza).HasColumnName("FAZA");

                entity.Property(e => e.IdFirmaMn).HasColumnName("IdFirmaMn");

                entity.Property(e => e.Nkod)
                    .HasMaxLength(2)
                    .HasColumnName("NKOD");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdFirmaMnNavigation)
                    .WithMany(p => p.MonRajonis)
                    .HasForeignKey(d => d.IdFirmaMn)
                    .HasConstraintName("FK_mon_rajoni_mon_dogovor");
            });

            modelBuilder.Entity<MonPayments>(entity =>
            {
                entity.HasKey(e => e.IdRec)
                    .HasName("PK_montaj_payments_ID_rec");

                entity.ToTable("mon_payments");

                entity.Property(e => e.IdRec).HasColumnName("ID_rec");

                entity.Property(e => e.IdFirmaMn).HasColumnName("ID_FIRMA_MN");

                entity.Property(e => e.SumaBezDds)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("SumaBezDDS");

                entity.Property(e => e.SumaSDds)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("SumaDDS");

                entity.HasOne(d => d.IdFirmaMnNavigation)
                    .WithMany(p => p.MonPayments)
                    .HasForeignKey(d => d.IdFirmaMn)
                    .HasConstraintName("FK_mon_payments_dem_dogovor");
            });

            modelBuilder.Entity<Profilaktika>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_profilaktika_Idt");

                entity.ToTable("mon_profilaktika");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.IdUred).HasColumnName("IdUred");

                entity.Property(e => e.Koga)
                    .HasColumnType("datetime");

                entity.Property(e => e.Status_PF)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Status_PF")
                    .IsFixedLength(true);

                entity.Property(e => e.User).HasMaxLength(128);

                entity.Property(e => e.PNomer)
                     .HasMaxLength(99999)
                     .HasColumnName("PNomer")
                     .IsFixedLength(true);

                entity.Property(e => e.IdL).HasColumnName("IdL");
                entity.Property(e => e.Period)
                        .HasMaxLength(5)
                        .HasColumnName("Period");

                entity.HasOne(d => d.IdMainNavigation)
                    .WithMany(p => p.Profilaktikas)
                    .HasForeignKey(d => d.IdPorachkaMain)
                    .HasConstraintName("FK_mon_profilaktika_porychka_main");

                entity.HasOne(d => d.IdLNavigation)
                    .WithMany(p => p.Profilaktika)
                    .HasForeignKey(d => d.IdDogovorLice)
                    .HasConstraintName("FK_mon_profilaktika_lica_dogovor");

            });

            //nomenklaturi
            
            modelBuilder.Entity<NSpravki>(entity =>
            {
                entity.ToTable("n_spravki");

                entity.Property(e => e.nkod)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("nkod");
            });

            modelBuilder.Entity<NJk>(entity =>
            {
                entity.HasKey(e => e.Nkod)
                    .HasName("PK_n_jk_nkod");

                entity.ToTable("n_jk");

                entity.Property(e => e.Nkod)
                    .HasMaxLength(5)
                    .HasColumnName("nkod");

                entity.Property(e => e.Nime)
                    .HasMaxLength(45)
                    .HasColumnName("nime");
            });

            modelBuilder.Entity<NKmetstva>(entity =>
            {
                entity.HasKey(e => e.Nkod)
                    .HasName("PK_n_kmetstva_nkod");

                entity.ToTable("n_kmetstva");

                entity.Property(e => e.Nkod)
                    .HasMaxLength(10)
                    .HasColumnName("nkod");

                entity.Property(e => e.Nime)
                    .HasMaxLength(45)
                    .HasColumnName("nime");
            });

            modelBuilder.Entity<NNmnObshti>(entity =>
            {
                entity.HasKey(e => e.IdKn)
                    .HasName("PK_n_nmn_obshti_id_kn");

                entity.ToTable("n_nmn_obshti");

                entity.Property(e => e.IdKn)
                    .HasColumnName("id_kn");

                entity.Property(e => e.Faza)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.KodNmn)
                    .HasMaxLength(2)
                    .HasColumnName("kod_nmn");

                entity.Property(e => e.KodPozicia)
                    .HasMaxLength(4)
                    .HasColumnName("Kod_pozicia");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .IsFixedLength(true);

                entity.Property(e => e.Text).HasMaxLength(70);

                entity.Property(e => e.Vypros)
                    .HasMaxLength(6)
                    .HasColumnName("vypros");

                entity.Property(e => e.Text)
                     .HasMaxLength(200)
                     .HasColumnName("Text");

            });

            modelBuilder.Entity<NNsMestum>(entity =>
            {
                entity.HasKey(e => e.Nkod)
                    .HasName("PK_n_ns_mesta_nkod");

                entity.ToTable("n_ns_mesta");

                entity.Property(e => e.Nkod)
                    .HasMaxLength(5)
                    .HasColumnName("nkod");

                entity.Property(e => e.Kmetstvo).HasMaxLength(8);

                entity.Property(e => e.KodNmn)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("kod_nmn");

                entity.Property(e => e.Nime)
                    .HasMaxLength(45)
                    .HasColumnName("nime");
            });

            modelBuilder.Entity<NRaioni>(entity =>
            {
                entity.HasKey(e => e.Nkod)
                    .HasName("PK_n_raioni_nkod");

                entity.ToTable("n_raioni");

                entity.Property(e => e.Nime)
                    .HasMaxLength(45)
                    .HasColumnName("NIME");

                entity.Property(e => e.Nkod)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("NKOD");

            });

            modelBuilder.Entity<NShablonF>(entity =>
            {
                entity.HasKey(e => e.IdN)
                    .HasName("PK_shablon_f_ID_N");

                entity.ToTable("n_shablon_f");

                entity.Property(e => e.IdN)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_N");

                entity.Property(e => e.Faza)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TblVBd)
                    .HasMaxLength(2)
                    .HasColumnName("TBL_vBD");

                entity.Property(e => e.Text).HasMaxLength(60);

                entity.Property(e => e.Vypros).HasMaxLength(5);
            });

            modelBuilder.Entity<NSpisykNmn>(entity =>
            {
                entity.HasKey(e => e.KodNmn)
                    .HasName("PK_n_spisyk_nmn_kod_nmn");

                entity.ToTable("n_spisyk_nmn");

                entity.Property(e => e.KodNmn)
                    .HasMaxLength(2)
                    .HasColumnName("kod_nmn");

                entity.Property(e => e.Ime).HasMaxLength(40);

                entity.Property(e => e.Komentar).HasMaxLength(40);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TablicaVBazata)
                    .HasMaxLength(30)
                    .HasColumnName("Tablica_vBazata");

                entity.Property(e => e.Vypros).HasMaxLength(6);
            });

            modelBuilder.Entity<NStatusi>(entity =>
            {
                entity.HasKey(e => e.IdSt)
                    .HasName("PK_n_statusi_Id_St");

                entity.ToTable("n_statusi");

                entity.Property(e => e.IdSt).HasColumnName("Id_St");

                entity.Property(e => e.KodNmn)
                    .HasMaxLength(2)
                    .HasColumnName("kod_nmn");

                entity.Property(e => e.Komentar).HasMaxLength(60);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StatusCode)
                    .HasMaxLength(2)
                    .HasColumnName("Status_Code");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(10)
                    .HasColumnName("Status_name");

                entity.Property(e => e.TableName)
                    .HasMaxLength(40)
                    .HasColumnName("Table_name");

                entity.Property(e => e.Text).HasMaxLength(30);
            });

            modelBuilder.Entity<NUlicii>(entity =>
            {
                entity.HasKey(e => e.Nkod)
                    .HasName("PK_n_ulicii_nkod");

                entity.ToTable("n_ulicii");

                entity.Property(e => e.Nkod)
                    .HasMaxLength(5)
                    .HasColumnName("nkod");

                entity.Property(e => e.KodNmn)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("kod_nmn");

                entity.Property(e => e.Nime)
                    .HasMaxLength(50)
                    .HasColumnName("nime");

                entity.Property(e => e.WnasmNkod)
                    .HasMaxLength(5)
                    .HasColumnName("wnasm_nkod");

                entity.Property(e => e.WnuliNkod)
                    .HasMaxLength(5)
                    .HasColumnName("wnuli_nkod");
            });

            modelBuilder.Entity<NFp4Tablica3>(entity =>
            {
                entity.Property(e => e.Id)
                  .ValueGeneratedNever()
                  .HasColumnName("ID");

                entity.HasKey(e => e.Id)
                    .HasName("PK_n_fp4tablica3_Id");

                entity.ToTable("n_fp4_tablica3");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Nime)
                    .HasMaxLength(50)
                    .HasColumnName("nime");

                entity.Property(e => e.Koeficient)
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

            });


            modelBuilder.Entity<Firmi>(entity =>
            {
                entity.HasKey(e => e.IdFirma)
                    .HasName("PK_firmi_IDFirma");

                entity.ToTable("firmi");
            });

            modelBuilder.Entity<LicaFormuliarFirma>(entity =>
            {
                entity.ToTable("lica_formuliar_firma");

                entity.HasOne(d => d.IdLNavigation)
                      .WithMany(p => p.LicaFormuliarFirma)
                      .HasForeignKey(d => d.IdL)
                      .HasConstraintName("FK_lica_formuliar_firma_lica");

            });

            modelBuilder.Entity<LicaFormuliarKolektiv>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_lica_formuliar_kolektiv_Id");

                entity.ToTable("lica_formuliar_kolektiv");

                entity.Property(e => e.ARaion)
                    .HasMaxLength(5)
                    .HasColumnName("A_Raion");

                entity.Property(e => e.Ap)
                    .HasMaxLength(20)
                    .HasColumnName("AP");

                entity.Property(e => e.Blok)
                     .HasMaxLength(10);

                entity.Property(e => e.DataIzdavane)
                    .HasColumnType("date")
                    .HasColumnName("Data_izdavane");

                entity.Property(e => e.EMail)
                    .HasMaxLength(100)
                    .HasColumnName("e_mail");

                entity.Property(e => e.Etaj)
                    .HasMaxLength(50)
                    .HasColumnName("etaj");

                entity.Property(e => e.Ident)
                    .HasMaxLength(10)
                    .HasColumnName("IDENT");

                entity.Property(e => e.Ime)
                    .HasMaxLength(120)
                    .HasColumnName("IME");

                entity.Property(e => e.Jk)
                    .HasMaxLength(5)
                    .HasColumnName("JK");

                entity.Property(e => e.Koga)
                    .HasColumnType("datetime")
                    .HasColumnName("koga");

                entity.Property(e => e.Kv)
                    .HasMaxLength(5)
                    .HasColumnName("KV");

                entity.Property(e => e.NLk)
                    .HasMaxLength(30)
                    .HasColumnName("N_LK");

                entity.Property(e => e.Nm)
                    .HasMaxLength(5)
                    .HasColumnName("NM");

                entity.Property(e => e.Nomer)
                    .HasMaxLength(35);

                entity.Property(e => e.Pk)
                    .HasMaxLength(15)
                    .HasColumnName("PK");

                entity.Property(e => e.Tel)
                    .HasMaxLength(50)
                    .HasColumnName("tel");

                entity.Property(e => e.Ul)
                    .HasMaxLength(5)
                    .HasColumnName("UL");

                entity.Property(e => e.VIdent)
                    .HasMaxLength(1)
                    .HasColumnName("v_ident");

                entity.Property(e => e.Vh)
                    .HasMaxLength(10)
                    .HasColumnName("vh");

                entity.HasOne(d => d.IdLNavigation)
                      .WithMany(p => p.LicaFormuliarKolektiv)
                      .HasForeignKey(d => d.IdL)
                      .HasConstraintName("FK_lica_formuliar_kolektiv_lica");
            });

            
            modelBuilder.Entity<NUredi>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_n_uredi_id");

                entity.ToTable("n_uredi");

                entity.Property(e => e.Nkod)
                    .HasMaxLength(4)
                    .HasColumnName("nkod");

                entity.Property(e => e.Nime)
                    .HasMaxLength(200)
                    .HasColumnName("nime");
            });

            modelBuilder.Entity<NUrediBudget>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_n_uredi_budget_id");

                entity.ToTable("n_uredi_budget");

                entity.Property(e => e.Quantity)
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdMainNavigation)
                               .WithMany(p => p.NUredisBudget)
                               .HasForeignKey(d => d.Id)
                               .HasConstraintName("FK_nuredi_budget_nuredi");
            });

            modelBuilder.Entity<NKid>(entity =>
            {
                entity.HasKey(e => e.Nkod)
                    .HasName("PK_n_kid_id");

                entity.ToTable("n_kid");

                entity.Property(e => e.Nkod)
                    .HasMaxLength(4)
                    .HasColumnName("nkod");

                entity.Property(e => e.Nime)
                    .HasMaxLength(200)
                    .HasColumnName("nime");
            });

            modelBuilder.Entity<LicaFormuliarOldUredi>(entity =>
            {
                entity.HasKey(e => e.IdUredF)
                    .HasName("PK_olduredi_f_Id_ured_F");

                entity.ToTable("lica_formuliar_olduredi");

                entity.Property(e => e.IdUredF).HasColumnName("Id_ured_F");

                entity.Property(e => e.IdFormuliar).HasColumnName("Id_formuliar");

                entity.Property(e => e.IdKt).HasColumnName("Id_KT");

                entity.Property(e => e.IdL).HasColumnName("Id_L");

                entity.Property(e => e.Koga)
                    .HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StatusU)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Status_U")
                    .IsFixedLength(true);

                entity.Property(e => e.User).HasColumnName("user");

                entity.HasOne(d => d.IdLNavigation)
                    .WithMany(p => p.LicaFormuliarOldUredis)
                    .HasForeignKey(d => d.IdL)
                    .HasConstraintName("FK_lica_formuliar_olduredi_lica");
            });


            modelBuilder.Entity<FacturiMain>(entity =>
            {
                entity.ToTable("Facturi_Main");

                entity.HasKey(e => e.IdFactura)
                    .HasName("PK_factura_main_IdFactura");

                entity.Property(e => e.FacNomer)
                      .HasColumnType("varchar")
                      .HasMaxLength(30);

                entity.Property(e => e.Status)
                    .HasMaxLength(1);

                entity.Property(e => e.FacData)
                     .HasColumnType("datetime");

                entity.Property(e => e.Suma)
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.DDS)
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdFirmaNavigation)
                    .WithMany(p => p.FirmiFacturiMain)
                    .HasForeignKey(d => d.IdFirma)
                    .HasConstraintName("FK_facturi_main_firmi");

            });


            modelBuilder.Entity<FacturiRows>(entity =>
            {
                entity.ToTable("Facturi_Rows");

                entity.HasKey(e => e.IdRow)
                    .HasName("PK_facturirows_IdRow");

                entity.Property(e => e.Model)
                      .HasColumnType("varchar")
                      .HasMaxLength(30);

                entity.Property(e => e.EdCena)
                    .HasColumnType("decimal(7, 2)")
                    .HasColumnName("Ed_cena");

                entity.Property(e => e.Suma)
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Status)
                    .HasMaxLength(1);

                entity.HasOne(d => d.IdFacturaMainNavigation)
                    .WithMany(s => s.FacturiRowsSet)
                    .HasForeignKey(d => d.IdFactura)
                    .HasConstraintName("FK_factura_rows_factura_main");
            });

            modelBuilder.Entity<FacturiDokumenti>(entity =>
            {
                entity.HasKey(e => e.IdDok)
                    .HasName("PK_fakturi_dok_Id_Dok");

                entity.ToTable("facturi_dokumenti");

                entity.Property(e => e.IdDok).HasColumnName("Id_Dok");

                entity.Property(e => e.DocType).HasColumnName("DocType");

                entity.Property(e => e.IdFactura).HasColumnName("IdFactura");

                entity.Property(e => e.Koga)
                    .HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FileName)
                    .HasMaxLength(200);

                entity.Property(e => e.SavedFileName)
                    .HasMaxLength(200);

                entity.Property(e => e.DocDescription)
                    .HasMaxLength(500)
                    .HasColumnName("DocDescription");

                entity.Property(e => e.User).HasMaxLength(128);

                entity.HasOne(d => d.IdFacturaMainNavigation)
                    .WithMany(p => p.FacturiDocsSet)
                    .HasForeignKey(d => d.IdFactura)
                    .HasConstraintName("FK_factura_docs_factura_main");
            });

            modelBuilder.Entity<NOditLog>(entity =>
            {
                entity.ToTable("N_odit_log");

                entity.HasKey(e => e.Id)
                    .HasName("PK_noditlog_Id");

                entity.Property(e => e.Text)
                      .HasColumnType("varchar")
                      .HasMaxLength(100);
            });

            modelBuilder.Entity<OditLog>(entity =>
            {
                entity.ToTable("odit_log");

                entity.HasKey(e => e.Id)
                    .HasName("PK_oditlog_Id");

                entity.Property(e => e.User)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Text)
                      .HasColumnType("varchar")
                      .HasMaxLength(100);
            });


            modelBuilder.Entity<Attachments>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_attachments_Id");

                entity.ToTable("Attachments");

                entity.Property(e => e.IdDog).HasColumnName("IdDog");

                entity.Property(e => e.DocType).HasColumnName("DocType");

                entity.Property(e => e.Koga)
                    .HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FileName)
                    .HasMaxLength(200);

                entity.Property(e => e.SavedFileName)
                    .HasMaxLength(200);

                entity.Property(e => e.DocDescription)
                    .HasMaxLength(500);

                entity.Property(e => e.FileName)
                    .HasMaxLength(500);

                entity.Property(e => e.SavedFileName)
                    .HasMaxLength(500);

                entity.Property(e => e.User).HasMaxLength(128);

            });

            modelBuilder.Entity<Sequnces>(entity =>
            {
                entity.Property(e => e.seqname)
                    .IsRequired(true)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasKey(e => e.seqname)
                    .HasName("PK_sequences");

                entity.ToTable("Sequences");

            });


            modelBuilder.Entity<LicaDopSporazumeniq>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_licadopsporaz_Id_Dok");

                entity.ToTable("lica_dopsporazumeniq");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.IdL).HasColumnName("Id_L");

                entity.Property(e => e.IdDopSp).HasColumnName("IdDopSp");

                entity.Property(e => e.RegNomer)
                    .HasMaxLength(200);

                entity.Property(e => e.Komentar)
                    .HasMaxLength(200);

                entity.Property(e => e.User)
                    .HasMaxLength(128);

                entity.Property(e => e.Koga)
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdLNavigation)
                    .WithMany(p => p.LicaDopSporazumeniq)
                    .HasForeignKey(d => d.IdL)
                    .HasConstraintName("FK_lica_dopsporazumeniq_lica");
            });


            modelBuilder.Entity<FiltriAdres>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_filtri_adress_Id");

                entity.ToTable("filtri_adresi");

                entity.Property(e => e.tip)
                    .HasColumnType("smallint")
                    .HasColumnName("Tip");

                entity.Property(e => e.ARaion)
                    .HasMaxLength(5)
                    .HasColumnName("A_Raion");

                entity.Property(e => e.Ap)
                    .HasMaxLength(20)
                    .HasColumnName("AP");

                entity.Property(e => e.Blok)
                     .HasMaxLength(10);

                entity.Property(e => e.Etaj)
                    .HasMaxLength(50)
                    .HasColumnName("etaj");

                entity.Property(e => e.Jk)
                    .HasMaxLength(5)
                    .HasColumnName("JK");

                entity.Property(e => e.Kv)
                    .HasMaxLength(5)
                    .HasColumnName("KV");

                entity.Property(e => e.Nm)
                    .HasMaxLength(5)
                    .HasColumnName("NM");

                entity.Property(e => e.Nomer)
                    .HasMaxLength(35);

                entity.Property(e => e.Pk)
                    .HasMaxLength(15)
                    .HasColumnName("PK");

                entity.Property(e => e.Ul)
                    .HasMaxLength(5)
                    .HasColumnName("UL");

                entity.Property(e => e.Vh)
                    .HasMaxLength(10)
                    .HasColumnName("vh");

            });

            modelBuilder.Entity<FormCollectingInfo>(entity =>
            {
                entity.ToTable("form_collecting_info");

                entity.HasKey(e => e.Id)
                  .HasName("PK_form_collecting_info_Id");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Prezime)
                    .HasMaxLength(50);

                entity.Property(e => e.Familiq)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.v1)
                    .IsRequired()
                    .HasColumnType("smallint")
                    .HasColumnName("v1");

                entity.Property(e => e.v101)
                    .IsRequired()
                    .HasColumnType("smallint")
                    .HasColumnName("v101");

                entity.Property(e => e.v2)
                    .IsRequired()
                    .HasColumnType("smallint")
                    .HasColumnName("v2");

                entity.Property(e => e.v201)
                    .IsRequired()
                    .HasColumnType("smallint")
                    .HasColumnName("v201");

                entity.Property(e => e.ARaion)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("A_Raion");

                entity.Property(e => e.Ap)
                    .HasMaxLength(20)
                    .HasColumnName("AP");

                entity.Property(e => e.Blok)
                     .HasMaxLength(10);

                entity.Property(e => e.Etaj)
                    .HasMaxLength(50)
                    .HasColumnName("etaj");

                entity.Property(e => e.Jk)
                    .HasMaxLength(5)
                    .HasColumnName("JK");

                entity.Property(e => e.Nm)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("NM");

                entity.Property(e => e.Nomer)
                    .HasMaxLength(35);

                entity.Property(e => e.Pk)
                    .HasMaxLength(15)
                    .HasColumnName("PK");

                entity.Property(e => e.Ul)
                    .HasMaxLength(5)
                    .HasColumnName("UL");

                entity.Property(e => e.Vh)
                    .HasMaxLength(10)
                    .HasColumnName("vh");

                entity.Property(e => e.e_mail)
                    .HasMaxLength(100)
                    .IsRequired()
                    .HasColumnName("e_mail");

                entity.Property(e => e.tel)
                    .HasMaxLength(50)
                    .IsRequired()
                    .HasColumnName("tel");

                entity.Property(e => e.status)
                    .IsRequired()
                    .HasColumnType("smallint")
                    .HasColumnName("status");

                entity.Property(e => e.descript)
                    .HasMaxLength(200)
                    .IsRequired()
                    .HasColumnName("descript");

                entity.Property(p => p.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("CreatedOn");

            });

            modelBuilder.Entity<ViewOpos>()
                       .HasNoKey()
                       .ToView("vwOPOS");

            modelBuilder.Entity<ViewAdres>()
                       .HasNoKey()
                       .ToView("vwAdres");

            modelBuilder.Entity<ViewStatusi>()
                       .HasNoKey()
                       .ToView("vwStatusi");

            modelBuilder.Entity<ViewLicaDogovorUrediVid>()
                       .HasNoKey()
                       .ToView("vwLicaDogovorUredi");

            modelBuilder.Entity<vwSpravka14>()
                        .HasNoKey()
                        .ToView("vwSpravka14");

            //views 
            modelBuilder.Entity<ViewFormulqr>()
                       .HasNoKey()
                       .ToView("ViewFormulqr");

            modelBuilder.Entity<ViewListFormulqr>()
                       .HasNoKey()
                       .ToView("ViewListFormulqr");

            modelBuilder.Entity<ViewPersons>()
                   .HasNoKey()
                   .ToView("ViewPersons");

            modelBuilder.Entity<ViewUser>()
                   .HasNoKey()
                   .ToView("ViewUser");

            modelBuilder.Entity<ViewLiceDogovor>()
                    .HasNoKey()
                    .ToView("ViewLiceDogovor");

            modelBuilder.Entity<ViewFirmiIzpalniteli>()
                    .HasNoKey()
                    .ToView("ViewFirmiIzpalniteli");

            modelBuilder.Entity<ViewSpravka1>()
                    .HasNoKey()
                    .ToView("ViewSpravka1");

            modelBuilder.Entity<ViewSpravka2>()
                    .HasNoKey()
                    .ToView("ViewSpravka2");

            modelBuilder.Entity<ViewSpravka4>()
                    .HasNoKey()
                    .ToView("ViewSpravka4");

            modelBuilder.Entity<ViewFirmDogovor>()
                    .HasNoKey()
                    .ToView("ViewFirmDogovor");

            modelBuilder.Entity<ViewDogovorUredi>()
                    .HasNoKey()
                    .ToView("ViewDogovorUredi");

            modelBuilder.Entity<ViewOrder>()
                    .HasNoKey()
                    .ToView("ViewOrder");

            modelBuilder.Entity<ViewUrediOrder>()
                    .HasNoKey()
                    .ToView("ViewUrediOrder");

            modelBuilder.Entity<ViewMonOrderItem>()
                    .HasNoKey()
                    .ToView("ViewMonOrderItem");

            modelBuilder.Entity<ViewNUlici>()
                    .HasNoKey()
                    .ToView("ViewNUlici");

            modelBuilder.Entity<ViewDogovorPrint>()
                    .HasNoKey()
                    .ToView("ViewDogovorPrint");

            modelBuilder.Entity<ViewLica>()
                    .HasNoKey()
                    .ToView("ViewLica");
            
            modelBuilder.Entity<ViewLicaDocumenti>()
                    .HasNoKey()
                    .ToView("ViewLicaDocumenti");

            modelBuilder.Entity<ViewPersUrediOrder>()
                      .HasNoKey()
                      .ToView("ViewPersUrediOrder");

            modelBuilder.Entity<ViewOposPortret>()
                      .HasNoKey()
                      .ToView("ViewOposPortret");

            modelBuilder.Entity<ViewResult>()
                      .HasNoKey()
                      .ToView("ViewResult");

            modelBuilder.Entity<ViewRadiatoriZaPrekodirane>()
                      .HasNoKey()
                      .ToView("ViewRadiatoriZaPrekodirane");

            modelBuilder.Entity<ViewSpravka5>()
                      .HasNoKey()
                      .ToView("ViewSpravka5");

            modelBuilder.Entity<ViewSpravka24>()
                      .HasNoKey()
                      .ToView("ViewSpravka24");

            modelBuilder.Entity<ViewSpravka25>()
                      .HasNoKey()
                      .ToView("ViewSpravka25");

            modelBuilder.Entity<ViewSpravka50>()
                      .HasNoKey()
                      .ToView("ViewSpravka50");

            modelBuilder.Entity<ViewSpravka51>()
                      .HasNoKey()
                      .ToView("ViewSpravka51");

            modelBuilder.Entity<ViewSpravka52>()
                      .HasNoKey()
                      .ToView("ViewSpravka52");

            modelBuilder.Entity<ViewSpravka53>()
                      .HasNoKey()
                      .ToView("ViewSpravka53");

            modelBuilder.Entity<ViewSpravka54>()
                      .HasNoKey()
                      .ToView("ViewSpravka54");

            modelBuilder.Entity<ViewSpravka55>()
                      .HasNoKey()
                      .ToView("ViewSpravka55");

            modelBuilder.Entity<ViewFiltriAdres>()
                      .HasNoKey()
                      .ToView("ViewFiltriAdres");

            modelBuilder.Entity<ViewSpravka60>()
                       .HasNoKey()
                       .ToView("ViewSpravka60");

            modelBuilder.Entity<ViewSpravka70>()
                       .HasNoKey()
                       .ToView("ViewSpravka70");

            modelBuilder.Entity<ViewSpravka78>()
                       .HasNoKey()
                       .ToView("ViewSpravka78");

            modelBuilder.HasDefaultSchema("dbo");
        }
    }
}
