using DevExpress.XtraEditors;
using System;
using LOGO_XERO.LogoServis;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOGO_XERO.Models.LOGO_XERO_M;

namespace LOGO_XERO.Models.CariSorgulama
{

    public class EfaturaKontrol
    {
        public EfaturaKontrol()
        {
        
        }
        public string firmano = "";
        public string donemno = "";
        LOGO_XERO_PARAMETRELER parametre;
        SQLConnection clas = new SQLConnection();
        //web service url =https://pb.elogo.com.tr/PostboxService.svc

        PostBoxServiceEndpoint srv = new PostBoxServiceEndpoint();
        string sessionId;
        public int durum;
        public bool baglan()
        {
            using (LogoContext db = new LogoContext())
            {
                parametre = db.LOGO_XERO_PARAMETRELER.Where(s => s.FIRMANO == firmano && s.DONEMNO == donemno).FirstOrDefault();
            }
            string kAdi = parametre.GIBUSERNAME;
            string sifre =parametre.GIBPASSWORD;

            LoginType login = new LoginType();
            login.userName = kAdi;
            login.passWord = sifre;
            try
            {
                bool result, specified;
                srv.Login(login, out result, out specified, out sessionId);
                if (result)
                {
                    durum = 1;
                    return true;
                }
                else
                {
                    durum = 0;
                    return false;
                }
            }
            catch (Exception ex)
            {
                durum = 0;
                XtraMessageBox.Show("E-Fatura Kontrolü Web Servis Hatası ! Hata: " + ex.Message.ToString());
                return false;
            }
        }

        public LogoEFaturaBilgi Giris(string tcNo)
        {
            string[] paramlist = { "VKN=" + tcNo, "DOCUMENTTYPE=0" };
            LogoEFaturaBilgi deger = new LogoEFaturaBilgi();

            var sonuc = srv.GetValidateGIBUser(sessionId, paramlist);
            if (sonuc.resultCode == -1)
            {
                deger.dolumu = false;
                return deger;
            }
            else
            {
                deger.dolumu = true;
            }
            string[] ms = sonuc.outputList;
            List<string> gidenpostaList = new List<string>();
            List<string> gelenpostaList = new List<string>();
            if (deger.dolumu == true)
            {
                foreach (var item in ms)
                {
                    string[] r = item.Split('=');
                    string key = r[0];
                    string value = r[1];
                    if (key == "ISGIBUSER")
                    {
                        if (value == "1")
                        {
                            deger.EFatura = true;
                        }
                        else
                        {
                            deger.EFatura = false;
                        }
                    }
                    if (key == "EINVOICEPKALIAS")
                    {
                        //dİZİYE aT İLK GELENLERİ AL
                        deger.GelenPosta = value;
                        gelenpostaList.Add(value);
                    }
                    if (key == "EINVOICEGBALIAS")
                    {
                        deger.GidenPosta = value;
                        gidenpostaList.Add(value);
                    }
                    if (key == "REGISTERTIME")
                    {
                        deger.GecisTarihi = value;
                    }

                }
                if (gidenpostaList.Count == 0)
                {
                    deger.GidenPosta = "";
                }
                else
                {
                    deger.GidenPosta = gidenpostaList.First();
                }
                if (gelenpostaList.Count == 0)
                {
                    deger.GelenPosta = "";
                }
                else
                {
                    deger.GelenPosta = gelenpostaList.First();
                }
                deger.dolumu = true;
                return deger;
            }
            else
            {
                return deger;
            }
        }
    }
}

public partial class LogoEFaturaBilgi
{
    public int ID { get; set; }
    public string GecisTarihi { get; set; }
    public bool EFatura { get; set; }
    public string GidenPosta { get; set; }
    public string GelenPosta { get; set; }
    public bool dolumu { get; set; }
}
