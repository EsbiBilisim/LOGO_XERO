using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_M
{
    public class LG_CLCARD
    {
        [Key]
        public int LOGICALREF { get; set; }

        public short? ACTIVE { get; set; }

        public short? CARDTYPE { get; set; }

        public string CODE { get; set; }

        public string DEFINITION_ { get; set; }

        public string SPECODE { get; set; }

        public string CYPHCODE { get; set; }

        public string ADDR1 { get; set; }

        public string ADDR2 { get; set; }

        public string CITY { get; set; }

        public string COUNTRY { get; set; }

        public string POSTCODE { get; set; }

        public string TELNRS1 { get; set; }

        public string TELNRS2 { get; set; }

        public string FAXNR { get; set; }

        public string TAXNR { get; set; }

        public string TAXOFFICE { get; set; }

        public string INCHARGE { get; set; }

        public double? DISCRATE { get; set; }

        public int? EXTENREF { get; set; }

        public int? PAYMENTREF { get; set; }

        public string EMAILADDR { get; set; }

        public string WEBADDR { get; set; }

        public short? WARNMETHOD { get; set; }

        public string WARNEMAILADDR { get; set; }

        public string WARNFAXNR { get; set; }

        public short? CLANGUAGE { get; set; }

        public string VATNR { get; set; }

        public short? BLOCKED { get; set; }

        public string BANKBRANCHS1 { get; set; }

        public string BANKBRANCHS2 { get; set; }

        public string BANKBRANCHS3 { get; set; }

        public string BANKBRANCHS4 { get; set; }

        public string BANKBRANCHS5 { get; set; }

        public string BANKBRANCHS6 { get; set; }

        public string BANKBRANCHS7 { get; set; }

        public string BANKACCOUNTS1 { get; set; }

        public string BANKACCOUNTS2 { get; set; }

        public string BANKACCOUNTS3 { get; set; }

        public string BANKACCOUNTS4 { get; set; }

        public string BANKACCOUNTS5 { get; set; }

        public string BANKACCOUNTS6 { get; set; }

        public string BANKACCOUNTS7 { get; set; }

        public string DELIVERYMETHOD { get; set; }

        public string DELIVERYFIRM { get; set; }

        public short? CCURRENCY { get; set; }

        public short? TEXTINC { get; set; }

        public short? SITEID { get; set; }

        public short? RECSTATUS { get; set; }

        public int? ORGLOGICREF { get; set; }

        public string EDINO { get; set; }

        public string TRADINGGRP { get; set; }

        public short? CAPIBLOCK_CREATEDBY { get; set; }

        public DateTime? CAPIBLOCK_CREADEDDATE { get; set; }

        public short? CAPIBLOCK_CREATEDHOUR { get; set; }

        public short? CAPIBLOCK_CREATEDMIN { get; set; }

        public short? CAPIBLOCK_CREATEDSEC { get; set; }

        public short? CAPIBLOCK_MODIFIEDBY { get; set; }

        public DateTime? CAPIBLOCK_MODIFIEDDATE { get; set; }

        public short? CAPIBLOCK_MODIFIEDHOUR { get; set; }

        public short? CAPIBLOCK_MODIFIEDMIN { get; set; }

        public short? CAPIBLOCK_MODIFIEDSEC { get; set; }

        public short? PAYMENTPROC { get; set; }

        public short? CRATEDIFFPROC { get; set; }

        public int? WFSTATUS { get; set; }

        public string PPGROUPCODE { get; set; }

        public int? PPGROUPREF { get; set; }

        public string TAXOFFCODE { get; set; }

        public string TOWNCODE { get; set; }

        public string TOWN { get; set; }

        public string DISTRICTCODE { get; set; }

        public string DISTRICT { get; set; }

        public string CITYCODE { get; set; }

        public string COUNTRYCODE { get; set; }

        public short? ORDSENDMETHOD { get; set; }

        public string ORDSENDEMAILADDR { get; set; }

        public string ORDSENDFAXNR { get; set; }

        public short? DSPSENDMETHOD { get; set; }

        public string DSPSENDEMAILADDR { get; set; }

        public string DSPSENDFAXNR { get; set; }

        public short? INVSENDMETHOD { get; set; }

        public string INVSENDEMAILADDR { get; set; }

        public string INVSENDFAXNR { get; set; }

        public short? SUBSCRIBERSTAT { get; set; }

        public string SUBSCRIBEREXT { get; set; }

        public string AUTOPAIDBANK { get; set; }

        public short? PAYMENTTYPE { get; set; }

        public int? LASTSENDREMLEV { get; set; }

        public int? EXTACCESSFLAGS { get; set; }

        public short? ORDSENDFORMAT { get; set; }

        public short? DSPSENDFORMAT { get; set; }

        public short? INVSENDFORMAT { get; set; }

        public short? REMSENDFORMAT { get; set; }

        public string STORECREDITCARDNO { get; set; }

        public short? CLORDFREQ { get; set; }

        public short? ORDDAY { get; set; }

        public string LOGOID { get; set; }

        public short? LIDCONFIRMED { get; set; }

        public string EXPREGNO { get; set; }

        public string EXPDOCNO { get; set; }

        public int? EXPBUSTYPREF { get; set; }

        public short? INVPRINTCNT { get; set; }

        public short? PIECEORDINFLICT { get; set; }

        public short? COLLECTINVOICING { get; set; }

        public short? EBUSDATASENDTYPE { get; set; }

        public int? INISTATUSFLAGS { get; set; }

        public short? SLSORDERSTATUS { get; set; }

        public short? SLSORDERPRICE { get; set; }

        public short? LTRSENDMETHOD { get; set; }

        public string LTRSENDEMAILADDR { get; set; }

        public string LTRSENDFAXNR { get; set; }

        public short? LTRSENDFORMAT { get; set; }

        public short? IMAGEINC { get; set; }

        public string CELLPHONE { get; set; }

        public short? SAMEITEMCODEUSE { get; set; }

        public string STATECODE { get; set; }

        public string STATENAME { get; set; }

        public int? WFLOWCRDREF { get; set; }

        public int? PARENTCLREF { get; set; }

        public int? LOWLEVELCODES1 { get; set; }

        public int? LOWLEVELCODES2 { get; set; }

        public int? LOWLEVELCODES3 { get; set; }

        public int? LOWLEVELCODES4 { get; set; }

        public int? LOWLEVELCODES5 { get; set; }

        public int? LOWLEVELCODES6 { get; set; }

        public int? LOWLEVELCODES7 { get; set; }

        public int? LOWLEVELCODES8 { get; set; }

        public int? LOWLEVELCODES9 { get; set; }

        public int? LOWLEVELCODES10 { get; set; }

        public string TELCODES1 { get; set; }

        public string TELCODES2 { get; set; }

        public string FAXCODE { get; set; }

        public short? PURCHBRWS { get; set; }

        public short? SALESBRWS { get; set; }

        public short? IMPBRWS { get; set; }

        public short? EXPBRWS { get; set; }

        public short? FINBRWS { get; set; }

        public string ORGLOGOID { get; set; }

        public short? ADDTOREFLIST { get; set; }

        public short? TEXTREFTR { get; set; }

        public short? TEXTREFEN { get; set; }

        public short? ARPQUOTEINC { get; set; }

        public short? CLCRM { get; set; }

        public short? GRPFIRMNR { get; set; }

        public int? CONSCODEREF { get; set; }

        public string SPECODE2 { get; set; }

        public string SPECODE3 { get; set; }

        public string SPECODE4 { get; set; }

        public string SPECODE5 { get; set; }

        public short? OFFSENDMETHOD { get; set; }

        public string OFFSENDEMAILADDR { get; set; }

        public string OFFSENDFAXNR { get; set; }

        public short? OFFSENDFORMAT { get; set; }

        public short? EBANKNO { get; set; }

        public short? LOANGRPCTRL { get; set; }

        public string BANKNAMES1 { get; set; }

        public string BANKNAMES2 { get; set; }

        public string BANKNAMES3 { get; set; }

        public string BANKNAMES4 { get; set; }

        public string BANKNAMES5 { get; set; }

        public string BANKNAMES6 { get; set; }

        public string BANKNAMES7 { get; set; }

        public short? LDXFIRMNR { get; set; }

        public string MAPID { get; set; }

        public string LONGITUDE { get; set; }

        public string LATITUTE { get; set; }

        public string CITYID { get; set; }

        public string TOWNID { get; set; }

        public string BANKIBANS1 { get; set; }

        public string BANKIBANS2 { get; set; }


        public string BANKIBANS3 { get; set; }
        public string BANKIBANS4 { get; set; }
        public string BANKIBANS5 { get; set; }
        public string BANKIBANS6 { get; set; }
        public string BANKIBANS7 { get; set; }









        public string TCKNO { get; set; }
        public Int16? ISPERSCOMP { get; set; }
        public Int16? EXTSENDMETHOD { get; set; }
        public string EXTSENDEMAILADDR { get; set; }
        public string EXTSENDFAXNR { get; set; }
        public Int16? EXTSENDFORMAT { get; set; }
        public string BANKBICS1 { get; set; }
        public string BANKBICS2 { get; set; }
        public string BANKBICS3 { get; set; }
        public string BANKBICS4 { get; set; }
        public string BANKBICS5 { get; set; }
        public string BANKBICS6 { get; set; }
        public string BANKBICS7 { get; set; }


        public int? CASHREF { get; set; }
        public Int16? USEDINPERIODS { get; set; }


        public string INCHARGE2 { get; set; }
        public string INCHARGE3 { get; set; }
        public string EMAILADDR2 { get; set; }
        public string EMAILADDR3 { get; set; }
        public Int16? RSKLIMCR { get; set; }
        public Int16? RSKDUEDATECR { get; set; }
        public Int16? RSKAGINGCR { get; set; }
        public Int16? RSKAGINGDAY { get; set; }
        public Int16? ACCEPTEINV { get; set; }
        public string EINVOICEID { get; set; }
        public Int16? PROFILEID { get; set; }
        public string BANKBCURRENCY1 { get; set; }
        public string BANKBCURRENCY2 { get; set; }
        public string BANKBCURRENCY3 { get; set; }
        public string BANKBCURRENCY4 { get; set; }
        public string BANKBCURRENCY5 { get; set; }
        public string BANKBCURRENCY6 { get; set; }
        public string BANKBCURRENCY7 { get; set; }
        public Int16? PURCORDERSTATUS { get; set; }
        public Int16? PURCORDERPRICE { get; set; }
        public Int16? ISFOREIGN { get; set; }
        public int? SHIPBEGTIME1 { get; set; }
        public int? SHIPBEGTIME2 { get; set; }
        public int? SHIPBEGTIME3 { get; set; }
        public int? SHIPENDTIME1 { get; set; }
        public int? SHIPENDTIME2 { get; set; }
        public int? SHIPENDTIME3 { get; set; }
        public double? DBSLIMIT1 { get; set; }
        public double? DBSLIMIT2 { get; set; }
        public double? DBSLIMIT3 { get; set; }
        public double? DBSLIMIT4 { get; set; }
        public double? DBSLIMIT5 { get; set; }
        public double? DBSLIMIT6 { get; set; }
        public double? DBSLIMIT7 { get; set; }
        public double? DBSTOTAL1 { get; set; }
        public double? DBSTOTAL2 { get; set; }
        public double? DBSTOTAL3 { get; set; }
        public double? DBSTOTAL4 { get; set; }
        public double? DBSTOTAL5 { get; set; }
        public double? DBSTOTAL6 { get; set; }
        public double? DBSTOTAL7 { get; set; }
        public Int16? DBSBANKNO1 { get; set; }
        public Int16? DBSBANKNO2 { get; set; }
        public Int16? DBSBANKNO3 { get; set; }
        public Int16? DBSBANKNO4 { get; set; }
        public Int16? DBSBANKNO5 { get; set; }
        public Int16? DBSBANKNO6 { get; set; }
        public Int16? DBSBANKNO7 { get; set; }
        public Int16? DBSRISKCNTRL1 { get; set; }
        public Int16? DBSRISKCNTRL2 { get; set; }
        public Int16? DBSRISKCNTRL3 { get; set; }
        public Int16? DBSRISKCNTRL4 { get; set; }
        public Int16? DBSRISKCNTRL5 { get; set; }
        public Int16? DBSRISKCNTRL6 { get; set; }
        public Int16? DBSRISKCNTRL7 { get; set; }
        public Int16? DBSBANKCURRENCY1 { get; set; }
        public Int16? DBSBANKCURRENCY2 { get; set; }
        public Int16? DBSBANKCURRENCY3 { get; set; }
        public Int16? DBSBANKCURRENCY4 { get; set; }
        public Int16? DBSBANKCURRENCY5 { get; set; }
        public Int16? DBSBANKCURRENCY6 { get; set; }
        public Int16? DBSBANKCURRENCY7 { get; set; }
        public string BANKCORRPACC1 { get; set; }
        public string BANKCORRPACC2 { get; set; }
        public string BANKCORRPACC3 { get; set; }
        public string BANKCORRPACC4 { get; set; }
        public string BANKCORRPACC5 { get; set; }
        public string BANKCORRPACC6 { get; set; }
        public string BANKCORRPACC7 { get; set; }
        public string BANKVOEN1 { get; set; }
        public string BANKVOEN2 { get; set; }
        public string BANKVOEN3 { get; set; }
        public string BANKVOEN4 { get; set; }
        public string BANKVOEN5 { get; set; }
        public string BANKVOEN6 { get; set; }
        public string BANKVOEN7 { get; set; }
        public Int16? EINVOICETYPE { get; set; }
        public string DEFINITION2 { get; set; }
        public string TELEXTNUMS1 { get; set; }
        public string TELEXTNUMS2 { get; set; }
        public string FAXEXTNUM { get; set; }
        public string FACEBOOKURL { get; set; }
        public string TWITTERURL { get; set; }
        public string APPLEID { get; set; }
        public string SKYPEID { get; set; }
        public string GLOBALID { get; set; }
        public string GUID { get; set; }
        public Int16? DUEDATECOUNT { get; set; }
        public double? DUEDATELIMIT { get; set; }
        public Int16? DUEDATETRACK { get; set; }
        public Int16? DUEDATECONTROL1 { get; set; }
        public Int16? DUEDATECONTROL2 { get; set; }
        public Int16? DUEDATECONTROL3 { get; set; }
        public Int16? DUEDATECONTROL4 { get; set; }
        public Int16? DUEDATECONTROL5 { get; set; }
        public Int16? DUEDATECONTROL6 { get; set; }
        public Int16? DUEDATECONTROL7 { get; set; }
        public Int16? DUEDATECONTROL8 { get; set; }
        public Int16? DUEDATECONTROL9 { get; set; }
        public Int16? DUEDATECONTROL10 { get; set; }
        public Int16? DUEDATECONTROL11 { get; set; }
        public Int16? DUEDATECONTROL12 { get; set; }
        public Int16? DUEDATECONTROL13 { get; set; }
        public Int16? DUEDATECONTROL14 { get; set; }
        public Int16? DUEDATECONTROL15 { get; set; }
        public string ADRESSNO { get; set; }
        public string POSTLABELCODE { get; set; }
        public string SENDERLABELCODE { get; set; }
        public Int16? CLOSEDATECOUNT { get; set; }
        public Int16? CLOSEDATETRACK { get; set; }
        public Int16? DEGACTIVE { get; set; }
        public Int16? DEGCURR { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
        public Int16? LABELINFO { get; set; }
        public int? DEFBNACCREF { get; set; }
        public int? PROJECTREF { get; set; }
        public Int16? DISCTYPE { get; set; }
        public Int16? SENDMOD { get; set; }
        public Int16? ISPERCURR { get; set; }
        public Int16? CURRATETYPE { get; set; }
        public Int16? INSTEADOFDESP { get; set; }
        public Int16? EINVOICETYP { get; set; }
        public Int16? FBSSENDMETHOD { get; set; }
        public string FBSSENDEMAILADDR { get; set; }
        public Int16? FBSSENDFORMAT { get; set; }
        public string FBSSENDFAXNR { get; set; }
        public Int16? FBASENDMETHOD { get; set; }
        public string FBASENDEMAILADDR { get; set; }
        public Int16? FBASENDFORMAT { get; set; }
        public string FBASENDFAXNR { get; set; }
        public int? SECTORMAINREF { get; set; }
        public int? SECTORSUBREF { get; set; }
        public Int16? PERSONELCOSTS { get; set; }
        public string EARCEMAILADDR1 { get; set; }
        public string EARCEMAILADDR2 { get; set; }
        public string EARCEMAILADDR3 { get; set; }
        public Int16? FACTORYDIVNR { get; set; }
        public Int16? FACTORYNR { get; set; }
        public Int16? ININVENNR { get; set; }
        public Int16? OUTINVENNR { get; set; }
        public double? QTYDEPDURATION { get; set; }
        public double? QTYINDEPDURATION { get; set; }
        public Int16? OVERLAPTYPE { get; set; }
        public double? OVERLAPAMNT { get; set; }
        public double? OVERLAPPERC { get; set; }
        public Int16? BROKERCOMP { get; set; }
        public Int16? CREATEWHFICHE { get; set; }
        public Int16? EINVCUSTOM { get; set; }
        public Int16? SUBCONT { get; set; }
        public Int16? ORDPRIORITY { get; set; }
        public Int16? ACCEPTEDESP { get; set; }
        public Int16? PROFILEIDDESP { get; set; }
        public Int16? LABELINFODESP { get; set; }
        public string POSTLABELCODEDESP { get; set; }
        public string SENDERLABELCODEDESP { get; set; }
        public Int16? ACCEPTEINVPUBLIC { get; set; }
        public int? PUBLICBNACCREF { get; set; }
        public Int16? PAYMENTPROCBRANCH { get; set; }
        public Int16? KVKKPERMSTATUS { get; set; }
        public DateTime? KVKKBEGDATE { get; set; }
        public DateTime? KVKKENDDATE { get; set; }
        public DateTime? KVKKCANCELDATE { get; set; }
        public Int16? KVKKANONYSTATUS { get; set; }
        public DateTime? KVKKANONYDATE { get; set; }
        public Int16? EXIMSENDMETHOD { get; set; }
        public string EXIMSENDEMAILADDR { get; set; }
        public Int16? EXIMSENDFORMAT { get; set; }
        public string EXIMSENDFAXNR { get; set; }
        public Int16? CLCCANDEDUCT { get; set; }
        public int? DRIVERREF { get; set; }
        public string INCHTELCODES1 { get; set; }
        public string INCHTELCODES2 { get; set; }
        public string INCHTELCODES3 { get; set; }
        public string INCHTELNRS1 { get; set; }
        public string INCHTELNRS2 { get; set; }
        public string INCHTELNRS3 { get; set; }
        public string INCHTELEXTNUMS1 { get; set; }
        public string INCHTELEXTNUMS2 { get; set; }
        public string INCHTELEXTNUMS3 { get; set; }
        public int? NOTIFYCRDREF { get; set; }
        public Int16? EXCNTRYTYP { get; set; }
        public int? EXCNTRYREF { get; set; }
        public Int16? IMCNTRYTYP { get; set; }
        public int? IMCNTRYREF { get; set; }
        public int? EXIMPAYTYPREF { get; set; }
        public int? EXIMBRBANKREF { get; set; }
        public int? EXIMCUSTOMREF { get; set; }
        public int? EXIMREGTYPREF { get; set; }
        public int? EXIMNTFYCLREF { get; set; }
        public int? EXIMCNSLTCLREF { get; set; }
        public int? EXIMFRGHTCLREF { get; set; }
        public Int16? DISPPRINTCNT { get; set; }
        public Int16? ORDPRINTCNT { get; set; }
        public string MERSISNO { get; set; }
        public string COMMRECORDNO { get; set; }
        public Int16? CLPTYPEFORPPAYDT { get; set; }
        public Int16? CLSTYPEFORPPAYDT { get; set; }
        public string WHATSAPPID { get; set; }
        public string LINKEDINURL { get; set; }
        public string INSTAGRAMURL { get; set; }

    }
}
