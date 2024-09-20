using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
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
    public partial class frmAmbarlar : DevExpress.XtraEditors.XtraForm
    {
        frmAnaForm ana;
        string firma = "";
        Islemler islem = new Islemler();
        frmCariKoduAmbarParametreleri _frmCariKoduAmbarParametreleri;
        public frmAmbarlar(frmCariKoduAmbarParametreleri frmCariKoduAmbarParametreleri)
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            firma = ana.lk_firma.EditValue.ToString();
            _frmCariKoduAmbarParametreleri = frmCariKoduAmbarParametreleri;
        }

        private void frmAmbarlar_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = islem.TumAmbarListesi(firma);
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            L_CAPIWHOUSE row = (L_CAPIWHOUSE)gridView1.GetFocusedRow();
            if (_frmCariKoduAmbarParametreleri != null)
            {
                _frmCariKoduAmbarParametreleri.btn_ambarsec.Text = row.NR.ToString();
                _frmCariKoduAmbarParametreleri.txtAmbarAdi.Text = row.NAME;
                Close();
            }
           
        }
    }
}