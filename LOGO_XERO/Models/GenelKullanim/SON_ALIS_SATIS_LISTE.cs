using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.GenelKullanim
{
    public class SON_ALIS_SATIS_LISTE
    {
        public string  FISTIPI { get; set; }
        public DateTime  TARIH { get; set; }
        public int?  FATURAREF { get; set; }
        public int?  LOGICALREF { get; set; }
        public string  STOKKODU { get; set; }
        public string  STOKCINSI { get; set; }
        public string  STOKCINSI2 { get; set; }
        public double  MIKTAR { get; set; }
        public Int16?  DOVIZKODU { get; set; }
        public string  DOVIZ { get; set; }
        public double?  TL_FIYAT { get; set; }
        public double  FIYAT { get; set; }
        public double?  ISK { get; set; }
        public double?  NETFIYAT { get; set; }
        public double?  ISKONTOLUTUTAR { get; set; }
        public string  MUSTERIUNVANI { get; set; }
        public string  MUSTERIKODU { get; set; }
        public bool  KDVDAHIL { get; set; }
    }
}
