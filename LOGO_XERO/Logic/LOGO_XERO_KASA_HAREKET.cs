using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Logic
{
    public class LOGO_XERO_KASA_HAREKET
    {
        public int LOGICALREF { get; set; }
        public string CODE { get; set; }
        public string KasaAdi { get; set; }
        public DateTime? Tarih { get; set; }
        public string IslemTuru { get; set; }
        public string FisNo { get; set; }

        public string KasaAciklamasi { get; set; }
        public string SatirAciklamasi { get; set; }

        public string DovizTuru { get; set; }
        public double? Borc { get; set; }
        public double? Alacak { get; set; }
        public double? Bakiye { get; set; }
        public double? BAKIYERUNNING { get; set; }
    }
}
