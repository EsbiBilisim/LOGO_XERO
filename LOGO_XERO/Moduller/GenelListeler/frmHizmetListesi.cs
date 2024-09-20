using DevExpress.CodeParser;
using DevExpress.XtraEditors;
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
    public partial class frmHizmetListesi : DevExpress.XtraEditors.XtraForm
    {
        frmTeklifOlustur frm = new frmTeklifOlustur();
        int tur;
        public frmHizmetListesi(frmTeklifOlustur _frmtkl , int _tur)
        {
            InitializeComponent();
            frm = _frmtkl;
            tur = _tur;
            HizmetleriGetir();
        }

        public void HizmetleriGetir(){
            using (LogoContext db = new LogoContext())
            {
                grid_HizmetListesi.DataSource = db.LOGO_XERO_HIZMETLISTESI.Where(s=>s.MINMIKTAR == tur).ToList();
                grid_HizmetListesi.RefreshDataSource();
                grid_HizmetListesi.Refresh();
            }
        }
        private void grid_HizmetListesi_DoubleClick(object sender, EventArgs e)
        {
            if (frm.gv_TeklifSatirlari.GetFocusedRow() != null)
            {
                LOGO_XERO_TEKLIF_SATIR FrmSatir = (LOGO_XERO_TEKLIF_SATIR)frm.gv_TeklifSatirlari.GetFocusedRow();
                if (FrmSatir != null )
                {
                    if (gv_HizmetListesi.GetFocusedRow() != null)
                    {
                        LOGO_XERO_HIZMETLISTESI hizmet = (LOGO_XERO_HIZMETLISTESI)gv_HizmetListesi.GetFocusedRow();
                        var raporlamaturu = frm.lk_RaporlamaDoviz.EditValue.ToString();
                        var islemturu = frm.Lk_IslemDoviz.EditValue.ToString();
                        frm.gv_TeklifSatirlari.SetFocusedRowCellValue("STOKLOGICALREF", hizmet.LOGICALREF);
                        frm.gv_TeklifSatirlari.SetFocusedRowCellValue("STOKKODU", hizmet.STOKKODU);
                        frm.gv_TeklifSatirlari.SetFocusedRowCellValue("STOKADI", hizmet.STOKCINSI);
                        frm.gv_TeklifSatirlari.SetFocusedRowCellValue("FIYATGURUBU", "testfiyatgrubu");
                        frm.gv_TeklifSatirlari.SetFocusedRowCellValue("BIRIM", hizmet.BIRIM);
                        frm.gv_TeklifSatirlari.SetFocusedRowCellValue("MARKA", hizmet.MARKA);
                        frm.gv_TeklifSatirlari.SetFocusedRowCellValue("KDV", hizmet.KDV);
                        frm.gv_TeklifSatirlari.SetFocusedRowCellValue("OZELKOD1", hizmet.OZELKOD1);
                        frm.gv_TeklifSatirlari.SetFocusedRowCellValue("OZKODACIKLAMA", hizmet.OZKODACIKLAMA);
                        frm.gv_TeklifSatirlari.SetFocusedRowCellValue("SATIRTIPI", "0");
                        frm.gv_TeklifSatirlari.SetFocusedRowCellValue("TEVKIFATLI", hizmet.TEVKIFAT);
                        frm.gv_TeklifSatirlari.SetFocusedRowCellValue("FIYAT", hizmet.LISTEFIYATI);
                        frm.gv_TeklifSatirlari.SetFocusedRowCellValue("ISKONTOYUZDESI1",0);
                        frm.gv_TeklifSatirlari.SetFocusedRowCellValue("ISKONTOYUZDESI2", 0);
                        frm.gv_TeklifSatirlari.SetFocusedRowCellValue("ISKONTOYUZDESI3", 0);
                        frm.gv_TeklifSatirlari.SetFocusedRowCellValue("MIKTAR",1);
                        frm.gv_TeklifSatirlari.SetFocusedRowCellValue("SATIRDOVIZKODU", 160);
                               
                        if (Convert.ToBoolean(hizmet.TEVKIFAT))
                        {
                            frm.gv_TeklifSatirlari.SetFocusedRowCellValue("TEVKIFATKODU", hizmet.TEVKIFATKODU);
                            frm.gv_TeklifSatirlari.SetFocusedRowCellValue("TEVKIFATBOLEN", hizmet.TEVKIFATBOLEN);
                            frm.gv_TeklifSatirlari.SetFocusedRowCellValue("TEVKIFATCARPAN", hizmet.TEVKIFATCARPAN); 
                        }
                        else
                        {
                            FrmSatir.TEVKIFATKODU = "";
                            FrmSatir.TEVKIFATBOLEN = 0;
                            FrmSatir.TEVKIFATCARPAN = 0;
                        }
                        frm.gv_TeklifSatirlari.SetFocusedRowCellValue("AMBAR", Convert.ToInt16(frm.lk_ambar.EditValue.ToString()));


                        frm.SatirEkle(2);
                        frm.SiraNoYenile();
                      
                    } 
                }
            }
          
        }
    }
}