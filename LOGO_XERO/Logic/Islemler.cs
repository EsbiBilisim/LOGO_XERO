using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using LOGO_XERO.Models;
using LOGO_XERO.Models.LOGO_M;
using LOGO_XERO.Models.LOGO_XERO_M;
using LOGO_XERO.Moduller.GenelListeler;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using System.Text;
using LOGO_XERO.Models.GenelKullanim;
using LOGO_XERO.Models.LogoObje;
using RestSharp;
using DevExpress.XtraGrid;
using System.Data;
using System.Data.SqlTypes;
using DevExpress.CodeParser;
using System.Data.SqlClient;
using DevExpress.Utils;
using DevExpress.XtraCharts.Native;
using LOGO_XERO.Models.CariSorgulama;
using Newtonsoft.Json;
using LOGO_XERO.Models.StokEkstresi;
using LOGO_XERO.Models.CARI_CEKRISKBILGILERI;
using LOGO_XERO.Models.LOGO_M.DosyaClaslari;
using System.Xml;
using System.Xml.Serialization;

namespace LOGO_XERO.Logic
{
    public class Islemler
    {
        public List<LG_EMUHACC> CariHesapPlanlariGetir()
        {
            using (LogoContext db = new LogoContext())
            {
                return db.LG_EMUHACC.OrderBy(s => s.CODE).ToList();
            }
        }

        public LG_EMUHACC SeciliCariHesapPlaniGetir(int logicalref)
        {
            using (LogoContext db = new LogoContext())
            {
                return db.LG_EMUHACC.Where(s => s.LOGICALREF == logicalref).FirstOrDefault();
            }
        }

        public LG_EMUHACC CariHesapPLaniKontrol(string kod)
        {
            LG_EMUHACC varmi = new LG_EMUHACC();
            using (LogoContext db = new LogoContext())
            {
                return db.LG_EMUHACC.Where(s => s.CODE == kod).FirstOrDefault();
            }
        }

        public List<L_FIRMPARAMS> FirmaLogoTumParametreleriGetir(string firmano)
        {
            using (LogoContext db = new LogoContext())
            {
                Int16 firma = Convert.ToInt16(firmano);
                return db.L_FIRMPARAMS.Where(s => s.FIRMNR == firma).ToList();
            }
        }
        public LG_TRGPAR RiskParametreleriLogo()
        {
            using (LogoContext db = new LogoContext())
            {
                return db.LG_TRGPAR.FirstOrDefault();
            }
        }
        public LG_CLRNUMS CariRiskBilgileriGetir(int cariref)
        {
            using (LogoContext db = new LogoContext())
            {
                return db.LG_CLRNUMS.Where(s => s.CLCARDREF == cariref).FirstOrDefault();
            }
        }
        public L_FIRMPARAMS FirmaLogoSeciliParametreyiGetir(short firmano, string tip, int grupnr, int modul)
        {
            using (LogoContext db = new LogoContext())
            {
                return db.L_FIRMPARAMS.Where(s => s.FIRMNR == firmano && s.CODE == tip && s.GROUPNR == grupnr && s.MODULENR == modul).FirstOrDefault();
            }
        }
        public List<L_CURRENCYLIST> firmaKurBilgileriGetir(short firmano)
        {
            using (LogoContext db = new LogoContext())
            {
                return db.L_CURRENCYLIST.Where(s => s.FIRMNR == firmano).ToList();
            }
        }
        public string kdvmaufiyetgetir(LOGO_XERO_PARAMETRELER parametre,string kod)
        {
            string dosyayolu = parametre.PROGRAMKATALOGDOSYAYOLU + "\\VatExcepts.xml";

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(dosyayolu);
            VATEXCEPT_REASON result = new VATEXCEPT_REASON();
            XmlReader xmlReader = new XmlNodeReader(xmlDocument);
            XmlSerializer serializer = new XmlSerializer(typeof(LOGO_XERO.Models.LOGO_M.DosyaClaslari.VATEXCEPT_REASON));
            result = (LOGO_XERO.Models.LOGO_M.DosyaClaslari.VATEXCEPT_REASON)serializer.Deserialize(xmlReader);
            if (result.VATEXCEPTREASON.Count > 0)
            {
                var sonuc = result.VATEXCEPTREASON; 
                if (sonuc != null)
                {
                    VATEXCEPTREASON snc = sonuc.Where(s => s.CODE == kod).FirstOrDefault();
                    if (snc != null)
                    {
                        return snc.NAME;
                    }
                }
                return "hata";
            }
            else
            {
                return "hata";
            }
        }
        public string tokenAl(LOGO_XERO_PARAMETRELER parametre, string firmaNo)
        {
            using (LogoContext db = new LogoContext())
            {
                LOGO_XERO_PARAMETRELER par = db.LOGO_XERO_PARAMETRELER.Where(s => s.FIRMANO == firmaNo).FirstOrDefault();
                var client = new RestClient(par.RESTSERVISURL + "/api/v1/token");
                var request = new RestRequest(RestSharp.Method.POST);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddParameter("grant_type", "password");
                request.AddHeader("Authorization", "Basic REFUQU1FUjptNVFQWDJIZjE3Sm1NaXVVMC93NlBnR1FlQzE0MDBLbnZaZWk1V2J6UGF3PQ==");
                request.AddParameter("username", $@"{par.RESTSERVISKULLANICIADI}");
                request.AddParameter("password", $@"{par.RESTSERVISSIFRE}");
                request.AddParameter("firmno", $@"{Convert.ToInt32(firmaNo)}");
                IRestResponse response = client.Execute(request);
                try
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ObjeToken.Sonuc.Rootobject sonuc = Newtonsoft.Json.JsonConvert.DeserializeObject<ObjeToken.Sonuc.Rootobject>(response.Content);
                        par.RESTSERVISTOKEN = sonuc.access_token;
                        db.Entry(par).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        parametre.RESTSERVISTOKEN = sonuc.access_token;
                        return sonuc.access_token;
                    }
                    else
                    {
                        return "";
                    }
                }
                catch (Exception ex)
                {
                    string hata = ex.ToString();
                    throw;
                }
            }
        }
        public void GridDetayGoster(GridView gridview) {

            gridview.BeginUpdate();
            try
            {
                int dataRowCount = gridview.DataRowCount;
                for (int rHandle = 0; rHandle < dataRowCount; rHandle++)
                    gridview.SetMasterRowExpanded(rHandle, true);
            }
            finally
            {
                gridview.EndUpdate();
            }

        }
        public void GridDetayKapat(GridView gridView) {
            
            gridView.BeginUpdate();
            try
            {
                int dataRowCount = gridView.DataRowCount;
                for (int rHandle = 0; rHandle < dataRowCount; rHandle++)
                    gridView.CollapseMasterRow(rHandle);
            }
            finally
            {
                gridView.EndUpdate();
            }
        }
        public void excelAktar(GridControl grid)
        {
            SaveFileDialog svf = new SaveFileDialog();
            svf.Filter = "Excel Dosyası| *.xlsx";
            DialogResult dr = svf.ShowDialog();
            if (dr == DialogResult.OK)
            {
                grid.ExportToXlsx(svf.FileName);
            }
        }
        public double IndirimliFiyatHesapla(double indirimsizFiyat, double[] indirimler)
        {

            foreach (double indirim in indirimler)
                indirimsizFiyat *= (1 - indirim / 100);
            return Math.Round(indirimsizFiyat, 3, MidpointRounding.AwayFromZero);
        }
        public void TeslimSuresiDoldur(dynamic nesne)
        {
            nesne.DataSource = TeslimSureleriGetir();
            nesne.ValueMember = "TESLIMSURESI";
            nesne.DisplayMember = "TESLIMSURESI";
        }
        public void LogoSatisElemaniDoldur(LookUpEdit nesne, string firma)
        {
            nesne.Properties.DataSource = LogoSatisElemanlariGetir(firma);
            nesne.Properties.ValueMember = "CODE";
            nesne.Properties.DisplayMember = "DEFINITION_";
        }
        public void LogoSatisElemaniDoldurDinamik(dynamic nesne, string firma)
        {
            nesne.DataSource = LogoSatisElemanlariGetir(firma);
            nesne.ValueMember = "CODE";
            nesne.DisplayMember = "DEFINITION_";
        }
        public void LogoSatisElemaniDoldurDinamikRef(dynamic nesne, string firma)
        {
            nesne.DataSource = LogoSatisElemanlariGetir(firma);
            nesne.ValueMember = "LOGICALREF";
            nesne.DisplayMember = "DEFINITION_";
        }

        public void PazarlamaTipleriDoldur(dynamic nesne)
        {
            nesne.Properties.DataSource = PazarlamaTipleriGetir();
            nesne.Properties.ValueMember = "ID";
            nesne.Properties.DisplayMember = "PAZARLAMATIPI";
        }
        public void UyariMesajlariDoldur(dynamic nesne, string firma)
        {
            using (LogoContext db = new LogoContext())
            {
                int firmano = Convert.ToInt32(firma);
                nesne.Properties.DataSource = db.LOGO_XERO_UYARI_MESAJLARI.Where(s => s.FIRMANO == firmano).ToList();
                nesne.Properties.ValueMember = "ID";
                nesne.Properties.DisplayMember = "ACIKLAMA";
            }
        }
        public void FirmaListesiDoldur(dynamic nesne)
        {
            List<L_CAPIFIRM> firmalar = firmalistesi("");
            nesne.DisplayMember = "NUM";
            nesne.ValueMember = "NUM2";
            nesne.DataSource = firmalar;
        }
        public void DonemListesiDoldur(dynamic nesne, string firma)
        {
            List<L_CAPIPERIOD> donemListesi = Donemlistesi(firma);
            nesne.DisplayMember = "NUM2";
            nesne.ValueMember = "NUM";
            nesne.DataSource = donemListesi;
        }
        public void IsyeriListesiDoldur(dynamic nesne, string firma)
        {
            List<L_CAPIDIV> isyeriListesi = IsyeriListesi(firma);
            nesne.Properties.DisplayMember = "NUMARA";
            nesne.Properties.ValueMember = "NR";
            nesne.Properties.DataSource = isyeriListesi;
        }
        public void BolumListesiDoldur(dynamic nesne, string firma)
        {
            List<L_CAPIDEPT> bolumListesi = BolumListesi(firma);
            nesne.Properties.DisplayMember = "NUMARA";
            nesne.Properties.ValueMember = "NR";
            nesne.Properties.DataSource = bolumListesi;
        }
        public void FabrikaListesiDoldur(dynamic nesne, string firma)
        {
            List<L_CAPIFACTORY> fabrikaListesi = FabrikaListesi(firma);
            nesne.Properties.DisplayMember = "NUMARA";
            nesne.Properties.ValueMember = "NR";
            nesne.Properties.DataSource = fabrikaListesi;
        }
        public void AmbarListesiDoldur(dynamic nesne, string firma, int isyeri,int fabrika)
        {
            List<L_CAPIWHOUSE> ambarListesi = AmbarListesi(firma, isyeri,fabrika);
            nesne.Properties.DisplayMember = "NUMARA";
            nesne.Properties.ValueMember = "NR";
            nesne.Properties.DataSource = ambarListesi;
        }
        public void TumAmbarListesiDoldur(dynamic nesne, string firma)
        {
            List<L_CAPIWHOUSE> ambarListesi = TumAmbarListesi(firma);
            nesne.Properties.DisplayMember = "NUMARA";
            nesne.Properties.ValueMember = "NR";
            nesne.Properties.DataSource = ambarListesi;
        }
        public void PersonelListesiDoldur(dynamic nesne)
        {
            List<LOGO_XERO_KULLANICILAR> kullanicilar = KullaniciListesiGetir();
            nesne.Properties.DisplayMember = "KULLANICIADI";
            nesne.Properties.ValueMember = "ID";
            nesne.Properties.DataSource = kullanicilar;
        }

        public void LookUpTeklifTipDoldur(dynamic nesne)
        {
            KODAD s = new KODAD()
            {
                CODE = 8,
                NAME = "SATIŞ"
            };
            KODAD a = new KODAD()
            {
                CODE = 1,
                NAME = "ALIŞ"
            };

            List<KODAD> alsts = new List<KODAD>();
            alsts.Add(a);
            alsts.Add(s);
            nesne.DataSource = alsts;
            nesne.DisplayMember = "NAME";
            nesne.ValueMember = "CODE";
        }

        public void LookUpTeklifOnayDurumDoldur(dynamic nesne)
        {

            KODAD onay1 = new KODAD()
            {
                CODE = 1,
                NAME = "ONAY BEKLİYOR"
            };
            KODAD onay2 = new KODAD()
            {
                CODE = 2,
                NAME = "ONAYLANDI"
            };
            KODAD onay3 = new KODAD()
            {
                CODE = 3,
                NAME = "TEKLİF REDDEDİLDİ"
            };
            List<KODAD> onaylst = new List<KODAD>();
            onaylst.Add(onay1);
            onaylst.Add(onay2);
            onaylst.Add(onay3);
            nesne.DataSource = onaylst;
            nesne.DisplayMember = "NAME";
            nesne.ValueMember = "CODE";
        }

        //public void LookUpTeklifSatirTipDoldur(dynamic nesne)
        //{

        //    KODAD KD = new KODAD() { CODE = 8, NAME = "SATIŞ" };
        //    KODAD KN = new KODAD() { CODE = 1, NAME = "ALIŞ" };
        //    List<KODAD> list = new List<KODAD> { KD, KN };
        //    rpTur.DataSource = list;
        //    rpTur.DisplayMember = "NAME";
        //    rpTur.ValueMember = "CODE";
        //}
        public void TeklifDurumListesiDoldur(dynamic nesne)
        {
            List<LOGO_XERO_TEKLIF_DURUMLARI> durumlar = TeklifDurumGetir();
            nesne.Properties.DisplayMember = "DURUM";
            nesne.Properties.ValueMember = "TIP";
            nesne.Properties.DataSource = durumlar;
        }
        public void TeklifTanimliAlanOdemeTipiDoldur(dynamic nesne, string firma)
        {
            using (LogoContext db = new LogoContext())
            {
                List<LG_CATEGLISTS> tanimliAlanOdemeler = db.LG_CATEGLISTS.Where(s => s.RECORDID == 8 && s.CATEGID == 10850).OrderBy(s => s.TAG).ToList();
                nesne.Properties.DisplayMember = "CATDESC";
                nesne.Properties.ValueMember = "TAG";
                nesne.Properties.DataSource = tanimliAlanOdemeler;
            }
        }
        public void DovizBilgileriDoldur(dynamic nesne, string firmano)
        {
            List<L_CURRENCYLIST> dovizler = DovizListesiGetir(firmano);
            nesne.Properties.DisplayMember = "CURCODE";
            nesne.Properties.ValueMember = "CURTYPE";
            nesne.Properties.DataSource = dovizler;
        }

        public void XeroDovizBilgileriDoldur(dynamic nesne, string firmano)
        {
            List<LOGO_XERO_DOVIZ_BILGILERI> dovizler = XeroDovizListesiGetir(firmano);
            nesne.Properties.DisplayMember = "DOVIZCINSI";
            nesne.Properties.ValueMember = "DOVIZKODU";
            nesne.Properties.DataSource = dovizler;
        }
        public void OdemeTipleriDoldur(dynamic nesne, string firma)
        {
            List<LG_PAYPLANS> odemeler = OdemeListesiGetir(firma);
            nesne.Properties.DisplayMember = "DEFINITION_";
            nesne.Properties.ValueMember = "LOGICALREF";
            nesne.Properties.DataSource = odemeler;
        }
        public bool TasarimKaydet(GridView gv, int kullaniciid, string sayfaadi, string gridadi)
        {
            Stream str = new System.IO.MemoryStream();
            gv.SaveLayoutToStream(str);
            str.Seek(0, System.IO.SeekOrigin.Begin);
            StreamReader reader = new StreamReader(str);
            string text = reader.ReadToEnd();
            bool durum = false;
            using (LogoContext db3 = new LogoContext())
            {
                try
                {
                    LOGO_XERO_TASARIMLAR tasarim = db3.LOGO_XERO_TASARIMLAR.Where(s => s.SAYFAADI == sayfaadi && s.PERSONELID == kullaniciid && s.GRIDADI == gridadi).FirstOrDefault();
                    if (tasarim == null)
                    {
                        LOGO_XERO_TASARIMLAR yenitasarim = new LOGO_XERO_TASARIMLAR();
                        yenitasarim.GRIDADI = gridadi;
                        yenitasarim.PERSONELID = kullaniciid;
                        yenitasarim.TASARIM = text;
                        yenitasarim.SAYFAADI = sayfaadi;
                        db3.LOGO_XERO_TASARIMLAR.Add(yenitasarim);
                        db3.SaveChanges();
                    }
                    else
                    {
                        tasarim.TASARIM = text;
                        db3.Entry(tasarim).State = System.Data.Entity.EntityState.Modified;
                        db3.SaveChanges();
                    }
                    durum = true;
                }
                catch
                {
                    durum = false;
                }
            }
            return durum;
        }
        public void TasarimGetir(GridView gv, int kullaniciid, string sayfaadi, string gridadi)
        {
            string tasarimdeger = "";
            using (LogoContext db3 = new LogoContext())
            {
                LOGO_XERO_TASARIMLAR tasarim = db3.LOGO_XERO_TASARIMLAR.Where(s => s.SAYFAADI == sayfaadi && s.PERSONELID == kullaniciid && s.GRIDADI == gridadi).FirstOrDefault();
                if (tasarim != null)
                {
                    tasarimdeger = tasarim.TASARIM;
                    byte[] encodedString = Encoding.UTF8.GetBytes(tasarimdeger);
                    MemoryStream ms = new MemoryStream(encodedString);
                    gv.RestoreLayoutFromStream(ms);
                    ms.Flush();
                    ms.Position = 0;
                }
            }
        }
        public string[] StokKodaAitCinsVeBarkodGetir(string firma, string stokkodu)
        {
            SQLConnection connect = new SQLConnection();
            connect.Connect();
            string sql = $@" 
                    select I.CODE 'STOKKODU',I.NAME 'STOKADI',(select top 1 BARCODE from LG_{firma}_UNITBARCODE where ITEMREF = I.LOGICALREF ) 'BARKOD' from LG_{firma}_ITEMS I WHERE I.CODE = '{stokkodu}'
            ";
            SqlCommand cmd = new SqlCommand(sql, connect.Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            string _stokkodu = ds.Tables[0].Rows[0]["STOKKODU"].ToString();
            string _stokadı = ds.Tables[0].Rows[0]["STOKADI"].ToString();
            string _barkod = ds.Tables[0].Rows[0]["BARKOD"].ToString();
            string[] stk = { _stokkodu, _stokadı, _barkod };
            return stk;
        }
        public List<L_CAPIDIV> IsyeriListesi(string firmano)
        {
            using (LogoContext db = new LogoContext())
            {
                int firma = Convert.ToInt32(firmano);
                return db.L_CAPIDIV.Where(s => s.FIRMNR == firma).ToList();
            }
        }
        public List<LOGO_XERO_ARAMA_FILTRE_ALANLARI> FiltreListesiGetir(int modul, string firma)
        {
            using (LogoContext db = new LogoContext())
            {
                return db.LOGO_XERO_ARAMA_FILTRE_ALANLARI.Where(s => s.MODUL == modul).ToList();
            }
        }
        public List<L_CAPIDEPT> BolumListesi(string firmano)
        {
            using (LogoContext db = new LogoContext())
            {
                int firma = Convert.ToInt32(firmano);
                return db.L_CAPIDEPT.Where(s => s.FIRMNR == firma).ToList();
            }
        }
        public List<L_CAPIFACTORY> FabrikaListesi(string firmano)
        {
            using (LogoContext db = new LogoContext())
            {
                int firma = Convert.ToInt32(firmano);
                return db.L_CAPIFACTORY.Where(s => s.FIRMNR == firma).ToList();
            }
        }
        public List<L_CAPIWHOUSE> AmbarListesi(string firmano, int isyeri,int fabrika)
        {
            using (LogoContext db = new LogoContext())
            {
                int firma = Convert.ToInt32(firmano);
                return db.L_CAPIWHOUSE.Where(s => s.FIRMNR == firma && s.DIVISNR == isyeri && s.FACTNR == fabrika ).ToList();
            }
        }
        public List<L_CAPIWHOUSE> TumAmbarListesi(string firmano)
        {
            using (LogoContext db = new LogoContext())
            {
                int firma = Convert.ToInt32(firmano);
                return db.L_CAPIWHOUSE.Where(s => s.FIRMNR == firma).ToList();
            }
        }
        public List<L_CAPIFIRM> firmalistesi(string firmano)
        {
            using (LogoContext db = new LogoContext())
            {
                return db.L_CAPIFIRM.ToList();
            }
        }
        public List<L_CAPIPERIOD> Donemlistesi(string firmano)
        {
            using (LogoContext db = new LogoContext())
            {
                int firma = Convert.ToInt32(firmano);
                return db.L_CAPIPERIOD.Where(s => s.FIRMNR == firma).ToList();
            }
        }
        public List<L_CURRENCYLIST> DovizListesiGetir(string firmano)
        {
            using (LogoContext db = new LogoContext())
            {
                int firma = Convert.ToInt32(firmano);
                return db.L_CURRENCYLIST.Where(s => s.FIRMNR == firma).ToList();
            }
        }

        public List<LG_SLSMAN> LogoSatisElemanlariGetir(string firmano)
        {
            using (LogoContext db = new LogoContext())
            {
                int firma = Convert.ToInt32(firmano);
                return db.LG_SLSMAN.Where(s => s.FIRMNR == firma).ToList();
            }
        }

        public List<LOGO_XERO_DOVIZ_BILGILERI> XeroDovizListesiGetir(string firmano)
        {
            List<LOGO_XERO_DOVIZ_BILGILERI> dovizListesi = new List<LOGO_XERO_DOVIZ_BILGILERI>();
            using (LogoContext db = new LogoContext())
            {
                int firma = Convert.ToInt32(firmano);
                dovizListesi = db.LOGO_XERO_DOVIZ_BILGILERI.Where(s => s.FIRMANO == firma).ToList();
                if (dovizListesi.Where(s => s.DOVIZKODU == 0 || s.DOVIZKODU == 160).Count() == 0)
                {
                    dovizListesi.Add(new LOGO_XERO_DOVIZ_BILGILERI { ACIKLAMA = "TL", LOGICALREF = 0, DOVIZKODU = 0, DOVIZCINSI = "TL", FIRMANO = firma, SEMBOL = "", ID = 0 });
                }
                return dovizListesi;
            }
        }
        public L_CURRENCYLIST DovizBilgisiGetir(string firmano, Int16 dovizKodu)
        {
            using (LogoContext db = new LogoContext())
            {
                int firma = Convert.ToInt32(firmano);
                if (dovizKodu == 0 || dovizKodu == 160)
                {
                    dovizKodu = 160;
                }
                return db.L_CURRENCYLIST.Where(s => s.FIRMNR == firma && s.CURTYPE == dovizKodu).FirstOrDefault();
            }
        }
        public L_CAPIFIRM FirmaBilgileriGetir(string firmano)
        {
            using (LogoContext db = new LogoContext())
            {
                int firma = Convert.ToInt32(firmano);
                return db.L_CAPIFIRM.Where(s => s.NR == firma).FirstOrDefault();
            }
        }
        public L_CAPIPERIOD DonemBilgileriGetir(string firmano, string donemno)
        {
            using (LogoContext db = new LogoContext())
            {
                int firma = Convert.ToInt32(firmano);
                int donem = Convert.ToInt32(donemno);
                return db.L_CAPIPERIOD.Where(s => s.FIRMNR == firma && s.NR == donem).FirstOrDefault();
            }
        }
        public List<Models.LOGO_M.LG_SHIPINFO> SevkiyatAdresleriGetir(string firmano, int cariRef)
        {
            using (LogoContext db = new LogoContext())
            {
                string sql = $@"SELECT * FROM LG_{firmano}_SHIPINFO WHERE ACTIVE=0 AND CLIENTREF={cariRef}";
                return db.Database.SqlQuery<LG_SHIPINFO>(sql).ToList();
            }
        }
        public CODENAME SevkiyatAdresi(string firmano, int cariRef, int sevkiyatadresiid)
        {
            using (LogoContext db = new LogoContext())
            {
                string sql = $@"SELECT CODE,NAME FROM LG_{firmano}_SHIPINFO WHERE  ACTIVE=0 AND CLIENTREF={cariRef} AND LOGICALREF = {sevkiyatadresiid}";
                return db.Database.SqlQuery<CODENAME>(sql).FirstOrDefault();
            }
        }
        public LOGO_XERO_CARILISTE CariBilgiGetir(int logicalref)
        {
            LOGO_XERO_CARILISTE kay = new LOGO_XERO_CARILISTE();
            using (LogoContext db = new LogoContext())
            {
                kay = db.LOGO_XERO_CARILISTE.Where(s => s.LOGICALREF == logicalref).FirstOrDefault();
            }
            return kay;

        }
        public List<LOGO_XERO_LISANSLAR> LisansListesiGetir()
        {
            using (LogoContext db = new LogoContext())
            {
                return db.LOGO_XERO_LISANSLAR.ToList();
            }
        }
        public List<LOGO_XERO_TESLIM_SURESI> TeslimSureleriGetir()
        {
            using (LogoContext db = new LogoContext())
            {
                return db.LOGO_XERO_TESLIM_SURESI.ToList();
            }
        }
        public List<LOGO_XERO_NAKLIYE_TURU> NakliyeTurleriGetir()
        {
            using (LogoContext db = new LogoContext())
            {
                return db.LOGO_XERO_NAKLIYE_TURU.ToList();
            }
        }
        public List<LOGO_XERO_VIRMAN_ACIKLAMA> VirmanAciklamaGetir()
        {
            using (LogoContext db = new LogoContext())
            {
                return db.LOGO_XERO_VIRMAN_ACIKLAMA.ToList();
            }
        }
        public List<LOGO_XERO_PAZARLAMA_TIPLERI> PazarlamaTipleriGetir()
        {
            using (LogoContext db = new LogoContext())
            {
                return db.LOGO_XERO_PAZARLAMA_TIPLERI.ToList();
            }
        }
        public List<LOGO_XERO_KULLANICILAR> KullaniciListesiGetir()
        {
            using (LogoContext db = new LogoContext())
            {
                return db.LOGO_XERO_KULLANICILAR.ToList();
            }
        }
        public List<LOGO_XERO_TEKLIF_DURUMLARI> TeklifDurumGetir()
        {
            using (LogoContext db = new LogoContext())
            {
                return db.LOGO_XERO_TEKLIF_DURUMLARI.ToList();
            }
        }
        public List<L_TRADGRP> TicariIslemGruplariGetir()
        {
            using (LogoContext db = new LogoContext())
            {
                return db.L_TRADGRP.ToList();
            }
        }
        public LG_MARK SeciliMarkaBilgiGetir(int id)
        {
            using (LogoContext db = new LogoContext())
            {
                return db.LG_MARK.Where(s => s.LOGICALREF == id).FirstOrDefault();
            }
        }
        public List<LG_MARK> MarkListesiGetir()
        {
            using (LogoContext db = new LogoContext())
            {
                return db.LG_MARK.ToList();
            }
        }
        public List<LG_PAYPLANS> OdemeListesiGetir(string firmano)
        {
            using (LogoContext db = new LogoContext())
            {
                return db.LG_PAYPLANS.Where(s => s.ACTIVE == 0).ToList();
            }
        }
        public LG_PAYPLANS OdemeBilgiGetir(string firmano, int logicalref)
        {
            using (LogoContext db = new LogoContext())
            {
                return db.LG_PAYPLANS.Where(s => s.ACTIVE == 0 && s.LOGICALREF == logicalref).FirstOrDefault();
            }
        }
        public List<LG_PROJECT> ProjeListesiGetir(string firmano)
        {
            using (LogoContext db = new LogoContext())
            {
                return db.LG_PROJECT.ToList();
            }
        }
        public string ProjeKodu(string firmano, int id)
        {
            using (LogoContext db = new LogoContext())
            {
                string kod = "";
                LG_PROJECT proje = db.LG_PROJECT.Where(s => s.LOGICALREF == id).FirstOrDefault();
                if (proje != null)
                {
                    kod = proje.CODE;
                }
                return kod;
            }
        }
        public List<LG_SPECODES> OzelKodlarGetir(string firmano, int codetype, int specodetype, int spetype)
        {
            using (LogoContext db = new LogoContext())
            {
                if (spetype == 1)
                {
                    return db.LG_SPECODES.Where(s => s.CODETYPE == codetype && s.SPECODETYPE == specodetype && s.SPETYP1 == 1).ToList();
                }
                else if (spetype == 2)
                {
                    return db.LG_SPECODES.Where(s => s.CODETYPE == codetype && s.SPECODETYPE == specodetype && s.SPETYP2 == 1).ToList();
                }
                else if (spetype == 3)
                {
                    return db.LG_SPECODES.Where(s => s.CODETYPE == codetype && s.SPECODETYPE == specodetype && s.SPETYP3 == 1).ToList();
                }
                else if (spetype == 4)
                {
                    return db.LG_SPECODES.Where(s => s.CODETYPE == codetype && s.SPECODETYPE == specodetype && s.SPETYP4 == 1).ToList();
                }
                else if (spetype == 5)
                {
                    return db.LG_SPECODES.Where(s => s.CODETYPE == codetype && s.SPECODETYPE == specodetype && s.SPETYP5 == 1).ToList();
                }
                else
                {
                    return db.LG_SPECODES.Where(s => s.CODETYPE == codetype && s.SPECODETYPE == specodetype).ToList();
                }
            }
        }
        public List<L_SHPAGENT> TasiyiciKodListesi()
        {
            using (LogoContext db = new LogoContext())
            {
                return db.L_SHPAGENT.ToList();
            }
        }
        public string TasiyiciKoduAciklamasi(string tasiyiciKodu)
        {
            using (LogoContext db = new LogoContext())
            {
                return db.L_SHPAGENT.Where(s => s.CODE == tasiyiciKodu).FirstOrDefault().TITLE;
            }
        }
        public List<L_SHPTYPES> TeslimSekliListesi()
        {
            using (LogoContext db = new LogoContext())
            {
                return db.L_SHPTYPES.ToList();
            }
        }
        public string TeslimSekliAciklamasi(string teslimSekliKodu)
        {
            using (LogoContext db = new LogoContext())
            {
                return db.L_SHPTYPES.Where(s => s.SCODE == teslimSekliKodu).FirstOrDefault().SDEF;
            }
        }
        public LOGO_XERO_KULLANICILAR KullaniciBilgisiGetir(int id)
        {
            LOGO_XERO_KULLANICILAR kul = new LOGO_XERO_KULLANICILAR();
            try
            {
                using (LogoContext db = new LogoContext())
                {
                    kul = db.LOGO_XERO_KULLANICILAR.Where(s => s.ID == id).FirstOrDefault();

                }
            }
            catch
            {
            }
            return kul;

        }
        public void CariListesiAc(dynamic frm, int tip, bool rp = false)
        {
            frmCariListesi frm1 = new frmCariListesi(frm);
            frm1.rpmi = rp;
            frm1.tip = tip;
            frm1.ShowDialog();
        }
        public void OzelKodListesiAc(dynamic frm, int tip, int codetype, int specodetype, int spetype)
        {
            frmOzelKodlar frm1 = new frmOzelKodlar(frm);
            frm1.tip = tip;
            frm1.codetype = codetype;
            frm1.specodetype = specodetype;
            frm1.SPETYPE = spetype;
            frm1.ShowDialog();
        }
        public void TasiyiciKodlariListesiniAc(dynamic frm)
        {
            frmTasiyiciKodlari frm1 = new frmTasiyiciKodlari(frm);
            frm1.ShowDialog();
        }
        public void TeslimSekilleriListesiniAc(dynamic frm)
        {
            frmTeslimSekilleri frm1 = new frmTeslimSekilleri(frm);
            frm1.ShowDialog();
        }
        public void OdemeTipiAc(dynamic frm)
        {
            frmOdemeler frm1 = new frmOdemeler(frm);
            frm1.ShowDialog();
        }
        public LG_ITEMS stokBilgi(int logicalref)
        {
            using (LogoContext db = new LogoContext())
            {
                return db.LG_ITEMS.Where(s => s.LOGICALREF == logicalref).FirstOrDefault();
            }
        }
        public LG_CLCARD cariBilgi(int logicalref)
        {
            using (LogoContext db = new LogoContext())
            {
                return db.LG_CLCARD.Where(s => s.LOGICALREF == logicalref).FirstOrDefault();
            }
        }
        public LG_EMUHACC cariMuhasebeBilgi(string firma, string donem, int cariref)
        {
            LG_EMUHACC KAY = new LG_EMUHACC();
            using (LogoContext db = new LogoContext())
            {
                string sql = $@"select EM.* from LG_{firma}_CRDACREF C
LEFT OUTER JOIN LG_{firma}_EMUHACC EM ON C.ACCOUNTREF=EM.LOGICALREF
WHERE C.CARDREF={cariref} AND C.TRCODE=5";
                KAY = db.Database.SqlQuery<LG_EMUHACC>(sql).FirstOrDefault();
                return KAY;
            }
        }
        public void TicariIslemGruplariAc(dynamic frm)
        {
            frmTicariIslemGuruplari frm1 = new frmTicariIslemGuruplari(frm);
            frm1.ShowDialog();
        }
        public void ProjeListesiniAc(dynamic frm)
        {
            frmProjeler frm1 = new frmProjeler(frm);
            frm1.ShowDialog();
        }
        public double RatesDovizKuruDondur(LOGO_XERO_PARAMETRELER parametre, L_CAPIFIRM firmaBilgi, short? dovizkodu, string firma, string donem)
        {
            double dovizKuru;
            string dovizKuruSql = "";
            using (LogoContext db = new LogoContext())
            {
                if (firmaBilgi.SEPEXCHTABLE == 0)
                {
                    dovizKuruSql = $@"SELECT RATES{parametre.KULLANILACAKDOVIZTURU} FROM L_DAILYEXCHANGES WHERE CRTYPE={dovizkodu} AND EDATE='{DateTime.Now.ToString("yyyy-MM-dd")}'";
                }
                else
                {
                    dovizKuruSql = $@"SELECT RATES{parametre.KULLANILACAKDOVIZTURU} FROM LG_EXCHANGE_{firma} WHERE CRTYPE={dovizkodu} AND EDATE='{DateTime.Now.ToString("yyyy-MM-dd")}'";
                }
                dovizKuru = db.Database.SqlQuery<double>(dovizKuruSql).FirstOrDefault();
                return dovizKuru;
            }
        }

        public bool DovizKontrol(LOGO_XERO_PARAMETRELER parametre, L_CAPIFIRM firmaBilgi, string firma, string donem)
        {
            double dovizKuru;
            string dovizKuruSql = "";
            using (LogoContext db = new LogoContext())
            {
                if (firmaBilgi.SEPEXCHTABLE == 0)
                {
                    dovizKuruSql = $@"SELECT RATES{parametre.KULLANILACAKDOVIZTURU} FROM L_DAILYEXCHANGES WHERE EDATE='{DateTime.Now.ToString("yyyy-MM-dd")}'";
                }
                else
                {
                    dovizKuruSql = $@"SELECT RATES{parametre.KULLANILACAKDOVIZTURU} FROM LG_EXCHANGE_{firma} WHERE  EDATE='{DateTime.Now.ToString("yyyy-MM-dd")}'";
                }
                dovizKuru = db.Database.SqlQuery<double>(dovizKuruSql).FirstOrDefault();
                if (dovizKuru == 0)
                {
                    return false;

                }
                else
                {
                    return true;
                }
            }
        }
        public string LogoBarkodOlustur(LOGO_XERO_PARAMETRELER parametre, string firma)
        {
            using (LogoContext db = new LogoContext())
            {
                string barkodAl = LogoBarkodNoEan13(parametre.MSTK_OTOBARKODLOGICALREF, firma).ToString();
                string Barkod = barkodAl + CalculateChecksum(barkodAl);
                return Barkod;
            }
        }
        public string LogoBarkodNoEan13(int logicalref, string firmaNo)
        {
            using (LogoContext db = new LogoContext())
            {
                string RefNoAl = string.Format($@"SELECT  LASTASGND CODE, '' [NAME] FROM L_LDOCNUM WITH (NOLOCK)  WHERE LOGICALREF ={logicalref} AND FIRMID='{firmaNo}';
                                             ");

                CODENAME ReferansNo = db.Database.SqlQuery<CODENAME>(RefNoAl).FirstOrDefault(); /* .ToString().PadLeft(12, '0');*/
                string RefNoArttir = $@" UPDATE L_LDOCNUM SET LASTASGND=(SELECT TOP 1 CAST(LASTASGND AS NUMERIC) FROM L_LDOCNUM WITH (NOLOCK)  WHERE LOGICALREF ={logicalref} AND FIRMID='{firmaNo}')+1 
                                     WHERE LOGICALREF={logicalref} AND FIRMID='{firmaNo}';";
                db.Database.ExecuteSqlCommand(RefNoArttir);
                return ReferansNo.CODE.ToString().PadLeft(12, '0');
            }
        }
        public static int CalculateChecksum(string code)
        {
            if (code == null || code.Length != 12)
                throw new ArgumentException("Code length should be 12, i.e. excluding the checksum digit");

            int sum = 0;
            for (int i = 0; i < 12; i++)
            {
                int v;
                if (!int.TryParse(code[i].ToString(), out v))
                    throw new ArgumentException("Invalid character encountered in specified code.");
                sum += (i % 2 == 0 ? v : v * 3);
            }
            int check = 10 - (sum % 10);
            return check % 10;
        }
        public double FirmaTevkifatLimitiCek(string firma)
        {
            double tutar = 1;
            using (LogoContext db = new LogoContext())
            {
                string sql = $@"SELECT TOP 1 LGMAIN.DEDUCTLIMIT FROM LG_{Convert.ToInt32(firma).ToString("000")}_DEDUCTLIMITS LGMAIN  ORDER BY LGMAIN.ENDDATE DESC";
                tutar = db.Database.SqlQuery<double>(sql).FirstOrDefault();
            }
            return tutar;
        }
        public double RatesTarihDovizKuruDondur(LOGO_XERO_PARAMETRELER parametre, L_CAPIFIRM firmaBilgi, short? dovizkodu, DateTime tarih, string firma, string donem)
        {
            double dovizKuru;
            string dovizKuruSql = "";

            using (LogoContext db = new LogoContext())
            {
                if (firmaBilgi.SEPEXCHTABLE == 0)
                {
                    dovizKuruSql = $@"SELECT RATES{parametre.KULLANILACAKDOVIZTURU} FROM L_DAILYEXCHANGES WHERE CRTYPE={dovizkodu} AND EDATE='{tarih.ToString("yyyy-MM-dd")}'";
                }
                else
                {
                    dovizKuruSql = $@"SELECT RATES{parametre.KULLANILACAKDOVIZTURU} FROM LG_EXCHANGE_{firma} WHERE CRTYPE={dovizkodu} AND EDATE='{tarih.ToString("yyyy-MM-dd")}'";
                }

                dovizKuru = db.Database.SqlQuery<double>(dovizKuruSql).FirstOrDefault();
                return dovizKuru;
            }
        }
        public string[] PRCLISTgetir(string firma)
        {
            using (LogoContext db = new LogoContext())
            {
                string sql = $@"SELECT CYPHCODE FROM LG_{firma}_PRCLIST WHERE PTYPE=2 AND ACTIVE=0 GROUP BY CYPHCODE";

                string[] list = db.Database.SqlQuery<string>(sql).ToArray();
                return list;
            }


        }
        public List<LOGO_XERO_STOKLISTESI_STOK_ARA> BarkodStokKoduStokAra(string kod, string firma, string donem)
        {
            using (LogoContext db = new LogoContext())
            {
                string sql = $@"SELECT I.LOGICALREF, I.SPECODE OZELKOD,I.CODE STOKKODU,I.NAME STOKCINSI, I.NAME3 ACIKLAMA3,I.NAME4 ACIKLAMA4, M.DESCR MARKA,
I.SPECODE OZELKOD1,(SELECT TOP 1 DEFINITION_ FROM LG_{firma}_SPECODES With (Nolock) WHERE SPECODE=I.SPECODE AND SPETYP1=1 AND CODETYPE=1 AND SPECODETYPE=1) OZKODACIKLAMA, 
I.SPECODE2 OZELKOD2,I.SPECODE3 OZELKOD3,I.SPECODE4 OZELKOD4,I.SPECODE5 OZELKOD5,I.CYPHCODE YETKIKODU,I.VAT [KDV],
ISNULL((SELECT SUM(ONHAND) FROM LV_{firma}_{donem}_STINVTOT WITH (NOLOCK) WHERE STOCKREF=I.LOGICALREF AND INVENNO=-1),0) STOKBAKIYE,
ISNULL((SELECT TOP 1 MINLEVEL FROM LG_{firma}_INVDEF With (Nolock) WHERE ITEMREF = I.LOGICALREF), 0) AS MINMIKTAR,I.TRACKTYPE LOTTID,
ISNULL((SELECT TOP 1 PRICE FROM LG_{firma}_PRCLIST P WHERE P.CYPHCODE='' AND P.CARDREF=I.LOGICALREF AND P.PTYPE=2 AND P.ACTIVE=0),0)[PRKSATISFIYATI],
(SELECT TOP 1 GROSSVOLUME FROM LG_{firma}_ITMUNITA With (Nolock) WHERE ITEMREF=I.LOGICALREF) DESI,
ISNULL(I.CANDEDUCT,0) [TEVKIFAT], I.DEDUCTCODE [TEVKIFATKODU], I.SALEDEDUCTPART1 [TEVKIFATCARPAN], I.SALEDEDUCTPART2 [TEVKIFATBOLEN],I.UNITSETREF,ISNULL(KDVDURUMU,0) KDVDURUMU,DOVIZKODU, ISNULL(LISTEFIYATI,0)LISTEFIYATI, DOVIZ.DOVIZ,BIRIM
FROM LG_{firma}_ITEMS I With (Nolock)
LEFT OUTER JOIN LG_{firma}_MARK M WITH(NOLOCK) ON I.MARKREF=M.LOGICALREF
LEFT OUTER JOIN LG_{firma}_UNITBARCODE UB WITH (NOLOCK) ON UB.ITEMREF = I.LOGICALREF
OUTER APPLY ((SELECT TOP 1 PRICE LISTEFIYATI,INCVAT KDVDURUMU,CURRENCY DOVIZKODU FROM LG_{firma}_PRCLIST P WITH(NOLOCK) WHERE P.CYPHCODE='' AND P.CARDREF=I.LOGICALREF AND P.PTYPE=2 AND P.ACTIVE=0))FIYATLISTESI
OUTER APPLY ((SELECT TOP 1 CURCODE DOVIZ FROM L_CURRENCYLIST WITH(NOLOCK)  WHERE CURTYPE=FIYATLISTESI.DOVIZKODU AND FIRMNR={firma}))DOVIZ
OUTER APPLY(select TOP 1 CODE BIRIM From LG_{firma}_UNITSETL WITH(NOLOCK) where LG_{firma}_UNITSETL.UNITSETREF=I.UNITSETREF AND MAINUNIT=1)BIRIM
WHERE I.ACTIVE=0 AND  I.CARDTYPE <>22 AND (I.CODE = '{kod}' OR UB.BARCODE = '{kod}')";

                List<LOGO_XERO_STOKLISTESI_STOK_ARA> satir = db.Database.SqlQuery<LOGO_XERO_STOKLISTESI_STOK_ARA>(sql).ToList();
                return satir;
            }
        }
        public List<LOGO_XERO_CARILISTE> CariGetir(string kod, string firma, string donem)
        {
            using (LogoContext db = new LogoContext())
            {
                string sql = $@"WITH CARILISTE AS (
SELECT C.LOGICALREF,C.CODE,DEFINITION_,C.SPECODE OZELKOD1,C.SPECODE2 OZELKOD2,C.SPECODE3 OZELKOD3,C.SPECODE4 OZELKOD4,C.SPECODE5 OZELKOD5,C.NAME ADI, C.SURNAME SOYADI,
C.ADDR1 as [ADRES1],C.ADDR2 as [ADRES2],C.TRADINGGRP TICARIISLEMGURUBU, C.TELNRS1 as [TELEFON1], C.TELNRS2 as [TELEFON2],C.COUNTRY ULKE, C.COUNTRYCODE ULKEKODU, C.CITY [SEHIR],C.TOWN ILCE, C.TAXOFFICE VERGIDAIRESI, C.CARDTYPE,
C.TCKNO, C.FAXNR, C.POSTCODE POSTAKODU, C.TAXNR,C.INCHARGE [YETKILISI], C.CYPHCODE YETKIKODU, ISNULL(C.ACCEPTEINV,0) EFATURA, C.EMAILADDR EPOSTA,
C.EMAILADDR2 EPOSTA2, C.EMAILADDR3 EPOSTA3 ,C.ISPERSCOMP SAHISSIRKETI,C.PAYMENTREF,
CAST(CAST(ISNULL((SELECT SUM(DEBIT)-SUM(CREDIT) FROM LV_{firma}_{donem}_GNTOTCL WITH (NOLOCK) WHERE CARDREF=C.LOGICALREF AND TOTTYP=1),0)AS decimal(18,3))AS float) AS [BAKIYE]
FROM LG_{firma}_CLCARD C WHERE C.ACTIVE=0 AND C.CARDTYPE<>22 )
SELECT * FROM CARILISTE
OUTER APPLY(SELECT TOP 1 EM.CODE MUHASEBEKODU FROM LG_{firma}_CRDACREF C WITH (NOLOCK)
LEFT OUTER JOIN LG_{firma}_EMUHACC EM WITH (NOLOCK) ON C.ACCOUNTREF=EM.LOGICALREF
WHERE C.CARDREF=CARILISTE.LOGICALREF AND C.TRCODE=5)MUSAHEBEBILGILERI
OUTER APPLY(SELECT TOP 1 CODE ODEMEPLANKODU,DEFINITION_ ODEMEPLANI FROM LG_{firma}_PAYPLANS P WITH (NOLOCK)
WHERE P.LOGICALREF=CARILISTE.PAYMENTREF)ODEMEBILGILERI WHERE (CODE = '{kod}' OR TELEFON1 = '{kod}' OR TELEFON2 = '{kod}' OR TCKNO = '{kod}' OR TAXNR = '{kod}')";

                List<LOGO_XERO_CARILISTE> liste = db.Database.SqlQuery<LOGO_XERO_CARILISTE>(sql).ToList();
                return liste;
            }
        }
        public List<STOKLISTESIDEPOBAKIYELERI> StokDepoBakiyesi(int stokLogicalRef, string firma, string donem)
        {
            using (LogoContext db = new LogoContext())
            {
                string sql = $@"SELECT CW.NAME AMBAR, CAST(ISNULL((SELECT SUM(ONHAND) FROM LV_{firma}_{donem}_STINVTOT ST WITH (NOLOCK) WHERE ST.STOCKREF = IT.LOGICALREF AND INVENNO = CW.NR), 0) AS FLOAT) DEPODAKIBAKIYE
                FROM LG_{firma}_ITEMS IT WITH (NOLOCK)
                CROSS JOIN L_CAPIWHOUSE CW WITH (NOLOCK)
                WHERE IT.LOGICALREF = {stokLogicalRef} AND CW.FIRMNR = {Convert.ToInt16(firma)}";
                List<STOKLISTESIDEPOBAKIYELERI> liste = db.Database.SqlQuery<STOKLISTESIDEPOBAKIYELERI>(sql).ToList();
                return liste;
            }
        }
        public List<STOKLISTESISTOKSATISFIYATLARI> StokSatisFiyatlari(int stokLogicalRef, string firma)
        {
            using (LogoContext db = new LogoContext())
            {
                string sql = $@"select P.CYPHCODE YETKIKODU, P.CLSPECODE CARIHOZELKOD,P.DEFINITION_ ACIKLAMA,CASE WHEN P.INCVAT=0 THEN 'Hariç' else 'Dahil' end as KDV ,P.CURRENCY DOVIZKODU, (SELECT TOP (1) CURCODE FROM  L_CURRENCYLIST WITH (Nolock) WHERE (CURTYPE =P.CURRENCY ) AND (FIRMNR = {Convert.ToInt16(firma)})) AS DOVIZ, ISNULL(P.PRICE,0) FIYAT from LG_{firma}_ITEMS IT WITH (NOLOCK)
                  INNER JOIN LG_{firma}_PRCLIST P WITH (NOLOCK) ON IT.LOGICALREF=P.CARDREF
                  WHERE IT.LOGICALREF='{stokLogicalRef}' AND P.PTYPE=2 AND P.ACTIVE=0";
                List<STOKLISTESISTOKSATISFIYATLARI> liste = db.Database.SqlQuery<STOKLISTESISTOKSATISFIYATLARI>(sql).ToList();
                return liste;
            }
        }
        public List<STOKLISTESIALISSATISHARK> StokAlisHareketleri(int stokLogicalRef, string firma, string donem)
        {
            using (LogoContext db = new LogoContext())
            {
                string sql = $@"SELECT CASE WHEN S.BILLED=0 THEN '' WHEN S.BILLED=1 THEN 'F' END as [FATURADURUMU], S.INVOICEREF, F.FICHENO [FISNO], S.STFICHEREF,
            CASE 
            WHEN S.TRCODE =1 then 'Satınalma İrsaliyesi'
            WHEN S.TRCODE =2 then 'Perakende İade İrsaliyesi'
            WHEN S.TRCODE =3 then 'Toptan Satış İade İrsaliyesi'
            WHEN S.TRCODE =4 then 'Alınan Hizmet Faturası'
            WHEN S.TRCODE =5 then 'Konsinye Giriş İrsaliyesi'
            WHEN S.TRCODE =6 then 'Satınalma İade İrsaliyesi'
            WHEN S.TRCODE =7 then 'Perakende Satış İrsaliyesi'
            WHEN S.TRCODE =8 then 'Toptan Satış İrsaliyesi'
            WHEN S.TRCODE =10 then 'Verilen Proforma Faturası'
            WHEN S.TRCODE =11 then 'Fire Fişi'
            WHEN S.TRCODE =12 then 'Sarf Fişi'
            WHEN S.TRCODE =13 AND S.SOURCELINK=0 then 'Üretimden Giriş Fişi'  WHEN S.TRCODE =13 AND S.SOURCELINK<>0 then 'Alınan Fiyat Farkı Faturası'
            WHEN S.TRCODE =14 AND S.SOURCELINK=0 then 'Devir Fişi'  WHEN S.TRCODE =14 AND S.SOURCELINK<>0 then 'Satış Fiyat Farkı Faturası'
            WHEN S.TRCODE =15 then 'Sayım Fişi'
            WHEN S.TRCODE =25 then 'Ambar Fişi'
            WHEN S.TRCODE =50 then 'Sayım Fazlası'
            WHEN S.TRCODE =51 then 'Sayım Eksiği'
            ELSE '' END [FISTURU],
            C.CODE, C.DEFINITION_ CARI, S.DATE_ [TARIH],
            I.CODE [STOKKODU],I.NAME [STOKCINSI],S.AMOUNT MIKTAR,
            (SELECT TOP 1  CODE FROM LG_{firma}_UNITSETL WHERE LOGICALREF = S.UOMREF) [BIRIM],
            ISNULL(((NULLIF((S.LINENET),0)+S.DIFFPRICE)/NULLIF(S.AMOUNT,0)),0) FIYAT,
CASE WHEN S.TRCURR=0 THEN ISNULL(((NULLIF((S.LINENET),0)+S.DIFFPRICE)/NULLIF(S.AMOUNT,0)),0) ELSE ISNULL(((NULLIF((S.LINENET),0)+S.DIFFPRICE)/NULLIF(S.AMOUNT,0)),0) / S.TRRATE END AS DOVIZBIRIMFIYAT,
             CASE WHEN S.TRCURR=0 THEN 'TL' ELSE CUR.CURCODE END AS DOVIZTURU,
			 S.VATAMNT [KDV], S.LINENET+S.DIFFPRICE TUTAR,
			CASE WHEN S.TRCURR=0 THEN S.LINENET+S.DIFFPRICE ELSE (S.LINENET+S.DIFFPRICE) / S.TRRATE END AS DOVIZTUTAR
            FROM LG_{firma}_{donem}_STLINE S With (Nolock) 
           LEFT OUTER JOIN L_CURRENCYLIST CUR ON S.TRCURR=CUR.CURTYPE AND CUR.FIRMNR = {Convert.ToInt16(firma)}
            LEFT OUTER JOIN LG_{firma}_{donem}_INVOICE F ON S.INVOICEREF=F.LOGICALREF
            LEFT OUTER JOIN LG_{firma}_CLCARD C ON S.CLIENTREF=C.LOGICALREF
            LEFT OUTER JOIN LG_{firma}_ITEMS I ON S.STOCKREF=I.LOGICALREF
            WHERE S.TRCODE IN (1) AND I.LOGICALREF = {stokLogicalRef} AND S.CANCELLED=0
            ORDER BY S.DATE_ DESC,S.FTIME DESC;";

                List<STOKLISTESIALISSATISHARK> liste = db.Database.SqlQuery<STOKLISTESIALISSATISHARK>(sql).ToList();
                return liste;
            }
        }
        public List<STOKLISTESIALISSATISHARK> StokSatisHareketleri(int stokLogicalRef, string firma, string donem)
        {
            using (LogoContext db = new LogoContext())
            {
                string sql = $@"SELECT CASE WHEN S.BILLED=0 THEN '' WHEN S.BILLED=1 THEN 'F' END as [FATURADURUMU], S.INVOICEREF, F.FICHENO [FISNO], S.STFICHEREF,
            CASE 
            WHEN S.TRCODE =1 then 'Satınalma İrsaliyesi'
            WHEN S.TRCODE =2 then 'Perakende İade İrsaliyesi'
            WHEN S.TRCODE =3 then 'Toptan Satış İade İrsaliyesi'
            WHEN S.TRCODE =4 then 'Alınan Hizmet Faturası'
            WHEN S.TRCODE =5 then 'Konsinye Giriş İrsaliyesi'
            WHEN S.TRCODE =6 then 'Satınalma İade İrsaliyesi'
            WHEN S.TRCODE =7 then 'Perakende Satış İrsaliyesi'
            WHEN S.TRCODE =8 then 'Toptan Satış İrsaliyesi'
            WHEN S.TRCODE =10 then 'Verilen Proforma Faturası'
            WHEN S.TRCODE =11 then 'Fire Fişi'
            WHEN S.TRCODE =12 then 'Sarf Fişi'
            WHEN S.TRCODE =13 AND S.SOURCELINK=0 then 'Üretimden Giriş Fişi'  WHEN S.TRCODE =13 AND S.SOURCELINK<>0 then 'Alınan Fiyat Farkı Faturası'
            WHEN S.TRCODE =14 AND S.SOURCELINK=0 then 'Devir Fişi'  WHEN S.TRCODE =14 AND S.SOURCELINK<>0 then 'Satış Fiyat Farkı Faturası'
            WHEN S.TRCODE =15 then 'Sayım Fişi'
            WHEN S.TRCODE =25 then 'Ambar Fişi'
            WHEN S.TRCODE =50 then 'Sayım Fazlası'
            WHEN S.TRCODE =51 then 'Sayım Eksiği'
            ELSE '' END [FISTURU],
            C.CODE, C.DEFINITION_ CARI, S.DATE_ [TARIH],
            I.CODE [STOKKODU],I.NAME [STOKCINSI],S.AMOUNT MIKTAR,
            (SELECT TOP 1  CODE FROM LG_{firma}_UNITSETL WHERE LOGICALREF = S.UOMREF) [BIRIM],
            ISNULL(((NULLIF((S.LINENET),0)+S.DIFFPRICE)/NULLIF(S.AMOUNT,0)),0) FIYAT,
CASE WHEN S.TRCURR=0 THEN ISNULL(((NULLIF((S.LINENET),0)+S.DIFFPRICE)/NULLIF(S.AMOUNT,0)),0) ELSE ISNULL(((NULLIF((S.LINENET),0)+S.DIFFPRICE)/NULLIF(S.AMOUNT,0)),0) / S.TRRATE END AS DOVIZBIRIMFIYAT,
             CASE WHEN S.TRCURR=0 THEN 'TL' ELSE CUR.CURCODE END AS DOVIZTURU,
			 S.VATAMNT [KDV], S.LINENET+S.DIFFPRICE TUTAR,
			CASE WHEN S.TRCURR=0 THEN S.LINENET+S.DIFFPRICE ELSE (S.LINENET+S.DIFFPRICE) / S.TRRATE END AS DOVIZTUTAR
            FROM LG_{firma}_{donem}_STLINE S With (Nolock) 
           LEFT OUTER JOIN L_CURRENCYLIST CUR ON S.TRCURR=CUR.CURTYPE AND CUR.FIRMNR = {Convert.ToInt16(firma)}
            LEFT OUTER JOIN LG_{firma}_{donem}_INVOICE F ON S.INVOICEREF=F.LOGICALREF
            LEFT OUTER JOIN LG_{firma}_CLCARD C ON S.CLIENTREF=C.LOGICALREF
            LEFT OUTER JOIN LG_{firma}_ITEMS I ON S.STOCKREF=I.LOGICALREF
            WHERE S.TRCODE IN (7,8) AND I.LOGICALREF = {stokLogicalRef} AND S.CANCELLED=0
            ORDER BY S.DATE_ DESC,S.FTIME DESC;";

                List<STOKLISTESIALISSATISHARK> liste = db.Database.SqlQuery<STOKLISTESIALISSATISHARK>(sql).ToList();
                return liste;
            }
        }
        public List<byte[]> StokResimGetir(int stokLogicalRef, string firma)
        {
            using (LogoContext db = new LogoContext())
            {
                string stokResimleriSql = $@" SELECT LDATA FROM LG_{firma}_FIRMDOC WHERE INFOREF={stokLogicalRef} AND DOCTYP=0 AND INFOTYP=20";
                var ldata = db.Database.SqlQuery<byte[]>(stokResimleriSql).ToList();

                return ldata;
            }
        }
        public bool TeklifMailGonder(LOGO_XERO_PARAMETRELER parametre, LOGO_XERO_KULLANICILAR kullanici, string kime, string mailcc, string personelMail, string konu, string aciklama, string dosyaAdi)
        {
            try
            {
                using (MailMessage mail = new MailMessage(kullanici.EPOSTA, kime))
                {
                    if (!string.IsNullOrWhiteSpace(mailcc)) mail.To.Add(mailcc);
                    mail.Subject = konu;
                    mail.IsBodyHtml = true;
                    mail.Body = aciklama;
                    if (dosyaAdi != null)
                        mail.Attachments.Add(new Attachment(dosyaAdi));
                    SmtpClient smtp = new SmtpClient();
                    smtp.Port = Convert.ToInt32(parametre.MAILPORT);
                    smtp.Host = parametre.MAILSERVER;
                    smtp.EnableSsl = Convert.ToBoolean(parametre.SSLGEREKLIMI);
                    System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                    NetworkCred.UserName = personelMail;
                    NetworkCred.Password = kullanici.MAILSIFRE;
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    try
                    {
                        smtp.Send(mail);
                        return true;
                    }
                    catch (Exception EX)
                    {
                        XtraMessageBox.Show("AÇIKLAMA: " + EX.Message, "HATA OLUŞTU", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("AÇIKLAMA: " + ex.Message, "HATA OLUŞTU", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool KullaniciSayfaTasarimlariTemizle(int KullaniciId)
        {
            try
            {
                using (LogoContext db = new LogoContext())
                {
                    string sql = $@"DELETE from LOGO_XERO_TASARIMLAR WITH (NOLOCK)  WHERE PERSONELID = {Convert.ToInt32(KullaniciId)}";
                    db.Database.ExecuteSqlCommand(sql);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        static bool EmailKontrol(string email)
        {
            const string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                    @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                    @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            return new Regex(strRegex).IsMatch(email);
        }
        public LOGO_XERO_PARAMETRELER ParametreAl(string firma, string donem)
        {
            using (LogoContext db = new LogoContext())
            {
                return db.LOGO_XERO_PARAMETRELER.Where(s => s.FIRMANO == firma && s.DONEMNO == donem).FirstOrDefault();
            }
        }
        public string[] LockKontrol(int modulno, int referanskod)
        {
            List<LOGO_XERO_LOCK> locklist = new List<LOGO_XERO_LOCK>();
            using (LogoContext db = new LogoContext())
            {

                List<LOGO_XERO_LOCK> Kullanici = db.LOGO_XERO_LOCK.Where(s => s.MODUL == modulno && s.REFERANS == referanskod).ToList();
                if (Kullanici != null)
                {
                    if (Kullanici.Count == 0)
                    {
                        return new string[] { "true" };
                    }
                    else
                    {
                        int idd = Kullanici.FirstOrDefault().KULID;
                        var pr = db.LOGO_XERO_KULLANICILAR.Where(s => s.ID == idd).FirstOrDefault();
                        if (pr != null)
                        {
                            string pers = pr.KULLANICIADI;

                            return new string[] { "false", pers };
                        }
                        else
                        {
                            return new string[] { "true" };
                        }

                    }
                }
                else
                {
                    return new string[] { "true" };
                }
            }
        }
        public void pageLock(int modulno, int referanskod, int kullaniciID)
        {
            using (LogoContext db = new LogoContext())
            {
                LOGO_XERO_LOCK kilit = new LOGO_XERO_LOCK();
                try
                {
                    kilit.KULID = kullaniciID;
                    kilit.MODUL = modulno;
                    kilit.REFERANS = referanskod;
                    db.LOGO_XERO_LOCK.Add(kilit);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                }
            }
        }
        public void pageLockDelete(int modulno, int referanskod)
        {
            using (LogoContext db = new LogoContext())
            {
                try
                {
                    var ob = db.LOGO_XERO_LOCK.Where(s => s.MODUL == modulno && s.REFERANS == referanskod).FirstOrDefault();
                    if (ob != null)
                    {
                        db.LOGO_XERO_LOCK.Remove(ob);
                        db.SaveChanges();
                    }

                }
                catch (Exception ex)
                {

                }
            }
        }
        public LG_ITMUNITA StokBirimBilgiGetir(int birimSatirref, int stokref)
        {
            using (LogoContext db = new LogoContext())
            {
                return db.LG_ITMUNITA.Where(s => s.UNITLINEREF == birimSatirref && s.ITEMREF == stokref).FirstOrDefault();
            }

        }
        public LG_UNITSETF BirimSetiGetir(int birimref)
        {
            using (LogoContext db = new LogoContext())
            {
                return db.LG_UNITSETF.Where(s => s.LOGICALREF == birimref).FirstOrDefault();
            }

        }
        public LG_UNITSETL SeciliBirimGetir(int birimref)
        {
            using (LogoContext db = new LogoContext())
            {
                LG_UNITSETL birim = db.LG_UNITSETL.Where(s => s.LOGICALREF == birimref).FirstOrDefault();
                birim.GROSSVOLUME = 0;
                birim.GROSSWEIGHT = 0;
                birim.DEGISTI = 0;
                return birim;
            }

        }
        public List<LG_UNITSETL> BiriminAltBirimleriniListele(int birimref)
        {
            using (LogoContext db = new LogoContext())
            {
                List<LG_UNITSETL> liste = db.LG_UNITSETL.Where(s => s.UNITSETREF == birimref).OrderBy(s => s.LINENR).ToList();
                liste.ForEach(s => { s.GROSSVOLUME = 0; s.GROSSWEIGHT = 0; s.DEGISTI = 0; });
                return liste;
            }

        }
        public List<BIRIM_BOYUTLAR> StokKartiBoyutBirimleri(string firma, string donem, int tip)
        {
            using (LogoContext db = new LogoContext())
            {
                //tip 4 ağırlık
                //tip 3 hacim
                //tip 2 alan
                //tip 1 uzunluk
                string sql = $@"SELECT 
LOGICALREF, CODE, NAME, UNITSETREF, LINENR, MAINUNIT, CONVFACT1, CONVFACT2, WIDTH, LENGTH, HEIGHT, AREA, VOLUME_, WEIGHT, WIDTHREF, LENGTHREF, HEIGHTREF, AREAREF, VOLUMEREF, WEIGHTREF, DIVUNIT, MEASURECODE, GLOBALCODE
 FROM 
LG_{firma}_UNITSETL WITH(NOLOCK) 
 WHERE 
(((UNITSETREF = {tip}) AND (LINENR >= 0)) OR ((UNITSETREF > {tip}))) AND (((UNITSETREF <= {tip})))

ORDER BY 
UNITSETREF, LINENR";
                return db.Database.SqlQuery<BIRIM_BOYUTLAR>(sql).ToList();
            }

        }
        public List<KODAD> AnaEkranAdetListesi(string firma, string donem, int kullaniciid)
        {
            using (LogoContext db = new LogoContext())
            {
                string sql = $@"SELECT 'OT' NAME, CAST(ISNULL((SELECT COUNT(ID) FROM LOGO_XERO_TEKLIF_BASLIK_{firma} WHERE (ONAYDURUMU=1 OR ONAYDURUMU=3) AND ONAYLAYANID={kullaniciid} AND ONAYAGONDERIM=1 ),0)AS INT) CODE
UNION ALL
SELECT 'OBSS' NAME, CAST(ISNULL((SELECT COUNT(LOGICALREF) FROM LG_{firma}_{donem}_ORFICHE WHERE TRCODE=1 AND STATUS=1 AND CANCELLED=0),0)AS INT) CODE
UNION ALL
SELECT 'OBAS' NAME, CAST(ISNULL((SELECT COUNT(LOGICALREF) FROM LG_{firma}_{donem}_ORFICHE WHERE TRCODE=2 AND STATUS=1 AND CANCELLED=0),0)AS INT) CODE
UNION ALL
SELECT 'AMS' NAME, CAST(ISNULL((SELECT COUNT(LOGICALREF) FROM LG_{firma}_CLCARD WHERE ACTIVE=0),0)AS INT) CODE";
                return db.Database.SqlQuery<KODAD>(sql).ToList();
            }
        }

        public List<KODAD> AnaEkranDashAdetGetir(string firma, string donem)
        {
            using (LogoContext db = new LogoContext())
            {
                string sql = $@" 
select CAST(ISNULL((select COUNT(ID) from LOGO_XERO_TEKLIF_BASLIK_{firma} where TRCODE = 8 ),0)AS INT) CODE, 'SATISTEKLIF' NAME
UNION ALL
select CAST(ISNULL((select COUNT(ID) from LOGO_XERO_TEKLIF_BASLIK_{firma}  where TRCODE = 1),0)AS INT) CODE, 'ALISTEKLIF' NAME
UNION ALL
select CAST(ISNULL((select COUNT(ID) from LOGO_XERO_TEKLIF_BASLIK_{firma} where TRCODE = 1 and ONAYDURUMU = 2),0)AS INT) CODE, 'ALISTEKLIFONAYLANAN'  NAME
UNION ALL
select CAST(ISNULL((select COUNT(ID) from LOGO_XERO_TEKLIF_BASLIK_{firma}  where TRCODE = 8 and ONAYDURUMU = 2),0)AS INT) CODE,	'SATISTEKLIFONAYLANAN'  NAME
UNION ALL
select CAST(ISNULL((select COUNT(LOGICALREF) from LG_{firma}_{donem}_INVOICE  where TRCODE IN(7,8,9,6,10,14)),0)AS INT) CODE, 'FATURASATIS'  NAME
UNION ALL
select CAST(ISNULL((select COUNT(LOGICALREF) from LG_{firma}_{donem}_INVOICE  where TRCODE IN(1,4,2,3,13,26)),0)AS INT) CODE, 'FATURAALIS'  NAME
UNION ALL
select CAST(ISNULL((SELECT COUNT(LOGICALREF) FROM LG_{firma}_{donem}_ORFICHE WHERE TRCODE=1 ),0)AS INT) CODE, 'SIPARISSATIS'  NAME
UNION ALL
select CAST(ISNULL((SELECT COUNT(LOGICALREF) FROM LG_{firma}_{donem}_ORFICHE  WHERE TRCODE=2),0)AS INT) CODE,  'SIPARISALIS'  NAME  ";
                return db.Database.SqlQuery<KODAD>(sql).ToList();
            }
        }

        public List<TEKLIF_LISTESI_M> urunteklifgetir(string firma, string stokKodu)
        {
            List<TEKLIF_LISTESI_M> liste = new List<TEKLIF_LISTESI_M>();
            using (LogoContext db = new LogoContext())
            {
                string sql = $@" SELECT T.TARIH, T.TEKLIFNO, T.CARIUNVANI, S.STOKKODU, S.STOKADI,S.BIRIM,S.MIKTAR,
            S.FIYAT,S.KDV, ISNULL(S.ISKONTOYUZDESI1,0)  ISKONTOYUZDESI1, ISNULL(S.ISKONTOYUZDESI2,0)  ISKONTOYUZDESI2, ISNULL(S.ISKONTOYUZDESI3,0) ISKONTOYUZDESI3, 
            S.ISKONTOLUTUTAR TUTAR,
            S.DOVIZLIFIYAT,S.DOVIZLIFIYAT*S.MIKTAR DOVIZLITOPLAMFIYAT,
			CASE WHEN S.SATIRDOVIZKODU=0 THEN 'TL' ELSE CUR.CURCODE END AS DOVIZTURU
            FROM  LOGO_XERO_TEKLIF_SATIR_{firma} S
			LEFT OUTER JOIN L_CURRENCYLIST CUR ON S.SATIRDOVIZKODU=CUR.CURTYPE AND CUR.FIRMNR={firma}
            LEFT OUTER JOIN LOGO_XERO_TEKLIF_BASLIK_{firma} T ON S.TEKLIFID=T.ID
            WHERE S.STOKKODU='{stokKodu}'  --isyerifiltresi ambarfiltresi 
            ORDER BY T.TARIH ";
                liste = db.Database.SqlQuery<TEKLIF_LISTESI_M>(sql).ToList();
            }
            return liste;
        }

        public List<STOK_LOT_BILGISI> stokLotBilgiGetir(string firma, string donem, int stoklogicalref)
        {
            List<STOK_LOT_BILGISI> liste = new List<STOK_LOT_BILGISI>();
            using (LogoContext db = new LogoContext())
            {
                string sql = $@"SELECT L.CODE [KOD],L.NAME [ACIKLAMA],
                         (SELECT SUM(AMOUNT) FROM  LG_{firma}_{donem}_SLTRANS  WHERE SLREF = L.LOGICALREF AND IOCODE IN(1,2) AND INVENNO=CP.NR) [GIRIS],
                         (SELECT SUM(REMAMOUNT) FROM  LG_{firma}_{donem}_SLTRANS  WHERE SLREF = L.LOGICALREF AND IOCODE IN(1,2) AND INVENNO=CP.NR) [STOKBAKIYESI],CP.NAME [AMBARADI]
                         FROM LG_{firma}_{donem}_SERILOTN L
                         CROSS JOIN L_CAPIWHOUSE CP  
                         WHERE CP.FIRMNR={firma} AND L.LOGICALREF IN (SELECT SLREF FROM LG_{firma}_{donem}_SLTRANS WHERE ITEMREF= {stoklogicalref} AND REMAMOUNT >0 AND INVENNO=CP.NR)";
                liste = db.Database.SqlQuery<STOK_LOT_BILGISI>(sql).ToList();
            }
            return liste;
        }
        public List<STOK_FIYATLISTESI_MODELI> stokTanimliAlisSatisFiyatlar(string firma, int trkod, int stoklogicalref)
        {
            List<STOK_FIYATLISTESI_MODELI> liste = new List<STOK_FIYATLISTESI_MODELI>();
            using (LogoContext db = new LogoContext())
            {
                string sql = $@"select cast(ISNULL(P.INCVAT,0) as bit) KDVDAHIL,P.CYPHCODE YETKIKODU, P.CLSPECODE CARIHESAPOZELKOD,P.DEFINITION_ ACIKLAMA,
CASE WHEN P.INCVAT=0 THEN 'Hariç' else 'Dahil' end as KDV ,(select TOP 1 CURCODE from L_CURRENCYLIST WHERE CURTYPE=P.CURRENCY AND FIRMNR={Convert.ToInt32(firma)})DOVIZ,
ISNULL(P.PRICE,0) FIYAT,P.CURRENCY  from  LG_{firma}_PRCLIST P
 WHERE P.CARDREF={stoklogicalref} AND P.PTYPE={trkod} AND P.ACTIVE=0";
                liste = db.Database.SqlQuery<STOK_FIYATLISTESI_MODELI>(sql).ToList();
            }
            return liste;
        }


        public List<STOK_SON10_ALISSATIS> urunSon10AlisSatisGetir(string firma, string donem, string stokKodu, string trkod)
        {
            List<STOK_SON10_ALISSATIS> liste = new List<STOK_SON10_ALISSATIS>();
            using (LogoContext db = new LogoContext())
            {
                string sql = $@"SELECT TOP 20
            F.DATE_ [TARIH], 
            CASE 
            WHEN S.TRCODE =1 then 'Satınalma Faturası'
            WHEN S.TRCODE =2 then 'Perakende İade Faturası'
            WHEN S.TRCODE =3 then 'Toptan Satış İade Faturası'
            WHEN S.TRCODE =4 then 'Alınan Hizmet Faturası'
            WHEN S.TRCODE =5 then 'Konsinye Giriş İrsaliyesi'
            WHEN S.TRCODE =6 then 'Satınalma İade Faturası'
            WHEN S.TRCODE =7 then 'Perakende Satış Faturası'
            WHEN S.TRCODE =8 then 'Toptan Satış Faturası'
            WHEN S.TRCODE =10 then 'Verilen Proforma Faturası'
            WHEN S.TRCODE =11 then 'Fire Fişi'
            WHEN S.TRCODE =12 then 'Sarf Fişi'
            WHEN S.TRCODE =13 then 'Üretimden Giriş Fişi'
            WHEN S.TRCODE =14 then 'Devir Fişi'
            WHEN S.TRCODE =15 then 'Sayım Fişi'
            WHEN S.TRCODE =25 then 'Ambar Fişi'
            WHEN S.TRCODE =50 then 'Sayım Fazlası'
            WHEN S.TRCODE =51 then 'Sayım Eksiği'
            ELSE '' END [FISTURU],C.CODE CARIKODU,
            C.DEFINITION_ [CARIUNVANI],  S.AMOUNT [ADET],
            ISNULL(((NULLIF((S.LINENET),0)+S.DIFFPRICE)/NULLIF(S.AMOUNT,0)),0) FIYAT,
            CASE WHEN S.TRCURR=0 THEN ISNULL(((NULLIF((S.LINENET),0)+S.DIFFPRICE)/NULLIF(S.AMOUNT,0)),0) ELSE ISNULL(((NULLIF((S.LINENET),0)+S.DIFFPRICE)/NULLIF(S.AMOUNT,0)),0) / S.TRRATE END AS DOVIZBIRIMFIYAT,
            CASE WHEN S.TRCURR=0 THEN 'TL' ELSE CUR.CURCODE END AS [DOVIZTIPI],S.VAT KDV,  S.VATAMNT [KDVTUTARI],S.LINENET+S.DIFFPRICE TUTAR,
	        CASE WHEN S.TRCURR=0 THEN S.LINENET+S.DIFFPRICE ELSE (S.LINENET+S.DIFFPRICE) / S.TRRATE END AS DOVIZTUTAR,
            S.LINENET+S.DIFFPRICE+S.VATAMNT [TOPLAMTUTAR]
            FROM LG_{firma}_{donem}_STLINE S
            LEFT OUTER JOIN L_CURRENCYLIST CUR ON S.TRCURR=CUR.CURTYPE AND CUR.FIRMNR={Convert.ToInt32(firma)}
            LEFT OUTER JOIN LG_{firma}_{donem}_INVOICE F ON S.INVOICEREF=F.LOGICALREF
            LEFT OUTER JOIN LG_{firma}_ITEMS I ON S.STOCKREF=I.LOGICALREF
            LEFT OUTER JOIN LG_{firma}_CLCARD C on F.CLIENTREF = C.LOGICALREF
            WHERE S.LINETYPE=0 AND I.CODE='{stokKodu}' AND {trkod} ORDER BY S.DATE_ DESC";
                liste = db.Database.SqlQuery<STOK_SON10_ALISSATIS>(sql).ToList();
            }
            return liste;
        }

        public List<SIPARIS_LISTESI_M> StokSiparisListe(string stokKodu, string firma, string donem, int trkod)
        {
            List<SIPARIS_LISTESI_M> liste = new List<SIPARIS_LISTESI_M>();
            using (LogoContext db = new LogoContext())
            {
                string sql = $@"SELECT S.DATE_ [TARIH], F.FICHENO [FISNO],C.CODE CARIKODU, C.DEFINITION_ [CARIUNVANI], S.AMOUNT [MIKTAR], S.PRICE [FIYAT],
            ISNULL((SELECT DISCPER FROM LG_{firma}_{donem}_ORFLINE WHERE ORDFICHEREF=S.ORDFICHEREF AND PARENTLNREF= S.LOGICALREF AND LINETYPE=2 ORDER BY LOGICALREF OFFSET (0) ROWS FETCH NEXT (1) ROWS ONLY),0) [ISK1], 
            ISNULL((SELECT DISCPER FROM LG_{firma}_{donem}_ORFLINE WHERE ORDFICHEREF=S.ORDFICHEREF AND PARENTLNREF= S.LOGICALREF AND LINETYPE=2 ORDER BY LOGICALREF OFFSET (1) ROWS FETCH NEXT (1) ROWS ONLY),0) [ISK2], 
            ISNULL((SELECT DISCPER FROM LG_{firma}_{donem}_ORFLINE WHERE ORDFICHEREF=S.ORDFICHEREF AND PARENTLNREF= S.LOGICALREF AND LINETYPE=2 ORDER BY LOGICALREF OFFSET (2) ROWS FETCH NEXT (1) ROWS ONLY),0) [ISK3], 
            (NULLIF(S.LINENET,0)/NULLIF(S.AMOUNT,0)) [NETFIYAT],
            S.VAT KDV, S.VATAMNT [KDVTUTARI],S.TOTAL [TUTAR], S.TOTAL+S.VATAMNT [TOPLAMTUTAR],
            CASE WHEN S.TRRATE=0 THEN FORMAT(ISNULL(S.PRICE,0),'N2') ELSE FORMAT(ISNULL(S.PRICE,0) / S.TRRATE,'N2') END AS DOVIZBIRIMFIYAT,
			CASE WHEN S.TRCURR=0 THEN 'TL' ELSE CUR.CURCODE END AS DOVIZTURU, 
			CASE WHEN S.TRCURR=0 THEN FORMAT(S.AMOUNT*S.PRICE,'N2') ELSE FORMAT((S.AMOUNT*S.PRICE) / S.TRRATE,'N2') END AS DOVIZTUTAR
            FROM LG_{firma}_{donem}_ORFLINE S
            LEFT OUTER JOIN L_CURRENCYLIST CUR ON S.TRCURR=CUR.CURTYPE AND CUR.FIRMNR={firma}
            LEFT OUTER JOIN LG_{firma}_{donem}_ORFICHE F ON S.ORDFICHEREF=F.LOGICALREF
            LEFT OUTER JOIN LG_{firma}_CLCARD C ON S.CLIENTREF=C.LOGICALREF
            LEFT OUTER JOIN LG_{firma}_ITEMS I ON S.STOCKREF=I.LOGICALREF
            WHERE F.TRCODE ={trkod} AND I.CODE='{stokKodu}' AND S.CANCELLED=0  ORDER BY S.DATE_";
                liste = db.Database.SqlQuery<SIPARIS_LISTESI_M>(sql).ToList();
            }
            return liste;
        }
        public List<FATURA_LISTESI_M> StokFaturaListe(string stokKodu, string firma, string donem, string trkod)
        {
            List<FATURA_LISTESI_M> liste = new List<FATURA_LISTESI_M>();
            using (LogoContext db = new LogoContext())
            {
                string sql = $@"SELECT S.DATE_ [TARIH], F.FICHENO [FISNO],C.CODE CARIKODU, C.DEFINITION_ [CARIUNVANI], S.AMOUNT [MIKTAR], S.PRICE [FIYAT],
            ISNULL((SELECT DISCPER FROM LG_{firma}_{donem}_STLINE WHERE INVOICEREF=S.INVOICEREF AND PARENTLNREF= S.LOGICALREF AND LINETYPE=2 ORDER BY LOGICALREF OFFSET (0) ROWS FETCH NEXT (1) ROWS ONLY),0) [ISK1], 
            ISNULL((SELECT DISCPER FROM LG_{firma}_{donem}_STLINE WHERE INVOICEREF=S.INVOICEREF AND PARENTLNREF= S.LOGICALREF AND LINETYPE=2 ORDER BY LOGICALREF OFFSET (1) ROWS FETCH NEXT (1) ROWS ONLY),0) [ISK2], 
            ISNULL((SELECT DISCPER FROM LG_{firma}_{donem}_STLINE WHERE INVOICEREF=S.INVOICEREF AND PARENTLNREF= S.LOGICALREF AND LINETYPE=2 ORDER BY LOGICALREF OFFSET (2) ROWS FETCH NEXT (1) ROWS ONLY),0) [ISK3], 
            (NULLIF(S.LINENET,0)/NULLIF(S.AMOUNT,0)) [NETFIYAT],
            S.VAT KDV,S.VATAMNT [KDVTUTARI],S.TOTAL [TUTAR], S.TOTAL+S.VATAMNT [TOPLAMTUTAR],
	        CASE WHEN S.TRCURR=0 THEN ISNULL(((NULLIF((S.LINENET),0)+S.DIFFPRICE)/NULLIF(S.AMOUNT,0)),0) ELSE ISNULL(((NULLIF((S.LINENET),0)+S.DIFFPRICE)/NULLIF(S.AMOUNT,0)),0) / S.TRRATE END AS DOVIZBIRIMFIYAT,
            CASE WHEN S.TRCURR=0 THEN 'TL' ELSE CUR.CURCODE END AS DOVIZTURU,
	        CASE WHEN S.TRCURR=0 THEN S.LINENET+S.DIFFPRICE ELSE (S.LINENET+S.DIFFPRICE) / S.TRRATE END AS DOVIZTUTAR
            FROM LG_{firma}_{donem}_STLINE S
            LEFT OUTER JOIN L_CURRENCYLIST CUR ON S.TRCURR=CUR.CURTYPE AND CUR.FIRMNR={firma}
            LEFT OUTER JOIN LG_{firma}_{donem}_INVOICE F ON S.INVOICEREF=F.LOGICALREF
            LEFT OUTER JOIN LG_{firma}_CLCARD C ON S.CLIENTREF=C.LOGICALREF
            LEFT OUTER JOIN LG_{firma}_ITEMS I ON S.STOCKREF=I.LOGICALREF
            WHERE F.TRCODE IN ({trkod}) AND I.CODE='{stokKodu}' AND S.BILLED=1 AND S.CANCELLED=0  ORDER BY S.DATE_";
                liste = db.Database.SqlQuery<FATURA_LISTESI_M>(sql).ToList();
            }
            return liste;

        }

        public List<STOKHAREKETLERI> UrunStokHareketleriYuruyen(string firma, string donem, string stokkodu, DateTime ilktarih, DateTime sontarih)
        {
            using (LogoContext db = new LogoContext())
            {
                string sql = $@" SET NOCOUNT ON
 IF(OBJECT_ID('tempdb..#GECICITABLO') IS NOT NULL) BEGIN DROP TABLE #GECICITABLO END ;
CREATE TABLE #GECICITABLO ( [FATURADURUMU] VARCHAR(1),[STFICHEREFERANS] INT,[STLINEREFERANS] INT,[FISNO] VARCHAR(100),[FISTURU] VARCHAR(65),
[BELGENO] VARCHAR(100),[STFICHETARIH] SMALLDATETIME,[STLINETARIH] SMALLDATETIME,[SAAT] nvarchar(250),
[CARIKODU] VARCHAR(100),[CARIUNVANI] VARCHAR(200),[STOKKODU] VARCHAR(250),[STOKADI] VARCHAR(250),[BIRIM] VARCHAR(15),
[GIRIS] VARCHAR(20),[CIKIS] VARCHAR(20),[GIRISCIKISTIP] VARCHAR(20),[GIRISAMBARI] VARCHAR(250),[CIKISAMBARI] varchar(250),
[MIKTAR] float,[KALAN] float,[TUTAR] float
)

 CREATE CLUSTERED INDEX IX_#GECICITABLO ON #GECICITABLO ([STOKKODU], [STLINETARIH], [MIKTAR])

INSERT INTO #GECICITABLO
([FATURADURUMU],[STFICHEREFERANS],[STLINEREFERANS],[FISNO],[FISTURU],[BELGENO],[STFICHETARIH],[STLINETARIH],[SAAT],
[CARIKODU],[CARIUNVANI],[STOKKODU],[STOKADI],[BIRIM],[GIRIS],[CIKIS],[GIRISCIKISTIP],[GIRISAMBARI],[CIKISAMBARI],
[MIKTAR],[KALAN],[TUTAR] )
SELECT LISTE.[FATURADURUMU],LISTE.[STFICHEREFERANS] ,LISTE.[STLINEREFERANS] ,LISTE.[FISNO],LISTE.[FISTURU],LISTE.[BELGENO],
LISTE.[STFICHETARIH],LISTE.[STLINETARIH],LISTE.[SAAT],LISTE.[CARIKODU],LISTE.[CARIUNVANI],LISTE.[STOKKODU],
LISTE.[STOKADI],LISTE.[BIRIM],LISTE.[GIRIS],LISTE.[CIKIS],LISTE.[GIRISCIKISTIP],LISTE.[GIRISAMBARI],LISTE.[CIKISAMBARI],
LISTE.[MIKTAR],LISTE.KALAN,LISTE.[TUTAR]
FROM (SELECT
CASE WHEN STFICHE.BILLED=0 THEN '' WHEN STFICHE.BILLED=1 THEN 'F' END as [FATURADURUMU],
STFICHE.LOGICALREF [STFICHEREFERANS],
STLINE.LOGICALREF [STLINEREFERANS],
[FISNO]=STFICHE.FICHENO,
[FISTURU]=CASE  
WHEN  STLINE.TRCODE=1 then 'Satınalma İrsaliyesi'
WHEN  STLINE.TRCODE=2 then 'Perakende Satış İade İrsaliyesi'
WHEN  STLINE.TRCODE=3 then 'Toptan Satış İade İrsaliyesi'
WHEN  STLINE.TRCODE=4 then 'Konsinye Çıkış İade İrsaliyesi'
WHEN  STLINE.TRCODE=5 then 'Konsinye Giriş İrsaliyesi'
WHEN  STLINE.TRCODE=6 then 'Satınalma İade İrsaliyesi'
WHEN  STLINE.TRCODE=7 then 'Perakende Satış İrsaliyesi'
WHEN  STLINE.TRCODE=8 then 'Toptan Satış İrsaliyesi'
WHEN  STLINE.TRCODE=9 then 'Konsinye Çıkış İrsaliyesi'
WHEN  STLINE.TRCODE=10 then 'Konsinye Giriş İade İrsaliyesi'
WHEN  STLINE.TRCODE=11 then 'Fire Fişi'
WHEN  STLINE.TRCODE=12 then 'Sarf Fişi'
WHEN STLINE.TRCODE=13 AND STLINE.SOURCELINK=0 then 'Üretimden Giriş Fişi'  WHEN STLINE.TRCODE=13 AND STLINE.SOURCELINK<>0 then 'Alınan Fiyat Farkı Faturası'
WHEN STLINE.TRCODE=14 AND STLINE.SOURCELINK=0 then 'Devir Fişi'  WHEN STLINE.TRCODE=14 AND STLINE.SOURCELINK<>0 then 'Satış Fiyat Farkı Faturası'
WHEN  STLINE.TRCODE=25 then 'Ambar Fişi'
WHEN  STLINE.TRCODE=26 then 'Muhtahsil Faturası'
WHEN  STLINE.TRCODE=50 then 'Sayım Fazlası Fişi'
WHEN  STLINE.TRCODE=51 then 'Sayım Eksiği Fişi' ELSE '' END,
[BELGENO]=STFICHE.DOCODE,
[STFICHETARIH]=STFICHE.DATE_,
[STLINETARIH]=STLINE.DATE_,
[SAAT]=dbo.LG_INTTOTIME(STLINE.FTIME),
[CARIKODU]=C.CODE,
[CARIUNVANI]=C.DEFINITION_,
[STOKKODU]=ITEMS.CODE,
[STOKADI]=ITEMS.NAME,
[BIRIM]=BIRIM.CODE,
[GIRIS]=CASE WHEN STLINE.IOCODE IN(1,2) THEN STLINE.AMOUNT else '' end,
[CIKIS]=CASE WHEN STLINE.IOCODE IN(3,4) THEN STLINE.AMOUNT else '' end,
[GIRISCIKISTIP]=CASE WHEN STLINE.IOCODE IN(1,2) THEN 'Giriş' when STLINE.IOCODE IN(3,4) THEN 'Çıkış' else '' end,
[GIRISAMBARI]= CASE WHEN (STLINE.IOCODE IN(1,2) AND STLINE.TRCODE<>25) OR (STLINE.TRCODE=25) THEN (SELECT TOP 1 NAME FROM L_CAPIWHOUSE WHERE FIRMNR={Convert.ToInt32(firma)} AND NR=STLINE.DESTINDEX) else '' end ,
[CIKISAMBARI]= CASE WHEN (STLINE.IOCODE IN(3,4) AND STLINE.TRCODE<>25) OR  (STLINE.TRCODE=25) THEN (SELECT TOP 1 NAME FROM L_CAPIWHOUSE WHERE FIRMNR={Convert.ToInt32(firma)} AND NR=STLINE.SOURCEINDEX)else '' end,
[MIKTAR]=(CASE WHEN STLINE.IOCODE IN(1,2) THEN 1 ELSE -1 end) * STLINE.AMOUNT*(CASE WHEN ISNULL(UINFO2,0)=0 THEN 1 ELSE UINFO2 END)/(CASE WHEN ISNULL(UINFO1,0)=0 THEN 1 ELSE UINFO1 END),
NULL KALAN,
[TUTAR]=(CASE WHEN STLINE.IOCODE IN(1,2) THEN 1 ELSE -1 end) * STLINE.VATMATRAH		
FROM LG_{firma}_{donem}_STFICHE STFICHE WITH (NOLOCK)
LEFT OUTER JOIN LG_{firma}_{donem}_STLINE STLINE WITH (NOLOCK) ON STFICHE.LOGICALREF=STLINE.STFICHEREF
LEFT OUTER JOIN LG_{firma}_ITEMS ITEMS      WITH (NOLOCK) ON STLINE.STOCKREF =ITEMS.LOGICALREF
LEFT OUTER JOIN LG_{firma}_CLCARD C WITH (NOLOCK) ON STFICHE.CLIENTREF =C.LOGICALREF
LEFT OUTER JOIN LG_{firma}_UNITSETL BIRIM   WITH (NOLOCK) ON BIRIM.UNITSETREF= ITEMS.UNITSETREF AND BIRIM.MAINUNIT=1
WHERE ITEMS.CODE='{stokkodu}'
AND STFICHE.CANCELLED=0 AND STLINE.CANCELLED=0
AND STLINE.LINETYPE=0
AND STLINE.IOCODE IN (1,2,3,4)

) LISTE
 DECLARE @STOK_KODU VARCHAR(150),
 @YURUYEN  FLOAT,
@SAYI     FLOAT; 
SELECT @SAYI = 1;
WITH CTE AS
(SELECT SAY = ROW_NUMBER() OVER (ORDER BY [STOKKODU], [STLINETARIH],[SAAT]),
 [FATURADURUMU],[STFICHEREFERANS] , [STLINEREFERANS] , [FISNO], [FISTURU], [BELGENO], [STFICHETARIH], [STLINETARIH], [SAAT],
 [CARIKODU], [CARIUNVANI], [STOKKODU], [STOKADI],[BIRIM],[GIRISCIKISTIP], [GIRISAMBARI],[CIKISAMBARI], [MIKTAR], [GIRIS], [CIKIS],
 KALAN, [TUTAR]
 FROM #GECICITABLO WITH(INDEX=IX_#GECICITABLO)
  )
UPDATE tgt
SET @YURUYEN = KALAN = CASE
WHEN tgt.SAY = @SAYI
THEN CASE
WHEN tgt.[STOKKODU] = @STOK_KODU THEN tgt.MIKTAR + @YURUYEN
ELSE tgt.MIKTAR
END ELSE 0 END,
@STOK_KODU = tgt.[STOKKODU],
@SAYI  = @SAYI + 1
FROM CTE tgt
WITH (TABLOCKX)
OPTION (MAXDOP 1)           
SELECT TOP 1
'' [FATURADURUMU],null [STFICHEREFERANS] ,null [STLINEREFERANS] ,'' [FISNO],
'' [FISTURU],'' [BELGENO],null [STFICHETARIH],null [STLINETARIH],'' AS SAAT,'' [CARIKODU],'{ilktarih.AddDays(-1).ToString("yyyy-MM-dd")} tarihinden Devir' [CARIUNVANI],
[STOKKODU] [STOKKODU],[STOKADI] [STOKADI],[BIRIM] [BIRIM],'Devir' [GIRISCIKISTIP],'' [GIRISAMBARI],''[CIKISAMBARI],
'0' [MIKTAR],'0' [GIRIS],'0' [CIKIS],cast(ISNULL ((SELECT SUM(ONHAND) FROM dbo.LV_{firma}_{donem}_STINVTOT
WHERE DATE_<'{sontarih.ToString("yyyy-MM-dd")}' AND STOCKREF = (SELECT TOP 1 LOGICALREF FROM LG_{firma}_ITEMS WHERE CODE='{stokkodu}') AND (INVENNO = - 1)), 0)as float) AS [KALAN],
'0' [TUTAR],'0' [SONFIYAT]
FROM #GECICITABLO
WHERE [STOKKODU]='{stokkodu}'
UNION ALL
SELECT [FATURADURUMU], [STFICHEREFERANS] ,[STLINEREFERANS] ,[FISNO],[FISTURU],[BELGENO],[STFICHETARIH],[STLINETARIH],[SAAT] AS SAAT,
[CARIKODU],[CARIUNVANI],[STOKKODU],[STOKADI],[BIRIM],[GIRISCIKISTIP],[GIRISAMBARI],[CIKISAMBARI],[MIKTAR],[GIRIS],[CIKIS],[KALAN],[TUTAR],
(SELECT TOP 1 ISNULL(NULLIF(LINENET,0)/NULLIF(AMOUNT,0),0) FROM LG_{firma}_{donem}_STLINE WHERE LOGICALREF=STLINEREFERANS) [SONFIYAT]
FROM #GECICITABLO
WHERE [STOKKODU]='{stokkodu}' AND [STLINETARIH] between '{ilktarih.ToString("yyyy-MM-dd")}' and '{sontarih.ToString("yyyy-MM-dd")}'
ORDER BY [STOKKODU],[STLINETARIH],[SAAT];";
                return db.Database.SqlQuery<STOKHAREKETLERI>(sql).ToList();

            }
        }
        public List<STOKALISSATISHAREKETLERI> UrunAlisSatisHareketleri(string firma, string donem, string stokkodu, string trkod, DateTime ilktarih, DateTime sontarih)
        {
            using (LogoContext db = new LogoContext())
            {
                string sql = $@"SELECT CASE WHEN S.BILLED=0 THEN '' WHEN S.BILLED=1 THEN 'F' END as [FATURADURUMU], S.INVOICEREF, F.FICHENO [FISNO], S.STFICHEREF,
            CASE 
            WHEN S.TRCODE =1 then 'Satınalma Faturası'
            WHEN S.TRCODE =2 then 'Perakende İade Faturası'
            WHEN S.TRCODE =3 then 'Toptan Satış İade Faturası'
            WHEN S.TRCODE =4 then 'Alınan Hizmet Faturası'
            WHEN S.TRCODE =5 then 'Konsinye Giriş İrsaliyesi'
            WHEN S.TRCODE =6 then 'Satınalma İade Faturası'
            WHEN S.TRCODE =7 then 'Perakende Satış Faturası'
            WHEN S.TRCODE =8 then 'Toptan Satış Faturası'
            WHEN S.TRCODE =10 then 'Verilen Proforma Faturası'
            WHEN S.TRCODE =11 then 'Fire Fişi'
            WHEN S.TRCODE =12 then 'Sarf Fişi'
            WHEN S.TRCODE =13 AND S.SOURCELINK=0 then 'Üretimden Giriş Fişi'  WHEN S.TRCODE =13 AND S.SOURCELINK<>0 then 'Alınan Fiyat Farkı Faturası'
            WHEN S.TRCODE =14 AND S.SOURCELINK=0 then 'Devir Fişi'  WHEN S.TRCODE =14 AND S.SOURCELINK<>0 then 'Satış Fiyat Farkı Faturası'
            WHEN S.TRCODE =15 then 'Sayım Fişi'
            WHEN S.TRCODE =25 then 'Ambar Fişi'
            WHEN S.TRCODE =50 then 'Sayım Fazlası'
            WHEN S.TRCODE =51 then 'Sayım Eksiği'
            ELSE '' END [FISTURU],
            C.CODE CARIKODU,C.DEFINITION_ CARIUNVANI, S.DATE_ [TARIH],
            I.CODE STOKKODU,I.NAME STOKCINSI,S.AMOUNT MIKTAR,
            (SELECT TOP 1  CODE FROM LG_{firma}_UNITSETL WHERE LOGICALREF = S.UOMREF) [BIRIM],
ISNULL(((NULLIF((S.LINENET),0)+S.DIFFPRICE)/NULLIF(S.AMOUNT,0)),0) FIYAT,
	CASE WHEN S.TRCURR=0 THEN ISNULL(((NULLIF((S.LINENET),0)+S.DIFFPRICE)/NULLIF(S.AMOUNT,0)),0) ELSE ISNULL(((NULLIF((S.LINENET),0)+S.DIFFPRICE)/NULLIF(S.AMOUNT,0)),0) / S.TRRATE END AS DOVIZBIRIMFIYAT,
    CASE WHEN S.TRCURR=0 THEN 'TL' ELSE CUR.CURCODE END AS DOVIZTURU,
S.LINENET+S.DIFFPRICE TUTAR,
			CASE WHEN S.TRCURR=0 THEN S.LINENET+S.DIFFPRICE ELSE (S.LINENET+S.DIFFPRICE) / S.TRRATE END AS DOVIZTUTAR
            FROM LG_{firma}_{donem}_STLINE S With (Nolock) 
            LEFT OUTER JOIN L_CURRENCYLIST CUR ON S.TRCURR=CUR.CURTYPE AND CUR.FIRMNR={Convert.ToInt32(firma)}
            LEFT OUTER JOIN LG_{firma}_{donem}_INVOICE F ON S.INVOICEREF=F.LOGICALREF
            LEFT OUTER JOIN LG_{firma}_CLCARD C ON S.CLIENTREF=C.LOGICALREF
            LEFT OUTER JOIN LG_{firma}_ITEMS I ON S.STOCKREF=I.LOGICALREF
            WHERE S.TRCODE IN ({trkod}) AND I.CODE='{stokkodu}' AND S.CANCELLED=0 
            ORDER BY S.DATE_, S.FTIME;";
                return db.Database.SqlQuery<STOKALISSATISHAREKETLERI>(sql).ToList();

            }
        }


        public bool SiparisOlustuktanSonraTeklifBilgileriniKaydetLogoObjeIle(List<LOGO_XERO.Models.LogoObje.SATIRLAR> siparisOlusanTeklif, int teklifId, int siparisid, int kullanici, string firma, string donem)
        {
            try
            {
                using (LogoContext db = new LogoContext())
                {
                    foreach (var item in siparisOlusanTeklif)
                    {
                        LOGO_XERO_TEKLIF_SIPARISSEVK_TABLOSU sevk = new LOGO_XERO_TEKLIF_SIPARISSEVK_TABLOSU();
                        sevk.TEKLIFID = teklifId;
                        sevk.TEKLIFSATIRID = Convert.ToInt32(item.TEKLIFSATIRID);
                        sevk.MIKTAR = item.MIKTAR;
                        sevk.KULLANICIID = kullanici;
                        sevk.TARIH = DateTime.Now;
                        sevk.SIPARISREF = siparisid;
                        sevk.STOKREF = item.STOKLOGICALREF;
                        sevk.SIPARISSATIRREF = db.Database.SqlQuery<int>($@"SELECT TOP 1 LOGICALREF FROM LG_{firma}_{donem}_ORFLINE WHERE ORDFICHEREF={siparisid} AND DELVRYCODE='{item.TEKLIFSATIRID}' AND LINETYPE=0").FirstOrDefault();
                        db.LOGO_XERO_TEKLIF_SIPARISSEVK_TABLOSU.Add(sevk);
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool SiparisOlustuktanSonraTeklifBilgileriniKaydetRestServisIle(List<Logo.Siparis.Item> siparisOlusanTeklif, int teklifId, int siparisid, int kullanici, string firma, string donem)
        {
            try
            {
                using (LogoContext db = new LogoContext())
                {
                    foreach (var item in siparisOlusanTeklif)
                    {
                        LOGO_XERO_TEKLIF_SIPARISSEVK_TABLOSU sevk = new LOGO_XERO_TEKLIF_SIPARISSEVK_TABLOSU();
                        sevk.TEKLIFID = teklifId;
                        sevk.TEKLIFSATIRID = Convert.ToInt32(item.DELVRY_CODE);
                        sevk.MIKTAR = Convert.ToInt32(item.QUANTITY);
                        sevk.KULLANICIID = kullanici;
                        sevk.TARIH = DateTime.Now;
                        sevk.STOKREF = Convert.ToInt32(item.STOCKREF);
                        sevk.SIPARISREF = siparisid;
                        sevk.SIPARISSATIRREF = db.Database.SqlQuery<int>($@"SELECT TOP 1 LOGICALREF FROM LG_{firma}_{donem}_ORFLINE WHERE ORDFICHEREF={siparisid} AND DELVRYCODE='{item.DELVRY_CODE}' AND LINETYPE=0").FirstOrDefault();
                        db.LOGO_XERO_TEKLIF_SIPARISSEVK_TABLOSU.Add(sevk);
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public TEKLIF_SIPARIS_IPTAL_SONUC TeklifinSilinmisSiparisiniKontrolEt(LOGO_XERO_PARAMETRELER parametre, string firma, string donem, int teklifId, int trkod)
        {
            TEKLIF_SIPARIS_IPTAL_SONUC SONUC = new TEKLIF_SIPARIS_IPTAL_SONUC();
            using (LogoContext db = new LogoContext())
            {
                List<LOGO_XERO_TEKLIF_SIPARISSEVK_TABLOSU> SiparisSatirlari = db.LOGO_XERO_TEKLIF_SIPARISSEVK_TABLOSU.Where(s => s.TEKLIFID == teklifId).ToList();
                if (SiparisSatirlari != null)
                {
                    if (SiparisSatirlari.Count > 0)
                    {
                        List<int> siparislergruplanmisRefler = SiparisSatirlari.GroupBy(s => s.SIPARISSATIRREF).Select(s => s.Key).ToList();
                        foreach (var item in siparislergruplanmisRefler)
                        {
                            string sorgu = $@"SELECT LOGICALREF FROM LG_{firma}_{donem}_ORFLINE WHERE LOGICALREF={item}";
                            int varmi = db.Database.SqlQuery<int>(sorgu).FirstOrDefault();
                            if (varmi == 0)
                            {
                                LOGO_XERO_TEKLIF_SIPARISSEVK_TABLOSU kay = db.LOGO_XERO_TEKLIF_SIPARISSEVK_TABLOSU.Where(s => s.SIPARISSATIRREF == varmi).FirstOrDefault();
                                if (kay != null)
                                {
                                    db.LOGO_XERO_TEKLIF_SIPARISSEVK_TABLOSU.Remove(kay);
                                    db.SaveChanges();
                                }
                            }
                        }
                        using (LogoContext db1 = new LogoContext())
                        {
                            List<LOGO_XERO_TEKLIF_SIPARISSEVK_TABLOSU> bagliSiparisVarmi = db.LOGO_XERO_TEKLIF_SIPARISSEVK_TABLOSU.Where(s => s.TEKLIFID == teklifId).ToList();
                            if (bagliSiparisVarmi != null)
                            {
                                if (bagliSiparisVarmi.Count > 0)
                                {
                                    SONUC.BAGLISIPARISVARMI = true;
                                }
                                else
                                {
                                    SONUC.BAGLISIPARISVARMI = false;
                                }
                            }
                            else
                            {
                                SONUC.BAGLISIPARISVARMI = false;
                            }
                        }

                        bool sonuc = TeklifinBagliSiparisiniSil(parametre, firma, donem, teklifId, trkod);
                        if (sonuc == true)
                        {
                            SONUC.DURUM = true;
                            SONUC.MESAJ = "Sipariş Silme İşlemi Başarılı !";
                        }
                        else
                        {
                            SONUC.DURUM = false;
                            SONUC.MESAJ = "Sipariş Silme İşlemi Başarısız !";
                        }
                        return SONUC;
                    }
                    else
                    {
                        SONUC.BAGLISIPARISVARMI = false;
                        SONUC.DURUM = true;
                        SONUC.MESAJ = "Bağlı Sipariş Bilgisi Bulunamadı !";
                        return SONUC;
                    }
                }
                else
                {
                    SONUC.BAGLISIPARISVARMI = false;
                    SONUC.DURUM = true;
                    SONUC.MESAJ = "Bağlı Sipariş Bilgisi Bulunamadı !";
                    return SONUC;
                }
            }
        }
        public bool TeklifinBagliSiparisiniSil(LOGO_XERO_PARAMETRELER parametre, string firma, string donem, int teklifId, int trcode)
        {
            using (LogoContext db = new LogoContext())
            {
                trcode = (trcode == 8) ? 1 : 2;
                List<LOGO_XERO_TEKLIF_SIPARISSEVK_TABLOSU> SiparisSatirlari = db.LOGO_XERO_TEKLIF_SIPARISSEVK_TABLOSU.Where(s => s.TEKLIFID == teklifId).ToList();
                if (SiparisSatirlari != null)
                {
                    if (SiparisSatirlari.Count > 0)
                    {
                        try
                        {
                            List<int> siparislergruplanmisRefler = SiparisSatirlari.GroupBy(s => s.SIPARISREF).Select(s => s.Key).ToList();
                            List<int> siparislerinsilmedurumu = new List<int>();
                            foreach (var item in siparislergruplanmisRefler)
                            {
                                if (parametre.LOGOBAGLANTISECIMI == 1)
                                {
                                    if (string.IsNullOrWhiteSpace(parametre.RESTSERVISURL) || string.IsNullOrWhiteSpace(parametre.RESTSERVISKULLANICIADI) || string.IsNullOrWhiteSpace(parametre.RESTSERVISSIFRE))
                                    {
                                        XtraMessageBox.Show("Rest Servis Ayarları Eksik ! Sistem Parametrelerinden Rest Servis Alanlarını Girip Programı Yeniden Başlatınız !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return false;
                                    }
                                v:

                                    string[] sonuc = new string[3];
                                    try
                                    {
                                        var request = new RestRequest(RestSharp.Method.DELETE);
                                        var client1 = new RestClient(parametre.RESTSERVISURL + "/api/v1/salesOrders/" + item);

                                        if (trcode == 1)
                                        {
                                            client1 = new RestClient(parametre.RESTSERVISURL + "/api/v1/salesOrders/" + item);//SATIŞ SİPARİŞİ
                                        }
                                        else if (trcode == 2)
                                        {
                                            client1 = new RestClient(parametre.RESTSERVISURL + "/api/v1/purchaseOrders/" + item);//SATINALMA sİPARİŞİ
                                        }
                                        client1.Timeout = -1;
                                        request.AddHeader("Authorization", $@"Bearer {parametre.RESTSERVISTOKEN}");
                                        try
                                        {

                                            IRestResponse response = client1.Execute(request);
                                            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                                            {
                                                string tok = tokenAl(parametre, firma);
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

                                                XtraMessageBox.Show("Hata : " + mesaj, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                siparislerinsilmedurumu.Add(0);

                                            }
                                            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                                            {
                                                bool dur = SilinmisSiparisSatirlariniSil(parametre, firma, donem, item);
                                                siparislerinsilmedurumu.Add(Convert.ToInt32(dur));
                                            }
                                            if (response.StatusCode == 0)
                                            {
                                                XtraMessageBox.Show("Hata : " + response.ErrorMessage, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                siparislerinsilmedurumu.Add(0);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            XtraMessageBox.Show("Sipariş İptali Başarısız ! Hata= " + ex.ToString());
                                            siparislerinsilmedurumu.Add(0);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        XtraMessageBox.Show("Hata=!" + ex.Message.ToString());
                                        siparislerinsilmedurumu.Add(0);
                                    }
                                }
                                else
                                {
                                    LogoObjeAktar obj = new LogoObjeAktar(parametre);
                                    string silmesonuc = "";
                                    if (trcode == 1)
                                    {
                                        silmesonuc = obj.SatisSiparisiIptal(item);
                                    }
                                    else
                                    {
                                        silmesonuc = obj.AlisSiparisiIptal(item);
                                    }
                                    if (silmesonuc == "true")
                                    {
                                        SilinmisSiparisSatirlariniSil(parametre, firma, donem, item);
                                        siparislerinsilmedurumu.Add(1);
                                    }
                                    else
                                    {
                                        XtraMessageBox.Show("Sipariş İptali Başarısız ! Hata= " + silmesonuc);
                                        siparislerinsilmedurumu.Add(0);
                                    }
                                }
                            }
                            if (siparislerinsilmedurumu.Where(s => s == 0).Count() > 0)
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }

                        }
                        catch (Exception)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
        }
        public bool SilinmisSiparisSatirlariniSil(LOGO_XERO_PARAMETRELER parametre, string firma, string donem, int siparisId)
        {
            try
            {
                using (LogoContext db = new LogoContext())
                {
                    using (var dbtransaction = db.Database.BeginTransaction())
                    {
                        List<LOGO_XERO_TEKLIF_SIPARISSEVK_TABLOSU> liste = db.LOGO_XERO_TEKLIF_SIPARISSEVK_TABLOSU.Where(s => s.SIPARISREF == siparisId).ToList();
                        if (liste != null)
                        {
                            if (liste.Count > 0)
                            {
                                try
                                {
                                    foreach (var item in liste)
                                    {

                                        LOGO_XERO_TEKLIF_SIPARISSEVK_TABLOSU kay = db.LOGO_XERO_TEKLIF_SIPARISSEVK_TABLOSU.Where(s => s.ID == item.ID).FirstOrDefault();
                                        if (kay != null)
                                        {
                                            db.LOGO_XERO_TEKLIF_SIPARISSEVK_TABLOSU.Remove(kay);
                                            db.SaveChanges();
                                        }
                                    }
                                    dbtransaction.Commit();
                                    return true;
                                }
                                catch (Exception)
                                {
                                    dbtransaction.Rollback();
                                    return false;
                                }

                            }

                            else
                            {
                                return true;
                            }
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<LG_UNITBARCODE> BirimVeStokBarkodGetir(int stokref, int secilibirimrefUnitlineRef)
        {
            using (LogoContext db = new LogoContext())
            {
                return db.LG_UNITBARCODE.Where(s => s.ITEMREF == stokref && s.UNITLINEREF == secilibirimrefUnitlineRef).ToList();
            }
        }
        public List<LG_UNITBARCODE> TumBarkodlarGetir()
        {
            using (LogoContext db = new LogoContext())
            {
                return db.LG_UNITBARCODE.ToList();
            }
        }
        public bool BarkodLogodaKayitli(string barkod, int itemref)
        {
            using (LogoContext db = new LogoContext())
            {
                var barkodlar = db.LG_UNITBARCODE.Where(s => s.ITEMREF != itemref).Select(s => s.BARCODE).ToList();
                return barkodlar.Contains(barkod);
            }
        }
        public void sqlInsertPRCLIST(string firma, bool kdvdahilharic, int cardref, int currency, double fiyat, int logicalref, LOGO_XERO_PARAMETRELER param, string ozelad = "")
        {
            using (LogoContext db = new LogoContext())
            {
                string ozeladvirgulsuz = ozelad;
                int kdvdhl = kdvdahilharic == false ? 0 : 1;
                if (string.IsNullOrWhiteSpace(ozelad))
                {
                }
                else
                {
                    ozelad = "," + ozelad;
                }
                string ozelsutunad = string.IsNullOrWhiteSpace(param.OZELFIYATKARTSUTUNAD) ? " " : $@", {param.OZELFIYATKARTSUTUNAD}  ";
                string sorgu = !string.IsNullOrWhiteSpace(ozeladvirgulsuz) && !string.IsNullOrWhiteSpace(param.OZELFIYATKARTSUTUNAD) ? " AND " + param.OZELFIYATKARTSUTUNAD + " = " + ozeladvirgulsuz : " ";

                //DOUBLEAD snc = FiyatGetirPRCLIST(cardref,firma, sorgu, $@"AND CURRENCY = {currency} AND INCVAT = {Convert.ToInt32(kdvdahilharic)} AND PTYPE = 2");
                if (logicalref == 0)
                {
                    string sql = $@"INSERT INTO LG_{firma}_PRCLIST
                    (CARDREF,CAPIBLOCK_CREADEDDATE  ,CLSPECODE, PRICE, PTYPE, PRIORITY, INCVAT, PAYPLANREF, CLIENTCODE, CURRENCY, CODE, BEGDATE, ENDDATE, MTRLTYPE, UNITCONVERT, BRANCH, UOMREF {ozelsutunad}, ACTIVE, DEFINITION_,CAPIBLOCK_CREATEDHOUR,CAPIBLOCK_CREATEDMIN,CAPIBLOCK_CREATEDSEC) VALUES 
                    ({cardref},'{DateTime.Now.ToString("MM.dd.yyyy")}' ,'',{fiyat}, {2/*TURU(PTYPE)*/}, {0/*PRIORITY*/}, {kdvdhl}, {0},'' , {currency}, 
                    (SELECT TOP 1 MAX(LOGICALREF)+100000000 FROM LG_{firma}_PRCLIST) ,
                    '{Convert.ToDateTime("01.01.2018").ToString("MM.dd.yyyy")}', '{Convert.ToDateTime("31.12.2100").ToString("MM.dd.yyyy")}', {0/*MTRLTYPE*/}, {0/*UNITCONVERT*/}, {-1/*BRANCH*/}, 
                    (SELECT TOP 1 L.LOGICALREF UOMREF FROM LG_{firma}_UNITSETL L LEFT OUTER JOIN LG_{firma}_ITEMS I ON L.UNITSETREF=I.UNITSETREF  WHERE I.LOGICALREF={cardref}) {ozelad}, {0/* ACTİVE*/}, '{DateTime.Now.ToString("dd-MM.yyyy")}',{DateTime.Now.Hour},{DateTime.Now.Minute},{DateTime.Now.Second});
                    INSERT INTO LG_{firma}_PRCLSTDIV(PARENTPRCREF,DIVCODES) 
                    SELECT LOGICALREF,-1  FROM LG_{firma}_PRCLIST WHERE PTYPE=2 AND LOGICALREF NOT IN (SELECT PARENTPRCREF FROM LG_{firma}_PRCLSTDIV);";
                    db.Database.ExecuteSqlCommand(sql);
                }
                else
                {
                    string sql = $@"UPDATE LG_{firma}_PRCLIST SET PRICE = {fiyat} ,CURRENCY = {currency} ,CAPIBLOCK_MODIFIEDDATE = '{DateTime.Now.ToString("MM.dd.yyyy")}',CAPIBLOCK_MODIFIEDHOUR = {DateTime.Now.Hour},CAPIBLOCK_MODIFIEDMIN = {DateTime.Now.Minute},CAPIBLOCK_MODIFIEDSEC = {DateTime.Now.Second}, INCVAT = {kdvdhl} WHERE CARDREF = {cardref} AND 
                                    LOGICALREF = {logicalref}";
                    db.Database.ExecuteSqlCommand(sql);
                }



            }
        }
        public DOUBLEAD FiyatGetirPRCLIST(int cardref, string firma, string sutunfiltre, string aramafiltre = " ")
        {
            using (LogoContext db = new LogoContext())
            {
                string anasql = $@"SELECT TOP 1 PRICE,CAST(INCVAT AS bit)INCVAT,CURRENCY ,LOGICALREF FROM LG_{firma}_PRCLIST WHERE CARDREF = {cardref} AND PTYPE = 2 {sutunfiltre} {aramafiltre}
                ORDER BY ENDDATE DESC";

                DOUBLEAD snc = db.Database.SqlQuery<DOUBLEAD>(anasql).FirstOrDefault();
                if (snc == null)
                {
                    return null;
                }
                else
                {
                    return snc;
                }

            }

        }

        public SAHIS CariSorgula(LOGO_XERO_PARAMETRELER parametre, int tip, string tc)
        {
            SQLConnection clas = new SQLConnection();
            SAHIS sh = new SAHIS();
            Rootobject data = new Rootobject();
            var client = new RestClient("http://turmob.harmonq.com:5470/v1/musteriBilgileri/" + tc);
            client.Timeout = -1;
            var request = new RestRequest(RestSharp.Method.POST);
            request.AddHeader("accept", "text/plain");
            request.AddHeader("harmonqSecretKey", "esbifb64-c498-4ffe-a9df-d84ac80ce8bf");
            request.AddHeader("accountantKey", parametre.MALIMUSAVIR_TOKEN);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                data = JsonConvert.DeserializeObject<Rootobject>(response.Content);
                SAHIS sahis = new SAHIS();
                sahis.sonuc = true;
                if (data.success)
                {
                    if (data.data.durum.durumKodu == "1000")
                    {
                        if (tip == 1)
                        {
                            //Vkn ile

                            sahis.sonucAciklama = "";
                            sahis.adi = "";
                            sahis.soyadi = "";
                            sahis.babaAdi = "";
                            sahis.vergiDairesiAdi = data.data.vergiDairesiAdi;
                            sahis.vergiDairesiKodu = data.data.vergiDairesiKodu;
                            sahis.vKN = data.data.vkn;
                            sahis.unvan = data.data.unvan;
                            if (data.data.adresBilgileri.Length > 0)
                            {
                                var adresbil = data.data.adresBilgileri.OrderByDescending(s => s.adresTipi).FirstOrDefault();
                                sahis.isAdresi = new ADRES()
                                {
                                    mahalleSemt = adresbil.mahalleSemt ?? "",
                                    caddeSokak = adresbil.caddeSokak ?? "",
                                    kapiNO = adresbil.icKapiNo ?? "",
                                    daireNO = adresbil.disKapiNo ?? "",
                                    ilceAdi = adresbil.ilceAdi ?? "",
                                    ilKodu = adresbil.ilKodu == null ? "" : adresbil.ilKodu.ToString(),
                                    ilAdi = adresbil.ilAdi ?? ""
                                };
                                sahis.ikametgahAdresi = new ADRES()
                                {

                                    mahalleSemt = adresbil.mahalleSemt ?? "",
                                    caddeSokak = adresbil.caddeSokak ?? "",
                                    kapiNO = adresbil.icKapiNo ?? "",
                                    daireNO = adresbil.disKapiNo ?? "",
                                    ilceAdi = adresbil.ilceAdi ?? "",
                                    ilKodu = adresbil.ilKodu == null ? "" : adresbil.ilKodu.ToString(),
                                    ilAdi = adresbil.ilAdi ?? ""
                                };
                            }
                            return sahis;
                        }
                        else
                        {

                            sahis.sonucAciklama = "";
                            sahis.adi = data.data.ad.ToString();
                            sahis.soyadi = data.data.soyad.ToString();
                            sahis.babaAdi = data.data.babaAdi;
                            sahis.vergiDairesiAdi = data.data.vergiDairesiAdi;
                            sahis.vergiDairesiKodu = data.data.vergiDairesiKodu;
                            sahis.vKN = data.data.vkn;
                            sahis.unvan = data.data.unvan;
                            if (data.data.adresBilgileri.Length > 0)
                            {
                                var adresbil = data.data.adresBilgileri.OrderByDescending(s => s).FirstOrDefault();
                                if (adresbil != null)
                                {
                                    sahis.isAdresi = new ADRES()
                                    {
                                        mahalleSemt = adresbil.mahalleSemt == null ? "" : adresbil.mahalleSemt.ToString(),
                                        caddeSokak = adresbil.caddeSokak == null ? "" : adresbil.caddeSokak.ToString(),
                                        kapiNO = adresbil.icKapiNo == null ? "" : adresbil.icKapiNo.ToString(),
                                        daireNO = adresbil.disKapiNo == null ? "" : adresbil.disKapiNo.ToString(),
                                        ilceAdi = adresbil.ilceAdi == null ? "" : adresbil.ilceAdi.ToString(),
                                        ilKodu = adresbil.ilKodu == null ? "" : adresbil.ilKodu.ToString(),
                                        ilAdi = adresbil.ilAdi == null ? "" : adresbil.ilAdi.ToString()
                                    };
                                    sahis.ikametgahAdresi = new ADRES()
                                    {
                                        mahalleSemt = adresbil.mahalleSemt == null ? "" : adresbil.mahalleSemt.ToString(),
                                        caddeSokak = adresbil.caddeSokak == null ? "" : adresbil.caddeSokak.ToString(),
                                        kapiNO = adresbil.icKapiNo == null ? "" : adresbil.icKapiNo.ToString(),
                                        daireNO = adresbil.disKapiNo == null ? "" : adresbil.disKapiNo.ToString(),
                                        ilceAdi = adresbil.ilceAdi == null ? "" : adresbil.ilceAdi.ToString(),
                                        ilKodu = adresbil.ilKodu == null ? "" : adresbil.ilKodu.ToString(),
                                        ilAdi = adresbil.ilAdi == null ? "" : adresbil.ilAdi.ToString()
                                    };

                                }
                            }
                            return sahis;
                        }
                    }
                    else
                    {
                        sahis.sonuc = false;
                        sahis.sonucAciklama = data.data.durum.durumKodAciklamasi.ToString();
                        return sahis;
                    }
                }
                else
                {
                    sahis.sonuc = false;
                    sahis.sonucAciklama = "";
                    return sahis;
                }
            }
            else
            {
                SAHIS sahis = new SAHIS();
                sahis.sonuc = false;
                sahis.sonucAciklama = "";
                return sahis;
            }
        }
        public List<L_COUNTRY> UlkeListesiGetir()
        {
            using (LogoContext db = new LogoContext())
            {
                return db.L_COUNTRY.ToList();
            }
        }
        public void UlkeListesiDoldur(dynamic nesne)
        {
            nesne.Properties.DisplayMember = "NAME";
            nesne.Properties.ValueMember = "LOGICALREF";
            nesne.Properties.DataSource = UlkeListesiGetir();
        }
        public List<L_CITY> TumSehirListesiGetir()
        {
            using (LogoContext db = new LogoContext())
            {
                return db.L_CITY.ToList();
            }
        }
        public List<L_CITY> SehirListesiGetir(int UlkeNr)
        {
            using (LogoContext db = new LogoContext())
            {
                return db.L_CITY.Where(s => s.COUNTRY == UlkeNr).ToList();
            }
        }
        public void SehirListesiDoldur(dynamic nesne, int ulkeref)
        {
            nesne.Properties.DisplayMember = "NAME";
            nesne.Properties.ValueMember = "LOGICALREF";
            nesne.Properties.DataSource = SehirListesiGetir(ulkeref);
        }
        public List<L_TOWN> TumIlceListesiGetir()
        {
            using (LogoContext db = new LogoContext())
            {
                return db.L_TOWN.ToList();
            }
        }
        public List<L_TOWN> IlceListesiGetir(int UlkeNr, int sehirNr)
        {
            using (LogoContext db = new LogoContext())
            {
                return db.L_TOWN.Where(s => s.CTYREF == sehirNr && s.CNTRNR == UlkeNr).ToList();
            }
        }
        public List<L_DISTRICT> MahalleListesiGetir(int ilceNr)
        {
            using (LogoContext db = new LogoContext())
            {
                return db.L_DISTRICT.Where(s => s.TOWNNR == ilceNr).ToList();
            }
        }
        public List<L_TAXOFFICE> VergiDaireleriGetir(int ulkenr)
        {
            using (LogoContext db = new LogoContext())
            {
                return db.L_TAXOFFICE.Where(s => s.CNTRNR == ulkenr).ToList();
            }
        }
        public List<L_TAXOFFICE> TumVergiDaireleriGetir()
        {
            using (LogoContext db = new LogoContext())
            {
                return db.L_TAXOFFICE.ToList();
            }
        }
        public void MahalleListesiDoldur(dynamic nesne, int ilceref)
        {
            nesne.Properties.DisplayMember = "NAME";
            nesne.Properties.ValueMember = "LOGICALREF";
            nesne.Properties.DataSource = MahalleListesiGetir(ilceref);
        }
        public List<L_DISTRICT> TumMahalleListesiGetir()
        {
            using (LogoContext db = new LogoContext())
            {
                return db.L_DISTRICT.ToList();
            }
        }
        public void IlceListesiDoldur(dynamic nesne, int ulkeref, int sehirref)
        {
            nesne.Properties.DisplayMember = "NAME";
            nesne.Properties.ValueMember = "LOGICALREF";
            nesne.Properties.DataSource = IlceListesiGetir(ulkeref, sehirref);
        }

        public FATURA_BILGILERI CariRiskBilgiEkraniFaturaBilgileri(string firma, string donem, int carilogicalref)
        {
            FATURA_BILGILERI kay = new FATURA_BILGILERI();
            kay.BIRIMFATURATUTARI = 0;
            kay.FATURASAYISI = 0;
            kay.FATURATUTARI = 0;
            using (LogoContext db = new LogoContext())
            {
                string sql = $@" SELECT
                        ISNULL(COUNT(F.CLIENTREF),0) FATURASAYISI,
                        ISNULL(SUM(F.NETTOTAL),0) FATURATUTARI,
                        (ISNULL(SUM(NULLIF(F.NETTOTAL,0)),0)/ISNULL(NULLIF(COUNT(F.LOGICALREF),0),1)) BIRIMFATURATUTARI
                        FROM LG_{firma}_{donem}_INVOICE F With (Nolock) 
                        LEFT OUTER JOIN LG_{firma}_CLCARD C ON F.CLIENTREF=C.LOGICALREF
                        WHERE C.LOGICALREF={carilogicalref} AND F.CANCELLED=0;";
                kay = db.Database.SqlQuery<FATURA_BILGILERI>(sql).FirstOrDefault();
            }
            return kay;
        }

        public RISK_TUTARLAR CariRiskBilgiEkraniRiskBilgileri(string firma, string donem, int carilogicalref)
        {
            RISK_TUTARLAR kay = new RISK_TUTARLAR();
            kay = new RISK_TUTARLAR { ACIKHESAPRISKI = 0, CARIREF = carilogicalref, CEKRISKKENDI = 0, CIROCEKSENETRISKTOPLAM = 0, CIROTUTAR = 0, KENDICEKSENETRISKTOPLAM = 0, DEFINITION_ = "", CODE = "", ID = 0, KENDIODENMEMISCEKRISKIMIZ = 0, MUSTERICEKSENETCIRORISKTOPLAM = 0, MUSTERICEKSENETRISKTOPLAM = 0, MUSTERITAHSILEDILMEMISCEKCIRORISKI = 0, ODENMEMISSENETRISKI = 0, RISKIASANTOPLAM = 0, SATISTUTAR = 0 };
            using (LogoContext db = new LogoContext())
            {
                string sql = $@"SELECT C.CODE, C.DEFINITION_, CL.LOGICALREF AS [ID],CL.CLCARDREF AS [CARIREF], 
                        ISNULL(CL.CSTCSRISKLIMIT,0) AS [MUSTERITAHSILEDILMEMISCEKCIRORISKI], ISNULL(CL.MYCSRISKLIMIT,0) AS [KENDIODENMEMISCEKRISKIMIZ], ISNULL(CL.SENET1_DEBIT,0) AS[ODENMEMISSENETRISKI],ISNULL(CL.CSTCSCIRORISKLIMIT,0) AS [CIROCEKSENETRISKTOPLAM],ISNULL(CL.CSTCSOWNRISKTOTAL,0) AS [MUSTERICEKSENETRISKTOPLAM] ,                        
                        ISNULL(CL.CSTCSRISKTOTAL,0) AS [MUSTERICEKSENETCIRORISKTOPLAM],ISNULL(CL.MYCSRISKTOTAL,0) AS [KENDICEKSENETRISKTOPLAM], 
                        ISNULL(CL.ACCRISKLIMIT,0) AS [ACIKHESAPRISKI],  ISNULL(CL.RISKTOTAL,0) AS [RISKIASANTOPLAM],                     
                        ISNULL((SELECT SUM (NETTOTAL) FROM LG_{firma}_{donem}_INVOICE WHERE TRCODE IN (7,8) AND CANCELLED=0 AND CLIENTREF= C.LOGICALREF),0) [SATISTUTAR],
                       ISNULL(((SELECT SUM(CASE WHEN  CSC.CIRO=1 THEN CSC.AMOUNT ELSE 0 END)                      
                        FROM  LG_{firma}_{donem}_CSCARD AS CSC 
                        LEFT OUTER JOIN LG_{firma}_{donem}_CSTRANS AS CST ON CSC.LOGICALREF=CST.CSREF AND CST.CARDMD=5 AND CSC.CURRSTAT= CST.STATUS                 
                        LEFT OUTER JOIN LG_{firma}_{donem}_CSTRANS AS CST2 ON CSC.LOGICALREF=CST2.CSREF AND CST2.CARDMD=7 
                        LEFT OUTER JOIN LG_{firma}_{donem}_CSTRANS AS CST3 ON CSC.LOGICALREF=CST3.CSREF AND CST3.CARDMD=5 AND CST3.STATUS=1
                        LEFT OUTER JOIN LG_{firma}_CLCARD AS C ON CST3.CARDREF=C.LOGICALREF
                        WHERE CURRSTAT NOT IN (8,6) AND C.LOGICALREF =  C.LOGICALREF) ),0) [CIROTUTAR],
                        ISNULL(((SELECT SUM(CASE WHEN  CSC.CIRO=0 THEN CSC.AMOUNT ELSE 0 END)                     
                        FROM  LG_{firma}_{donem}_CSCARD AS CSC 
                        LEFT OUTER JOIN LG_{firma}_{donem}_CSTRANS AS CST ON CSC.LOGICALREF=CST.CSREF AND CST.CARDMD=5 AND CSC.CURRSTAT= CST.STATUS                     
                        LEFT OUTER JOIN LG_{firma}_{donem}_CSTRANS AS CST2 ON CSC.LOGICALREF=CST2.CSREF AND CST2.CARDMD=7 
                        LEFT OUTER JOIN LG_{firma}_{donem}_CSTRANS AS CST3 ON CSC.LOGICALREF=CST3.CSREF AND CST3.CARDMD=5 AND CST3.STATUS=1
                        LEFT OUTER JOIN LG_{firma}_CLCARD AS C ON CST3.CARDREF=C.LOGICALREF
                        WHERE CURRSTAT NOT IN (8,6) AND C.LOGICALREF=C.LOGICALREF) ),0) [CEKRISKKENDI]
                        FROM LG_{firma}_{donem}_CLRNUMS CL
                        INNER JOIN LG_{firma}_CLCARD C ON CL.CLCARDREF=C.LOGICALREF
                        WHERE C.LOGICALREF={carilogicalref}";
                kay = db.Database.SqlQuery<RISK_TUTARLAR>(sql).FirstOrDefault();
            }
            return kay;
        }

        public List<YIL_SATISBILGILERI> CariRiskBilgiEkraniSatisYilGetir(string firma, string donem, int carilogicalref)
        {
            List<YIL_SATISBILGILERI> kay = new List<YIL_SATISBILGILERI>();
            using (LogoContext db = new LogoContext())
            {
                string sql = $@"SELECT  SUM (NETTOTAL)TUTAR
,YEAR(DATE_)YIL  FROM LG_{firma}_{donem}_INVOICE WHERE TRCODE IN (7,8) AND CANCELLED=0 AND CLIENTREF= {carilogicalref}
                GROUP BY YEAR(DATE_)
                ORDER BY YEAR(DATE_) DESC";
                kay = db.Database.SqlQuery<YIL_SATISBILGILERI>(sql).ToList();
            }
            return kay;
        }

        public double CariRiskBilgileriCariBakiyeGetir(string firma, string donem, int carilogicalref)
        {
            double tutar = 0;

            using (LogoContext db = new LogoContext())
            {
                string sql = $@" SELECT ISNULL(SUM(DEBIT),0)-ISNULL(SUM(CREDIT),0) BAKIYE FROM LV_{firma}_{donem}_GNTOTCL 
                        WHERE TOTTYP=1 AND CARDREF=(SELECT TOP 1 LOGICALREF FROM LG_{firma}_CLCARD WHERE LOGICALREF={carilogicalref})";
                tutar = db.Database.SqlQuery<double>(sql).FirstOrDefault();
            }
            return tutar;
        }

        public TEKLIF_BILGILERI_RISK CariRiskBilgiEkraniTeklifBilgileri(string firma, string donem, int carilogicalref)
        {
            TEKLIF_BILGILERI_RISK kay = new TEKLIF_BILGILERI_RISK();
            kay = new TEKLIF_BILGILERI_RISK { KALEMSAYISI = 0, SIPARISEDONENKALEMSAYISI = 0, SIPARISEDONUSENTEKLIFSAYISI = 0, SIPARISTUTARI = 0, TEKLIFSAYISI = 0, TEKLIFTUTARI = 0 };
            using (LogoContext db = new LogoContext())
            {
                string sql = $@"SELECT COUNT(LISTE.ID)TEKLIFSAYISI,ISNULL((SELECT COUNT(ID) FROM LOGO_XERO_TEKLIF_BASLIK_{firma} WHERE CARIID={carilogicalref} AND DURUMU=3),0) SIPARISEDONUSENTEKLIFSAYISI,
  ISNULL(SUM(LISTE.KALEMSAYISI),0)KALEMSAYISI,ISNULL(SUM(LISTE.SIPARISTUTARI),0)SIPARISTUTARI,ISNULL(SUM(LISTE.TEKLIFTUTARI),0)TEKLIFTUTARI,ISNULL(SUM(LISTE.SIPARISEDONENKALEMSAYISI),0)SIPARISEDONENKALEMSAYISI
  FROM (
 select b.ID,
 ISNULL((SELECT COUNT(ID) FROM LOGO_XERO_TEKLIF_SATIR_{firma} ST WHERE ST.TEKLIFID=B.ID),0)KALEMSAYISI,
 ISNULL((SELECT count(DISTINCT TEKLIFSATIRID) FROM LOGO_XERO_TEKLIF_SIPARISSEVK_TABLOSU_{firma} WHERE TEKLIFID=B.ID ),0)SIPARISEDONENKALEMSAYISI,
 CASE WHEN B.DURUMU=3 THEN (SELECT SUM(NETTOTAL) FROM LG_{firma}_{donem}_ORFICHE WHERE DOCODE=B.TEKLIFNO) ELSE 0 END AS SIPARISTUTARI,
 KDVDAHILNETTUTAR TEKLIFTUTARI
 from LOGO_XERO_TEKLIF_BASLIK_{firma} B  WHERE B.CARIID={carilogicalref} ) AS LISTE";
                kay = db.Database.SqlQuery<TEKLIF_BILGILERI_RISK>(sql).FirstOrDefault();
            }
            return kay;
        }

        public List<LG_CLINTEL> IstihbaratBilgileriGetir(int carilogicalref)
        {
            List<LG_CLINTEL> liste = new List<LG_CLINTEL>();
            using (LogoContext db = new LogoContext())
            {
                liste = db.LG_CLINTEL.OrderBy(s => s.LINENUM).Where(s => s.CLIENTREF == carilogicalref).ToList();
            }
            return liste;
        }

    }
}