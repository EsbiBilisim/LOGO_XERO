using DevExpress.CodeParser;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Import.Doc;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using LOGO_XERO.Models.GenelKullanim;
using LOGO_XERO.Models.LOGO_XERO_M;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGO_XERO.Moduller.GenelListeler
{
    public partial class frmKampanyaFiyat : DevExpress.XtraEditors.XtraForm
    {
        frmTeklifOlustur teklif;
        frmAnaForm ana;
        Islemler islem = new Islemler();
        public int tip = 0;
        public frmKampanyaFiyat(frmTeklifOlustur _tklf)
        {
            InitializeComponent();
            teklif = _tklf;
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            islem.TasarimGetir(gv_kampanyafiyatlist, ana._Kullanici.ID, this.Name, grid_kampanyafiyatlist.Name);
        }

        private void frmKampanyaFiyat_Load(object sender, EventArgs e)
        {

        }
        public void Listele(string stokkodu) 
        {
            DateTime tarih = DateTime.Now;

            using (LogoContext db = new LogoContext())
            {
                string sql = $@"SELECT P.CYPHCODE [KAMPANYAKODU], 
                ISNULL((SELECT TOP 1 L.CURCODE                
                FROM L_CURRENCYLIST L
                WHERE CURTYPE=P.CURRENCY AND FIRMNR={ana.lk_firma.EditValue.ToString()}),'TL') [DOVIZ],
                P.CURRENCY [DOVIZKODU],
                ISNULL(P.CLSPECODE5,0) [LISTEFIYATI], 
                ISNULL(P.TRSPECODE,0) [ISKONTOORANI], 
                CASE 
             WHEN  P.INCVAT=1 THEN  (P.PRICE/(1+(I.VAT/100))) * (ISNULL((SELECT TOP 1 RATES{ana.parametre.KULLANILACAKDOVIZTURU} FROM LG_EXCHANGE_{ana.lk_firma.EditValue.ToString()} WHERE EDATE='{tarih.ToString("yyyy-MM-dd")}' AND CRTYPE=P.CURRENCY),1))
             WHEN  P.INCVAT=0 THEN  (P.PRICE) * (ISNULL((SELECT TOP 1 RATES{ana.parametre.KULLANILACAKDOVIZTURU} FROM LG_EXCHANGE_{ana.lk_firma.EditValue.ToString()} WHERE EDATE='{tarih.ToString("yyyy-MM-dd")}' AND CRTYPE=P.CURRENCY),1))
             END   [KAMPANYATLFIYATI],
                ISNULL(P.PRICE,0) [KAMPANYAFIYATI]
                FROM LG_{ana.lk_firma.EditValue.ToString()}_PRCLIST P 
                LEFT OUTER JOIN LG_{ana.lk_firma.EditValue.ToString()}_ITEMS I ON P.CARDREF=I.LOGICALREF
                
                WHERE P.PTYPE=2 AND P.ACTIVE=0 AND I.CODE='{stokkodu}' AND I.CYPHCODE!=''
                GROUP BY P.CYPHCODE,P.CURRENCY,P.CLSPECODE5,P.TRSPECODE,P.PRICE,P.INCVAT,I.VAT ";
                List<KAMPANYA_FIYAT_LISTE> liste = db.Database.SqlQuery<KAMPANYA_FIYAT_LISTE>(sql).ToList();
                grid_kampanyafiyatlist.DataSource = liste;
                grid_kampanyafiyatlist.RefreshDataSource();
                grid_kampanyafiyatlist.Refresh();
            }
        }

        private void tasarımKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            islem.TasarimKaydet(gv_kampanyafiyatlist,ana._Kullanici.ID,this.Name,grid_kampanyafiyatlist.Name);
        }

        private void grid_kampanyafiyatlist_DoubleClick(object sender, EventArgs e)
        {
            if (gv_kampanyafiyatlist.GetFocusedRow() != null)
            {
                KAMPANYA_FIYAT_LISTE satir = (KAMPANYA_FIYAT_LISTE)gv_kampanyafiyatlist.GetFocusedRow();
                if (teklif.gv_TeklifSatirlari.GetFocusedRow() != null)
                {
                    LOGO_XERO_TEKLIF_SATIR teklifsatir = (LOGO_XERO_TEKLIF_SATIR)teklif.gv_TeklifSatirlari.GetFocusedRow();
                    double kdv = Convert.ToDouble(teklif.gv_TeklifSatirlari.GetRowCellValue(teklif.gv_TeklifSatirlari.FocusedRowHandle, "KDV").ToString());
                    double fiyat = Convert.ToDouble(satir.KAMPANYAFIYATI);
                    double dovizkuru = 0;
                    short _firma = Convert.ToInt16(Convert.ToInt16(ana.lk_firma.EditValue));
                    string dovizkod = satir.DOVIZ;
                    double kur = islem.RatesDovizKuruDondur(ana.parametre, ana.firmaBilgisi, satir.DOVIZKODU, ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString());
                    //FİYAT KISMI
                    if (tip == 1)
                    {
                        if (satir.DOVIZKODU == 160 || satir.DOVIZKODU == 0) //TL İSE                                                                
                        {
                            //if (teklif.ck_kdvdahil.Checked)
                            //{
                            //    if (satir.KDVDAHIL == false)
                            //    {
                                    fiyat = fiyat * (1 + Convert.ToDouble(kdv) / 100);
                            //    }
                            //}
                            //else
                            //{
                            //    if (satir.KDVDAHIL == true)
                            //    {
                            //        fiyat = fiyat / (1 + Convert.ToDouble(kdv) / 100);
                            //    }
                            //}

                            teklif.gv_TeklifSatirlari.SetFocusedRowCellValue("FIYAT", fiyat);
                        }
                        else
                        {
                            double tlkarsiligi = kur * fiyat;
                            //if (teklif.ck_kdvdahil.Checked)
                            //{
                            //    if (satir.KDVDAHIL == false)
                            //    {
                                    tlkarsiligi = tlkarsiligi * (1 + Convert.ToDouble(kdv) / 100);
                            //    }
                            //}
                            //else
                            //{
                            //    if (satir.KDVDAHIL == true)
                            //    {
                            //        tlkarsiligi = tlkarsiligi / (1 + Convert.ToDouble(kdv) / 100);
                            //    }
                            //}

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
        }

        private void frmKampanyaFiyat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { simpleButton1_Click(sender, e); }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}