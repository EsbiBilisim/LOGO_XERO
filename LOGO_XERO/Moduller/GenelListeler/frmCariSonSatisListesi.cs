using DevExpress.CodeParser;
using DevExpress.DashboardWin.Design;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using LOGO_XERO.Models.GenelKullanim;
using LOGO_XERO.Models.LOGO_XERO_M;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGO_XERO.Moduller.GenelListeler
{
    public partial class frmCariSonSatisListesi : DevExpress.XtraEditors.XtraForm
    {
        frmTeklifOlustur teklif;
        SQLConnection clas = new SQLConnection();
        frmAnaForm ana;
        Islemler islem = new Islemler();
        public int tip = 0;
        public frmCariSonSatisListesi(frmTeklifOlustur _teklif)
        {
            InitializeComponent();
            teklif = _teklif;
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            islem.TasarimGetir(gv_carisonsatislist, ana._Kullanici.ID, this.Name, grid_carisonsatislist.Name);
            islem.TasarimGetir(gv_teklificin, ana._Kullanici.ID, this.Name, grid__teklificin.Name);
        }

        private void frmCariSonSatisListesi_Load(object sender, EventArgs e)
        {

        }
        
        public void TeklifListe(string cariKodu, string stokKodu,int trcode)
        {
            grid_carisonsatislist.Visible = false;
            grid__teklificin.Visible = true;
            using (LogoContext db = new LogoContext())
            { 
            string SQL =$@"SELECT B.TARIH, B.CARIUNVANI,T.STOKKODU,T.STOKADI,B.KDVDURUMU [KDVDAHIL], T.STOKACIKLAMA [STOKCINSI2], T.MIKTAR,T.BIRIM,T.SATIRDOVIZKODU [DOVIZKODU],ISNULL((select CURCODE from L_CURRENCYLIST where FIRMNR = 219 AND CURTYPE = T.SATIRDOVIZKODU),'TL') [DOVIZ],T.DOVIZLIFIYAT,
            --T.ISKONTOYUZDESI1 [ISK%],
            T.FIYAT [TLFIYAT],T.ISKONTOLUTUTAR [ISKONTOLUTUTAR]
            FROM LOGO_XERO_TEKLIF_SATIR_{ana.lk_firma.EditValue.ToString()} T
            LEFT OUTER JOIN LOGO_XERO_TEKLIF_BASLIK_{ana.lk_firma.EditValue.ToString()} B ON T.TEKLIFID = B.ID
            WHERE B.TRCODE= {trcode} AND B.CARIKODU='{cariKodu}' AND T.STOKKODU='{stokKodu}'";

            List<ALIS_SATIS_TEKLIF_LISTE> liste=  db.Database.SqlQuery<ALIS_SATIS_TEKLIF_LISTE>(SQL).ToList();
            grid__teklificin.DataSource = liste;
            grid__teklificin.RefreshDataSource();
            grid__teklificin.Refresh(); 
            }
        }

        public void SonAlislar(string cariKodu, string stokKodu,string sorgu)
        {
            grid_carisonsatislist.Visible = true;
            grid__teklificin.Visible = false;
            if (string.IsNullOrWhiteSpace(cariKodu))
            {
                this.Text = "Tüm Carilere Son Satış Listesi ";
                gridColumn21.Visible = true;
            }
            else
            {
                this.Text = "Cari Son Satış Listesi ";
                gridColumn21.Visible = false; 
            }
            using (LogoContext db = new LogoContext())
            {

           
            //AND ((S.BILLED=1 AND S.TRCODE IN (1)) OR  (S.BILLED=0 AND S.TRCODE IN (13,14,50)))  sonalislar -- AND S.TRCODE IN (7,8) son satislar
            string SQL = $@"SELECT TOP 50 

case when S.BILLED=1 AND S.TRCODE=1 THEN 'ALIŞ FATURASI'
when S.BILLED=1 AND S.TRCODE=7 THEN 'PERAKENDE SATIŞ FATURASI' 
when S.BILLED=1 AND S.TRCODE=8 THEN 'TOPTAN SATIŞ FATURASI' 
when S.BILLED=0 AND S.TRCODE=14 THEN 'DEVİR FİŞİ' 
when S.BILLED=0 AND S.TRCODE=13 THEN 'ÜRETİMDEN GİRİŞ FİŞİ'
when S.BILLED=0 AND S.TRCODE=50 THEN 'SAYIM FAZLASI FİŞİ'
ELSE '' END AS FISTIPI,

S.DATE_ [TARIH],INV.LOGICALREF FATURAREF, S.LOGICALREF, I.CODE [STOKKODU], 
            CAST(CASE INV.GVATINC WHEN 1 THEN 1 ELSE 0 END AS BIT) [KDVDAHIL],
            I.NAME  [STOKCINSI],
            I.NAME3 [STOKCINSI2],    
            S.AMOUNT [MIKTAR], 
CASE WHEN INV.LINEEXCTYP<>4 THEN (CASE WHEN S.TRCURR=0 THEN cast(160 as smallint) ELSE S.TRCURR END)
			ELSE (CASE WHEN S.PRCURR=0 THEN cast(160 as smallint) ELSE S.PRCURR END) END AS [DOVIZKODU],

              CASE WHEN INV.LINEEXCTYP<>4 THEN (CASE WHEN S.TRCURR=0 THEN 'TL' ELSE (SELECT TOP 1 CURCODE FROM L_CURRENCYLIST With (Nolock)
			WHERE CURTYPE=S.TRCURR AND FIRMNR={ana.lk_firma.EditValue.ToString()}) END)
			ELSE (CASE WHEN S.PRCURR=0 THEN 'TL' ELSE (SELECT TOP 1 CURCODE FROM L_CURRENCYLIST With (Nolock)
			WHERE CURTYPE=S.PRCURR AND FIRMNR={ana.lk_firma.EditValue.ToString()}) END) END AS [DOVIZ],

            S.PRICE [TL_FIYAT],
 CASE WHEN INV.LINEEXCTYP<>4 THEN (CASE WHEN S.TRCURR=0 THEN S.PRICE ELSE  ISNULL((S.PRICE/NULLIF(S.TRRATE,0)),S.PRICE) END)
			ELSE (CASE WHEN S.PRCURR=0 THEN S.PRICE ELSE  ISNULL(S.PRPRICE,0) END) END AS [FIYAT],
            (NULLIF(DISTCOST,0)/(NULLIF(VATMATRAH,0)+NULLIF(DISTCOST,0)))*100 [ISK],
            (S.LINENET/S.AMOUNT) [NET FIYAT], S.LINENET [ISKONTOLUTUTAR],C.DEFINITION_ [MUSTERIUNVANI],C.CODE [MUSTERIKODU]
            FROM LG_{ana.lk_firma.EditValue.ToString()}_{ana.lk_donem.EditValue.ToString()}_STLINE S With (Nolock)
	        LEFT OUTER JOIN LG_{ana.lk_firma.EditValue.ToString()}_{ana.lk_donem.EditValue.ToString()}_INVOICE INV ON S.INVOICEREF=INV.LOGICALREF
            LEFT OUTER JOIN LG_{ana.lk_firma.EditValue.ToString()}_CLCARD C ON S.CLIENTREF=C.LOGICALREF
            LEFT OUTER JOIN LG_{ana.lk_firma.EditValue.ToString()}_ITEMS I ON S.STOCKREF=I.LOGICALREF
            WHERE S.CANCELLED=0 {cariKodu} AND I.CODE='{stokKodu}'
            {sorgu} 
            AND LINETYPE=0 ORDER BY S.DATE_ DESC"; 
            List<SON_ALIS_SATIS_LISTE> liste = db.Database.SqlQuery<SON_ALIS_SATIS_LISTE>(SQL).ToList(); 
            grid_carisonsatislist.DataSource = liste;
            grid_carisonsatislist.RefreshDataSource();
            grid_carisonsatislist.Refresh(); 
            }
        }

        private void tasarımıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            islem.TasarimKaydet(gv_teklificin,ana._Kullanici.ID,this.Name,grid__teklificin.Name);
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
           // islem.TasarimKaydet(gv_carisonsatislist, ana._Kullanici.ID, this.Name, grid_carisonsatislist.Name);
        }

        private void grid__teklificin_DoubleClick(object sender, EventArgs e)
        {
            if (gv_teklificin.GetFocusedRow() != null)
            {
                ALIS_SATIS_TEKLIF_LISTE satir = (ALIS_SATIS_TEKLIF_LISTE)gv_teklificin.GetFocusedRow();
                if (teklif.gv_TeklifSatirlari.GetFocusedRow() != null) 
                { 
                LOGO_XERO_TEKLIF_SATIR teklifsatir = (LOGO_XERO_TEKLIF_SATIR)teklif.gv_TeklifSatirlari.GetFocusedRow();
                    double kdv = Convert.ToDouble(teklif.gv_TeklifSatirlari.GetRowCellValue(teklif.gv_TeklifSatirlari.FocusedRowHandle, "KDV").ToString());
                    double fiyat = Convert.ToDouble(satir.DOVIZLIFIYAT);
                    double dovizkuru = 0;
                    short _firma = Convert.ToInt16(Convert.ToInt16(ana.lk_firma.EditValue));
                    string dovizkod = satir.DOVIZ;
                    double kur = islem.RatesDovizKuruDondur(ana.parametre, ana.firmaBilgisi, satir.DOVIZKODU, ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString());
                    //FİYAT KISMI
                    if (tip == 1)
                    { 
                       if (satir.DOVIZKODU == 160 || satir.DOVIZKODU == 0) //TL İSE                                                                
                       {
                           if (teklif.ck_kdvdahil.Checked)
                           {
                               if (satir.KDVDAHIL == false)
                               {
                                   fiyat = fiyat * (1 + Convert.ToDouble(kdv) / 100);
                               }
                           }
                           else
                           {
                               if (satir.KDVDAHIL == true)
                               {
                                   fiyat = fiyat / (1 + Convert.ToDouble(kdv) / 100);
                               }
                           }

                           teklif.gv_TeklifSatirlari.SetFocusedRowCellValue("FIYAT", fiyat);
                       }
                       else
                       {
                           //double tlkarsiligi = kur * fiyat;
                           double dovizkarsiligi =  fiyat;
                           if (teklif.ck_kdvdahil.Checked)
                           {
                               if (satir.KDVDAHIL == false)
                               {
                                    //tlkarsiligi = tlkarsiligi * (1 + Convert.ToDouble(kdv) / 100);
                                    dovizkarsiligi = dovizkarsiligi * (1 + Convert.ToDouble(kdv) / 100);
                               }
                           }
                           else
                           {
                               if (satir.KDVDAHIL == true)
                               {
                                   // tlkarsiligi = tlkarsiligi / (1 + Convert.ToDouble(kdv) / 100);
                                    dovizkarsiligi = dovizkarsiligi / (1 + Convert.ToDouble(kdv) / 100);
                               }
                           }
                            teklif.gv_TeklifSatirlari.SetRowCellValue(teklif.gv_TeklifSatirlari.FocusedRowHandle, "DOVIZLIFIYAT", dovizkarsiligi);
                           teklif.gv_TeklifSatirlari.SetFocusedRowCellValue("DOVIZLIFIYAT", dovizkarsiligi);
                       }
                    }
                    // DÖVİZ FİYAT KISMI
                    else if (tip == 2)
                    {

                    
                        if (teklif.SatirlarParaBirimi.SelectedIndex == 0 || teklif.SatirlarParaBirimi.SelectedIndex == 1)
                        {
                            dovizkuru = Convert.ToDouble(teklif.btn_raporlamakuru.Text);
                            if (dovizkod == "TL")
                            {
                                double sonuc = fiyat / dovizkuru;
                                teklif.gv_TeklifSatirlari.SetFocusedRowCellValue("DOVIZLIFIYAT", sonuc);
                            }
                            else
                            {
                                double sonuc = (fiyat * kur) / dovizkuru;
                                teklif.gv_TeklifSatirlari.SetFocusedRowCellValue("DOVIZLIFIYAT", sonuc);
                            }

                        }
                        else if (teklif.SatirlarParaBirimi.SelectedIndex == 2)
                        {
                            dovizkuru = Convert.ToDouble(teklif.btn_islemkuru.Text);
                            if (dovizkod == "TL")
                            {
                                double sonuc = fiyat / dovizkuru;
                                teklif.gv_TeklifSatirlari.SetFocusedRowCellValue("DOVIZLIFIYAT", sonuc);
                            }
                            else
                            {
                                double sonuc = (fiyat * kur) / dovizkuru;
                                teklif.gv_TeklifSatirlari.SetFocusedRowCellValue("DOVIZLIFIYAT", sonuc);
                            }
                        }
                        else
                        {
                            double satirdovizkuru = Convert.ToDouble(teklif.gv_TeklifSatirlari.GetFocusedRowCellValue("SATIRDOVIZKURU"));
                            string dövizkodu = teklif.gv_TeklifSatirlari.GetFocusedRowCellValue("SATIRDOVIZKODU").ToString();
                            dovizkuru = Convert.ToDouble(teklif.btn_islemkuru.Text);
                            if (dövizkodu == dovizkod)
                            {
                                teklif.gv_TeklifSatirlari.SetFocusedRowCellValue("FIYAT", fiyat);
                                teklif.gv_TeklifSatirlari.SetFocusedRowCellValue("DOVIZLIFIYAT", fiyat);
                            }
                            else
                            {
                                double sonuc = (fiyat * kur) / satirdovizkuru;
                                teklif.gv_TeklifSatirlari.SetFocusedRowCellValue("DOVIZLIFIYAT", fiyat);
                                teklif.gv_TeklifSatirlari.SetFocusedRowCellValue("FIYAT", sonuc);
                                
                            }
                        }
                    }
                    this.Close();
                }


            }
        }

        private void grid_carisonsatislist_DoubleClick(object sender, EventArgs e)
        {
            SON_ALIS_SATIS_LISTE satir = (SON_ALIS_SATIS_LISTE)gv_carisonsatislist.GetFocusedRow();
            if (teklif.gv_TeklifSatirlari.GetFocusedRow() != null)
            {
                LOGO_XERO_TEKLIF_SATIR teklifsatir = (LOGO_XERO_TEKLIF_SATIR)teklif.gv_TeklifSatirlari.GetFocusedRow();
                double kdv = Convert.ToDouble(teklif.gv_TeklifSatirlari.GetRowCellValue(teklif.gv_TeklifSatirlari.FocusedRowHandle, "KDV").ToString());
                double fiyat = Convert.ToDouble(satir.FIYAT);
                double dovizkuru = 0;
                short _firma = Convert.ToInt16(Convert.ToInt16(ana.lk_firma.EditValue));
                string dovizkod = satir.DOVIZ;
                double kur = islem.RatesDovizKuruDondur(ana.parametre, ana.firmaBilgisi, satir.DOVIZKODU, ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString());
                //FİYAT KISMI
                if (tip == 1)
                {
                    if (satir.DOVIZKODU == 160 || satir.DOVIZKODU == 0) //TL İSE                                                                
                    {
                        if (teklif.ck_kdvdahil.Checked)
                        {
                            if (satir.KDVDAHIL == false)
                            {
                                fiyat = fiyat * (1 + Convert.ToDouble(kdv) / 100);
                            }
                        }
                        else
                        {
                            if (satir.KDVDAHIL == true)
                            {
                                fiyat = fiyat / (1 + Convert.ToDouble(kdv) / 100);
                            }
                        }

                        teklif.gv_TeklifSatirlari.SetFocusedRowCellValue("FIYAT", fiyat);
                    }
                    else
                    {
                        double tlkarsiligi = kur * fiyat;
                        if (teklif.ck_kdvdahil.Checked)
                        {
                            if (satir.KDVDAHIL == false)
                            {
                                tlkarsiligi = tlkarsiligi * (1 + Convert.ToDouble(kdv) / 100);
                            }
                        }
                        else
                        {
                            if (satir.KDVDAHIL == true)
                            {
                                tlkarsiligi = tlkarsiligi / (1 + Convert.ToDouble(kdv) / 100);
                            }
                        }

                        teklif.gv_TeklifSatirlari.SetFocusedRowCellValue("FIYAT", tlkarsiligi);
                    }
                }
                // DÖVİZ FİYAT KISMI
                else if (tip == 2)
                {


                    if (teklif.SatirlarParaBirimi.SelectedIndex == 0 || teklif.SatirlarParaBirimi.SelectedIndex == 1)
                    {
                        dovizkuru = Convert.ToDouble(teklif.btn_raporlamakuru.Text);
                        if (dovizkod == "TL")
                        {
                            double sonuc = fiyat / dovizkuru;
                            teklif.gv_TeklifSatirlari.SetFocusedRowCellValue("DOVIZLIFIYAT", sonuc);
                        }
                        else
                        {
                            double sonuc = (fiyat * kur) / dovizkuru;
                            teklif.gv_TeklifSatirlari.SetFocusedRowCellValue("DOVIZLIFIYAT", sonuc);
                        }

                    }
                    else if (teklif.SatirlarParaBirimi.SelectedIndex == 2)
                    {
                        dovizkuru = Convert.ToDouble(teklif.btn_islemkuru.Text);
                        if (dovizkod == "TL")
                        {
                            double sonuc = fiyat / dovizkuru;
                            teklif.gv_TeklifSatirlari.SetFocusedRowCellValue("DOVIZLIFIYAT", sonuc);
                        }
                        else
                        {
                            double sonuc = (fiyat * kur) / dovizkuru;
                            teklif.gv_TeklifSatirlari.SetFocusedRowCellValue("DOVIZLIFIYAT", sonuc);
                        }
                    }
                    else
                    {
                        double satirdovizkuru = Convert.ToDouble(teklif.gv_TeklifSatirlari.GetFocusedRowCellValue("SATIRDOVIZKURU"));
                        string dövizkodu = teklif.gv_TeklifSatirlari.GetFocusedRowCellValue("SATIRDOVIZKODU").ToString();
                        dovizkuru = Convert.ToDouble(teklif.btn_islemkuru.Text);
                        if (dövizkodu == dovizkod)
                        {
                            teklif.gv_TeklifSatirlari.SetFocusedRowCellValue("FIYAT", fiyat);
                            teklif.gv_TeklifSatirlari.SetFocusedRowCellValue("DOVIZLIFIYAT", fiyat);
                        }
                        else
                        {
                            double sonuc = (fiyat * kur) / satirdovizkuru;
                            teklif.gv_TeklifSatirlari.SetFocusedRowCellValue("DOVIZLIFIYAT", fiyat);
                            teklif.gv_TeklifSatirlari.SetFocusedRowCellValue("FIYAT", sonuc);

                        }
                    }
                }
                this.Close();
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (grid_carisonsatislist.Visible == true)
            {
                grid_carisonsatislist.ShowPrintPreview();
            }
            else
            {
                grid__teklificin.ShowPrintPreview();
            }
        }

        private void frmCariSonSatisListesi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                simpleButton1_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F4) {
                simpleButton2_Click(sender, e);
            }
        }
    }
}