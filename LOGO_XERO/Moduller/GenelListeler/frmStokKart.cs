using DevExpress.CodeParser;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using LOGO_XERO.Models.GenelKullanim;
using LOGO_XERO.Models.LOGO_M;
using LOGO_XERO.Models.LOGO_M.DosyaClaslari;
using LOGO_XERO.Models.LOGO_XERO_M;
using LOGO_XERO.Models.LogoObje;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace LOGO_XERO.Moduller.GenelListeler
{
    public partial class frmStokKart : DevExpress.XtraEditors.XtraForm
    {
        string firma, donem;
        frmAnaForm ana;
        Islemler islem = new Islemler();
        LogoObjeAktar obj;
        public int Stokreferans = 0;
        int standartfiyat = 0;
        int perakendefiyat = 0;

        public List<L_FIRMPARAMS> FirmaLogoParametre;

        public frmStokKart()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            firma = ana.lk_firma.EditValue.ToString();
            donem = ana.lk_donem.EditValue.ToString();
            obj = new LogoObjeAktar(ana.parametre);
            //islem.XeroDovizListesiGetir(ana.lk_firma.EditValue.ToString()).ForEach(s => cboxdovizstan.Properties.Items.Add(s.ACIKLAMA));
            islem.XeroDovizBilgileriDoldur(lkdovizperakende, ana.lk_firma.EditValue.ToString());
            islem.XeroDovizBilgileriDoldur(lkdovizstandar, ana.lk_firma.EditValue.ToString()); 
            if (!string.IsNullOrWhiteSpace(txtLogicalRef.Text))
            {
                btn_ambarparametreleri.Visible = true;
            } 
            
        }
        public void SatisFiyatGetir() 
        {
            lkdovizperakende.EditValue = 0;
            lkdovizstandar.EditValue = 0;
            if (ana.parametre.FYTPRMT_OZELFIYATSECENEGI == 1)
            {
                lkdovizperakende.Enabled = false;
                txtFiyatiPerak.Enabled = false;
                txttanimi.Enabled = false;
                ckkdvpar.Enabled = false;
                txttanimistand.Enabled = false;
                DOUBLEAD fiyat1 = islem.FiyatGetirPRCLIST(Stokreferans, firma, "");
                if (fiyat1 != null)
                {
                    ckkdvstan.Checked = fiyat1.INCVAT;
                    lkdovizstandar.EditValue = fiyat1.CURRENCY;
                    txtFiyatiStandar.Text = fiyat1.PRICE.ToString();
                    standartfiyat = fiyat1.LOGICALREF;
                }
            }
            else
            {
                txttanimi.Text = ana.parametre.FYTPRMT_PERAKENDEFIYATGRUBU.ToString();
                txttanimistand.Text = ana.parametre.FYTPRMT_FIYATGRUBU.ToString();
                string fiyatsorgu = " ";
                string perakendesorgu = " ";

                string sutunadi = !string.IsNullOrWhiteSpace(ana.parametre.OZELFIYATKARTSUTUNAD) ? ana.parametre.OZELFIYATKARTSUTUNAD : " ";
                string fiyatgrubu = !string.IsNullOrWhiteSpace(ana.parametre.FYTPRMT_FIYATGRUBU) ? ana.parametre.FYTPRMT_FIYATGRUBU : " ";
                string perakendefiyatgrubu = !string.IsNullOrWhiteSpace(ana.parametre.FYTPRMT_PERAKENDEFIYATGRUBU) ? ana.parametre.FYTPRMT_PERAKENDEFIYATGRUBU : " ";

                if (!string.IsNullOrWhiteSpace(sutunadi) && !string.IsNullOrWhiteSpace(fiyatgrubu))
                {
                    fiyatsorgu = $@" AND {sutunadi} = {fiyatgrubu}"; 
                }
                if (!string.IsNullOrWhiteSpace(sutunadi) && !string.IsNullOrWhiteSpace(perakendefiyatgrubu))
                {
                    perakendesorgu = $@"AND {sutunadi} = {perakendefiyatgrubu} ";
                }

                if (!string.IsNullOrWhiteSpace(ana.parametre.FYTPRMT_FIYATGRUBU))
                {
                    DOUBLEAD fiyat1 = islem.FiyatGetirPRCLIST(Stokreferans, firma, fiyatsorgu);
                    if (fiyat1 !=null)
                    {
                        ckkdvstan.Checked = fiyat1.INCVAT;
                        lkdovizstandar.EditValue = fiyat1.CURRENCY;
                        txtFiyatiStandar.Text = fiyat1.PRICE.ToString();
                        standartfiyat = fiyat1.LOGICALREF;
                    }
                }
                if (!string.IsNullOrWhiteSpace(ana.parametre.FYTPRMT_PERAKENDEFIYATGRUBU))
                {
                    DOUBLEAD fiyat2 = islem.FiyatGetirPRCLIST(Stokreferans, firma, perakendesorgu);
                    if (fiyat2 != null)
                    {
                        ckkdvpar.Checked = fiyat2.INCVAT;
                        lkdovizperakende.EditValue = fiyat2.CURRENCY;
                        txtFiyatiPerak.Text = fiyat2.PRICE.ToString();
                        perakendefiyat = fiyat2.LOGICALREF;
                    } 
                } 
            } 
              
        }
       
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStokKodu.Text))
            {
                XtraMessageBox.Show("Stok Kodu Olmadan Kayıt Ekleyemezsiniz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtStokKodu.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txt_BirimKodu.Text))
            {
                XtraMessageBox.Show("Birim Seçimi Yapmadan Kayıt Ekleyemezsiniz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_BirimKodu.Focus();
                return;
            }

            using (LogoContext db = new LogoContext())
            {
                var parametreler = db.LOGO_XERO_PARAMETRELER.Where(s => s.FIRMANO == firma && s.DONEMNO == donem).FirstOrDefault();
                if (parametreler != null)
                {
                    bool ozelKod1 = (bool)parametreler.ZSTK_OZELKOD1;
                    bool ozelKod2 = (bool)parametreler.ZSTK_OZELKOD2;
                    bool ozelKod3 = (bool)parametreler.ZSTK_OZELKOD3;
                    bool ozelKod4 = (bool)parametreler.ZSTK_OZELKOD4;
                    bool ozelKod5 = (bool)parametreler.ZSTK_OZELKOD5;
                    bool marka = (bool)parametreler.ZSTK_MARKA;
                    bool grupKodu = (bool)parametreler.ZSTK_GRUPKODU;
                    bool fiyat = (bool)parametreler.ZSTK_FIYAT;

                    if (ozelKod1 && string.IsNullOrEmpty(txtOzelKod1.Text))
                    {
                        XtraMessageBox.Show("ÖZEL KOD 1 ALANI ZORUNLU ALAN !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtOzelKod1.Focus();
                        return;
                    }

                    if (ozelKod2 && string.IsNullOrEmpty(txtOzelKod2.Text))
                    {
                        XtraMessageBox.Show("ÖZEL KOD 2 ALANI ZORUNLU ALAN !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtOzelKod2.Focus();
                        return;
                    }

                    if (ozelKod3 && string.IsNullOrEmpty(txtOzelKod3.Text))
                    {
                        XtraMessageBox.Show("ÖZEL KOD 3 ALANI ZORUNLU ALAN !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtOzelKod3.Focus();
                        return;
                    }

                    if (ozelKod4 && string.IsNullOrEmpty(txtOzelKod4.Text))
                    {
                        XtraMessageBox.Show("ÖZEL KOD 4 ALANI ZORUNLU ALAN !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtOzelKod4.Focus();
                        return;
                    }

                    if (ozelKod5 && string.IsNullOrEmpty(txtOzelKod5.Text))
                    {
                        XtraMessageBox.Show("ÖZEL KOD 5 ALANI ZORUNLU ALAN !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtOzelKod5.Focus();
                        return;
                    }

                    if (marka && string.IsNullOrEmpty(txtMarka.Text))
                    {
                        XtraMessageBox.Show("MARKA ALANI ZORUNLU ALAN !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtMarka.Focus();
                        return;
                    }

                    if (grupKodu && string.IsNullOrEmpty(txtGrupKodu.Text))
                    {
                        XtraMessageBox.Show("GRUP KODU ALANI ZORUNLU ALAN !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtGrupKodu.Focus();
                        return;
                    }

                    if (fiyat && string.IsNullOrEmpty(txtFiyatiStandar.Text))
                    {
                        XtraMessageBox.Show("STANDART FİYAT ALANI ZORUNLU ALAN !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtFiyatiStandar.Focus();
                        return;
                    }

                    if (fiyat && string.IsNullOrEmpty(txtFiyatiPerak.Text))
                    {
                        XtraMessageBox.Show("PERAKENDE FİYAT ALANI ZORUNLU ALAN !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtFiyatiPerak.Focus();
                        return;
                    }
                }
            }

            Logo.STOK.Rootobject stok = new Logo.STOK.Rootobject();
            stok.CARD_TYPE = 1;
            stok.INTERNAL_REFERENCE = Stokreferans;
            stok.CODE = txtStokKodu.Text;
            stok.NAME = txt_Aciklama.Text;
            stok.NAME3 = txtAciklama2.Text;
            stok.NAME4 = txt_aciklama3.Text;
            stok.AUXIL_CODE = txtOzelKod1.Text;
            stok.AUXIL_CODE2 = txtOzelKod2.Text;
            stok.AUXIL_CODE3 = txtOzelKod3.Text;
            stok.AUXIL_CODE4 = txtOzelKod4.Text;
            stok.AUXIL_CODE5 = txtOzelKod5.Text;
            stok.AUTH_CODE = btn_yetkikodu.Text;
            stok.MARKCODE = txtMarka.Text;
            stok.GROUP_CODE = txtGrupKodu.Text;
            stok.PRODUCER_CODE = txt_UreticiKodu.Text;
            //stok.KDV_DEPT_NR = Convert.ToInt32(txtDepartmanNo.Text);


            stok.VAT = txt_SatinAlmaKdv.Text;
            stok.SELVAT = txt_SatisKdv.Text;
            stok.RETURNVAT = txt_IadeKdv.Text;
            stok.SELPRVAT = txt_perakendeSatisKdv.Text;
            stok.RETURNPRVAT = txt_PerakendeIadeKdv.Text;

            //kullanım yeri
            stok.USEF_MM = Convert.ToInt32(ck_MalzemeYonetimi.EditValue);
            stok.USEF_PURCHASING = Convert.ToInt32(ck_Satinalma.EditValue);
            stok.USEF_SALES = Convert.ToInt32(ck_SatisveDagitim.EditValue);

            //ek vergi kullanım yeri
            stok.ADDTAXPURCHBRWS = Convert.ToInt32(ck_EkVergiKullanimYeriSatinAlma.EditValue);
            stok.ADDTAXSALESBRWS = Convert.ToInt32(ck_EkVergiKullanimYeriSatis.EditValue);

            //tevkifat kısmı
            stok.CAN_DEDUCT = Convert.ToInt32(ck_tevkifatUygulansin.Checked);
            stok.DEDUCT_CODE = btn_SatisTevkifatKodu.Text;
            stok.PURCH_DEDUCT_CODE = btn_alisTevkifatKodu.Text;
            stok.SALE_DEDUCTION_PART1 = Convert.ToInt32(txt_satisTevkifatOraniCarpan.Text);
            stok.SALE_DEDUCTION_PART2 = Convert.ToInt32(txt_satisTevkifatOraniBolen.Text);
            stok.PURCH_DEDUCTION_PART1 = Convert.ToInt32(txt_alisTevkifatOraniCarpan.Text);
            stok.PURCH_DEDUCTION_PART2 = Convert.ToInt32(txt_alisTevkifatOraniBolen.Text);


            //izleme ve sıralama
            stok.TRACK_TYPE = Convert.ToInt32(rd_izlemeYonetimiSecimi.EditValue);
            stok.DIST_LOT_UNITS = Convert.ToInt32(ck_lotBirimleriDagitilabilir.Checked);
            stok.COMB_LOT_UNITS = Convert.ToInt32(ck_lotBirimleriBirlestirilebilir.Checked);
            stok.LOTS_DIVISIBLE = Convert.ToInt32(ck_lotBuyuklukleribolunebilir.EditValue);


            stok.LOCATION_TRACKING = Convert.ToInt32(ck_StokYeriTakibiYapilacak.EditValue);//stok yeri takibi yapılacak

            if (Stokreferans == 0)
            {
                stok.DATE_CREATED = DateTime.Now;
                stok.HOUR_CREATED = DateTime.Now.Hour;
                stok.MIN_CREATED = DateTime.Now.Minute;
                stok.SEC_CREATED = DateTime.Now.Second;
            }
            else
            {
                stok.DATE_MODIFIED = DateTime.Now;
                stok.HOUR_MODIFIED = DateTime.Now.Hour;
                stok.MIN_MODIFIED = DateTime.Now.Minute;
                stok.SEC_MODIFIED = DateTime.Now.Second;
            }

            stok.UNITSET_CODE = txt_BirimKodu.Text;


            stok.UNITS = new Logo.STOK.UNITS();
            stok.UNITS.items = new List<Logo.STOK.Item>();
            List<LG_UNITSETL> birimler = grid_Birimler.DataSource as List<LG_UNITSETL>;
            foreach (var item in birimler)
            {
                string barkodd = "";


                Logo.STOK.Item yeni = new Logo.STOK.Item();
                yeni.UNIT_CODE = item.CODE;
                if (item.CONVFACT1 == 0)
                {
                    yeni.CONV_FACT1 = 1;
                }
                else
                {
                    yeni.CONV_FACT1 = Convert.ToDouble(item.CONVFACT1);
                }
                if (item.CONVFACT2 == 0)
                {
                    yeni.CONV_FACT2 = 1;
                }
                else
                {
                    yeni.CONV_FACT2 = Convert.ToDouble(item.CONVFACT2);
                }
                yeni.BARCODE_LIST = new Logo.STOK.BARCODE_LIST();
                yeni.BARCODE_LIST.items = new List<Logo.Barkod.Item>();

                if (item.CHECKOTOMATIKBARKOD == false && !string.IsNullOrWhiteSpace(item.BUTONBARKOD))
                {
                    barkodd = item.BUTONBARKOD;
                }
                else if (item.CHECKOTOMATIKBARKOD == true)
                {
                    barkodd = islem.LogoBarkodOlustur(ana.parametre, firma);
                }
                if (islem.BarkodLogodaKayitli(barkodd, stok.INTERNAL_REFERENCE) && !string.IsNullOrWhiteSpace(barkodd))
                {
                    XtraMessageBox.Show($@"{item.NAME} Birimine Yazılan Barkod Zaten Kullanımda !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (stok.INTERNAL_REFERENCE != 0)
                {
                    List<LG_UNITBARCODE> barkodlar = islem.BirimVeStokBarkodGetir(stok.INTERNAL_REFERENCE, item.LOGICALREF);
                    foreach (var barkod in barkodlar)
                    {
                        yeni.BARCODE_LIST.items.Add(new Logo.Barkod.Item { BARCODE = barkod.BARCODE, LINENR = barkod.LINENR });
                    }
                }
                if (!string.IsNullOrWhiteSpace(barkodd))
                {
                    if (stok.INTERNAL_REFERENCE == 0)
                    { 
                        yeni.BARCODE_LIST.items.Add(new Logo.Barkod.Item { BARCODE = barkodd });
                    }
                    else
                    {
                        if (yeni.BARCODE_LIST.items.Where(s => s.BARCODE == barkodd).Count() == 0)
                        {
                            var kay = yeni.BARCODE_LIST.items.FirstOrDefault(s => s.LINENR == 1);
                            if (kay != null)
                            {
                                kay.BARCODE = barkodd;
                            }
                        }

                    }
                   


                }
                yeni.USEF_MTRLCLASS = 1;
                yeni.USEF_PURCHCLAS = 1;
                yeni.USEF_SALESCLAS = 1;

                yeni.WIDTH = Convert.ToDouble(item.WIDTH);
                yeni.LENGTH = Convert.ToDouble(item.LENGTH);
                yeni.HEIGHT = Convert.ToDouble(item.HEIGHT);
                yeni.AREA = Convert.ToDouble(item.AREA);
                yeni.VOLUME = Convert.ToDouble(item.VOLUME_);
                yeni.WEIGHT = Convert.ToDouble(item.WEIGHT);
                yeni.GROSS_VOLUME = Convert.ToDouble(item.GROSSVOLUME);
                yeni.GROSS_WEIGHT = Convert.ToDouble(item.GROSSWEIGHT);

                yeni.WIDTH_CODE = item.BUTONEN;
                yeni.LENGTH_CODE = item.BUTONBOY;
                yeni.HEIGHT_CODE = item.BUTONYUKSEKLIK;
                yeni.AREA_CODE = item.BUTONALAN;
                yeni.VOLUME_CODE = item.BUTONNETHACIM;
                yeni.GROSS_VOL_CODE = item.BUTONBRUTHACIM;
                yeni.WEIGHT_CODE = item.BUTONNETAGIRLIK;
                yeni.GROSS_WGHT_CODE = item.BUTONBRUTRAGIRLIK;

                stok.UNITS.items.Add(yeni);
            }



            if (ana.parametre.LOGOBAGLANTISECIMI == 1)
            {
                if (string.IsNullOrWhiteSpace(ana.parametre.RESTSERVISURL) || string.IsNullOrWhiteSpace(ana.parametre.RESTSERVISKULLANICIADI) || string.IsNullOrWhiteSpace(ana.parametre.RESTSERVISSIFRE))
                {
                    XtraMessageBox.Show("Rest Servis Ayarları Eksik ! Sistem Parametrelerinden Rest Servis Alanlarını Girip Programı Yeniden Başlatınız !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                string[] sonuc = new string[3];
                try
                {
                v:
                    var request = new RestRequest(RestSharp.Method.POST);
                    var client1 = new RestClient(ana.parametre.RESTSERVISURL + "/api/v1/items");
                    if (Stokreferans > 0)
                    {
                        client1 = new RestClient(ana.parametre.RESTSERVISURL + "/api/v1/items/" + Stokreferans);
                        request = new RestRequest(RestSharp.Method.PUT);
                    }

                    client1.Timeout = -1;
                    string jbody = Newtonsoft.Json.JsonConvert.SerializeObject(stok);
                    request.AddHeader("Authorization", $@"Bearer {ana.parametre.RESTSERVISTOKEN}");
                    request.AddParameter("application/json", jbody, ParameterType.RequestBody);
                    try
                    {

                        IRestResponse response = client1.Execute(request);
                        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        {
                            string tok = islem.tokenAl(ana.parametre, firma);
                            ana.parametre.RESTSERVISTOKEN = tok;
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

                            int stokref = Convert.ToInt32(sonuc1.INTERNAL_REFERENCE);
                            Stokreferans = stokref;
                            txtLogicalRef.Text = stokref.ToString();
                            fiyatEkleGuncelle();
                            btn_ambarparametreleri.Visible = true;
                            XtraMessageBox.Show("Stok Ekleme Başarılı !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                            //this.Close();

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
            else if (ana.parametre.LOGOBAGLANTISECIMI == 2)
            {
                if (string.IsNullOrWhiteSpace(ana.parametre.OBJEKULLANICIADI) || string.IsNullOrWhiteSpace(ana.parametre.OBJEKULLANICISIFRE))
                {
                    XtraMessageBox.Show("Obje Kullanıcı Adı Şifre Boş ! Sistem Parametrelerinden Logo Obje Kullanıcı Adı-Şifre Bilgilerini Girip Programı Yeniden Başlatınız !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                LogoObjeAktar obje = new LogoObjeAktar(ana.parametre);


                string[] sonuc;
                if (Stokreferans > 0)
                {
                    sonuc = obje.StokKartiDuzenle(stok);
                }
                else
                {
                    sonuc = obje.StokKartiEkle(stok);
                }
                if (sonuc[0] == "true")
                {
                    int stokref = Convert.ToInt32(sonuc[1]);
                    Stokreferans = stokref;
                    txtLogicalRef.Text = sonuc[1].ToString();
                    fiyatEkleGuncelle();
                    btn_ambarparametreleri.Visible = true;
                    XtraMessageBox.Show("Stok Ekleme Başarılı !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Close();

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
        public void fiyatEkleGuncelle()
        {
            if (txtFiyatiStandar.Text != "0")
            {
                islem.sqlInsertPRCLIST(firma, ckkdvstan.Checked, Stokreferans, Convert.ToInt32(lkdovizstandar.EditValue), Convert.ToDouble(txtFiyatiStandar.Text), standartfiyat, ana.parametre, ana.parametre.FYTPRMT_FIYATGRUBU); //standarticin
            }
            if (txtFiyatiPerak.Text != "0")
            {
                if (ana.parametre.FYTPRMT_OZELFIYATSECENEGI != 1)
                {
                    islem.sqlInsertPRCLIST(firma, ckkdvpar.Checked, Stokreferans, Convert.ToInt32(lkdovizperakende.EditValue), Convert.ToDouble(txtFiyatiPerak.Text), perakendefiyat, ana.parametre, ana.parametre.FYTPRMT_PERAKENDEFIYATGRUBU);
                }
            }
        }
        private void txtOzelKod1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            islem.OzelKodListesiAc(this, 1, 1, 1, 1);
        }
        private void txtOzelKod2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.OzelKodListesiAc(this, 1, 1, 1, 2);
        }
        private void txtOzelKod3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.OzelKodListesiAc(this, 1, 1, 1, 3);
        }
        private void txtOzelKod4_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.OzelKodListesiAc(this, 1, 1, 1, 4);
        }
        private void txtOzelKod5_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.OzelKodListesiAc(this, 1, 1, 1, 5);
        }
        private void txtGrupKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.OzelKodListesiAc(this, 4, 4, 0, 0);
        }
        private void txtBirim_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmBirimler birim = new frmBirimler(this);
            birim.ShowDialog();

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtMarka_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmMarkalar frm = new frmMarkalar(this);
            frm.ShowDialog();
        }
        private void txtDoviz_SelectedIndexChanged(object sender, EventArgs e)
        {
            string firma = ana.lk_firma.EditValue.ToString();
            //txtDovizKodu.Text = islem.XeroDovizListesiGetir(firma).Where(s => s.DOVIZCINSI == cboxdovizstan.Text).FirstOrDefault().DOVIZKODU.ToString();
        }
        private void frmStokKart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                simpleButton2_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void ckBarkod_CheckedChanged(object sender, EventArgs e)
        {
            LG_UNITSETL secili = (LG_UNITSETL)gridView1.GetFocusedRow();
            if (secili != null)
            {
                secili.CHECKOTOMATIKBARKOD = ckBarkod.Checked;
                secili.DEGISTI = 1;
            }
            if (ckBarkod.Checked)
            {
                txtBarkod.Properties.ReadOnly = true;
            }
            else
            {
                txtBarkod.Properties.ReadOnly = false;
            }
        }
        private void simpleButton8_Click(object sender, EventArgs e)
        {
            txt_BirimKodu.Text = "";
            txt_BirimAciklama.Text = "";
        }
        private void simpleButton7_Click(object sender, EventArgs e)
        {
            txtOzelKod1.Text = "";
        }
        private void btn_ozelkod1temizle_Click(object sender, EventArgs e)
        {
            txtOzelKod2.Text = "";
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            txtOzelKod3.Text = "";
        }
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            txtOzelKod4.Text = "";
        }
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            txtOzelKod5.Text = "";
        }
        private void frmStokKart_Load(object sender, EventArgs e)
        {
            FirmaLogoParametre = islem.FirmaLogoTumParametreleriGetir(ana.lk_firma.EditValue.ToString());
            SatisFiyatGetir();
            if (Stokreferans == 0)
            {
                btn_ambarparametreleri.Visible = false;
                L_FIRMPARAMS alisKdvParametresi = FirmaLogoParametre.Where(s => s.GROUPNR == 1 && s.MODULENR == 11 && s.CODE == "FIN_PURDEFVATRATE").FirstOrDefault();
                L_FIRMPARAMS satisKdvParametresi = FirmaLogoParametre.Where(s => s.GROUPNR == 2 && s.MODULENR == 11 && s.CODE == "FIN_SALDEFVATRATE").FirstOrDefault();
                L_FIRMPARAMS iadeKdvParametresi = FirmaLogoParametre.Where(s => s.GROUPNR == 3 && s.MODULENR == 11 && s.CODE == "FIN_RETDEFVATRATE").FirstOrDefault();
                L_FIRMPARAMS perakendeSatisKdvParametresi = FirmaLogoParametre.Where(s => s.GROUPNR == 59 && s.MODULENR == 11 && s.CODE == "FIN_SALPERDEFVATRATE").FirstOrDefault();
                L_FIRMPARAMS perakendeSatisIadeKdvParametresi = FirmaLogoParametre.Where(s => s.GROUPNR == 60 && s.MODULENR == 11 && s.CODE == "FIN_RETPERDEFVATRATE").FirstOrDefault();

                L_FIRMPARAMS satisTevkifatCarpan = FirmaLogoParametre.Where(s => s.GROUPNR == 85 && s.MODULENR == 10 && s.CODE == "SALES_DEDUCTIONPART1").FirstOrDefault();
                L_FIRMPARAMS satisTevkifatBolen = FirmaLogoParametre.Where(s => s.GROUPNR == 86 && s.MODULENR == 10 && s.CODE == "SALES_DEDUCTIONPART2").FirstOrDefault();
                L_FIRMPARAMS alisTevkifatCarpan = FirmaLogoParametre.Where(s => s.GROUPNR == 85 && s.MODULENR == 9 && s.CODE == "PURCH_DEDUCTIONPART1").FirstOrDefault();
                L_FIRMPARAMS alisTevkifatBolen = FirmaLogoParametre.Where(s => s.GROUPNR == 86 && s.MODULENR == 9 && s.CODE == "PURCH_DEDUCTIONPART2").FirstOrDefault();


                txt_IadeKdv.Text = iadeKdvParametresi.VALUE;
                txt_SatisKdv.Text = satisKdvParametresi.VALUE;
                txt_SatinAlmaKdv.Text = alisKdvParametresi.VALUE;
                txt_PerakendeIadeKdv.Text = perakendeSatisIadeKdvParametresi.VALUE;
                txt_perakendeSatisKdv.Text = perakendeSatisKdvParametresi.VALUE;

                txt_satisTevkifatOraniCarpan.Text = satisTevkifatCarpan.VALUE;
                txt_satisTevkifatOraniBolen.Text = satisTevkifatBolen.VALUE;
                txt_alisTevkifatOraniCarpan.Text = alisTevkifatCarpan.VALUE;
                txt_alisTevkifatOraniBolen.Text = alisTevkifatBolen.VALUE;

                rd_izlemeYonetimiSecimi.EditValue = 0;
                ck_lotBirimleriBirlestirilebilir.Checked = true;
                ck_lotBirimleriDagitilabilir.Checked = true;
                ck_lotBuyuklukleribolunebilir.Checked = true;

                ck_EkVergiKullanimYeriSatinAlma.Checked = true;
                ck_EkVergiKullanimYeriSatis.Checked = true;


                ck_MalzemeYonetimi.Checked = true;
                ck_SatisveDagitim.Checked = true;
                ck_Satinalma.Checked = true;
                ck_StokYeriTakibiYapilacak.Checked = false;

                //BİRİMLERİ GETİRME
                ////////////////////////////////////////////////////////////////////////
                L_FIRMPARAMS stokKartiStandartBirimSet = FirmaLogoParametre.Where(s => s.GROUPNR == 40 && s.MODULENR == 1 && s.CODE == "ITEM_UNITSETREF").FirstOrDefault();
                int AnaBirimRef = Convert.ToInt32(stokKartiStandartBirimSet.VALUE);
                LG_UNITSETF birimSeti = islem.BirimSetiGetir(AnaBirimRef);
                List<LG_UNITSETL> AltBirimler = islem.BiriminAltBirimleriniListele(AnaBirimRef);
                grid_Birimler.DataSource = AltBirimler;
                LG_UNITSETL anabirim = AltBirimler.Where(s => s.MAINUNIT == 1).FirstOrDefault();
                lbl_BirimmiAnaBirimmi.Text = "Ana Birim";
                txt_BirimCarpani.ReadOnly = true;
                txt_AnaBirimCarpani.ReadOnly = true;
                txt_SecilenBirimKodu.Text = anabirim.CODE;
                txt_SecilenBirimAciklamasi.Text = anabirim.NAME;
                lbl_BirimKodu.Text = anabirim.CODE;
                lbl_AnabirimKodu.Text = anabirim.CODE;
                txt_BirimCarpani.Text = anabirim.CONVFACT1.ToString();
                txt_AnaBirimCarpani.Text = anabirim.CONVFACT2.ToString();
                txt_BirimKodu.Text = birimSeti.CODE;
                txt_BirimAciklama.Text = birimSeti.NAME;
                ////////////////////////////////////////////////////////////////////////
                List<LG_UNITBARCODE> barkodlar = islem.BirimVeStokBarkodGetir(Stokreferans, anabirim.LOGICALREF);
                if (barkodlar.Count != 0)
                {
                    txtBarkod.Text = barkodlar[0].BARCODE;
                }
                else
                {
                    txtBarkod.Text = null;
                }
              
            }
            else
            {
                btn_ambarparametreleri.Visible = true;
                LG_ITEMS gelenstok = islem.stokBilgi(Stokreferans);
                if (gelenstok != null)
                {
                    txtStokKodu.Text = gelenstok.CODE;
                    txt_Aciklama.Text = gelenstok.NAME;
                    txtAciklama2.Text = gelenstok.NAME3;
                    txt_aciklama3.Text = gelenstok.NAME4;
                    txtOzelKod1.Text = gelenstok.SPECODE;
                    txtOzelKod2.Text = gelenstok.SPECODE2;
                    txtOzelKod3.Text = gelenstok.SPECODE3;
                    txtOzelKod4.Text = gelenstok.SPECODE4;
                    txtOzelKod5.Text = gelenstok.SPECODE5;
                    btn_yetkikodu.Text = gelenstok.CYPHCODE;
                    txtGrupKodu.Text = gelenstok.STGRPCODE;
                    txt_UreticiKodu.Text= gelenstok.PRODUCERCODE;
                    //txtDepartmanNo.Text = gelenstok.kdv

                    LG_MARK markabilgi = islem.SeciliMarkaBilgiGetir(gelenstok.MARKREF);
                    if (markabilgi != null)
                    {
                        txtMarkRef.Text = markabilgi.LOGICALREF.ToString();
                        txtMarka.Text = markabilgi.CODE;
                        txt_markaAciklama.Text = markabilgi.DESCR;
                    }

                    ck_tevkifatUygulansin.Checked = Convert.ToBoolean(gelenstok.CANDEDUCT);
                    btn_SatisTevkifatKodu.Text = gelenstok.DEDUCTCODE;
                    btn_alisTevkifatKodu.Text = gelenstok.PURCHDEDUCTCODE;

                    txt_satisTevkifatOraniCarpan.Text = gelenstok.SALEDEDUCTPART1.ToString();
                    txt_satisTevkifatOraniBolen.Text = gelenstok.SALEDEDUCTPART2.ToString();

                    txt_alisTevkifatOraniCarpan.Text = gelenstok.PURCDEDUCTPART1.ToString();
                    txt_alisTevkifatOraniBolen.Text = gelenstok.PURCDEDUCTPART2.ToString();


                    txt_SatisKdv.Text = gelenstok.SELLVAT.ToString();
                    txt_SatinAlmaKdv.Text = gelenstok.VAT.ToString();
                    txt_IadeKdv.Text = gelenstok.RETURNVAT.ToString();
                    txt_PerakendeIadeKdv.Text = gelenstok.RETURNPRVAT.ToString();
                    txt_perakendeSatisKdv.Text = gelenstok.SELLPRVAT.ToString();

                    ck_Satinalma.Checked = Convert.ToBoolean(gelenstok.PURCHBRWS);
                    ck_SatisveDagitim.Checked = Convert.ToBoolean(gelenstok.SALESBRWS);
                    ck_MalzemeYonetimi.Checked = Convert.ToBoolean(gelenstok.MTRLBRWS);

                    ck_EkVergiKullanimYeriSatinAlma.Checked = Convert.ToBoolean(gelenstok.ADDTAXPURCHBRWS);
                    ck_EkVergiKullanimYeriSatis.Checked = Convert.ToBoolean(gelenstok.ADDTAXSALESBRWS);
                    ck_StokYeriTakibiYapilacak.Checked = Convert.ToBoolean(gelenstok.LOCTRACKING);
                    rd_izlemeYonetimiSecimi.EditValue = Convert.ToInt32(gelenstok.TRACKTYPE);


                    ck_lotBuyuklukleribolunebilir.Checked = Convert.ToBoolean(gelenstok.DIVLOTSIZE);
                    ck_lotBirimleriDagitilabilir.Checked = Convert.ToBoolean(gelenstok.DISTLOTUNITS);
                    ck_lotBirimleriBirlestirilebilir.Checked = Convert.ToBoolean(gelenstok.COMBLOTUNITS);

                    LG_UNITSETF stogunbirimSeti = islem.BirimSetiGetir(gelenstok.UNITSETREF);
                    txt_BirimKodu.Text = stogunbirimSeti.CODE;
                    txt_BirimAciklama.Text = stogunbirimSeti.NAME;

                    List<LG_UNITSETL> tumbirimler = islem.BiriminAltBirimleriniListele(gelenstok.UNITSETREF);


                    grid_Birimler.DataSource = tumbirimler;
                    LG_UNITSETL anabirim = tumbirimler.Where(s => s.MAINUNIT == 1).FirstOrDefault();
                    List<LG_UNITBARCODE> tumbarkodlar = islem.BirimVeStokBarkodGetir(gelenstok.LOGICALREF, anabirim.LOGICALREF);
                    lbl_AnabirimKodu.Text = anabirim.CODE;
                    lbl_BirimKodu.Text = anabirim.CODE;
                    txt_SecilenBirimKodu.Text = anabirim.CODE;
                    txt_SecilenBirimAciklamasi.Text = anabirim.NAME;
                    lbl_BirimmiAnaBirimmi.Text = "Ana Birim";
                    txt_BirimCarpani.ReadOnly = true;
                    txt_AnaBirimCarpani.ReadOnly = true;
                    LG_ITMUNITA stokbirimBilgileri = islem.StokBirimBilgiGetir(anabirim.LOGICALREF, Stokreferans);
                    LG_UNITBARCODE barkod = islem.BirimVeStokBarkodGetir(Stokreferans, anabirim.LOGICALREF).FirstOrDefault();
                    if (barkod != null)
                    {
                        txtBarkod.Text = barkod.BARCODE;
                        anabirim.BUTONBARKOD = barkod.BARCODE;
                    }
                    else
                    {
                        txtBarkod.Text = null;
                    }


                    if (stokbirimBilgileri != null)
                    {
                        txt_En.Text = stokbirimBilgileri.WIDTH.ToString();
                        if (Convert.ToInt32(stokbirimBilgileri.WIDTHREF) > 0)
                        {
                            btn_En.Text = islem.SeciliBirimGetir(Convert.ToInt32(stokbirimBilgileri.WIDTHREF)).CODE;
                        }

                        txt_Boy.Text = stokbirimBilgileri.LENGTH.ToString();
                        if (Convert.ToInt32(stokbirimBilgileri.LENGTHREF) > 0)
                        {
                            btn_Boy.Text = islem.SeciliBirimGetir(Convert.ToInt32(stokbirimBilgileri.LENGTHREF)).CODE;
                        }

                        txt_Yukseklik.Text = stokbirimBilgileri.HEIGHT.ToString();
                        if (Convert.ToInt32(stokbirimBilgileri.HEIGHTREF) > 0)
                        {
                            btn_Yukseklik.Text = islem.SeciliBirimGetir(Convert.ToInt32(stokbirimBilgileri.HEIGHTREF)).CODE;
                        }

                        txt_Alan.Text = stokbirimBilgileri.AREA.ToString();
                        if (Convert.ToInt32(stokbirimBilgileri.AREAREF) > 0)
                        {
                            btn_alan.Text = islem.SeciliBirimGetir(Convert.ToInt32(stokbirimBilgileri.AREAREF)).CODE;
                        }

                        txt_BrutAgirlik.Text = stokbirimBilgileri.GROSSWEIGHT.ToString();
                        if (Convert.ToInt32(stokbirimBilgileri.GROSSWGHTREF) > 0)
                        {
                            btn_BrutAgirlik.Text = islem.SeciliBirimGetir(Convert.ToInt32(stokbirimBilgileri.GROSSWGHTREF)).CODE;
                        }

                        txt_NetAgirlik.Text = stokbirimBilgileri.WEIGHT.ToString();
                        if (Convert.ToInt32(stokbirimBilgileri.WEIGHTREF) > 0)
                        {
                            btn_NetAgirlik.Text = islem.SeciliBirimGetir(Convert.ToInt32(stokbirimBilgileri.WEIGHTREF)).CODE;
                        }

                        txt_BrutHacim.Text = stokbirimBilgileri.GROSSVOLUME.ToString();
                        if (Convert.ToInt32(stokbirimBilgileri.GROSSVOLREF) > 0)
                        {
                            btn_brutHacim.Text = islem.SeciliBirimGetir(Convert.ToInt32(stokbirimBilgileri.GROSSVOLREF)).CODE;
                        }

                        txt_NetHacim.Text = stokbirimBilgileri.VOLUME_.ToString();
                        if (Convert.ToInt32(stokbirimBilgileri.VOLUMEREF) > 0)
                        {
                            btn_netHacim.Text = islem.SeciliBirimGetir(Convert.ToInt32(stokbirimBilgileri.VOLUMEREF)).CODE;
                        }


                        if (Convert.ToDouble(stokbirimBilgileri.CONVFACT2) == 0 && Convert.ToDouble(stokbirimBilgileri.CONVFACT1) == 0)
                        {
                            txt_AnaBirimCarpani.Text = "1";
                            txt_BirimCarpani.Text = "1";
                        }
                        else
                        {
                            txt_AnaBirimCarpani.Text = stokbirimBilgileri.CONVFACT2.ToString();
                            txt_BirimCarpani.Text = stokbirimBilgileri.CONVFACT1.ToString();
                        }
                    }
                   
                }
            }
        }
        private void txtStokKodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (string.IsNullOrEmpty(txtStokKodu.Text)) return;

                using (LogoContext db = new LogoContext())
                {
                    if (txtStokKodu.Text != "*")
                    {
                        string sql = $@"SELECT TOP 1 CODE [KOD] FROM LG_{ana.lk_firma.EditValue.ToString()}_ITEMS WHERE CODE LIKE '{txtStokKodu.Text}%' ORDER BY CODE DESC";
                        string kodd = db.Database.SqlQuery<string>(sql).FirstOrDefault();
                        if (!string.IsNullOrWhiteSpace(kodd))
                        {
                            txtSonStokKodu.Text = kodd;
                        }
                        else
                        {
                            txtSonStokKodu.Text = "Serbest giriş algılandı!";
                        }
                    }
                    else
                    {
                        string sql = $@"SELECT MAX(CODE) [KOD] FROM LG_{ana.lk_firma.EditValue.ToString()}_ITEMS WHERE ISNUMERIC(CODE)>0 AND ACTIVE=0";
                        string kodd = db.Database.SqlQuery<string>(sql).FirstOrDefault();
                        if (!string.IsNullOrWhiteSpace(kodd))
                        {
                            Int64 kod = 0;
                            txtSonStokKodu.Text = kodd;
                            if (!string.IsNullOrEmpty(txtSonStokKodu.Text))
                            {
                                kod = Convert.ToInt64(txtSonStokKodu.Text);
                                kod++;
                                txtSonStokKodu.Text = kod.ToString();
                            }
                            else
                            {
                                txtSonStokKodu.Text = "Serbest giriş algılandı!";
                            }
                        }
                        else
                        {
                            txtSonStokKodu.Text = "Serbest giriş algılandı!";
                        }
                    }
                }
            }
        }
        private void btn_SatisTevkifatKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ana.parametre.PROGRAMKATALOGDOSYAYOLU))
            {
                XtraMessageBox.Show("SİSTEM PARAMETRELERİNE PROGRAM KATALOG DOSYA YOLU GİRİNİZ !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            frmSatisTevkifatKodlari frm = new frmSatisTevkifatKodlari(this, ana.parametre);
            frm.tip = 2;
            frm.ShowDialog();
        }

        private void btn_alisTevkifatKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ana.parametre.PROGRAMKATALOGDOSYAYOLU))
            {
                XtraMessageBox.Show("SİSTEM PARAMETRELERİNE PROGRAM KATALOG DOSYA YOLU GİRİNİZ !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            frmSatisTevkifatKodlari frm = new frmSatisTevkifatKodlari(this, ana.parametre);
            frm.tip = 1;
            frm.ShowDialog();
        }

        private void btn_SatisTevkifatKodu_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(btn_SatisTevkifatKodu.Text))
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(ana.parametre.PROGRAMKATALOGDOSYAYOLU))
            {
                XtraMessageBox.Show("SİSTEM PARAMETRELERİNE PROGRAM KATALOG DOSYA YOLU GİRİNİZ !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SatisTevkifatKoduIslemYap();

        }
        void SatisTevkifatKoduIslemYap()
        {
            try
            {
                string dosyayolu = ana.parametre.PROGRAMKATALOGDOSYAYOLU + "\\VatDeducts.xml";
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(dosyayolu);
                DEDUCT_CODE result = new DEDUCT_CODE();
                XmlReader xmlReader = new XmlNodeReader(xmlDocument);
                XmlSerializer serializer = new XmlSerializer(typeof(LOGO_XERO.Models.LOGO_M.DosyaClaslari.DEDUCT_CODE));
                result = (LOGO_XERO.Models.LOGO_M.DosyaClaslari.DEDUCT_CODE)serializer.Deserialize(xmlReader);
                if (result.DEDUCTCODE.Count > 0)
                {
                    var row = result.DEDUCTCODE.Where(s => s.CODE == btn_SatisTevkifatKodu.Text).FirstOrDefault();
                    if (row != null)
                    {
                        string carpan = row.DEDUCTRATE.Split('/')[0];
                        string bolen = row.DEDUCTRATE.Split('/')[1];

                        txt_satisTevkifatOraniCarpan.Text = carpan;
                        txt_satisTevkifatOraniBolen.Text = bolen;
                    }
                    else
                    {
                        txt_satisTevkifatOraniCarpan.Text = "0";
                        txt_satisTevkifatOraniBolen.Text = "0";
                    }
                }
                else
                {
                    txt_satisTevkifatOraniCarpan.Text = "0";
                    txt_satisTevkifatOraniBolen.Text = "0";
                }
            }
            catch (Exception)
            {
                txt_satisTevkifatOraniCarpan.Text = "0";
                txt_satisTevkifatOraniBolen.Text = "0";
            }
        }

        void AlisTevkifatKoduIslemYap()
        {
            try
            {
                string dosyayolu = ana.parametre.PROGRAMKATALOGDOSYAYOLU + "\\VatDeducts2.xml";
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(dosyayolu);
                DEDUCT_CODE result = new DEDUCT_CODE();
                XmlReader xmlReader = new XmlNodeReader(xmlDocument);
                XmlSerializer serializer = new XmlSerializer(typeof(LOGO_XERO.Models.LOGO_M.DosyaClaslari.DEDUCT_CODE));
                result = (LOGO_XERO.Models.LOGO_M.DosyaClaslari.DEDUCT_CODE)serializer.Deserialize(xmlReader);
                if (result.DEDUCTCODE.Count > 0)
                {
                    var row = result.DEDUCTCODE.Where(s => s.CODE == btn_alisTevkifatKodu.Text).FirstOrDefault();
                    if (row != null)
                    {
                        string carpan = row.DEDUCTRATE.Split('/')[0];
                        string bolen = row.DEDUCTRATE.Split('/')[1];

                        txt_alisTevkifatOraniCarpan.Text = carpan;
                        txt_alisTevkifatOraniBolen.Text = bolen;
                    }
                    else
                    {
                        txt_alisTevkifatOraniCarpan.Text = "0";
                        txt_alisTevkifatOraniBolen.Text = "0";
                    }
                }
                else
                {
                    txt_alisTevkifatOraniCarpan.Text = "0";
                    txt_alisTevkifatOraniBolen.Text = "0";
                }
            }
            catch (Exception)
            {
                txt_alisTevkifatOraniCarpan.Text = "0";
                txt_alisTevkifatOraniBolen.Text = "0";
            }
        }

        private void btn_alisTevkifatKodu_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(btn_alisTevkifatKodu.Text))
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(ana.parametre.PROGRAMKATALOGDOSYAYOLU))
            {
                XtraMessageBox.Show("SİSTEM PARAMETRELERİNE PROGRAM KATALOG DOSYA YOLU GİRİNİZ !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            AlisTevkifatKoduIslemYap();

        }
        private void btn_SatisTevkifatKodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (string.IsNullOrEmpty(btn_SatisTevkifatKodu.Text)) return;
                SatisTevkifatKoduIslemYap();
            }
        }
        private void btn_alisTevkifatKodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (string.IsNullOrEmpty(btn_alisTevkifatKodu.Text)) return;
                AlisTevkifatKoduIslemYap();
            }
        }

        private void rd_izlemeYonetimiSecimi_EditValueChanged(object sender, EventArgs e)
        {
            if (rd_izlemeYonetimiSecimi.EditValue.ToString() == "1")
            {
                ck_lotBirimleriBirlestirilebilir.Enabled = true;
                ck_lotBirimleriDagitilabilir.Enabled = true;
                ck_lotBuyuklukleribolunebilir.Enabled = true;
            }
            else
            {
                ck_lotBirimleriBirlestirilebilir.Enabled = false;
                ck_lotBirimleriDagitilabilir.Enabled = false;
                ck_lotBuyuklukleribolunebilir.Enabled = false;
            }
        }
        private void btn_En_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmBoyutIciBirimler frm = new frmBoyutIciBirimler(this, 1, btn_En);
            frm.ShowDialog();
        }
        private void btn_Boy_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmBoyutIciBirimler frm = new frmBoyutIciBirimler(this, 1, btn_Boy);
            frm.ShowDialog();
        }
        private void btn_yukseklik_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmBoyutIciBirimler frm = new frmBoyutIciBirimler(this, 1, btn_Yukseklik);
            frm.ShowDialog();
        }
        private void btn_alan_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmBoyutIciBirimler frm = new frmBoyutIciBirimler(this, 2, btn_alan);
            frm.ShowDialog();
        }
        private void btn_netHacim_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmBoyutIciBirimler frm = new frmBoyutIciBirimler(this, 3, btn_netHacim);
            frm.ShowDialog();
        }
        private void btn_brutHacim_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmBoyutIciBirimler frm = new frmBoyutIciBirimler(this, 3, btn_brutHacim);
            frm.ShowDialog();
        }
        private void btn_NetAgirlik_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmBoyutIciBirimler frm = new frmBoyutIciBirimler(this, 4, btn_NetAgirlik);
            frm.ShowDialog();
        }
        private void btn_BrutAgirlik_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmBoyutIciBirimler frm = new frmBoyutIciBirimler(this, 4, btn_BrutAgirlik);
            frm.ShowDialog();
        }

        private void btn_yetkikodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.OzelKodListesiAc(this, 2, 2, 1, 1);
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            txt_markaAciklama.Text = "";
            txtMarkRef.Text = "0";
            txtMarka.Text = "";
        }

        private void txt_BirimCarpani_EditValueChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(txt_BirimCarpani.Text))
            //{
            //    return;
            //}
            int carpann = Convert.ToInt32(txt_BirimCarpani.Text);
            LG_UNITSETL secili = (LG_UNITSETL)gridView1.GetFocusedRow();
            if (secili != null)
            {
                secili.CONVFACT1 = string.IsNullOrWhiteSpace(carpann.ToString()) ? 0 : carpann; 
                secili.DEGISTI = 1;
            }
        }

        private void txt_AnaBirimCarpani_EditValueChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(txt_AnaBirimCarpani.Text))
            //{
            //    return;
            //}
            int carpann = Convert.ToInt32(txt_AnaBirimCarpani.Text);
            LG_UNITSETL secili = (LG_UNITSETL)gridView1.GetFocusedRow();
            if (secili != null)
            {
                secili.CONVFACT2 = string.IsNullOrWhiteSpace(carpann.ToString()) ? 0 : carpann; 
                secili.DEGISTI = 1;
            }
        }

        private void txt_En_EditValueChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(txt_En.Text))
            //{
            //    return;
            //}
            int carpann = Convert.ToInt32(txt_En.Text);
            LG_UNITSETL secili = (LG_UNITSETL)gridView1.GetFocusedRow();
            if (secili != null)
            {
                secili.WIDTH = string.IsNullOrWhiteSpace(carpann.ToString()) ? 0 : carpann; 
                secili.DEGISTI = 1;
            }
        }

        private void txt_Boy_EditValueChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(txt_Boy.Text))
            //{
            //    return;
            //}
            int carpann = Convert.ToInt32(txt_Boy.Text);
            LG_UNITSETL secili = (LG_UNITSETL)gridView1.GetFocusedRow();
            if (secili != null)
            {
                secili.LENGTH = string.IsNullOrWhiteSpace(carpann.ToString()) ? 0 : carpann; 
                secili.DEGISTI = 1;
            }
        }

        private void txt_Yukseklik_EditValueChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(txt_Yukseklik.Text))
            //{
            //    return;
            //}
            int carpann = Convert.ToInt32(txt_Yukseklik.Text);
            LG_UNITSETL secili = (LG_UNITSETL)gridView1.GetFocusedRow();
            if (secili != null)
            {
                secili.HEIGHT = string.IsNullOrWhiteSpace(carpann.ToString()) ? 0 : carpann; 
                secili.DEGISTI = 1;
            }
        }

        private void txt_Alan_EditValueChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(txt_Alan.Text))
            //{
            //    return;
            //}
            int carpann = Convert.ToInt32(txt_Alan.Text);
            LG_UNITSETL secili = (LG_UNITSETL)gridView1.GetFocusedRow();
            if (secili != null)
            {
                secili.AREA = string.IsNullOrWhiteSpace(carpann.ToString()) ? 0 : carpann; 
                secili.DEGISTI = 1;
            }
        }

        private void txt_NetHacim_EditValueChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(txt_NetHacim.Text))
            //{
            //    return;
            //}
            int carpann = Convert.ToInt32(txt_NetHacim.Text);
            LG_UNITSETL secili = (LG_UNITSETL)gridView1.GetFocusedRow();
            if (secili != null)
            {
                secili.VOLUME_ = string.IsNullOrWhiteSpace(carpann.ToString()) ? 0 : carpann; 
                secili.DEGISTI = 1;
            }
        }

        private void txt_BrutHacim_EditValueChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(txt_BrutHacim.Text))
            //{
            //    return;
            //}
            int carpann = Convert.ToInt32(txt_BrutHacim.Text);
            LG_UNITSETL secili = (LG_UNITSETL)gridView1.GetFocusedRow();
            if (secili != null)
            {
                secili.GROSSVOLUME = string.IsNullOrWhiteSpace(carpann.ToString()) ? 0 : carpann;
                secili.DEGISTI = 1;
            }
        }

        private void txt_NetAgirlik_EditValueChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(txt_NetAgirlik.Text))
            //{
            //    return;
            //}
            int carpann = Convert.ToInt32(txt_NetAgirlik.Text);
            LG_UNITSETL secili = (LG_UNITSETL)gridView1.GetFocusedRow();
            if (secili != null)
            {
                secili.WEIGHT = string.IsNullOrWhiteSpace(carpann.ToString()) ? 0 : carpann; 
                secili.DEGISTI = 1;
            }
        }

        private void txt_BrutAgirlik_EditValueChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(txt_BrutAgirlik.Text))
            //{
            //    return;
            //}
            int carpann = Convert.ToInt32(txt_BrutAgirlik.Text);
            LG_UNITSETL secili = (LG_UNITSETL)gridView1.GetFocusedRow();
            if (secili != null)
            {
                secili.GROSSWEIGHT = string.IsNullOrWhiteSpace(carpann.ToString()) ? 0 : carpann; 
                secili.DEGISTI = 1;
            }
        }

        private void txtBarkod_EditValueChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(txtBarkod.Text))
            //{
            //    return;
            //}
            string barkod = txtBarkod.Text;
            LG_UNITSETL secili = (LG_UNITSETL)gridView1.GetFocusedRow();
            if (secili != null)
            {
                secili.BUTONBARKOD = string.IsNullOrWhiteSpace(barkod) ? "" : barkod;
                secili.DEGISTI = 1;
            }
        }

        private void btn_En_EditValueChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(btn_En.Text))
            //{
            //    return;
            //}
            string BUTONEN = btn_En.Text;
            LG_UNITSETL secili = (LG_UNITSETL)gridView1.GetFocusedRow();
            if (secili != null)
            {
                secili.BUTONEN = string.IsNullOrWhiteSpace(BUTONEN) ? "":BUTONEN;
                secili.DEGISTI = 1;
            }
        }

        private void btn_Boy_EditValueChanged(object sender, EventArgs e)
        {
        //    if (string.IsNullOrWhiteSpace(btn_Boy.Text))
        //    {
        //        return;
        //    }
            string butonboy = btn_Boy.Text;
            LG_UNITSETL secili = (LG_UNITSETL)gridView1.GetFocusedRow();
            if (secili != null)
            {
                secili.BUTONBOY = string.IsNullOrWhiteSpace(butonboy) ? "" : butonboy; ;
                secili.DEGISTI = 1;
            }
        }

        private void btn_Yukseklik_EditValueChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(btn_Yukseklik.Text))
            //{
            //    return;
            //}
            string butonyukseklik = btn_Yukseklik.Text;
            LG_UNITSETL secili = (LG_UNITSETL)gridView1.GetFocusedRow();
            if (secili != null)
            {
                secili.BUTONYUKSEKLIK = string.IsNullOrWhiteSpace(butonyukseklik) ? "" : butonyukseklik;  
                secili.DEGISTI = 1;
            }
        }

        private void btn_alan_EditValueChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(btn_alan.Text))
            //{
            //    return;
            //}
            string butonalan = btn_alan.Text;
            LG_UNITSETL secili = (LG_UNITSETL)gridView1.GetFocusedRow();
            if (secili != null)
            {
                secili.BUTONALAN = string.IsNullOrWhiteSpace(butonalan) ? "" : butonalan;  
                secili.DEGISTI = 1;
            }
        }

        private void btn_netHacim_EditValueChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(btn_netHacim.Text))
            //{
            //    return;
            //}
            string butonnethacim = btn_netHacim.Text;
            LG_UNITSETL secili = (LG_UNITSETL)gridView1.GetFocusedRow();
            if (secili != null)
            {
                secili.BUTONNETHACIM = string.IsNullOrWhiteSpace(butonnethacim) ? "" : butonnethacim;
                secili.DEGISTI = 1;
            }
        }

        private void btn_brutHacim_EditValueChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(btn_brutHacim.Text))
            //{
            //    return;
            //}
            string butonbruthacim = btn_brutHacim.Text;
            LG_UNITSETL secili = (LG_UNITSETL)gridView1.GetFocusedRow();
            if (secili != null)
            {
                secili.BUTONBRUTHACIM = string.IsNullOrWhiteSpace(butonbruthacim) ? "" : butonbruthacim;
                secili.DEGISTI = 1;
            }
        }

        private void btn_NetAgirlik_EditValueChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(btn_NetAgirlik.Text))
            //{
            //    return;
            //}
            string butonnetagirlik = btn_NetAgirlik.Text;
            LG_UNITSETL secili = (LG_UNITSETL)gridView1.GetFocusedRow();
            if (secili != null)
            {
                secili.BUTONNETAGIRLIK = string.IsNullOrWhiteSpace(butonnetagirlik) ? "" : butonnetagirlik;
                secili.DEGISTI = 1;
            }
        }

        private void btn_BrutAgirlik_EditValueChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(btn_BrutAgirlik.Text))
            //{
            //    return;
            //}
            string butonbrutagirlik = btn_BrutAgirlik.Text;
            LG_UNITSETL secili = (LG_UNITSETL)gridView1.GetFocusedRow();
            if (secili != null)
            {
                secili.BUTONBRUTRAGIRLIK = string.IsNullOrWhiteSpace(butonbrutagirlik) ? "" : butonbrutagirlik;
                secili.DEGISTI = 1;
            }
        }

        private void labelControl36_Click(object sender, EventArgs e)
        {

        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        private void btn_ambarparametreleri_Click(object sender, EventArgs e)
        {
            frmAmbarParametreleri ambar = new frmAmbarParametreleri(Stokreferans);
            ambar.lbl_StokAdi.Text = txt_Aciklama.Text;
            ambar.lbl_StokKodu.Text = txtStokKodu.Text;
            ambar.ShowDialog();
        }
        public int unitlinelog = 0;

        private void txtBarkod_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmBarkodlar barkodlar = new frmBarkodlar(this);
            barkodlar.ShowDialog();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LG_UNITSETL seciliBirim = (LG_UNITSETL)gridView1.GetFocusedRow();
            if (seciliBirim != null)
            {
                unitlinelog = seciliBirim.LOGICALREF;
            }
        }

        private void grid_Birimler_Click(object sender, EventArgs e)
        {
            LG_UNITSETL seciliBirim = (LG_UNITSETL)gridView1.GetFocusedRow();
            if (seciliBirim != null)
            { 
                if (seciliBirim.MAINUNIT == 1)
                {
                    lbl_BirimmiAnaBirimmi.Text = "Ana Birim";
                    txt_BirimCarpani.ReadOnly = true;
                    txt_AnaBirimCarpani.ReadOnly = true;
                }
                else
                {
                    lbl_BirimmiAnaBirimmi.Text = "Birim";
                    txt_BirimCarpani.ReadOnly = false;
                    txt_AnaBirimCarpani.ReadOnly = false;
                }
                List<LG_UNITSETL> tumbirimler = grid_Birimler.DataSource as List<LG_UNITSETL>;
                LG_UNITSETL anabirim = tumbirimler.Where(s => s.MAINUNIT == 1).FirstOrDefault();
                lbl_AnabirimKodu.Text = anabirim.CODE;
                lbl_BirimKodu.Text = seciliBirim.CODE;
                txt_SecilenBirimKodu.Text = seciliBirim.CODE;
                txt_SecilenBirimAciklamasi.Text = seciliBirim.NAME;

                if (seciliBirim.DEGISTI == 1)
                {
                    txt_En.Text = seciliBirim.WIDTH.ToString();
                    txt_Boy.Text = seciliBirim.LENGTH.ToString();
                    txt_Yukseklik.Text = seciliBirim.HEIGHT.ToString();
                    txt_Alan.Text = seciliBirim.AREA.ToString();
                    txt_BrutAgirlik.Text = seciliBirim.GROSSWEIGHT.ToString();
                    txt_NetAgirlik.Text = seciliBirim.WEIGHT.ToString();
                    txt_BrutHacim.Text = seciliBirim.GROSSVOLUME.ToString();
                    txt_NetHacim.Text = seciliBirim.VOLUME_.ToString();
                    txt_AnaBirimCarpani.Text = seciliBirim.CONVFACT2.ToString();
                    txt_BirimCarpani.Text = seciliBirim.CONVFACT1.ToString();

                    btn_En.Text = seciliBirim.BUTONEN;
                    btn_Boy.Text = seciliBirim.BUTONBOY;
                    btn_Yukseklik.Text = seciliBirim.BUTONYUKSEKLIK;
                    btn_alan.Text = seciliBirim.BUTONALAN;
                    btn_BrutAgirlik.Text = seciliBirim.BUTONBRUTRAGIRLIK;
                    btn_NetAgirlik.Text = seciliBirim.BUTONNETAGIRLIK;
                    btn_brutHacim.Text = seciliBirim.BUTONBRUTHACIM;
                    btn_netHacim.Text = seciliBirim.BUTONNETHACIM;

                    txtBarkod.Text = seciliBirim.BUTONBARKOD;
                    ckBarkod.Checked = seciliBirim.CHECKOTOMATIKBARKOD;

                }
                else
                {
                    if (Stokreferans == 0)
                    {

                        txt_AnaBirimCarpani.Text = seciliBirim.CONVFACT2.ToString();
                        txt_BirimCarpani.Text = seciliBirim.CONVFACT1.ToString();
                        txtBarkod.Text = "";
                        txt_En.Text = "0";
                        txt_Boy.Text = "0";
                        txt_Yukseklik.Text = "0";
                        txt_Alan.Text = "0";
                        txt_BrutAgirlik.Text = "0";
                        txt_NetAgirlik.Text = "0";
                        txt_BrutHacim.Text = "0";
                        txt_NetHacim.Text = "0";
                        txt_AnaBirimCarpani.Text = "0";
                        txt_BirimCarpani.Text = "0";
                        btn_En.Text = "";
                        btn_Boy.Text = "";
                        btn_Yukseklik.Text = "";
                        btn_alan.Text = "";
                        btn_BrutAgirlik.Text = "";
                        btn_NetAgirlik.Text = "";
                        btn_brutHacim.Text = "";
                        btn_netHacim.Text = "";
                        ckBarkod.Checked = false;

                    }
                    else
                    {
                        LG_ITMUNITA stokbirimBilgileri = islem.StokBirimBilgiGetir(seciliBirim.LOGICALREF, Stokreferans);
                        if (stokbirimBilgileri != null)
                        {
                            List<LG_UNITBARCODE> barkodlar = islem.BirimVeStokBarkodGetir(Stokreferans, seciliBirim.LOGICALREF);
                            txtBarkod.Text = barkodlar.Count == 0 ? null : barkodlar.FirstOrDefault().BARCODE;
                            txt_En.Text = stokbirimBilgileri.WIDTH.ToString();
                            seciliBirim.WIDTH = stokbirimBilgileri.WIDTH;
                            txt_Boy.Text = stokbirimBilgileri.LENGTH.ToString();
                            seciliBirim.LENGTH = stokbirimBilgileri.LENGTH;
                            txt_Yukseklik.Text = stokbirimBilgileri.HEIGHT.ToString();
                            seciliBirim.HEIGHT = stokbirimBilgileri.HEIGHT;
                            txt_Alan.Text = stokbirimBilgileri.AREA.ToString();
                            seciliBirim.AREA = stokbirimBilgileri.AREA;
                            txt_BrutAgirlik.Text = stokbirimBilgileri.GROSSWEIGHT.ToString();
                            seciliBirim.GROSSWEIGHT = stokbirimBilgileri.GROSSWEIGHT;
                            txt_NetAgirlik.Text = stokbirimBilgileri.WEIGHT.ToString();
                            seciliBirim.WEIGHT = stokbirimBilgileri.WEIGHT;
                            txt_BrutHacim.Text = stokbirimBilgileri.GROSSVOLUME.ToString();
                            seciliBirim.GROSSVOLUME = stokbirimBilgileri.GROSSVOLUME;
                            txt_NetHacim.Text = stokbirimBilgileri.VOLUME_.ToString();
                            seciliBirim.VOLUME_ = stokbirimBilgileri.VOLUME_;
                            txt_AnaBirimCarpani.Text = stokbirimBilgileri.CONVFACT2.ToString();
                            seciliBirim.CONVFACT2 = stokbirimBilgileri.CONVFACT2;
                            txt_BirimCarpani.Text = stokbirimBilgileri.CONVFACT1.ToString();
                            seciliBirim.CONVFACT1 = stokbirimBilgileri.CONVFACT1;
                            ckBarkod.Checked = false;

                            if (Convert.ToInt32(stokbirimBilgileri.WIDTHREF) > 0)
                            {
                                btn_En.Text = islem.SeciliBirimGetir(Convert.ToInt32(stokbirimBilgileri.WIDTHREF)).CODE;
                                seciliBirim.BUTONEN = btn_En.Text;
                            }
                            else
                            {
                                btn_En.Text = "";
                            }

                            if (Convert.ToInt32(stokbirimBilgileri.LENGTHREF) > 0)
                            {
                                btn_Boy.Text = islem.SeciliBirimGetir(Convert.ToInt32(stokbirimBilgileri.LENGTHREF)).CODE;
                                seciliBirim.BUTONBOY = btn_Boy.Text;
                            }
                            else
                            {
                                btn_Boy.Text = "";
                            }
                            if (Convert.ToInt32(stokbirimBilgileri.HEIGHTREF) > 0)
                            {
                                btn_Yukseklik.Text = islem.SeciliBirimGetir(Convert.ToInt32(stokbirimBilgileri.HEIGHTREF)).CODE;
                                seciliBirim.BUTONYUKSEKLIK = btn_Yukseklik.Text;
                            }
                            else
                            {
                                btn_Yukseklik.Text = "";
                            }
                            if (Convert.ToInt32(stokbirimBilgileri.AREAREF) > 0)
                            {
                                btn_alan.Text = islem.SeciliBirimGetir(Convert.ToInt32(stokbirimBilgileri.AREAREF)).CODE;
                                seciliBirim.BUTONALAN = btn_alan.Text;
                            }
                            else
                            {
                                btn_alan.Text = "";
                            }
                            if (Convert.ToInt32(stokbirimBilgileri.GROSSWGHTREF) > 0)
                            {
                                btn_BrutAgirlik.Text = islem.SeciliBirimGetir(Convert.ToInt32(stokbirimBilgileri.GROSSWGHTREF)).CODE;
                                seciliBirim.BUTONBRUTRAGIRLIK = btn_BrutAgirlik.Text;
                            }
                            else
                            {
                                btn_BrutAgirlik.Text = "";
                            }
                            if (Convert.ToInt32(stokbirimBilgileri.WEIGHTREF) > 0)
                            {
                                btn_NetAgirlik.Text = islem.SeciliBirimGetir(Convert.ToInt32(stokbirimBilgileri.WEIGHTREF)).CODE;
                                seciliBirim.BUTONNETAGIRLIK = btn_NetAgirlik.Text;
                            }
                            else
                            {
                                btn_NetAgirlik.Text = "";
                            }
                            if (Convert.ToInt32(stokbirimBilgileri.GROSSVOLREF) > 0)
                            {
                                btn_brutHacim.Text = islem.SeciliBirimGetir(Convert.ToInt32(stokbirimBilgileri.GROSSVOLREF)).CODE;
                                seciliBirim.BUTONBRUTHACIM = btn_brutHacim.Text;
                            }
                            else
                            {
                                btn_brutHacim.Text = "";
                            }
                            if (Convert.ToInt32(stokbirimBilgileri.VOLUMEREF) > 0)
                            {
                                btn_netHacim.Text = islem.SeciliBirimGetir(Convert.ToInt32(stokbirimBilgileri.VOLUMEREF)).CODE;
                                seciliBirim.BUTONNETHACIM = btn_netHacim.Text;
                            }
                            else
                            {
                                btn_netHacim.Text = "";
                            }
                        }
                    }
                }
                if (txt_AnaBirimCarpani.Text == "0")
                {
                    txt_AnaBirimCarpani.Text = "1";
                }
                if (txt_BirimCarpani.Text == "0")
                {
                    txt_BirimCarpani.Text = "1";
                }

            }
        }
    }
}