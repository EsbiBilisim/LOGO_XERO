using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Logic
{
    public class LOGO_XERO_CARI_BAKIYE
    { 
        public int? LOGICALREF { get; set; }
        public string CARIYETKIKODU { get; set; }
        public string CARIKODU { get; set; }
        public string UNVAN { get; set; }
        public Int16 DURUMU { get; set; }
        public string OZELKOD1 { get; set; }
        public string OZELKOD2 { get; set; }
        public string OZELKOD3 { get; set; }
        public string OZELKOD4 { get; set; }
        public string OZELKOD5 { get; set; }
        public double? BORC { get; set; }
        public double? ALACAK { get; set; }
        public double? BAKIYE { get; set; }
        public DateTime? SONALACAKHAREKETTARIHI { get; set; }
        public string SONALACAKISLEMTURU { get; set; }
        public double? SONALACAKTUTARI { get; set; }
        public DateTime? SONBORCHAREKETTARIHI { get; set; }
        public string SONBORCISLEMTURU { get; set; }
        public double? SONBORCTUTARI { get; set; }
    }
}
