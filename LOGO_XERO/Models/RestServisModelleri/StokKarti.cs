using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logo.STOK
{

    public class Rootobject
    {
        public int INTERNAL_REFERENCE { get; set; }
        public string CODE { get; set; }
        public string NAME { get; set; }
        public string NAME2 { get; set; }
        public string NAME3 { get; set; }
        public string NAME4 { get; set; }
        public string ITEXT { get; set; }
        public string ITEXTENG { get; set; }
        public string RECORD_STATUS { get; set; }
        public string PROD_COUNTRY { get; set; }
        public string MARKCODE { get; set; }
        public string GTIPCODE { get; set; }
        public string AUTH_CODE { get; set; }
        public string AUXIL_CODE { get; set; }
        public string AUXIL_CODE2 { get; set; }
        public string AUXIL_CODE3 { get; set; }
        public string AUXIL_CODE4 { get; set; }
        public string AUXIL_CODE5 { get; set; }
        public string PRODUCER_CODE { get; set; }
        public string GROUP_CODE { get; set; }
        public string UNITSET_CODE { get; set; }
        public string VAT { get; set; }
        public string SELVAT { get; set; }
        public string RETURNVAT { get; set; }
        public int? LOCATION_TRACKING { get; set; }
        public int? TRACK_TYPE { get; set; }
        public int? LOTS_DIVISIBLE { get; set; }
        public int? ADDTAXPURCHBRWS { get; set; }
        public int? ADDTAXSALESBRWS { get; set; }
        public int? SHELF_LIFE { get; set; }
        public int? SHELF_DATE { get; set; }
        public string SELPRVAT { get; set; }
        public string RETURNPRVAT { get; set; }
        public int? CARD_TYPE { get; set; }
        public int? USEF_PURCHASING { get; set; }
        public int? USEF_SALES { get; set; }
        public int? USEF_MM { get; set; }
        public int? SALE_DEDUCTION_PART1 { get; set; }
        public int? SALE_DEDUCTION_PART2 { get; set; }
        public int? PURCH_DEDUCTION_PART1 { get; set; }
        public int? PURCH_DEDUCTION_PART2 { get; set; }
        public int? CAN_DEDUCT { get; set; }
        public int? KDV_DEPT_NR { get; set; }
        public int? COMB_LOT_UNITS { get; set; }
        public int? DIST_LOT_UNITS { get; set; }
        public string DEDUCT_CODE { get; set; }
        public string PURCH_DEDUCT_CODE { get; set; }
        public string ISO_NR { get; set; }//araç tipi 
        public DateTime? DATE_CREATED { get; set; }
        public int? HOUR_CREATED { get; set; }
        public int? MIN_CREATED { get; set; }
        public int? SEC_CREATED { get; set; }
        public DateTime? DATE_MODIFIED { get; set; }
        public int? HOUR_MODIFIED { get; set; }
        public int? MIN_MODIFIED { get; set; }
        public int? SEC_MODIFIED { get; set; }
        public SUPPLIERS SUPPLIERS { get; set; }

        public UNITS UNITS { get; set; }

    }

    public class SUPPLIERS
    {
        public int? offset { get; set; }
        public int? limit { get; set; }
        public List<Items> items { get; set; }
    }

    public class UNITS
    {
        public List<Item> items { get; set; }
    }


    public class Item
    {
        public string UNIT_CODE { get; set; }
        public int USEF_MTRLCLASS { get; set; }
        public int USEF_PURCHCLAS { get; set; }
        public int USEF_SALESCLAS { get; set; }
        public double WIDTH { get; set; }
        public double LENGTH { get; set; }
        public double HEIGHT { get; set; }
        public double AREA { get; set; }
        public double VOLUME { get; set; }
        public double WEIGHT { get; set; }
        public double GROSS_VOLUME { get; set; }
        public double GROSS_WEIGHT { get; set; }




        public string WIDTH_CODE { get; set; }
        public string LENGTH_CODE { get; set; }
        public string HEIGHT_CODE { get; set; }
        public string AREA_CODE { get; set; }
        public string VOLUME_CODE { get; set; }
        public string WEIGHT_CODE { get; set; }
        public string GROSS_VOL_CODE { get; set; }

        public string GROSS_WGHT_CODE { get; set; }



        public double CONV_FACT1 { get; set; }
        public double CONV_FACT2 { get; set; }
        public BARCODE_LIST BARCODE_LIST { get; set; }

    }

    public class BARCODE_LIST
    {
        public List<Logo.Barkod.Item> items { get; set; }
    }
    public class Items
    {
        public int? INTERNAL_REFERENCE { get; set; }
        public int? ITEMREF { get; set; }
        public int? SUPPLY_TYPE { get; set; }
        public int? PRIORITY { get; set; }
        public int? LINE_NO { get; set; }
        public int? CLIENTREF { get; set; }
        public string TRADING_GRP { get; set; }
        public int? CL_CARD_TYPE { get; set; }
        public int? QCC_CHECK { get; set; }
        public double? LEAD_TIME { get; set; }
        public double? MAX_QUANTITY { get; set; }
        public double? MIN_QUANTITY { get; set; }
        public DateTime? BEG_DATE { get; set; }
        public int? SPECIALIZED { get; set; }
        public string ICUST_SUP_CODE { get; set; }
        public string ICUST_SUP_NAME { get; set; }
        public double? QTY_DEP_LEAD_TIME { get; set; }
        public string ARP_CODE { get; set; }
        public int? PACKETREF { get; set; }
        public string PACKET_CODE { get; set; }
        public double? PACKAGING_AMNT { get; set; }
        public int? PACKAGINGUOMREF { get; set; }
        public string UNIT_CODE { get; set; }
        public int? PACKET_USE_TYPE { get; set; }
        public string UNITSET_CODE { get; set; }
        public double? ORD_PERC { get; set; }
        public int? ORD_FREC { get; set; }
        public int? VARIANT_REF { get; set; }

    }
}

namespace Logo.Barkod
{
    public class Item
    {
        public string BARCODE { get; set; }
        public int? XMLATTRIBUTE { get; set; }
        public int? DATAREFERENCE { get; set; }
        public int? CREATEDBY { get; set; }
        public string DATECREATED { get; set; }
        public int? HOURCREATED { get; set; }
        public int? MINCREATED { get; set; }
        public int? SECCREATED { get; set; }
        [NotMapped]
        public int LINENR { get; set; }
    }
}
