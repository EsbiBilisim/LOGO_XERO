using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_M
{
    public class LG_ITEMS
    {
        [Key]
        public int LOGICALREF { get; set; }

        public Int16? ACTIVE { get; set; }

        public Int16? CARDTYPE { get; set; }

        public string CODE { get; set; }

        public string NAME { get; set; }

        public string STGRPCODE { get; set; }

        public string PRODUCERCODE { get; set; }

        public string SPECODE { get; set; }

        public string CYPHCODE { get; set; }

        public Int16? CLASSTYPE { get; set; }

        public Int16? PURCHBRWS { get; set; }

        public Int16? SALESBRWS { get; set; }

        public Int16? MTRLBRWS { get; set; }

        public double? VAT { get; set; }

        public int? PAYMENTREF { get; set; }

        public Int16? TRACKTYPE { get; set; }

        public Int16? LOCTRACKING { get; set; }

        public Int16? TOOL { get; set; }

        public Int16? AUTOINCSL { get; set; }

        public Int16? DIVLOTSIZE { get; set; }

        public double? SHELFLIFE { get; set; }

        public Int16? SHELFDATE { get; set; }

        public int? DOMINANTREFS1 { get; set; }

        public int? DOMINANTREFS2 { get; set; }

        public int? DOMINANTREFS3 { get; set; }

        public int? DOMINANTREFS4 { get; set; }

        public int? DOMINANTREFS5 { get; set; }

        public int? DOMINANTREFS6 { get; set; }

        public int? DOMINANTREFS7 { get; set; }

        public int? DOMINANTREFS8 { get; set; }

        public int? DOMINANTREFS9 { get; set; }

        public int? DOMINANTREFS10 { get; set; }

        public int? DOMINANTREFS11 { get; set; }

        public int? DOMINANTREFS12 { get; set; }

        public Int16? IMAGEINC { get; set; }

        public Int16? TEXTINC { get; set; }

        public Int16? DEPRTYPE { get; set; }

        public double? DEPRRATE { get; set; }

        public Int16? DEPRDUR { get; set; }

        public double? SALVAGEVAL { get; set; }

        public Int16? REVALFLAG { get; set; }

        public Int16? REVDEPRFLAG { get; set; }

        public Int16? PARTDEP { get; set; }

        public Int16? DEPRTYPE2 { get; set; }

        public double? DEPRRATE2 { get; set; }

        public Int16? DEPRDUR2 { get; set; }

        public Int16? REVALFLAG2 { get; set; }

        public Int16? REVDEPRFLAG2 { get; set; }

        public Int16? PARTDEP2 { get; set; }

        public Int16? APPROVED { get; set; }

        public int UNITSETREF { get; set; }

        public int? QCCSETREF { get; set; }

        public double? DISTAMOUNT { get; set; }

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
        public int? ORGLOGICREF { get; set; }

        public string UNIVID { get; set; }
        public Int16? DISTLOTUNITS { get; set; }
        public Int16? COMBLOTUNITS { get; set; }
        public int? WFSTATUS { get; set; }
        public double? DISTPOINT { get; set; }
        public double? CAMPPOINT { get; set; }
        public Int16? CANUSEINTRNS { get; set; }

        public string ISONR { get; set; }

        public string GROUPNR { get; set; }

        public string PRODCOUNTRY { get; set; }

        public int? ADDTAXREF { get; set; }

        public double? QPRODAMNT { get; set; }

        public int? QPRODUOM { get; set; }

        public Int16? QPRODSRCINDEX { get; set; }

        public int? EXTACCESSFLAGS { get; set; }

        public Int16? PACKET { get; set; }

        public double? SALVAGEVAL2 { get; set; }

        public double? SELLVAT { get; set; }

        public double? RETURNVAT { get; set; }

        public string LOGOID { get; set; }

        public Int16? LIDCONFIRMED { get; set; }

        public string GTIPCODE { get; set; }

        public string EXPCTGNO { get; set; }

        public string B2CCODE { get; set; }

        public int MARKREF { get; set; }

        public Int16? IMAGE2INC { get; set; }

        public double? AVRWHDURATION { get; set; }

        public int? EXTCARDFLAGS { get; set; }

        public double? MINORDAMOUNT { get; set; }

        public string FREIGHTPLACE { get; set; }

        public string FREIGHTTYPCODE1 { get; set; }

        public string FREIGHTTYPCODE2 { get; set; }

        public string FREIGHTTYPCODE3 { get; set; }

        public string FREIGHTTYPCODE4 { get; set; }

        public string FREIGHTTYPCODE5 { get; set; }

        public string FREIGHTTYPCODE6 { get; set; }

        public string FREIGHTTYPCODE7 { get; set; }

        public string FREIGHTTYPCODE8 { get; set; }

        public string FREIGHTTYPCODE9 { get; set; }

        public string FREIGHTTYPCODE10 { get; set; }

        public string STATECODE { get; set; }

        public string STATENAME { get; set; }

        public string EXPCATEGORY { get; set; }

        public double? LOSTFACTOR { get; set; }

        public Int16? TEXTINCENG { get; set; }

        public string EANBARCODE { get; set; }

        public string DEPRCLASSTYPE { get; set; }

        public int? WFLOWCRDREF { get; set; }

        public double? SELLPRVAT { get; set; }

        public double? RETURNPRVAT { get; set; }

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

        public string ORGLOGOID { get; set; }

        public Int16? QPRODDEPART { get; set; }

        public Int16? CANCONFIGURE { get; set; }

        public int? CHARSETREF { get; set; }

        public Int16? CANDEDUCT { get; set; }

        public int? CONSCODEREF { get; set; }

        public string SPECODE2 { get; set; }

        public string SPECODE3 { get; set; }

        public string SPECODE4 { get; set; }

        public string SPECODE5 { get; set; }

        public Int16? EXPENSE { get; set; }

        public string ORIGIN { get; set; }

        public string NAME2 { get; set; }

        public Int16? COMPKDVUSE { get; set; }

        public Int16? USEDINPERIODS { get; set; }

        public double? EXIMTAX1 { get; set; }

        public double? EXIMTAX2 { get; set; }

        public double? EXIMTAX3 { get; set; }

        public double? EXIMTAX4 { get; set; }

        public double? EXIMTAX5 { get; set; }

        public Int16? PRODUCTLEVEL { get; set; }

        public Int16? APPSPEVATMATRAH { get; set; }

        public string NAME3 { get; set; }

        public Int16? FACOSTKEYS { get; set; }

        public Int16? KKLINESDISABLE { get; set; }

        public Int16? APPROVE { get; set; }

        public DateTime? APPROVEDATE { get; set; }

        public string GLOBALID { get; set; }

        public Int16? SALEDEDUCTPART1 { get; set; }

        public Int16? SALEDEDUCTPART2 { get; set; }

        public Int16? PURCDEDUCTPART1 { get; set; }

        public Int16? PURCDEDUCTPART2 { get; set; }

        public string CATEGORYID { get; set; }

        public string CATEGORYNAME { get; set; }

        public string KEYWORD1 { get; set; }

        public string KEYWORD2 { get; set; }

        public string KEYWORD3 { get; set; }

        public string KEYWORD4 { get; set; }

        public string KEYWORD5 { get; set; }

        public string GUID { get; set; }

        public string DEMANDMEETSORTFLD1 { get; set; }

        public string DEMANDMEETSORTFLD2 { get; set; }

        public string DEMANDMEETSORTFLD3 { get; set; }
        public string DEMANDMEETSORTFLD4 { get; set; }
        public string DEMANDMEETSORTFLD5 { get; set; }
        public string DEDUCTCODE { get; set; }
        public int? PROJECTREF { get; set; }
        public string NAME4 { get; set; }
        public double? QPRODSUBAMNT { get; set; }


        public int? QPRODSUBUOM { get; set; }
        public Int16? QPRODSUBSRCINDEX { get; set; }
        public Int16? QPRODSUBDEPART { get; set; }
        public double? PORDAMNTTOLERANCE { get; set; }
        public double? SORDAMNTTOLERANCE { get; set; }


        public Int16? MULTIADDTAX { get; set; }
        public string CPACODE { get; set; }
        public int? PUBLICCOUNTRYREF { get; set; }
        public string FAUSEFULLIFECODE { get; set; }
        public string FAUSEFULLIFECODE2 { get; set; }
        public Int16? MOLD { get; set; }
        public Int16? MOLDLIFETRACKTYPE { get; set; }
        public double? MOLDUSAGELIFE { get; set; }
        public Int16? MOLDFACTOR { get; set; }
        //public int? MOLDMAINTNUMBER { get; set; }
        //public Int16? MOLDMAINTLIFETYPE { get; set; }
        //public int? MOLDMAINTLIFE { get; set; }
        //public Int16? MOLDLIFEASRATIO { get; set; }
        //public Int16? MOLDMAINTTYPE { get; set; }
        //public DateTime? MOLDMAINTBEGDATE { get; set; }
        //public double? MOLDMAINTPERIOD { get; set; }
        //public Int16? MOLDMAINTPERUNIT { get; set; }
        //public Int16? OBTAINTYPE { get; set; }
        //public Int16? GAINTYPE { get; set; }
        //public string FORECASTCODE { get; set; }
        public double? SALESLIMITQUANTITY { get; set; }
        public Int16? NODISCOUNT { get; set; }
        public Int16? LEVELCONTROL { get; set; }
        public int? NOTIFYCRDREF { get; set; }
        public string PAYERBARCODE { get; set; }
        public double? PAYERPURCHPRICE { get; set; }



        public string PAYERNAME { get; set; }
        public string PAYERSUBTITLE { get; set; }
        public Int16? PAYERACTIVE { get; set; }


        public string PURCHDEDUCTCODE { get; set; }
        public double? PAYERSALESPRICE { get; set; }
        public string PAYERID { get; set; }
        public string UETDSLOADTYPEDEF { get; set; }
        public Int16? UETDSTRANSPORTMODE { get; set; }
        public Int16? UETDSTRANSPORTTYPE { get; set; }



        public string UETDSLOADTYPE { get; set; }
        public string UETDSLOADUNIT { get; set; }
        public string TSENR { get; set; }
        public string UETDSUNCODE { get; set; }
        public string UETDSUNDEF { get; set; }


        public Int16? ADDTAXSALESBRWS { get; set; }
        public Int16? ADDTAXPURCHBRWS { get; set; }
        public int? PRODCLREF { get; set; }
        public Int16? DRAFTOFFERBRWS { get; set; }
        public double? SALESDISPRATETOT { get; set; }
        public double? PROFITMARGINRATE { get; set; }
        public int? EXIMREGTYPREF { get; set; }
        public double? PURCHDISPRATETOT { get; set; }
        public string ORDCMPRICETYPECODE { get; set; }
    }
}
