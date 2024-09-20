using System;
using System.Collections.Generic;
using LOGO_XERO.Moduller._7_Raporlar;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using LOGO_XERO.Logic;
using LOGO_XERO.Models.CARI_CEKRISKBILGILERI;
using LOGO_XERO.Moduller._7_Raporlar.Tasarımlar;

namespace LOGO_XERO
{
    public partial class frmCekRiskBilgileri : DevExpress.XtraEditors.XtraForm
    {
        Islemler islem = new Islemler();
        public string kod, cariUnvan, ticariIslemGrubu;
        public int carilogicalref = 0;
        frmAnaForm ana;
        public string firma, donem;
        public frmCekRiskBilgileri()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            firma = ana.lk_firma.EditValue.ToString();
            donem = ana.lk_donem.EditValue.ToString();
        }
        private void frmCekRiskBilgileri_Load(object sender, EventArgs e)
        {
            //labelControl9.Text = "Satış " + DateTime.Now.Year.ToString();
        }
        public void CekListesi()
        {
            double sifir = 0;
            RISK_TUTARLAR RiskBilgileriGetir = islem.CariRiskBilgiEkraniRiskBilgileri(firma, donem, carilogicalref);
            List<YIL_SATISBILGILERI> yilSatisBilgiler = islem.CariRiskBilgiEkraniSatisYilGetir(firma, donem, carilogicalref);
            grid_YilSatisBilgileri.DataSource = yilSatisBilgiler;
            if (RiskBilgileriGetir != null)
            {
                txtMUSTERITAHSILEDILMEMISCEKCIRORISKI.Text = Convert.ToDouble(RiskBilgileriGetir.MUSTERITAHSILEDILMEMISCEKCIRORISKI).ToString("n2");
                txtKENDIODENMEMISCEKRISKIMIZ.Text = Convert.ToDouble(RiskBilgileriGetir.KENDIODENMEMISCEKRISKIMIZ).ToString("n2");
                txtCIROCEKSENETRISKTOPLAM.Text = Convert.ToDouble(RiskBilgileriGetir.CIROCEKSENETRISKTOPLAM).ToString("n2");
                txtACIKHESAPRISKI.Text = Convert.ToDouble(RiskBilgileriGetir.ACIKHESAPRISKI).ToString("n2");
                txtKrediToplami.Text = (Convert.ToDouble(txtMUSTERITAHSILEDILMEMISCEKCIRORISKI.Text) + Convert.ToDouble(txtKENDIODENMEMISCEKRISKIMIZ.Text) + Convert.ToDouble(txtCIROCEKSENETRISKTOPLAM.Text) + Convert.ToDouble(txtACIKHESAPRISKI.Text)).ToString("n2");
                double krediTop = Convert.ToDouble(txtMUSTERITAHSILEDILMEMISCEKCIRORISKI.Text) + Convert.ToDouble(txtKENDIODENMEMISCEKRISKIMIZ.Text) + Convert.ToDouble(txtCIROCEKSENETRISKTOPLAM.Text);

                txtSatisYil.Text = Convert.ToDouble(RiskBilgileriGetir.SATISTUTAR).ToString("n2");
                txtCekRiskKendi.Text = Convert.ToDouble(RiskBilgileriGetir.CEKRISKKENDI).ToString("n2");
                txtCekriskCiro.Text = Convert.ToDouble(RiskBilgileriGetir.CIROTUTAR).ToString("n2");
                txtOdenmemisCekler.Text = (Convert.ToDouble(txtCekRiskKendi.Text) + Convert.ToDouble(txtCekriskCiro.Text)).ToString("n2");
                txtRiskToplami.Text = (Convert.ToDouble(txtCekRiskKendi.Text) + Convert.ToDouble(txtCekriskCiro.Text) + Convert.ToDouble(txtBakiye.Text)).ToString("n2");
                double riskiAsanTutar = (-1 * ((Convert.ToDouble(RiskBilgileriGetir.ACIKHESAPRISKI) - (Convert.ToDouble(txtRiskToplami.Text)))));
                txtRiskiAsanTutar.Text = (riskiAsanTutar - krediTop).ToString("n2");
            }
            else
            {
                txtMUSTERITAHSILEDILMEMISCEKCIRORISKI.Text = sifir.ToString("n2");
                txtKENDIODENMEMISCEKRISKIMIZ.Text = sifir.ToString("n2");
                txtCIROCEKSENETRISKTOPLAM.Text = sifir.ToString("n2");
                txtSatisYil.Text = sifir.ToString("n2");
                txtCekriskCiro.Text = sifir.ToString("n2");
                txtACIKHESAPRISKI.Text = sifir.ToString("n2");
                txtRiskToplami.Text = sifir.ToString("n2");
                txtCekRiskKendi.Text = sifir.ToString("n2");
                txtOdenmemisCekler.Text = sifir.ToString("n2");
            }

            txtBakiye.Text = islem.CariRiskBilgileriCariBakiyeGetir(firma, donem, carilogicalref).ToString("n2");

            TEKLIF_BILGILERI_RISK teklifBilgileriRisk = islem.CariRiskBilgiEkraniTeklifBilgileri(firma, donem, carilogicalref);



            double teklifYuzde = (Convert.ToDouble(teklifBilgileriRisk.SIPARISEDONUSENTEKLIFSAYISI) * 100) / Convert.ToDouble(teklifBilgileriRisk.TEKLIFSAYISI);
            if (teklifYuzde == double.NaN || teklifYuzde.ToString() == "NaN")
            {
                teklifYuzde = 0;
            }
            chart1.Titles[0].Text = "Teklif Adet (%" + teklifYuzde.ToString("n0") + ")";

            double tutarYuzde = (Convert.ToDouble(teklifBilgileriRisk.SIPARISTUTARI) * 100) / Convert.ToDouble(teklifBilgileriRisk.TEKLIFTUTARI);
            if (tutarYuzde == double.NaN || tutarYuzde.ToString() == "NaN")
            {
                tutarYuzde = 0;
            }

            chart2.Titles[0].Text = "Teklif Tutar (%" + tutarYuzde.ToString("n0") + ")";

            double kalemYuzde = (Convert.ToDouble(teklifBilgileriRisk.SIPARISEDONENKALEMSAYISI) * 100) / Convert.ToDouble(teklifBilgileriRisk.KALEMSAYISI);
            if (kalemYuzde == double.NaN || kalemYuzde.ToString() == "NaN")
            {
                kalemYuzde = 0;
            }
            chart3.Titles[0].Text = "Kalem Adet (%" + kalemYuzde.ToString("n0") + ")";




            Series Adet = new Series("Adet", ViewType.Bar);
            Series SipariseDonusenAdet = new Series("Siparişe Donüşen Adet", ViewType.Bar);
            Series Tutar = new Series("Tutar", ViewType.Bar);
            Series SipariseDonusenTutar = new Series("Siparişe Donüşen Tutar", ViewType.Bar);
            Series TeklifKalemSayisi = new Series("Tutar", ViewType.Bar);
            Series SipariseDonenKalemSayisi = new Series("Tutar", ViewType.Bar);
            Series FaturaSayisi = new Series("Fatura Adedi", ViewType.Bar);
            Series FaturaTutari = new Series("Fatura Tutarı", ViewType.Bar);
            Series BirimFaturaTutari = new Series("Birim.Fat.Tut.", ViewType.Bar);

            Adet.Points.Add(
                new SeriesPoint("Adet", teklifBilgileriRisk.TEKLIFSAYISI));
            SipariseDonusenAdet.Points.Add(
                    new SeriesPoint("Sip.Adet", teklifBilgileriRisk.SIPARISEDONUSENTEKLIFSAYISI));
            Tutar.Points.Add(
                new SeriesPoint("Tutar", Convert.ToDouble(teklifBilgileriRisk.TEKLIFTUTARI).ToString("n2")));
            SipariseDonusenTutar.Points.Add(
                    new SeriesPoint("Sip.Tutarı", Convert.ToDouble(teklifBilgileriRisk.SIPARISTUTARI).ToString("n2")));
            TeklifKalemSayisi.Points.Add(
                new SeriesPoint("Kalem Sayısı", teklifBilgileriRisk.KALEMSAYISI));
            SipariseDonenKalemSayisi.Points.Add(
                new SeriesPoint("Sip.Kalem Sayısı", teklifBilgileriRisk.SIPARISEDONENKALEMSAYISI));



            FATURA_BILGILERI faturaBilgiler = islem.CariRiskBilgiEkraniFaturaBilgileri(firma, donem, carilogicalref);

            FaturaSayisi.Points.Add(
                    new SeriesPoint("Fatura Adedi", faturaBilgiler.FATURASAYISI.ToString("n2")));
            FaturaTutari.Points.Add(
                new SeriesPoint("Fatura Tutarı", faturaBilgiler.FATURATUTARI.ToString("n2")));
            BirimFaturaTutari.Points.Add(
                new SeriesPoint("Birim.Fat.Tut.", faturaBilgiler.BIRIMFATURATUTARI.ToString("n2")));

            Adet.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            Adet.CrosshairLabelPattern = "{V:n0}";

            SipariseDonusenAdet.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            SipariseDonusenAdet.CrosshairLabelPattern = "{V:n0}";

            Tutar.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            Tutar.CrosshairLabelPattern = "{V:n2}";
            Tutar.Label.TextPattern = "{V:n2}";

            SipariseDonusenTutar.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            SipariseDonusenTutar.CrosshairLabelPattern = "{V:n2}";
            SipariseDonusenTutar.Label.TextPattern = "{V:n2}";

            TeklifKalemSayisi.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            SipariseDonenKalemSayisi.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

            FaturaSayisi.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            FaturaTutari.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            FaturaTutari.CrosshairLabelPattern = "{V:n2}";
            FaturaTutari.Label.TextPattern = "{V:n2}";
            BirimFaturaTutari.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            BirimFaturaTutari.CrosshairLabelPattern = "{V:n2}";
            BirimFaturaTutari.Label.TextPattern = "{V:n2}";

            chart1.Series.Add(Adet);
            chart1.Series.Add(SipariseDonusenAdet);
            chart2.Series.Add(Tutar);
            chart2.Series.Add(SipariseDonusenTutar);
            chart3.Series.Add(TeklifKalemSayisi);
            chart3.Series.Add(SipariseDonenKalemSayisi);
            chartFatura.Series.Add(FaturaSayisi);
            chartFatura.Series.Add(FaturaTutari);
            chartFatura.Series.Add(BirimFaturaTutari);
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmCekRiskBilgileri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                simpleButton1_Click(sender, e);
            }
            if (e.KeyCode == Keys.F4)
            {
                simpleButton2_Click(sender, e);
            }
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DataRow dRowSatir = null;
            xrRiskBilgileri rp = new xrRiskBilgileri();
            dsGunlukKasa risk = new dsGunlukKasa();
            risk.risktablo.NewrisktabloRow();

            rp.xrCari.Text = cariUnvan;
            rp.xrTarih.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
            rp.xrMusteriCekiKredisi.Text = txtMUSTERITAHSILEDILMEMISCEKCIRORISKI.Text;
            rp.xrKendiCekSenetKredimiz.Text = txtKENDIODENMEMISCEKRISKIMIZ.Text;
            rp.xrCiroCekSenetKredisi.Text = txtCIROCEKSENETRISKTOPLAM.Text;
            rp.xrMusteriCekSenetKrediToplami.Text = txtOdenmemisCekler.Text;
            rp.xrAcikHesapKrediToplami.Text = txtSatisYil.Text;
            rp.xrMusteriCekSenetCiroKrediToplami.Text = txtCekRiskKendi.Text;
            rp.xrKendiCekSenetKredimiz.Text = txtCekriskCiro.Text;
            rp.xrAcikHesapKredisi.Text = txtACIKHESAPRISKI.Text;
            rp.xrToplamKredi.Text = txtRiskToplami.Text;
            rp.xrCariBakiye.Text = txtBakiye.Text;

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                DataRow row = gridView1.GetDataRow(i);
                if (row.Table.Rows[i]["Tipi"].ToString().Length > 1)
                {
                    dRowSatir = risk.risktablo.NewrisktabloRow();
                    dRowSatir["TIPI"] = row.Table.Rows[i]["Tipi"].ToString();
                    dRowSatir["DURUMU"] = row.Table.Rows[i]["Durumu"].ToString();
                    dRowSatir["PORTFOYNO"] = row.Table.Rows[i]["Portföyno"].ToString();
                    dRowSatir["SERINO"] = row.Table.Rows[i]["serino"].ToString();
                    dRowSatir["CEKSAHIBI"] = row.Table.Rows[i]["Çek Sahibi"].ToString();
                    dRowSatir["VADETARIHI"] = row.Table.Rows[i]["Vade Tarihi"].ToString();
                    dRowSatir["GIRISTARIHI"] = row.Table.Rows[i]["Giriş Tarih"].ToString();
                    dRowSatir["TUTAR"] = Convert.ToDouble(row.Table.Rows[i]["Tutar"]);
                    dRowSatir["CIROEDILENFIRMA"] = row.Table.Rows[i]["Ciro Edilen Firma"].ToString();
                    risk.risktablo.Rows.Add(dRowSatir);
                }
            }

            rp.DataSource = risk;
            rp.CreateDocument();
            using (ReportPrintTool raporYaz = new ReportPrintTool(rp))
            {
                raporYaz.ShowRibbonPreviewDialog();
            }
        }
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            //frmMusteriPerformansTekil frm = new frmMusteriPerformansTekil();
            //frm.cariKodu = kod;
            //frm.Text = cariUnvan + " Peformans Raporu";
            //frm.ShowDialog();
        }
        private void ayarlarıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            //clas.Yetkiler();
            //if (clas.cari_Tahsilat == false)
            //{
            //    XtraMessageBox.Show("YETKİ VERİLMEDİ !" + Environment.NewLine + "LÜTFEN YETKİNİZİN DOĞRULUĞUNU KONTROL ETTİRİNİZ !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            //clas.CariBilgileri(kod);
            //frmCariTahsilatFormu frm = new frmCariTahsilatFormu();
            //frm.ticariIslemGurubu = clas.cariTicariIslemGrubu;
            //frm.nakitTrCode = "11";
            //frm.nakitSign = "0";
            //frm.kkTrCode = "70";
            //frm.kkSign = "1";
            //frm.cariKodu = kod;
            //frm.lblCariKodu.Text = kod;
            //frm.lblUnvan.Text = cariUnvan;
            //frm.cariUnvan = cariUnvan;
            //frm.lblMuhKod.Text = clas.cariMuhKod;
            //frm.adres = clas.cariAdres + " " + clas.cariAdres2;
            //frm.ilce = clas.cariIlce;
            //frm.sehir = clas.cariSehir;
            //frm.ShowDialog();
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {

            frmCariEkstre frmCariEkstre = new frmCariEkstre(cariUnvan, kod);
            frmCariEkstre.carikod = kod;
            frmCariEkstre.Yenile();
            frmCariEkstre.ShowDialog();
        }
    }
}