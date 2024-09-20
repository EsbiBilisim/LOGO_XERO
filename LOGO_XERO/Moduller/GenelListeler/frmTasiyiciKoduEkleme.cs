using DevExpress.XtraEditors;
using LOGO_XERO.Models;
using LOGO_XERO.Models.LOGO_M;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGO_XERO.Moduller.GenelListeler
{
    public partial class frmTasiyiciKoduEkleme : DevExpress.XtraEditors.XtraForm
    {
        public int id = 0;
        frmAnaForm ana;
        public L_SHPAGENT guncellenecekKayit;
        public frmTasiyiciBilgileri frmTasiyiciBilgileri;
        public frmTasiyiciKodlari frmTasiyiciKodlari;
        public frmTasiyiciKoduEkleme(frmTasiyiciBilgileri _frmTasiyiciBilgileri)
        {
            InitializeComponent();
            frmTasiyiciBilgileri = _frmTasiyiciBilgileri;
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
        }
        public frmTasiyiciKoduEkleme(frmTasiyiciKodlari _frmTasiyiciKodlari)
        {
            InitializeComponent();
            frmTasiyiciKodlari = _frmTasiyiciKodlari;
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
        }
        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtKod.Text.Length == 0 || txtKod.Text == "")
            {
                XtraMessageBox.Show("Kod Alanı Zorunludur!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtKod.Focus();
                return;
            }
            if (txtAciklama.Text.Length == 0 || txtAciklama.Text == "")
            {
                XtraMessageBox.Show("Açıklama Alanı Zorunludur!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAciklama.Focus();
                return;
            }
            if (txtUlkeKod.Text.Length == 0 || txtUlkeKod.Text == "")
            {
                XtraMessageBox.Show("Ülke Kodu Alanı Zorunludur!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUlkeKod.Focus();
                return;
            }
            if (txtUlke.Text.Length == 0 || txtUlke.Text == "")
            {
                XtraMessageBox.Show("Ülke Adı Alanı Zorunludur!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUlke.Focus();
                return;
            }
            if (cm_kurumtipi.SelectedIndex == 0)
            {
                if (txtUnvan.Text.Length == 0 || txtUnvan.Text == "")
                {
                    XtraMessageBox.Show("Taşıyıcı Cari Unvan Zorunludur!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUnvan.Focus();
                    return;
                }
                if (txt_vergino.Text.Length == 0 || txt_vergino.Text == "")
                {
                    XtraMessageBox.Show("Vergi Kimlik No Alanı Zorunludur!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_vergino.Focus();
                    return;
                }
                if (txt_vergino.Text.Length != 10)
                {
                    XtraMessageBox.Show("Vergi Kimlik No 10 Haneli Olmalıdır!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_vergino.Focus();
                    return;
                }
            }
            if (cm_kurumtipi.SelectedIndex == 1)
            {
                if (txt_adi.Text.Length == 0 || txt_adi.Text == "")
                {
                    XtraMessageBox.Show("Ad Zorunludur!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_adi.Focus();
                    return;
                }
                if (txt_soyadi.Text.Length == 0 || txt_soyadi.Text == "")
                {
                    XtraMessageBox.Show("Soyad Zorunludur!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_soyadi.Focus();
                    return;
                }
                if (txt_tc.Text.Length == 0 || txt_tc.Text == "")
                {
                    XtraMessageBox.Show("Tc Kimlik No Alanı Zorunludur!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txt_tc.Focus();
                    return;
                }
                if (txt_tc.Text.Length != 11)
                {
                    XtraMessageBox.Show("Tc Kimlik No 11 Haneli Olmalıdır!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_tc.Focus();
                    return;
                }
            }

            try
            {
                using (LogoContext db = new LogoContext())
                {
                    if (id == 0)
                    {

                        var varmi = db.L_SHPAGENT.Where(s => s.CODE == txtKod.Text).FirstOrDefault();
                        if (varmi != null)
                        {
                            XtraMessageBox.Show("Bu Koda Ait Taşıyıcı Kodu Daha Önceden Tanımlanmış ! Tekrar Aynı Kodla Tanımlama Yapamazsınız !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtKod.Focus();
                            return;
                        }

                        L_SHPAGENT yenitasiyici = new L_SHPAGENT();
                        yenitasiyici.ADDR1 = txtAdres.Text;
                        yenitasiyici.ADDR2 = txtAdres2.Text;
                        yenitasiyici.CITY = txtIl.Text;
                        yenitasiyici.CITYCODE = txtIlKodu.Text;
                        yenitasiyici.CLANGUAGE = 0;
                        yenitasiyici.CODE = txtKod.Text;
                        yenitasiyici.COUNTRY = txtUlke.Text;
                        yenitasiyici.COUNTRYCODE = txtUlkeKod.Text;
                        yenitasiyici.DEFINITION_ = txtUnvan.Text;
                        yenitasiyici.DISTRICT = txtmahalle.Text;
                        yenitasiyici.DISTRICTCODE = txtmahallekodu.Text;
                        yenitasiyici.EMAIL = "";
                        yenitasiyici.FAXNR = "";
                        yenitasiyici.FIRMTYPE = Convert.ToInt16(cm_kurumtipi.SelectedIndex);
                        yenitasiyici.INCHARGE = "";
                        yenitasiyici.NAME = txt_adi.Text;
                        yenitasiyici.POSTCODE = txtPostaKodu.Text;
                        yenitasiyici.SURNAME = txt_soyadi.Text;
                        yenitasiyici.TAXNR = txt_vergino.Text;
                        yenitasiyici.TCNO = txt_tc.Text;
                        yenitasiyici.TELNRS1 = txtTelefon.Text;
                        yenitasiyici.TELNRS2 = "";
                        yenitasiyici.TITLE = txtAciklama.Text;
                        yenitasiyici.TOWN = txtIlce.Text;
                        yenitasiyici.TOWNCODE = txtIlceKodu.Text;
                        yenitasiyici.TRACKINGFORM = "";
                        yenitasiyici.WEBADDR = "";

                        db.L_SHPAGENT.Add(yenitasiyici);
                        db.SaveChanges();
                    }
                    else
                    {
                        var data = db.L_SHPAGENT.Where(s => s.LOGICALREF == id).FirstOrDefault();
                        data.ADDR1 = txtAdres.Text;
                        data.ADDR2 = txtAdres2.Text;
                        data.CITY = txtIl.Text;
                        data.CITYCODE = txtIlKodu.Text;
                        data.CLANGUAGE = 0;
                        data.CODE = txtKod.Text;
                        data.COUNTRY = txtUlke.Text;
                        data.COUNTRYCODE = txtUlkeKod.Text;
                        data.DEFINITION_ = txtUnvan.Text;
                        data.DISTRICT = txtmahalle.Text;
                        data.DISTRICTCODE = txtmahallekodu.Text;
                        data.EMAIL = "";
                        data.FAXNR = "";
                        data.FIRMTYPE = Convert.ToInt16(cm_kurumtipi.SelectedIndex);
                        data.INCHARGE = "";
                        data.NAME = txt_adi.Text;
                        data.POSTCODE = txtPostaKodu.Text;
                        data.SURNAME = txt_soyadi.Text;
                        data.TAXNR = txt_vergino.Text;
                        data.TCNO = txt_tc.Text;
                        data.TELNRS1 = txtTelefon.Text;
                        data.TELNRS2 = "";
                        data.TITLE = txtAciklama.Text;
                        data.TOWN = txtIlce.Text;
                        data.TOWNCODE = txtIlceKodu.Text;
                        data.TRACKINGFORM = "";
                        data.WEBADDR = "";

                        db.Entry(data);
                        db.SaveChanges();

                    }


                    XtraMessageBox.Show("İŞLEM BAŞARILI !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (frmTasiyiciBilgileri != null)
                    {
                        frmTasiyiciBilgileri.Listele();
                    }  
                    if (frmTasiyiciKodlari != null)
                    {
                        frmTasiyiciKodlari.ListeGetir();
                    }
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Hata Oluştu ! Tekrar Deneyiniz !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void cm_kurumtipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cm_kurumtipi.SelectedIndex == 0)
            {
                txt_tc.Enabled = false;
                txt_adi.Enabled = false;
                txt_soyadi.Enabled = false;
                txt_vergino.Enabled = true;
            }
            else
            {
                txt_tc.Enabled = true;
                txt_adi.Enabled = true;
                txt_soyadi.Enabled = true;
                txt_vergino.Enabled = false;
            }
        }

        private void frmTasiyiciKoduEkleme_Load(object sender, EventArgs e)
        {
            cm_kurumtipi.SelectedIndex = 0;
            if (guncellenecekKayit != null)
            {
                id = guncellenecekKayit.LOGICALREF;
                txtAdres.Text = guncellenecekKayit.ADDR1;
                txtAdres2.Text = guncellenecekKayit.ADDR2;
                txtIl.Text = guncellenecekKayit.CITY;
                txtIlKodu.Text = guncellenecekKayit.CITYCODE.ToString();
                txtKod.Text = guncellenecekKayit.CODE;
                txtUlke.Text = guncellenecekKayit.COUNTRY;
                txtUlkeKod.Text = guncellenecekKayit.COUNTRYCODE.ToString();
                txtUnvan.Text = guncellenecekKayit.DEFINITION_;
                txtmahalle.Text = guncellenecekKayit.DISTRICT;
                txtmahallekodu.Text = guncellenecekKayit.DISTRICTCODE.ToString();
                cm_kurumtipi.SelectedIndex = (int)guncellenecekKayit.FIRMTYPE;
                txt_adi.Text = guncellenecekKayit.NAME;
                txtPostaKodu.Text = guncellenecekKayit.POSTCODE.ToString();
                txt_soyadi.Text = guncellenecekKayit.SURNAME;
                //if (!string.IsNullOrWhiteSpace(guncellenecekKayit.TAXNR))
                //{
                txt_vergino.EditValue = guncellenecekKayit.TAXNR;
                //}
                //if (!string.IsNullOrWhiteSpace(guncellenecekKayit.TCNO))
                //{
                txt_tc.EditValue = guncellenecekKayit.TCNO;
                //}

                txtTelefon.Text = guncellenecekKayit.TELNRS1.ToString();
                txtAciklama.Text = guncellenecekKayit.TITLE.ToString();
                txtIlce.Text = guncellenecekKayit.TOWN;
                txtIlceKodu.Text = guncellenecekKayit.TOWNCODE.ToString();
            }
        }
    }
}