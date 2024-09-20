using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using LOGO_XERO.Models.GenelKullanim;
using LOGO_XERO.Models.LOGO_M;
using LOGO_XERO.Models.LOGO_XERO_M;
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

namespace LOGO_XERO.Moduller.GenelListeler
{
    public partial class frmSevkiyatAdresiEkleme : DevExpress.XtraEditors.XtraForm
    {
        LOGO_XERO_PARAMETRELER parametre;
        Islemler islem = new Islemler();
        public string cariKod = "";
        public bool duzenle;
        public int logicalref;
        string firma, donem;
        public int carilogicalref = 0;
        public frmSevkiyatAdresiEkleme()
        {
            InitializeComponent();
            frmAnaForm anafrm = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            firma = Convert.ToInt32(anafrm.lk_firma.EditValue).ToString("000");
            donem = Convert.ToInt32(anafrm.lk_donem.EditValue).ToString("00");
            parametre = anafrm.parametre;
        }
        private void frmSevkiyatAdresiEkleme_Load(object sender, EventArgs e)
        {
            using (LogoContext db = new LogoContext())
            {
                ckStatu.Properties.Items.Clear();
                ckStatu.Properties.Items.Add("Kullanımda");
                ckStatu.Properties.Items.Add("Kullanım Dışı");
                ckStatu.SelectedIndex = 0;

                tmBas1.EditValue = "08:00:00";
                tmBit1.EditValue = "17:55:00";
                tmBas2.EditValue = "00:00:00";
                tmBit2.EditValue = "00:00:00";
                tmBas3.EditValue = "00:00:00";
                tmBit3.EditValue = "00:00:00";
                txTcNo.Enabled = false;
                txAd.Enabled = false;
                txSoyad.Enabled = false;
                ckTicIslem.Properties.DataSource = islem.TicariIslemGruplariGetir();
                ckTicIslem.Properties.ValueMember = "GCODE";
                ckTicIslem.Properties.DisplayMember = "GCODE";
                if (duzenle)
                {
                    DuzenleMethodu();
                }
            }
        }
        void DuzenleMethodu()
        {
            LG_SHIPINFO bilgi = new LG_SHIPINFO();
            using (LogoContext db = new LogoContext())
            {
                bilgi = db.LG_SHIPINFO.Where(s => s.LOGICALREF == logicalref).FirstOrDefault();
            }


            txKod.Text = bilgi.CODE;
            txAciklama.Text = bilgi.NAME;
            txUnvan.Text = bilgi.TITLE;
            txAdres1.Text = bilgi.ADDR1;
            txAdres2.Text = bilgi.ADDR2;
            btn_ozelkod.Text = bilgi.SPECODE;
            btn_yetkikodu.Text = bilgi.CYPHCODE;
            txMahKod.Text = bilgi.DISTRICTCODE;
            txMah1.Text = bilgi.DISTRICT;
            txIlce1.Text = bilgi.TOWN;
            txIlceKod.Text = bilgi.TOWNCODE;
            txIlKod.Text = bilgi.CITYCODE;
            txIl1.Text = bilgi.CITY;
            txUlke1.Text = bilgi.COUNTRY;
            txUlkeKod.Text = bilgi.COUNTRYCODE;
            txPosta.Text = bilgi.POSTCODE.ToString();
            txTel1.Text = bilgi.TELNRS1;
            txTel2.Text = bilgi.TELNRS2;
            txFax.Text = bilgi.FAXNR;
            txVergiNo.Text = bilgi.TAXNR;
            txVergiDairesi.Text = bilgi.TAXOFFICE;
            ckTicIslem.EditValue = bilgi.TRADINGGRP;
            txKdvNo.Text = bilgi.VATNR.ToString();
            txIlgili.Text = bilgi.INCHANGE.ToString();
            txBoylam.Text = bilgi.LONGITUDE.ToString();
            txEnlem.Text = bilgi.LATITUTE.ToString();
            txIlID.Text = bilgi.CITYID.ToString();
            txIlceID.Text = bilgi.TOWNID;
            chkOndeger.Checked = Convert.ToBoolean(bilgi.DEFAULTFLG);
            chkSahsi.Checked = Convert.ToBoolean(bilgi.ISPERSCOMP);

            tmBas1.EditValue = timeReConvert(Convert.ToInt32(bilgi.SHIPBEGTIME1));
            tmBas2.EditValue = timeReConvert(Convert.ToInt32(bilgi.SHIPBEGTIME2));
            tmBas3.EditValue = timeReConvert(Convert.ToInt32(bilgi.SHIPBEGTIME3));

            tmBit1.EditValue = timeReConvert(Convert.ToInt32(bilgi.SHIPENDTIME1));
            tmBit2.EditValue = timeReConvert(Convert.ToInt32(bilgi.SHIPENDTIME2));
            tmBit3.EditValue = timeReConvert(Convert.ToInt32(bilgi.SHIPENDTIME3));

            ckStatu.SelectedIndex = Convert.ToInt16(bilgi.ACTIVE);//0 ise aktif
            txEposta.Text = bilgi.EMAILADDR;


            if (chkSahsi.Checked)
            {
                txTcNo.Text = bilgi.TCKNO;
                txAd.Text = bilgi.SNAME;
                txSoyad.Text = bilgi.SSURNAME;
            }

        }
        private void btnVazgec_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void chkOndeger_CheckedChanged(object sender, EventArgs e)
        {
            using (LogoContext db = new LogoContext())
            {
                if (chkOndeger.Checked)
                {
                    List<LG_SHIPINFO> varmi = db.LG_SHIPINFO.Where(s => s.CLIENTREF == carilogicalref && s.DEFAULTFLG == 1).ToList();
                    if (varmi != null)
                    {
                        if (varmi.Count > 0)
                        {
                            if (varmi.Where(s => s.LOGICALREF != logicalref).Count() > 0)
                            {
                                MessageBox.Show("Öndeğer Olarak Kayıtlı Adres Zaten Mevcut!");
                                chkOndeger.Checked = false;
                                return;
                            }
                            else
                            {
                                chkOndeger.Checked = true;
                            }
                        }
                    }
                }
            }
        }
        private void chkSahsi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSahsi.Checked)
            {
                txTcNo.Enabled = true;
                txAd.Enabled = true;
                txSoyad.Enabled = true;
            }
            else
            {
                txTcNo.Enabled = false;
                txAd.Enabled = false;
                txSoyad.Enabled = false;
            }
        }
        int timeConvert(string time)
        {
            DateTime zaman = Convert.ToDateTime(time);
            int timee = zaman.Millisecond + 256 * zaman.Second + 65536 * zaman.Minute + 16777216 * zaman.Hour;
            return timee;
        }
        string timeReConvert(int time)
        {
            if (time > 0)
            {
                string HH, mm, ss;
                HH = ((time - (time % 65536)) / 65536 / 256).ToString("00");
                mm = ((time - (time % 65536)) / 65536 - ((time - (time % 65536)) / 65536 / 256) * 256).ToString("00");
                ss = (((time % 65536) - ((time % 65536) % 256)) / 256).ToString("00");
                string timee1 = HH + ":" + mm + ":" + ss;
                return timee1;
            }
            else
            {
                return "00:00:00";
            }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txKod.Text))
            {
                MessageBox.Show("Kod Alanı Boş Bırakılamaz !");
                return;

            }
            if (string.IsNullOrWhiteSpace(txAciklama.Text))
            {
                MessageBox.Show("Açıklama Alanı Boş Bırakılamaz !");
                return;

            }
            if (string.IsNullOrWhiteSpace(txUnvan.Text))
            {
                MessageBox.Show("Ünvan Alanı Boş Bırakılamaz !");
                return;

            }
            if (chkSahsi.Checked)
            {
                if (string.IsNullOrWhiteSpace(txTcNo.Text))
                {
                    MessageBox.Show("Tc No. Boş Bırakılamaz !");
                    return;

                }
                if (string.IsNullOrWhiteSpace(txAd.Text))
                {
                    MessageBox.Show("Ad Boş Bırakılamaz !");
                    return;

                }
                if (string.IsNullOrWhiteSpace(txSoyad.Text))
                {
                    MessageBox.Show("Soyad Boş Bırakılamaz !");
                    return;

                }
            }
            panelControl1.Enabled = false;
            panelControl2.Enabled = false;
            xtraTabControl1.Enabled = false;
            SevkKaydet();
        }
        private void frmSevkiyatAdresiEkleme_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.F2)
            {
                btnKaydet_Click(sender, e);
            }
        }
        private void btn_ozelkod_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.OzelKodListesiAc(this, 1, 1, 166,0);
        }
        private void btn_yetkikodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.OzelKodListesiAc(this, 2, 2, 166,0);
        }
        public void SevkKaydet()
        {
            Logo.CariSevk.Root sevk = new Logo.CariSevk.Root();
            sevk.ARP_CODE = cariKod;
            sevk.CLIENTREF = carilogicalref;
            sevk.AUTH_CODE = btn_yetkikodu.Text;
            sevk.AUXIL_CODE = btn_ozelkod.Text;
            sevk.CODE = txKod.Text;
            sevk.DESCRIPTION = txAciklama.Text;
            sevk.TITLE = txUnvan.Text;
            sevk.ADDRESS1 = txAdres1.Text;
            sevk.ADDRESS2 = txAdres2.Text;
            sevk.DISTRICT_CODE = txMahKod.Text;
            sevk.DISTRICT = txMah1.Text;
            sevk.TOWN = txIlce1.Text;
            sevk.TOWN_CODE = txIlceKod.Text;
            sevk.CITY = txIl1.Text;
            sevk.CITY_CODE = txIlKod.Text;
            sevk.COUNTRY = txUlke1.Text;
            sevk.COUNTRY_CODE = txUlkeKod.Text;
            sevk.POSTAL_CODE = txPosta.Text;
            sevk.TELEPHONE1 = txTel1.Text;
            sevk.TELEPHONE2 = txTel2.Text;
            sevk.FAX = txFax.Text;
            sevk.TAX_NR = txVergiNo.Text;
            sevk.TAX_OFFICE = txVergiDairesi.Text;
            if (ckTicIslem.EditValue != null)
            {
                sevk.TRADING_GRP = ckTicIslem.EditValue.ToString();
            }
            sevk.VAT_NR = txKdvNo.Text;
            if (!duzenle)
            {
                sevk.DATE_CREATED = DateTime.Now;
                sevk.HOUR_CREATED = DateTime.Now.Hour;
                sevk.MIN_CREATED = DateTime.Now.Minute;
                sevk.SEC_CREATED = DateTime.Now.Second;
            }
            sevk.XBUFS = txVergiNo.Text;
            sevk.INCHANGE = txIlgili.Text;//ilgili
            sevk.LONGITUDE = txBoylam.Text;
            sevk.LATITUDE = txEnlem.Text;
            sevk.CITY_ID = txIlID.Text;
            sevk.TOWN_ID = txIlceID.Text;
            sevk.DEFAULT_FLAG = chkOndeger.Checked;
            sevk.PERSCOMPANY = chkSahsi.Checked;
            sevk.SHIP_BEG_TIME1 = timeConvert(tmBas1.EditValue.ToString());
            sevk.SHIP_BEG_TIME2 = timeConvert(tmBas2.EditValue.ToString());
            sevk.SHIP_BEG_TIME3 = timeConvert(tmBas3.EditValue.ToString());
            sevk.SHIP_END_TIME1 = timeConvert(tmBit1.EditValue.ToString());
            sevk.SHIP_END_TIME2 = timeConvert(tmBit2.EditValue.ToString());
            sevk.SHIP_END_TIME3 = timeConvert(tmBit3.EditValue.ToString());

            if (ckStatu.EditValue.ToString() == "Kullanımda")
            {
                sevk.RECORD_STATUS = 0;
            }
            if (ckStatu.EditValue.ToString() == "Kullanım Dışı")
            {
                sevk.RECORD_STATUS = 1;
            }
            sevk.EMAIL_ADDR = txEposta.Text;

            if (chkSahsi.Checked)
            {
                sevk.TCKNO = txTcNo.Text;
                sevk.NAME = txAd.Text;
                sevk.SURNAME = txSoyad.Text;
            }

            if (parametre.LOGOBAGLANTISECIMI == 1)
            {
                if (string.IsNullOrWhiteSpace(parametre.RESTSERVISURL) || string.IsNullOrWhiteSpace(parametre.RESTSERVISKULLANICIADI) || string.IsNullOrWhiteSpace(parametre.RESTSERVISSIFRE))
                {
                    XtraMessageBox.Show("Rest Servis Ayarları Eksik ! Sistem Parametrelerinden Rest Servis Alanlarını Girip Programı Yeniden Başlatınız !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ErisilebilirlikAc();
                    return;
                }
            v:

                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", $@"Bearer {parametre.RESTSERVISTOKEN}");
                request.AddHeader("Content-Type", "application/json");

                var request1 = new RestRequest(Method.PUT);
                request1.AddHeader("Authorization", $@"Bearer {parametre.RESTSERVISTOKEN}");
                request1.AddHeader("Content-Type", "application/json");
                if (!duzenle)
                {
                    var client1 = new RestClient(parametre.RESTSERVISURL + "/api/v1/ArpShipmentLocations");
                    client1.Timeout = -1;
                    string jbody = Newtonsoft.Json.JsonConvert.SerializeObject(sevk);
                    request.AddParameter("application/json", jbody, ParameterType.RequestBody);
                    try
                    {

                        IRestResponse response = client1.Execute(request);
                        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        {
                            islem.tokenAl(parametre, firma);
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
                            XtraMessageBox.Show("Ekleme Başarısız ! Hata : " + mesaj, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            XtraMessageBox.Show("Sevkiyat Adresi Eklendi !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        if (response.StatusCode == 0)
                        {
                            XtraMessageBox.Show("Hata : " + response.ErrorMessage, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Hata : " + ex.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    var client1 = new RestClient(parametre.RESTSERVISURL + "/api/v1/ArpShipmentLocations/" + logicalref);
                    client1.Timeout = -1;
                    string jbody = Newtonsoft.Json.JsonConvert.SerializeObject(sevk);
                    request1.AddParameter("application/json", jbody, ParameterType.RequestBody);
                    try
                    {

                        IRestResponse response = client1.Execute(request1);
                        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        {
                            islem.tokenAl(parametre, firma);
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
                            XtraMessageBox.Show("Düzenleme Başarısız ! Hata : " + mesaj, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            XtraMessageBox.Show("Sevkiyat Adresi Güncellendi !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        if (response.StatusCode == 0)
                        {
                            XtraMessageBox.Show("Hata : " + response.ErrorMessage, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Hata : " + ex.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (parametre.LOGOBAGLANTISECIMI == 2)
            {
                if (string.IsNullOrWhiteSpace(parametre.OBJEKULLANICIADI) || string.IsNullOrWhiteSpace(parametre.OBJEKULLANICISIFRE))
                {
                    XtraMessageBox.Show("Obje Kullanıcı Adı Şifre Boş ! Sistem Parametrelerinden Logo Obje Kullanıcı Adı-Şifre Bilgilerini Girip Programı Yeniden Başlatınız !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ErisilebilirlikAc();
                    return;
                }
                LogoObjeAktar obj = new LogoObjeAktar(parametre);
                if (!duzenle)
                {
                    string[] sonuc = obj.SevkAdesiEkle(sevk);
                    if (sonuc[0] == "true")
                    {
                        XtraMessageBox.Show("Sevkiyat Adresi Oluşturuldu !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("Hata : " + sonuc[0].ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    sevk.INTERNAL_REFERENCE = logicalref;
                    string[] sonuc = obj.SevkAdesiDuzenle(sevk);
                    if (sonuc[0] == "true")
                    {
                        XtraMessageBox.Show("Sevkiyat Adresi Güncellendi !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("Hata : " + sonuc[0].ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Logo Bağlantı Ayarı Yapılmamış ! Sistem Parametrelerinden Logo Bağlantı Seçimi Ayarını Düzenleyiniz ! Programı Tekrar Başlatınız ! ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ErisilebilirlikAc();
                return;
            }

            ErisilebilirlikAc();

        }
        void ErisilebilirlikAc()
        {
            panelControl1.Enabled = true;
            panelControl2.Enabled = true;
            xtraTabControl1.Enabled = true;
        }
    }
}