using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using LOGO_XERO.Models.LOGO_M;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LOGO_XERO.Moduller.Giris_AnaForm_Ayarlar
{
    public partial class frmDovizKurGuncelleme : DevExpress.XtraEditors.XtraForm
    {
        frmAnaForm ana;
        Islemler islem = new Islemler();
        L_CAPIFIRM firmaBilgi;
        int firmaNo = 0;
        public frmDovizKurGuncelleme()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            firmaNo = Convert.ToInt32(ana.lk_firma.EditValue.ToString());

        }

        private void frmDovizKurGuncelleme_Load(object sender, EventArgs e)
        {
            firmaBilgi = islem.FirmaBilgileriGetir(firmaNo.ToString());
            date_tarih.DateTime = DateTime.Today;

        }
        public void OncekiGunDovizKurlariGetir()
        {
            using (LogoContext db = new LogoContext())
            {
                List<DOVIZ_KURLARI_LOGO> griddekiListe = new List<DOVIZ_KURLARI_LOGO>();
                griddekiListe = gridControl1.DataSource as List<DOVIZ_KURLARI_LOGO>;
                int firmaNo = Convert.ToInt32(ana.lk_firma.EditValue.ToString());
                L_CAPIFIRM firmaBilgi = islem.FirmaBilgileriGetir(firmaNo.ToString());
                string sql = "";
                if (firmaBilgi.SEPEXCHTABLE == 0)
                {
                    sql = $@"select cast(0 as INT) LREF,C.CURTYPE DOVIZKODU, C.CURCODE [DOVIZ], C.CURNAME [DOVIZADI],E.RATES1,E.RATES2,E.RATES3,E.RATES4,C.CURSYMBOL,E.EDATE
FROM L_CURRENCYLIST C WITH(NOLOCK)
LEFT OUTER JOIN L_DAILYEXCHANGES E WITH(NOLOCK) ON C.CURTYPE=E.CRTYPE
WHERE E.EDATE='{date_tarih.DateTime.AddDays(-1).ToString("yyyy-MM-dd")}' AND FIRMNR={firmaNo} ORDER BY C.LOGICALREF";
                }
                else
                {
                    sql = $@"select cast(0 as INT) LREF,C.CURTYPE DOVIZKODU, C.CURCODE [DOVIZ], C.CURNAME [DOVIZADI],E.RATES1,E.RATES2,E.RATES3,E.RATES4,C.CURSYMBOL,E.EDATE
FROM L_CURRENCYLIST C WITH(NOLOCK)
LEFT OUTER JOIN LG_EXCHANGE_{firmaNo} E WITH(NOLOCK) ON C.CURTYPE=E.CRTYPE
WHERE E.EDATE='{date_tarih.DateTime.AddDays(-1).ToString("yyyy-MM-dd")}' AND FIRMNR={firmaNo} ORDER BY C.LOGICALREF";
                }
                List<DOVIZ_KURLARI_LOGO> dovizler = new List<DOVIZ_KURLARI_LOGO>();
                dovizler = db.Database.SqlQuery<DOVIZ_KURLARI_LOGO>(sql).ToList();
                if (dovizler.Count > 0)
                {

                }
                else
                {
                    if (firmaBilgi.SEPEXCHTABLE == 0)
                    {
                        sql = $@"select cast(0 as INT) LREF , C.DOVIZKODU, C.DOVIZCINSI [DOVIZ], C.ACIKLAMA [DOVIZADI],E.RATES1,E.RATES2,E.RATES3,E.RATES4,C.SEMBOL CURSYMBOL,E.EDATE
FROM LOGO_XERO_DOVIZ_BILGILERI C WITH(NOLOCK)
LEFT OUTER JOIN L_DAILYEXCHANGES E WITH(NOLOCK) ON C.DOVIZKODU=E.CRTYPE AND E.EDATE='{date_tarih.DateTime.AddDays(-1).ToString("yyyy-MM-dd")}'
WHERE C.FIRMANO={firmaNo}  ORDER BY C.LOGICALREF";
                    }
                    else
                    {
                        sql = $@"select cast(0 as INT) LREF , C.DOVIZKODU, C.DOVIZCINSI [DOVIZ], C.ACIKLAMA [DOVIZADI],E.RATES1,E.RATES2,E.RATES3,E.RATES4,C.SEMBOL CURSYMBOL,E.EDATE
FROM LOGO_XERO_DOVIZ_BILGILERI C WITH(NOLOCK)
LEFT OUTER JOIN LG_EXCHANGE_{firmaNo} E WITH(NOLOCK) ON C.DOVIZKODU=E.CRTYPE AND E.EDATE='{date_tarih.DateTime.AddDays(-1).ToString("yyyy-MM-dd")}'
WHERE C.FIRMANO={firmaNo}  ORDER BY C.LOGICALREF";
                    }
                    dovizler = db.Database.SqlQuery<DOVIZ_KURLARI_LOGO>(sql).ToList();
                    gridControl1.DataSource = dovizler;
                }
                if (griddekiListe.Count > 0)
                {
                    foreach (var item in griddekiListe)
                    {
                        var varmi = dovizler.Where(s => s.DOVIZKODU == item.DOVIZKODU).FirstOrDefault();
                        if (varmi != null)
                        {
                            varmi.LREF = item.LREF;
                            varmi.RATES1 = varmi.RATES1;
                            varmi.RATES2 = varmi.RATES2;
                            varmi.RATES3 = varmi.RATES3;
                            varmi.RATES4 = varmi.RATES4;
                        }
                    }
                }
                gridControl1.DataSource = dovizler;

            }
        }
        public void DovizKurlariGetir()
        {
            using (LogoContext db = new LogoContext())
            {

                string sql = "";
                if (firmaBilgi.SEPEXCHTABLE == 0)
                {
                    sql = $@"select E.LREF,C.CURTYPE DOVIZKODU,C.CURCODE [DOVIZ], C.CURNAME [DOVIZADI],E.RATES1,E.RATES2,E.RATES3,E.RATES4,C.CURSYMBOL,E.EDATE
FROM L_CURRENCYLIST C WITH(NOLOCK)
LEFT OUTER JOIN L_DAILYEXCHANGES E WITH(NOLOCK) ON C.CURTYPE=E.CRTYPE 
WHERE E.EDATE='{date_tarih.DateTime.ToString("yyyy-MM-dd")}' AND FIRMNR={firmaNo} ORDER BY C.LOGICALREF";
                }
                else
                {
                    sql = $@"select E.LREF,C.CURTYPE DOVIZKODU, C.CURCODE [DOVIZ], C.CURNAME [DOVIZADI],E.RATES1,E.RATES2,E.RATES3,E.RATES4,C.CURSYMBOL,E.EDATE
FROM L_CURRENCYLIST C WITH(NOLOCK)
LEFT OUTER JOIN LG_EXCHANGE_{firmaNo} E WITH(NOLOCK) ON C.CURTYPE=E.CRTYPE  
WHERE E.EDATE='{date_tarih.DateTime.ToString("yyyy-MM-dd")}' AND FIRMNR={firmaNo} ORDER BY C.LOGICALREF";
                }
                List<DOVIZ_KURLARI_LOGO> dovizler = new List<DOVIZ_KURLARI_LOGO>();
                dovizler = db.Database.SqlQuery<DOVIZ_KURLARI_LOGO>(sql).ToList();
                if (dovizler.Count > 0)
                {
                    gridControl1.DataSource = dovizler;
                }
                else
                {
                    if (firmaBilgi.SEPEXCHTABLE == 0)
                    {
                        sql = $@"select ISNULL(E.LREF,0)LREF , C.DOVIZKODU, C.DOVIZCINSI [DOVIZ], C.ACIKLAMA [DOVIZADI],E.RATES1,E.RATES2,E.RATES3,E.RATES4,C.SEMBOL CURSYMBOL,E.EDATE
FROM LOGO_XERO_DOVIZ_BILGILERI C WITH(NOLOCK)
LEFT OUTER JOIN L_DAILYEXCHANGES E WITH(NOLOCK) ON C.DOVIZKODU=E.CRTYPE AND E.EDATE='{date_tarih.DateTime.ToString("yyyy-MM-dd")}'
WHERE C.FIRMANO={firmaNo}  ORDER BY C.LOGICALREF";
                    }
                    else
                    {
                        sql = $@"select ISNULL(E.LREF,0)LREF , C.DOVIZKODU, C.DOVIZCINSI [DOVIZ], C.ACIKLAMA [DOVIZADI],E.RATES1,E.RATES2,E.RATES3,E.RATES4,C.SEMBOL CURSYMBOL,E.EDATE
FROM LOGO_XERO_DOVIZ_BILGILERI C WITH(NOLOCK)
LEFT OUTER JOIN LG_EXCHANGE_{firmaNo} E WITH(NOLOCK) ON C.DOVIZKODU=E.CRTYPE AND E.EDATE='{date_tarih.DateTime.ToString("yyyy-MM-dd")}'
WHERE C.FIRMANO={firmaNo}  ORDER BY C.LOGICALREF";
                    }
                    dovizler = db.Database.SqlQuery<DOVIZ_KURLARI_LOGO>(sql).ToList();
                    gridControl1.DataSource = dovizler;
                }

            }
        }

        private void date_tarih_EditValueChanged(object sender, EventArgs e)
        {
            DovizKurlariGetir();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OncekiGunDovizKurlariGetir();
        }

        public void IMKB2()
        {
            try
            {
                string usd1 = "";
                string eur1 = "";
                string usd2 = "";
                string eur2 = "";
                string usd3 = "";
                string eur3 = "";
                string usd4 = "";
                string eur4 = "";
                string exchangeRate = "http://www.tcmb.gov.tr/kurlar/today.xml";
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(exchangeRate);

                //EFEKTİF SATIŞ
                usd4 = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod ='USD']/BanknoteSelling").InnerXml.Replace(".", ",");
                eur4 = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod ='EUR']/BanknoteSelling").InnerXml.Replace(".", ",");

                //DOVİZ ALIŞ
                usd1 = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod ='USD']/ForexBuying").InnerXml.Replace(".", ",");
                eur1 = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod ='EUR']/ForexBuying").InnerXml.Replace(".", ",");

                //DOVİZ SATIŞ
                usd2 = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod ='USD']/ForexSelling").InnerXml.Replace(".", ",");
                eur2 = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod ='EUR']/ForexSelling").InnerXml.Replace(".", ",");

                //EFEKTİF ALIŞ
                usd3 = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod ='USD']/BanknoteBuying").InnerXml.Replace(".", ",");
                eur3 = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod ='EUR']/BanknoteBuying").InnerXml.Replace(".", ",");


                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    DOVIZ_KURLARI_LOGO row = gridView1.GetRow(i) as DOVIZ_KURLARI_LOGO;
                    string kod = row.DOVIZKODU.ToString();
                    if (kod == "1")
                    {
                        gridView1.SetRowCellValue(i, "RATES1", usd1);
                        gridView1.SetRowCellValue(i, "RATES2", usd2);
                        gridView1.SetRowCellValue(i, "RATES3", usd3);
                        gridView1.SetRowCellValue(i, "RATES4", usd4);
                    }

                    else if (kod == "20")
                    {
                        gridView1.SetRowCellValue(i, "RATES1", eur1);
                        gridView1.SetRowCellValue(i, "RATES2", eur2);
                        gridView1.SetRowCellValue(i, "RATES3", eur3);
                        gridView1.SetRowCellValue(i, "RATES4", eur4);
                    }

                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show(hata.ToString(), "HATA!! DÖVİZ KURLARI ALINAMADI !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            IMKB2();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

            long tr = date_tarih.DateTime.Day + 256 * date_tarih.DateTime.Month + 65536 * date_tarih.DateTime.Year;
            using (LogoContext db = new LogoContext())
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    DOVIZ_KURLARI_LOGO row = gridView1.GetRow(i) as DOVIZ_KURLARI_LOGO;
                    string rates1 = "0";
                    string rates2 = "0";
                    string rates3 = "0";
                    string rates4 = "0";

                    if (row.RATES1 != null)
                    {
                        rates1 = row.RATES1.ToString().Replace(",", ".");
                    }
                    if (row.RATES2 != null)
                    {
                        rates2 = row.RATES2.ToString().Replace(",", ".");
                    }
                    if (row.RATES3 != null)
                    {
                        rates3 = row.RATES3.ToString().Replace(",", ".");
                    }
                    if (row.RATES4 != null)
                    {
                        rates4 = row.RATES4.ToString().Replace(",", ".");
                    }
                    string sql = "";
                    if (row.LREF > 0)
                    {
                        if (firmaBilgi.SEPEXCHTABLE == 0)
                        {
                            sql = $@"UPDATE L_DAILYEXCHANGES SET
                    RATES1={rates1},RATES2={rates2},RATES3={rates3},RATES4={rates4}  WHERE LREF={row.LREF}";
                        }
                        else
                        {
                            sql = $@"UPDATE LG_EXCHANGE_{firmaNo} SET
                     RATES1={rates1},RATES2={rates2},RATES3={rates3},RATES4={rates4}  WHERE LREF={row.LREF}";
                        }


                    }
                    else
                    {
                        if (firmaBilgi.SEPEXCHTABLE == 0)
                        {
                            sql = $@"INSERT INTO L_DAILYEXCHANGES (DATE_,EDATE,CRTYPE,RATES1,RATES2,RATES3,RATES4,GLOBALID,APPROVE,APPROVEDATE) VALUES ({tr},'{date_tarih.DateTime.ToString("yyyy-MM-dd")}',{row.DOVIZKODU},{rates1},{rates2},{rates3},{rates4},'',0,0)";
                        }
                        else
                        {
                            sql = $@"INSERT INTO LG_EXCHANGE_{firmaNo}(DATE_,EDATE,CRTYPE,RATES1,RATES2,RATES3,RATES4,GLOBALID,APPROVE,APPROVEDATE) VALUES ({tr},'{date_tarih.DateTime.ToString("yyyy-MM-dd")}',{row.DOVIZKODU},{rates1},{rates2},{rates3},{rates4},'',0,0)";
                        }

                    }
                    db.Database.ExecuteSqlCommand(sql);

                }
            }

            DovizKurlariGetir();
            XtraMessageBox.Show("KAYIT TAMAMLANDI!", "BILGI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDovizKurGuncelleme_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmAnaDashBoard dash = Application.OpenForms["frmAnaDashBoard"] as frmAnaDashBoard;
            dash.DolarEuroDoldur();
        }
    }
}