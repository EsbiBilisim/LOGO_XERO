using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_M
{
    public class LG_PROJECT
    {
        [Key]
        public int LOGICALREF { get; set; }

        public string CODE { get; set; }

        public string NAME { get; set; }

        public string SPECODE { get; set; }

        public string CYPHCODE { get; set; }

        public short? CAPIBLOCK_CREATEDBY { get; set; }

        public DateTime? CAPIBLOCK_CREADEDDATE { get; set; }

        public short? CAPIBLOCK_CREATEDHOUR { get; set; }

        public short? CAPIBLOCK_CREATEDMIN { get; set; }

        public short? CAPIBLOCK_CREATEDSEC { get; set; }

        public short? CAPIBLOCK_MODIFIEDBY { get; set; }

        public DateTime? CAPIBLOCK_MODIFIEDDATE { get; set; }

        public short? CAPIBLOCK_MODIFIEDHOUR { get; set; }

        public short? CAPIBLOCK_MODIFIEDMIN { get; set; }

        public short? CAPIBLOCK_MODIFIEDSEC { get; set; }

        public short? ACTIVE { get; set; }

        public short? SITEID { get; set; }

        public short? RECSTATUS { get; set; }

        public int? ORGLOGICREF { get; set; }

        public int? WFSTATUS { get; set; }

        public DateTime? BEGDATE { get; set; }

        public DateTime? ENDDATE { get; set; }

        public string PRJRESPON { get; set; }

        public string GUID { get; set; }

        public short? IOCTRL { get; set; }

        public string SPECODE4 { get; set; }

        public string SPECODE5 { get; set; }

        public string SPECODE2 { get; set; }

        public string SPECODE3 { get; set; }
    }
}
