using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models.LOGO_XERO_M
{
    public class LOGO_XERO_PARAMETRELER
    {
        public int ID { get; set; }

        public string FIRMANO { get; set; }

        public string DONEMNO { get; set; }

        public byte[] FATURALOGO { get; set; }

        public byte[] FATURAIMZA { get; set; }

        public byte[] LOGINLOGO { get; set; }

        public byte[] EFATURALOGO { get; set; }

        public byte[] EARSIVLOGO { get; set; }

        public string ARASKARGOUSERNAME { get; set; }

        public string ARASKARGOPASSWORD { get; set; }

        public string ARASKARGOGONDERITIPI { get; set; }

        public string BANKA1 { get; set; }

        public string IBAN1 { get; set; }

        public string BANKASUBE1 { get; set; }

        public string BANKAHESAPNO1 { get; set; }

        public string BANKA2 { get; set; }

        public string IBAN2 { get; set; }

        public string BANKASUBE2 { get; set; }

        public string BANKAHESAPNO2 { get; set; }

        public string BANKA3 { get; set; }

        public string IBAN3 { get; set; }

        public string BANKASUBE3 { get; set; }

        public string BANKAHESAPNO3 { get; set; }

        public string BANKA4 { get; set; }

        public string IBAN4 { get; set; }

        public string BANKASUBE4 { get; set; }

        public string BANKAHESAPNO4 { get; set; }

        public string BANKA5 { get; set; }

        public string IBAN5 { get; set; }

        public string BANKASUBE5 { get; set; }

        public string BANKAHESAPNO5 { get; set; }

        public bool? SMSID { get; set; }

        public string SMSUSER { get; set; }

        public string SMSPASSWORD { get; set; }

        public string SMSHEADER { get; set; }

        public string PROGRAMKATALOGDOSYAYOLU { get; set; }

        public string SOZLESMELICARIDOSYAYOLU { get; set; }

        public int? KULLANILACAKDOVIZTURU { get; set; }

        public int? STANDARTPARABIRIMI { get; set; }

        public string MALIMUSAVIR_TOKEN { get; set; }

        public bool? GIBSORGULAMAYAPABILSIN { get; set; }

        public string GIBUSERNAME { get; set; }

        public string GIBPASSWORD { get; set; }

        public string FATURAALTNOT { get; set; }

        public string TEKLIFALTNOT { get; set; }

        public string MAILSERVER { get; set; }

        public string MAILPORT { get; set; }

        public bool? SSLGEREKLIMI { get; set; }

        public int? LOGOBAGLANTISECIMI { get; set; }
        public int? LOGOPAKETSECIMI { get; set; }

        public string OBJESERVISURL { get; set; }
        public string OBJEKULLANICIADI { get; set; }
        public string OBJEKULLANICISIFRE { get; set; }

        public string RESTSERVISURL { get; set; }

        public string RESTSERVISKULLANICIADI { get; set; }

        public string RESTSERVISSIFRE { get; set; }
        public string RESTSERVISTOKEN { get; set; }

        public bool? ZC_OZELKOD1 { get; set; }

        public bool? ZC_OZELKOD2 { get; set; }

        public bool? ZC_OZELKOD3 { get; set; }

        public bool? ZC_OZELKOD4 { get; set; }

        public bool? ZC_OZELKOD5 { get; set; }

        public bool? ZC_ODEMEPLANI_VADE { get; set; }

        public bool? ZC_EPOSTA1 { get; set; }

        public bool? ZC_EPOSTA2 { get; set; }

        public bool? ZC_EPOSTA3 { get; set; }

        public bool? ZC_TICARIISLEMGRUBU { get; set; }

        public bool? ZC_MUHASEBEKODU { get; set; }

        public string ZC_BAGLISATISELEMANIALANI { get; set; }

        public string ZC_BAGLIHAZIRLAYANALANI { get; set; }

        public string ZC_BAGLIPAZARLAYANALANI { get; set; }

        public bool? ZSTK_OZELKOD1 { get; set; }

        public bool? ZSTK_OZELKOD2 { get; set; }

        public bool? ZSTK_OZELKOD3 { get; set; }

        public bool? ZSTK_OZELKOD4 { get; set; }

        public bool? ZSTK_OZELKOD5 { get; set; }

        public bool? ZSTK_MARKA { get; set; }

        public bool? ZSTK_GRUPKODU { get; set; }


        public bool? ZSTK_FIYAT { get; set; }

        public bool? Z_STKLF_HAZIRLAYANPERSONEL { get; set; }

        public bool? Z_STKLF_SATISELEMANI { get; set; }

        public bool? Z_STKLF_OZELKOD { get; set; }

        public bool? Z_STKLF_YETKIKOD { get; set; }

        public bool? Z_STKLF_PROJEKOD { get; set; }

        public bool? Z_STKLF_TICISLGRUP { get; set; }

        public bool? Z_STKLF_ODEMETIP { get; set; }

        public bool? Z_STKLF_TASIYICIKOD { get; set; }

        public bool? Z_SSPRS_HAZIRLAYANPERSONEL { get; set; }

        public bool? Z_SSPRS_SATISELEMANI { get; set; }

        public bool? Z_SSPRS_OZELKOD { get; set; }

        public bool? Z_SSPRS_YETKIKOD { get; set; }

        public bool? Z_SSPRS_PROJEKOD { get; set; }

        public bool? Z_SSPRS_TICISLGRUP { get; set; }

        public bool? Z_SSPRS_ODEMETIP { get; set; }

        public bool? Z_SSPRS_TASIYICIKOD { get; set; }

        public bool? Z_SIRS_HAZIRLAYANPERSONEL { get; set; }

        public bool? Z_SIRS_SATISELEMANI { get; set; }

        public bool? Z_SIRS_OZELKOD { get; set; }

        public bool? Z_SIRS_YETKIKOD { get; set; }

        public bool? Z_SIRS_PROJEKOD { get; set; }

        public bool? Z_SIRS_TICISLGRUP { get; set; }

        public bool? Z_SIRS_ODEMETIP { get; set; }

        public bool? Z_SIRS_TASIYICIKOD { get; set; }

        public bool? Z_SF_HAZIRLAYANPERSONEL { get; set; }

        public bool? Z_SF_SATISELEMANI { get; set; }

        public bool? Z_SF_OZELKOD { get; set; }

        public bool? Z_SF_YETKIKOD { get; set; }

        public bool? Z_SF_PROJEKOD { get; set; }

        public bool? Z_SF_TICISLGRUP { get; set; }

        public bool? Z_SF_ODEMETIP { get; set; }

        public bool? Z_SF_TASIYICIKOD { get; set; }

        public bool? Z_ATKLF_HAZIRLAYANPERSONEL { get; set; }

        public bool? Z_ATKLF_SATISELEMANI { get; set; }

        public bool? Z_ATKLF_OZELKOD { get; set; }

        public bool? Z_ATKLF_YETKIKOD { get; set; }

        public bool? Z_ATKLF_PROJEKOD { get; set; }

        public bool? Z_ATKLF_TICISLGRUP { get; set; }

        public bool? Z_ATKLF_ODEMETIP { get; set; }

        public bool? Z_ATKLF_TASIYICIKOD { get; set; }

        public bool? Z_ASPRS_HAZIRLAYANPERSONEL { get; set; }

        public bool? Z_ASPRS_SATISELEMANI { get; set; }

        public bool? Z_ASPRS_OZELKOD { get; set; }

        public bool? Z_ASPRS_YETKIKOD { get; set; }

        public bool? Z_ASPRS_PROJEKOD { get; set; }

        public bool? Z_ASPRS_TICISLGRUP { get; set; }

        public bool? Z_ASPRS_ODEMETIP { get; set; }

        public bool? Z_ASPRS_TASIYICIKOD { get; set; }

        public bool? Z_AIRS_HAZIRLAYANPERSONEL { get; set; }

        public bool? Z_AIRS_SATISELEMANI { get; set; }

        public bool? Z_AIRS_OZELKOD { get; set; }

        public bool? Z_AIRS_YETKIKOD { get; set; }

        public bool? Z_AIRS_PROJEKOD { get; set; }

        public bool? Z_AIRS_TICISLGRUP { get; set; }

        public bool? Z_AIRS_ODEMETIP { get; set; }

        public bool? Z_AIRS_TASIYICIKOD { get; set; }

        public bool? Z_AF_HAZIRLAYANPERSONEL { get; set; }

        public bool? Z_AF_SATISELEMANI { get; set; }

        public bool? Z_AF_OZELKOD { get; set; }

        public bool? Z_AF_YETKIKOD { get; set; }

        public bool? Z_AF_PROJEKOD { get; set; }

        public bool? Z_AF_TICISLGRUP { get; set; }

        public bool? Z_AF_ODEMETIP { get; set; }

        public bool? Z_AF_TASIYICIKOD { get; set; }

        public bool? Z_MF_OZELKOD { get; set; }

        public bool? Z_MF_YETKIKOD { get; set; }

        public bool? MC_OTOMATIKMUHASEBEOLUSTUR { get; set; }

        public bool? MC_AMBAR_OTOTMATIKKODVER { get; set; }

        public bool? M_STKLF_FIYATSIZFISKAYDEDEBILMA { get; set; }

        public bool? M_STKLF_CIKTIDASECMELITASARIMKULLAN { get; set; }

        public bool? M_STKLF_CARISONBAKIYEGORUNSUN { get; set; }

        public bool? M_STKLF_COKLUSIPARISOLUSTURMA { get; set; }

        public bool? M_STKLF_MIKTARHESAPLAMAKULLAN { get; set; }

        public bool? M_SSPRS_FIYATSIZFISKAYDEDEBILME { get; set; }

        public bool? M_SSPRS_CIKTIDASECMELITASARIMKULLAN { get; set; }

        public bool? M_SSPRS_CARISONBAKIYEGORUNSUN { get; set; }

        public bool? M_SSPRS_KAYITIPTALETMECIKARMA { get; set; }

        public bool? M_SSPRS_MIKTARHESAPLAMAKULLAN { get; set; }

        public bool? M_SIRS_FIYATSIZFISKAYDEDEBILME { get; set; }

        public bool? M_SIRS_CIKTIDASECMELITASARIMKULLAN { get; set; }

        public bool? M_SIRS_CARISONBAKIYEGORUNSUN { get; set; }

        public bool? M_SIRS_KAYITIPTALETMECIKARMA { get; set; }

        public bool? M_SIRS_MIKTARHESAPLAMAKULLAN { get; set; }

        public bool? M_SF_FIYATSIZFISKAYDEDEBILME { get; set; }

        public bool? M_SF_CIKTIDASECMELITASARIMKULLAN { get; set; }

        public bool? M_SF_CARISONBAKIYEGORUNSUN { get; set; }

        public bool? M_SF_KAYITIPTALETMECIKARMA { get; set; }

        public bool? M_SF_KAGITFATURAKESIMI { get; set; }

        public bool? M_SF_NUMARATORDEISYERINEBAKILSIN { get; set; }

        public bool? M_SF_NUMARATORDEAMBARABAKILSIN { get; set; }

        public bool? M_SF_EFATURAKONTROLUYAPILSIN { get; set; }

        public bool? M_SF_MIKTARHESAPLAMAKULLAN { get; set; }

        public bool? M_ATKLF_FIYATSIZFISKAYDEDEBILME { get; set; }

        public bool? M_ATKLF_CIKTIDASECMELITASARIMKULLAN { get; set; }

        public bool? M_ATKLF_CARISONBAKIYEGORUNSUN { get; set; }

        public bool? M_ATKLF_COKLUSIPARISOLUSTURMA { get; set; }

        public bool? M_ATKLF_MIKTARHESAPLAMAKULLAN { get; set; }

        public bool? M_ASPRS_FIYATSIZFISKAYDEDEBILME { get; set; }

        public bool? M_ASPRS_CIKTIDASECMELITASARIMKULLAN { get; set; }

        public bool? M_ASPRS_CARISONBAKIYEGORUNSUN { get; set; }

        public bool? M_ASPRS_KAYITIPTALETMECIKARMA { get; set; }

        public bool? M_ASPRS_MIKTARHESAPLAMAKULLAN { get; set; }

        public bool? M_AIRS_FIYATSIZFISKAYDEDEBILME { get; set; }

        public bool? M_AIRS_CIKTIDASECMELITASARIMKULLAN { get; set; }

        public bool? M_AIRS_CARISONBAKIYEGORUNSUN { get; set; }

        public bool? M_AIRS_KAYITIPTALETMECIKARMA { get; set; }

        public bool? M_AIRS_MIKTARHESAPLAMAKULLAN { get; set; }

        public bool? M_AF_FIYATSIZFISKAYDEDEBILME { get; set; }

        public bool? M_AF_CIKTIDASECMELITASARIMKULLAN { get; set; }

        public bool? M_AF_CARISONBAKIYEGORUNSUN { get; set; }

        public bool? M_AF_KAYITIPTALETMECIKARMA { get; set; }

        public bool? M_AF_KAGITFATURAKESIMI { get; set; }

        public bool? M_AF_NUMARATORDEISYERINEBAKILSIN { get; set; }

        public bool? M_AF_NUMARATORDEAMBARABAKILSIN { get; set; }

        public bool? M_AF_EFATURAKONTROLUYAPILSIN { get; set; }

        public bool? M_AF_MIKTARHESAPLAMAKULLAN { get; set; }

        public bool? M_MF_AMBARFISINDEONDEGERKAGITGELSIN { get; set; }

        public bool? M_MF_CIKTIDASECMELITASARIMKULLAN { get; set; }

        public bool? M_MF_MIKTARHESAPLAMAKULLAN { get; set; }

        public bool? M_GNL_BARKODOKUTMAMIKTARBIRLESIMI { get; set; }

        public bool? M_GNL_KAYITLARDANSONRASAYFAKAPAT { get; set; }

        public bool? M_GNL_KAYITLARDANSONRASAYFAYENILE { get; set; }

        public bool? M_GNL_ALTERNATIFURUNONERISIAKTIF { get; set; }

        public bool? M_GNL_KULLANICIKASABAGLANTISI { get; set; }

        public int? M_GNL_ALISFIYATININALTINDA_YAPILACAKISLEM { get; set; }

        public string M_GNL_ALISFIYATUSTUNEKARORANI { get; set; }

        public int? M_GNL_LISTELERIN_GUNFARKI { get; set; }

        public int? FYTPRMT_OZELFIYATSECENEGI { get; set; }

        public string FYTPRMT_PERAKENDEFIYATGRUBU { get; set; }

        public string FYTPRMT_FIYATGRUBU { get; set; }

        public string FYTPRMT_ETICARETFIYATGRUBU { get; set; }

        public bool? MIKTARH_1ALANKULLAN { get; set; }

        public bool? MIKTARH_2ALANKULLAN { get; set; }

        public bool? MIKTARH_3ALANKULLAN { get; set; }

        public bool? MIKTARH_4ALANKULLAN { get; set; }

        public bool? MIKTARH_5ALANKULLAN { get; set; }
        public bool? Z_ATKLF_VADE { get; set; }
        public bool? Z_STKLF_VADE { get; set; }

        public bool? Z_ASPRS_VADE { get; set; }
        public bool? Z_SSPRS_VADE { get; set; }

        public bool? Z_AIRS_VADE { get; set; }
        public bool? Z_SIRS_VADE { get; set; }
        public bool? Z_SF_VADE { get; set; }
        public bool? Z_AF_VADE { get; set; }


        public string MIKTARH_1ALANADI { get; set; }

        public string MIKTARH_2ALANADI { get; set; }

        public string MIKTARH_3ALANADI { get; set; }

        public string MIKTARH_4ALANADI { get; set; }

        public string MIKTARH_5ALANADI { get; set; }

        public double? MIKTARH_1ALANVARSDEGER { get; set; }

        public double? MIKTARH_2ALANVARSDEGER { get; set; }

        public double? MIKTARH_3ALANVARSDEGER { get; set; }

        public double? MIKTARH_4ALANVARSDEGER { get; set; }

        public double? MIKTARH_5ALANVARSDEGER { get; set; }

        public string MIKTARH_FORMUL { get; set; }
        public string OZELFIYATKARTSUTUNAD { get; set; }
        public int MSTK_OTOBARKODLOGICALREF { get; set; }
    }
}
