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
    public partial class frmTasiyiciKodlari : DevExpress.XtraEditors.XtraForm
    {
        frmTeklifOlustur _frmTeklifOlustur;
        Islemler islem = new Islemler();
        public frmTasiyiciKodlari(frmTeklifOlustur frmTeklifOlustur)
        {
            InitializeComponent();
            _frmTeklifOlustur = frmTeklifOlustur;
        }

        private void frmTasiyiciKodlari_Load(object sender, EventArgs e)
        {
            ListeGetir();
        }
        public void ListeGetir()
        {
            grid_TasiyiciKodlari.DataSource = islem.TasiyiciKodListesi();
        }

        private void grid_TasiyiciKodlari_DoubleClick(object sender, EventArgs e)
        {
            L_SHPAGENT tasiyici = (L_SHPAGENT)gv_TasiyiciKodlari.GetFocusedRow();
            if (tasiyici != null)
            {
                if (_frmTeklifOlustur != null)
                {
                    _frmTeklifOlustur.btn_TasiyiciKodu.Text = tasiyici.CODE;
                    _frmTeklifOlustur.btn_TasiyiciKoduAciklamasi.Text = tasiyici.TITLE;
                    Close();
                }
            }
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            L_SHPAGENT row = (L_SHPAGENT)gv_TasiyiciKodlari.GetFocusedRow();
            if (row != null)
            {
                frmTasiyiciKoduEkleme frmTasiyiciKoduEkleme = new frmTasiyiciKoduEkleme(this); 
                frmTasiyiciKoduEkleme.ShowDialog();
            }
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            L_SHPAGENT row = (L_SHPAGENT)gv_TasiyiciKodlari.GetFocusedRow();
            if (row != null)
            {
                frmTasiyiciKoduEkleme frmTasiyiciKoduEkleme = new frmTasiyiciKoduEkleme(this);
                frmTasiyiciKoduEkleme.guncellenecekKayit = row;
                frmTasiyiciKoduEkleme.id = row.LOGICALREF;
                frmTasiyiciKoduEkleme.ShowDialog();
            }
        }
    }
}