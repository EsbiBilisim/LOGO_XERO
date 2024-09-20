using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_XERO_M
{
    public class PERAKENDE_SATIS_FIYAT
    {
        public string STOKKODU { get; set; }
        public string STOKCINSI { get; set; }
        public double? KDV  { get; set; }
        public Int16? DOVIZKODU  { get; set; }
        public string DOVIZ  { get; set; }
        public double? LISTEFIYATI  { get; set; }
    }
}
