using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using LOGO_XERO.Models.LOGO_XERO_M;
using LOGO_XERO.Models.LOGO_M;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LOGO_XERO.Models;
using System.Data.Entity;
using LOGO_XERO.Moduller.Giris_AnaForm_Ayarlar;
using LOGO_XERO.Moduller.Personeller;
using System.Data.SqlClient;
using System.IO;

namespace LOGO_XERO
{
    public partial class frmKullaniciGiris : DevExpress.XtraEditors.XtraForm
    {
        IlkTabloIslemler islem = new IlkTabloIslemler();
        public List<LOGO_XERO_LISANSLAR> olanLisansListesi = new List<LOGO_XERO_LISANSLAR>();
        public frmKullaniciGiris()
        {
            InitializeComponent();

            PanelTum.Location = new Point(ClientSize.Width / 2 - PanelTum.Size.Width / 2, ClientSize.Height / 2 - PanelTum.Size.Height / 2);
            PanelTum.Anchor = AnchorStyles.None;
        }
        private void btn_giris_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lk_kullanici.Text))
            {
                XtraMessageBox.Show("KULLANICI SEÇİMİ YAPIN", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (lk_kullanici.EditValue == null)
            {
                XtraMessageBox.Show("KULLANICI SEÇİMİ YAPIN", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (LK_sirket.EditValue == null)
            {
                XtraMessageBox.Show("FİRMA SEÇİMİ YAPIN", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            int kullaniciId = Convert.ToInt32(lk_kullanici.EditValue);
            LOGO_XERO_KULLANICILAR kull = islem.DataSetliKullaniciBilgisiGetir(kullaniciId);
            if (kull != null)
            {
                if (txt_sfre.Text != kull.SIFRE)
                {
                    XtraMessageBox.Show("ŞİFRE YANLIŞTIR !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_sfre.Focus();
                    return;
                }
            }
            else
            {
                XtraMessageBox.Show("ŞİFRE YANLIŞTIR !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_sfre.Focus(); ;
                return;
            }


            RegistryKey rsk = Registry.CurrentUser.CreateSubKey("Software\\EsbiSetting\\LOGO_XERO");
            rsk.SetValue("KULLANICIID", lk_kullanici.EditValue.ToString(), RegistryValueKind.String);
            rsk.SetValue("FIRMANO", LK_sirket.EditValue.ToString(), RegistryValueKind.String);
            rsk.SetValue("DONEMNO", Lk_donem.EditValue.ToString(), RegistryValueKind.String);



            frmAnaForm frm = new frmAnaForm(kull);
            foreach (var item in olanLisansListesi)
            {
                if (item.MODUL == 1)
                {
                    frm.TeklifModulu.Visible = true;
                    frm.FinansModulu.Visible = true;
                    frm.MalzemeModulu.Visible = true;
                    frm.MalzemeAnaKayitlar.Visible = true;
                    frm.MalzemeKartlari.Visible = true;
                    frm.FinansAnakayitlar.Visible = true;
                    frm.CariKartlar.Visible = true;
                }
                if (item.MODUL == 3)
                {
                    frm.SatinalmaModulu.Visible = true;
                    frm.CariKoduAmbarParametreFormu.Visible = true;
                    frm.TeklifModulu.Visible = true;
                    frm.SatisModulu.Visible = true;
                    frm.MalzemeModulu.Visible = true;
                    frm.FinansModulu.Visible = true;
                    frm.TalepModulu.Visible = true;
                    frm.gooz_Modulu.Visible = true;
                }
                if (item.MODUL == 2)
                {
                    frm.gooz_Modulu.Visible = true;
                }
                if (item.MODUL == 4)
                {
                    frm.SatinalmaModulu.Visible = true;
                    frm.TeklifModulu.Visible = true;
                    frm.SatisModulu.Visible = true;
                    frm.MalzemeModulu.Visible = true;
                    frm.FinansModulu.Visible = true;
                    frm.TalepModulu.Visible = true;
                    frm.gooz_Modulu.Visible = true;
                    frm.demomu = 1;
                }
            }
            frm.firma = LK_sirket.EditValue.ToString();
            frm.donem = Lk_donem.EditValue.ToString();
            IlkTabloIslemler tablo = new IlkTabloIslemler();
            tablo.logoxerokarzararonaytablosuolustur(LK_sirket.EditValue.ToString(),Lk_donem.EditValue.ToString());
            tablo.XERO_TeklifSiparisSevkTabloOlustur(LK_sirket.EditValue.ToString());
            tablo.KDVMATRAHOLUSTUR(LK_sirket.EditValue.ToString(),Lk_donem.EditValue.ToString());
            tablo.XERO_TeklifBaslikTabloOlustur(LK_sirket.EditValue.ToString());
            tablo.XERO_TeklifSatirTabloOlustur(LK_sirket.EditValue.ToString());
            tablo.XERO_OnayliTeklifSatirTabloOlustur(LK_sirket.EditValue.ToString());
            tablo.XERO_TeklifBaslikFaturaTipiKdvMuafiyetBilgileriEkle(LK_sirket.EditValue.ToString());            
            tablo.XERO_KullaniciLockTablosuOlustur(LK_sirket.EditValue.ToString(), Lk_donem.EditValue.ToString());
            tablo.CariListesiViewOlustur(LK_sirket.EditValue.ToString(), Lk_donem.EditValue.ToString());
            tablo.CariListesiViewGuncelle(LK_sirket.EditValue.ToString(), Lk_donem.EditValue.ToString());
            tablo.StokListesiViewOlustur(LK_sirket.EditValue.ToString(), Lk_donem.EditValue.ToString());
            tablo.StokListesiViewGuncelle(LK_sirket.EditValue.ToString(), Lk_donem.EditValue.ToString());
            tablo.HizmetListesiViewOlustur(LK_sirket.EditValue.ToString(), Lk_donem.EditValue.ToString());
            tablo.HizmetListesiViewGuncelle(LK_sirket.EditValue.ToString(), Lk_donem.EditValue.ToString());
            tablo.KDVTUTAROLUSTUR(LK_sirket.EditValue.ToString(),Lk_donem.EditValue.ToString());
            tablo.DuyurularTablosuOlustur(LK_sirket.EditValue.ToString(), Lk_donem.EditValue.ToString());
            tablo.ESBI_CARIVADE_FonksiyonuOlustur(LK_sirket.EditValue.ToString(), Lk_donem.EditValue.ToString());
            tablo.HatirlatmalarTablosuOlustur(LK_sirket.EditValue.ToString(), Lk_donem.EditValue.ToString());
            tablo.TeklifGorusmelerTablosuOlustur(LK_sirket.EditValue.ToString(), Lk_donem.EditValue.ToString());
            tablo.RaporDosyalariTablosuOlustur(LK_sirket.EditValue.ToString(), Lk_donem.EditValue.ToString());
            tablo.RaporTasarimlariKaydet();

            frm.Show();
            this.Hide();
        }


        private void frmKullaniciGiris_Load(object sender, EventArgs e)
        {

            ListeleriGetir();
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\EsbiSetting\\LOGO_XERO");

            if (rk != null)
            {
                string kullanici = rk.GetValue("KULLANICIID").ToString();
                if (!string.IsNullOrWhiteSpace(kullanici))
                {
                    int kullaniciId = Convert.ToInt32(kullanici);
                    LOGO_XERO_KULLANICILAR kull = islem.DataSetliKullaniciBilgisiGetir(kullaniciId);
                    if (kull != null)
                    {
                        lk_kullanici.EditValue = kullaniciId;
                        LK_sirket.EditValue = kull.TANIMLIFIRMA;
                        Lk_donem.EditValue = kull.TANIMLIDONEM;
                        txt_sfre.Focus();
                    }
                }
                List<LOGO_XERO_KULLANICILAR> kullanicilar = islem.DataSetliTumKullaniciLİstesiGetir();
                if (kullanicilar.Count == 0)
                {
                    XtraMessageBox.Show("Kayıtlı Kullanıcı Bulunmamaktadır ! Sistem Parametrelerinizi Giriniz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    frmSistemParametreleri prm = new frmSistemParametreleri();
                    prm.loginden = 1;
                    prm.ShowDialog();
                }
            }


        }
        List<LOGO_XERO_KULLANICILAR> kullanicilar = new List<LOGO_XERO_KULLANICILAR>();
        List<L_CAPIFIRM> firm = new List<L_CAPIFIRM>();
        List<L_CAPIPERIOD> donem = new List<L_CAPIPERIOD>();
        public void ListeleriGetir()
        {
            kullanicilar = islem.DataSetliTumKullaniciLİstesiGetir();
            lk_kullanici.Properties.DisplayMember = "KULLANICIADI";
            lk_kullanici.Properties.ValueMember = "ID";
            lk_kullanici.Properties.DataSource = kullanicilar;

            firm = islem.DataSetlifirmalistesi();
            LK_sirket.Properties.DisplayMember = "NUM";
            LK_sirket.Properties.ValueMember = "NUM2";
            LK_sirket.Properties.DataSource = firm;
        }

        private void LK_sirket_EditValueChanged(object sender, EventArgs e)
        {
            if (LK_sirket.EditValue != null)
            {
                string firma = LK_sirket.EditValue.ToString();
                if (!string.IsNullOrWhiteSpace(firma))
                {
                    donem = islem.DataSetlidonemlistesi(firma);
                    Lk_donem.Properties.DisplayMember = "NUM2";
                    Lk_donem.Properties.ValueMember = "NUM";
                    Lk_donem.Properties.DataSource = donem;

                    LOGO_XERO_PARAMETRELER parametre = islem.ParametrelerGetir(LK_sirket.EditValue.ToString());
                    if (parametre.LOGINLOGO != null)
                    {
                        Logo.Image = null;
                        byte[] logoResim = parametre.LOGINLOGO;
                        MemoryStream ms = new MemoryStream(logoResim);
                        Logo.Image = Image.FromStream(ms);
                    }
                    else
                    {
                        Logo.Image = null;
                    }
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void frmKullaniciGiris_Resize(object sender, EventArgs e)
        {
            PanelTum.Location = new Point(ClientSize.Width / 2 - PanelTum.Size.Width / 2, ClientSize.Height / 2 - PanelTum.Size.Height / 2);
            PanelTum.Anchor = AnchorStyles.None;

        }

        private void txt_sfre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btn_giris_Click(sender, e);
            }
        }

        private void lk_kullanici_EditValueChanged(object sender, EventArgs e)
        {
            if (lk_kullanici.EditValue != null)
            {
                if (!string.IsNullOrWhiteSpace(lk_kullanici.EditValue.ToString()))
                {
                    int kullaniciId = Convert.ToInt32(lk_kullanici.EditValue);
                    LOGO_XERO_KULLANICILAR kull = islem.DataSetliKullaniciBilgisiGetir(kullaniciId);
                    LK_sirket.EditValue = kull.TANIMLIFIRMA;
                    Lk_donem.EditValue = kull.TANIMLIDONEM;
                }
            }

        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            frmSistemParametreleri frm = new frmSistemParametreleri();
            frm.loginden = 1;
            if (LK_sirket.EditValue != null && Lk_donem.EditValue != null)
            {
                frm.gelenfirma = LK_sirket.EditValue.ToString();
                frm.gelendonem = Lk_donem.EditValue.ToString();
            }
            frm.ShowDialog();
        }
    }
}