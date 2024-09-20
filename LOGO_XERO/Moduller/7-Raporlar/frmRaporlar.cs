using DevExpress.CodeParser;
using DevExpress.XtraReports.UI;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using LOGO_XERO.Models.LOGO_XERO_M;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LOGO_XERO.Moduller._7_Raporlar
{
    public partial class frmRaporlar : DevExpress.XtraEditors.XtraForm
    {
        frmAnaForm ana;
        SQLConnection clas = new SQLConnection();

        XtraReport dynamicReport;

        frmTeklifOlustur _frmTeklifOlustur;

        public TEKLIFYAZDIRMODEL TeklifData;
        public frmRaporlar(frmTeklifOlustur frmTeklifOlustur)
        {
            InitializeComponent();
            _frmTeklifOlustur = frmTeklifOlustur;
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
        }
        public void getir() {
            using (LogoContext db = new LogoContext())
            {
                grid.DataSource =  db.LOGO_XERO_RAPOR_DOSYALARI.Where(s=>s.AKTIF == true && s.SABLON == 1).OrderByDescending(s=>s.VARSAYILAN).ToList();
                grid.RefreshDataSource();
                grid.Refresh();
            }
        }
        private void frmRaporlar_Load(object sender, EventArgs e)
        {
            getir();
            gridView1.MoveFirst();
            grid_Click(sender, e);
        }

        private void grid_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) return;
            LOGO_XERO_RAPOR_DOSYALARI roww = (LOGO_XERO_RAPOR_DOSYALARI)gridView1.GetFocusedRow();
            if (roww != null)
            {

            
            int Id = Convert.ToInt32(roww.ID);

            using (LogoContext db = new LogoContext())
            {
                var dosya = db.LOGO_XERO_RAPOR_DOSYALARI
                              .Where(s => s.ID == Id)
                              .Select(s => s.DOSYA)
                              .FirstOrDefault();
                if (dosya != null)
                {
                    MemoryStream ms = new MemoryStream(dosya);
                    dynamicReport = new XtraReport();
                    dynamicReport.LoadLayout(ms);

                    if (ana.FATURALOGO != null)
                    {
                        XRPictureBox xrLogo = dynamicReport.FindControl("xrLogo", true) as XRPictureBox;
                        if (xrLogo != null)
                        {
                            using (MemoryStream logoStream = new MemoryStream(ana.FATURALOGO))
                            {
                                xrLogo.Image = Image.FromStream(logoStream);
                            }
                        }
                    }

                    dynamicReport.DataSource = new List<TEKLIFYAZDIRMODEL> { TeklifData };
                    dynamicReport.DataMember = "SATIRLAR";
                    dynamicReport.CreateDocument();
                    dynamicReport.PrintingSystem.ShowMarginsWarning = false;
                    dk.DocumentSource = dynamicReport;
                }

            }
            }
        }

        private void btn_mailgonder_Click(object sender, EventArgs e)
        {
            string teklifDosyaAdi = string.Empty;
            string MailAciklama3;
            string MailAciklama2 = string.Empty;

            StringBuilder sbY = new StringBuilder();
            sbY.Append("<style>td {font-size:12px; padding:3px 5px;}</style><tr style='font-size:12px; Font-Family:Arial;'><td align=left >" + "Merhabalar" + "</td></tr>");
            sbY.Append("<style>td {font-size:12px; padding:3px 5px;}</style><tr style='font-size:12px; Font-Family:Arial;'><td align=left >" + "İstemiş olduğunuz teklif ektedir." + "</td></tr><BR/>");
            sbY.Append("<style>td {font-size:12px; padding:3px 5px;}</style><tr style='font-size:12px; Font-Family:Arial;'><td align=left >" + "Saygılarımla" + "</td></tr>");
            sbY.Append("<style>td {font-size:12px; padding:3px 5px;}</style><tr style='font-size:12px; Font-Family:Arial;'><td align=left >" + "<b>" + TeklifData.SATISELEMANI + "</b>" + "</td></tr><BR/>");
            sbY.Append("<style>td {font-size:14px; padding:3px 5px;}</style><tr style='font-size:14px; Font-Family:Arial;'><td align=left >" + "<b>" + TeklifData.FirmaBilgileri.UNVANI + "</b>" + "</td></tr>");
            sbY.Append("<style>td {font-size:12px; padding:3px 5px;}</style><tr style='font-size:12PX; Font-Family:Arial;'><td align=left >" + TeklifData.FirmaBilgileri.ADRES + "</td></tr>");
            sbY.Append("<style>td {font-size:12px; padding:3px 5px;}</style><tr style='font-size:12PX; Font-Family:Arial;'><td align=left >" + TeklifData.FirmaBilgileri.ILCE + "/" + TeklifData.FirmaBilgileri.SEHIR + "/" + TeklifData.FirmaBilgileri.ULKE + "</td></tr>");
            sbY.Append("<style>td {font-size:12px; padding:3px 5px;}</style><tr style='font-size:12PX; Font-Family:Arial;'><td align=left >" + "<b>Tel :</b>" + TeklifData.FirmaBilgileri.TELEFON + "</td></tr>");
            sbY.Append("<style>td {font-size:12px; padding:3px 5px;}</style><tr style='font-size:12PX; Font-Family:Arial;'><td align=left >" + "<b>Faks :</b>" + TeklifData.FirmaBilgileri.FAX + "</td></tr>");
            sbY.Append("<style>td {font-size:12px; padding:3px 5px;}</style><tr style='font-size:12PX; Font-Family:Arial;'><td align=left >" + "<b>E-mail :</b>" + TeklifData.FirmaBilgileri.MAIL + "</td></tr>");
            sbY.Append("<style>td {font-size:12px; padding:3px 5px;}</style><tr style='font-size:12PX; Font-Family:Arial;'></tr>");

            MailAciklama2 = MailAciklama2 + "<BR/><BR/>" + "<table>" + sbY.ToString() + "</table>" + "<BR/><BR/>";
            MailAciklama3 = MailAciklama2.ToString();
            string baslik = string.Empty;
          
            baslik = TeklifData.TEKLIFNO + "_" + TeklifData.CARIUNVANI;
            teklifDosyaAdi = Path.GetPathRoot(Environment.SystemDirectory) + "\\LOGO_XERO AYARLAR\\" + baslik.Trim().Replace(" ", "").Replace(".", "").Replace("-", "").Replace("/", "_").Replace("(", "_").Replace(")", "_") + ".pdf";
            dynamicReport.ExportToPdf(teklifDosyaAdi);
            string mailBaslik = string.Empty;
            Islemler islem = new Islemler();
            bool durum = islem.TeklifMailGonder(_frmTeklifOlustur.parametre,ana._Kullanici, txtEPosta.Text.Trim(), txtEPostaCC.Text, txtGonderen.Text, mailBaslik, MailAciklama3, teklifDosyaAdi);
            if (durum == true)
                MessageBox.Show("E-Mail Gönderildi!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                MessageBox.Show("E-Mail Gönderilemedi!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            File.Delete(teklifDosyaAdi);
        }
    }
}