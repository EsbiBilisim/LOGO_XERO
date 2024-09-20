using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.CariSorgulama
{
    public class SAHIS
    {
        public bool sonuc { get; set; }
        public string sonucAciklama { get; set; }
        public string adi { get; set; }
        public string soyadi { get; set; }
        public string babaAdi { get; set; }
        public string vergiDairesiAdi { get; set; }
        public string vergiDairesiKodu { get; set; }
        public string vKN { get; set; }
        public string unvan { get; set; }
        public ADRES isAdresi { get; set; }
        public ADRES ikametgahAdresi { get; set; }
        public List<MESLEK> meslekListesi { get; set; }
    }
    public class ADRES
    {
        public string mahalleSemt { get; set; }
        public string caddeSokak { get; set; }
        public string kapiNO { get; set; }
        public string daireNO { get; set; }
        public string ilceAdi { get; set; }
        public string ilKodu { get; set; }
        public string ilAdi { get; set; }

    }
    public class MESLEK
    {

        public string meslekAdi { get; set; }

        public string meslekKodu { get; set; }
    }
}
