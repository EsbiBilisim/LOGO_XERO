using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.GenelKullanim
{
    public class CariEkstreDovizliDetay
    {
        public int FISNO { get; set; }
        public string STOKKODU { get; set; }
        public string STOKCINSI { get; set; }
        public string ACIKLAMA { get; set; }
        public double MIKTAR { get; set; }
        public double FIYAT { get; set; }
        public double KDV { get; set; }
        public double TUTAR { get; set; }
    }
}
