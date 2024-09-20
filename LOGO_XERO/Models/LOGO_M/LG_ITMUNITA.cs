using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_M
{
    public class LG_ITMUNITA
    {
        [Key]
        public int LOGICALREF { get; set; }

        public int? ITEMREF { get; set; }

        public Int16? LINENR { get; set; }

        public int? UNITLINEREF { get; set; }

        public string BARCODE { get; set; }

        public Int16? MTRLCLAS { get; set; }

        public Int16? PURCHCLAS { get; set; }

        public Int16? SALESCLAS { get; set; }

        public Int16? MTRLPRIORITY { get; set; }

        public Int16? PURCHPRIORTY { get; set; }

        public Int16? SALESPRIORITY { get; set; }

        public double? WIDTH { get; set; }

        public double? LENGTH { get; set; }

        public double? HEIGHT { get; set; }

        public double? AREA { get; set; }

        public double? VOLUME_ { get; set; }

        public double? WEIGHT { get; set; }

        public int? WIDTHREF { get; set; }

        public int? LENGTHREF { get; set; }

        public int? HEIGHTREF { get; set; }

        public int? AREAREF { get; set; }

        public int? VOLUMEREF { get; set; }

        public int? WEIGHTREF { get; set; }

        public double? GROSSVOLUME { get; set; }

        public double? GROSSWEIGHT { get; set; }

        public int? GROSSVOLREF { get; set; }

        public int? GROSSWGHTREF { get; set; }

        public double? CONVFACT1 { get; set; }

        public double? CONVFACT2 { get; set; }

        public int? EXTACCESSFLAGS { get; set; }

        public Int16? SITEID { get; set; }

        public Int16? RECSTATUS { get; set; }

        public int? ORGLOGICREF { get; set; }

        public string BARCODE2 { get; set; }

        public string BARCODE3 { get; set; }

        public string WBARCODE { get; set; }

        public Int16? WBARCODESHIFT { get; set; }

        public int? VARIANTREF { get; set; }

        public string GLOBALID { get; set; }

        public string FORMULA { get; set; }
    }
}
