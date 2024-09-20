using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.GenelKullanim
{
    public class STOK_FIYATLISTESI_MODELI
    {
        public bool? KDVDAHIL { get; set; }
        public string YETKIKODU { get; set; }
        public string CARIHESAPOZELKOD { get; set; }
        public string ACIKLAMA { get; set; }
        public string KDV { get; set; }
        public string DOVIZ { get; set; }
        public double? FIYAT { get; set; } 
        public Int16? CURRENCY { get; set; }
    }
}
