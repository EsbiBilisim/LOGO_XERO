using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_M
{
    public  class LG_PAYLINES
    {
        [Key]
        public int LOGICALREF { get; set; }

        public int? PAYPLANREF { get; set; }

        public Int16? LINENO_ { get; set; }

        public Int16? AFTERDAYS { get; set; }

        public string FORMULA { get; set; }

        public string CONDITION { get; set; }

        public string DAY_ { get; set; }

        public string MOUNTH { get; set; }

        public string YEAR_ { get; set; }

        public double? RNDVALUE { get; set; }

        public DateTime? ABSDATE { get; set; }

        public Int16? DATETYPE { get; set; }

        public double? DISCRATE { get; set; }

        public Int16? PAYMENTTYPE { get; set; }

        public int? BANKACCREF { get; set; }

        public int? REPAYDEFREF { get; set; }

        public Int16? TRCURR { get; set; }

        public string GLOBALCODE { get; set; }

        public int? CASHREF { get; set; }
    }
}
