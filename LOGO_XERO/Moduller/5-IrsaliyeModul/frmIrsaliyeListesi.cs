using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using LOGO_XERO.Models.GenelKullanim;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGO_XERO.Moduller._1_TeklifModul
{
    public partial class frmIrsaliyeListesi : DevExpress.XtraEditors.XtraForm
    {

        frmAnaForm ana;
        public int tip = 0;
        Logic.GenelListeler listeler = new Logic.GenelListeler();
        Islemler islem = new Islemler();
        bool faturanmis = false;

        public frmIrsaliyeListesi()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            txtIlk.DateTime = DateTime.Now.AddDays(Convert.ToDouble(-ana.parametre.M_GNL_LISTELERIN_GUNFARKI));
            txtSon.DateTime = DateTime.Now;
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            listeler.FATURALANMAMIS_IRS_PROCEDURE_OLUSTUR(ana.lk_firma.EditValue.ToString());
            islem.TumAmbarListesiDoldur(rpambar, ana.lk_firma.EditValue.ToString());
            islem.LogoSatisElemaniDoldurDinamikRef(rpsatiselemani, ana.lk_firma.EditValue.ToString());
            islem.BolumListesiDoldur(rpbolum,ana.lk_firma.EditValue.ToString());
            islem.IsyeriListesiDoldur(rpisyeri, ana.lk_firma.EditValue.ToString());
            islem.IsyeriListesiDoldur(ck_isyeri, ana.lk_firma.EditValue.ToString());

            ck_isyeri.CheckAll();
           
        }
        private void frmTeklifListesi_Load(object sender, EventArgs e)
        {

            ListeYenile();
            gridIrsaliyeler.RefreshDataSource();
            gridIrsaliyeler.Refresh();
            if (tip == 1)
            {
                this.Text = "Alış İrsaliyeleri";
                islem.TasarimGetir(gv_Irsaliyeler, ana._Kullanici.ID, this.Name, gridIrsaliyeler.Name + "Alis");
            }
            else if (tip == 8)
            {
                this.Text = "Satış İrsaliyeleri";
                islem.TasarimGetir(gv_Irsaliyeler, ana._Kullanici.ID, this.Name, gridIrsaliyeler.Name + "Satis");
            }
        }
         
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            ListeYenile();
        }

        public void ListeYenile()
        {
            string isyerisorgu = "";
            if (!string.IsNullOrWhiteSpace(ck_isyeri.EditValue.ToString()))
            {
                isyerisorgu = $@"AND  S.BRANCH IN({ck_isyeri.EditValue.ToString()})";
            }
             
            gridIrsaliyeler.DataSource = listeler.Faturalanmamisİrsaliyeler(ana.lk_firma.EditValue.ToString(),
               ana.lk_donem.EditValue.ToString(), tip, txtIlk.DateTime.ToString("yyyy-MM-dd"), txtSon.DateTime.ToString("yyyy-MM-dd"), isyerisorgu, faturanmis);
            gridIrsaliyeler.RefreshDataSource();
            gridIrsaliyeler.Refresh(); 
        }
        private void tasarımKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tip == 1) // Satış
            {
                islem.TasarimKaydet(gv_Irsaliyeler, ana._Kullanici.ID, this.Name, gridIrsaliyeler.Name + "Alis");
                XtraMessageBox.Show("TASARIM KAYIT BAŞARILI !", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (tip == 8) // Alış
            {
                islem.TasarimKaydet(gv_Irsaliyeler, ana._Kullanici.ID, this.Name, gridIrsaliyeler.Name + "Satis");
                XtraMessageBox.Show("TASARIM KAYIT BAŞARILI !", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                XtraMessageBox.Show("TİP HATASI !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void ck_CheckedChanged(object sender, EventArgs e)
        {
            if (ck.Checked)
            {
                faturanmis = true; //billed  = 0 lari göster
            }
            else
            {
                faturanmis = false; // billed = 0 olanları gösterme
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            gridIrsaliyeler.ShowPrintPreview();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIrsaliyeListesi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                ListeYenile();
            }
            if (e.KeyCode == Keys.Escape)
            {
                simpleButton4_Click(sender, e);
            }
            if (e.KeyCode == Keys.F4)
            {
                simpleButton2_Click(sender, e);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (ana.demomu == 1)
            {
                ekleToolStripMenuItem.Enabled = false;
                düzenleToolStripMenuItem.Enabled = false;
            }
            else
            {
                ekleToolStripMenuItem.Enabled = true;
                düzenleToolStripMenuItem.Enabled = true;
            }
        }
    }
}