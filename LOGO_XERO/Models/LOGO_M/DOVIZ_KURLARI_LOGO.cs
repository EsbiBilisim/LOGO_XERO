using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_M
{
    public class DOVIZ_KURLARI_LOGO
    {
        public int LREF { get; set; }
        public Int16? DOVIZKODU { get; set; }
        public string DOVIZ { get; set; }
        public string DOVIZADI { get; set; }

        public double? RATES1 { get; set; }

        public double? RATES2 { get; set; }

        public double? RATES3 { get; set; }

        public double? RATES4 { get; set; }

        public DateTime? EDATE { get; set; }

        public string CURSYMBOL { get; set; }
    }
}
