using DevExpress.XtraEditors;
using LOGO_XERO.Models;
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
    public partial class frmKullaniciMailAyari : DevExpress.XtraEditors.XtraForm
    {
        public LOGO_XERO_KULLANICILAR _Kullanici;
        frmAnaForm ana;
        public frmKullaniciMailAyari()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            _Kullanici = ana._Kullanici;
        }

        private void frmKullaniciMailAyari_Load(object sender, EventArgs e)
        {
            txt_Mail.Text = _Kullanici.EPOSTA;
            txt_Sifre.Text = _Kullanici.MAILSIFRE;
        }

        private void btn_Guncelle_Click(object sender, EventArgs e)
        {
            using (LogoContext db = new LogoContext())
            {
                try
                {
                    LOGO_XERO_KULLANICILAR kayitliKullanici = db.LOGO_XERO_KULLANICILAR.Where(s => s.ID == _Kullanici.ID).FirstOrDefault();
                    if (kayitliKullanici != null)
                    {
                        kayitliKullanici.EPOSTA = txt_Mail.Text;
                        kayitliKullanici.MAILSIFRE = txt_Sifre.Text;
                        db.Entry(kayitliKullanici);
                        db.SaveChanges();
                        ana._Kullanici.EPOSTA = txt_Mail.Text;
                        ana._Kullanici.MAILSIFRE = txt_Sifre.Text;
                        _Kullanici.EPOSTA = txt_Mail.Text;
                        _Kullanici.MAILSIFRE = txt_Sifre.Text;
                        XtraMessageBox.Show("Güncelleme Başarılı !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Güncelleme Başarısız ! Hata : " + ex.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
        }

        private void ck_sifreGoster_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit ck = sender as CheckEdit;
            if (ck.Checked == true)
            {
                txt_Sifre.Properties.PasswordChar = '\0';
            }
            else
            {
                txt_Sifre.Properties.PasswordChar = '*';
            }
        }
    }
}