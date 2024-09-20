using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
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

namespace LOGO_XERO.Moduller.Finans
{
    public partial class frmIstihbaratBilgileriListele : DevExpress.XtraEditors.XtraForm
    {
        int id = 0;
        public int cariref = 0;
        Islemler islem = new Islemler();
        public frmIstihbaratBilgileriListele()
        {
            InitializeComponent();
        }
        private void frmIstihbaratBilgileriListele_Load(object sender, EventArgs e)
        {
            GetList();
        }
        public void GetList()
        {
            grid_IstihbaratBilgileri.DataSource = islem.IstihbaratBilgileriGetir(cariref);
        }
        private void frmIstihbaratBilgileriListele_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}