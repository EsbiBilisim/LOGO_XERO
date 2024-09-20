using System;

namespace LOGO_XERO.Models.LOGO_XERO_M
{
    public class LOGO_XERO_KULLANICILAR
    {
        public int ID { get; set; }
        public string KULLANICIADI { get; set; }
        public string LOGOSATISELEMANIID { get; set; }
        public string SIFRE { get; set; }
        public string TANIMLIFIRMA { get; set; }
        public string TANIMLIDONEM { get; set; }
        public Int16 GIRISISYERI { get; set; }
        public Int16 GIRISBOLUM { get; set; }
        public Int16 GIRISAMBAR { get; set; }
        public Int16 ISYERI { get; set; }
        public Int16 BOLUM { get; set; }
        public Int16 FABRIKA { get; set; }
        public Int16 AMBAR { get; set; }
        public string TELEFON { get; set; }
        public string EPOSTA { get; set; }
        public string ILCE { get; set; }
        public string IL { get; set; }
        public string ADRES { get; set; }
        public int GOREV { get; set; }
        public double TEKLIFTUTARILIMIT { get; set; }
        public string KISITLIOZELKOD { get; set; }
        public double ISKONTOLIMIT { get; set; }
        public string YETKI { get; set; }
        public string MAILSIFRE { get; set; }
    }
}