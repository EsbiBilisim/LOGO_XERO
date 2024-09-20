using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_XERO_M
{
    public class LOGO_XERO_DOVIZ_BILGILERI
    {
        
        public int ID { get; set; }

        public int FIRMANO { get; set; }

        public int? LOGICALREF { get; set; }

        public short? DOVIZKODU { get; set; }

        public string DOVIZCINSI { get; set; }

        public string ACIKLAMA { get; set; }

        public string SEMBOL { get; set; }
    }
}
