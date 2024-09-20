using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_XERO_M
{
    public class LOGO_XERO_YETKILER
    {
        public int ID { get; set; }
        public int YETKIID { get; set; }
        public string YETKI { get; set; }
        public int USTYETKIID { get; set; }
        public DateTime KAYITTARIHI { get; set; }
    }
}
