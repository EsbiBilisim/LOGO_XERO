using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_M
{
    public class LG_EMUHACC
    {
        [Key]
        public int LOGICALREF { get; set; }

        public Int16? ACTIVE { get; set; }

        public string CODE { get; set; }

        public string DEFINITION_ { get; set; }

        public string EXTNAME { get; set; }

        public string SPECODE { get; set; }

        public string CYPHCODE { get; set; }

        public string UNITS { get; set; }

        public int? ADDINFOPTR { get; set; }

        public int? CENTERREF { get; set; }

        public int? CURRDIFREF { get; set; }

        public int? SUBACCOUNTS { get; set; }

        public Int16? LEVEL_ { get; set; }

        public Int16? GROUPCODE { get; set; }

        public Int16? ACCTYPE { get; set; }

        public Int16? QUANCTRL { get; set; }

        public Int16? CENTERCTRL { get; set; }

        public int? EXTENREF { get; set; }

        public Int16? CAPIBLOCK_CREATEDBY { get; set; }

        public DateTime? CAPIBLOCK_CREADEDDATE { get; set; }

        public Int16? CAPIBLOCK_CREATEDHOUR { get; set; }

        public Int16? CAPIBLOCK_CREATEDMIN { get; set; }

        public Int16? CAPIBLOCK_CREATEDSEC { get; set; }

        public Int16? CAPIBLOCK_MODIFIEDBY { get; set; }

        public DateTime? CAPIBLOCK_MODIFIEDDATE { get; set; }

        public Int16? CAPIBLOCK_MODIFIEDHOUR { get; set; }

        public Int16? CAPIBLOCK_MODIFIEDMIN { get; set; }

        public Int16? CAPIBLOCK_MODIFIEDSEC { get; set; }

        public Int16? SITEID { get; set; }

        public Int16? RECSTATUS { get; set; }

        public int? ORGLOGICALREF { get; set; }

        public int? WFSTATUS { get; set; }

        public Int16? POSTINGONLY { get; set; }

        public int? CATEGORY { get; set; }

        public string FTFLAGS { get; set; }

        public Int16? MONETARY { get; set; }

        public Int16? PROJECTCTRL { get; set; }

        public Int16? NOTINFLATED { get; set; }

        public int? CURRDIFFDEBTREF { get; set; }

        public int? INFDIFFACCREF { get; set; }

        public Int16? ISANBDGTLINE { get; set; }

        public int? BDGTACCREF { get; set; }

        public int? BDREFLACCREF { get; set; }

        public int? BDGTPAYAREF { get; set; }

        public int? BDPAYREFLAREF { get; set; }

        public Int16? CRBDGTACCLN { get; set; }

        public Int16? CRBDGTPAYALN { get; set; }

        public string CORPCODE1 { get; set; }

        public string CORPCODE2 { get; set; }

        public string CORPCODE3 { get; set; }

        public string CORPCODE4 { get; set; }

        public string FUNCCODE1 { get; set; }

        public string FUNCCODE2 { get; set; }

        public string FUNCCODE3 { get; set; }

        public string FUNCCODE4 { get; set; }

        public string FINCODE { get; set; }

        public string ECOCODE1 { get; set; }

        public string ECOCODE2 { get; set; }

        public string ECOCODE3 { get; set; }

        public string ECOCODE4 { get; set; }

        public int? VATREFLAREF { get; set; }

        public int? VATREFLOTHAREF { get; set; }

        public Int16? CCURRENCY { get; set; }

        public Int16? CURRATETYPE { get; set; }

        public Int16? FIXEDCURRTYPE { get; set; }

        public string CLDEF { get; set; }

        public string TAXNR { get; set; }

        public Int16? FORTAXDECL { get; set; }

        public Int16? VATACC { get; set; }

        public int? GRPTRANSACCREF { get; set; }

        public string SPECODE2 { get; set; }

        public string SPECODE3 { get; set; }

        public string SPECODE4 { get; set; }

        public string SPECODE5 { get; set; }

        public string TCKNO { get; set; }

        public Int16? ISPERSCOMP { get; set; }

        public Int16? ISCASH { get; set; }

        public Int16? TEXTINC { get; set; }

        public Int16? TEXTINCENG { get; set; }

        public int? POSDIFFACCREF { get; set; }

        public int? INFCORRACCREF { get; set; }

        public Int16? PINDEXCALCTYP { get; set; }

        public int? NEGDIFFACCREF { get; set; }

        public int? REFLECTOUTCACCREF { get; set; }

        public Int16? ACCRELCONTROL { get; set; }

        public string GUID { get; set; }

        public int? REFLECTINCACCREF { get; set; }

        public Int16? OPEX { get; set; }
    }
}
