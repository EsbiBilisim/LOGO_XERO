using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Obje.Basarili
{
    public class Rootobject
    {
        public int? INTERNAL_REFERENCE { get; set; }
        public string NUMBER { get; set; }
        public int? GRPCODE { get; set; }
        public int? TYPE { get; set; }
        public DateTime DATE { get; set; }
        public int? TIME { get; set; }
        public string ARP_CODE { get; set; }
        public int? SOURCE_WH { get; set; }
        public int? SOURCE_COST_GRP { get; set; }
        public DateTime CANCEL_DATE { get; set; }
        public float? VAT_RATE { get; set; }
        public float? TOTAL_VAT { get; set; }
        public float? TOTAL_GROSS { get; set; }
        public float? TOTAL_NET { get; set; }
        public string NOTES2 { get; set; }
        public float? TC_XRATE { get; set; }
        public float? TC_NET { get; set; }
        public float? RC_XRATE { get; set; }
        public float? RC_NET { get; set; }
        public DateTime? PRINT_DATE { get; set; }
        public int? VAT_INCLUDED_GRS { get; set; }
        public int? DIVISION { get; set; }
        public int? DEPARTMENT { get; set; }
        public int? CREATED_BY { get; set; }
        public DateTime? DATE_CREATED { get; set; }
        public int? HOUR_CREATED { get; set; }
        public int? MIN_CREATED { get; set; }
        public int? SEC_CREATED { get; set; }
        public int? MODIFIED_BY { get; set; }
        public DateTime? DATE_MODIFIED { get; set; }
        public int? HOUR_MODIFIED { get; set; }
        public int? MIN_MODIFIED { get; set; }
        public int? SEC_MODIFIED { get; set; }
        public int? SALESMANREF { get; set; }
        public int? CURRSEL_TOTALS { get; set; }
        public TRANSACTIONS TRANSACTIONS { get; set; }
        public float? TOTAL_ADD_TAX { get; set; }
        public int? PAYMENT_TYPE { get; set; }
        public int? STATUS { get; set; }
        public int? DEDUCTIONPART1 { get; set; }
        public int? DEDUCTIONPART2 { get; set; }
        public int? APPROVE { get; set; }
        public DateTime? APPROVE_DATE { get; set; }
        public DateTime? DOC_DATE { get; set; }
        public int? AUTOFILL_SLDETAILS { get; set; }
        public int? EINVOICE { get; set; }
        public DateTime? ESEND_DATE { get; set; }
        public DateTime? ESTARTDATE { get; set; }
        public DateTime? EENDDATE { get; set; }
        public int? EINSTEAD_OF_DISPATCH { get; set; }
        public int? EINVOICE_SENDCUSTOM { get; set; }
        public int? EINVOICE_TAXTYPE { get; set; }
        public DateTime? EINVOICE_TUPASSPORTDATE { get; set; }
        public int? EINVOICE_TRANSPORTTYP { get; set; }
        public DateTime? EINVOICE_EXITDATE { get; set; }
        public int? EINVOICE_EXITTIME { get; set; }
        public float? EINVOICE_TURETPRICE { get; set; }
        public int? EINVOICE_SENDEINVCUSTOM { get; set; }
        public int? EINVOICE_EINVOICETYPSGK { get; set; }
        public int? EINVOICE_CHAINDELIVERY { get; set; }
        public int? EINVOICE_SELLERCLIENTREF { get; set; }
        public int? EARCHIVEDETR_LOGICALREF { get; set; }
        public int? EARCHIVEDETR_INVOICEREF { get; set; }
        public int? EARCHIVEDETR_EARCHIVESTATUS { get; set; }
        public int? EARCHIVEDETR_EARCHIVESTATUSOLD { get; set; }
        public int? EARCHIVEDETR_SENDMOD { get; set; }
        public int? EARCHIVEDETR_INTPAYMENTTYPE { get; set; }
        public int? EARCHIVEDETR_INTPAYMENTDATEORG { get; set; }
        public int? EARCHIVEDETR_OCKFICHEDATEORG { get; set; }
        public int? EARCHIVEDETR_ISCOMP { get; set; }
        public int? EARCHIVEDETR_ISPERCURR { get; set; }
        public int? EARCHIVEDETR_INSTEADOFDESP { get; set; }
        public int? EARCHIVEDETR_OLDEARCHIVESTATUS { get; set; }
        public int? EARCHIVEDETR_CHAINDELIVERY { get; set; }
        public int? EARCHIVEDETR_SELLERCLIENTREF { get; set; }
        public DateTime? EBOOK_DOCDATE { get; set; }
        public int? EBOOK_NODOCUMENT { get; set; }
        public int? EBOOK_DOCTYPE { get; set; }
        public int? EBOOK_NOPAY { get; set; }
        public int? EPRODUCER_STATUS { get; set; }
        public int? EPRODUCER_SENDMOD { get; set; }
        public int? EPRODUCER_ISCOMP { get; set; }
        public int? EPRODUCER_DELIVERYDATEORG { get; set; }
        public int? EPRODUCER_ISPERCURR { get; set; }
    }

    public class TRANSACTIONS
    {
        public Item[] items { get; set; }
    }

    public class Item
    {
        public int? INTERNAL_REFERENCE { get; set; }
        public int? TYPE { get; set; }
        public string MASTER_CODE { get; set; }
        public DateTime? DATE { get; set; }
        public int? SOURCEINDEX { get; set; }
        public int? SOURCECOSTGRP { get; set; }
        public float? QUANTITY { get; set; }
        public float? PRICE { get; set; }
        public float? TOTAL { get; set; }
        public float? DISCOUNT_RATE { get; set; }
        public string UNIT_CODE { get; set; }
        public int? UOMREF { get; set; }
        public int? USREF { get; set; }
        public int? VAT_INCLUDED { get; set; }
        public float? VAT_RATE { get; set; }
        public int? SALESMANREF { get; set; }
        public DateTime? INF_DATE { get; set; }
        public DateTime? FUTURE_MONTH_BEGDATE { get; set; }
        public DateTime? FUTURE_MONTH_ENDDATE { get; set; }
    }
}
