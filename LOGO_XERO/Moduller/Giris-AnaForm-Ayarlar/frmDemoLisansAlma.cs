using ApiDonenKayitId;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Import.Doc;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using LOGO_XERO.Models.LOGO_M;
using LOGO_XERO.Models.LOGO_XERO_M;
using Models.LisanslamaModelleri;
using Newtonsoft.Json;
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

namespace LOGO_XERO.Moduller.Giris_AnaForm_Ayarlar
{
    public partial class frmDemoLisansAlma : DevExpress.XtraEditors.XtraForm
    {

        List<LOGO_XERO_LISANSLAR> lisanslar = new List<LOGO_XERO_LISANSLAR>();
        EsbiContext clas = new EsbiContext();
        Lisans lisans = new Lisans();
        public string demoLisansNumarasi = "";
        frmLisanslar _frmLisanslar;
        public int almamiYenilemmi = 0;

        IlkTabloIslemler islem = new IlkTabloIslemler();
        public frmDemoLisansAlma(frmLisanslar frmLisanslar)
        {
            InitializeComponent();
            _frmLisanslar = frmLisanslar;
        }

        public void LisansAlYenile(int almamiYenilememi)
        {

            //0 alma 1 yenileme
            int modülTipi = 0;
            int modülStokReferans = 0;
            if (ck_LisansModülü.SelectedIndex == 1)
            {
                modülTipi = 3;
            }
            else if (ck_LisansModülü.SelectedIndex == 2)
            {
                modülTipi = 1;
            }
            else if (ck_LisansModülü.SelectedIndex == 3)
            {
                modülTipi = 2;
            }
            else if (ck_LisansModülü.SelectedIndex == 4)
            {
                modülTipi = 4;
            }
            if (modülTipi == 0)
            {
                XtraMessageBox.Show("Lisans Modülü Seçiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (lisanslar.Where(s => s.MODUL == modülTipi && s.VAR == 1).Count() > 0)
            {
                if (almamiYenilemmi == 1)
                {

                }
                else
                {
                    XtraMessageBox.Show("Önceden Alınmış Lisansınız Mevcuttur ! Bu Modül İçin Lisans Yenile Tarafından İşleminizi Gerçekleştirin !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if (lisanslar.Where(s => s.MODUL == modülTipi && s.VAR == 1).Count() == 0)
            {
                if (almamiYenilemmi == 1)
                {
                    XtraMessageBox.Show("Önceden Alınmış Lisansınız Yoktur ! Bu Modül İçin Lisans Al Tarafından İşleminizi Gerçekleştirin !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {

                }
            }
            if (almamiYenilemmi == 0)
            {
                if (modülTipi == 4 || modülTipi == 3)
                {
                    modülStokReferans = 16424;
                }
                else if (modülTipi == 2)
                {
                    modülStokReferans = 16430;
                }
                else if (modülTipi == 1)
                {
                    modülStokReferans = 16428;
                }
            }
            else
            {
                if (modülTipi == 4 || modülTipi == 3)
                {
                    modülStokReferans = 16425;
                }
                else if (modülTipi == 2)
                {
                    modülStokReferans = 16431;
                }
                else if (modülTipi == 1)
                {
                    modülStokReferans = 16429;
                }
            }


            if (modülStokReferans == 0)
            {
                XtraMessageBox.Show("Lisans Stoğuna Erişilemedi ! İşlem İle İlgili '+90 (264) 777 1 666' Numarasıyla İrtibata Geçiniz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            List<L_CAPIFIRM> firm = islem.DataSetlifirmalistesi();
            L_CAPIFIRM lisansliFirma = firm.Where(s => s.TAXNR == txt_VergiKimlikNo.Text).FirstOrDefault();
            if (lisansliFirma == null)
            {
                XtraMessageBox.Show("Girilen Vergi Kimlik Numarasına Ait Firmanız Bulunmamaktadır ! Demo Lisansı Alamazsınız !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_VergiKimlikNo.Focus();
                return;
            }

            string demolisans = "";
            try
            {
                LisansStokModeli.Root stok = new LisansStokModeli.Root();
                var client = new RestClient("https://lisans.esbi.com.tr/lisans/api/Logo/StokBilgiGetir?stokReferansBilgisi=" + modülStokReferans);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                IRestResponse response = client.Execute(request) as RestResponse;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    stok = JsonConvert.DeserializeObject<LisansStokModeli.Root>(response.Content);
                    if (stok.stokkarT_FIYAT_M == null)
                    {
                        MessageBox.Show("Hata Oluştu !");
                        return;
                    }
                    else
                    {
                        if (stok.stokkarT_FIYAT_M.logicalref == 0)
                        {
                            MessageBox.Show("Hata Oluştu !");
                            return;
                        }
                        else
                        {
                            if (stok.stokkarT_FIYAT_M.fiyat == 0)
                            {
                                if (modülTipi != 4)
                                {
                                    MessageBox.Show(stok.stokkarT_FIYAT_M.name + " Ürününün Lisans Fiyat İşlemi İle İlgili '+90 (264) 777 1 666' Numarasıyla İrtibata Geçiniz !");
                                    return;
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Hata Oluştu !");
                    return;
                }

                ESBI_PROGRAM_LISANSLAMA_ODEME kay = new ESBI_PROGRAM_LISANSLAMA_ODEME();
                kay.ANAHTAR = txt_VergiKimlikNo.Text;
                kay.FIRMATCVKN = txt_VergiKimlikNo.Text;
                kay.FIRMAUNVANI = txt_CariUnvani.Text;
                kay.GUID = Guid.NewGuid().ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();

                if (modülTipi == 4)
                {
                    demolisans = lisans.SifreleAES(txt_VergiKimlikNo.Text + "+" + DateTime.Now.ToString("yyyy-MM-dd") + "+" + "4", "HST");
                    kay.LISANSNUMARASI = demolisans;
                    kay.ODEMEALINDI = 1;
                    kay.ODEMEALINMAZAMANI = DateTime.Now;
                    kay.LISANSUCRETI = 0;

                }
                else
                {
                    kay.LISANSNUMARASI = "";
                    kay.ODEMEALINDI = 0;
                    kay.ODEMEALINMAZAMANI = null;
                    kay.LISANSUCRETI = stok.stokkarT_FIYAT_M.fiyat;

                }
                kay.DEMO = modülTipi;
                kay.TARIH = DateTime.Now;
                kay.LISANSSTOKADI = stok.stokkarT_FIYAT_M.name;
                kay.LISANSSTOKREFERANS = stok.stokkarT_FIYAT_M.logicalref;

                var client1 = new RestClient("https://lisans.esbi.com.tr/lisans/api/Logo/LisansKayitEt");
                var request1 = new RestRequest(Method.POST);
                request1.AddHeader("Content-Type", "application/json");
                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(kay);
                request1.AddHeader("Content-Type", "application/json");
                request1.AddParameter("application/json", jsonString, ParameterType.RequestBody);
                IRestResponse response1 = client1.Execute(request1) as RestResponse;
                if (response1.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    ApiDonenKayitId.Root sonucc = JsonConvert.DeserializeObject<ApiDonenKayitId.Root>(response1.Content);
                    if (sonucc.kayitId == 0)
                    {
                        XtraMessageBox.Show("Hata Oluştu !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        simpleButton1.Visible = false;
                        if (modülTipi == 4)
                        {
                            XtraMessageBox.Show("Demo Lisans Alımınız Başarılıdır !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txt_DemoLisansi.Text = demolisans;
                            if (_frmLisanslar != null)
                            {
                                _frmLisanslar.LisansNumarasi = demolisans;
                                _frmLisanslar.Modül = modülTipi;
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Ödeme İşleminden Sonra Aldığınız Lisans Numarasını İlgili Modüle Yazıp Kaydete Basınız !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            string guidNumarasi = kay.GUID.ToString();
                            string target = "https://lisans.esbi.com.tr/lisans-al/" + guidNumarasi;
                            System.Diagnostics.Process.Start(target);

                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("Hata Oluştu !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lisans Alımı Başarısızdır !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_VergiKimlikNo.Text))
            {
                XtraMessageBox.Show("Vergi Kimlik Numarası Girilmeden Demo Lisansı Alamazsınız !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_VergiKimlikNo.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txt_CariUnvani.Text))
            {
                XtraMessageBox.Show("Cari Ünvanı Girilmeden Demo Lisansı Alamazsınız !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_CariUnvani.Focus();
                return;
            }
            if (ck_LisansModülü.EditValue == null)
            {
                XtraMessageBox.Show("Lisans Modülü Seçiniz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ck_LisansModülü.Focus();
                return;
            }
            if (ck_LisansModülü.EditValue.ToString() == "0")
            {
                XtraMessageBox.Show("Lisans Modülü Seçiniz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ck_LisansModülü.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(ck_LisansModülü.Text))
            {
                XtraMessageBox.Show("Lisans Modülü Seçiniz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ck_LisansModülü.Focus();
                return;
            }

            LisansAlYenile(almamiYenilemmi);


        }

        List<L_CAPIFIRM> firmalistesi = new List<L_CAPIFIRM>();
        private void frmDemoLisansAlma_Load(object sender, EventArgs e)
        {
            ck_LisansModülü.EditValue = null;
            firmalistesi = islem.DataSetlifirmalistesi();
            frmAnaForm ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            if (ana != null)
            {
                int nrr = Convert.ToInt32(ana.lk_firma.EditValue);
                L_CAPIFIRM seciliFirma = firmalistesi.Where(s => s.NR == nrr).FirstOrDefault();
                if (seciliFirma != null)
                {
                    txt_CariUnvani.Text = seciliFirma.NAME;
                    txt_VergiKimlikNo.Text = seciliFirma.TAXNR;
                    txt_CariUnvani.Enabled = false;
                    txt_VergiKimlikNo.Enabled = false;
                }
            }
            lisanslar = islem.DataSetliLisanslistesi();
            if (lisanslar.Where(s => s.MODUL == 4 && s.VAR == 1).Count() > 0)
            {
                ck_LisansModülü.Properties.Items.Remove("Demo Lisansı (6 Aylık)");
            }
        }
    }
}