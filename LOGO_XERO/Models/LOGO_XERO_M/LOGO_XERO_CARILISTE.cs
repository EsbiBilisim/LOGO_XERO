using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_XERO_M
{
    public class LOGO_XERO_CARILISTE
    {
        [Key]
        public int LOGICALREF { get; set; }
        public Int16 CARDTYPE { get; set; }
        public string CODE { get; set; }
        public string DEFINITION_ { get; set; }
        public string TICARIISLEMGURUBU { get; set; }
        public string OZELKOD1 { get; set; }
        public string OZELKOD2 { get; set; }
        public string OZELKOD3 { get; set; }
        public string OZELKOD4 { get; set; }
        public string OZELKOD5 { get; set; }
        public string ADI { get; set; }
        public string SOYADI { get; set; }
        public string ADRES1 { get; set; }
        public string ADRES2 { get; set; }
        public string TELEFON1 { get; set; }
        public string TELEFON2 { get; set; }
        public string ULKEKODU { get; set; }
        public string ULKE { get; set; }
        public string SEHIR { get; set; }
        public string ILCE { get; set; }
        public string VERGIDAIRESI { get; set; }
        public string TCKNO { get; set; }
        public string FAXNR { get; set; }
        public string POSTAKODU { get; set; }
        public string TAXNR { get; set; }
        public string YETKILISI { get; set; }
        public string YETKIKODU { get; set; }
        public Int16? EFATURA { get; set; }
        public string EPOSTA { get; set; }
        public string EPOSTA2 { get; set; }
        public string EPOSTA3 { get; set; }
        public Int16? SAHISSIRKETI { get; set; }
        public int? PAYMENTREF { get; set; }
        public double? BAKIYE { get; set; }
        public string MUHASEBEKODU { get; set; }
        public string ODEMEPLANKODU { get; set; }
        public string ODEMEPLANI { get; set; }

    }
}
