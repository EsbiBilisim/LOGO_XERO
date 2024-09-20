using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_M
{
    public class LG_UNITBARCODE
    {
            [Key]
            public int LOGICALREF { get; set; }
            public int? ITMUNITAREF { get; set; }
            public int ITEMREF { get; set; }
            public int? VARIANTREF { get; set; }
            public int? UNITLINEREF { get; set; }
            public short LINENR { get; set; }
            public string BARCODE { get; set; }
            public short? SITEID { get; set; }
            public short? RECSTATUS { get; set; }
            public int? ORGLOGICREF { get; set; }
            public short? TYP { get; set; }
            public short? WBARCODESHIFT { get; set; }
            public string GLOBALID { get; set; }
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
    }
}
