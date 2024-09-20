using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_XERO_M
{
    public class LOGO_XERO_GORUSMELER
    {
        public int ID { get; set; }
        public int TIP { get; set; }
        public int TEKLIFID { get; set; }
        public DateTime TARIH { get; set; }
        public int PERSONELID { get; set; }
        public string PERSONEL { get; set; }
        public string ACIKLAMA { get; set; }
    }
}
