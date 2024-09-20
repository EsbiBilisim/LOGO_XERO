using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_M
{
    public class L_CAPIFIRM
    {
        [Key]
        public int LOGICALREF { get; set; }

        public Int16? NR { get; set; }

        public string NUM
        {
            get
            {
                return "(" + Convert.ToInt32(NR).ToString("000") + ") " + NAME;
            }
        }

        public string NUM2
        {
            get
            {
                return Convert.ToInt32(NR).ToString("000");
            }
        }

        public string NAME { get; set; }

        public string TITLE { get; set; }

        public string STREET { get; set; }

        public string ROAD { get; set; }

        public string DOORNR { get; set; }

        public string DISTRICT { get; set; }

        public string CITY { get; set; }

        public string COUNTRY { get; set; }

        public string ZIPCODE { get; set; }

        public string PHONE1 { get; set; }

        public string PHONE2 { get; set; }

        public string FAX { get; set; }

        public string TAXOFF { get; set; }

        public string TAXNR { get; set; }

        public string SECURNR { get; set; }

        public string DIRECT { get; set; }

        public string CPANAME { get; set; }

        public string CPASTREET { get; set; }

        public string CPAROAD { get; set; }

        public string CPADOORNR { get; set; }

        public string CPADISTRICT { get; set; }

        public string CPACITY { get; set; }

        public string CPAPHONE { get; set; }

        public string CPATAXOFF { get; set; }

        public string CPATAXNR { get; set; }

        public string CPACHAMBNR { get; set; }

        public Int16? BEGMON { get; set; }

        public Int16? BEGDAY { get; set; }

        public int? USEREXT { get; set; }

        public Int16? PERNR { get; set; }

        public Int16? COUNTOFLEG { get; set; }

        public string CTABLE { get; set; }

        public Int16? WORKDAYFLGS1 { get; set; }

        public Int16? WORKDAYFLGS2 { get; set; }

        public Int16? WORKDAYFLGS3 { get; set; }

        public Int16? WORKDAYFLGS4 { get; set; }

        public Int16? WORKDAYFLGS5 { get; set; }

        public Int16? WORKDAYFLGS6 { get; set; }

        public Int16? WORKDAYFLGS7 { get; set; }

        public Int16? LOCALCTYP { get; set; }

        public Int16? FIRMREPCURR { get; set; }

        public Int16? SEPEXCHTABLE { get; set; }

        public Int16? VATROUNDMTD { get; set; }

        public string FIRMEUVATNUMBER { get; set; }

        public Int16? MAJVERSNR { get; set; }

        public Int16? MINVERSNR { get; set; }

        public Int16? RELVERSNR { get; set; }

        public Int16? SITEID { get; set; }

        public int? ORGCHART { get; set; }

        public Int16? LOCALCALDR { get; set; }

        public Int16? FIRMLANG { get; set; }

        public string TAXOFFCODE { get; set; }

        public string CNTRYCODE { get; set; }

        public Int16? LONGPERIODS { get; set; }

        public string LOGOID { get; set; }

        public string EMAILADDR { get; set; }

        public string WEBADDR { get; set; }

        public DateTime? MODDATE { get; set; }

        public int? MODTIME { get; set; }

        public string TRADEREGISNO { get; set; }

        public string EMPLOYERNAME { get; set; }

        public string EMPLOYERSURNAME { get; set; }

        public string EMPLOYERIDTCNO { get; set; }

        public string EMPLOYEREMAIL { get; set; }

        public Int16? FIRMYTLSTATUS { get; set; }

        public Int16? YTLSOURCEFIRM { get; set; }

        public string ZUSATZNO { get; set; }

        public string TAXOFFSTATECD { get; set; }

        public string TAXOFFSTATENM { get; set; }

        public string STATECODE { get; set; }

        public string STATENAME { get; set; }

        public string CPAOCCUPATION { get; set; }

        public string CPAEXTENSION { get; set; }

        public string CPAEMAIL { get; set; }

        public string CPASURNAME { get; set; }

        public string CPAIDTCNO { get; set; }

        public string ACCOFFICECODE { get; set; }

        public Int16? ADVANCEDPRODUCT { get; set; }

        public string BAGKURNR { get; set; }

        public string USERNAME { get; set; }

        public string DBNAME { get; set; }

        public string PASSWORD { get; set; }

        public Int16? ACTAREA { get; set; }

        public Int16? SECTOR { get; set; }

        public string SRCCRITERIA { get; set; }

        public int? CONSCODEREF { get; set; }

        public string TCELLAPPID { get; set; }

        public string TCELLAPPPW { get; set; }

        public Int16? DNCNSTLEN { get; set; }

        public Int16? USESERVERDATE { get; set; }

        public Int16? USECHANGELOG { get; set; }

        public string MOBUSERNAME { get; set; }

        public string MOBPASSWORD { get; set; }

        public string MOBFIRMALIAS { get; set; }

        public Int16? ACCEPTEINV { get; set; }

        public string EINVOICEID { get; set; }

        public string PROFILEID { get; set; }

        public Int16? USECOMMONPARAM { get; set; }

        public Int16? PASSIVE { get; set; }

        public string USERCODE { get; set; }

        public string PAROLE { get; set; }

        public string PASSWORDTAXDECL { get; set; }

        public string FIRMEMAILADDR { get; set; }

        public Int16? FIRMTYPE { get; set; }

        public string NACECODE { get; set; }

        public string CPACOUNTRY { get; set; }

        public string CPAZIPCODE { get; set; }

        public string CPAFAXNR { get; set; }

        public string CPACNTRYCODE { get; set; }

        public Int16? USEEBOOK { get; set; }

        public string CONTRACTDESC { get; set; }

        public string CONTRACTTYPE { get; set; }

        public DateTime? CONTRACTDATE { get; set; }

        public string CONTRACTNUMBER { get; set; }

        public string HASHVERS { get; set; }

        public string TIMESTAMPUSER { get; set; }

        public string TIMESTAMPPASS { get; set; }

        public string TIMESTAMPSERVER { get; set; }

        public Int16? USEPROXY { get; set; }

        public string PTIMESTAMPUSER { get; set; }

        public string PTIMESTAMPPASS { get; set; }

        public string PTIMESTAMPHOST { get; set; }

        public int? PTIMESTAMPPORT { get; set; }

        public int? TIMESTAMPPORT { get; set; }

        public string TIMESTAMPAPPPTH { get; set; }

        public string JGSERVERURL { get; set; }

        public string JGUSERNAME { get; set; }

        public string JGPASSWORD { get; set; }

        public int? JGCOMPANYNR { get; set; }

        public int? JGPERIODNR { get; set; }

        public string JGHRFIRMCODE { get; set; }

        public double? DEDUCTLIMIT { get; set; }

        public string POSTLABELCODE { get; set; }

        public string SENDERLABELCODE { get; set; }

        public Int16? EINVCONTTYPE { get; set; }

        public Int16? EBOOKCONTTYPE { get; set; }

        public string MERSISNO { get; set; }

        public string OFFICALTITLE { get; set; }

        public Int16? USEEARCHIVE { get; set; }

        public string INTSALESADDR { get; set; }

        public string FAXUSERNAME { get; set; }

        public string FAXUSERKEY { get; set; }

        public string FAXEMAILADDR { get; set; }

        public DateTime? EBOOKSTARTDATE { get; set; }

        public Int16? EBOOKCURRTYPE { get; set; }

        public Int16? EARCENTSEND { get; set; }

        public string EARCENTUSER { get; set; }

        public string EARCENTPASS { get; set; }

        public string EARCENTDEFADDR { get; set; }

        public Int16? CPATITLE { get; set; }

        public Int16? ISEBOOKKEPTBYFIRM { get; set; }

        public Int16? ISYMMCONTRACTMADE { get; set; }

        public string YMMNAME { get; set; }

        public string YMMSURNAME { get; set; }

        public string YMMCONTDESC { get; set; }

        public string YMMCONTTYPE { get; set; }

        public int? YMMCONTDATE { get; set; }

        public string YMMCONTNUMBER { get; set; }

        public int? LASTCONTROLNO { get; set; }

        public int? LASTJOURNALNO { get; set; }

        public int? LASTGLOBLINENO { get; set; }

        public Int16? BACKUPEBOOKS { get; set; }

        public Int16? EINVCUSTOM { get; set; }

        public string YMMPHONE { get; set; }

        public string YMMFAXNR { get; set; }

        public string YMMEMAIL { get; set; }

        public Int16? EINVOICETYPSGK { get; set; }

        public string TAXPAYERCODE { get; set; }

        public string TAXPAYERNAME { get; set; }

        public string YMMCHAMBNR { get; set; }

        public string YMMTCNO { get; set; }
    }
}
