using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using LOGO_XERO.Models.LOGO_XERO_M;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGO_XERO.Moduller.Giris_AnaForm_Ayarlar
{
    public partial class frmPazarlamaTipleri : DevExpress.XtraEditors.XtraForm
    {
        public int id = 0;
        Islemler islem = new Islemler();
        public frmPazarlamaTipleri()
        {
            InitializeComponent();
        }
        private void frmPazarlamaTipleri_Load(object sender, EventArgs e)
        {
            TipleriGetir();
        }
        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LOGO_XERO_PAZARLAMA_TIPLERI row = (LOGO_XERO_PAZARLAMA_TIPLERI)gv_pazarlamatipi.GetFocusedRow();
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
                            LOGO_XERO_PAZARLAMA_TIPLERI kay = db.LOGO_XERO_PAZARLAMA_TIPLERI.Where(s => s.ID == row.ID).FirstOrDefault();
                            if (kay != null)
                            {
                                db.LOGO_XERO_PAZARLAMA_TIPLERI.Remove(kay);
                                db.SaveChanges();
                                XtraMessageBox.Show("Silme Başarılı !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        TipleriGetir();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("İşlem Başarısız ! HATA : " + ex.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void TipleriGetir()
        {
            gridControlPazarlamaTipi.DataSource = islem.PazarlamaTipleriGetir();
        }
        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LOGO_XERO_PAZARLAMA_TIPLERI row = (LOGO_XERO_PAZARLAMA_TIPLERI)gv_pazarlamatipi.GetFocusedRow();
            if (row != null)
            {
                id = row.ID;
                txt_PazarlamaTipi.Text = row.PAZARLAMATIPI;
                btn_kaydet.Text = "Güncelle";
            }
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            id = 0;
            txt_PazarlamaTipi.Text = "";
            txt_PazarlamaTipi.Focus();
            btn_kaydet.Text = "Ekle";
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_PazarlamaTipi.Text))
            {
                XtraMessageBox.Show("Pazarlama Tipi Girmeden Kayıt Ekleyemezsiniz !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_PazarlamaTipi.Focus();
                return;
            }
            try
            {
                using (LogoContext db = new LogoContext())
                {
                    if (id == 0)
                    {
                        if (db.LOGO_XERO_PAZARLAMA_TIPLERI.Where(s => s.PAZARLAMATIPI == txt_PazarlamaTipi.Text).ToList().Count > 0)
                        {
                            XtraMessageBox.Show("Eklemek İstediğiniz Tip Veri Tabanında Var Ekranı Kapatıp Açın !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        LOGO_XERO_PAZARLAMA_TIPLERI yeniPazarlamaTipi = new LOGO_XERO_PAZARLAMA_TIPLERI();
                        yeniPazarlamaTipi.PAZARLAMATIPI = txt_PazarlamaTipi.Text;
                        db.LOGO_XERO_PAZARLAMA_TIPLERI.Add(yeniPazarlamaTipi);
                        db.SaveChanges();
                        XtraMessageBox.Show("Kayıt Başarılı !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (db.LOGO_XERO_PAZARLAMA_TIPLERI.Where(s => s.PAZARLAMATIPI == txt_PazarlamaTipi.Text && s.ID != id).ToList().Count > 0)
                        {
                            XtraMessageBox.Show("Eklemek İstediğiniz Tip Veri Tabanında Var Ekranı Kapatıp Açın !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        LOGO_XERO_PAZARLAMA_TIPLERI kayitliPazarlamaTipi = db.LOGO_XERO_PAZARLAMA_TIPLERI.Where(s => s.ID == id).FirstOrDefault();
                        if (kayitliPazarlamaTipi != null)
                        {
                            kayitliPazarlamaTipi.PAZARLAMATIPI = txt_PazarlamaTipi.Text;
                            db.Entry(kayitliPazarlamaTipi);
                            db.SaveChanges();
                            XtraMessageBox.Show("Düzenleme Başarılı !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    id = 0;
                    txt_PazarlamaTipi.Text = "";
                    btn_kaydet.Text = "Ekle";
                    TipleriGetir();
                    txt_PazarlamaTipi.Focus();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("İşlem Başarısız ! HATA : " + ex.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}