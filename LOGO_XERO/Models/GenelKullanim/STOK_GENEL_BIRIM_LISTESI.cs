using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.GenelKullanim
{
    public class STOK_GENEL_BIRIM_LISTESI
    {
        public int LOGICALREF { get; set; }
        public string BIRIMKODU { get; set; }
        public string BIRIMACIKLAMA { get; set; }
        public double CONVFACT1 { get; set; }
        public double CONVFACT2 { get; set; }
        [NotMapped]
        public double BOL { get; set; }
    }
}
