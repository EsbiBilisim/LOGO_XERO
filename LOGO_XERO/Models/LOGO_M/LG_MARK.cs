using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_M
{
    public class LG_MARK
    {
        [Key]
        public int LOGICALREF { get; set; }

        public string CODE { get; set; }

        public string DESCR { get; set; }

        public string SPECODE { get; set; }

        public string CYPHCODE { get; set; }

        public Int16? CAPIBLOCK_CREATEDBY { get; set; }

        public DateTime? CAPIBLOCK_CREADEDDATE { get; set; }

        public Int16? CAPIBLOCK_CREATEDHOUR { get; set; }

        public Int16? CAPIBLOCK_CREATEDMIN { get; set; }

        public Int16? CAPIBLOCK_CREATEDSEC { get; set; }

        public Int16? CAPIBLOCK_MODIFIEDBY { get; set; }

        public DateTime? CAPIBLOCK_MODIFIEDDATE { get; set; }

        public Int16? CAPIBLOCK_MODIFIEDHOUR { get; set; }

        public Int16? CAPIBLOCK_MODIFIEDMIN { get; set; }

        public Int16? CAPIBLOCK_MODIFIEDSEC { get; set; }

        public Int16? SITEID { get; set; }

        public Int16? RECSTATUS { get; set; }

        public int? ORGLOGICREF { get; set; }
    }
}
