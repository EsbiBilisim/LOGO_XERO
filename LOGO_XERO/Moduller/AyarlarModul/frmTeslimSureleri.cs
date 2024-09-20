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
    public partial class frmTeslimSureleri : DevExpress.XtraEditors.XtraForm
    {
        public int id = 0;
        Islemler islem = new Islemler();
        public frmTeslimSureleri()
        {
            InitializeComponent();
        }
        private void frmTeslimSureleri_Load(object sender, EventArgs e)
        {
            TeslimSureleriGetir();
        }
        public void TeslimSureleriGetir()
        {
            gridControlTeslimSuresi.DataSource = islem.TeslimSureleriGetir();
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
                        if (db.LOGO_XERO_TESLIM_SURESI.Where(s => s.TESLIMSURESI == txt_NakliyeTuru.Text).ToList().Count > 0)
                        {
                            XtraMessageBox.Show("Eklemek İstediğiniz Süre Veri Tabanında Var Ekranı Kapatıp Açın !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        LOGO_XERO_TESLIM_SURESI yenisure = new LOGO_XERO_TESLIM_SURESI();
                        yenisure.TESLIMSURESI = txt_NakliyeTuru.Text;
                        db.LOGO_XERO_TESLIM_SURESI.Add(yenisure);
                        db.SaveChanges();
                        XtraMessageBox.Show("Kayıt Başarılı !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (db.LOGO_XERO_TESLIM_SURESI.Where(s => s.TESLIMSURESI == txt_NakliyeTuru.Text && s.ID != id).ToList().Count > 0)
                        {
                            XtraMessageBox.Show("Eklemek İstediğiniz Süre Veri Tabanında Var Ekranı Kapatıp Açın !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        LOGO_XERO_TESLIM_SURESI kayitliSure = db.LOGO_XERO_TESLIM_SURESI.Where(s => s.ID == id).FirstOrDefault();
                        if (kayitliSure != null)
                        {
                            kayitliSure.TESLIMSURESI = txt_NakliyeTuru.Text;
                            db.Entry(kayitliSure);
                            db.SaveChanges();
                            XtraMessageBox.Show("Düzenleme Başarılı !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    id = 0;
                    txt_NakliyeTuru.Text = "";
                    btn_kaydet.Text = "Ekle";
                    TeslimSureleriGetir();
                    txt_NakliyeTuru.Focus();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("İşlem Başarısız ! HATA : " + ex.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            id = 0;
            txt_NakliyeTuru.Text = "";
            txt_NakliyeTuru.Focus();
            btn_kaydet.Text = "Ekle";
        }
      
        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LOGO_XERO_TESLIM_SURESI row = (LOGO_XERO_TESLIM_SURESI)gv_teslimSuresi.GetFocusedRow();
            if (row != null)
            {
                id = row.ID;
                txt_NakliyeTuru.Text = row.TESLIMSURESI;
                btn_kaydet.Text = "Güncelle";
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LOGO_XERO_TESLIM_SURESI row = (LOGO_XERO_TESLIM_SURESI)gv_teslimSuresi.GetFocusedRow();
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
                            LOGO_XERO_TESLIM_SURESI kay = db.LOGO_XERO_TESLIM_SURESI.Where(s => s.ID == row.ID).FirstOrDefault();
                            if (kay != null)
                            {
                                db.LOGO_XERO_TESLIM_SURESI.Remove(kay);
                                db.SaveChanges();
                                XtraMessageBox.Show("Silme Başarılı !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        TeslimSureleriGetir();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("İşlem Başarısız ! HATA : " + ex.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}