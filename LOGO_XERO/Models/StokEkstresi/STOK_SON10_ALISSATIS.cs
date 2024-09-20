using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.StokEkstresi
{
    public class STOK_SON10_ALISSATIS
    {
        public DateTime? TARIH { get; set; }
        public string FISTURU { get; set; }
        public string CARIKODU { get; set; }
        public string CARIUNVANI { get; set; }

        public double? ADET { get; set; }
        public double? FIYAT { get; set; }
        public double? DOVIZBIRIMFIYAT { get; set; }
        public string DOVIZTIPI { get; set; }
        public double? KDV { get; set; }
        public double? KDVTUTARI { get; set; }
        public double? TUTAR { get; set; }
        public double? DOVIZTUTAR { get; set; }
        public double? TOPLAMTUTAR { get; set; }
    }
}
