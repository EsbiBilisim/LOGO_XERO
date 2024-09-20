using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_M
{
    public class LG_SPECODES
    {
        [Key]
        public int LOGICALREF { get; set; }

        public short CODETYPE { get; set; }

        public short SPECODETYPE { get; set; }

        public string SPECODE { get; set; }

        public string DEFINITION_ { get; set; }

        public short? COLOR { get; set; }

        public int? WINCOLOR { get; set; }

        public short? SITEID { get; set; }

        public short? RECSTATUS { get; set; }

        public int? ORGLOGICREF { get; set; }

        public short? SPETYP1 { get; set; }

        public short? SPETYP2 { get; set; }

        public short? SPETYP3 { get; set; }

        public short? SPETYP4 { get; set; }

        public short? SPETYP5 { get; set; }

        public string GLOBALID { get; set; }

        public string DEFINITION2 { get; set; }

        public string DEFINITION3 { get; set; }
    }
}
