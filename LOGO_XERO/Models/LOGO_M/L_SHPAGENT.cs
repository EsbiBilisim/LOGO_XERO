using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_M
{
    public class L_SHPAGENT
    {
        //TAŞIYICI KODU
        [Key]
        public int LOGICALREF { get; set; }

        public string CODE { get; set; }

        public string TITLE { get; set; }

        public string EMAIL { get; set; }

        public string WEBADDR { get; set; }

        public string TRACKINGFORM { get; set; }

        public string ADDR1 { get; set; }

        public string ADDR2 { get; set; }

        public string CITY { get; set; }

        public string CITYCODE { get; set; }

        public string COUNTRY { get; set; }

        public string COUNTRYCODE { get; set; }

        public string TOWN { get; set; }

        public string TOWNCODE { get; set; }

        public string DISTRICT { get; set; }

        public string DISTRICTCODE { get; set; }

        public string POSTCODE { get; set; }

        public string TELNRS1 { get; set; }

        public string TELNRS2 { get; set; }

        public string FAXNR { get; set; }

        public string INCHARGE { get; set; }

        public short? CLANGUAGE { get; set; }

        public short? FIRMTYPE { get; set; }

        public string TAXNR { get; set; }

        public string TCNO { get; set; }

        public string DEFINITION_ { get; set; }

        public string NAME { get; set; }

        public string SURNAME { get; set; }
    }
}
