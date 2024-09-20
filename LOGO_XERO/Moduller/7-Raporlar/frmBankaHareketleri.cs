using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using Microsoft.Win32;
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
    public partial class frmBankaHareketleri : DevExpress.XtraEditors.XtraForm
    {
        Islemler islem = new Islemler();
        Logic.GenelListeler listeler = new Logic.GenelListeler();
        List<LOGO_XERO_BANKA_HAREKET> liste;
        frmAnaForm ana;
        public frmBankaHareketleri()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            date_ilk.DateTime = DateTime.Now.AddDays(-Convert.ToDouble(ana.parametre.M_GNL_LISTELERIN_GUNFARKI));
            date_son.DateTime = DateTime.Now;
            islem.TasarimGetir(gv_banka, ana._Kullanici.ID, this.Name, grid_banka.Name);
            islem.IsyeriListesiDoldur(ck_isyeri,ana.lk_firma.EditValue.ToString());
            List<L_BNCARD> banka = listeler.BankaGetir(ana.lk_firma.EditValue.ToString());
            checkedComboBoxEdit1.Properties.DisplayMember = "HESAP";
            checkedComboBoxEdit1.Properties.ValueMember = "LOGICALREF";
            checkedComboBoxEdit1.Properties.DataSource = banka;
            checkedComboBoxEdit1.CheckAll();
            ck_isyeri.CheckAll(); 
        }
       
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ck_isyeri.EditValue.ToString()))
            {
                XtraMessageBox.Show("İşyeri Kısmı Boş Bırakılamaz ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ck_isyeri.Focus();return;
            }
            if (string.IsNullOrWhiteSpace(checkedComboBoxEdit1.EditValue.ToString()))
            {
                XtraMessageBox.Show("Banka Seçim Kısmı Boş Bırakılamaz ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                checkedComboBoxEdit1.Focus(); return;
            }
            ListeYenile();
        }
        public void ListeYenile() 
        {
            string[] selected = checkedComboBoxEdit1.EditValue.ToString().Split(',');
            string secilen = "";
            for (int i = 0; i < selected.Count(); i++)
            {
                secilen += selected[i].Trim() + ",";
            }
            if (selected.Count() != 0)
            {
                secilen = secilen.Remove(secilen.Length - 1, 1);
            }
            string[] isyerisecilen = ck_isyeri.EditValue.ToString().Split(',');
            string isyerisecilenliste = "";
            for (int i = 0; i < isyerisecilen.Count(); i++)
            {
                isyerisecilenliste += isyerisecilen[i].Trim() + ",";
            }
            if (isyerisecilen.Count() != 0)
            {
                isyerisecilenliste = isyerisecilenliste.Remove(isyerisecilenliste.Length - 1, 1);
            }
            
            if (Convert.ToBoolean(checkEdit1.Checked) == true)
            {
                liste = listeler.BankaHareketGetirYuruyensiz(ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString(), date_ilk.DateTime.ToString("yyyy-MM-dd"), date_son.DateTime.ToString("yyyy-MM-dd"), secilen);
            }
            else
            {
                liste = listeler.BankaHareketGetir(ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString(), date_ilk.DateTime.ToString("yyyy-MM-dd"), date_son.DateTime.ToString("yyyy-MM-dd"), secilen, isyerisecilenliste);
            }
            grid_banka.DataSource = liste;
            grid_banka.RefreshDataSource();
            grid_banka.Refresh();
        }

        private void tASARIMIKAYDETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            islem.TasarimKaydet(gv_banka,ana._Kullanici.ID,this.Name,grid_banka.Name);
            XtraMessageBox.Show("Tasarım Kaydedildi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pDFAKTARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listeler.pdfAktar(grid_banka);
        }

        private void eXCELAKTARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listeler.excelAktar(grid_banka);
        }

        private void yazdırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listeler.yazdir(grid_banka);
        }

        private void cariBilgiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gv_banka.RowCount > 0)
            {
                LOGO_XERO_BANKA_HAREKET row = (LOGO_XERO_BANKA_HAREKET)gv_banka.GetFocusedRow();
                if (row.CARIUNVANI != null && row.CARIUNVANI != "")
                {
                    frmDetayBilgi dt = new frmDetayBilgi();
                    string code = row.CARILOG.ToString();
                    dt.tip = 1;
                    dt.Text = row.CARIUNVANI.ToString() + " İsimli Carinin Bakiye Durumu ";
                    dt.carikod  = code;
                    dt.Yenile();
                    dt.Show();
                }
                else
                {
                    XtraMessageBox.Show("Kayıtlı Cari Bilgisi Yoktur ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void cariEkstreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gv_banka.RowCount > 0)
            {
                LOGO_XERO_BANKA_HAREKET row = (LOGO_XERO_BANKA_HAREKET)gv_banka.GetFocusedRow();
                if (row.CARIUNVANI != null && row.CARIUNVANI != "")
                {
                    frmCariEkstre dt = new frmCariEkstre(row.CARIUNVANI,row.CARIKODU);
                    string code = row.CARIKODU.ToString();
                    dt.Text = row.CARIUNVANI.ToString() + " İsimli Carinin Ekstresi "; 
                    dt.Yenile();
                    dt.Show();
                }
                else
                {
                    XtraMessageBox.Show("Kayıtlı Cari Bilgisi Yoktur ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void frmBankaHareketleri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                simpleButton1_Click(sender,e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.F4)
            {
                grid_banka.ShowPrintPreview();
            }
        }

        private void frmBankaHareketleri_Load(object sender, EventArgs e)
        {

        }
    }
}