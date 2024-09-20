using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_M
{
    public class L_TRADGRP
    {
        [Key]
        public int LOGICALREF { get; set; }

        public string GCODE { get; set; }

        public string GDEF { get; set; }

        public int? GATTRIB { get; set; }

        public short? TRDGRPTYPE { get; set; }

        public short? ACTIVE { get; set; }
    }
}
