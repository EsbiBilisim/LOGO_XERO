using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Import.Doc;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
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
    public partial class frmDetayBilgi : DevExpress.XtraEditors.XtraForm
    {
        public string cariad = "";
        public string carikod = "";
        public int tip  = 0;
        public string StokRef = "0";
        frmAnaForm ana;
        List<LOGO_XERO_CARI_BILGI> liste;
        List<LOGO_XERO_URUN_BILGI> liste1;
        Logic.GenelListeler listeler = new Logic.GenelListeler();
        public frmDetayBilgi()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
        } 
        private void frmDetayBilgi_Load(object sender, EventArgs e)
        {

            if (tip ==1)
            {
                using (LogoContext db = new LogoContext())
                {
                    string firma = ana.lk_firma.EditValue.ToString();
                    string donem = ana.lk_donem.EditValue.ToString();

                    string sorgu = $@"SELECT DEFINITION_ FROM LG_{firma}_CLCARD WHERE LOGICALREF={carikod}";
                    string cariunvani = db.Database.SqlQuery<string>(sorgu).ToList().FirstOrDefault();
                    cariad = cariunvani;
                }

                //  btn_borclasdirma.Visible = true;
                //  btn_alacakyaslandirma.Visible = true;
            } 
            else if (tip == 2)
            {
                btn_borclasdirma.Visible = false;

                btn_alacakyaslandirma.Visible = false;
            }Yenile();
        }
        public void Yenile()
        {
            if (tip == 1)
            {
                if (btn_ay.Checked)
                {
                    liste = listeler.caribilgiAyGetir(ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString(), Convert.ToInt32(carikod).ToString());

                }
                else
                {
                  liste = listeler.caribilgiYilGetir(ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString(), Convert.ToInt32(carikod).ToString()); 
                }
                grid_detaybilgi.DataSource = liste;
                grid_detaybilgi.RefreshDataSource();
                grid_detaybilgi.Refresh();
            }
            else if (tip == 2)
            {
                if (btn_ay.Checked)
                {
                    liste1 = listeler.urunbilgiAyGetir(ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString(), Convert.ToInt32(StokRef).ToString());
                }
                else
                {    
                    liste1 = listeler.urunbilgiYilGetir(ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString(), Convert.ToInt32(StokRef).ToString());
                    
                }
                grid_detaybilgi.DataSource = liste1;
                grid_detaybilgi.RefreshDataSource();
                grid_detaybilgi.Refresh();

            }

        }

        private void btn_ay_CheckedChanged(object sender, EventArgs e)
        {
            Yenile();
        }

        private void btn_yl_CheckedChanged(object sender, EventArgs e)
        {
            Yenile();
        }
    }
    
}