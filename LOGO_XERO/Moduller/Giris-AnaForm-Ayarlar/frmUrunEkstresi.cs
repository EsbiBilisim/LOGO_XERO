using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using LOGO_XERO.Models.StokEkstresi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGO_XERO.Moduller.Giris_AnaForm_Ayarlar
{
    public partial class frmUrunEkstresi : DevExpress.XtraEditors.XtraForm
    {
        Islemler islem = new Islemler();
        frmAnaForm ana;
        string stokkodu = "";
        public frmUrunEkstresi(string _stokkodu,string _stokadi)
        {
            InitializeComponent();
            lbl_StokKodu.Text = _stokkodu;
            lbl_StokAdi.Text = _stokadi;
            stokkodu = _stokkodu;
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
        }
        public void TumTasarimlariGetir()
        {
            islem.TasarimGetir(gv_teklifler, ana._Kullanici.ID, this.Name, grid_teklifler.Name);
            islem.TasarimGetir(gv_alissip, ana._Kullanici.ID, this.Name, grid_AlisSiparis.Name);
            islem.TasarimGetir(gv_satissip, ana._Kullanici.ID, this.Name, grid_satissip.Name);
            islem.TasarimGetir(gv_satisfat, ana._Kullanici.ID, this.Name, grid_satisfat.Name);
            islem.TasarimGetir(gv_alisfat, ana._Kullanici.ID, this.Name, grid_alisfat.Name);
        }
        public void ListeGetir()
        {

            List<TEKLIF_LISTESI_M> resultteklif = islem.urunteklifgetir(ana.lk_firma.EditValue.ToString(), stokkodu);
            List<SIPARIS_LISTESI_M> resultsatissip = islem.StokSiparisListe(stokkodu, ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString(), 1);
            List<SIPARIS_LISTESI_M> resultalissip = islem.StokSiparisListe(stokkodu, ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString(), 2);
            List<FATURA_LISTESI_M> resultsatisfat = islem.StokFaturaListe(stokkodu, ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString(), "7,8");
            List<FATURA_LISTESI_M> resultalisfat = islem.StokFaturaListe(stokkodu, ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString(), "1");


            grid_teklifler.DataSource = resultteklif;
            grid_satissip.DataSource = resultsatissip;
            grid_AlisSiparis.DataSource = resultalissip;
            grid_satisfat.DataSource = resultsatisfat;
            grid_alisfat.DataSource = resultalisfat;

            grid_teklifler.RefreshDataSource();
            grid_teklifler.Refresh();

            grid_satissip.RefreshDataSource();
            grid_satissip.Refresh();

            grid_AlisSiparis.RefreshDataSource();
            grid_AlisSiparis.Refresh();

            grid_satisfat.RefreshDataSource();
            grid_satisfat.Refresh();

            grid_alisfat.RefreshDataSource();
            grid_alisfat.Refresh();
            TumTasarimlariGetir();
        }
        private void frmUrunEkstresi_Load(object sender, EventArgs e)
        {
            ListeGetir();
            
        }
        private void tasarımıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            islem.TasarimKaydet(gv_teklifler, ana._Kullanici.ID, this.Name, grid_teklifler.Name);
            islem.TasarimKaydet(gv_alisfat, ana._Kullanici.ID, this.Name, grid_alisfat.Name);
            islem.TasarimKaydet(gv_satisfat, ana._Kullanici.ID, this.Name, grid_satisfat.Name);
            islem.TasarimKaydet(gv_alissip, ana._Kullanici.ID, this.Name, grid_AlisSiparis.Name);
            islem.TasarimKaydet(gv_satissip, ana._Kullanici.ID, this.Name, grid_satissip.Name);
            XtraMessageBox.Show("Tasarım Başarıyla Kaydedildi");

        }
    }
}