using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_M
{
    public class LG_TRGPAR
    {
        [Key]
        public int LOGICALREF { get; set; }

        public Int16? RISKTYPE { get; set; }

        public Int16? RISKOVER { get; set; }

        public Int16? ORDRISKOVER { get; set; }

        public Int16? DESPRISKOVER { get; set; }

        public Int16? USEREPRISK { get; set; }

        public Int16? PRETURNEFFECTORDER { get; set; }

        public Int16? SRETURNEFFECTORDER { get; set; }

        public Int16? FIRMCALENDARTYPE { get; set; }

        public Int16? COLLRISKTYPE { get; set; }

        public Int16? COLLRISKOVER { get; set; }

        public Int16? ORDCOLLRISKOVER { get; set; }

        public Int16? DESPCOLLRISKOVER { get; set; }

        public Int16? USEREPCOLLRISK { get; set; }

        public Int16? FIRMREPCURR { get; set; }

        public Int16? RISKTYPES1 { get; set; }

        public Int16? RISKTYPES2 { get; set; }

        public Int16? RISKTYPES3 { get; set; }

        public Int16? RISKTYPES4 { get; set; }

        public Int16? RISKTYPES5 { get; set; }

        public Int16? RISKTYPES6 { get; set; }

        public Int16? RISKTYPES7 { get; set; }

        public Int16? RISKTYPES8 { get; set; }

        public Int16? RISKTYPES9 { get; set; }

        public Int16? RISKTYPES10 { get; set; }

        public Int16? RISKTYPES11 { get; set; }

        public Int16? RISKTYPES12 { get; set; }

        public Int16? RISKTYPES13 { get; set; }

        public Int16? RISKTYPES14 { get; set; }

        public Int16? RISKTYPES15 { get; set; }

        public Int16? ACCRISKOVER { get; set; }

        public Int16? MYCSRISKOVER { get; set; }

        public Int16? CSTCSRISKOVER { get; set; }

        public Int16? RISKGRPCTRL { get; set; }

        public Int16? RISKCTRLTYPE { get; set; }

        public Int16? ORDRISKOVERSUGG { get; set; }

        public Int16? CSTCSCIRORISKOVER { get; set; }

        public Int16? DESPRISKOVERSUGG { get; set; }
    }
}
