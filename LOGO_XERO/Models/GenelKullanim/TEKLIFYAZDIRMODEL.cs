using LOGO_XERO.Models.LOGO_M;
using LOGO_XERO.Models.LOGO_XERO_M;
using System;
using System.Collections.Generic;

namespace LOGO_XERO.Models
{
    public class TEKLIFYAZDIRMODEL
    {
        public string TARIH { get; set; }
        public string SAAT { get; set; }
        public string GELISTARIHI { get; set; }
        public string GELISZAMANI { get; set; }
        public string OPSIYONTARIHI { get; set; }
        public string TEKLIFNO { get; set; }
        public string CARIKODU { get; set; }
        public string CARIUNVANI { get; set; }
        public string CARIVADEKODU { get; set; }
        public string CARIVADEACIKLAMASI { get; set; }
        public string FIYATGURUBU { get; set; }
        public string SATISELEMANI { get; set; }
        public string SATISELEMANIKODU { get; set; }
        public string OZELKOD { get; set; }
        public string YETKIKODU { get; set; }
        public string TANIMLIALANODEMETIPI { get; set; }
        public string ISYERI { get; set; }
        public string BOLUM { get; set; }
        public string AMBAR { get; set; }
        public string FABRIKA { get; set; }
        public string HAZIRLAYAN { get; set; }
        public string EPOSTA { get; set; }
        public string EPOSTA2 { get; set; }
        public string YETKILI { get; set; }
        public string ACIKLAMA { get; set; }
        public string KONU { get; set; }
        public string RAPORLAMADOVIZI { get; set; }
        public string ISLEMDOVIZI { get; set; }
        public double? RAPORLAMADOVIZKURU { get; set; }
        public double? ISLEMDOVIZKURU { get; set; }
        public string PAZARLAYAN { get; set; }
        public string PAZARLAMATIPI { get; set; }
        public string PROJEKODU { get; set; }
        public string PROJEACIKLAMASI { get; set; }
        public string SEVKADRESIKODU { get; set; }
        public string SEVKADRESIACIKLAMASI { get; set; }
        public string SEVKIYATHESABIKODU { get; set; }
        public string SEVKIYATHESABIACIKLAMASI { get; set; }
        public string TESLIMSEKLIKODU { get; set; }
        public string TESLIMSEKLIACIKLAMASI { get; set; }
        public string TASIYICIKODU { get; set; }
        public string TASIYICIACIKLAMASI { get; set; }
        public string DETAYACIKLAMA1 { get; set; }
        public string DETAYACIKLAMA2 { get; set; }
        public string DETAYACIKLAMA3 { get; set; }
        public string DETAYACIKLAMA4 { get; set; }
        public string DETAYACIKLAMA5 { get; set; }
        public string DETAYACIKLAMA6 { get; set; }
        public double? NAKLIYEBEDELI { get; set; }
        public string NOTLARACIKLAMA2 { get; set; }
        public string NOTLARACIKLAMA3 { get; set; }
        public string NOTLAROZELACIKLAMA1 { get; set; }
        public string NOTLAROZELACIKLAMA2 { get; set; }
        public string NOTLAROZELACIKLAMA3 { get; set; }
        public string NOTLARUYARIMESAJI { get; set; }
        public string NOT { get; set; }
        public string TAKIPSONUC { get; set; }
        public string OZELBILGI { get; set; }
        public string ONAYLAYAN { get; set; }
        public string TEKLIFTIPI { get; set; }


        public string FATURABILGIADRES1 { get; set; }
        public string FATURABILGIADRES2 { get; set; }
        public string FATURABILGIULKE { get; set; }
        public string FATURABILGIIL { get; set; }
        public string FATURABILGIILCE { get; set; }
        public string FATURABILGIVERGIDAIRESI { get; set; }
        public string FATURABILGITELEFON { get; set; }
        public string FATURABILGIFAKS { get; set; }
        public string FATURABILGIPOSTAKODU { get; set; }
        public string FATURABILGIVERGINUMARASI { get; set; }


       

        public FIRMABILGI FirmaBilgileri { get; set; }
        public List<SATIRLAR> Satirlar { get; set; }
    }
    public class FIRMABILGI
    {
        public string UNVANI { get; set; }
        public string TELEFON { get; set; }
        public string FAX { get; set; }
        public string MAIL { get; set; }
        public string WEB { get; set; }
        public string VERGIDAIRESI { get; set; }
        public string VERGINUMARASI { get; set; }
        public string TICARETSICILNO { get; set; }
        public string MERSISNO { get; set; }
        public string SOKAK { get; set; }
        public string CADDE { get; set; }
        public string KAPINO { get; set; }
        public string ILCE { get; set; }
        public string SEHIR { get; set; }
        public string ULKE { get; set; }
        public string ADRES { get; set; }
    }

    public class SATIRLAR
    {
        public double? FIYAT { get; set; }
        public double? TLFIYAT { get; set; }
        public double? NETFIYAT { get; set; }
        public double? DOVIZLIFIYAT { get; set; }
        public double? TUTAR { get; set; }
        public double? ISKONTOLUTUTAR { get; set; }
        public double? TOPLAMTUTAR { get; set; }
        public double? KDV { get; set; }
        public double? KDVTUTARI { get; set; }
        public string DOVIZTIPI { get; set; }
        public string RAPORLAMADOVIZTIPI { get; set; }
        public int? SIRANO { get; set; }
        public string STOKKODU { get; set; }
        public string STOKADI { get; set; }
        public string BIRIM { get; set; }
        public string TESLIMSURESI { get; set; }
        public double? MIKTAR { get; set; }
        public string ISKONTOLARTOPLUHALDE { get; set; }
        public double? ISKONTOYUZDESI1 { get; set; }
        public double? ISKONTOYUZDESI2 { get; set; }
        public double? ISKONTOYUZDESI3 { get; set; }
        public short? RAPORLAMADOVIZI { get; set; }
        public short? ISLEMDOVIZI { get; set; }
        public double? RAPORLAMADOVIZKURU { get; set; }
        public double? ISLEMDOVIZKURU { get; set; }
        public short? SATIRDOVIZKODU { get; set; }
        public double? SATIRDOVIZKURU { get; set; }
        public DateTime? DOVIZKURUTARIHI { get; set; }
        public double? TOPLAMINDIRIM { get; set; }
        public double ARATOPLAM { get; set; }
        public double? SATIRISKONTOLUTUTAR { get; set; }
        public double? DOVIZLITUTAR { get; set; }
        public double? DOVIZLIISKONTOLUTUTAR { get; set; }
        public double? DOVIZLITOPLAMINDIRIM { get; set; }
        public double? DOVIZLIKDVTUTARI { get; set; }
        public double? DOVIZLITOPLAMTUTAR { get; set; }
    }
}