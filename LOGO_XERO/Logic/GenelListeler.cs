using DevExpress.CodeParser;
using DevExpress.DashboardWin.Design;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPrinting;
using LOGO_XERO.Models;
using LOGO_XERO.Models.GenelKullanim;
using LOGO_XERO.Models.LOGO_XERO_M;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGO_XERO.Logic
{
    public class GenelListeler
    {
        SQLConnection clas = new SQLConnection();
        public double UrunStokBakiyeBilgisiGetir(string firma,string donem,int secilenambarlar,int stokref) 
        {
            double stokbak = 0;
            try
            {
                using (LogoContext db = new LogoContext())
                {
                    string sql = $@"select sum(ONHAND) STOKBAKIYEBILGISI from LV_{firma}_{donem}_STINVTOT WHERE STOCKREF={stokref} AND DATE_<='{DateTime.Now.ToString("yyyy-MM-dd")}' AND INVENNO={secilenambarlar}";
                    stokbak = db.Database.SqlQuery<double>(sql).FirstOrDefault();
                    return stokbak;
                }
            }
            catch (Exception)
            {
                return stokbak;
            }
           
        }
        public void DepoStokGetir(string firma, string donem, string stokkod,GridControl grid)
        {
            clas.Connect();

            string SQLd = $@"SELECT 
                    ISNULL((SELECT SUM(ONHAND) FROM LV_{firma}_{donem}_STINVTOT With (Nolock) WHERE (STOCKREF=I.LOGICALREF) AND (INVENNO = -1)),0) [Stok Miktarı], 
                    ISNULL((SELECT SUM(AMOUNT)-SUM(SHIPPEDAMOUNT) FROM LG_{firma}_{donem}_ORFLINE With (Nolock) WHERE STOCKREF=I.LOGICALREF AND TRCODE=1 AND LINETYPE=0 AND CLOSED=0),0) [Satış Siparisi],                   
                    ISNULL((SELECT SUM(AMOUNT)-SUM(SHIPPEDAMOUNT) FROM LG_{firma}_{donem}_ORFLINE With (Nolock) WHERE STOCKREF=I.LOGICALREF AND TRCODE=2 AND LINETYPE=0 AND CLOSED=0),0) [Alış Siparisi],
                    ISNULL((SELECT SUM(ONHAND) FROM LV_{firma}_{donem}_STINVTOT With (Nolock) WHERE (STOCKREF=I.LOGICALREF)  AND (INVENNO = -1)),0)- ISNULL((SELECT SUM(AMOUNT)-SUM(SHIPPEDAMOUNT) FROM LG_{firma}_{donem}_ORFLINE With (Nolock) WHERE STOCKREF=I.LOGICALREF AND TRCODE=1 AND LINETYPE=0  AND CLOSED=0 AND CANCELLED=0),0) [Serbest Stok]
                  

                    FROM LG_{firma}_ITEMS AS I
                    WHERE I.CODE='{stokkod}' AND I.CARDTYPE<>22 AND I.ACTIVE=0
                    GROUP BY I.LOGICALREF,I.CODE, I.CARDTYPE;";
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(SQLd, clas.Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            grid.DataSource = ds.Tables[0];
            grid.RefreshDataSource();
            grid.Refresh();
        }
        public List<LOGO_XERO_SIPARIS_BASLIK> SiparisGetir(string frmano, string donem, string filtre, string tar1, string tar2, string isyeri,int trkod) //GOOZDEKİ satisSiparis2getir
        {
            //trkod 1 Satis 2 Alis
            using (LogoContext db = new LogoContext())
            {
                string sorgu = $@"SELECT  ORF.FICHENO ,ORF.DEPARTMENT BOLUMID,ORF.DOCODE[BELGENO],ORF.LOGICALREF,ORF.DATE_ [DATE],ORF.GROSSTOTAL TOPLAM,ORF.PAYDEFREF [ODEMETIPI],ORF.CAPIBLOCK_CREADEDDATE [KAYITTARIHI],ORF.TRADINGGRP [GRUPACIKLAMA],
 CASE WHEN ORF.STATUS=1 THEN 'ONAY BEKLİYOR'
 WHEN ORF.STATUS=4 THEN 'ONAYLANDI'
 WHEN ORF.STATUS=2 THEN 'ONAYLANMADI'
 ELSE '' END [ONAY],ORF.GENEXP6 [ONAYLAYAN],
 ORF.TRRATE DOVIZKUR,ORF.TRCURR DOVIZ,
ORF.TOTALDISCOUNTS [ISKONTOTUTARI], ORF.TOTALDISCOUNTED [ISKONTOLUTUTAR], ORF.TOTALVAT [KDVTUTARI], ORF.NETTOTAL [TOPLAMTUTAR],
CASE WHEN CL.ACCEPTEINV=0 THEN 'Kağıt Fatura'
WHEN CL.ACCEPTEINV=1 THEN 'E-Fatura'
WHEN CL.ACCEPTEINV=2 THEN 'E-Arşiv' ELSE '' END [FATURATIPI],
--CASE WHEN (ORL.AMOUNT =ORL.SHIPPEDAMOUNT) OR (ORL.CLOSED=1) OR (ORL.AMOUNT<ORL.SHIPPEDAMOUNT) THEN 'KAPALI'  WHEN  (ORL.AMOUNT >ORL.SHIPPEDAMOUNT) AND (ORL.SHIPPEDAMOUNT>0) AND (ORL.CLOSED=0) THEN 'KISMI SEVK' else 'AÇIK'  END TESLIMDURUMU,
CASE WHEN ORF.STATUS  = 1 THEN 'Öneri' WHEN ORF.STATUS  = 2  THEN 'Sevkedilemez'  WHEN ORF.STATUS  = 4 THEN 'Sevkedilebilir' END ONAYDURUMU,
 CL.CODE CARIKOD,CL.DEFINITION_ CARIUNVAN,CL.LOGICALREF [CARILOG],CL.SPECODE CARIOZELKOD,  
ORF.BRANCH ISYERI,ORF.SOURCEINDEX AMBAR,
 

ORF.GENEXP1 SIPARISACIKLAMA,
ORF.GENEXP2 SIPARISACIKLAMA2,
ORF.GENEXP3 SIPARISACIKLAMA3,
ORF.GENEXP4 SIPARISACIKLAMA4,
ORF.GENEXP5 SIPARISACIKLAMA5,
ORF.GENEXP6 SIPARISACIKLAMA6
    
    
FROM LG_{frmano}_{donem}_ORFICHE ORF
--LEFT OUTER JOIN LG_{frmano}_{donem}_ORFLINE ORL ON ORF.LOGICALREF=ORL.ORDFICHEREF  
LEFT OUTER JOIN L_CURRENCYLIST CUR ON ORF.TRCURR = CUR.CURTYPE AND CUR.FIRMNR = {frmano} 
LEFT OUTER JOIN LG_{frmano}_CLCARD CL ON ORF.CLIENTREF = CL.LOGICALREF 
WHERE ORF.TRCODE={trkod} AND --ORL.LINETYPE <> 2 AND 
ORF.DATE_ BETWEEN '{tar1}' and '{tar2}' {isyeri} {filtre}  order by  ORF.DATE_ desc";
                List<LOGO_XERO_SIPARIS_BASLIK> data = db.Database.SqlQuery<LOGO_XERO_SIPARIS_BASLIK>(sorgu).ToList();
                return data;
            } 
        } 
        public List<LOGO_XERO_FATURA_BASLIK> FaturaGetir(string frmano, string donem, string trkod, string ilkt, string sont, int durum ,string isyeri)//GOOZDEKİ Alisfatgetir 
        {
            using (LogoContext db = new LogoContext())
            {
                string sorgu = $@"SELECT TOP (100) PERCENT O.GENEXP2,O.GENEXP3,O.GENEXP4,O.GENEXP5,O.GENEXP6,O.LOGICALREF,C.LOGICALREF [CARILOG], O.FICHENO AS [FISNO],  O.DOCODE AS [BELGENO], 
O.DATE_ AS TARIH,O.DEPARTMENT BOLUMID, dbo.LG_INTTOTIME(O.TIME_) AS SAAT, O.DOCDATE AS [SEVKTARIHI], C.CODE AS [CARIKODU], 
                        C.DEFINITION_ AS [CARIUNVANI], C.SPECODE AS [OZELKOD1],C.SPECODE2 AS [OZELKOD2], C.SPECODE4 AS [OZELKOD4], C.TELNRS1 AS TELEFON, O.TRADINGGRP AS [TICARIISLEMGRUBU],

							  O.BRANCH AS ISYERINO,
							  O.SOURCEINDEX AS [AMBARNO],

O.GENEXP1 AS ACIKLAMA,  O.SALESMANREF AS SALESMANREF,  
                         O.GROSSTOTAL AS TUTAR, O.TOTALDISCOUNTS - O.ADDDISCOUNTS AS [ISKONTOTUTARI], O.TOTALDISCOUNTED AS [ISKONTOLUTUTAR], O.TOTALVAT AS [KDVTUTARI], O.NETTOTAL AS [TOPLAMTUTAR], 
                         O.ADDDISCOUNTS AS [GENELISKONTO], O.PAYDEFREF AS ODEMETIPIID, O.PAYDEFREF AS ODEMETIPI, CASE WHEN O.EINVOICE = 0 THEN 'Kağıt Fatura' WHEN O.EINVOICE = 1 THEN 'E-Fatura' 
						 WHEN O.EINVOICE = 2 THEN 'E-Arşiv'  WHEN O.EINVOICE = 3 THEN 'E-Arşiv İnternet' ELSE '' END AS [FATURATIPI], O.GUID, 
						 
CASE WHEN O.TRCODE =1 THEN '(01)Satın Alma Faturası'
WHEN O.TRCODE =4 THEN '(04)Alınan Hizmet Faturası'
WHEN O.TRCODE=5 THEN '(05)Alınan Proforma Fatura'
WHEN O.TRCODE=6 THEN '(06)Satın Alma İade Faturası'
WHEN O.TRCODE=13 THEN '(13)Satın Alma Fiyat Farkı Faturası'
WHEN O.TRCODE=26 THEN '(26)Müstahsil Makbuzu'
WHEN O.TRCODE =2 THEN '(02)Perakende Satış İade Faturası'
WHEN O.TRCODE =3 THEN '(03)Toptan Satış İade Faturası'
WHEN O.TRCODE=7 THEN '(07)Perakende Satış Faturası'
WHEN O.TRCODE=8 THEN '(08)Toptan Satış Faturası'
WHEN O.TRCODE=9 THEN '(09)Verilen Hizmet Faturası'
WHEN O.TRCODE=10 THEN '(10)Verilen Proforma Fatura'
WHEN O.TRCODE=14 THEN '(14)Verilen Fiyat Farkı Faturası'
ELSE '' END AS [TRCODE], 
E.TCKNO AS [PERAKENDETCNO],
                          E.NAME + E.SURNAME AS [PERAKENDEADISOYADI], E.ISCOMP, E.DEFINITION_ AS ACIKLAMA,  C.TELNRS1 [TELNO], C.ADDR1 [ADRES], C.CITY [SEHIR], C.TOWN [ILCE], C.EMAILADDR [EMAILADRES], 
						  
						  CASE WHEN O.EINVOICE = 1 AND O.ESTATUS=0 THEN 'GİBe Gönderilecek'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=1 THEN 'Onay Gönderildi'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=2 THEN 'Onaylandı'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=3 THEN 'Paketlendi'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=4 THEN 'GİBe Gönderildi'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=5 THEN 'GİBe Gönderilemedi'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=6 THEN 'GİBde İşlendi-Alıcıya İletilecek'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=7 THEN 'GİBde İşlenemedi'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=8 THEN 'Alıcıya Gönderildi'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=9 THEN 'Alıcıya Gönderilemedi'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=10 THEN 'Alıcıda İşlendi-Başarıyla Tamamlandı'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=11 THEN 'Alıcıda İşlenemedi'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=12 THEN 'Kabul Edildi'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=13 THEN 'Reddedildi'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=14 THEN 'İade Edildi'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=15 THEN 'Sunucuya İletildi-İşlenmeyi Bekliyor'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=16 THEN 'Sunuda Mühürlendi'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=17 THEN 'Sunucuda Zarflandı'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=18 THEN 'Sunucuda Hata Alındı'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=19 THEN 'Alındı'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=20 THEN 'Kabul Edildi'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=21 THEN 'Reddedildi'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=22 THEN 'Sunucuya Gönderildi'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=23 THEN 'Harici Yollardan İptal Edildi'
						  WHEN O.EINVOICE = 2 AND E.EARCHIVESTATUS=0 THEN 'E-Arşiv Faturası Oluşturulacak'
						 WHEN O.EINVOICE = 2 AND E.EARCHIVESTATUS=1 THEN 'E-Arşiv Faturası Oluşturuldu'
						 WHEN O.EINVOICE = 2 AND E.EARCHIVESTATUS=2 THEN 'Rapor Dosyasına Yazıldı'
						 WHEN O.EINVOICE = 2 AND E.EARCHIVESTATUS=3 THEN 'Sunucuya İletildi. İşlenmeyi Bekliyor'
						 WHEN O.EINVOICE = 2 AND E.EARCHIVESTATUS=4 THEN 'GIBe İletildi.'
						 WHEN O.EINVOICE = 2 AND E.EARCHIVESTATUS=5 THEN 'Sunucuda Hata Alındı'
						 WHEN O.EINVOICE = 2 AND E.EARCHIVESTATUS=6 THEN 'Sunucuda İmzalandı'
						  else '' end 
						  AS [EFATURASTATUSU],
                          O.PRINTCNT AS [YAZDIRMABILGISI], O.DOCTRACKINGNR AS [DOKUMANIZLEMENO],
                             (SELECT TOP (1) DATE_ FROM dbo.LG_{Convert.ToInt32(frmano)}_{donem}_PAYTRANS WITH (Nolock)
                               WHERE (FICHEREF = O.LOGICALREF) AND (PROCDATE = O.DATE_)) AS [VADETARIHI], AD.CODE AS [SEVKIYATADRESKODU], AD.NAME AS [SEVKIYATADRESI], 
(CASE WHEN O.CANCELLED = 1 THEN 'İptal' WHEN O.CANCELLED=0 THEN 'Gerçek' ELSE '' END) AS DURUMU,  O.EINVOICETYP AS TEVKIFATTIP, C.TAXNR AS [VERGINO], C.TAXOFFICE[VERGIDAIRESI], C.TCKNO, C.SPECODE3, E.SENDMOD
                        FROM   dbo.LG_{Convert.ToInt32(frmano)}_{donem}_INVOICE AS O WITH (Nolock)
                         LEFT OUTER JOIN dbo.LG_{Convert.ToInt32(frmano)}_CLCARD AS C ON O.CLIENTREF = C.LOGICALREF LEFT OUTER JOIN
                         dbo.LG_{Convert.ToInt32(frmano)}_SHIPINFO AS AD ON O.SHIPINFOREF = AD.LOGICALREF LEFT OUTER JOIN 
                         dbo.LG_{Convert.ToInt32(frmano)}_{donem}_EARCHIVEDET AS E ON O.LOGICALREF = E.INVOICEREF
                        WHERE (O.TRCODE IN ({trkod}) AND O.DATE_ BETWEEN '{ilkt}' And '{sont}' AND O.CANCELLED = {durum} {isyeri} ) 
                        ORDER BY  O.DATE_ DESC";
                List<LOGO_XERO_FATURA_BASLIK> data = db.Database.SqlQuery<LOGO_XERO_FATURA_BASLIK>(sorgu).ToList();
                return data;
            }

             
        }  
        public List<LOGO_XERO_FATURALANMAMIS_IRSALIYE> Faturalanmamisİrsaliyeler(string frmano, string donem, int islem, string ilkt, string sont, string isyeri,bool faturalanmis)
        {
			using (LogoContext db = new LogoContext())
			{
                string faturalanmissorgusu = "1=1";
                if (faturalanmis ==false) 
                {
                     faturalanmissorgusu = "S.BILLED = 0";
                }
                else 
                {
                    faturalanmissorgusu = "S.BILLED = 1 OR S.BILLED = 0";
                }
                string sorgu = $@"[dbo].[LOGO_XERO_FATURALANMAMIS_IRSALIYELER]
		@FIRMA = N'{Convert.ToInt32(frmano).ToString("000")}',
		@DONEM = N'{donem}',
		@ISLEM = {islem},
        @TARIH1 = N'{ilkt}',
		@TARIH2 = N'{sont}',
		@Sqlcommand = N' ',
		@filtre = N' ',
		@filtre2 = N' ',
        @isyeri = N'{isyeri}',
        @faturasorgu = N'{faturalanmissorgusu}'
		";
                return db.Database.SqlQuery<LOGO_XERO_FATURALANMAMIS_IRSALIYE>(sorgu).ToList();
            }
        }
        public List<LOGO_XERO_CARI_HAREKET_DOKUM> CariHareketGetir(string frmano, string donem, string ilkt, string sont, string isyeri)
        {
            using (LogoContext db = new LogoContext())
            {
                string sorgu = $@"SELECT   ch.SIGN BA, CC.LOGICALREF[CARILOG],CC.CODE CARIKODU, CC.DEFINITION_ CARIUNVAN, CC.SPECODE OZELKOD1, CC.SPECODE2 OZELKOD2, CC.SPECODE3 OZELKOD3, SPE.DEFINITION_ OZELKOD3AD,
 CC.SPECODE4 OZELKOD4, CC.SPECODE5 OZELKOD5, CH.AMOUNT TUTAR, SE.DEFINITION_ SATISELEMANI, CH.DATE_ TARIH,
CASE when CH.MONTH_=1 then '01-Ocak'
when CH.MONTH_=2 then '02-Şubat'
when CH.MONTH_=3 then '03-Mart'
when CH.MONTH_=4 then '04-Nisan'
when CH.MONTH_=5 then '05-Mayıs'
when CH.MONTH_=6 then '06-Haziran'
when CH.MONTH_=7 then '07-Temmuz'
when CH.MONTH_=8 then '08-Ağustos'
when CH.MONTH_=9 then '09-Eylül'
when CH.MONTH_=10 then '10-Ekim'
when CH.MONTH_=11 then '11-Kasım'
when CH.MONTH_=12 then '12-Aralık'
else '' end as AY, CH.CAPIBLOCK_CREADEDDATE OLUSTURMATARIHI,
(SELECT NAME FROM L_CAPIUSER CP  WHERE CP.LOGICALREF = CH.CAPIBLOCK_CREATEDBY ) EKLEYEN,
CH.CAPIBLOCK_MODIFIEDDATE DEGISTIRMETARIHI,
(SELECT NAME FROM L_CAPIUSER CP  WHERE CP.LOGICALREF = CH.CAPIBLOCK_MODIFIEDBY  ) DEGISTIREN,
CH.YEAR_ YIL, CH.TRCODE TRCODE,CH.MODULENR MODULENR,
CASE WHEN CH.TRCODE = 1 THEN 'Nakit Tahsilat' WHEN CH.TRCODE = 2 THEN 'Nakit Ödeme' WHEN CH.TRCODE = 3 THEN 'Borç Dekontu' WHEN CH.TRCODE = 4 THEN
'Alacak Dekontu' WHEN CH.TRCODE = 5 THEN 'Virman İşlemi' WHEN CH.TRCODE = 14 THEN 'Açılış Fişi' WHEN CH.TRCODE = 20 THEN 'Gelen Havale' WHEN CH.TRCODE
= 21 THEN 'Gönderilen Havale' WHEN CH.TRCODE = 28 THEN 'Banka Alınan Hizmet Faturası' WHEN CH.TRCODE = 29 THEN 'Banka Verilen Hizmet Faturası' WHEN CH.TRCODE
= 31 THEN 'Satınalma Faturası' WHEN CH.TRCODE = 32 THEN 'Perakende Satış İade Faturası' WHEN CH.TRCODE = 33 THEN 'Toptan Satış İade Faturası' WHEN CH.TRCODE
= 34 THEN 'Alınan Hizmet Faturası' WHEN CH.TRCODE = 36 THEN 'Satınalma İade Faturası' WHEN CH.TRCODE = 37 THEN 'Perakende Satış Faturası' WHEN CH.TRCODE
= 38 THEN 'Toptan Satış Faturası' WHEN CH.TRCODE = 39 THEN 'Verilen Hizmet Faturası' WHEN CH.TRCODE = 43 THEN 'Satınalma Fiyat Farkı Faturası' WHEN CH.TRCODE
= 44 THEN 'Satış Fiyat Farkı Faturası' WHEN CH.TRCODE = 61 THEN 'Çek Girişi' WHEN CH.TRCODE = 62 THEN 'Senet Girişi' WHEN CH.TRCODE = 63 THEN 'Çek Çıkış (Cari Hesaba)'
WHEN CH.TRCODE = 70 THEN 'Kredi Kartı Fişi' WHEN CH.TRCODE = 72 THEN 'Firma Kredi Kartı Fişi' WHEN CH.TRCODE = 73 THEN 'Firma Kredi Kartı İade Fişi' END AS
[FISTIPI], CASE WHEN CH.CANCELLED = 0 THEN 'Gerçek' WHEN CH.CANCELLED = 1 THEN 'İptal' END AS DURUMU,
case when ch.SIGN=0 then ch.AMOUNT end [BORCTUTARI], CASE WHEN CH.SIGN=1 THEN CH.AMOUNT END [ALACAKTUTARI],
(SELECT TOP 1 NAME FROM L_CAPIDIV WHERE NR=CH.BRANCH AND FIRMNR={Convert.ToInt32(frmano).ToString("000")}) ISYERI
FROM dbo.LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE AS CH
LEFT OUTER JOIN dbo.LG_{Convert.ToInt32(frmano).ToString("000")}_CLCARD AS CC ON CH.CLIENTREF = CC.LOGICALREF
LEFT OUTER JOIN
dbo.LG_SLSMAN AS SE ON CH.SALESMANREF = SE.LOGICALREF
LEFT OUTER JOIN LG_{Convert.ToInt32(frmano).ToString("000")}_SPECODES SPE ON CC.SPECODE3=SPE.SPECODE AND SPE.SPETYP3=1 AND SPE.SPECODETYPE=26
where CH.DATE_ between '{ilkt}' and '{sont}' AND CH.BRANCH IN ({isyeri})";
                List<LOGO_XERO_CARI_HAREKET_DOKUM> data = db.Database.SqlQuery<LOGO_XERO_CARI_HAREKET_DOKUM>(sorgu).ToList();
                return data;
            } 
        } 
        public List<LOGO_XERO_CARI_BAKIYE> Cari_Bakiye_Getir(string frmano, string donem,string carikod = "")
        {
			using (LogoContext db = new LogoContext())
			{
                string sorgu = $@"SELECT C.LOGICALREF
	,C.CYPHCODE [CARIYETKIKODU]
	,C.CODE [CARIKODU]
	,C.DEFINITION_ [UNVAN]
	,C.SPECODE [OZELKOD1]
	,C.SPECODE2 [OZELKOD2]
	,C.SPECODE3 [OZELKOD3]
	,C.SPECODE4 [OZELKOD4]
	,C.SPECODE5 [OZELKOD5],
    C.ACTIVE[DURUMU],
	ISNULL((SELECT SUM(AMOUNT) FROM LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE CLF  WHERE CLF.CLIENTREF=C.LOGICALREF AND CLF.SIGN=0  AND CANCELLED=0 ), 0) 
    + ISNULL((SELECT SUM(AMOUNT) FROM LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE CLF WHERE CLF.CLIENTREF=C.LOGICALREF AND SIGN=1 AND PAIDINCASH=1 AND CANCELLED=0), 0) [BORC],
	ISNULL((SELECT SUM(AMOUNT) FROM LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE CLF  WHERE CLF.CLIENTREF=C.LOGICALREF AND CLF.SIGN=1  AND CANCELLED=0 ), 0)
    + ISNULL((SELECT SUM(AMOUNT) FROM LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE CLF WHERE CLF.CLIENTREF=C.LOGICALREF AND SIGN=0 AND PAIDINCASH=1 AND CANCELLED=0), 0) [ALACAK],
	ISNULL((SELECT SUM(AMOUNT) FROM LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE CLF  WHERE CLF.CLIENTREF=C.LOGICALREF AND CLF.SIGN=0  AND CANCELLED=0  AND CLF.PAIDINCASH<>1), 0) - ISNULL((SELECT SUM(AMOUNT) FROM LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE CLF  WHERE CLF.CLIENTREF=C.LOGICALREF AND CLF.SIGN=1  AND CANCELLED=0  AND CLF.PAIDINCASH<>1), 0)  [BAKIYE]
	,(SELECT TOP 1 DATE_ FROM LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE  CLF		WHERE SIGN = 1	AND  CANCELLED=0  AND CLF.CLIENTREF = C.LOGICALREF	ORDER BY CLF.DATE_ DESC	)	 [SONALACAKHAREKETTARIHI],
			(SELECT TOP 1 (
				CASE 
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 1
						THEN 'Nakit Tahsilat'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 2
						THEN 'Nakit Ödeme'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 3
						THEN 'Borç Dekontu'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 4
						THEN 'Alacak Dekontu'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 5
						THEN 'Virman Fişi'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 6
						THEN 'Alım iade faturası'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 14
						THEN 'Devir'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 20
						THEN 'Gelen Havale'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 21
						THEN 'Gönderilen Havale'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 28
						THEN 'Alınan Hizmet Fat.(B)'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 29
						THEN 'Verilen Hizmet Fat.(B)'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 31
						THEN 'Satın Alma Faturası'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 32
						THEN 'Perakende Satış İade Fat.'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 33
						THEN 'Toptan Satış İade Fat.'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 34
						THEN 'Alınan Hizmet Faturası'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 34
						THEN 'Satınalma İade Fat.'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 37
						THEN 'Perakende Satış Fat.'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 38
						THEN 'Toptan Satış Faturası'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 39
						THEN 'Verilen Hizmet Faturası'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 61
						THEN 'Çek Girişi'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 62
						THEN 'Senet Girişi'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 63
						THEN 'Çek Çıkış'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 64
						THEN 'Senet Çıkış'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 70
						THEN 'Kredi Kartı Fişi'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 72
						THEN 'Firma Kredi Kartı Fişi'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 26
						THEN 'Müstahsil makbuzu'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 81
						THEN 'Ödemeli Satış Siparişi'
					END
				) AS FISTURU
		FROM LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE 
		WHERE SIGN = 1
			AND  LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.CLIENTREF= C.LOGICALREF
		ORDER BY DATE_ DESC
		) [SONALACAKISLEMTURU]
	,(
		SELECT TOP 1 AMOUNT
		FROM LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE
		WHERE SIGN = 1 
			AND LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.CLIENTREF =C.LOGICALREF
		ORDER BY DATE_ DESC
		) [SONALACAKTUTARI]
	,(
		SELECT TOP 1 DATE_
		FROM LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE
		WHERE SIGN = 0 
			AND  LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.CLIENTREF =C.LOGICALREF 
		ORDER BY DATE_ DESC
		) [SONBORCHAREKETTARIHI]
	,(
		SELECT TOP 1 (
				CASE 
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 1
						THEN 'Nakit Tahsilat'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 2
						THEN 'Nakit Ödeme'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 3
						THEN 'Borç Dekontu'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 4
						THEN 'Alacak Dekontu'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 5
						THEN 'Virman Fişi'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 6
						THEN 'Alım iade faturası'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 14
						THEN 'Devir'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 20
						THEN 'Gelen Havale'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 21
						THEN 'Gönderilen Havale'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 28
						THEN 'Alınan Hizmet Fat.(B)'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 29
						THEN 'Verilen Hizmet Fat.(B)'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 31
						THEN 'Satın Alma Faturası'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 32
						THEN 'Perakende Satış İade Fat.'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 33
						THEN 'Toptan Satış İade Fat.'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 34
						THEN 'Alınan Hizmet Faturası'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 34
						THEN 'Satınalma İade Fat.'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 37
						THEN 'Perakende Satış Fat.'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 38
						THEN 'Toptan Satış Faturası'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 39
						THEN 'Verilen Hizmet Faturası'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 61
						THEN 'Çek Girişi'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 62
						THEN 'Senet Girişi'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 63
						THEN 'Çek Çıkış'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 64
						THEN 'Senet Çıkış'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 70
						THEN 'Kredi Kartı Fişi'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 72
						THEN 'Firma Kredi Kartı Fişi'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 26
						THEN 'Müstahsil makbuzu'
					WHEN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.TRCODE = 81
						THEN 'Ödemeli Satış Siparişi'
					END
				) AS FISTURU
		FROM LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE
		WHERE SIGN = 0 
			AND  LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.CLIENTREF =C.LOGICALREF
		ORDER BY DATE_ DESC
		) [SONBORCISLEMTURU]
	,(
		SELECT TOP 1 AMOUNT
		FROM LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE
		WHERE SIGN = 0 
			AND  LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_CLFLINE.CLIENTREF = C.LOGICALREF
		ORDER BY DATE_ DESC
		) [SONBORCTUTARI]
	FROM 
LG_{Convert.ToInt32(frmano).ToString("000")}_CLCARD C
WHERE C.CARDTYPE<>22 AND C.ACTIVE=0 {carikod}
group by 
	 C.LOGICALREF
	,C.CYPHCODE
	,C.CODE
	,C.SPECODE
	,C.SPECODE2
	,C.SPECODE3
	,C.SPECODE4
	,C.SPECODE5
	,C.DEFINITION_,C.ACTIVE

ORDER BY C.DEFINITION_";
                List<LOGO_XERO_CARI_BAKIYE> data = db.Database.SqlQuery<LOGO_XERO_CARI_BAKIYE>(sorgu).ToList();
                return data;
            } 
        }
        public List<LOGO_XERO_URUN_BILGI> urunbilgiAyGetir(string sirket, string donem, string stokref)
		{
			using (LogoContext db = new LogoContext())
			{
                string sorgu = $@"SELECT YEAR (DATE_) [Yıl],CASE WHEN MONTH(DATE_)=1 then 'Ocak'
WHEN MONTH(DATE_)=2 then 'Şubat'
WHEN MONTH(DATE_)=3 then 'Mart'
WHEN MONTH(DATE_)=4 then 'Nisan'
WHEN MONTH(DATE_)=5 then 'Mayıs'
WHEN MONTH(DATE_)=6 then 'Haziran'
WHEN MONTH(DATE_)=7 then 'Temmuz'
WHEN MONTH(DATE_)=8 then 'Ağustos'
WHEN MONTH(DATE_)=9 then 'Eylül'
WHEN MONTH(DATE_)=10 then 'Ekim'
WHEN MONTH(DATE_)=11 then 'Kasım'
WHEN MONTH(DATE_)=12 then 'Aralık' else '' end as [Ay],

SUM(PURAMNT) [Alıs_Mıktar],SUM(PURCASH)  [Alıs_Tutar],
SUM(SALAMNT )[Satıs_Mıktar],SUM(SALCASH) [Satıs_Tutar]
FROM LV_{sirket}_{donem}_STINVTOT 
WHERE STOCKREF = {stokref}
AND INVENNO=-1
GROUP BY  YEAR (DATE_),MONTH (DATE_)
ORDER BY YEAR(DATE_) DESC , MONTH (DATE_) DESC";

                List<LOGO_XERO_URUN_BILGI> data = db.Database.SqlQuery<LOGO_XERO_URUN_BILGI>(sorgu).ToList();
                return data;
            }
        
        }
        public List<LOGO_XERO_URUN_BILGI> urunbilgiYilGetir(string sirket, string donem, string stokref)
        {
			using (LogoContext db = new LogoContext())
			{

                string sorgu = $@"SELECT YEAR (DATE_) [Yıl],

SUM(PURAMNT) [Alıs_Mıktar],SUM(PURCASH) [Alıs_Tutar],
SUM(SALAMNT )[Satıs_Mıktar],SUM(SALCASH) [Satıs_Tutar]
FROM LV_{sirket}_{donem}_STINVTOT 
WHERE STOCKREF = {stokref}
AND INVENNO=-1
GROUP BY  YEAR (DATE_)
ORDER BY YEAR(DATE_) DESC ";

                List<LOGO_XERO_URUN_BILGI> data = db.Database.SqlQuery<LOGO_XERO_URUN_BILGI>(sorgu).ToList();
                return data;
            }
        }
        public List<STRINGDEGER> OzelKodListesi(string frmano, string OdelKodSayi)
        {
            using (LogoContext db = new LogoContext())
            {
                string sql = $@"SELECT LOGICALREF LOGICALREF,SPECODE DEGER, DEFINITION_ DEGER2 
            FROM LG_{frmano}_SPECODES
            WHERE SPECODETYPE=1 AND {OdelKodSayi} = 1 AND CODETYPE = 1 ORDER BY SPECODE";
                return db.Database.SqlQuery<STRINGDEGER>(sql).ToList();
            }
        }
        public List<STRINGDEGER> MalzemeGrupKoduOzelKodListesi(string frmano)
        {
            using (LogoContext db = new LogoContext())
            {
                string sql = $@"SELECT LOGICALREF LOGICALREF,SPECODE DEGER, DEFINITION_ DEGER2 
            FROM LG_{frmano}_SPECODES
            WHERE CODETYPE=4 ORDER BY SPECODE";
                return db.Database.SqlQuery<STRINGDEGER>(sql).ToList();
            }
        }
        public void FATURALANMAMIS_IRS_PROCEDURE_OLUSTUR(string firma)
        {
            try
            {
                clas.Connect();
                string sql = $@"CREATE PROCEDURE[dbo].[LOGO_XERO_FATURALANMAMIS_IRSALIYELER]
@FIRMA nvarchar(5),  
@DONEM  nvarchar(3),
@ISLEM int,
@TARIH1   nvarchar(200),
@TARIH2   nvarchar(200),
@Sqlcommand nvarchar(max),
@filtre nvarchar(200),
@filtre2 nvarchar(200),
@isyeri nvarchar(200), 
@faturasorgu nvarchar(200)


AS   
BEGIN set @filtre ='S.TRCODE IN(1,5,6,10,26)'
set @filtre2='S.TRCODE IN(7,8,9)'
set @Sqlcommand='SELECT S.DATE_ [TARIH],S.FICHENO [FISNO],S.BILLED[BILLED],S.SALESMANREF[CODE],S.DEPARTMENT [BOLUM],S.SOURCEINDEX [AMBAR],S.BRANCH[ISYERI],S.TOTALDISCOUNTED[TOTALDISCOUNTED],S.GROSSTOTAL[GROSSTOTAL],S.NETTOTAL [NETTOTAL], CASE WHEN S.TRCODE=1 THEN ''Mal Alım Faturası'' WHEN S.TRCODE=2  THEN ''Perakende Satış İade Faturası'' WHEN S.TRCODE=3 THEN ''Toptan Satış İade Faturası'' WHEN S.TRCODE=4 THEN ''Alınan Hizmet Faturası'' WHEN S.TRCODE=5 THEN ''Alınan Proforma Faturası'' WHEN S.TRCODE=6  THEN ''Alım İade Faturası'' WHEN S.TRCODE=7 THEN ''Perakende Satış Faturası'' WHEN S.TRCODE=8  THEN ''Toptan Satış Faturası'' WHEN S.TRCODE=9 THEN ''Verilen Hizmet Faturası'' WHEN S.TRCODE=10  THEN ''Verilen Proforma Faturası'' WHEN S.TRCODE=13 THEN ''Alınan Fiyat Farkı Faturası''  WHEN S.TRCODE=26 THEN ''Müstahsil Makbuzu'' ELSE '''' END [FISTURU], CASE WHEN S.EDESPATCH=1 and S.EDESPSTATUS=0 THEN ''GİB’e Gönderilecek''  WHEN S.EDESPATCH=1 and S.EDESPSTATUS=1 THEN ''Mühürde/Onayda'' WHEN S.EDESPATCH=1 and S.EDESPSTATUS=2 THEN ''Mühürlendi/Onaylandı'' WHEN S.EDESPATCH=1 and S.EDESPSTATUS=3 THEN ''Zarflandı/Paketlendi'' WHEN S.EDESPATCH=1 and S.EDESPSTATUS=4 THEN ''GİB’e gönderildi''  WHEN S.EDESPATCH=1 and S.EDESPSTATUS=5 THEN ''GİB’e gönderilemedi''
 WHEN S.EDESPATCH=1 and S.EDESPSTATUS=6 THEN ''GİB’de işlendi - Alıcıya iletilecek''  WHEN S.EDESPATCH=1 and S.EDESPSTATUS=7 THEN ''GİB’de işlenemedi''
 WHEN S.EDESPATCH=1 and S.EDESPSTATUS=8 THEN ''Alıcıya gönderildi''  WHEN S.EDESPATCH=1 and S.EDESPSTATUS=9 THEN ''Alıcıya gönderilemedi'' 
 WHEN S.EDESPATCH=1 and S.EDESPSTATUS=10 THEN ''Alıcıda işlendi - Başarıyla Tamamlandı'' WHEN S.EDESPATCH=1 and S.EDESPSTATUS=11 THEN ''Alıcıda işlenemedi'' 
 WHEN S.EDESPATCH=1 and S.EDESPSTATUS=12 THEN ''Kabul edildi'' WHEN S.EDESPATCH=1 and S.EDESPSTATUS=14 THEN ''İade edildi'' WHEN S.EDESPATCH=1 and S.EDESPSTATUS=15 THEN ''Sunucuya iletildi - İşlenmeyi bekliyor'' WHEN S.EDESPATCH=1 and S.EDESPSTATUS=16 THEN ''Sunucuda Mühürlendi'' WHEN S.EDESPATCH=1 and S.EDESPSTATUS=17 THEN ''Sunucuda Zarflandı'' WHEN S.EDESPATCH=1 and S.EDESPSTATUS=18 THEN ''Sunucuda hata alındı''  WHEN S.EDESPATCH=1 and S.EDESPSTATUS=19 THEN ''Alındı'' WHEN S.EDESPATCH=1 and S.EDESPSTATUS=22 THEN ''Sunucuya gönderildi'' WHEN S.EDESPATCH=1 and S.EDESPSTATUS=24 THEN ''İrsaliye Yanıtı Alındı'' WHEN S.EDESPATCH=1 and S.EDESPSTATUS=25 THEN ''Alındı – İrsaliye Yanıtı Oluşturuldu'' ELSE '''' END [STATU], C.LOGICALREF[CARILOG],C.CODE [CARIKODU],C.SPECODE [OZELKOD],C.DEFINITION_ [CARIUNVANI], S.TOTALVAT[KDVTUTARI], S.LOGICALREF [LOGREF], S.NETTOTAL [TOPLAMTUTAR],S.EDESPATCH [DURUMU],CASE WHEN S.EDESPATCH=0 THEN ''Kağıt İrsaliye'' WHEN S.EDESPATCH=1 THEN ''E-İrsaliye'' END AS [DURUMU1],S.EDESPATCH[EIRSALIYEDURUMU] FROM LG_'+@FIRMA+'_'+@DONEM+'_STFICHE S LEFT OUTER JOIN LG_'+@FIRMA+'_'+@DONEM+'_STLINE SL on S.LOGICALREF=SL.STFICHEREF INNER JOIN LG_'+@FIRMA+'_CLCARD C ON S.CLIENTREF=C.LOGICALREF WHERE S.DATE_ >= '''+@TARIH1+''' AND S.DATE_ <='''+@TARIH2+''' AND '+CASE WHEN @ISLEM=1 THEN @filtre ELSE @filtre2 END  +' AND '+@faturasorgu+' AND SL.LINETYPE=0 AND S.CANCELLED=0 AND SL.SOURCELINK=0 AND  S.BRANCH IN('+@isyeri+') AND  SL.LOGICALREF NOT IN (SELECT SOURCELINK FROM LG_'+@FIRMA+'_'+@DONEM+'_STLINE WHERE SOURCELINK>0 AND DATE_ BETWEEN '''+@TARIH1+''' AND '''+@TARIH2+''' AND TRCODE IN (6,3) AND LINETYPE=0 AND CANCELLED=0) GROUP BY C.LOGICALREF,C.SPECODE,S.LOGICALREF, S.FICHENO, S.BILLED,S.DEPARTMENT,S.SOURCEINDEX,S.SALESMANREF,S.BRANCH,C.CODE,C.DEFINITION_,C.DEFINITION2,S.DATE_,S.TRCODE,S.EDESPATCH,S.EDESPSTATUS, S.TOTALDISCOUNTED ,S.TOTALVAT ,S.TOTALDISCOUNTS,S.GROSSTOTAL,S.NETTOTAL'
EXEC (@Sqlcommand)
END
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }

        } 
        public List<LOGO_XERO_CARI_BILGI> caribilgiAyGetir(string sirket, string donem, string cardref)
        {
			using (LogoContext db = new LogoContext())
			{
                string sorgu = $@"SELECT YEAR_ [Yıl],CASE WHEN MONTH_=1 then 'Ocak'
                WHEN MONTH_=2 then 'Şubat'
                WHEN MONTH_=3 then 'Mart'
                WHEN MONTH_=4 then 'Nisan'
                WHEN MONTH_=5 then 'Mayıs'
                WHEN MONTH_=6 then 'Haziran'
                WHEN MONTH_=7 then 'Temmuz'
                WHEN MONTH_=8 then 'Ağustos'
                WHEN MONTH_=9 then 'Eylül'
                WHEN MONTH_=10 then 'Ekim'
                WHEN MONTH_=11 then 'Kasım'
                WHEN MONTH_=12 then 'Aralık'
                else '' end as [Ay]  , 
                SUM(DEBIT)[Borc_Tutarı], SUM(CREDIT)[Alacak_Tutarı] 
                FROM LV_{sirket}_{donem}_CLTOTFIL CT
                WHERE CARDREF={cardref} AND TOTTYP=1
                GROUP BY YEAR_,MONTH_ 
                ORDER BY YEAR_ desc ,MONTH_ desc ";
                List<LOGO_XERO_CARI_BILGI> data = db.Database.SqlQuery<LOGO_XERO_CARI_BILGI>(sorgu).ToList();
                return data;
            } 
        }
        public List<LOGO_XERO_CARI_BILGI> caribilgiYilGetir(string sirket, string donem, string cardref)
		{
			using (LogoContext db = new LogoContext())
			{ 
				string sorgu = $@"SELECT  YEAR_ [Yıl],
					SUM(DEBIT)[Borc_Tutarı], SUM(CREDIT)[Alacak_Tutarı]   
					FROM LV_{sirket}_{donem}_CLTOTFIL CT  
					WHERE CARDREF={cardref} AND TOTTYP=1 
					GROUP BY YEAR_  
					ORDER BY YEAR_ desc";

                List<LOGO_XERO_CARI_BILGI> data = db.Database.SqlQuery<LOGO_XERO_CARI_BILGI>(sorgu).ToList();
                return data;
            }
        }
        public void pdfAktar(GridControl grid)
        {
            SaveFileDialog svf = new SaveFileDialog();
            svf.Filter = "Pdf Dosyası| *.pdf";
            DialogResult dr = svf.ShowDialog();
            if (dr == DialogResult.OK)
            {

                grid.ExportToPdf(svf.FileName);
            }
        }
        public void pdfAktar(PivotGridControl pivot)
        {
            SaveFileDialog svf = new SaveFileDialog();
            svf.Filter = "Pdf Dosyası| *.pdf";
            DialogResult dr = svf.ShowDialog();
            if (dr == DialogResult.OK)
            {

                pivot.ExportToPdf(svf.FileName);
            }
        }
        public void excelAktar(GridControl grid)
        {
            SaveFileDialog svf = new SaveFileDialog();
            svf.Filter = "Excel Dosyası| *.xlsx";
            DialogResult dr = svf.ShowDialog();
            if (dr == DialogResult.OK)
            {
                grid.ExportToXlsx(svf.FileName);
            }
        }
        public void excelAktar(PivotGridControl pivot)
        {
            SaveFileDialog svf = new SaveFileDialog();
            svf.Filter = "Excel Dosyası| *.xlsx";
            DialogResult dr = svf.ShowDialog();
            if (dr == DialogResult.OK)
            {
                pivot.ExportToXlsx(svf.FileName);
            }
        }
        public List<LOGO_XERO_CARI_EKSTRE> CariEkstreGetir(string sirket, string donem, string carikod,string tarihilk,string tarihson,string secilisorgu)
        {
            using (LogoContext db = new LogoContext())
            {

                string sorgu = $@"WITH cteHesap AS(SELECT ROW_NUMBER() OVER (ORDER BY CLF.DATE_) as TarihId, 
                C.CODE as BAYIKODU,C.DEFINITION_[CARIUNVANI],
                CLF.SOURCEFREF AS SREF,
                CLF.DATE_,CLF.TRANNO AS FISNO,
ISNULL((SELECT TOP 1 CODE  FROM LG_{sirket}_PROJECT P WHERE LOGICALREF=CLF.CLPRJREF),'') PROJEKODU,
ISNULL((SELECT TOP 1 NAME  FROM LG_{sirket}_PROJECT P WHERE LOGICALREF=CLF.CLPRJREF),'') PROJE,
                case when CLF.TRCODE=1 then 'Nakit Tahsilat'
                when CLF.TRCODE=2 then 'Nakit Ödeme' 
                when CLF.TRCODE=3 then 'Borç Dekontu' 
                when CLF.TRCODE=4 then 'Alacak Dekontu'
                when CLF.TRCODE=5 then 'Virman Fişi'  
                 when CLF.TRCODE=6 then 'Kur Farkı İşlemi' 
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
                when CLF.TRCODE=56 then 'Müstahsil makbuzu' end as FISTURU,CLF.TRCODE [TRKOD], 
                CLF.DOCODE AS BELGENO,CLF.CLIENTREF,CLF.LINEEXP AS ACIKLAMA,
                 sum(CASE
				WHEN SIGN=0  AND CLF.PAIDINCASH=1 AND TRCODE=34 THEN CLF.AMOUNT
				WHEN SIGN=0  AND CLF.PAIDINCASH<>1 THEN CLF.AMOUNT  
				WHEN SIGN=1  AND CLF.PAIDINCASH=1 THEN CLF.AMOUNT 
				ELSE 0 END) as BORC, 
                sum(CASE 
				WHEN SIGN=1 AND CLF.PAIDINCASH=1 AND TRCODE=34 THEN CLF.AMOUNT
				WHEN SIGN=1  AND CLF.PAIDINCASH<>1 THEN CLF.AMOUNT  
				WHEN SIGN=0  AND CLF.PAIDINCASH=1 THEN CLF.AMOUNT 
				ELSE 0 END) as ALACAK,
                ISNULL(SUM((CASE
				WHEN SIGN=0  AND CLF.PAIDINCASH=1 AND TRCODE=34 THEN CLF.AMOUNT
				WHEN SIGN=0  AND CLF.PAIDINCASH<>1 THEN CLF.AMOUNT  
				WHEN SIGN=1  AND CLF.PAIDINCASH=1 THEN CLF.AMOUNT 
				ELSE 0 END)-(CASE 
				WHEN SIGN=1 AND CLF.PAIDINCASH=1 AND TRCODE=34 THEN CLF.AMOUNT
				WHEN SIGN=1  AND CLF.PAIDINCASH<>1 THEN CLF.AMOUNT  
				WHEN SIGN=0  AND CLF.PAIDINCASH=1 THEN CLF.AMOUNT 
				ELSE 0 END)),0) BAKIYE,
                CLF.CANCELLED
                FROM LG_{sirket}_{donem}_CLFLINE CLF With (Nolock)
                LEFT OUTER JOIN LG_{sirket}_CLCARD C ON CLF.CLIENTREF=C.LOGICALREF
                where C.CODE = '{carikod}' AND CLF.CANCELLED=0  AND CLF.DATE_ BETWEEN '{tarihilk}' AND '{tarihson}'
                GROUP BY CLF.SOURCEFREF,C.DEFINITION_,
                C.CODE,
                CLF.DATE_,
                CLF.TRANNO,
                CLF.TRCODE,
                CLF.DOCODE,
                CLF.CLIENTREF,
                CLF.LINEEXP,
                CLF.LOGICALREF,
                CLF.CANCELLED,CLF.CLPRJREF)

                SELECT c1.BAYIKODU,c1.CARIUNVANI,c1.CLIENTREF, c1.SREF,c1.DATE_ as TARIH,c1.FISNO,c1.PROJEKODU,c1.PROJE,c1.FISTURU,c1.TRKOD,c1.BELGENO,c1.ACIKLAMA,c1.BORC,c1.ALACAK,SUM(c2.BAKIYE) BAKIYE
                FROM cteHesap c1 
                LEFT JOIN cteHesap c2 ON c1.TarihId>=c2.TarihId
                WHERE  c1.BAYIKODU = '{carikod}' AND c1.CANCELLED=0  {secilisorgu}
               
                GROUP BY c1.BAYIKODU, c1.CLIENTREF,c1.SREF,c1.DATE_,c1.FISNO,c1.PROJEKODU,c1.PROJE,c1.FISTURU,c1.TRKOD,c1.CARIUNVANI,c1.BELGENO,c1.BAKIYE,c1.BORC,c1.ALACAK,c1.ACIKLAMA,c1.CANCELLED
                ORDER BY c1.DATE_,c1.SREF;
               ";

                List<LOGO_XERO_CARI_EKSTRE> data = db.Database.SqlQuery<LOGO_XERO_CARI_EKSTRE>(sorgu).ToList();
                return data;
            }
        }
        public List<LOGO_XERO_KAR_ZARAR_RENK> YeniRenkGetir(int tip)
        {
            using (LogoContext db = new LogoContext())
            {
                return db.LOGO_XERO_KAR_ZARAR_RENK.Where(s=>s.TIP == tip).ToList();

            }  
        }
        public void yazdir(GridControl grid)
        {
            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());

            // her seferinde sadece biri
            link.Component = grid; //yazdıracağımız grid’i gösteriyoruz.


            link.Landscape = true; //kenarlıkların, boşlukların görüntülenmesini sağlıyoruz.
            link.PageHeaderFooter = true;
            link.RtfReportHeader = "Rapor" + " " + DateTime.Now.ToString();
            link.ShowPreview(); //yazdırılacak gridi ekranda gösteriyoruz
            //PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());

            //link.Component = grid;

            //link.CreateMarginalHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeaderArea);

            //link.CreateDocument();
            //link.ShowPreview();

        }
        public void yazdir(PivotGridControl grid)
        {
            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());

            // her seferinde sadece biri
            link.Component = grid; //yazdıracağımız grid’i gösteriyoruz.


            link.Landscape = true; //kenarlıkların, boşlukların görüntülenmesini sağlıyoruz.
            link.PageHeaderFooter = true;
            link.RtfReportHeader = "Rapor" + " " + DateTime.Now.ToString();
            link.ShowPreview(); //yazdırılacak gridi ekranda gösteriyoruz
            //PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());

            //link.Component = grid;

            //link.CreateMarginalHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeaderArea);

            //link.CreateDocument();
            //link.ShowPreview();

        }
        public List<LOGO_XERO_KAR_ZARAR_ANALIZ> karZararAnaliz(string frmano, string donem, string ilkt, string sont, string ambar, string stokfiltesi, string filtre, string ambarfiltre, string trkodfiltresi, string outcostuntrkodfiltresi, string outcostfiyatalani, string caribilgisi, string maliyettarihyeri, string bolum)
        {
            string bolumfiltresi = "";
            if (!string.IsNullOrWhiteSpace(bolum))
            {
                bolumfiltresi = $@" AND STFICHE.DEPARTMENT IN({bolum})";
            }
            using (LogoContext db = new LogoContext())
            {
                string sorgu = $@"if (object_id('tempdb..#tmpsatiskarzarar') is not null) begin drop table #tmpsatiskarzarar end;
create table #tmpsatiskarzarar ( FTIME INT,[STLOG] int,SATISELEMANI nvarchar(51), [STOCKREF] INT,IRSALIYETARIHI DATETIME,FATURATARIHI DATETIME,FATURATIPI NVARCHAR(50), 
[FATURANO] nvarchar(55),[FISTURU] nvarchar(55),[STOKKODU] nvarchar(25),[STOKADI] nvarchar(51),CARILOG INT,[CARIKODU] nvarchar(51),[CARIUNVANI] nvarchar(250),[CARIOZELKOD] nvarchar(51),
[CARIOZELKOD2] nvarchar(51),[CARIOZELKOD3] nvarchar(51),
[CARIOZELKOD4] nvarchar(51),[CARIOZELKOD5] nvarchar(51),CARIBAKIYE FLOAT,STOKOZELKOD NVARCHAR(25),STOKOZELKOD2 NVARCHAR(25),STOKOZELKOD3 NVARCHAR(25),STOKOZELKOD4 NVARCHAR(25),STOKOZELKOD5 NVARCHAR(25),
MIKTAR FLOAT ,BIRIMSATISFIYATI FLOAT,KDVHARICNETTUTARI FLOAT,KDVTUTARI FLOAT, KDVDAHILNETTUTARI FLOAT,[FISTIPI] nvarchar(55),HAREKETSONALISFIYATI FLOAT, HAREKETSONALISTARIHI DATETIME,ENSONALISFIYATI FLOAT, ENSONALISTARIHI DATETIME,
KARFIYATI FLOAT, KARYUZDE FLOAT,KARTUTARI FLOAT, AMBAR NVARCHAR(51),BOLUM NVARCHAR(51),STOKBAKIYESI FLOAT, MARKA NVARCHAR(51) ,TRCODE SMALLINT
 );
WITH LISTE AS(
SELECT ST.FTIME, ST.LOGICALREF[STLOG],SLSMN.DEFINITION_[SATISELEMANI], ST.STOCKREF [STOCKREF], ST.DATE_ [IRSALIYETARIHI],ST.SOURCEINDEX,
CASE WHEN ST.BILLED=1 THEN INV.DATE_ ELSE NULL END AS [FATURATARIHI], INV.FICHENO [FATURANO],CASE WHEN ST.BILLED=0 THEN 'İrsaliye' WHEN ST.BILLED=1 THEN 'Fatura' ELSE '' END AS [FISTURU],
IT.CODE [STOKKODU] ,IT.NAME [STOKADI],ST.CLIENTREF [CARILOG], IT.SPECODE [STOKOZELKOD], IT.SPECODE2 [STOKOZELKOD2],IT.SPECODE3 [STOKOZELKOD3],IT.SPECODE4 [STOKOZELKOD4],IT.SPECODE5 [STOKOZELKOD5],
case when ST.TRCODE IN(2,3) THEN ST.AMOUNT*-1 ELSE ST.AMOUNT END AS [MIKTAR], (ISNULL((ST.VATMATRAH+ST.DIFFPRICE),0)/NULLIF(ISNULL(ST.AMOUNT,1),0))[BIRIMSATISFIYATI],
(ST.VATMATRAH)[KDVHARICNETTUTARI],
ST.VATAMNT KDVTUTARI,
(ST.VATMATRAH+ST.VATAMNT)
KDVDAHILNETTUTARI,
	CASE WHEN ST.BILLED=1 THEN CASE  
WHEN INV.TRCODE =2 THEN '(02)Perakende Satış İade Faturası'
WHEN INV.TRCODE =3 THEN '(03)Toptan Satış İade Faturası' 
WHEN INV.TRCODE=7 THEN '(07)Perakende Satış Faturası'
WHEN INV.TRCODE=8 THEN '(08)Toptan Satış Faturası'
WHEN INV.TRCODE=9 THEN '(09)Verilen Hizmet Faturası'
WHEN INV.TRCODE=10 THEN '(10)Verilen Proforma Fatura'
WHEN INV.TRCODE=14 THEN '(14)Verilen Fiyat Farkı Faturası'
ELSE '' END
ELSE 
CASE WHEN ST.TRCODE =2  THEN '(02)Perakende Satış İade İrsaliyesi'
WHEN ST.TRCODE =3  THEN '(03)Toptan Satış İade İrsaliyesi'
WHEN ST.TRCODE=7 THEN '(07)Perakende Satış İrsaliyesi'
WHEN ST.TRCODE=8 THEN '(08)Toptan Satış İrsaliyesi'
WHEN ST.TRCODE=9 THEN '(09)Konsinye Çıkış İrsaliyesi'
ELSE '' END END 
AS  FISTIPI,
ST.VATMATRAH,ST.DIFFPRICE,ST.AMOUNT,ST.UINFO1,ST.UINFO2, CASE WHEN INV.EINVOICE = 0 THEN 'Kağıt Fatura' WHEN INV.EINVOICE = 1 THEN 'E-Fatura' WHEN INV.EINVOICE = 2 THEN 'E-Arşiv'  WHEN INV.EINVOICE = 3 THEN 'E-Arşiv İnternet' ELSE '' END AS [FATURATIPI], 
WH.NAME AS [AMBAR], DEPT.NAME AS BOLUM, ISNULL((select sum(ONHAND) from LV_{Convert.ToInt32(frmano).ToString("000")}_{donem}_STINVTOT WHERE  STOCKREF = IT.LOGICALREF  AND INVENNO IN(0)),0) STOKBAKIYESI,M.DESCR MARKA ,ST.TRCODE
from LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_STLINE ST
LEFT OUTER JOIN LG_SLSMAN SLSMN ON ST.SALESMANREF=SLSMN.LOGICALREF AND SLSMN.FIRMNR={Convert.ToInt32(frmano)}
LEFT OUTER JOIN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_STFICHE STFICHE on ST.STFICHEREF=STFICHE.LOGICALREF AND STFICHE.CANCELLED=0 
LEFT OUTER JOIN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_INVOICE INV on ST.INVOICEREF=INV.LOGICALREF AND INV.CANCELLED=0 
LEFT OUTER JOIN LG_{Convert.ToInt32(frmano).ToString("000")}_ITEMS IT ON ST.STOCKREF=IT.LOGICALREF
LEFT OUTER JOIN LG_{Convert.ToInt32(frmano).ToString("000")}_MARK M ON M.LOGICALREF=IT.MARKREF
LEFT OUTER JOIN  L_CAPIWHOUSE WH ON ST.SOURCEINDEX=WH.NR AND WH.FIRMNR={Convert.ToInt32(frmano)}
LEFT OUTER JOIN  L_CAPIDEPT DEPT ON STFICHE.DEPARTMENT=DEPT.NR AND DEPT.FIRMNR={Convert.ToInt32(frmano)}
where  ((ST.TRCODE IN (2,3,7,8,9,10)) OR (ST.BILLED=1 AND ST.TRCODE=14) )
and ST.LINETYPE=0 {bolumfiltresi} and ST.CANCELLED=0 AND ST.DATE_ between '{ilkt}' and '{sont}'  and ST.SOURCEINDEX IN({ambar})   {stokfiltesi}  {caribilgisi}
),

LIST AS (
SELECT LISTE.FTIME, LISTE.STLOG,
LISTE.SATISELEMANI,LISTE.STOCKREF,LISTE.IRSALIYETARIHI,LISTE.FATURATARIHI,LISTE.FATURATIPI,LISTE.FATURANO,LISTE.FISTURU,LISTE.STOKKODU,LISTE.STOKADI,LISTE.CARILOG,
 CARIBILGILERI.CARIKODU,CARIBILGILERI.CARIUNVANI,CARIBILGILERI.CARIOZELKOD,
CARIBILGILERI.CARIOZELKOD2,CARIBILGILERI.CARIOZELKOD3,CARIBILGILERI.CARIOZELKOD4,CARIBILGILERI.CARIOZELKOD5,
ISNULL(CARIBILGILERI.CARIBAKIYE,0)CARIBAKIYE,
LISTE.STOKOZELKOD,LISTE.STOKOZELKOD2,LISTE.STOKOZELKOD3,
LISTE.STOKOZELKOD4,LISTE.STOKOZELKOD5,LISTE.MIKTAR,LISTE.BIRIMSATISFIYATI,LISTE.KDVHARICNETTUTARI,LISTE.KDVTUTARI,LISTE.KDVDAHILNETTUTARI,LISTE.FISTIPI,
ISNULL({outcostfiyatalani},0) HAREKETSONALISFIYATI,{maliyettarihyeri} HAREKETSONALISTARIHI,
ISNULL(ENSONALISFIYATTARIH.FIYAT,0) [ENSONALISFIYATI],ENSONALISFIYATTARIH.TARIH [ENSONALISTARIHI],


CAST(CAST(ISNULL((ISNULL((LISTE.VATMATRAH+LISTE.DIFFPRICE),0)/NULLIF(ISNULL(LISTE.AMOUNT,1),0))-({filtre}),0) AS DECIMAL (18,2)) AS FLOAT)[KARFIYATI],

CAST(CAST(CASE WHEN ({filtre})=0 THEN 100 
WHEN ({filtre})=0 AND (ISNULL((LISTE.VATMATRAH+LISTE.DIFFPRICE),0)/NULLIF(LISTE.AMOUNT,0))=0 THEN 0 ELSE ((((ISNULL((LISTE.VATMATRAH+LISTE.DIFFPRICE),0)/
NULLIF(LISTE.AMOUNT,0))-(ISNULL(({filtre}),0)))*100)/NULLIF(ISNULL(({filtre}),0),0))
END AS DECIMAL (18,2)) AS FLOAT)  AS [KARYUZDE],

CAST(CAST((ISNULL((ISNULL((LISTE.VATMATRAH+LISTE.DIFFPRICE),0)/NULLIF(ISNULL(LISTE.AMOUNT,1),0))-({filtre}),0)*LISTE.AMOUNT) AS DECIMAL (18,2)) AS FLOAT)[KARTUTARI],

LISTE.AMBAR,LISTE.BOLUM,LISTE.STOKBAKIYESI,LISTE.MARKA  ,LISTE.TRCODE
FROM LISTE 

OUTER APPLY(
 select top 1 NULLIF(ISNULL(((((ST1.VATMATRAH +ST1.DIFFPRICE) / NULLIF(ISNULL(ST1.AMOUNT,1),0)) / NULLIF((ISNULL(ST1.UINFO2,1)/NULLIF(ISNULL(ST1.UINFO1,1),0)),0))),0),0) FIYAT, DATE_ TARIH ,ST1.OUTCOST
 from LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_STLINE ST1 where ST1.STOCKREF=LISTE.STOCKREF AND ST1.VATMATRAH<>0 AND ST1.SOURCELINK =0
 and ST1.TRCODE IN({outcostuntrkodfiltresi}) AND ST1.CANCELLED = 0 AND ST1.LINETYPE = 0 {ambarfiltre}  and ST1.DATE_ <= LISTE.IRSALIYETARIHI order by ST1.DATE_ desc,ST1.FTIME desc
)SONALISFIYATTARIH
OUTER APPLY(			
 SELECT C1.CODE [CARIKODU] ,C1.DEFINITION_[CARIUNVANI],C1.SPECODE[CARIOZELKOD],C1.SPECODE2[CARIOZELKOD2],C1.SPECODE3[CARIOZELKOD3],
 C1.SPECODE4[CARIOZELKOD4],C1.SPECODE5[CARIOZELKOD5], (SELECT SUM(DEBIT)-SUM(CREDIT) FROM LV_{Convert.ToInt32(frmano).ToString("000")}_{donem}_GNTOTCL WHERE CARDREF=LISTE.CARILOG AND TOTTYP=1) AS CARIBAKIYE
 FROM LG_{Convert.ToInt32(frmano).ToString("000")}_CLCARD C1  WHERE C1.LOGICALREF=LISTE.CARILOG and C1.CARDTYPE<>22 ) CARIBILGILERI
OUTER APPLY
(select top 1 NULLIF(ISNULL(((((ST1.VATMATRAH +ST1.DIFFPRICE) / NULLIF(ISNULL(ST1.AMOUNT,1),0)) / NULLIF((ISNULL(ST1.UINFO2,1)/NULLIF(ISNULL(ST1.UINFO1,1),0)),0))),0),0) FIYAT, DATE_ TARIH ,ST1.OUTCOST 
 from LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_STLINE ST1 where ST1.STOCKREF=LISTE.STOCKREF AND ST1.VATMATRAH<>0 AND ST1.SOURCELINK =0
 and ST1.TRCODE IN({trkodfiltresi}) AND ST1.CANCELLED = 0 AND ST1.LINETYPE = 0  {ambarfiltre}  order by ST1.DATE_ desc,ST1.FTIME desc
)ENSONALISFIYATTARIH
 ) 
INSERT INTO #tmpsatiskarzarar  SELECT FTIME, [STLOG] ,SATISELEMANI , [STOCKREF] ,IRSALIYETARIHI ,FATURATARIHI,FATURATIPI , 
[FATURANO],[FISTURU] ,[STOKKODU] ,[STOKADI] ,CARILOG ,[CARIKODU] ,[CARIUNVANI],[CARIOZELKOD] ,[CARIOZELKOD2] ,[CARIOZELKOD3] ,
[CARIOZELKOD4] ,[CARIOZELKOD5] ,CARIBAKIYE ,STOKOZELKOD ,STOKOZELKOD2 ,STOKOZELKOD3 ,STOKOZELKOD4 ,STOKOZELKOD5,
MIKTAR  ,BIRIMSATISFIYATI ,KDVHARICNETTUTARI ,KDVTUTARI,KDVDAHILNETTUTARI,FISTIPI,HAREKETSONALISFIYATI , HAREKETSONALISTARIHI ,ENSONALISFIYATI , ENSONALISTARIHI ,
KARFIYATI , KARYUZDE ,KARTUTARI , AMBAR ,BOLUM,STOKBAKIYESI , MARKA, TRCODE   FROM LIST ;

create clustered index idx_tmpsatiskarzarar ON #tmpsatiskarzarar ([STLOG]);
select FTIME, [STLOG] ,SATISELEMANI , [STOCKREF] ,IRSALIYETARIHI ,FATURATARIHI,FATURATIPI , 
[FATURANO],[FISTURU] ,[STOKKODU] ,[STOKADI] ,CARILOG ,[CARIKODU] ,[CARIUNVANI],[CARIOZELKOD] ,[CARIOZELKOD2] ,[CARIOZELKOD3] ,
[CARIOZELKOD4] ,[CARIOZELKOD5] ,CARIBAKIYE ,STOKOZELKOD ,STOKOZELKOD2 ,STOKOZELKOD3 ,STOKOZELKOD4 ,STOKOZELKOD5,
MIKTAR  ,BIRIMSATISFIYATI ,KDVHARICNETTUTARI ,KDVTUTARI,KDVDAHILNETTUTARI,FISTIPI,HAREKETSONALISFIYATI , HAREKETSONALISTARIHI ,ENSONALISFIYATI , ENSONALISTARIHI ,
CASE WHEN TRCODE IN(2,3)THEN KARFIYATI*-1 ELSE KARFIYATI END AS KARFIYATI,
CASE WHEN TRCODE IN(2,3)THEN KARYUZDE*-1 ELSE KARYUZDE END AS KARYUZDE,
CASE WHEN TRCODE IN(2,3)THEN KARTUTARI*-1 ELSE KARTUTARI END AS KARTUTARI,
 AMBAR ,BOLUM,STOKBAKIYESI , MARKA ,CAST(0 AS INT) KARHESAPLAMASONALISLOGICALREF from #tmpsatiskarzarar WHERE NOT EXISTS
(SELECT 1 FROM LOGO_XERO_KAR_ZARAR_ONAY_{frmano}_{donem} O WHERE O.LOGICALREF=STLOG)
ORDER BY IRSALIYETARIHI DESC,FTIME DESC
";
                List<LOGO_XERO_KAR_ZARAR_ANALIZ> data = db.Database.SqlQuery<LOGO_XERO_KAR_ZARAR_ANALIZ>(sorgu).ToList();
                data.ForEach(s => { s.HAREKETONCESISONALISCARPMIKTAR = Convert.ToDouble(s.HAREKETSONALISFIYATI) * Convert.ToDouble(s.MIKTAR); s.ENSONALISCARPMIKTAR = Convert.ToDouble(s.ENSONALISFIYATI) * Convert.ToDouble(s.MIKTAR); });
                return data;
            }
         
        }
        public List<LOGO_XERO_KAR_ZARAR_ANALIZ> AlisKarZararAnaliz(string frmano, string donem, string ilkt, string sont, string ambar, string stokfiltresi, string filtre, string ambarfiltre, string trkodfiltresi, string caribilgisi, string sonalisLogicalrefAlani,string secilenbolum)
        {
            string bolumfiltresi = "";
            if (!string.IsNullOrWhiteSpace(secilenbolum))
            {
                bolumfiltresi = $@" AND STFICHE.DEPARTMENT IN({secilenbolum})";
            }
            using (LogoContext db = new LogoContext())
            {
                string sorgu = $@"if (object_id('tempdb..#tmpaliskarzarar') is not null) begin drop table #tmpaliskarzarar end;
create table #tmpaliskarzarar ( FTIME INT,[STLOG] int,SATISELEMANI nvarchar(51), [STOCKREF] INT,IRSALIYETARIHI DATETIME,FATURATARIHI DATETIME,FATURATIPI NVARCHAR(50), 
[FATURANO] nvarchar(55),[FISTURU] nvarchar(55),[STOKKODU] nvarchar(25),[STOKADI] nvarchar(51),CARILOG INT,[CARIKODU] nvarchar(51),[CARIUNVANI] nvarchar(250),[CARIOZELKOD] nvarchar(51),
[CARIOZELKOD2] nvarchar(51),[CARIOZELKOD3] nvarchar(51),
[CARIOZELKOD4] nvarchar(51),[CARIOZELKOD5] nvarchar(51),CARIBAKIYE FLOAT,STOKOZELKOD NVARCHAR(25),STOKOZELKOD2 NVARCHAR(25),STOKOZELKOD3 NVARCHAR(25),STOKOZELKOD4 NVARCHAR(25),STOKOZELKOD5 NVARCHAR(25),
MIKTAR FLOAT ,BIRIMSATISFIYATI FLOAT,NETTUTARI FLOAT,HAREKETSONALISFIYATI FLOAT, HAREKETSONALISTARIHI DATETIME,ENSONALISFIYATI FLOAT, ENSONALISTARIHI DATETIME,
KARFIYATI FLOAT, KARYUZDE FLOAT,KARTUTARI FLOAT, AMBAR NVARCHAR(51),BOLUM NVARCHAR(51),STOKBAKIYESI FLOAT, MARKA NVARCHAR(51),KARHESAPLAMASONALISLOGICALREF INT
 );
WITH LISTE AS(
SELECT ST.FTIME, ST.LOGICALREF[STLOG],SLSMN.DEFINITION_[SATISELEMANI], ST.STOCKREF [STOCKREF], ST.DATE_ [IRSALIYETARIHI],ST.SOURCEINDEX,
CASE WHEN ST.BILLED=1 THEN INV.DATE_ ELSE NULL END AS [FATURATARIHI], INV.FICHENO [FATURANO],CASE WHEN ST.BILLED=0 THEN 'İrsaliye' WHEN ST.BILLED=1 THEN 'Fatura' ELSE '' END AS [FISTURU],
IT.CODE [STOKKODU] ,IT.NAME [STOKADI],ST.CLIENTREF [CARILOG], IT.SPECODE [STOKOZELKOD], IT.SPECODE2 [STOKOZELKOD2],IT.SPECODE3 [STOKOZELKOD3],IT.SPECODE4 [STOKOZELKOD4],IT.SPECODE5 [STOKOZELKOD5],
ST.AMOUNT [MIKTAR], (ISNULL((ST.VATMATRAH+ST.DIFFPRICE),0)/NULLIF(ISNULL(ST.AMOUNT,1),0))[BIRIMSATISFIYATI],(ST.VATMATRAH+ST.DIFFPRICE)[NETTUTARI],
ST.VATMATRAH,ST.DIFFPRICE,ST.AMOUNT,ST.UINFO1,ST.UINFO2, CASE WHEN INV.EINVOICE = 0 THEN 'Kağıt Fatura' WHEN INV.EINVOICE = 1 THEN 'E-Fatura' WHEN INV.EINVOICE = 2 THEN 'E-Arşiv'  WHEN INV.EINVOICE = 3 THEN 'E-Arşiv İnternet' ELSE '' END AS [FATURATIPI], 
WH.NAME AS [AMBAR],DEPT.NAME AS [BOLUM], ISNULL((select sum(ONHAND) from LV_{Convert.ToInt32(frmano).ToString("000")}_{donem}_STINVTOT WHERE  STOCKREF = IT.LOGICALREF  AND INVENNO IN(0)),0) STOKBAKIYESI,M.DESCR MARKA
from LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_STLINE ST
LEFT OUTER JOIN LG_SLSMAN SLSMN ON ST.SALESMANREF=SLSMN.LOGICALREF AND SLSMN.FIRMNR={Convert.ToInt32(frmano)}
LEFT OUTER JOIN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_INVOICE INV on ST.INVOICEREF=INV.LOGICALREF AND INV.CANCELLED=0 
LEFT OUTER JOIN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_STFICHE STF on ST.STFICHEREF=STF.LOGICALREF AND STF.CANCELLED=0 
LEFT OUTER JOIN LG_{Convert.ToInt32(frmano).ToString("000")}_ITEMS IT ON ST.STOCKREF=IT.LOGICALREF
LEFT OUTER JOIN LG_{Convert.ToInt32(frmano).ToString("000")}_MARK M ON M.LOGICALREF=IT.MARKREF
LEFT OUTER JOIN  L_CAPIWHOUSE WH ON ST.SOURCEINDEX=WH.NR AND WH.FIRMNR={Convert.ToInt32(frmano)}
LEFT OUTER JOIN  L_CAPIDEPT DEPT ON STF.DEPARTMENT=DEPT.NR AND DEPT.FIRMNR={Convert.ToInt32(frmano)}
where  ST.TRCODE IN (1) AND ST.CANCELLED=0
and ST.LINETYPE=0 {bolumfiltresi} AND ST.DATE_ between '{ilkt}' and '{sont}'  and ST.SOURCEINDEX IN({ambar}) {stokfiltresi}  {caribilgisi}
),

LIST AS (
SELECT LISTE.FTIME, LISTE.STLOG,
LISTE.SATISELEMANI,LISTE.STOCKREF,LISTE.IRSALIYETARIHI,LISTE.FATURATARIHI,LISTE.FATURATIPI,LISTE.FATURANO,LISTE.FISTURU,LISTE.STOKKODU,LISTE.STOKADI,LISTE.CARILOG,
 CARIBILGILERI.CARIKODU,CARIBILGILERI.CARIUNVANI,CARIBILGILERI.CARIOZELKOD,
CARIBILGILERI.CARIOZELKOD2,CARIBILGILERI.CARIOZELKOD3,CARIBILGILERI.CARIOZELKOD4,CARIBILGILERI.CARIOZELKOD5,
ISNULL(CARIBILGILERI.CARIBAKIYE,0)CARIBAKIYE,
LISTE.STOKOZELKOD,LISTE.STOKOZELKOD2,LISTE.STOKOZELKOD3,
LISTE.STOKOZELKOD4,LISTE.STOKOZELKOD5,LISTE.MIKTAR,LISTE.BIRIMSATISFIYATI,LISTE.NETTUTARI,
SONALISFIYATTARIH.FIYAT HAREKETSONALISFIYATI,SONALISFIYATTARIH.TARIH HAREKETSONALISTARIHI,
ENSONALISFIYATTARIH.FIYAT [ENSONALISFIYATI],ENSONALISFIYATTARIH.TARIH [ENSONALISTARIHI],


CAST(CAST(ISNULL((ISNULL((LISTE.VATMATRAH+LISTE.DIFFPRICE),0)/NULLIF(ISNULL(LISTE.AMOUNT,1),0))-({filtre}),0) AS DECIMAL (18,2)) AS FLOAT)[KARFIYATI],

CAST(CAST(CASE WHEN ({filtre})=0 THEN 100 
WHEN ({filtre})=0 AND (ISNULL((LISTE.VATMATRAH+LISTE.DIFFPRICE),0)/NULLIF(LISTE.AMOUNT,0))=0 THEN 0 ELSE ((((ISNULL((LISTE.VATMATRAH+LISTE.DIFFPRICE),0)/
NULLIF(LISTE.AMOUNT,0))-(ISNULL(({filtre}),0)))*100)/NULLIF(ISNULL(({filtre}),0),0))
END AS DECIMAL (18,2)) AS FLOAT)*-1  AS [KARYUZDE],

CAST(CAST((ISNULL((ISNULL((LISTE.VATMATRAH+LISTE.DIFFPRICE),0)/NULLIF(ISNULL(LISTE.AMOUNT,1),0))-({filtre}),0)*LISTE.AMOUNT) AS DECIMAL (18,2)) AS FLOAT)[KARTUTARI],

LISTE.AMBAR,LISTE.BOLUM,LISTE.STOKBAKIYESI,LISTE.MARKA , {sonalisLogicalrefAlani} KARHESAPLAMASONALISLOGICALREF
FROM LISTE 

OUTER APPLY(
 select top 1 ((((ST1.VATMATRAH +ST1.DIFFPRICE) / NULLIF(ISNULL(ST1.AMOUNT,1),0)) / NULLIF((ISNULL(ST1.UINFO2,1)/NULLIF(ISNULL(ST1.UINFO1,1),0)),0))) FIYAT, DATE_ TARIH ,ST1.OUTCOST,ST1.LOGICALREF KARHESAPLAMASONALISLOGICALREF  
 from LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_STLINE ST1 where ST1.STOCKREF=LISTE.STOCKREF AND ST1.VATMATRAH<>0 AND ST1.SOURCELINK =0
 and ST1.TRCODE IN({trkodfiltresi}) AND ST1.CANCELLED = 0 AND ST1.LINETYPE = 0 {ambarfiltre}  and ((ST1.DATE_= LISTE.IRSALIYETARIHI AND ST1.FTIME< LISTE.FTIME) OR (ST1.DATE_< LISTE.IRSALIYETARIHI)) AND ST1.LOGICALREF<>LISTE.STLOG order by ST1.DATE_ desc,ST1.FTIME desc
)SONALISFIYATTARIH
OUTER APPLY(			
 SELECT C1.CODE [CARIKODU] ,C1.DEFINITION_[CARIUNVANI],C1.SPECODE[CARIOZELKOD],C1.SPECODE2[CARIOZELKOD2],C1.SPECODE3[CARIOZELKOD3],
 C1.SPECODE4[CARIOZELKOD4],C1.SPECODE5[CARIOZELKOD5], (SELECT SUM(DEBIT)-SUM(CREDIT) FROM LV_{Convert.ToInt32(frmano).ToString("000")}_{donem}_GNTOTCL WHERE CARDREF=LISTE.CARILOG AND TOTTYP=1) AS CARIBAKIYE
 FROM LG_{Convert.ToInt32(frmano).ToString("000")}_CLCARD C1  WHERE C1.LOGICALREF=LISTE.CARILOG and C1.CARDTYPE<>22 
) CARIBILGILERI
OUTER APPLY
(select top 1 ((((ST1.VATMATRAH +ST1.DIFFPRICE) / NULLIF(ISNULL(ST1.AMOUNT,1),0)) / NULLIF((ISNULL(ST1.UINFO2,1)/NULLIF(ISNULL(ST1.UINFO1,1),0)),0))) FIYAT, DATE_ TARIH ,ST1.OUTCOST  ,ST1.LOGICALREF KARHESAPLAMASONALISLOGICALREF 
 from LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_STLINE ST1 where ST1.STOCKREF=LISTE.STOCKREF AND ST1.VATMATRAH<>0 AND ST1.SOURCELINK =0
 and ST1.TRCODE IN({trkodfiltresi}) AND ST1.CANCELLED = 0 AND ST1.LINETYPE = 0  {ambarfiltre}  order by ST1.DATE_ desc,ST1.FTIME desc
)ENSONALISFIYATTARIH
 ) 
INSERT INTO #tmpaliskarzarar  SELECT FTIME, [STLOG] ,SATISELEMANI , [STOCKREF] ,IRSALIYETARIHI ,FATURATARIHI,FATURATIPI , 
[FATURANO],[FISTURU] ,[STOKKODU] ,[STOKADI] ,CARILOG ,[CARIKODU] ,[CARIUNVANI],[CARIOZELKOD] ,[CARIOZELKOD2] ,[CARIOZELKOD3] ,
[CARIOZELKOD4] ,[CARIOZELKOD5] ,CARIBAKIYE ,STOKOZELKOD ,STOKOZELKOD2 ,STOKOZELKOD3 ,STOKOZELKOD4 ,STOKOZELKOD5,
MIKTAR  ,BIRIMSATISFIYATI ,NETTUTARI ,HAREKETSONALISFIYATI , HAREKETSONALISTARIHI ,ENSONALISFIYATI , ENSONALISTARIHI ,
KARFIYATI , KARYUZDE ,KARTUTARI , AMBAR ,BOLUM,STOKBAKIYESI , MARKA ,KARHESAPLAMASONALISLOGICALREF  FROM LIST ;

create clustered index idx_tmpaliskarzarar ON #tmpaliskarzarar ([STLOG]);
select * from #tmpaliskarzarar WHERE NOT EXISTS
(SELECT 1 FROM LOGO_XERO_KAR_ZARAR_ONAY_{frmano}_{donem} O WHERE O.LOGICALREF=STLOG)
ORDER BY IRSALIYETARIHI DESC,FTIME DESC
";
                List<LOGO_XERO_KAR_ZARAR_ANALIZ> data = db.Database.SqlQuery<LOGO_XERO_KAR_ZARAR_ANALIZ>(sorgu).ToList();
                data.ForEach(s => { s.HAREKETONCESISONALISCARPMIKTAR = Convert.ToDouble(s.HAREKETSONALISFIYATI) * Convert.ToDouble(s.MIKTAR); s.ENSONALISCARPMIKTAR = Convert.ToDouble(s.ENSONALISFIYATI) * Convert.ToDouble(s.MIKTAR); });
                return data;
            } 
        }
        public List<LOGO_XERO_CARILISTE> CariGetir(  string firma, string donem)
        {
            using (LogoContext db = new LogoContext())
            {
                string sql = $@"WITH CARILISTE AS (
SELECT C.LOGICALREF,C.CODE,DEFINITION_ ,C.SPECODE OZELKOD1,C.SPECODE2 OZELKOD2,C.SPECODE3 OZELKOD3,C.SPECODE4 OZELKOD4,C.SPECODE5 OZELKOD5,C.NAME ADI, C.SURNAME SOYADI,
C.ADDR1 as [ADRES1],C.ADDR2 as [ADRES2],C.TRADINGGRP TICARIISLEMGURUBU, C.TELNRS1 as [TELEFON1], C.TELNRS2 as [TELEFON2],C.COUNTRY ULKE, C.COUNTRYCODE ULKEKODU, C.CITY [SEHIR],C.TOWN ILCE, C.TAXOFFICE VERGIDAIRESI, C.CARDTYPE,
C.TCKNO, C.FAXNR, C.POSTCODE POSTAKODU, C.TAXNR,C.INCHARGE [YETKILISI], C.CYPHCODE YETKIKODU, ISNULL(C.ACCEPTEINV,0) EFATURA, C.EMAILADDR EPOSTA,
C.EMAILADDR2 EPOSTA2, C.EMAILADDR3 EPOSTA3 ,C.ISPERSCOMP SAHISSIRKETI,C.PAYMENTREF,
CAST(CAST(ISNULL((SELECT SUM(DEBIT)-SUM(CREDIT) FROM LV_{firma}_{donem}_GNTOTCL WITH (NOLOCK) WHERE CARDREF=C.LOGICALREF AND TOTTYP=1),0)AS decimal(18,3))AS float) AS [BAKIYE]
FROM LG_{firma}_CLCARD C WHERE C.ACTIVE=0 AND C.CARDTYPE<>22 )
SELECT * FROM CARILISTE
OUTER APPLY(SELECT TOP 1 EM.CODE MUHASEBEKODU FROM LG_{firma}_CRDACREF C WITH (NOLOCK)
LEFT OUTER JOIN LG_{firma}_EMUHACC EM WITH (NOLOCK) ON C.ACCOUNTREF=EM.LOGICALREF
WHERE C.CARDREF=CARILISTE.LOGICALREF AND C.TRCODE=5)MUSAHEBEBILGILERI
OUTER APPLY(SELECT TOP 1 CODE ODEMEPLANKODU,DEFINITION_ ODEMEPLANI FROM LG_{firma}_PAYPLANS P WITH (NOLOCK)
WHERE P.LOGICALREF=CARILISTE.PAYMENTREF)ODEMEBILGILERI  ";

                List<LOGO_XERO_CARILISTE> liste = db.Database.SqlQuery<LOGO_XERO_CARILISTE>(sql).ToList();
                return liste;
            }
        }
        public List<STRINGDEGER> MarkaGetir(string firma)
        {
            using (LogoContext db = new LogoContext())
            {

                string sql = $@"select LOGICALREF LOGICALREF,CODE DEGER,DESCR DEGER2 from LG_{firma}_MARK WHERE DESCR<>'' ORDER BY CODE";
                return db.Database.SqlQuery<STRINGDEGER>(sql).ToList();
            }
        }
        public void seciliiyenirenkguncelle(int ID, string baslangicoran, string renk, string bitisoran,int tip)
        {
            LogoContext db = new LogoContext();
            {
                var secilirenk = db.LOGO_XERO_KAR_ZARAR_RENK.FirstOrDefault(s => s.ID == ID);
                secilirenk.YUZDEBASLANGIC = baslangicoran;
                secilirenk.YUZDEBITIS = bitisoran;
                secilirenk.RENK = renk;
                secilirenk.TIP = tip;
                db.Entry(secilirenk).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void yenirenkekle(string yuzdebaslangic, string renk, string yuzdebitis,int tip)
        {
            //TİP = 1 - SATIŞ // TİP = 2 - ALIŞ
            using (LogoContext db1 = new LogoContext())
            {
                LOGO_XERO_KAR_ZARAR_RENK yenirenk = new LOGO_XERO_KAR_ZARAR_RENK();
                yenirenk.YUZDEBASLANGIC = yuzdebaslangic;
                yenirenk.YUZDEBITIS = yuzdebitis;
                yenirenk.RENK = renk;
                yenirenk.TIP = tip;
                db1.LOGO_XERO_KAR_ZARAR_RENK.Add(yenirenk);
                db1.SaveChanges();
            }


        }
        public LOGO_XERO_KAR_ZARAR_RENK secilirenkGetirYeni(int ID)

        {
            LogoContext db = new LogoContext();
            {
                return db.LOGO_XERO_KAR_ZARAR_RENK.FirstOrDefault(s => s.ID == ID);
            }
        }
        public void secilirenksilyeni(int ID)
        {
            LogoContext db = new LogoContext();
            {
                LOGO_XERO_KAR_ZARAR_RENK secilirenk = db.LOGO_XERO_KAR_ZARAR_RENK.FirstOrDefault(s => s.ID == ID);
                db.LOGO_XERO_KAR_ZARAR_RENK.Remove(secilirenk);
                db.SaveChanges();
            }
        }
        
        public List<LOGO_XERO_KASA_HAREKET> KasaHareketGetir(string frmano, string donem, string ilkt, string sont, string kasaAdi, string isyeri)
        {
            using (LogoContext db = new LogoContext())
            {
                string sorgu = $@"; with cte as(SELECT 0 LOGICALREF , 
            KSCARD.CODE ,
            KSCARD.NAME AS [KasaAdi],
            '' AS [Tarih],
            'DEVİR' AS [IslemTuru],
            '' AS [FisNo],
            '{ilkt} Tarihinden Devir' AS [KasaAciklamasi],
            '' AS [SatirAciklamasi],
            CASE WHEN  KSLINES.TRCURR IN(0,160) THEN 'TL' ELSE (SELECT TOP 1  K.CURCODE FROM L_CURRENCYLIST K WHERE K.CURTYPE=KSLINES.TRCURR) END [DovizTuru],
			CASE WHEN (SUM(CASE WHEN KSLINES.SIGN = 0 THEN KSLINES.AMOUNT ELSE 0 END)-SUM(CASE WHEN KSLINES.SIGN = 1 THEN KSLINES.AMOUNT ELSE 0 END))>0 THEN SUM(CASE WHEN KSLINES.SIGN = 0 THEN KSLINES.AMOUNT ELSE 0 END)-SUM(CASE WHEN KSLINES.SIGN = 1 THEN KSLINES.AMOUNT ELSE 0 END) ELSE 0 END Borc,
			CASE WHEN (SUM(CASE WHEN KSLINES.SIGN = 0 THEN KSLINES.AMOUNT ELSE 0 END)-SUM(CASE WHEN KSLINES.SIGN = 1 THEN KSLINES.AMOUNT ELSE 0 END))<0 THEN SUM(CASE WHEN KSLINES.SIGN = 0 THEN KSLINES.AMOUNT ELSE 0 END)-SUM(CASE WHEN KSLINES.SIGN = 1 THEN KSLINES.AMOUNT ELSE 0 END) ELSE 0 END Alacak,
            ISNULL(SUM(CASE WHEN KSLINES.SIGN = 0 THEN KSLINES.AMOUNT ELSE 0 END),0) - ISNULL(SUM(CASE WHEN KSLINES.SIGN = 1 THEN KSLINES.AMOUNT ELSE 0 END),0) Bakiye
            FROM LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_KSLINES KSLINES 
            LEFT OUTER JOIN LG_{Convert.ToInt32(frmano).ToString("000")}_KSCARD KSCARD ON KSLINES.CARDREF = KSCARD.LOGICALREF
            WHERE KSLINES.CANCELLED=0 
            AND KSCARD.CODE IN({kasaAdi})
            AND KSLINES.DATE_ < '{ilkt}'   
            AND KSLINES.BRANCH IN ({isyeri})
			GROUP BY KSCARD.CODE,KSCARD.NAME,KSLINES.TRCURR
            UNION
           SELECT KSLINES.LOGICALREF,
            KSCARD.CODE ,
            KSCARD.NAME AS [KasaAdi],
            KSLINES.DATE_ AS [Tarih],
            --CAST(KSLINES.HOUR_ AS varchar) + ':'+ CAST(KSLINES.MINUTE_ AS varchar) Saat,
            --KSLINES.HOUR_ AS Saat,
            --KSLINES.MINUTE_ AS Dakika,
            CASE
            WHEN KSLINES.TRCODE = 11 THEN 'Ch Tahsilat'
            WHEN KSLINES.TRCODE = 12 THEN 'Ch Ödeme'
            WHEN KSLINES.TRCODE = 21 THEN 'Bankaya Yatırılan'
            WHEN KSLINES.TRCODE = 22 THEN 'Bankadan Çekilen'
            WHEN KSLINES.TRCODE = 31 THEN 'Satınalma Faturası'
            WHEN KSLINES.TRCODE = 32 THEN 'Perakende Satış İade Fatura'
            WHEN KSLINES.TRCODE = 33 THEN 'Toptan Satış İade Fatura'
            WHEN KSLINES.TRCODE = 34 THEN 'Alınan Hizmet Faturası'
            WHEN KSLINES.TRCODE = 35 THEN 'Satınalma İade Faturası'
            WHEN KSLINES.TRCODE = 36 THEN 'Perakende Satış Faturası'
            WHEN KSLINES.TRCODE = 37 THEN 'Toptan Satış Faturası'
            WHEN KSLINES.TRCODE = 38 THEN 'Verilen Hizmet Faturası'
            WHEN KSLINES.TRCODE = 39 THEN 'Mistahsil Makbuz'
            WHEN KSLINES.TRCODE = 41 THEN 'Muhasebe (Tahsil)'
            WHEN KSLINES.TRCODE = 42 THEN 'Muhasebe (Tediye)'
            WHEN KSLINES.TRCODE = 51 THEN 'Personel Borçlanması'
            WHEN KSLINES.TRCODE = 52 THEN 'Personel Geri Ödemesi'
            WHEN KSLINES.TRCODE = 61 THEN 'Çek Tahsili'
            WHEN KSLINES.TRCODE = 62 THEN 'Senet Tahsili'
            WHEN KSLINES.TRCODE = 63 THEN 'Çek Ödemesi'
            WHEN KSLINES.TRCODE = 64 THEN 'Senet Ödemesi'
            WHEN KSLINES.TRCODE = 71 THEN 'Açılış (Borç)'
            WHEN KSLINES.TRCODE = 72 THEN 'Açılış (Alacak)'
            WHEN KSLINES.TRCODE = 73 THEN 'Virman (Borç)'
            WHEN KSLINES.TRCODE = 74 THEN 'Virman (Alacak)'
            WHEN KSLINES.TRCODE = 75 THEN 'Gider Pusulası'
            WHEN KSLINES.TRCODE = 76 THEN 'Verilen Serbest Meslek Makbuzu'
            WHEN KSLINES.TRCODE = 77 THEN 'Alınan Serbest Meslek Makbuzu'
            WHEN KSLINES.TRCODE = 79 THEN 'Kur Farkı (Borç)'
            WHEN KSLINES.TRCODE = 80 THEN 'Kur Farkı (Alacak)' END AS [IslemTuru],
            --KSLINES.BRANCH AS [IsYerı],
            --KSLINES.SPECODE AS [OzelKod],
            --KSLINES.CYPHCODE AS [YetkiKodu],
            KSLINES.FICHENO AS [FisNo],
            KSLINES.CUSTTITLE AS [KasaAciklamasi],
            KSLINES.LINEEXP AS [SatirAciklamasi],
            --KSLINES.TRRATE AS [IslemKuru],
            --KSLINES.REPORTRATE AS [RaporlamaKuru],
            CASE WHEN  KSLINES.TRCURR IN(0,160) THEN 'TL' ELSE (SELECT TOP 1  K.CURCODE FROM L_CURRENCYLIST K WHERE K.CURTYPE=KSLINES.TRCURR) END [DovizTuru],
            CASE WHEN KSLINES.SIGN = 0 THEN KSLINES.AMOUNT ELSE 0 END AS [Borc],
            CASE WHEN KSLINES.SIGN = 1 THEN KSLINES.AMOUNT ELSE 0 END AS [Alacak],
             ISNULL(CASE WHEN KSLINES.SIGN = 0 THEN KSLINES.AMOUNT ELSE 0 END,0) - ISNULL(CASE WHEN KSLINES.SIGN = 1 THEN KSLINES.AMOUNT ELSE 0 END,0) Bakiye

            FROM LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_KSLINES KSLINES 
            LEFT OUTER JOIN LG_{Convert.ToInt32(frmano).ToString("000")}_KSCARD KSCARD ON KSLINES.CARDREF = KSCARD.LOGICALREF
            WHERE KSLINES.CANCELLED=0 
            AND KSCARD.CODE IN ({kasaAdi})
            AND KSLINES.DATE_ BETWEEN '{ilkt}' AND '{sont}' 
            AND KSLINES.BRANCH IN ({isyeri})
            group by KSCARD.CODE,KSLINES.LOGICALREF,KSCARD.NAME,KSLINES.DATE_,KSLINES.TRCODE,KSLINES.FICHENO,KSLINES.CUSTTITLE,KSLINES.LINEEXP,KSLINES.TRCURR,KSLINES.SIGN,KSLINES.AMOUNT
         )select *, SUM(Bakiye) OVER (PARTITION BY CODE ORDER BY  LOGICALREF ROWS BETWEEN UNBOUNDED PRECEDING AND 0 PRECEDING) AS  BAKIYERUNNING
	from cte                 
            --ORDER BY Tarih;
            --SELECT
            --ISNULL(SUM(CASE WHEN H.SIGN = 0 THEN H.AMOUNT ELSE 0 END),0) ToplamBorc,
            --ISNULL(SUM(CASE WHEN H.SIGN = 1 THEN H.AMOUNT ELSE 0 END),0) ToplamAlacak,
            --ISNULL(SUM(CASE WHEN H.SIGN = 0 THEN H.AMOUNT ELSE 0 END),0) - ISNULL(SUM(CASE WHEN H.SIGN = 1 THEN H.AMOUNT ELSE 0 END),0) Bakiye
           -- FROM LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_KSLINES H
            --LEFT OUTER JOIN LG_{Convert.ToInt32(frmano).ToString("000")}_KSCARD K ON H.CARDREF = K.LOGICALREF
           -- WHERE H.CANCELLED=0 
            --AND K.CODE IN({kasaAdi})
            ";
                List<LOGO_XERO_KASA_HAREKET> data = db.Database.SqlQuery<LOGO_XERO_KASA_HAREKET>(sorgu).ToList();
                return data;
            }
            
        }
        public List<LOGO_XERO_KASA_HAREKET> KasaHareketGetirYürüyensiz(string frmano, string donem, string ilkt, string sont, string kasaAdi)
        {
            using (LogoContext db = new LogoContext())
            {
                string sorgu = $@"SELECT 0 LOGICALREF , 
            KSCARD.CODE ,
            KSCARD.NAME AS [KasaAdi],
            '' AS [Tarih],
            'DEVİR' AS [IslemTuru],
            '' AS [FisNo],
            '{ilkt} Tarihinden Devir' AS [KasaAciklamasi],
            '' AS [SatirAciklamasi],
            CASE WHEN  KSLINES.TRCURR IN(0,160) THEN 'TL' ELSE (SELECT TOP 1  K.CURCODE FROM L_CURRENCYLIST K WHERE K.CURTYPE=KSLINES.TRCURR) END [DovizTuru],
			CASE WHEN (SUM(CASE WHEN KSLINES.SIGN = 0 THEN KSLINES.AMOUNT ELSE 0 END)-SUM(CASE WHEN KSLINES.SIGN = 1 THEN KSLINES.AMOUNT ELSE 0 END))>0 THEN SUM(CASE WHEN KSLINES.SIGN = 0 THEN KSLINES.AMOUNT ELSE 0 END)-SUM(CASE WHEN KSLINES.SIGN = 1 THEN KSLINES.AMOUNT ELSE 0 END) ELSE 0 END Borc,
			CASE WHEN (SUM(CASE WHEN KSLINES.SIGN = 0 THEN KSLINES.AMOUNT ELSE 0 END)-SUM(CASE WHEN KSLINES.SIGN = 1 THEN KSLINES.AMOUNT ELSE 0 END))<0 THEN SUM(CASE WHEN KSLINES.SIGN = 0 THEN KSLINES.AMOUNT ELSE 0 END)-SUM(CASE WHEN KSLINES.SIGN = 1 THEN KSLINES.AMOUNT ELSE 0 END) ELSE 0 END Alacak,
            ISNULL(SUM(CASE WHEN KSLINES.SIGN = 0 THEN KSLINES.AMOUNT ELSE 0 END),0) - ISNULL(SUM(CASE WHEN KSLINES.SIGN = 1 THEN KSLINES.AMOUNT ELSE 0 END),0) Bakiye
            FROM LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_KSLINES KSLINES 
            LEFT OUTER JOIN LG_{Convert.ToInt32(frmano).ToString("000")}_KSCARD KSCARD ON KSLINES.CARDREF = KSCARD.LOGICALREF
            WHERE KSLINES.CANCELLED=0 
            AND KSCARD.CODE IN({kasaAdi})
            AND KSLINES.DATE_ < '{ilkt}'   
			GROUP BY KSCARD.CODE,KSCARD.NAME,KSLINES.TRCURR
            UNION
           SELECT KSLINES.LOGICALREF,
            KSCARD.CODE ,
            KSCARD.NAME AS [KasaAdi],
            KSLINES.DATE_ AS [Tarih],
           CASE  WHEN KSLINES.TRCODE = 11 THEN 'Ch Tahsilat'
            WHEN KSLINES.TRCODE = 12 THEN 'Ch Ödeme'
            WHEN KSLINES.TRCODE = 21 THEN 'Bankaya Yatırılan'
            WHEN KSLINES.TRCODE = 22 THEN 'Bankadan Çekilen'
            WHEN KSLINES.TRCODE = 31 THEN 'Satınalma Faturası'
            WHEN KSLINES.TRCODE = 32 THEN 'Perakende Satış İade Fatura'
            WHEN KSLINES.TRCODE = 33 THEN 'Toptan Satış İade Fatura'
            WHEN KSLINES.TRCODE = 34 THEN 'Alınan Hizmet Faturası'
            WHEN KSLINES.TRCODE = 35 THEN 'Satınalma İade Faturası'
            WHEN KSLINES.TRCODE = 36 THEN 'Perakende Satış Faturası'
            WHEN KSLINES.TRCODE = 37 THEN 'Toptan Satış Faturası'
            WHEN KSLINES.TRCODE = 38 THEN 'Verilen Hizmet Faturası'
            WHEN KSLINES.TRCODE = 39 THEN 'Mistahsil Makbuz'
            WHEN KSLINES.TRCODE = 41 THEN 'Muhasebe (Tahsil)'
            WHEN KSLINES.TRCODE = 42 THEN 'Muhasebe (Tediye)'
            WHEN KSLINES.TRCODE = 51 THEN 'Personel Borçlanması'
            WHEN KSLINES.TRCODE = 52 THEN 'Personel Geri Ödemesi'
            WHEN KSLINES.TRCODE = 61 THEN 'Çek Tahsili'
            WHEN KSLINES.TRCODE = 62 THEN 'Senet Tahsili'
            WHEN KSLINES.TRCODE = 63 THEN 'Çek Ödemesi'
            WHEN KSLINES.TRCODE = 64 THEN 'Senet Ödemesi'
            WHEN KSLINES.TRCODE = 71 THEN 'Açılış (Borç)'
            WHEN KSLINES.TRCODE = 72 THEN 'Açılış (Alacak)'
            WHEN KSLINES.TRCODE = 73 THEN 'Virman (Borç)'
            WHEN KSLINES.TRCODE = 74 THEN 'Virman (Alacak)'
            WHEN KSLINES.TRCODE = 75 THEN 'Gider Pusulası'
            WHEN KSLINES.TRCODE = 76 THEN 'Verilen Serbest Meslek Makbuzu'
            WHEN KSLINES.TRCODE = 77 THEN 'Alınan Serbest Meslek Makbuzu'
            WHEN KSLINES.TRCODE = 79 THEN 'Kur Farkı (Borç)'
            WHEN KSLINES.TRCODE = 80 THEN 'Kur Farkı (Alacak)' END AS [IslemTuru],
                      KSLINES.FICHENO AS [FisNo],
            KSLINES.CUSTTITLE AS [KasaAciklamasi],
            KSLINES.LINEEXP AS [SatirAciklamasi],
                      CASE WHEN  KSLINES.TRCURR IN(0,160) THEN 'TL' ELSE (SELECT TOP 1  K.CURCODE FROM L_CURRENCYLIST K WHERE K.CURTYPE=KSLINES.TRCURR) END [DovizTuru],
            CASE WHEN KSLINES.SIGN = 0 THEN KSLINES.AMOUNT ELSE 0 END AS [Borc],
            CASE WHEN KSLINES.SIGN = 1 THEN KSLINES.AMOUNT ELSE 0 END AS [Alacak],
             ISNULL(CASE WHEN KSLINES.SIGN = 0 THEN KSLINES.AMOUNT ELSE 0 END,0) - ISNULL(CASE WHEN KSLINES.SIGN = 1 THEN KSLINES.AMOUNT ELSE 0 END,0) Bakiye

            FROM LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_KSLINES KSLINES 
            LEFT OUTER JOIN LG_{Convert.ToInt32(frmano).ToString("000")}_KSCARD KSCARD ON KSLINES.CARDREF = KSCARD.LOGICALREF
            WHERE KSLINES.CANCELLED=0 
            AND KSCARD.CODE IN ({kasaAdi})
            AND KSLINES.DATE_ BETWEEN '{ilkt}' AND '{sont}' 
            group by KSCARD.CODE,KSLINES.LOGICALREF,KSCARD.NAME,KSLINES.DATE_,KSLINES.TRCODE,KSLINES.FICHENO,KSLINES.CUSTTITLE,KSLINES.LINEEXP,KSLINES.TRCURR,KSLINES.SIGN,KSLINES.AMOUNT 
            ";
                List<LOGO_XERO_KASA_HAREKET> data = db.Database.SqlQuery<LOGO_XERO_KASA_HAREKET>(sorgu).ToList();
                return data;
            }
           
        }
        public List<L_KSCARD> KasaGetir(string firma)
        {
            using (LogoContext db = new LogoContext())
            {
                List<L_KSCARD> kasa = db.Database.SqlQuery<L_KSCARD>($@"select * from LG_{firma}_KSCARD where ACTIVE=0").ToList();
                return kasa;
            } 
        }
        public List<LOGO_XERO_BANKA_HAREKET> BankaHareketGetirYuruyensiz(string frmano, string donem, string ilkt, string sont, string bankaadi)
        {
            using (LogoContext db = new LogoContext())
            {
                string sorgu = $@"SELECT 0 BNLLOG, 0 LOGICALREF , 
            '' CODE ,
            '' AS [BankaAdi],
            '' AS [Tarih],
			'DEVİR' AS [IslemTuru],
			'' [BANKAIBAN],
	        '' AS [BANKAHESAPDETAYI],'' [CARIUNVANI],''[CARILOG],''[CARIKODU],'' [HESAPADI],
            '{ilkt} Tarihinden Devir' AS [ACIKLAMA],
            '' [HAREKETTURU],
		    SUM(ISNULL(CASE WHEN BNL.SIGN = 0 AND BNL.TRCURR = 0 THEN BNL.AMOUNT END, 0))  [BORC],
			sum(ISNULL(CASE WHEN BNL.SIGN = 1 AND BNL.TRCURR = 0 THEN BNL.AMOUNT END, 0))  [ALACAK],
			ISNULL(sum(ISNULL(CASE WHEN BNL.SIGN = 0 AND BNL.TRCURR = 0 THEN BNL.AMOUNT END, 0))-sum(ISNULL(CASE WHEN BNL.SIGN = 1 AND BNL.TRCURR = 0 THEN BNL.AMOUNT END, 0)),0) [BAKIYE]
		  FROM  LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_BNFLINE AS BNL
           LEFT OUTER JOIN  LG_{Convert.ToInt32(frmano).ToString("000")}_BANKACC BC ON  BNL.BNACCREF=BC.LOGICALREF
LEFT OUTER JOIN LG_{Convert.ToInt32(frmano).ToString("000")}_BNCARD AS BNC ON   BNL.BANKREF= BNC.LOGICALREF
LEFT OUTER JOIN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_BNFICHE AS BNF ON BNL.SOURCEFREF=BNF.LOGICALREF
LEFT OUTER JOIN LG_{Convert.ToInt32(frmano).ToString("000")}_CLCARD AS C ON BNL.CLIENTREF = C.LOGICALREF
            WHERE BC.LOGICALREF IN ({bankaadi})
            AND BNL.DATE_ < '{ilkt}'   
		   UNION
           SELECT BNL.LOGICALREF BNLLOG, BC.LOGICALREF [HESAPLOG],
            BNC.CODE [BANKAKODU] ,
            BNC.DEFINITION_ AS [BankaAdi],
            BNL.DATE_ AS [Tarih],
			
            CASE BNL.TRCODE
	WHEN 1 THEN 'Banka İşlem Fişi'  WHEN 2 THEN 'Banka Virman Fişi'
	WHEN 3 THEN 'Gelen Havale-EFT'  WHEN 4 THEN 'Gönderilen EFT/Havale'
	WHEN 5 THEN 'Banka Açılış Fişi'  WHEN 6 THEN 'Banka Kur Farkı Fişi'
	WHEN 16 THEN 'Banka Alınan Hizmet Faturası' WHEN 17 THEN 'Banka Verilen Hizmet Faturası'
	WHEN 18 THEN 'Bankadan Çek Ödemesi' WHEN 19 THEN 'Bankadan Senet Ödemesi'
	END AS [IslemTuru],BC.IBAN[BANKAIBAN],
		CASE WHEN BNL.TRANSTYPE=1 THEN 'Cari Hesap' 
WHEN  BNL.TRANSTYPE=2 THEN 'Tahsil Senetleri'
WHEN  BNL.TRANSTYPE=3 THEN 'Takas Çekleri'
WHEN  BNL.TRANSTYPE=4 THEN 'Kesilen Çekler'
WHEN  BNL.TRANSTYPE=5 THEN 'Teminat Senetleri'
WHEN  BNL.TRANSTYPE=6 THEN 'Teminat Çekleri'
WHEN  BNL.TRANSTYPE=7 THEN 'Senet Karşılığı Kredi'
WHEN  BNL.TRANSTYPE=8 THEN 'Çek Karşılığı Kredi'
WHEN  BNL.TRANSTYPE=9 THEN 'Teminat Mektubu'
WHEN  BNL.TRANSTYPE=10 THEN 'Teminatsız Kredi'
WHEN  BNL.TRANSTYPE=20 THEN 'Provizyon Masrafı'
WHEN  BNL.TRANSTYPE=50 THEN 'Kredi Kartı Bloke'
END AS [BANKAHESAPDETAYI],(C.DEFINITION_) [CARIUNVANI],(C.LOGICALREF)[CARILOG],(C.CODE)[CARIKODU],BC.DEFINITION_[HESAPADI],
            BNL.LINEEXP AS [ACIKLAMA],
               CASE WHEN BNL.TRANSTYPE=1 THEN 'Nakit' 
			WHEN  BNL.TRANSTYPE=2 THEN 'Tahsil Senetleri' 
			WHEN  BNL.TRANSTYPE=3 THEN 'Takas Çekleri' 
			WHEN  BNL.TRANSTYPE=4 THEN 'Kesilen Çekler' 
			WHEN  BNL.TRANSTYPE=5 THEN 'Teminat Senetleri' 
			WHEN  BNL.TRANSTYPE=6 THEN 'Teminat Çekleri' 
			WHEN  BNL.TRANSTYPE=7 THEN 'Senet Karşılığı Kredi' 
			WHEN  BNL.TRANSTYPE=8 THEN 'Çek Karşılığı Kredi' 
			WHEN  BNL.TRANSTYPE=9 THEN 'Teminat Mektubu' 
			WHEN  BNL.TRANSTYPE=10 THEN 'Teminatsız Kredi' 
			WHEN  BNL.TRANSTYPE=20 THEN 'Provizyon Masrafları' 
			WHEN  BNL.TRANSTYPE=50 THEN 'Kredi Kartı Bloke' 
			ELSE 'PROBLEM'
			END  [HAREKETTURU],
            ISNULL(CASE WHEN BNL.SIGN = 0 AND BNL.TRCURR = 0 THEN BNL.AMOUNT END, 0)  [BORC],
            ISNULL(CASE WHEN BNL.SIGN = 1 AND BNL.TRCURR = 0 THEN BNL.AMOUNT END, 0)  [ALACAK],
            ISNULL(ISNULL(CASE WHEN BNL.SIGN = 0 AND BNL.TRCURR = 0 THEN BNL.AMOUNT END, 0)-ISNULL(CASE WHEN BNL.SIGN = 1 AND BNL.TRCURR = 0 THEN BNL.AMOUNT END, 0),0) [BAKIYE]
            FROM  LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_BNFLINE AS BNL
           LEFT OUTER JOIN  LG_{Convert.ToInt32(frmano).ToString("000")}_BANKACC BC ON  BNL.BNACCREF=BC.LOGICALREF
LEFT OUTER JOIN LG_{Convert.ToInt32(frmano).ToString("000")}_BNCARD AS BNC ON   BNL.BANKREF= BNC.LOGICALREF
LEFT OUTER JOIN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_BNFICHE AS BNF ON BNL.SOURCEFREF=BNF.LOGICALREF
LEFT OUTER JOIN LG_{Convert.ToInt32(frmano).ToString("000")}_CLCARD AS C ON BNL.CLIENTREF = C.LOGICALREF
            WHERE 
            BC.LOGICALREF IN ({bankaadi})
            AND BNL.DATE_ BETWEEN '{ilkt}' AND '{sont}' 
			AND (BNL.TRCODE IN (1, 2, 3, 4, 5, 6, 16, 17, 18, 19)) 
AND (BNL.TRANSTYPE NOT IN (3,2))  
            group by BNL.LOGICALREF,BNC.CODE,BC.LOGICALREF,BNC.DEFINITION_,BNL.DATE_,BNL.TRCODE,BNL.LINEEXP,BNL.SIGN,BNL.AMOUNT,BNL.TRCURR,BNL.TRANSTYPE,BC.IBAN,C.DEFINITION_,BC.DEFINITION_,BNL.TRANSTYPE,C.LOGICALREF,C.CODE
         ";
                List<LOGO_XERO_BANKA_HAREKET> data = db.Database.SqlQuery<LOGO_XERO_BANKA_HAREKET>(sorgu).ToList();
                return data;
            }
           
        }
        public List<LOGO_XERO_BANKA_HAREKET> BankaHareketGetir(string frmano, string donem, string ilkt, string sont, string bankaadi, string isyeri)
        {
            using (LogoContext db = new LogoContext())
            {
                string sorgu = $@"; with cte as(SELECT 0 BNLLOG, 0 LOGICALREF , 
            '' CODE ,
            '' AS [BankaAdi],
            '' AS [Tarih],
			'DEVİR' AS [IslemTuru],
			'' [BANKAIBAN],
	        '' AS [BANKAHESAPDETAYI],'' [CARIUNVANI],''[CARILOG],''[CARIKODU],'' [HESAPADI],
            '{ilkt} Tarihinden Devir' AS [ACIKLAMA],
            '' [HAREKETTURU],
		    SUM(ISNULL(CASE WHEN BNL.SIGN = 0 AND BNL.TRCURR = 0 THEN BNL.AMOUNT END, 0))  [BORC],
			sum(ISNULL(CASE WHEN BNL.SIGN = 1 AND BNL.TRCURR = 0 THEN BNL.AMOUNT END, 0))  [ALACAK],
			ISNULL(sum(ISNULL(CASE WHEN BNL.SIGN = 0 AND BNL.TRCURR = 0 THEN BNL.AMOUNT END, 0))-sum(ISNULL(CASE WHEN BNL.SIGN = 1 AND BNL.TRCURR = 0 THEN BNL.AMOUNT END, 0)),0) [BAKIYE]
		  FROM  LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_BNFLINE AS BNL
           LEFT OUTER JOIN  LG_{Convert.ToInt32(frmano).ToString("000")}_BANKACC BC ON  BNL.BNACCREF=BC.LOGICALREF
LEFT OUTER JOIN LG_{Convert.ToInt32(frmano).ToString("000")}_BNCARD AS BNC ON   BNL.BANKREF= BNC.LOGICALREF
LEFT OUTER JOIN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_BNFICHE AS BNF ON BNL.SOURCEFREF=BNF.LOGICALREF
LEFT OUTER JOIN LG_{Convert.ToInt32(frmano).ToString("000")}_CLCARD AS C ON BNL.CLIENTREF = C.LOGICALREF
            WHERE BC.LOGICALREF IN ({bankaadi})
            AND BNL.DATE_ < '{ilkt}'  
            AND BNL.BRANCH IN ({isyeri})  
		   UNION
           SELECT  BNL.LOGICALREF BNLLOG, BC.LOGICALREF [HESAPLOG],
            BNC.CODE [BANKAKODU] ,
            BNC.DEFINITION_ AS [BankaAdi],
            BNL.DATE_ AS [Tarih],
			
            CASE BNL.TRCODE
	WHEN 1 THEN 'Banka İşlem Fişi'  WHEN 2 THEN 'Banka Virman Fişi'
	WHEN 3 THEN 'Gelen Havale-EFT'  WHEN 4 THEN 'Gönderilen EFT/Havale'
	WHEN 5 THEN 'Banka Açılış Fişi'  WHEN 6 THEN 'Banka Kur Farkı Fişi'
	WHEN 16 THEN 'Banka Alınan Hizmet Faturası' WHEN 17 THEN 'Banka Verilen Hizmet Faturası'
	WHEN 18 THEN 'Bankadan Çek Ödemesi' WHEN 19 THEN 'Bankadan Senet Ödemesi'
	END AS [IslemTuru],BC.IBAN[BANKAIBAN],
		CASE WHEN BNL.TRANSTYPE=1 THEN 'Cari Hesap' 
WHEN  BNL.TRANSTYPE=2 THEN 'Tahsil Senetleri'
WHEN  BNL.TRANSTYPE=3 THEN 'Takas Çekleri'
WHEN  BNL.TRANSTYPE=4 THEN 'Kesilen Çekler'
WHEN  BNL.TRANSTYPE=5 THEN 'Teminat Senetleri'
WHEN  BNL.TRANSTYPE=6 THEN 'Teminat Çekleri'
WHEN  BNL.TRANSTYPE=7 THEN 'Senet Karşılığı Kredi'
WHEN  BNL.TRANSTYPE=8 THEN 'Çek Karşılığı Kredi'
WHEN  BNL.TRANSTYPE=9 THEN 'Teminat Mektubu'
WHEN  BNL.TRANSTYPE=10 THEN 'Teminatsız Kredi'
WHEN  BNL.TRANSTYPE=20 THEN 'Provizyon Masrafı'
WHEN  BNL.TRANSTYPE=50 THEN 'Kredi Kartı Bloke'
END AS [BANKAHESAPDETAYI],(C.DEFINITION_) [CARIUNVANI],(C.LOGICALREF)[CARILOG],(C.CODE)[CARIKODU],BC.DEFINITION_[HESAPADI],
            BNL.LINEEXP AS [ACIKLAMA],
            CASE WHEN BNL.TRANSTYPE=1 THEN 'Nakit' 
			WHEN  BNL.TRANSTYPE=2 THEN 'Tahsil Senetleri' 
			WHEN  BNL.TRANSTYPE=3 THEN 'Takas Çekleri' 
			WHEN  BNL.TRANSTYPE=4 THEN 'Kesilen Çekler' 
			WHEN  BNL.TRANSTYPE=5 THEN 'Teminat Senetleri' 
			WHEN  BNL.TRANSTYPE=6 THEN 'Teminat Çekleri' 
			WHEN  BNL.TRANSTYPE=7 THEN 'Senet Karşılığı Kredi' 
			WHEN  BNL.TRANSTYPE=8 THEN 'Çek Karşılığı Kredi' 
			WHEN  BNL.TRANSTYPE=9 THEN 'Teminat Mektubu' 
			WHEN  BNL.TRANSTYPE=10 THEN 'Teminatsız Kredi' 
			WHEN  BNL.TRANSTYPE=20 THEN 'Provizyon Masrafları' 
			WHEN  BNL.TRANSTYPE=50 THEN 'Kredi Kartı Bloke' 
			ELSE 'PROBLEM'
			END  [HAREKETTURU],
            ISNULL(CASE WHEN BNL.SIGN = 0 AND BNL.TRCURR = 0 THEN BNL.AMOUNT END, 0)  [BORC],
            ISNULL(CASE WHEN BNL.SIGN = 1 AND BNL.TRCURR = 0 THEN BNL.AMOUNT END, 0)  [ALACAK],
            ISNULL(ISNULL(CASE WHEN BNL.SIGN = 0 AND BNL.TRCURR = 0 THEN BNL.AMOUNT END, 0)-ISNULL(CASE WHEN BNL.SIGN = 1 AND BNL.TRCURR = 0 THEN BNL.AMOUNT END, 0),0) [BAKIYE]
            FROM  LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_BNFLINE AS BNL
           LEFT OUTER JOIN  LG_{Convert.ToInt32(frmano).ToString("000")}_BANKACC BC ON  BNL.BNACCREF=BC.LOGICALREF
LEFT OUTER JOIN LG_{Convert.ToInt32(frmano).ToString("000")}_BNCARD AS BNC ON   BNL.BANKREF= BNC.LOGICALREF
LEFT OUTER JOIN LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_BNFICHE AS BNF ON BNL.SOURCEFREF=BNF.LOGICALREF
LEFT OUTER JOIN LG_{Convert.ToInt32(frmano).ToString("000")}_CLCARD AS C ON BNL.CLIENTREF = C.LOGICALREF
            WHERE 
            BC.LOGICALREF IN ({bankaadi})
            AND BNL.DATE_ BETWEEN '{ilkt}' AND '{sont}' 
			AND (BNL.TRCODE IN (1, 2, 3, 4, 5, 6, 16, 17, 18, 19))
            AND BNL.BRANCH IN ({isyeri}) 
AND (BNL.TRANSTYPE NOT IN (3,2))  
            group by BNL.LOGICALREF, BNC.CODE,BC.LOGICALREF,BNC.DEFINITION_,BNL.DATE_,BNL.TRCODE,BNL.LINEEXP,BNL.SIGN,BNL.AMOUNT,BNL.TRCURR,BNL.TRANSTYPE,BC.IBAN,C.DEFINITION_,BC.DEFINITION_,BNL.TRANSTYPE,C.LOGICALREF,C.CODE
         )select *, SUM(BAKIYE) OVER (ORDER BY  LOGICALREF ROWS BETWEEN UNBOUNDED PRECEDING AND 0 PRECEDING) AS  BAKIYERUNNING
	from cte ";
                 List<LOGO_XERO_BANKA_HAREKET> data = db.Database.SqlQuery<LOGO_XERO_BANKA_HAREKET>(sorgu).ToList();
                return data;
            }
           
        }
        public List<L_BNCARD> BankaGetir(string firma)
        {
            using (LogoContext db = new LogoContext())
            {
                List<L_BNCARD> banka = db.Database.SqlQuery<L_BNCARD>($@"select BC.LOGICALREF,BC.DEFINITION_+' / '+BC.CODE [HESAP] from LG_{firma}_BANKACC BC LEFT OUTER JOIN   LG_{firma}_BNCARD B ON B.LOGICALREF=BC.BANKREF
            where B.ACTIVE=0").ToList();
                return banka;
            } 
        }
        public List<LOGO_XERO_KREDI_KART_HAREKET> KrediKartiHareket(string frmano, string donem, string trcode, string ilkt, string sont, string isyeri)
        {
            using (LogoContext db = new LogoContext())
            {
                string sorgu = $@" [dbo].[LOGO_XERO_KREDI_KART_HAREKET]
		@FIRMA = N'{Convert.ToInt32(frmano).ToString("000")}',
		@DONEM = N'{donem}',
		@FIRMNR = N'{Convert.ToInt32(frmano)}',
        @trcode =N'{Convert.ToInt32(trcode)}',
		@Sqlcommand = N' ' ,
        @ilkt = N'{ilkt}',
		@sont = N'{sont}',
        @ISYERI = N'{isyeri}'";
                return db.Database.SqlQuery<LOGO_XERO_KREDI_KART_HAREKET>(sorgu).ToList();
            }
        }
        public bool TasarimKaydetPivot(PivotGridControl gv, int kullaniciid, string sayfaadi, string gridadi)
        {
            Stream str = new System.IO.MemoryStream();
            gv.SaveLayoutToStream(str);
            str.Seek(0, System.IO.SeekOrigin.Begin);
            StreamReader reader = new StreamReader(str);
            string text = reader.ReadToEnd();
            bool durum = false;
            using (LogoContext db3 = new LogoContext())
            {
                try
                {
                    LOGO_XERO_TASARIMLAR tasarim = db3.LOGO_XERO_TASARIMLAR.Where(s => s.SAYFAADI == sayfaadi && s.PERSONELID == kullaniciid && s.GRIDADI == gridadi).FirstOrDefault();
                    if (tasarim == null)
                    {
                        LOGO_XERO_TASARIMLAR yenitasarim = new LOGO_XERO_TASARIMLAR();
                        yenitasarim.GRIDADI = gridadi;
                        yenitasarim.PERSONELID = kullaniciid;
                        yenitasarim.TASARIM = text;
                        yenitasarim.SAYFAADI = sayfaadi;
                        db3.LOGO_XERO_TASARIMLAR.Add(yenitasarim);
                        db3.SaveChanges();
                    }
                    else
                    {
                        tasarim.TASARIM = text;
                        db3.Entry(tasarim).State = System.Data.Entity.EntityState.Modified;
                        db3.SaveChanges();
                    }
                    durum = true;
                }
                catch
                {
                    durum = false;
                }
            }
            return durum;
        }
        public void TasarimGetirPivot(PivotGridControl gv, int kullaniciid, string sayfaadi, string gridadi)
        {
            string tasarimdeger = "";
            using (LogoContext db3 = new LogoContext())
            {
                LOGO_XERO_TASARIMLAR tasarim = db3.LOGO_XERO_TASARIMLAR.Where(s => s.SAYFAADI == sayfaadi && s.PERSONELID == kullaniciid && s.GRIDADI == gridadi).FirstOrDefault();
                if (tasarim != null)
                {
                    tasarimdeger = tasarim.TASARIM;
                    byte[] encodedString = Encoding.UTF8.GetBytes(tasarimdeger);
                    MemoryStream ms = new MemoryStream(encodedString);
                    gv.RestoreLayoutFromStream(ms);
                    ms.Flush();
                    ms.Position = 0;
                }
            }
        }
        public void excelAktarpivot(PivotGridControl pivot)
        {
            SaveFileDialog svf = new SaveFileDialog();
            svf.Filter = "Excel Dosyası| *.xlsx";
            DialogResult dr = svf.ShowDialog();
            if (dr == DialogResult.OK)
            {
                pivot.ExportToXlsx(svf.FileName);
            }
        }
        public void KREDI_KART_HAREKET_PROCEDURE_OLUSTUR(string firma)
        {
            try
            {
                clas.Connect();
                string sql = $@"CREATE PROCEDURE[dbo].[LOGO_XERO_KREDI_KART_HAREKET]
@FIRMA nvarchar(5),  
@DONEM  nvarchar(3),
@FIRMNR nvarchar(5),
@trcode nvarchar(5),
@ilkt nvarchar(200),
@sont nvarchar (200),
@ISYERI nvarchar (200),
@Sqlcommand nvarchar(max)
AS   
BEGIN   
set @Sqlcommand='SELECT 
				F.DEPARTMENT [ISYERINO],
                CP.NAME [ISYERIADI],
                YEAR(F.DATE_) [YIL], case when MONTH(F.DATE_)=1 then ''01-Ocak''
 when MONTH(F.DATE_)=2 then ''02-Şubat''
 when MONTH(F.DATE_)=3 then ''03-Mart''
 when MONTH(F.DATE_)=4 then ''04-Nisan''
 when MONTH(F.DATE_)=5 then ''05-Mayıs''
 when MONTH(F.DATE_)=6 then ''06-Haziran''
 when MONTH(F.DATE_)=7 then ''07-Temmuz''
 when MONTH(F.DATE_)=8 then ''08-Ağustos''
 when MONTH(F.DATE_)=9 then ''09-Eylül''
 when MONTH(F.DATE_)=10 then ''10-Ekim''
 when MONTH(F.DATE_)=11 then ''11-Kasım''
 when MONTH(F.DATE_)=12 then ''12-Aralık''else '''' end as [AY],F.DATE_ [TARIH],
                F.FICHENO [FISNO],CC.DEFINITION_[CARIAD],CC.LOGICALREF[CARILOG],CC.CODE[CARIKODU],BC.DEFINITION_[BANKAADI], F.SPECCODE [OZELKOD], F.CYPHCODE [YETKIKODU], 
                F.GENEXP1 [ACIKLAMA1],F.GENEXP2 [ACIKLAMA2], 
                L.AMOUNT [TUTAR]
    			FROM LG_'+@FIRMA+'_'+@DONEM+'_CLFLINE L
				LEFT OUTER JOIN  LG_'+@FIRMA+'_'+@DONEM+'_CLFICHE F  ON L.SOURCEFREF = F.LOGICALREF
                LEFT OUTER JOIN LG_'+@FIRMA+'_CLCARD CC ON L.CLIENTREF= CC.LOGICALREF
                LEFT OUTER JOIN LG_'+@FIRMA+'_BANKACC BC ON L.BANKACCREF= BC.LOGICALREF
				LEFT OUTER JOIN L_CAPIDEPT CP ON F.DEPARTMENT=CP.NR  
				WHERE L.TRCODE='+@trcode+' AND L.CANCELLED=0 AND L.DATE_ BETWEEN '''+@ilkt+''' AND '''+@sont+''' AND CP.FIRMNR='+@FIRMNR+' AND L.BRANCH IN('+@ISYERI+')'

EXEC (@Sqlcommand)
END
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }

        }
        public List<LOGO_XERO_FATURA_KDV_RAPORU> FaturaKDVRaporuGetir(string frmano, string donem, string trkod, string ilkt, string sont, string isyeri)
        {
            using (LogoContext db = new LogoContext())
            {
                string sorgu = $@"SELECT O.LOGICALREF,C.LOGICALREF [CARILOG], O.FICHENO AS [FISNO], O.DOCODE AS [BELGENO], O.DATE_ AS TARIH, dbo.LG_INTTOTIME(O.TIME_) AS SAAT, O.DOCDATE AS [SEVKTARIHI], C.CODE AS [CARIKODU], 
                         C.DEFINITION_ AS [CARIUNVANI], C.SPECODE AS [OZELKOD1],C.SPECODE2 AS [OZELKOD2], C.SPECODE4 AS [OZELKOD4], C.TELNRS1 AS TELEFON, O.TRADINGGRP AS [TICARIISLEMGRUBU],
                              (SELECT TOP (1) GDEF FROM  dbo.L_TRADGRP WITH (Nolock) WHERE (GCODE = O.TRADINGGRP)) AS GRUPACIKLAMA, O.DEPARTMENT AS ISYERINO,(SELECT  NAME FROM dbo.L_CAPIDEPT WITH (Nolock) WHERE (NR = O.DEPARTMENT) AND (FIRMNR = {Convert.ToInt32(frmano)})) AS [ISYERIADI], O.SOURCEINDEX AS [AMBARNO],(SELECT NAME FROM dbo.L_CAPIWHOUSE WITH (Nolock) WHERE (NR = O.SOURCEINDEX) AND (FIRMNR = {Convert.ToInt32(frmano)})) AS [AMBARADI], O.GENEXP1 AS ACIKLAMA, O.SALESMANREF, P.CODE AS SALESMANCODE, P.DEFINITION_ AS SALESMANNAME, 
                         O.GROSSTOTAL AS TUTAR, O.TOTALDISCOUNTS - O.ADDDISCOUNTS AS [ISKONTOTUTARI], O.TOTALDISCOUNTED AS [ISKONTOLUTUTAR], O.TOTALVAT AS [KDVTUTARI], O.NETTOTAL AS [TOPLAMTUTAR], 
                         O.ADDDISCOUNTS AS [GENELISKONTO], O.PAYDEFREF AS ODEMETIPIID, OT.DEFINITION_ AS ODEMETIPI, CASE WHEN O.EINVOICE = 0 THEN 'Kağıt Fatura' WHEN O.EINVOICE = 1 THEN 'E-Fatura' WHEN O.EINVOICE = 2 THEN 'E-Arşiv'  WHEN O.EINVOICE = 3 THEN 'E-Arşiv İnternet' ELSE '' END AS [FATURATIPI], O.GUID, 
CASE WHEN O.TRCODE =1 THEN '(01)Satın Alma Faturası'
WHEN O.TRCODE =4 THEN '(04)Alınan Hizmet Faturası'
WHEN O.TRCODE=5 THEN '(05)Alınan Proforma Fatura'
WHEN O.TRCODE=6 THEN '(06)Satın Alma İade Faturası'
WHEN O.TRCODE=13 THEN '(13)satın Alma Fiyat Farkı Faturası'
WHEN O.TRCODE=26 THEN '(26)Müstahsil Makbuzu'
WHEN O.TRCODE =2 THEN '(02)Perakende Satış İade Faturası'
WHEN O.TRCODE =3 THEN '(03)Toptan Satış İade Faturası'
WHEN O.TRCODE=7 THEN '(07)Perakende Satış Faturası'
WHEN O.TRCODE=8 THEN '(08)Toptan Satış Faturası'
WHEN O.TRCODE=9 THEN '(09)Verilen Hizmet Faturası'
WHEN O.TRCODE=10 THEN '(10)Verilen Proforma Fatura'
WHEN O.TRCODE=14 THEN '(14)Verilen Fiyat Farkı Faturası'
ELSE '' END AS [TRCODE], E.TCKNO AS [PERAKENDETCNO],
                          E.NAME AS [PERAKENDEADI],E.SURNAME AS [PERAKENDESOYADI], E.ISCOMP, E.DEFINITION_,  C.TELNRS1 [TELNO], C.ADDR1 [ADRES], C.CITY [SEHIR], C.TOWN [ILCE], C.EMAILADDR [EMAILADRES], 
						  
						  CASE WHEN O.EINVOICE = 1 AND O.ESTATUS=0 THEN 'GİBe Gönderilecek'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=1 THEN 'Onay Gönderildi'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=2 THEN 'Onaylandı'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=3 THEN 'Paketlendi'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=4 THEN 'GİBe Gönderildi'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=5 THEN 'GİBe Gönderilemedi'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=6 THEN 'GİBde İşlendi-Alıcıya İletilecek'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=7 THEN 'GİBde İşlenemedi'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=8 THEN 'Alıcıya Gönderildi'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=9 THEN 'Alıcıya Gönderilemedi'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=10 THEN 'Alıcıda İşlendi-Başarıyla Tamamlandı'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=11 THEN 'Alıcıda İşlenemedi'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=12 THEN 'Kabul Edildi'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=13 THEN 'Reddedildi'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=14 THEN 'İade Edildi'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=15 THEN 'Sunucuya İletildi-İşlenmeyi Bekliyor'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=16 THEN 'Sunuda Mühürlendi'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=17 THEN 'Sunucuda Zarflandı'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=18 THEN 'Sunucuda Hata Alındı'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=19 THEN 'Alındı'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=20 THEN 'Kabul Edildi'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=21 THEN 'Reddedildi'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=22 THEN 'Sunucuya Gönderildi'
						  WHEN O.EINVOICE = 1 AND O.ESTATUS=23 THEN 'Harici Yollardan İptal Edildi'
						  WHEN O.EINVOICE = 2 AND E.EARCHIVESTATUS=0 THEN 'E-Arşiv Faturası Oluşturulacak'
						 WHEN O.EINVOICE = 2 AND E.EARCHIVESTATUS=1 THEN 'E-Arşiv Faturası Oluşturuldu'
						 WHEN O.EINVOICE = 2 AND E.EARCHIVESTATUS=2 THEN 'Rapor Dosyasına Yazıldı'
						 WHEN O.EINVOICE = 2 AND E.EARCHIVESTATUS=3 THEN 'Sunucuya İletildi. İşlenmeyi Bekliyor'
						 WHEN O.EINVOICE = 2 AND E.EARCHIVESTATUS=4 THEN 'GIBe İletildi.'
						 WHEN O.EINVOICE = 2 AND E.EARCHIVESTATUS=5 THEN 'Sunucuda Hata Alındı'
						 WHEN O.EINVOICE = 2 AND E.EARCHIVESTATUS=6 THEN 'Sunucuda İmzalandı'
						  else '' end 
						  AS [EFATURASTATUSU],
						 
                          O.PRINTCNT AS [YAZDIRMABILGISI], O.DOCTRACKINGNR AS [DOKUMANIZLEMENO],
                          ISNULL(dbo.KDVMATRAH_{Convert.ToInt32(frmano).ToString("000")}_{donem}(O.LOGICALREF,1),0) AS [KDV1MATRAH], ISNULL(dbo.KDVTUTAR_{Convert.ToInt32(frmano).ToString("000")}_{donem}(O.LOGICALREF,1),0) AS [KDV1TUTAR], ISNULL(dbo.KDVMATRAH_{Convert.ToInt32(frmano).ToString("000")}_{donem}(O.LOGICALREF,8),0) AS [KDV8MATRAH], ISNULL(dbo.KDVTUTAR_{Convert.ToInt32(frmano).ToString("000")}_{donem}(O.LOGICALREF,8),0) AS [KDV8TUTAR], ISNULL(dbo.KDVMATRAH_{Convert.ToInt32(frmano).ToString("000")}_{donem}(O.LOGICALREF,18),0) AS [KDV18MATRAH], ISNULL(dbo.KDVTUTAR_{Convert.ToInt32(frmano).ToString("000")}_{donem}(O.LOGICALREF,18),0) AS [KDV18TUTAR] , 
ISNULL(dbo.KDVMATRAH_{Convert.ToInt32(frmano).ToString("000")}_{donem}(O.LOGICALREF,10),0) AS [KDV10MATRAH], ISNULL(dbo.KDVTUTAR_{Convert.ToInt32(frmano).ToString("000")}_{donem}(O.LOGICALREF,10),0) AS [KDV10TUTAR] , 
ISNULL(dbo.KDVMATRAH_{Convert.ToInt32(frmano).ToString("000")}_{donem}(O.LOGICALREF,20),0) AS [KDV20MATRAH], ISNULL(dbo.KDVTUTAR_{Convert.ToInt32(frmano).ToString("000")}_{donem}(O.LOGICALREF,20),0) AS [KDV20TUTAR] , 
                             (SELECT TOP (1) DATE_ FROM dbo.LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_PAYTRANS WITH (Nolock)
                               WHERE (FICHEREF = O.LOGICALREF) AND (PROCDATE = O.DATE_)) AS [VADETARIHI], AD.CODE AS [SEVKIYATADRESKODU], AD.NAME AS [SEVKIYATADRESI], (CASE WHEN O.CANCELLED = 1 THEN 'İptal' WHEN O.CANCELLED=0 THEN 'Gerçek' ELSE '' END) 
                         AS DURUMU, O.EINVOICETYP AS TEVKIFATTIP, C.TAXNR AS [VERGINO], C.TAXOFFICE[VERGIDAIRESI], C.TCKNO, C.SPECODE3, E.SENDMOD
                        FROM   dbo.LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_INVOICE AS O WITH (Nolock)
                         LEFT OUTER JOIN dbo.LG_{Convert.ToInt32(frmano).ToString("000")}_CLCARD AS C ON O.CLIENTREF = C.LOGICALREF LEFT OUTER JOIN
                         dbo.LG_{Convert.ToInt32(frmano).ToString("000")}_PAYPLANS AS OT ON O.PAYDEFREF = OT.LOGICALREF LEFT OUTER JOIN
                         dbo.LG_{Convert.ToInt32(frmano).ToString("000")}_SHIPINFO AS AD ON O.SHIPINFOREF = AD.LOGICALREF LEFT OUTER JOIN
                         dbo.LG_SLSMAN AS P ON O.SALESMANREF = P.LOGICALREF AND P.FIRMNR = {Convert.ToInt32(frmano)} LEFT OUTER JOIN
                         dbo.LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_EARCHIVEDET AS E ON O.LOGICALREF = E.INVOICEREF
                        WHERE (O.TRCODE IN ({trkod}) AND O.DATE_ BETWEEN '{ilkt}' And '{sont}' AND O.CANCELLED = 0 AND O.BRANCH IN ({isyeri})) 
                        ORDER BY [FISNO]";
                List<LOGO_XERO_FATURA_KDV_RAPORU> data = db.Database.SqlQuery<LOGO_XERO_FATURA_KDV_RAPORU>(sorgu).ToList();
                return data;
            }
           
        }
        public List<LOGO_XERO_KDV_RAPOR_KARSILASTIRMA> FatKdvKarsilastirma(string frmano, string donem, string trkod, string ilkt, string sont, string isyeri)
        {
            using (LogoContext db = new LogoContext())
            {
                string sorgu = $@"SELECT O.LOGICALREF,C.LOGICALREF [CARILOG], O.FICHENO AS [FISNO], O.DOCODE AS [BELGENO], O.DATE_ AS TARIH, C.CODE AS [CARIKODU], 
                         C.DEFINITION_ AS [CARIUNVANI], O.GENEXP1 AS ACIKLAMA, P.CODE AS SALESMANCODE,P.DEFINITION_ AS SALESMANNAME, 
                         O.GROSSTOTAL AS TUTAR, O.TOTALDISCOUNTS - O.ADDDISCOUNTS AS [ISKONTOTUTARI], O.TOTALDISCOUNTED AS [ISKONTOLUTUTAR], O.TOTALVAT AS [KDVTUTARI], O.NETTOTAL AS [TOPLAMTUTAR], 
                         O.ADDDISCOUNTS AS [GENELISKONTO], CASE WHEN O.EINVOICE = 0 THEN 'Kağıt Fatura' WHEN O.EINVOICE = 1 THEN 'E-Fatura' WHEN O.EINVOICE = 2 THEN 'E-Arşiv'  WHEN O.EINVOICE = 3 THEN 'E-Arşiv İnternet' ELSE '' END AS [FATURATIPI],
CASE WHEN O.TRCODE =1 THEN '(01)Satın Alma Faturası'
WHEN O.TRCODE =4 THEN '(04)Alınan Hizmet Faturası'
WHEN O.TRCODE=5 THEN '(05)Alınan Proforma Fatura'
WHEN O.TRCODE=6 THEN '(06)Satın Alma İade Faturası'
WHEN O.TRCODE=13 THEN '(13)satın Alma Fiyat Farkı Faturası'
WHEN O.TRCODE=26 THEN '(26)Müstahsil Makbuzu'
WHEN O.TRCODE =2 THEN '(02)Perakende Satış İade Faturası'
WHEN O.TRCODE =3 THEN '(03)Toptan Satış İade Faturası'
WHEN O.TRCODE=7 THEN '(07)Perakende Satış Faturası'
WHEN O.TRCODE=8 THEN '(08)Toptan Satış Faturası'
WHEN O.TRCODE=9 THEN '(09)Verilen Hizmet Faturası'
WHEN O.TRCODE=10 THEN '(10)Verilen Proforma Fatura'
WHEN O.TRCODE=14 THEN '(14)Verilen Fiyat Farkı Faturası'
ELSE '' END AS [TRCODE],
                          E.DEFINITION_,  C.TELNRS1 [TELNO], C.ADDR1 [ADRES],C.TAXNR AS [VERGINO],C.TCKNO,ISNULL(dbo.KDVMATRAH_{Convert.ToInt32(frmano).ToString("000")}_{donem}(O.LOGICALREF,1),0) AS [KDV1MATRAH], ISNULL(dbo.KDVTUTAR_{Convert.ToInt32(frmano).ToString("000")}_{donem}(O.LOGICALREF,1),0) AS [KDV1TUTAR], ISNULL(dbo.KDVMATRAH_{Convert.ToInt32(frmano).ToString("000")}_{donem}(O.LOGICALREF,8),0) AS [KDV8MATRAH], ISNULL(dbo.KDVTUTAR_{Convert.ToInt32(frmano).ToString("000")}_{donem}(O.LOGICALREF,8),0) AS [KDV8TUTAR], ISNULL(dbo.KDVMATRAH_{Convert.ToInt32(frmano).ToString("000")}_{donem}(O.LOGICALREF,18),0) AS [KDV18MATRAH], ISNULL(dbo.KDVTUTAR_{Convert.ToInt32(frmano).ToString("000")}_{donem}(O.LOGICALREF,18),0) AS [KDV18TUTAR],
ISNULL(dbo.KDVMATRAH_{Convert.ToInt32(frmano).ToString("000")}_{donem}(O.LOGICALREF,10),0) AS [KDV10MATRAH], ISNULL(dbo.KDVTUTAR_{Convert.ToInt32(frmano).ToString("000")}_{donem}(O.LOGICALREF,10),0) AS [KDV10TUTAR],
ISNULL(dbo.KDVMATRAH_{Convert.ToInt32(frmano).ToString("000")}_{donem}(O.LOGICALREF,20),0) AS [KDV20MATRAH], ISNULL(dbo.KDVTUTAR_{Convert.ToInt32(frmano).ToString("000")}_{donem}(O.LOGICALREF,20),0) AS [KDV20TUTAR]
                         FROM   dbo.LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_INVOICE AS O WITH (Nolock)
                         LEFT OUTER JOIN dbo.LG_{Convert.ToInt32(frmano).ToString("000")}_CLCARD AS C ON O.CLIENTREF = C.LOGICALREF LEFT OUTER JOIN
                         dbo.LG_{Convert.ToInt32(frmano).ToString("000")}_PAYPLANS AS OT ON O.PAYDEFREF = OT.LOGICALREF LEFT OUTER JOIN
                         dbo.LG_{Convert.ToInt32(frmano).ToString("000")}_SHIPINFO AS AD ON O.SHIPINFOREF = AD.LOGICALREF LEFT OUTER JOIN
                         dbo.LG_SLSMAN AS P ON O.SALESMANREF = P.LOGICALREF AND P.FIRMNR = {Convert.ToInt32(frmano)} LEFT OUTER JOIN
                         dbo.LG_{Convert.ToInt32(frmano).ToString("000")}_{donem}_EARCHIVEDET AS E ON O.LOGICALREF = E.INVOICEREF
                        WHERE ({trkod} AND O.DATE_ BETWEEN '{ilkt}' And '{sont}' AND O.CANCELLED = 0 AND O.BRANCH IN ({isyeri})) 
                        ORDER BY [FISNO]";
                List<LOGO_XERO_KDV_RAPOR_KARSILASTIRMA> data = db.Database.SqlQuery<LOGO_XERO_KDV_RAPOR_KARSILASTIRMA>(sorgu).ToList();
                return data;
            } 
        }
    }
}
