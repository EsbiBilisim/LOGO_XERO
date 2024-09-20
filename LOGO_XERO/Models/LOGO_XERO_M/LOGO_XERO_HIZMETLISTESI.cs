using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_XERO_M
{
    public class LOGO_XERO_HIZMETLISTESI
    {
        [Key]
        public int LOGICALREF { get; set; }
        public string OZELKOD { get; set; }
        public string STOKKODU { get; set; }
        public string STOKCINSI { get; set; }
        public string ACIKLAMA3 { get; set; }
        public string ACIKLAMA4 { get; set; }
        public string MARKA { get; set; }
        public string OZELKOD1 { get; set; }
        public string OZKODACIKLAMA { get; set; }
        public string OZELKOD2 { get; set; }
        public string OZELKOD3 { get; set; }
        public string OZELKOD4 { get; set; }
        public string OZELKOD5 { get; set; }
        public string YETKIKODU { get; set; }
        public double? KDV { get; set; }
        public Int16 MINMIKTAR { get; set; }
        public double STOKBAKIYE { get; set; }
        public Int32 LOTTID { get; set; }
        public double PRKSATISFIYATI { get; set; }
        public double? DESI { get; set; }
        public short TEVKIFAT { get; set; }
        public string TEVKIFATKODU { get; set; }
        public short? TEVKIFATCARPAN { get; set; }
        public short? TEVKIFATBOLEN { get; set; }
        public int? UNITSETREF { get; set; }
        public Int32 KDVDURUMU { get; set; }
        public short? DOVIZKODU { get; set; }
        public double LISTEFIYATI { get; set; }
        public string DOVIZ { get; set; }
        public string BARKOD { get; set; }
        public string BARKOD2 { get; set; }
        public string BIRIM { get; set; }
    }
}
