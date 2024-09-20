using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LogoObje
{
    public class OBJE_SIPARIS_M
    {
        public DateTime TARIH { get; set; } //DATE
        public DateTime OLUSTURMATARIHI { get; set; } //DATE_CREATED  OLUŞTURMATARİHİ
        public DateTime GUNCELLEMETARIHI { get; set; } //DATE_MODIFIED
        public string OLUSTURMASAATI { get; set; } //HOUR_CREATED ,MIN_CREATED,SEC_CREATED
        public string GUNCELLEMESAATI { get; set; } //HOUR_MODIFIED ,MIN_MODIFIED,SEC_MODIFIED
        public string FATURANO { get; set; } //NUMBER
        public string SAAT { get; set; } //TIME
        public string CARIKODU { get; set; } //ARP_CODE
        public string SEVKIYATHESABIKODU { get; set; } //ARP_CODE_SHPM
        public string MUHASEBEKODU { get; set; } //GL_CODE
        public string OZELKOD { get; set; } //AUXIL_CODE
        public string YETKIKODU { get; set; } //AUTH_CODE
        public string TICARIISLEMGRUBU { get; set; } //TRADING_GRP
        public string BELGENO { get; set; } //DOC_NUMBER
        public string CARIODEMEKODU { get; set; } //PAYMENT_CODE
        public string CARIODEMEREFI { get; set; } //PAYDEFREF
        public int SIPARISSTATU { get; set; } //ORDER_STATUS //1 öneri 4 sevkedilebilir
        public string DOKUMANIZLEMENO { get; set; } //DOC_TRACKING_NR

        public string TASIYICIKODU { get; set; }//SHIPPING_AGENT
        public string ACIKLAMA1 { get; set; } //NOTES1
        public string ACIKLAMA2 { get; set; } //NOTES2
        public string ACIKLAMA3 { get; set; } //NOTES3
        public string ACIKLAMA4 { get; set; } //NOTES4
        public string ACIKLAMA5 { get; set; } //NOTES5
        public string ACIKLAMA6 { get; set; } //NOTES6
        public string SATISELEMANIKODU { get; set; }//SALESMAN_CODE
        public Int16 AMBAR { get; set; } //SOURCE_WH
        public Int16 MALIYETAMBAR { get; set; } //SOURCE_COST_GRP
        public Int16 ISYERI { get; set; } //DIVISION
        public Int16 BOLUM { get; set; } //DEPARTMENT
        public Int16 FABRIKA { get; set; }//FACTORY
        public string PROJEKODU { get; set; } //PROJECT_CODE
        public string TESLIMSEKLIKODU { get; set; }//SHIPMENT_TYPE
        public string SEVKADRESIKODU { get; set; } //SHIPLOC_CODE
        public string MUSTERISIPARISNUMARASI { get; set; } //CUST_ORD_NO
        public Int16 EFATURA { get; set; }//EINVOICE
        public Int16 EINVOICE_TYPE { get; set; } //EINVOICE_TYPE EFATURATİPİ 1 ÖZELMATRAH,2 İSTİSNA ,3 ARAÇ TESCİL 4 TEVKİFAT
        public Int16 EINVOICE_PROFILEID { get; set; } //EINVOICE_PROFILEID EFATURASENARYO 1 İSE TEMEL 2 TİCARİ 
        public Int16 ODEMELIMI { get; set; } //WITH_PAYMENT  -- 0 ÖDEMESİZ 1 ÖDEMELİ
        public int KDVDAHIL { get; set; }
        public int TEVKIFATLI { get; set; }
        public int CURRSELTOTAL { get; set; } //CURRSEL_TOTAL GENEL PARA BİRİMİ BAŞLIK-- 1 RAPORLAMA 2 İŞLEM 3 EURO
        public int CURRSELDETAILS { get; set; } //CURRSEL_DETAILS 0 YEREL 1 RAPORLAMA 2 İŞLEM 3 EURO 4 FİYATLANDIRMA
        public int CREATED_BY { get; set; } //1 GİDECEK
        public double? FIRMARAPORLAMAKURU { get; set; } //RC_RATE
        public double? ISLEMDOVIZKURU { get; set; }//TC_RATE
        public Int16? ISLEMDOVIZIKODU { get; set; }//CURR_TRANSACTIN
        public Int16? AKTARILDIGINDAFIYALANDIRMADOVIZIDEGISSIN { get; set; }//UPD_CURR 
        public Int16? AKTARILDIGINDAISLEMDOVIZIDEGISSIN { get; set; }//UPD_TRCURR
        public string PAZARLAMATIPI { get; set; }
        public int? TANIMLIODEMETIPINUMARASI { get; set; }
        public int? RISKIETKILESIN { get; set; }//AFFECT_RISK
        public string KDVMUAFIYETKODU { get; set; }
        public string KDVMUAFIYETACIKLAMA { get; set; }
        public List<SATIRLAR> SATIRLAR { get; set; }
    }
    public class SATIRLAR
    {
        public int SATIRTIPI { get; set; }
        public int STOKLOGICALREF { get; set; }
        public string STOKKODU { get; set; }
        public string BIRIM { get; set; }
        public string TEVKIFATKODU { get; set; }
        public string TEKLIFSATIRID { get; set; }
        public string SATIRACIKLAMA { get; set; }
        public string FIYATGURUBU { get; set; }
        public DateTime? TESLIMTARIHI { get; set; }
        public int TEVKIFATLI { get; set; }
        public int KDVDAHIL { get; set; }
        public double? TEVKIFATCARPAN { get; set; }
        public double? TEVKIFATBOLEN { get; set; }
        public double MIKTAR { get; set; }
        public double FIYAT { get; set; }
        public double? DOVIZLIFIYAT { get; set; }
        public double? DOVIZKURU { get; set; }
        public Int16? DOVIZKODU { get; set; }
        public Int16 SATIRAMBARNO { get; set; }
        public Int16 SATIRMALIYETAMBAR { get; set; }
        public double KDV { get; set; }
        public double ISKONTO1 { get; set; }
        public double ISKONTO2 { get; set; }
        public double ISKONTO3 { get; set; }
        public string KDVMUAFIYETKODU { get; set; }
        public string KDVMUAFIYETACIKLAMA { get; set; }
    }
}
