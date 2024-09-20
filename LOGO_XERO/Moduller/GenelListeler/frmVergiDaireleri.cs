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
    public partial class frmVergiDaireleri : DevExpress.XtraEditors.XtraForm
    {
        Islemler islem = new Islemler();
        public int ulkeNr = 0;
        frmCariKartEkle _frmCariKartEkle;
        public frmVergiDaireleri(frmCariKartEkle frmCariKartEkle)
        {
            InitializeComponent();
            _frmCariKartEkle = frmCariKartEkle;
        }

        private void frmVergiDaireleri_Load(object sender, EventArgs e)
        {
            ListeGetir();
        }
        void ListeGetir()
        {
            if (ulkeNr == 0)
            {
                grid_VergiDaireleri.DataSource = islem.TumVergiDaireleriGetir();
            }
            else
            {
                grid_VergiDaireleri.DataSource = islem.VergiDaireleriGetir(ulkeNr);
            }

        }

        private void grid_VergiDaireleri_DoubleClick(object sender, EventArgs e)
        {
            L_TAXOFFICE row = (L_TAXOFFICE)gridView1.GetFocusedRow();
            if (row != null)
            {
                if (_frmCariKartEkle != null)
                {
                    _frmCariKartEkle.btn_VergiDairesi.Text = row.NAME;
                    _frmCariKartEkle.btn_VergiDairesiKodu.Text = row.CODE;
                }
                Close();
            }
        }
    }
}