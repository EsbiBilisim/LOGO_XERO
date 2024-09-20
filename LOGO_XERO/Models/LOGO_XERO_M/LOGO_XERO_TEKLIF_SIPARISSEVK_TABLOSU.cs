using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_XERO_M
{
    public class LOGO_XERO_TEKLIF_SIPARISSEVK_TABLOSU
    {
        public int ID { get; set; }

        public int TEKLIFID { get; set; }

        public int TEKLIFSATIRID { get; set; }

        public int SIPARISREF { get; set; }

        public int SIPARISSATIRREF { get; set; }

        public int STOKREF { get; set; }

        public double MIKTAR { get; set; }

        public DateTime TARIH { get; set; }

        public int KULLANICIID { get; set; }
    }
}
