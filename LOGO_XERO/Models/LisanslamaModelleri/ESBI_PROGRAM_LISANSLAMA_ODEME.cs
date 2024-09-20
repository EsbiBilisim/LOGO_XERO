using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.LisanslamaModelleri
{
    public class ESBI_PROGRAM_LISANSLAMA_ODEME
    {
        public int ID { get; set; }

        public DateTime? TARIH { get; set; }

        public string GUID { get; set; }

        public string ANAHTAR { get; set; }

        public string LISANSNUMARASI { get; set; }

        public string FIRMAUNVANI { get; set; }

        public string FIRMATCVKN { get; set; }

        public int? LISANSSTOKREFERANS { get; set; }

        public string LISANSSTOKADI { get; set; }

        public double? LISANSUCRETI { get; set; }

        public int? ODEMEALINDI { get; set; }
        public int DEMO { get; set; }
        public DateTime? ODEMEALINMAZAMANI { get; set; }
    }
}
