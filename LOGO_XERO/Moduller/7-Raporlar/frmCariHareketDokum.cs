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

namespace LOGO_XERO.Moduller._7_Raporlar
{
    public partial class frmCariHareketDokum : DevExpress.XtraEditors.XtraForm
    {
        frmAnaForm ana;
        Islemler islem = new Islemler();
        Logic.GenelListeler liste = new Logic.GenelListeler();
        public frmCariHareketDokum()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            txtIlk.DateTime = DateTime.Now.AddDays(Convert.ToDouble(-ana.parametre.M_GNL_LISTELERIN_GUNFARKI));
            txtSon.DateTime = DateTime.Now;
            islem.IsyeriListesiDoldur(lk_isyeri,ana.lk_firma.EditValue.ToString());
            lk_isyeri.Properties.DisplayMember = "NAME";
            lk_isyeri.Properties.ValueMember = "NR"; 
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Yenile();
        }
     
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            pivotcarihareket.ShowPrintPreview();
        }
        public void Yenile()
        {
            List<LOGO_XERO_CARI_HAREKET_DOKUM> dataliste = liste.CariHareketGetir(ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString(), txtIlk.DateTime.ToString("MM-dd-yyyy"), txtSon.DateTime.ToString("MM-dd-yyyy"), lk_isyeri.EditValue.ToString());
            if (radioGroup1.SelectedIndex == 0)
            {
                pivotcarihareket.DataSource = dataliste;
                pivotcarihareket.RefreshData();
                pivotcarihareket.Refresh();
            }
            else if (radioGroup1.SelectedIndex == 1)
            {
                grid_carihareket.DataSource = dataliste;
                grid_carihareket.RefreshDataSource();
                grid_carihareket.Refresh();
            }

        }

        private void frmCariHareketDokum_Load(object sender, EventArgs e)
        {
            radioGroup1.SelectedIndex = 1;
        }

        private void frmCariHareketDokum_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F5)
            {
                simpleButton3_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.F4)
            {
                pivotcarihareket.ShowPrintPreview();
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                grid_carihareket.Visible = false;
                pivotcarihareket.Visible = true;
            }
            else if (radioGroup1.SelectedIndex == 1)
            {
                grid_carihareket.Visible = true;
                pivotcarihareket.Visible = false;
            }
        }
    }
}