using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using LOGO_XERO.Models.LOGO_M;
using LOGO_XERO.Moduller.Finans;
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
    public partial class frmOdemeler : DevExpress.XtraEditors.XtraForm
    {
        frmAnaForm ana;
        Islemler islem = new Islemler();
        frmTeklifOlustur _frmTeklifOlustur;
        frmCariKartEkle _frmCariKartEkle;
        //frmIrsaliyeOlustur _frmIrsaliyeOlustur;
        //frmFaturaOlustur _frmFaturaOlustur;

        public frmOdemeler(frmTeklifOlustur frmTeklifOlustur)
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            _frmTeklifOlustur = frmTeklifOlustur;
        }
        public frmOdemeler(frmCariKartEkle frmCariKartEkle)
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            _frmCariKartEkle = frmCariKartEkle;
        }
        //public frmOdemeler(frmIrsaliyeOlustur frmIrsaliyeOlustur)
        //{
        //    InitializeComponent();
        //    ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
        //    _frmIrsaliyeOlustur = frmIrsaliyeOlustur;
        //}
        //public frmOdemeler(frmFaturaOlustur frmFaturaOlustur)
        //{
        //    InitializeComponent();
        //    ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
        //    _frmFaturaOlustur = frmFaturaOlustur;
        //}

        private void frmOdemeler_Load(object sender, EventArgs e)
        {
            ListeYukle();
        }
        void ListeYukle()
        {
            List<LG_PAYPLANS> liste = islem.OdemeListesiGetir(ana.lk_firma.EditValue.ToString());
            grid_Odemeler.DataSource = liste;
        }

        private void grid_TicariIslemGuruplari_DoubleClick(object sender, EventArgs e)
        {
            LG_PAYPLANS row = (LG_PAYPLANS)gv_Odemeler.GetFocusedRow();
            if (row != null)
            {
                if (_frmTeklifOlustur != null)
                {
                    Close();
                }
                if (_frmCariKartEkle != null)
                {
                    _frmCariKartEkle.txt_OdemePlanKodu.Text = row.CODE;
                    _frmCariKartEkle.txt_OdemePlanAciklama.Text = row.DEFINITION_;
                    Close();
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmOdemeler_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                simpleButton2_Click(sender, e);
            }
        }
    }
}