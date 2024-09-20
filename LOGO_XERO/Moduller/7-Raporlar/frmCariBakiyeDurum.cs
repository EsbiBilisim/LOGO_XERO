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
    public partial class frmCariBakiyeDurum : DevExpress.XtraEditors.XtraForm
    {
        frmAnaForm ana;
        Islemler islem = new Islemler();
        Logic.GenelListeler liste = new Logic.GenelListeler();
        public frmCariBakiyeDurum()
        {
            InitializeComponent();
            ana = (frmAnaForm)Application.OpenForms["frmAnaForm"];
            txtIlk.DateTime = DateTime.Now.AddDays(-Convert.ToInt32(ana.parametre.M_GNL_LISTELERIN_GUNFARKI));
            txtSon.DateTime = DateTime.Now;
            islem.TasarimGetir(gv_caribakdrm, ana._Kullanici.ID, this.Name, grid_caribakdrm.Name); 
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            grid_caribakdrm.DataSource = liste.Cari_Bakiye_Getir(ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString());
            grid_caribakdrm.RefreshDataSource();
            grid_caribakdrm.Refresh();
        }
        
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            grid_caribakdrm.ShowPrintPreview();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (gv_caribakdrm.RowCount > 0)
            {
                LOGO_XERO_CARI_BAKIYE row = (LOGO_XERO_CARI_BAKIYE)gv_caribakdrm.GetFocusedRow();
                frmDetayBilgi dt = new frmDetayBilgi();
                if (row.UNVAN != null)
                {
                    string code = row.LOGICALREF.ToString();
                    dt.tip = 1;
                    dt.Text = row.UNVAN.ToString() + " İsimli Carinin Bakiye Durumu ";
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

        private void tasarımıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            islem.TasarimKaydet(gv_caribakdrm,ana._Kullanici.ID,this.Name,grid_caribakdrm.Name);
            XtraMessageBox.Show("Tasarım Kaydedildi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void excelAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            liste.excelAktar(grid_caribakdrm);
        }

        private void pDFAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            liste.pdfAktar(grid_caribakdrm);
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grid_caribakdrm.DataSource = liste.Cari_Bakiye_Getir(ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString());
            grid_caribakdrm.RefreshDataSource();
            grid_caribakdrm.Refresh();
        }

        private void cariEkstreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gv_caribakdrm.RowCount > 0)
            {
                LOGO_XERO_CARI_BAKIYE row = (LOGO_XERO_CARI_BAKIYE)gv_caribakdrm.GetFocusedRow();

                frmCariEkstre dt = new frmCariEkstre(row.UNVAN,row.CARIKODU);
                if (row.UNVAN != null)
                {
                    string code = row.CARIKODU.ToString();
                    dt.Text = row.UNVAN.ToString() + " İsimli Carinin Ekstresi "; 
                    dt.Yenile();
                    dt.Show();
                }
                else
                {
                    XtraMessageBox.Show("Kayıtlı Cari Bilgisi Yoktur ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSon_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void frmCariBakiyeDurum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                simpleButton3_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.F4)
            {
                grid_caribakdrm.ShowPrintPreview();
            }
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmCariBakiyeDurum_Load(object sender, EventArgs e)
        {

        }
    }
}