using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.StokEkstresi
{
    public class FATURA_LISTESI_M
    {
        public DateTime? TARIH { get; set; }
        public string FISNO { get; set; }
        public string CARIKODU { get; set; }
        public string CARIUNVANI { get; set; }
        public double? MIKTAR { get; set; }
        public double? FIYAT { get; set; }
        public double? ISK1 { get; set; }
        public double? ISK2 { get; set; }
        public double? ISK3 { get; set; }
        public double? NETFIYAT { get; set; }
        public double? KDV { get; set; }
        public double? KDVTUTARI { get; set; }
        public double? TUTAR { get; set; }
        public double? TOPLAMTUTAR { get; set; }
        public double? DOVIZBIRIMFIYAT { get; set; }
        public string DOVIZTURU { get; set; }
        public double? DOVIZTUTAR { get; set; }
    }
}
