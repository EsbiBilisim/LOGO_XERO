using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.StokEkstresi
{
    public class TEKLIF_LISTESI_M
    {
        public DateTime? TARIH { get; set; }
        public string TEKLIFNO { get; set; }
        public string CARIUNVANI { get; set; }
        public string STOKKODU { get; set; }
        public string STOKADI { get; set; }
        public string BIRIM { get; set; }
        public double? MIKTAR { get; set; }
        public double? FIYAT { get; set; }
        public double? KDV { get; set; }
        public double? ISKONTOYUZDESI1 { get; set; }
        public double? ISKONTOYUZDESI2 { get; set; }
        public double? ISKONTOYUZDESI3 { get; set; }
        public double? TUTAR { get; set; }
        public double? DOVIZLIFIYAT { get; set; }
        public double? DOVIZLITOPLAMFIYAT { get; set; }
        public string DOVIZTURU { get; set; }
    }
}
