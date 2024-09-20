using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_XERO_M
{
    public class LOGO_XERO_DUYURULAR
    {
        public int ID { get; set; }
        public DateTime TARIH { get; set; }
        public string ACIKLAMA { get; set; }
        public string PERSONEL { get; set; }
        public int IPTALID { get; set; }
        public bool ONCELIKLI { get; set; }
    }
}
