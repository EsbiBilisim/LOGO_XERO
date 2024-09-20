using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_M
{
    public class L_CAPIDEPT
    {
        [Key]
        public int LOGICALREF { get; set; }

        public Int16? FIRMNR { get; set; }

        public Int16? NR { get; set; }

        public string NUMARA
        {
            get
            {
                return Convert.ToInt32(NR).ToString("000") + ", " + NAME;
            }
        }
        public string NAME { get; set; }

        public int? USEREXT { get; set; }

        public DateTime? MODDATE { get; set; }

        public int? MODTIME { get; set; }

        public Int16? PASSIVE { get; set; }

        public string NETFLAG { get; set; }
    }
}
