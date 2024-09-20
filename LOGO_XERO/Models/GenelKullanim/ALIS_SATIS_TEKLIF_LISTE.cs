using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models
{
    public class ALIS_SATIS_TEKLIF_LISTE
    {
        public DateTime TARIH { get; set; }
        public string CARIUNVANI { get; set; }
        public string STOKKODU { get; set; }
        public string STOKADI { get; set; }
        public string STOKCINSI2 { get; set; }
        public double? MIKTAR { get; set; }
        public string BIRIM { get; set; }
        public short? DOVIZKODU { get; set; }
        public  string DOVIZ { get; set; }
        public  double? TLFIYAT { get; set; }
        public  double? DOVIZLIFIYAT { get; set; }
        public  double? ISKONTOLUTUTAR { get; set; }
        public  bool KDVDAHIL { get; set; }
    }
}
