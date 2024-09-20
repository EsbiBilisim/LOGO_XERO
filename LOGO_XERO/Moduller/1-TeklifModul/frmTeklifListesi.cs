using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using LOGO_XERO.Models.GenelKullanim;
using LOGO_XERO.Models.LOGO_M;
using LOGO_XERO.Models.LOGO_XERO_M;
using LOGO_XERO.Models.LOGO_XERO_M.LOGO_XERO_M;
using LOGO_XERO.Moduller.Giris_AnaForm_Ayarlar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace LOGO_XERO.Moduller._1_TeklifModul
{
    public partial class frmTeklifListesi : DevExpress.XtraEditors.XtraForm
    {
        Islemler islem = new Islemler();
        frmAnaForm ana;
        public string firma, donem;
        int isyeri;
        LOGO_XERO_PARAMETRELER parametre = new LOGO_XERO_PARAMETRELER();
        public frmTeklifListesi()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            firma = ana.lk_firma.EditValue.ToString();
            donem = ana.lk_donem.EditValue.ToString();
            parametre = ana.parametre;
            islem.TasarimGetir(gv_TeklifListesi, ana._Kullanici.ID, this.Name, grid_TeklifListesi.Name);
            LookUpDoldur();
        }
        private void satışTeklifiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool durum = islem.DovizKontrol(parametre, ana.firmaBilgisi, firma, donem);
            if (durum == false)
            {
                XtraMessageBox.Show("Günlük Döviz Kurları Boş !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmDovizKurGuncelleme frm = new frmDovizKurGuncelleme();
                frm.ShowDialog();
                ana.KurlariAnaEkranaGetir();
                return;
            }

            frmTeklifOlustur teklifOlustur = new frmTeklifOlustur();
            teklifOlustur.Trkod = 8;
            teklifOlustur.MdiParent = ana;
            teklifOlustur.Show();
        }

        private void satınAlmaTeklifiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool durum = islem.DovizKontrol(parametre, ana.firmaBilgisi, firma, donem);
            if (durum == false)
            {
                XtraMessageBox.Show("Günlük Döviz Kurları Boş !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmDovizKurGuncelleme frm = new frmDovizKurGuncelleme();
                frm.ShowDialog();
                ana.KurlariAnaEkranaGetir();
                return;
            }
            frmTeklifOlustur teklifOlustur = new frmTeklifOlustur();
            teklifOlustur.Trkod = 1;
            teklifOlustur.MdiParent = ana;
            teklifOlustur.Show();
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {


            LOGO_XERO_TEKLIF_BASLIK row = (LOGO_XERO_TEKLIF_BASLIK)gv_TeklifListesi.GetFocusedRow();
            if (row != null)
            {
                int id = row.ID;
                string[] kontrol = islem.LockKontrol(1, id);
                if (kontrol[0] != "true")
                {
                    DialogResult dr = XtraMessageBox.Show("Bu Fiş " + kontrol[1] + " Tarafından İşlem Görüyor!", "", MessageBoxButtons.OK);
                    return;
                }
             
                int trkod = row.TRCODE;
                frmTeklifOlustur teklifOlustur = new frmTeklifOlustur(id, Convert.ToDateTime(row.TARIH));
                teklifOlustur.Trkod = trkod;
                teklifOlustur.MdiParent = ana;
                islem.pageLock(1, id,ana._Kullanici.ID);
                teklifOlustur.Show();
            }

        }
        public void LookUpDoldur()
        {
            islem.LookUpTeklifTipDoldur(rpTur);
            islem.LookUpTeklifOnayDurumDoldur(rpOnaydurum);
            islem.TeklifDurumListesiDoldur(rpDurum);
            islem.TumAmbarListesiDoldur(lkambar, firma);
            islem.IsyeriListesiDoldur(lkisyeri, firma);
            islem.BolumListesiDoldur(rpbolum, firma);
            islem.OdemeTipleriDoldur(rpVade, firma);
            islem.LogoSatisElemaniDoldurDinamik(rpSatisElemani, firma);
        }
        private void frmTeklifListesi_Load(object sender, EventArgs e)
        {

            txtSon.DateTime = DateTime.Now;
            txtIlk.DateTime = DateTime.Now.AddDays(Convert.ToInt32(-parametre.M_GNL_LISTELERIN_GUNFARKI));


            ListeyiDoldur();
        }
        public void ListeyiDoldur()
        {
            DateTime son = txtSon.DateTime;
            DateTime ilk = txtIlk.DateTime;
            using (LogoContext db = new LogoContext())
            {
                List<LOGO_XERO_TEKLIF_BASLIK> liste = db.LOGO_XERO_TEKLIF_BASLIK.Where(s => s.TARIH <= son && s.TARIH >= ilk).ToList(); 
                grid_TeklifListesi.DataSource = liste;
                grid_TeklifListesi.Refresh();
                grid_TeklifListesi.RefreshDataSource();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            ListeyiDoldur();
        }
        private void tasarımKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            islem.TasarimKaydet(gv_TeklifListesi, ana._Kullanici.ID, this.Name, grid_TeklifListesi.Name);
            XtraMessageBox.Show("Tasarım Başarıyla Kaydedildi");
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTeklifListesi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.F4)
            {
                grid_TeklifListesi.ShowPrintPreview();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            grid_TeklifListesi.ShowPrintPreview();
        }

        private void gv_TeklifListesi_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //DevExpress.XtraGrid.Views.Grid.GridView currentView = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            //    if (e.Column.FieldName == "ONAYDURUMU")
            //    {
            //        int durum = 0;
            //        durum = Convert.ToInt32(currentView.GetRowCellValue(e.RowHandle, "ONAYDURUMU"));
            //    if (durum == 1)
            //        e.Appearance.BackColor = Color.Yellow; 
            //    else if (durum == 2)
            //        e.Appearance.BackColor = Color.LightGreen;
            //} 
        }

        private void gv_TeklifListesi_RowStyle(object sender, RowStyleEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView currentView = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (e.RowHandle >= 0)
            {
                string category = currentView.GetRowCellDisplayText(e.RowHandle, currentView.Columns["ONAYDURUMU"]);
                if (category == "ONAYLANDI")
                {
                    e.Appearance.BackColor = Color.LightGreen; 
                }
                else if (category == "ONAY BEKLİYOR")
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
                else if(category == "REDDEDİLDİ")
                    e.Appearance.BackColor = Color.Red;
            }
        }

        private void yeniTeklifToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void grid_TeklifListesi_DoubleClick(object sender, EventArgs e)
        {
            düzenleToolStripMenuItem_Click(sender, e);
        }
    }
}