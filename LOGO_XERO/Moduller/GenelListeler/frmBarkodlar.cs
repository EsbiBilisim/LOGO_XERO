using DevExpress.XtraEditors;
using LOGO_XERO.Models;
using LOGO_XERO.Models.LOGO_M;
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
    public partial class frmBarkodlar : DevExpress.XtraEditors.XtraForm
    {
        frmStokKart stokkart;
        public frmBarkodlar(frmStokKart _stokkart)
        {
            InitializeComponent();
            stokkart = _stokkart;
            Listele(); 
        }
        public void Listele() {
            using (LogoContext db = new LogoContext())
            {
               List<LG_UNITBARCODE> liste = db.LG_UNITBARCODE.Where(s => s.ITEMREF == stokkart.Stokreferans && s.UNITLINEREF == stokkart.unitlinelog).ToList();
                grid_barkodlar.DataSource = liste;
                grid_barkodlar.RefreshDataSource();
                grid_barkodlar.Refresh();
            }
        }

        private void gv_barkodlar_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }
        public void Kaydet() 
        {
            
            using (LogoContext db = new LogoContext())
            {
                
            }
        }

        private void frmBarkodlar_Load(object sender, EventArgs e)
        {

        }
    }
}