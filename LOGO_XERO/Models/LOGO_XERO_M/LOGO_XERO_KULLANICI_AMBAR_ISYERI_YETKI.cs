using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_XERO_M
{
    public  class LOGO_XERO_KULLANICI_AMBAR_ISYERI_YETKI
    {
        public int ID { get; set; }

        public int? KULLANICIID { get; set; }

        public string FIRMANO { get; set; }

        public short? AMBARID { get; set; }

        public short? ISYERIID { get; set; }
    }
}
