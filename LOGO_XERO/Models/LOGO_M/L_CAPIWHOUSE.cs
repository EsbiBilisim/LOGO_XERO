using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_M
{
    public class L_CAPIWHOUSE
    {
        [Key]
        public int LOGICALREF { get; set; }

        public Int16? FIRMNR { get; set; }

        public Int16? NR { get; set; }

        public string NUMARA
        {
            get
            {
                return Convert.ToInt32(NR).ToString("000") + ", " + NAME;
            }
        }

        public string NAME { get; set; }

        public Int16? DIVISNR { get; set; }

        public Int16? FACTNR { get; set; }

        public Int16? COSTGRP { get; set; }

        public Int16? SITEID { get; set; }

        public int? USEREXT { get; set; }

        public DateTime? MODDATE { get; set; }

        public int? MODTIME { get; set; }

        public Int16? VIRTUALINVEN { get; set; }

        public string LONGITUDE { get; set; }

        public string LATITUTE { get; set; }

        public string ADDR1 { get; set; }

        public string ADDR2 { get; set; }

        public string TOWNCODE { get; set; }

        public string TOWN { get; set; }

        public string DISTRICTCODE { get; set; }

        public string DISTRICT { get; set; }

        public string CITYCODE { get; set; }

        public string CITY { get; set; }

        public string COUNTRYCODE { get; set; }

        public string COUNTRY { get; set; }

        public string TELCODES1 { get; set; }

        public string TELCODES2 { get; set; }

        public string TELNRS1 { get; set; }

        public string TELNRS2 { get; set; }

        public string TELEXTNUMS1 { get; set; }

        public string TELEXTNUMS2 { get; set; }

        public string EMAILADDR { get; set; }

        public string SHPAGNCOD { get; set; }

        public string POSTCODE { get; set; }

        public Int16? AREACODE { get; set; }
    }
}
