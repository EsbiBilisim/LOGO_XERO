using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.GenelKullanim
{
    public class CariEkstreDovizli
    {
        public string BAYIKODU { get; set; }
        public int CLIENTREF { get; set; }
        public int SREF { get; set; }
        public DateTime? TARIH { get; set; }
        public DateTime? VADETARIHI { get; set; }
        public string FISNO { get; set; }
        public string FISTURU { get; set; }
        public string BELGENO { get; set; }
        public string ACIKLAMA { get; set; }
        public double BORC { get; set; }
        public double ALACAK { get; set; }
        public Int16 PAIDINCASH { get; set; }
        public double BAKIYE { get; set; }
    }
}
