using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_M
{
    public class L_SHPTYPES
    {
        //TESLİM ŞEKLİ
        [Key]
        public int LOGICALREF { get; set; }

        public string SCODE { get; set; }

        public string SDEF { get; set; }

        public string SDEF2 { get; set; }

        public short? PRICELEVEL { get; set; }

        public string EDICODE { get; set; }
    }
}
