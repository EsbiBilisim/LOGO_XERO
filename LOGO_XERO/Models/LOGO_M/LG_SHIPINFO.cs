using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_M
{
    public class LG_SHIPINFO
    {
        //SEVKİYAT ADRESİ
        [Key]
        public int LOGICALREF { get; set; }

        public int? CLIENTREF { get; set; }

        public string CODE { get; set; }

        public string NAME { get; set; }

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

        public string TRADINGGRP { get; set; }

        public string VATNR { get; set; }

        public string TAXNR { get; set; }

        public string TAXOFFICE { get; set; }

        public string TOWNCODE { get; set; }

        public string TOWN { get; set; }

        public string DISTRICTCODE { get; set; }

        public string DISTRICT { get; set; }

        public string CITYCODE { get; set; }

        public string COUNTRYCODE { get; set; }

        public Int16? ACTIVE { get; set; }

        public Int16? TEXTINC { get; set; }

        public string EMAILADDR { get; set; }

        public string INCHANGE { get; set; }

        public string TELCODES1 { get; set; }

        public string TELCODES2 { get; set; }

        public string FAXCODE { get; set; }

        public string LONGITUDE { get; set; }

        public string LATITUTE { get; set; }

        public string CITYID { get; set; }

        public string TOWNID { get; set; }

        public int? SHIPBEGTIME1 { get; set; }

        public int? SHIPBEGTIME2 { get; set; }

        public int? SHIPBEGTIME3 { get; set; }

        public int? SHIPENDTIME1 { get; set; }

        public int? SHIPENDTIME2 { get; set; }

        public int? SHIPENDTIME3 { get; set; }

        public string POSTLABELCODE { get; set; }

        public string SENDERLABELCODE { get; set; }

        public string TITLE { get; set; }

        public Int16? DEFAULTFLG { get; set; }

        public string SNAME { get; set; }

        public string SSURNAME { get; set; }

        public string GUID { get; set; }

        public string TCKNO { get; set; }

        public string POSTCODELEDESP { get; set; }

        public string SENDERCODELEDESP { get; set; }

        public Int16? ISPERSCOMP { get; set; }

    }
}
