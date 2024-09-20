using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
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
    public partial class frmNakliyeTurleri : DevExpress.XtraEditors.XtraForm
    {
        public int id = 0;
        Islemler islem = new Islemler();
        public frmNakliyeTurleri()
        {
            InitializeComponent();
        }
        private void frmNakliyeTurleri_Load(object sender, EventArgs e)
        {
            TurleriGetir();
        }
        public void TurleriGetir()
        {
            gridControlNakliyeTuru.DataSource = islem.NakliyeTurleriGetir();
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_NakliyeTuru.Text))
            {
                XtraMessageBox.Show("Nakliye Türü Girmeden Kayıt Ekleyemezsiniz !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_NakliyeTuru.Focus();
                return;

            }
            try
            {
                using (LogoContext db = new LogoContext())
                {
                    if (id == 0)
                    {
                        if (db.LOGO_XERO_NAKLIYE_TURU.Where(s => s.NAKLIYETURU == txt_NakliyeTuru.Text).ToList().Count > 0)
                        {
                            XtraMessageBox.Show("Eklemek İstediğiniz Tür Veri Tabanında Var Ekranı Kapatıp Açın !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        LOGO_XERO_NAKLIYE_TURU yeniNakliyeTuru = new LOGO_XERO_NAKLIYE_TURU();
                        yeniNakliyeTuru.NAKLIYETURU = txt_NakliyeTuru.Text;
                        db.LOGO_XERO_NAKLIYE_TURU.Add(yeniNakliyeTuru);
                        db.SaveChanges();
                        XtraMessageBox.Show("Kayıt Başarılı !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (db.LOGO_XERO_NAKLIYE_TURU.Where(s => s.NAKLIYETURU == txt_NakliyeTuru.Text && s.ID != id).ToList().Count > 0)
                        {
                            XtraMessageBox.Show("Eklemek İstediğiniz Tür Veri Tabanında Var Ekranı Kapatıp Açın !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        LOGO_XERO_NAKLIYE_TURU kayitliNakliyeTuru = db.LOGO_XERO_NAKLIYE_TURU.Where(s => s.ID == id).FirstOrDefault();
                        if (kayitliNakliyeTuru != null)
                        {
                            kayitliNakliyeTuru.NAKLIYETURU = txt_NakliyeTuru.Text;
                            db.Entry(kayitliNakliyeTuru);
                            db.SaveChanges();
                            XtraMessageBox.Show("Düzenleme Başarılı !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    id = 0;
                    txt_NakliyeTuru.Text = "";
                    btn_kaydet.Text = "Ekle";
                    TurleriGetir();
                    txt_NakliyeTuru.Focus();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("İşlem Başarısız ! HATA : " + ex.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LOGO_XERO_NAKLIYE_TURU row = (LOGO_XERO_NAKLIYE_TURU)gv_nakliyeTuru.GetFocusedRow();
                if (row != null)
                {
                    DialogResult dr = XtraMessageBox.Show("Seçili Kayıt Silinecektir ! Onaylıyor Musunuz ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        using (LogoContext db = new LogoContext())
                        {
                            LOGO_XERO_NAKLIYE_TURU kay = db.LOGO_XERO_NAKLIYE_TURU.Where(s => s.ID == row.ID).FirstOrDefault();
                            if (kay != null)
                            {
                                db.LOGO_XERO_NAKLIYE_TURU.Remove(kay);
                                db.SaveChanges();
                                XtraMessageBox.Show("Silme Başarılı !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        TurleriGetir();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("İşlem Başarısız ! HATA : " + ex.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LOGO_XERO_NAKLIYE_TURU row = (LOGO_XERO_NAKLIYE_TURU)gv_nakliyeTuru.GetFocusedRow();
            if (row != null)
            {
                id = row.ID;
                txt_NakliyeTuru.Text = row.NAKLIYETURU;
                btn_kaydet.Text = "Güncelle";
            }
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            id = 0;
            txt_NakliyeTuru.Text = "";
            txt_NakliyeTuru.Focus();
            btn_kaydet.Text = "Ekle";
        }
    }
}