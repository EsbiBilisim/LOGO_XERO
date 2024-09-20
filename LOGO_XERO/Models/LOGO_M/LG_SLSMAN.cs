using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_M
{
    public class LG_SLSMAN
    {
        [Key]
        public int LOGICALREF { get; set; }
        public Int16 FIRMNR { get; set; }
        public string CODE { get; set; }
        public string DEFINITION_ { get; set; }
        public Int16 ACTIVE { get; set; }
    }
}
