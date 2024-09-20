using DevExpress.Data.Async.Helpers;
using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using LOGO_XERO.Models.LOGO_XERO_M;
using LOGO_XERO.Moduller.GenelListeler;
using System;
using System.Windows.Forms;

namespace LOGO_XERO.Moduller.MalzemeYonetimi
{
    public partial class frmMalzemeYonetimiStokListesi : DevExpress.XtraEditors.XtraForm
    {
        Islemler islem = new Islemler();
        frmAnaForm ana;
        public frmMalzemeYonetimiStokListesi()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            islem.TasarimGetir(gv_StokListesi, ana._Kullanici.ID, this.Name, grid_StokListesi.Name);
            this.entityInstantFeedbackSource1.GetQueryable += entityInstantFeedbackSource1_GetQueryable;
            this.entityInstantFeedbackSource1.DismissQueryable += entityInstantFeedbackSource1_DismissQueryable;
        }
        void entityInstantFeedbackSource1_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            LOGO_XERO.Models.LogoContext dataContext = new LOGO_XERO.Models.LogoContext();
            e.QueryableSource = dataContext.LOGO_XERO_STOKLISTESI;
            e.Tag = dataContext;
        }

        void entityInstantFeedbackSource1_DismissQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            ((LOGO_XERO.Models.LogoContext)e.Tag).Dispose();
        }

        private void tasarımKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Tasarım Kaydedildi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            islem.TasarimKaydet(gv_StokListesi, ana._Kullanici.ID, this.Name, grid_StokListesi.Name);
        }

        private void excelAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            islem.excelAktar(grid_StokListesi);
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStokKart stk = new frmStokKart();
            stk.ShowDialog();
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ReadonlyThreadSafeProxyForObjectFromAnotherThread secilmis = (ReadonlyThreadSafeProxyForObjectFromAnotherThread)gv_StokListesi.GetFocusedRow();
            if (secilmis != null)
            {
                LOGO_XERO_STOKLISTESI row = (LOGO_XERO_STOKLISTESI)secilmis.OriginalRow;
                if (row != null)
                {
                    frmStokKart stk = new frmStokKart();
                    stk.Stokreferans = row.LOGICALREF;
                    stk.ShowDialog();
                }
            }
        }

        private void gv_StokListesi_DoubleClick(object sender, EventArgs e)
        {
            düzenleToolStripMenuItem_Click(sender, e);
        }
    }
}