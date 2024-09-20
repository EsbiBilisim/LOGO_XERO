using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using LOGO_XERO.Models.GenelKullanim;
using LOGO_XERO.Models.LOGO_XERO_M;
using LOGO_XERO.Models.LogoObje;
using LOGO_XERO.Moduller.GenelListeler;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGO_XERO.Moduller._1_TeklifModul
{
    public partial class frmTeklifSiparisOlusturma : DevExpress.XtraEditors.XtraForm
    {
        public List<MIKTARLISATIR> sipariseGidecekler;
        frmTeklifOnaylama _frmTeklifOnaylama;
        frmTeklifOlustur _frmTeklifOlustur;
        LOGO_XERO_PARAMETRELER parametre;
        Islemler islem = new Islemler();
        frmAnaForm ana;
        string firma, donem;
        public bool islemyapildi = false;
        public frmTeklifSiparisOlusturma(frmTeklifOnaylama frmTeklifOnaylama, frmTeklifOlustur frmTeklifOlustur)
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            firma = ana.lk_firma.EditValue.ToString();
            donem = ana.lk_donem.EditValue.ToString();
            parametre = ana.parametre;
            _frmTeklifOnaylama = frmTeklifOnaylama;
            _frmTeklifOlustur = frmTeklifOlustur;
            islem.TasarimGetir(gv_teklifsiparisOlusturma, ana._Kullanici.ID, this.Name, gridcontrolTeklifSiparisOlusturma.Name);
        }
        private void frmTeklifSiparisOlusturma_Load(object sender, EventArgs e)
        {
            using (LogoContext db = new LogoContext())
            {
                string sql = $@"
select * ,(s.ONAYLANANMIKTAR-s.SIPARISEDILENMIKTAR) KALANMIKTAR from (
select ISNULL((select ONAYLANANMIKTAR from LOGO_XERO_ONAYLI_TEKLIF_SATIR_{firma} where TEKLIFID = s.TEKLIFID and TEKLIFSATIRID =s.ID),0)as ONAYLANANMIKTAR,
cast(0 as float)SIPARISEDILECEKMIKTAR,CAST(ISNULL((SELECT sum(MIKTAR) FROM LOGO_XERO_TEKLIF_SIPARISSEVK_TABLOSU_{firma} WHERE TEKLIFSATIRID=s.ID),0) AS FLOAT)SIPARISEDILENMIKTAR,
ISNULL((select ID from LOGO_XERO_ONAYLI_TEKLIF_SATIR_{firma} where TEKLIFID = s.TEKLIFID and TEKLIFSATIRID =s.ID),0) AS ONAYID,* 
from LOGO_XERO_TEKLIF_SATIR_{firma} s where s.ID IN({string.Join(",", sipariseGidecekler.Select(S => S.ID).ToArray())}) ) as s";

                gridcontrolTeklifSiparisOlusturma.DataSource = db.Database.SqlQuery<SIPARISEDONUSECEK_TEKLIF>(sql).ToList();
                gridcontrolTeklifSiparisOlusturma.RefreshDataSource();
                gridcontrolTeklifSiparisOlusturma.Refresh();
            }

        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            List<SIPARISEDONUSECEK_TEKLIF> satirlar = gv_teklifsiparisOlusturma.DataSource as List<SIPARISEDONUSECEK_TEKLIF>;
            foreach (var item in satirlar)
            {
                item.SIPARISEDILECEKMIKTAR = Convert.ToDouble(item.KALANMIKTAR);
            }
            gridcontrolTeklifSiparisOlusturma.DataSource = satirlar;
            gridcontrolTeklifSiparisOlusturma.RefreshDataSource();
            gridcontrolTeklifSiparisOlusturma.Refresh();
        }
        private void hepsiniSeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gv_teklifsiparisOlusturma.SelectAll();
        }
        private void seçilenleriKaldırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gv_teklifsiparisOlusturma.ClearSelection();
        }
        private void tasarımıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            islem.TasarimKaydet(gv_teklifsiparisOlusturma, ana._Kullanici.ID, this.Name, gridcontrolTeklifSiparisOlusturma.Name);
            XtraMessageBox.Show("Tasarım Başarıyla Kaydedildi !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void tümOnaylarıKaldırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<SIPARISEDONUSECEK_TEKLIF> satirlar = gv_teklifsiparisOlusturma.DataSource as List<SIPARISEDONUSECEK_TEKLIF>;
            foreach (var item in satirlar)
            {
                item.SIPARISEDILECEKMIKTAR = 0;
            }
            gridcontrolTeklifSiparisOlusturma.DataSource = satirlar;
            gridcontrolTeklifSiparisOlusturma.RefreshDataSource();
            gridcontrolTeklifSiparisOlusturma.Refresh();
        }

        public void SiparisOlustur(List<SIPARISEDONUSECEK_TEKLIF> liste)
        {

            if (parametre.LOGOBAGLANTISECIMI == 1)
            {
                if (string.IsNullOrWhiteSpace(parametre.RESTSERVISURL) || string.IsNullOrWhiteSpace(parametre.RESTSERVISKULLANICIADI) || string.IsNullOrWhiteSpace(parametre.RESTSERVISSIFRE))
                {
                    XtraMessageBox.Show("Rest Servis Ayarları Eksik ! Sistem Parametrelerinden Rest Servis Alanlarını Girip Programı Yeniden Başlatınız !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Logo.Siparis.Root yenisip = new Logo.Siparis.Root();

                yenisip.DATE = DateTime.Now;
                int time2 = DateTime.Now.Millisecond + 256 * DateTime.Now.Second + 65536 * DateTime.Now.Minute + 16777216 * DateTime.Now.Hour;
                yenisip.TIME = time2;
                yenisip.ARP_CODE = _frmTeklifOlustur.btn_cariKodu.Text;
                yenisip.GL_CODE = "";//muhasebeKodu

                yenisip.AUXIL_CODE = _frmTeklifOlustur.btn_OzelKod.Text;
                yenisip.AUTH_CODE = _frmTeklifOlustur.btn_YetkiKodu.Text;
                yenisip.TRADING_GRP = _frmTeklifOlustur.btn_ticariIslemGuruplari.Text;


                yenisip.DOC_NUMBER = _frmTeklifOlustur.txt_teklifno.Text;
                yenisip.SHIPPING_AGENT = _frmTeklifOlustur.btn_TasiyiciKodu.Text;
                yenisip.ORDER_STATUS = 4;

                yenisip.EINVOICE_TYPE = _frmTeklifOlustur.cm_FaturaTipiSecim.SelectedIndex;
                yenisip.VATEXCEPT_CODE = _frmTeklifOlustur.btn_KdvMuafiyetSebebiKodu.Text;
                yenisip.VATEXCEPT_REASON = _frmTeklifOlustur.txt_KdvMuafiyetSebebiAciklamasi.Text;

                yenisip.NOTES1 = _frmTeklifOlustur.txt1aciklama.Text;
                yenisip.NOTES2 = _frmTeklifOlustur.txt2aciklama.Text;
                yenisip.NOTES3 = _frmTeklifOlustur.txt3aciklama.Text;
                yenisip.NOTES4 = _frmTeklifOlustur.txt4aciklama.Text;
                yenisip.NOTES5 = _frmTeklifOlustur.txt5aciklama.Text;
                yenisip.NOTES6 = _frmTeklifOlustur.txt6aciklama.Text;

                yenisip.SALESMAN_CODE = _frmTeklifOlustur.lk_satisElemani.EditValue.ToString();
                yenisip.SOURCE_WH = Convert.ToInt16(_frmTeklifOlustur.lk_ambar.EditValue);
                yenisip.SOURCE_COST_GRP = Convert.ToInt16(_frmTeklifOlustur.lk_ambar.EditValue);
                yenisip.DIVISION = Convert.ToInt16(_frmTeklifOlustur.lk_isyeri.EditValue);
                yenisip.DEPARTMENT = Convert.ToInt16(_frmTeklifOlustur.lk_bolum.EditValue);
                yenisip.FACTORY = Convert.ToInt16(_frmTeklifOlustur.lk_fabrika.EditValue);

                var ODEME = islem.OdemeListesiGetir(firma).Where(S => S.LOGICALREF == Convert.ToInt16(_frmTeklifOlustur.lk_OdemeTipi.EditValue)).FirstOrDefault();
                if (ODEME != null)
                {
                    yenisip.PAYMENT_CODE = ODEME.CODE;
                }
                yenisip.PROJECT_CODE = _frmTeklifOlustur.btn_ProjeKodu.Text;
                yenisip.SHIPMENT_TYPE = _frmTeklifOlustur.btn_TeslimSekliKodu.Text;
                yenisip.SHIPLOC_CODE = _frmTeklifOlustur.btn_SevkAdresKodu.Text;
                yenisip.ARP_CODE_SHPM = _frmTeklifOlustur.btn_SevkHesabiKodu.Text;
                yenisip.EINVOICE = Convert.ToInt16(_frmTeklifOlustur.Efatura_resim.Visible);
                yenisip.EINVOICE_TYPE = 0;
                yenisip.WITH_PAYMENT = 0;
                yenisip.CURRSEL_TOTAL = Convert.ToInt32(_frmTeklifOlustur.GenelParaBirim.EditValue);
                yenisip.CURRSEL_DETAILS = Convert.ToInt32(_frmTeklifOlustur.SatirlarParaBirimi.EditValue);
                yenisip.RC_RATE = Convert.ToDouble(_frmTeklifOlustur.btn_raporlamakuru.Text);
                yenisip.UPD_CURR = Convert.ToInt16(_frmTeklifOlustur.rd_AktarildigindaFiyatlandirmaDoviziAynenKalacak.EditValue);
                yenisip.UPD_TRCURR = Convert.ToInt16(_frmTeklifOlustur.rd_AktarildigindaIslemDoviziAynenKalacak.EditValue);
                yenisip.CURR_TRANSACTIN = Convert.ToInt16(_frmTeklifOlustur.Lk_IslemDoviz.EditValue);
                if (yenisip.CURRSEL_DETAILS == 2)
                {
                    yenisip.CURRSEL_DETAILS = 2;
                    yenisip.TC_RATE = Convert.ToDouble(_frmTeklifOlustur.btn_islemkuru.Text);
                    yenisip.CURR_TRANSACTIN = Convert.ToInt32(_frmTeklifOlustur.Lk_IslemDoviz.EditValue.ToString());

                }
                if (yenisip.CURRSEL_DETAILS == 0 || yenisip.CURRSEL_DETAILS == 1)
                {
                    yenisip.CURR_TRANSACTIN = 0;
                }
                yenisip.DEFNFLDSLIST = new Logo.Siparis.DEFNFLDSLIST();
                yenisip.DEFNFLDSLIST.DEFNFLD = new List<Logo.Siparis.DEFNFLD>();
                if (_frmTeklifOlustur.lk_pazarlamatipi.EditValue != null)
                {
                    Logo.Siparis.DEFNFLD yenitanimlialan = new Logo.Siparis.DEFNFLD();
                    yenitanimlialan.MODULENR = 8;
                    yenitanimlialan.XMLATTRIBUTE = 1;
                    yenitanimlialan.DATAREFERENCE = 0;
                    yenitanimlialan.TEXTFLDS50 = _frmTeklifOlustur.lk_pazarlamatipi.EditValue.ToString();
                    yenisip.DEFNFLDSLIST.DEFNFLD.Add(yenitanimlialan);
                }

                if (_frmTeklifOlustur.lk_TanimliAlanOdemeTipi.EditValue != null)
                {
                    Logo.Siparis.DEFNFLD yenitanimlialan = new Logo.Siparis.DEFNFLD();
                    yenitanimlialan.MODULENR = 8;
                    yenitanimlialan.XMLATTRIBUTE = 1;
                    yenitanimlialan.DATAREFERENCE = 0;
                    yenitanimlialan.NUMFLDS50 = Convert.ToInt32(_frmTeklifOlustur.lk_TanimliAlanOdemeTipi.EditValue.ToString());
                    yenisip.DEFNFLDSLIST.DEFNFLD.Add(yenitanimlialan);
                }

                Logo.Siparis.TRANSACTIONS SAT = new Logo.Siparis.TRANSACTIONS();
                SAT.items = new List<Logo.Siparis.Item>();

                foreach (var row in liste)
                {
                    Logo.Siparis.Item satir = new Logo.Siparis.Item();
                    satir.TYPE = row.SATIRTIPI;
                    satir.QUANTITY = Convert.ToDouble(row.SIPARISEDILECEKMIKTAR);
                    satir.STOCKREF = row.STOKLOGICALREF;
                    satir.MASTER_CODE = row.STOKKODU;
                    satir.UNIT_CODE = row.BIRIM;
                    satir.PRICE = Convert.ToDouble(row.FIYAT);
                    satir.VAT_RATE = Convert.ToDouble(row.KDV);
                    if (_frmTeklifOlustur.ck_kdvdahil.Checked)
                    {
                        satir.VAT_INCLUDED = 1;
                    }
                    else
                    {
                        satir.VAT_INCLUDED = 0;
                    }

                    satir.DELVRY_CODE = row.ID.ToString();
                    satir.SOURCE_WH = row.AMBAR;
                    satir.SOURCE_COST_GRP = row.AMBAR;

                    if (yenisip.CURRSEL_DETAILS == 4)
                    {
                        satir.PC_PRICE = row.DOVIZLIFIYAT;
                        satir.PR_RATE = row.SATIRDOVIZKURU;
                        satir.CURR_PRICE = row.SATIRDOVIZKODU;

                    }
                    else if (yenisip.CURRSEL_DETAILS == 2)
                    {
                        satir.EXCLINE_PRICE = row.DOVIZLIFIYAT;
                        satir.CURR_TRANSACTIN = row.SATIRDOVIZKODU;
                    }
                    else
                    {
                        satir.CURR_TRANSACTIN = 0;
                    }


                    satir.CANDEDUCT = Convert.ToInt32(row.TEVKIFATLI);
                    satir.DEDUCT_CODE = row.TEVKIFATKODU;
                    satir.DEDUCTION_PART2 = Convert.ToInt32(row.TEVKIFATBOLEN);
                    satir.DEDUCTION_PART1 = Convert.ToInt32(row.TEVKIFATCARPAN);

                    satir.VATEXCEPT_CODE = row.KDVMUAFIYETKODU;
                    satir.VATEXCEPT_REASON = row.KDVMUAFIYETACIKLAMA;

                    satir.TRANS_DESCRIPTION = row.SATIRACIKLAMA;
                    satir.AUXIL_CODE2 = row.FIYATGURUBU;
                    satir.DUE_DATE = row.TESLIMTARIHI;

                    SAT.items.Add(satir);
                }
                yenisip.TRANSACTIONS = SAT;
                int trcode = _frmTeklifOlustur.Trkod;
                string[] sonuc = new string[3];
                try
                {
                v:
                    var request = new RestRequest(Method.POST);
                    var client1 = new RestClient(parametre.RESTSERVISURL + "/api/v1/salesOrders");
                    if (trcode == 1)
                    {
                        client1 = new RestClient(parametre.RESTSERVISURL + "/api/v1/salesOrders");//SATIŞ SİPARİŞİ
                    }
                    else if (trcode == 2)
                    {
                        client1 = new RestClient(parametre.RESTSERVISURL + "/api/v1/purchaseOrders");//SATINALMA sİPARİŞİ
                    }
                    client1.Timeout = -1;
                    string jbody = Newtonsoft.Json.JsonConvert.SerializeObject(yenisip);
                    request.AddHeader("Authorization", $@"Bearer {parametre.RESTSERVISTOKEN}");
                    request.AddParameter("application/json", jbody, ParameterType.RequestBody);
                    try
                    {

                        IRestResponse response = client1.Execute(request);
                        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        {
                            string tok = islem.tokenAl(parametre, firma);
                            parametre.RESTSERVISTOKEN = tok;
                            goto v;
                        }
                        if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                        {
                            Obje.Hata.Root sonuc1 = Newtonsoft.Json.JsonConvert.DeserializeObject<Obje.Hata.Root>(response.Content);
                            string mesaj = "";
                            if (sonuc1.ModelState.ValError0 != null)
                            {
                                if (sonuc1.ModelState.ValError0.Count > 0)
                                {
                                    mesaj += string.Join(",", sonuc1.ModelState.ValError0);
                                }
                            }
                            if (sonuc1.ModelState.ValError1 != null)
                            {
                                if (sonuc1.ModelState.ValError1.Count > 0)
                                {
                                    mesaj += string.Join(",", sonuc1.ModelState.ValError1);
                                }
                            }
                            if (sonuc1.ModelState.LOError != null)
                            {
                                if (sonuc1.ModelState.LOError.Count > 0)
                                {
                                    mesaj += string.Join(",", sonuc1.ModelState.LOError);
                                }
                            }
                            if (sonuc1.ModelState.ValError2 != null)
                            {
                                if (sonuc1.ModelState.ValError2.Count > 0)
                                {
                                    mesaj += string.Join(",", sonuc1.ModelState.ValError2);
                                }
                            }
                            if (sonuc1.ModelState.ValError3 != null)
                            {
                                if (sonuc1.ModelState.ValError3.Count > 0)
                                {
                                    mesaj += string.Join(",", sonuc1.ModelState.ValError3);
                                }
                            }
                            if (sonuc1.ModelState.ValError4 != null)
                            {
                                if (sonuc1.ModelState.ValError4.Count > 0)
                                {
                                    mesaj += string.Join(",", sonuc1.ModelState.ValError4);
                                }
                            }
                            if (sonuc1.ModelState.ValError5 != null)
                            {
                                if (sonuc1.ModelState.ValError5.Count > 0)
                                {
                                    mesaj += string.Join(",", sonuc1.ModelState.ValError5);
                                }
                            }
                            if (sonuc1.ModelState.OtherError != null)
                            {
                                if (sonuc1.ModelState.OtherError.Count > 0)
                                {
                                    mesaj += string.Join(",", sonuc1.ModelState.OtherError);
                                }
                            }
                            if (sonuc1.ModelState.DBError != null)
                            {
                                if (sonuc1.ModelState.DBError.Count > 0)
                                {
                                    mesaj += string.Join(",", sonuc1.ModelState.DBError);
                                }
                            }
                            XtraMessageBox.Show("Hata : " + mesaj, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            Obje.Basarili.Rootobject sonuc1 = Newtonsoft.Json.JsonConvert.DeserializeObject<Obje.Basarili.Rootobject>(response.Content);

                            int SiparisLogicalref = Convert.ToInt32(sonuc1.INTERNAL_REFERENCE);
                            bool kayitislemi = islem.SiparisOlustuktanSonraTeklifBilgileriniKaydetRestServisIle(yenisip.TRANSACTIONS.items, _frmTeklifOlustur.Teklifid, SiparisLogicalref, ana._Kullanici.ID, firma, donem);
                            if (kayitislemi == true)
                            {
                                _frmTeklifOnaylama.siparisolusturuldu = true;
                                XtraMessageBox.Show("Sipariş Oluşturuldu !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                XtraMessageBox.Show("Sipariş Oluşturuldu ! Sipariş Sevk Tablosuna Yazılamadı !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            this.Close();

                        }
                        if (response.StatusCode == 0)
                        {

                            XtraMessageBox.Show("Hata : " + response.ErrorMessage, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Kayıt Başarısız ! Hata= " + ex.ToString());
                    }


                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Kayıt Başarısız ! Hata=!" + ex.Message.ToString());

                    return;

                }

            }
            else if (parametre.LOGOBAGLANTISECIMI == 2)
            {
                if (string.IsNullOrWhiteSpace(parametre.OBJEKULLANICIADI) || string.IsNullOrWhiteSpace(parametre.OBJEKULLANICISIFRE))
                {
                    XtraMessageBox.Show("Obje Kullanıcı Adı Şifre Boş ! Sistem Parametrelerinden Logo Obje Kullanıcı Adı-Şifre Bilgilerini Girip Programı Yeniden Başlatınız !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                LogoObjeAktar obje = new LogoObjeAktar(_frmTeklifOlustur.parametre);

                OBJE_SIPARIS_M gidecekSiparis = new OBJE_SIPARIS_M();
                gidecekSiparis.TARIH = DateTime.Now;
                gidecekSiparis.SAAT = DateTime.Now.ToShortTimeString();
                gidecekSiparis.CARIKODU = _frmTeklifOlustur.btn_cariKodu.Text;
                gidecekSiparis.MUHASEBEKODU = "";
                gidecekSiparis.OZELKOD = _frmTeklifOlustur.btn_OzelKod.Text;
                gidecekSiparis.YETKIKODU = _frmTeklifOlustur.btn_YetkiKodu.Text;
                gidecekSiparis.TICARIISLEMGRUBU = _frmTeklifOlustur.btn_ticariIslemGuruplari.Text;
                gidecekSiparis.BELGENO = _frmTeklifOlustur.txt_teklifno.Text;
                gidecekSiparis.TASIYICIKODU = _frmTeklifOlustur.btn_TasiyiciKodu.Text;
                gidecekSiparis.SIPARISSTATU = 4;
                gidecekSiparis.ACIKLAMA1 = _frmTeklifOlustur.txt1aciklama.Text;
                gidecekSiparis.ACIKLAMA2 = _frmTeklifOlustur.txt2aciklama.Text;
                gidecekSiparis.ACIKLAMA3 = _frmTeklifOlustur.txt3aciklama.Text;
                gidecekSiparis.ACIKLAMA4 = _frmTeklifOlustur.txt4aciklama.Text;
                gidecekSiparis.ACIKLAMA5 = _frmTeklifOlustur.txt5aciklama.Text;
                gidecekSiparis.ACIKLAMA6 = _frmTeklifOlustur.txt6aciklama.Text;
                gidecekSiparis.SATISELEMANIKODU = _frmTeklifOlustur.lk_satisElemani.EditValue.ToString();
                gidecekSiparis.AMBAR = Convert.ToInt16(_frmTeklifOlustur.lk_ambar.EditValue);
                gidecekSiparis.MALIYETAMBAR = Convert.ToInt16(_frmTeklifOlustur.lk_ambar.EditValue);
                gidecekSiparis.ISYERI = Convert.ToInt16(_frmTeklifOlustur.lk_isyeri.EditValue);
                gidecekSiparis.BOLUM = Convert.ToInt16(_frmTeklifOlustur.lk_bolum.EditValue);
                gidecekSiparis.FABRIKA = Convert.ToInt16(_frmTeklifOlustur.lk_fabrika.EditValue);

                var ODEME = islem.OdemeListesiGetir(firma).Where(S => S.LOGICALREF == Convert.ToInt16(_frmTeklifOlustur.lk_OdemeTipi.EditValue)).FirstOrDefault();
                if (ODEME != null)
                {
                    gidecekSiparis.CARIODEMEKODU = ODEME.CODE;
                }

                gidecekSiparis.PROJEKODU = _frmTeklifOlustur.btn_ProjeKodu.Text;
                gidecekSiparis.TESLIMSEKLIKODU = _frmTeklifOlustur.btn_TeslimSekliKodu.Text;
                gidecekSiparis.SEVKADRESIKODU = _frmTeklifOlustur.btn_SevkAdresKodu.Text;
                gidecekSiparis.SEVKIYATHESABIKODU = _frmTeklifOlustur.btn_SevkHesabiKodu.Text;
                gidecekSiparis.EFATURA = Convert.ToInt16(_frmTeklifOlustur.Efatura_resim.Visible);

                gidecekSiparis.EINVOICE_TYPE = Convert.ToInt16(_frmTeklifOlustur.cm_FaturaTipiSecim.SelectedIndex);
                gidecekSiparis.KDVMUAFIYETKODU = _frmTeklifOlustur.btn_KdvMuafiyetSebebiKodu.Text;
                gidecekSiparis.KDVMUAFIYETACIKLAMA = _frmTeklifOlustur.txt_KdvMuafiyetSebebiAciklamasi.Text;

                gidecekSiparis.ODEMELIMI = 0;
                gidecekSiparis.CURRSELTOTAL = Convert.ToInt32(_frmTeklifOlustur.GenelParaBirim.EditValue);
                gidecekSiparis.CURRSELDETAILS = Convert.ToInt32(_frmTeklifOlustur.SatirlarParaBirimi.EditValue);
                gidecekSiparis.FIRMARAPORLAMAKURU = Convert.ToDouble(_frmTeklifOlustur.btn_raporlamakuru.Text);
                if (_frmTeklifOlustur.lk_pazarlamatipi.EditValue != null)
                {
                    gidecekSiparis.PAZARLAMATIPI = _frmTeklifOlustur.lk_pazarlamatipi.EditValue.ToString();
                }
                else
                {
                    gidecekSiparis.PAZARLAMATIPI = "";
                }

                gidecekSiparis.TANIMLIODEMETIPINUMARASI = Convert.ToInt16(_frmTeklifOlustur.lk_TanimliAlanOdemeTipi.EditValue);
                gidecekSiparis.AKTARILDIGINDAFIYALANDIRMADOVIZIDEGISSIN = Convert.ToInt16(_frmTeklifOlustur.rd_AktarildigindaFiyatlandirmaDoviziAynenKalacak.EditValue);
                gidecekSiparis.AKTARILDIGINDAISLEMDOVIZIDEGISSIN = Convert.ToInt16(_frmTeklifOlustur.rd_AktarildigindaIslemDoviziAynenKalacak.EditValue);
                gidecekSiparis.ISLEMDOVIZKURU = Convert.ToDouble(_frmTeklifOlustur.btn_islemkuru.Text);
                gidecekSiparis.ISLEMDOVIZIKODU = Convert.ToInt16(_frmTeklifOlustur.Lk_IslemDoviz.EditValue);
                if (_frmTeklifOlustur.ck_kdvdahil.Checked)
                {
                    gidecekSiparis.KDVDAHIL = 1;

                }
                else
                {
                    gidecekSiparis.KDVDAHIL = 0;
                }
                gidecekSiparis.SATIRLAR = new List<Models.LogoObje.SATIRLAR>();
                foreach (var row in liste)
                {
                    Models.LogoObje.SATIRLAR satir = new Models.LogoObje.SATIRLAR();
                    satir.MIKTAR = Convert.ToDouble(row.SIPARISEDILECEKMIKTAR);
                    satir.STOKKODU = row.STOKKODU;
                    satir.BIRIM = row.BIRIM;
                    satir.FIYAT = Convert.ToDouble(row.FIYAT);
                    satir.KDV = Convert.ToDouble(row.KDV);
                    if (_frmTeklifOlustur.ck_kdvdahil.Checked)
                    {
                        satir.KDVDAHIL = 1;
                    }
                    else
                    {
                        satir.KDVDAHIL = 0;
                    }
                    satir.STOKLOGICALREF = Convert.ToInt32(row.STOKLOGICALREF);
                    satir.DOVIZLIFIYAT = row.DOVIZLIFIYAT;
                    satir.DOVIZKODU = row.SATIRDOVIZKODU;
                    satir.DOVIZKURU = row.SATIRDOVIZKURU;
                    satir.TEKLIFSATIRID = row.ID.ToString();
                  
                    satir.TEVKIFATLI = Convert.ToInt32(row.TEVKIFATLI);
                    satir.TEVKIFATKODU = row.TEVKIFATKODU;
                    satir.TEVKIFATBOLEN = row.TEVKIFATBOLEN;
                    satir.TEVKIFATCARPAN = row.TEVKIFATCARPAN;
                  
                    satir.SATIRAMBARNO = Convert.ToInt16(row.AMBAR);
                    satir.SATIRMALIYETAMBAR = Convert.ToInt16(row.AMBAR);
                    satir.SATIRACIKLAMA = row.SATIRACIKLAMA;
                    satir.FIYATGURUBU = row.FIYATGURUBU;
                    satir.TESLIMTARIHI = row.TESLIMTARIHI;
                    satir.ISKONTO1 = Convert.ToDouble(row.ISKONTOYUZDESI1);
                    satir.ISKONTO2 = Convert.ToDouble(row.ISKONTOYUZDESI2);
                    satir.ISKONTO3 = Convert.ToDouble(row.ISKONTOYUZDESI3);
                    satir.KDVMUAFIYETKODU = row.KDVMUAFIYETKODU;
                    satir.KDVMUAFIYETACIKLAMA = row.KDVMUAFIYETACIKLAMA;

                    gidecekSiparis.SATIRLAR.Add(satir);
                }
                string[] sonuc;
                if (_frmTeklifOlustur.Trkod == 8)
                {
                    sonuc = obje.SatisSiparisiEkle(gidecekSiparis);
                }
                else
                {
                    sonuc = obje.SatinAlmaSiparisiEkle(gidecekSiparis);
                }
                if (sonuc[0] == "true")
                {
                    int SiparisLogicalref = Convert.ToInt32(sonuc[1]);
                    bool kayitislemi = islem.SiparisOlustuktanSonraTeklifBilgileriniKaydetLogoObjeIle(gidecekSiparis.SATIRLAR, _frmTeklifOlustur.Teklifid, SiparisLogicalref, ana._Kullanici.ID, firma, donem);
                    if (kayitislemi == true)
                    {
                        _frmTeklifOnaylama.siparisolusturuldu = true;
                        XtraMessageBox.Show("Sipariş Oluşturuldu !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XtraMessageBox.Show("Sipariş Oluşturuldu ! Sipariş Sevk Tablosuna Yazılamadı !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Close();

                }
                else
                {
                    XtraMessageBox.Show("Hata : " + sonuc[0].ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            else
            {
                XtraMessageBox.Show("Logo Bağlantı Ayarı Yapılmamış ! Sistem Parametrelerinden Logo Bağlantı Seçimi Ayarını Düzenleyiniz ! Programı Tekrar Başlatınız ! ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void frmTeklifSiparisOlusturma_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_frmTeklifOnaylama.siparisolusturuldu == false)
            {

                if (XtraMessageBox.Show("Onaylanan Satırlar Silinecektir Devam Etmek İstiyor Musunuz ! ", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {

                    using (LogoContext db = new LogoContext())
                    {
                        List<LOGO_XERO_ONAYLI_TEKLIF_SATIR> list = db.LOGO_XERO_ONAYLI_TEKLIF_SATIR.Where(s => s.TEKLIFID == _frmTeklifOlustur.Teklifid).ToList();
                        if (list != null)
                        {
                            db.LOGO_XERO_ONAYLI_TEKLIF_SATIR.RemoveRange(list);
                        }
                        db.SaveChanges();
                    }
                    _frmTeklifOlustur.xtraTabControl2.SelectedTabPage = _frmTeklifOlustur.OnayliTeklifSatirlariTab;
                }
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int[] selectedRowHandles = gv_teklifsiparisOlusturma.GetSelectedRows();
            if (selectedRowHandles.Count() == 0)
            {
                XtraMessageBox.Show("Sipariş Edilecek Satırları Seçiniz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            List<SIPARISEDONUSECEK_TEKLIF> sipariseGidecekListesi = new List<SIPARISEDONUSECEK_TEKLIF>();
            for (int i = 0; i < selectedRowHandles.Length; i++)
            {
                SIPARISEDONUSECEK_TEKLIF row = (SIPARISEDONUSECEK_TEKLIF)gv_teklifsiparisOlusturma.GetRow(selectedRowHandles[i]);
                if (row.SIPARISEDILECEKMIKTAR == 0)
                {
                    XtraMessageBox.Show("Seçili Satırlarda Sipariş Edilecek Miktar 0 Olamaz ! Seçimlerinizi Kontrol Edin !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (row.SIPARISEDILECEKMIKTAR > (row.ONAYLANANMIKTAR - row.SIPARISEDILENMIKTAR))
                {
                    XtraMessageBox.Show("Sipariş Edilecek Miktar Onaylanan Miktardan Fazla Olamaz ! Seçimlerinizi Kontrol Edin !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                sipariseGidecekListesi.Add(row);
            }
            SiparisOlustur(sipariseGidecekListesi);
        }
    }
}