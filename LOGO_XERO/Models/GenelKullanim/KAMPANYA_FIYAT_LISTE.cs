using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.GenelKullanim
{
    public class KAMPANYA_FIYAT_LISTE
    {
        public string KAMPANYAKODU { get; set; }
        public string DOVIZ { get; set; }
        public string LISTEFIYATI { get; set; }
        public string ISKONTOORANI { get; set; }
        public double KAMPANYATLFIYATI { get; set; }
        public double KAMPANYAFIYATI { get; set; } 
        public Int16? DOVIZKODU { get; set; }
    }
}
