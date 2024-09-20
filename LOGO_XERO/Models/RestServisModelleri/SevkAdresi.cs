using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logo.CariSevk
{
    public class Root
    {
        public string NAME { get; set; }
        public string SURNAME { get; set; }

        public int INTERNAL_REFERENCE { get; set; }
        public string ARP_CODE { get; set; }
        public int? CLIENTREF { get; set; }
        public string CODE { get; set; }
        public string DESCRIPTION { get; set; }
        public string AUXIL_CODE { get; set; }
        public string AUTH_CODE { get; set; }
        public string TITLE { get; set; }
        public string ADDRESS1 { get; set; }
        public string ADDRESS2 { get; set; }


        public string DISTRICT_CODE { get; set; }
        public string DISTRICT { get; set; }

        public string TOWN_CODE { get; set; }
        public string TOWN { get; set; }
        public string CITY_CODE { get; set; }
        public string CITY { get; set; }
        public string COUNTRY_CODE { get; set; }
        public string COUNTRY { get; set; }
        public string POSTAL_CODE { get; set; }
        public string TELEPHONE1 { get; set; }
        public string TELEPHONE2 { get; set; }

        public string FAX { get; set; }
        public int? CREATED_BY { get; set; }
        public DateTime? DATE_CREATED { get; set; }
        public int? HOUR_CREATED { get; set; }
        public int? MIN_CREATED { get; set; }
        public int? SEC_CREATED { get; set; }
        public int MODIFIED_BY { get; set; }
        public DateTime? DATE_MODIFIED { get; set; }
        public int? HOUR_MODIFIED { get; set; }
        public int? MIN_MODIFIED { get; set; }
        public int? SEC_MODIFIED { get; set; }
        public string XBUFS { get; set; }
        public int? DATA_SITEID { get; set; }
        public int? XML_ATTRIBUTE { get; set; }
        public int? DATA_REFERENCE { get; set; }
        public int? RECORD_STATUS { get; set; }
        public int? TEXTINC { get; set; }
        public string INCHANGE { get; set; }

        public int? SHIP_BEG_TIME1 { get; set; }
        public int? SHIP_BEG_TIME2 { get; set; }
        public int? SHIP_BEG_TIME3 { get; set; }
        public int? SHIP_END_TIME1 { get; set; }
        public int? SHIP_END_TIME2 { get; set; }
        public int? SHIP_END_TIME3 { get; set; }

        public string EMAIL_ADDR { get; set; }
        public bool? DEFAULT_FLAG { get; set; }
        public string POST_LABEL { get; set; }
        public string SENDER_LABEL { get; set; }
        public bool? PERSCOMPANY { get; set; }
        public string TAX_NR { get; set; }
        public string TAX_OFFICE { get; set; }
        public string VAT_NR { get; set; }
        public string TCKNO { get; set; }

        public string CITY_ID { get; set; }
        public string TOWN_ID { get; set; }
        public string LONGITUDE { get; set; }
        public string LATITUDE { get; set; }
        public string TRADING_GRP { get; set; }

        public DateTime? CAPIBLOCK_CREATEDDATE { get; set; }
        public int? CAPIBLOCK_CREATEDHOUR { get; set; }
        public int? CAPIBLOCK_CREATEDMIN { get; set; }
        public int? CAPIBLOCK_CREATEDSEC { get; set; }
    }

}
