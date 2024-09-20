using DevExpress.CodeParser;
using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using LOGO_XERO.Models.GenelKullanim;
using LOGO_XERO.Models.LOGO_M;
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
    public partial class frmStokFiyatListesi : DevExpress.XtraEditors.XtraForm
    {
        public frmTeklifOlustur TeklifFormu;
        SQLConnection clas = new SQLConnection();
        Islemler isl = new Islemler();
        int tip;
        string firma;
        string donem;
        string itemcode;
        frmAnaForm ana;
        LOGO_XERO_PARAMETRELER parametre = new LOGO_XERO_PARAMETRELER();
        L_CAPIFIRM firmaLogoBilgi = new L_CAPIFIRM();
        public frmStokFiyatListesi()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            parametre = ana.parametre;
            firmaLogoBilgi = ana.firmaBilgisi;
        }
        public frmStokFiyatListesi(frmTeklifOlustur _tklf, int trkod, string _firma, string _donem, string _itemcode)
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            parametre = ana.parametre;
            firmaLogoBilgi = ana.firmaBilgisi;
            TeklifFormu = _tklf;
            tip = trkod;
            firma = _firma;
            donem = _donem;
            itemcode = _itemcode;
        }
        public void ListeyiGetir(int tip, string firma, string itemcode)
        {
            List<STOK_FIYATLISTESI_MODELI> liste = new List<STOK_FIYATLISTESI_MODELI>();
            string sorgu = "";
            if (tip == 8) //satıs
            {
                sorgu = $@"select  CAST ( P.INCVAT AS bit) KDVDAHIL, P.CYPHCODE YETKIKODU, P.CLSPECODE CARIHESAPOZELKOD,P.DEFINITION_ ACIKLAMA,CASE WHEN P.INCVAT=0 THEN 'Hariç' else 'Dahil' end as KDV ,(select TOP 1 CURCODE from L_CURRENCYLIST WHERE CURTYPE=P.CURRENCY)DOVIZ, ISNULL(P.PRICE,0) FIYAT ,P.CURRENCY from LG_{firma}_ITEMS IT
INNER JOIN LG_{firma}_PRCLIST P ON IT.LOGICALREF=P.CARDREF
 WHERE IT.CODE='{itemcode}' AND P.PTYPE=2 AND P.ACTIVE=0 ";

            }
            if (tip == 1)
            {
                sorgu = $@"select  CAST ( P.INCVAT AS bit) KDVDAHIL,P.CYPHCODE YETKIKODU, P.CLSPECODE CARIHESAPOZELKOD,P.DEFINITION_ ACIKLAMA,CASE WHEN P.INCVAT=0 THEN 'Hariç' else 'Dahil' end as KDV ,(select TOP 1 CURCODE from L_CURRENCYLIST WHERE CURTYPE=P.CURRENCY)DOVIZ, ISNULL(P.PRICE,0) FIYAT ,P.CURRENCY from LG_{firma}_ITEMS IT
INNER JOIN LG_{firma}_PRCLIST P ON IT.LOGICALREF=P.CARDREF
 WHERE IT.CODE='{itemcode}' AND P.PTYPE=1 AND P.ACTIVE=0 ";

            }

            using (LogoContext db = new LogoContext())
            {
                liste = db.Database.SqlQuery<STOK_FIYATLISTESI_MODELI>(sorgu).ToList();
            }
            grid.DataSource = liste;
            grid.RefreshDataSource();
            grid.Refresh();
        }
        private void frmCariSonSatisFiyatListesi_Load(object sender, EventArgs e)
        {
            ListeyiGetir(tip, firma, itemcode);
        }
        private void grid_DoubleClick(object sender, EventArgs e)
        {
            using (LogoContext db = new LogoContext())
            {
                STOK_FIYATLISTESI_MODELI row = (STOK_FIYATLISTESI_MODELI)gridView1.GetFocusedRow();
                if (row != null)
                {
                    double kdv = Convert.ToDouble(TeklifFormu.gv_TeklifSatirlari.GetRowCellValue(TeklifFormu.gv_TeklifSatirlari.FocusedRowHandle, "KDV").ToString());
                    double fiyat = Convert.ToDouble(row.FIYAT);
                    double dovizkuru = 0;
                    short _firma = Convert.ToInt16(firma);
                    string dovizkod = row.DOVIZ;
                    double kur = isl.RatesDovizKuruDondur(parametre, firmaLogoBilgi, row.CURRENCY, firma, donem);
                    //FİYAT KISMI
                    if (row.CURRENCY == 160) //TL İSE                                                                
                    {
                        if (TeklifFormu.ck_kdvdahil.Checked)
                        {
                            if (row.KDVDAHIL == false)
                            {
                                fiyat = fiyat * (1 + Convert.ToDouble(kdv) / 100);
                            }
                        }
                        else
                        {
                            if (row.KDVDAHIL == true)
                            {
                                fiyat = fiyat / (1 + Convert.ToDouble(kdv) / 100);
                            }
                        }

                        TeklifFormu.gv_TeklifSatirlari.SetFocusedRowCellValue("FIYAT", fiyat);
                    }
                    else
                    {
                        double tlkarsiligi = kur * fiyat;
                        if (TeklifFormu.ck_kdvdahil.Checked)
                        {
                            if (row.KDVDAHIL == false)
                            {
                                tlkarsiligi = tlkarsiligi * (1 + Convert.ToDouble(kdv) / 100);
                            }
                        }
                        else
                        {
                            if (row.KDVDAHIL == true)
                            {
                                tlkarsiligi = tlkarsiligi / (1 + Convert.ToDouble(kdv) / 100);
                            }
                        }

                        TeklifFormu.gv_TeklifSatirlari.SetFocusedRowCellValue("FIYAT", tlkarsiligi);
                    }
                    // DÖVİZ FİYAT KISMI
                    if (TeklifFormu.SatirlarParaBirimi.SelectedIndex == 0 || TeklifFormu.SatirlarParaBirimi.SelectedIndex == 1)
                    {
                        dovizkuru = Convert.ToDouble(TeklifFormu.btn_raporlamakuru.Text);
                        if (dovizkod == "TL")
                        {
                            double sonuc = fiyat / dovizkuru;
                            TeklifFormu.gv_TeklifSatirlari.SetFocusedRowCellValue("DOVIZLIFIYAT", sonuc);
                        }
                        else
                        {
                            double sonuc = (fiyat * kur) / dovizkuru;
                            TeklifFormu.gv_TeklifSatirlari.SetFocusedRowCellValue("DOVIZLIFIYAT", sonuc);
                        }

                    }
                    else if (TeklifFormu.SatirlarParaBirimi.SelectedIndex == 2)
                    {
                        dovizkuru = Convert.ToDouble(TeklifFormu.btn_islemkuru.Text);
                        if (dovizkod == "TL")
                        {
                            double sonuc = fiyat / dovizkuru;
                            TeklifFormu.gv_TeklifSatirlari.SetFocusedRowCellValue("DOVIZLIFIYAT", sonuc);
                        }
                        else
                        {
                            double sonuc = (fiyat * kur) / dovizkuru;
                            TeklifFormu.gv_TeklifSatirlari.SetFocusedRowCellValue("DOVIZLIFIYAT", sonuc);
                        }
                    }
                    else
                    {
                        double satirdovizkuru = Convert.ToDouble(TeklifFormu.gv_TeklifSatirlari.GetFocusedRowCellValue("SATIRDOVIZKURU"));
                        string dövizkodu = TeklifFormu.gv_TeklifSatirlari.GetFocusedRowCellValue("SATIRDOVIZKODU").ToString();
                        dovizkuru = Convert.ToDouble(TeklifFormu.btn_islemkuru.Text);
                        if (dövizkodu == dovizkod)
                        {
                            TeklifFormu.gv_TeklifSatirlari.SetFocusedRowCellValue("FIYAT", fiyat);
                            TeklifFormu.gv_TeklifSatirlari.SetFocusedRowCellValue("DOVIZLIFIYAT", fiyat);
                        }
                        else
                        {
                            double sonuc = (fiyat * kur) / satirdovizkuru;
                            TeklifFormu.gv_TeklifSatirlari.SetFocusedRowCellValue("FIYAT", sonuc);
                            TeklifFormu.gv_TeklifSatirlari.SetFocusedRowCellValue("DOVIZLIFIYAT", fiyat);
                        }
                    }
                }


            }


            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStokFiyatListesi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                simpleButton1_Click(sender, e);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
