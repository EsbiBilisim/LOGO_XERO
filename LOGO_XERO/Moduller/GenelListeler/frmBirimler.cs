using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using LOGO_XERO.Models.GenelKullanim;
using LOGO_XERO.Models.LOGO_M;
using LOGO_XERO.Models.LOGO_XERO_M;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using UnityObjects;

namespace LOGO_XERO.Moduller.GenelListeler
{
    public partial class frmBirimler : DevExpress.XtraEditors.XtraForm
    {
        SQLConnection clas = new SQLConnection();
        frmAnaForm ana;
        string firma;
        Islemler islem = new Islemler();
        public LOGO_XERO_TEKLIF_SATIR seciliTeklifSatir { get; set; }

        frmTeklifOlustur _frmTeklifOlustur;
        frmStokKart frmStokKart;
        public frmBirimler(frmTeklifOlustur frmTeklifOlustur)
        {
            InitializeComponent();
            _frmTeklifOlustur = frmTeklifOlustur;
            ana = System.Windows.Forms.Application.OpenForms["frmAnaForm"] as frmAnaForm;
            firma = ana.lk_firma.EditValue.ToString();
        }
        public frmBirimler(frmStokKart _frmStokKart)
        {
            InitializeComponent();
            frmStokKart = _frmStokKart;
            ana = System.Windows.Forms.Application.OpenForms["frmAnaForm"] as frmAnaForm;
            firma = ana.lk_firma.EditValue.ToString();
        }
        private void frmBirimler_Load(object sender, EventArgs e)
        {
            List<STOK_GENEL_BIRIM_LISTESI> birimler = new List<STOK_GENEL_BIRIM_LISTESI>();
            string sql = "";
            if (seciliTeklifSatir != null)
            {
                if (seciliTeklifSatir.STOKLOGICALREF == null || seciliTeklifSatir.STOKLOGICALREF == 0)
                {
                    sql = string.Format($@"SELECT LOGICALREF, CODE [BIRIMKODU],NAME [BIRIMACIKLAMA],CAST (0 AS FLOAT)CONVFACT1,CAST (0 AS FLOAT) CONVFACT2 
            FROM LG_{firma}_UNITSETF WHERE CARDTYPE=5");
                }
                else
                {
                    sql = string.Format($@"SELECT UNITL.UNITSETREF LOGICALREF, UNITL.CODE [BIRIMKODU],UNITL.NAME [BIRIMACIKLAMA],cast(ITMA.CONVFACT1 as float)CONVFACT1,cast(ITMA.CONVFACT2 as float)CONVFACT2 
            FROM LG_{firma}_ITMUNITA ITMA 
            LEFT OUTER JOIN LG_{firma}_UNITSETL UNITL ON ITMA.UNITLINEREF=UNITL.LOGICALREF
            LEFT OUTER JOIN LG_{firma}_ITEMS I ON ITMA.ITEMREF=I.LOGICALREF
            WHERE I.LOGICALREF = {seciliTeklifSatir.STOKLOGICALREF}");
                }
            }
            else if (frmStokKart != null)
            {
                sql = $@"Select LOGICALREF, CODE [BIRIMKODU], NAME [BIRIMACIKLAMA],cast(0 as float) CONVFACT1, cast(0 as float) CONVFACT2  
            FROM LG_{firma}_UNITSETF WHERE CARDTYPE=5";
            }
            using (LogoContext db = new LogoContext())
            {
                birimler = db.Database.SqlQuery<STOK_GENEL_BIRIM_LISTESI>(sql).ToList();
                birimler.ForEach(s => s.BOL = s.CONVFACT1 / s.CONVFACT2);
            }

            gridBirimler.DataSource = birimler;

        }
        private void gridBirimler_DoubleClick(object sender, EventArgs e)
        {
            STOK_GENEL_BIRIM_LISTESI row = (STOK_GENEL_BIRIM_LISTESI)gv_birimler.GetFocusedRow();
            if (row != null)
            {
                if (_frmTeklifOlustur != null)
                {
                    _frmTeklifOlustur.gv_TeklifSatirlari.SetRowCellValue(_frmTeklifOlustur.gv_TeklifSatirlari.FocusedRowHandle, _frmTeklifOlustur.grdBirim, row.BIRIMKODU);
                }
                if (frmStokKart != null)
                {
                    frmStokKart.txt_BirimKodu.Text = row.BIRIMKODU;
                    frmStokKart.txt_BirimAciklama.Text = row.BIRIMACIKLAMA;
                    List<LG_UNITSETL> altbirimler= islem.BiriminAltBirimleriniListele(row.LOGICALREF);
                    LG_UNITSETL anabirim = altbirimler.Where(s => s.MAINUNIT == 1).FirstOrDefault();
                    frmStokKart.grid_Birimler.DataSource = altbirimler;
                    if (anabirim != null)
                    {
                        frmStokKart.lbl_BirimmiAnaBirimmi.Text = "Ana Birim";
                        frmStokKart.txt_SecilenBirimKodu.Text = anabirim.CODE;
                        frmStokKart.txt_SecilenBirimAciklamasi.Text = anabirim.NAME;
                        frmStokKart.txt_BirimCarpani.Text = anabirim.CONVFACT1.ToString();
                        frmStokKart.txt_AnaBirimCarpani.Text = anabirim.CONVFACT2.ToString();
                        frmStokKart.lbl_BirimKodu.Text = anabirim.CODE;
                        frmStokKart.lbl_AnabirimKodu.Text = anabirim.CODE;
                        frmStokKart.txt_BirimCarpani.ReadOnly = true;
                        frmStokKart.txt_AnaBirimCarpani.ReadOnly = true;
                    }                  
                }
                this.Close();
            }
        }
    }
}