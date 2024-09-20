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
    public partial class frmHatirlatmaListele : DevExpress.XtraEditors.XtraForm
    {
        Islemler islem = new Islemler();
        frmAnaForm ana;
        public frmHatirlatmaListele()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            islem.TasarimGetir(gv_hatirlatma, ana._Kullanici.ID, this.Name, grid_Hatirlatma.Name);
            Listele();
           
        }
        public void Listele() 
        {
            using (LogoContext db = new LogoContext())
            {
                grid_Hatirlatma.DataSource = db.LOGO_XERO_HATIRLATMA.ToList();
                grid_Hatirlatma.RefreshDataSource();
                grid_Hatirlatma.Refresh();
            }
        
        }

        private void tasarımKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            islem.TasarimKaydet(gv_hatirlatma,ana._Kullanici.ID,this.Name,grid_Hatirlatma.Name);
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LOGO_XERO_HATIRLATMA row = (LOGO_XERO_HATIRLATMA)gv_hatirlatma.GetFocusedRow();
            if (row != null)
            {
                int tip = Convert.ToInt32(row.TIP);
                frmTeklifHatirlatmaEkle frm = new frmTeklifHatirlatmaEkle(tip);
                frm.id = Convert.ToInt32(row.ID);
                frm.ShowDialog();
            }
           
        } 
        private void gv_hatirlatma_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DegisenSatirKaydet(e.RowHandle);
        }

        private void hepsiniOkunduİşaretleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gv_hatirlatma.RowCount; i++)
            {
                gv_hatirlatma.FocusedRowHandle = i;
                gv_hatirlatma.SetFocusedRowCellValue("OKUNDU",true);
                DegisenSatirKaydet(i);
            }
        }
        public void DegisenSatirKaydet(int satirind) 
        {
            using (LogoContext db = new LogoContext())
            {
                int id = Convert.ToInt32(gv_hatirlatma.GetRowCellValue(satirind, "ID"));
                LOGO_XERO_HATIRLATMA hat = db.LOGO_XERO_HATIRLATMA.Where(s => s.ID == id).FirstOrDefault();
                hat.OKUNDU = Convert.ToBoolean(gv_hatirlatma.GetRowCellValue(satirind,"OKUNDU")); 
                db.LOGO_XERO_HATIRLATMA.AddOrUpdate(hat);
                db.SaveChanges();
            }
        }

        private void gv_hatirlatma_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DegisenSatirKaydet(e.RowHandle);
        }

        private void frmHatirlatmaListele_Load(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            LOGO_XERO_HATIRLATMA row =(LOGO_XERO_HATIRLATMA) gv_hatirlatma.GetFocusedRow();
            if (row != null)
            {
                düzenleToolStripMenuItem.Visible = true;
                hepsiniOkunduİşaretleToolStripMenuItem.Visible = true;
            }
            else
            {
                düzenleToolStripMenuItem.Visible = false;
                hepsiniOkunduİşaretleToolStripMenuItem.Visible = false;
            }
        }
    }
}