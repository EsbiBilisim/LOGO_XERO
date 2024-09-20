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
    public partial class frmKasaHareketleri : DevExpress.XtraEditors.XtraForm
    {
        Islemler islem = new Islemler();
        Logic.GenelListeler listeler = new Logic.GenelListeler();
        frmAnaForm ana;
        List<LOGO_XERO_KASA_HAREKET> liste;
        public frmKasaHareketleri()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            islem.TasarimGetir(gv_kasa, ana._Kullanici.ID, this.Name, grid_kasa.Name);
            islem.IsyeriListesiDoldur(ck_isyeri,ana.lk_firma.EditValue.ToString());
            ck_isyeri.CheckAll();
            date_ilk.DateTime = DateTime.Now.AddDays(-Convert.ToDouble(ana.parametre.M_GNL_LISTELERIN_GUNFARKI));
            date_son.DateTime = DateTime.Now;
            List<L_KSCARD> kasa = listeler.KasaGetir(ana.lk_firma.EditValue.ToString());
            combokasa.Properties.DisplayMember = "NAME";
            combokasa.Properties.ValueMember = "CODE";
            combokasa.Properties.DataSource = kasa;
            combokasa.CheckAll(); 
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ck_isyeri.EditValue.ToString()) && !string.IsNullOrWhiteSpace(combokasa.EditValue.ToString()))
            {
                ListeYenile();
            }
            else
            {
                MessageBox.Show("İş Yeri veya Kasa Seçimi Boş Bırakılamaz!");
            }
        }
        

        public void ListeYenile() 
        {
            string[] selected = combokasa.EditValue.ToString().Split(',');
            string secilen = "";
            for (int i = 0; i < selected.Count(); i++)
            {
                secilen += "'" + selected[i].Trim() + "',";
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
                liste = listeler.KasaHareketGetirYürüyensiz(ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString(), date_ilk.DateTime.ToString("yyyy-MM-dd"), date_son.DateTime.ToString("yyyy-MM-dd"), secilen);

            }
            else
            {

                liste = listeler.KasaHareketGetir(ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString(), date_ilk.DateTime.ToString("yyyy-MM-dd"), date_son.DateTime.ToString("yyyy-MM-dd"), secilen, isyerisecilenliste);
            }
            grid_kasa.DataSource = liste;
            grid_kasa.RefreshDataSource();
            grid_kasa.Refresh();
        }

        private void tASARIMIKAYDETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            islem.TasarimKaydet(gv_kasa,ana._Kullanici.ID,this.Name,grid_kasa.Name);
            XtraMessageBox.Show("Tasarım Kaydedildi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pDFAKTARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listeler.pdfAktar(grid_kasa);
        }

        private void eXCELAKTARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listeler.excelAktar(grid_kasa);
        }

        private void yazdırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listeler.yazdir(grid_kasa);
        }

        private void frmKasaHareketleri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                simpleButton1_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.F4)
            {
                grid_kasa.ShowPrintPreview();
            }
        }

        private void frmKasaHareketleri_Load(object sender, EventArgs e)
        {

        }
    }
}