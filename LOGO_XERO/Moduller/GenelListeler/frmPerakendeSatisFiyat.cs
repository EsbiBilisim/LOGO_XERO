using DevExpress.CodeParser;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Import.Doc;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
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
    public partial class frmPerakendeSatisFiyat : DevExpress.XtraEditors.XtraForm
    {
        frmTeklifOlustur teklif;
        frmAnaForm ana;
        public int tip = 0;
        Islemler islem = new Islemler();
        public frmPerakendeSatisFiyat(frmTeklifOlustur _tklf)
        {
            InitializeComponent();
            teklif = _tklf;
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            islem.TasarimGetir(gv_perakendesatis, ana._Kullanici.ID, this.Name, grid_perakendesatis.Name);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ListelePerakende(string stokkodu) 
        {
            using (LogoContext db = new LogoContext())
            {
                string sql = " ";
                string sutunad = "CYPHCODE";
                string filtre = "P";
                if (ana.parametre.FYTPRMT_OZELFIYATSECENEGI.ToString() == "2" && !string.IsNullOrWhiteSpace(ana.parametre.FYTPRMT_PERAKENDEFIYATGRUBU))
                {
                    sutunad = ana.parametre.OZELFIYATKARTSUTUNAD;
                    filtre = ana.parametre.FYTPRMT_PERAKENDEFIYATGRUBU;
                   
                }
                else if (ana.parametre.FYTPRMT_OZELFIYATSECENEGI.ToString() == "2") 
                {
                    
                }
                sql = $@"SELECT I.CODE [STOKKODU], I.NAME [STOKCINSI], I.VAT [KDV],
                P.CURRENCY [DOVIZKODU],
			    (SELECT TOP 1 CURCODE FROM L_CURRENCYLIST WHERE CURTYPE=P.CURRENCY AND FIRMNR={ana.lk_firma.EditValue.ToString()}) [DOVIZ],
                ISNULL(P.PRICE,0) [LISTEFIYATI]
                FROM LG_{ana.lk_firma.EditValue.ToString()}_ITEMS I 
                LEFT OUTER JOIN LG_{ana.lk_firma.EditValue.ToString()}_PRCLIST P ON I.LOGICALREF=P.CARDREF AND P.{ana.parametre.OZELFIYATKARTSUTUNAD} = '{ana.parametre.FYTPRMT_PERAKENDEFIYATGRUBU}'
                WHERE I. CODE='{stokkodu}' ";

                grid_perakendesatis.DataSource = db.Database.SqlQuery<PERAKENDE_SATIS_FIYAT>(sql).ToList();
                grid_perakendesatis.RefreshDataSource();
                grid_perakendesatis.Refresh();
            }
        }

        private void frmPerakendeSatisFiyat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                simpleButton1_Click(sender, e);
            }
        }

        private void frmPerakendeSatisFiyat_Load(object sender, EventArgs e)
        {
            ListelePerakende(teklif.gv_TeklifSatirlari.GetFocusedRowCellValue("STOKKODU").ToString());
        }

        private void tasarımKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            islem.TasarimKaydet(gv_perakendesatis, ana._Kullanici.ID, this.Name, grid_perakendesatis.Name);
        }

        private void grid_perakendesatis_DoubleClick(object sender, EventArgs e)
        {
            if (gv_perakendesatis.GetFocusedRow() != null)
            {
                PERAKENDE_SATIS_FIYAT satir = (PERAKENDE_SATIS_FIYAT)gv_perakendesatis.GetFocusedRow();
                if (teklif.gv_TeklifSatirlari.GetFocusedRow() != null)
                {
                    LOGO_XERO_TEKLIF_SATIR teklifsatir = (LOGO_XERO_TEKLIF_SATIR)teklif.gv_TeklifSatirlari.GetFocusedRow();
                    double kdv = Convert.ToDouble(teklif.gv_TeklifSatirlari.GetRowCellValue(teklif.gv_TeklifSatirlari.FocusedRowHandle, "KDV").ToString());
                    double fiyat = Convert.ToDouble(satir.LISTEFIYATI);
                    double dovizkuru = 0;
                    short _firma = Convert.ToInt16(Convert.ToInt16(ana.lk_firma.EditValue));
                    string dovizkod = satir.DOVIZ;
                    double kur = islem.RatesDovizKuruDondur(ana.parametre, ana.firmaBilgisi, satir.DOVIZKODU, ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString());
                    //FİYAT KISMI
                    if (tip == 1)
                    {
                        if (satir.DOVIZKODU == 160 || satir.DOVIZKODU == 0) //TL İSE                                                                
                        {
                             
                            fiyat = fiyat * (1 + Convert.ToDouble(kdv) / 100); 
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
                               // }
                            //}
                            //else
                            //{
                            //   if (satir.KDVDAHIL == true)
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
    }
}