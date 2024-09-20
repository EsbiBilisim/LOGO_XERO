using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LisansStokModeli
{
    public class Root
    {
        public StokkarTFIYATM stokkarT_FIYAT_M { get; set; }
    }

    public class StokkarTFIYATM
    {
        public int logicalref { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public double? fiyat { get; set; }
    }
}
