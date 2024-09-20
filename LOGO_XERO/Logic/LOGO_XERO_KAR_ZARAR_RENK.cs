using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Logic
{
    public class LOGO_XERO_KAR_ZARAR_RENK
    {
        [Key]
        public int ID { get; set; }
        public int TIP { get; set; }
        public string YUZDEBASLANGIC { get; set; }
        public string RENK { get; set; }
        public string YUZDEBITIS { get; set; }
    }
}
