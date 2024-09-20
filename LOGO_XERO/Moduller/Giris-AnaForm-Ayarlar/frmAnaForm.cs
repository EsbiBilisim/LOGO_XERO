using DevExpress.LookAndFeel;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraTab;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using LOGO_XERO.Models.LOGO_M;
using LOGO_XERO.Models.LOGO_XERO_M;
using LOGO_XERO.Moduller._1_TeklifModul;
using LOGO_XERO.Moduller._1_TeklifModul.TeklifRaporlari;
using LOGO_XERO.Moduller._7_Raporlar;
using LOGO_XERO.Moduller.AyarlarModul;
using LOGO_XERO.Moduller.Finans;
using LOGO_XERO.Moduller.GenelListeler;
using LOGO_XERO.Moduller.Giris_AnaForm_Ayarlar;
using LOGO_XERO.Moduller.MalzemeYonetimi;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LOGO_XERO
{
    public partial class frmAnaForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        Islemler islem = new Islemler();
        public int demomu = 0;
        public string firma, donem;
        RegistryKey rsk = Registry.CurrentUser.CreateSubKey("Software\\EsbiSetting\\LOGO_XERO");
        public LOGO_XERO_KULLANICILAR _Kullanici;
        public L_CAPIFIRM firmaBilgisi;


        public LOGO_XERO_PARAMETRELER parametre = new LOGO_XERO_PARAMETRELER();
        public byte[] FATURALOGO;
        public byte[] FATURAIMZA;
        IlkTabloIslemler ilkislemler = new IlkTabloIslemler();
        public List<L_FIRMPARAMS> FirmaLogoParametre;

        L_FIRMPARAMS stokKartiStandartBirimSet = new L_FIRMPARAMS();
        LG_UNITSETF birimSeti = new LG_UNITSETF();
        List<LG_UNITSETL> AltBirimler = new List<LG_UNITSETL>();
        public LG_UNITSETL anabirim = new LG_UNITSETL();

        public frmAnaForm(LOGO_XERO_KULLANICILAR Kullanici)
        {
            InitializeComponent();
            _Kullanici = Kullanici;
            try
            {
                using (LogoContext db = new LogoContext())
                {
                    _Kullanici = islem.KullaniciBilgisiGetir(_Kullanici.ID);
                }

                //UserLookAndFeel.Default.SkinName = rsk.GetValue("Skin").ToString();
            }
            catch
            {
            }
        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            frmTeklifOlustur frm1 = (frmTeklifOlustur)Application.OpenForms["frmTeklifOlustur"];
            if (frm1 != null)
            {
                frm1.Focus();
            }
            else
            {
                frmTeklifOlustur frm = new frmTeklifOlustur();
                frm.MdiParent = this;
                frm.Show();
            }
        }


        private void frmAnaForm_Load(object sender, EventArgs e)
        {
            barDockControlTop.Visible = false;
            islem.FirmaListesiDoldur(Lk_Firmaa);
            lk_firma.EditValue = firma;
            lk_donem.EditValue = donem;
            parametre = islem.ParametreAl(firma, donem);
            FATURALOGO = parametre.FATURALOGO;
            firmaBilgisi = islem.FirmaBilgileriGetir(lk_firma.EditValue.ToString());
            KurlariAnaEkranaGetir();


            FirmaLogoParametre = islem.FirmaLogoTumParametreleriGetir(lk_firma.EditValue.ToString());
            stokKartiStandartBirimSet = FirmaLogoParametre.Where(s => s.GROUPNR == 40 && s.MODULENR == 1 && s.CODE == "ITEM_UNITSETREF").FirstOrDefault();
            int AnaBirimRef = Convert.ToInt32(stokKartiStandartBirimSet.VALUE);
            birimSeti = islem.BirimSetiGetir(AnaBirimRef);
            AltBirimler = islem.BiriminAltBirimleriniListele(AnaBirimRef);
            anabirim = AltBirimler.Where(s => s.MAINUNIT == 1).FirstOrDefault();


            ilkislemler.KurTablosuDoldur(lk_firma.EditValue.ToString());
            frmAnaDashBoard frm = new frmAnaDashBoard();
            frm.Text = _Kullanici.KULLANICIADI;
            frm.MdiParent = this;
            frm.Show();
        }

        public void KurlariAnaEkranaGetir()
        {
            txt_dolarKuru.EditValue = islem.RatesTarihDovizKuruDondur(parametre, firmaBilgisi, 1, DateTime.Now, firma, donem).ToString();
            txt_euroKuru.EditValue = islem.RatesTarihDovizKuruDondur(parametre, firmaBilgisi, 20, DateTime.Now, firma, donem).ToString();
        }
        private void frmAnaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DialogResult dr = XtraMessageBox.Show("Program Kapatılacak ! Emin Misiniz ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    this.Dispose();
                    Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception)
            {
            }
        }
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmAyarlar ayarlar = new frmAyarlar();
            ayarlar.ShowDialog();
        }
        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            frmTeklifListesi frm1 = (frmTeklifListesi)Application.OpenForms["frmTeklifListesi"];
            if (frm1 != null)
            {
                frm1.Focus();
            }
            else
            {
                frmTeklifListesi frm = new frmTeklifListesi();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void accordionControlElement11_Click(object sender, EventArgs e)
        {
            OpenSiparisFormInMdiTab(1);
        }

        private void accordionControlElement9_Click(object sender, EventArgs e)
        {
            OpenSiparisFormInMdiTab(2);
        }

        private void lk_firma_EditValueChanged(object sender, EventArgs e)
        {
            if (lk_firma.EditValue != null)
            {
                string firma = lk_firma.EditValue.ToString();
                if (!string.IsNullOrWhiteSpace(firma))
                {
                    islem.DonemListesiDoldur(lk_donemm, firma);
                }
            }
        }

        private void accordionControlElement5_Click(object sender, EventArgs e)
        {
            OpenIrsaliyeFormInMdiTab(1);
        }

        private void accordionControlElement15_Click(object sender, EventArgs e)
        {
            OpenIrsaliyeFormInMdiTab(8);
        }

        private void OpenSiparisFormInMdiTab(int tip)
        {
            string formKey = $"frmSiparisListesi_{tip}";

            foreach (Form frm in this.MdiChildren)
            {
                if (frm is frmSiparisListesi existingForm && existingForm.tip == tip)
                {
                    existingForm.Focus();
                    return;
                }
            }
            frmSiparisListesi newForm = new frmSiparisListesi();
            newForm.tip = tip;
            newForm.MdiParent = this;
            newForm.Text = $"Sipariş Listesi - Tip {tip}";
            newForm.Show();
        }

        private void OpenIrsaliyeFormInMdiTab(int tip)
        {
            string formKey = $"frmIrsaliyeListesi_{tip}";

            foreach (Form frm in this.MdiChildren)
            {
                if (frm is frmIrsaliyeListesi existingForm && existingForm.tip == tip)
                {
                    existingForm.Focus();
                    return;
                }
            }

            frmIrsaliyeListesi newForm = new frmIrsaliyeListesi();
            newForm.tip = tip;
            newForm.MdiParent = this;
            newForm.Text = $"Irsaliye Listesi - Tip {tip}";
            newForm.Show();
        }

        private void accordionControlElement8_Click(object sender, EventArgs e)
        {
            OpenFaturaFormInMdiTab(1);
        }

        private void accordionControlElement10_Click(object sender, EventArgs e)
        {
            OpenFaturaFormInMdiTab(8);
        }

        private void accordionControlElement146_Click(object sender, EventArgs e)
        {
            frmKullaniciListesi frm1 = (frmKullaniciListesi)Application.OpenForms["frmKullaniciListesi"];
            if (frm1 != null)
            {
                frm1.Focus();
                frm1.kullanicilarilistele();
            }
            else
            {
                frmKullaniciListesi kullaniciListesi = new frmKullaniciListesi();
                kullaniciListesi.MdiParent = this;
                kullaniciListesi.Show();
            }
        }

        private void accordionControlElement155_Click(object sender, EventArgs e)
        {
            frmPazarlamaTipleri frm = new frmPazarlamaTipleri();
            frm.ShowDialog();
        }

        private void accordionControlElement154_Click(object sender, EventArgs e)
        {
            frmGorevler frm1 = (frmGorevler)Application.OpenForms["frmGorevler"];
            if (frm1 != null)
            {
                frm1.Focus();
            }
            else
            {
                frmGorevler gorevler = new frmGorevler();
                gorevler.MdiParent = this;
                gorevler.Show();
            }
        }

        private void accordionControlElement148_Click(object sender, EventArgs e)
        {
            frmRaporDosya frm1 = (frmRaporDosya)Application.OpenForms["frmRaporDosya"];
            if (frm1 != null)
            {
                frm1.Focus();
            }
            else
            {
                frmRaporDosya raporDosyalari = new frmRaporDosya();
                raporDosyalari.MdiParent = this;
                raporDosyalari.Show();
            }
        }

        private void accordionControlElement49_Click(object sender, EventArgs e)
        {
            frmDovizKurGuncelleme DovizGuncelleme = new frmDovizKurGuncelleme();
            DovizGuncelleme.ShowDialog();
            KurlariAnaEkranaGetir();

        }

        private void accordionControlElement152_Click(object sender, EventArgs e)
        {
            frmDovizTurleri dovizTurleri = new frmDovizTurleri();
            dovizTurleri.ShowDialog();
        }

        private void accordionControlElement153_Click(object sender, EventArgs e)
        {
            frmTeklifUyariMesajlari uyariMesajlari = new frmTeklifUyariMesajlari();
            uyariMesajlari.ShowDialog();
        }
        private void accordionControlElement150_Click(object sender, EventArgs e)
        {
            frmTanimliAlanOdemeTipleri tanimliAlanOdemeTipleri = new frmTanimliAlanOdemeTipleri();
            tanimliAlanOdemeTipleri.ShowDialog();
        }
        private void accordionControlElement157_Click(object sender, EventArgs e)
        {
            frmTasiyiciBilgileri frm1 = (frmTasiyiciBilgileri)Application.OpenForms["frmTasiyiciBilgileri"];
            if (frm1 != null)
            {
                frm1.Focus();
            }
            else
            {
                frmTasiyiciBilgileri tasiyici = new frmTasiyiciBilgileri();
                tasiyici.MdiParent = this;
                tasiyici.Show();
            }
        }
        private void accordionControlElement147_Click(object sender, EventArgs e)
        {
            frmSistemParametreleri parametreler = new frmSistemParametreleri();
            parametreler.gelendonem = lk_donem.EditValue.ToString();
            parametreler.gelenfirma = lk_firma.EditValue.ToString();
            parametreler.ShowDialog();
        }

        private void accordionControlElement137_Click(object sender, EventArgs e)
        {
            frmCariKoduAmbarParametreleri carikoduambarParametresi = new frmCariKoduAmbarParametreleri();
            carikoduambarParametresi.ShowDialog();
        }

        private void accordionControlElement145_Click(object sender, EventArgs e)
        {
            frmNakliyeTurleri frm = new frmNakliyeTurleri();
            frm.ShowDialog();
        }

        private void accordionControlElement151_Click(object sender, EventArgs e)
        {
            frmTeslimSureleri frm = new frmTeslimSureleri();
            frm.ShowDialog();
        }

        private void accordionControlElement149_Click(object sender, EventArgs e)
        {
            frmVirmanAciklamalari frm = new frmVirmanAciklamalari();
            frm.ShowDialog();
        }

        private void accordionControlElement46_Click(object sender, EventArgs e)
        {
            frmTeklifRaporuGunluk frm1 = (frmTeklifRaporuGunluk)Application.OpenForms["frmTeklifRaporuGunluk"];
            if (frm1 != null)
            {
                frm1.Focus();
            }
            else
            {
                frmTeklifRaporuGunluk frm2 = new frmTeklifRaporuGunluk();
                frm2.MdiParent = this;
                frm2.Show();
            }
        }

        private void CariKartlar_Click(object sender, EventArgs e)
        {
            frmCariKartListesi frm1 = (frmCariKartListesi)Application.OpenForms["frmCariKartListesi"];
            if (frm1 != null)
            {
                frm1.Focus();
            }
            else
            {
                frmCariKartListesi frm2 = new frmCariKartListesi();
                frm2.MdiParent = this;
                frm2.Show();
            }
        }
        private void MalzemeKartlari_Click(object sender, EventArgs e)
        {
            frmMalzemeYonetimiStokListesi frm1 = (frmMalzemeYonetimiStokListesi)Application.OpenForms["frmMalzemeYonetimiStokListesi"];
            if (frm1 != null)
            {
                frm1.Focus();
            }
            else
            {
                frmMalzemeYonetimiStokListesi frm2 = new frmMalzemeYonetimiStokListesi();
                frm2.MdiParent = this;
                frm2.Show();
            }
        }

        private void accordionControlElement72_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement54_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void accordionControlElement51_Click(object sender, EventArgs e)
        {
            frmKullaniciSifreDegistirme frm = new frmKullaniciSifreDegistirme();
            frm.ShowDialog();
        }

        private void accordionControlElement117_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = XtraMessageBox.Show("Tüm Kayıtlı Sayfa Tasarımlarınız Silinecektir ! Emin Misiniz ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    bool sonuc = islem.KullaniciSayfaTasarimlariTemizle(_Kullanici.ID);
                    if (sonuc)
                    {
                        XtraMessageBox.Show("İşlem Başarılı !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XtraMessageBox.Show("İşlem Başarısız !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("İşlem Başarısız ! Hata : " + ex.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void accordionControlElement53_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
            frmKullaniciMailAyari frm = new frmKullaniciMailAyari();
            frm.ShowDialog();
        }

        private void MenuOnayBekleyenTeklifListesi_Click(object sender, EventArgs e)
        {
            frmOnayBekleyenTeklifListesi frm1 = (frmOnayBekleyenTeklifListesi)Application.OpenForms["frmOnayBekleyenTeklifListesi"];
            if (frm1 != null)
            {
                frm1.ListeyiDoldur();
                frm1.Focus();
            }
            else
            {
                frmOnayBekleyenTeklifListesi frm = new frmOnayBekleyenTeklifListesi();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void accordionControlElement7_Click(object sender, EventArgs e)
        {
            frmKarZararAnaliz frm1 = (frmKarZararAnaliz)Application.OpenForms["frmKarZararAnaliz"];
            if (frm1 != null)
            {
                frm1.Focus();
            }
            else
            {
                frmKarZararAnaliz frm2 = new frmKarZararAnaliz();
                frm2.MdiParent = this;
                frm2.Show();
            }
        }

        private void accordionControlElement12_Click(object sender, EventArgs e)
        {
            frmAlisKarZararAnaliz frm1 = (frmAlisKarZararAnaliz)Application.OpenForms["frmAlisKarZararAnaliz"];
            if (frm1 != null)
            {
                frm1.Focus();
            }
            else
            {
                frmAlisKarZararAnaliz frm2 = new frmAlisKarZararAnaliz();
                frm2.MdiParent = this;
                frm2.Show();
            }
        }

        private void accordionControlElement3_Click_1(object sender, EventArgs e)
        {
            frmCariBakiyeDurum frm1 = (frmCariBakiyeDurum)Application.OpenForms["frmCariBakiyeDurum"];
            if (frm1 != null)
            {
                frm1.Focus();
            }
            else
            {
                frmCariBakiyeDurum frm2 = new frmCariBakiyeDurum();
                frm2.MdiParent = this;
                frm2.Show();
            }
        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {
            frmCariHareketDokum frm1 = (frmCariHareketDokum)Application.OpenForms["frmCariHareketDokum"];
            if (frm1 != null)
            {
                frm1.Focus();
            }
            else
            {
                frmCariHareketDokum frm2 = new frmCariHareketDokum();
                frm2.MdiParent = this;
                frm2.Show();
            }
        }

        private void accordionControlElement13_Click(object sender, EventArgs e)
        {
            frmKasaHareketleri frm1 = (frmKasaHareketleri)Application.OpenForms["frmKasaHareketleri"];
            if (frm1 != null)
            {
                frm1.Focus();
            }
            else
            {
                frmKasaHareketleri frm2 = new frmKasaHareketleri();
                frm2.MdiParent = this;
                frm2.Show();
            }
        }

        private void accordionControlElement14_Click(object sender, EventArgs e)
        {
            frmBankaHareketleri frm1 = (frmBankaHareketleri)Application.OpenForms["frmBankaHareketleri"];
            if (frm1 != null)
            {
                frm1.Focus();
            }
            else
            {
                frmBankaHareketleri frm2 = new frmBankaHareketleri();
                frm2.MdiParent = this;
                frm2.Show();
            }
        }

        private void accordionControlElement17_Click(object sender, EventArgs e)
        {
            frmMusteriKrediKrtHareket frm1 = (frmMusteriKrediKrtHareket)Application.OpenForms["frmMusteriKrediKrtHareket"];
            if (frm1 != null)
            {
                frm1.Focus();
            }
            else
            {
                frmMusteriKrediKrtHareket frm2 = new frmMusteriKrediKrtHareket();
                frm2.MdiParent = this;
                frm2.Show();
            }
        }

        private void accordionControlElement21_Click(object sender, EventArgs e)
        {
            //ALIŞ
            frmFaturalarKDVRaporu itemtip = new frmFaturalarKDVRaporu("");
            bool satisrprvar = false;
            foreach (var item in Application.OpenForms)
            {
                if (item.GetType() == typeof(frmFaturalarKDVRaporu))
                {
                    itemtip = (frmFaturalarKDVRaporu)item;
                    if (itemtip.tip == 2)
                    {
                        satisrprvar = true;
                        break;
                    }

                }
            }
            if (satisrprvar == true)
            {
                itemtip.Focus();
            }
            else
            {
                frmFaturalarKDVRaporu frm = new frmFaturalarKDVRaporu("1,4,5,6,13,26");
                frm.Text = "Alış Faturaları KDV Raporu";
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void accordionControlElement22_Click(object sender, EventArgs e)
        {
            //satış
            frmFaturalarKDVRaporu itemtip = new frmFaturalarKDVRaporu("");
            bool satisrprvar = false;
            foreach (var item in Application.OpenForms)
            {
                if (item.GetType() == typeof(frmFaturalarKDVRaporu))
                {
                    itemtip = (frmFaturalarKDVRaporu)item;
                    if (itemtip.tip == 1)
                    {
                        satisrprvar = true;
                        break;
                    }

                }
            }
            if (satisrprvar == true)
            {
                itemtip.Focus();
            }
            else
            {
                frmFaturalarKDVRaporu frm = new frmFaturalarKDVRaporu("2,3,7,8,9,10,14");
                frm.Text = "Satış Faturaları KDV Raporu";
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void accordionControlElement27_Click(object sender, EventArgs e)
        {
            frmKDVkarsilastirma frm1 = (frmKDVkarsilastirma)Application.OpenForms["frmKDVkarsilastirma"];
            if (frm1 != null)
            {
                frm1.Focus();
            }
            else
            {
                frmKDVkarsilastirma frm2 = new frmKDVkarsilastirma();
                frm2.MdiParent = this;
                frm2.Show();
            }
        }

        private void TeklifModulu_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement28_Click(object sender, EventArgs e)
        {
            frmDuyurular frm1 = (frmDuyurular)Application.OpenForms["frmDuyurular"];
            if (frm1 != null)
            {
                frm1.Focus();
            }
            else
            {
                frmDuyurular frm2 = new frmDuyurular();
                frm2.Show();
            }
        }

        private void accordionControlElement50_Click(object sender, EventArgs e)
        {
            frmHatirlatmaListele frm1 = (frmHatirlatmaListele)Application.OpenForms["frmHatirlatmaListele"];
            if (frm1 != null)
            {
                frm1.Focus();
            }
            else
            {
                frmHatirlatmaListele frm2 = new frmHatirlatmaListele();
                frm2.MdiParent = this;
                frm2.Show();
            }
        }

        private void OpenFaturaFormInMdiTab(int tip)
        {
            string formKey = $"frmFaturaListesi_{tip}";

            foreach (Form frm in this.MdiChildren)
            {
                if (frm is frmFaturaListesi existingForm && existingForm.tip == tip)
                {
                    existingForm.Focus();
                    return;
                }
            }

            frmFaturaListesi newForm = new frmFaturaListesi();
            newForm.tip = tip;
            newForm.MdiParent = this;
            newForm.Text = $"Fatura Listesi - Tip {tip}";
            newForm.Show();
        }
    }
}