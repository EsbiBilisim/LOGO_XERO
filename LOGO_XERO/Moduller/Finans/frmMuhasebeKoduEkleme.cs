using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using LOGO_XERO.Models.LOGO_M;
using LOGO_XERO.Models.LogoObje;
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

namespace LOGO_XERO.Moduller.Finans
{
    public partial class frmMuhasebeKoduEkleme : DevExpress.XtraEditors.XtraForm
    {
        string firma, donem;
        frmAnaForm ana;
        public int MuhasebeReferans = 0;
        Islemler islem = new Islemler();
        LogoObjeAktar obj;
        public frmMuhasebeKoduEkleme()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            firma = ana.lk_firma.EditValue.ToString();
            donem = ana.lk_donem.EditValue.ToString();
            obj = new LogoObjeAktar(ana.parametre);
        }

        private void frmMuhasebeKoduEkleme_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btn_Vazgec_Click(sender, e);
            }
            if (e.KeyCode == Keys.F2)
            {
                btn_Kaydet_Click(sender, e);
            }
        }

        private void btn_Vazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Ozelkod_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.OzelKodListesiAc(this, 1, 1, 35, 1);
        }

        private void btn_yetkiKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.OzelKodListesiAc(this, 2, 2, 35, 0);
        }

        private void btn_Ozelkod2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.OzelKodListesiAc(this, 1, 1, 35, 2);
        }

        private void btn_Ozelkod3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.OzelKodListesiAc(this, 1, 1, 35, 3);
        }

        private void btn_Ozelkod4_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.OzelKodListesiAc(this, 1, 1, 35, 4);
        }

        private void btn_Ozelkod5_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.OzelKodListesiAc(this, 1, 1, 35, 5);
        }

        private void frmMuhasebeKoduEkleme_Load(object sender, EventArgs e)
        {
            if (MuhasebeReferans > 0)
            {
                LG_EMUHACC kay = islem.SeciliCariHesapPlaniGetir(MuhasebeReferans);
                if (kay != null)
                {
                    txt_Kodu.Text = kay.CODE;
                    txt_Aciklamasi.Text = kay.DEFINITION_;
                    txt_Aciklamasi2.Text = kay.EXTNAME;
                    btn_Ozelkod.Text = kay.SPECODE;
                    btn_Ozelkod2.Text = kay.SPECODE2;
                    btn_Ozelkod3.Text = kay.SPECODE3;
                    btn_Ozelkod4.Text = kay.SPECODE4;
                    btn_Ozelkod5.Text = kay.SPECODE5;
                    btn_yetkiKodu.Text = kay.CYPHCODE;
                    //rd_HesapTuru.EditValue = kay.ACCTYPE;
                    rd_HesapTuru.SelectedIndex = Convert.ToInt32(kay.ACCTYPE);

                    int tip = Convert.ToInt32(kay.MONETARY);
                    if (tip == 2)
                    {
                        cm_HesapTipi.SelectedIndex = 0;
                    }
                    else if (cm_HesapTipi.SelectedIndex == 1)
                    {
                        cm_HesapTipi.SelectedIndex = 2;
                    }
                    else
                    {
                        cm_HesapTipi.SelectedIndex = 1;
                    }
                }
            }
            else
            {
                cm_HesapTipi.SelectedIndex = 0;
                rd_HesapTuru.SelectedIndex = 2;
            }
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            LG_EMUHACC varmi = islem.CariHesapPLaniKontrol(txt_Kodu.Text);

            if (varmi != null)
            {
                if (varmi.LOGICALREF != MuhasebeReferans)
                {
                    XtraMessageBox.Show("Aynı Kodlu Bir Kayıt Daha Var !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(txt_Kodu.Text))
            {
                XtraMessageBox.Show("Kodu Olmadan Kayıt Ekleyemezsiniz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_Kodu.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txt_Aciklamasi.Text))
            {
                XtraMessageBox.Show("Açıklama Olmadan Kayıt Ekleyemezsiniz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_Aciklamasi.Focus();
                return;
            }


            Logo.MuhasebeHesapKarti.Root muhasebe = new Logo.MuhasebeHesapKarti.Root();
            muhasebe.INTERNAL_REFERENCE = MuhasebeReferans;
            muhasebe.CODE = txt_Kodu.Text;
            muhasebe.DESCRIPTION = txt_Aciklamasi.Text;
            muhasebe.DESCRIPTION2 = txt_Aciklamasi2.Text;
            muhasebe.AUXIL_CODE = btn_Ozelkod.Text;
            muhasebe.AUXIL_CODE2 = btn_Ozelkod2.Text;
            muhasebe.AUXIL_CODE3 = btn_Ozelkod3.Text;
            muhasebe.AUXIL_CODE4 = btn_Ozelkod4.Text;
            muhasebe.AUXIL_CODE5 = btn_Ozelkod5.Text;
            muhasebe.AUTH_CODE = btn_yetkiKodu.Text;
            muhasebe.RECORD_STATUS = 2;
            muhasebe.ACCOUNT_TYPE = Convert.ToInt32(rd_HesapTuru.EditValue.ToString());  //hesap türü  0,1,2

            int tip = 0;
            if (cm_HesapTipi.SelectedIndex == 0)
            {
                tip = 2;
            }
            else if (cm_HesapTipi.SelectedIndex == 1)
            {
                tip = 0;
            }
            else
            {
                tip = 1;
            }

            muhasebe.ACCOUNT_CHAR = tip;//hesap tipi   parasal:2 parasal olmayan borç 1 parasal olmayan alacak2

            if (MuhasebeReferans == 0)
            {
                muhasebe.DATE_CREATED = DateTime.Now;
                muhasebe.HOUR_CREATED = DateTime.Now.Hour;
                muhasebe.MIN_CREATED = DateTime.Now.Minute;
                muhasebe.SEC_CREATED = DateTime.Now.Second;
            }
            else
            {
                muhasebe.DATE_MODIFIED = DateTime.Now;
                muhasebe.HOUR_MODIFIED = DateTime.Now.Hour;
                muhasebe.MIN_MODIFIED = DateTime.Now.Minute;
                muhasebe.SEC_MODIFIED = DateTime.Now.Second;
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
                    var client1 = new RestClient(ana.parametre.RESTSERVISURL + "/api/v1/GLAccounts");
                    if (MuhasebeReferans > 0)
                    {
                        client1 = new RestClient(ana.parametre.RESTSERVISURL + "/api/v1/GLAccounts/" + MuhasebeReferans);
                        request = new RestRequest(RestSharp.Method.PUT);
                    }
                    client1.Timeout = -1;
                    string jbody = Newtonsoft.Json.JsonConvert.SerializeObject(muhasebe);
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

                            int cariref = Convert.ToInt32(sonuc1.INTERNAL_REFERENCE);
                            MuhasebeReferans = cariref;
                            XtraMessageBox.Show("İşlem Başarılı !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);


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
                if (MuhasebeReferans > 0)
                {
                    sonuc = obje.CariMuhasebeKoduDuzenle(muhasebe);
                }
                else
                {
                    sonuc = obje.CariMuhasebeKoduEkle(muhasebe);
                }
                if (sonuc[0] == "true")
                {
                    int cariref = Convert.ToInt32(sonuc[1]);
                    MuhasebeReferans = cariref;
                    XtraMessageBox.Show("İşlem Başarılı !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}