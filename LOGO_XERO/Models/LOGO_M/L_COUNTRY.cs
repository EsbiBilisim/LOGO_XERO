using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models
{
    public class L_COUNTRY
    {
        [Key]
        public int LOGICALREF { get; set; }

        public string CODE { get; set; }

        public string NAME { get; set; }

        public int? COUNTRYNR { get; set; }

        public string STATESTR { get; set; }

        public Int16? SITEID { get; set; }

        public Int16? RECSTATUS { get; set; }

        public int? ORGLOGICREF { get; set; }

        public string NAME2 { get; set; }

        public string EDICODE { get; set; }

        public string NETFLAG { get; set; }
    }
}
