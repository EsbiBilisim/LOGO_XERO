using DevExpress.Data.Async.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using LOGO_XERO.Logic;
using LOGO_XERO.Moduller._7_Raporlar;
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

namespace LOGO_XERO.Moduller.Finans
{
    public partial class frmCariKartListesi : DevExpress.XtraEditors.XtraForm
    {
        Islemler islem = new Islemler();
        frmAnaForm ana;
        public frmCariKartListesi()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            islem.TasarimGetir(gv_CariListesi, ana._Kullanici.ID, this.Name, grid_CariListesi.Name);

            this.entityInstantFeedbackSource2.GetQueryable += entityInstantFeedbackSource2_GetQueryable;
            this.entityInstantFeedbackSource2.DismissQueryable += entityInstantFeedbackSource2_DismissQueryable;
        }
        void entityInstantFeedbackSource2_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            LOGO_XERO.Models.LogoContext dataContext = new LOGO_XERO.Models.LogoContext();
            e.QueryableSource = dataContext.LOGO_XERO_CARILISTE;
            e.Tag = dataContext;
        }
        void entityInstantFeedbackSource2_DismissQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            ((LOGO_XERO.Models.LogoContext)e.Tag).Dispose();
        }
        private void tasarimKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Tasarım Kaydedildi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            islem.TasarimKaydet(gv_CariListesi, ana._Kullanici.ID, this.Name, grid_CariListesi.Name);
        }
        private void excelAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            islem.excelAktar(grid_CariListesi);
        }
        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCariKartEkle frm = new frmCariKartEkle();
            frm.ShowDialog();
        }
        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReadonlyThreadSafeProxyForObjectFromAnotherThread secilmis = (ReadonlyThreadSafeProxyForObjectFromAnotherThread)gv_CariListesi.GetFocusedRow();
            if (secilmis != null)
            {
                LOGO_XERO_CARILISTE row = (LOGO_XERO_CARILISTE)secilmis.OriginalRow;
                if (row != null)
                {
                    frmCariKartEkle cari = new frmCariKartEkle();
                    cari.cariReferans = row.LOGICALREF;
                    cari.ShowDialog();
                }
            }
        }

        private void gv_CariListesi_DoubleClick(object sender, EventArgs e)
        {
            düzenleToolStripMenuItem_Click(sender, e);
        }

        private void cariHareketEkstresiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReadonlyThreadSafeProxyForObjectFromAnotherThread secilmis = (ReadonlyThreadSafeProxyForObjectFromAnotherThread)gv_CariListesi.GetFocusedRow();
            if (secilmis != null)
            {
                LOGO_XERO_CARILISTE row = (LOGO_XERO_CARILISTE)secilmis.OriginalRow;
                if (row != null)
                {                  
                    frmCariEkstre frmCariEkstre = new frmCariEkstre(row.DEFINITION_, row.CODE);
                    frmCariEkstre.carikod = row.CODE;
                    frmCariEkstre.Yenile();
                    frmCariEkstre.ShowDialog();
                }
            }
        }
    }
}