using DevExpress.CodeParser;
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

namespace LOGO_XERO.Moduller._7_Raporlar
{
    public partial class frmMusteriKrediKrtHareket : DevExpress.XtraEditors.XtraForm
    {
        Islemler islem = new Islemler();
        Logic.GenelListeler listeler = new Logic.GenelListeler();
        List<LOGO_XERO_KREDI_KART_HAREKET> liste;
        frmAnaForm ana;
        public frmMusteriKrediKrtHareket()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            date_ilk.DateTime = DateTime.Now.AddDays(-Convert.ToDouble(ana.parametre.M_GNL_LISTELERIN_GUNFARKI));
            date_son.DateTime = DateTime.Now;
            pivotkredikart.Visible = false;
            checkEdit1.Checked = false;
            islem.IsyeriListesiDoldur(ck_isyeri, ana.lk_firma.EditValue.ToString());
            listeler.KREDI_KART_HAREKET_PROCEDURE_OLUSTUR(ana.lk_firma.EditValue.ToString());
            ck_isyeri.CheckAll(); 
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
            {
                pivotkredikart.Visible = true;
                gridkredikart.Visible = false;
                pivotkredikart.DataSource = liste;
                pivotkredikart.Enabled = true; 
            }
            else
            {
                pivotkredikart.Visible = false;
                gridkredikart.Visible = true;
                gridkredikart.DataSource = liste;
                gridkredikart.Enabled = true; 
            }
        }
       
        public void ListeYenile() 
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
            liste = listeler.KrediKartiHareket(ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString(), "70", date_ilk.DateTime.ToString("yyyy-MM-dd"), date_son.DateTime.ToString("yyyy-MM-dd"), secilen);
            if (checkEdit1.Checked)
            {
                pivotkredikart.Visible = true;
                gridkredikart.Visible = false;
                pivotkredikart.DataSource = liste;
                pivotkredikart.Enabled = true;
                listeler.TasarimGetirPivot(pivotkredikart, ana._Kullanici.ID, this.Name, pivotkredikart.Name);
            }
            else
            {
                pivotkredikart.Visible = false;
                gridkredikart.Visible = true;
                gridkredikart.DataSource = liste;
                gridkredikart.Enabled = true;
                islem.TasarimGetir(gv_kredi, ana._Kullanici.ID, this.Name, gridkredikart.Name);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ck_isyeri.EditValue.ToString()))
            {
                XtraMessageBox.Show("İşyeri Kısmı Boş Olamaz ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ck_isyeri.Focus();return;
            }
            ListeYenile();
        }

        private void cariBilgiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gv_kredi.RowCount > 0)
            {
                LOGO_XERO_KREDI_KART_HAREKET row = (LOGO_XERO_KREDI_KART_HAREKET)gv_kredi.GetFocusedRow();

                if (row.CARIAD != null && row.CARIAD != "")
                {
                    frmDetayBilgi dt = new frmDetayBilgi();
                    string code = row.CARILOG.ToString();
                    dt.tip = 1;
                    dt.Text = row.CARIAD.ToString() + " İsimli Carinin Bakiye Durumu ";
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
            if (gv_kredi.RowCount > 0)
            {
                LOGO_XERO_KREDI_KART_HAREKET row = (LOGO_XERO_KREDI_KART_HAREKET)gv_kredi.GetFocusedRow();


                if (row.CARIAD != null && row.CARIAD != "")
                {
                    frmCariEkstre dt = new frmCariEkstre(row.CARIAD,row.CARIKODU);
                    string code = row.CARIKODU.ToString();
                    dt.Text = row.CARIAD.ToString() + " İsimli Carinin Ekstresi ";
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
            islem.TasarimKaydet(gv_kredi,ana._Kullanici.ID,this.Name,gridkredikart.Name);
            XtraMessageBox.Show("Tasarım Kaydedildi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tASARIMIKAYDETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listeler.TasarimKaydetPivot(pivotkredikart,ana._Kullanici.ID,this.Name,pivotkredikart.Name);
            XtraMessageBox.Show("Tasarım Kaydedildi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            listeler.pdfAktar(gridkredikart);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            listeler.excelAktar(gridkredikart);
        }

        private void eXCELAKTARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listeler.excelAktarpivot(pivotkredikart);
        }

        private void frmMusteriKrediKrtHareket_KeyDown(object sender, KeyEventArgs e)
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
                if (pivotkredikart.Visible==true)
                {
                    pivotkredikart.ShowPrintPreview();
                }
                else if (gridkredikart.Visible==true)
                {
                    gridkredikart.ShowPrintPreview();
                }
            }
        }

        private void frmMusteriKrediKrtHareket_Load(object sender, EventArgs e)
        {

        }
    }
}