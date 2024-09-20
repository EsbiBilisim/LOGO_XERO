using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_M
{
    public class L_CITY
    {
        [Key]
        public int LOGICALREF { get; set; }

        public int? COUNTRY { get; set; }

        public string NAME { get; set; }

        public string CODE { get; set; }

        public Int16? SITEID { get; set; }

        public Int16? RECSTATUS { get; set; }

        public int? ORGLOGICREF { get; set; }

        public string NAME2 { get; set; }

        public string NETFLAG { get; set; }

    }
}
