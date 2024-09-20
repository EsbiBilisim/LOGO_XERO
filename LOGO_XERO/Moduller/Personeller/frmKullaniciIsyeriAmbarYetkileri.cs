using DevExpress.XtraEditors;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.UI.WebControls;
using System.Windows.Forms;
using static LOGO_XERO.Moduller.Personeller.frmKullaniciEkle;

namespace LOGO_XERO
{
    public partial class frmKullaniciIsyeriAmbarYetkileri : DevExpress.XtraEditors.XtraForm
    {
        frmKullaniciEkle _kullanici;
        SQLConnection clas = new SQLConnection();
        string firma;
        string donem;
        frmAnaForm ana;
        LOGO_XERO_KULLANICILAR kln;
        public frmKullaniciIsyeriAmbarYetkileri(frmKullaniciEkle kullanici)
        {
            InitializeComponent();
            _kullanici = kullanici;
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            firma = ana.lk_firma.EditValue.ToString();
            donem = ana.lk_donem.EditValue.ToString();
            if (kullanici.kullaniciid != null && !string.IsNullOrWhiteSpace(kullanici.kullaniciid.ToString()))
            {
                kln = KullaniciDoldur(kullanici.kullaniciid);
            }

        }
        public LOGO_XERO_KULLANICILAR KullaniciDoldur(int _kullaniciid)
        {
            clas.Connect();
            string sqlParametre = $@"SELECT * FROM LOGO_XERO_KULLANICILAR where ID={_kullaniciid}";
            SqlCommand cmd = new SqlCommand(sqlParametre, clas.Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            List<LOGO_XERO_KULLANICILAR> denemes = new List<LOGO_XERO_KULLANICILAR>();
            DataSet ds = new DataSet();
            da.Fill(ds);

            LOGO_XERO_KULLANICILAR kullanici = new LOGO_XERO_KULLANICILAR();

            if (ds.Tables[0].Rows[0]["ID"] != DBNull.Value)
                kullanici.ID = (int)Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
            if (ds.Tables[0].Rows[0]["KULLANICIADI"] != DBNull.Value)
                kullanici.KULLANICIADI = (string)ds.Tables[0].Rows[0]["KULLANICIADI"].ToString();
            if (ds.Tables[0].Rows[0]["LOGOSATISELEMANIID"] != DBNull.Value)
                kullanici.LOGOSATISELEMANIID = (string)ds.Tables[0].Rows[0]["LOGOSATISELEMANIID"].ToString();
            if (ds.Tables[0].Rows[0]["SIFRE"] != DBNull.Value)
                kullanici.SIFRE = (string)ds.Tables[0].Rows[0]["SIFRE"].ToString();
            if (ds.Tables[0].Rows[0]["TANIMLIFIRMA"] != DBNull.Value)
                kullanici.TANIMLIFIRMA = (string)ds.Tables[0].Rows[0]["TANIMLIFIRMA"].ToString();
            if (ds.Tables[0].Rows[0]["TANIMLIDONEM"] != DBNull.Value)
                kullanici.TANIMLIDONEM = (string)ds.Tables[0].Rows[0]["TANIMLIDONEM"].ToString();
            if (ds.Tables[0].Rows[0]["ISYERI"] != DBNull.Value)
                kullanici.ISYERI = (Int16)ds.Tables[0].Rows[0]["ISYERI"];
            if (ds.Tables[0].Rows[0]["BOLUM"] != DBNull.Value)
                kullanici.BOLUM = (Int16)ds.Tables[0].Rows[0]["BOLUM"];
            if (ds.Tables[0].Rows[0]["FABRIKA"] != DBNull.Value)
                kullanici.FABRIKA = (Int16)ds.Tables[0].Rows[0]["FABRIKA"];
            if (ds.Tables[0].Rows[0]["AMBAR"] != DBNull.Value)
                kullanici.AMBAR = (Int16)ds.Tables[0].Rows[0]["AMBAR"];
            if (ds.Tables[0].Rows[0]["TELEFON"] != DBNull.Value)
                kullanici.TELEFON = (string)ds.Tables[0].Rows[0]["TELEFON"].ToString();
            if (ds.Tables[0].Rows[0]["EPOSTA"] != DBNull.Value)
                kullanici.EPOSTA = (string)ds.Tables[0].Rows[0]["EPOSTA"].ToString();
            if (ds.Tables[0].Rows[0]["ILCE"] != DBNull.Value)
                kullanici.ILCE = (string)ds.Tables[0].Rows[0]["ILCE"].ToString();
            if (ds.Tables[0].Rows[0]["IL"] != DBNull.Value)
                kullanici.IL = (string)ds.Tables[0].Rows[0]["IL"].ToString();
            if (ds.Tables[0].Rows[0]["ADRES"] != DBNull.Value)
                kullanici.ADRES = (string)ds.Tables[0].Rows[0]["ADRES"].ToString();
            if (ds.Tables[0].Rows[0]["GOREV"] != DBNull.Value)
                kullanici.GOREV = (int)Convert.ToInt32(ds.Tables[0].Rows[0]["GOREV"]);
            if (ds.Tables[0].Rows[0]["TEKLIFTUTARILIMIT"] != DBNull.Value)
                kullanici.TEKLIFTUTARILIMIT = (int)Convert.ToInt32(ds.Tables[0].Rows[0]["TEKLIFTUTARILIMIT"]);
            if (ds.Tables[0].Rows[0]["KISITLIOZELKOD"] != DBNull.Value)
                kullanici.KISITLIOZELKOD = (string)ds.Tables[0].Rows[0]["KISITLIOZELKOD"].ToString();
            if (ds.Tables[0].Rows[0]["ISKONTOLIMIT"] != DBNull.Value)
                kullanici.ISKONTOLIMIT = (float)Convert.ToSingle(ds.Tables[0].Rows[0]["ISKONTOLIMIT"]);
            if (ds.Tables[0].Rows[0]["GIRISAMBAR"] != DBNull.Value)
                kullanici.GIRISAMBAR = (short)Convert.ToInt32(ds.Tables[0].Rows[0]["GIRISAMBAR"]);
            if (ds.Tables[0].Rows[0]["GIRISBOLUM"] != DBNull.Value)
                kullanici.GIRISBOLUM = (short)Convert.ToInt32(ds.Tables[0].Rows[0]["GIRISBOLUM"]);
            if (ds.Tables[0].Rows[0]["GIRISISYERI"] != DBNull.Value)
                kullanici.GIRISISYERI = (short)Convert.ToInt32(ds.Tables[0].Rows[0]["GIRISISYERI"]);
            return kullanici;

        }
        private void frmKullaniciIsyeriAmbarYetkileri_Load(object sender, EventArgs e)
        {
            ListeGetir();
            KullanicininListesiniGetir();


        }

        public void ListeGetir()
        {
            int firmano = Convert.ToInt32(firma);
            clas.Connect();
            string sqlParametre = $@"select * from L_CAPIDIV where FIRMNR = '{firmano}'";
            SqlCommand cmd = new SqlCommand(sqlParametre, clas.Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            List<L_CAPIDIV> list = new List<L_CAPIDIV>();
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow MyDataRow in ds.Tables[0].Rows)
            {
                list.Add(new L_CAPIDIV()
                {
                    LOGICALREF = (int)MyDataRow["LOGICALREF"],
                    FIRMNR = MyDataRow["FIRMNR"] != DBNull.Value ? (Int16?)Convert.ToInt16(MyDataRow["FIRMNR"]) : null,
                    NR = MyDataRow["NR"] != DBNull.Value ? (Int16?)Convert.ToInt16(MyDataRow["NR"]) : null,
                    NAME = MyDataRow["NAME"].ToString(),
                    STREET = MyDataRow["STREET"].ToString(),
                    ROAD = MyDataRow["ROAD"].ToString(),
                    DOORNR = MyDataRow["DOORNR"].ToString(),
                    DISTRICT = MyDataRow["DISTRICT"].ToString(),
                    CITY = MyDataRow["CITY"].ToString(),
                    COUNTRY = MyDataRow["COUNTRY"].ToString(),
                    ZIPCODE = MyDataRow["ZIPCODE"].ToString(),
                    PHONE = MyDataRow["PHONE"].ToString(),
                    FAX = MyDataRow["FAX"].ToString(),
                    TAXOFF = MyDataRow["TAXOFF"].ToString(),
                    TAXNR = MyDataRow["TAXNR"].ToString(),
                    SECURNR = MyDataRow["SECURNR"].ToString(),
                    SITEID = MyDataRow["SITEID"] != DBNull.Value ? (Int16?)Convert.ToInt16(MyDataRow["SITEID"]) : null,
                    USEREXT = MyDataRow["USEREXT"] != DBNull.Value ? (int?)Convert.ToInt32(MyDataRow["USEREXT"]) : null,
                    TAXOFFCODE = MyDataRow["TAXOFFCODE"].ToString(),
                    CNTRYCODE = MyDataRow["CNTRYCODE"].ToString(),
                    MODDATE = MyDataRow["MODDATE"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(MyDataRow["MODDATE"]) : null,
                    MODTIME = MyDataRow["MODTIME"] != DBNull.Value ? (int?)Convert.ToInt32(MyDataRow["MODTIME"]) : null,
                    ISKURNR = MyDataRow["ISKURNR"].ToString(),
                    FOUNDDATE = MyDataRow["FOUNDDATE"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(MyDataRow["FOUNDDATE"]) : null,
                    ISKURDEPT = MyDataRow["ISKURDEPT"].ToString(),
                    INDSECTOR = MyDataRow["INDSECTOR"].ToString(),
                    LOGOID = MyDataRow["LOGOID"].ToString(),
                    SGKUSERNAME = MyDataRow["SGKUSERNAME"].ToString(),
                    SGKUSERCODE = MyDataRow["SGKUSERCODE"].ToString(),
                    SGKSYSPASS = MyDataRow["SGKSYSPASS"].ToString(),
                    DIVPASSWORD = MyDataRow["DIVPASSWORD"].ToString(),
                    ISKURTCKNO = MyDataRow["ISKURTCKNO"].ToString(),
                    ISKURPASS = MyDataRow["ISKURPASS"].ToString(),
                    CSGBWORKCODE = MyDataRow["CSGBWORKCODE"].ToString(),
                    CSGBFILENO = MyDataRow["CSGBFILENO"].ToString(),
                    PASSIVE = MyDataRow["PASSIVE"] != DBNull.Value ? (Int16?)Convert.ToInt16(MyDataRow["PASSIVE"]) : null,
                    USEEINV = MyDataRow["USEEINV"] != DBNull.Value ? (Int16?)Convert.ToInt16(MyDataRow["USEEINV"]) : null,
                    POSTLABELCODE = MyDataRow["POSTLABELCODE"].ToString(),
                    SENDERLABELCODE = MyDataRow["SENDERLABELCODE"].ToString(),
                    WEBADD = MyDataRow["WEBADD"].ToString(),
                    EMAILADDR = MyDataRow["EMAILADDR"].ToString(),
                    FIRMTYPE = MyDataRow["FIRMTYPE"] != DBNull.Value ? (Int16?)Convert.ToInt16(MyDataRow["FIRMTYPE"]) : null,
                    NACECODE = MyDataRow["NACECODE"].ToString(),
                    USEEBOOK = MyDataRow["USEEBOOK"] != DBNull.Value ? (Int16?)Convert.ToInt16(MyDataRow["USEEBOOK"]) : null,
                    TRADEREGISNO = MyDataRow["TRADEREGISNO"].ToString(),
                    MERSISNO = MyDataRow["MERSISNO"].ToString(),
                    TITLE = MyDataRow["TITLE"].ToString(),
                    EBOOKFILENO = MyDataRow["EBOOKFILENO"] != DBNull.Value ? (Int16?)Convert.ToInt16(MyDataRow["EBOOKFILENO"]) : null,
                    USEEARCHIVE = MyDataRow["USEEARCHIVE"] != DBNull.Value ? (Int16?)Convert.ToInt16(MyDataRow["USEEARCHIVE"]) : null,
                    INTSALESADDR = MyDataRow["INTSALESADDR"].ToString(),
                    EBOOKSTARTDATE = MyDataRow["EBOOKSTARTDATE"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(MyDataRow["EBOOKSTARTDATE"]) : null,
                    EBOOKDIVNAME = MyDataRow["EBOOKDIVNAME"].ToString(),
                    EBOOKFIRMNAME = MyDataRow["EBOOKFIRMNAME"].ToString(),
                    EBOOKFIRMTITLE = MyDataRow["EBOOKFIRMTITLE"].ToString(),
                    EBOOKCURRTYPE = MyDataRow["EBOOKCURRTYPE"] != DBNull.Value ? (Int16?)Convert.ToInt16(MyDataRow["EBOOKCURRTYPE"]) : null,
                    EARCENTSEND = MyDataRow["EARCENTSEND"] != DBNull.Value ? (Int16?)Convert.ToInt16(MyDataRow["EARCENTSEND"]) : null,
                    EARCENTUSER = MyDataRow["EARCENTUSER"].ToString(),
                    EARCENTPASS = MyDataRow["EARCENTPASS"].ToString(),
                    EARCENTDEFADDR = MyDataRow["EARCENTDEFADDR"].ToString(),
                    LASTCONTROLNO = MyDataRow["LASTCONTROLNO"] != DBNull.Value ? (int?)Convert.ToInt32(MyDataRow["LASTCONTROLNO"]) : null,
                    LASTJOURNALNO = MyDataRow["LASTJOURNALNO"] != DBNull.Value ? (int?)Convert.ToInt32(MyDataRow["LASTJOURNALNO"]) : null,
                    LASTGLOBLINENO = MyDataRow["LASTGLOBLINENO"] != DBNull.Value ? (int?)Convert.ToInt32(MyDataRow["LASTGLOBLINENO"]) : null,
                    BACKUPEBOOKS = MyDataRow["BACKUPEBOOKS"] != DBNull.Value ? (Int16?)Convert.ToInt16(MyDataRow["BACKUPEBOOKS"]) : null,
                    EINVCUSTOM = MyDataRow["EINVCUSTOM"] != DBNull.Value ? (Int16?)Convert.ToInt16(MyDataRow["EINVCUSTOM"]) : null,
                    EINVOICETYPSGK = MyDataRow["EINVOICETYPSGK"] != DBNull.Value ? (Int16?)Convert.ToInt16(MyDataRow["EINVOICETYPSGK"]) : null,
                    TAXPAYERCODE = MyDataRow["TAXPAYERCODE"].ToString(),
                    TAXPAYERNAME = MyDataRow["TAXPAYERNAME"].ToString(),
                    CPATITLE = MyDataRow["CPATITLE"] != DBNull.Value ? (Int16?)Convert.ToInt16(MyDataRow["CPATITLE"]) : null,
                    CPAIDTCNO = MyDataRow["CPATITLE"].ToString(),
                    CPANAME = MyDataRow["CPANAME"].ToString(),
                    CPASURNAME = MyDataRow["CPASURNAME"].ToString(),
                    CPASTREET = MyDataRow["CPASTREET"].ToString(),
                    CPAROAD = MyDataRow["CPAROAD"].ToString(),
                    CPADOORNR = MyDataRow["CPADOORNR"].ToString(),
                    CPADISTRICT = MyDataRow["CPADISTRICT"].ToString(),
                    CPACITY = MyDataRow["CPACITY"].ToString(),
                    CPAPHONE = MyDataRow["CPAPHONE"].ToString(),
                    CPATAXOFF = MyDataRow["CPATAXOFF"].ToString(),
                    CPATAXNR = MyDataRow["CPATAXNR"].ToString(),
                    CPACHAMBNR = MyDataRow["CPACHAMBNR"].ToString(),
                    CPAEMAIL = MyDataRow["CPAEMAIL"].ToString(),
                    CPAUSERCODE = MyDataRow["CPAUSERCODE"].ToString(),
                    CPAPAROLE = MyDataRow["CPAPAROLE"].ToString(),
                    CPAPASSWORDTAXDECL = MyDataRow["CPAPASSWORDTAXDECL"].ToString(),
                    CPACNTRYCODE = MyDataRow["CPACNTRYCODE"].ToString(),
                    CPACOUNTRY = MyDataRow["CPACOUNTRY"].ToString(),
                    CPAZIPCODE = MyDataRow["CPAZIPCODE"].ToString(),
                    CPAFAXNR = MyDataRow["CPAFAXNR"].ToString(),
                    CPACONTRACTDESC = MyDataRow["CPACONTRACTDESC"].ToString(),
                    CPACONTRACTTYPE = MyDataRow["CPACONTRACTTYPE"].ToString(),
                    CPACONTRACTDATE = MyDataRow["CPACONTRACTDATE"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(MyDataRow["CPACONTRACTDATE"]) : null,
                    CPACONTRACTNUMBER = MyDataRow["CPACONTRACTNUMBER"].ToString(),
                    CPAISEBOOKKEPTBYFIRM = MyDataRow["CPAISEBOOKKEPTBYFIRM"] != DBNull.Value ? (Int16?)Convert.ToInt16(MyDataRow["CPAISEBOOKKEPTBYFIRM"]) : null,
                    CPAISYMMCONTRACTMADE = MyDataRow["CPAISYMMCONTRACTMADE"] != DBNull.Value ? (Int16?)Convert.ToInt16(MyDataRow["CPAISYMMCONTRACTMADE"]) : null,
                    CPAYMMNAME = MyDataRow["CPAYMMNAME"].ToString(),
                    CPAYMMCONTDESC = MyDataRow["CPAYMMCONTDESC"].ToString(),
                    CPAYMMCONTTYPE = MyDataRow["CPAYMMCONTTYPE"].ToString(),
                    CPAYMMPHONE = MyDataRow["CPAYMMPHONE"].ToString(),
                    CPAYMMEMAIL = MyDataRow["CPAYMMEMAIL"].ToString(),
                    CPAYMMSURNAME = MyDataRow["CPAYMMSURNAME"].ToString(),
                    CPAYMMCONTDATE = MyDataRow["CPAYMMCONTDATE"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(MyDataRow["CPAYMMCONTDATE"]) : null,
                    CPAYMMCONTNUMBER = MyDataRow["CPAYMMCONTNUMBER"].ToString(),
                    CPAYMMFAXNR = MyDataRow["CPAYMMFAXNR"].ToString(),
                    USEEDESPATCH = MyDataRow["USEEDESPATCH"] != DBNull.Value ? (Int16?)Convert.ToInt16(MyDataRow["USEEDESPATCH"]) : null,
                    POSTLABELCODEDESP = MyDataRow["POSTLABELCODEDESP"].ToString(),
                    SENDERLABELCODEDESP = MyDataRow["SENDERLABELCODEDESP"].ToString(),
                    USEEPRODUCERREC = MyDataRow["USEEPRODUCERREC"] != DBNull.Value ? (Int16?)Convert.ToInt16(MyDataRow["USEEPRODUCERREC"]) : null,
                    USEETRADESMANINV = MyDataRow["USEETRADESMANINV"] != DBNull.Value ? (Int16?)Convert.ToInt16(MyDataRow["USEETRADESMANINV"]) : null,
                    LOCBRANCHCODE = MyDataRow["LOCBRANCHCODE"].ToString(),
                    LOCBRANCHADDRESSNR = MyDataRow["LOCBRANCHADDRESSNR"].ToString(),
                    PROPERTYSTATUS = MyDataRow["PROPERTYSTATUS"] != DBNull.Value ? (Int16?)Convert.ToInt16(MyDataRow["PROPERTYSTATUS"]) : null,
                    LOCATIONTYPE = MyDataRow["LOCATIONTYPE"] != DBNull.Value ? (Int16?)Convert.ToInt16(MyDataRow["LOCATIONTYPE"]) : null,
                    EARCHIVETYPE = MyDataRow["EARCHIVETYPE"] != DBNull.Value ? (Int16?)Convert.ToInt16(MyDataRow["EARCHIVETYPE"]) : null,
                    USEPAPERINV = MyDataRow["USEPAPERINV"] != DBNull.Value ? (Int16?)Convert.ToInt16(MyDataRow["USEPAPERINV"]) : null,
                    TRADEREGCODE = MyDataRow["TRADEREGCODE"] != DBNull.Value ? (Int16?)Convert.ToInt16(MyDataRow["TRADEREGCODE"]) : null,
                    ISCCCLIENT = MyDataRow["ISCCCLIENT"] != DBNull.Value ? (Int16?)Convert.ToInt16(MyDataRow["ISCCCLIENT"]) : null,
                });
            }

            gridIsyeri.DataSource = list;

        }
        public void KullanicininListesiniGetir()
        {

            int kullanici = Convert.ToInt32(_kullanici.kullaniciid);
            if (kullanici == null) return; // Seçili Ambar Ve işyeri Tıklanmış Gelsin
            clas.Connect();
            string sqlParametre = $@"select * from LOGO_XERO_KULLANICI_AMBAR_ISYERI_YETKI where KULLANICIID = '{kullanici}' AND FIRMANO = '{firma}'";
            SqlCommand cmd = new SqlCommand(sqlParametre, clas.Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            List<LOGO_XERO_KULLANICI_AMBAR_ISYERI_YETKI> kullanicikayitlari = new List<LOGO_XERO_KULLANICI_AMBAR_ISYERI_YETKI>();
            DataSet ds = new DataSet();
            da.Fill(ds);


            foreach (DataRow MyDataRow in ds.Tables[0].Rows)
            {

                kullanicikayitlari.Add(new LOGO_XERO_KULLANICI_AMBAR_ISYERI_YETKI()
                {
                    ID = (int)MyDataRow["ID"],
                    KULLANICIID = (int)MyDataRow["KULLANICIID"],
                    FIRMANO = (string)MyDataRow["FIRMANO"],
                    AMBARID = (short)MyDataRow["AMBARID"],
                    ISYERIID = (short)MyDataRow["ISYERIID"],
                });
            }
            if (kullanicikayitlari.Count > 0)
            {
                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    L_CAPIDIV row = (L_CAPIDIV)gridView1.GetRow(i);
                    if (row != null)
                    {
                        LOGO_XERO_KULLANICI_AMBAR_ISYERI_YETKI kay = kullanicikayitlari.Where(s => s.ISYERIID == row.NR).FirstOrDefault();
                        if (kay != null)
                        {
                            gridView1.SelectRow(i);
                        }
                    }
                }
                for (int i = 0; i < gridView2.DataRowCount; i++)
                {
                    ISYERI_AMBAR row = (ISYERI_AMBAR)gridView2.GetRow(i);
                    if (row != null)
                    {
                        LOGO_XERO_KULLANICI_AMBAR_ISYERI_YETKI kay = kullanicikayitlari.Where(s => s.AMBARID == row.NR).FirstOrDefault();
                        if (kay != null)
                        {
                            gridView2.SelectRow(i);
                        }
                    }
                }
            }

        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            L_CAPIDIV seciliIsyeri = (L_CAPIDIV)gridView1.GetRow(e.ControllerRow);
            if (seciliIsyeri != null)
            {
                List<ISYERI_AMBAR> liste = GridAmbar.DataSource as List<ISYERI_AMBAR>;

                clas.Connect();
                string sql = $@"select C.NR,C.NAME,D.NAME ISYERI,D.NR ISYERINR from L_CAPIWHOUSE C
LEFT OUTER JOIN L_CAPIDIV D ON C.DIVISNR=D.NR AND D.FIRMNR={firma}
 WHERE C.DIVISNR={seciliIsyeri.NR} AND C.FIRMNR={firma} ";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                List<ISYERI_AMBAR> yenlis = new List<ISYERI_AMBAR>();
                foreach (DataRow MyDataRow in ds.Tables[0].Rows)
                {

                    yenlis.Add(new ISYERI_AMBAR()
                    {
                        NR = (Int16)MyDataRow["NR"],
                        NAME = (string)MyDataRow["NAME"],
                        ISYERI = (string)MyDataRow["ISYERI"],
                        ISYERINR = (short)MyDataRow["ISYERINR"]
                    });
                }



                //  List<ISYERI_AMBAR> yenlis =ds.Tables[0] as List<ISYERI_AMBAR>;
                if (liste == null)
                {
                    liste = new List<ISYERI_AMBAR>();
                }
                if (e.Action == CollectionChangeAction.Add)
                {
                    liste.AddRange(yenlis);
                }
                if (e.Action == CollectionChangeAction.Remove)
                {
                    foreach (var item in yenlis)
                    {
                        var kay = liste.Where(s => s.ISYERINR == item.ISYERINR && s.NR == item.NR).FirstOrDefault();
                        if (kay != null)
                        {
                            liste.Remove(kay);
                        }

                    }
                }
                GridAmbar.DataSource = liste;
                GridAmbar.RefreshDataSource();
            }
            else
            {
                int[] secililer = gridView1.GetSelectedRows();
                if (secililer.Length > 0)
                {
                    Int16[] isyerinr = new Int16[secililer.Count()];
                    for (int i = 0; i < secililer.Count(); i++)
                    {
                        L_CAPIDIV row = (L_CAPIDIV)gridView1.GetRow(i);
                        isyerinr[i] = Convert.ToInt16(row.NR);
                    }

                    string sql = $@"select C.NR,C.NAME,D.NAME ISYERI,D.NR ISYERINR from L_CAPIWHOUSE C
LEFT OUTER JOIN L_CAPIDIV D ON C.DIVISNR=D.NR AND D.FIRMNR={firma}
 WHERE C.DIVISNR IN({string.Join(",", isyerinr)}) AND C.FIRMNR={firma} ";
                    SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    List<ISYERI_AMBAR> yenlis = new List<ISYERI_AMBAR>();
                    foreach (DataRow MyDataRow in ds.Tables[0].Rows)
                    {

                        yenlis.Add(new ISYERI_AMBAR()
                        {
                            NR = (Int16)MyDataRow["NR"],
                            NAME = (string)MyDataRow["NAME"],
                            ISYERI = (string)MyDataRow["ISYERI"],
                            ISYERINR = (short)MyDataRow["ISYERINR"]
                        });
                    }
                    GridAmbar.DataSource = yenlis;
                    GridAmbar.RefreshDataSource();

                }
                else
                {

                    GridAmbar.DataSource = null;
                    GridAmbar.RefreshDataSource();
                }

            }


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            List<ISYERI_AMBAR> liste = new List<ISYERI_AMBAR>();
            int[] secililer = gridView2.GetSelectedRows();
            if (secililer.Length == 0)
            {
                XtraMessageBox.Show($"SEÇİM YAPMADAN KAYIT EKLEYEMEZSİNİZ!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                liste = gridView2.DataSource as List<ISYERI_AMBAR>;
                int kullaniciambar = Convert.ToInt32(kln.AMBAR);
                int kullaniciisyeri = Convert.ToInt32(kln.ISYERI);
                var kay = liste.Where(s => s.NR == kullaniciambar && s.ISYERINR == kullaniciisyeri).FirstOrDefault();
                if (kay == null)
                {
                    XtraMessageBox.Show($"KULLANICIDA TANIMLI İŞYERİ VE AMBARI SEÇMEDEN LİSTEYİ KAYDEDEMEZSİNİZ ! ( KULLANICI İŞYERİ = " + _kullanici.lk_isyeri.Text + " /  KULLANICI AMBARI = " + _kullanici.lk_ambar.Text + " )", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                clas.Connect();
                clas.Conn.Open();
                SqlCommand VeriKaydet = new SqlCommand($@"DELETE FROM LOGO_XERO_KULLANICI_AMBAR_ISYERI_YETKI WHERE KULLANICIID={kln.ID} ", clas.Conn);
                VeriKaydet.ExecuteNonQuery();
                for (int i = 0; i < secililer.Count(); i++)
                {
                    int selectedRowHandle = secililer[i];
                    if (selectedRowHandle >= 0)
                    {
                        ISYERI_AMBAR row = (ISYERI_AMBAR)gridView2.GetRow(selectedRowHandle);
                        SqlCommand VERIGUNCELLE = new SqlCommand($@"INSERT INTO [dbo].[LOGO_XERO_KULLANICI_AMBAR_ISYERI_YETKI]
                                                                        ([KULLANICIID]
                                                                        ,[FIRMANO]
                                                                        ,[AMBARID]
                                                                        ,[ISYERIID])
                                                                  VALUES
                                                                        (@KULLANICIID
                                                                        ,@FIRMANO
                                                                        ,@AMBARID
                                                                        ,@ISYERIID)", clas.Conn);

                        VERIGUNCELLE.Parameters.AddWithValue("@KULLANICIID", Convert.ToInt32(kln.ID));
                        VERIGUNCELLE.Parameters.AddWithValue("@FIRMANO", ana.lk_firma.EditValue.ToString());
                        VERIGUNCELLE.Parameters.AddWithValue("@AMBARID", row.NR);
                        VERIGUNCELLE.Parameters.AddWithValue("@ISYERIID", row.ISYERINR);
                        VERIGUNCELLE.ExecuteNonQuery();

                    }
                }
                clas.Conn.Close();
                XtraMessageBox.Show($"İŞLEM BAŞARILI !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {
                XtraMessageBox.Show($"İŞLEM BAŞARISIZ !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
    }
}