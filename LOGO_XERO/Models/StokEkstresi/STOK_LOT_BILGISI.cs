using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.StokEkstresi
{
    public class STOK_LOT_BILGISI
    {
        public string KOD { get; set; }
        public string ACIKLAMA { get; set; }
        public string AMBARADI { get; set; }
        public double? GIRIS { get; set; }
        public double? STOKBAKIYESI { get; set; }
    }
}
