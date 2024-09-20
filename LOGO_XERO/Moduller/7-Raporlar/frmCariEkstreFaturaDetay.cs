using DevExpress.CodeParser;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using LOGO_XERO.Models;
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

namespace LOGO_XERO.Moduller._7_Raporlar
{
    public partial class frmCariEkstreFaturaDetay : DevExpress.XtraEditors.XtraForm
    {
        SQLConnection clas = new SQLConnection();
        frmAnaForm ana;
        string firma,donem;
        public frmCariEkstreFaturaDetay()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            firma = ana.lk_firma.EditValue.ToString();
            donem = ana.lk_donem.EditValue.ToString();
        }
        public void Liste(int logicalRef)
        { 
            clas.Connect();
            string SQL = $@"SET ROWCOUNT 0  SELECT STLINE.DATE_ [TARİH],
                ITEMS.CODE [ÜRÜN KODU],
                CASE WHEN STLINE.LINETYPE=4 THEN (SELECT TOP 1 DEFINITION_ FROM LG_{firma}_SRVCARD WHERE LOGICALREF=STLINE.STOCKREF) 
                ELSE 
                ITEMS.NAME END [ÜRÜN CİNSİ],
                STLINE.AMOUNT [ADET], (STLINE.LINENET/STLINE.AMOUNT) [FİYAT],  
                STLINE.VATAMNT [KDV], STLINE.LINENET [TUTAR], STLINE.LINENET+STLINE.VATAMNT [KDVLİ TUTAR],
                ISNULL((SELECT TOP 1 ISNULL((NULLIF(LINENET,0)/NULLIF(AMOUNT,0)),0) 
                FROM LG_{firma}_{donem}_STLINE With (Nolock) WHERE STOCKREF=ITEMS.LOGICALREF AND DATE_<= STLINE.DATE_ AND CANCELLED=0 AND ((BILLED=1 AND TRCODE IN (1)) OR  (BILLED=0 AND TRCODE IN (13,14,15,50))) AND LINETYPE =0   ORDER BY DATE_ DESC),0) [SON ALIS]
                FROM LG_{firma}_{donem}_STLINE STLINE WITH(NOLOCK)  
                LEFT OUTER JOIN LG_{firma}_CLCARD CLCARD WITH(NOLOCK) ON (STLINE.CLIENTREF = CLCARD.LOGICALREF)  
                LEFT OUTER JOIN LG_{firma}_ITEMS ITEMS WITH(NOLOCK) ON (STLINE.STOCKREF = ITEMS.LOGICALREF)  
                WHERE STLINE.INVOICEREF = {logicalRef}
                AND (STLINE.CANCELLED = 0)  
                AND LINETYPE IN(0,4) 
                Order By STLINE.DATE_,STLINE.FTIME;

                SELECT I.DATE_, I.FICHENO, I.DOCODE, C.CODE, C.DEFINITION_,I.SPECODE,I.GENEXP1,I.GENEXP2,I.GENEXP3,
                (SELECT TOP 1 DEFINITION_ FROM LG_SLSMAN WHERE LOGICALREF=I.SALESMANREF AND FIRMNR=
            {firma}) SALESMANNAME,
                (SELECT TOP 1 DATE_ FROM LG_{firma}_{donem}_PAYTRANS With (Nolock) WHERE FICHEREF=I.LOGICALREF AND PROCDATE=I.DATE_) [VADETARIHI]
                FROM LG_{firma}_{donem}_INVOICE I
                LEFT OUTER JOIN LG_{firma}_CLCARD C WITH(NOLOCK) ON (I.CLIENTREF = C.LOGICALREF)  
                WHERE I.LOGICALREF={logicalRef}";
            DataSet ks = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand sorgu = new SqlCommand(SQL, clas.Conn);
            da.SelectCommand = sorgu;
            sorgu.CommandTimeout = 0;
            da.Fill(ks);
            grid.DataSource = ks.Tables[0];
            gridView1.OptionsBehavior.Editable = false;
            gridView1.Columns["SON ALIS"].AppearanceCell.ForeColor = Color.DarkRed;
            gridView1.Columns["SON ALIS"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            gridView1.Columns[2].Width = 200;
            gridView1.Columns[4].DisplayFormat.FormatType = FormatType.Numeric;
            gridView1.Columns[4].DisplayFormat.FormatString = "n2";
            gridView1.Columns[5].DisplayFormat.FormatType = FormatType.Numeric;
            gridView1.Columns[5].DisplayFormat.FormatString = "n2";
            gridView1.Columns[6].DisplayFormat.FormatType = FormatType.Numeric;
            gridView1.Columns[6].DisplayFormat.FormatString = "n2";
            gridView1.Columns[7].DisplayFormat.FormatType = FormatType.Numeric;
            gridView1.Columns[7].DisplayFormat.FormatString = "n2";
            gridView1.Columns["SON ALIS"].DisplayFormat.FormatType = FormatType.Numeric;
            gridView1.Columns["SON ALIS"].DisplayFormat.FormatString = "n2";

            gridView1.Columns[5].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[5].SummaryItem.DisplayFormat = "{0:n2}";
            gridView1.Columns[6].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[6].SummaryItem.DisplayFormat = "{0:n2}";
            gridView1.Columns[7].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[7].SummaryItem.DisplayFormat = "{0:n2}";

            if (ks.Tables[1].Rows.Count > 0)
            {
                lblTarih.Text = ks.Tables[1].Rows[0]["DATE_"].ToString().Substring(0, 10);
                lblFisNo.Text = ks.Tables[1].Rows[0]["FICHENO"].ToString();
                lblBelgeNo.Text = ks.Tables[1].Rows[0]["DOCODE"].ToString();
                lblCariKodu.Text = ks.Tables[1].Rows[0]["CODE"].ToString();
                lblUnvani.Text = ks.Tables[1].Rows[0]["DEFINITION_"].ToString();
                lblSatisElemani.Text = ks.Tables[1].Rows[0]["SALESMANNAME"].ToString();
                lblOzelKod.Text = ks.Tables[1].Rows[0]["SPECODE"].ToString();
                lblAciklama.Text = ks.Tables[1].Rows[0]["GENEXP1"].ToString() + " " + ks.Tables[1].Rows[0]["GENEXP2"].ToString() + " " + ks.Tables[1].Rows[0]["GENEXP3"].ToString();
                lblVadeTarihi.Text = ks.Tables[1].Rows[0]["VADETARIHI"].ToString();
            }
            else
            {
                lblTarih.Text = "";
                lblFisNo.Text = "";
                lblBelgeNo.Text = "";
                lblCariKodu.Text = "";
                lblUnvani.Text = "";
                lblSatisElemani.Text = "";
                lblOzelKod.Text = "";
                lblAciklama.Text = "";
            }
        }
    }
}