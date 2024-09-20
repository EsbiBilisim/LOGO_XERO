using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_M
{
    public class LG_UNITSETL
    {
        [Key]
        public int LOGICALREF { get; set; }

        public string CODE { get; set; }

        public string NAME { get; set; }

        public int? UNITSETREF { get; set; }

        public Int16? LINENR { get; set; }

        public Int16? MAINUNIT { get; set; }

        public double? CONVFACT1 { get; set; }

        public double? CONVFACT2 { get; set; }

        public double? WIDTH { get; set; }

        public double? LENGTH { get; set; }

        public double? HEIGHT { get; set; }

        public double? AREA { get; set; }

        public double? VOLUME_ { get; set; }
        [NotMapped]
        public double? GROSSVOLUME { get; set; }
        [NotMapped]
        public double? GROSSWEIGHT { get; set; }

        public double? WEIGHT { get; set; }

        public int? WIDTHREF { get; set; }

        public int? LENGTHREF { get; set; }

        public int? HEIGHTREF { get; set; }

        public int? AREAREF { get; set; }

        public int? VOLUMEREF { get; set; }

        public int? WEIGHTREF { get; set; }

        public Int16? DIVUNIT { get; set; }

        public string MEASURECODE { get; set; }

        public string GLOBALCODE { get; set; }
        [NotMapped]
        public string BUTONEN { get; set; }
        [NotMapped]
        public string BUTONBOY { get; set; }
        [NotMapped]
        public string BUTONYUKSEKLIK { get; set; }
        [NotMapped]
        public string BUTONALAN { get; set; }
        [NotMapped]
        public string BUTONBRUTRAGIRLIK { get; set; }
        [NotMapped]
        public string BUTONNETAGIRLIK { get; set; }
        [NotMapped]
        public string BUTONBRUTHACIM { get; set; }
        [NotMapped]
        public string BUTONNETHACIM { get; set; }
        [NotMapped]
        public string BUTONBARKOD { get; set; }
        [NotMapped]
        public int DEGISTI { get; set; }
        [NotMapped]
        public bool CHECKOTOMATIKBARKOD { get; set; }
    }
}
