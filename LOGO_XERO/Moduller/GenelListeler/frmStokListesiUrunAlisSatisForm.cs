using DevExpress.Utils;
using LOGO_XERO.Models;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using LOGO_XERO.Logic;

namespace LOGO_XERO.Moduller.GenelListeler
{
    public partial class frmStokListesiUrunAlisSatisForm : DevExpress.XtraEditors.XtraForm
    {
        frmAnaForm ana;
        SQLConnection clas = new SQLConnection();
        Islemler islem = new Islemler();
        string firma;
        string donem;
        public frmStokListesiUrunAlisSatisForm()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            firma = ana.lk_firma.EditValue.ToString();
            donem = ana.lk_donem.EditValue.ToString();
            islem.TasarimGetir(gv_UrunAlisSatis, ana._Kullanici.ID, this.Name, grid_UrunAlisSatis.Name);
        }
        public void Liste(string stokKodu, string trCode)
        {
            grid_UrunAlisSatis.DataSource = islem.urunSon10AlisSatisGetir(firma,donem,stokKodu,trCode);          
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmStokListesiUrunAlisSatisForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                simpleButton1_Click(sender, e);
            }
        }
        private void tasarımıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            islem.TasarimKaydet(gv_UrunAlisSatis, ana._Kullanici.ID, this.Name, grid_UrunAlisSatis.Name);
        }
    }
}