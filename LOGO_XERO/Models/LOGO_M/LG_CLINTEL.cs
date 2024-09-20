using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_M
{
    public class LG_CLINTEL
    {
        [Key]
        public int LOGICALREF { get; set; }

        public int? CLIENTREF { get; set; }

        public Int16 LINENUM { get; set; }

        public string INTELLINE { get; set; }
    }
}
