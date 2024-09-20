using DevExpress.DashboardWin.Design;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using LOGO_XERO.Models.GenelKullanim;
using LOGO_XERO.Models.LOGO_M;
using LOGO_XERO.Models.LOGO_M.DosyaClaslari;
using LOGO_XERO.Models.LOGO_XERO_M;
using LOGO_XERO.Models.LOGO_XERO_M.LOGO_XERO_M;
using LOGO_XERO.Moduller._1_TeklifModul;
using LOGO_XERO.Moduller._7_Raporlar;
using LOGO_XERO.Moduller.Finans;
using LOGO_XERO.Moduller.GenelListeler;
using LOGO_XERO.Moduller.Giris_AnaForm_Ayarlar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using UnityObjects;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Application = System.Windows.Forms.Application;

namespace LOGO_XERO
{
    public partial class frmTeklifOlustur : DevExpress.XtraEditors.XtraForm
    {
        double firmatevkifatLimiti = 0;
        Islemler islem = new Islemler();
        frmAnaForm ana;
        public LOGO_XERO_PARAMETRELER parametre = new LOGO_XERO_PARAMETRELER();
        List<LOGO_XERO_TEKLIF_BASLIK> Basliklar = new List<LOGO_XERO_TEKLIF_BASLIK>();
        L_CAPIFIRM firmaLogoBilgi = new L_CAPIFIRM();
        public int Teklifid = 0;
        public int Trkod = 0;
        public string firma, donem;
        public bool duzenle = false;
        public List<KODAD> turler = new List<KODAD>();
        GenelListeler genellisteler = new GenelListeler();
        LogoContext dbsatirsilmekicin = new LogoContext();
        int lkonaysayisi;
        public string lotKodu, lotAdi, lotMiktar;
        public int lotIptalId;
        public int LookUpDurum;
        int hattip = 0;

        public List<L_FIRMPARAMS> FirmaLogoParametre;
        L_FIRMPARAMS kdvmuafiyetkontrolüyapilacak = new L_FIRMPARAMS();
        L_FIRMPARAMS kdvmuafiyetkoontrolüsiparisteyapilacak = new L_FIRMPARAMS();

        public frmTeklifOlustur(int id, DateTime tarih)
        {
            InitializeComponent();
            ana = System.Windows.Forms.Application.OpenForms["frmAnaForm"] as frmAnaForm;
            parametre = ana.parametre;
            date_tarih.DateTime = tarih;
            firmaLogoBilgi = ana.firmaBilgisi;
            duzenle = true;
            lkonaysayisi = 0;
            islem.TasarimGetir(gv_TeklifSatirlari, ana._Kullanici.ID, this.Name, grid_TeklifSatirlari.Name);
            TurleriGetir();
            islem.TeslimSuresiDoldur(rpTeslimSuresi);
            islem.PazarlamaTipleriDoldur(lk_pazarlamatipi);
            OnayDoldur();
            firma = ana.firma;
            donem = ana.donem;
            lk_RaporlamaDoviz.EditValue = 0;
            Lk_IslemDoviz.EditValue = 0;
            Teklifid = id;
            // simpleButton3.Visible = true;
            lk_durum.Enabled = false;
        }
        public frmTeklifOlustur()
        {
            InitializeComponent();
            ana = System.Windows.Forms.Application.OpenForms["frmAnaForm"] as frmAnaForm;
            parametre = ana.parametre;
            firmaLogoBilgi = ana.firmaBilgisi;
            date_tarih.DateTime = DateTime.Now;
            islem.TasarimGetir(gv_TeklifSatirlari, ana._Kullanici.ID, this.Name, grid_TeklifSatirlari.Name);
            TurleriGetir();
            islem.TeslimSuresiDoldur(rpTeslimSuresi);
            islem.PazarlamaTipleriDoldur(lk_pazarlamatipi);
            OnayDoldur();
            lkonaysayisi = 1;
            date_gelistarihi.DateTime = DateTime.Now;
            date_opsiyonTarihi.DateTime = DateTime.Now;
            time_geliszamani.Time = DateTime.Now;
            time_saat.Time = DateTime.Now;
            // simpleButton3.Visible = false;
            lk_durum.Enabled = false;
            cm_FaturaTipiSecim.SelectedIndex = 0;
        }
        public void OnayDoldur()
        {
            List<CODENAME> OnayDurum = new List<CODENAME>();
            CODENAME d1 = new CODENAME() { CODE = "1", NAME = "Onay Bekliyor" };
            CODENAME d2 = new CODENAME() { CODE = "2", NAME = "Onaylandı" };
            CODENAME d3 = new CODENAME() { CODE = "3", NAME = "Onaylanmadı" };
            OnayDurum.Add(d1);
            OnayDurum.Add(d2);
            OnayDurum.Add(d3);
            lk_onay.Properties.DataSource = OnayDurum;
            lk_onay.Properties.DisplayMember = "NAME";
            lk_onay.Properties.ValueMember = "CODE";
            lk_onay.EditValue = "1";
        }
        public void HatirlatmalariGetir(int id)
        {
            using (LogoContext db = new LogoContext())
            {

                grid_Hatirlatmalar.DataSource = db.LOGO_XERO_HATIRLATMA.Where(s => s.TEKLIFID == id).ToList();
                grid_Hatirlatmalar.RefreshDataSource();
                grid_Hatirlatmalar.Refresh();
            }
        }

        public void TurleriGetir()
        {
            turler.Add(new KODAD { CODE = 1, NAME = "MALZEME" });
            turler.Add(new KODAD { CODE = 2, NAME = "HIZMET" });
            rpTur.DataSource = turler;
            rpTur.ValueMember = "CODE";
            rpTur.DisplayMember = "NAME";
        }
        
        public void baslikgetir(object sender, EventArgs e,int id)
        {
            using (LogoContext db = new LogoContext())
            {
                LOGO_XERO_TEKLIF_BASLIK baslik = db.LOGO_XERO_TEKLIF_BASLIK.Where(s => s.ID == id).FirstOrDefault();
                txt_teklifno.Text = baslik.TEKLIFNO;
                if (baslik.TRCODE == 8)
                {
                    txt_TeklifFisTipi.Text = "SATIŞ TEKLİFİ";
                }
                if (baslik.TRCODE == 1)
                {
                    txt_TeklifFisTipi.Text = "SATINALMA TEKLİFİ";
                }
                date_tarih.DateTime = Convert.ToDateTime(baslik.TARIH);
                time_saat.Time = Convert.ToDateTime(date_tarih.DateTime + baslik.SAAT);
                date_gelistarihi.DateTime = Convert.ToDateTime(baslik.GELISTARIHI);
                time_geliszamani.Time = Convert.ToDateTime(date_gelistarihi.DateTime + baslik.GELISZAMANI);
                date_opsiyonTarihi.DateTime = Convert.ToDateTime(baslik.OPSIYONTARIHI);
                lbl_cariref.Text = baslik.CARIID.ToString();
                btn_cariKodu.Text = baslik.CARIKODU;
                btn_cariUnvani.Text = baslik.CARIUNVANI;
                btn_OzelKod.Text = baslik.OZELKOD;
                btn_YetkiKodu.Text = baslik.YETKIKODU;
                btn_ticariIslemGuruplari.EditValue = baslik.TRADDINGGRP;
                txt_Yetkili.Text = baslik.YETKILI;
                txt_Telefon.Text = baslik.TELEFON;
                txt_Eposta.Text = baslik.EPOSTA;
                txt_Eposta2.Text = baslik.EPOSTA2;
                txt_konu.Text = baslik.KONU;
                txt_aciklama.Text = baslik.ACIKLAMA;
                ck_kdvdahil.Checked = Convert.ToBoolean(baslik.KDVDURUMU);
                lk_isyeri.EditValue = Convert.ToInt16(baslik.ISYERI);
                lk_bolum.EditValue = Convert.ToInt16(baslik.BOLUM);
                lk_ambar.EditValue = Convert.ToInt16(baslik.AMBAR);
                lk_fabrika.EditValue = Convert.ToInt16(baslik.FABRIKA);
                lk_satisElemani.EditValue = baslik.SATISELEMANIKODU;
                lk_Hazirlayan.EditValue = baslik.HAZIRLAYANID;
                lk_pazarlayan.EditValue = baslik.PAZARLAYANID;
                lk_Onaylayan.EditValue = baslik.ONAYLAYANID;
                lk_onay.EditValue = baslik.ONAYDURUMU.ToString();
                //if (lk_onay.EditValue.ToString() == "2")
                //{
                ///    xtraTabControl2.SelectedTabPage = OnayliTeklifSatirlariTab;
                OnaylanansatirlariGetir(baslik.ID);
                //}
                lk_durum.EditValue = baslik.DURUMU;
                Efatura_resim.Visible = Convert.ToBoolean(baslik.EFATURA);
                lk_OdemeTipi.EditValue = baslik.VADE;
                lk_TanimliAlanOdemeTipi.EditValue = baslik.TANIMLIALANODEMETIPI;
                if (baslik.TESLIMSEKLIKODU != "")
                {
                    btn_TeslimSekliKodu.Text = baslik.TESLIMSEKLIKODU;
                    btn_TeslimSekliAciklamasi.Text = islem.TeslimSekliAciklamasi(baslik.TESLIMSEKLIKODU);
                }

                if (baslik.TASIYICIKODU != "")
                {
                    btn_TasiyiciKodu.Text = baslik.TASIYICIKODU;
                    btn_TasiyiciKoduAciklamasi.Text = islem.TasiyiciKoduAciklamasi(baslik.TASIYICIKODU);
                }
                txt_nakliyebedeli.Text = baslik.NAKLIYEBEDELI.ToString();
                lk_pazarlamatipi.EditValue = baslik.PAZARLAMATIPI;
                //ck_Tevkifat.Checked = Convert.ToBoolean(baslik.TEVKIFATID);
                GenelParaBirim.SelectedIndex = Convert.ToInt32(baslik.GENELDOVIZLIISLEMTIPI);
                SatirlarParaBirimi.SelectedIndex = Convert.ToInt32(baslik.SATIRLARDOVIZLIISLEMTIPI);
                Lk_IslemDoviz.EditValue = baslik.DOVIZKODU;
                btn_islemkuru.Text = baslik.ISLEMDOVIZKURU.ToString();
                btn_raporlamakuru.Text = baslik.RAPORLAMADOVIZKURU.ToString();
                rd_AktarildigindaFiyatlandirmaDoviziAynenKalacak.SelectedIndex = Convert.ToInt32(baslik.FIYATLANDIRMADOVIZIAYNENKALACAK);
                rd_AktarildigindaIslemDoviziAynenKalacak.SelectedIndex = Convert.ToInt32(baslik.ISLEMDOVIZIAYNENKALACAK);
                txt_aciklama2.Text = baslik.ACIKLAMA2;
                txt_aciklama3.Text = baslik.ACIKLAMA3;
                lk_uyarimesaji.EditValue = baslik.UYARIMESAJI;
                txt_takipsonuc.Text = baslik.TAKIPSONUC;
                txt_ozelbilgi.Text = baslik.OZELBILGI;
                txt_not.Text = baslik.NOT;
                txt_ozelacik1.Text = baslik.OZELACIKLAMA1;
                txt_ozelacik2.Text = baslik.OZELACIKLAMA2;
                txt_ozelacik3.Text = baslik.OZELACIKLAMA3;
                lbl_projeref.Text = baslik.PROJEID.ToString();
                btn_ProjeKodu.Text = islem.ProjeKodu(firma, Convert.ToInt32(baslik.PROJEID));
                lbl_sevkiyatadresref.Text = baslik.SEVKIYATADRESIID.ToString();
                lbl_SevkiyatHesabiRefi.Text = baslik.SEVKIYATHESAPID.ToString();
                CODENAME code = islem.SevkiyatAdresi(firma, Convert.ToInt32(baslik.CARIID), Convert.ToInt32(baslik.SEVKIYATADRESIID));
                if (baslik.SEVKIYATHESAPID != 0)
                {
                    LOGO_XERO_CARILISTE cari = islem.CariBilgiGetir(Convert.ToInt32(baslik.SEVKIYATHESAPID));
                    if (cari != null)
                    {
                        btn_SevkHesabiKodu.Text = cari.CODE;
                        btn_sevkiyatHesabiaciklamasi.Text = cari.DEFINITION_;
                    }
                }
                if (code != null)
                {
                    btn_SevkAdresKodu.Text = code.CODE;
                    btn_sevkiyatAdresAciklama.Text = code.NAME;
                }
                else
                {
                    btn_SevkAdresKodu.Text = "";
                    btn_sevkiyatAdresAciklama.Text = "";
                }
                txt_Adres1.Text = baslik.FATADRES1;
                txt_Adres2.Text = baslik.FATADRES2;
                txt_Ulke.Text = baslik.FATULKE;
                txt_Il.Text = baslik.FATIL;
                txt_Ilce.Text = baslik.FATILCE;
                txt_Fax.Text = baslik.FATFAKS;
                txt_VergiDairesi.Text = baslik.FATVD;
                txt_VergiNo.Text = baslik.FATVN;
                txt1aciklama.Text = baslik.GENELACIKLAMA1;
                txt2aciklama.Text = baslik.GENELACIKLAMA2;
                txt3aciklama.Text = baslik.GENELACIKLAMA3;
                txt4aciklama.Text = baslik.GENELACIKLAMA4;
                txt5aciklama.Text = baslik.GENELACIKLAMA5;
                txt6aciklama.Text = baslik.GENELACIKLAMA6;
                cm_FaturaTipiSecim.SelectedIndex = baslik.FATURATIPI;
                btn_KdvMuafiyetSebebiKodu.Text = baslik.KDVMUAFIYETKODU;
                txt_KdvMuafiyetSebebiAciklamasi.Text = baslik.KDVMUAFIYETACIKLAMA;

                Teklifid = baslik.ID;
                this.Text = txt_teklifno.Text + " Nolu " + btn_cariUnvani.Text + " İsimli Cari Teklifi";
                Uyari(sender, e);
            }
        }
        public List<LOGO_XERO_TEKLIF_SATIR> satirgetir(int baslikid)
        {
            using (LogoContext db = new LogoContext())
            {
                var listeler = db.LOGO_XERO_TEKLIF_SATIR.Where(s => s.TEKLIFID == baslikid).ToList();
                listeler.ForEach(s => s.AMBARBAKIYE = genellisteler.UrunStokBakiyeBilgisiGetir(firma, donem, Convert.ToInt32(lk_ambar.EditValue), s.STOKLOGICALREF));
                return listeler;
            }
        }
        L_CAPIFIRM firmaBilgisi;
        L_CAPIPERIOD DonemBilgisi;
        int sayac = 0;
        public void HatirlatmaRenkAyarla(int teklifid)
        {
            using (LogoContext db = new LogoContext())
            {
                if (duzenle == true)
                {
                    //hatırlatma
                    int hatirlatma = db.LOGO_XERO_HATIRLATMA.Where(s => s.TEKLIFID == teklifid && s.OKUNDU == false).Count();
                    try
                    {

                        if (hatirlatma != null && hatirlatma != 0)
                        {
                            if (sayac % 2 == 0)
                            {
                                hatirlatmalartabpage.Appearance.Header.BackColor = Color.FromArgb(255, 0, 0);
                                hatirlatmalartabpage.Text = "Hatırlatmalar (" + hatirlatma.ToString() + ") ";
                                sayac++;
                            }
                            else
                            {
                                hatirlatmalartabpage.Appearance.Header.BackColor = Color.FromArgb(255, 255, 255);
                                hatirlatmalartabpage.Text = "Hatırlatmalar (" + hatirlatma.ToString() + ") ";
                                sayac++;
                            }
                            if (sayac == int.MaxValue - 100)
                            {
                                sayac = 0;
                            }
                        }
                        else if (hatirlatma == 0)
                        {
                            hatirlatmalartabpage.Text = "Hatırlatmalar";
                            hatirlatmalartabpage.Appearance.Header.BackColor = default(Color);
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }
        private void frmTeklifOlustur_Load(object sender, EventArgs e)
        {
            try
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                FirstThreadAsync();
                async void FirstThreadAsync()
                {
                    void InnerThread()
                    {
                        while (true)
                        {
                            Thread.Sleep(750);
                            HatirlatmaRenkAyarla(Teklifid);
                        }
                    }

                    Task task = new Task(() => InnerThread());
                    task.Start();
                    await task;
                }
            }
            catch (Exception)
            {

            }

            FirmaLogoParametre = islem.FirmaLogoTumParametreleriGetir(ana.lk_firma.EditValue.ToString());//eklenecek
            kdvmuafiyetkontrolüyapilacak = FirmaLogoParametre.Where(s => s.GROUPNR == 350 && s.MODULENR == 10 && s.CODE == "SALES_SVATEXCEPTCODECTRL").FirstOrDefault();
            kdvmuafiyetkoontrolüsiparisteyapilacak = FirmaLogoParametre.Where(s => s.GROUPNR == 400 && s.MODULENR == 10 && s.CODE == "SALES_SVATEXCCODETYP1").FirstOrDefault();


            if (Trkod == 8) //satis
            {
                hattip = 1;
            }
            else if (Trkod == 1)
            {
                hattip = 2;
            }

            using (LogoContext db = new LogoContext())
            {
                Basliklar = db.LOGO_XERO_TEKLIF_BASLIK.Where(s => !s.TEKLIFNO.Contains("-R")).ToList();
            }
            grid_TeklifSatirlari.AllowDrop = true;
            firma = ana.lk_firma.EditValue.ToString();
            donem = ana.lk_donem.EditValue.ToString();
            islem.UyariMesajlariDoldur(lk_uyarimesaji, firma);
            StandartYuklemeleriYap();
            firmatevkifatLimiti = islem.FirmaTevkifatLimitiCek(firma);
            lk_durum.EditValue = 1;
            if (Teklifid == 0)
            {
                lk_isyeri.EditValue = ana._Kullanici.ISYERI;
                lk_Hazirlayan.EditValue = ana._Kullanici.ID;
                lk_satisElemani.EditValue = ana._Kullanici.LOGOSATISELEMANIID;
                lk_bolum.EditValue = ana._Kullanici.BOLUM;
                lk_fabrika.EditValue = ana._Kullanici.FABRIKA;               
                lk_Onaylayan.EditValue = ana._Kullanici.ID;
                GenelParaBirim.EditValue = 1;
                SatirlarParaBirimi.EditValue = 0;
                lk_ambar.EditValue = ana._Kullanici.AMBAR;
                //List<LOGO_XERO_TEKLIF_SATIR> liste = new List<LOGO_XERO_TEKLIF_SATIR>();
                //liste.Add(new LOGO_XERO_TEKLIF_SATIR { TUR = 1, AMBAR = Convert.ToInt16(lk_ambar.EditValue), TEVKIFATKODU = "", TEVKIFATBOLEN = 0, TEVKIFATCARPAN = 0, TEVKIFATLI = false });
                //grid_TeklifSatirlari.DataSource = liste;
            }

            if (Teklifid != 0)
            {
                baslikgetir(sender,e,Teklifid);
                List<LOGO_XERO_TEKLIF_SATIR> satirs = satirgetir(Teklifid);
                grid_TeklifSatirlari.DataSource = satirs;
                grid_TeklifSatirlari.RefreshDataSource();
                grid_TeklifSatirlari.Refresh(); 
                AltToplamlariHesapla();
            }
           

            HatirlatmalariGetir(Teklifid);
            if (lk_onay.EditValue.ToString() == "1") //onay bekliyor
            {
                List<LOGO_XERO_TEKLIF_SATIR> satrlar = (List<LOGO_XERO_TEKLIF_SATIR>)gv_TeklifSatirlari.DataSource;
                if (satrlar != null)
                {
                    bool bosvar = false;
                    foreach (var item in satrlar)
                    {
                        if (item.STOKADI == null)
                        {
                            bosvar = true;
                            break;
                        }
                    }
                    if (!bosvar)
                    {
                        SatirEkle();
                    }
                }
                else
                {
                    SatirEkle();
                }
                xtraTabControl2.SelectedTabPage = TeklifSatirlariTab;
            }
            else if (lk_onay.EditValue.ToString() == "2") //onaylandı
            {
                List<LOGO_XERO_TEKLIF_SATIR> satrlar = (List<LOGO_XERO_TEKLIF_SATIR>)gv_TeklifSatirlari.DataSource;
                List<LOGO_XERO_TEKLIF_SATIR> silinecekler = satrlar.Where(s => string.IsNullOrWhiteSpace(s.STOKADI)).ToList();
                silinecekler.ForEach(s => satrlar.Remove(s));
                grid_TeklifSatirlari.DataSource = satrlar;
                grid_TeklifSatirlari.RefreshDataSource();
                grid_TeklifSatirlari.Refresh();
            }
            else if (lk_onay.EditValue.ToString() == "3")
            {

            }

        }
        public void Numarator(int trcode)
        {
            try
            {
                using (LogoContext db = new LogoContext())
                {
                    string seri = null;
                    string serino = null;
                    if (trcode == 8)
                    {
                        seri = db.LOGO_XERO_BELGENUMARASI_NUMARATOR
                        .Where(s => s.FIRMANO == firma && s.DONEMNO == donem)
                        .Select(s => s.STEKLIF_SERI)
                        .FirstOrDefault();
                        serino = db.LOGO_XERO_BELGENUMARASI_NUMARATOR
                       .Where(s => s.FIRMANO == firma && s.DONEMNO == donem)
                       .Select(s => s.STEKLIF_SERINO)
                       .FirstOrDefault();
                    }
                    if (trcode == 1)
                    {
                        seri = db.LOGO_XERO_BELGENUMARASI_NUMARATOR
                        .Where(s => s.FIRMANO == firma && s.DONEMNO == donem)
                        .Select(s => s.ATEKLIF_SERI)
                        .FirstOrDefault();
                        serino = db.LOGO_XERO_BELGENUMARASI_NUMARATOR
                       .Where(s => s.FIRMANO == firma && s.DONEMNO == donem)
                       .Select(s => s.ATEKLIF_SERINO)
                       .FirstOrDefault();
                    }
                    if (seri != null && serino != null)
                    {
                        string formattedSerino = serino.PadLeft(9, '0');
                        txt_teklifno.Text = seri + formattedSerino;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        public void NumaratoruArttir(int trcode)
        {
            try
            {
                using (LogoContext db = new LogoContext())
                {
                    var numarator = db.LOGO_XERO_BELGENUMARASI_NUMARATOR
                        .Where(s => s.FIRMANO == firma && s.DONEMNO == donem)
                        .FirstOrDefault();
                    if (numarator != null)
                    {
                        if (trcode == 8)
                        {
                            var newSeriNo = Convert.ToInt32(numarator.STEKLIF_SERINO) + 1;
                            numarator.STEKLIF_SERINO = newSeriNo.ToString();

                            db.Entry(numarator).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                        if (trcode == 1)
                        {
                            var newSeriNo = Convert.ToInt32(numarator.ATEKLIF_SERINO) + 1;
                            numarator.ATEKLIF_SERINO = newSeriNo.ToString();

                            db.Entry(numarator).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        void StandartYuklemeleriYap()
        {
            Numarator(Trkod);
            if (Trkod == 8)
            {
                txt_TeklifFisTipi.Text = "SATIŞ TEKLİFİ";
            }
            if (Trkod == 1)
            {
                txt_TeklifFisTipi.Text = "SATINALMA TEKLİFİ";
            }
            islem.IsyeriListesiDoldur(lk_isyeri, ana.lk_firma.EditValue.ToString());
            islem.PersonelListesiDoldur(lk_Hazirlayan);
            islem.PersonelListesiDoldur(lk_pazarlayan);
            islem.LogoSatisElemaniDoldur(lk_satisElemani, ana.lk_firma.EditValue.ToString());
            islem.PersonelListesiDoldur(lk_Onaylayan);
            islem.TeklifDurumListesiDoldur(lk_durum);
            islem.TeklifTanimliAlanOdemeTipiDoldur(lk_TanimliAlanOdemeTipi, "");
            islem.OdemeTipleriDoldur(lk_OdemeTipi, ana.lk_firma.EditValue.ToString());

            firmaBilgisi = islem.FirmaBilgileriGetir(ana.lk_firma.EditValue.ToString());
            DonemBilgisi = islem.DonemBilgileriGetir(ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString());
            islem.XeroDovizBilgileriDoldur(lk_RaporlamaDoviz, ana.lk_firma.EditValue.ToString());
            islem.XeroDovizBilgileriDoldur(Lk_IslemDoviz, ana.lk_firma.EditValue.ToString());
            lk_RaporlamaDoviz.Properties.ForceInitialize();
            lk_RaporlamaDoviz.EditValue = DonemBilgisi.PERREPCURR;
            Lk_IslemDoviz.EditValue = 0;
            rd_AktarildigindaFiyatlandirmaDoviziAynenKalacak.EditValue = 0;
            rd_AktarildigindaIslemDoviziAynenKalacak.EditValue = 0;
            islem.XeroDovizBilgileriDoldur(rpSatirDovizKodu, ana.lk_firma.EditValue.ToString());
            
            double dovizKuru = islem.RatesDovizKuruDondur(parametre, firmaLogoBilgi, Convert.ToInt16(lk_RaporlamaDoviz.EditValue.ToString()), firma, donem);
            btn_raporlamakuru.Text = dovizKuru.ToString();
            Gorusmeler();
        }
        public void Gorusmeler()
        {
            if (Teklifid != 0)
            {
                using (LogoContext db = new LogoContext())
                {
                    grid_Gorusmeler.DataSource = db.LOGO_XERO_GORUSMELER.Where(S => S.TEKLIFID == Teklifid).ToList();
                    gv_Gorusmeler.OptionsBehavior.Editable = false;

                }
            }
        }
        public void vadegun(int payplansid)
        {
            try
            {
                using (LogoContext db = new LogoContext())
                {
                    if (payplansid != null)
                    {
                        LG_PAYLINES payplans = db.LG_PAYLINES.Where(s => s.PAYPLANREF == payplansid && s.LINENO_ == 1).FirstOrDefault();
                        if (payplans != null)
                        {

                            if (!string.IsNullOrWhiteSpace(payplans.DAY_))
                            {
                                string[] sayilar = Regex.Split(payplans.DAY_, @"\D+");
                                int gun = int.Parse(sayilar[1]);
                                if (payplans.DAY_.Contains("+"))
                                {
                                    lb_vadetarihi.Text = date_gelistarihi.DateTime.AddDays(+gun).ToString("dd-MM-yy");
                                }
                                else if (payplans.DAY_.Contains("-"))
                                {
                                    lb_vadetarihi.Text = date_gelistarihi.DateTime.AddDays(-gun).ToString("dd-MM-yy");
                                }

                            }



                            if (!string.IsNullOrWhiteSpace(payplans.MOUNTH))
                            {
                                string[] sayilar = Regex.Split(payplans.MOUNTH, @"\D+");
                                int gun = int.Parse(sayilar[1]);
                                if (payplans.MOUNTH.Contains("+"))
                                {
                                    lb_vadetarihi.Text = date_gelistarihi.DateTime.AddMonths(+gun).ToString("dd-MM-yy");
                                }
                                else if (payplans.MOUNTH.Contains("-"))
                                {
                                    lb_vadetarihi.Text = date_gelistarihi.DateTime.AddMonths(-gun).ToString("dd-MM-yy");
                                }
                            }

                            if (!string.IsNullOrWhiteSpace(payplans.YEAR_))
                            {
                                string[] sayilar = Regex.Split(payplans.YEAR_, @"\D+");
                                int gun = int.Parse(sayilar[1]);
                                if (payplans.YEAR_.Contains("+"))
                                {
                                    lb_vadetarihi.Text = date_gelistarihi.DateTime.AddYears(+gun).ToString("dd-MM-yy");
                                }
                                else if (payplans.YEAR_.Contains("-"))
                                {
                                    lb_vadetarihi.Text = date_gelistarihi.DateTime.AddYears(-gun).ToString("dd-MM-yy");
                                }
                            }
                            if (string.IsNullOrWhiteSpace(payplans.DAY_) && string.IsNullOrWhiteSpace(payplans.MOUNTH) && string.IsNullOrWhiteSpace(payplans.YEAR_))
                            {
                                lb_vadetarihi.Text = "";
                            }
                            //string[] sayilar = Regex.Split(payplans.CODE, @"\D+");
                            //try
                            //{
                            //    int gun = int.Parse(sayilar[0]);
                            //    return gun;
                            //}
                            //catch (Exception ex)
                            //{
                            //    return 0;
                            //}

                        }

                        else
                        {
                            lb_vadetarihi.Text = "";
                        }
                    }
                    else { lb_vadetarihi.Text = ""; }
                }
            }
            catch (Exception)
            {
                lb_vadetarihi.Text = "";
            }

        }
        private void lk_isyeri_EditValueChanged(object sender, EventArgs e)
        {
            islem.BolumListesiDoldur(lk_bolum, ana.lk_firma.EditValue.ToString());
            int isyeri = Convert.ToInt32(lk_isyeri.EditValue.ToString());
            islem.FabrikaListesiDoldur(lk_fabrika, ana.lk_firma.EditValue.ToString());
           
        }
        private void btn_ticariIslemGuruplari_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.TicariIslemGruplariAc(this);
        }
        private void btn_odemeTipi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.OdemeTipiAc(this);
        }
        private void ck_Tevkifat_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit nesne = sender as CheckEdit;
            if (nesne.Checked == true)
            {
               //btn_tevkifat.Visible = true;
                panelControl6.Visible = true;
            }
            else
            {
                //btn_tevkifat.Visible = false;
                panelControl6.Visible = false;
                tevkifatHesaplandi = 1;
                TevkifatiGeriAl();
            }
        }
        private void btn_SevkAdresKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SevkiyatHesabiListeAc();
        }
        private void btn_sevkiyatAdresAciklama_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SevkiyatHesabiListeAc();
        }
        void SevkiyatHesabiListeAc()
        {
            if (string.IsNullOrWhiteSpace(lbl_cariref.Text))
            {
                XtraMessageBox.Show("CARİ HESAP SEÇİLMELİDİR !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (lbl_cariref.Text == "0")
            {
                XtraMessageBox.Show("CARİ HESAP SEÇİLMELİDİR !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmSevkiyatAdresleri frm = new frmSevkiyatAdresleri(this);
            frm.ShowDialog();
        }
        private void btn_cariKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.CariListesiAc(this, 1);
            Uyari(sender, e);
        }
        private void btn_OzelKod_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (Trkod == 1)
            {
                islem.OzelKodListesiAc(this, 1, 1, 15, 0);
            }
            if (Trkod == 8)
            {
                islem.OzelKodListesiAc(this, 1, 1, 14, 0);
            }
        }
        private void btn_YetkiKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (Trkod == 1)
            {
                islem.OzelKodListesiAc(this, 2, 2, 15, 0);
            }
            if (Trkod == 8)
            {
                islem.OzelKodListesiAc(this, 2, 2, 14, 0);
            }
        }
        private void btn_SevkAdresHesapKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.CariListesiAc(this, 2);
        }
        private void btn_sevkiyatAdresiHesapAciklamasi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.CariListesiAc(this, 2);
        }
        private void btn_cariUnvani_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.CariListesiAc(this, 1);
        }
        private void btn_ProjeKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.ProjeListesiniAc(this);
        }
        private void btn_TeslimSekliKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.TeslimSekilleriListesiniAc(this);
        }
        private void btn_TeslimSekliAciklamasi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.TeslimSekilleriListesiniAc(this);
        }
        private void btn_TasiyiciKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.TasiyiciKodlariListesiniAc(this);
        }
        private void btn_TasiyiciKoduAciklamasi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.TasiyiciKodlariListesiniAc(this);
        }
        public LOGO_XERO_TEKLIF_SATIR SatirEkle(int tur = 1)
        {
            List<LOGO_XERO_TEKLIF_SATIR> TeklifsatirListe = grid_TeklifSatirlari.DataSource as List<LOGO_XERO_TEKLIF_SATIR>;
            int nullcounter = 0;
            LOGO_XERO_TEKLIF_SATIR yeniSatir = new LOGO_XERO_TEKLIF_SATIR { TUR = tur };
            if (TeklifsatirListe == null)
            {
                TeklifsatirListe = new List<LOGO_XERO_TEKLIF_SATIR>();
                yeniSatir.AMBAR = Convert.ToInt16(lk_ambar.EditValue);
                yeniSatir.TEVKIFATKODU = "";
                yeniSatir.TEVKIFATBOLEN = 0;
                yeniSatir.TEVKIFATCARPAN = 0;
                yeniSatir.TEVKIFATLI = false;

                TeklifsatirListe.Add(yeniSatir);
                grid_TeklifSatirlari.DataSource = TeklifsatirListe;
                grid_TeklifSatirlari.RefreshDataSource();
                int yeniSatiraFocus = gv_TeklifSatirlari.GetRowHandle(TeklifsatirListe.Count - 1);
                gv_TeklifSatirlari.FocusedRowHandle = yeniSatiraFocus;
                gv_TeklifSatirlari.SelectRow(yeniSatiraFocus);
                return yeniSatir;
            }
            foreach (var satir in TeklifsatirListe)
            {
                if (satir.STOKLOGICALREF == null) { nullcounter++; }
            }

            
            if (nullcounter == 0)
            {
                yeniSatir.AMBAR=Convert.ToInt16(lk_ambar.EditValue);
                yeniSatir.TEVKIFATKODU = "";
                yeniSatir.TEVKIFATBOLEN = 0;
                yeniSatir.TEVKIFATCARPAN = 0;
                yeniSatir.TEVKIFATLI = false;

                TeklifsatirListe.Add(yeniSatir);
                grid_TeklifSatirlari.DataSource = TeklifsatirListe;
                grid_TeklifSatirlari.RefreshDataSource();
                int yeniSatiraFocus = gv_TeklifSatirlari.GetRowHandle(TeklifsatirListe.Count - 1);
                gv_TeklifSatirlari.FocusedRowHandle = yeniSatiraFocus;
                gv_TeklifSatirlari.SelectRow(yeniSatiraFocus);

                return yeniSatir;
            }
            else
            {
                return yeniSatir;
            }
        }
        public void AltToplamlariHesapla()
        {
            List<LOGO_XERO_TEKLIF_SATIR> TeklifsatirListe = grid_TeklifSatirlari.DataSource as List<LOGO_XERO_TEKLIF_SATIR>;

            if (TeklifsatirListe == null) { return; }

            double toplamkdvtutari = 0;
            double iskontotutari1 = 0;
            double iskontotutari2 = 0;
            double iskontotutari3 = 0;
            double iskontolugeneltutar = 0;
            double toplamtutar = 0;

            foreach (var satir in TeklifsatirListe)
            {
                toplamkdvtutari += Convert.ToDouble(satir.KDVTUTARI);
                iskontotutari1 += Convert.ToDouble(satir.ISKONTOTUTARI1);
                iskontotutari2 += Convert.ToDouble(satir.ISKONTOTUTARI2);
                iskontotutari3 += Convert.ToDouble(satir.ISKONTOTUTARI3);
                iskontolugeneltutar += Convert.ToDouble(satir.ISKONTOLUTUTAR);
                toplamtutar += Convert.ToDouble(satir.TUTAR);
            }

            double toplam = iskontolugeneltutar;
            double nettoplam = iskontolugeneltutar + toplamkdvtutari;
            double iskontogeneltoplam = iskontotutari1 + iskontotutari2 + iskontotutari3;

            txt_YerelToplamKdv.Text = toplamkdvtutari.ToString("N2");
            txt_YerelToplamIndirim.Text = iskontogeneltoplam.ToString("N2");
            if (ck_kdvdahil.Checked)
            {
                txt_YerelToplam.Text = iskontolugeneltutar.ToString("N2");
                txt_YerelToplamNet.Text = iskontolugeneltutar.ToString("N2");
            }
            else
            {
                txt_YerelToplam.Text = iskontolugeneltutar.ToString("N2");
                txt_YerelToplamNet.Text = nettoplam.ToString("N2");
            }
            txt_YerelToplamMasraf.Text = 0.ToString("N2");

            double dovizKuru = 0;
            string rtext = "";
            string raporlamaturu = lk_RaporlamaDoviz.EditValue.ToString();
            string islemturu = Lk_IslemDoviz.EditValue.ToString();

            L_CURRENCYLIST doviz = new L_CURRENCYLIST();

            if (GenelParaBirim.SelectedIndex == 0)
            {
                doviz = islem.DovizBilgisiGetir(firma, Convert.ToInt16(raporlamaturu));
                labelControl42.Text = "Raporlama Dövizi";
                if (btn_raporlamakuru.Text == "" || btn_raporlamakuru.Text == "0") { btn_raporlamakuru.Text = "1"; }
                dovizKuru = Convert.ToDouble(btn_raporlamakuru.Text);
                rtext = " " + doviz.CURSYMBOL;
                txt_raporlamanettoplam.Text = (Convert.ToDouble(txt_YerelToplamNet.Text) / dovizKuru).ToString("N2");
            }
            else
            {
                doviz = islem.DovizBilgisiGetir(firma, Convert.ToInt16(islemturu));
                labelControl42.Text = "İşlem Dövizi";
                if (btn_islemkuru.Text == "" || btn_islemkuru.Text == "0") { btn_islemkuru.Text = "1"; }
                dovizKuru = Convert.ToDouble(btn_islemkuru.Text);
                rtext = " " + doviz.CURSYMBOL;
                txt_islemnettoplam.Text = (Convert.ToDouble(txt_YerelToplamNet.Text) / dovizKuru).ToString("N2");
            }

            double dovizlitoplamindirim = Convert.ToDouble(txt_YerelToplamIndirim.Text) / dovizKuru;
            double dovizlitoplamkdv = Convert.ToDouble(txt_YerelToplamKdv.Text) / dovizKuru;
            double dovizlitoplam = Convert.ToDouble(txt_YerelToplam.Text) / dovizKuru;
            double dovizlinettoplam = Convert.ToDouble(txt_YerelToplamNet.Text) / dovizKuru;
            txt_DovizliToplamIndirim.Text = dovizlitoplamindirim.ToString("N2") + rtext;
            txt_DovizliToplamKdv.Text = dovizlitoplamkdv.ToString("N2") + rtext;
            txt_DovizliToplam.Text = dovizlitoplam.ToString("N2") + rtext;
            if (ck_kdvdahil.Checked)
            {
                txt_DovizliToplamNet.Text = dovizlitoplam.ToString("N2") + rtext;
            }
            else
            {
                txt_DovizliToplamNet.Text = dovizlinettoplam.ToString("N2") + rtext;
            }
            txt_DovizliToplamMasraf.Text = 0.ToString("N2") + rtext;
            double raporlamadovizkuru;
            if (btn_raporlamakuru.Text == "" || btn_raporlamakuru.Text == "0") { btn_raporlamakuru.Text = "1"; }
            raporlamadovizkuru = Convert.ToDouble(btn_raporlamakuru.Text);
            txt_raporlamanettoplam.Text = (Convert.ToDouble(txt_YerelToplamNet.Text) / raporlamadovizkuru).ToString("N2");

            double islemdovizkuru;
            if (btn_islemkuru.Text == "" || btn_islemkuru.Text == "0") { btn_islemkuru.Text = "1"; }
            islemdovizkuru = Convert.ToDouble(btn_islemkuru.Text);
            txt_islemnettoplam.Text = (Convert.ToDouble(txt_YerelToplamNet.Text) / islemdovizkuru).ToString("N2");

            double tltutar = Convert.ToDouble(txt_YerelToplamNet.Text);
            if (lk_onay.EditValue.ToString() != "2")
            {
                if (ana._Kullanici.TEKLIFTUTARILIMIT > 0)
                {
                    if (ana._Kullanici.TEKLIFTUTARILIMIT < tltutar)
                    {
                        lk_onay.Enabled = false;
                    }
                }

            }
        }
        private void Lk_IslemDoviz_EditValueChanged(object sender, EventArgs e)
        {
            using (LogoContext db = new LogoContext())
            {
                string crtype = Lk_IslemDoviz.EditValue.ToString();

                if (crtype == "0" || crtype == "160")
                {
                    btn_islemkuru.ReadOnly = true;
                }
                else
                {
                    btn_islemkuru.ReadOnly = false;
                }

                double dovizKuru = islem.RatesTarihDovizKuruDondur(parametre, firmaLogoBilgi, Convert.ToInt16(crtype), date_tarih.DateTime, firma, donem);
                if (dovizKuru == 0)
                {
                    btn_islemkuru.Text = "";
                    dovizKuru = 1;
                }
                else
                {
                    btn_islemkuru.Text = dovizKuru.ToString();
                }

                var raporlamaturu = lk_RaporlamaDoviz.EditValue.ToString();
                var islemturu = Lk_IslemDoviz.EditValue.ToString();

                List<LOGO_XERO_TEKLIF_SATIR> TeklifsatirListe = grid_TeklifSatirlari.DataSource as List<LOGO_XERO_TEKLIF_SATIR>;
                if (TeklifsatirListe != null)
                {
                    foreach (var item in TeklifsatirListe)
                    {
                        if (string.IsNullOrWhiteSpace(item.STOKADI)) { continue; }
                        if (crtype == "0" || crtype == "160")
                        {
                            if (item.SATIRDOVIZKODU == 0 || item.SATIRDOVIZKODU == 160)
                            {
                                item.DOVIZLIFIYAT = item.FIYAT;
                                item.SATIRDOVIZKODU = Convert.ToInt16(raporlamaturu);
                            }
                            else
                            {
                                var birimf = item.FIYAT * dovizKuru;
                                item.FIYAT = birimf;
                                item.DOVIZLIFIYAT = birimf;
                                item.SATIRDOVIZKODU = Convert.ToInt16(raporlamaturu);
                            }
                        }
                        else
                        {
                            if (item.SATIRDOVIZKODU == 0 || item.SATIRDOVIZKODU == 160)
                            {
                                item.DOVIZLIFIYAT = item.FIYAT / Convert.ToDouble(dovizKuru);
                                item.SATIRDOVIZKODU = Convert.ToInt16(islemturu);
                            }
                            else
                            {
                                item.DOVIZLIFIYAT = item.FIYAT / dovizKuru;
                                item.SATIRDOVIZKODU = Convert.ToInt16(islemturu);
                            }
                        }
                    }
                }
                if (crtype == "0" || crtype == "160")
                {
                    GenelParaBirim.SelectedIndex = 0;
                    SatirlarParaBirimi.SelectedIndex = 0;
                }
                else
                {
                    GenelParaBirim.SelectedIndex = 1;
                    SatirlarParaBirimi.SelectedIndex = 2;
                }



            }

            grid_TeklifSatirlari.RefreshDataSource();
            grid_TeklifSatirlari.Refresh();

            AltToplamlariHesapla();
        }
        private void GenelParaBirim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GenelParaBirim.SelectedIndex == 0)
            {
                labelControl42.Text = "Raporlama Dövizi";
            }
            else
            {
                labelControl42.Text = "İşlem Dövizi";
            }

            AltToplamlariHesapla();
        }
        private void SatirlarParaBirimi_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView view = grid_TeklifSatirlari.MainView as GridView;
            string raporlamaturu = lk_RaporlamaDoviz.EditValue.ToString();
            string islemturu = Lk_IslemDoviz.EditValue.ToString();
            List<LOGO_XERO_TEKLIF_SATIR> TeklifsatirListe = grid_TeklifSatirlari.DataSource as List<LOGO_XERO_TEKLIF_SATIR>;
            if (TeklifsatirListe != null)
            {
                foreach (var item in TeklifsatirListe)
                {
                    if (string.IsNullOrWhiteSpace(item.STOKADI)) { continue; }

                    if (item.DOVIZKURUTARIHI == null)
                    {
                        item.DOVIZKURUTARIHI = DateTime.Now;
                    }
                    if (SatirlarParaBirimi.SelectedIndex == 0 || SatirlarParaBirimi.SelectedIndex == 1)
                    {
                        item.DOVIZLIFIYAT = item.FIYAT / Convert.ToDouble(btn_raporlamakuru.Text);
                        item.SATIRDOVIZKODU = Convert.ToInt16(raporlamaturu);
                        item.SATIRDOVIZKURU = Convert.ToDouble(btn_raporlamakuru.Text);
                    }
                    else if (SatirlarParaBirimi.SelectedIndex == 2)
                    {
                        item.SATIRDOVIZKURU = Convert.ToDouble(btn_islemkuru.Text);
                        if (islemturu == "0" || islemturu == "160")
                        {
                            item.DOVIZLIFIYAT = item.FIYAT;
                            item.SATIRDOVIZKODU = Convert.ToInt16(islemturu);
                        }
                        else
                        {
                            item.DOVIZLIFIYAT = item.FIYAT / Convert.ToDouble(btn_islemkuru.Text);
                            item.SATIRDOVIZKODU = Convert.ToInt16(islemturu);
                        }
                    }
                    else
                    {
                        if (islemturu == "0" || islemturu == "160")
                        {
                            item.DOVIZLIFIYAT = item.FIYAT;
                            item.SATIRDOVIZKODU = Convert.ToInt16(islemturu);
                            item.SATIRDOVIZKURU = 1;
                        }
                        else
                        {
                            item.DOVIZLIFIYAT = item.FIYAT / Convert.ToDouble(btn_islemkuru.Text);
                            item.SATIRDOVIZKODU = Convert.ToInt16(islemturu);
                            item.SATIRDOVIZKURU = Convert.ToDouble(btn_islemkuru.Text);
                        }
                    }
                }
            }
            if (SatirlarParaBirimi.SelectedIndex == 0)
            {
                gv_TeklifSatirlari.Columns["SATIRDOVIZKURU"].OptionsColumn.AllowEdit = false;
                gv_TeklifSatirlari.Columns["DOVIZKURUTARIHI"].OptionsColumn.AllowEdit = false;
                gv_TeklifSatirlari.Columns["FIYAT"].OptionsColumn.AllowEdit = true;
                gv_TeklifSatirlari.Columns["DOVIZLIFIYAT"].OptionsColumn.AllowEdit = false;
                gv_TeklifSatirlari.Columns["SATIRDOVIZKODU"].OptionsColumn.AllowEdit = false;
            }
            else if (SatirlarParaBirimi.SelectedIndex == 1 || SatirlarParaBirimi.SelectedIndex == 2)
            {
                gv_TeklifSatirlari.Columns["SATIRDOVIZKURU"].OptionsColumn.AllowEdit = false;
                gv_TeklifSatirlari.Columns["DOVIZKURUTARIHI"].OptionsColumn.AllowEdit = false;
                gv_TeklifSatirlari.Columns["FIYAT"].OptionsColumn.AllowEdit = false;
                gv_TeklifSatirlari.Columns["DOVIZLIFIYAT"].OptionsColumn.AllowEdit = true;
                gv_TeklifSatirlari.Columns["SATIRDOVIZKODU"].OptionsColumn.AllowEdit = false;
            }
            else if (SatirlarParaBirimi.SelectedIndex == 3)
            {
                gv_TeklifSatirlari.Columns["SATIRDOVIZKURU"].OptionsColumn.AllowEdit = true;
                gv_TeklifSatirlari.Columns["DOVIZKURUTARIHI"].OptionsColumn.AllowEdit = true;
                gv_TeklifSatirlari.Columns["FIYAT"].OptionsColumn.AllowEdit = false;
                gv_TeklifSatirlari.Columns["DOVIZLIFIYAT"].OptionsColumn.AllowEdit = true;
                gv_TeklifSatirlari.Columns["SATIRDOVIZKODU"].OptionsColumn.AllowEdit = true;
            }
            AltToplamlariHesapla();
            grid_TeklifSatirlari.Refresh();
            grid_TeklifSatirlari.RefreshDataSource();
        }
        private void gv_TeklifSatirlari_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            tevkifatHesaplandi = 1;
            //TevkifatiGeriAl();

            LOGO_XERO_TEKLIF_SATIR row = (LOGO_XERO_TEKLIF_SATIR)gv_TeklifSatirlari.GetRow(e.RowHandle);

            int stoklogicalref = Convert.ToInt32(row.STOKLOGICALREF); 

            double fiyat = Convert.ToDouble(row.FIYAT);
            double netfiyat = Convert.ToDouble(row.NETFIYAT);
            double dovizlifiyat = Convert.ToDouble(row.DOVIZLIFIYAT);
            double miktar = Convert.ToDouble(row.MIKTAR);
            double kdv = Convert.ToDouble(row.KDV);
            double tutar = Convert.ToDouble(row.TUTAR);
            double toplamtutar = Convert.ToDouble(row.TOPLAMTUTAR);
            int tur = Convert.ToInt32(row.TUR);
            double iskontolututar = Convert.ToDouble(row.ISKONTOLUTUTAR);
            double iskontoYuzdesi1 = 0;
            double iskontoYuzdesi2 = 0;
            double iskontoYuzdesi3 = 0;
            double toplamiskontotutar = 0;


            if (row.SATIRDOVIZKODU == null)
            {
                if (SatirlarParaBirimi.SelectedIndex == 0 || SatirlarParaBirimi.SelectedIndex == 1 || SatirlarParaBirimi.SelectedIndex == 3)
                {
                    row.SATIRDOVIZKODU = Convert.ToInt16(lk_RaporlamaDoviz.EditValue);
                }
                else
                {
                    row.SATIRDOVIZKODU = Convert.ToInt16(Lk_IslemDoviz.EditValue);
                }
            }

            if (row.SATIRDOVIZKURU == null || row.SATIRDOVIZKURU == 0)
            {
                if (SatirlarParaBirimi.SelectedIndex == 0 || SatirlarParaBirimi.SelectedIndex == 1 || SatirlarParaBirimi.SelectedIndex == 3)
                {
                    row.SATIRDOVIZKURU = Convert.ToDouble(btn_raporlamakuru.EditValue);
                }
                else
                {
                    row.SATIRDOVIZKURU = Convert.ToDouble(btn_islemkuru.EditValue);
                }
            }

            double kur = 1;
            if (SatirlarParaBirimi.SelectedIndex == 0 || SatirlarParaBirimi.SelectedIndex == 1)
            {
                kur = Convert.ToDouble(btn_raporlamakuru.Text);
            }
            else if (SatirlarParaBirimi.SelectedIndex == 2)
            {
                kur = Convert.ToDouble(btn_islemkuru.Text);
            }
            else
            {
                kur = Convert.ToDouble(row.SATIRDOVIZKURU);
            }
            DateTime kurtarihi = date_tarih.DateTime;
            if (row.DOVIZKURUTARIHI != null)
            {
                kurtarihi = Convert.ToDateTime(row.DOVIZKURUTARIHI);
            }
            else
            {
                row.DOVIZKURUTARIHI = date_tarih.DateTime;
            }

            if (row.TEVKIFATLI == null)
            {
                row.TEVKIFATLI = false;
            }

            if (row.ISKONTOYUZDESI1 != null)
            {
                iskontoYuzdesi1 = Convert.ToDouble(row.ISKONTOYUZDESI1);
            }
            if (row.ISKONTOYUZDESI2 != null)
            {
                iskontoYuzdesi2 = Convert.ToDouble(row.ISKONTOYUZDESI2);
            }
            if (row.ISKONTOYUZDESI3 != null)
            {
                iskontoYuzdesi3 = Convert.ToDouble(row.ISKONTOYUZDESI3);
            }

            double[] iskontolar = new double[] { iskontoYuzdesi1, iskontoYuzdesi2, iskontoYuzdesi3 }; 
            if (miktar == 0 && tur == 1)
            {
                row.MIKTAR = 1;
                row.KDVTUTARI = 0;
                row.KDV = 0;
                row.TUTAR = 0;
                row.BIRIM = ana.anabirim.CODE;
                row.FIYAT = 0;
                row.DOVIZLIFIYAT = 0;
                row.ISKONTOYUZDESI1 = 0;
                row.ISKONTOYUZDESI2 = 0;
                row.ISKONTOYUZDESI3 = 0;
                row.ISKONTOTUTARI1 = 0;
                row.ISKONTOTUTARI2 = 0;
                row.ISKONTOTUTARI3 = 0;
                row.ISKONTOLUTUTAR = 0;
                row.TOPLAMTUTAR = 0;
                row.NETFIYAT = 0;
                row.SATIRDOVIZKURU = 0;
            }
            else
            { 
                if (e.Column.FieldName == "ISKONTOYUZDESI1" || e.Column.FieldName == "ISKONTOYUZDESI2" || e.Column.FieldName == "ISKONTOYUZDESI3")
                {
                    
                    tutar = fiyat * miktar;
                    row.TUTAR = tutar;
                    row.ISKONTOLUTUTAR = tutar;

                    double kdvtutarihesap, kdvtutari;
                    if (kdv > 0)
                    {
                        if (ck_kdvdahil.Checked)
                        {
                            kdvtutarihesap = tutar / (1 + kdv / 100);
                            kdvtutari = tutar - kdvtutarihesap;
                            toplamtutar = tutar;
                        }
                        else
                        {
                            kdvtutarihesap = tutar * (1 + kdv / 100);
                            kdvtutari = kdvtutarihesap - tutar;
                            toplamtutar = tutar + kdvtutari;
                        }
                    }
                    else
                    {
                        kdvtutari = 0;
                        toplamtutar = tutar;
                    }
                    double iskontoSonrasiTutar = tutar;
                    double toplamiskonto = 0;
                    for (int i = 1; i <= 3; i++)
                    {
                        double iskontoyuzdesi = Convert.ToDouble(gv_TeklifSatirlari.GetRowCellValue(e.RowHandle, gv_TeklifSatirlari.Columns["ISKONTOYUZDESI" + i]));
                        double iskontotutari = 0;
                        if (iskontoyuzdesi == 0)
                        {
                            gv_TeklifSatirlari.SetRowCellValue(e.RowHandle, gv_TeklifSatirlari.Columns["ISKONTOTUTARI" + i], 0.ToString("N2"));
                        }
                        else
                        {
                            iskontotutari = (iskontoSonrasiTutar * iskontoyuzdesi) / 100;
                            gv_TeklifSatirlari.SetRowCellValue(e.RowHandle, gv_TeklifSatirlari.Columns["ISKONTOTUTARI" + i], iskontotutari.ToString("N2"));

                            iskontoSonrasiTutar -= iskontotutari;
                        }
                        toplamiskonto += iskontotutari;
                    }

                    row.ISKONTOLUTUTAR = iskontoSonrasiTutar;

                    netfiyat = iskontoSonrasiTutar / miktar;
                    row.NETFIYAT = netfiyat;

                    if (kdv > 0)
                    {
                        if (ck_kdvdahil.Checked)
                        {
                            kdvtutarihesap = iskontoSonrasiTutar / (1 + kdv / 100);
                            kdvtutari = iskontoSonrasiTutar - kdvtutarihesap;
                            toplamtutar = iskontoSonrasiTutar;
                            row.ISKONTOLUTUTAR = toplamtutar - kdvtutari;
                        }
                        else
                        {
                            kdvtutarihesap = iskontoSonrasiTutar * (1 + kdv / 100);
                            kdvtutari = kdvtutarihesap - iskontoSonrasiTutar;
                            toplamtutar = iskontoSonrasiTutar + kdvtutari; 
                        }
                    }
                    else
                    {
                        kdvtutari = 0;
                        toplamtutar = iskontoSonrasiTutar;
                    }

                    row.KDVTUTARI = kdvtutari;
                    row.TOPLAMTUTAR = toplamtutar;

                    //gv_TeklifSatirlari.SetRowCellValue(e.RowHandle,"TOPLTUTAR", toplamtutar);
                    // TevkifatHesapla(); sildim
                }
                if (e.Column.FieldName == "TOPLAMTUTAR")
                {
                    tevkifathesapla2();
                }
                if (e.Column.FieldName == "FIYAT" || e.Column.FieldName == "KDV" || e.Column.FieldName == "MIKTAR" || e.Column.FieldName == "DOVIZLIFIYAT" || e.Column.FieldName == "SATIRDOVIZKODU" || e.Column.FieldName == "DOVIZKURUTARIHI" || e.Column.FieldName == "SATIRDOVIZKURU" || e.Column.FieldName == "MIKTAR" )
                {
                    
                    if (e.Column.FieldName == "SATIRDOVIZKODU")
                    {
                        Int16 satirdovizkodu = Convert.ToInt16(row.SATIRDOVIZKODU);
                        DateTime dovizkuruTarihi = Convert.ToDateTime(row.DOVIZKURUTARIHI);
                        kur = islem.RatesTarihDovizKuruDondur(parametre, firmaBilgisi, satirdovizkodu, dovizkuruTarihi, firma, donem);
                        row.SATIRDOVIZKURU = kur;
                        if (kur == 0) kur = 1;

                    }

                    if (e.Column.FieldName == "DOVIZKURUTARIHI")
                    {
                        Int16 satirdovizkodu = Convert.ToInt16(row.SATIRDOVIZKODU);
                        kur = islem.RatesTarihDovizKuruDondur(parametre, firmaBilgisi, satirdovizkodu, kurtarihi, firma, donem);
                        if (kur == 0) kur = 1;
                        row.SATIRDOVIZKURU = kur;
                    }
                    if (e.Column.FieldName == "SATIRDOVIZKURU")
                    {
                        kur = Convert.ToDouble(row.SATIRDOVIZKURU);
                        if (kur == 0) kur = 1;
                    } 
                    if (e.Column.FieldName == "DOVIZLIFIYAT")
                    {
                        fiyat = Convert.ToDouble(kur * row.DOVIZLIFIYAT);
                        row.FIYAT = fiyat;

                        if (kur == 0) kur = 1;
                    }
                  

                    if (SatirlarParaBirimi.SelectedIndex == 0)
                    {
                        dovizlifiyat = Math.Round(fiyat / kur, 2, MidpointRounding.AwayFromZero);
                        row.DOVIZLIFIYAT = dovizlifiyat;
                    }
                    if (SatirlarParaBirimi.SelectedIndex == 1 || SatirlarParaBirimi.SelectedIndex == 2 || SatirlarParaBirimi.SelectedIndex == 3)
                    {
                        fiyat = Math.Round(dovizlifiyat * kur, 2, MidpointRounding.AwayFromZero);
                        row.FIYAT = fiyat;

                    }
                    tutar = Math.Round(miktar * Math.Round(fiyat, 5), 2, MidpointRounding.AwayFromZero);

                    if (ck_kdvdahil.Checked)
                    {
                        toplamiskontotutar = Math.Round((tutar / (1 + (kdv / 100))), 5) - Math.Round(islem.IndirimliFiyatHesapla(tutar / (1 + (kdv / 100)), iskontolar), 2, MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        double indirimlifiy = Math.Round(islem.IndirimliFiyatHesapla(tutar, iskontolar), 3, MidpointRounding.AwayFromZero);
                        decimal ikifiy = Convert.ToDecimal(tutar - indirimlifiy);
                        toplamiskontotutar = Math.Round(Convert.ToDouble(ikifiy), 2, MidpointRounding.AwayFromZero);
                    }


                    iskontolututar = Math.Round(Math.Round(tutar, 5) - Math.Round(toplamiskontotutar, 5), 2, MidpointRounding.AwayFromZero);
                    if (miktar == 0) miktar = 1;
                    netfiyat = Math.Round(iskontolututar, 5) / miktar;

                    double kdvTutari = 0;
                    if (ck_kdvdahil.Checked)
                    {
                        kdvTutari = Math.Round((Math.Round(tutar, 5) - Math.Round(toplamiskontotutar, 5)) / (1 + (kdv / 100)) * kdv / 100, 5, MidpointRounding.AwayFromZero);
                        toplamtutar = Math.Round(Math.Round(iskontolututar, 2) - kdvTutari, 2, MidpointRounding.AwayFromZero);
                    }
                    else
                    {

                        kdvTutari = Math.Round(((Math.Round(tutar, 5) - Math.Round(toplamiskontotutar, 5)) * kdv) / 100, 5, MidpointRounding.AwayFromZero);
                        toplamtutar = Math.Round((Math.Round((Math.Round(tutar, 5) - Math.Round(toplamiskontotutar, 5)), 2) + Math.Round(kdvTutari, 2)), 2, MidpointRounding.AwayFromZero);

                    }
                    row.NETFIYAT = netfiyat;
                    row.TUTAR = Math.Round(tutar, 2, MidpointRounding.AwayFromZero);
                    row.ISKONTOLUTUTAR = iskontolututar;
                    row.KDVTUTARI = kdvTutari;
                    row.TOPLAMTUTAR = toplamtutar;
                    gv_TeklifSatirlari.SetRowCellValue(gv_TeklifSatirlari.FocusedRowHandle, grdIskontoYuzdesi1, iskontoYuzdesi1);
                    //TevkifatHesapla();siliyom 
                }
                if (e.Column.FieldName == "TEVKIFATBOLEN" || e.Column.FieldName == "TEVKIFATCARPAN" || e.Column.FieldName == "KDV"  )
                {
                    tevkifathesapla2();
                } 
            } 
            grid_TeklifSatirlari.RefreshDataSource();
            grid_TeklifSatirlari.Refresh();
            tevkifatHesaplandi = 0; 
            AltToplamlariHesapla();
        }
         
        private void btn_raporlamakuru_EditValueChanged(object sender, EventArgs e)
        {
            string raporlamaturu = lk_RaporlamaDoviz.EditValue.ToString();
            string islemturu = Lk_IslemDoviz.EditValue.ToString();

            var raporlamakuru = btn_raporlamakuru.Text;
            var islemkuru = btn_islemkuru.Text;

            if (raporlamakuru == "" || raporlamakuru == "0")
            {
                raporlamakuru = "1";
            }
            if (islemkuru == "" || islemkuru == "0")
            {
                islemkuru = "1";
            }
            List<LOGO_XERO_TEKLIF_SATIR> TeklifsatirListe = grid_TeklifSatirlari.DataSource as List<LOGO_XERO_TEKLIF_SATIR>;

            if (TeklifsatirListe != null)
            {
                foreach (var item in TeklifsatirListe)
                {
                    if (string.IsNullOrWhiteSpace(item.STOKADI)) { continue; }

                    if (SatirlarParaBirimi.SelectedIndex == 0 || SatirlarParaBirimi.SelectedIndex == 1)
                    {
                        item.DOVIZLIFIYAT = item.FIYAT / Convert.ToDouble(raporlamakuru);
                        item.SATIRDOVIZKODU = Convert.ToInt16(raporlamaturu);
                    }
                    else if (SatirlarParaBirimi.SelectedIndex == 2)
                    {
                        if (islemturu == "0" || islemturu == "160")
                        {
                            item.DOVIZLIFIYAT = item.FIYAT;
                            item.SATIRDOVIZKODU = Convert.ToInt16(islemturu);
                        }
                        else
                        {
                            item.DOVIZLIFIYAT = item.FIYAT / Convert.ToDouble(islemkuru);
                            item.SATIRDOVIZKODU = Convert.ToInt16(islemturu);
                        }
                    }
                    else
                    {
                        using (LogoContext db = new LogoContext())
                        {
                            double dovizKuru = islem.RatesTarihDovizKuruDondur(parametre, firmaBilgisi, item.SATIRDOVIZKODU, Convert.ToDateTime(item.DOVIZKURUTARIHI), firma, donem);
                            if (dovizKuru == 0) { dovizKuru = 1; }
                            item.SATIRDOVIZKODU = item.SATIRDOVIZKODU;
                            item.DOVIZLIFIYAT = item.FIYAT / dovizKuru;
                        }
                    }
                }
            }
            grid_TeklifSatirlari.RefreshDataSource();
            grid_TeklifSatirlari.Refresh();

            AltToplamlariHesapla();
        }
        private void btn_islemkuru_EditValueChanged(object sender, EventArgs e)
        {
            string raporlamaturu = lk_RaporlamaDoviz.EditValue.ToString();
            string islemturu = Lk_IslemDoviz.EditValue.ToString();

            var raporlamakuru = btn_raporlamakuru.Text;
            var islemkuru = btn_islemkuru.Text;

            if (raporlamakuru == "" || raporlamakuru == "0")
            {
                raporlamakuru = "1";
            }
            if (islemkuru == "" || islemkuru == "0")
            {
                islemkuru = "1";
            }

            List<LOGO_XERO_TEKLIF_SATIR> TeklifsatirListe = grid_TeklifSatirlari.DataSource as List<LOGO_XERO_TEKLIF_SATIR>;

            if (TeklifsatirListe != null)
            {
                foreach (var item in TeklifsatirListe)
                {
                    if (string.IsNullOrWhiteSpace(item.STOKADI)) { continue; }

                    if (SatirlarParaBirimi.SelectedIndex == 0 || SatirlarParaBirimi.SelectedIndex == 1)
                    {
                        item.DOVIZLIFIYAT = item.FIYAT / Convert.ToDouble(raporlamakuru);
                        item.SATIRDOVIZKODU = Convert.ToInt16(raporlamaturu);
                    }
                    else if (SatirlarParaBirimi.SelectedIndex == 2)
                    {
                        if (islemturu == "0" || islemturu == "160")
                        {
                            item.DOVIZLIFIYAT = item.FIYAT;
                            item.SATIRDOVIZKODU = Convert.ToInt16(islemturu);
                        }
                        else
                        {
                            item.DOVIZLIFIYAT = item.FIYAT / Convert.ToDouble(islemkuru);
                            item.SATIRDOVIZKODU = Convert.ToInt16(islemturu);
                        }
                    }
                    else
                    {
                        using (LogoContext db = new LogoContext())
                        {
                            double dovizKuru = islem.RatesTarihDovizKuruDondur(parametre, firmaBilgisi, item.SATIRDOVIZKODU, Convert.ToDateTime(item.DOVIZKURUTARIHI), firma, donem);
                            if (dovizKuru == 0) { dovizKuru = 1; }
                            item.SATIRDOVIZKODU = item.SATIRDOVIZKODU;
                            item.DOVIZLIFIYAT = item.FIYAT / dovizKuru;
                        }
                    }
                }
            }
            grid_TeklifSatirlari.Refresh();
            grid_TeklifSatirlari.RefreshDataSource();

            AltToplamlariHesapla();
        }

        private void btn_cariKodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextEdit ts = sender as TextEdit;
                var kod = ts.Text;
                if (kod == "")
                {
                    XtraMessageBox.Show("Cari Kod Giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                var liste = islem.CariGetir(kod, ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString());
                if (liste.Count == 0)
                {
                    XtraMessageBox.Show("Cari Bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lbl_cariref.Text = "0";
                    btn_cariKodu.Text = "";
                    btn_cariUnvani.Text = "";
                    txt_Eposta.Text = "";
                    txt_Eposta2.Text = "";
                    txt_Yetkili.Text = "";
                    lk_OdemeTipi.EditValue = "";
                    txt_Adres1.Text = "";
                    txt_Adres2.Text = "";
                    txt_Ulke.Text = "";
                    txt_Il.Text = "";
                    txt_Ilce.Text = "";
                    txt_VergiDairesi.Text = "";
                    txt_Telefon.Text = "";
                    txt_Fax.Text = "";
                    txt_PostaKodu.Text = "";
                    txt_VergiNo.Text = "";
                    Efatura_resim.Visible = false;
                    btn_ticariIslemGuruplari.Text = "";

                    return;
                }
                else
                {
                    var cari = liste.FirstOrDefault();
                    if (Trkod == 1 && cari.CARDTYPE == 1)
                    {
                        XtraMessageBox.Show("Cari Hesap Türü Uygun Değil !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    if (Trkod == 8 && cari.CARDTYPE == 2)
                    {
                        XtraMessageBox.Show("Cari Hesap Türü Uygun Değil !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    lbl_cariref.Text = cari.LOGICALREF.ToString();
                    btn_cariKodu.Text = cari.CODE;
                    btn_cariUnvani.Text = cari.DEFINITION_;
                    txt_Eposta.Text = cari.EPOSTA;
                    txt_Eposta2.Text = cari.EPOSTA2;
                    txt_Yetkili.Text = cari.YETKILISI;
                    lk_OdemeTipi.EditValue = cari.PAYMENTREF;
                    txt_Adres1.Text = cari.ADRES1;
                    txt_Adres2.Text = cari.ADRES2;
                    txt_Ulke.Text = cari.ULKE;
                    txt_Il.Text = cari.SEHIR;
                    txt_Ilce.Text = cari.ILCE;
                    txt_VergiDairesi.Text = cari.VERGIDAIRESI;
                    txt_Telefon.Text = cari.TELEFON1;
                    txt_Fax.Text = cari.FAXNR;
                    txt_PostaKodu.Text = cari.POSTAKODU;
                    txt_VergiNo.Text = cari.TAXNR;
                    if (cari.EFATURA == 1)
                    {
                        Efatura_resim.Visible = true;
                    }
                    else
                    {
                        Efatura_resim.Visible = false;
                    }
                    btn_ticariIslemGuruplari.Text = cari.TICARIISLEMGURUBU;
                }
            }
            if (e.KeyCode == Keys.F10)
            {
                TextEdit ts = sender as TextEdit;
                var kod = ts.Text;

                if (kod == "")
                {
                    XtraMessageBox.Show("Cari Kod Giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                frmCariListesi frmCari = new frmCariListesi(this);
                frmCari.tip = 1;
                frmCari.kod = kod;
                frmCari.ShowDialog();
            }

            Uyari(sender, e);
        }
        private void ck_kdvdahil_CheckedChanged(object sender, EventArgs e)
        {
            List<LOGO_XERO_TEKLIF_SATIR> TeklifsatirListe = grid_TeklifSatirlari.DataSource as List<LOGO_XERO_TEKLIF_SATIR>;
            if (ck_kdvdahil.Checked)
            {
                foreach (var item in TeklifsatirListe)
                {
                    if (string.IsNullOrWhiteSpace(item.STOKADI)) { continue; }

                    //item.ISKONTOLUTUTAR = item.NETFIYAT * item.MIKTAR;
                    item.KDVTUTARI = item.ISKONTOLUTUTAR - (item.ISKONTOLUTUTAR / (1 + item.KDV / 100));
                    item.ISKONTOLUTUTAR = item.TOPLAMTUTAR - item.KDVTUTARI;
                    item.TOPLAMTUTAR = Convert.ToDouble(item.ISKONTOLUTUTAR + item.KDVTUTARI);
                }
            }
            else
            {
                foreach (var item in TeklifsatirListe)
                {
                    if (string.IsNullOrWhiteSpace(item.STOKADI)) { continue; }

                    item.KDVTUTARI = item.ISKONTOLUTUTAR * ( item.KDV / 100); 
                    item.TOPLAMTUTAR = item.ISKONTOLUTUTAR + item.KDVTUTARI;
                }
            }

            grid_TeklifSatirlari.RefreshDataSource();
            grid_TeklifSatirlari.Refresh();

            tevkifatHesaplandi = 1;
            TevkifatiGeriAl();
            tevkifathesapla2();
            AltToplamlariHesapla();
        }

        private int tevkifatHesaplandi = 0;
        private void btn_tevkifat_Click(object sender, EventArgs e)
        {
            
        }
        public void TevkifatHesapla()
        {
            TevkifatiGeriAl();
            List<LOGO_XERO_TEKLIF_SATIR> TeklifsatirListe = grid_TeklifSatirlari.DataSource as List<LOGO_XERO_TEKLIF_SATIR>;
            double sum = Convert.ToDouble(TeklifsatirListe.Sum(s => s.TOPLAMTUTAR));
            if (sum >= firmatevkifatLimiti)
            {   
            panelControl6.Visible = true;
            double kdvTop = 0;
            double tevTop = 0;
            double netTop = 0;
            double normalKdv = 0;
            double normalKdvToplamTutar = 0;
            double islemegirmedenkdv = 0;
            double islemegirmedentoplamtutar = 0;


            var norKdvTop_ = TeklifsatirListe.Where(v => v.TEVKIFATLI == true).Sum(v => (v.ISKONTOLUTUTAR * (v.KDV + 100) / 100));

            var kdvTut_ = TeklifsatirListe.Sum(v => (v.ISKONTOLUTUTAR * (v.KDV) / 100));

            var tklikdvtop = TeklifsatirListe.Where(v => v.TEVKIFATLI == true).Sum(v => ((v.ISKONTOLUTUTAR * (v.KDV) / 100) * v.TEVKIFATCARPAN / v.TEVKIFATBOLEN)) ; //değişti

            var tkliMuavKdv = kdvTut_ - tklikdvtop;

            foreach (var item in TeklifsatirListe)
            {
                if (string.IsNullOrWhiteSpace(item.STOKADI)) { continue; }
                if ((bool)!item.TEVKIFATLI) { continue; }
                islemegirmedentoplamtutar += (double)item.TOPLAMTUTAR;  //tevkifatlıların toplam tutarı
            }

            foreach (var item in TeklifsatirListe)
            {
                if (string.IsNullOrWhiteSpace(item.STOKADI)) { continue; }
                islemegirmedenkdv += (double)item.KDVTUTARI;  //toplam kdv tutarı 
            }

            foreach (var item in TeklifsatirListe)
            {
                    //tevkifatlı satırın kdv tutarı hesaplama
                if (string.IsNullOrWhiteSpace(item.STOKADI)) { continue; }
                if ((bool)!item.TEVKIFATLI) { continue; }
                double kdvfiyat = 0;
                double kdvtevk = 0;
                double kdvtutari = 0;
                double indirimliTutar = item.ISKONTOLUTUTAR == null ? 0 : (double)item.ISKONTOLUTUTAR;
                double toplamTutar = item.TOPLAMTUTAR == null ? 0 : (double)item.TOPLAMTUTAR;

                double kdv = (double)(item.ISKONTOLUTUTAR * item.KDV / 100);
                    //kdv -> item.kdvtutarı
                kdvtevk = (double)(item.KDVTUTARI * (item.TEVKIFATCARPAN / item.TEVKIFATBOLEN));
                kdvtutari = (double)item.KDVTUTARI - kdvtevk;
                if (!ck_kdvdahil.Checked)
                {
                    item.TOPLAMTUTAR = indirimliTutar + kdvtutari;
                }
                normalKdv += indirimliTutar;
                normalKdvToplamTutar += toplamTutar;
                kdvTop += kdvfiyat;
                netTop += kdvtevk;
                tevTop += kdvtutari;

                item.KDVTUTARI = kdvtutari;
            }
            double netkdvtutari = 0;
            foreach (var item in TeklifsatirListe)
            {
                if (string.IsNullOrWhiteSpace(item.STOKADI)) { continue; }
                netkdvtutari += (double)item.KDVTUTARI;
            }

            //txt_normKdv.Text = islemegirmedentoplamtutar.ToString("N2");
            txt_kdvTop.Text = islemegirmedenkdv.ToString("N2");
            double tevvtop = islemegirmedenkdv - netkdvtutari;
            txt_netTop.Text = netkdvtutari.ToString("N2");
            txt_tevTop.Text = tevvtop.ToString("N2");

            grid_TeklifSatirlari.RefreshDataSource();
            grid_TeklifSatirlari.Refresh();

            tevkifatHesaplandi = 1;
            AltToplamlariHesapla();
            }
            else
            {
                panelControl6.Visible = false;
            }
        }

        public void tevkifathesapla2() {
            List<LOGO_XERO_TEKLIF_SATIR> TeklifsatirListe = grid_TeklifSatirlari.DataSource as List<LOGO_XERO_TEKLIF_SATIR>;
            double toplamkdvli = 0;
            foreach (var item in TeklifsatirListe)
            {
                if (item.TEVKIFATLI == true)
                {
                      //if (ck_kdvdahil.Checked==true)
                      //{
                      //  toplamkdvli += Convert.ToDouble(item.ISKONTOLUTUTAR+ item.KDVTUTARI);
                      //}
                      //else
                      //{
                        toplamkdvli += Convert.ToDouble(item.ISKONTOLUTUTAR + item.ISKONTOLUTUTAR * (item.KDV / 100));
                     // } 
                }
            }
           // double sum = Convert.ToDouble(TeklifsatirListe.Where(s => s.TEVKIFATLI == true).Sum(s => s.TOPLAMTUTAR));
            double sum = toplamkdvli;
            if (sum >= firmatevkifatLimiti)
            {
                 panelControl6.Visible = true; 
                List<LOGO_XERO_TEKLIF_SATIR> satirlar = gv_TeklifSatirlari.DataSource as List<LOGO_XERO_TEKLIF_SATIR>;
                if (satirlar != null)
                { 
                    double muafkdvtutari = 0;
                    double normalkdvtutari = 0;
                    double netkdvtutari = 0;
                    double tevftoplamtutar = 0;
                    foreach (var item in satirlar)
                    {
                        double kdv = 0;
                        if (ck_kdvdahil.Checked == false)
                        {
                             kdv = Convert.ToDouble(item.ISKONTOLUTUTAR * (item.KDV / 100));
                        }
                        else
                        {
                            kdv = Convert.ToDouble(item.ISKONTOLUTUTAR * (100 / (100 + item.KDV)));
                            kdv = Convert.ToDouble(item.ISKONTOLUTUTAR - kdv);
                        }
                        
                        if ((bool)item.TEVKIFATLI)
                        {
                             
                                //  double muafkdv = ; //muaf oldugu kısım
                                if (item.TEVKIFATBOLEN != 0)
                                {
                                    item.KDVTUTARI = kdv - kdv * (item.TEVKIFATCARPAN / item.TEVKIFATBOLEN);
                                    muafkdvtutari += Convert.ToDouble(kdv * (item.TEVKIFATCARPAN / item.TEVKIFATBOLEN));
                                    tevftoplamtutar += Convert.ToDouble(item.TOPLAMTUTAR);
                                }
                                else
                                {
                                    item.KDVTUTARI = kdv;
                                }   
                        } 
                        item.TOPLAMTUTAR = item.ISKONTOLUTUTAR + item.KDVTUTARI;
                         
                        normalkdvtutari += kdv;
                    }
                    netkdvtutari = normalkdvtutari - muafkdvtutari; 
                    //txt_normKdv.Text = tevftoplamtutar.ToString("N2");
                    txt_kdvTop.Text = normalkdvtutari.ToString("N2");
                    txt_tevTop.Text = muafkdvtutari.ToString("N2");
                    txt_netTop.Text = (normalkdvtutari - muafkdvtutari).ToString("N2");

                }
            }
            else
            {
                panelControl6.Visible = false;
            }
        }
        private void TevkifatiGeriAl()
        {
            if (tevkifatHesaplandi == 1)
            {
                List<LOGO_XERO_TEKLIF_SATIR> TeklifsatirListe = grid_TeklifSatirlari.DataSource as List<LOGO_XERO_TEKLIF_SATIR>;

                foreach (var item in TeklifsatirListe)
                {
                    if (string.IsNullOrWhiteSpace(item.STOKADI)) { continue; }
                    if (item.TEVKIFATLI == null) continue;

                    if ((bool)!item.TEVKIFATLI) { continue; }
                    if (item.KDV == null) { item.KDV = 0; }
                    double kdvtutarihesap;
                    double kdvfiyat;
                    double kdvtutari;
                    double indirimliTutar = item.ISKONTOLUTUTAR == null ? 0 : (double)item.ISKONTOLUTUTAR;

                    if (ck_kdvdahil.Checked)
                    {
                        kdvtutarihesap = (double)(indirimliTutar / (1 + (item.KDV / 100)));
                        kdvfiyat = indirimliTutar - kdvtutarihesap;
                    }
                    else
                    {
                        kdvtutarihesap = (double)(indirimliTutar * (1 + (item.KDV / 100)));
                        kdvfiyat = kdvtutarihesap - indirimliTutar;
                        item.TOPLAMTUTAR = indirimliTutar + kdvfiyat;
                    }

                    kdvtutari = kdvfiyat;
                    item.KDVTUTARI = kdvtutari;
                }

                //txt_normKdv.Text = 0.ToString("N2");
                txt_kdvTop.Text = 0.ToString("N2");
                txt_netTop.Text = 0.ToString("N2");
                txt_tevTop.Text = 0.ToString("N2");
                grid_TeklifSatirlari.RefreshDataSource();
                grid_TeklifSatirlari.Refresh();
                tevkifatHesaplandi = 0;
                AltToplamlariHesapla();
            }
        }
        private void btn_raporlamakuru_Click(object sender, EventArgs e)
        {
            string raporlamaturu = lk_RaporlamaDoviz.EditValue.ToString();
            double dovizKuru = islem.RatesTarihDovizKuruDondur(parametre, firmaBilgisi, Convert.ToInt16(raporlamaturu), date_tarih.DateTime, firma, donem);
            if (dovizKuru == 0) { dovizKuru = 1; }
            btn_raporlamakuru.Text = dovizKuru.ToString("N2");
            AltToplamlariHesapla();
        }

        private void btn_islemkuru_Click(object sender, EventArgs e)
        {
            string islemturu = Lk_IslemDoviz.EditValue.ToString();
            double dovizKuru = islem.RatesTarihDovizKuruDondur(parametre, firmaBilgisi, Convert.ToInt16(islemturu), date_tarih.DateTime, firma, donem);
            if (dovizKuru == 0) { dovizKuru = 1; }
            btn_islemkuru.Text = dovizKuru.ToString("N2");
            AltToplamlariHesapla();
        }

        private void grid_TeklifSatirlari_ProcessGridKey(object sender, KeyEventArgs e)
        {
            List<LOGO_XERO_TEKLIF_SATIR> TeklifsatirListe = grid_TeklifSatirlari.DataSource as List<LOGO_XERO_TEKLIF_SATIR>;
            if (e.Shift && e.KeyCode == Keys.Delete)
            {
                if (lk_onay.EditValue.ToString() == "2")
                {
                    return;
                }
                if (MessageBox.Show("Satır Silinecektir!", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int rowHandle = gv_TeklifSatirlari.FocusedRowHandle;
                    gv_TeklifSatirlari.DeleteRow(rowHandle);
                    tevkifatHesaplandi = 1;
                    TevkifatiGeriAl();
                    AltToplamlariHesapla();
                }
                e.Handled = true;

                if (TeklifsatirListe.Count == 0)
                {
                    SatirEkle();
                }
            }
            if (e.Shift && e.KeyCode == Keys.Insert)
            {
                if (lk_onay.EditValue.ToString() == "2")
                {
                    return;
                }
                SatirEkle();
                e.SuppressKeyPress = true;
                e.Handled = true;
            } 
            SiraNoYenile();
        }

        
        private void lk_onay_EditValueChanged(object sender, EventArgs e)
        {
            if (lk_onay.EditValue.ToString() == "1")
            {
                if (lk_durum.EditValue != null)
                {
                    if (lk_durum.EditValue.ToString() == "3")
                    {
                        XtraMessageBox.Show("Teklifte Onaylanan Miktarlar Var ! Teklifi Onay Bekliyora Çevirebilmeniz İçin Önce Teklif Hazırlandı Durumuna Getirin !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        lk_onay.EditValue = lk_onay.OldEditValue;
                        return;
                    }
                }

                using (LogoContext db = new LogoContext())
                {
                    LOGO_XERO_TEKLIF_BASLIK tklfbslk = db.LOGO_XERO_TEKLIF_BASLIK.Where(s => s.ID == Teklifid).FirstOrDefault();
                    if (tklfbslk != null)
                    {
                        tklfbslk.ONAYDURUMU = Convert.ToInt32(lk_onay.EditValue);
                        db.LOGO_XERO_TEKLIF_BASLIK.AddOrUpdate(tklfbslk);
                        db.SaveChanges();
                        Teklifid = tklfbslk.ID;
                    }
                }
                List<LOGO_XERO_TEKLIF_SATIR> satrlar = (List<LOGO_XERO_TEKLIF_SATIR>)gv_TeklifSatirlari.DataSource;
                if (satrlar != null)
                {
                    bool bosvar = false;
                    foreach (var item in satrlar)
                    {
                        if (item.STOKADI == null || item.STOKADI == "")
                        {
                            bosvar = true;
                            return;
                        }
                    }
                    if (!bosvar)
                    {
                        SatirEkle();
                    }
                }
                lk_durum.EditValue = 1;
                lk_durum.Enabled = false;
                lk_durum.EditValue = 1;
                gv_TeklifSatirlari.OptionsBehavior.Editable = true;
                btn_cariKodu.Enabled = true;
                btn_cariUnvani.Enabled = true;
                btn_ticariIslemGuruplari.Enabled = true;
                simpleButton3.Visible = false;
                btn_OnayaGonder.Visible = true;
            }
            if (lk_onay.EditValue.ToString() == "2") //onaylandı
            {
                if (!duzenle)
                {
                    XtraMessageBox.Show("Onaylayabilmek İçin Kaydetmeniz Gerek");
                    lk_onay.EditValue = lk_onay.OldEditValue;
                    return;
                }
                if (duzenle)
                {
                    using (LogoContext db = new LogoContext())
                    {
                        LOGO_XERO_TEKLIF_BASLIK tklfbslk = db.LOGO_XERO_TEKLIF_BASLIK.Where(s => s.ID == Teklifid).FirstOrDefault();
                        if (tklfbslk != null)
                        {
                            if (Convert.ToInt32(lk_Onaylayan.EditValue) != ana._Kullanici.ID)
                            {
                                XtraMessageBox.Show("Teklifi Onaylayan İsim Sizin İsminizle Uyuşmuyor ! Gerekli Düzenlemeyi Yaptıktan Sonra Tekrar Deneyiniz !");
                                lk_onay.EditValue = lk_onay.OldEditValue;
                                return;
                            }
                            List<LOGO_XERO_TEKLIF_SATIR> satrlar = (List<LOGO_XERO_TEKLIF_SATIR>)gv_TeklifSatirlari.DataSource;
                            if (satrlar == null)
                            {
                                satrlar = new List<LOGO_XERO_TEKLIF_SATIR>();
                            }
                            satrlar = satrlar.Where(s => !string.IsNullOrWhiteSpace(s.STOKADI)).ToList();
                            grid_TeklifSatirlari.DataSource = satrlar;
                            grid_TeklifSatirlari.RefreshDataSource();
                            grid_TeklifSatirlari.Refresh();
                            tklfbslk.ONAYLAYANID = Convert.ToInt32(lk_Onaylayan.EditValue);
                            tklfbslk.ONAYDURUMU = Convert.ToInt32(lk_onay.EditValue);
                            tklfbslk.ONAYCEVAP = 1;
                            tklfbslk.ONAYAGONDERIM = 0;
                            db.LOGO_XERO_TEKLIF_BASLIK.AddOrUpdate(tklfbslk);
                            Teklifid = tklfbslk.ID;
                            db.SaveChanges();
                            gv_TeklifSatirlari.OptionsBehavior.Editable = false;
                            btn_cariKodu.Enabled = false;
                            btn_cariUnvani.Enabled = false;
                            btn_ticariIslemGuruplari.Enabled = false;
                            simpleButton3.Visible = true;
                            btn_OnayaGonder.Visible = false;
                        }
                    }
                }
                lk_durum.Enabled = true;
            }
            else if (lk_onay.EditValue.ToString() == "3")
            {
                if (!duzenle)
                {
                    XtraMessageBox.Show("Teklifte Onaylanan Miktarlar Var ! Teklifi Onaylanmadı Yapabilmeniz İçin Önce Teklif Hazırlandı Durumuna Getirin !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lk_onay.EditValue = lk_onay.OldEditValue;
                    return;
                }
                if (lk_durum.EditValue != null)
                {
                    if (lk_durum.EditValue.ToString() == "3")
                    {
                        XtraMessageBox.Show("Teklifi Reddedebilmek İçin Önce Teklif Hazırlandı Durumuna Getirin !");
                        lk_onay.EditValue = lk_onay.OldEditValue;
                        return;
                    }
                }
                using (LogoContext db = new LogoContext())
                {
                    LOGO_XERO_TEKLIF_BASLIK tklfbslk = db.LOGO_XERO_TEKLIF_BASLIK.Where(s => s.ID == Teklifid).FirstOrDefault();
                    if (tklfbslk != null)
                    {
                        tklfbslk.ONAYAGONDERIM = 0;
                        tklfbslk.ONAYCEVAP = 0;
                        tklfbslk.ONAYDURUMU = Convert.ToInt32(lk_onay.EditValue);
                        db.LOGO_XERO_TEKLIF_BASLIK.AddOrUpdate(tklfbslk);
                        db.SaveChanges();
                        Teklifid = tklfbslk.ID;
                    }
                }
                lk_durum.EditValue = null;
                lk_durum.Enabled = false;
                gv_TeklifSatirlari.OptionsBehavior.Editable = true;
                btn_cariKodu.Enabled = true;
                btn_cariUnvani.Enabled = true;
                btn_ticariIslemGuruplari.Enabled = true;
                simpleButton3.Visible = false;
                btn_OnayaGonder.Visible = true;
            }
        }

        private void tasarımKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            islem.TasarimKaydet(gv_TeklifSatirlari, ana._Kullanici.ID, this.Name, grid_TeklifSatirlari.Name);

            XtraMessageBox.Show("Tasarım Başarıyla Kaydedildi");
        }
        private void xtraTabControl2_Click(object sender, EventArgs e)
        {
            if (Teklifid != null || Teklifid != 0)
            {
                OnaylanansatirlariGetir(Teklifid);
            }
        }
        public void OnaylanansatirlariGetir(int teklifbaslikid)
        {
            using (LogoContext db = new LogoContext())
            {
                grid_OnaylananTeklifSatirlari.DataSource = db.LOGO_XERO_ONAYLI_TEKLIF_SATIR.Where(s => s.TEKLIFID == teklifbaslikid).ToList();
                grid_OnaylananTeklifSatirlari.RefreshDataSource();
                grid_OnaylananTeklifSatirlari.Refresh();
            }
        }
        GridHitInfo downHitInfo = null;
        public void btn_kaydet_Click(object sender, EventArgs e)
        {
            bool satisvade = Convert.ToBoolean(ana.parametre.Z_STKLF_VADE);
            bool alisvade = Convert.ToBoolean(ana.parametre.Z_ATKLF_VADE);
            bool satisodemetip = Convert.ToBoolean(ana.parametre.Z_STKLF_ODEMETIP);
            bool alisodemetip = Convert.ToBoolean(ana.parametre.Z_ATKLF_ODEMETIP);
            if (string.IsNullOrWhiteSpace(btn_cariUnvani.Text))
            {
                XtraMessageBox.Show("CARİ ÜNVAN GİRİNİZ !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btn_cariUnvani.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(lk_durum.Text))
            {
                XtraMessageBox.Show("TEKLİF DURUMUNU BELİRTİNİZ !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lk_durum.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(lk_Onaylayan.Text))
            {
                XtraMessageBox.Show("ONAYLAYAN YETKİLİYİ BELİRTİNİZ !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lk_Onaylayan.Focus();
                return;
            }
            if (Trkod == 8)//SATIŞ
            {

                if (satisodemetip == true && string.IsNullOrWhiteSpace(lk_TanimliAlanOdemeTipi.Text))
                {
                    XtraMessageBox.Show("TANIMLI ALAN ÖDEME TİPİNİ BELİRTİNİZ !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lk_TanimliAlanOdemeTipi.Focus();
                    return;
                }
                if (satisvade == true && string.IsNullOrWhiteSpace(lk_OdemeTipi.Text))
                {
                    XtraMessageBox.Show("ÖDEME TİPİNİ BELİRTİNİZ !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lk_OdemeTipi.Focus();
                    return;
                }
            }
            if (Trkod == 1)//ALIŞ
            {

                if (alisodemetip == true && string.IsNullOrWhiteSpace(lk_TanimliAlanOdemeTipi.Text))
                {
                    XtraMessageBox.Show("TANIMLI ALAN ÖDEME TİPİNİ BELİRTİNİZ !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lk_TanimliAlanOdemeTipi.Focus();
                    return;
                }
                if (alisvade == true && string.IsNullOrWhiteSpace(lk_OdemeTipi.Text))
                {
                    XtraMessageBox.Show("ÖDEME TİPİNİ BELİRTİNİZ !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lk_OdemeTipi.Focus();
                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(lk_isyeri.Text) || string.IsNullOrWhiteSpace(lk_ambar.Text))
            {
                XtraMessageBox.Show("İŞYERİ VE AMBAR SEÇİNİZ!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lk_isyeri.Focus();
                return;
            }

            List<LOGO_XERO_TEKLIF_SATIR> satirlar = grid_TeklifSatirlari.DataSource as List<LOGO_XERO_TEKLIF_SATIR>;
            if (satirlar == null)
            {
                satirlar = new List<LOGO_XERO_TEKLIF_SATIR>();
            }
            var BirimsizSatirVarmi = satirlar.Where(s => (s.BIRIM == "" || s.BIRIM == null) && !string.IsNullOrWhiteSpace(s.STOKADI)).ToList();
            if (BirimsizSatirVarmi.Count > 0)
            {
                XtraMessageBox.Show("BİRİMSİZ SATIRLARINIZ VARDIR !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var KdvsizSatirlar = satirlar.Where(s => (s.KDV == 0 || s.KDV == null) && !string.IsNullOrWhiteSpace(s.STOKADI)).ToList();
            if (KdvsizSatirlar.Count > 0)
            {
                if (kdvmuafiyetkontrolüyapilacak.VALUE == "1")
                {
                    if (kdvmuafiyetkoontrolüsiparisteyapilacak.VALUE == "1")
                    {
                        var KdvMuafiyetsizSatirlar = satirlar.Where(s => (s.KDV == 0 || s.KDV == null) && (s.KDVMUAFIYETKODU == "" || s.KDVMUAFIYETACIKLAMA == null) && !string.IsNullOrWhiteSpace(s.STOKADI)).ToList();
                        if (KdvMuafiyetsizSatirlar.Count > 0)
                        {
                            XtraMessageBox.Show("KDV MUAFİYET SEBEBİ BOŞ OLAN SATIRLAR MEVCUTTUR !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                }
            }


            using (LogoContext db = new LogoContext())
            {
                using (var dbtransaction = db.Database.BeginTransaction())
                {
                    LOGO_XERO_ONAYLI_TEKLIF_SATIR satir = db.LOGO_XERO_ONAYLI_TEKLIF_SATIR.Where(s => s.TEKLIFID == Teklifid).FirstOrDefault();
                    if (satir != null && lk_durum.EditValue.ToString() != "3")
                    {
                        XtraMessageBox.Show("TEKLİFE AİT ONAYLANMIŞ SATIRLARINIZ VAR LÜTFEN TEKLİFİ SİPARİŞE DÖNÜŞTÜYE ÇEVİRİP TEKRAR KAYDEDİNİZ !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        lk_onay.Focus();
                        return;
                    }
                    LOGO_XERO_TEKLIF_BASLIK orijinalTeklif = new LOGO_XERO_TEKLIF_BASLIK();
                    if (duzenle == false)
                    {
                        try
                        {
                            LOGO_XERO_TEKLIF_BASLIK baslik = new LOGO_XERO_TEKLIF_BASLIK();
                            baslik.TRCODE = Trkod;
                            baslik.TARIH = Convert.ToDateTime(date_tarih.Text);
                            baslik.SAAT = TimeSpan.Parse(time_saat.Text);
                            baslik.GELISTARIHI = Convert.ToDateTime(date_gelistarihi.Text);
                            baslik.GELISZAMANI = TimeSpan.Parse(time_geliszamani.Text);
                            baslik.OPSIYONTARIHI = Convert.ToDateTime(date_opsiyonTarihi.Text);
                            List<LOGO_XERO_TEKLIF_BASLIK> list = null;
                            if (revizyonMu)
                            {
                                var eskiTeklif = db.LOGO_XERO_TEKLIF_BASLIK.Where(s => s.ID == eskiTeklifId).FirstOrDefault();
                                if (eskiTeklif != null)
                                {
                                    if (eskiTeklif.TEKLIFNO.Contains("-R"))
                                    {
                                        string orijinalTeklifNo = eskiTeklif.TEKLIFNO.Split('-')[0];
                                        orijinalTeklif = db.LOGO_XERO_TEKLIF_BASLIK.Where(s => s.ID == eskiTeklifId).FirstOrDefault();
                                        if (orijinalTeklif != null)
                                        {
                                            db.SaveChanges();
                                            txt_teklifno.Text = $"{orijinalTeklifNo}-R{orijinalTeklif.REVIZYONNO + 1}";
                                            baslik.TEKLIFNO = txt_teklifno.Text;
                                        }

                                    }
                                    else
                                    {
                                        txt_teklifno.Text = $"{txt_teklifno.Text}-R{eskiTeklif.REVIZYONNO + 1}";
                                        baslik.TEKLIFNO = txt_teklifno.Text;
                                    }

                                }
                                if (eskiTeklif.REVIZYONTEKLIFID == 0)
                                {
                                    baslik.REVIZYONTEKLIFID = eskiTeklif.ID;
                                }
                                else
                                {
                                    baslik.REVIZYONTEKLIFID = eskiTeklif.REVIZYONTEKLIFID;
                                }


                            }
                            else
                            {
                                LOGO_XERO_TEKLIF_BASLIK baslikk = db.LOGO_XERO_TEKLIF_BASLIK.Where(s => s.TEKLIFNO == txt_teklifno.Text && s.TRCODE==Trkod).FirstOrDefault();
                                while (baslikk != null)
                                {
                                    Numarator(Trkod);
                                    baslikk = db.LOGO_XERO_TEKLIF_BASLIK.Where(s => s.TEKLIFNO == txt_teklifno.Text && s.TRCODE == Trkod).FirstOrDefault();

                                }
                                Numarator(Trkod);
                                NumaratoruArttir(Trkod);
                                baslik.TEKLIFNO = txt_teklifno.Text;
                                baslik.REVIZYONTEKLIFID = 0;
                            }
                            baslik.BELGENO = "";
                            baslik.CARIID = Convert.ToInt32(lbl_cariref.Text);
                            baslik.CARIKODU = btn_cariKodu.Text;
                            baslik.CARIUNVANI = btn_cariUnvani.Text;
                            baslik.OZELKOD = btn_OzelKod.Text;
                            baslik.YETKIKODU = btn_YetkiKodu.Text;
                            baslik.TRADDINGGRP = btn_ticariIslemGuruplari.Text;
                            baslik.YETKILI = txt_Yetkili.Text;
                            baslik.TELEFON = txt_Telefon.Text;
                            baslik.EPOSTA = txt_Eposta.Text;
                            baslik.EPOSTA2 = txt_Eposta2.Text;
                            baslik.KONU = txt_konu.Text;
                            baslik.ACIKLAMA = txt_aciklama.Text;
                            baslik.KDVDURUMU = ck_kdvdahil.Checked;
                            baslik.ISYERI = Convert.ToInt32(lk_isyeri.EditValue.ToString());
                            baslik.BOLUM = Convert.ToInt32(lk_bolum.EditValue.ToString());
                            baslik.AMBAR = Convert.ToInt32(lk_ambar.EditValue.ToString());
                            baslik.FABRIKA = Convert.ToInt32(lk_fabrika.EditValue.ToString());
                            baslik.SATISELEMANIKODU = lk_satisElemani.EditValue == null ? "" : lk_satisElemani.EditValue.ToString();
                            baslik.HAZIRLAYANID = Convert.ToInt32(lk_Hazirlayan.EditValue);
                            baslik.PAZARLAYANID = Convert.ToInt32(lk_pazarlayan.EditValue);
                            baslik.ONAYDURUMU = Convert.ToInt32(lk_onay.EditValue);
                            baslik.ONAYLAYANID = Convert.ToInt32(lk_Onaylayan.EditValue);
                            baslik.DURUMU = Convert.ToInt32(lk_durum.EditValue);
                            baslik.EFATURA = Efatura_resim.Visible;
                            baslik.VADE = Convert.ToInt32(lk_OdemeTipi.EditValue);
                            baslik.FATURATIPI = Convert.ToInt32(cm_FaturaTipiSecim.SelectedIndex);
                            baslik.KDVMUAFIYETKODU = btn_KdvMuafiyetSebebiKodu.Text;
                            baslik.KDVMUAFIYETACIKLAMA = txt_KdvMuafiyetSebebiAciklamasi.Text;
                            baslik.TANIMLIALANODEMETIPI = Convert.ToInt32(lk_TanimliAlanOdemeTipi.EditValue);
                            baslik.TESLIMSEKLIKODU = btn_TeslimSekliKodu.Text;
                            baslik.TASIYICIKODU = btn_TasiyiciKodu.Text;
                            baslik.NAKLIYEBEDELI = txt_nakliyebedeli.Text == "" ? 0 : Convert.ToDouble(txt_nakliyebedeli.Text);
                            if (lk_pazarlamatipi.EditValue == null)
                            {
                                baslik.PAZARLAMATIPI = 0;
                            }
                            else
                            {
                                baslik.PAZARLAMATIPI = Convert.ToInt32(lk_pazarlamatipi.EditValue.ToString());
                            }
                            //baslik.TEVKIFATID = ck_Tevkifat.Checked;
                            baslik.GENELDOVIZLIISLEMTIPI = GenelParaBirim.SelectedIndex;
                            baslik.SATIRLARDOVIZLIISLEMTIPI = SatirlarParaBirimi.SelectedIndex;
                            baslik.ISKONTOTUTARI = Convert.ToDouble(txt_YerelToplamIndirim.Text);
                            baslik.ISKONTOLUNETTUTAR = Convert.ToDouble(txt_YerelToplam.Text);
                            baslik.KDVTUTARI = Convert.ToDouble(txt_YerelToplamKdv.Text);
                            baslik.KDVHARICNETTUTAR = Convert.ToDouble(txt_YerelToplamNet.Text) - Convert.ToDouble(txt_YerelToplamKdv.Text);
                            baslik.KDVDAHILNETTUTAR = Convert.ToDouble(txt_YerelToplamNet.Text);
                            if (SatirlarParaBirimi.SelectedIndex == 0)
                            {
                                baslik.DOVIZKODU = 0;
                            }
                            else if (SatirlarParaBirimi.SelectedIndex == 1)
                            {
                                baslik.DOVIZKODU = Convert.ToInt32(lk_RaporlamaDoviz.EditValue);
                            }
                            else if (SatirlarParaBirimi.SelectedIndex == 2)
                            {
                                baslik.DOVIZKODU = Convert.ToInt32(Lk_IslemDoviz.EditValue);
                            }
                            else
                            {
                                baslik.DOVIZKODU = 0;
                            }
                            baslik.ISLEMDOVIZKURU = Convert.ToDouble(btn_islemkuru.Text);
                            baslik.RAPORLAMADOVIZKURU = Convert.ToDouble(btn_raporlamakuru.Text);
                            baslik.ACIKLAMA2 = txt_aciklama2.Text;
                            baslik.ACIKLAMA3 = txt_aciklama3.Text;
                            baslik.UYARIMESAJI = Convert.ToInt32(lk_uyarimesaji.EditValue);
                            baslik.TAKIPSONUC = txt_takipsonuc.Text;
                            baslik.OZELBILGI = txt_ozelbilgi.Text;
                            baslik.NOT = txt_not.Text;
                            baslik.OZELACIKLAMA1 = txt_ozelacik1.Text;
                            baslik.OZELACIKLAMA2 = txt_ozelacik2.Text;
                            baslik.OZELACIKLAMA3 = txt_ozelacik3.Text;
                            baslik.PROJEID = Convert.ToInt32(lbl_projeref.Text);
                            baslik.SEVKIYATADRESIID = Convert.ToInt32(lbl_sevkiyatadresref.Text);
                            if (!string.IsNullOrWhiteSpace(lbl_SevkiyatHesabiRefi.Text))
                            {
                                baslik.SEVKIYATHESAPID = Convert.ToInt32(lbl_SevkiyatHesabiRefi.Text);
                            }
                            else
                            {
                                baslik.SEVKIYATHESAPID = 0;

                            }
                            baslik.ISLEMDOVIZIAYNENKALACAK = !Convert.ToBoolean(rd_AktarildigindaIslemDoviziAynenKalacak.SelectedIndex);
                            baslik.FIYATLANDIRMADOVIZIAYNENKALACAK = !Convert.ToBoolean(rd_AktarildigindaFiyatlandirmaDoviziAynenKalacak.SelectedIndex);
                            baslik.REVIZYONDURUMU = false;
                            baslik.REVIZYONNO = 0;

                            baslik.FATADRES1 = txt_Adres1.Text;
                            baslik.FATADRES2 = txt_Adres2.Text;
                            baslik.FATULKE = txt_Ulke.Text;
                            baslik.FATIL = txt_Il.Text;
                            baslik.FATILCE = txt_Ilce.Text;
                            baslik.FATPOSTAKODU = txt_PostaKodu.Text;
                            baslik.FATTEL = txt_Telefon.Text;
                            baslik.FATFAKS = txt_Fax.Text;
                            baslik.FATVD = txt_VergiDairesi.Text;
                            baslik.FATVN = txt_VergiNo.Text;


                            baslik.GENELACIKLAMA1 = txt1aciklama.Text;
                            baslik.GENELACIKLAMA2 = txt2aciklama.Text;
                            baslik.GENELACIKLAMA3 = txt3aciklama.Text;
                            baslik.GENELACIKLAMA4 = txt4aciklama.Text;
                            baslik.GENELACIKLAMA5 = txt5aciklama.Text;
                            baslik.GENELACIKLAMA6 = txt6aciklama.Text;
                            db.LOGO_XERO_TEKLIF_BASLIK.Add(baslik);
                            db.SaveChanges();

                            Teklifid = baslik.ID;


                            int i = 1;
                            foreach (var item in satirlar)
                            {
                                if (string.IsNullOrWhiteSpace(item.STOKADI)) { continue; }
                                LOGO_XERO_TEKLIF_SATIR satir2 = new LOGO_XERO_TEKLIF_SATIR();
                                satir2 = item;
                                satir2.SIRANO = item.SIRANO;
                                satir2.TRCODE = Trkod;
                                satir2.TEKLIFID = baslik.ID;
                                satir2.ISYERI = Convert.ToInt16(lk_isyeri.EditValue);
                                satir2.BOLUM = Convert.ToInt16(lk_bolum.EditValue);
                                satir2.FABRIKA = Convert.ToInt16(lk_fabrika.EditValue);
                                satir2.NAKLIYEBEDELI = txt_nakliyebedeli.Text == "" ? 0 : Convert.ToDouble(txt_nakliyebedeli.Text); ;
                                satir2.RAPORLAMADOVIZI = Convert.ToInt16(lk_RaporlamaDoviz.EditValue);
                                satir2.RAPORLAMADOVIZKURU = Convert.ToDouble(btn_raporlamakuru.Text);
                                satir2.ISLEMDOVIZI = Convert.ToInt16(Lk_IslemDoviz.EditValue);
                                satir2.ISLEMDOVIZKURU = Convert.ToDouble(btn_islemkuru.Text);
                                i++;
                                db.LOGO_XERO_TEKLIF_SATIR.Add(satir2);
                            }
                            db.SaveChanges();
                            dbtransaction.Commit();
                            this.Text = txt_teklifno.Text + " Nolu " + btn_cariUnvani.Text + " İsimli Cari Teklifi";
                            MessageBox.Show("Kayıt Başarılı!");
                            // simpleButton3.Visible = true;

                            duzenle = true;
                        }
                        catch (Exception ex)
                        {
                            dbtransaction.Rollback();
                            MessageBox.Show(ex.Message);
                        }
                        lkonaysayisi = 2;
                    }
                    else
                    {
                        try
                        {
                            LOGO_XERO_TEKLIF_BASLIK baslik = new LOGO_XERO_TEKLIF_BASLIK();
                            baslik.ID = Teklifid;
                            baslik.TRCODE = Trkod;
                            baslik.TARIH = Convert.ToDateTime(date_tarih.Text);
                            baslik.SAAT = TimeSpan.Parse(time_saat.Text);
                            baslik.GELISTARIHI = Convert.ToDateTime(date_gelistarihi.Text);
                            baslik.GELISZAMANI = TimeSpan.Parse(time_geliszamani.Text);
                            baslik.OPSIYONTARIHI = Convert.ToDateTime(date_opsiyonTarihi.Text);
                            baslik.TEKLIFNO = txt_teklifno.Text;
                            baslik.BELGENO = "";
                            baslik.CARIID = Convert.ToInt32(lbl_cariref.Text);
                            baslik.CARIKODU = btn_cariKodu.Text;
                            baslik.CARIUNVANI = btn_cariUnvani.Text;
                            baslik.OZELKOD = btn_OzelKod.Text;
                            baslik.YETKIKODU = btn_YetkiKodu.Text;
                            baslik.TRADDINGGRP = btn_ticariIslemGuruplari.Text;
                            baslik.YETKILI = txt_Yetkili.Text;
                            baslik.TELEFON = txt_Telefon.Text;
                            baslik.EPOSTA = txt_Eposta.Text;
                            baslik.EPOSTA2 = txt_Eposta2.Text;
                            baslik.KONU = txt_konu.Text;
                            baslik.ACIKLAMA = txt_aciklama.Text;
                            baslik.KDVDURUMU = ck_kdvdahil.Checked;
                            baslik.ISYERI = Convert.ToInt32(lk_isyeri.EditValue.ToString());
                            baslik.BOLUM = Convert.ToInt32(lk_bolum.EditValue.ToString());
                            baslik.AMBAR = Convert.ToInt32(lk_ambar.EditValue.ToString());
                            baslik.FABRIKA = Convert.ToInt32(lk_fabrika.EditValue.ToString());
                            baslik.SATISELEMANIKODU = lk_satisElemani.EditValue == null ? "" : lk_satisElemani.EditValue.ToString();
                            baslik.HAZIRLAYANID = Convert.ToInt32(lk_Hazirlayan.EditValue);
                            baslik.PAZARLAYANID = Convert.ToInt32(lk_pazarlayan.EditValue);
                            baslik.ONAYDURUMU = Convert.ToInt32(lk_onay.EditValue);
                            baslik.ONAYLAYANID = Convert.ToInt32(lk_Onaylayan.EditValue);
                            baslik.DURUMU = Convert.ToInt32(lk_durum.EditValue);
                            baslik.EFATURA = Efatura_resim.Visible;
                            baslik.VADE = Convert.ToInt32(lk_OdemeTipi.EditValue);
                            baslik.FATURATIPI = Convert.ToInt32(cm_FaturaTipiSecim.SelectedIndex);
                            baslik.KDVMUAFIYETKODU = btn_KdvMuafiyetSebebiKodu.Text;
                            baslik.KDVMUAFIYETACIKLAMA = txt_KdvMuafiyetSebebiAciklamasi.Text;
                            baslik.TANIMLIALANODEMETIPI = Convert.ToInt32(lk_TanimliAlanOdemeTipi.EditValue);
                            baslik.TESLIMSEKLIKODU = btn_TeslimSekliKodu.Text;
                            baslik.TASIYICIKODU = btn_TasiyiciKodu.Text;
                            baslik.NAKLIYEBEDELI = txt_nakliyebedeli.Text == "" ? 0 : Convert.ToDouble(txt_nakliyebedeli.Text);
                            if (lk_pazarlamatipi.EditValue != null)
                            {
                                baslik.PAZARLAMATIPI = Convert.ToInt32(lk_pazarlamatipi.EditValue.ToString());
                            }
                            else
                            {
                                baslik.PAZARLAMATIPI = 0;
                            }
                            //baslik.TEVKIFATID = ck_Tevkifat.Checked;
                            baslik.GENELDOVIZLIISLEMTIPI = GenelParaBirim.SelectedIndex;
                            baslik.SATIRLARDOVIZLIISLEMTIPI = SatirlarParaBirimi.SelectedIndex;
                            baslik.ISKONTOTUTARI = Convert.ToDouble(txt_YerelToplamIndirim.Text);
                            baslik.ISKONTOLUNETTUTAR = Convert.ToDouble(txt_YerelToplam.Text);
                            baslik.KDVTUTARI = Convert.ToDouble(txt_YerelToplamKdv.Text);
                            baslik.KDVHARICNETTUTAR = Convert.ToDouble(txt_YerelToplamNet.Text) - Convert.ToDouble(txt_YerelToplamKdv.Text);
                            baslik.KDVDAHILNETTUTAR = Convert.ToDouble(txt_YerelToplamNet.Text);
                            if (SatirlarParaBirimi.SelectedIndex == 0)
                            {
                                baslik.DOVIZKODU = 0;
                            }
                            else if (SatirlarParaBirimi.SelectedIndex == 1)
                            {
                                baslik.DOVIZKODU = Convert.ToInt32(lk_RaporlamaDoviz.EditValue);
                            }
                            else if (SatirlarParaBirimi.SelectedIndex == 2)
                            {
                                baslik.DOVIZKODU = Convert.ToInt32(Lk_IslemDoviz.EditValue);
                            }
                            else
                            {
                                baslik.DOVIZKODU = 0;
                            }
                            baslik.ISLEMDOVIZKURU = Convert.ToDouble(btn_islemkuru.Text);
                            baslik.RAPORLAMADOVIZKURU = Convert.ToDouble(btn_raporlamakuru.Text);
                            baslik.ACIKLAMA2 = txt_aciklama2.Text;
                            baslik.ACIKLAMA3 = txt_aciklama3.Text;
                            baslik.UYARIMESAJI = Convert.ToInt32(lk_uyarimesaji.EditValue);
                            baslik.TAKIPSONUC = txt_takipsonuc.Text;
                            baslik.OZELBILGI = txt_ozelbilgi.Text;
                            baslik.NOT = txt_not.Text;
                            baslik.OZELACIKLAMA1 = txt_ozelacik1.Text;
                            baslik.OZELACIKLAMA2 = txt_ozelacik2.Text;
                            baslik.OZELACIKLAMA3 = txt_ozelacik3.Text;
                            baslik.PROJEID = Convert.ToInt32(lbl_projeref.Text);
                            baslik.SEVKIYATADRESIID = Convert.ToInt32(lbl_sevkiyatadresref.Text);
                            if (!string.IsNullOrWhiteSpace(lbl_SevkiyatHesabiRefi.Text))
                            {
                                baslik.SEVKIYATHESAPID = Convert.ToInt32(lbl_SevkiyatHesabiRefi.Text);
                            }
                            else
                            {
                                baslik.SEVKIYATHESAPID = 0;
                            }
                            baslik.ISLEMDOVIZIAYNENKALACAK = !Convert.ToBoolean(rd_AktarildigindaIslemDoviziAynenKalacak.SelectedIndex);
                            baslik.FIYATLANDIRMADOVIZIAYNENKALACAK = !Convert.ToBoolean(rd_AktarildigindaFiyatlandirmaDoviziAynenKalacak.SelectedIndex);
                            baslik.REVIZYONTEKLIFID = db.LOGO_XERO_TEKLIF_BASLIK.Where(s => s.ID == Teklifid).FirstOrDefault().REVIZYONTEKLIFID;
                            baslik.REVIZYONDURUMU = db.LOGO_XERO_TEKLIF_BASLIK.Where(s => s.ID == Teklifid).FirstOrDefault().REVIZYONDURUMU;
                            baslik.REVIZYONNO = db.LOGO_XERO_TEKLIF_BASLIK.Where(s => s.ID == Teklifid).FirstOrDefault().REVIZYONNO;
                            baslik.FATADRES1 = txt_Adres1.Text;
                            baslik.FATADRES2 = txt_Adres2.Text;
                            baslik.FATULKE = txt_Ulke.Text;
                            baslik.FATIL = txt_Il.Text;
                            baslik.FATILCE = txt_Ilce.Text;
                            baslik.FATPOSTAKODU = txt_PostaKodu.Text;
                            baslik.FATTEL = txt_Telefon.Text;
                            baslik.FATFAKS = txt_Fax.Text;
                            baslik.FATVD = txt_VergiDairesi.Text;
                            baslik.FATVN = txt_VergiNo.Text;
                            baslik.GENELACIKLAMA1 = txt1aciklama.Text;
                            baslik.GENELACIKLAMA2 = txt2aciklama.Text;
                            baslik.GENELACIKLAMA3 = txt3aciklama.Text;
                            baslik.GENELACIKLAMA4 = txt4aciklama.Text;
                            baslik.GENELACIKLAMA5 = txt5aciklama.Text;
                            baslik.GENELACIKLAMA6 = txt6aciklama.Text;
                            db.LOGO_XERO_TEKLIF_BASLIK.AddOrUpdate(baslik);
                            db.SaveChanges();
                            Teklifid = baslik.ID;
                            var guncellenecekler = satirlar.Where(s => !string.IsNullOrWhiteSpace(s.STOKADI)).ToList();

                            var sirano = db.LOGO_XERO_TEKLIF_SATIR.Where(s => s.TEKLIFID == Teklifid).Max(s => s.SIRANO);

                            guncellenecekler.ForEach(s =>
                            {
                                if (string.IsNullOrEmpty(s.TEKLIFID.ToString())) s.TEKLIFID = Teklifid;
                                if (s.SIRANO == null) s.SIRANO = ++sirano;
                                s.TRCODE = Trkod;
                                s.TEKLIFID = baslik.ID;
                                s.ISYERI = Convert.ToInt16(lk_isyeri.EditValue);
                                s.BOLUM = Convert.ToInt16(lk_bolum.EditValue);
                                s.FABRIKA = Convert.ToInt16(lk_fabrika.EditValue);
                                s.NAKLIYEBEDELI = txt_nakliyebedeli.Text == "" ? 0 : Convert.ToDouble(txt_nakliyebedeli.Text); ;
                                s.RAPORLAMADOVIZI = Convert.ToInt16(lk_RaporlamaDoviz.EditValue);
                                s.RAPORLAMADOVIZKURU = Convert.ToDouble(btn_raporlamakuru.Text);
                                s.ISLEMDOVIZI = Convert.ToInt16(Lk_IslemDoviz.EditValue);
                                s.ISLEMDOVIZKURU = Convert.ToDouble(btn_islemkuru.Text);
                            });
                            guncellenecekler.ForEach(s => db.LOGO_XERO_TEKLIF_SATIR.AddOrUpdate(s));

                            db.SaveChanges();
                            dbsatirsilmekicin.SaveChanges();
                            dbtransaction.Commit();
                            MessageBox.Show("Düzenleme Başarılı!");
                        }
                        catch (Exception ex)
                        {
                            dbtransaction.Rollback();
                            MessageBox.Show(ex.Message);
                        }
                    }

                    if (parametre.M_GNL_KAYITLARDANSONRASAYFAKAPAT == true)
                    {
                        if (revizyonMu == false)
                        {
                            this.Close();
                        }
                        else
                        {
                            islem.pageLockDelete(1, eskiTeklifId);
                            islem.pageLock(1, Teklifid, ana._Kullanici.ID);
                        }
                    }
                    else
                    {
                        if (revizyonMu == false)
                        {
                        }
                        else
                        {
                            islem.pageLockDelete(1, eskiTeklifId);
                            islem.pageLock(1, Teklifid, ana._Kullanici.ID);
                        }
                    }
                }
            }
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            using (LogoContext db = new LogoContext())
            {
                List<LOGO_XERO_TEKLIF_SATIR> dtsrc = gv_TeklifSatirlari.DataSource as List<LOGO_XERO_TEKLIF_SATIR>;
                LOGO_XERO_TEKLIF_SATIR satir = (LOGO_XERO_TEKLIF_SATIR)gv_TeklifSatirlari.GetFocusedRow();
                if (satir.ID > 0)
                    if (satir.ID > 0)
                    {
                        dbsatirsilmekicin.Entry(satir).State = EntityState.Deleted;
                    }
                int ind = gv_TeklifSatirlari.FocusedRowHandle;
                if (ind != gv_TeklifSatirlari.RowCount - 1)
                {
                    dtsrc.Remove(dtsrc[ind]);
                    grid_TeklifSatirlari.DataSource = dtsrc;
                    grid_TeklifSatirlari.RefreshDataSource();
                    grid_TeklifSatirlari.Refresh();
                }
            }
            SiraNoYenile();
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            OnaylanansatirlariGetir(Teklifid);

            LogoContext db = new LogoContext();
            TEKLIFYAZDIRMODEL tm = new TEKLIFYAZDIRMODEL();
            tm.TARIH = date_tarih.DateTime.ToString("dd-MM-yyyy");
            tm.SAAT = time_saat.Time.ToString("HH:mm:ss");
            tm.GELISTARIHI = date_gelistarihi.DateTime.ToString("dd-MM-yyyy");
            tm.GELISZAMANI = time_geliszamani.Time.ToString("HH:mm:ss");
            tm.OPSIYONTARIHI = date_opsiyonTarihi.DateTime.ToString("dd-MM-yyyy");
            tm.TEKLIFNO = txt_teklifno.Text;
            tm.CARIKODU = btn_cariKodu.Text;
            tm.CARIUNVANI = btn_cariUnvani.Text;

            tm.CARIVADEACIKLAMASI = lk_OdemeTipi.Text;
            tm.CARIVADEKODU = lk_OdemeTipi.EditValue == null || string.IsNullOrWhiteSpace(lk_OdemeTipi.Text) ? "" : islem.OdemeBilgiGetir(firma, Convert.ToInt32(lk_OdemeTipi.EditValue)).CODE;
            tm.FIYATGURUBU = btn_ticariIslemGuruplari.Text;
            tm.SATISELEMANI = lk_satisElemani.Text;
            tm.SATISELEMANIKODU = lk_satisElemani.EditValue == null ? "" : lk_satisElemani.EditValue.ToString();


            tm.OZELKOD = btn_OzelKod.Text;
            tm.YETKIKODU = btn_YetkiKodu.Text;
            tm.TANIMLIALANODEMETIPI = lk_TanimliAlanOdemeTipi.Text;

            tm.ISYERI = lk_isyeri.Text;
            tm.BOLUM = lk_bolum.Text;
            tm.AMBAR = lk_ambar.Text;
            tm.FABRIKA = lk_fabrika.Text;

            tm.HAZIRLAYAN = lk_Hazirlayan.Text;

            tm.EPOSTA = txt_Eposta.Text;
            tm.EPOSTA2 = txt_Eposta2.Text;
            tm.YETKILI = txt_Yetkili.Text;
            tm.ACIKLAMA = txt_aciklama.Text;
            tm.KONU = txt_konu.Text;

            tm.RAPORLAMADOVIZI = lk_RaporlamaDoviz.Text;
            tm.ISLEMDOVIZI = Lk_IslemDoviz.Text;
            tm.RAPORLAMADOVIZKURU = btn_raporlamakuru.Text == null ? 0 : Convert.ToDouble(btn_raporlamakuru.Text);
            tm.ISLEMDOVIZKURU = btn_islemkuru.Text == null ? 0 : Convert.ToDouble(btn_islemkuru.Text);

            tm.PAZARLAYAN = lk_pazarlayan.Text;
            tm.PAZARLAMATIPI = lk_pazarlamatipi.Text;


            tm.PROJEKODU = btn_ProjeKodu.Text;
            tm.PROJEACIKLAMASI = btn_projeAciklamasi.Text;
            tm.SEVKADRESIKODU = btn_SevkAdresKodu.Text;
            tm.SEVKADRESIACIKLAMASI = btn_sevkiyatAdresAciklama.Text;
            tm.SEVKIYATHESABIKODU = btn_SevkHesabiKodu.Text;
            tm.SEVKIYATHESABIACIKLAMASI = btn_sevkiyatHesabiaciklamasi.Text;



            tm.TESLIMSEKLIKODU = btn_TeslimSekliKodu.Text;
            tm.TESLIMSEKLIACIKLAMASI = btn_TeslimSekliAciklamasi.Text;
            tm.TASIYICIKODU = btn_TasiyiciKodu.Text;
            tm.TASIYICIACIKLAMASI = btn_TasiyiciKoduAciklamasi.Text;
            tm.DETAYACIKLAMA1 = txt1aciklama.Text;
            tm.DETAYACIKLAMA2 = txt2aciklama.Text;
            tm.DETAYACIKLAMA3 = txt3aciklama.Text;
            tm.DETAYACIKLAMA4 = txt4aciklama.Text;
            tm.DETAYACIKLAMA5 = txt5aciklama.Text;
            tm.DETAYACIKLAMA6 = txt6aciklama.Text;
            tm.NAKLIYEBEDELI = string.IsNullOrWhiteSpace(txt_nakliyebedeli.Text) ? 0 : Convert.ToDouble(txt_nakliyebedeli.Text);


            tm.NOTLARACIKLAMA2 = txt_aciklama2.Text;
            tm.NOTLARACIKLAMA3 = txt_aciklama3.Text;
            tm.NOTLAROZELACIKLAMA1 = txt_ozelacik1.Text;
            tm.NOTLAROZELACIKLAMA2 = txt_ozelacik2.Text;
            tm.NOTLAROZELACIKLAMA3 = txt_ozelacik3.Text;
            tm.NOTLARUYARIMESAJI = lk_uyarimesaji.Text;


            tm.NOT = txt_not.Text;
            tm.TAKIPSONUC = txt_takipsonuc.Text;
            tm.OZELBILGI = txt_ozelbilgi.Text;
            tm.ONAYLAYAN = lk_Onaylayan.Text;
            tm.TEKLIFTIPI = txt_TeklifFisTipi.Text;

            tm.FATURABILGIADRES1 = txt_Adres1.Text;
            tm.FATURABILGIADRES2 = txt_Adres2.Text;
            tm.FATURABILGIULKE = txt_Ulke.Text;
            tm.FATURABILGIIL = txt_Il.Text;
            tm.FATURABILGIILCE = txt_Ilce.Text;
            tm.FATURABILGITELEFON = txt_Telefon.Text;
            tm.FATURABILGIVERGIDAIRESI = txt_VergiDairesi.Text;
            tm.FATURABILGIVERGINUMARASI = txt_VergiNo.Text;
            tm.FATURABILGIFAKS = txt_Fax.Text;
            tm.FATURABILGIPOSTAKODU = txt_PostaKodu.Text;
            tm.FirmaBilgileri = new FIRMABILGI
            {
                UNVANI = firmaBilgisi.OFFICALTITLE,
                ADRES = firmaBilgisi.STREET + " " + firmaBilgisi.ROAD + " No: " + firmaBilgisi.DOORNR,
                CADDE = firmaBilgisi.ROAD,
                FAX = firmaBilgisi.FAX,
                ILCE = firmaBilgisi.DISTRICT,
                KAPINO = firmaBilgisi.DOORNR,
                MAIL = firmaBilgisi.FIRMEMAILADDR,
                MERSISNO = firmaBilgisi.MERSISNO,
                SEHIR = firmaBilgisi.CITY,
                SOKAK = firmaBilgisi.STREET,
                TELEFON = firmaBilgisi.PHONE1,
                TICARETSICILNO = "",
                ULKE = firmaBilgisi.COUNTRY,
                VERGIDAIRESI = firmaBilgisi.TAXOFF,
                VERGINUMARASI = firmaBilgisi.TAXNR,
                WEB = firmaBilgisi.INTSALESADDR
            };
            tm.Satirlar = new List<SATIRLAR>();
            List<LOGO_XERO_TEKLIF_SATIR> satirlar = new List<LOGO_XERO_TEKLIF_SATIR>();
            int tabpage = xtraTabControl2.SelectedTabPageIndex;
            if (tabpage == 1)//ONAYLI SATIRLAR
            {
                if (gv_OnaylananTeklifSatirlari.RowCount == 0)
                {
                    XtraMessageBox.Show("Teklife Ait Onaylanan Satır Bulunmamaktadır !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                LOGO_XERO_TEKLIF_BASLIK baslik = db.LOGO_XERO_TEKLIF_BASLIK.Where(s => s.ID == Teklifid).FirstOrDefault();
                List<LOGO_XERO_ONAYLI_TEKLIF_SATIR> onaylilar = db.LOGO_XERO_ONAYLI_TEKLIF_SATIR.Where(s => s.TEKLIFID == baslik.ID).ToList();

                foreach (var item in onaylilar)
                {
                    LOGO_XERO_TEKLIF_SATIR satir;
                    satir = db.LOGO_XERO_TEKLIF_SATIR.Where(a => a.ID == item.TEKLIFSATIRID && a.TEKLIFID == item.TEKLIFID).FirstOrDefault();
                    if (satir != null)
                    {
                        satirlar.Add(satir);
                    }
                }
            }
            else if (tabpage == 0) //TEKLIF SATIRLARI
            {
                satirlar = (List<LOGO_XERO_TEKLIF_SATIR>)gv_TeklifSatirlari.DataSource;
            }

            satirlar = satirlar.OrderBy(S => S.SIRANO).ToList();
            int i = 1;
            double toplam = 0;
            foreach (var item in satirlar)
            {
                if (string.IsNullOrWhiteSpace(item.STOKADI)) { continue; }
                SATIRLAR satir = new SATIRLAR();

                toplam = Convert.ToDouble(item.TUTAR);

                satir.SIRANO = item.SIRANO;
                satir.BIRIM = item.BIRIM;
                //LOGO_XERO_TESLIM_SURESI sure = db.LOGO_XERO_TESLIM_SURESI.Where(s => s.ID == item.TESLIMSURESI).FirstOrDefault();
                //if (sure != null)
                //{
                //    string TESLIMSURESI = sure.TESLIMSURESI;
                //    satir.TESLIMSURESI = TESLIMSURESI;
                //}
                //else
                //{
                //    satir.TESLIMSURESI = null;
                //}
                satir.TESLIMSURESI = item.TESLIMSURESI;
                satir.NETFIYAT = item.NETFIYAT;
                satir.MIKTAR = item.MIKTAR;
                satir.STOKKODU = item.STOKKODU;
                satir.STOKADI = item.STOKADI;
                satir.KDV = item.KDV;
                satir.RAPORLAMADOVIZI = Convert.ToInt16(lk_RaporlamaDoviz.EditValue);
                satir.RAPORLAMADOVIZKURU = Convert.ToDouble(btn_raporlamakuru.Text);
                satir.ISLEMDOVIZI = Convert.ToInt16(Lk_IslemDoviz.EditValue);
                satir.ISLEMDOVIZKURU = Convert.ToDouble(btn_islemkuru.Text);
                satir.ARATOPLAM = Convert.ToDouble(txt_YerelToplam.Text);
                satir.ISKONTOLARTOPLUHALDE = item.ISKONTOYUZDESI1.ToString() + " , " + item.ISKONTOYUZDESI2.ToString() + " , " + item.ISKONTOYUZDESI3.ToString();
                satir.ISKONTOYUZDESI1 = item.ISKONTOYUZDESI1;
                satir.ISKONTOYUZDESI2 = item.ISKONTOYUZDESI2;
                satir.ISKONTOYUZDESI3 = item.ISKONTOYUZDESI3;
                satir.SATIRDOVIZKODU = 0;
                satir.SATIRDOVIZKURU = 1;
                satir.SATIRDOVIZKODU = item.SATIRDOVIZKODU;
                satir.DOVIZKURUTARIHI = item.DOVIZKURUTARIHI;
                satir.RAPORLAMADOVIZTIPI = lk_RaporlamaDoviz.Text;
                satir.KDVTUTARI = item.KDVTUTARI;
                satir.FIYAT = item.FIYAT;
                satir.TUTAR = item.TUTAR;
                satir.DOVIZLIFIYAT = item.DOVIZLIFIYAT;
                satir.SATIRISKONTOLUTUTAR = item.ISKONTOLUTUTAR;
                satir.TOPLAMTUTAR = item.TOPLAMTUTAR;
                satir.ISKONTOLUTUTAR = item.ISKONTOLUTUTAR;
                satir.TOPLAMINDIRIM = item.ISKONTOTUTARI1 + item.ISKONTOTUTARI2 + item.ISKONTOTUTARI3;


                if (SatirlarParaBirimi.SelectedIndex == 0 || SatirlarParaBirimi.SelectedIndex == 1)
                {
                    satir.DOVIZTIPI = "TL";
                    satir.DOVIZLIFIYAT = item.FIYAT / Convert.ToDouble(btn_raporlamakuru.Text);
                    double dovizlitoplam = toplam / Convert.ToDouble(btn_raporlamakuru.Text);
                    satir.DOVIZLIISKONTOLUTUTAR = item.ISKONTOLUTUTAR / Convert.ToDouble(btn_raporlamakuru.Text);
                }

                else if (SatirlarParaBirimi.SelectedIndex == 2)
                {
                    satir.SATIRDOVIZKURU = Convert.ToDouble(btn_islemkuru.Text);
                    satir.DOVIZTIPI = Lk_IslemDoviz.Text;
                    satir.RAPORLAMADOVIZTIPI = lk_RaporlamaDoviz.Text;
                    satir.DOVIZLIISKONTOLUTUTAR = item.ISKONTOLUTUTAR / Convert.ToDouble(btn_islemkuru.Text);
                }
                else
                {
                    satir.SATIRDOVIZKURU = item.SATIRDOVIZKURU;
                    satir.SATIRDOVIZKODU = item.SATIRDOVIZKODU;
                    satir.DOVIZKURUTARIHI = item.DOVIZKURUTARIHI;
                    if (satir.SATIRDOVIZKODU != null)
                    {
                        string doviz = "";
                        L_CURRENCYLIST DovizBilgisi = islem.DovizBilgisiGetir(firma, Convert.ToInt16(item.SATIRDOVIZKODU));
                        if (DovizBilgisi == null)
                        {
                            doviz = "TL";
                        }
                        else
                        {
                            doviz = DovizBilgisi.CURCODE;
                        }
                        satir.DOVIZTIPI = doviz;
                        satir.RAPORLAMADOVIZTIPI = lk_RaporlamaDoviz.Text;
                        satir.DOVIZLIISKONTOLUTUTAR = item.ISKONTOLUTUTAR / Convert.ToDouble((item.SATIRDOVIZKURU));
                    }
                }
                satir.DOVIZLITOPLAMTUTAR = item.TOPLAMTUTAR / item.SATIRDOVIZKURU;
                satir.DOVIZLITOPLAMINDIRIM = satir.TOPLAMINDIRIM / item.SATIRDOVIZKURU;
                satir.DOVIZLIKDVTUTARI = item.KDVTUTARI / item.SATIRDOVIZKURU;
                satir.DOVIZLITUTAR = item.TUTAR / item.SATIRDOVIZKURU;
                tm.Satirlar.Add(satir);
                i++;
            }
            frmRaporlar rpr = new frmRaporlar(this);
            if (!string.IsNullOrWhiteSpace(tm.EPOSTA))
            {
                rpr.txtEPosta.Text = tm.EPOSTA;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(tm.EPOSTA2))
                {
                    rpr.txtEPosta.Text = tm.EPOSTA2;
                }
            }
            rpr.txtGonderen.Text = ana._Kullanici.EPOSTA;
            rpr.TeklifData = tm;
            rpr.Show();
        }
        private Point downHitPoint;
        private int sourceRowHandle;
        public bool revizyonMu = false;
        public int eskiTeklifId = 0;
        private void btn_Revizyon_Click(object sender, EventArgs e)
        {
            if (Teklifid == 0)
            {
                XtraMessageBox.Show("Revizyon Yapabilmek İçin Önce Teklifi Kaydetiniz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (lk_onay.EditValue.ToString() == "2")
                {
                    XtraMessageBox.Show("Onaylanan Teklifin Revizyonu Yapılamaz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                using (LogoContext db = new LogoContext())
                {
                    duzenle = false;
                    revizyonMu = true;
                    eskiTeklifId = Teklifid;
                    var eskiTeklif = db.LOGO_XERO_TEKLIF_BASLIK.Where(s => s.ID == eskiTeklifId).FirstOrDefault();
                    string orijinalTeklifNo = eskiTeklif.TEKLIFNO.Split('-')[0];
                    Teklifid = 0;
                    List<LOGO_XERO_TEKLIF_BASLIK> list = db.LOGO_XERO_TEKLIF_BASLIK.Where(s => s.TEKLIFNO.Contains(orijinalTeklifNo)).ToList();
                    if (list != null)
                    {
                        foreach (var item in list)
                        {
                            item.REVIZYONNO++;
                        }
                    }
                    btn_kaydet_Click(sender, e);
                    var anakayit = db.LOGO_XERO_TEKLIF_BASLIK.Where(s => s.TEKLIFNO == orijinalTeklifNo && s.REVIZYONTEKLIFID == 0).FirstOrDefault();

                    if (eskiTeklif != null)
                    {
                        eskiTeklif.REVIZYONDURUMU = true;
                        db.LOGO_XERO_TEKLIF_BASLIK.AddOrUpdate(eskiTeklif);
                        db.SaveChanges();
                    }

                    revizyonMu = false;
                }
                Gorusmeler();
                HatirlatmalariGetir(Teklifid);
            }
        }
        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            GridControl ctrl = sender as GridControl;
            GridView view = (GridView)ctrl.MainView;
            downHitInfo = null;

            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            if (Control.ModifierKeys != Keys.None)
                return;
            if (e.Button == MouseButtons.Left && hitInfo.InRow && hitInfo.RowHandle != GridControl.NewItemRowHandle)
                downHitInfo = hitInfo;
        }
        private void gridView1_MouseMove(object sender, MouseEventArgs e)
        {
            GridControl ctrl = sender as GridControl;
            GridView view = (GridView)ctrl.MainView;
            if (lk_onay.EditValue.ToString() == "2") { return; }
            if (e.Button == MouseButtons.Left && downHitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(new Point(downHitInfo.HitPoint.X - dragSize.Width / 2,
                    downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);

                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    view.GridControl.DoDragDrop(downHitInfo, DragDropEffects.All);
                    downHitInfo = null;
                }
            }
        }
        private void grid_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(GridHitInfo)))
            {
                GridHitInfo downHitInfo = e.Data.GetData(typeof(GridHitInfo)) as GridHitInfo;
                if (downHitInfo == null)
                    return;

                GridControl grid = sender as GridControl;
                GridView view = grid.MainView as GridView;
                GridHitInfo hitInfo = view.CalcHitInfo(grid.PointToClient(new Point(e.X, e.Y)));
                if (hitInfo.InRow && hitInfo.RowHandle != downHitInfo.RowHandle && hitInfo.RowHandle != GridControl.NewItemRowHandle)
                    e.Effect = DragDropEffects.Move;
                else
                    e.Effect = DragDropEffects.None;
            }
        }
        private void simpleButton8_Click(object sender, EventArgs e)
        {
            Hesapla(sender, e);
        }
        private void simpleButton9_Click(object sender, EventArgs e)
        {
            Hesapla(sender, e);
        }
        private void simpleButton10_Click(object sender, EventArgs e)
        {
            Hesapla(sender, e);
        }
        public void HesaplaClick(object sender, EventArgs e)
        {
            Hesapla(sender, e);
        }
        void Hesapla(object sender, EventArgs e)
        {
            SimpleButton button = (SimpleButton)sender;
            txtHesapla.Focus();
            txtHesapla.SelectedText = button.Text.Replace("x", "*").Replace("X", "*");
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var txtTable = txtHesapla.Tag as String;
            pnlHesap.Visible = false;
            double sonuc = Convert.ToDouble(lblSonuc.Text);
            txtHesapla.Text = "";
            gv_TeklifSatirlari.SetRowCellValue(gv_TeklifSatirlari.FocusedRowHandle, txtTable, sonuc);
            grid_TeklifSatirlari.RefreshDataSource();
            grid_TeklifSatirlari.Refresh();
        }

        private void txtHesapla_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lblSonuc.Text = new DataTable().Compute(txtHesapla.Text.Replace(",", "."), null).ToString();
            }
            catch { }
        }
        private void simpleButton6_Click(object sender, EventArgs e)
        {
            txtHesapla.Text = "";
            pnlHesap.Visible = false;
        }
        private void context_TeklifSatirlari_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (lk_onay.EditValue.ToString() == "2")
            {
                toolStripMenuItem2.Visible = false;
                talepEdenFirmayıTümSatırlaraYazToolStripMenuItem.Visible = false;
            }
            else
            {
                toolStripMenuItem2.Visible = true;
                talepEdenFirmayıTümSatırlaraYazToolStripMenuItem.Visible = true;
            }
        }
        private void talepEdenFirmayıTümSatırlaraYazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gv_TeklifSatirlari.GetFocusedRow() != null && gv_TeklifSatirlari.GetFocusedRowCellValue(grdTalepEdenFirma) != null)
                {
                    string firmadi = gv_TeklifSatirlari.GetFocusedRowCellValue(grdTalepEdenFirma).ToString();
                    List<LOGO_XERO_TEKLIF_SATIR> str = (List<LOGO_XERO_TEKLIF_SATIR>)gv_TeklifSatirlari.DataSource;
                    str.Where(x => !string.IsNullOrEmpty(x.STOKADI)).ForEach(s => s.TALEPEDENFIRMA = firmadi);
                    grid_TeklifSatirlari.DataSource = str;
                    grid_TeklifSatirlari.RefreshDataSource();
                    grid_TeklifSatirlari.Refresh();
                }
            }
            catch (Exception)
            {
            }
        }

        private void rpTalepEdenFirma_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.CariListesiAc(this, 1, true);
        }

        private void lk_durum_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            if (duzenle == true)
            {
                if (Convert.ToInt32(lk_durum.EditValue) == 3)
                {
                    if (lbl_cariref.Text == "0" || string.IsNullOrWhiteSpace(lbl_cariref.Text))
                    {
                        XtraMessageBox.Show("Cari Bulunamadı ! Sipariş Oluşturabilmek İçin Cari Kart Seçimi Yapmalısınız !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        lk_durum.EditValue = lk_durum.OldEditValue;
                        return;
                    }
                    else
                    {
                        List<LOGO_XERO_TEKLIF_SATIR> list = grid_TeklifSatirlari.DataSource as List<LOGO_XERO_TEKLIF_SATIR>;
                        if (list != null)
                        {
                            if (list.Where(s => s.STOKLOGICALREF == 0 || s.STOKLOGICALREF == null).ToList().Count() > 0)
                            {
                                using (LogoContext db = new LogoContext())
                                {
                                    List<LOGO_XERO_TEKLIF_SATIR> liste = db.LOGO_XERO_TEKLIF_SATIR.Where(s => s.STOKLOGICALREF == 0 || s.STOKLOGICALREF == null).ToList();
                                    liste = liste.Where(s => s.TEKLIFID == Teklifid).ToList();

                                    XtraMessageBox.Show("Logoda Olmayan Stok Kartı Varken Siparişe Dönüştüremezsiniz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    //List<LOGO_XERO_TEKLIF_SATIR> gönderilcekler = list.Where(s => s.STOKLOGICALREF == 0 || s.STOKLOGICALREF == null).ToList();
                                    frmStokEsleme stokesleme = new frmStokEsleme(liste, this);
                                    stokesleme.ShowDialog();
                                    lk_durum.EditValue = lk_durum.OldEditValue;

                                    return;
                                }
                            }
                            if (LookUpDurum == Convert.ToInt32(lk_durum.EditValue) && LookUpDurum == 3)
                            {
                                frmTeklifOnaylama teklifonaylama = new frmTeklifOnaylama(Teklifid, this);
                                // teklifonaylama.Show();
                                frmTeklifSiparisOlusturma teklifsiparis = new frmTeklifSiparisOlusturma(teklifonaylama, this);
                                teklifsiparis.islemyapildi = true;
                                teklifsiparis.sipariseGidecekler = miktarlisatirdon(Teklifid);
                                teklifsiparis.ShowDialog();
                                OnaylanansatirlariGetir(Teklifid);
                            }
                            else if (Convert.ToInt32(lk_durum.EditValue) == 3)
                            {
                                frmTeklifOnaylama teklifonaylama = new frmTeklifOnaylama(Teklifid, this);
                                teklifonaylama.ShowDialog();
                                OnaylanansatirlariGetir(Teklifid);
                            }
                        }
                    }

                }
                using (LogoContext db = new LogoContext())
                {
                    LOGO_XERO_TEKLIF_BASLIK tklfbslk = db.LOGO_XERO_TEKLIF_BASLIK.Where(s => s.ID == Teklifid).FirstOrDefault();
                    if (tklfbslk != null)
                    {
                        tklfbslk.DURUMU = Convert.ToInt32(lk_durum.EditValue);
                        db.LOGO_XERO_TEKLIF_BASLIK.AddOrUpdate(tklfbslk);
                        db.SaveChanges();
                        Teklifid = tklfbslk.ID;
                    }
                }
                if (Convert.ToInt32(lk_durum.EditValue) != 3 && LookUpDurum == 3)
                {
                    if (XtraMessageBox.Show("Onaylanmış Satır Varsa Silincektir Ve Bağlı Sipariş Varsa Silinecektir. Onaylıyor Musunuz", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using (LogoContext db = new LogoContext())
                        {
                            //if (ana.demomu == 0)
                            //{
                            TEKLIF_SIPARIS_IPTAL_SONUC siparisSilmeSonucu = islem.TeklifinSilinmisSiparisiniKontrolEt(parametre, firma, donem, Teklifid, Trkod);
                            if (siparisSilmeSonucu.DURUM == true)
                            {
                                if (siparisSilmeSonucu.BAGLISIPARISVARMI == true)
                                {
                                    XtraMessageBox.Show(siparisSilmeSonucu.MESAJ, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {

                                }
                                List<LOGO_XERO_ONAYLI_TEKLIF_SATIR> list = db.LOGO_XERO_ONAYLI_TEKLIF_SATIR.Where(s => s.TEKLIFID == Teklifid).ToList();
                                db.LOGO_XERO_ONAYLI_TEKLIF_SATIR.RemoveRange(list);
                                db.SaveChanges();
                                XtraMessageBox.Show("Onaylı Teklif Satırları Silindi !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                OnaylanansatirlariGetir(Teklifid);
                                xtraTabControl2.SelectedTabPage = TeklifSatirlariTab;

                            }
                            else
                            {
                                XtraMessageBox.Show("İşlem Başarısız !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                lk_durum.EditValue = LookUpDurum;
                            }
                            //}
                            //else
                            //{
                            //    List<LOGO_XERO_ONAYLI_TEKLIF_SATIR> list = db.LOGO_XERO_ONAYLI_TEKLIF_SATIR.Where(s => s.TEKLIFID == Teklifid).ToList();
                            //    db.LOGO_XERO_ONAYLI_TEKLIF_SATIR.RemoveRange(list);
                            //    db.SaveChanges();
                            //    XtraMessageBox.Show("Onaylı Teklif Satırları Silindi !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //    OnaylanansatirlariGetir(Teklifid);
                            //}
                        }
                    }
                    else
                    {
                        lk_durum.EditValue = LookUpDurum;
                    }
                }
            }
        }
        public List<MIKTARLISATIR> miktarlisatirdon(int teklifid)
        {
            using (LogoContext db = new LogoContext())
            {
                string sql = $@"select ISNULL((select ONAYLANANMIKTAR from LOGO_XERO_ONAYLI_TEKLIF_SATIR_{firma} where TEKLIFID = s.TEKLIFID and TEKLIFSATIRID =s.ID),0)as ONAYLANANMIKTAR,
ISNULL((select ID from LOGO_XERO_ONAYLI_TEKLIF_SATIR_{firma} where TEKLIFID = s.TEKLIFID and TEKLIFSATIRID =s.ID),0) AS ONAYID,* 
from LOGO_XERO_TEKLIF_SATIR_{firma} s where s.TEKLIFID ={Teklifid}";

                List<MIKTARLISATIR> liste = db.Database.SqlQuery<MIKTARLISATIR>(sql).ToList();
                return liste;
            }
        }
        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                try
                {
                    double isk = Convert.ToDouble(toolStripTextBox1.Text);
                    List<LOGO_XERO_TEKLIF_SATIR> str = (List<LOGO_XERO_TEKLIF_SATIR>)gv_TeklifSatirlari.DataSource;
                    for (int i = 0; i < str.Count; i++)
                    {
                        var stokk = gv_TeklifSatirlari.GetRowCellValue(i, STOKKODU);
                        if (stokk != null)
                        {
                            gv_TeklifSatirlari.SetRowCellValue(i, ISKONTOYUZDESI1, isk);
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }
        private void lk_durum_Popup(object sender, EventArgs e)
        {
            LookUpEdit lk = (LookUpEdit)sender;
            LookUpDurum = Convert.ToInt32(lk.EditValue);
        }
        private void simpleButton14_Click(object sender, EventArgs e)
        {
            string teklifno = txt_teklifno.Text;
            using (LogoContext db = new LogoContext())
            {
                LOGO_XERO_TEKLIF_BASLIK anlikteklif = db.LOGO_XERO_TEKLIF_BASLIK.Where(s => s.ID == Teklifid && (s.REVIZYONDURUMU == true || s.REVIZYONTEKLIFID != 0)).FirstOrDefault();
                if (anlikteklif != null)
                {
                    string teklifnoo = anlikteklif.TEKLIFNO.Split('-')[0];
                    LOGO_XERO_TEKLIF_BASLIK sonrakirevizyon = db.LOGO_XERO_TEKLIF_BASLIK.Where(s => s.REVIZYONNO == anlikteklif.REVIZYONNO - 1 && s.TEKLIFNO.Contains(teklifnoo)).FirstOrDefault();
                    if (sonrakirevizyon != null)
                    {
                        baslikgetir(sender,e,sonrakirevizyon.ID);
                        List<LOGO_XERO_TEKLIF_SATIR> satirlar = satirgetir(sonrakirevizyon.ID);
                        grid_TeklifSatirlari.DataSource = satirlar;
                        bool bossatirvarmi = false;
                        foreach (var item in satirlar)
                        {
                            if (item.STOKKODU == null)
                            {
                                bossatirvarmi = true;
                                break;
                            }
                        }
                        if (lk_onay.EditValue.ToString() == "2")
                        {
                        }
                        else
                        {
                            if (!bossatirvarmi) //false sa
                            { 
                                SatirEkle();
                            }
                        }

                        grid_TeklifSatirlari.RefreshDataSource();
                        grid_TeklifSatirlari.Refresh();
                        OnaylanansatirlariGetir(sonrakirevizyon.ID);
                        Gorusmeler();
                        HatirlatmalariGetir(sonrakirevizyon.ID);
                        AltToplamlariHesapla();

                        islem.pageLockDelete(1, anlikteklif.ID);
                        Teklifid = sonrakirevizyon.ID;
                        islem.pageLock(1, Teklifid, ana._Kullanici.ID);
                    }
                }
            }
        }
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            string teklifno = txt_teklifno.Text;
            using (LogoContext db = new LogoContext())
            {
                LOGO_XERO_TEKLIF_BASLIK anlikteklif = db.LOGO_XERO_TEKLIF_BASLIK.Where(s => s.ID == Teklifid && (s.REVIZYONDURUMU == true || s.REVIZYONTEKLIFID != 0)).FirstOrDefault();
                if (anlikteklif != null)
                {
                    string teklifnoo = anlikteklif.TEKLIFNO.Split('-')[0];
                    LOGO_XERO_TEKLIF_BASLIK oncekirevizyon = db.LOGO_XERO_TEKLIF_BASLIK.Where(s => s.REVIZYONNO == anlikteklif.REVIZYONNO + 1 && s.TEKLIFNO.Contains(teklifnoo)).FirstOrDefault();
                    if (oncekirevizyon != null)
                    {
                        baslikgetir(sender, e, oncekirevizyon.ID);
                        List<LOGO_XERO_TEKLIF_SATIR> satirlar = satirgetir(oncekirevizyon.ID);
                        grid_TeklifSatirlari.DataSource = satirlar;
                        bool bossatirvarmi = false;
                        foreach (var item in satirlar)
                        {
                            if (item.STOKKODU == null)
                            {
                                bossatirvarmi = true;
                                break;
                            }
                        }
                        if (lk_onay.EditValue.ToString() == "2")
                        {
                        }
                        else
                        {
                            if (!bossatirvarmi) //false sa
                            { 
                                SatirEkle();
                            }
                        }

                        grid_TeklifSatirlari.RefreshDataSource();
                        grid_TeklifSatirlari.Refresh();
                        OnaylanansatirlariGetir(oncekirevizyon.ID);
                        Gorusmeler();
                        HatirlatmalariGetir(oncekirevizyon.ID);
                        AltToplamlariHesapla();


                        islem.pageLockDelete(1, anlikteklif.ID);
                        Teklifid = oncekirevizyon.ID;
                        islem.pageLock(1, Teklifid, ana._Kullanici.ID);
                    }
                }

            }
        }
        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Teklifid == 0)
            {
                XtraMessageBox.Show("Görüşme Eklemek İçin Önce Teklifi Kaydetiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                frmTeklifGorusmeler frm = new frmTeklifGorusmeler(this);
                frm.txtTeklifId.Text = Teklifid.ToString();
                frm.ShowDialog();
            }
        }
        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (gv_Gorusmeler.GetFocusedRow() != null)
            {
                LOGO_XERO_GORUSMELER gorusmeSatir = (LOGO_XERO_GORUSMELER)gv_Gorusmeler.GetFocusedRow();
                DialogResult dr = XtraMessageBox.Show("Görüşme Metni Silinecektir Devam Etmek İstiyor Musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                {
                    return;
                }
                else
                {
                    using (LogoContext db = new LogoContext())
                    {

                        var gorusme = db.LOGO_XERO_GORUSMELER.Where(s => s.ID == gorusmeSatir.ID).FirstOrDefault();
                        db.LOGO_XERO_GORUSMELER.Remove(gorusme);
                        db.SaveChanges();
                        Gorusmeler();
                    }
                }

            }

        }
        private void rpfiyatbutonlu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit btnSender = (ButtonEdit)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            context_satir.Show(ptLowerLeft);
        }
        private void stokFiyatListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LOGO_XERO_TEKLIF_SATIR str = (LOGO_XERO_TEKLIF_SATIR)gv_TeklifSatirlari.GetFocusedRow();
            if (str != null)
            {
                if (str.STOKKODU != null)
                {
                    frmStokFiyatListesi frm = new frmStokFiyatListesi(this, Trkod, firma, donem, str.STOKKODU);
                    frm.ShowDialog();
                }
            }
        }
        private void frmTeklifOlustur_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ana.parametre.M_GNL_KAYITLARDANSONRASAYFAYENILE == true)
            {
                frmTeklifListesi frmteklif = Application.OpenForms["frmTeklifListesi"] as frmTeklifListesi;
                if (frmteklif != null)
                {
                    frmteklif.Focus();
                    frmteklif.ListeyiDoldur();
                }
            }
        }
        private void lk_ambar_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            List<LOGO_XERO_TEKLIF_SATIR> list = (List<LOGO_XERO_TEKLIF_SATIR>)gv_TeklifSatirlari.DataSource;
            if (XtraMessageBox.Show("FİŞ SATIRLARINDA AMBAR BİLGİSİ GÜNCELLENSİN Mİ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                foreach (var item in list.Where(s => !string.IsNullOrWhiteSpace(s.STOKADI)))
                {
                    item.AMBAR = Convert.ToInt16(lk_ambar.EditValue);
                }
                grid_TeklifSatirlari.DataSource = list;
                grid_TeklifSatirlari.RefreshDataSource();
                grid_TeklifSatirlari.Refresh();
            }

        }
        public void StokListeGüncelle()
        {
            bool stokvar = false;
            List<LOGO_XERO_TEKLIF_SATIR> list = (List<LOGO_XERO_TEKLIF_SATIR>)gv_TeklifSatirlari.DataSource;
            foreach (var item in list)
            {
                if (!string.IsNullOrWhiteSpace(item.STOKKODU))
                {
                    stokvar = true;
                }
            }
            if (stokvar == true)
            {
                //List<string> stokliste = list.Select(s => s.STOKKODU).ToList();
                //for (int i = 0; i < stokliste.Count; i++)
                //{
                //    if (!string.IsNullOrWhiteSpace(stokliste[i]))
                //    {
                //        stokliste[i] = "'"+stokliste[i] + "'"; 
                //    }

                //}

                //string result = string.Join(",", stokliste);
                //string result1 = $@"and IT.CODE IN({result})";
                //result1 = result1.Substring(0, result1.Length-1 - 1);
                //grid_StokBakiye.DataSource = liste.UrunStokBakiyeBilgisiGetir(firma, donem, Convert.ToInt32(lk_ambar.EditValue), result1);
                //grid_StokBakiye.RefreshDataSource();
                //grid_StokBakiye.Refresh();
            }

        }
        private void rpDovizliFiyatButonlu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit btnSender = (ButtonEdit)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            context_satir.Show(ptLowerLeft);
        }
        private void simpleButton15_Click(object sender, EventArgs e)
        {
            try
            {
                LOGO_XERO_TEKLIF_BASLIK baslk = Basliklar.Where(s => s.ID == Teklifid).FirstOrDefault();
                if (baslk != null)
                {
                    int indx = Basliklar.IndexOf(baslk);
                    baslikgetir(sender,e,Basliklar[indx - 1].ID);
                    grid_TeklifSatirlari.DataSource = satirgetir(Basliklar[indx - 1].ID);
                    grid_TeklifSatirlari.RefreshDataSource();
                    grid_TeklifSatirlari.Refresh();
                    OnaylanansatirlariGetir(Basliklar[indx - 1].ID);
                    Gorusmeler();
                    HatirlatmalariGetir(Teklifid);
                    AltToplamlariHesapla();

                    islem.pageLockDelete(1, baslk.ID);
                    islem.pageLock(1, Teklifid, ana._Kullanici.ID);
                }

            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("Dizin aralık dışındaydı"))
                {
                    XtraMessageBox.Show("TEKLİFLERİN SONUNA GELDİNİZ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                XtraMessageBox.Show("ÖNCEKİ TEKLİFE GİDERKEN HATA : " + ex, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
        private void simpleButton16_Click(object sender, EventArgs e)
        {
            try
            {
                LOGO_XERO_TEKLIF_BASLIK baslk = Basliklar.Where(s => s.ID == Teklifid).FirstOrDefault();
                if (baslk != null)
                {
                    int indx = Basliklar.IndexOf(baslk);
                    baslikgetir(sender, e, Basliklar[indx + 1].ID);

                    grid_TeklifSatirlari.DataSource = satirgetir(Basliklar[indx + 1].ID);
                    grid_TeklifSatirlari.RefreshDataSource();
                    grid_TeklifSatirlari.Refresh();
                    OnaylanansatirlariGetir(Basliklar[indx + 1].ID);
                    Gorusmeler();
                    HatirlatmalariGetir(Teklifid);
                    AltToplamlariHesapla();
                    islem.pageLockDelete(1, baslk.ID);
                    islem.pageLock(1, Teklifid, ana._Kullanici.ID);
                }

            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("Dizin aralık dışındaydı"))
                {
                    XtraMessageBox.Show("TEKLİFLERİN SONUNA GELDİNİZ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                XtraMessageBox.Show("SONRAKİ TEKLİFE GİDERKEN HATA : " + ex, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
        private void btn_OnayaGonder_Click(object sender, EventArgs e)
        {
            if (Teklifid == 0)
            {
                XtraMessageBox.Show("Onaya Göderebilmek Teklifi İçin Kaydetmeniz Gereklidir !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (lk_Onaylayan.EditValue == null)
            {

                XtraMessageBox.Show("Teklifi Onaylayacak Yetkiliyi Belirtmeniz Gerekir !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                bool sonuc = KullaniciLimitKontrol();
                if (sonuc == false)
                {
                    return;
                }
                using (LogoContext db = new LogoContext())
                {
                    LOGO_XERO_TEKLIF_BASLIK tklfbslk = db.LOGO_XERO_TEKLIF_BASLIK.Where(s => s.ID == Teklifid).FirstOrDefault();
                    if (tklfbslk != null)
                    {
                        tklfbslk.ONAYAGONDERIM = 1;
                        tklfbslk.ONAYCEVAP = 0;
                        tklfbslk.ONAYLAYANID = Convert.ToInt32(lk_Onaylayan.EditValue);
                        db.LOGO_XERO_TEKLIF_BASLIK.AddOrUpdate(tklfbslk);
                        db.SaveChanges();
                        Teklifid = tklfbslk.ID;
                    }
                    XtraMessageBox.Show("Teklif Onaya Gönderildi !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Teklif Onaya Gönderilirken Hata Oluştu ! Hata : " + ex.ToString(), "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void groupControl6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt1aciklama_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
            if (e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
        private void txt2aciklama_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
            if (e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, false, true, true, true);
            }
            if (e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
        private void txt3aciklama_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
            if (e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, false, true, true, true);
            }
            if (e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
        private void txt4aciklama_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
            if (e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, false, true, true, true);
            }
            if (e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
        private void txt5aciklama_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
            if (e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, false, true, true, true);
            }
            if (e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
        private void txt6aciklama_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, false, true, true, true);
            }
            if (e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTeklifOlustur_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.F4)
            {
                simpleButton3_Click(sender, e);
            }
            if (e.KeyCode == Keys.F2)
            {
                btn_kaydet_Click(sender, e);
            }
        }

        private void frmTeklifOlustur_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Teklifid != 0)
            {
                islem.pageLockDelete(1, Teklifid);
            }
        }

        private void lk_Onaylayan_EditValueChanged(object sender, EventArgs e)
        {
            if (Teklifid != 0)
            {
                LOGO_XERO_KULLANICILAR OnaylayacakKullanici = islem.KullaniciBilgisiGetir(Convert.ToInt32(lk_Onaylayan.EditValue));
                double tltutar = Convert.ToDouble(txt_YerelToplamNet.Text);
                if (OnaylayacakKullanici != null)
                {
                    if (OnaylayacakKullanici.TEKLIFTUTARILIMIT > 0)
                    {
                        if (OnaylayacakKullanici.TEKLIFTUTARILIMIT < tltutar)
                        {

                            XtraMessageBox.Show("ONAYA GÖNDERİM BAŞARISIZ !" + Environment.NewLine + "Onaylayan Personel Limiti Yetersiz ! Gerekli Düzenlemeyi Yaptıktan Sonra Tekrar Deneyiniz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            lk_Onaylayan.EditValue = lk_Onaylayan.OldEditValue;
                            return;
                        }

                    }
                }

            }

        }
        public bool KullaniciLimitKontrol()
        {
            LOGO_XERO_KULLANICILAR OnaylayacakKullanici = islem.KullaniciBilgisiGetir(Convert.ToInt32(lk_Onaylayan.EditValue));
            double tltutar = Convert.ToDouble(txt_YerelToplamNet.Text);
            if (OnaylayacakKullanici != null)
            {
                if (OnaylayacakKullanici.TEKLIFTUTARILIMIT > 0)
                {
                    if (OnaylayacakKullanici.TEKLIFTUTARILIMIT < tltutar)
                    {
                        XtraMessageBox.Show("ONAYA GÖNDERİM BAŞARISIZ !" + Environment.NewLine + "Onaylayan Personel Limiti Yetersiz ! Gerekli Düzenlemeyi Yaptıktan Sonra Tekrar Deneyiniz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        lk_Onaylayan.EditValue = lk_Onaylayan.OldEditValue;
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (duzenle)
            {
                frmHatirlatmaListele hatlist;
                frmTeklifHatirlatmaEkle frm = new frmTeklifHatirlatmaEkle(hattip, this);
                frm.txtTeklifBaslik.Text = txt_teklifno.Text;
                frm.ShowDialog();
                HatirlatmalariGetir(Teklifid);
                hatlist = Application.OpenForms["frmHatirlatmaListele"] as frmHatirlatmaListele;
                if (hatlist != null)
                {
                    hatlist.Listele();
                }
            }
            else
            {
                XtraMessageBox.Show("Hatırlatma Eklemek İçin Önce Teklifi Kaydetiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void lk_durum_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lk_durum.EditValue) != 3)
            {
                xtraTabControl2.SelectedTabPage = TeklifSatirlariTab;
            }
            else if (Convert.ToInt32(lk_durum.EditValue) == 3)
            {
                xtraTabControl2.SelectedTabPage = OnayliTeklifSatirlariTab;
            }
        }

        private void btn_cariKodu_EditValueChanged(object sender, EventArgs e)
        {
            LOGO_XERO_CARI_BAKIYE listebak = genellisteler.Cari_Bakiye_Getir(firma, donem, $@"AND C.CODE = '{btn_cariKodu.Text}'").FirstOrDefault();
            if (listebak == null)
            {
                return;
            }
            textEdit1.Text = listebak.SONBORCTUTARI.ToString();
            textEdit2.Text = listebak.SONALACAKTUTARI.ToString();
            textEdit3.Text = listebak.BAKIYE.ToString();
            textEdit4.Text = listebak.ALACAK.ToString();
            textEdit5.Text = listebak.BORC.ToString();

        }

        private void gv_TeklifSatirlari_RowCountChanged(object sender, EventArgs e)
        {
            //StokListeGüncelle();
        }

        private void lk_ambar_EditValueChanged(object sender, EventArgs e)
        {
            List<LOGO_XERO_TEKLIF_SATIR> satirlar = gv_TeklifSatirlari.DataSource as List<LOGO_XERO_TEKLIF_SATIR>;
            if (satirlar == null)
            {
                satirlar = new List<LOGO_XERO_TEKLIF_SATIR>();
            }
            foreach (var item in satirlar)
            {
                if (!string.IsNullOrWhiteSpace(item.STOKKODU))
                {
                    item.AMBARBAKIYE = genellisteler.UrunStokBakiyeBilgisiGetir(firma, donem, Convert.ToInt32(lk_ambar.EditValue), item.STOKLOGICALREF);
                }
            }
        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gv_TeklifSatirlari_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gv_TeklifSatirlari.GetFocusedRow() != null && gv_TeklifSatirlari.GetFocusedRowCellValue("STOKKODU") != null)
            {
                string stokkodu = gv_TeklifSatirlari.GetFocusedRowCellValue("STOKKODU").ToString();
                if (!string.IsNullOrWhiteSpace(stokkodu))
                {
                    genellisteler.DepoStokGetir(firma, donem, stokkodu, grid_stokaltbakiye);
                }
            }
        }

        private void lk_durum_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {

        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gv_Gorusmeler.GetFocusedRow() != null && !string.IsNullOrWhiteSpace(gv_Gorusmeler.GetFocusedRowCellValue("ID").ToString()))
            {
                if (Teklifid == 0)
                {
                    XtraMessageBox.Show("Görüşü Düzenlemek İçin Önce Teklifi Kaydetiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    frmTeklifGorusmeler frm = new frmTeklifGorusmeler(this);
                    frm.gorusmeid = Convert.ToInt32(gv_Gorusmeler.GetFocusedRowCellValue("ID"));
                    frm.txtAciklama.Text = gv_Gorusmeler.GetFocusedRowCellValue("ACIKLAMA").ToString();
                    frm.txtTeklifId.Text = Teklifid.ToString();
                    frm.ShowDialog();
                }
            }
        }

        private void düzenleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (gv_Hatirlatmalar.GetFocusedRow() != null)
            {
                int id = Convert.ToInt32(gv_Hatirlatmalar.GetFocusedRowCellValue("ID"));
                using (LogoContext db = new LogoContext())
                {
                    LOGO_XERO_HATIRLATMA hatirlat = db.LOGO_XERO_HATIRLATMA.Where(s => s.ID == id).FirstOrDefault();
                    if (hatirlat.OKUNDU == true)
                    {
                        XtraMessageBox.Show("Okunmuş Hatırlatmalar Düzenlenemez !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    frmTeklifHatirlatmaEkle frmhat = new frmTeklifHatirlatmaEkle(hattip, this);
                    frmhat.id = id;
                    frmhat.Show();
                }
                HatirlatmalariGetir(Teklifid);

            }

        }
        public void DegisenSatirKaydet(int satirind)
        {
            using (LogoContext db = new LogoContext())
            {
                int id = Convert.ToInt32(gv_Hatirlatmalar.GetRowCellValue(satirind, "ID"));
                LOGO_XERO_HATIRLATMA hat = db.LOGO_XERO_HATIRLATMA.Where(s => s.ID == id).FirstOrDefault();
                hat.OKUNDU = Convert.ToBoolean(gv_Hatirlatmalar.GetRowCellValue(satirind, "OKUNDU"));
                db.LOGO_XERO_HATIRLATMA.AddOrUpdate(hat);
                db.SaveChanges();
            }
        }
        private void tümünüOkunduOlarakİşaretleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gv_Hatirlatmalar.RowCount; i++)
            {
                gv_Hatirlatmalar.FocusedRowHandle = i;
                gv_Hatirlatmalar.SetFocusedRowCellValue("OKUNDU", true);
                DegisenSatirKaydet(i);
            }
        }

        private void gv_Hatirlatmalar_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DegisenSatirKaydet(e.RowHandle);
        }

        private void gv_Hatirlatmalar_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DegisenSatirKaydet(e.RowHandle);
        }

        private void silToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (gv_Hatirlatmalar.GetFocusedRow() != null)
            {
                if (XtraMessageBox.Show("Bu Hatırlatmayı Silmek İstediğinize Emin Misiniz ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    using (LogoContext db = new LogoContext())
                    {
                        int id = Convert.ToInt32(gv_Hatirlatmalar.GetFocusedRowCellValue("ID"));
                        LOGO_XERO_HATIRLATMA hat = db.LOGO_XERO_HATIRLATMA.Where(s => s.ID == id).FirstOrDefault();
                        db.LOGO_XERO_HATIRLATMA.Remove(hat);
                        db.SaveChanges();
                        XtraMessageBox.Show("Silme İşlemi Başarılı !", "Hatırlatma Silindi ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        HatirlatmalariGetir(Teklifid);
                        frmHatirlatmaListele hatlist = Application.OpenForms["frmHatirlatmaListele"] as frmHatirlatmaListele;
                        if (hatlist != null)
                        {
                            hatlist.Listele();
                        }
                    }
                }
            }
        }

        private void hatırlatmaEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (duzenle)
            {
                frmHatirlatmaListele hatlist;

                frmTeklifHatirlatmaEkle frm = new frmTeklifHatirlatmaEkle(hattip, this);
                frm.txtTeklifBaslik.Text = txt_teklifno.Text;
                frm.ShowDialog();
                HatirlatmalariGetir(Teklifid);
                hatlist = Application.OpenForms["frmHatirlatmaListele"] as frmHatirlatmaListele;
                if (hatlist != null)
                {
                    hatlist.Listele();
                }
            }
            else
            {
                XtraMessageBox.Show("Hatırlatma Eklemek İçin Önce Teklifi Kaydetiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void context_hatirlatma_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LOGO_XERO_HATIRLATMA row = (LOGO_XERO_HATIRLATMA)gv_Hatirlatmalar.GetFocusedRow();
            if (row != null)
            {
                düzenleToolStripMenuItem1.Visible = true;
                silToolStripMenuItem1.Visible = true;
                tümünüOkunduOlarakİşaretleToolStripMenuItem.Visible = true;
            }
            else
            {
                düzenleToolStripMenuItem1.Visible = false;
                silToolStripMenuItem1.Visible = false;
                tümünüOkunduOlarakİşaretleToolStripMenuItem.Visible = false;
            }
        }

        private void panelControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void teklifiOnayBekliyorDurumunaGetirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lk_onay.EditValue = "1";
        }

        private void dövizKurlarınıGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDovizKurGuncelleme kurguncelleme = new frmDovizKurGuncelleme();
            kurguncelleme.ShowDialog();
            ana.KurlariAnaEkranaGetir();
        }

        private void ürünTedarikçileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gv_TeklifSatirlari.GetFocusedRow() != null)
            {
                LOGO_XERO_TEKLIF_SATIR satir = (LOGO_XERO_TEKLIF_SATIR)gv_TeklifSatirlari.GetFocusedRow();
                frmUrunTedarikcileri urunted = new frmUrunTedarikcileri();
                urunted.lbl_StokKodu.Text = (!string.IsNullOrWhiteSpace(satir.STOKKODU)) ? satir.STOKKODU : " ";
                urunted.lbl_StokAdi.Text = (!string.IsNullOrWhiteSpace(satir.STOKADI)) ? satir.STOKADI : " ";
                urunted.Liste((!string.IsNullOrWhiteSpace(satir.STOKKODU)) ? satir.STOKKODU : " ");
                urunted.ShowDialog();
            }
        }


        private void ürünEkstresiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LOGO_XERO_TEKLIF_SATIR satir = (LOGO_XERO_TEKLIF_SATIR)gv_TeklifSatirlari.GetFocusedRow();
            if (satir != null)
            {
                if (!string.IsNullOrWhiteSpace(satir.STOKKODU))
                {
                    frmUrunEkstresi ekstre = new frmUrunEkstresi(satir.STOKKODU, satir.STOKADI);
                    ekstre.ShowDialog();
                }
            }
        }

        private void topluStokVarYazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<LOGO_XERO_TEKLIF_SATIR> teklifsat = grid_TeklifSatirlari.DataSource as List<LOGO_XERO_TEKLIF_SATIR>;
            for (int i = 0; i < teklifsat.Where(s => !string.IsNullOrWhiteSpace(s.STOKKODU)).Count(); i++)
            {
                gv_TeklifSatirlari.SetRowCellValue(i, "TESLIMSURESI", "STOK VAR");
            }
        }

        private void lotBilgisiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LOGO_XERO_TEKLIF_SATIR satir = (LOGO_XERO_TEKLIF_SATIR)gv_TeklifSatirlari.GetFocusedRow();
            if (satir != null)
            {
                if (!string.IsNullOrWhiteSpace(satir.STOKKODU))
                {
                    frmLotBilgileri frmLot = new frmLotBilgileri();
                    frmLot.stokLogicalref = satir.STOKLOGICALREF;
                    frmLot.lbl_StokAdi.Text = satir.STOKADI;
                    frmLot.lbl_StokKodu.Text = satir.STOKKODU;

                    frmLot.ShowDialog();
                }
            }
        }

        private void buCariyeSonSatışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LOGO_XERO_TEKLIF_SATIR satir = (LOGO_XERO_TEKLIF_SATIR)gv_TeklifSatirlari.GetFocusedRow();
            if (satir != null)
            {
                if (!string.IsNullOrWhiteSpace(satir.STOKKODU))
                {
                    frmCariSonSatisListesi frm = new frmCariSonSatisListesi(this);
                    frm.tip = SatirlarParaBirimi.SelectedIndex == 0 ? 1 : 2;
                    frm.txtForm.Text = "TEKLİF";
                    frm.SonAlislar($@"AND C.CODE = '{btn_cariKodu.Text}'", satir.STOKKODU.ToString(), "AND S.TRCODE IN (7,8)");
                    frm.ShowDialog();
                }

            }

        }

        private void tümCarilereSonSatışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LOGO_XERO_TEKLIF_SATIR satir = (LOGO_XERO_TEKLIF_SATIR)gv_TeklifSatirlari.GetFocusedRow();
            frmCariSonSatisListesi frm = new frmCariSonSatisListesi(this);
            frm.tip = SatirlarParaBirimi.SelectedIndex == 0 ? 1 : 2;
            frm.txtForm.Text = "TEKLİF";
            frm.SonAlislar(" ", satir.STOKKODU.ToString(), "AND S.TRCODE IN (7,8)");
            frm.ShowDialog();
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            LOGO_XERO_TEKLIF_SATIR satir = (LOGO_XERO_TEKLIF_SATIR)gv_TeklifSatirlari.GetFocusedRow();
            frmCariSonSatisListesi frm = new frmCariSonSatisListesi(this);
            frm.tip = SatirlarParaBirimi.SelectedIndex == 0 ? 1 : 2;
            frm.Text = "Alınan Teklif Listesi";
            frm.txtForm.Text = "FATURA";
            frm.TeklifListe(btn_cariKodu.Text, satir.STOKKODU.ToString(), 1);
            frm.ShowDialog();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            LOGO_XERO_TEKLIF_SATIR satir = (LOGO_XERO_TEKLIF_SATIR)gv_TeklifSatirlari.GetFocusedRow();
            frmCariSonSatisListesi frm = new frmCariSonSatisListesi(this);
            frm.tip = SatirlarParaBirimi.SelectedIndex == 0 ? 1 : 2;
            frm.Text = "Verilen Teklif Listesi";
            frm.txtForm.Text = "FATURA";
            frm.TeklifListe(btn_cariKodu.Text, satir.STOKKODU.ToString(), 8);
            frm.ShowDialog();
        }

        private void sonSatınalmaFiyatlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LOGO_XERO_TEKLIF_SATIR satir = (LOGO_XERO_TEKLIF_SATIR)gv_TeklifSatirlari.GetFocusedRow();
            frmCariSonSatisListesi frm = new frmCariSonSatisListesi(this);
            frm.tip = SatirlarParaBirimi.SelectedIndex == 0 ? 1 : 2;
            frm.txtForm.Text = "TEKLİF";
            frm.SonAlislar($@"AND C.CODE = '{btn_cariKodu.Text}'", satir.STOKKODU.ToString(), "AND ((S.BILLED=1 AND S.TRCODE IN (1)) OR  (S.BILLED=0 AND S.TRCODE IN (13,14,50)))");
            frm.ShowDialog();
        }

        private void rpStokKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            LOGO_XERO_TEKLIF_SATIR satir = (LOGO_XERO_TEKLIF_SATIR)gv_TeklifSatirlari.GetFocusedRow();
            int tur = Convert.ToInt32(gv_TeklifSatirlari.GetFocusedRowCellValue(TUR));
            if (tur == 2)//hizmet
            {
                using (LogoContext db = new LogoContext())
                {
                    int stsals = (Trkod == 8) ? 2 : 1;
                    frmHizmetListesi hizmet = new frmHizmetListesi(this, stsals);
                    hizmet.ShowDialog();
                }
            }
            if (satir != null && tur == 1)//malzeme
            {
                frmStokListesi frm = new frmStokListesi(this);
                frm.seciliTeklifSatir = satir;
                frm.ShowDialog();
            }
        }

        private void rpBirim_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            LOGO_XERO_TEKLIF_SATIR satir = (LOGO_XERO_TEKLIF_SATIR)gv_TeklifSatirlari.GetFocusedRow();
            if (satir != null)
            {
                frmBirimler frm = new frmBirimler(this);
                frm.seciliTeklifSatir = satir;
                frm.ShowDialog();
                //}
            }
        }

        private void rpMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '*' || e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == '/')
            {
                TextEdit btn = (TextEdit)sender;
                Point point = grid_TeklifSatirlari.PointToScreen(new Point(btn.Location.X, btn.Location.Y - 150));
                pnlHesap.Location = point;
                pnlHesap.Visible = true;
                txtHesapla.Text = btn.Text + e.KeyChar.ToString();
                txtHesapla.Focus();
                txtHesapla.Select(txtHesapla.Text.Length, 0);
                txtHesapla.Tag = "MIKTAR";
                e.Handled = false;
            }
        }

        private void rpStokKodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextEdit ts = sender as TextEdit;
                var kod = ts.Text;
                int tur = Convert.ToInt32(gv_TeklifSatirlari.GetFocusedRowCellValue(TUR));
                if (tur == 1) //malzeme
                {
                    var liste = islem.BarkodStokKoduStokAra(kod, ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString());
                    string raporlamaturu = lk_RaporlamaDoviz.EditValue.ToString();
                    string islemturu = Lk_IslemDoviz.EditValue.ToString();
                    if (liste.Count == 0)
                    {
                        XtraMessageBox.Show("Stok Bulunamadı!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        tevkifatHesaplandi = 1;
                        TevkifatiGeriAl();
                        var stok = liste.FirstOrDefault();
                        int rowHandle = gv_TeklifSatirlari.GetRowHandle(gv_TeklifSatirlari.GetDataSourceRowIndex(gv_TeklifSatirlari.FocusedRowHandle));
                        List<LOGO_XERO_TEKLIF_SATIR> TeklifsatirListe = grid_TeklifSatirlari.DataSource as List<LOGO_XERO_TEKLIF_SATIR>;
                        int index = gv_TeklifSatirlari.GetDataSourceRowIndex(rowHandle);
                        LOGO_XERO_TEKLIF_SATIR seciliTeklifSatir = TeklifsatirListe[index];
                        seciliTeklifSatir.AMBARBAKIYE = genellisteler.UrunStokBakiyeBilgisiGetir(firma, donem, Convert.ToInt32(lk_ambar.EditValue), stok.LOGICALREF);
                        seciliTeklifSatir.STOKLOGICALREF = stok.LOGICALREF;
                        seciliTeklifSatir.STOKKODU = stok.STOKKODU;
                        seciliTeklifSatir.STOKADI = stok.STOKCINSI;
                        seciliTeklifSatir.FIYATGURUBU = btn_ticariIslemGuruplari.Text;
                        seciliTeklifSatir.BIRIM = stok.BIRIM;
                        seciliTeklifSatir.MARKA = stok.MARKA;
                        seciliTeklifSatir.KDV = stok.KDV;
                        seciliTeklifSatir.OZELKOD1 = stok.OZELKOD1;
                        seciliTeklifSatir.OZKODACIKLAMA = stok.OZKODACIKLAMA;
                        seciliTeklifSatir.SATIRTIPI = 0;
                        seciliTeklifSatir.TEVKIFATLI = Convert.ToBoolean(stok.TEVKIFAT);
                        if (Convert.ToBoolean(stok.TEVKIFAT))
                        {
                            seciliTeklifSatir.TEVKIFATKODU = stok.TEVKIFATKODU;
                            seciliTeklifSatir.TEVKIFATBOLEN = stok.TEVKIFATBOLEN;
                            seciliTeklifSatir.TEVKIFATCARPAN = stok.TEVKIFATCARPAN;
                        }
                        else
                        {
                            seciliTeklifSatir.TEVKIFATKODU = "";
                            seciliTeklifSatir.TEVKIFATBOLEN = 0;
                            seciliTeklifSatir.TEVKIFATCARPAN = 0;
                        }
                        seciliTeklifSatir.AMBAR = Convert.ToInt16(lk_ambar.EditValue.ToString());
                        seciliTeklifSatir.MIKTAR = 1;
                        seciliTeklifSatir.ISKONTOYUZDESI1 = 0;
                        seciliTeklifSatir.ISKONTOYUZDESI2 = 0;
                        seciliTeklifSatir.ISKONTOYUZDESI3 = 0;
                        seciliTeklifSatir.ISKONTOTUTARI1 = 0;
                        seciliTeklifSatir.ISKONTOTUTARI2 = 0;
                        seciliTeklifSatir.ISKONTOTUTARI3 = 0;
                        seciliTeklifSatir.SIRANO = 1;

                        double dovizkuru = 0;
                        double tlfiyat = 0;
                        double dovizlifiyat = 0;
                        Int16 dovizkodu = 0;
                        string doviztipi = "TL";


                        if (gv_TeklifSatirlari.GetRow(rowHandle - 1) != null)
                        {
                            seciliTeklifSatir.SIRANO = Convert.ToInt32(Convert.ToInt32(gv_TeklifSatirlari.GetRowCellValue(rowHandle - 1, SNo)) + 1);
                        }
                        if (seciliTeklifSatir.DOVIZKURUTARIHI == null)
                        {
                            seciliTeklifSatir.DOVIZKURUTARIHI = date_tarih.DateTime;
                        }
                        if (SatirlarParaBirimi.SelectedIndex == 0 || SatirlarParaBirimi.SelectedIndex == 1)
                        {
                            Int16 raporlamaDovizi = Convert.ToInt16(lk_RaporlamaDoviz.EditValue.ToString());
                            if ((raporlamaDovizi != 0 && raporlamaDovizi != 160) && (string.IsNullOrWhiteSpace(btn_raporlamakuru.Text) || btn_raporlamakuru.Text == "0"))
                            {
                                XtraMessageBox.Show("Raporlama Döviz Kuru Giriniz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                            else
                            {
                                if ((string.IsNullOrWhiteSpace(btn_raporlamakuru.Text) || btn_raporlamakuru.Text == "0"))
                                {
                                    btn_islemkuru.Text = "1";
                                }
                            }
                            dovizkuru = Convert.ToDouble(btn_raporlamakuru.Text);
                            dovizkodu = raporlamaDovizi;
                            if (stok.DOVIZKODU == null || stok.DOVIZKODU == 0 || stok.DOVIZKODU == 160)
                            {
                                tlfiyat = 0;
                                if (stok.LISTEFIYATI != null)
                                {
                                    tlfiyat = stok.LISTEFIYATI;
                                    if (ck_kdvdahil.Checked)
                                    {
                                        if (stok.KDVDURUMU == 0)
                                        {
                                            tlfiyat = tlfiyat * (1 + Convert.ToDouble(stok.KDV) / 100);
                                        }
                                    }
                                    else
                                    {
                                        if (stok.KDVDURUMU == 1)
                                        {
                                            tlfiyat = tlfiyat / (1 + Convert.ToDouble(stok.KDV) / 100);
                                        }
                                    }
                                }
                                dovizlifiyat = tlfiyat / dovizkuru;
                            }
                            else
                            {
                                if (raporlamaDovizi == stok.DOVIZKODU)
                                {
                                    tlfiyat = stok.LISTEFIYATI * dovizkuru;
                                    dovizlifiyat = stok.LISTEFIYATI;
                                    if (ck_kdvdahil.Checked)
                                    {
                                        if (stok.KDVDURUMU == 0)
                                        {
                                            tlfiyat = (stok.LISTEFIYATI * Convert.ToDouble(seciliTeklifSatir.SATIRDOVIZKURU)) * (1 + Convert.ToDouble(stok.KDV) / 100);
                                            dovizlifiyat = (stok.LISTEFIYATI) * (1 + Convert.ToDouble(stok.KDV) / 100);
                                        }
                                    }
                                    else
                                    {
                                        if (stok.KDVDURUMU == 1)
                                        {
                                            tlfiyat = (stok.LISTEFIYATI * Convert.ToDouble(seciliTeklifSatir.SATIRDOVIZKURU)) / (1 + Convert.ToDouble(stok.KDV) / 100);
                                            dovizlifiyat = (stok.LISTEFIYATI) / (1 + Convert.ToDouble(stok.KDV) / 100);
                                        }
                                    }
                                }
                                else
                                {
                                    double dovizKuru = islem.RatesTarihDovizKuruDondur(parametre, firmaLogoBilgi, stok.DOVIZKODU, date_tarih.DateTime, firma, donem);
                                    var birimf = stok.LISTEFIYATI * dovizKuru;
                                    tlfiyat = birimf;
                                    dovizlifiyat = birimf / dovizkuru;
                                    if (ck_kdvdahil.Checked)
                                    {
                                        if (stok.KDVDURUMU == 0)
                                        {
                                            birimf = (stok.LISTEFIYATI * dovizKuru) * (1 + Convert.ToDouble(stok.KDV) / 100);
                                            tlfiyat = birimf;
                                            dovizlifiyat = birimf / dovizkuru;
                                        }
                                    }
                                    else
                                    {
                                        if (stok.KDVDURUMU == 1)
                                        {
                                            birimf = (stok.LISTEFIYATI * dovizKuru) / (1 + Convert.ToDouble(stok.KDV) / 100);
                                            tlfiyat = birimf;
                                            dovizlifiyat = birimf / dovizkuru;
                                        }
                                    }
                                }
                            }
                        }
                        else if (SatirlarParaBirimi.SelectedIndex == 2)
                        {
                            Int16 IslemDovizKodu = Convert.ToInt16(Lk_IslemDoviz.EditValue);

                            if ((IslemDovizKodu != 0 || IslemDovizKodu != 160) && (string.IsNullOrWhiteSpace(btn_islemkuru.Text) || btn_islemkuru.Text == "0"))
                            {
                                XtraMessageBox.Show("İşlem Döviz Kuru Giriniz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                            else
                            {
                                if ((string.IsNullOrWhiteSpace(btn_islemkuru.Text) || btn_islemkuru.Text == "0"))
                                {
                                    btn_islemkuru.Text = "1";
                                }
                            }

                            dovizkuru = Convert.ToDouble(btn_islemkuru.Text);
                            dovizkodu = IslemDovizKodu;

                            seciliTeklifSatir.SATIRDOVIZKURU = Convert.ToDouble(btn_islemkuru.Text);
                            seciliTeklifSatir.SATIRDOVIZKODU = IslemDovizKodu;
                            seciliTeklifSatir.ISLEMDOVIZKURU = Convert.ToDouble(btn_islemkuru.Text);
                            if (IslemDovizKodu == 0 || IslemDovizKodu == 160)
                            {
                                if (stok.DOVIZKODU == 0 || stok.DOVIZKODU == 160 || stok.DOVIZKODU == null)
                                {
                                    tlfiyat = 0;
                                    if (stok.LISTEFIYATI != null)
                                    {
                                        tlfiyat = stok.LISTEFIYATI;
                                        if (ck_kdvdahil.Checked)
                                        {
                                            if (stok.KDVDURUMU == 0)
                                            {
                                                tlfiyat = tlfiyat * (1 + Convert.ToDouble(stok.KDV) / 100);
                                            }
                                        }
                                        else
                                        {
                                            if (stok.KDVDURUMU == 1)
                                            {
                                                tlfiyat = tlfiyat / (1 + Convert.ToDouble(stok.KDV) / 100);
                                            }
                                        }
                                    }
                                    dovizlifiyat = tlfiyat;
                                }
                                else
                                {
                                    double dovizKuru = islem.RatesTarihDovizKuruDondur(parametre, firmaLogoBilgi, stok.DOVIZKODU, Convert.ToDateTime(seciliTeklifSatir.DOVIZKURUTARIHI), firma, donem);
                                    tlfiyat = 0;
                                    tlfiyat = stok.LISTEFIYATI * dovizKuru;
                                    if (ck_kdvdahil.Checked)
                                    {
                                        if (stok.KDVDURUMU == 0)
                                        {
                                            tlfiyat = tlfiyat * (1 + Convert.ToDouble(stok.KDV) / 100);
                                        }
                                    }
                                    else
                                    {
                                        if (stok.KDVDURUMU == 1)
                                        {
                                            tlfiyat = tlfiyat / (1 + Convert.ToDouble(stok.KDV) / 100);
                                        }
                                    }
                                    dovizlifiyat = tlfiyat;
                                }
                            }
                            else
                            {
                                if (stok.DOVIZKODU == 0 || stok.DOVIZKODU == 160 || stok.DOVIZKODU == null)
                                {
                                    tlfiyat = 0;
                                    if (stok.LISTEFIYATI != null)
                                    {
                                        tlfiyat = stok.LISTEFIYATI;
                                        if (ck_kdvdahil.Checked)
                                        {
                                            if (stok.KDVDURUMU == 0)
                                            {
                                                tlfiyat = tlfiyat * (1 + Convert.ToDouble(stok.KDV) / 100);
                                            }
                                        }
                                        else
                                        {
                                            if (stok.KDVDURUMU == 1)
                                            {
                                                tlfiyat = tlfiyat / (1 + Convert.ToDouble(stok.KDV) / 100);
                                            }
                                        }
                                    }
                                    dovizlifiyat = tlfiyat / dovizkuru;
                                }
                                else
                                {
                                    if (IslemDovizKodu == stok.DOVIZKODU)
                                    {
                                        tlfiyat = stok.LISTEFIYATI * dovizkuru;
                                        dovizlifiyat = stok.LISTEFIYATI;
                                        if (ck_kdvdahil.Checked)
                                        {
                                            if (stok.KDVDURUMU == 0)
                                            {
                                                tlfiyat = (stok.LISTEFIYATI * Convert.ToDouble(seciliTeklifSatir.SATIRDOVIZKURU)) * (1 + Convert.ToDouble(stok.KDV) / 100);
                                                dovizlifiyat = (stok.LISTEFIYATI) * (1 + Convert.ToDouble(stok.KDV) / 100);
                                            }
                                        }
                                        else
                                        {
                                            if (stok.KDVDURUMU == 1)
                                            {
                                                tlfiyat = (stok.LISTEFIYATI * Convert.ToDouble(seciliTeklifSatir.SATIRDOVIZKURU)) / (1 + Convert.ToDouble(stok.KDV) / 100);
                                                dovizlifiyat = (stok.LISTEFIYATI) / (1 + Convert.ToDouble(stok.KDV) / 100);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        double dovizKuru = islem.RatesTarihDovizKuruDondur(parametre, firmaLogoBilgi, stok.DOVIZKODU, Convert.ToDateTime(seciliTeklifSatir.DOVIZKURUTARIHI), firma, donem);

                                        var birimf = stok.LISTEFIYATI * dovizKuru;
                                        tlfiyat = birimf;
                                        dovizlifiyat = birimf / dovizkuru;
                                        if (ck_kdvdahil.Checked)
                                        {
                                            if (stok.KDVDURUMU == 0)
                                            {
                                                birimf = (stok.LISTEFIYATI * dovizKuru) * (1 + Convert.ToDouble(stok.KDV) / 100);
                                                tlfiyat = birimf;
                                                dovizlifiyat = birimf / dovizkuru;
                                            }
                                        }
                                        else
                                        {
                                            if (stok.KDVDURUMU == 1)
                                            {
                                                birimf = (stok.LISTEFIYATI * dovizKuru) / (1 + Convert.ToDouble(stok.KDV) / 100);
                                                tlfiyat = birimf;
                                                dovizlifiyat = birimf / dovizkuru;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (stok.DOVIZKODU == 0 || stok.DOVIZKODU == 160 || stok.DOVIZKODU == null)
                            {
                                tlfiyat = 0;
                                if (stok.LISTEFIYATI != null)
                                {
                                    tlfiyat = stok.LISTEFIYATI;
                                    if (ck_kdvdahil.Checked)
                                    {
                                        if (stok.KDVDURUMU == 0)
                                        {
                                            tlfiyat = tlfiyat * (1 + Convert.ToDouble(stok.KDV) / 100);
                                        }
                                    }
                                    else
                                    {
                                        if (stok.KDVDURUMU == 1)
                                        {
                                            tlfiyat = tlfiyat / (1 + Convert.ToDouble(stok.KDV) / 100);
                                        }
                                    }
                                }
                                dovizlifiyat = tlfiyat;
                            }
                            else
                            {
                                double dovizKuru = islem.RatesTarihDovizKuruDondur(parametre, firmaLogoBilgi, stok.DOVIZKODU, Convert.ToDateTime(seciliTeklifSatir.DOVIZKURUTARIHI), firma, donem);
                                dovizkodu = Convert.ToInt16(stok.DOVIZKODU);
                                dovizkuru = dovizKuru;

                                var birimf = stok.LISTEFIYATI * dovizKuru;
                                tlfiyat = birimf;
                                dovizlifiyat = stok.LISTEFIYATI;
                                if (ck_kdvdahil.Checked)
                                {
                                    if (stok.KDVDURUMU == 0)
                                    {
                                        birimf = (stok.LISTEFIYATI * dovizKuru) * (1 + Convert.ToDouble(stok.KDV) / 100);
                                        tlfiyat = birimf;
                                        dovizlifiyat = birimf / dovizKuru;
                                    }
                                }
                                else
                                {
                                    if (stok.KDVDURUMU == 1)
                                    {
                                        birimf = (stok.LISTEFIYATI * dovizKuru) / (1 + Convert.ToDouble(stok.KDV) / 100);
                                        tlfiyat = birimf;
                                        dovizlifiyat = birimf / dovizkuru;
                                    }
                                }
                            }
                        }

                        seciliTeklifSatir.FIYAT = tlfiyat;
                        seciliTeklifSatir.NETFIYAT = tlfiyat;
                        seciliTeklifSatir.DOVIZLIFIYAT = dovizlifiyat;
                        seciliTeklifSatir.SATIRDOVIZKODU = dovizkodu;
                        seciliTeklifSatir.SATIRDOVIZKURU = dovizkuru;

                        seciliTeklifSatir.TUTAR = seciliTeklifSatir.FIYAT * seciliTeklifSatir.MIKTAR;
                        seciliTeklifSatir.ISKONTOLUTUTAR = seciliTeklifSatir.FIYAT * seciliTeklifSatir.MIKTAR;
                        seciliTeklifSatir.NETFIYAT = seciliTeklifSatir.FIYAT;
                        if (ck_kdvdahil.Checked)
                        {
                            var kdvtutari = seciliTeklifSatir.FIYAT / (1 + Convert.ToDouble(stok.KDV) / 100);
                            seciliTeklifSatir.KDVTUTARI = (seciliTeklifSatir.FIYAT - kdvtutari) * seciliTeklifSatir.MIKTAR;
                            seciliTeklifSatir.TOPLAMTUTAR = (seciliTeklifSatir.FIYAT) * seciliTeklifSatir.MIKTAR;
                        }
                        else
                        {
                            var kdvtutari = seciliTeklifSatir.FIYAT * (1 + Convert.ToDouble(stok.KDV) / 100);
                            seciliTeklifSatir.KDVTUTARI = (kdvtutari - seciliTeklifSatir.FIYAT) * seciliTeklifSatir.MIKTAR;
                            seciliTeklifSatir.TOPLAMTUTAR = (seciliTeklifSatir.FIYAT + seciliTeklifSatir.KDVTUTARI) * seciliTeklifSatir.MIKTAR;
                        } 
                        SatirEkle();
                        gv_TeklifSatirlari.FocusedRowHandle = gv_TeklifSatirlari.GetRowHandle(gv_TeklifSatirlari.RowCount - 1);
                        gv_TeklifSatirlari.SelectRow(gv_TeklifSatirlari.FocusedRowHandle);

                        tevkifatHesaplandi = 1;
                        TevkifatiGeriAl();
                        AltToplamlariHesapla();
                    }
                }
                if (tur == 2)
                {
                    if (gv_TeklifSatirlari.GetFocusedRow() != null)
                    {
                        LOGO_XERO_TEKLIF_SATIR FrmSatir = (LOGO_XERO_TEKLIF_SATIR)gv_TeklifSatirlari.GetFocusedRow();
                        if (FrmSatir != null)
                        {
                            using (LogoContext db = new LogoContext())
                            {
                                LOGO_XERO_HIZMETLISTESI hizmet = (LOGO_XERO_HIZMETLISTESI)db.LOGO_XERO_HIZMETLISTESI.Where(s => s.STOKKODU == kod).FirstOrDefault(); ;
                                if (hizmet == null)
                                {
                                    XtraMessageBox.Show("Yazılan Koda Ait Hizmet Bulunamadı !");
                                    return;
                                }
                                var raporlamaturu = lk_RaporlamaDoviz.EditValue.ToString();
                                var islemturu = Lk_IslemDoviz.EditValue.ToString();
                                gv_TeklifSatirlari.SetFocusedRowCellValue("STOKLOGICALREF", hizmet.LOGICALREF);
                                gv_TeklifSatirlari.SetFocusedRowCellValue("STOKKODU", hizmet.STOKKODU);
                                gv_TeklifSatirlari.SetFocusedRowCellValue("STOKADI", hizmet.STOKCINSI);
                                gv_TeklifSatirlari.SetFocusedRowCellValue("FIYATGURUBU", "testfiyatgrubu");
                                gv_TeklifSatirlari.SetFocusedRowCellValue("BIRIM", hizmet.BIRIM);
                                gv_TeklifSatirlari.SetFocusedRowCellValue("MARKA", hizmet.MARKA);
                                gv_TeklifSatirlari.SetFocusedRowCellValue("KDV", hizmet.KDV);
                                gv_TeklifSatirlari.SetFocusedRowCellValue("OZELKOD1", hizmet.OZELKOD1);
                                gv_TeklifSatirlari.SetFocusedRowCellValue("OZKODACIKLAMA", hizmet.OZKODACIKLAMA);
                                gv_TeklifSatirlari.SetFocusedRowCellValue("SATIRTIPI", "0");
                                gv_TeklifSatirlari.SetFocusedRowCellValue("TEVKIFATLI", hizmet.TEVKIFAT);
                                gv_TeklifSatirlari.SetFocusedRowCellValue("FIYAT", hizmet.LISTEFIYATI);
                                gv_TeklifSatirlari.SetFocusedRowCellValue("ISKONTOYUZDESI1", 0);
                                gv_TeklifSatirlari.SetFocusedRowCellValue("ISKONTOYUZDESI2", 0);
                                gv_TeklifSatirlari.SetFocusedRowCellValue("ISKONTOYUZDESI3", 0);
                                gv_TeklifSatirlari.SetFocusedRowCellValue("MIKTAR", 1);
                                gv_TeklifSatirlari.SetFocusedRowCellValue("SATIRDOVIZKODU", 0);

                                if (Convert.ToBoolean(hizmet.TEVKIFAT))
                                {
                                    gv_TeklifSatirlari.SetFocusedRowCellValue("TEVKIFATKODU", hizmet.TEVKIFATKODU);
                                    gv_TeklifSatirlari.SetFocusedRowCellValue("TEVKIFATBOLEN", hizmet.TEVKIFATBOLEN);
                                    gv_TeklifSatirlari.SetFocusedRowCellValue("TEVKIFATCARPAN", hizmet.TEVKIFATCARPAN);
                                }
                                else
                                {
                                    FrmSatir.TEVKIFATKODU = "";
                                    FrmSatir.TEVKIFATBOLEN = 0;
                                    FrmSatir.TEVKIFATCARPAN = 0;
                                }
                                gv_TeklifSatirlari.SetFocusedRowCellValue("AMBAR", Convert.ToInt16(lk_ambar.EditValue.ToString()));

                                SatirEkle(2);
                                SiraNoYenile();
                            }
                        }
                    }
                }

            }

            if (e.KeyCode == Keys.F10)
            {
                ts = sender as TextEdit;
                var kod = ts.Text;

                if (kod == "")
                {
                    XtraMessageBox.Show("Stok Kodu Giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                LOGO_XERO_TEKLIF_SATIR satir = (LOGO_XERO_TEKLIF_SATIR)gv_TeklifSatirlari.GetFocusedRow();
                if (satir != null)
                {
                    frmStokListesi frmStok = new frmStokListesi(this);
                    frmStok.seciliTeklifSatir = satir;
                    frmStok.kod = kod;
                    frmStok.ShowDialog(); 
                }
            }
            SiraNoYenile();
        }
        public TextEdit ts;
        private void perakendeSatışFiyatlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LOGO_XERO_TEKLIF_SATIR satir = (LOGO_XERO_TEKLIF_SATIR)gv_TeklifSatirlari.GetFocusedRow();
            if (satir != null)
            {
                frmPerakendeSatisFiyat frm = new frmPerakendeSatisFiyat(this);
                frm.tip = SatirlarParaBirimi.SelectedIndex == 0 ? 1 : 2;
                frm.ShowDialog();
            }
        }

        private void kampanyaFiyatlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LOGO_XERO_TEKLIF_SATIR satir = (LOGO_XERO_TEKLIF_SATIR)gv_TeklifSatirlari.GetFocusedRow();
            if (satir != null)
            {
                frmKampanyaFiyat frm = new frmKampanyaFiyat(this);
                frm.tip = SatirlarParaBirimi.SelectedIndex == 0 ? 1 : 2;
                frm.Listele(satir.STOKKODU);
                frm.ShowDialog();
            }
        }

        private void ürünStokHareketleriToolStripMenuItem_Click(object sender, EventArgs e)
        {

            LOGO_XERO_TEKLIF_SATIR satir = (LOGO_XERO_TEKLIF_SATIR)gv_TeklifSatirlari.GetFocusedRow();
            if (satir != null)
            {
                if (!string.IsNullOrWhiteSpace(satir.STOKKODU))
                {
                    frmUrunStokHareketleri hareketler = new frmUrunStokHareketleri(satir.STOKKODU);
                    hareketler.lbl_StokAdi.Text = satir.STOKADI;
                    hareketler.lbl_StokKodu.Text = satir.STOKKODU;
                    hareketler.ShowDialog();
                }
            }

        }

        private void lk_OdemeTipi_EditValueChanged(object sender, EventArgs e)
        {

            vadegun(Convert.ToInt32(lk_OdemeTipi.EditValue));

        }

        private void date_gelistarihi_EditValueChanged(object sender, EventArgs e)
        {
            vadegun(Convert.ToInt32(lk_OdemeTipi.EditValue));

        }

        private void simpleButton18_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lbl_cariref.Text) || lbl_cariref.Text == "0")
            {
                XtraMessageBox.Show("CARİ SEÇİNİZ !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btn_cariKodu.Focus();
            }
            else
            {
                frmCekRiskBilgileri frm = new frmCekRiskBilgileri();
                frm.kod = btn_cariKodu.Text;
                frm.cariUnvan = btn_cariUnvani.Text;
                frm.carilogicalref = Convert.ToInt32(lbl_cariref.Text);
                frm.CekListesi();
                frm.ShowDialog();
            }
        }

        public void Uyari(object sender, EventArgs e)
        {
            if (lbl_cariref.Text != "0" && !string.IsNullOrWhiteSpace(lbl_cariref.Text))
            {
                int cariref = Convert.ToInt32(lbl_cariref.Text);
                List<LG_CLINTEL> istihbarat = islem.IstihbaratBilgileriGetir(cariref);
                if (istihbarat.Count > 0)
                {
                    btn_cariKodu.BackColor = Color.Red;
                    btn_cariUnvani.BackColor = Color.Red;
                    btn_cariKodu.ForeColor = Color.White;
                    btn_cariUnvani.ForeColor = Color.White;
                    timer_CariIstıhbaratBilgileri.Enabled = true;
                    picUyari_Click(sender, e);
                }
                else
                {
                    timer_CariIstıhbaratBilgileri.Enabled = false;
                    picUyari.EditValue = global::LOGO_XERO.Properties.Resources.icon_48_alert_kırmızı;
                    btn_cariKodu.BackColor = Color.White;
                    btn_cariUnvani.BackColor = Color.White;
                    btn_cariKodu.ForeColor = Color.Black;
                    btn_cariUnvani.ForeColor = Color.Black;
                }
            }
        }

        private void picUyari_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lbl_cariref.Text) || lbl_cariref.Text == "0")
            {
                XtraMessageBox.Show("CARİ SEÇİNİZ !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btn_cariKodu.Focus();
            }
            else
            {
                frmIstihbaratBilgileriListele frm = new frmIstihbaratBilgileriListele();
                frm.cariref = Convert.ToInt32(lbl_cariref.Text);
                frm.ShowDialog();
            }
        }
        private void timer_CariIstıhbaratBilgileri_Tick(object sender, EventArgs e)
        {
            if (picUyari.Image != null)
            {
                picUyari.Image = null;
            }
            else
            {
                picUyari.EditValue = global::LOGO_XERO.Properties.Resources.icon_48_alert_kırmızı;
            }
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        private void lk_fabrika_EditValueChanged(object sender, EventArgs e)
        {
            int isyeri = Convert.ToInt32(lk_isyeri.EditValue.ToString());
            int fabrika = Convert.ToInt32(lk_fabrika.EditValue.ToString());
            islem.AmbarListesiDoldur(lk_ambar, ana.lk_firma.EditValue.ToString(), isyeri, fabrika);
            islem.AmbarListesiDoldur(rpSatirAmbarNo, ana.lk_firma.EditValue.ToString(), isyeri, fabrika);
        }

        private void cm_FaturaTipiSecim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cm_FaturaTipiSecim.SelectedIndex == 3)
            {

            }
            else
            {
                btn_KdvMuafiyetSebebiKodu.Text = "";
                txt_KdvMuafiyetSebebiAciklamasi.Text = "";
                List<LOGO_XERO_TEKLIF_SATIR> TeklifsatirListe = grid_TeklifSatirlari.DataSource as List<LOGO_XERO_TEKLIF_SATIR>;

                if (TeklifsatirListe != null)
                {
                    foreach (var item in TeklifsatirListe)
                    {
                        item.KDVMUAFIYETKODU = "";
                        item.KDVMUAFIYETACIKLAMA = "";
                    }
                    grid_TeklifSatirlari.Refresh();
                }
            }
        }

        private void btn_KdvMuafiyetSebebiKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (cm_FaturaTipiSecim.Text == "İstisna")
            {

                if (string.IsNullOrWhiteSpace(ana.parametre.PROGRAMKATALOGDOSYAYOLU))
                {
                    XtraMessageBox.Show("SİSTEM PARAMETRELERİNE PROGRAM KATALOG DOSYA YOLU GİRİNİZ !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                frmKdvMuafiyetSebepleri frm = new frmKdvMuafiyetSebepleri(this, ana.parametre, 0);
                frm.ShowDialog();
            }
        }

        void KdvMuafiyetSebebiSec()
        {
            try
            {
                string dosyayolu = ana.parametre.PROGRAMKATALOGDOSYAYOLU + "\\VatExcepts.xml";
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(dosyayolu);
                VATEXCEPT_REASON result = new VATEXCEPT_REASON();
                XmlReader xmlReader = new XmlNodeReader(xmlDocument);
                XmlSerializer serializer = new XmlSerializer(typeof(LOGO_XERO.Models.LOGO_M.DosyaClaslari.VATEXCEPT_REASON));
                result = (LOGO_XERO.Models.LOGO_M.DosyaClaslari.VATEXCEPT_REASON)serializer.Deserialize(xmlReader);
                if (result.VATEXCEPTREASON.Count > 0)
                {
                    var row = result.VATEXCEPTREASON.Where(s => s.CODE == btn_KdvMuafiyetSebebiKodu.Text).FirstOrDefault();
                    if (row != null)
                    {
                        btn_KdvMuafiyetSebebiKodu.Text = row.CODE;
                        txt_KdvMuafiyetSebebiAciklamasi.Text = row.NAME;
                        if (MessageBox.Show("Fiş Satırları KDV Muafiyet Bilgileri Güncellenecek !", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            List<LOGO_XERO_TEKLIF_SATIR> TeklifsatirListe = grid_TeklifSatirlari.DataSource as List<LOGO_XERO_TEKLIF_SATIR>;

                            if (TeklifsatirListe != null)
                            {
                                foreach (var item in TeklifsatirListe)
                                {
                                    item.KDVMUAFIYETKODU = row.CODE;
                                    item.KDVMUAFIYETACIKLAMA = row.NAME;
                                }
                                grid_TeklifSatirlari.Refresh();
                            }
                        }
                    }
                    else
                    {
                        btn_KdvMuafiyetSebebiKodu.Text = "";
                        txt_KdvMuafiyetSebebiAciklamasi.Text = "";
                    }
                }
                else
                {
                    btn_KdvMuafiyetSebebiKodu.Text = "";
                    txt_KdvMuafiyetSebebiAciklamasi.Text = "";
                }
            }
            catch (Exception)
            {
                btn_KdvMuafiyetSebebiKodu.Text = "";
                txt_KdvMuafiyetSebebiAciklamasi.Text = "";
            }
        }

        private void btn_KdvMuafiyetSebebiKodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (string.IsNullOrEmpty(btn_KdvMuafiyetSebebiKodu.Text)) return;
                KdvMuafiyetSebebiSec();
            }
        }
        
        private void rp_KdvMuafiyetSebebi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (cm_FaturaTipiSecim.Text == "İstisna")
            {

                if (string.IsNullOrWhiteSpace(ana.parametre.PROGRAMKATALOGDOSYAYOLU))
                {
                    XtraMessageBox.Show("SİSTEM PARAMETRELERİNE PROGRAM KATALOG DOSYA YOLU GİRİNİZ !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                frmKdvMuafiyetSebepleri frm = new frmKdvMuafiyetSebepleri(this, ana.parametre, 1);
                frm.ShowDialog();
            }
        }

        private void rp_KdvMuafiyetSebebi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ButtonEdit senderbtn = (ButtonEdit)sender ;
                LOGO_XERO_TEKLIF_SATIR satir = (LOGO_XERO_TEKLIF_SATIR)gv_TeklifSatirlari.GetFocusedRow();
                if (cm_FaturaTipiSecim.Text == "İstisna")
                { 
                    if (satir != null)
                    {
                        
                        string kod = senderbtn.Text;
                        if (!string.IsNullOrWhiteSpace(kod) )
                        {
                            string deger = islem.kdvmaufiyetgetir(parametre, kod);
                            if (deger != "hata")
                            {
                                satir.KDVMUAFIYETACIKLAMA = deger;
                            }
                            else
                            {
                                XtraMessageBox.Show("KDV Muafiyet Kodu Bulunamadı !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                satir.KDVMUAFIYETACIKLAMA = "";
                                senderbtn.Text = "";
                            } 
                        }
                        else
                        {
                            satir.KDVMUAFIYETACIKLAMA = "";
                            senderbtn.Text = "";
                        }
                    }
                    else
                    {
                        satir.KDVMUAFIYETACIKLAMA = ""; senderbtn.Text = "";
                    }
                    
                }
                else
                {
                    XtraMessageBox.Show("KDV Muafiyet Girebilmek İçin Fatura Tipini İstisna Olarak Değiştiriniz !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    satir.KDVMUAFIYETACIKLAMA = "";
                    senderbtn.Text = "";
                }
            }
        }

        private void grid_DragDrop(object sender, DragEventArgs e)
        {
            GridControl grid = sender as GridControl;
            GridView view = grid.MainView as GridView;
            GridHitInfo srcHitInfo = e.Data.GetData(typeof(GridHitInfo)) as GridHitInfo;
            GridHitInfo hitInfo = view.CalcHitInfo(grid.PointToClient(new Point(e.X, e.Y)));
            int sourceRow = srcHitInfo.RowHandle;
            int targetRow = hitInfo.RowHandle;
            MoveRow(sourceRow, targetRow);
            SiraNoYenile();
        }
        private void MoveRow(int sourceRow, int targetRow)
        {
            if (sourceRow == targetRow)
                return;

            List<LOGO_XERO_TEKLIF_SATIR> teklifsatirListe = grid_TeklifSatirlari.DataSource as List<LOGO_XERO_TEKLIF_SATIR>;
            if (teklifsatirListe == null)
                return;

            LOGO_XERO_TEKLIF_SATIR sourceItem = teklifsatirListe[sourceRow];
            LOGO_XERO_TEKLIF_SATIR targetItem = teklifsatirListe[targetRow];
            if (targetItem.STOKKODU == null)
            {
                return;
            }
            double sourceSirano = (double)sourceItem.SIRANO;
            double targetSirano = (double)targetItem.SIRANO;

            if (targetRow == sourceRow + 1 || sourceRow == targetRow + 1)
            {
                // Komşu satırlar yer değiştiriyor
                sourceItem.SIRANO = (int?)targetSirano;
                targetItem.SIRANO = (int?)sourceSirano;
            }
            else
            {
                LOGO_XERO_TEKLIF_SATIR row0 = targetRow > 0 ? teklifsatirListe[targetRow - 1] : null;
                LOGO_XERO_TEKLIF_SATIR row2 = targetRow < teklifsatirListe.Count - 1 ? teklifsatirListe[targetRow + 1] : null;
                double val1 = row0?.SIRANO ?? (targetSirano - 1);
                double val2 = row2?.SIRANO ?? (targetSirano + 1);

                sourceItem.SIRANO = (int?)((val1 + val2) / 2);
            }

            teklifsatirListe.RemoveAt(sourceRow);
            if (targetRow > sourceRow)
                targetRow--;

            teklifsatirListe.Insert(targetRow, sourceItem);

            grid_TeklifSatirlari.DataSource = null;
            grid_TeklifSatirlari.DataSource = teklifsatirListe;
            gv_TeklifSatirlari.FocusedRowHandle = targetRow;
        }
        public void SiraNoYenile()
        {
            List<LOGO_XERO_TEKLIF_SATIR> satirlar = (List<LOGO_XERO_TEKLIF_SATIR>)gv_TeklifSatirlari.DataSource;
            int i = 1;
            satirlar.ForEach(x =>
            {
                if (!string.IsNullOrWhiteSpace(x.STOKADI))
                {
                    x.SIRANO = i++;
                }
                //if (x.STOKLOGICALREF != null)
                //{
                //    x.SIRANO = i++;
                //}
            }
            );
            grid_TeklifSatirlari.DataSource = satirlar;
            grid_TeklifSatirlari.RefreshDataSource();
            grid_TeklifSatirlari.Refresh();
        }

    }
}