using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Logic
{
    public class LOGO_XERO_FATURA_BASLIK
    { 
        public int LOGICALREF { get; set; }
         
        public string FISNO { get; set; }
        public Int16 CONTROLINFO { get; set; } 
        public bool? CONTROLDURUM { get; set; }
        public Int16? BOLUMID { get; set; }
        public int? CARILOG { get; set; } 
        public string BELGENO { get; set; }
        public string GENEXP2 { get; set; }
        public string GENEXP3 { get; set; }
        public string GENEXP4 { get; set; }
        public string GENEXP5 { get; set; }
        public string GENEXP6 { get; set; }

        public DateTime? TARIH { get; set; } 
        public string SAAT { get; set; } 
        public DateTime? SEVKTARIHI { get; set; }
          
        public string CARIKODU { get; set; }
          
        public string CARIUNVANI { get; set; }
         
        public string OZELKOD1 { get; set; }
         
        public string OZELKOD2 { get; set; }
         
        public string OZELKOD4 { get; set; } 
        public string TELEFON { get; set; } 
        public string TICARIISLEMGRUBU { get; set; } 
        public string GRUPACIKLAMA { get; set; } 
        public short? ISYERINO { get; set; }  
        public short? AMBARNO { get; set; }  
        public string EFATURA { get; set; } 
        public string ACIKLAMA { get; set; } 
        public int? SALESMANREF { get; set; }
        public string BOLUMADI { get; set; }   
        public double? TUTAR { get; set; } 
        public double? ISKONTOTUTARI { get; set; }  
        public double? ISKONTOLUTUTAR { get; set; } 
        public double? KDVTUTARI { get; set; } 
        public double? TOPLAMTUTAR { get; set; } 
        public double? GENELISKONTO { get; set; } 
        public int? ODEMETIPIID { get; set; } 
        public int? ODEMETIPI { get; set; }   
        public string FATURATIPI { get; set; }  
        public string GUID { get; set; }  
        public string TRCODE { get; set; } 
        public string PERAKENDETCNO { get; set; } 
        public string PERAKENDEADISOYADI { get; set; }  
        public short? ISCOMP { get; set; } 
        public string DEFINITION_ { get; set; }  
        public string TAXOFFICE { get; set; }  
        public string TELNO { get; set; }  
        public string ADRES { get; set; } 
        public string SEHIR { get; set; } 
        public string ILCE { get; set; } 
        public string EMAILADRES { get; set; } 
        public string EFATURASTATUSU { get; set; } 
        public short? YAZDIRMABILGISI { get; set; } 
        public string DOKUMANIZLEMENO { get; set; } 
        public DateTime? VADETARIHI { get; set; } 
        public string SEVKIYATADRESKODU { get; set; } 
        public string SEVKIYATADRESI { get; set; } 
        public string DURUMU { get; set; } 
        public string PAZARLAYAN { get; set; } 
        public string HAZIRLAYAN { get; set; } 
        public short? TEVKIFATTIP { get; set; } 
        public string VERGINO { get; set; } 
        public string VERGIDAIRESI { get; set; } 
        public string TCKNO { get; set; } 
        public string SPECODE3 { get; set; } 
        public short? SENDMOD { get; set; }
    }
}
