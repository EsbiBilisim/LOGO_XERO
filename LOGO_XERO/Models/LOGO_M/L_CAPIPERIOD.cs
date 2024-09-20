using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_M
{
    public class L_CAPIPERIOD
    {
        [Key]
        public int LOGICALREF { get; set; }

        public Int16? NR { get; set; }

        public Int16? FIRMNR { get; set; }

        public DateTime BEGDATE { get; set; }

        public DateTime ENDDATE { get; set; }

        public Int16? ACTIVE { get; set; }
        public Int16 PERREPCURR { get; set; }

        public string NUM
        {
            get
            {
                return Convert.ToInt32(NR).ToString("00");
            }
        }
        public string NUM2
        {
            get
            {
                return Convert.ToInt32(NR).ToString("00") + " (" + BEGDATE.ToString("dd.MM.yyyy") + "..." + ENDDATE.ToString("dd.MM.yyyy") + ")";
            }
        }
    }
}
