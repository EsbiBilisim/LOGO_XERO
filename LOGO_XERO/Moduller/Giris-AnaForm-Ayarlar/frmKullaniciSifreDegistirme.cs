using DevExpress.XtraEditors;
using LOGO_XERO.Models;
using LOGO_XERO.Models.LOGO_M;
using LOGO_XERO.Models.LOGO_XERO_M;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGO_XERO.Moduller.Giris_AnaForm_Ayarlar
{
    public partial class frmKullaniciSifreDegistirme : DevExpress.XtraEditors.XtraForm
    {
        public LOGO_XERO_KULLANICILAR _Kullanici;
        public L_CAPIFIRM firmaBilgisi;
        frmAnaForm ana;
        public frmKullaniciSifreDegistirme()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            _Kullanici = ana._Kullanici;
        }

        private void btn_Guncelle_Click(object sender, EventArgs e)
        {
            if (txt_EskiSifre.Text != _Kullanici.SIFRE)
            {
                XtraMessageBox.Show("Kayıtlı Şifreniz Eski Şifrenizle Uyuşmuyor !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_EskiSifre.Focus();
                return;
            }
            else
            {
                if (txt_YeniSifre.Text != txt_YeniSifreTekrar.Text)
                {
                    XtraMessageBox.Show("Yeni Şifreler Uyuşmuyor !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_YeniSifre.Focus();
                    return;
                }
                else
                {
                    using (LogoContext db = new LogoContext())
                    {
                        try
                        {
                            LOGO_XERO_KULLANICILAR kayitliKullanici = db.LOGO_XERO_KULLANICILAR.Where(s => s.ID == _Kullanici.ID).FirstOrDefault();
                            if (kayitliKullanici != null)
                            {
                                kayitliKullanici.SIFRE = txt_YeniSifre.Text;
                                db.Entry(kayitliKullanici);
                                db.SaveChanges();
                                ana._Kullanici.SIFRE = txt_YeniSifre.Text;
                                _Kullanici.SIFRE = txt_YeniSifre.Text;
                                XtraMessageBox.Show("Güncelleme Başarılı !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("Güncelleme Başarısız ! Hata : "+ex.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                }
            }
        }

        private void ck_sifreGoster_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit ck= sender as CheckEdit;
            if (ck.Checked==true)
            {
                txt_EskiSifre.Properties.PasswordChar = '\0';
                txt_YeniSifre.Properties.PasswordChar = '\0';
                txt_YeniSifreTekrar.Properties.PasswordChar = '\0';
            }
            else
            {
                txt_EskiSifre.Properties.PasswordChar = '*';
                txt_YeniSifre.Properties.PasswordChar = '*';
                txt_YeniSifreTekrar.Properties.PasswordChar = '*';
            }
        }

        private void frmKullaniciSifreDegistirme_Load(object sender, EventArgs e)
        {

        }
    }
}