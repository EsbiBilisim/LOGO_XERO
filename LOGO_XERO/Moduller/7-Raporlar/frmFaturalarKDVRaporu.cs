using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace LOGO_XERO.Moduller._7_Raporlar
{
    public partial class frmFaturalarKDVRaporu : DevExpress.XtraEditors.XtraForm
    {
        Islemler islem = new Islemler();
        frmAnaForm ana;
        List<LOGO_XERO_FATURA_KDV_RAPORU> liste;
        Logic.GenelListeler listeler = new Logic.GenelListeler();
        string trcdode;
        public int tip; 
        public frmFaturalarKDVRaporu(string _trcode)
        {
            InitializeComponent(); 
            trcdode = _trcode;
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            date_ilk.DateTime = DateTime.Now.AddDays(-Convert.ToDouble(ana.parametre.M_GNL_LISTELERIN_GUNFARKI));
            date_son.DateTime = DateTime.Now;
            isyerigetir();
            ck_isyeri.CheckAll();
            if (trcdode == "1,4,5,6,13,26")
            {
                tip = 2;
                islem.TasarimGetir(gv_kdvraporalis, ana._Kullanici.ID, this.Name, grid_kdvraporalis.Name);
            }
            else
            {
                tip = 1;
                islem.TasarimGetir(gv_kdvraporsatis, ana._Kullanici.ID, this.Name, grid_kdvraporsatis.Name);
            }
        } 

        public void isyerigetir() 
        {
            islem.IsyeriListesiDoldur(ck_isyeri,ana.lk_firma.EditValue.ToString());
        }
        public void Yenile() 
        {
            string[] selected = ck_isyeri.EditValue.ToString().Split(',');
            string secilen = "";
            for (int i = 0; i < selected.Count(); i++)
            {
                secilen += selected[i].Trim() + ",";
            }
            if (selected.Count() != 0)
            {
                secilen = secilen.Remove(secilen.Length - 1, 1);
            }
            liste = listeler.FaturaKDVRaporuGetir(ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString(), trcdode, date_ilk.DateTime.ToString("yyyy-MM-dd"), date_son.DateTime.ToString("yyyy-MM-dd"), secilen);
            if (tip == 1)
            {
                grid_kdvraporsatis.DataSource = liste;
                grid_kdvraporsatis.RefreshDataSource();
                grid_kdvraporsatis.Refresh();
                grid_kdvraporsatis.Visible = true;
                grid_kdvraporalis.Visible = false;
            }
            else
            {
                grid_kdvraporalis.DataSource = liste;
                grid_kdvraporalis.RefreshDataSource();
                grid_kdvraporalis.Refresh();
                grid_kdvraporsatis.Visible = false;
                grid_kdvraporalis.Visible = true;
            }
           


        }

        private void btn_filtre_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ck_isyeri.EditValue.ToString()))
            {
                XtraMessageBox.Show("İSYERİ BOŞ BIRAKILAMAZ !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ck_isyeri.Focus();
                return;
            }
            Yenile();
        }

        private void frmAlisFaturalarıKDV_Load(object sender, EventArgs e)
        { 
        }

        private void tasarımıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            islem.TasarimKaydet(gv_kdvraporalis,ana._Kullanici.ID,this.Name,grid_kdvraporalis.Name);
            XtraMessageBox.Show("Tasarım Kaydedildi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void excelAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listeler.excelAktar(grid_kdvraporalis);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            listeler.excelAktar(grid_kdvraporsatis);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            islem.TasarimKaydet(gv_kdvraporsatis, ana._Kullanici.ID, this.Name, grid_kdvraporsatis.Name);
            XtraMessageBox.Show("Tasarım Kaydedildi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cariBilgiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gv_kdvraporalis.RowCount > 0)
            {
                LOGO_XERO_FATURA_KDV_RAPORU row = (LOGO_XERO_FATURA_KDV_RAPORU)gv_kdvraporalis.GetFocusedRow();
                frmDetayBilgi dt = new frmDetayBilgi();
                if (row.CARIUNVANI != null)
                {
                    string code = row.CARILOG.ToString();
                    dt.tip = 1;
                    dt.Text = row.CARIUNVANI.ToString() + " İsimli Carinin Bakiye Durumu ";
                    dt.carikod = code;
                    dt.Yenile();
                    dt.Show();
                }
                else
                {
                    XtraMessageBox.Show("Kayıtlı Cari Bilgisi Yoktur ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (gv_kdvraporsatis.RowCount > 0)
            {
                LOGO_XERO_FATURA_KDV_RAPORU row = (LOGO_XERO_FATURA_KDV_RAPORU)gv_kdvraporsatis.GetFocusedRow();
                frmDetayBilgi dt = new frmDetayBilgi();
                if (row.CARIUNVANI != null)
                {
                    string code = row.CARILOG.ToString();
                    dt.tip = 1;
                    dt.Text = row.CARIUNVANI.ToString() + " İsimli Carinin Bakiye Durumu ";
                    dt.carikod = code;
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
            if (gv_kdvraporalis.RowCount > 0)
            {
                LOGO_XERO_FATURA_KDV_RAPORU row = (LOGO_XERO_FATURA_KDV_RAPORU)gv_kdvraporalis.GetFocusedRow();
                frmCariEkstre dt = new frmCariEkstre(row.CARIUNVANI,row.CARIKODU);
                if (row.CARIUNVANI != null)
                {
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

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (gv_kdvraporsatis.RowCount > 0)
            {
                LOGO_XERO_FATURA_KDV_RAPORU row = (LOGO_XERO_FATURA_KDV_RAPORU)gv_kdvraporsatis.GetFocusedRow();
                frmCariEkstre dt = new frmCariEkstre(row.CARIUNVANI,row.CARIKODU);
                if (row.CARIUNVANI != null)
                {
                    string code = row.CARIKODU.ToString();
                    dt.Text = row.CARIUNVANI.ToString() + " İsimli Carinin Ekstresi ";
                    dt.carikod = code;
                    dt.Yenile();
                    dt.Show();
                }
                else
                {
                    XtraMessageBox.Show("Kayıtlı Cari Bilgisi Yoktur ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void frmFaturalarKDVRaporu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                btn_filtre_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.F4)
            {
                if (grid_kdvraporalis.Visible == true)
                {
                    grid_kdvraporalis.ShowPrintPreview();
                }
                else
                {
                    grid_kdvraporsatis.ShowPrintPreview();
                }
                
            }
        }
    }
}