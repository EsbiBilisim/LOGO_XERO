using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using LOGO_XERO.Models.GenelKullanim;
using LOGO_XERO.Models.LOGO_XERO_M;
using LOGO_XERO.Models.LOGO_XERO_M.LOGO_XERO_M;
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
    public partial class frmOnayBekleyenTeklifListesi : DevExpress.XtraEditors.XtraForm
    {
        Islemler islem = new Islemler();
        frmAnaForm ana;
        public string firma, donem;
        LOGO_XERO_PARAMETRELER parametre = new LOGO_XERO_PARAMETRELER();
        public frmOnayBekleyenTeklifListesi()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            islem.TasarimGetir(gv_OnayBekleyenTeklifListesi, ana._Kullanici.ID, this.Name, grid_OnayBekleyenTeklifListesi.Name);
            LookUpDoldur();
        }
        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grid_OnayBekleyenTeklifListesi_DoubleClick(sender, e);
        }
        private void grid_OnayBekleyenTeklifListesi_DoubleClick(object sender, EventArgs e)
        {
            LOGO_XERO_TEKLIF_BASLIK row = (LOGO_XERO_TEKLIF_BASLIK)gv_OnayBekleyenTeklifListesi.GetFocusedRow();
            if (row != null)
            {

                string[] kontrol = islem.LockKontrol(1, ana._Kullanici.ID);
                if (kontrol[0] != "true")
                {
                    DialogResult dr = XtraMessageBox.Show("Bu Fiş " + kontrol[1] + " Tarafından İşlem Görüyor!", "", MessageBoxButtons.OK);
                    return;
                }

                int id = row.ID;
                int trkod = row.TRCODE;
                frmTeklifOlustur teklifOlustur = new frmTeklifOlustur(id, Convert.ToDateTime(row.TARIH));
                teklifOlustur.Trkod = trkod;
                teklifOlustur.MdiParent = ana;
                teklifOlustur.Show();
            }
        }

        private void tasarımKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            islem.TasarimKaydet(gv_OnayBekleyenTeklifListesi, ana._Kullanici.ID, this.Name, grid_OnayBekleyenTeklifListesi.Name);
            XtraMessageBox.Show("Tasarım Başarıyla Kaydedildi");
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            grid_OnayBekleyenTeklifListesi.ShowPrintPreview();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ListeyiDoldur();
        }

        private void frmOnayBekleyenTeklifListesi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                simpleButton1_Click(sender, e);
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
            islem.PersonelListesiDoldur(rpOnaylayan);
        }

        private void frmOnayBekleyenTeklifListesi_Load(object sender, EventArgs e)
        {
            ListeyiDoldur();
        }

        public void ListeyiDoldur()
        {
            using (LogoContext db = new LogoContext())
            {
                if (ck_TumOnayBekleyenleriGetir.Checked)
                {
                    grid_OnayBekleyenTeklifListesi.DataSource = db.LOGO_XERO_TEKLIF_BASLIK.Where(s => (s.ONAYDURUMU == 1 || s.ONAYDURUMU == 3) && s.ONAYAGONDERIM == 1).ToList();
                }
                else
                {
                    grid_OnayBekleyenTeklifListesi.DataSource = db.LOGO_XERO_TEKLIF_BASLIK.Where(s => (s.ONAYDURUMU == 1 || s.ONAYDURUMU==3) && s.ONAYLAYANID == ana._Kullanici.ID && s.ONAYAGONDERIM==1).ToList();
                }
              
                grid_OnayBekleyenTeklifListesi.Refresh();
                grid_OnayBekleyenTeklifListesi.RefreshDataSource();
            }
        }
    }
}