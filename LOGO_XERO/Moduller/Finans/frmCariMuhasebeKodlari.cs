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

namespace LOGO_XERO.Moduller.Finans
{
    public partial class frmCariMuhasebeKodlari : DevExpress.XtraEditors.XtraForm
    {
        frmCariKartEkle _frmCariKartEkle;
        Islemler islem = new Islemler();
        public frmCariMuhasebeKodlari(frmCariKartEkle frmCariKartEkle)
        {
            InitializeComponent();
            _frmCariKartEkle = frmCariKartEkle;
        }

        private void frmCariMuhasebeKodlari_Load(object sender, EventArgs e)
        {
            GetList();
        }
        void GetList()
        {
            grid_cariHesapPlanlari.DataSource = islem.CariHesapPlanlariGetir();
        }

        private void grid_cariHesapPlanlari_DoubleClick(object sender, EventArgs e)
        {
            LG_EMUHACC row = (LG_EMUHACC)gridView1.GetFocusedRow();
            if (row != null)
            {
                if (row.SUBACCOUNTS != 0)
                {
                    XtraMessageBox.Show("Alt Hesap Kodu Seçilmelidir !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (_frmCariKartEkle != null)
                    {
                        _frmCariKartEkle.txt_MuhasebeKodu.Text = row.CODE;
                        Close();
                    }
                }

            }
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMuhasebeKoduEkleme frm = new frmMuhasebeKoduEkleme();
            frm.ShowDialog();
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LG_EMUHACC row = (LG_EMUHACC)gridView1.GetFocusedRow();
            if (row != null)
            {
                frmMuhasebeKoduEkleme frm = new frmMuhasebeKoduEkleme();
                frm.MuhasebeReferans = row.LOGICALREF;
                frm.ShowDialog();
            }
        }
    }
}