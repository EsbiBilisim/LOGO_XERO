using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_M
{
    public class LG_CLRNUMS
    {
        [Key]
        public int LOGICALREF { get; set; }

        public int? CLCARDREF { get; set; }

        public short? RISKTYPE { get; set; }

        public short? RISKOVER { get; set; }

        public double? PS { get; set; }

        public double? KC { get; set; }

        public double? RISKTOTAL { get; set; }

        public double? DESPRISKTOTAL { get; set; }

        public double? RISKLIMIT { get; set; }

        public double? RISKBALANCED { get; set; }

        public double? CEKRISKFACTOR { get; set; }

        public double? SENETRISKFACTOR { get; set; }

        public double? CEK0_DEBIT { get; set; }

        public double? CEK0_CREDIT { get; set; }

        public double? CEK1_DEBIT { get; set; }

        public double? CEK1_CREDIT { get; set; }

        public double? SENET0_DEBIT { get; set; }

        public double? SENET0_CREDIT { get; set; }

        public double? SENET1_DEBIT { get; set; }

        public double? SENET1_CREDIT { get; set; }

        public double? CEKCURR0_DEBIT { get; set; }

        public double? CEKCURR0_CREDIT { get; set; }

        public double? CEKCURR1_DEBIT { get; set; }

        public double? CEKCURR1_CREDIT { get; set; }

        public double? SENETCURR0_DEBIT { get; set; }

        public double? SENETCURR0_CREDIT { get; set; }

        public double? SENETCURR1_DEBIT { get; set; }

        public double? SENETCURR1_CREDIT { get; set; }

        public short? ORDRISKOVER { get; set; }

        public short? DESPRISKOVER { get; set; }

        public short? USEREPRISK { get; set; }

        public double? REPRISKTOTAL { get; set; }

        public double? REPDESPRISKTOTAL { get; set; }

        public double? REPRISKLIMIT { get; set; }

        public double? REPRISKBALANCED { get; set; }

        public double? REPPS { get; set; }

        public double? REPKC { get; set; }

        public double? ORDRISKTOTAL { get; set; }

        public double? ORDRISKTOTALSUGG { get; set; }

        public double? REPORDRISKTOTAL { get; set; }

        public double? REPORDRISKTOTALSUGG { get; set; }

        public short? RISKTYPES1 { get; set; }

        public short? RISKTYPES2 { get; set; }

        public short? RISKTYPES3 { get; set; }

        public short? RISKTYPES4 { get; set; }

        public short? RISKTYPES5 { get; set; }

        public short? RISKTYPES6 { get; set; }

        public short? RISKTYPES7 { get; set; }

        public short? RISKTYPES8 { get; set; }

        public short? RISKTYPES9 { get; set; }

        public short? RISKTYPES10 { get; set; }

        public short? RISKTYPES11 { get; set; }

        public short? RISKTYPES12 { get; set; }

        public short? RISKTYPES13 { get; set; }

        public short? RISKTYPES14 { get; set; }

        public short? RISKTYPES15 { get; set; }

        public double? CSTCEKRISKFACTOR { get; set; }

        public double? CSTSENETRISKFACTOR { get; set; }

        public short? RISKGRPCONTROL { get; set; }

        public short? ACCRISKOVER { get; set; }

        public short? CSTCSRISKOVER { get; set; }

        public short? MYCSRISKOVER { get; set; }

        public short? RISKCTRLTYPE { get; set; }

        public double? ACCRISKTOTAL { get; set; }

        public double? REPACCRISKTOTAL { get; set; }

        public double? CSTCSRISKTOTAL { get; set; }

        public double? REPCSTCSRISKTOTAL { get; set; }

        public double? MYCSRISKTOTAL { get; set; }

        public double? REPMYCSRISKTOTAL { get; set; }

        public double? ACCRISKLIMIT { get; set; }

        public double? REPACCRISKLIMIT { get; set; }

        public double? CSTCSRISKLIMIT { get; set; }

        public double? REPCSTCSRISKLIMIT { get; set; }

        public double? MYCSRISKLIMIT { get; set; }

        public double? REPMYCSRISKLIMIT { get; set; }

        public double? DESPRISKLIMIT { get; set; }

        public double? REPDESPRISKLIMIT { get; set; }

        public double? ORDRISKLIMIT { get; set; }

        public double? REPORDRISKLIMIT { get; set; }

        public double? ORDRISKLIMITSUGG { get; set; }

        public double? REPORDRISKLIMITSUGG { get; set; }

        public double? ACCRSKBLNCED { get; set; }

        public double? REPACCRSKBLNCED { get; set; }

        public double? CSTCSRSKBLNCED { get; set; }

        public double? REPCSTCSRSKBLNCED { get; set; }

        public double? MYCSRSKBLNCED { get; set; }

        public double? REPMYCSRSKBLNCED { get; set; }

        public double? DESPRSKBLNCED { get; set; }

        public double? REPDESPRSKBLNCED { get; set; }

        public double? ORDRSKBLNCED { get; set; }

        public double? REPORDRSKBLNCED { get; set; }

        public double? ORDRSKBLNCEDSUG { get; set; }

        public double? REPORDRSKBLNCEDSUG { get; set; }

        public short? ORDRISKOVERSUGG { get; set; }

        public short? CSDOWNSRISK { get; set; }

        public short? CSTCSCIRORISKOVER { get; set; }

        public double? CSTCIROCEKRISKFAC { get; set; }

        public double? CSTCIROSENETRISKFAC { get; set; }

        public short? CSCIRODOWNSRISK { get; set; }

        public double? CSTCSCIRORISKLIMIT { get; set; }

        public double? REPCSTCSCIRORISKLIM { get; set; }

        public double? CSTCSCIRORSKBLNCED { get; set; }

        public double? REPCSTCSCIRORSKBLN { get; set; }

        public double? CSTCSOWNRISKTOTAL { get; set; }

        public double? REPCSTCSOWNRISKTOT { get; set; }

        public double? CSTCSCIRORISKTOTAL { get; set; }

        public double? REPCSTCSCIRORISKTOT { get; set; }

        public short? DESPRISKOVERSUG { get; set; }

        public double? DESPRISKLIMITSUG { get; set; }

        public double? REPDESPRISKLIMITSUG { get; set; }

        public double? DESPRISKTOTALSUG { get; set; }

        public double? REPDESPRISKTOTALSUG { get; set; }

        public double? DESPRSKBLNCEDSUG { get; set; }

        public double? REPDESPRSKBLNCEDSUG { get; set; }

    }
}
