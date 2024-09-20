using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_M
{
    public class LG_INVDEF
    {
        [NotMapped]
        public double? STOKBAKIYESI { get; set; }



        [Key]
        public int LOGICALREF { get; set; }

        public short? INVENNO { get; set; }

        public int? ITEMREF { get; set; }

        public double? MINLEVEL { get; set; }

        public double? MAXLEVEL { get; set; }

        public double? SAFELEVEL { get; set; }

        public int? LOCATIONREF { get; set; }

        public DateTime? PERCLOSEDATE { get; set; }

        public short? ABCCODE { get; set; }

        public short? MINLEVELCTRL { get; set; }

        public short? MAXLEVELCTRL { get; set; }

        public short? SAFELEVELCTRL { get; set; }

        public short? NEGLEVELCTRL { get; set; }

        public short? IOCTRL { get; set; }

        public int? VARIANTREF { get; set; }

        public short? OUTCTRL { get; set; }
       
        
    }
}
