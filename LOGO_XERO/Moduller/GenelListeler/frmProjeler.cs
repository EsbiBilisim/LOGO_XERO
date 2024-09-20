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
    public partial class frmProjeler : DevExpress.XtraEditors.XtraForm
    {
        Islemler islem = new Islemler();
        frmAnaForm ana;
        frmTeklifOlustur _frmTeklifOlustur;
        public frmProjeler(frmTeklifOlustur frmTeklifOlustur)
        {
            InitializeComponent();
            _frmTeklifOlustur = frmTeklifOlustur;
            ana=Application.OpenForms["frmAnaForm"] as frmAnaForm;
        }

        private void frmProjeler_Load(object sender, EventArgs e)
        {
            ListeGetir();
        }
        void ListeGetir()
        {
            grid_Projeler.DataSource = islem.ProjeListesiGetir(ana.lk_firma.EditValue.ToString());
        }

        private void grid_Projeler_DoubleClick(object sender, EventArgs e)
        {
            LG_PROJECT proje = (LG_PROJECT)gv_Projeler.GetFocusedRow();
            if (proje != null)
            {
                if (_frmTeklifOlustur != null)
                {
                    _frmTeklifOlustur.btn_ProjeKodu.Text = proje.CODE;
                    _frmTeklifOlustur.btn_projeAciklamasi.Text = proje.NAME;
                    _frmTeklifOlustur.lbl_projeref.Text = proje.LOGICALREF.ToString();
                    Close();
                }
            }
        }
    }
}