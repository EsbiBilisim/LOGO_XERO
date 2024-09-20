using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using LOGO_XERO.Models.LOGO_M;
using LOGO_XERO.Models.LOGO_XERO_M;
using LOGO_XERO.Moduller.Giris_AnaForm_Ayarlar;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace LOGO_XERO
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(BaglantiControl());
        }

        static Form BaglantiControl()
        {
            Lisans lisans = new Lisans();

            RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\EsbiSetting\\LOGO_XERO");

            if (rk == null)
            {
                frmAyarlar ayar = new frmAyarlar();
                return ayar;
            }
            else
            {
                List<REGISTERALANLAR> liste = lisans.Registeralan();
                List<string> rks = Registry.CurrentUser.OpenSubKey("Software\\EsbiSetting\\LOGO_XERO").GetValueNames().ToList();
                RegistryKey rkyaz = Registry.CurrentUser.CreateSubKey("Software\\EsbiSetting\\LOGO_XERO");
                foreach (var item in liste)
                {
                    var varmi = rks.Find(item.ADI.Contains);
                    if (varmi == null)
                    {
                        rkyaz.SetValue(item.ADI, item.TIP == typeof(bool) ? "false" : item.TIP == typeof(string) ? "" : "0");
                    }

                }
                RegistryKey rsk = Registry.CurrentUser.CreateSubKey("Software\\EsbiSetting\\LOGO_XERO");

                string SqlServerName = rk.GetValue("SERVERNAME").ToString();
                string Database = rk.GetValue("DBNAME").ToString();
                string SqlKullanici = rk.GetValue("USERNAME").ToString();
                string SqlPass = rk.GetValue("PASSWORD").ToString();
                string firma = rk.GetValue("FIRMANO").ToString();
                string sorgu = $@"Data Source={SqlServerName};uid={SqlKullanici};pwd={SqlPass};database={Database};Connect Timeout=0;";

                try
                {
                    using (SqlConnection connection = new SqlConnection())
                    {
                        connection.ConnectionString = sorgu;

                        connection.Open();

                        if (connection.State == ConnectionState.Broken)
                        {
                            MessageBox.Show("Bağlantı Bilgileri Yanlıştır !");
                            frmAyarlar ayar = new frmAyarlar();
                            return ayar;
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Bağlantı Bilgileri Yanlıştır !");
                    frmAyarlar ayar = new frmAyarlar();
                    return ayar;
                }

                SQLConnection con = new SQLConnection();
                con.Connect();
                IlkTabloIslemler Tablo = new IlkTabloIslemler();
                Tablo.RenkTablosuOlustur();
                Tablo.TeklifDurumTablosuOlustur();
                Tablo.LisansTablosuOlustur();
                Tablo.LisansTablosuModulEkle();
                Tablo.TeklifDurumTablosuOlustur();
                Tablo.TeklifDurumlariEkle();
                Tablo.AmbaraBagliCariKodTablosuOlustur();
                Tablo.UyariMesajlariTablosuOlustur();
                Tablo.DovizBilgileriTablosuOlustur();
                Tablo.GorevlerTablosuOlustur();
                Tablo.GorevlerTablosuDoldur();

                Tablo.YetkiTablosuOlustur();
                Tablo.PazarlamaTipiTablosuOlustur();
                Tablo.PazarlamaTipiDoldur();
                Tablo.NakliyeTuruTablosuOlustur();
                Tablo.NakliyeTuruDoldur();
                Tablo.TeslimSuresiTablosuOlustur();
                Tablo.TeslimSureleriDoldur();
                Tablo.VirmanAciklamaTablosuOlustur();
                Tablo.VirmanTablosuDoldur();
                Tablo.KullaniciAmbarIsyeriYetkiTablosuOlustur();

                Tablo.XERO_NUMARATOR_TABLOOLUSTUR();
                Tablo.TasarimTablosuOlustur();
                Tablo.YetkiTablosuDoldur();
                string tar = DateTime.Now.ToString("yyyy-MM-dd");


                string demolisans = lisans.SifreleAES("7350575134" + "+" + tar + "+"+"4", "AYNT");
                string gozlisans = lisans.SifreleAES("7350575134" + "+" + tar + "+"+"2", "AYNT");
                string tamlisans = lisans.SifreleAES("7350575134" + "+" + tar + "+" + "3", "HST");
                string teklifLisans = lisans.SifreleAES("7350575134" + "+" + tar + "+" + "1", "HST");
                //string tekliflisans = lisans.SifreleAES("3330027330" +"+"+ tar + "+"+"1", "AYNT");

                List<L_CAPIFIRM> firm = Tablo.DataSetlifirmalistesi();
                List<LOGO_XERO_LISANSLAR> lisanslar = Tablo.DataSetliLisanslistesi();
                List<LOGO_XERO_LISANSLAR> OlanLisansListesi = new List<LOGO_XERO_LISANSLAR>();
                List<LOGO_XERO_LISANSLAR> lisansBilgisiBosOlanlar = new List<LOGO_XERO_LISANSLAR>();
                List<LOGO_XERO_LISANSLAR> lisansSuresiDolanlar = new List<LOGO_XERO_LISANSLAR>();
                frmKullaniciGiris ana = new frmKullaniciGiris();
                foreach (var item in lisanslar)
                {
                    if (!string.IsNullOrWhiteSpace(item.LISANSNUMARASI))
                    {
                        LOGO_XERO_LISANS lisansli = lisans.LisansKontrolEt(item.LISANSNUMARASI);
                        if (lisansli.MODUL == item.MODUL)
                        {
                            L_CAPIFIRM lisansliFirma = firm.Where(s => s.TAXNR == lisansli.VERGIKIMLIKNO).FirstOrDefault();
                            if (lisansliFirma != null)
                            {
                                int kalanGun = lisans.KalanGunDondur(lisansli.TARIH, lisansli.MODUL);
                                if (kalanGun <= 0)
                                {
                                    lisansSuresiDolanlar.Add(new LOGO_XERO_LISANSLAR { ID = 0, LISANSNUMARASI = "", MODUL = lisansli.MODUL, VAR = 0 });
                                }
                                else
                                {
                                    OlanLisansListesi.Add(new LOGO_XERO_LISANSLAR { ID = 0, LISANSNUMARASI = "", MODUL = lisansli.MODUL, VAR = 0 });
                                }
                            }
                            else
                            {
                                lisansSuresiDolanlar.Add(new LOGO_XERO_LISANSLAR { ID = 0, LISANSNUMARASI = "", MODUL = lisansli.MODUL, VAR = 0 });
                            }
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        lisansBilgisiBosOlanlar.Add(item);
                    }
                }
                if (lisansBilgisiBosOlanlar.Count == 4)
                {
                    MessageBox.Show("Lisans Bilgileri Boştur !");
                    frmLisanslar ayar = new frmLisanslar();
                    return ayar;
                }
                if (lisansSuresiDolanlar.Count > 0 && OlanLisansListesi.Count > 0)
                {
                    MessageBox.Show("Lisans Süresi Dolmuş Modüller Mevcuttur ! Bilginize !");
                }
                if (lisansSuresiDolanlar.Count > 0 && OlanLisansListesi.Count == 0)
                {
                    MessageBox.Show("Lisans Süresi Dolmuştur !");
                    frmLisanslar ayar = new frmLisanslar();
                    return ayar;
                }

                if (OlanLisansListesi.Count > 0)
                {
                    ana.olanLisansListesi = OlanLisansListesi;
                }
                try
                {
                    //  UserLookAndFeel.Default.SkinName = rk.GetValue("Skin").ToString();
                }
                catch
                {
                }
                return ana;

            }
        }
    }
}