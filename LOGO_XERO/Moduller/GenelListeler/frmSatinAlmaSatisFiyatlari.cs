using DevExpress.Utils;
using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGO_XERO.Moduller.GenelListeler
{
    public partial class frmSatinAlmaSatisFiyatlari : DevExpress.XtraEditors.XtraForm
    {
        frmAnaForm ana;
        Islemler islem = new Islemler();
        string firma;
        string donem;

        public int stoklogicalref = 0;
        public frmSatinAlmaSatisFiyatlari()
        {
            InitializeComponent();

            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            firma = ana.lk_firma.EditValue.ToString();
            donem = ana.lk_donem.EditValue.ToString();
            islem.TasarimGetir(gv_SatinAlmaFiy, ana._Kullanici.ID, this.Name, grid_satinalmafiyatlari.Name);
            islem.TasarimGetir(gv_SatisFiy, ana._Kullanici.ID, this.Name, grid_satisfiyatlari.Name);
        }
        private void frmSatinAlmaSatisFiyatlari_Load(object sender, EventArgs e)
        {
            Liste();
        }
        public void Liste()
        {
            grid_satisfiyatlari.DataSource = islem.stokTanimliAlisSatisFiyatlar(firma, 2, stoklogicalref);
            grid_satinalmafiyatlari.DataSource = islem.stokTanimliAlisSatisFiyatlar(firma, 1, stoklogicalref);
        }

        private void tasarımKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            islem.TasarimKaydet(gv_SatinAlmaFiy, ana._Kullanici.ID, this.Name, grid_satinalmafiyatlari.Name);
            islem.TasarimKaydet(gv_SatisFiy, ana._Kullanici.ID, this.Name, grid_satisfiyatlari.Name);
            XtraMessageBox.Show("Tasarım Kaydedildi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}