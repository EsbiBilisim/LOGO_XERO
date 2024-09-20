using Dapper;
using DevExpress.CodeParser;
using DevExpress.DashboardWin.Design;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using LOGO_XERO.Models.GenelKullanim;
using LOGO_XERO.Models.LOGO_M;
using System;
using System.Collections.Generic; 
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace LOGO_XERO.Moduller._7_Raporlar
{
    public partial class frmCariEkstreDovizli : DevExpress.XtraEditors.XtraForm
    {
        SQLConnection clas = new SQLConnection();
        Islemler islem = new Islemler();
        frmAnaForm ana;
        string firma;
        string donem;
        public frmCariEkstreDovizli()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            firma = ana.lk_firma.EditValue.ToString(); 
            donem = ana.lk_donem.EditValue.ToString();
            txtIlk.DateTime = DateTime.Today.AddDays(-60);
            txtSon.DateTime = DateTime.Now;
            string cariKodu;
            cariKodu = txtCariKodu.Text;
            ck.Checked = false;
            // KurlariGetir();
            islem.DovizBilgileriDoldur(lkk_kurbilgi,firma);
        }
        string SQLMaster, SQLDetail;
        DataSet ks = new DataSet();
        public void KurlariGetir()
        {

            List<L_CURRENCYLIST> liste = islem.firmaKurBilgileriGetir(Convert.ToInt16(firma));
            lkk_kurbilgi.Properties.DataSource = liste;
            lkk_kurbilgi.Properties.ValueMember = "CURTYPE";
            lkk_kurbilgi.Properties.DisplayMember = "CURCODE";
            lkk_kurbilgi.Properties.PopulateViewColumns();  
        }
        public void Liste()
        {
            if (ck.Checked == true)
            {
                SQLMaster = string.Format(@"WITH cteHesap AS(SELECT ROW_NUMBER() OVER (ORDER BY CLF.DATE_) as TarihId, 
                C.CODE as BAYIKODU,
                CLF.SOURCEFREF AS SREF,
                CLF.DATE_,
                CASE WHEN CLF.MODULENR=4 THEN
                (SELECT TOP 1 P.DATE_ 
                FROM LG_{4}_{3}_PAYTRANS P WHERE FICHEREF= CLF.SOURCEFREF AND MODULENR=4) 
				ELSE NULL END VADETARIHI,
                CLF.TRANNO AS FISNO,
                --(SELECT TOP 1 CASE WHEN DURUM=1 THEN 'KAPALI' ELSE 'AÇIK' END FROM ASISTAN_FATURA_TIP With (Nolock) 
                --WHERE LOGICALREF=I.LOGICALREF) FATODEMETIP,
                case when CLF.TRCODE=1 then 'Nakit Tahsilat'
                when CLF.TRCODE=2 then 'Nakit Ödeme' 
                when CLF.TRCODE=3 then 'Borç Dekontu' 
                when CLF.TRCODE=5 then 'Virman Fişi'  
                when CLF.TRCODE=6 then 'Alım iade faturası' 
                when CLF.TRCODE=12 then 'Özel Fiş'
                when CLF.TRCODE=14 then 'Açılış Fişi' 
                when CLF.TRCODE=20 then 'Gelen Havale' 
                when CLF.TRCODE=21 then 'Gönderilen Havale'
                when CLF.TRCODE=24 then 'Döviz Alış Belgesi'
                when CLF.TRCODE=25 then 'Döviz Satış Belgesi' 
                when CLF.TRCODE=28 then 'Banka Alınan Hizmet Faturası'
                when CLF.TRCODE=31 then 'Satınalma Faturası'
                when CLF.TRCODE=32 then 'Perakende Satış İade Faturası'
                when CLF.TRCODE=33 then 'Toptan Satış İade Faturası'
                when CLF.TRCODE=34 then 'Alınan Hizmet Faturası' 
                when CLF.TRCODE=35 then 'Alınan Proforma Faturası' 
                when CLF.TRCODE=36 then 'Satınalma İade Faturası' 
                when CLF.TRCODE=37 then 'Perakende Satış Faturası' 
                when CLF.TRCODE=38 then 'Toptan Satış Faturası'
                when CLF.TRCODE=39 then 'Verilen Hizmet Faturası' 
                when CLF.TRCODE=40 then 'Verilen Proforma Faturası'
                when CLF.TRCODE=41 then 'Verilen Vade Farkı Faturası'
                when CLF.TRCODE=42 then 'Alınan Vade Farkı Faturası'
                when CLF.TRCODE=43 then 'Alınan Fiyat Farkı Faturası' 
                when CLF.TRCODE=44 then 'Verilen Fiyat Farkı Faturası' 
                when CLF.TRCODE=46 then 'Alınan Serbest Meslek Makbuzu' 
                when CLF.TRCODE=61 then 'Çek Girişi'
                when CLF.TRCODE=62 then 'Senet Girişi'
                when CLF.TRCODE=63 then 'Çek Çıkış Cari Hesaba'
                when CLF.TRCODE=64 then 'Senet Çıkış Cari Hesaba'
                when CLF.TRCODE=70 then 'Kredi Kartı Fişi'
                when CLF.TRCODE=71 then 'Kredi Kartı İade Fişi'
                when CLF.TRCODE=72 then 'Firma Kredi Kartı Fişi'
                when CLF.TRCODE=73 then 'Firma Kredi Kartı İade Fişi'
                when CLF.TRCODE=81 then 'Ödemeli Satış Siparişi'
                when CLF.TRCODE=82 then 'Ödemeli Satın alma Siparişi'
                when CLF.TRCODE=56 then 'Müstahsil makbuzu' end as FISTURU,
                CLF.DOCODE AS BELGENO,CLF.CLIENTREF,CLF.LINEEXP AS ACIKLAMA,

                CASE WHEN CLF.PAIDINCASH=1 THEN sum(CASE WHEN SIGN=1 THEN CLF.AMOUNT ELSE 0 END) ELSE
                sum(CASE WHEN SIGN=0 THEN CLF.AMOUNT ELSE 0 END) END BORC,

				CASE WHEN CLF.PAIDINCASH=1 THEN sum(CASE WHEN SIGN=1 THEN CLF.AMOUNT ELSE 0 END) ELSE
                sum(CASE WHEN SIGN=1 THEN CLF.AMOUNT ELSE 0 END) END ALACAK,

				CLF.PAIDINCASH,

                ROUND(sum(CASE WHEN SIGN=0 THEN CLF.AMOUNT ELSE 0 END)-
				CASE WHEN CLF.PAIDINCASH=1 THEN sum(CASE WHEN SIGN=0 THEN CLF.AMOUNT ELSE 0 END) ELSE
                sum(CASE WHEN SIGN=1 THEN CLF.AMOUNT ELSE 0 END) END,2) BAKIYE,

                CLF.CANCELLED
                FROM LG_{4}_{3}_CLFLINE CLF With (Nolock)
                LEFT OUTER JOIN LG_{4}_CLCARD C ON CLF.CLIENTREF=C.LOGICALREF
                LEFT OUTER JOIN LG_{4}_{3}_INVOICE I ON CLF.SOURCEFREF=I.LOGICALREF
                where C.CODE = '{0}' AND CLF.CANCELLED=0
                GROUP BY CLF.SOURCEFREF,CLF.PAIDINCASH,
                C.CODE,
                CLF.DATE_,
                CLF.TRANNO,
                I.LOGICALREF,
                CLF.TRCODE,
                CLF.MODULENR,
                CLF.DOCODE,
                CLF.CLIENTREF,
                CLF.LINEEXP,
                CLF.CANCELLED)

                SELECT c1.BAYIKODU,c1.CLIENTREF,c1.SREF,c1.DATE_ as TARIH, c1.VADETARIHI, c1.FISNO,c1.FISTURU,c1.BELGENO,c1.ACIKLAMA,
                --c1.FATODEMETIP,
                c1.BORC,c1.ALACAK,c1.PAIDINCASH,SUM(c2.BAKIYE) BAKIYE
                FROM cteHesap c1 
                LEFT JOIN cteHesap c2 ON c1.TarihId>=c2.TarihId
                WHERE  c1.CLIENTREF=c2.CLIENTREF and c1.BAYIKODU = '{0}' AND c1.CANCELLED=0
                GROUP BY c1.BAYIKODU,c1.CLIENTREF,c1.SREF,c1.DATE_, c1.VADETARIHI, c1.FISNO,c1.FISTURU,c1.BELGENO,c1.BAKIYE,c1.BORC,c1.ALACAK,c1.ACIKLAMA,
                --c1.FATODEMETIP,
                c1.PAIDINCASH,c1.CANCELLED
                ORDER BY c1.DATE_,c1.SREF; ", txtCariKodu.Text, txtIlk.DateTime.ToString("yyyy-MM-dd"), txtSon.DateTime.ToString("yyyy-MM-dd"), donem, firma);

                SQLDetail = $@"SELECT F.LOGICALREF FNO, 

                CASE WHEN S.LINETYPE = 4 THEN (SELECT TOP 1 CODE FROM LG_{firma}_SRVCARD WHERE LOGICALREF = S.STOCKREF) 
                                ELSE 
                                I.CODE END [STOKKODU],

                CASE WHEN S.LINETYPE = 4 THEN (SELECT TOP 1 DEFINITION_ FROM LG_{firma}_SRVCARD WHERE LOGICALREF = S.STOCKREF) 
                                ELSE 
                                I.NAME END [STOKCINSI],
                S.LINEEXP [ACIKLAMA],
                S.AMOUNT [MIKTAR], ROUND(ISNULL((NULLIF(S.LINENET,0) / NULLIF(S.AMOUNT,0)),0),2) [FIYAT], S.VAT [KDV], ROUND((S.LINENET+S.VATAMNT),2) [TUTAR]
                FROM LG_
                {firma}_{donem}_STLINE S With (Nolock)
                LEFT OUTER JOIN LG_{firma}_{donem}_INVOICE F ON S.INVOICEREF=F.LOGICALREF
                LEFT OUTER JOIN LG_{firma}_ITEMS I ON S.STOCKREF=I.LOGICALREF
                LEFT OUTER JOIN LG_{firma}_CLCARD C ON F.CLIENTREF=C.LOGICALREF
                WHERE C.CODE='{txtCariKodu.Text}' AND  S.CANCELLED=0 AND S.LINETYPE IN (0,4)";
            }
            else
            {
                SQLMaster = string.Format(@"WITH cteHesap AS(
                SELECT 0 TarihId, '{0}' BAYIKODU,
                0 SREF,
                null DATE_,
                null VADETARIHI,
                '' FISNO,
                --'' FATODEMETIP,
                'DEVİR' FISTURU,
                '' BELGENO,  
                0 CLIENTREF,
                '' ACIKLAMA,
                  SUM(CASE WHEN CLF.SIGN=0 THEN CLF.AMOUNT ELSE 0 END) BORC,
                 CASE WHEN CLF.PAIDINCASH=1 THEN sum(CASE WHEN SIGN=0 THEN CLF.AMOUNT ELSE 0 END) ELSE
                                sum(CASE WHEN SIGN=1 THEN CLF.AMOUNT ELSE 0 END) END ALACAK,
                				CLF.PAIDINCASH,
                                sum(CASE WHEN SIGN=0 THEN CLF.AMOUNT ELSE 0 END)-
                				CASE WHEN CLF.PAIDINCASH=1 THEN sum(CASE WHEN SIGN=0 THEN CLF.AMOUNT ELSE 0 END) ELSE
                                sum(CASE WHEN SIGN=1 THEN CLF.AMOUNT ELSE 0 END) END BAKIYE
                				,
                				0 CANCELLED
                FROM LG_{4}_{3}_CLFLINE CLF
                INNER JOIN LG_{4}_CLCARD CL ON CLF.CLIENTREF=CL.LOGICALREF
                WHERE CLF.TRCURR=0 AND  CL.CODE='{0}'  AND CLF.DATE_ < '{1}'  AND CLF.CANCELLED=0
                GROUP BY CLF.PAIDINCASH
                union all
                SELECT ROW_NUMBER() OVER (ORDER BY CLF.DATE_) as TarihId, 
                C.CODE as BAYIKODU,
                CLF.SOURCEFREF AS SREF,
                CLF.DATE_,
                CASE WHEN CLF.MODULENR=4 THEN
                (SELECT TOP 1 P.DATE_ 
                FROM LG_{4}_{3}_PAYTRANS P WHERE FICHEREF= CLF.SOURCEFREF AND MODULENR=4) 
				ELSE NULL END VADETARIHI,
                CLF.TRANNO AS FISNO,
                --(SELECT TOP 1 CASE WHEN DURUM=1 THEN 'KAPALI' ELSE 'AÇIK' END FROM ASISTAN_FATURA_TIP With (Nolock) 
                --WHERE LOGICALREF=I.LOGICALREF) FATODEMETIP,
                case when CLF.TRCODE=1 then 'Nakit Tahsilat'
                when CLF.TRCODE=2 then 'Nakit Ödeme' 
                when CLF.TRCODE=3 then 'Borç Dekontu' 
                when CLF.TRCODE=5 then 'Virman Fişi'  
                when CLF.TRCODE=6 then 'Alım iade faturası' 
                when CLF.TRCODE=12 then 'Özel Fiş'
                when CLF.TRCODE=14 then 'Açılış Fişi' 
                when CLF.TRCODE=20 then 'Gelen Havale' 
                when CLF.TRCODE=21 then 'Gönderilen Havale'
                when CLF.TRCODE=24 then 'Döviz Alış Belgesi'
                when CLF.TRCODE=25 then 'Döviz Satış Belgesi' 
                when CLF.TRCODE=28 then 'Banka Alınan Hizmet Faturası'
                when CLF.TRCODE=31 then 'Satınalma Faturası'
                when CLF.TRCODE=32 then 'Perakende Satış İade Faturası'
                when CLF.TRCODE=33 then 'Toptan Satış İade Faturası'
                when CLF.TRCODE=34 then 'Alınan Hizmet Faturası' 
                when CLF.TRCODE=35 then 'Alınan Proforma Faturası' 
                when CLF.TRCODE=36 then 'Satınalma İade Faturası' 
                when CLF.TRCODE=37 then 'Perakende Satış Faturası' 
                when CLF.TRCODE=38 then 'Toptan Satış Faturası'
                when CLF.TRCODE=39 then 'Verilen Hizmet Faturası' 
                when CLF.TRCODE=40 then 'Verilen Proforma Faturası'
                when CLF.TRCODE=41 then 'Verilen Vade Farkı Faturası'
                when CLF.TRCODE=42 then 'Alınan Vade Farkı Faturası'
                when CLF.TRCODE=43 then 'Alınan Fiyat Farkı Faturası' 
                when CLF.TRCODE=44 then 'Verilen Fiyat Farkı Faturası' 
                when CLF.TRCODE=46 then 'Alınan Serbest Meslek Makbuzu' 
                when CLF.TRCODE=61 then 'Çek Girişi'
                when CLF.TRCODE=62 then 'Senet Girişi'
                when CLF.TRCODE=63 then 'Çek Çıkış Cari Hesaba'
                when CLF.TRCODE=64 then 'Senet Çıkış Cari Hesaba'
                when CLF.TRCODE=70 then 'Kredi Kartı Fişi'
                when CLF.TRCODE=71 then 'Kredi Kartı İade Fişi'
                when CLF.TRCODE=72 then 'Firma Kredi Kartı Fişi'
                when CLF.TRCODE=73 then 'Firma Kredi Kartı İade Fişi'
                when CLF.TRCODE=81 then 'Ödemeli Satış Siparişi'
                when CLF.TRCODE=82 then 'Ödemeli Satın alma Siparişi'
                when CLF.TRCODE=56 then 'Müstahsil makbuzu' end as FISTURU,
                CLF.DOCODE AS BELGENO,CLF.CLIENTREF,CLF.LINEEXP AS ACIKLAMA,
                sum(CASE WHEN SIGN=0 THEN CLF.AMOUNT ELSE 0 END) as BORC,
				CASE WHEN CLF.PAIDINCASH=1 THEN sum(CASE WHEN SIGN=0 THEN CLF.AMOUNT ELSE 0 END) ELSE
                sum(CASE WHEN SIGN=1 THEN CLF.AMOUNT ELSE 0 END) END ALACAK,
				CLF.PAIDINCASH,
                sum(CASE WHEN SIGN=0 THEN CLF.AMOUNT ELSE 0 END)-
				CASE WHEN CLF.PAIDINCASH=1 THEN sum(CASE WHEN SIGN=0 THEN CLF.AMOUNT ELSE 0 END) ELSE
                sum(CASE WHEN SIGN=1 THEN CLF.AMOUNT ELSE 0 END) END BAKIYE,
                CLF.CANCELLED
                FROM LG_{4}_{3}_CLFLINE CLF With (Nolock)
                LEFT OUTER JOIN LG_{4}_CLCARD C ON CLF.CLIENTREF=C.LOGICALREF
                LEFT OUTER JOIN LG_{4}_{3}_INVOICE I ON CLF.SOURCEFREF=I.LOGICALREF
                where CLF.TRCURR=0 AND C.CODE = '{0}' AND CLF.CANCELLED=0 AND CLF.DATE_>='{1}' AND CLF.DATE_<='{2}'
                GROUP BY CLF.SOURCEFREF,CLF.PAIDINCASH,
                C.CODE,
                CLF.DATE_,
                CLF.TRANNO,
                I.LOGICALREF,
                CLF.TRCODE,
                CLF.MODULENR,
                CLF.DOCODE,
                CLF.CLIENTREF,
                CLF.LINEEXP,
                CLF.CANCELLED)

                SELECT c1.BAYIKODU,c1.CLIENTREF,c1.SREF,c1.DATE_ as TARIH, c1.VADETARIHI, c1.FISNO,c1.FISTURU,c1.BELGENO,c1.ACIKLAMA,
                --c1.FATODEMETIP,
                c1.BORC,c1.ALACAK,c1.PAIDINCASH,SUM(c2.BAKIYE) BAKIYE
                FROM cteHesap c1 
                LEFT JOIN cteHesap c2 ON c1.TarihId>=c2.TarihId
                WHERE c1.BAYIKODU = '{0}' AND c1.CANCELLED=0
                GROUP BY c1.BAYIKODU,c1.CLIENTREF,c1.SREF,c1.DATE_,c1.VADETARIHI, c1.FISNO,c1.FISTURU,c1.BELGENO,c1.BAKIYE,c1.BORC,c1.ALACAK,c1.PAIDINCASH,c1.ACIKLAMA,
                --c1.FATODEMETIP,
                c1.CANCELLED
                ORDER BY c1.DATE_,c1.SREF;"
                , txtCariKodu.Text, txtIlk.DateTime.ToString("yyyy-MM-dd"), txtSon.DateTime.ToString("yyyy-MM-dd"), donem, firma);

                SQLDetail = $@"SELECT F.LOGICALREF FNO, 

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
                WHERE C.CODE='{txtCariKodu.Text}' AND  S.CANCELLED=0 AND S.LINETYPE IN (0,4)";
            }
            try
            {
                using (LogoContext db = new LogoContext())
                {
                   List<CariEkstreDovizli> analiste = db.Database.SqlQuery<CariEkstreDovizli>(SQLMaster).ToList();
                    grid_CariHesapDovizliEkstre.DataSource = analiste;
                    grid_CariHesapDovizliEkstre.RefreshDataSource();
                    grid_CariHesapDovizliEkstre.Refresh();

                    List<CariEkstreDovizliDetay> detayliste = db.Database.SqlQuery<CariEkstreDovizliDetay>(SQLDetail).ToList();
                    
                } 
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("AÇIKLAMA : " + hata.Message, "RAPOR ALINAMADI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIlk.DateTime.ToString()) || string.IsNullOrWhiteSpace(txtSon.DateTime.ToString())||string.IsNullOrWhiteSpace(Convert.ToString(lkk_kurbilgi.EditValue)))
            {
                XtraMessageBox.Show("Tarih Ve Kur Seçimleri Boş Olamaz");
                return;
            }
            ListeDovizli();
        }

        private void gv_CarihesapDovizliEkstre_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            CariEkstreDovizli row = (CariEkstreDovizli)gv_CarihesapDovizliEkstre.GetFocusedRow();
            if (row != null)
            {

                if (row.SREF == 0)
                {

                }
                else
                {
                    using (LogoContext db = new LogoContext())
                    {
                        string sql = $@"SELECT F.LOGICALREF FNO,
                            CASE WHEN S.LINETYPE = 4 THEN(SELECT TOP 1 CODE FROM LG_{firma}_SRVCARD WHERE LOGICALREF = S.STOCKREF) 
                                            ELSE I.CODE END[STOKKODU],
                          F.LOGICALREF INVOICEREF,
                        CASE WHEN S.LINETYPE = 4 THEN(SELECT TOP 1 DEFINITION_ FROM LG_{firma}_SRVCARD WHERE LOGICALREF = S.STOCKREF)                                         ELSE I.NAME END[STOKCINSI], S.LINEEXP[ACIKLAMA],
                        S.AMOUNT[MIKTAR], ROUND(ISNULL((NULLIF(S.LINENET, 0) / NULLIF(S.AMOUNT, 0)), 0), 2)[FIYAT], S.VAT[KDV], ROUND((S.LINENET + S.VATAMNT), 2)[TUTAR]
                        FROM LG_{firma}_{donem}_STLINE S With(Nolock)
                        LEFT OUTER JOIN LG_{firma}_{donem}_INVOICE F ON S.INVOICEREF = F.LOGICALREF
                        LEFT OUTER JOIN LG_{firma}_ITEMS I ON S.STOCKREF = I.LOGICALREF
                        LEFT OUTER JOIN LG_{firma}_CLCARD C ON F.CLIENTREF = C.LOGICALREF
                                     WHERE C.CODE='{txtCariKodu.Text}' AND  S.CANCELLED=0 AND S.LINETYPE IN (0,4) and F.LOGICALREF={row.SREF}";

                        List<CariEkstreDovizliDetay> liste = db.Database.SqlQuery<CariEkstreDovizliDetay>(sql).ToList();
                        e.ChildList = liste;

                    }
                }


            }
            else
            {
                e.ChildList = new List<CariEkstreDovizliDetay>();
            }
        }

        private void gv_CarihesapDovizliEkstre_MasterRowGetRelationCount(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void gv_CarihesapDovizliEkstre_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView dView = gv_CarihesapDovizliEkstre.GetDetailView(e.RowHandle, 0) as DevExpress.XtraGrid.Views.Grid.GridView;


            dView.Columns["FISNO"].Visible = false;

            dView.Columns["FIYAT"].DisplayFormat.FormatType = FormatType.Numeric;
            dView.Columns["FIYAT"].DisplayFormat.FormatString = "n2";
            dView.Columns["TUTAR"].DisplayFormat.FormatType = FormatType.Numeric;
            dView.Columns["TUTAR"].DisplayFormat.FormatString = "n2";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ListeDovizli()
        {
            clas.Connect();
            clas.Conn.Open();
            Int16 kur = Convert.ToInt16(lkk_kurbilgi.EditValue);
            if (lkk_kurbilgi.Text == "TL")
            {
                Liste();
                return;
            }
            if (ck.Checked == true)
            {
                SQLMaster = string.Format(@"WITH cteHesap AS(SELECT ROW_NUMBER() OVER (ORDER BY CLF.DATE_) as TarihId, 
                C.CODE as BAYIKODU,
                CLF.SOURCEFREF AS SREF,
                CLF.DATE_,
                CASE WHEN CLF.TRCODE IN (38,39,40,41,42,43,44) THEN
                (SELECT TOP 1 P.DATE_ 
                FROM LG_{4}_{3}_PAYTRANS P WHERE FICHEREF= CLF.SOURCEFREF AND MODULENR=4) 
				ELSE NULL END VADETARIHI,
                CLF.TRANNO AS FISNO,
                --(SELECT TOP 1 CASE WHEN DURUM=1 THEN 'KAPALI' ELSE 'AÇIK' END FROM ASISTAN_FATURA_TIP With (Nolock) 
                --WHERE LOGICALREF=I.LOGICALREF) FATODEMETIP,
                case when CLF.TRCODE=1 then 'Nakit Tahsilat'
                when CLF.TRCODE=2 then 'Nakit Ödeme' 
                when CLF.TRCODE=3 then 'Borç Dekontu' 
                when CLF.TRCODE=5 then 'Virman Fişi'  
                when CLF.TRCODE=6 then 'Alım iade faturası' 
                when CLF.TRCODE=12 then 'Özel Fiş'
                when CLF.TRCODE=14 then 'Açılış Fişi' 
                when CLF.TRCODE=20 then 'Gelen Havale' 
                when CLF.TRCODE=21 then 'Gönderilen Havale'
                when CLF.TRCODE=24 then 'Döviz Alış Belgesi'
                when CLF.TRCODE=25 then 'Döviz Satış Belgesi' 
                when CLF.TRCODE=28 then 'Banka Alınan Hizmet Faturası'
                when CLF.TRCODE=31 then 'Satınalma Faturası'
                when CLF.TRCODE=32 then 'Perakende Satış İade Faturası'
                when CLF.TRCODE=33 then 'Toptan Satış İade Faturası'
                when CLF.TRCODE=34 then 'Alınan Hizmet Faturası' 
                when CLF.TRCODE=35 then 'Alınan Proforma Faturası' 
                when CLF.TRCODE=36 then 'Satınalma İade Faturası' 
                when CLF.TRCODE=37 then 'Perakende Satış Faturası' 
                when CLF.TRCODE=38 then 'Toptan Satış Faturası'
                when CLF.TRCODE=39 then 'Verilen Hizmet Faturası' 
                when CLF.TRCODE=40 then 'Verilen Proforma Faturası'
                when CLF.TRCODE=41 then 'Verilen Vade Farkı Faturası'
                when CLF.TRCODE=42 then 'Alınan Vade Farkı Faturası'
                when CLF.TRCODE=43 then 'Alınan Fiyat Farkı Faturası' 
                when CLF.TRCODE=44 then 'Verilen Fiyat Farkı Faturası' 
                when CLF.TRCODE=46 then 'Alınan Serbest Meslek Makbuzu' 
                when CLF.TRCODE=61 then 'Çek Girişi'
                when CLF.TRCODE=62 then 'Senet Girişi'
                when CLF.TRCODE=63 then 'Çek Çıkış Cari Hesaba'
                when CLF.TRCODE=64 then 'Senet Çıkış Cari Hesaba'
                when CLF.TRCODE=70 then 'Kredi Kartı Fişi'
                when CLF.TRCODE=71 then 'Kredi Kartı İade Fişi'
                when CLF.TRCODE=72 then 'Firma Kredi Kartı Fişi'
                when CLF.TRCODE=73 then 'Firma Kredi Kartı İade Fişi'
                when CLF.TRCODE=81 then 'Ödemeli Satış Siparişi'
                when CLF.TRCODE=82 then 'Ödemeli Satın alma Siparişi'
                when CLF.TRCODE=56 then 'Müstahsil makbuzu' end as FISTURU,
                CLF.DOCODE AS BELGENO,CLF.CLIENTREF,CLF.LINEEXP AS ACIKLAMA,

                CASE WHEN CLF.PAIDINCASH=1 THEN sum(CASE WHEN SIGN=1 THEN CLF.TRNET ELSE 0 END) ELSE
                sum(CASE WHEN SIGN=0 THEN CLF.TRNET ELSE 0 END) END BORC,

				CASE WHEN CLF.PAIDINCASH=1 THEN sum(CASE WHEN SIGN=1 THEN CLF.TRNET ELSE 0 END) ELSE
                sum(CASE WHEN SIGN=1 THEN CLF.TRNET ELSE 0 END) END ALACAK,

				CLF.PAIDINCASH,

                ROUND(sum(CASE WHEN SIGN=0 THEN CLF.TRNET ELSE 0 END)-
				CASE WHEN CLF.PAIDINCASH=1 THEN sum(CASE WHEN SIGN=0 THEN CLF.TRNET ELSE 0 END) ELSE
                sum(CASE WHEN SIGN=1 THEN CLF.TRNET ELSE 0 END) END,2) BAKIYE,

                CLF.CANCELLED
                FROM LG_{4}_{3}_CLFLINE CLF With (Nolock)
                LEFT OUTER JOIN LG_{4}_CLCARD C ON CLF.CLIENTREF=C.LOGICALREF
                LEFT OUTER JOIN LG_{4}_{3}_INVOICE I ON CLF.SOURCEFREF=I.LOGICALREF
                where CLF.TRCURR={5} AND C.CODE = '{0}' AND CLF.CANCELLED=0
                GROUP BY CLF.SOURCEFREF,CLF.PAIDINCASH,
                C.CODE,
                CLF.DATE_,
                CLF.TRANNO,
                I.LOGICALREF,
                CLF.TRCODE,
                CLF.DOCODE,
                CLF.CLIENTREF,
                CLF.LINEEXP,
                CLF.CANCELLED)

                SELECT c1.BAYIKODU,c1.CLIENTREF,c1.SREF,c1.DATE_ as TARIH, c1.VADETARIHI, c1.FISNO,c1.FISTURU,c1.BELGENO,c1.ACIKLAMA,
                --c1.FATODEMETIP,
                c1.BORC,c1.ALACAK,c1.PAIDINCASH,SUM(c2.BAKIYE) BAKIYE
                FROM cteHesap c1 
                LEFT JOIN cteHesap c2 ON c1.TarihId>=c2.TarihId
                WHERE  c1.CLIENTREF=c2.CLIENTREF and c1.BAYIKODU = '{0}' AND c1.CANCELLED=0
                GROUP BY c1.BAYIKODU,c1.CLIENTREF,c1.SREF,c1.DATE_, c1.VADETARIHI, c1.FISNO,c1.FISTURU,c1.BELGENO,c1.BAKIYE,c1.BORC,c1.ALACAK,c1.ACIKLAMA,
                --c1.FATODEMETIP,
                c1.PAIDINCASH,c1.CANCELLED
                ORDER BY c1.DATE_,c1.SREF;
               
                SELECT 
                ISNULL(sum(CASE WHEN CLF.SIGN=0 THEN ISNULL(CLF.TRNET,0) ELSE 0 END),0) [GBORC],

                CASE WHEN CLF.PAIDINCASH=1 THEN sum(CASE WHEN SIGN=0 THEN CLF.TRNET ELSE 0 END) ELSE
                sum(CASE WHEN SIGN=1 THEN ISNULL(CLF.AMOUNT,0) ELSE 0 END) END [GALACAK],

                sum(CASE WHEN SIGN=0 THEN CLF.TRNET ELSE 0 END)-
				CASE WHEN CLF.PAIDINCASH=1 THEN sum(CASE WHEN SIGN=0 THEN CLF.TRNET ELSE 0 END) ELSE
                sum(CASE WHEN SIGN=1 THEN ISNULL(CLF.AMOUNT,0) ELSE 0 END) END [GBAKIYE]
                FROM LG_{4}_{3}_CLFLINE CLF With (Nolock)
                LEFT OUTER JOIN LG_{4}_CLCARD C ON CLF.CLIENTREF=C.LOGICALREF
                WHERE CLF.TRCURR={5} AND CLF.CANCELLED=0 AND C.CODE = '{0}'
                GROUP BY CLF.PAIDINCASH;;

               SELECT DATEADD(DAY, dbo.ESBI_CARIVADEGUN_{4}((SELECT TOP 1 LOGICALREF FROM LG_{4}_CLCARD WHERE CODE='{0}')), GETDATE()) AS ORT_VADE_TARIHI;
                ", txtCariKodu.Text, txtIlk.DateTime.ToString("yyyy-MM-dd"), txtSon.DateTime.ToString("yyyy-MM-dd"), donem, firma, kur);

                SQLDetail = $@"SELECT F.LOGICALREF FNO, 

                CASE WHEN S.LINETYPE = 4 THEN (SELECT TOP 1 CODE FROM LG_{firma}_SRVCARD WHERE LOGICALREF = S.STOCKREF) 
                                ELSE 
                                I.CODE END [STOKKODU],

                CASE WHEN S.LINETYPE = 4 THEN (SELECT TOP 1 DEFINITION_ FROM LG_{firma}_SRVCARD WHERE LOGICALREF = S.STOCKREF) 
                                ELSE 
                                I.NAME END [STOKCINSI],
                S.LINEEXP [ACIKLAMA],
                S.AMOUNT [MIKTAR], CASE WHEN F.LINEEXCTYP<>4 THEN (CASE WHEN S.TRCURR=0 THEN S.PRICE ELSE  ISNULL((S.PRICE/NULLIF(S.TRRATE,0)),S.PRICE) END)
			ELSE (CASE WHEN S.PRCURR=0 THEN S.PRICE ELSE  ISNULL(S.PRPRICE,0) END) END AS [FIYAT], S.VAT [KDV], ROUND(((ISNULL(S.VATMATRAH,0)+s.VATAMNT)/s.TRRATE),2) [TUTAR]
                FROM LG_{firma}_{donem}_STLINE S With (Nolock)
                LEFT OUTER JOIN LG_{firma}_{donem}_INVOICE F ON S.INVOICEREF=F.LOGICALREF
                LEFT OUTER JOIN LG_{firma}_ITEMS I ON S.STOCKREF=I.LOGICALREF
                LEFT OUTER JOIN LG_{firma}_CLCARD C ON F.CLIENTREF=C.LOGICALREF
                WHERE S.TRCURR={kur} AND C.CODE='{txtCariKodu.Text}' AND  S.CANCELLED=0 AND S.LINETYPE IN (0,4)";
            }
            else
            {
                SQLMaster = string.Format(@"WITH cteHesap AS(
                SELECT 0 TarihId, '{0}' BAYIKODU,
                0 SREF,
                null DATE_,
                null VADETARIHI,
                '' FISNO,
                --'' FATODEMETIP,
                'DEVİR' FISTURU,
                '' BELGENO,  
                0 CLIENTREF,
                '' ACIKLAMA,
                  SUM(CASE WHEN CLF.SIGN=0 THEN CLF.TRNET ELSE 0 END) BORC,
                 CASE WHEN CLF.PAIDINCASH=1 THEN sum(CASE WHEN SIGN=0 THEN CLF.TRNET ELSE 0 END) ELSE
                                sum(CASE WHEN SIGN=1 THEN CLF.TRNET ELSE 0 END) END ALACAK,
                				CLF.PAIDINCASH,
                                sum(CASE WHEN SIGN=0 THEN CLF.TRNET ELSE 0 END)-
                				CASE WHEN CLF.PAIDINCASH=1 THEN sum(CASE WHEN SIGN=0 THEN CLF.TRNET ELSE 0 END) ELSE
                                sum(CASE WHEN SIGN=1 THEN CLF.TRNET ELSE 0 END) END BAKIYE
                				,
                				0 CANCELLED
                FROM LG_{4}_{3}_CLFLINE CLF
                INNER JOIN LG_{4}_CLCARD CL ON CLF.CLIENTREF=CL.LOGICALREF
                WHERE CLF.TRCURR={5} AND  CL.CODE='{0}'  AND CLF.DATE_ < '{1}'  AND CLF.CANCELLED=0
                GROUP BY CLF.PAIDINCASH
                union all
                SELECT ROW_NUMBER() OVER (ORDER BY CLF.DATE_) as TarihId, 
                C.CODE as BAYIKODU,
                CLF.SOURCEFREF AS SREF,
                CLF.DATE_,
                CASE WHEN CLF.TRCODE IN (38,39,40,41,42,43,44) THEN
                (SELECT TOP 1 P.DATE_ 
                FROM LG_{4}_{3}_PAYTRANS P WHERE FICHEREF= CLF.SOURCEFREF AND MODULENR=4) 
				ELSE NULL END VADETARIHI,
                CLF.TRANNO AS FISNO,
                --(SELECT TOP 1 CASE WHEN DURUM=1 THEN 'KAPALI' ELSE 'AÇIK' END FROM ASISTAN_FATURA_TIP With (Nolock) 
                --WHERE LOGICALREF=I.LOGICALREF) FATODEMETIP,
                case when CLF.TRCODE=1 then 'Nakit Tahsilat'
                when CLF.TRCODE=2 then 'Nakit Ödeme' 
                when CLF.TRCODE=3 then 'Borç Dekontu' 
                when CLF.TRCODE=5 then 'Virman Fişi'  
                when CLF.TRCODE=6 then 'Alım iade faturası' 
                when CLF.TRCODE=12 then 'Özel Fiş'
                when CLF.TRCODE=14 then 'Açılış Fişi' 
                when CLF.TRCODE=20 then 'Gelen Havale' 
                when CLF.TRCODE=21 then 'Gönderilen Havale'
                when CLF.TRCODE=24 then 'Döviz Alış Belgesi'
                when CLF.TRCODE=25 then 'Döviz Satış Belgesi' 
                when CLF.TRCODE=28 then 'Banka Alınan Hizmet Faturası'
                when CLF.TRCODE=31 then 'Satınalma Faturası'
                when CLF.TRCODE=32 then 'Perakende Satış İade Faturası'
                when CLF.TRCODE=33 then 'Toptan Satış İade Faturası'
                when CLF.TRCODE=34 then 'Alınan Hizmet Faturası' 
                when CLF.TRCODE=35 then 'Alınan Proforma Faturası' 
                when CLF.TRCODE=36 then 'Satınalma İade Faturası' 
                when CLF.TRCODE=37 then 'Perakende Satış Faturası' 
                when CLF.TRCODE=38 then 'Toptan Satış Faturası'
                when CLF.TRCODE=39 then 'Verilen Hizmet Faturası' 
                when CLF.TRCODE=40 then 'Verilen Proforma Faturası'
                when CLF.TRCODE=41 then 'Verilen Vade Farkı Faturası'
                when CLF.TRCODE=42 then 'Alınan Vade Farkı Faturası'
                when CLF.TRCODE=43 then 'Alınan Fiyat Farkı Faturası' 
                when CLF.TRCODE=44 then 'Verilen Fiyat Farkı Faturası' 
                when CLF.TRCODE=46 then 'Alınan Serbest Meslek Makbuzu' 
                when CLF.TRCODE=61 then 'Çek Girişi'
                when CLF.TRCODE=62 then 'Senet Girişi'
                when CLF.TRCODE=63 then 'Çek Çıkış Cari Hesaba'
                when CLF.TRCODE=64 then 'Senet Çıkış Cari Hesaba'
                when CLF.TRCODE=70 then 'Kredi Kartı Fişi'
                when CLF.TRCODE=71 then 'Kredi Kartı İade Fişi'
                when CLF.TRCODE=72 then 'Firma Kredi Kartı Fişi'
                when CLF.TRCODE=73 then 'Firma Kredi Kartı İade Fişi'
                when CLF.TRCODE=81 then 'Ödemeli Satış Siparişi'
                when CLF.TRCODE=82 then 'Ödemeli Satın alma Siparişi'
                when CLF.TRCODE=56 then 'Müstahsil makbuzu' end as FISTURU,
                CLF.DOCODE AS BELGENO,CLF.CLIENTREF,CLF.LINEEXP AS ACIKLAMA,
                sum(CASE WHEN SIGN=0 THEN CLF.TRNET ELSE 0 END) as BORC,
				CASE WHEN CLF.PAIDINCASH=1 THEN sum(CASE WHEN SIGN=0 THEN CLF.TRNET ELSE 0 END) ELSE
                sum(CASE WHEN SIGN=1 THEN CLF.TRNET ELSE 0 END) END ALACAK,
				CLF.PAIDINCASH,
                sum(CASE WHEN SIGN=0 THEN CLF.TRNET ELSE 0 END)-
				CASE WHEN CLF.PAIDINCASH=1 THEN sum(CASE WHEN SIGN=0 THEN CLF.TRNET ELSE 0 END) ELSE
                sum(CASE WHEN SIGN=1 THEN CLF.TRNET ELSE 0 END) END BAKIYE,
                CLF.CANCELLED
                FROM LG_{4}_{3}_CLFLINE CLF With (Nolock)
                LEFT OUTER JOIN LG_{4}_CLCARD C ON CLF.CLIENTREF=C.LOGICALREF
                LEFT OUTER JOIN LG_{4}_{3}_INVOICE I ON CLF.SOURCEFREF=I.LOGICALREF
                where CLF.TRCURR={5} AND C.CODE = '{0}' AND CLF.CANCELLED=0 AND CLF.DATE_>='{1}' AND CLF.DATE_<='{2}'
                GROUP BY CLF.SOURCEFREF,CLF.PAIDINCASH,
                C.CODE,
                CLF.DATE_,
                CLF.TRANNO,
                I.LOGICALREF,
                CLF.TRCODE,
                CLF.DOCODE,
                CLF.CLIENTREF,
                CLF.LINEEXP,
                CLF.CANCELLED)

                SELECT c1.BAYIKODU,c1.CLIENTREF,c1.SREF,c1.DATE_ as TARIH, c1.VADETARIHI, c1.FISNO,c1.FISTURU,c1.BELGENO,c1.ACIKLAMA,
                --c1.FATODEMETIP,
                c1.BORC,c1.ALACAK,c1.PAIDINCASH,SUM(c2.BAKIYE) BAKIYE
                FROM cteHesap c1 
                LEFT JOIN cteHesap c2 ON c1.TarihId>=c2.TarihId
                WHERE c1.BAYIKODU = '{0}' AND c1.CANCELLED=0
                GROUP BY c1.BAYIKODU,c1.CLIENTREF,c1.SREF,c1.DATE_,c1.VADETARIHI, c1.FISNO,c1.FISTURU,c1.BELGENO,c1.BAKIYE,c1.BORC,c1.ALACAK,c1.PAIDINCASH,c1.ACIKLAMA,
                --c1.FATODEMETIP,
                c1.CANCELLED
                ORDER BY c1.DATE_,c1.SREF;

                   SELECT 			
				(ISNULL(( SELECT  SUM(CASE WHEN CLF2.SIGN=0 THEN CLF2.TRNET ELSE 0 END) BORC  FROM LG_{4}_{3}_CLFLINE CLF2
                WHERE CLF2.TRCURR={5} AND CLF2.CLIENTREF=C.LOGICALREF AND   CLF2.DATE_ < '{1}'  AND CLF2.CANCELLED=0  ),0)+
                (ISNULL(sum(CASE WHEN CLF.SIGN=0 THEN CLF.TRNET ELSE 0 END),0))) [GBORC],

				(ISNULL(
				(SELECT  SUM(CASE WHEN CLF2.SIGN=1 THEN CLF2.TRNET ELSE 0 END) BORC  FROM LG_{4}_{3}_CLFLINE CLF2
                WHERE CLF2.TRCURR={5} AND CLF2.CLIENTREF=C.LOGICALREF AND   CLF2.DATE_ < '{1}'  AND CLF2.CANCELLED=0 ),0)+

                CASE WHEN CLF.PAIDINCASH=1 THEN sum(CASE WHEN SIGN=0 THEN CLF.TRNET ELSE 0 END) ELSE
                sum(CASE WHEN SIGN=1 THEN CLF.TRNET ELSE 0 END) END) [GALACAK],

				ISNULL((SELECT  sum(CASE WHEN SIGN=0 THEN CLF2.TRNET ELSE 0 END)-
                				CASE WHEN CLF2.PAIDINCASH=1 THEN sum(CASE WHEN SIGN=0 THEN CLF2.TRNET ELSE 0 END) ELSE
                                sum(CASE WHEN SIGN=1 THEN CLF2.TRNET ELSE 0 END) END  FROM LG_{4}_{3}_CLFLINE CLF2
                WHERE CLF2.TRCURR={5} AND CLF2.CLIENTREF=C.LOGICALREF AND   CLF2.DATE_ < '{1}'  AND CLF2.CANCELLED=0 group by CLF2.PAIDINCASH ),0)+
                sum(CASE WHEN SIGN=0 THEN CLF.TRNET ELSE 0 END)-
				CASE WHEN CLF.PAIDINCASH=1 THEN sum(CASE WHEN SIGN=0 THEN CLF.TRNET ELSE 0 END) ELSE
                sum(CASE WHEN SIGN=1 THEN CLF.TRNET ELSE 0 END) END [GBAKIYE]

                FROM LG_{4}_{3}_CLFLINE CLF With (Nolock)
                LEFT OUTER JOIN LG_{4}_CLCARD C ON CLF.CLIENTREF=C.LOGICALREF
                WHERE  CLF.TRCURR={5} AND CLF.CANCELLED=0 AND C.CODE = '{0}' AND CLF.DATE_>='{1}' AND CLF.DATE_<='{2}'
                GROUP BY CLF.PAIDINCASH,C.LOGICALREF;

                
                SELECT DATEADD(DAY, dbo.ESBI_CARIVADEGUN_{4}((SELECT TOP 1 LOGICALREF FROM LG_{4}_CLCARD WHERE CODE='{0}')), GETDATE()) AS ORT_VADE_TARIHI;


 SELECT 			
				(ISNULL(( SELECT  SUM(CASE WHEN CLF2.SIGN=0 THEN CLF2.TRNET ELSE 0 END) BORC  FROM LG_{4}_{3}_CLFLINE CLF2
                WHERE  CLF2.TRCURR={5} AND CLF2.CLIENTREF=(SELECT TOP 1 LOGICALREF FROM LG_{4}_CLCARD WHERE CODE='{0}') AND   CLF2.DATE_ < '{1}'  AND CLF2.CANCELLED=0  ),0)) [GBORC],

				(
				ISNULL((SELECT  SUM(CASE WHEN CLF2.SIGN=1 THEN CLF2.TRNET ELSE 0 END) BORC  FROM LG_{4}_{3}_CLFLINE CLF2
                WHERE CLF2.TRCURR={5} AND CLF2.CLIENTREF=(SELECT TOP 1 LOGICALREF FROM LG_{4}_CLCARD WHERE CODE='{0}') AND   CLF2.DATE_ < '{1}'  AND CLF2.CANCELLED=0 ),0)) [GALACAK],

				ISNULL((SELECT  sum(CASE WHEN SIGN=0 THEN CLF2.TRNET ELSE 0 END)-
                				CASE WHEN CLF2.PAIDINCASH=1 THEN sum(CASE WHEN SIGN=0 THEN CLF2.TRNET ELSE 0 END) ELSE
                                sum(CASE WHEN SIGN=1 THEN CLF2.TRNET ELSE 0 END) END  FROM LG_{4}_{3}_CLFLINE CLF2
                WHERE CLF2.TRCURR={5} AND CLF2.CLIENTREF=(SELECT TOP 1 LOGICALREF FROM LG_{4}_CLCARD WHERE CODE='{0}') AND   CLF2.DATE_ < '{1}'  AND CLF2.CANCELLED=0 group by CLF2.PAIDINCASH ),0) [GBAKIYE];


                ", txtCariKodu.Text, txtIlk.DateTime.ToString("yyyy-MM-dd"), txtSon.DateTime.ToString("yyyy-MM-dd"), donem, firma, kur);

                SQLDetail = $@"SELECT F.LOGICALREF FNO, 

                CASE WHEN S.LINETYPE = 4 THEN (SELECT TOP 1 CODE FROM LG_{firma}_SRVCARD WHERE LOGICALREF = S.STOCKREF) 
                                ELSE 
                                I.CODE END [STOKKODU],

                CASE WHEN S.LINETYPE = 4 THEN (SELECT TOP 1 DEFINITION_ FROM LG_{firma}_SRVCARD WHERE LOGICALREF = S.STOCKREF) 
                                ELSE 
                                I.NAME END [STOKCINSI],
                S.LINEEXP [ACIKLAMA],
                S.AMOUNT [MIKTAR], CASE WHEN F.LINEEXCTYP<>4 THEN (CASE WHEN S.TRCURR=0 THEN S.PRICE ELSE  ISNULL((S.PRICE/NULLIF(S.TRRATE,0)),S.PRICE) END)
			ELSE (CASE WHEN S.PRCURR=0 THEN S.PRICE ELSE  ISNULL(S.PRPRICE,0) END) END AS [FIYAT], S.VAT [KDV], ROUND(((ISNULL(S.VATMATRAH,0)+s.VATAMNT)/s.TRRATE),2) [TUTAR]
                FROM LG_{firma}_{donem}_STLINE S With (Nolock)
                LEFT OUTER JOIN LG_{firma}_{donem}_INVOICE F ON S.INVOICEREF=F.LOGICALREF
                LEFT OUTER JOIN LG_{firma}_ITEMS I ON S.STOCKREF=I.LOGICALREF
                LEFT OUTER JOIN LG_{firma}_CLCARD C ON F.CLIENTREF=C.LOGICALREF
                WHERE S.TRCURR={kur} AND C.CODE='{txtCariKodu.Text}' AND  S.CANCELLED=0 AND S.LINETYPE IN (0,4)";
            }
            try
            {
                SqlCommand cmdMaster = new SqlCommand(SQLMaster, clas.Conn);
                SqlDataAdapter daMaster = new SqlDataAdapter(cmdMaster);
                cmdMaster.CommandTimeout = 0;

                SqlCommand cmdDetail = new SqlCommand(SQLDetail, clas.Conn);
                SqlDataAdapter daDetail = new SqlDataAdapter(cmdDetail);
                cmdDetail.CommandTimeout = 0;
                ks.Clear();
                daMaster.Fill(ks, $"LG_{firma}_{donem}_CLFLINE");
                daDetail.Fill(ks, $"LG_{firma}_{donem}_STLINE");

                DataColumn masterColumn = ks.Tables[$"LG_{firma}_{donem}_CLFLINE"].Columns["SREF"];
                DataColumn detailColumn = ks.Tables[$"LG_{firma}_{donem}_STLINE"].Columns["FNO"];

                try
                {
                    ks.Relations.Clear();
                    ks.Relations.Add("FATURA DETAY", masterColumn, detailColumn);
                    clas.Conn.Open();
                }
                catch (Exception e)
                {
                    string s = e.Message;
                    clas.Conn.Close();
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("AÇIKLAMA : " + hata.Message, "RAPOR ALINAMADI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                clas.Conn.Close();
                return;
            }
        }
    }
}