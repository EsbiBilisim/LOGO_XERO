using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Logic
{
    public class LOGO_XERO_BANKA_HAREKET
    {
        public int? BNLLOG { get; set; }
        public DateTime? Tarih { get; set; }
        public string CODE { get; set; }
        public string BankaAdi { get; set; }
        public int? CARILOG { get; set; }
        public string CARIKODU { get; set; }
        public string CARIUNVANI { get; set; }
        public string IslemTuru { get; set; }
        public int? HESAPLOG { get; set; }
        public string HESAPADI { get; set; }
        //public string HESAPNO { get; set; }
        // public string HESAPKODU { get; set; }
        public string BANKAIBAN { get; set; }
        public string ACIKLAMA { get; set; }
        public string HAREKETTURU { get; set; }
        public double? BORC { get; set; }
        public double? ALACAK { get; set; }
        public double? BAKIYE { get; set; }
        public double? BAKIYERUNNING { get; set; }

        public string BANKAHESAPDETAYI { get; set; }
    }
}
