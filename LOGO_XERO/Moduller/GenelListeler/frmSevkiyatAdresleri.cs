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
    public partial class frmSevkiyatAdresleri : DevExpress.XtraEditors.XtraForm
    {

        frmTeklifOlustur _frmTeklifOlustur;
        //frmSiparisOlustur _frmSiparisOlustur;
        //frmIrsaliyeOlustur _frmIrsaliyeOlustur;
        //frmFaturaOlustur _frmFaturaOlustur;
        frmTeklifOlustur frmTeklifOlustur;
        Islemler islem = new Islemler();
        frmAnaForm ana;
        int cariId;
        public string cariKodu;
        public frmSevkiyatAdresleri(frmTeklifOlustur _frmTeklifOlustur)
        {
            InitializeComponent();
            frmTeklifOlustur = _frmTeklifOlustur;
            cariId = Convert.ToInt32(frmTeklifOlustur.lbl_cariref.Text);
            cariKodu = frmTeklifOlustur.btn_cariKodu.Text;
        }
        private void frmSevkiyatAdresleri_Load(object sender, EventArgs e)
        {
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            ListeGetir();
        }
        void ListeGetir()
        {

            grid_SevkiyatAdresler.DataSource = islem.SevkiyatAdresleriGetir(ana.lk_firma.EditValue.ToString(), cariId);
        }

        private void grid_SevkiyatAdresler_DoubleClick(object sender, EventArgs e)
        {
            LG_SHIPINFO row = (LG_SHIPINFO)gv_SevkiyatAdresler.GetFocusedRow();
            if (row != null)
            {
                if (frmTeklifOlustur != null)
                {
                    frmTeklifOlustur.btn_SevkAdresKodu.Text = row.CODE;
                    frmTeklifOlustur.btn_sevkiyatAdresAciklama.Text = row.NAME;
                    frmTeklifOlustur.lbl_sevkiyatadresref.Text = row.LOGICALREF.ToString();
                    Close();
                }
            }
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmSevkiyatAdresleri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                simpleButton2_Click(sender, e);
            }
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSevkiyatAdresiEkleme frm = new frmSevkiyatAdresiEkleme();
            frm.carilogicalref = cariId;
            frm.cariKod = cariKodu;
            frm.ShowDialog();
            ListeGetir();
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LG_SHIPINFO row = (LG_SHIPINFO)gv_SevkiyatAdresler.GetFocusedRow();
            if (row != null)
            {
                frmSevkiyatAdresiEkleme sevk = new frmSevkiyatAdresiEkleme();
                sevk.duzenle = true;
                sevk.logicalref = Convert.ToInt32(row.LOGICALREF);
                sevk.carilogicalref = cariId;
                sevk.cariKod = cariKodu;
                sevk.ShowDialog();
                ListeGetir();
            }
        }
    }
}