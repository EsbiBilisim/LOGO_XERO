using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.GenelKullanim
{
    public class STOKALISSATISHAREKETLERI
    {
        public string FATURADURUMU { get; set; }
        public int INVOICEREF { get; set; }
        public string FISNO { get; set; }
        public int STFICHEREF { get; set; }
        public string FISTURU { get; set; }
        public string CARIKODU { get; set; }
        public string CARIUNVANI { get; set; }
        public DateTime? TARIH { get; set; }
        public string STOKKODU { get; set; }
        public string STOKCINSI { get; set; }
        public double? MIKTAR { get; set; }
        public string BIRIM { get; set; }
        public double? FIYAT { get; set; }
        public double? DOVIZBIRIMFIYAT { get; set; }
        public string DOVIZTURU { get; set; }
        public double? TUTAR { get; set; }
        public double? DOVIZTUTAR { get; set; }
    }
}
