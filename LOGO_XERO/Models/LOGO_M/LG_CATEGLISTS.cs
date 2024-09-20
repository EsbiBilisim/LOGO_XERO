using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_M
{
    public class LG_CATEGLISTS
    {
        [Key]
        public int LOGICALREF { get; set; }

        public int? CATEGID { get; set; }

        public Int16? LINENO_ { get; set; }

        public int TAG { get; set; }

        public string CATDESC { get; set; }

        public Int16? CUSTOM { get; set; }

        public int RECORDID { get; set; }
    }
}
