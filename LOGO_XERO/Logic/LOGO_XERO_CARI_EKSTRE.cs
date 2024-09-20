using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Logic
{
    public class LOGO_XERO_CARI_EKSTRE
    {
        public string BAYIKODU { get; set; }
        public int CLIENTREF { get; set; } 
        public int SREF { get; set; }
        public DateTime? TARIH { get; set; }
        public string FISNO { get; set; }
        public string FISTURU { get; set; }
        public Int16? TRKOD { get; set; }
        public string CARIUNVANI { get; set; }
        public string BELGENO { get; set; }
        public string PROJEKODU { get; set; }
        public string PROJE { get; set; }

        public string ACIKLAMA { get; set; }
        public double? BORC { get; set; }
        public double? ALACAK { get; set; }
        public double? BAKIYE { get; set; }
    }
}
