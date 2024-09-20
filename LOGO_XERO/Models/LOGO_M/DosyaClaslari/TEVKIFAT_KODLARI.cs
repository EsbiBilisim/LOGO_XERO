using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LOGO_XERO.Models.LOGO_M.DosyaClaslari
{
    [XmlRoot(ElementName = "DEDUCTCODE")]
    public class DEDUCTCODE
    {

        [XmlElement(ElementName = "CODE")]
        public string CODE { get; set; }

        [XmlElement(ElementName = "NAME")]
        public string NAME { get; set; }

        [XmlElement(ElementName = "DEDUCTRATE")]
        public string DEDUCTRATE { get; set; }

        [XmlAttribute(AttributeName = "DBOP")]
        public string DBOP { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "DEDUCT_CODE")]
    public class DEDUCT_CODE
	{

        [XmlElement(ElementName = "DEDUCTCODE")]
        public List<DEDUCTCODE> DEDUCTCODE { get; set; }
	}
}
