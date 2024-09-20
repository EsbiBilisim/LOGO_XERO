using LOGO_XERO.Models.LOGO_M;
using LOGO_XERO.Models.LOGO_XERO_M;
using LOGO_XERO.Models;
using Microsoft.Win32;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using LOGO_XERO.Models.LOGO_XERO_M.LOGO_XERO_M;
using LOGO_XERO.Logic;

namespace LOGO_XERO.Models
{
    public partial class LogoContext : DbContext
    {
        public LogoContext()
            : base(SqlBaglanticumlesi())
        {
        }

        static string SqlBaglanticumlesi()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\EsbiSetting\\LOGO_XERO");
            string SqlServerName = rk.GetValue("SERVERNAME").ToString();
            string Database = rk.GetValue("DBNAME").ToString();
            string SqlKullanici = rk.GetValue("USERNAME").ToString();
            string SqlPass = rk.GetValue("PASSWORD").ToString();

            return $@"Data Source={SqlServerName};uid={SqlKullanici};pwd={SqlPass};database={Database};Connect Timeout=0;";
        }
        public virtual DbSet<LOGO_XERO_KAR_ZARAR_RENK> LOGO_XERO_KAR_ZARAR_RENK { get; set; }
        public virtual DbSet<LOGO_XERO_HATIRLATMA> LOGO_XERO_HATIRLATMA { get; set; }
        public virtual DbSet<LOGO_XERO_DUYURULAR> LOGO_XERO_DUYURULAR { get; set; }
        public virtual DbSet<LOGO_XERO_AMBARA_BAGLI_CARI_KOD> LOGO_XERO_AMBARA_BAGLI_CARI_KOD { get; set; }
        public virtual DbSet<LOGO_XERO_VIRMAN_ACIKLAMA> LOGO_XERO_VIRMAN_ACIKLAMA { get; set; }
        public virtual DbSet<LOGO_XERO_UYARI_MESAJLARI> LOGO_XERO_UYARI_MESAJLARI { get; set; }
        public virtual DbSet<LOGO_XERO_DOVIZ_BILGILERI> LOGO_XERO_DOVIZ_BILGILERI { get; set; }
        public virtual DbSet<LOGO_XERO_GORUSMELER> LOGO_XERO_GORUSMELER { get; set; }
        public virtual DbSet<LOGO_XERO_BELGENUMARASI_NUMARATOR> LOGO_XERO_BELGENUMARASI_NUMARATOR { get; set; }
        public virtual DbSet<LOGO_XERO_YETKILER> LOGO_XERO_YETKILER { get; set; }
        public virtual DbSet<LOGO_XERO_ONAYLI_TEKLIF_SATIR> LOGO_XERO_ONAYLI_TEKLIF_SATIR { get; set; }
        public virtual DbSet<LOGO_XERO_PAZARLAMA_TIPLERI> LOGO_XERO_PAZARLAMA_TIPLERI { get; set; }
        public virtual DbSet<LOGO_XERO_TESLIM_SURESI> LOGO_XERO_TESLIM_SURESI { get; set; }
        public virtual DbSet<LOGO_XERO_NAKLIYE_TURU> LOGO_XERO_NAKLIYE_TURU { get; set; }
        public virtual DbSet<LOGO_XERO_PARAMETRELER> LOGO_XERO_PARAMETRELER { get; set; }
        public virtual DbSet<LOGO_XERO_KULLANICI_AMBAR_ISYERI_YETKI> LOGO_XERO_KULLANICI_AMBAR_ISYERI_YETKI { get; set; }
        public virtual DbSet<LOGO_XERO_RAPOR_DOSYALARI> LOGO_XERO_RAPOR_DOSYALARI { get; set; }
        public virtual DbSet<LOGO_XERO_TEKLIF_SIPARISSEVK_TABLOSU> LOGO_XERO_TEKLIF_SIPARISSEVK_TABLOSU { get; set; }
        public virtual DbSet<LOGO_XERO_TEKLIF_BASLIK> LOGO_XERO_TEKLIF_BASLIK { get; set; }
        public virtual DbSet<LOGO_XERO_TEKLIF_SATIR> LOGO_XERO_TEKLIF_SATIR { get; set; }
        public virtual DbSet<LOGO_XERO_CARILISTE> LOGO_XERO_CARILISTE { get; set; }
        public virtual DbSet<LOGO_XERO_STOKLISTESI> LOGO_XERO_STOKLISTESI { get; set; }
        public virtual DbSet<LOGO_XERO_HIZMETLISTESI> LOGO_XERO_HIZMETLISTESI { get; set; }
        public virtual DbSet<LOGO_XERO_ARAMA_FILTRE_ALANLARI> LOGO_XERO_ARAMA_FILTRE_ALANLARI { get; set; }
        public virtual DbSet<LOGO_XERO_TEKLIF_DURUMLARI> LOGO_XERO_TEKLIF_DURUMLARI { get; set; }
        public virtual DbSet<LOGO_XERO_KULLANICILAR> LOGO_XERO_KULLANICILAR { get; set; }
        public virtual DbSet<LOGO_XERO_LISANSLAR> LOGO_XERO_LISANSLAR { get; set; }
        public virtual DbSet<LOGO_XERO_GOREVLER> LOGO_XERO_GOREVLER { get; set; }
        public virtual DbSet<LOGO_XERO_LOCK> LOGO_XERO_LOCK { get; set; }
        public virtual DbSet<LG_INVDEF> LG_INVDEF { get; set; }




        public virtual DbSet<LG_SLSMAN> LG_SLSMAN { get; set; }
        public virtual DbSet<L_CAPIFIRM> L_CAPIFIRM { get; set; }
        public virtual DbSet<L_CAPIPERIOD> L_CAPIPERIOD { get; set; }
        public virtual DbSet<L_CAPIDEPT> L_CAPIDEPT { get; set; }
        public virtual DbSet<LOGO_XERO_TASARIMLAR> LOGO_XERO_TASARIMLAR { get; set; }
        public virtual DbSet<L_CAPIFACTORY> L_CAPIFACTORY { get; set; }
        public virtual DbSet<L_CAPIDIV> L_CAPIDIV { get; set; }
        public virtual DbSet<L_CAPIWHOUSE> L_CAPIWHOUSE { get; set; }
        public virtual DbSet<L_TRADGRP> L_TRADGRP { get; set; }
        public virtual DbSet<L_CURRENCYLIST> L_CURRENCYLIST { get; set; }
        public virtual DbSet<L_SHPAGENT> L_SHPAGENT { get; set; }
        public virtual DbSet<L_SHPTYPES> L_SHPTYPES { get; set; }
        public virtual DbSet<LG_CATEGLISTS> LG_CATEGLISTS { get; set; }
        public virtual DbSet<LG_SPECODES> LG_SPECODES { get; set; }
        public virtual DbSet<LG_PAYPLANS> LG_PAYPLANS { get; set; }
        public virtual DbSet<LG_PROJECT> LG_PROJECT { get; set; }
        public virtual DbSet<LG_SHIPINFO> LG_SHIPINFO { get; set; }
        public virtual DbSet<LG_MARK> LG_MARK { get; set; }
        public virtual DbSet<L_FIRMPARAMS> L_FIRMPARAMS { get; set; }
        public virtual DbSet<LG_UNITSETF> LG_UNITSETF { get; set; }
        public virtual DbSet<LG_UNITSETL> LG_UNITSETL { get; set; }
        public virtual DbSet<LG_ITMUNITA> LG_ITMUNITA { get; set; }
        public virtual DbSet<LG_UNITBARCODE> LG_UNITBARCODE { get; set; }
        public virtual DbSet<LG_ITEMS> LG_ITEMS { get; set; }
        public virtual DbSet<LG_CLCARD> LG_CLCARD { get; set; }

        public virtual DbSet<L_CITY> L_CITY { get; set; }
        public virtual DbSet<L_COUNTRY> L_COUNTRY { get; set; }
        public virtual DbSet<L_TOWN> L_TOWN { get; set; }
        public virtual DbSet<L_DISTRICT> L_DISTRICT { get; set; }
        public virtual DbSet<L_TAXOFFICE> L_TAXOFFICE { get; set; }
        public virtual DbSet<LG_TRGPAR> LG_TRGPAR { get; set; }
        public virtual DbSet<LG_CLINTEL> LG_CLINTEL { get; set; }
        public virtual DbSet<LG_EMUHACC> LG_EMUHACC { get; set; }
        public virtual DbSet<LG_CLRNUMS> LG_CLRNUMS { get; set; }
        public virtual DbSet<LG_PAYLINES> LG_PAYLINES { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\EsbiSetting\\LOGO_XERO");
            string firma = rk.GetValue("FIRMANO").ToString();
            string donem = rk.GetValue("DONEMNO").ToString();

            modelBuilder.Entity<LOGO_XERO_TEKLIF_SIPARISSEVK_TABLOSU>().ToTable($"LOGO_XERO_TEKLIF_SIPARISSEVK_TABLOSU_{firma}");
            modelBuilder.Entity<LOGO_XERO_LOCK>().ToTable($"LOGO_XERO_LOCK_{firma}_{donem}");
            modelBuilder.Entity<LOGO_XERO_TEKLIF_BASLIK>().ToTable($"LOGO_XERO_TEKLIF_BASLIK_{firma}");
            modelBuilder.Entity<LOGO_XERO_TEKLIF_SATIR>().ToTable($"LOGO_XERO_TEKLIF_SATIR_{firma}");
            modelBuilder.Entity<LOGO_XERO_ONAYLI_TEKLIF_SATIR>().ToTable($"LOGO_XERO_ONAYLI_TEKLIF_SATIR_{firma}");
            modelBuilder.Entity<LOGO_XERO_STOKLISTESI>().ToTable($"LOGO_XERO_STOKLISTESI_{firma}");
            modelBuilder.Entity<LOGO_XERO_CARILISTE>().ToTable($"LOGO_XERO_CARILISTE_{firma}");
            modelBuilder.Entity<LOGO_XERO_HIZMETLISTESI>().ToTable($"LOGO_XERO_HIZMETLISTESI_{firma}");
            modelBuilder.Entity<LOGO_XERO_RAPOR_DOSYALARI>().ToTable($"LOGO_XERO_RAPOR_DOSYALARI_{firma}_{donem}");
            modelBuilder.Entity<LG_SPECODES>().ToTable($"LG_{firma}_SPECODES");
            modelBuilder.Entity<LG_PAYPLANS>().ToTable($"LG_{firma}_PAYPLANS");
            modelBuilder.Entity<LG_PROJECT>().ToTable($"LG_{firma}_PROJECT");
            modelBuilder.Entity<LG_SHIPINFO>().ToTable($"LG_{firma}_SHIPINFO");
            modelBuilder.Entity<LG_MARK>().ToTable($"LG_{firma}_MARK");
            modelBuilder.Entity<LG_UNITSETF>().ToTable($"LG_{firma}_UNITSETF");
            modelBuilder.Entity<LG_UNITSETL>().ToTable($"LG_{firma}_UNITSETL");
            modelBuilder.Entity<LG_UNITBARCODE>().ToTable($"LG_{firma}_UNITBARCODE");
            modelBuilder.Entity<LG_ITMUNITA>().ToTable($"LG_{firma}_ITMUNITA");
            modelBuilder.Entity<LG_ITEMS>().ToTable($"LG_{firma}_ITEMS");
            modelBuilder.Entity<LG_CLCARD>().ToTable($"LG_{firma}_CLCARD");
            modelBuilder.Entity<LOGO_XERO_HATIRLATMA>().ToTable($"LOGO_XERO_HATIRLATMA_{firma}_{donem}");
            modelBuilder.Entity<LOGO_XERO_DUYURULAR>().ToTable($"LOGO_XERO_DUYURULAR_{firma}_{donem}");
            modelBuilder.Entity<LOGO_XERO_GORUSMELER>().ToTable($"LOGO_XERO_GORUSMELER_{firma}_{donem}");
            modelBuilder.Entity<LG_INVDEF>().ToTable($"LG_{firma}_INVDEF");
            modelBuilder.Entity<LG_TRGPAR>().ToTable($"LG_{firma}_TRGPAR");
            modelBuilder.Entity<LG_CLINTEL>().ToTable($"LG_{firma}_CLINTEL");
            modelBuilder.Entity<LG_EMUHACC>().ToTable($"LG_{firma}_EMUHACC");
            modelBuilder.Entity<LG_PAYLINES>().ToTable($"LG_{firma}_PAYLINES");
            modelBuilder.Entity<LG_CLRNUMS>().ToTable($"LG_{firma}_{donem}_CLRNUMS");
        }
    }
}