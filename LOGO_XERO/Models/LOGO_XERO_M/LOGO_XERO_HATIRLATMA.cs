using DevExpress.XtraEditors.Filtering.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_XERO_M
{
    public class LOGO_XERO_HATIRLATMA
    {
        //TEKLIF SATIS -1 
        //TEKLIF ALIS  -2
        public int ID { get; set; }
        public int TIP { get; set; }
        public int TEKLIFID { get; set; }
        public string PERSONEL { get; set; }
        public DateTime TARIH { get; set; }
        public DateTime HATIRLATMATARIHI { get; set; }
        public string TEKLIFNO { get; set; }
        public string ACIKLAMA { get; set; }
        public bool OKUNDU { get; set; }
    }
}
