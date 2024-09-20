using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_M
{
    public class L_CURRENCYLIST
    {
        [Key]
        public int LOGICALREF { get; set; }

        public Int16 FIRMNR { get; set; }

        public Int16 CURTYPE { get; set; }

        public string CURCODE { get; set; }

        public string CURNAME { get; set; }

        public Int16? COEF { get; set; }

        public Int16? SUBDIGITS { get; set; }

        public string SUBNAME { get; set; }

        public Int16? DIVFLAG { get; set; }

        public Int16? EMUCURR { get; set; }

        public double? EURORATE { get; set; }

        public Int16? SUBLIMIT { get; set; }

        public string CURSYMBOL { get; set; }

        public Int16? ROUNDMTD { get; set; }

        public Int16? TRIEXCH { get; set; }

        public Int16? CURINUSE { get; set; }

        public string GLOBALID { get; set; }
    }
}
