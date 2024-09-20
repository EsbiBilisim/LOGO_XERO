using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Logic
{
    public class LOGO_XERO_KAR_ZARAR_ANALIZ
    {
        public int STLOG { get; set; }
        public string SATISELEMANI { get; set; }
        public int STOCKREF { get; set; }
        public DateTime? IRSALIYETARIHI { get; set; }
        public DateTime? FATURATARIHI { get; set; }
        public string FATURANO { get; set; }
        public string FISTURU { get; set; }
        public string STOKKODU { get; set; }
        public string STOKADI { get; set; }
        public double? CARIBAKIYE { get; set; }
        public int? CARILOG { get; set; }
        public string CARIKODU { get; set; }
        public string CARIOZELKOD { get; set; }
        public string CARIOZELKOD2 { get; set; }
        public string CARIOZELKOD3 { get; set; }
        public string CARIOZELKOD4 { get; set; }
        public string CARIOZELKOD5 { get; set; }
        public string CARIUNVANI { get; set; }
        public string STOKOZELKOD { get; set; }
        public string STOKOZELKOD2 { get; set; }
        public string STOKOZELKOD3 { get; set; }
        public string STOKOZELKOD4 { get; set; }
        public string STOKOZELKOD5 { get; set; }
        public double? MIKTAR { get; set; }
        public double? BIRIMSATISFIYATI { get; set; }
        public double? KDVHARICNETTUTARI { get; set; }
        public double? KDVTUTARI { get; set; }
        public double? KDVDAHILNETTUTARI { get; set; }
        public string FISTIPI { get; set; }
        public double? KARFIYATI { get; set; }
        public double? KARYUZDE { get; set; }
        public double? KARTUTARI { get; set; }
        public string AMBAR { get; set; }
        public string BOLUM { get; set; }
        public string MARKA { get; set; }
        public double? HAREKETSONALISFIYATI { get; set; }
        public DateTime? HAREKETSONALISTARIHI { get; set; }
        public double? ENSONALISFIYATI { get; set; }
        public DateTime? ENSONALISTARIHI { get; set; }
        public string FATURATIPI { get; set; }
        public double? STOKBAKIYESI { get; set; }
        [NotMapped]
        public double? ENSONALISCARPMIKTAR { get; set; }
        [NotMapped]
        public double? HAREKETONCESISONALISCARPMIKTAR { get; set; }
        public int? KARHESAPLAMASONALISLOGICALREF { get; set; }
    }
}
