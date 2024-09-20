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

namespace LOGO_XERO
{
    public partial class frmStokListesiArama : DevExpress.XtraEditors.XtraForm
    {
        Islemler islem = new Islemler();
        public frmStokListesiArama()
        {
            InitializeComponent();
        }

        List<LOGO_XERO_ARAMA_FILTRE_ALANLARI> filtreListesi = new List<LOGO_XERO_ARAMA_FILTRE_ALANLARI>();

        private void frmStokListesiArama_Load(object sender, EventArgs e)
        {
            filtreListesi = islem.FiltreListesiGetir(1,"");
            ck_Alanlar.Properties.DataSource = filtreListesi;
            ck_Alanlar.Properties.ValueMember = "VERITABANI_ALANI";
            ck_Alanlar.Properties.DisplayMember = "TURKCEALAN";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ck_Alanlar.EditValue=null;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            ck_Alanlar.CheckAll();
        }
    }
}