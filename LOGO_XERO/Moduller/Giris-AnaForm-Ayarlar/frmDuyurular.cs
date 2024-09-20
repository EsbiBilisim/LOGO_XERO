using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base.ViewInfo;
using LOGO_XERO.Models;
using LOGO_XERO.Models.LOGO_XERO_M;
using LOGO_XERO.Moduller.AyarlarModul;
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
    public partial class frmDuyurular : DevExpress.XtraEditors.XtraForm
    {
        int id = 0;
        frmAnaForm ana;
        frmAnaDashBoard dashBoard;
        public frmDuyurular()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            dashBoard = Application.OpenForms["frmAnaDashBoard"] as frmAnaDashBoard;
            Listele();
        }
        public void Listele() 
        {
            using (LogoContext db = new LogoContext())
            {
                List<LOGO_XERO_DUYURULAR> liste = db.LOGO_XERO_DUYURULAR.Where(s=>s.IPTALID == 0).ToList();
                gridDuyuru.DataSource = liste;
                gridDuyuru.RefreshDataSource();
                gridDuyuru.Refresh();
            }
        } 
        private void gridDuyuru_DoubleClick(object sender, EventArgs e)
        { 
            LOGO_XERO_DUYURULAR duyuru = (LOGO_XERO_DUYURULAR) gv_duyuru.GetFocusedRow();
            id = duyuru.ID;
            txt_duyuruaciklama.Text = duyuru.ACIKLAMA;
            checkEdit1.Checked = duyuru.ONCELIKLI; 
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void frmDuyurular_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (dashBoard !=null)
            {
                dashBoard.ListeleDuyuru();
            }
        }
         
        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            using (LogoContext db = new LogoContext())
            {
                LOGO_XERO_DUYURULAR duyuru = new LOGO_XERO_DUYURULAR();
                if (id == 0)
                {
                    duyuru.ACIKLAMA = txt_duyuruaciklama.Text;
                    duyuru.ONCELIKLI = checkEdit1.Checked;
                    duyuru.TARIH = DateTime.Now;
                    duyuru.IPTALID = 0;
                    duyuru.PERSONEL = ana._Kullanici.KULLANICIADI;
                }
                else
                {
                    duyuru.ID = id;
                    duyuru.ACIKLAMA = txt_duyuruaciklama.Text;
                    duyuru.ONCELIKLI = checkEdit1.Checked;
                    duyuru.TARIH = DateTime.Now;
                    duyuru.IPTALID = 0;
                    duyuru.PERSONEL = ana._Kullanici.KULLANICIADI;
                }
                db.LOGO_XERO_DUYURULAR.AddOrUpdate(duyuru);
                XtraMessageBox.Show("Duyuru Kaydedildi ! ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.SaveChanges();
                txt_duyuruaciklama.Clear();
                checkEdit1.Checked = false;
                btn_kaydet.Text = "Ekle";
                id = 0;
            }
            Listele();
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            txt_duyuruaciklama.Text = null;
            btn_kaydet.Text = "Ekle";
            id = 0;
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LOGO_XERO_DUYURULAR duyuru = (LOGO_XERO_DUYURULAR)gv_duyuru.GetFocusedRow();
            btn_kaydet.Text = "Düzenle";
            id = duyuru.ID;
            txt_duyuruaciklama.Text = duyuru.ACIKLAMA;
            checkEdit1.Checked = duyuru.ONCELIKLI;
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Duyuruyu Silmeyi Onaylıyor Musunuz ?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    LOGO_XERO_DUYURULAR duyuru = (LOGO_XERO_DUYURULAR)gv_duyuru.GetFocusedRow();
                    using (LogoContext db = new LogoContext())
                    {
                        duyuru = db.LOGO_XERO_DUYURULAR.Where(s => s.ID == duyuru.ID).FirstOrDefault();
                        duyuru.IPTALID = 1;
                        db.LOGO_XERO_DUYURULAR.AddOrUpdate(duyuru);
                        db.SaveChanges();
                    }
                    XtraMessageBox.Show("Duyuru Silindi ! ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Hata ! : " + ex, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                Listele();
            }
        }
    }
}