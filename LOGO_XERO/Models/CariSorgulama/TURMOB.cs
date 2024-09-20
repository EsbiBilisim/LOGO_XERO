using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.CariSorgulama
{
    public class Rootobject
    {
        public bool success { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public Durum durum { get; set; }
        public string vkn { get; set; }
        public string tckn { get; set; }
        public object ad { get; set; }
        public object soyad { get; set; }
        public string babaAdi { get; set; }
        public string vergiDairesiAdi { get; set; }
        public string vergiDairesiKodu { get; set; }
        public string sirketinTuru { get; set; }
        public string faalTerkDurumu { get; set; }
        public Nacefaaliyetkoduvetanimi[] nACEFaaliyetKoduveTanimi { get; set; }
        public Adresbilgileri[] adresBilgileri { get; set; }
        public string iseBaslamaTarihi { get; set; }
        public object isiBirakmaTarihi { get; set; }
        public string kimlikUnvani { get; set; }
        public string unvan { get; set; }
        public string kurulusTarihi { get; set; }
        public object tamDarMukellefiyet { get; set; }
        public object kimlikPotansiyel { get; set; }
        public object dogumYeri { get; set; }
    }

    public class Durum
    {
        public string durumKodu { get; set; }
        public string durumKodAciklamasi { get; set; }
        public object hataDetayBilgisi { get; set; }
        public bool sonuc { get; set; }
    }

    public class Nacefaaliyetkoduvetanimi
    {
        public string faaliyetAdi { get; set; }
        public string faaliyetKodu { get; set; }
        public string sira { get; set; }
    }

    public class Adresbilgileri
    {
        public string adresTipi { get; set; }
        public string adresTipiAciklamasi { get; set; }
        public string mahalleSemt { get; set; }
        public object koy { get; set; }
        public string caddeSokak { get; set; }
        public string disKapiNo { get; set; }
        public string icKapiNo { get; set; }
        public object beldeBucak { get; set; }
        public string ilceAdi { get; set; }
        public string ilAdi { get; set; }
        public object ilKodu { get; set; }
        public object ilceKodu { get; set; }
    }
}

