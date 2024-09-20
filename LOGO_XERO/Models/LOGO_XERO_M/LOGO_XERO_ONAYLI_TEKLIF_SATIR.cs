using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_XERO_M
{
    public class LOGO_XERO_ONAYLI_TEKLIF_SATIR
    {
        public int ID { get; set; }
        public int? TUR { get; set; }

        public int TEKLIFSATIRID { get; set; }
        public int SATIRTIPI { get; set; }

        public int TEKLIFID { get; set; }

        public int? SIRANO { get; set; }

        public int? TRCODE { get; set; }

        public int? STOKLOGICALREF { get; set; }

        public string STOKKODU { get; set; }

        public string STOKADI { get; set; }

        public string FIYATGURUBU { get; set; }

        public string BIRIM { get; set; }

        public string MARKA { get; set; }

        public string STOKACIKLAMA { get; set; }

        public string SATIRACIKLAMA { get; set; }

        public double? MIKTAR { get; set; }
        public double? ONAYLANANMIKTAR { get; set; }
        public double? TESLIMMIKTAR { get; set; }
        public double? KALANMIKTAR { get; set; }

        public double? ORJINALISKONTO { get; set; }

        public double? ISKONTOYUZDESI1 { get; set; }

        public double? ISKONTOYUZDESI2 { get; set; }

        public double? ISKONTOYUZDESI3 { get; set; }

        public double? ISKONTOTUTARI1 { get; set; }

        public double? ISKONTOTUTARI2 { get; set; }

        public double? ISKONTOTUTARI3 { get; set; }

        public double? KDV { get; set; }

        public double? KDVTUTARI { get; set; }
        public double? ONAYLANANKDVTUTARI { get; set; }


        public string LOTKODU { get; set; }


        public double? FIYAT { get; set; }
        public double? NETFIYAT { get; set; } // TABLOYA EKLENECEK
        public double? DOVIZLIFIYAT { get; set; }
        public double? TUTAR { get; set; }
        public double? ONAYLANANTUTAR { get; set; }
        public double? ISKONTOLUTUTAR { get; set; } // ISKONTO TOPLAM TUTAR
        public double? ONAYLANANISKONTOLUTUTAR { get; set; }
        //public double? NETTUTAR { get; set; } // TABLOYA EKLENECEK
        public double? TOPLAMTUTAR { get; set; } // TABLOYA EKLENECEK
        public double? ONAYLANANTOPLAMTUTAR { get; set; }




        public DateTime? TESLIMTARIHI { get; set; }

        public string TALEPEDENFIRMA { get; set; }

        public short? ISYERI { get; set; }

        public short? BOLUM { get; set; }

        public short? FABRIKA { get; set; }

        public short? AMBAR { get; set; }

        public double? NAKLIYEBEDELI { get; set; }



        public bool? TEVKIFATLI { get; set; }

        public string TEVKIFATKODU { get; set; }
        public string TESLIMSURESI { get; set; }

        public double? TEVKIFATCARPAN { get; set; }

        public double? TEVKIFATBOLEN { get; set; }


        public short? RAPORLAMADOVIZI { get; set; }

        public short? ISLEMDOVIZI { get; set; }

        public double? RAPORLAMADOVIZKURU { get; set; }

        public double? ISLEMDOVIZKURU { get; set; }

        public short? SATIRDOVIZKODU { get; set; }

        public double? SATIRDOVIZKURU { get; set; }

        public DateTime? DOVIZKURUTARIHI { get; set; }

        public string OZELKOD1 { get; set; } // TABLOYA EKLENECEK

        public string OZKODACIKLAMA { get; set; } // TABLOYA EKLENECEK
        public string KDVMUAFIYETKODU { get; set; }
        public string KDVMUAFIYETACIKLAMA { get; set; }
    }
}
