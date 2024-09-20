using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_M
{
    public class L_CAPIDIV
    {
        [Key]
        public int LOGICALREF { get; set; }

        public Int16? FIRMNR { get; set; }

        public Int16? NR { get; set; }
        public string NUMARA
        {
            get
            {
                return Convert.ToInt32(NR).ToString("000") + ", " + NAME;
            }
        }

        public string NAME { get; set; }

        public string STREET { get; set; }

        public string ROAD { get; set; }

        public string DOORNR { get; set; }

        public string DISTRICT { get; set; }

        public string CITY { get; set; }

        public string COUNTRY { get; set; }

        public string ZIPCODE { get; set; }

        public string PHONE { get; set; }

        public string FAX { get; set; }

        public string TAXOFF { get; set; }

        public string TAXNR { get; set; }

        public string SECURNR { get; set; }

        public Int16? SITEID { get; set; }

        public int? USEREXT { get; set; }

        public string TAXOFFCODE { get; set; }

        public string CNTRYCODE { get; set; }

        public DateTime? MODDATE { get; set; }

        public int? MODTIME { get; set; }

        public string ISKURNR { get; set; }

        public DateTime? FOUNDDATE { get; set; }

        public string ISKURDEPT { get; set; }

        public string INDSECTOR { get; set; }

        public string LOGOID { get; set; }

        public string SGKUSERNAME { get; set; }

        public string SGKUSERCODE { get; set; }

        public string SGKSYSPASS { get; set; }

        public string DIVPASSWORD { get; set; }

        public string ISKURTCKNO { get; set; }

        public string ISKURPASS { get; set; }

        public string CSGBWORKCODE { get; set; }

        public string CSGBFILENO { get; set; }

        public Int16? PASSIVE { get; set; }

        public Int16? USEEINV { get; set; }

        public string POSTLABELCODE { get; set; }

        public string SENDERLABELCODE { get; set; }

        public string WEBADD { get; set; }

        public string EMAILADDR { get; set; }

        public Int16? FIRMTYPE { get; set; }

        public string NACECODE { get; set; }

        public Int16? USEEBOOK { get; set; }

        public string TRADEREGISNO { get; set; }

        public string MERSISNO { get; set; }

        public string TITLE { get; set; }

        public Int16? EBOOKFILENO { get; set; }

        public Int16? USEEARCHIVE { get; set; }

        public string INTSALESADDR { get; set; }

        public DateTime? EBOOKSTARTDATE { get; set; }

        public string EBOOKDIVNAME { get; set; }

        public string EBOOKFIRMNAME { get; set; }

        public string EBOOKFIRMTITLE { get; set; }

        public Int16? EBOOKCURRTYPE { get; set; }

        public Int16? EARCENTSEND { get; set; }

        public string EARCENTUSER { get; set; }

        public string EARCENTPASS { get; set; }

        public string EARCENTDEFADDR { get; set; }

        public int? LASTCONTROLNO { get; set; }

        public int? LASTJOURNALNO { get; set; }

        public int? LASTGLOBLINENO { get; set; }

        public Int16? BACKUPEBOOKS { get; set; }

        public Int16? EINVCUSTOM { get; set; }

        public Int16? EINVOICETYPSGK { get; set; }

        public string TAXPAYERCODE { get; set; }

        public string TAXPAYERNAME { get; set; }

        public Int16? CPATITLE { get; set; }

        public string CPAIDTCNO { get; set; }

        public string CPANAME { get; set; }

        public string CPASURNAME { get; set; }

        public string CPASTREET { get; set; }

        public string CPAROAD { get; set; }

        public string CPADOORNR { get; set; }

        public string CPADISTRICT { get; set; }

        public string CPACITY { get; set; }

        public string CPAPHONE { get; set; }

        public string CPATAXOFF { get; set; }

        public string CPATAXNR { get; set; }

        public string CPACHAMBNR { get; set; }

        public string CPAEMAIL { get; set; }

        public string CPAUSERCODE { get; set; }

        public string CPAPAROLE { get; set; }

        public string CPAPASSWORDTAXDECL { get; set; }

        public string CPACNTRYCODE { get; set; }

        public string CPACOUNTRY { get; set; }

        public string CPAZIPCODE { get; set; }

        public string CPAFAXNR { get; set; }

        public string CPACONTRACTDESC { get; set; }

        public string CPACONTRACTTYPE { get; set; }

        public DateTime? CPACONTRACTDATE { get; set; }

        public string CPACONTRACTNUMBER { get; set; }

        public Int16? CPAISEBOOKKEPTBYFIRM { get; set; }

        public Int16? CPAISYMMCONTRACTMADE { get; set; }

        public string CPAYMMNAME { get; set; }

        public string CPAYMMCONTDESC { get; set; }

        public string CPAYMMCONTTYPE { get; set; }

        public string CPAYMMPHONE { get; set; }

        public string CPAYMMEMAIL { get; set; }

        public string CPAYMMSURNAME { get; set; }

        public DateTime? CPAYMMCONTDATE { get; set; }

        public string CPAYMMCONTNUMBER { get; set; }

        public string CPAYMMFAXNR { get; set; }

        public Int16? USEEDESPATCH { get; set; }

        public string POSTLABELCODEDESP { get; set; }

        public string SENDERLABELCODEDESP { get; set; }

        public Int16? USEEPRODUCERREC { get; set; }

        public Int16? USEETRADESMANINV { get; set; }

        public string LOCBRANCHCODE { get; set; }

        public string LOCBRANCHADDRESSNR { get; set; }

        public Int16? PROPERTYSTATUS { get; set; }

        public Int16? LOCATIONTYPE { get; set; }

        public Int16? EARCHIVETYPE { get; set; }

        public Int16? USEPAPERINV { get; set; }

        public Int16? TRADEREGCODE { get; set; }

        public Int16? ISCCCLIENT { get; set; }

    }
}
