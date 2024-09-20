using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.GenelKullanim
{
    public class KULLANICILAR
    {
        public int ID { get; set; }
        public string KULLANICIADI { get; set; }
        public string LOGOSATISELEMANIID { get; set; }
        public string SIFRE { get; set; }
        public string TANIMLIFIRMA { get; set; }
        public string TANIMLIDONEM { get; set; }
        public int ISYERI { get; set; }
        public int BOLUM { get; set; }
        public int FABRIKA { get; set; }
        public int AMBAR { get; set; }
        public string TELEFON { get; set; }
        public string EPOSTA { get; set; }
        public string ILCE { get; set; }
        public string IL { get; set; }
        public string ADRES { get; set; }
        public int? GOREV { get; set; }
        public int TEKLIFTUTARILIMIT { get; set; }
        public string KISITLIOZELKOD { get; set; }
        public float ISKONTOLIMIT { get; set; }
        public int GIRISAMBAR { get; set; }
        public int GIRISISYERI { get; set; }
        public int GIRISBOLUM { get; set; }
        public string YETKI { get; set; }
        [Required]
        public string GOREVTANIMI { get; set; }
    }
}
