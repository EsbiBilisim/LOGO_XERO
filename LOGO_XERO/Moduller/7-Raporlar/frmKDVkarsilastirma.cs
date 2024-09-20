using DevExpress.Xpo.Helpers;
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
    public partial class frmKDVkarsilastirma : DevExpress.XtraEditors.XtraForm
    {
        frmAnaForm ana;
        Logic.GenelListeler listeler = new Logic.GenelListeler();
        Islemler islem = new Islemler();
        List<LOGO_XERO_KDV_RAPOR_KARSILASTIRMA> alislistesi;
        List<LOGO_XERO_KDV_RAPOR_KARSILASTIRMA> satislistesi;
        public frmKDVkarsilastirma()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            islem.TasarimGetir(gv_kdvkarsilastirmaalis, ana._Kullanici.ID, this.Name, grid_kdvkarsilastirmaalis.Name);
            islem.TasarimGetir(gv_karsilastirmasatis, ana._Kullanici.ID, this.Name, grid_kdvkarsilastirmasatis.Name);
            date_ilk.DateTime = DateTime.Now.AddDays(-Convert.ToDouble(ana.parametre.M_GNL_LISTELERIN_GUNFARKI));
            date_son.DateTime = DateTime.Now;
            islem.IsyeriListesiDoldur(ck_isyeri,ana.lk_firma.EditValue.ToString());
            ck_isyeri.CheckAll(); 
        } 
        public void Yenile() {
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

            alislistesi = listeler.FatKdvKarsilastirma(ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString(), "(O.TRCODE IN (1,4,5,26,2,3) OR (O.TRCODE=13 AND O.DECPRDIFF=0) OR (O.TRCODE=14 AND O.DECPRDIFF=1))", date_ilk.DateTime.ToString("yyyy-MM-dd"), date_son.DateTime.ToString("yyyy-MM-dd"), secilen);
            satislistesi = listeler.FatKdvKarsilastirma(ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString(), "(O.TRCODE IN (7,8,9,10,14,6) OR (O.TRCODE=13 AND O.DECPRDIFF=1) OR (O.TRCODE=14 AND O.DECPRDIFF=0))", date_ilk.DateTime.ToString("yyyy-MM-dd"), date_son.DateTime.ToString("yyyy-MM-dd"), secilen);

            grid_kdvkarsilastirmaalis.DataSource = alislistesi;
            grid_kdvkarsilastirmaalis.RefreshDataSource();
            grid_kdvkarsilastirmaalis.Refresh();

            grid_kdvkarsilastirmasatis.DataSource = satislistesi;
            grid_kdvkarsilastirmasatis.RefreshDataSource();
            grid_kdvkarsilastirmasatis.Refresh();

        }
         

        private void tasarımıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            islem.TasarimKaydet(gv_kdvkarsilastirmaalis,ana._Kullanici.ID,this.Name,grid_kdvkarsilastirmaalis.Name);
            XtraMessageBox.Show("Tasarım Kaydedildi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void con_satis_Opening(object sender, CancelEventArgs e)
        {
           
        }

        private void btn_filtre_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ck_isyeri.EditValue.ToString()))
            {
                Yenile();
            }
            else
            {
                XtraMessageBox.Show("İşyeri Kısmı Boş Bırakılamaz ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void excelAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listeler.excelAktar(grid_kdvkarsilastirmaalis);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            listeler.excelAktar(grid_kdvkarsilastirmasatis);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (gv_karsilastirmasatis.RowCount > 0)
            {
                LOGO_XERO_KDV_RAPOR_KARSILASTIRMA row = (LOGO_XERO_KDV_RAPOR_KARSILASTIRMA)gv_karsilastirmasatis.GetFocusedRow();
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

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (gv_karsilastirmasatis.RowCount > 0)
            {
                LOGO_XERO_KDV_RAPOR_KARSILASTIRMA row = (LOGO_XERO_KDV_RAPOR_KARSILASTIRMA)gv_karsilastirmasatis.GetFocusedRow();
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

        private void cariBilgiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gv_kdvkarsilastirmaalis.RowCount > 0)
            {
                LOGO_XERO_KDV_RAPOR_KARSILASTIRMA row = (LOGO_XERO_KDV_RAPOR_KARSILASTIRMA)gv_kdvkarsilastirmaalis.GetFocusedRow();
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
            if (gv_kdvkarsilastirmaalis.RowCount > 0)
            {
                LOGO_XERO_KDV_RAPOR_KARSILASTIRMA row = (LOGO_XERO_KDV_RAPOR_KARSILASTIRMA)gv_kdvkarsilastirmaalis.GetFocusedRow();
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            islem.TasarimKaydet(gv_karsilastirmasatis, ana._Kullanici.ID, this.Name, grid_kdvkarsilastirmasatis.Name);
            XtraMessageBox.Show("Tasarım Kaydedildi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmKDVkarsilastirma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                btn_filtre_Click_1(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            } 
        }

        private void frmKDVkarsilastirma_Load(object sender, EventArgs e)
        {

        }
    }
}