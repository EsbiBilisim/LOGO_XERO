using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LOGO_XERO.Models.LOGO_M.DosyaClaslari
{
	[XmlRoot(ElementName = "VATEXCEPTREASON")]
	public class VATEXCEPTREASON
	{
		[XmlElement(ElementName = "CODE")]
		public string CODE { get; set; }
		[XmlElement(ElementName = "NAME")]
		public string NAME { get; set; }
		[XmlAttribute(AttributeName = "DBOP")]
		public string DBOP { get; set; }
	}

	[XmlRoot(ElementName = "VATEXCEPT_REASON")]
	public class VATEXCEPT_REASON
	{
		[XmlElement(ElementName = "VATEXCEPTREASON")]
		public List<VATEXCEPTREASON> VATEXCEPTREASON { get; set; }
		[XmlElement(ElementName = "TURU")]
		public List<string> TURU { get; set; }
	}
}
