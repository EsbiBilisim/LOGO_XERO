using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Logic
{
    public class LOGO_XERO_FATURALANMAMIS_IRSALIYE
    {  
        [Key]
        public int LOGREF { get; set; }
        public DateTime? TARIH { get; set; }
        public string FISNO { get; set; }
        public string FISTURU { get; set; }
        public int? CARILOG { get; set; }
        public string CARIKODU { get; set; }
        public string OZELKOD { get; set; }
        public string CARIUNVANI { get; set; }
        public double? KDVTUTARI { get; set; }
        public string STATU { get; set; }
        public double? TOPLAMTUTAR { get; set; }
        public double? TOTALDISCOUNTED { get; set; }
        public double? GROSSTOTAL { get; set; }
        public double? NETTOTAL { get; set; }
        public Int16? BILLED { get; set; }
        public Int16 DURUMU { get; set; } 
        public Int16 BOLUM { get; set; } 
        public Int16 AMBAR { get; set; } 
        public Int16 ISYERI { get; set; } 
        public int CODE { get; set; } 
        public string DURUMU1 { get; set; }
        
        public Int16 EIRSALIYEDURUMU { get; set; } 
    }
}
