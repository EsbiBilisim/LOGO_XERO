using DevExpress.Utils.Gesture;
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

namespace LOGO_XERO.Moduller.AyarlarModul
{
    public partial class frmVirmanAciklamalari : DevExpress.XtraEditors.XtraForm
    {
        public int id = 0;
        Islemler islem = new Islemler();
        public frmVirmanAciklamalari()
        {
            InitializeComponent();
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            Kaydet();
        }
        public void Kaydet() 
        {
            if (string.IsNullOrWhiteSpace(txt_virmanaciklama.Text))
            {
                XtraMessageBox.Show("Virman Açıklaması Girmeden Kayıt Ekleyemezsiniz !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_virmanaciklama.Focus();
                return;

            }
            try
            {
                using (LogoContext db = new LogoContext())
                {
                    if (id == 0)
                    {
                        if (db.LOGO_XERO_VIRMAN_ACIKLAMA.Where(s => s.VIRMANACIKLAMA == txt_virmanaciklama.Text).ToList().Count > 0)
                        {
                            XtraMessageBox.Show("Eklemek İstediğiniz Açıklama Veri Tabanında Var Ekranı Kapatıp Açın !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        LOGO_XERO_VIRMAN_ACIKLAMA yenivirmanaciklama = new LOGO_XERO_VIRMAN_ACIKLAMA();
                        yenivirmanaciklama.VIRMANACIKLAMA = txt_virmanaciklama.Text;
                        db.LOGO_XERO_VIRMAN_ACIKLAMA.Add(yenivirmanaciklama);
                        db.SaveChanges();
                        XtraMessageBox.Show("Kayıt Başarılı !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (db.LOGO_XERO_VIRMAN_ACIKLAMA.Where(s => s.VIRMANACIKLAMA == txt_virmanaciklama.Text && s.ID != id).ToList().Count > 0)
                        {
                            XtraMessageBox.Show("Eklemek İstediğiniz Açıklama Veri Tabanında Var Ekranı Kapatıp Açın !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        LOGO_XERO_VIRMAN_ACIKLAMA kayitlivirman = db.LOGO_XERO_VIRMAN_ACIKLAMA.Where(s => s.ID == id).FirstOrDefault();
                        if (kayitlivirman != null)
                        {
                            kayitlivirman.VIRMANACIKLAMA = txt_virmanaciklama.Text;
                            db.Entry(kayitlivirman);
                            db.SaveChanges();
                            XtraMessageBox.Show("Düzenleme Başarılı !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    id = 0;
                    txt_virmanaciklama.Text = "";
                    btn_kaydet.Text = "Ekle";
                    TurleriGetir();
                    txt_virmanaciklama.Focus();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("İşlem Başarısız ! HATA : " + ex.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
        public void TurleriGetir() 
        {
            gridControlVirmanAciklama.DataSource = islem.VirmanAciklamaGetir();
            gridControlVirmanAciklama.RefreshDataSource();
            gridControlVirmanAciklama.Refresh();
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LOGO_XERO_VIRMAN_ACIKLAMA row = (LOGO_XERO_VIRMAN_ACIKLAMA)gv_virmanaciklama.GetFocusedRow();
            if (row != null)
            {
                id = row.ID;
                txt_virmanaciklama.Text = row.VIRMANACIKLAMA;
                btn_kaydet.Text = "Güncelle";
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LOGO_XERO_VIRMAN_ACIKLAMA row = (LOGO_XERO_VIRMAN_ACIKLAMA)gv_virmanaciklama.GetFocusedRow();
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
                            LOGO_XERO_VIRMAN_ACIKLAMA kay = db.LOGO_XERO_VIRMAN_ACIKLAMA.Where(s => s.ID == row.ID).FirstOrDefault();
                            if (kay != null)
                            {
                                db.LOGO_XERO_VIRMAN_ACIKLAMA.Remove(kay);
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

        private void frmVirmanAciklamalari_Load(object sender, EventArgs e)
        {
            TurleriGetir();
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            txt_virmanaciklama.Text = "";
            id = 0;
            txt_virmanaciklama.Focus();
            btn_kaydet.Text = "Ekle";
        }
    }
}