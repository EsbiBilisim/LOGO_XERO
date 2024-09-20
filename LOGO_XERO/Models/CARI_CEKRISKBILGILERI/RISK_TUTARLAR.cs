using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.CARI_CEKRISKBILGILERI
{
    public class RISK_TUTARLAR
    {
        public string CODE { get; set; }
        public string DEFINITION_ { get; set; }
        public int? ID { get; set; }
        public int? CARIREF { get; set; }
        public double? MUSTERITAHSILEDILMEMISCEKCIRORISKI { get; set; }
        public double? KENDIODENMEMISCEKRISKIMIZ { get; set; }
        public double? ODENMEMISSENETRISKI { get; set; }
        public double? CIROCEKSENETRISKTOPLAM { get; set; }
        public double? MUSTERICEKSENETRISKTOPLAM { get; set; }
        public double? MUSTERICEKSENETCIRORISKTOPLAM { get; set; }
        public double? KENDICEKSENETRISKTOPLAM { get; set; }
        public double? ACIKHESAPRISKI { get; set; }
        public double? RISKIASANTOPLAM { get; set; }
        public double? SATISTUTAR { get; set; }
        public double? CIROTUTAR { get; set; }
        public double? CEKRISKKENDI { get; set; }
    }
}
