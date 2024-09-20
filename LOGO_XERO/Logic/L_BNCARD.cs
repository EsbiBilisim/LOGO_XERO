using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Logic
{
    public class L_BNCARD
    {
        [Key]  
        public int? LOGICALREF { get; set; }
        public string HESAP { get; set; }
    }
}
