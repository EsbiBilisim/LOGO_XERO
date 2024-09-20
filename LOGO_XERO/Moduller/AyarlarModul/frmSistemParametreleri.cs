using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using LOGO_XERO.Models.GenelKullanim;
using LOGO_XERO.Models.LOGO_M;
using LOGO_XERO.Models.LOGO_XERO_M;
using LOGO_XERO.Moduller.Personeller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGO_XERO.Moduller.Giris_AnaForm_Ayarlar
{
    public partial class frmSistemParametreleri : DevExpress.XtraEditors.XtraForm
    {

        public string gelenfirma = "";
        public string gelendonem = "";
        public int loginden = 0;
        List<L_CAPIFIRM> firmaListesi = new List<L_CAPIFIRM>();
        List<L_CAPIPERIOD> donemListesi = new List<L_CAPIPERIOD>();
        IlkTabloIslemler islem = new IlkTabloIslemler();
        MemoryStream ms;
        SQLConnection clas = new SQLConnection();
        public frmSistemParametreleri()
        {
            InitializeComponent();
        }
        private void btn_vazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSistemParametreleri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btn_vazgec_Click(sender, e);
            }
            if (e.KeyCode == Keys.F2)
            {
                btn_kaydet_Click(sender, e);
            }
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            string numarator = "";

            //if (Demomu == 0)
            //{
                if (Convert.ToInt32(rd_LogoBaglantiSecimi.EditValue) == 1)
                {
                    if (string.IsNullOrWhiteSpace(txt_RestServisLogoKullanici.Text) || string.IsNullOrWhiteSpace(txt_RestServisLogoKullaniciSifre.Text) || string.IsNullOrWhiteSpace(txt_RestServisUrl.Text))
                    {
                        XtraMessageBox.Show("LOGO BAĞLANTISI REST SERVİS SEÇİLİ İSE REST SERVİS İÇİN GEREKLİ BİLGİLERİ BOŞ BIRAKAMAZSINIZ !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                if (Convert.ToInt32(rd_LogoBaglantiSecimi.EditValue) == 2)
                {
                    if (string.IsNullOrWhiteSpace(txt_ObjeServisUrl.Text) || string.IsNullOrWhiteSpace(txt_ObjeKullaniciAdi.Text) || string.IsNullOrWhiteSpace(txt_ObjeKullaniciSifre.Text))
                    {
                        XtraMessageBox.Show("LOGO BAĞLANTISI OBJE SEÇİLİ İSE OBJE İÇİN GEREKLİ BİLGİLERİ BOŞ BIRAKAMAZSINIZ !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                if (Convert.ToInt32(rd_LogoPaketSecimi.EditValue) == 0 || rd_LogoPaketSecimi.EditValue == null)
                {
                    XtraMessageBox.Show("LOGO PAKET SEÇİMİ ZORUNLUDUR !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rd_LogoPaketSecimi.Focus();
                    return;
                }
            //}


            if (LK_sirket.EditValue == null)
            {
                XtraMessageBox.Show("FİRMA SEÇİMİ ZORUNLUDUR !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LK_sirket.Focus();
                return;
            }
            if (Lk_donem.EditValue == null)
            {
                XtraMessageBox.Show("DÖNEM SEÇİMİ ZORUNLUDUR !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Lk_donem.Focus();
                return;
            }



            if (ck_IlkHesaplamaAlaniniKullan.Checked == true)
            {
                if (string.IsNullOrWhiteSpace(txt_1AlanAdi.Text))
                {
                    XtraMessageBox.Show("1. ALAN ADI DOLDURULMASI ZORUNLUDUR !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_1AlanAdi.Focus();
                    return;
                }
            }

            if (ck_IkinciHesaplamaAlaniniKullan.Checked == true)
            {
                if (string.IsNullOrWhiteSpace(txt_2AlanAdi.Text))
                {
                    XtraMessageBox.Show("2. ALAN ADI DOLDURULMASI ZORUNLUDUR !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_2AlanAdi.Focus();
                    return;
                }
            }

            if (ck_UcüncüHesaplamaAlaniniKullan.Checked == true)
            {
                if (string.IsNullOrWhiteSpace(txt_3AlanAdi.Text))
                {
                    XtraMessageBox.Show("3. ALAN ADI DOLDURULMASI ZORUNLUDUR !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_3AlanAdi.Focus();
                    return;
                }
            }

            if (ck_DorduncuHesaplamaAlaniniKullan.Checked == true)
            {
                if (string.IsNullOrWhiteSpace(txt_4AlanAdi.Text))
                {
                    XtraMessageBox.Show("4. ALAN ADI DOLDURULMASI ZORUNLUDUR !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_4AlanAdi.Focus();
                    return;
                }
            }

            if (ck_BesinciHesaplamaAlaniniKullan.Checked == true)
            {
                if (string.IsNullOrWhiteSpace(txt_5AlanAdi.Text))
                {
                    XtraMessageBox.Show("5. ALAN ADI DOLDURULMASI ZORUNLUDUR !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_5AlanAdi.Focus();
                    return;
                }
            }
            if (rd_FiyatParametreleriOzelFiyatSecenegi.EditValue.ToString() == "2")
            {
                if (ozelfiyatkartalanilk.EditValue == null)
                {
                    XtraMessageBox.Show("ÖZEL TANIMLI FİYAT KARTI SEÇİLİYSE SUTUN SEÇİLMESİ ZORUNLUDUR !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ozelfiyatkartalanilk.Focus();
                    return;
                } 
            }

            try
            {
                string editvaluesorgu = ozelfiyatkartalanilk.EditValue  == null ? " " : ozelfiyatkartalanilk.EditValue.ToString();
                clas.Connect();
                string sqlParametre = $@"SELECT TOP 1 * FROM LOGO_XERO_PARAMETRELER";
                SqlCommand cmd = new SqlCommand(sqlParametre, clas.Conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);


                double MiktarHesaplamavarsayilanDeger1 = 0;
                double MiktarHesaplamavarsayilanDeger2 = 0;
                double MiktarHesaplamavarsayilanDeger3 = 0;
                double MiktarHesaplamavarsayilanDeger4 = 0;
                double MiktarHesaplamavarsayilanDeger5 = 0;
                if (!string.IsNullOrWhiteSpace(txt_1VarsayilanDeger.Text))
                {
                    MiktarHesaplamavarsayilanDeger1 = Convert.ToDouble(txt_1VarsayilanDeger.Text);
                }
                if (!string.IsNullOrWhiteSpace(txt_2VarsayilanDeger.Text))
                {
                    MiktarHesaplamavarsayilanDeger2 = Convert.ToDouble(txt_2VarsayilanDeger.Text);
                }
                if (!string.IsNullOrWhiteSpace(txt_3VarsayilanDeger.Text))
                {
                    MiktarHesaplamavarsayilanDeger3 = Convert.ToDouble(txt_3VarsayilanDeger.Text);
                }
                if (!string.IsNullOrWhiteSpace(txt_4VarsayilanDeger.Text))
                {
                    MiktarHesaplamavarsayilanDeger4 = Convert.ToDouble(txt_4VarsayilanDeger.Text);
                }
                if (!string.IsNullOrWhiteSpace(txt_5VarsayilanDeger.Text))
                {
                    MiktarHesaplamavarsayilanDeger5 = Convert.ToDouble(txt_5VarsayilanDeger.Text);
                }

                int alisfiyatustuneKarOrani = (txt_ModulGenelAlisfiyatininorani.Text == "") ? 0 : Convert.ToInt32(txt_ModulGenelAlisfiyatininorani.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    string sqlParametreSeciliFirma = $@"SELECT TOP 1 * FROM LOGO_XERO_PARAMETRELER WHERE FIRMANO='{LK_sirket.EditValue.ToString()}' AND DONEMNO='{Lk_donem.EditValue.ToString()}'";
                    SqlCommand cmdSecili = new SqlCommand(sqlParametreSeciliFirma, clas.Conn);
                    SqlDataAdapter daSecili = new SqlDataAdapter(cmdSecili);
                    DataSet dsSecili = new DataSet();
                    daSecili.Fill(dsSecili);
                    if (dsSecili.Tables[0].Rows.Count > 0)
                    {
                       
                        string sqlGuncelleme = $@"UPDATE [LOGO_XERO_PARAMETRELER]
SET 
ARASKARGOUSERNAME='{txt_ArasKargoEntegrasyonKullaniciAdi.Text}',
ARASKARGOPASSWORD='{txt_ArasKargoEntegrasyonKargoSifre.Text}',
ARASKARGOGONDERITIPI='{txt_ArasKargoEntegrasyonKargoGonderiTipi.Text}',
BANKA1='{txt_Banka1Adı.Text}',
IBAN1='{txt_Banka1Iban.Text}',
BANKASUBE1='{txt_Banka1SubeAdi.Text}',
BANKAHESAPNO1='{txt_Banka1HesapNo.Text}',
BANKA2='{txt_Banka2Adı.Text}',
IBAN2='{txt_Banka2Iban.Text}',
BANKASUBE2='{txt_Banka2SubeAdi.Text}',
BANKAHESAPNO2='{txt_Banka2HesapNo.Text}',
BANKA3='{txt_Banka3Adı.Text}',
IBAN3='{txt_Banka3Iban.Text}',
BANKASUBE3='{txt_Banka3SubeAdi.Text}',
BANKAHESAPNO3='{txt_Banka3HesapNo.Text}',
BANKA4='{txt_Banka4Adı.Text}',
IBAN4='{txt_Banka4Iban.Text}',
BANKASUBE4='{txt_Banka4SubeAdi.Text}',
BANKAHESAPNO4='{txt_Banka4HesapNo.Text}',
BANKA5='{txt_Banka5Adı.Text}',
IBAN5='{txt_Banka5Iban.Text}',
BANKASUBE5='{txt_Banka5SubeAdi.Text}',
BANKAHESAPNO5='{txt_Banka5HesapNo.Text}',
SMSID={Convert.ToInt32(ck_smsGonder.Checked)},
SMSUSER='{txt_smsKullaniciAdi.Text}',
SMSPASSWORD='{txt_SmsSifre.Text}',
SMSHEADER='{txt_SmsBaslik.Text}',
PROGRAMKATALOGDOSYAYOLU='{txt_ProgramKatalogDosyaYolu.Text}',
SOZLESMELICARIDOSYAYOLU='{txt_SozlesmeliCariDosyaYolu.Text}',
KULLANILACAKDOVIZTURU={Convert.ToInt32(rd_OtomatikDovizTuru.EditValue)},
STANDARTPARABIRIMI={Convert.ToInt32(rd_StandartKullanilacakParaBirimi.EditValue)},
MALIMUSAVIR_TOKEN='{txt_GibMaliMusavirTokenBilgisi.Text}',
GIBSORGULAMAYAPABILSIN={Convert.ToInt32(ck_GibSorgulamaYapabilsin.Checked)},
GIBUSERNAME='{txt_ElogoKullaniciAdi.Text}',
GIBPASSWORD='{txt_ElogoKullaniciSifre.Text}',
FATURAALTNOT='{txt_FaturaAltNotu.Text}',
TEKLIFALTNOT='{txt_TeklifAltNotu.Text}',
MAILSERVER='{txt_mailServer.Text}',
MAILPORT='{txt_mailPort.Text}',
SSLGEREKLIMI={Convert.ToInt32(ck_mailSSlGerekli.Checked)},
LOGOBAGLANTISECIMI={Convert.ToInt32(rd_LogoBaglantiSecimi.EditValue)},
LOGOPAKETSECIMI={Convert.ToInt32(rd_LogoPaketSecimi.EditValue)},
OBJESERVISURL='{txt_ObjeServisUrl.Text}',
OBJEKULLANICIADI='{txt_ObjeKullaniciAdi.Text}',
OBJEKULLANICISIFRE='{txt_ObjeKullaniciSifre.Text}',
RESTSERVISURL='{txt_RestServisUrl.Text}',
RESTSERVISKULLANICIADI='{txt_RestServisLogoKullanici.Text}',
RESTSERVISSIFRE='{txt_RestServisLogoKullaniciSifre.Text}',
ZC_OZELKOD1={Convert.ToInt32(ck_zorunluCariKartOzelkod1.Checked)},
ZC_OZELKOD2={Convert.ToInt32(ck_zorunluCariKartOzelkod2.Checked)},
ZC_OZELKOD3={Convert.ToInt32(ck_zorunluCariKartOzelkod3.Checked)},
ZC_OZELKOD4={Convert.ToInt32(ck_zorunluCariKartOzelkod4.Checked)},
ZC_OZELKOD5={Convert.ToInt32(ck_zorunluCariKartOzelkod5.Checked)},
ZC_ODEMEPLANI_VADE={Convert.ToInt32(ck_zorunluCariKartOdemePlani.Checked)},
ZC_EPOSTA1={Convert.ToInt32(ck_zorunluCariKartEposta.Checked)},
ZC_EPOSTA2={Convert.ToInt32(ck_zorunluCariKartEposta2.Checked)},
ZC_EPOSTA3={Convert.ToInt32(ck_zorunluCariKartEposta3.Checked)},
ZC_TICARIISLEMGRUBU={Convert.ToInt32(ck_zorunluCariKartTicariIslemGurubu.Checked)},
ZC_MUHASEBEKODU={Convert.ToInt32(ck_zorunluCariKartMuhasebeKodu.Checked)},
ZC_BAGLISATISELEMANIALANI='{ck_zorunluCariKart_SatisElemaniKodunaBagliAlan.SelectedValue.ToString()}',
ZC_BAGLIHAZIRLAYANALANI='{ck_zorunluCariKart_PazarlayanKodunaBagliAlan.SelectedValue.ToString()}',
ZC_BAGLIPAZARLAYANALANI='{ck_zorunluCariKart_HazirlayanKodunaBagliAlan.SelectedValue.ToString()}',
ZSTK_OZELKOD1={Convert.ToInt32(ck_zorunluStokKartOzelkod1.Checked)},
ZSTK_OZELKOD2={Convert.ToInt32(ck_zorunluStokKartOzelkod2.Checked)},
ZSTK_OZELKOD3={Convert.ToInt32(ck_zorunluStokKartOzelkod3.Checked)},
ZSTK_OZELKOD4={Convert.ToInt32(ck_zorunluStokKartOzelkod4.Checked)},
ZSTK_OZELKOD5={Convert.ToInt32(ck_zorunluStokKartOzelkod5.Checked)},
ZSTK_MARKA={Convert.ToInt32(ck_zorunluStokKartMarka.Checked)},
ZSTK_GRUPKODU={Convert.ToInt32(ck_zorunluStokKartGrupKodu.Checked)},
ZSTK_FIYAT={Convert.ToInt32(ck_zorunluStokKartFiyat.Checked)},
Z_STKLF_HAZIRLAYANPERSONEL={Convert.ToInt32(ck_zorunluSatisTeklifHazirlayanPersonel.Checked)},
Z_STKLF_SATISELEMANI={Convert.ToInt32(ck_zorunluSatisTeklifSatisElemani.Checked)},
Z_STKLF_OZELKOD={Convert.ToInt32(ck_zorunluSatisTeklifOzelkod.Checked)},
Z_STKLF_YETKIKOD={Convert.ToInt32(ck_zorunluSatisTeklifYetkikod.Checked)},
Z_STKLF_PROJEKOD={Convert.ToInt32(ck_zorunluSatisTeklifProjekod.Checked)},
Z_STKLF_TICISLGRUP={Convert.ToInt32(ck_zorunluSatisTeklifTicariIslemGrupkod.Checked)},
Z_STKLF_ODEMETIP={Convert.ToInt32(ck_zorunluSatisTeklifOdemeTipi.Checked)},
Z_STKLF_TASIYICIKOD={Convert.ToInt32(ck_zorunluSatisTeklifTasiyiciKodu.Checked)},
Z_STKLF_VADE={Convert.ToInt32(ck_zorunluSatisTeklifVade.Checked)},
Z_SSPRS_HAZIRLAYANPERSONEL={Convert.ToInt32(ck_zorunluSatisSiparisHazirlayanPersonel.Checked)},
Z_SSPRS_SATISELEMANI={Convert.ToInt32(ck_zorunluSatisSiparisSatisElemani.Checked)},
Z_SSPRS_OZELKOD={Convert.ToInt32(ck_zorunluSatisSiparisOzelkod.Checked)},
Z_SSPRS_YETKIKOD={Convert.ToInt32(ck_zorunluSatisSiparisYetkikod.Checked)},
Z_SSPRS_PROJEKOD={Convert.ToInt32(ck_zorunluSatisSiparisProjekod.Checked)},
Z_SSPRS_TICISLGRUP={Convert.ToInt32(ck_zorunluSatisSiparisTicariIslemGrupkod.Checked)},
Z_SSPRS_ODEMETIP={Convert.ToInt32(ck_zorunluSatisSiparisOdemeTipi.Checked)},
Z_SSPRS_TASIYICIKOD={Convert.ToInt32(ck_zorunluSatisSiparisTasiyiciKodu.Checked)},
Z_SSPRS_VADE={Convert.ToInt32(ck_zorunluSatisSiparisVade.Checked)},
Z_SIRS_HAZIRLAYANPERSONEL={Convert.ToInt32(ck_zorunluSatisIrsaliyeHazirlayanPersonel.Checked)},
Z_SIRS_SATISELEMANI={Convert.ToInt32(ck_zorunluSatisIrsaliyeSatisElemani.Checked)},
Z_SIRS_OZELKOD={Convert.ToInt32(ck_zorunluSatisIrsaliyeOzelkod.Checked)},
Z_SIRS_YETKIKOD={Convert.ToInt32(ck_zorunluSatisIrsaliyeYetkikod.Checked)},
Z_SIRS_PROJEKOD={Convert.ToInt32(ck_zorunluSatisIrsaliyeProjekod.Checked)},
Z_SIRS_TICISLGRUP={Convert.ToInt32(ck_zorunluSatisIrsaliyeTicariIslemGrupkod.Checked)},
Z_SIRS_ODEMETIP={Convert.ToInt32(ck_zorunluSatisIrsaliyeOdemeTipi.Checked)},
Z_SIRS_TASIYICIKOD={Convert.ToInt32(ck_zorunluSatisIrsaliyeTasiyiciKodu.Checked)},
Z_SIRS_VADE={Convert.ToInt32(ck_zorunluSatisIrsaliyeVade.Checked)},
Z_SF_HAZIRLAYANPERSONEL={Convert.ToInt32(ck_zorunluSatisFaturaHazirlayanPersonel.Checked)},
Z_SF_SATISELEMANI={Convert.ToInt32(ck_zorunluSatisFaturaSatisElemani.Checked)},
Z_SF_OZELKOD={Convert.ToInt32(ck_zorunluSatisFaturaOzelkod.Checked)},
Z_SF_YETKIKOD={Convert.ToInt32(ck_zorunluSatisFaturaYetkikod.Checked)},
Z_SF_PROJEKOD={Convert.ToInt32(ck_zorunluSatisFaturaProjekod.Checked)},
Z_SF_TICISLGRUP={Convert.ToInt32(ck_zorunluSatisFaturaTicariIslemGrupkod.Checked)},
Z_SF_ODEMETIP={Convert.ToInt32(ck_zorunluSatisFaturaOdemeTipi.Checked)},
Z_SF_TASIYICIKOD={Convert.ToInt32(ck_zorunluSatisFaturaTasiyiciKodu.Checked)},
Z_SF_VADE={Convert.ToInt32(ck_zorunluSatisFaturaVade.Checked)},
Z_ATKLF_HAZIRLAYANPERSONEL={Convert.ToInt32(ck_zorunluSatinalmaTeklifHazirlayanPersonel.Checked)},
Z_ATKLF_SATISELEMANI={Convert.ToInt32(ck_zorunluSatinalmaTeklifSatisElemani.Checked)},
Z_ATKLF_OZELKOD={Convert.ToInt32(ck_zorunluSatinalmaTeklifOzelkod.Checked)},
Z_ATKLF_YETKIKOD={Convert.ToInt32(ck_zorunluSatinalmaTeklifYetkikod.Checked)},
Z_ATKLF_PROJEKOD={Convert.ToInt32(ck_zorunluSatinalmaTeklifProjekod.Checked)},
Z_ATKLF_TICISLGRUP={Convert.ToInt32(ck_zorunluSatinalmaTeklifTicariIslemGrupkod.Checked)},
Z_ATKLF_ODEMETIP={Convert.ToInt32(ck_zorunluSatinalmaTeklifOdemeTipi.Checked)},
Z_ATKLF_TASIYICIKOD={Convert.ToInt32(ck_zorunluSatinalmaTeklifTasiyiciKodu.Checked)},
Z_ATKLF_VADE={Convert.ToInt32(ck_zorunluSatinalmaTeklifVade.Checked)},
Z_ASPRS_HAZIRLAYANPERSONEL={Convert.ToInt32(ck_zorunluSatinalmaSiparisHazirlayanPersonel.Checked)},
Z_ASPRS_SATISELEMANI={Convert.ToInt32(ck_zorunluSatinalmaSiparisSatisElemani.Checked)},
Z_ASPRS_OZELKOD={Convert.ToInt32(ck_zorunluSatinalmaSiparisOzelkod.Checked)},
Z_ASPRS_YETKIKOD={Convert.ToInt32(ck_zorunluSatinalmaSiparisYetkikod.Checked)},
Z_ASPRS_PROJEKOD={Convert.ToInt32(ck_zorunluSatinalmaSiparisProjekod.Checked)},
Z_ASPRS_TICISLGRUP={Convert.ToInt32(ck_zorunluSatinalmaSiparisTicariIslemGrupkod.Checked)},
Z_ASPRS_ODEMETIP={Convert.ToInt32(ck_zorunluSatinalmaSiparisOdemeTipi.Checked)},
Z_ASPRS_TASIYICIKOD={Convert.ToInt32(ck_zorunluSatinalmaSiparisTasiyiciKodu.Checked)},
Z_ASPRS_VADE={Convert.ToInt32(ck_zorunluSatinalmaSiparisVade.Checked)},
Z_AIRS_HAZIRLAYANPERSONEL={Convert.ToInt32(ck_zorunluSatinalmaIrsaliyeHazirlayanPersonel.Checked)},
Z_AIRS_SATISELEMANI={Convert.ToInt32(ck_zorunluSatinalmaIrsaliyeSatisElemani.Checked)},
Z_AIRS_OZELKOD={Convert.ToInt32(ck_zorunluSatinalmaIrsaliyeOzelkod.Checked)},
Z_AIRS_YETKIKOD={Convert.ToInt32(ck_zorunluSatinalmaIrsaliyeYetkikod.Checked)},
Z_AIRS_PROJEKOD={Convert.ToInt32(ck_zorunluSatinalmaIrsaliyeProjekod.Checked)},
Z_AIRS_TICISLGRUP={Convert.ToInt32(ck_zorunluSatinalmaIrsaliyeTicariIslemGrupkod.Checked)},
Z_AIRS_ODEMETIP={Convert.ToInt32(ck_zorunluSatinalmaIrsaliyeOdemeTipi.Checked)},
Z_AIRS_TASIYICIKOD={Convert.ToInt32(ck_zorunluSatinalmaIrsaliyeTasiyiciKodu.Checked)},
Z_AIRS_VADE={Convert.ToInt32(ck_zorunluSatinalmaIrsaliyeVade.Checked)},
Z_AF_HAZIRLAYANPERSONEL={Convert.ToInt32(ck_zorunluSatinalmaFaturaHazirlayanPersonel.Checked)},
Z_AF_SATISELEMANI={Convert.ToInt32(ck_zorunluSatinalmaFaturaSatisElemani.Checked)},
Z_AF_OZELKOD={Convert.ToInt32(ck_zorunluSatinalmaFaturaOzelkod.Checked)},
Z_AF_YETKIKOD={Convert.ToInt32(ck_zorunluSatinalmaFaturaYetkikod.Checked)},
Z_AF_PROJEKOD={Convert.ToInt32(ck_zorunluSatinalmaFaturaProjekod.Checked)},
Z_AF_TICISLGRUP={Convert.ToInt32(ck_zorunluSatinalmaFaturaTicariIslemGrupkod.Checked)},
Z_AF_ODEMETIP={Convert.ToInt32(ck_zorunluSatinalmaFaturaOdemeTipi.Checked)},
Z_AF_TASIYICIKOD={Convert.ToInt32(ck_zorunluSatinalmaFaturaTasiyiciKodu.Checked)},
Z_AF_VADE={Convert.ToInt32(ck_zorunluSatinalmaFaturaVade.Checked)},
Z_MF_OZELKOD={Convert.ToInt32(ck_zorunluMalzemeFisiOzelKod.Checked)},
Z_MF_YETKIKOD={Convert.ToInt32(ck_zorunluMalzemeFisiYetkiKodu.Checked)},
MC_OTOMATIKMUHASEBEOLUSTUR={Convert.ToInt32(ck_ModulCariKartAcilisindaMuhasebeHesabiOlustur.Checked)}, 
MC_AMBAR_OTOTMATIKKODVER={Convert.ToInt32(ck_ModulCariKartAcilisindaAmbarParametresineGoreOtomatikKodVer.Checked)},
MSTK_OTOBARKODLOGICALREF={Convert.ToInt32(txt_otomatikbarkodlog.Text)},
M_STKLF_FIYATSIZFISKAYDEDEBILMA={Convert.ToInt32(ck_ModulSatisTeklifFiyatsizFisKaydedebilme.Checked)},
M_STKLF_CIKTIDASECMELITASARIMKULLAN={Convert.ToInt32(ck_ModulSatisTeklifCiktidaSecmeliTasarimKullan.Checked)},
M_STKLF_CARISONBAKIYEGORUNSUN={Convert.ToInt32(ck_ModulSatisTeklifCariSonBakiyeGorunsun.Checked)},
M_STKLF_COKLUSIPARISOLUSTURMA={Convert.ToInt32(ck_ModulSatisTeklifCokluSiparisOlusturma.Checked)}, 
M_STKLF_MIKTARHESAPLAMAKULLAN={Convert.ToInt32(ck_ModulSatisTeklifMiktarHesaplamaKullan.Checked)}, 
M_SSPRS_FIYATSIZFISKAYDEDEBILME={Convert.ToInt32(ck_ModulSatisSiparisFiyatsizFisKaydedebilme.Checked)},
M_SSPRS_CIKTIDASECMELITASARIMKULLAN={Convert.ToInt32(ck_ModulSatisSiparisCiktidaSecmeliTasarimKullan.Checked)},
M_SSPRS_CARISONBAKIYEGORUNSUN={Convert.ToInt32(ck_ModulSatisSiparisCariSonBakiyeGorunsun.Checked)},
M_SSPRS_KAYITIPTALETMECIKARMA={Convert.ToInt32(ck_ModulSatisSiparisKayitIptalEtmeCikma.Checked)},
M_SSPRS_MIKTARHESAPLAMAKULLAN={Convert.ToInt32(ck_ModulSatisSiparisMiktarHesaplamaKullan.Checked)},
M_SIRS_FIYATSIZFISKAYDEDEBILME={Convert.ToInt32(ck_ModulSatisIrsaliyeFiyatsizFisKaydedebilme.Checked)},
M_SIRS_CIKTIDASECMELITASARIMKULLAN={Convert.ToInt32(ck_ModulSatisIrsaliyeCiktidaSecmeliTasarimKullan.Checked)},
M_SIRS_CARISONBAKIYEGORUNSUN={Convert.ToInt32(ck_ModulSatisIrsaliyeCariSonBakiyeGorunsun.Checked)},
M_SIRS_KAYITIPTALETMECIKARMA={Convert.ToInt32(ck_ModulSatisIrsaliyeKayitIptalEtmeCikma.Checked)},
M_SIRS_MIKTARHESAPLAMAKULLAN={Convert.ToInt32(ck_ModulSatisIrsaliyeMiktarHesaplamaKullan.Checked)},
M_SF_FIYATSIZFISKAYDEDEBILME={Convert.ToInt32(ck_ModulSatisFaturaFiyatsizFisKaydedebilme.Checked)},
M_SF_CIKTIDASECMELITASARIMKULLAN={Convert.ToInt32(ck_ModulSatisFaturaCiktidaSecmeliTasarimKullan.Checked)},
M_SF_CARISONBAKIYEGORUNSUN={Convert.ToInt32(ck_ModulSatisFaturaCariSonBakiyeGorunsun.Checked)},
M_SF_KAYITIPTALETMECIKARMA={Convert.ToInt32(ck_ModulSatisFaturaKayitIptalEtmeCikma.Checked)},
M_SF_KAGITFATURAKESIMI={Convert.ToInt32(ck_ModulSatisFaturaKagitFaturaKesimi.Checked)},
M_SF_NUMARATORDEISYERINEBAKILSIN={Convert.ToInt32(ck_ModulSatisFaturaFaturaNumaratorundeIsyerineBakilsin.Checked)},
M_SF_NUMARATORDEAMBARABAKILSIN={Convert.ToInt32(ck_ModulSatisFaturaFaturaNumaratorundeAmbaraBakilsin.Checked)},
M_SF_EFATURAKONTROLUYAPILSIN={Convert.ToInt32(ck_ModulSatisFaturaKayitEsnasindaEfaturaKontroluYapilsin.Checked)},
M_SF_MIKTARHESAPLAMAKULLAN={Convert.ToInt32(ck_ModulSatisFaturaMiktarHesaplamaKullan.Checked)},
M_ATKLF_FIYATSIZFISKAYDEDEBILME={Convert.ToInt32(ck_ModulSatinalmaTeklifFiyatsizFisKaydedebilme.Checked)},
M_ATKLF_CIKTIDASECMELITASARIMKULLAN={Convert.ToInt32(ck_ModulSatinalmaTeklifCiktidaSecmeliTasarimKullan.Checked)},
M_ATKLF_CARISONBAKIYEGORUNSUN={Convert.ToInt32(ck_ModulSatinalmaTeklifCariSonBakiyeGorunsun.Checked)},
M_ATKLF_COKLUSIPARISOLUSTURMA={Convert.ToInt32(ck_ModulSatinalmaTeklifCokluSiparisOlusturma.Checked)},
M_ATKLF_MIKTARHESAPLAMAKULLAN={Convert.ToInt32(ck_ModulSatinalmaTeklifMiktarHesaplamaKullan.Checked)},
M_ASPRS_FIYATSIZFISKAYDEDEBILME={Convert.ToInt32(ck_ModulSatinalmaSiparisFiyatsizFisKaydedebilme.Checked)},
M_ASPRS_CIKTIDASECMELITASARIMKULLAN={Convert.ToInt32(ck_ModulSatinalmaSiparisCiktidaSecmeliTasarimKullan.Checked)},
M_ASPRS_CARISONBAKIYEGORUNSUN={Convert.ToInt32(ck_ModulSatinalmaSiparisCariSonBakiyeGorunsun.Checked)},
M_ASPRS_KAYITIPTALETMECIKARMA={Convert.ToInt32(ck_ModulSatinalmaSiparisKayitIptalEtmeCikma.Checked)},
M_ASPRS_MIKTARHESAPLAMAKULLAN={Convert.ToInt32(ck_ModulSatinalmaSiparisMiktarHesaplamaKullan.Checked)},
M_AIRS_FIYATSIZFISKAYDEDEBILME={Convert.ToInt32(ck_ModulSatinalmaIrsaliyeFiyatsizFisKaydedebilme.Checked)},
M_AIRS_CIKTIDASECMELITASARIMKULLAN={Convert.ToInt32(ck_ModulSatinalmaIrsaliyeCiktidaSecmeliTasarimKullan.Checked)},
M_AIRS_CARISONBAKIYEGORUNSUN= {Convert.ToInt32(ck_ModulSatinalmaIrsaliyeCariSonBakiyeGorunsun.Checked)},
M_AIRS_KAYITIPTALETMECIKARMA={Convert.ToInt32(ck_ModulSatinalmaIrsaliyeKayitIptalEtmeCikma.Checked)},
M_AIRS_MIKTARHESAPLAMAKULLAN={Convert.ToInt32(ck_ModulSatinalmaIrsaliyeMiktarHesaplamaKullan.Checked)},
M_AF_FIYATSIZFISKAYDEDEBILME={Convert.ToInt32(ck_ModulSatinalmaFaturaFiyatsizFisKaydedebilme.Checked)},
M_AF_CIKTIDASECMELITASARIMKULLAN={Convert.ToInt32(ck_ModulSatinalmaFaturaCiktidaSecmeliTasarimKullan.Checked)},
M_AF_CARISONBAKIYEGORUNSUN={Convert.ToInt32(ck_ModulSatinalmaFaturaCariSonBakiyeGorunsun.Checked)},
M_AF_KAYITIPTALETMECIKARMA={Convert.ToInt32(ck_ModulSatinalmaFaturaKayitIptalEtmeCikma.Checked)},
M_AF_KAGITFATURAKESIMI={Convert.ToInt32(ck_ModulSatinalmaFaturaKagitFaturaKesimi.Checked)},
M_AF_NUMARATORDEISYERINEBAKILSIN={Convert.ToInt32(ck_ModulSatinalmaFaturaFaturaNumaratorundeIsyerineBakilsin.Checked)},
M_AF_NUMARATORDEAMBARABAKILSIN={Convert.ToInt32(ck_ModulSatinalmaFaturaFaturaNumaratorundeAmbaraBakilsin.Checked)},
M_AF_EFATURAKONTROLUYAPILSIN={Convert.ToInt32(ck_ModulSatinalmaFaturaKayitEsnasindaEfaturaKontroluYapilsin.Checked)},
M_AF_MIKTARHESAPLAMAKULLAN={Convert.ToInt32(ck_ModulSatinalmaFaturaMiktarHesaplamaKullan.Checked)},
M_MF_AMBARFISINDEONDEGERKAGITGELSIN={Convert.ToInt32(ck_ModulMalzemeFisleriAmbarFisindeOnDegerKagitGelsin.Checked)},
M_MF_CIKTIDASECMELITASARIMKULLAN={Convert.ToInt32(ck_ModulMalzemeFisleriCiktidaSecmeliTasarimKullan.Checked)},
M_MF_MIKTARHESAPLAMAKULLAN={Convert.ToInt32(ck_ModulMalzemeFisleriMiktarHesaplamaKullan.Checked)},
M_GNL_BARKODOKUTMAMIKTARBIRLESIMI={Convert.ToInt32(ck_ModulGenelModullerdeBarkodOkutmaMiktarBirlesimi.Checked)},
M_GNL_KAYITLARDANSONRASAYFAKAPAT={Convert.ToInt32(ck_ModulGenelKayitlardanSonraSayfaKapatma.Checked)},
M_GNL_KAYITLARDANSONRASAYFAYENILE={Convert.ToInt32(ck_ModulGenelKayitlardanSonraSayfaYenileme.Checked)},
M_GNL_ALTERNATIFURUNONERISIAKTIF={Convert.ToInt32(ck_ModulGenelAlternatifUrunOnerisiAktif.Checked)},
M_GNL_KULLANICIKASABAGLANTISI={Convert.ToInt32(ck_ModulGenelKullaniciKasaBaglantisiKullan.Checked)},
M_GNL_ALISFIYATININALTINDA_YAPILACAKISLEM={Convert.ToInt32(cm_ModulGenelAlisfiyatininaltindaYapilacakIslem.SelectedIndex)},
M_GNL_ALISFIYATUSTUNEKARORANI={alisfiyatustuneKarOrani},
M_GNL_LISTELERIN_GUNFARKI={Convert.ToInt32(txt_ModulGenelListelerinStandartGunFarki.Text)},
FYTPRMT_OZELFIYATSECENEGI={Convert.ToInt32(rd_FiyatParametreleriOzelFiyatSecenegi.EditValue)},
FYTPRMT_PERAKENDEFIYATGRUBU='{txt_FiyatParametreleriStandartPerakendeFiyatKodu.Text}',
FYTPRMT_FIYATGRUBU='{txt_FiyatParametreleriStandartFiyatKodu.Text}',
FYTPRMT_ETICARETFIYATGRUBU='{txt_FiyatParametreleriStandartEticaretFiyatKodu.Text}',    
MIKTARH_1ALANKULLAN={Convert.ToInt32(ck_IlkHesaplamaAlaniniKullan.Checked)},    
MIKTARH_2ALANKULLAN={Convert.ToInt32(ck_IkinciHesaplamaAlaniniKullan.Checked)},    
MIKTARH_3ALANKULLAN={Convert.ToInt32(ck_UcüncüHesaplamaAlaniniKullan.Checked)},    
MIKTARH_4ALANKULLAN={Convert.ToInt32(ck_DorduncuHesaplamaAlaniniKullan.Checked)},    
MIKTARH_5ALANKULLAN={Convert.ToInt32(ck_BesinciHesaplamaAlaniniKullan.Checked)},    
MIKTARH_1ALANADI='{txt_1AlanAdi.Text}',       
MIKTARH_2ALANADI='{txt_2AlanAdi.Text}',       
MIKTARH_3ALANADI='{txt_3AlanAdi.Text}',       
MIKTARH_4ALANADI='{txt_4AlanAdi.Text}',       
MIKTARH_5ALANADI='{txt_5AlanAdi.Text}',       
MIKTARH_1ALANVARSDEGER={MiktarHesaplamavarsayilanDeger1},       
MIKTARH_2ALANVARSDEGER={MiktarHesaplamavarsayilanDeger2},       
MIKTARH_3ALANVARSDEGER={MiktarHesaplamavarsayilanDeger3},       
MIKTARH_4ALANVARSDEGER={MiktarHesaplamavarsayilanDeger4},       
MIKTARH_5ALANVARSDEGER={MiktarHesaplamavarsayilanDeger5},
MIKTARH_FORMUL='{txt_MiktarHesaplamaFormulu.Text}', 
OZELFIYATKARTSUTUNAD = '{editvaluesorgu}'
WHERE FIRMANO='{LK_sirket.EditValue.ToString()}' AND DONEMNO='{Lk_donem.EditValue.ToString()}';

UPDATE [LOGO_XERO_BELGENUMARASI_NUMARATOR]
SET 
SSPRS_SERI='{txt_BelgeNoNumaratorSSiparis_Seri.Text}',
SSPRS_SERINO='{txt_BelgeNoNumaratorSSiparis_SeriNo.Text}',
ASPRS_SERI='{txt_BelgeNoNumaratorASiparis_Seri.Text}',
ASPRS_SERINO='{txt_BelgeNoNumaratorASiparis_SeriNo.Text}',
SIRS_SERI='{txt_BelgeNoNumaratorSIrsaliye_Seri.Text}',
SIRS_SERINO='{txt_BelgeNoNumaratorSIrsaliye_SeriNo.Text}',
AIRS_SERI='{txt_BelgeNoNumaratorAIrsaliye_Seri.Text}',
AIRS_SERINO='{txt_BelgeNoNumaratorAIrsaliye_SeriNo.Text}',
SFATURA_EARSIV_SERI='{txt_BelgeNoNumaratorSEArsiv_Seri.Text}',
SFATURA_EARSIV_SERINO='{txt_BelgeNoNumaratorSEArsiv_SeriNo.Text}',
SFATURA_EFATURA_SERI='{txt_BelgeNoNumaratorSEFatura_Seri.Text}',
SFATURA_EFATURA_SERINO='{txt_BelgeNoNumaratorSEFatura_SeriNo.Text}',
SFATURA_KAGIT_SERI='{txt_BelgeNoNumaratorSKagit_Seri.Text}',
SFATURA_KAGIT_SERINO='{txt_BelgeNoNumaratorSKagit_SeriNo.Text}',
AFATURA_SERI='{txt_BelgeNoNumaratorSatinalmaFatura_Seri.Text}',
AFATURA_SERINO='{txt_BelgeNoNumaratorSatinalmaFatura_SeriNo.Text}',
ATEKLIF_SERI='{txt_BelgeNoNumaratorATeklif_Seri.Text}',
ATEKLIF_SERINO='{txt_BelgeNoNumaratorATeklif_SeriNo.Text}',
STEKLIF_SERI='{txt_BelgeNoNumaratorSTeklif_Seri.Text}',
STEKLIF_SERINO='{txt_BelgeNoNumaratorSTeklif_SeriNo.Text}'

WHERE FIRMANO='{LK_sirket.EditValue.ToString()}' AND DONEMNO='{Lk_donem.EditValue.ToString()}';
";
                        SqlCommand cmdGuncelle = new SqlCommand(sqlGuncelleme, clas.Conn);
                        try
                        {
                            clas.Conn.Open();
                            cmdGuncelle.ExecuteNonQuery();
                            clas.Conn.Close();
                            XtraMessageBox.Show("Sistem Parametreleri Kaydedildi ! Parametrelerin Geçerliliği İçin Programı Yeniden Başlatın !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception exxx)
                        {
                            XtraMessageBox.Show("KAYIT SIRASINDA HATA OLUŞTU ! HATA = " + exxx.Message.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    else
                    {
                        string sqlEkleme = $@"INSERT INTO [dbo].[LOGO_XERO_PARAMETRELER]([FIRMANO],[DONEMNO],[ARASKARGOUSERNAME],[ARASKARGOPASSWORD],[ARASKARGOGONDERITIPI],[BANKA1],[IBAN1],[BANKASUBE1]
,[BANKAHESAPNO1],[BANKA2],[IBAN2],[BANKASUBE2],[BANKAHESAPNO2],[BANKA3],[IBAN3],[BANKASUBE3],[BANKAHESAPNO3],[BANKA4],[IBAN4]
,[BANKASUBE4],[BANKAHESAPNO4],[BANKA5],[IBAN5],[BANKASUBE5],[BANKAHESAPNO5],[SMSID],[SMSUSER],[SMSPASSWORD],[SMSHEADER],[PROGRAMKATALOGDOSYAYOLU]
,[SOZLESMELICARIDOSYAYOLU],[KULLANILACAKDOVIZTURU],[STANDARTPARABIRIMI],[MALIMUSAVIR_TOKEN],[GIBSORGULAMAYAPABILSIN],[GIBUSERNAME],[GIBPASSWORD],[FATURAALTNOT]
,[TEKLIFALTNOT],[MAILSERVER],[MAILPORT],[SSLGEREKLIMI],[LOGOBAGLANTISECIMI],[LOGOPAKETSECIMI],[OBJESERVISURL],[OBJEKULLANICIADI],[OBJEKULLANICISIFRE],[RESTSERVISURL],[RESTSERVISKULLANICIADI]
,[RESTSERVISSIFRE],[ZC_OZELKOD1],[ZC_OZELKOD2],[ZC_OZELKOD3],[ZC_OZELKOD4],[ZC_OZELKOD5],[ZC_ODEMEPLANI_VADE],[ZC_EPOSTA1],[ZC_EPOSTA2],[ZC_EPOSTA3]
,[ZC_TICARIISLEMGRUBU],[ZC_MUHASEBEKODU],[ZC_BAGLISATISELEMANIALANI],[ZC_BAGLIHAZIRLAYANALANI],[ZC_BAGLIPAZARLAYANALANI],[ZSTK_OZELKOD1],[ZSTK_OZELKOD2]
,[ZSTK_OZELKOD3],[ZSTK_OZELKOD4],[ZSTK_OZELKOD5],[ZSTK_MARKA],[ZSTK_GRUPKODU],[ZSTK_FIYAT],[Z_STKLF_HAZIRLAYANPERSONEL],[Z_STKLF_SATISELEMANI]
,[Z_STKLF_OZELKOD],[Z_STKLF_YETKIKOD],[Z_STKLF_PROJEKOD],[Z_STKLF_TICISLGRUP],[Z_STKLF_ODEMETIP],[Z_STKLF_VADE],[Z_STKLF_TASIYICIKOD],[Z_SSPRS_HAZIRLAYANPERSONEL],[Z_SSPRS_SATISELEMANI]
,[Z_SSPRS_OZELKOD],[Z_SSPRS_YETKIKOD],[Z_SSPRS_PROJEKOD],[Z_SSPRS_TICISLGRUP],[Z_SSPRS_ODEMETIP],[Z_SSPRS_VADE],[Z_SSPRS_TASIYICIKOD],[Z_SIRS_HAZIRLAYANPERSONEL],[Z_SIRS_SATISELEMANI]
,[Z_SIRS_OZELKOD],[Z_SIRS_YETKIKOD],[Z_SIRS_PROJEKOD],[Z_SIRS_TICISLGRUP],[Z_SIRS_ODEMETIP],[Z_SIRS_VADE],[Z_SIRS_TASIYICIKOD],[Z_SF_HAZIRLAYANPERSONEL],[Z_SF_SATISELEMANI]
,[Z_SF_OZELKOD],[Z_SF_YETKIKOD],[Z_SF_PROJEKOD],[Z_SF_TICISLGRUP],[Z_SF_ODEMETIP],[Z_SF_VADE],[Z_SF_TASIYICIKOD],[Z_ATKLF_HAZIRLAYANPERSONEL],[Z_ATKLF_SATISELEMANI]
,[Z_ATKLF_OZELKOD],[Z_ATKLF_YETKIKOD],[Z_ATKLF_PROJEKOD],[Z_ATKLF_TICISLGRUP],[Z_ATKLF_ODEMETIP],[Z_ATKLF_VADE],[Z_ATKLF_TASIYICIKOD]
,[Z_ASPRS_HAZIRLAYANPERSONEL],[Z_ASPRS_SATISELEMANI],[Z_ASPRS_OZELKOD],[Z_ASPRS_YETKIKOD],[Z_ASPRS_PROJEKOD],[Z_ASPRS_TICISLGRUP],[Z_ASPRS_ODEMETIP],[Z_ASPRS_VADE],[Z_ASPRS_TASIYICIKOD]
,[Z_AIRS_HAZIRLAYANPERSONEL],[Z_AIRS_SATISELEMANI],[Z_AIRS_OZELKOD],[Z_AIRS_YETKIKOD],[Z_AIRS_PROJEKOD],[Z_AIRS_TICISLGRUP],[Z_AIRS_ODEMETIP],[Z_AIRS_VADE],[Z_AIRS_TASIYICIKOD]
,[Z_AF_HAZIRLAYANPERSONEL],[Z_AF_SATISELEMANI],[Z_AF_OZELKOD],[Z_AF_YETKIKOD],[Z_AF_PROJEKOD],[Z_AF_TICISLGRUP],[Z_AF_ODEMETIP],[Z_AF_VADE],[Z_AF_TASIYICIKOD]
,[Z_MF_OZELKOD],[Z_MF_YETKIKOD],[MC_OTOMATIKMUHASEBEOLUSTUR],[MC_AMBAR_OTOTMATIKKODVER],[MSTK_OTOBARKODLOGICALREF],[M_STKLF_FIYATSIZFISKAYDEDEBILMA],[M_STKLF_CIKTIDASECMELITASARIMKULLAN],[M_STKLF_CARISONBAKIYEGORUNSUN],[M_STKLF_COKLUSIPARISOLUSTURMA],[M_STKLF_MIKTARHESAPLAMAKULLAN],[M_SSPRS_FIYATSIZFISKAYDEDEBILME]
,[M_SSPRS_CIKTIDASECMELITASARIMKULLAN],[M_SSPRS_CARISONBAKIYEGORUNSUN],[M_SSPRS_KAYITIPTALETMECIKARMA],[M_SSPRS_MIKTARHESAPLAMAKULLAN],[M_SIRS_FIYATSIZFISKAYDEDEBILME],[M_SIRS_CIKTIDASECMELITASARIMKULLAN],[M_SIRS_CARISONBAKIYEGORUNSUN],[M_SIRS_KAYITIPTALETMECIKARMA],[M_SIRS_MIKTARHESAPLAMAKULLAN],[M_SF_FIYATSIZFISKAYDEDEBILME],[M_SF_CIKTIDASECMELITASARIMKULLAN]
,[M_SF_CARISONBAKIYEGORUNSUN],[M_SF_KAYITIPTALETMECIKARMA],[M_SF_KAGITFATURAKESIMI],[M_SF_NUMARATORDEISYERINEBAKILSIN],[M_SF_NUMARATORDEAMBARABAKILSIN],[M_SF_EFATURAKONTROLUYAPILSIN],[M_SF_MIKTARHESAPLAMAKULLAN]
,[M_ATKLF_FIYATSIZFISKAYDEDEBILME],[M_ATKLF_CIKTIDASECMELITASARIMKULLAN],[M_ATKLF_CARISONBAKIYEGORUNSUN],[M_ATKLF_COKLUSIPARISOLUSTURMA],[M_ATKLF_MIKTARHESAPLAMAKULLAN]
,[M_ASPRS_FIYATSIZFISKAYDEDEBILME],[M_ASPRS_CIKTIDASECMELITASARIMKULLAN],[M_ASPRS_CARISONBAKIYEGORUNSUN],[M_ASPRS_KAYITIPTALETMECIKARMA],[M_ASPRS_MIKTARHESAPLAMAKULLAN]
,[M_AIRS_FIYATSIZFISKAYDEDEBILME],[M_AIRS_CIKTIDASECMELITASARIMKULLAN]
,[M_AIRS_CARISONBAKIYEGORUNSUN],[M_AIRS_KAYITIPTALETMECIKARMA],[M_AIRS_MIKTARHESAPLAMAKULLAN],[M_AF_FIYATSIZFISKAYDEDEBILME],[M_AF_CIKTIDASECMELITASARIMKULLAN],[M_AF_CARISONBAKIYEGORUNSUN],[M_AF_KAYITIPTALETMECIKARMA],[M_AF_KAGITFATURAKESIMI],[M_AF_NUMARATORDEISYERINEBAKILSIN]
,[M_AF_NUMARATORDEAMBARABAKILSIN],[M_AF_EFATURAKONTROLUYAPILSIN],[M_AF_MIKTARHESAPLAMAKULLAN],[M_MF_AMBARFISINDEONDEGERKAGITGELSIN],[M_MF_CIKTIDASECMELITASARIMKULLAN],[M_MF_MIKTARHESAPLAMAKULLAN]
,[M_GNL_BARKODOKUTMAMIKTARBIRLESIMI],[M_GNL_KAYITLARDANSONRASAYFAKAPAT],[M_GNL_KAYITLARDANSONRASAYFAYENILE],[M_GNL_ALTERNATIFURUNONERISIAKTIF]
,[M_GNL_KULLANICIKASABAGLANTISI],[M_GNL_ALISFIYATININALTINDA_YAPILACAKISLEM],[M_GNL_ALISFIYATUSTUNEKARORANI],[M_GNL_LISTELERIN_GUNFARKI],[FYTPRMT_OZELFIYATSECENEGI]
,[FYTPRMT_PERAKENDEFIYATGRUBU],[FYTPRMT_FIYATGRUBU],[FYTPRMT_ETICARETFIYATGRUBU],[MIKTARH_1ALANKULLAN],[MIKTARH_2ALANKULLAN],[MIKTARH_3ALANKULLAN],[MIKTARH_4ALANKULLAN],[MIKTARH_5ALANKULLAN],[MIKTARH_1ALANADI] ,[MIKTARH_2ALANADI],[MIKTARH_3ALANADI],[MIKTARH_4ALANADI],[MIKTARH_5ALANADI],[MIKTARH_1ALANVARSDEGER],[MIKTARH_2ALANVARSDEGER],[MIKTARH_3ALANVARSDEGER],[MIKTARH_4ALANVARSDEGER],[MIKTARH_5ALANVARSDEGER],[MIKTARH_FORMUL],[OZELFIYATKARTSUTUNAD])
     VALUES  ('{Convert.ToInt32(LK_sirket.EditValue).ToString("000")}','{Convert.ToInt32(Lk_donem.EditValue).ToString("00")}','{txt_ArasKargoEntegrasyonKullaniciAdi.Text}','{txt_ArasKargoEntegrasyonKargoSifre.Text}','{txt_ArasKargoEntegrasyonKargoGonderiTipi.Text}','{txt_Banka1Adı.Text}','{txt_Banka1Iban.Text}','{txt_Banka1SubeAdi.Text}','{txt_Banka1HesapNo.Text}','{txt_Banka2Adı.Text}','{txt_Banka2Iban.Text}','{txt_Banka2SubeAdi.Text}','{txt_Banka2HesapNo.Text}','{txt_Banka3Adı.Text}','{txt_Banka3Iban.Text}','{txt_Banka3SubeAdi.Text}','{txt_Banka3HesapNo.Text}','{txt_Banka4Adı.Text}','{txt_Banka4Iban.Text}','{txt_Banka4SubeAdi.Text}','{txt_Banka4HesapNo.Text}','{txt_Banka5Adı.Text}','{txt_Banka5Iban.Text}','{txt_Banka5SubeAdi.Text}','{txt_Banka5HesapNo.Text}',{Convert.ToInt32(ck_smsGonder.Checked)},'{txt_smsKullaniciAdi.Text}','{txt_SmsSifre.Text}','{txt_SmsBaslik.Text}',
'{txt_ProgramKatalogDosyaYolu.Text}','{txt_SozlesmeliCariDosyaYolu.Text}',{Convert.ToInt32(rd_OtomatikDovizTuru.EditValue)},{Convert.ToInt32(rd_StandartKullanilacakParaBirimi.EditValue)},'{txt_GibMaliMusavirTokenBilgisi.Text}',{Convert.ToInt32(ck_GibSorgulamaYapabilsin.Checked)},'{txt_ElogoKullaniciAdi.Text}','{txt_ElogoKullaniciSifre.Text}','{txt_FaturaAltNotu.Text}','{txt_TeklifAltNotu.Text}','{txt_mailServer.Text}','{txt_mailPort.Text}'
,{Convert.ToInt32(ck_mailSSlGerekli.Checked)},{Convert.ToInt32(rd_LogoBaglantiSecimi.EditValue)},{Convert.ToInt32(rd_LogoPaketSecimi.EditValue)},'{txt_ObjeServisUrl.Text}','{txt_ObjeKullaniciAdi.Text}','{txt_ObjeKullaniciSifre.Text}','{txt_RestServisUrl.Text}','{txt_RestServisLogoKullanici.Text}'
,'{txt_RestServisLogoKullaniciSifre.Text}',{Convert.ToInt32(ck_zorunluCariKartOzelkod1.Checked)},{Convert.ToInt32(ck_zorunluCariKartOzelkod2.Checked)},{Convert.ToInt32(ck_zorunluCariKartOzelkod3.Checked)},{Convert.ToInt32(ck_zorunluCariKartOzelkod4.Checked)},{Convert.ToInt32(ck_zorunluCariKartOzelkod5.Checked)},{Convert.ToInt32(ck_zorunluCariKartOdemePlani.Checked)},{Convert.ToInt32(ck_zorunluCariKartEposta.Checked)}
,{Convert.ToInt32(ck_zorunluCariKartEposta2.Checked)},{Convert.ToInt32(ck_zorunluCariKartEposta3.Checked)},{Convert.ToInt32(ck_zorunluCariKartTicariIslemGurubu.Checked)},{Convert.ToInt32(ck_zorunluCariKartMuhasebeKodu.Checked)},'{ck_zorunluCariKart_SatisElemaniKodunaBagliAlan.SelectedValue.ToString()}','{ck_zorunluCariKart_PazarlayanKodunaBagliAlan.SelectedValue.ToString()}'
,'{ck_zorunluCariKart_HazirlayanKodunaBagliAlan.SelectedValue.ToString()}',{Convert.ToInt32(ck_zorunluStokKartOzelkod1.Checked)},{Convert.ToInt32(ck_zorunluStokKartOzelkod2.Checked)},{Convert.ToInt32(ck_zorunluStokKartOzelkod3.Checked)},{Convert.ToInt32(ck_zorunluStokKartOzelkod4.Checked)},{Convert.ToInt32(ck_zorunluStokKartOzelkod5.Checked)}
,{Convert.ToInt32(ck_zorunluStokKartMarka.Checked)},{Convert.ToInt32(ck_zorunluStokKartGrupKodu.Checked)},{Convert.ToInt32(ck_zorunluStokKartFiyat.Checked)},{Convert.ToInt32(ck_zorunluSatisTeklifHazirlayanPersonel.Checked)},{Convert.ToInt32(ck_zorunluSatisTeklifSatisElemani.Checked)}
,{Convert.ToInt32(ck_zorunluSatisTeklifOzelkod.Checked)},{Convert.ToInt32(ck_zorunluSatisTeklifYetkikod.Checked)},{Convert.ToInt32(ck_zorunluSatisTeklifProjekod.Checked)},{Convert.ToInt32(ck_zorunluSatisTeklifTicariIslemGrupkod.Checked)},{Convert.ToInt32(ck_zorunluSatisTeklifOdemeTipi.Checked)},{Convert.ToInt32(ck_zorunluSatisTeklifVade.Checked)},{Convert.ToInt32(ck_zorunluSatisTeklifTasiyiciKodu.Checked)},
{Convert.ToInt32(ck_zorunluSatisSiparisHazirlayanPersonel.Checked)},{Convert.ToInt32(ck_zorunluSatisSiparisSatisElemani.Checked)}
,{Convert.ToInt32(ck_zorunluSatisSiparisOzelkod.Checked)},{Convert.ToInt32(ck_zorunluSatisSiparisYetkikod.Checked)},{Convert.ToInt32(ck_zorunluSatisSiparisProjekod.Checked)},{Convert.ToInt32(ck_zorunluSatisSiparisTicariIslemGrupkod.Checked)},{Convert.ToInt32(ck_zorunluSatisSiparisOdemeTipi.Checked)},{Convert.ToInt32(ck_zorunluSatisSiparisVade.Checked)},{Convert.ToInt32(ck_zorunluSatisSiparisTasiyiciKodu.Checked)},
{Convert.ToInt32(ck_zorunluSatisIrsaliyeHazirlayanPersonel.Checked)},{Convert.ToInt32(ck_zorunluSatisIrsaliyeSatisElemani.Checked)}
,{Convert.ToInt32(ck_zorunluSatisIrsaliyeOzelkod.Checked)},{Convert.ToInt32(ck_zorunluSatisIrsaliyeYetkikod.Checked)},{Convert.ToInt32(ck_zorunluSatisIrsaliyeProjekod.Checked)},{Convert.ToInt32(ck_zorunluSatisIrsaliyeTicariIslemGrupkod.Checked)},{Convert.ToInt32(ck_zorunluSatisIrsaliyeOdemeTipi.Checked)},{Convert.ToInt32(ck_zorunluSatisIrsaliyeVade.Checked)},{Convert.ToInt32(ck_zorunluSatisIrsaliyeTasiyiciKodu.Checked)},
{Convert.ToInt32(ck_zorunluSatisFaturaHazirlayanPersonel.Checked)},{Convert.ToInt32(ck_zorunluSatisFaturaSatisElemani.Checked)}
,{Convert.ToInt32(ck_zorunluSatisFaturaOzelkod.Checked)},{Convert.ToInt32(ck_zorunluSatisFaturaYetkikod.Checked)},{Convert.ToInt32(ck_zorunluSatisFaturaProjekod.Checked)},{Convert.ToInt32(ck_zorunluSatisFaturaTicariIslemGrupkod.Checked)},{Convert.ToInt32(ck_zorunluSatisFaturaOdemeTipi.Checked)},{Convert.ToInt32(ck_zorunluSatisFaturaVade.Checked)},{Convert.ToInt32(ck_zorunluSatisFaturaTasiyiciKodu.Checked)},
{Convert.ToInt32(ck_zorunluSatinalmaTeklifHazirlayanPersonel.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaTeklifSatisElemani.Checked)}
,{Convert.ToInt32(ck_zorunluSatinalmaTeklifOzelkod.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaTeklifYetkikod.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaTeklifProjekod.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaTeklifTicariIslemGrupkod.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaTeklifOdemeTipi.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaTeklifVade.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaTeklifTasiyiciKodu.Checked)},
{Convert.ToInt32(ck_zorunluSatinalmaSiparisHazirlayanPersonel.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaSiparisSatisElemani.Checked)}
,{Convert.ToInt32(ck_zorunluSatinalmaSiparisOzelkod.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaSiparisYetkikod.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaSiparisProjekod.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaSiparisTicariIslemGrupkod.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaSiparisOdemeTipi.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaSiparisVade.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaSiparisTasiyiciKodu.Checked)},
{Convert.ToInt32(ck_zorunluSatinalmaIrsaliyeHazirlayanPersonel.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaIrsaliyeSatisElemani.Checked)}
,{Convert.ToInt32(ck_zorunluSatinalmaIrsaliyeOzelkod.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaIrsaliyeYetkikod.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaIrsaliyeProjekod.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaIrsaliyeTicariIslemGrupkod.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaIrsaliyeOdemeTipi.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaIrsaliyeVade.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaIrsaliyeTasiyiciKodu.Checked)},
{Convert.ToInt32(ck_zorunluSatinalmaFaturaHazirlayanPersonel.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaFaturaSatisElemani.Checked)}
,{Convert.ToInt32(ck_zorunluSatinalmaFaturaOzelkod.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaFaturaYetkikod.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaFaturaProjekod.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaFaturaTicariIslemGrupkod.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaFaturaOdemeTipi.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaFaturaVade.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaFaturaTasiyiciKodu.Checked)},
{Convert.ToInt32(ck_zorunluMalzemeFisiOzelKod.Checked)}
,{Convert.ToInt32(ck_zorunluMalzemeFisiYetkiKodu.Checked)},{Convert.ToInt32(ck_ModulCariKartAcilisindaMuhasebeHesabiOlustur.Checked)},{Convert.ToInt32(ck_ModulCariKartAcilisindaAmbarParametresineGoreOtomatikKodVer.Checked)},{Convert.ToInt32(txt_otomatikbarkodlog.Text)},{Convert.ToInt32(ck_ModulSatisTeklifFiyatsizFisKaydedebilme.Checked)},{Convert.ToInt32(ck_ModulSatisTeklifCiktidaSecmeliTasarimKullan.Checked)},{Convert.ToInt32(ck_ModulSatisTeklifCariSonBakiyeGorunsun.Checked)},{Convert.ToInt32(ck_ModulSatisTeklifCokluSiparisOlusturma.Checked)},{Convert.ToInt32(ck_ModulSatisTeklifMiktarHesaplamaKullan.Checked)}, {Convert.ToInt32(ck_ModulSatisSiparisFiyatsizFisKaydedebilme.Checked)},{Convert.ToInt32(ck_ModulSatisSiparisCiktidaSecmeliTasarimKullan.Checked)},{Convert.ToInt32(ck_ModulSatisSiparisCariSonBakiyeGorunsun.Checked)},{Convert.ToInt32(ck_ModulSatisSiparisKayitIptalEtmeCikma.Checked)},{Convert.ToInt32(ck_ModulSatisSiparisMiktarHesaplamaKullan.Checked)},
{Convert.ToInt32(ck_ModulSatisIrsaliyeFiyatsizFisKaydedebilme.Checked)},{Convert.ToInt32(ck_ModulSatisIrsaliyeCiktidaSecmeliTasarimKullan.Checked)},{Convert.ToInt32(ck_ModulSatisIrsaliyeCariSonBakiyeGorunsun.Checked)},{Convert.ToInt32(ck_ModulSatisIrsaliyeKayitIptalEtmeCikma.Checked)},{Convert.ToInt32(ck_ModulSatisIrsaliyeMiktarHesaplamaKullan.Checked)},{Convert.ToInt32(ck_ModulSatisFaturaFiyatsizFisKaydedebilme.Checked)},{Convert.ToInt32(ck_ModulSatisFaturaCiktidaSecmeliTasarimKullan.Checked)},{Convert.ToInt32(ck_ModulSatisFaturaCariSonBakiyeGorunsun.Checked)},{Convert.ToInt32(ck_ModulSatisFaturaKayitIptalEtmeCikma.Checked)},{Convert.ToInt32(ck_ModulSatisFaturaKagitFaturaKesimi.Checked)},{Convert.ToInt32(ck_ModulSatisFaturaFaturaNumaratorundeIsyerineBakilsin.Checked)},{Convert.ToInt32(ck_ModulSatisFaturaFaturaNumaratorundeAmbaraBakilsin.Checked)},{Convert.ToInt32(ck_ModulSatisFaturaKayitEsnasindaEfaturaKontroluYapilsin.Checked)},{Convert.ToInt32(ck_ModulSatisFaturaMiktarHesaplamaKullan.Checked)},{Convert.ToInt32(ck_ModulSatinalmaTeklifFiyatsizFisKaydedebilme.Checked)},{Convert.ToInt32(ck_ModulSatinalmaTeklifCiktidaSecmeliTasarimKullan.Checked)},{Convert.ToInt32(ck_ModulSatinalmaTeklifCariSonBakiyeGorunsun.Checked)}
,{Convert.ToInt32(ck_ModulSatinalmaTeklifCokluSiparisOlusturma.Checked)},{Convert.ToInt32(ck_ModulSatinalmaTeklifMiktarHesaplamaKullan.Checked)},{Convert.ToInt32(ck_ModulSatinalmaSiparisFiyatsizFisKaydedebilme.Checked)},{Convert.ToInt32(ck_ModulSatinalmaSiparisCiktidaSecmeliTasarimKullan.Checked)},{Convert.ToInt32(ck_ModulSatinalmaSiparisCariSonBakiyeGorunsun.Checked)}
,{Convert.ToInt32(ck_ModulSatinalmaSiparisKayitIptalEtmeCikma.Checked)},{Convert.ToInt32(ck_ModulSatinalmaSiparisMiktarHesaplamaKullan.Checked)},{Convert.ToInt32(ck_ModulSatinalmaIrsaliyeFiyatsizFisKaydedebilme.Checked)},{Convert.ToInt32(ck_ModulSatinalmaIrsaliyeCiktidaSecmeliTasarimKullan.Checked)},{Convert.ToInt32(ck_ModulSatinalmaIrsaliyeCariSonBakiyeGorunsun.Checked)},
{Convert.ToInt32(ck_ModulSatinalmaIrsaliyeKayitIptalEtmeCikma.Checked)},{Convert.ToInt32(ck_ModulSatinalmaIrsaliyeMiktarHesaplamaKullan.Checked)},{Convert.ToInt32(ck_ModulSatinalmaFaturaFiyatsizFisKaydedebilme.Checked)},{Convert.ToInt32(ck_ModulSatinalmaFaturaCiktidaSecmeliTasarimKullan.Checked)},{Convert.ToInt32(ck_ModulSatinalmaFaturaCariSonBakiyeGorunsun.Checked)}
,{Convert.ToInt32(ck_ModulSatinalmaFaturaKayitIptalEtmeCikma.Checked)},{Convert.ToInt32(ck_ModulSatinalmaFaturaKagitFaturaKesimi.Checked)},{Convert.ToInt32(ck_ModulSatinalmaFaturaFaturaNumaratorundeIsyerineBakilsin.Checked)},{Convert.ToInt32(ck_ModulSatinalmaFaturaFaturaNumaratorundeAmbaraBakilsin.Checked)},{Convert.ToInt32(ck_ModulSatinalmaFaturaKayitEsnasindaEfaturaKontroluYapilsin.Checked)},{Convert.ToInt32(ck_ModulSatinalmaFaturaMiktarHesaplamaKullan.Checked)}
,{Convert.ToInt32(ck_ModulMalzemeFisleriAmbarFisindeOnDegerKagitGelsin.Checked)},{Convert.ToInt32(ck_ModulMalzemeFisleriCiktidaSecmeliTasarimKullan.Checked)},{Convert.ToInt32(ck_ModulMalzemeFisleriMiktarHesaplamaKullan.Checked)},{Convert.ToInt32(ck_ModulGenelModullerdeBarkodOkutmaMiktarBirlesimi.Checked)},{Convert.ToInt32(ck_ModulGenelKayitlardanSonraSayfaKapatma.Checked)},{Convert.ToInt32(ck_ModulGenelKayitlardanSonraSayfaYenileme.Checked)},{Convert.ToInt32(ck_ModulGenelAlternatifUrunOnerisiAktif.Checked)},{Convert.ToInt32(ck_ModulGenelKullaniciKasaBaglantisiKullan.Checked)},{Convert.ToInt32(cm_ModulGenelAlisfiyatininaltindaYapilacakIslem.SelectedIndex)},{alisfiyatustuneKarOrani},{Convert.ToInt32(txt_ModulGenelListelerinStandartGunFarki.Text)},{Convert.ToInt32(rd_FiyatParametreleriOzelFiyatSecenegi.EditValue)},'{txt_FiyatParametreleriStandartPerakendeFiyatKodu.Text}','{txt_FiyatParametreleriStandartFiyatKodu.Text}','{txt_FiyatParametreleriStandartEticaretFiyatKodu.Text}' ,{Convert.ToInt32(ck_IlkHesaplamaAlaniniKullan.Checked)},{Convert.ToInt32(ck_IkinciHesaplamaAlaniniKullan.Checked)}, {Convert.ToInt32(ck_UcüncüHesaplamaAlaniniKullan.Checked)},{Convert.ToInt32(ck_DorduncuHesaplamaAlaniniKullan.Checked)},{Convert.ToInt32(ck_BesinciHesaplamaAlaniniKullan.Checked)}, '{txt_1AlanAdi.Text}','{txt_2AlanAdi.Text}','{txt_3AlanAdi.Text}','{txt_4AlanAdi.Text}','{txt_5AlanAdi.Text}',{MiktarHesaplamavarsayilanDeger1},{MiktarHesaplamavarsayilanDeger2},{MiktarHesaplamavarsayilanDeger3},{MiktarHesaplamavarsayilanDeger4},{MiktarHesaplamavarsayilanDeger5},'{txt_MiktarHesaplamaFormulu.Text}','{editvaluesorgu}') ;

INSERT INTO [dbo].[LOGO_XERO_BELGENUMARASI_NUMARATOR]([FIRMANO],[DONEMNO],[SSPRS_SERI],[SSPRS_SERINO],[ASPRS_SERI],[ASPRS_SERINO],[SIRS_SERI],[SIRS_SERINO]
,[AIRS_SERI],[AIRS_SERINO],[SFATURA_EARSIV_SERI],[SFATURA_EARSIV_SERINO],[SFATURA_EFATURA_SERI],[SFATURA_EFATURA_SERINO]
,[SFATURA_KAGIT_SERI],[SFATURA_KAGIT_SERINO],[AFATURA_SERI],[AFATURA_SERINO],[ATEKLIF_SERI],[ATEKLIF_SERINO],[STEKLIF_SERI],[STEKLIF_SERINO])
     VALUES  ('{Convert.ToInt32(LK_sirket.EditValue).ToString("000")}','{Convert.ToInt32(Lk_donem.EditValue).ToString("00")}','{txt_BelgeNoNumaratorSSiparis_Seri.Text}','{txt_BelgeNoNumaratorSSiparis_SeriNo.Text}','{txt_BelgeNoNumaratorASiparis_Seri.Text}','{txt_BelgeNoNumaratorASiparis_SeriNo.Text}','{txt_BelgeNoNumaratorSIrsaliye_Seri.Text}','{txt_BelgeNoNumaratorSIrsaliye_SeriNo.Text}','{txt_BelgeNoNumaratorAIrsaliye_Seri.Text}','{txt_BelgeNoNumaratorAIrsaliye_SeriNo.Text}','{txt_BelgeNoNumaratorSEArsiv_Seri.Text}','{txt_BelgeNoNumaratorSEArsiv_SeriNo.Text}','{txt_BelgeNoNumaratorSEFatura_Seri.Text}','{txt_BelgeNoNumaratorSEFatura_SeriNo.Text}','{txt_BelgeNoNumaratorSKagit_Seri.Text}','{txt_BelgeNoNumaratorSKagit_SeriNo.Text}','{txt_BelgeNoNumaratorSatinalmaFatura_Seri.Text}','{txt_BelgeNoNumaratorSatinalmaFatura_SeriNo.Text}','{txt_BelgeNoNumaratorATeklif_Seri.Text}','{txt_BelgeNoNumaratorATeklif_SeriNo.Text}','{txt_BelgeNoNumaratorSTeklif_Seri.Text}','{txt_BelgeNoNumaratorSTeklif_SeriNo.Text}');


";
                        SqlCommand cmdEkle = new SqlCommand(sqlEkleme, clas.Conn);
                        try
                        {
                            clas.Conn.Open();
                            cmdEkle.ExecuteNonQuery();
                            clas.Conn.Close();
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("KAYIT SIRASINDA HATA OLUŞTU ! HATA = " + ex.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                else
                {
                    try
                    {
                        foreach (var item in firmaListesi)
                        {
                            donemListesi = islem.DataSetlidonemlistesi(Convert.ToInt32(item.NR).ToString("000"));
                            foreach (var donem in donemListesi)
                            {
                                string sqlEkleme = $@"INSERT INTO [dbo].[LOGO_XERO_PARAMETRELER]([FIRMANO],[DONEMNO],[ARASKARGOUSERNAME],[ARASKARGOPASSWORD],[ARASKARGOGONDERITIPI],[BANKA1],[IBAN1],[BANKASUBE1]
,[BANKAHESAPNO1],[BANKA2],[IBAN2],[BANKASUBE2],[BANKAHESAPNO2],[BANKA3],[IBAN3],[BANKASUBE3],[BANKAHESAPNO3],[BANKA4],[IBAN4]
,[BANKASUBE4],[BANKAHESAPNO4],[BANKA5],[IBAN5],[BANKASUBE5],[BANKAHESAPNO5],[SMSID],[SMSUSER],[SMSPASSWORD],[SMSHEADER],[PROGRAMKATALOGDOSYAYOLU]
,[SOZLESMELICARIDOSYAYOLU],[KULLANILACAKDOVIZTURU],[STANDARTPARABIRIMI],[MALIMUSAVIR_TOKEN],[GIBSORGULAMAYAPABILSIN],[GIBUSERNAME],[GIBPASSWORD],[FATURAALTNOT]
,[TEKLIFALTNOT],[MAILSERVER],[MAILPORT],[SSLGEREKLIMI],[LOGOBAGLANTISECIMI],[LOGOPAKETSECIMI],[OBJESERVISURL],[OBJEKULLANICIADI],[OBJEKULLANICISIFRE],[RESTSERVISURL],[RESTSERVISKULLANICIADI]
,[RESTSERVISSIFRE],[ZC_OZELKOD1],[ZC_OZELKOD2],[ZC_OZELKOD3],[ZC_OZELKOD4],[ZC_OZELKOD5],[ZC_ODEMEPLANI_VADE],[ZC_EPOSTA1],[ZC_EPOSTA2],[ZC_EPOSTA3]
,[ZC_TICARIISLEMGRUBU],[ZC_MUHASEBEKODU],[ZC_BAGLISATISELEMANIALANI],[ZC_BAGLIHAZIRLAYANALANI],[ZC_BAGLIPAZARLAYANALANI],[ZSTK_OZELKOD1],[ZSTK_OZELKOD2]
,[ZSTK_OZELKOD3],[ZSTK_OZELKOD4],[ZSTK_OZELKOD5],[ZSTK_MARKA],[ZSTK_GRUPKODU],[ZSTK_FIYAT],[Z_STKLF_HAZIRLAYANPERSONEL],[Z_STKLF_SATISELEMANI]
,[Z_STKLF_OZELKOD],[Z_STKLF_YETKIKOD],[Z_STKLF_PROJEKOD],[Z_STKLF_TICISLGRUP],[Z_STKLF_ODEMETIP],[Z_STKLF_VADE],[Z_STKLF_TASIYICIKOD],[Z_SSPRS_HAZIRLAYANPERSONEL],[Z_SSPRS_SATISELEMANI]
,[Z_SSPRS_OZELKOD],[Z_SSPRS_YETKIKOD],[Z_SSPRS_PROJEKOD],[Z_SSPRS_TICISLGRUP],[Z_SSPRS_ODEMETIP],[Z_SSPRS_VADE],[Z_SSPRS_TASIYICIKOD],[Z_SIRS_HAZIRLAYANPERSONEL],[Z_SIRS_SATISELEMANI]
,[Z_SIRS_OZELKOD],[Z_SIRS_YETKIKOD],[Z_SIRS_PROJEKOD],[Z_SIRS_TICISLGRUP],[Z_SIRS_ODEMETIP],[Z_SIRS_VADE],[Z_SIRS_TASIYICIKOD],[Z_SF_HAZIRLAYANPERSONEL],[Z_SF_SATISELEMANI]
,[Z_SF_OZELKOD],[Z_SF_YETKIKOD],[Z_SF_PROJEKOD],[Z_SF_TICISLGRUP],[Z_SF_ODEMETIP],[Z_SF_VADE],[Z_SF_TASIYICIKOD],[Z_ATKLF_HAZIRLAYANPERSONEL],[Z_ATKLF_SATISELEMANI]
,[Z_ATKLF_OZELKOD],[Z_ATKLF_YETKIKOD],[Z_ATKLF_PROJEKOD],[Z_ATKLF_TICISLGRUP],[Z_ATKLF_ODEMETIP],[Z_ATKLF_VADE],[Z_ATKLF_TASIYICIKOD]
,[Z_ASPRS_HAZIRLAYANPERSONEL],[Z_ASPRS_SATISELEMANI],[Z_ASPRS_OZELKOD],[Z_ASPRS_YETKIKOD],[Z_ASPRS_PROJEKOD],[Z_ASPRS_TICISLGRUP],[Z_ASPRS_ODEMETIP],[Z_ASPRS_VADE],[Z_ASPRS_TASIYICIKOD]
,[Z_AIRS_HAZIRLAYANPERSONEL],[Z_AIRS_SATISELEMANI],[Z_AIRS_OZELKOD],[Z_AIRS_YETKIKOD],[Z_AIRS_PROJEKOD],[Z_AIRS_TICISLGRUP],[Z_AIRS_ODEMETIP],[Z_AIRS_VADE],[Z_AIRS_TASIYICIKOD]
,[Z_AF_HAZIRLAYANPERSONEL],[Z_AF_SATISELEMANI],[Z_AF_OZELKOD],[Z_AF_YETKIKOD],[Z_AF_PROJEKOD],[Z_AF_TICISLGRUP],[Z_AF_ODEMETIP],[Z_AF_VADE],[Z_AF_TASIYICIKOD]
,[Z_MF_OZELKOD],[Z_MF_YETKIKOD],[MC_OTOMATIKMUHASEBEOLUSTUR],[MC_AMBAR_OTOTMATIKKODVER],[MSTK_OTOBARKODLOGICALREF],[M_STKLF_FIYATSIZFISKAYDEDEBILMA],[M_STKLF_CIKTIDASECMELITASARIMKULLAN],[M_STKLF_CARISONBAKIYEGORUNSUN],[M_STKLF_COKLUSIPARISOLUSTURMA],[M_STKLF_MIKTARHESAPLAMAKULLAN],[M_SSPRS_FIYATSIZFISKAYDEDEBILME]
,[M_SSPRS_CIKTIDASECMELITASARIMKULLAN],[M_SSPRS_CARISONBAKIYEGORUNSUN],[M_SSPRS_KAYITIPTALETMECIKARMA],[M_SSPRS_MIKTARHESAPLAMAKULLAN],[M_SIRS_FIYATSIZFISKAYDEDEBILME],[M_SIRS_CIKTIDASECMELITASARIMKULLAN],[M_SIRS_CARISONBAKIYEGORUNSUN],[M_SIRS_KAYITIPTALETMECIKARMA],[M_SIRS_MIKTARHESAPLAMAKULLAN],[M_SF_FIYATSIZFISKAYDEDEBILME],[M_SF_CIKTIDASECMELITASARIMKULLAN]
,[M_SF_CARISONBAKIYEGORUNSUN],[M_SF_KAYITIPTALETMECIKARMA],[M_SF_KAGITFATURAKESIMI],[M_SF_NUMARATORDEISYERINEBAKILSIN],[M_SF_NUMARATORDEAMBARABAKILSIN],[M_SF_EFATURAKONTROLUYAPILSIN],[M_SF_MIKTARHESAPLAMAKULLAN]
,[M_ATKLF_FIYATSIZFISKAYDEDEBILME],[M_ATKLF_CIKTIDASECMELITASARIMKULLAN],[M_ATKLF_CARISONBAKIYEGORUNSUN],[M_ATKLF_COKLUSIPARISOLUSTURMA],[M_ATKLF_MIKTARHESAPLAMAKULLAN]
,[M_ASPRS_FIYATSIZFISKAYDEDEBILME],[M_ASPRS_CIKTIDASECMELITASARIMKULLAN],[M_ASPRS_CARISONBAKIYEGORUNSUN],[M_ASPRS_KAYITIPTALETMECIKARMA],[M_ASPRS_MIKTARHESAPLAMAKULLAN]
,[M_AIRS_FIYATSIZFISKAYDEDEBILME],[M_AIRS_CIKTIDASECMELITASARIMKULLAN]
,[M_AIRS_CARISONBAKIYEGORUNSUN],[M_AIRS_KAYITIPTALETMECIKARMA],[M_AIRS_MIKTARHESAPLAMAKULLAN],[M_AF_FIYATSIZFISKAYDEDEBILME],[M_AF_CIKTIDASECMELITASARIMKULLAN],[M_AF_CARISONBAKIYEGORUNSUN],[M_AF_KAYITIPTALETMECIKARMA],[M_AF_KAGITFATURAKESIMI],[M_AF_NUMARATORDEISYERINEBAKILSIN]
,[M_AF_NUMARATORDEAMBARABAKILSIN],[M_AF_EFATURAKONTROLUYAPILSIN],[M_AF_MIKTARHESAPLAMAKULLAN],[M_MF_AMBARFISINDEONDEGERKAGITGELSIN],[M_MF_CIKTIDASECMELITASARIMKULLAN],[M_MF_MIKTARHESAPLAMAKULLAN]
,[M_GNL_BARKODOKUTMAMIKTARBIRLESIMI],[M_GNL_KAYITLARDANSONRASAYFAKAPAT],[M_GNL_KAYITLARDANSONRASAYFAYENILE],[M_GNL_ALTERNATIFURUNONERISIAKTIF]
,[M_GNL_KULLANICIKASABAGLANTISI],[M_GNL_ALISFIYATININALTINDA_YAPILACAKISLEM],[M_GNL_ALISFIYATUSTUNEKARORANI],[M_GNL_LISTELERIN_GUNFARKI],[FYTPRMT_OZELFIYATSECENEGI]
,[FYTPRMT_PERAKENDEFIYATGRUBU],[FYTPRMT_FIYATGRUBU],[FYTPRMT_ETICARETFIYATGRUBU],[MIKTARH_1ALANKULLAN],[MIKTARH_2ALANKULLAN],[MIKTARH_3ALANKULLAN],[MIKTARH_4ALANKULLAN],[MIKTARH_5ALANKULLAN],[MIKTARH_1ALANADI] ,[MIKTARH_2ALANADI],[MIKTARH_3ALANADI],[MIKTARH_4ALANADI],[MIKTARH_5ALANADI],[MIKTARH_1ALANVARSDEGER],[MIKTARH_2ALANVARSDEGER],[MIKTARH_3ALANVARSDEGER],[MIKTARH_4ALANVARSDEGER],[MIKTARH_5ALANVARSDEGER],[MIKTARH_FORMUL],[OZELFIYATKARTSUTUNAD])
     VALUES  ('{Convert.ToInt32(item.NR).ToString("000")}','{Convert.ToInt32(donem.NR).ToString("00")}','{txt_ArasKargoEntegrasyonKullaniciAdi.Text}','{txt_ArasKargoEntegrasyonKargoSifre.Text}','{txt_ArasKargoEntegrasyonKargoGonderiTipi.Text}','{txt_Banka1Adı.Text}','{txt_Banka1Iban.Text}','{txt_Banka1SubeAdi.Text}','{txt_Banka1HesapNo.Text}','{txt_Banka2Adı.Text}','{txt_Banka2Iban.Text}','{txt_Banka2SubeAdi.Text}','{txt_Banka2HesapNo.Text}','{txt_Banka3Adı.Text}','{txt_Banka3Iban.Text}','{txt_Banka3SubeAdi.Text}','{txt_Banka3HesapNo.Text}','{txt_Banka4Adı.Text}','{txt_Banka4Iban.Text}','{txt_Banka4SubeAdi.Text}','{txt_Banka4HesapNo.Text}','{txt_Banka5Adı.Text}','{txt_Banka5Iban.Text}','{txt_Banka5SubeAdi.Text}','{txt_Banka5HesapNo.Text}',{Convert.ToInt32(ck_smsGonder.Checked)},'{txt_smsKullaniciAdi.Text}','{txt_SmsSifre.Text}','{txt_SmsBaslik.Text}',
'{txt_ProgramKatalogDosyaYolu.Text}','{txt_SozlesmeliCariDosyaYolu.Text}',{Convert.ToInt32(rd_OtomatikDovizTuru.EditValue)},{Convert.ToInt32(rd_StandartKullanilacakParaBirimi.EditValue)},'{txt_GibMaliMusavirTokenBilgisi.Text}',{Convert.ToInt32(ck_GibSorgulamaYapabilsin.Checked)},'{txt_ElogoKullaniciAdi.Text}','{txt_ElogoKullaniciSifre.Text}','{txt_FaturaAltNotu.Text}','{txt_TeklifAltNotu.Text}','{txt_mailServer.Text}','{txt_mailPort.Text}'
,{Convert.ToInt32(ck_mailSSlGerekli.Checked)},{Convert.ToInt32(rd_LogoBaglantiSecimi.EditValue)},{Convert.ToInt32(rd_LogoPaketSecimi.EditValue)},'{txt_ObjeServisUrl.Text}','{txt_ObjeKullaniciAdi.Text}','{txt_ObjeKullaniciSifre.Text}','{txt_RestServisUrl.Text}','{txt_RestServisLogoKullanici.Text}'
,'{txt_RestServisLogoKullaniciSifre.Text}',{Convert.ToInt32(ck_zorunluCariKartOzelkod1.Checked)},{Convert.ToInt32(ck_zorunluCariKartOzelkod2.Checked)},{Convert.ToInt32(ck_zorunluCariKartOzelkod3.Checked)},{Convert.ToInt32(ck_zorunluCariKartOzelkod4.Checked)},{Convert.ToInt32(ck_zorunluCariKartOzelkod5.Checked)},{Convert.ToInt32(ck_zorunluCariKartOdemePlani.Checked)},{Convert.ToInt32(ck_zorunluCariKartEposta.Checked)}
,{Convert.ToInt32(ck_zorunluCariKartEposta2.Checked)},{Convert.ToInt32(ck_zorunluCariKartEposta3.Checked)},{Convert.ToInt32(ck_zorunluCariKartTicariIslemGurubu.Checked)},{Convert.ToInt32(ck_zorunluCariKartMuhasebeKodu.Checked)},'{ck_zorunluCariKart_SatisElemaniKodunaBagliAlan.SelectedValue.ToString()}','{ck_zorunluCariKart_PazarlayanKodunaBagliAlan.SelectedValue.ToString()}'
,'{ck_zorunluCariKart_HazirlayanKodunaBagliAlan.SelectedValue.ToString()}',{Convert.ToInt32(ck_zorunluStokKartOzelkod1.Checked)},{Convert.ToInt32(ck_zorunluStokKartOzelkod2.Checked)},{Convert.ToInt32(ck_zorunluStokKartOzelkod3.Checked)},{Convert.ToInt32(ck_zorunluStokKartOzelkod4.Checked)},{Convert.ToInt32(ck_zorunluStokKartOzelkod5.Checked)}
,{Convert.ToInt32(ck_zorunluStokKartMarka.Checked)},{Convert.ToInt32(ck_zorunluStokKartGrupKodu.Checked)},{Convert.ToInt32(ck_zorunluStokKartFiyat.Checked)},{Convert.ToInt32(ck_zorunluSatisTeklifHazirlayanPersonel.Checked)},{Convert.ToInt32(ck_zorunluSatisTeklifSatisElemani.Checked)}
,{Convert.ToInt32(ck_zorunluSatisTeklifOzelkod.Checked)},{Convert.ToInt32(ck_zorunluSatisTeklifYetkikod.Checked)},{Convert.ToInt32(ck_zorunluSatisTeklifProjekod.Checked)},{Convert.ToInt32(ck_zorunluSatisTeklifTicariIslemGrupkod.Checked)},{Convert.ToInt32(ck_zorunluSatisTeklifOdemeTipi.Checked)},{Convert.ToInt32(ck_zorunluSatisTeklifVade.Checked)},{Convert.ToInt32(ck_zorunluSatisTeklifTasiyiciKodu.Checked)},
{Convert.ToInt32(ck_zorunluSatisSiparisHazirlayanPersonel.Checked)},{Convert.ToInt32(ck_zorunluSatisSiparisSatisElemani.Checked)}
,{Convert.ToInt32(ck_zorunluSatisSiparisOzelkod.Checked)},{Convert.ToInt32(ck_zorunluSatisSiparisYetkikod.Checked)},{Convert.ToInt32(ck_zorunluSatisSiparisProjekod.Checked)},{Convert.ToInt32(ck_zorunluSatisSiparisTicariIslemGrupkod.Checked)},{Convert.ToInt32(ck_zorunluSatisSiparisOdemeTipi.Checked)},{Convert.ToInt32(ck_zorunluSatisSiparisVade.Checked)},{Convert.ToInt32(ck_zorunluSatisSiparisTasiyiciKodu.Checked)},
{Convert.ToInt32(ck_zorunluSatisIrsaliyeHazirlayanPersonel.Checked)},{Convert.ToInt32(ck_zorunluSatisIrsaliyeSatisElemani.Checked)}
,{Convert.ToInt32(ck_zorunluSatisIrsaliyeOzelkod.Checked)},{Convert.ToInt32(ck_zorunluSatisIrsaliyeYetkikod.Checked)},{Convert.ToInt32(ck_zorunluSatisIrsaliyeProjekod.Checked)},{Convert.ToInt32(ck_zorunluSatisIrsaliyeTicariIslemGrupkod.Checked)},{Convert.ToInt32(ck_zorunluSatisIrsaliyeOdemeTipi.Checked)},{Convert.ToInt32(ck_zorunluSatisIrsaliyeVade.Checked)},{Convert.ToInt32(ck_zorunluSatisIrsaliyeTasiyiciKodu.Checked)},
{Convert.ToInt32(ck_zorunluSatisFaturaHazirlayanPersonel.Checked)},{Convert.ToInt32(ck_zorunluSatisFaturaSatisElemani.Checked)}
,{Convert.ToInt32(ck_zorunluSatisFaturaOzelkod.Checked)},{Convert.ToInt32(ck_zorunluSatisFaturaYetkikod.Checked)},{Convert.ToInt32(ck_zorunluSatisFaturaProjekod.Checked)},{Convert.ToInt32(ck_zorunluSatisFaturaTicariIslemGrupkod.Checked)},{Convert.ToInt32(ck_zorunluSatisFaturaOdemeTipi.Checked)},{Convert.ToInt32(ck_zorunluSatisFaturaVade.Checked)},{Convert.ToInt32(ck_zorunluSatisFaturaTasiyiciKodu.Checked)},
{Convert.ToInt32(ck_zorunluSatinalmaTeklifHazirlayanPersonel.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaTeklifSatisElemani.Checked)}
,{Convert.ToInt32(ck_zorunluSatinalmaTeklifOzelkod.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaTeklifYetkikod.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaTeklifProjekod.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaTeklifTicariIslemGrupkod.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaTeklifOdemeTipi.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaTeklifVade.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaTeklifTasiyiciKodu.Checked)},
{Convert.ToInt32(ck_zorunluSatinalmaSiparisHazirlayanPersonel.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaSiparisSatisElemani.Checked)}
,{Convert.ToInt32(ck_zorunluSatinalmaSiparisOzelkod.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaSiparisYetkikod.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaSiparisProjekod.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaSiparisTicariIslemGrupkod.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaSiparisOdemeTipi.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaSiparisVade.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaSiparisTasiyiciKodu.Checked)},
{Convert.ToInt32(ck_zorunluSatinalmaIrsaliyeHazirlayanPersonel.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaIrsaliyeSatisElemani.Checked)}
,{Convert.ToInt32(ck_zorunluSatinalmaIrsaliyeOzelkod.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaIrsaliyeYetkikod.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaIrsaliyeProjekod.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaIrsaliyeTicariIslemGrupkod.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaIrsaliyeOdemeTipi.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaIrsaliyeVade.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaIrsaliyeTasiyiciKodu.Checked)},
{Convert.ToInt32(ck_zorunluSatinalmaFaturaHazirlayanPersonel.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaFaturaSatisElemani.Checked)}
,{Convert.ToInt32(ck_zorunluSatinalmaFaturaOzelkod.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaFaturaYetkikod.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaFaturaProjekod.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaFaturaTicariIslemGrupkod.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaFaturaOdemeTipi.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaFaturaVade.Checked)},{Convert.ToInt32(ck_zorunluSatinalmaFaturaTasiyiciKodu.Checked)},
{Convert.ToInt32(ck_zorunluMalzemeFisiOzelKod.Checked)}
,{Convert.ToInt32(ck_zorunluMalzemeFisiYetkiKodu.Checked)},{Convert.ToInt32(ck_ModulCariKartAcilisindaMuhasebeHesabiOlustur.Checked)},{Convert.ToInt32(ck_ModulCariKartAcilisindaAmbarParametresineGoreOtomatikKodVer.Checked)},{Convert.ToInt32(txt_otomatikbarkodlog.Text)},{Convert.ToInt32(ck_ModulSatisTeklifFiyatsizFisKaydedebilme.Checked)},{Convert.ToInt32(ck_ModulSatisTeklifCiktidaSecmeliTasarimKullan.Checked)},{Convert.ToInt32(ck_ModulSatisTeklifCariSonBakiyeGorunsun.Checked)},{Convert.ToInt32(ck_ModulSatisTeklifCokluSiparisOlusturma.Checked)},{Convert.ToInt32(ck_ModulSatisTeklifMiktarHesaplamaKullan.Checked)}, {Convert.ToInt32(ck_ModulSatisSiparisFiyatsizFisKaydedebilme.Checked)},{Convert.ToInt32(ck_ModulSatisSiparisCiktidaSecmeliTasarimKullan.Checked)},{Convert.ToInt32(ck_ModulSatisSiparisCariSonBakiyeGorunsun.Checked)},{Convert.ToInt32(ck_ModulSatisSiparisKayitIptalEtmeCikma.Checked)},{Convert.ToInt32(ck_ModulSatisSiparisMiktarHesaplamaKullan.Checked)},
{Convert.ToInt32(ck_ModulSatisIrsaliyeFiyatsizFisKaydedebilme.Checked)},{Convert.ToInt32(ck_ModulSatisIrsaliyeCiktidaSecmeliTasarimKullan.Checked)},{Convert.ToInt32(ck_ModulSatisIrsaliyeCariSonBakiyeGorunsun.Checked)},{Convert.ToInt32(ck_ModulSatisIrsaliyeKayitIptalEtmeCikma.Checked)},{Convert.ToInt32(ck_ModulSatisIrsaliyeMiktarHesaplamaKullan.Checked)},{Convert.ToInt32(ck_ModulSatisFaturaFiyatsizFisKaydedebilme.Checked)},{Convert.ToInt32(ck_ModulSatisFaturaCiktidaSecmeliTasarimKullan.Checked)},{Convert.ToInt32(ck_ModulSatisFaturaCariSonBakiyeGorunsun.Checked)},{Convert.ToInt32(ck_ModulSatisFaturaKayitIptalEtmeCikma.Checked)},{Convert.ToInt32(ck_ModulSatisFaturaKagitFaturaKesimi.Checked)},{Convert.ToInt32(ck_ModulSatisFaturaFaturaNumaratorundeIsyerineBakilsin.Checked)},{Convert.ToInt32(ck_ModulSatisFaturaFaturaNumaratorundeAmbaraBakilsin.Checked)},{Convert.ToInt32(ck_ModulSatisFaturaKayitEsnasindaEfaturaKontroluYapilsin.Checked)},{Convert.ToInt32(ck_ModulSatisFaturaMiktarHesaplamaKullan.Checked)},{Convert.ToInt32(ck_ModulSatinalmaTeklifFiyatsizFisKaydedebilme.Checked)},{Convert.ToInt32(ck_ModulSatinalmaTeklifCiktidaSecmeliTasarimKullan.Checked)},{Convert.ToInt32(ck_ModulSatinalmaTeklifCariSonBakiyeGorunsun.Checked)}
,{Convert.ToInt32(ck_ModulSatinalmaTeklifCokluSiparisOlusturma.Checked)},{Convert.ToInt32(ck_ModulSatinalmaTeklifMiktarHesaplamaKullan.Checked)},{Convert.ToInt32(ck_ModulSatinalmaSiparisFiyatsizFisKaydedebilme.Checked)},{Convert.ToInt32(ck_ModulSatinalmaSiparisCiktidaSecmeliTasarimKullan.Checked)},{Convert.ToInt32(ck_ModulSatinalmaSiparisCariSonBakiyeGorunsun.Checked)}
,{Convert.ToInt32(ck_ModulSatinalmaSiparisKayitIptalEtmeCikma.Checked)},{Convert.ToInt32(ck_ModulSatinalmaSiparisMiktarHesaplamaKullan.Checked)},{Convert.ToInt32(ck_ModulSatinalmaIrsaliyeFiyatsizFisKaydedebilme.Checked)},{Convert.ToInt32(ck_ModulSatinalmaIrsaliyeCiktidaSecmeliTasarimKullan.Checked)},{Convert.ToInt32(ck_ModulSatinalmaIrsaliyeCariSonBakiyeGorunsun.Checked)},
{Convert.ToInt32(ck_ModulSatinalmaIrsaliyeKayitIptalEtmeCikma.Checked)},{Convert.ToInt32(ck_ModulSatinalmaIrsaliyeMiktarHesaplamaKullan.Checked)},{Convert.ToInt32(ck_ModulSatinalmaFaturaFiyatsizFisKaydedebilme.Checked)},{Convert.ToInt32(ck_ModulSatinalmaFaturaCiktidaSecmeliTasarimKullan.Checked)},{Convert.ToInt32(ck_ModulSatinalmaFaturaCariSonBakiyeGorunsun.Checked)}
,{Convert.ToInt32(ck_ModulSatinalmaFaturaKayitIptalEtmeCikma.Checked)},{Convert.ToInt32(ck_ModulSatinalmaFaturaKagitFaturaKesimi.Checked)},{Convert.ToInt32(ck_ModulSatinalmaFaturaFaturaNumaratorundeIsyerineBakilsin.Checked)},{Convert.ToInt32(ck_ModulSatinalmaFaturaFaturaNumaratorundeAmbaraBakilsin.Checked)},{Convert.ToInt32(ck_ModulSatinalmaFaturaKayitEsnasindaEfaturaKontroluYapilsin.Checked)},{Convert.ToInt32(ck_ModulSatinalmaFaturaMiktarHesaplamaKullan.Checked)}
,{Convert.ToInt32(ck_ModulMalzemeFisleriAmbarFisindeOnDegerKagitGelsin.Checked)},{Convert.ToInt32(ck_ModulMalzemeFisleriCiktidaSecmeliTasarimKullan.Checked)},{Convert.ToInt32(ck_ModulMalzemeFisleriMiktarHesaplamaKullan.Checked)},{Convert.ToInt32(ck_ModulGenelModullerdeBarkodOkutmaMiktarBirlesimi.Checked)},{Convert.ToInt32(ck_ModulGenelKayitlardanSonraSayfaKapatma.Checked)},{Convert.ToInt32(ck_ModulGenelKayitlardanSonraSayfaYenileme.Checked)},{Convert.ToInt32(ck_ModulGenelAlternatifUrunOnerisiAktif.Checked)},{Convert.ToInt32(ck_ModulGenelKullaniciKasaBaglantisiKullan.Checked)},{Convert.ToInt32(cm_ModulGenelAlisfiyatininaltindaYapilacakIslem.SelectedIndex)},{alisfiyatustuneKarOrani},{Convert.ToInt32(txt_ModulGenelListelerinStandartGunFarki.Text)},{Convert.ToInt32(rd_FiyatParametreleriOzelFiyatSecenegi.EditValue)},'{txt_FiyatParametreleriStandartPerakendeFiyatKodu.Text}','{txt_FiyatParametreleriStandartFiyatKodu.Text}','{txt_FiyatParametreleriStandartEticaretFiyatKodu.Text}' ,{Convert.ToInt32(ck_IlkHesaplamaAlaniniKullan.Checked)},{Convert.ToInt32(ck_IkinciHesaplamaAlaniniKullan.Checked)}, {Convert.ToInt32(ck_UcüncüHesaplamaAlaniniKullan.Checked)},{Convert.ToInt32(ck_DorduncuHesaplamaAlaniniKullan.Checked)},{Convert.ToInt32(ck_BesinciHesaplamaAlaniniKullan.Checked)}, '{txt_1AlanAdi.Text}','{txt_2AlanAdi.Text}','{txt_3AlanAdi.Text}','{txt_4AlanAdi.Text}','{txt_5AlanAdi.Text}',{MiktarHesaplamavarsayilanDeger1},{MiktarHesaplamavarsayilanDeger2},{MiktarHesaplamavarsayilanDeger3},{MiktarHesaplamavarsayilanDeger4},{MiktarHesaplamavarsayilanDeger5},'{txt_MiktarHesaplamaFormulu.Text}','{editvaluesorgu}');
 

INSERT INTO [dbo].[LOGO_XERO_BELGENUMARASI_NUMARATOR]([FIRMANO],[DONEMNO],[SSPRS_SERI],[SSPRS_SERINO],[ASPRS_SERI],[ASPRS_SERINO],[SIRS_SERI],[SIRS_SERINO]
,[AIRS_SERI],[AIRS_SERINO],[SFATURA_EARSIV_SERI],[SFATURA_EARSIV_SERINO],[SFATURA_EFATURA_SERI],[SFATURA_EFATURA_SERINO]
,[SFATURA_KAGIT_SERI],[SFATURA_KAGIT_SERINO],[AFATURA_SERI],[AFATURA_SERINO],[ATEKLIF_SERI],[ATEKLIF_SERINO],[STEKLIF_SERI],[STEKLIF_SERINO])
     VALUES  ('{Convert.ToInt32(item.NR).ToString("000")}','{Convert.ToInt32(donem.NR).ToString("00")}','{txt_BelgeNoNumaratorSSiparis_Seri.Text}','{txt_BelgeNoNumaratorSSiparis_SeriNo.Text}','{txt_BelgeNoNumaratorASiparis_Seri.Text}','{txt_BelgeNoNumaratorASiparis_SeriNo.Text}','{txt_BelgeNoNumaratorSIrsaliye_Seri.Text}','{txt_BelgeNoNumaratorSIrsaliye_SeriNo.Text}','{txt_BelgeNoNumaratorAIrsaliye_Seri.Text}','{txt_BelgeNoNumaratorAIrsaliye_SeriNo.Text}','{txt_BelgeNoNumaratorSEArsiv_Seri.Text}','{txt_BelgeNoNumaratorSEArsiv_SeriNo.Text}','{txt_BelgeNoNumaratorSEFatura_Seri.Text}','{txt_BelgeNoNumaratorSEFatura_SeriNo.Text}','{txt_BelgeNoNumaratorSKagit_Seri.Text}','{txt_BelgeNoNumaratorSKagit_SeriNo.Text}','{txt_BelgeNoNumaratorSatinalmaFatura_Seri.Text}','{txt_BelgeNoNumaratorSatinalmaFatura_SeriNo.Text}','{txt_BelgeNoNumaratorATeklif_Seri.Text}','{txt_BelgeNoNumaratorATeklif_SeriNo.Text}','{txt_BelgeNoNumaratorSTeklif_Seri.Text}','{txt_BelgeNoNumaratorSTeklif_SeriNo.Text}');
";
                                SqlCommand cmdEkle = new SqlCommand(sqlEkleme, clas.Conn);
                                try
                                {
                                    clas.Conn.Open();
                                    cmdEkle.ExecuteNonQuery();
                                    clas.Conn.Close();
                                }
                                catch (Exception ex)
                                {
                                    XtraMessageBox.Show("KAYIT SIRASINDA HATA OLUŞTU ! HATA = " + ex.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }

                        }


                        XtraMessageBox.Show("Sistem Parametreleri Kaydedildi ! Parametrelerin Geçerliliği İçin Programı Yeniden Başlatın !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        IlkKullaniciEkle();
                        frmKullaniciGiris frm = Application.OpenForms["frmKullaniciGiris"] as frmKullaniciGiris;
                        if (frm != null)
                        {
                            frm.ListeleriGetir();
                        }

                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("KAYIT SIRASINDA HATA OLUŞTU ! HATA = " + ex.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("KAYIT SIRASINDA HATA OLUŞTU ! HATA = " + ex.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        List<CARIOZELKODLAR_TURKCELER> satisElemaninaBagli = new List<CARIOZELKODLAR_TURKCELER>();
        List<CARIOZELKODLAR_TURKCELER> PazarlayanaBagli = new List<CARIOZELKODLAR_TURKCELER>();
        List<CARIOZELKODLAR_TURKCELER> HazirlayanaBagli = new List<CARIOZELKODLAR_TURKCELER>();
        List<L_CAPIFIRM> firm = new List<L_CAPIFIRM>();
        List<L_CAPIPERIOD> donem = new List<L_CAPIPERIOD>();

        public void IlkKullaniciEkle()
        {
            string sqlEkleme = $@"INSERT INTO [dbo].[LOGO_XERO_KULLANICILAR]
           ([KULLANICIADI],[LOGOSATISELEMANIID],[SIFRE],[TANIMLIFIRMA],[TANIMLIDONEM],[ISYERI],[BOLUM],[FABRIKA],[AMBAR],[TELEFON],[EPOSTA],[ILCE],[IL],[ADRES],[GOREV],[TEKLIFTUTARILIMIT],[KISITLIOZELKOD],[ISKONTOLIMIT],[GIRISAMBAR],[GIRISISYERI],[GIRISBOLUM],[YETKI])
           VALUES
           ('Admin',0,'12345','{LK_sirket.EditValue.ToString()}','{Lk_donem.EditValue.ToString()}',0,0,0,0,'','','','','',0,0,'',0,0,0,0,'')";
            SqlCommand cmdEkle = new SqlCommand(sqlEkleme, clas.Conn);
            try
            {
                clas.Conn.Open();
                cmdEkle.ExecuteNonQuery();
                clas.Conn.Close();
                XtraMessageBox.Show("İLK KULLANICINIZ EKLENDİ !" + Environment.NewLine + "KULLANICI ADI = 'Admin'" + Environment.NewLine + "ŞİFRE = 12345", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("KULLANICI EKLEME SIRASINDA HATA OLUŞTU ! HATA = " + ex.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        List<LOGO_XERO_LISANSLAR> LisansListesi;
        public int Demomu = 0;
        public void ListeleriGetir()
        {

            satisElemaninaBagli.Add(new CARIOZELKODLAR_TURKCELER { OZELKOD = "", SPECODE = "" });
            satisElemaninaBagli.Add(new CARIOZELKODLAR_TURKCELER { OZELKOD = "OZELKOD", SPECODE = "SPECODE" });
            satisElemaninaBagli.Add(new CARIOZELKODLAR_TURKCELER { OZELKOD = "OZELKOD2", SPECODE = "SPECODE2" });
            satisElemaninaBagli.Add(new CARIOZELKODLAR_TURKCELER { OZELKOD = "OZELKOD3", SPECODE = "SPECODE3" });
            satisElemaninaBagli.Add(new CARIOZELKODLAR_TURKCELER { OZELKOD = "OZELKOD4", SPECODE = "SPECODE4" });
            satisElemaninaBagli.Add(new CARIOZELKODLAR_TURKCELER { OZELKOD = "OZELKOD5", SPECODE = "SPECODE5" });
            satisElemaninaBagli.Add(new CARIOZELKODLAR_TURKCELER { OZELKOD = "YETKİ KODU", SPECODE = "CYPHCODE" });

            PazarlayanaBagli.Add(new CARIOZELKODLAR_TURKCELER { OZELKOD = "", SPECODE = "" });
            PazarlayanaBagli.Add(new CARIOZELKODLAR_TURKCELER { OZELKOD = "OZELKOD", SPECODE = "SPECODE" });
            PazarlayanaBagli.Add(new CARIOZELKODLAR_TURKCELER { OZELKOD = "OZELKOD2", SPECODE = "SPECODE2" });
            PazarlayanaBagli.Add(new CARIOZELKODLAR_TURKCELER { OZELKOD = "OZELKOD3", SPECODE = "SPECODE3" });
            PazarlayanaBagli.Add(new CARIOZELKODLAR_TURKCELER { OZELKOD = "OZELKOD4", SPECODE = "SPECODE4" });
            PazarlayanaBagli.Add(new CARIOZELKODLAR_TURKCELER { OZELKOD = "OZELKOD5", SPECODE = "SPECODE5" });
            PazarlayanaBagli.Add(new CARIOZELKODLAR_TURKCELER { OZELKOD = "YETKİ KODU", SPECODE = "CYPHCODE" });

            HazirlayanaBagli.Add(new CARIOZELKODLAR_TURKCELER { OZELKOD = "", SPECODE = "" });
            HazirlayanaBagli.Add(new CARIOZELKODLAR_TURKCELER { OZELKOD = "OZELKOD", SPECODE = "SPECODE" });
            HazirlayanaBagli.Add(new CARIOZELKODLAR_TURKCELER { OZELKOD = "OZELKOD2", SPECODE = "SPECODE2" });
            HazirlayanaBagli.Add(new CARIOZELKODLAR_TURKCELER { OZELKOD = "OZELKOD3", SPECODE = "SPECODE3" });
            HazirlayanaBagli.Add(new CARIOZELKODLAR_TURKCELER { OZELKOD = "OZELKOD4", SPECODE = "SPECODE4" });
            HazirlayanaBagli.Add(new CARIOZELKODLAR_TURKCELER { OZELKOD = "OZELKOD5", SPECODE = "SPECODE5" });
            HazirlayanaBagli.Add(new CARIOZELKODLAR_TURKCELER { OZELKOD = "YETKİ KODU", SPECODE = "CYPHCODE" });

            ck_zorunluCariKart_SatisElemaniKodunaBagliAlan.DataSource = satisElemaninaBagli;
            ck_zorunluCariKart_SatisElemaniKodunaBagliAlan.DisplayMember = "OZELKOD";
            ck_zorunluCariKart_SatisElemaniKodunaBagliAlan.ValueMember = "SPECODE";

            ck_zorunluCariKart_PazarlayanKodunaBagliAlan.DataSource = PazarlayanaBagli;
            ck_zorunluCariKart_PazarlayanKodunaBagliAlan.DisplayMember = "OZELKOD";
            ck_zorunluCariKart_PazarlayanKodunaBagliAlan.ValueMember = "SPECODE";

            ck_zorunluCariKart_HazirlayanKodunaBagliAlan.DataSource = HazirlayanaBagli;
            ck_zorunluCariKart_HazirlayanKodunaBagliAlan.DisplayMember = "OZELKOD";
            ck_zorunluCariKart_HazirlayanKodunaBagliAlan.ValueMember = "SPECODE";

            firm = islem.DataSetlifirmalistesi();
            LK_sirket.Properties.DisplayMember = "NUM";
            LK_sirket.Properties.ValueMember = "NUM2";
            LK_sirket.Properties.DataSource = firm;
        }

        private void frmSistemParametreleri_Load(object sender, EventArgs e)
        {
            firmaListesi = islem.DataSetlifirmalistesi();
            
            ListeleriGetir();
            Parametreler(0);
            LisansListesi = islem.DataSetliLisanslistesi();
            var varmiDemo = LisansListesi.Where(s => s.MODUL == 4).FirstOrDefault();
            if (varmiDemo != null)
            {
                if (!string.IsNullOrWhiteSpace(varmiDemo.LISANSNUMARASI))
                {
                    Demomu = 1;
                }
            }
            if (loginden == 1)
            {

            }
            else
            {
                LK_sirket.Enabled = false;
                Lk_donem.Enabled = false;
            }

            //if (Demomu == 1)
            //{
            //    //lbl_demoLisansUyarisi.Visible = true;
            //    rd_LogoBaglantiSecimi.EditValue = 0;
            //    rd_LogoBaglantiSecimi.Enabled = false;
            //    rd_LogoPaketSecimi.EditValue = 0;
            //    rd_LogoPaketSecimi.Enabled = false;
            //    grupObjeKullanimi.Visible = false;
            //    grupRestServisKullanimi.Visible = false;
            //}
            //else
            //{
            //    //lbl_demoLisansUyarisi.Visible = false;
            //}
            
        }
        byte[] photo_aray;
        void Parametreler(int tip)
        {
            string filtre = "";

            if (tip == 0)
            {
                if (!string.IsNullOrWhiteSpace(gelenfirma) && !string.IsNullOrWhiteSpace(gelendonem))
                {
                    filtre = $@" WHERE FIRMANO='{gelenfirma}' AND DONEMNO='{gelendonem}'";
                }
            }
            else
            {
                filtre = $@" WHERE FIRMANO='{LK_sirket.EditValue.ToString()}' AND DONEMNO='{Lk_donem.EditValue.ToString()}'";
            }


            clas.Connect();
            string sqlParametre = $@"SELECT TOP 1 * FROM LOGO_XERO_PARAMETRELER {filtre}  ;
            SELECT TOP 1 * FROM LOGO_XERO_BELGENUMARASI_NUMARATOR {filtre} ;
";
            SqlCommand cmd = new SqlCommand(sqlParametre, clas.Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                rd_FiyatParametreleriOzelFiyatSecenegi.EditValue = Convert.ToInt32(ds.Tables[0].Rows[0]["FYTPRMT_OZELFIYATSECENEGI"].ToString());  
               
                LK_sirket.EditValue = ds.Tables[0].Rows[0]["FIRMANO"].ToString();
                Lk_donem.EditValue = ds.Tables[0].Rows[0]["DONEMNO"].ToString();
                txt_ArasKargoEntegrasyonKullaniciAdi.Text = ds.Tables[0].Rows[0]["ARASKARGOUSERNAME"].ToString();
                txt_ArasKargoEntegrasyonKargoSifre.Text = ds.Tables[0].Rows[0]["ARASKARGOPASSWORD"].ToString();
                txt_ArasKargoEntegrasyonKargoGonderiTipi.Text = ds.Tables[0].Rows[0]["ARASKARGOGONDERITIPI"].ToString();
                txt_Banka1Adı.Text = ds.Tables[0].Rows[0]["BANKA1"].ToString();
                txt_Banka1Iban.Text = ds.Tables[0].Rows[0]["IBAN1"].ToString();
                txt_Banka1SubeAdi.Text = ds.Tables[0].Rows[0]["BANKASUBE1"].ToString();
                txt_Banka1HesapNo.Text = ds.Tables[0].Rows[0]["BANKAHESAPNO1"].ToString();
                txt_Banka2Adı.Text = ds.Tables[0].Rows[0]["BANKA2"].ToString();
                txt_Banka2Iban.Text = ds.Tables[0].Rows[0]["IBAN2"].ToString();
                txt_Banka2SubeAdi.Text = ds.Tables[0].Rows[0]["BANKASUBE2"].ToString();
                txt_Banka2HesapNo.Text = ds.Tables[0].Rows[0]["BANKAHESAPNO2"].ToString();
                txt_Banka3Adı.Text = ds.Tables[0].Rows[0]["BANKA3"].ToString();
                txt_Banka3Iban.Text = ds.Tables[0].Rows[0]["IBAN3"].ToString();
                txt_Banka3SubeAdi.Text = ds.Tables[0].Rows[0]["BANKASUBE3"].ToString();
                txt_Banka3HesapNo.Text = ds.Tables[0].Rows[0]["BANKAHESAPNO3"].ToString();
                txt_Banka4Adı.Text = ds.Tables[0].Rows[0]["BANKA4"].ToString();
                txt_Banka4Iban.Text = ds.Tables[0].Rows[0]["IBAN4"].ToString();
                txt_Banka4SubeAdi.Text = ds.Tables[0].Rows[0]["BANKASUBE4"].ToString();
                txt_Banka4HesapNo.Text = ds.Tables[0].Rows[0]["BANKAHESAPNO4"].ToString();
                txt_Banka5Adı.Text = ds.Tables[0].Rows[0]["BANKA5"].ToString();
                txt_Banka5Iban.Text = ds.Tables[0].Rows[0]["IBAN5"].ToString();
                txt_Banka5SubeAdi.Text = ds.Tables[0].Rows[0]["BANKASUBE5"].ToString();
                txt_Banka5HesapNo.Text = ds.Tables[0].Rows[0]["BANKAHESAPNO5"].ToString();
                ck_smsGonder.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["SMSID"].ToString());
                txt_smsKullaniciAdi.Text = ds.Tables[0].Rows[0]["SMSUSER"].ToString();
                txt_SmsSifre.Text = ds.Tables[0].Rows[0]["SMSPASSWORD"].ToString();
                txt_SmsBaslik.Text = ds.Tables[0].Rows[0]["SMSHEADER"].ToString();
                txt_ProgramKatalogDosyaYolu.Text = ds.Tables[0].Rows[0]["PROGRAMKATALOGDOSYAYOLU"].ToString();
                txt_SozlesmeliCariDosyaYolu.Text = ds.Tables[0].Rows[0]["SOZLESMELICARIDOSYAYOLU"].ToString();
                rd_OtomatikDovizTuru.EditValue = Convert.ToInt32(ds.Tables[0].Rows[0]["KULLANILACAKDOVIZTURU"].ToString());
                rd_StandartKullanilacakParaBirimi.EditValue = Convert.ToInt32(ds.Tables[0].Rows[0]["STANDARTPARABIRIMI"].ToString());
                txt_GibMaliMusavirTokenBilgisi.Text = ds.Tables[0].Rows[0]["MALIMUSAVIR_TOKEN"].ToString();
                ck_GibSorgulamaYapabilsin.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["GIBSORGULAMAYAPABILSIN"].ToString());
                txt_ElogoKullaniciAdi.Text = ds.Tables[0].Rows[0]["GIBUSERNAME"].ToString();
                txt_ElogoKullaniciSifre.Text = ds.Tables[0].Rows[0]["GIBPASSWORD"].ToString();
                txt_FaturaAltNotu.Text = ds.Tables[0].Rows[0]["FATURAALTNOT"].ToString();
                txt_TeklifAltNotu.Text = ds.Tables[0].Rows[0]["TEKLIFALTNOT"].ToString();
                txt_mailServer.Text = ds.Tables[0].Rows[0]["MAILSERVER"].ToString();
                txt_mailPort.Text = ds.Tables[0].Rows[0]["MAILPORT"].ToString();
                ck_mailSSlGerekli.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["SSLGEREKLIMI"].ToString());
                rd_LogoBaglantiSecimi.EditValue = Convert.ToInt32(ds.Tables[0].Rows[0]["LOGOBAGLANTISECIMI"].ToString());
                rd_LogoPaketSecimi.EditValue = Convert.ToInt32(ds.Tables[0].Rows[0]["LOGOPAKETSECIMI"].ToString());
                txt_ObjeServisUrl.Text = ds.Tables[0].Rows[0]["OBJESERVISURL"].ToString();

                txt_ObjeKullaniciAdi.Text = ds.Tables[0].Rows[0]["OBJEKULLANICIADI"].ToString();
                txt_ObjeKullaniciSifre.Text = ds.Tables[0].Rows[0]["OBJEKULLANICISIFRE"].ToString();

                txt_RestServisUrl.Text = ds.Tables[0].Rows[0]["RESTSERVISURL"].ToString();
                txt_RestServisLogoKullanici.Text = ds.Tables[0].Rows[0]["RESTSERVISKULLANICIADI"].ToString();
                txt_RestServisLogoKullaniciSifre.Text = ds.Tables[0].Rows[0]["RESTSERVISSIFRE"].ToString();
                ck_zorunluCariKartOzelkod1.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["ZC_OZELKOD1"].ToString());
                ck_zorunluCariKartOzelkod2.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["ZC_OZELKOD2"].ToString());
                ck_zorunluCariKartOzelkod3.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["ZC_OZELKOD3"].ToString());
                ck_zorunluCariKartOzelkod4.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["ZC_OZELKOD4"].ToString());
                ck_zorunluCariKartOzelkod5.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["ZC_OZELKOD5"].ToString());
                ck_zorunluCariKartOdemePlani.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["ZC_ODEMEPLANI_VADE"].ToString());
                ck_zorunluCariKartEposta.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["ZC_EPOSTA1"].ToString());
                ck_zorunluCariKartEposta2.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["ZC_EPOSTA2"].ToString());
                ck_zorunluCariKartEposta3.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["ZC_EPOSTA3"].ToString());
                ck_zorunluCariKartTicariIslemGurubu.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["ZC_TICARIISLEMGRUBU"].ToString());
                ck_zorunluCariKartMuhasebeKodu.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["ZC_MUHASEBEKODU"].ToString());
                ck_zorunluCariKart_SatisElemaniKodunaBagliAlan.Text = ds.Tables[0].Rows[0]["ZC_BAGLISATISELEMANIALANI"].ToString();
                ck_zorunluCariKart_PazarlayanKodunaBagliAlan.Text = ds.Tables[0].Rows[0]["ZC_BAGLIHAZIRLAYANALANI"].ToString();
                ck_zorunluCariKart_HazirlayanKodunaBagliAlan.Text = ds.Tables[0].Rows[0]["ZC_BAGLIPAZARLAYANALANI"].ToString();
                ck_zorunluStokKartOzelkod1.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["ZSTK_OZELKOD1"].ToString());
                ck_zorunluStokKartOzelkod2.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["ZSTK_OZELKOD2"].ToString());
                ck_zorunluStokKartOzelkod3.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["ZSTK_OZELKOD3"].ToString());
                ck_zorunluStokKartOzelkod4.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["ZSTK_OZELKOD4"].ToString());
                ck_zorunluStokKartOzelkod5.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["ZSTK_OZELKOD5"].ToString());
                ck_zorunluStokKartMarka.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["ZSTK_MARKA"].ToString());
                ck_zorunluStokKartGrupKodu.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["ZSTK_GRUPKODU"].ToString());
                ck_zorunluStokKartFiyat.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["ZSTK_FIYAT"].ToString());
                ck_zorunluSatisTeklifHazirlayanPersonel.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_STKLF_HAZIRLAYANPERSONEL"].ToString());
                ck_zorunluSatisTeklifSatisElemani.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_STKLF_SATISELEMANI"].ToString());
                ck_zorunluSatisTeklifOzelkod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_STKLF_OZELKOD"].ToString());
                ck_zorunluSatisTeklifYetkikod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_STKLF_YETKIKOD"].ToString());
                ck_zorunluSatisTeklifProjekod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_STKLF_PROJEKOD"].ToString());
                ck_zorunluSatisTeklifTicariIslemGrupkod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_STKLF_TICISLGRUP"].ToString());
                ck_zorunluSatisTeklifOdemeTipi.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_STKLF_ODEMETIP"].ToString());
                ck_zorunluSatisTeklifVade.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_STKLF_VADE"].ToString());
                ck_zorunluSatisTeklifTasiyiciKodu.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_STKLF_TASIYICIKOD"].ToString());
                ck_zorunluSatisSiparisHazirlayanPersonel.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_SSPRS_HAZIRLAYANPERSONEL"].ToString());
                ck_zorunluSatisSiparisSatisElemani.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_SSPRS_SATISELEMANI"].ToString());
                ck_zorunluSatisSiparisOzelkod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_SSPRS_OZELKOD"].ToString());
                ck_zorunluSatisSiparisYetkikod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_SSPRS_YETKIKOD"].ToString());
                ck_zorunluSatisSiparisProjekod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_SSPRS_PROJEKOD"].ToString());
                ck_zorunluSatisSiparisTicariIslemGrupkod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_SSPRS_TICISLGRUP"].ToString());
                ck_zorunluSatisSiparisOdemeTipi.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_SSPRS_ODEMETIP"].ToString());
                ck_zorunluSatisSiparisVade.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_SSPRS_VADE"].ToString());
                ck_zorunluSatisSiparisTasiyiciKodu.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_SSPRS_TASIYICIKOD"].ToString());
                ck_zorunluSatisIrsaliyeHazirlayanPersonel.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_SIRS_HAZIRLAYANPERSONEL"].ToString());
                ck_zorunluSatisIrsaliyeSatisElemani.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_SIRS_SATISELEMANI"].ToString());
                ck_zorunluSatisIrsaliyeOzelkod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_SIRS_OZELKOD"].ToString());
                ck_zorunluSatisIrsaliyeYetkikod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_SIRS_YETKIKOD"].ToString());
                ck_zorunluSatisIrsaliyeProjekod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_SIRS_PROJEKOD"].ToString());
                ck_zorunluSatisIrsaliyeTicariIslemGrupkod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_SIRS_TICISLGRUP"].ToString());
                ck_zorunluSatisIrsaliyeOdemeTipi.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_SIRS_ODEMETIP"].ToString());
                ck_zorunluSatisIrsaliyeVade.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_SIRS_VADE"].ToString());
                ck_zorunluSatisIrsaliyeTasiyiciKodu.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_SIRS_TASIYICIKOD"].ToString());
                ck_zorunluSatisFaturaHazirlayanPersonel.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_SF_HAZIRLAYANPERSONEL"].ToString());
                ck_zorunluSatisFaturaSatisElemani.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_SF_SATISELEMANI"].ToString());
                ck_zorunluSatisFaturaOzelkod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_SF_OZELKOD"].ToString());
                ck_zorunluSatisFaturaYetkikod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_SF_YETKIKOD"].ToString());
                ck_zorunluSatisFaturaProjekod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_SF_PROJEKOD"].ToString());
                ck_zorunluSatisFaturaTicariIslemGrupkod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_SF_TICISLGRUP"].ToString());
                ck_zorunluSatisFaturaOdemeTipi.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_SF_ODEMETIP"].ToString());
                ck_zorunluSatisFaturaVade.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_SF_VADE"].ToString());
                ck_zorunluSatisFaturaTasiyiciKodu.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_SF_TASIYICIKOD"].ToString());
                ck_zorunluSatinalmaTeklifHazirlayanPersonel.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_ATKLF_HAZIRLAYANPERSONEL"].ToString());
                ck_zorunluSatinalmaTeklifSatisElemani.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_ATKLF_SATISELEMANI"].ToString());
                ck_zorunluSatinalmaTeklifOzelkod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_ATKLF_OZELKOD"].ToString());
                ck_zorunluSatinalmaTeklifYetkikod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_ATKLF_YETKIKOD"].ToString());
                ck_zorunluSatinalmaTeklifProjekod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_ATKLF_PROJEKOD"].ToString());
                ck_zorunluSatinalmaTeklifTicariIslemGrupkod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_ATKLF_TICISLGRUP"].ToString());
                ck_zorunluSatinalmaTeklifOdemeTipi.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_ATKLF_ODEMETIP"].ToString());
                ck_zorunluSatinalmaTeklifVade.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_ATKLF_VADE"].ToString());
                ck_zorunluSatinalmaTeklifTasiyiciKodu.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_ATKLF_TASIYICIKOD"].ToString());
                ck_zorunluSatinalmaSiparisHazirlayanPersonel.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_ASPRS_HAZIRLAYANPERSONEL"].ToString());
                ck_zorunluSatinalmaSiparisSatisElemani.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_ASPRS_SATISELEMANI"].ToString());
                ck_zorunluSatinalmaSiparisOzelkod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_ASPRS_OZELKOD"].ToString());
                ck_zorunluSatinalmaSiparisYetkikod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_ASPRS_YETKIKOD"].ToString());
                ck_zorunluSatinalmaSiparisProjekod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_ASPRS_PROJEKOD"].ToString());
                ck_zorunluSatinalmaSiparisTicariIslemGrupkod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_ASPRS_TICISLGRUP"].ToString());
                ck_zorunluSatinalmaSiparisOdemeTipi.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_ASPRS_ODEMETIP"].ToString());
                ck_zorunluSatinalmaSiparisVade.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_ASPRS_VADE"].ToString());
                ck_zorunluSatinalmaSiparisTasiyiciKodu.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_ASPRS_TASIYICIKOD"].ToString());
                ck_zorunluSatinalmaIrsaliyeHazirlayanPersonel.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_AIRS_HAZIRLAYANPERSONEL"].ToString());
                ck_zorunluSatinalmaIrsaliyeSatisElemani.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_AIRS_SATISELEMANI"].ToString());
                ck_zorunluSatinalmaIrsaliyeOzelkod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_AIRS_OZELKOD"].ToString());
                ck_zorunluSatinalmaIrsaliyeYetkikod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_AIRS_YETKIKOD"].ToString());
                ck_zorunluSatinalmaIrsaliyeProjekod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_AIRS_PROJEKOD"].ToString());
                ck_zorunluSatinalmaIrsaliyeTicariIslemGrupkod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_AIRS_TICISLGRUP"].ToString());
                ck_zorunluSatinalmaIrsaliyeOdemeTipi.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_AIRS_ODEMETIP"].ToString());
                ck_zorunluSatinalmaIrsaliyeVade.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_AIRS_VADE"].ToString());
                ck_zorunluSatinalmaIrsaliyeTasiyiciKodu.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_AIRS_TASIYICIKOD"].ToString());
                ck_zorunluSatinalmaFaturaHazirlayanPersonel.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_AF_HAZIRLAYANPERSONEL"].ToString());
                ck_zorunluSatinalmaFaturaSatisElemani.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_AF_SATISELEMANI"].ToString());
                ck_zorunluSatinalmaFaturaOzelkod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_AF_OZELKOD"].ToString());
                ck_zorunluSatinalmaFaturaYetkikod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_AF_YETKIKOD"].ToString());
                ck_zorunluSatinalmaFaturaProjekod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_AF_PROJEKOD"].ToString());
                ck_zorunluSatinalmaFaturaTicariIslemGrupkod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_AF_TICISLGRUP"].ToString());
                ck_zorunluSatinalmaFaturaOdemeTipi.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_AF_ODEMETIP"].ToString());
                ck_zorunluSatinalmaFaturaVade.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_AF_VADE"].ToString());
                ck_zorunluSatinalmaFaturaTasiyiciKodu.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_AF_TASIYICIKOD"].ToString());
                ck_zorunluMalzemeFisiOzelKod.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_MF_OZELKOD"].ToString());
                ck_zorunluMalzemeFisiYetkiKodu.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Z_MF_YETKIKOD"].ToString());
                ck_ModulCariKartAcilisindaMuhasebeHesabiOlustur.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["MC_OTOMATIKMUHASEBEOLUSTUR"].ToString());
                ck_ModulCariKartAcilisindaAmbarParametresineGoreOtomatikKodVer.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["MC_AMBAR_OTOTMATIKKODVER"].ToString());
                txt_otomatikbarkodlog.Text = ds.Tables[0].Rows[0]["MSTK_OTOBARKODLOGICALREF"].ToString();
                ck_ModulSatisTeklifFiyatsizFisKaydedebilme.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_STKLF_FIYATSIZFISKAYDEDEBILMA"].ToString());
                ck_ModulSatisTeklifCiktidaSecmeliTasarimKullan.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_STKLF_CIKTIDASECMELITASARIMKULLAN"].ToString());
                ck_ModulSatisTeklifCariSonBakiyeGorunsun.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_STKLF_CARISONBAKIYEGORUNSUN"].ToString());
                ck_ModulSatisTeklifCokluSiparisOlusturma.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_STKLF_COKLUSIPARISOLUSTURMA"].ToString());
                ck_ModulSatisSiparisFiyatsizFisKaydedebilme.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_SSPRS_FIYATSIZFISKAYDEDEBILME"].ToString());
                ck_ModulSatisSiparisCiktidaSecmeliTasarimKullan.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_SSPRS_CIKTIDASECMELITASARIMKULLAN"].ToString());
                ck_ModulSatisSiparisCariSonBakiyeGorunsun.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_SSPRS_CARISONBAKIYEGORUNSUN"].ToString());
                ck_ModulSatisSiparisKayitIptalEtmeCikma.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_SSPRS_KAYITIPTALETMECIKARMA"].ToString());
                ck_ModulSatisIrsaliyeFiyatsizFisKaydedebilme.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_SIRS_FIYATSIZFISKAYDEDEBILME"].ToString());
                ck_ModulSatisIrsaliyeCiktidaSecmeliTasarimKullan.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_SIRS_CIKTIDASECMELITASARIMKULLAN"].ToString());
                ck_ModulSatisIrsaliyeCariSonBakiyeGorunsun.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_SIRS_CARISONBAKIYEGORUNSUN"].ToString());
                ck_ModulSatisIrsaliyeKayitIptalEtmeCikma.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_SIRS_KAYITIPTALETMECIKARMA"].ToString());
                ck_ModulSatisFaturaFiyatsizFisKaydedebilme.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_SF_FIYATSIZFISKAYDEDEBILME"].ToString());
                ck_ModulSatisFaturaCiktidaSecmeliTasarimKullan.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_SF_CIKTIDASECMELITASARIMKULLAN"].ToString());
                ck_ModulSatisFaturaCariSonBakiyeGorunsun.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_SF_CARISONBAKIYEGORUNSUN"].ToString());
                ck_ModulSatisFaturaKayitIptalEtmeCikma.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_SF_KAYITIPTALETMECIKARMA"].ToString());
                ck_ModulSatisFaturaKagitFaturaKesimi.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_SF_KAGITFATURAKESIMI"].ToString());
                ck_ModulSatisFaturaFaturaNumaratorundeIsyerineBakilsin.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_SF_NUMARATORDEISYERINEBAKILSIN"].ToString());
                ck_ModulSatisFaturaFaturaNumaratorundeAmbaraBakilsin.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_SF_NUMARATORDEAMBARABAKILSIN"].ToString());
                ck_ModulSatisFaturaKayitEsnasindaEfaturaKontroluYapilsin.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_SF_EFATURAKONTROLUYAPILSIN"].ToString());
                ck_ModulSatinalmaTeklifFiyatsizFisKaydedebilme.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_ATKLF_FIYATSIZFISKAYDEDEBILME"].ToString());
                ck_ModulSatinalmaTeklifCiktidaSecmeliTasarimKullan.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_ATKLF_CIKTIDASECMELITASARIMKULLAN"].ToString());
                ck_ModulSatinalmaTeklifCariSonBakiyeGorunsun.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_ATKLF_CARISONBAKIYEGORUNSUN"].ToString());
                ck_ModulSatinalmaTeklifCokluSiparisOlusturma.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_ATKLF_COKLUSIPARISOLUSTURMA"].ToString());
                ck_ModulSatinalmaSiparisFiyatsizFisKaydedebilme.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_ASPRS_FIYATSIZFISKAYDEDEBILME"].ToString());
                ck_ModulSatinalmaSiparisCiktidaSecmeliTasarimKullan.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_ASPRS_CIKTIDASECMELITASARIMKULLAN"].ToString());
                ck_ModulSatinalmaSiparisCariSonBakiyeGorunsun.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_ASPRS_CARISONBAKIYEGORUNSUN"].ToString());
                ck_ModulSatinalmaSiparisKayitIptalEtmeCikma.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_ASPRS_KAYITIPTALETMECIKARMA"].ToString());
                ck_ModulSatinalmaIrsaliyeFiyatsizFisKaydedebilme.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_AIRS_FIYATSIZFISKAYDEDEBILME"].ToString());
                ck_ModulSatinalmaIrsaliyeCiktidaSecmeliTasarimKullan.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_AIRS_CIKTIDASECMELITASARIMKULLAN"].ToString());
                ck_ModulSatinalmaIrsaliyeCariSonBakiyeGorunsun.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_AIRS_CARISONBAKIYEGORUNSUN"].ToString());
                ck_ModulSatinalmaIrsaliyeKayitIptalEtmeCikma.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_AIRS_KAYITIPTALETMECIKARMA"].ToString());
                ck_ModulSatinalmaFaturaFiyatsizFisKaydedebilme.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_AF_FIYATSIZFISKAYDEDEBILME"].ToString());
                ck_ModulSatinalmaFaturaCiktidaSecmeliTasarimKullan.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_AF_CIKTIDASECMELITASARIMKULLAN"].ToString());
                ck_ModulSatinalmaFaturaCariSonBakiyeGorunsun.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_AF_CARISONBAKIYEGORUNSUN"].ToString());
                ck_ModulSatinalmaFaturaKayitIptalEtmeCikma.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_AF_KAYITIPTALETMECIKARMA"].ToString());
                ck_ModulSatinalmaFaturaKagitFaturaKesimi.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_AF_KAGITFATURAKESIMI"].ToString());
                ck_ModulSatinalmaFaturaFaturaNumaratorundeIsyerineBakilsin.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_AF_NUMARATORDEISYERINEBAKILSIN"].ToString());
                ck_ModulSatinalmaFaturaFaturaNumaratorundeAmbaraBakilsin.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_AF_NUMARATORDEAMBARABAKILSIN"].ToString());
                ck_ModulSatinalmaFaturaKayitEsnasindaEfaturaKontroluYapilsin.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_AF_EFATURAKONTROLUYAPILSIN"].ToString());
                ck_ModulMalzemeFisleriAmbarFisindeOnDegerKagitGelsin.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_MF_AMBARFISINDEONDEGERKAGITGELSIN"].ToString());
                ck_ModulMalzemeFisleriCiktidaSecmeliTasarimKullan.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_MF_CIKTIDASECMELITASARIMKULLAN"].ToString());
                ck_ModulGenelModullerdeBarkodOkutmaMiktarBirlesimi.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_GNL_BARKODOKUTMAMIKTARBIRLESIMI"].ToString());
                ck_ModulGenelKayitlardanSonraSayfaKapatma.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_GNL_KAYITLARDANSONRASAYFAKAPAT"].ToString());
                ck_ModulGenelKayitlardanSonraSayfaYenileme.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_GNL_KAYITLARDANSONRASAYFAYENILE"].ToString());
                ck_ModulGenelAlternatifUrunOnerisiAktif.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_GNL_ALTERNATIFURUNONERISIAKTIF"].ToString());
                ck_ModulGenelKullaniciKasaBaglantisiKullan.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["M_GNL_KULLANICIKASABAGLANTISI"].ToString());
                cm_ModulGenelAlisfiyatininaltindaYapilacakIslem.SelectedIndex = Convert.ToInt32(ds.Tables[0].Rows[0]["M_GNL_ALISFIYATININALTINDA_YAPILACAKISLEM"].ToString());
                txt_ModulGenelAlisfiyatininorani.Text = ds.Tables[0].Rows[0]["M_GNL_ALISFIYATUSTUNEKARORANI"].ToString();
                txt_ModulGenelListelerinStandartGunFarki.Text = ds.Tables[0].Rows[0]["M_GNL_LISTELERIN_GUNFARKI"].ToString();
                rd_FiyatParametreleriOzelFiyatSecenegi.EditValue = Convert.ToInt32(ds.Tables[0].Rows[0]["FYTPRMT_OZELFIYATSECENEGI"].ToString());
                txt_FiyatParametreleriStandartPerakendeFiyatKodu.Text = ds.Tables[0].Rows[0]["FYTPRMT_PERAKENDEFIYATGRUBU"].ToString();
                txt_FiyatParametreleriStandartFiyatKodu.Text = ds.Tables[0].Rows[0]["FYTPRMT_FIYATGRUBU"].ToString();
                txt_FiyatParametreleriStandartEticaretFiyatKodu.Text = ds.Tables[0].Rows[0]["FYTPRMT_ETICARETFIYATGRUBU"].ToString();
                ck_IlkHesaplamaAlaniniKullan.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["MIKTARH_1ALANKULLAN"].ToString());
                ck_IkinciHesaplamaAlaniniKullan.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["MIKTARH_2ALANKULLAN"].ToString());
                ck_UcüncüHesaplamaAlaniniKullan.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["MIKTARH_3ALANKULLAN"].ToString());
                ck_DorduncuHesaplamaAlaniniKullan.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["MIKTARH_4ALANKULLAN"].ToString());
                ck_BesinciHesaplamaAlaniniKullan.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["MIKTARH_5ALANKULLAN"].ToString());
                txt_1AlanAdi.Text = ds.Tables[0].Rows[0]["MIKTARH_1ALANADI"].ToString();
                txt_2AlanAdi.Text = ds.Tables[0].Rows[0]["MIKTARH_2ALANADI"].ToString();
                txt_3AlanAdi.Text = ds.Tables[0].Rows[0]["MIKTARH_3ALANADI"].ToString();
                txt_4AlanAdi.Text = ds.Tables[0].Rows[0]["MIKTARH_4ALANADI"].ToString();
                txt_5AlanAdi.Text = ds.Tables[0].Rows[0]["MIKTARH_5ALANADI"].ToString();
                txt_1VarsayilanDeger.Text = ds.Tables[0].Rows[0]["MIKTARH_1ALANVARSDEGER"].ToString();
                txt_2VarsayilanDeger.Text = ds.Tables[0].Rows[0]["MIKTARH_2ALANVARSDEGER"].ToString();
                txt_3VarsayilanDeger.Text = ds.Tables[0].Rows[0]["MIKTARH_3ALANVARSDEGER"].ToString();
                txt_4VarsayilanDeger.Text = ds.Tables[0].Rows[0]["MIKTARH_4ALANVARSDEGER"].ToString();
                txt_5VarsayilanDeger.Text = ds.Tables[0].Rows[0]["MIKTARH_5ALANVARSDEGER"].ToString();
                txt_MiktarHesaplamaFormulu.Text = ds.Tables[0].Rows[0]["MIKTARH_FORMUL"].ToString();
                picFaturaLogo.Image = null; picFaturaImza.Image = null; picLoginLogo.Image = null; picFaturaEarsivLogo.Image = null; picFaturaEfaturaLogo.Image = null;
                comboboxozelkartdoldur();
                if (rd_FiyatParametreleriOzelFiyatSecenegi.EditValue.ToString() == "2")
                {
                    ozelfiyatkartalanilk.EditValue = ds.Tables[0].Rows[0]["OZELFIYATKARTSUTUNAD"].ToString(); 
                }
                if (ds.Tables[0].Rows[0]["FATURALOGO"] != System.DBNull.Value)
                {
                    photo_aray = (byte[])ds.Tables[0].Rows[0]["FATURALOGO"];
                    ms = new MemoryStream(photo_aray);
                    picFaturaLogo.Image = Image.FromStream(ms);
                }
                if (ds.Tables[0].Rows[0]["FATURAIMZA"] != System.DBNull.Value)
                {
                    photo_aray = (byte[])ds.Tables[0].Rows[0]["FATURAIMZA"];
                    ms = new MemoryStream(photo_aray);
                    picFaturaImza.Image = Image.FromStream(ms);
                }
                if (ds.Tables[0].Rows[0]["LOGINLOGO"] != System.DBNull.Value)
                {
                    photo_aray = (byte[])ds.Tables[0].Rows[0]["LOGINLOGO"];
                    ms = new MemoryStream(photo_aray);
                    picLoginLogo.Image = Image.FromStream(ms);
                }
                if (ds.Tables[0].Rows[0]["EFATURALOGO"] != System.DBNull.Value)
                {
                    photo_aray = (byte[])ds.Tables[0].Rows[0]["EFATURALOGO"];
                    ms = new MemoryStream(photo_aray);
                    picFaturaEfaturaLogo.Image = Image.FromStream(ms);
                }
                if (ds.Tables[0].Rows[0]["EARSIVLOGO"] != System.DBNull.Value)
                {
                    photo_aray = (byte[])ds.Tables[0].Rows[0]["EARSIVLOGO"];
                    ms = new MemoryStream(photo_aray);
                    picFaturaEarsivLogo.Image = Image.FromStream(ms);
                }
            }
            else
            {
                rd_FiyatParametreleriOzelFiyatSecenegi.EditValue = 1;
                //if (Demomu == 0)
                //{
                    rd_LogoBaglantiSecimi.EditValue = 1;
                    rd_LogoPaketSecimi.EditValue = 1;
                //}
                rd_OtomatikDovizTuru.EditValue = 1;
                rd_StandartKullanilacakParaBirimi.EditValue = 1;
                cm_ModulGenelAlisfiyatininaltindaYapilacakIslem.SelectedIndex = 1;
                txt_ModulGenelAlisfiyatininorani.Text = "0";
                txt_ModulGenelListelerinStandartGunFarki.Text = "30";
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                txt_BelgeNoNumaratorSSiparis_Seri.Text = ds.Tables[1].Rows[0]["SSPRS_SERI"].ToString();
                txt_BelgeNoNumaratorSSiparis_SeriNo.Text = ds.Tables[1].Rows[0]["SSPRS_SERINO"].ToString();
                txt_BelgeNoNumaratorASiparis_Seri.Text = ds.Tables[1].Rows[0]["ASPRS_SERI"].ToString();
                txt_BelgeNoNumaratorASiparis_SeriNo.Text = ds.Tables[1].Rows[0]["ASPRS_SERINO"].ToString();
                txt_BelgeNoNumaratorSIrsaliye_Seri.Text = ds.Tables[1].Rows[0]["SIRS_SERI"].ToString();
                txt_BelgeNoNumaratorSIrsaliye_SeriNo.Text = ds.Tables[1].Rows[0]["SIRS_SERINO"].ToString();
                txt_BelgeNoNumaratorAIrsaliye_Seri.Text = ds.Tables[1].Rows[0]["AIRS_SERI"].ToString();
                txt_BelgeNoNumaratorAIrsaliye_SeriNo.Text = ds.Tables[1].Rows[0]["AIRS_SERINO"].ToString();
                txt_BelgeNoNumaratorSEArsiv_Seri.Text = ds.Tables[1].Rows[0]["SFATURA_EARSIV_SERI"].ToString();
                txt_BelgeNoNumaratorSEArsiv_SeriNo.Text = ds.Tables[1].Rows[0]["SFATURA_EARSIV_SERINO"].ToString();
                txt_BelgeNoNumaratorSEFatura_Seri.Text = ds.Tables[1].Rows[0]["SFATURA_EFATURA_SERI"].ToString();
                txt_BelgeNoNumaratorSEFatura_SeriNo.Text = ds.Tables[1].Rows[0]["SFATURA_EFATURA_SERINO"].ToString();
                txt_BelgeNoNumaratorSKagit_Seri.Text = ds.Tables[1].Rows[0]["SFATURA_KAGIT_SERI"].ToString();
                txt_BelgeNoNumaratorSKagit_SeriNo.Text = ds.Tables[1].Rows[0]["SFATURA_KAGIT_SERINO"].ToString();
                txt_BelgeNoNumaratorSatinalmaFatura_Seri.Text = ds.Tables[1].Rows[0]["AFATURA_SERI"].ToString();
                txt_BelgeNoNumaratorSatinalmaFatura_SeriNo.Text = ds.Tables[1].Rows[0]["AFATURA_SERINO"].ToString();
                txt_BelgeNoNumaratorATeklif_Seri.Text = ds.Tables[1].Rows[0]["ATEKLIF_SERI"].ToString();
                txt_BelgeNoNumaratorATeklif_SeriNo.Text = ds.Tables[1].Rows[0]["ATEKLIF_SERINO"].ToString();
                txt_BelgeNoNumaratorSTeklif_Seri.Text = ds.Tables[1].Rows[0]["STEKLIF_SERI"].ToString();
                txt_BelgeNoNumaratorSTeklif_SeriNo.Text = ds.Tables[1].Rows[0]["STEKLIF_SERINO"].ToString();
            }
            else
            {
                txt_BelgeNoNumaratorSSiparis_Seri.Text = "";
                txt_BelgeNoNumaratorSSiparis_SeriNo.Text = "1";
                txt_BelgeNoNumaratorASiparis_Seri.Text = "";
                txt_BelgeNoNumaratorASiparis_SeriNo.Text = "1";
                txt_BelgeNoNumaratorSIrsaliye_Seri.Text = "";
                txt_BelgeNoNumaratorSIrsaliye_SeriNo.Text = "1";
                txt_BelgeNoNumaratorAIrsaliye_Seri.Text = "";
                txt_BelgeNoNumaratorAIrsaliye_SeriNo.Text = "1";
                txt_BelgeNoNumaratorSEArsiv_Seri.Text = "";
                txt_BelgeNoNumaratorSEArsiv_SeriNo.Text = "1";
                txt_BelgeNoNumaratorSEFatura_Seri.Text = "";
                txt_BelgeNoNumaratorSEFatura_SeriNo.Text = "1";
                txt_BelgeNoNumaratorSKagit_Seri.Text = "";
                txt_BelgeNoNumaratorSKagit_SeriNo.Text = "1";
                txt_BelgeNoNumaratorSatinalmaFatura_Seri.Text = "";
                txt_BelgeNoNumaratorSatinalmaFatura_SeriNo.Text = "1";
                txt_BelgeNoNumaratorATeklif_Seri.Text = "";
                txt_BelgeNoNumaratorATeklif_SeriNo.Text = "1";
                txt_BelgeNoNumaratorSTeklif_Seri.Text = "";
                txt_BelgeNoNumaratorSTeklif_SeriNo.Text = "1";
            }
        }
        string faturaResimYolu;
        private void simpleButton7_Click(object sender, EventArgs e)
        {
            try
            {

                if (LK_sirket.EditValue == null)
                {
                    XtraMessageBox.Show("FİRMA SEÇİMİ ZORUNLUDUR !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LK_sirket.Focus();
                    return;
                }
                if (Lk_donem.EditValue == null)
                {
                    XtraMessageBox.Show("DÖNEM SEÇİMİ ZORUNLUDUR !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Lk_donem.Focus();
                    return;
                }

                clas.Connect();
                string sqlParametre = $@"SELECT * FROM LOGO_XERO_PARAMETRELER WHERE FIRMANO='{LK_sirket.EditValue.ToString()}' AND DONEMNO='{Lk_donem.EditValue.ToString()}'";
                SqlCommand cmd = new SqlCommand(sqlParametre, clas.Conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {

                }
                else
                {
                    XtraMessageBox.Show("LOGO KAYDINDAN ÖNCE SİSTEM PARAMETRELERİ FİRMAYA AİT KAYDEDİLMELİDİR !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                OpenFileDialog ODialog = new OpenFileDialog();
                DialogResult dr = new DialogResult();
                ODialog.Title = "Dosya Aç";
                ODialog.InitialDirectory = Application.StartupPath;
                ODialog.Filter = "Resim|*.jpg;*.jpeg;*.bmp;*.png";
                ODialog.FilterIndex = 1;
                dr = ODialog.ShowDialog();
                faturaResimYolu = ODialog.FileName;
                if (dr == DialogResult.OK)
                {
                    faturaResimYolu = faturaResimYolu.Replace(@"\\", @"\").Replace(@"\", @"\\");
                    picFaturaLogo.Image = Image.FromFile(faturaResimYolu); // classImage.ImageFromFile(faturaResimYolu);

                    cmd = new SqlCommand($@"UPDATE LOGO_XERO_PARAMETRELER SET FATURALOGO=@FATURALOGO WHERE FIRMANO='{LK_sirket.EditValue.ToString()}'", clas.Conn);
                    if (picFaturaLogo.Image != null)
                    {
                        ms = new MemoryStream();
                        picFaturaLogo.Image.Save(ms, ImageFormat.Jpeg);
                        byte[] photo_aray = new byte[ms.Length];
                        ms.Position = 0;
                        ms.Read(photo_aray, 0, photo_aray.Length);
                        cmd.Parameters.AddWithValue("@FATURALOGO", photo_aray);
                    }
                    clas.Conn.Open();
                    int n = cmd.ExecuteNonQuery();
                    clas.Conn.Close();
                    if (n > 0)
                    {
                        XtraMessageBox.Show("FATURA LOGOSU KAYDEDİLDİ..", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        XtraMessageBox.Show("LOGO KAYDEDİLEMEDİ !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    return;
                }
            }
            catch (Exception h)
            {
                clas.Conn.Close();
                MessageBox.Show("HATA:" + h.ToString());
            }
        }
        string imzaResimYolu;
        private void simpleButton8_Click(object sender, EventArgs e)
        {
            try
            {
                if (LK_sirket.EditValue == null)
                {
                    XtraMessageBox.Show("FİRMA SEÇİMİ ZORUNLUDUR !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LK_sirket.Focus();
                    return;
                }
                if (Lk_donem.EditValue == null)
                {
                    XtraMessageBox.Show("DÖNEM SEÇİMİ ZORUNLUDUR !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Lk_donem.Focus();
                    return;
                }

                clas.Connect();
                string sqlParametre = $@"SELECT * FROM LOGO_XERO_PARAMETRELER WHERE FIRMANO='{LK_sirket.EditValue.ToString()}' AND DONEMNO='{Lk_donem.EditValue.ToString()}'";
                SqlCommand cmd = new SqlCommand(sqlParametre, clas.Conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {

                }
                else
                {
                    XtraMessageBox.Show("LOGO KAYDINDAN ÖNCE SİSTEM PARAMETRELERİ FİRMAYA AİT KAYDEDİLMELİDİR !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                OpenFileDialog ODialog = new OpenFileDialog();
                DialogResult dr = new DialogResult();
                ODialog.Title = "Dosya Aç";
                ODialog.InitialDirectory = Application.StartupPath;
                ODialog.Filter = "Resim|*.jpg;*.jpeg;*.bmp;*.png";
                ODialog.FilterIndex = 1;
                dr = ODialog.ShowDialog();
                imzaResimYolu = ODialog.FileName;
                if (dr == DialogResult.OK)
                {
                    imzaResimYolu = imzaResimYolu.Replace(@"\\", @"\").Replace(@"\", @"\\");
                    picFaturaImza.Image = Image.FromFile(imzaResimYolu); // classImage.ImageFromFile(faturaResimYolu);

                    cmd = new SqlCommand($@"UPDATE LOGO_XERO_PARAMETRELER SET FATURAIMZA=@FATURAIMZA WHERE FIRMANO='{LK_sirket.EditValue.ToString()}'", clas.Conn);
                    if (picFaturaImza.Image != null)
                    {
                        ms = new MemoryStream();
                        picFaturaImza.Image.Save(ms, ImageFormat.Jpeg);
                        byte[] photo_aray = new byte[ms.Length];
                        ms.Position = 0;
                        ms.Read(photo_aray, 0, photo_aray.Length);
                        cmd.Parameters.AddWithValue("@FATURAIMZA", photo_aray);
                    }
                    clas.Conn.Open();
                    int n = cmd.ExecuteNonQuery();
                    clas.Conn.Close();
                    if (n > 0)
                    {
                        XtraMessageBox.Show("FATURA İMZA RESMİ KAYDEDİLDİ..", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        XtraMessageBox.Show("İMZA RESMİ KAYDEDİLEMEDİ !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    return;
                }
            }
            catch (Exception h)
            {
                clas.Conn.Close();
                MessageBox.Show("HATA:" + h.ToString());
            }
        }
        string loginResimYolu;
        private void simpleButton9_Click(object sender, EventArgs e)
        {
            try
            {
                if (LK_sirket.EditValue == null)
                {
                    XtraMessageBox.Show("FİRMA SEÇİMİ ZORUNLUDUR !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LK_sirket.Focus();
                    return;
                }
                if (Lk_donem.EditValue == null)
                {
                    XtraMessageBox.Show("DÖNEM SEÇİMİ ZORUNLUDUR !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Lk_donem.Focus();
                    return;
                }

                clas.Connect();
                string sqlParametre = $@"SELECT * FROM LOGO_XERO_PARAMETRELER WHERE FIRMANO='{LK_sirket.EditValue.ToString()}' AND DONEMNO='{Lk_donem.EditValue.ToString()}'";
                SqlCommand cmd = new SqlCommand(sqlParametre, clas.Conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {

                }
                else
                {
                    XtraMessageBox.Show("LOGO KAYDINDAN ÖNCE SİSTEM PARAMETRELERİ FİRMAYA AİT KAYDEDİLMELİDİR !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                OpenFileDialog ODialog = new OpenFileDialog();
                DialogResult dr = new DialogResult();
                ODialog.Title = "Dosya Aç";
                ODialog.InitialDirectory = Application.StartupPath;
                ODialog.Filter = "Resim|*.jpg;*.jpeg;*.bmp;*.png";
                ODialog.FilterIndex = 1;
                dr = ODialog.ShowDialog();
                loginResimYolu = ODialog.FileName;
                if (dr == DialogResult.OK)
                {
                    loginResimYolu = loginResimYolu.Replace(@"\\", @"\").Replace(@"\", @"\\");
                    picLoginLogo.Image = Image.FromFile(loginResimYolu); // classImage.ImageFromFile(faturaResimYolu);

                    cmd = new SqlCommand($@"UPDATE LOGO_XERO_PARAMETRELER SET LOGINLOGO=@LOGINLOGO WHERE FIRMANO='{LK_sirket.EditValue.ToString()}'", clas.Conn);
                    if (picLoginLogo.Image != null)
                    {
                        ms = new MemoryStream();
                        picLoginLogo.Image.Save(ms, ImageFormat.Jpeg);
                        byte[] photo_aray = new byte[ms.Length];
                        ms.Position = 0;
                        ms.Read(photo_aray, 0, photo_aray.Length);
                        cmd.Parameters.AddWithValue("@LOGINLOGO", photo_aray);
                    }
                    clas.Conn.Open();
                    int n = cmd.ExecuteNonQuery();
                    clas.Conn.Close();
                    if (n > 0)
                    {
                        XtraMessageBox.Show("LOGIN RESMİ KAYDEDİLDİ..", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        XtraMessageBox.Show("LOGIN RESMİ KAYDEDİLEMEDİ !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    return;
                }
            }
            catch (Exception h)
            {
                clas.Conn.Close();
                MessageBox.Show("HATA:" + h.ToString());
            }
        }
        string faturaLogoEfaturaResimYolu;
        private void simpleButton11_Click(object sender, EventArgs e)
        {
            try
            {
                if (LK_sirket.EditValue == null)
                {
                    XtraMessageBox.Show("FİRMA SEÇİMİ ZORUNLUDUR !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LK_sirket.Focus();
                    return;
                }
                if (Lk_donem.EditValue == null)
                {
                    XtraMessageBox.Show("DÖNEM SEÇİMİ ZORUNLUDUR !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Lk_donem.Focus();
                    return;
                }

                clas.Connect();
                string sqlParametre = $@"SELECT * FROM LOGO_XERO_PARAMETRELER WHERE FIRMANO='{LK_sirket.EditValue.ToString()}' AND DONEMNO='{Lk_donem.EditValue.ToString()}'";
                SqlCommand cmd = new SqlCommand(sqlParametre, clas.Conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {

                }
                else
                {
                    XtraMessageBox.Show("LOGO KAYDINDAN ÖNCE SİSTEM PARAMETRELERİ FİRMAYA AİT KAYDEDİLMELİDİR !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                OpenFileDialog ODialog = new OpenFileDialog();
                DialogResult dr = new DialogResult();
                ODialog.Title = "Dosya Aç";
                ODialog.InitialDirectory = Application.StartupPath;
                ODialog.Filter = "Resim|*.jpg;*.jpeg;*.bmp;*.png";
                ODialog.FilterIndex = 1;
                dr = ODialog.ShowDialog();
                faturaLogoEfaturaResimYolu = ODialog.FileName;
                if (dr == DialogResult.OK)
                {
                    faturaLogoEfaturaResimYolu = faturaLogoEfaturaResimYolu.Replace(@"\\", @"\").Replace(@"\", @"\\");
                    picFaturaEfaturaLogo.Image = Image.FromFile(faturaLogoEfaturaResimYolu); // classImage.ImageFromFile(faturaResimYolu);

                    cmd = new SqlCommand($@"UPDATE LOGO_XERO_PARAMETRELER SET EFATURALOGO=@EFATURALOGO WHERE FIRMANO='{LK_sirket.EditValue.ToString()}'", clas.Conn);
                    if (picFaturaEfaturaLogo.Image != null)
                    {
                        ms = new MemoryStream();
                        picFaturaEfaturaLogo.Image.Save(ms, ImageFormat.Jpeg);
                        byte[] photo_aray = new byte[ms.Length];
                        ms.Position = 0;
                        ms.Read(photo_aray, 0, photo_aray.Length);
                        cmd.Parameters.AddWithValue("@EFATURALOGO", photo_aray);
                    }
                    clas.Conn.Open();
                    int n = cmd.ExecuteNonQuery();
                    clas.Conn.Close();
                    if (n > 0)
                    {
                        XtraMessageBox.Show("EFATURA LOGOSU KAYDEDİLDİ..", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        XtraMessageBox.Show("EFATURA LOGOSU KAYDEDİLEMEDİ !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    return;
                }
            }
            catch (Exception h)
            {
                clas.Conn.Close();
                MessageBox.Show("HATA:" + h.ToString());
            }
        }
        string faturaLogoEarsivResimYolu;
        private void simpleButton10_Click(object sender, EventArgs e)
        {
            try
            {
                if (LK_sirket.EditValue == null)
                {
                    XtraMessageBox.Show("FİRMA SEÇİMİ ZORUNLUDUR !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LK_sirket.Focus();
                    return;
                }
                if (Lk_donem.EditValue == null)
                {
                    XtraMessageBox.Show("DÖNEM SEÇİMİ ZORUNLUDUR !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Lk_donem.Focus();
                    return;
                }

                clas.Connect();
                string sqlParametre = $@"SELECT * FROM LOGO_XERO_PARAMETRELER WHERE FIRMANO='{LK_sirket.EditValue.ToString()}' AND DONEMNO='{Lk_donem.EditValue.ToString()}'";
                SqlCommand cmd = new SqlCommand(sqlParametre, clas.Conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {

                }
                else
                {
                    XtraMessageBox.Show("LOGO KAYDINDAN ÖNCE SİSTEM PARAMETRELERİ FİRMAYA AİT KAYDEDİLMELİDİR !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                OpenFileDialog ODialog = new OpenFileDialog();
                DialogResult dr = new DialogResult();
                ODialog.Title = "Dosya Aç";
                ODialog.InitialDirectory = Application.StartupPath;
                ODialog.Filter = "Resim|*.jpg;*.jpeg;*.bmp;*.png";
                ODialog.FilterIndex = 1;
                dr = ODialog.ShowDialog();
                faturaLogoEarsivResimYolu = ODialog.FileName;
                if (dr == DialogResult.OK)
                {
                    faturaLogoEarsivResimYolu = faturaLogoEarsivResimYolu.Replace(@"\\", @"\").Replace(@"\", @"\\");
                    picFaturaEarsivLogo.Image = Image.FromFile(faturaLogoEarsivResimYolu); // classImage.ImageFromFile(faturaResimYolu);

                    cmd = new SqlCommand($@"UPDATE LOGO_XERO_PARAMETRELER SET EARSIVLOGO=@EARSIVLOGO WHERE FIRMANO='{LK_sirket.EditValue.ToString()}'", clas.Conn);
                    if (picFaturaEarsivLogo.Image != null)
                    {
                        ms = new MemoryStream();
                        picFaturaEarsivLogo.Image.Save(ms, ImageFormat.Jpeg);
                        byte[] photo_aray = new byte[ms.Length];
                        ms.Position = 0;
                        ms.Read(photo_aray, 0, photo_aray.Length);
                        cmd.Parameters.AddWithValue("@EARSIVLOGO", photo_aray);
                    }
                    clas.Conn.Open();
                    int n = cmd.ExecuteNonQuery();
                    clas.Conn.Close();
                    if (n > 0)
                    {
                        XtraMessageBox.Show("EARSIV LOGOSU KAYDEDİLDİ..", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        XtraMessageBox.Show("EARSIV LOGOSU KAYDEDİLEMEDİ !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    return;
                }
            }
            catch (Exception h)
            {
                clas.Conn.Close();
                MessageBox.Show("HATA:" + h.ToString());
            }
        }
        private void LK_sirket_EditValueChanged(object sender, EventArgs e)
        {
            if (LK_sirket.EditValue != null)
            {
                string firma = LK_sirket.EditValue.ToString();
                if (!string.IsNullOrWhiteSpace(firma))
                {
                    donem = islem.DataSetlidonemlistesi(firma);
                    Lk_donem.Properties.DisplayMember = "NUM2";
                    Lk_donem.Properties.ValueMember = "NUM";
                    Lk_donem.Properties.DataSource = donem;
                    Lk_donem.EditValue = null;
                }
            }
        }

        private void rd_LogoBaglantiSecimi_EditValueChanged(object sender, EventArgs e)
        {
            if (rd_LogoBaglantiSecimi.EditValue.ToString() == "1")
            {
                grupRestServisKullanimi.Visible = true;
                grupObjeKullanimi.Visible = false;
            }
            else
            {
                grupRestServisKullanimi.Visible = false;
                grupObjeKullanimi.Visible = true;
            }
        }

        private void cm_ModulGenelAlisfiyatininaltindaYapilacakIslem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cm_ModulGenelAlisfiyatininaltindaYapilacakIslem.Text == "İşleme Devam Edilecek")
            {
                lbl_alisfiyatialtindaoranlabel.Visible = false;
                txt_ModulGenelAlisfiyatininorani.Text = "";
                txt_ModulGenelAlisfiyatininorani.Visible = false;
            }
            else
            {
                lbl_alisfiyatialtindaoranlabel.Visible = true;
                txt_ModulGenelAlisfiyatininorani.Visible = true;
            }
        }

        private void ck_IlkHesaplamaAlaniniKullan_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit ck = sender as CheckEdit;
            if (ck.Checked == true)
            {
                btn_1AlanDegeri.Enabled = true;
                txt_1AlanAdi.Enabled = true;
                txt_1VarsayilanDeger.Enabled = true;
            }
            else
            {
                btn_1AlanDegeri.Enabled = false;
                txt_1AlanAdi.Enabled = false;
                txt_1VarsayilanDeger.Enabled = false;
            }
        }

        private void ck_IkinciHesaplamaAlaniniKullan_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit ck = sender as CheckEdit;
            if (ck.Checked == true)
            {
                btn_2AlanDegeri.Enabled = true;
                txt_2AlanAdi.Enabled = true;
                txt_2VarsayilanDeger.Enabled = true;
            }
            else
            {
                btn_2AlanDegeri.Enabled = false;
                txt_2AlanAdi.Enabled = false;
                txt_2VarsayilanDeger.Enabled = false;
            }
        }

        private void ck_UcüncüHesaplamaAlaniniKullan_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit ck = sender as CheckEdit;
            if (ck.Checked == true)
            {
                btn_3AlanDegeri.Enabled = true;
                txt_3AlanAdi.Enabled = true;
                txt_3VarsayilanDeger.Enabled = true;
            }
            else
            {
                btn_3AlanDegeri.Enabled = false;
                txt_3AlanAdi.Enabled = false;
                txt_3VarsayilanDeger.Enabled = false;
            }
        }

        private void ck_DorduncuHesaplamaAlaniniKullan_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit ck = sender as CheckEdit;
            if (ck.Checked == true)
            {
                btn_4AlanDegeri.Enabled = true;
                txt_4AlanAdi.Enabled = true;
                txt_4VarsayilanDeger.Enabled = true;
            }
            else
            {
                btn_4AlanDegeri.Enabled = false;
                txt_4AlanAdi.Enabled = false;
                txt_4VarsayilanDeger.Enabled = false;
            }
        }

        private void ck_BesinciHesaplamaAlaniniKullan_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit ck = sender as CheckEdit;
            if (ck.Checked == true)
            {
                btn_5AlanDegeri.Enabled = true;
                txt_5AlanAdi.Enabled = true;
                txt_5VarsayilanDeger.Enabled = true;
            }
            else
            {
                btn_5AlanDegeri.Enabled = false;
                txt_5AlanAdi.Enabled = false;
                txt_5VarsayilanDeger.Enabled = false;
            }
        }

        private void btn_1AlanDegeri_Click(object sender, EventArgs e)
        {
            FormulTextineIslemYap("MH_ALAN1");

        }

        private void btn_2AlanDegeri_Click(object sender, EventArgs e)
        {
            FormulTextineIslemYap("MH_ALAN2");

        }

        private void btn_3AlanDegeri_Click(object sender, EventArgs e)
        {
            FormulTextineIslemYap("MH_ALAN3");
        }

        private void btn_4AlanDegeri_Click(object sender, EventArgs e)
        {
            FormulTextineIslemYap("MH_ALAN4");
        }

        private void btn_5AlanDegeri_Click(object sender, EventArgs e)
        {
            FormulTextineIslemYap("MH_ALAN5");
        }

        private void btn_arti_Click(object sender, EventArgs e)
        {
            FormulTextineIslemYap("+");
        }

        private void btn_eksi_Click(object sender, EventArgs e)
        {
            FormulTextineIslemYap("-");
        }

        private void btn_carpi_Click(object sender, EventArgs e)
        {
            FormulTextineIslemYap("*");
        }

        private void btn_bolme_Click(object sender, EventArgs e)
        {
            FormulTextineIslemYap("/");
        }

        private void btn_parantezBas_Click(object sender, EventArgs e)
        {
            FormulTextineIslemYap("(");
        }

        private void btn_parantezBit_Click(object sender, EventArgs e)
        {
            FormulTextineIslemYap(")");
        }

        public void FormulTextineIslemYap(string degisken)
        {
            //txt_MiktarHesaplamaFormulu.Focus();
            txt_MiktarHesaplamaFormulu.Text = txt_MiktarHesaplamaFormulu.Text.Insert(txt_MiktarHesaplamaFormulu.SelectionStart, degisken);
            txt_MiktarHesaplamaFormulu.SelectionStart = txt_MiktarHesaplamaFormulu.TextLength;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmKullaniciEkle frm = new frmKullaniciEkle();
            frm.ShowDialog();
        }

        private void Lk_donem_EditValueChanged(object sender, EventArgs e)
        {
            if (Lk_donem.EditValue != null)
            {
                string donem = Lk_donem.EditValue.ToString();
                if (!string.IsNullOrWhiteSpace(donem))
                {
                    Parametreler(1);
                }
            }
        }
        public void comboboxozelkartdoldur()
        {
            try
            {
                clas.Connect();
                string sqlParametre = $@"SELECT 
    COLUMN_NAME,
    CASE 
        WHEN COLUMN_NAME = 'CYPHCODE' THEN 'Yetki Kodu'
        WHEN COLUMN_NAME = 'CLCYPHCODE' THEN 'Cari Yetki Kodu'
        WHEN COLUMN_NAME = 'CLSPECODE' THEN 'Cari Özel Kod'
        WHEN COLUMN_NAME = 'CLSPECODE2' THEN 'Cari Özel Kod 2'
        WHEN COLUMN_NAME = 'CLSPECODE3' THEN 'Cari Özel Kod 3'
        WHEN COLUMN_NAME = 'CLSPECODE4' THEN 'Cari Özel Kod 4'
        WHEN COLUMN_NAME = 'CLSPECODE5' THEN 'Cari Özel Kod 5'
        WHEN COLUMN_NAME = 'GRPCODE' THEN 'Grup Kodu'
        WHEN COLUMN_NAME = 'TRADINGGRP' THEN 'Ticari İşlem Grubu'
    END AS 'TANIM'
FROM 
    INFORMATION_SCHEMA.COLUMNS
WHERE 
    TABLE_NAME = 'LG_{LK_sirket.EditValue.ToString()}_PRCLIST' 
    AND COLUMN_NAME IN ('CYPHCODE', 'CLCYPHCODE', 'CLSPECODE', 'CLSPECODE2', 'CLSPECODE3', 'CLSPECODE4', 'CLSPECODE5', 'GRPCODE', 'TRADINGGRP');";
                SqlCommand cmd = new SqlCommand(sqlParametre, clas.Conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                ozelfiyatkartalanilk.Properties.DataSource = ds.Tables[0]; 
                ozelfiyatkartalanilk.Properties.DisplayMember = "TANIM"; 
                ozelfiyatkartalanilk.Properties.ValueMember = "COLUMN_NAME"; 
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Firma Bilgilerinden Dolayı Hata !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } 
        }

  

        private void rd_FiyatParametreleriOzelFiyatSecenegi_EditValueChanged(object sender, EventArgs e)
        {
            if (rd_FiyatParametreleriOzelFiyatSecenegi.EditValue.ToString() == "1")
            {
                txt_FiyatParametreleriStandartFiyatKodu.Text = null;
                txt_FiyatParametreleriStandartFiyatKodu.Enabled = false;

                txt_FiyatParametreleriStandartPerakendeFiyatKodu.Text = null;
                txt_FiyatParametreleriStandartPerakendeFiyatKodu.Enabled = false;

                txt_FiyatParametreleriStandartEticaretFiyatKodu.Text = null;
                txt_FiyatParametreleriStandartEticaretFiyatKodu.Enabled = false;

                ozelfiyatkartalanilk.Enabled = false;
                ozelfiyatkartalanilk.EditValue = null;
            }
            else if (rd_FiyatParametreleriOzelFiyatSecenegi.EditValue.ToString() == "2")
            {
                txt_FiyatParametreleriStandartEticaretFiyatKodu.Enabled = true;
                txt_FiyatParametreleriStandartPerakendeFiyatKodu.Enabled = true;
                txt_FiyatParametreleriStandartFiyatKodu.Enabled = true;

                ozelfiyatkartalanilk.Enabled = true;
                ozelfiyatkartalanilk.EditValue = null;
            }
        }
    }
}