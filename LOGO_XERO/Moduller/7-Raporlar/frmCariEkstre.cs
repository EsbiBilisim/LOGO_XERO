using Dapper;
using DevExpress.CodeParser;
using DevExpress.Utils; 
using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LOGO_XERO.Models.GenelKullanim;

namespace LOGO_XERO.Moduller._7_Raporlar
{
    public partial class frmCariEkstre : DevExpress.XtraEditors.XtraForm
    {
        Logic.GenelListeler islem = new Logic.GenelListeler(); 
        Islemler isl = new Islemler(); 
        DateTime vadetarihi;
        frmAnaForm ana;
        string firma;
        string donem;
        public string carikod;
        List<CariEkstreDovizliDetay> detayliste;
        public frmCariEkstre(string cariunvan,string _carikodu)
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            firma = ana.lk_firma.EditValue.ToString();
            donem = ana.lk_donem.EditValue.ToString();
            txtUnvan.Text = cariunvan;
            txtCariKodu.Text = _carikodu;
            carikod = _carikodu;
            txtSon.DateTime = DateTime.Now;
            txtIlk.DateTime = DateTime.Now.AddYears(-1);
        }
        
        public void Yenile() 
        {
            string secilisorgu = " ";
            if (ck.Checked == true)
            {
                secilisorgu = " ";
            }
            else { secilisorgu = " AND c1.CLIENTREF=c2.CLIENTREF"; }
            grid_cariekstre.DataSource = islem.CariEkstreGetir(ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString(), carikod,txtIlk.DateTime.ToString("yyyy-MM-dd"), txtSon.DateTime.ToString("yyyy-MM-dd"),secilisorgu);
            grid_cariekstre.RefreshDataSource();
            grid_cariekstre.Refresh();

            //detayliste = detaygetir();
        }
        public List<CariEkstreDovizliDetay> detaygetir(int logicalref)
        {

            using (LogoContext db = new LogoContext())
            {
                string detay = $@"SELECT F.LOGICALREF FISNO,  
                     CASE WHEN S.LINETYPE = 4 THEN (SELECT TOP 1 CODE FROM LG_{firma}_SRVCARD WHERE LOGICALREF = S.STOCKREF) 
                                     ELSE 
                                     I.CODE END [STOKKODU],
                    
                     CASE WHEN S.LINETYPE = 4 THEN (SELECT TOP 1 DEFINITION_ FROM LG_{firma}_SRVCARD WHERE LOGICALREF = S.STOCKREF) 
                                     ELSE 
                                     I.NAME END [STOKCINSI],
                     S.LINEEXP [ACIKLAMA],
                     S.AMOUNT [MIKTAR], ROUND(ISNULL((NULLIF(S.LINENET,0) / NULLIF(S.AMOUNT,0)),0),2) [FIYAT], S.VAT [KDV], ROUND((S.LINENET+S.VATAMNT),2) [TUTAR]
                     FROM LG_{firma}_{donem}_STLINE S With (Nolock)
                     LEFT OUTER JOIN LG_{firma}_{donem}_INVOICE F ON S.INVOICEREF=F.LOGICALREF
                     LEFT OUTER JOIN LG_{firma}_ITEMS I ON S.STOCKREF=I.LOGICALREF
                     LEFT OUTER JOIN LG_{firma}_CLCARD C ON F.CLIENTREF=C.LOGICALREF
                     WHERE C.CODE='{txtCariKodu.Text}' AND F.LOGICALREF = {logicalref} AND S.CANCELLED=0 AND S.LINETYPE IN (0,4)";

                List<CariEkstreDovizliDetay> liste = db.Database.SqlQuery<CariEkstreDovizliDetay>(detay).ToList();
                return liste;
            }
        }

        private void frmCariEkstre_Load(object sender, EventArgs e)
        {

        }

        private void grid_cariekstre_DoubleClick(object sender, EventArgs e)
        {
            if (gv_cariekstre.FocusedRowHandle < 0) return;
            string fisRef = gv_cariekstre.GetRowCellValue(gv_cariekstre.FocusedRowHandle, "SREF").ToString();
            string fisTuru = gv_cariekstre.GetRowCellValue(gv_cariekstre.FocusedRowHandle, "FISTURU").ToString();
            if (fisTuru.ToLower().Contains("fatura")) 
            {
                frmCariEkstreFaturaDetay frm = new frmCariEkstreFaturaDetay();
                frm.Liste(Convert.ToInt32(fisRef));
                frm.Text = "Fatura Detayı";
                frm.ShowDialog();
            }
        }

     

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtIlk.DateTime.ToString()) && !string.IsNullOrWhiteSpace(txtSon.DateTime.ToString()))
            {
                Yenile();
            }
           
        }

        private void gv_cariekstre_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView dView = gv_cariekstre.GetDetailView(e.RowHandle, 0) as DevExpress.XtraGrid.Views.Grid.GridView;


            dView.Columns["FISNO"].Visible = false;

            dView.Columns["FIYAT"].DisplayFormat.FormatType = FormatType.Numeric;
            dView.Columns["FIYAT"].DisplayFormat.FormatString = "n2";
            dView.Columns["TUTAR"].DisplayFormat.FormatType = FormatType.Numeric;
            dView.Columns["TUTAR"].DisplayFormat.FormatString = "n2";
        }

        private void gv_cariekstre_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            LOGO_XERO_CARI_EKSTRE row = (LOGO_XERO_CARI_EKSTRE)gv_cariekstre.GetFocusedRow();
            if (row != null)
            {

                if (row.SREF == 0)
                {

                }
                else
                { 
                        List<CariEkstreDovizliDetay> liste = detaygetir(row.SREF);
                        e.ChildList = liste; 
                }  
            }
            else
            {
                e.ChildList = new List<CariEkstreDovizliDetay>();
            }
        }

        private void gv_cariekstre_MasterRowGetRelationCount(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            grid_cariekstre.ShowPrintPreview();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            isl.GridDetayGoster(gv_cariekstre);
            islem.yazdir(grid_cariekstre);
            isl.GridDetayKapat(gv_cariekstre);
        }
    }
}