using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.Parameters;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using LOGO_XERO.Models.GenelKullanim;
using LOGO_XERO.Models.LOGO_M;
using LOGO_XERO.Moduller._1_TeklifModul;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGO_XERO.Moduller.Giris_AnaForm_Ayarlar
{
    public partial class frmAnaDashBoard : DevExpress.XtraEditors.XtraForm
    {
        frmAnaForm ana;
        Islemler islem = new Islemler(); 
        string firma, donem; 
        
        public frmAnaDashBoard()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            firma = ana.lk_firma.EditValue.ToString();
            donem = ana.lk_donem.EditValue.ToString();
         
        }
        public void SayilariGetir() 
        {
            DolarEuroDoldur();
            AdetleriDoldur(); 
        }
        private void frmAnaDashBoard_Load(object sender, EventArgs e)
        { 
            EkrandakiTicketleraSayiGetir();
            ListeleDuyuru();
            SayilariGetir();
        }

        public void DolarEuroDoldur()
        { 
            L_CAPIFIRM firmabilg = islem.FirmaBilgileriGetir(ana.lk_firma.EditValue.ToString());

            chartControl3.Series.Clear();

            Series seriesusd = new Series("USD", ViewType.Line); //1
            Series seriesdolar = new Series("EURO", ViewType.Line);  //20


            for (int i = 0; i < 30; i++)
            {
                seriesusd.Points.Add(new SeriesPoint(Convert.ToDateTime(DateTime.Now.AddDays(-i)), Convert.ToDouble(islem.RatesTarihDovizKuruDondur(ana.parametre, firmabilg, 1, DateTime.Now.AddDays(-i), firma, donem))));
                seriesdolar.Points.Add(new SeriesPoint(Convert.ToDateTime(DateTime.Now.AddDays(-i)), Convert.ToDouble(islem.RatesTarihDovizKuruDondur(ana.parametre, firmabilg, 20, DateTime.Now.AddDays(-i), firma, donem))));
            }

            chartControl3.Series.Add(seriesusd);
            chartControl3.Series.Add(seriesdolar);
        }
        public void AdetleriDoldur()
        {
            using (LogoContext db = new LogoContext())
            {
                 
                List<KODAD> result =islem.AnaEkranDashAdetGetir(firma,donem);
                double[] faturaalis = new double[1];
                double[] faturasatis = new double[1];
                double[] siparisalis = new double[1];
                double[] siparissatis = new double[1];
                double[] onaylananteklifalis = new double[1];
                double[] onaylananteklifsatis = new double[1];
                double[] teklifalis = new double[1];
                double[] teklifsatis = new double[1];

                faturaalis[0] = Convert.ToDouble(result.FirstOrDefault(s=>s.NAME== "FATURAALIS").CODE);
                faturasatis[0] = Convert.ToDouble(result.FirstOrDefault(s => s.NAME == "FATURASATIS").CODE);
                siparisalis[0] = Convert.ToDouble(result.FirstOrDefault(s => s.NAME == "SIPARISALIS").CODE);
                siparissatis[0] = Convert.ToDouble(result.FirstOrDefault(s => s.NAME == "SIPARISSATIS").CODE);
                onaylananteklifalis[0] = Convert.ToDouble(result.FirstOrDefault(s => s.NAME == "ALISTEKLIFONAYLANAN").CODE);
                onaylananteklifsatis[0] = Convert.ToDouble(result.FirstOrDefault(s => s.NAME == "SATISTEKLIFONAYLANAN").CODE);
                teklifalis[0] = Convert.ToDouble(result.FirstOrDefault(s => s.NAME == "ALISTEKLIF").CODE);
                teklifsatis[0] = Convert.ToDouble(result.FirstOrDefault(s => s.NAME == "SATISTEKLIF").CODE);

                // POİNTS 0 = FATURA --> 1 = SİPARİS --> 2 = ONAYLANAN TEKLİF --> 3 = VERİLEN TEKLİF 

                chartControl2.Series["Series 1"].Points[0].Values = faturaalis;
                chartControl2.Series["Series 1"].Points[1].Values = faturasatis;
                chartControl2.Series["Series 1"].Points[2].Values = siparisalis;
                chartControl2.Series["Series 1"].Points[3].Values = siparissatis;
                chartControl2.Series["Series 1"].Points[4].Values = onaylananteklifalis;
                chartControl2.Series["Series 1"].Points[5].Values = onaylananteklifsatis;
                chartControl2.Series["Series 1"].Points[6].Values = teklifalis;
                chartControl2.Series["Series 1"].Points[7].Values = teklifsatis;

            }
        }
        public void ListeleDuyuru() 
        {
            using (LogoContext db = new LogoContext())
            {
                grid_anadash.DataSource= db.LOGO_XERO_DUYURULAR.Where(s=>s.IPTALID == 0).ToList();
                grid_anadash.RefreshDataSource();
                grid_anadash.Refresh();
            }
        }
        private void btn_onaybekleyenTeklif_Click(object sender, EventArgs e)
        {
            frmOnayBekleyenTeklifListesi frm1 = (frmOnayBekleyenTeklifListesi)Application.OpenForms["frmOnayBekleyenTeklifListesi"];
            if (frm1 != null)
            {
                frm1.ListeyiDoldur();
                frm1.Focus();
            }
            else
            {
                frmOnayBekleyenTeklifListesi frm = new frmOnayBekleyenTeklifListesi();
                frm.MdiParent = ana;
                frm.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 5000; i++)
            {
                if (i == 4999)
                {
                    EkrandakiTicketleraSayiGetir();
                }
            }
        }

        private void frmAnaDashBoard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                frmAnaDashBoard_Load(sender,e);
            }
        }

        private void chartControl3_Click(object sender, EventArgs e)
        {

        }

        public void EkrandakiTicketleraSayiGetir()
        {
            List<KODAD> veriler = islem.AnaEkranAdetListesi(firma, donem, ana._Kullanici.ID);
            btn_AktifMusteriSayisi.Text = "Aktif Müşteri Sayısı - " + veriler.Where(s => s.NAME == "AMS").FirstOrDefault().CODE.ToString();
            btn_OnayBekleyenAlisSiparisleri.Text = "Onay Bekleyen Alış Siparişleri - " + veriler.Where(s => s.NAME == "OBAS").FirstOrDefault().CODE.ToString();
            btn_onayBekleyenSatisSiparisleri.Text = "Onay Bekleyen Satış Siparişleri - " + veriler.Where(s => s.NAME == "OBSS").FirstOrDefault().CODE.ToString();
            btn_onaybekleyenTeklif.Text = "Onay Bekleyen Teklifler - " + veriler.Where(s => s.NAME == "OT").FirstOrDefault().CODE.ToString();
            timer1.Enabled = true;
        }
    }
}