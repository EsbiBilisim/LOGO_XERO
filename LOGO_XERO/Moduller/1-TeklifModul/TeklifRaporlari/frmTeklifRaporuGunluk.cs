using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using LOGO_XERO.Models.LOGO_XERO_M;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGO_XERO.Moduller._1_TeklifModul.TeklifRaporlari
{
    public partial class frmTeklifRaporuGunluk : DevExpress.XtraEditors.XtraForm
    {
        Islemler islem = new Islemler();
        frmAnaForm ana;
        public string firma, donem;
        LOGO_XERO_PARAMETRELER parametre = new LOGO_XERO_PARAMETRELER();
        public frmTeklifRaporuGunluk()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            firma = ana.lk_firma.EditValue.ToString();
            donem = ana.lk_donem.EditValue.ToString();
            parametre = ana.parametre;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTeklifRaporuGunluk_Load(object sender, EventArgs e)
        {
            sontarih.DateTime = DateTime.Now;
            ilktarih.DateTime = DateTime.Now.AddDays(Convert.ToInt32(-parametre.M_GNL_LISTELERIN_GUNFARKI));
            islem.PersonelListesiDoldur(ck_personellistesi);
        }
    }
}