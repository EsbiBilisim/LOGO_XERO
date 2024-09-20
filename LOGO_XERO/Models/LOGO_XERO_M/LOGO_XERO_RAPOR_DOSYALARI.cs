using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_XERO_M
{
    public class LOGO_XERO_RAPOR_DOSYALARI
    {
        public int ID { get; set; }
        public int SABLON { get; set; }
        public bool AKTIF { get; set; }
        public string MODUL { get; set; }
        public string RAPORADI { get; set; }
        public bool VARSAYILAN { get; set; }
        public byte[] DOSYA { get; set; }
        public bool DOVIZLI { get; set; }
    }
}
