using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using LOGO_XERO.Models.StokEkstresi;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LOGO_XERO.Moduller.GenelListeler
{
    public partial class frmLotBilgileri : DevExpress.XtraEditors.XtraForm
    {
        frmAnaForm ana;
        Islemler islem = new Islemler();
        string firma;
        string donem;
        public int stokLogicalref=0;
        public frmLotBilgileri()
        {
            InitializeComponent();

            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            firma = ana.lk_firma.EditValue.ToString();
            donem = ana.lk_donem.EditValue.ToString();
        }
        private void frmLotBilgileri_Load(object sender, EventArgs e)
        {
            Liste();
        }
        void Liste()
        {

            grid_LotBilgileri.DataSource = islem.stokLotBilgiGetir(firma,donem, stokLogicalref);
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void grid_LotBilgileri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                simpleButton1_Click(sender, e);
            }
        }
    }
}