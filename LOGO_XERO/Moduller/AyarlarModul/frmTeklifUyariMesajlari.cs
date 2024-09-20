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

namespace LOGO_XERO.Moduller.GenelListeler
{
    public partial class frmTeklifUyariMesajlari : DevExpress.XtraEditors.XtraForm
    {
        int id = 0;
        frmAnaForm ana;
        int firmano = 0;
        public frmTeklifUyariMesajlari()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            firmano = Convert.ToInt32(ana.lk_firma.EditValue);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TeklifUyariMesajiKaydet();
        }

        public void TeklifUyariMesajiKaydet()
        {
            if (string.IsNullOrWhiteSpace(txt_uyariMesaji.Text))
            {
                XtraMessageBox.Show("Mesaj Girmeden Kayıt Ekleyemezsiniz !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_uyariMesaji.Focus();
            }
            try
            {
                using (LogoContext db = new LogoContext())
                {
                    if (id == 0)
                    {

                        LOGO_XERO_UYARI_MESAJLARI yeniMesaj = new LOGO_XERO_UYARI_MESAJLARI();
                        yeniMesaj.ACIKLAMA = txt_uyariMesaji.Text;
                        yeniMesaj.FIRMANO = firmano;
                        db.LOGO_XERO_UYARI_MESAJLARI.Add(yeniMesaj);
                        db.SaveChanges();
                        XtraMessageBox.Show("Kayıt Başarılı !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                        LOGO_XERO_UYARI_MESAJLARI kayitliMesaj = db.LOGO_XERO_UYARI_MESAJLARI.Where(s => s.ID == id).FirstOrDefault();
                        if (kayitliMesaj != null)
                        {
                            kayitliMesaj.ACIKLAMA = txt_uyariMesaji.Text;
                            db.Entry(kayitliMesaj);
                            db.SaveChanges();
                            XtraMessageBox.Show("Düzenleme Başarılı !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    id = 0;
                    txt_uyariMesaji.Text = "";
                    btn_kaydet.Text = "Ekle";
                    UyariMesajlariListesi();
                    txt_uyariMesaji.Focus();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("İşlem Başarısız ! HATA : " + ex.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_temizle_Click(object sender, EventArgs e)
        {
            txt_uyariMesaji.Text = "";
            id = 0;
            btn_kaydet.Text = "Ekle";
            txt_uyariMesaji.Focus();
        }
        private void frmTeklifUyariMesajlari_Load(object sender, EventArgs e)
        {
            UyariMesajlariListesi();
        }

        public void UyariMesajlariListesi()
        {
            grid_TeklifUyariMesajlari.DataSource = TeklifUyariMesajlariGetir(firmano);
        }

        public List<LOGO_XERO_UYARI_MESAJLARI> TeklifUyariMesajlariGetir(int firmano)
        {
            using (LogoContext db = new LogoContext())
            {
                return db.LOGO_XERO_UYARI_MESAJLARI.Where(s => s.FIRMANO == firmano).ToList();
            }
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LOGO_XERO_UYARI_MESAJLARI row = (LOGO_XERO_UYARI_MESAJLARI)gridView1.GetFocusedRow();
            if (row != null)
            {
                id = row.ID;
                txt_uyariMesaji.Text = row.ACIKLAMA;
                btn_kaydet.Text = "Güncelle";
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LOGO_XERO_UYARI_MESAJLARI row = (LOGO_XERO_UYARI_MESAJLARI)gridView1.GetFocusedRow();
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
                            LOGO_XERO_UYARI_MESAJLARI kay = db.LOGO_XERO_UYARI_MESAJLARI.Where(s => s.ID == row.ID).FirstOrDefault();
                            if (kay != null)
                            {
                                db.LOGO_XERO_UYARI_MESAJLARI.Remove(kay);
                                db.SaveChanges();
                                XtraMessageBox.Show("Silme Başarılı !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        UyariMesajlariListesi();
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