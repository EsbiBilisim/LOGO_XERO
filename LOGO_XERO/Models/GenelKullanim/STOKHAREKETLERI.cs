using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.GenelKullanim
{
    public class STOKHAREKETLERI
    {
        public string FATURADURUMU { get; set; }
        public int? STFICHEREFERANS { get; set; }
        public int? STLINEREFERANS { get; set; }
        public string FISNO { get; set; }
        public string FISTURU { get; set; }
        public string BELGENO { get; set; }
        public DateTime? STFICHETARIH { get; set; }
        public DateTime? STLINETARIH { get; set; }
        public string SAAT { get; set; }
        public string CARIKODU { get; set; }
        public string CARIUNVANI { get; set; }
        public string STOKKODU { get; set; }
        public string STOKADI { get; set; }
        public string BIRIM { get; set; }
        public string GIRIS { get; set; }
        public string CIKIS { get; set; }
        public string GIRISCIKISTIP { get; set; }
        public string GIRISAMBARI { get; set; }
        public string CIKISAMBARI { get; set; }
        public double? MIKTAR { get; set; }
        public double? KALAN { get; set; }
        public double? TUTAR { get; set; }
        public double? SONFIYAT { get; set; }
    }
}
