using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.GenelKullanim
{
    public class BIRIM_BOYUTLAR
    {
        public int LOGICALREF { get; set; }

        public string CODE { get; set; }

        public string NAME { get; set; }

        public int? UNITSETREF { get; set; }

        public short? LINENR { get; set; }

        public short? MAINUNIT { get; set; }

        public double? CONVFACT1 { get; set; }

        public double? CONVFACT2 { get; set; }

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

        public Int16? DIVUNIT { get; set; }

        public string MEASURECODE { get; set; }

        public string GLOBALCODE { get; set; }
    }
}
