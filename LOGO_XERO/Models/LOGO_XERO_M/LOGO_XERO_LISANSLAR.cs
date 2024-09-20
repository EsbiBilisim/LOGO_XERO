
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace LOGO_XERO.Models.LOGO_XERO_M
{
    public partial class LOGO_XERO_LISANSLAR
    {
        public int ID { get; set; }

        public int MODUL { get; set; }
        public int VAR { get; set; }

        public string LISANSNUMARASI { get; set; }
        [NotMapped]
        public int LISANSKALANGUNSAYISI { get; set; }
        [NotMapped]
        public string MODULACIKLAMA { get; set; }
        [NotMapped]
        public bool GECERLILIKDURUMU { get; set; }
        [NotMapped]
        public bool LISANSALINABILIR { get; set; }
    }
}
