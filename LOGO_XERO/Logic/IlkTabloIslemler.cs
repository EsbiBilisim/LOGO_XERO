using DevExpress.XtraCharts.Native;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraReports.UI;
using LOGO_XERO.Models;
using LOGO_XERO.Models.GenelKullanim;
using LOGO_XERO.Models.LOGO_M;
using LOGO_XERO.Models.LOGO_XERO_M;
using LOGO_XERO.Moduller._7_Raporlar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LOGO_XERO.Logic
{
    public class IlkTabloIslemler
    {
        SQLConnection clas = new SQLConnection();

        public LOGO_XERO_KULLANICILAR DataSetliKullaniciBilgisiGetir(int id)
        {
            LOGO_XERO_KULLANICILAR kul = new LOGO_XERO_KULLANICILAR();
            try
            {
                clas.Connect();
                string sql = $@"SELECT * FROM LOGO_XERO_KULLANICILAR WHERE ID={id}";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        kul.ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"]);
                        kul.LOGOSATISELEMANIID = ds.Tables[0].Rows[i]["LOGOSATISELEMANIID"].ToString();
                        kul.KULLANICIADI = ds.Tables[0].Rows[i]["KULLANICIADI"].ToString();
                        kul.SIFRE = ds.Tables[0].Rows[i]["SIFRE"].ToString();
                        kul.TANIMLIFIRMA = ds.Tables[0].Rows[i]["TANIMLIFIRMA"].ToString();
                        kul.TANIMLIDONEM = ds.Tables[0].Rows[i]["TANIMLIDONEM"].ToString();
                        kul.ISYERI = Convert.ToInt16(ds.Tables[0].Rows[i]["ISYERI"]);
                        kul.BOLUM = Convert.ToInt16(ds.Tables[0].Rows[i]["BOLUM"]);
                        kul.FABRIKA = Convert.ToInt16(ds.Tables[0].Rows[i]["FABRIKA"]);
                        kul.AMBAR = Convert.ToInt16(ds.Tables[0].Rows[i]["AMBAR"]);

                    }
                }
            }
            catch
            {
            }
            return kul;

        }

        public LOGO_XERO_PARAMETRELER DataSetliParametrelerGetir(string firmano, string donem)
        {
            LOGO_XERO_PARAMETRELER parametre = new LOGO_XERO_PARAMETRELER();
            try
            {
                clas.Connect();
                string sql = $@"SELECT * FROM LOGO_XERO_PARAMETRELER WHERE FIRMANO='{firmano}' AND DONEMNO='{donem}'";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        parametre.FYTPRMT_OZELFIYATSECENEGI = Convert.ToInt32(ds.Tables[0].Rows[i]["FYTPRMT_OZELFIYATSECENEGI"].ToString());
                        parametre.FYTPRMT_PERAKENDEFIYATGRUBU = ds.Tables[0].Rows[i]["FYTPRMT_PERAKENDEFIYATGRUBU"].ToString();
                        parametre.FYTPRMT_FIYATGRUBU = ds.Tables[0].Rows[i]["FYTPRMT_FIYATGRUBU"].ToString();
                        parametre.FYTPRMT_ETICARETFIYATGRUBU = ds.Tables[0].Rows[i]["FYTPRMT_ETICARETFIYATGRUBU"].ToString();
                        parametre.FYTPRMT_ETICARETFIYATGRUBU = ds.Tables[0].Rows[i]["FYTPRMT_ETICARETFIYATGRUBU"].ToString();
                        parametre.OZELFIYATKARTSUTUNAD = ds.Tables[0].Rows[i]["OZELFIYATKARTSUTUNAD"].ToString();


                    }
                }
            }
            catch
            {
            }
            return parametre;

        }
        public bool KDVMATRAHOLUSTUR(string firma, string donem)
        {
            using (LogoContext db = new LogoContext())
            {
                try
                {
                    string sql = $@"CREATE FUNCTION [dbo].[KDVMATRAH_{firma}_{donem}] (@LREF INT , @VAT INT )
RETURNS FLOAT
AS
BEGIN
   DECLARE @BARKOD FLOAT

   SET @BARKOD=

(SELECT SUM(VATMATRAH) FROM LG_{firma}_{donem}_STLINE WHERE LINETYPE IN (0,4) AND VAT=@VAT AND INVOICEREF=@LREF)

;
 RETURN(@BARKOD)
END";
                    db.Database.ExecuteSqlCommand(sql);
                    return true;
                }
                catch
                {
                    string sql = $@"ALTER FUNCTION [dbo].[KDVMATRAH_{firma}_{donem}] (@LREF INT , @VAT INT )
RETURNS FLOAT
AS
BEGIN
   DECLARE @BARKOD FLOAT

   SET @BARKOD=

(SELECT SUM(VATMATRAH) FROM LG_{firma}_{donem}_STLINE WHERE LINETYPE IN (0,4) AND VAT=@VAT AND INVOICEREF=@LREF)

;
 RETURN(@BARKOD)
END";
                    db.Database.ExecuteSqlCommand(sql);
                    return false;
                }
                finally
                {

                }
            }


        }

        public void DuyurularTablosuOlustur(string firma, string donem)
        {
            try
            {
                clas.Connect();
                string sql = $@"CREATE TABLE [dbo].[LOGO_XERO_DUYURULAR_{firma}_{donem}](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TARIH] [datetime] NULL,
	[ACIKLAMA] [nvarchar](272) NULL,
	[PERSONEL] [nvarchar](50) NULL,
	[IPTALID] [int] NULL,
	[ONCELIKLI] [bit] NULL,
 CONSTRAINT [PK_LOGO_XERO_DUYURULAR_{firma}_{donem}] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] 
 ";

                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();
            }
            catch
            {
                clas.Conn.Close();
            }
        }

        public void ESBI_CARIVADE_FonksiyonuOlustur(string firma, string donem)
        {
            try
            {
                clas.Connect();
                string sql = $@"CREATE FUNCTION [dbo].[ESBI_CARIVADEGUN_{firma}] (@LOGICALREF INT) RETURNS FLOAT
            AS
            BEGIN
               DECLARE @VADEGUN FLOAT 
               DECLARE @VADETUTAR  FLOAT  
               DECLARE @ISLEMTUTATOPLAM FLOAT
               SET @VADETUTAR = ( SELECT  SUM(DATEDIFF(DAY,GETDATE(),DATE_)*(TOTAL-PAID) ) FROM LG_{firma}_{donem}_PAYTRANS WHERE CARDREF=@LOGICALREF AND TOTAL-PAID >0 AND CANCELLED=0)
               SET @ISLEMTUTATOPLAM = (SELECT SUM(TOTAL-PAID)  FROM LG_{firma}_{donem}_PAYTRANS WHERE CARDREF=@LOGICALREF AND TOTAL-PAID >0 AND CANCELLED=0)
               SET @VADEGUN = (@VADETUTAR/@ISLEMTUTATOPLAM)

             RETURN(@VADEGUN)
             END 
 ";

                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();
            }
            catch
            {
                clas.Conn.Close();
            }
        }





        public void HatirlatmalarTablosuOlustur(string firma, string donem)
        {
            try
            {
                clas.Connect();
                string sql = $@"CREATE TABLE [dbo].[LOGO_XERO_HATIRLATMA_{firma}_{donem}](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TIP] [int] NOT NULL,
	[TEKLIFID] [int] NOT NULL,
	[PERSONEL] [nvarchar](50) NULL,
	[TARIH] [datetime] NULL,
	[HATIRLATMATARIHI] [datetime] NULL,
	[TEKLIFNO] [nvarchar](50) NULL,
	[ACIKLAMA] [nvarchar](350) NULL,
	[OKUNDU] [bit] NULL,
 CONSTRAINT [PK_LOGO_XERO_HATIRLATMA_{firma}_{donem}] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)) ON [PRIMARY]
 ";

                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();
            }
            catch
            {
                clas.Conn.Close();
            }
        }

        public void RenkTablosuOlustur()
        {
            try
            {
                clas.Connect();
                string sql = $@"CREATE TABLE [dbo].[LOGO_XERO_KAR_ZARAR_RENK](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[YUZDEBASLANGIC] [nvarchar](50) NULL,
	[YUZDEBITIS] [nchar](50) NULL,
	[RENK] [nvarchar](max) NULL,
    [TIP] [int] NULL
 CONSTRAINT [PK_LOGO_XERO_KAR_ZARAR_RENK] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)) ON [PRIMARY] 
;";

                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();
            }
            catch
            {
                clas.Conn.Close();
            }
        }
        public bool logoxerokarzararonaytablosuolustur(string firma, string donem)

        {
            using (LogoContext db = new LogoContext())
            {
                try
                {
                    string sql = $@"CREATE TABLE [dbo].[LOGO_XERO_KAR_ZARAR_ONAY_{firma}_{donem}](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LOGICALREF] [int] NULL,
	[TARIH] [datetime] NULL,
	[ONAY] [bit] NULL,
 CONSTRAINT [PK_LOGO_XERO_KAR_ZARAR_ONAY_{firma}_{donem}] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]";
                    db.Database.ExecuteSqlCommand(sql);
                    return true;
                }
                catch
                {

                    return false;
                }
            }



        }
        public bool KDVTUTAROLUSTUR(string firma, string donem)
        {
            using (LogoContext db = new LogoContext())
            {
                try
                {
                    string sql = $@"CREATE FUNCTION [dbo].[KDVTUTAR_{firma}_{donem}] (@LREF INT,@VAT INT )
RETURNS FLOAT
AS
BEGIN
   DECLARE @BARKOD FLOAT

   SET @BARKOD=

(SELECT SUM(VATAMNT) FROM LG_{firma}_{donem}_STLINE WHERE LINETYPE IN (0,4) AND VAT=@VAT AND INVOICEREF=@LREF)

;
 RETURN(@BARKOD)
END";
                    db.Database.ExecuteSqlCommand(sql);
                    return true;
                }
                catch
                {
                    string sql = $@"ALTER FUNCTION [dbo].[KDVTUTAR_{firma}_{donem}] (@LREF INT,@VAT INT )
RETURNS FLOAT
AS
BEGIN
   DECLARE @BARKOD FLOAT

   SET @BARKOD=

(SELECT SUM(VATAMNT) FROM LG_{firma}_{donem}_STLINE WHERE LINETYPE IN (0,4) AND VAT=@VAT AND INVOICEREF=@LREF)

;
 RETURN(@BARKOD)
END";
                    db.Database.ExecuteSqlCommand(sql);
                    return false;
                }
                finally
                {

                }
            }


        }
        public void ambarsorgudondur(string firma, LookUpEdit lk, LookUpEdit isyeri)
        {
            clas.Connect();
            string sqlParametre = $@"select NR AS CODE,NAME  AS NAME from L_CAPIWHOUSE where FIRMNR = '{firma}' AND DIVISNR = '{isyeri.EditValue}'";
            SqlCommand cmd = new SqlCommand(sqlParametre, clas.Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            List<CODENAME> denemes = new List<CODENAME>();
            DataSet ds = new DataSet();
            da.Fill(ds);


            foreach (DataRow MyDataRow in ds.Tables[0].Rows)
            {

                denemes.Add(new CODENAME()
                {
                    CODE = MyDataRow["CODE"].ToString(),
                    NAME = MyDataRow["NAME"].ToString()
                });
            }
            lk.Properties.DisplayMember = "NAME";
            lk.Properties.ValueMember = "CODE";
            lk.Properties.DataSource = denemes;
        }
        public void isyerisorgudondur(string firma, LookUpEdit lk)
        {
            clas.Connect();
            string sqlParametre = $@"select NR AS CODE,NAME AS NAME from L_CAPIDIV where FIRMNR = '{firma}'";
            SqlCommand cmd = new SqlCommand(sqlParametre, clas.Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            List<CODENAME> denemes = new List<CODENAME>();
            DataSet ds = new DataSet();
            da.Fill(ds);


            foreach (DataRow MyDataRow in ds.Tables[0].Rows)
            {

                denemes.Add(new CODENAME()
                {
                    CODE = MyDataRow["CODE"].ToString(),
                    NAME = MyDataRow["NAME"].ToString()
                });
            }
            lk.Properties.DisplayMember = "NAME";
            lk.Properties.ValueMember = "CODE";
            lk.Properties.DataSource = denemes;
        }
        public void fabrikasorgudondur(string firma, LookUpEdit lk)
        {
            clas.Connect();
            string sqlParametre = $@"select NR AS CODE,NAME AS NAME from L_CAPIFACTORY where FIRMNR = '{firma}' ";
            SqlCommand cmd = new SqlCommand(sqlParametre, clas.Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            List<CODENAME> denemes = new List<CODENAME>();
            DataSet ds = new DataSet();
            da.Fill(ds);


            foreach (DataRow MyDataRow in ds.Tables[0].Rows)
            {

                denemes.Add(new CODENAME()
                {
                    CODE = MyDataRow["CODE"].ToString(),
                    NAME = MyDataRow["NAME"].ToString()
                });
            }
            lk.Properties.DisplayMember = "NAME";
            lk.Properties.ValueMember = "CODE";
            lk.Properties.DataSource = denemes;
        }
        public void bolumsorgudondur(string firma, LookUpEdit lk)
        {
            clas.Connect();
            string sqlParametre = $@"select NR AS CODE,NAME AS NAME from L_CAPIDEPT where FIRMNR = '{firma}'";
            SqlCommand cmd = new SqlCommand(sqlParametre, clas.Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            List<CODENAME> denemes = new List<CODENAME>();
            DataSet ds = new DataSet();
            da.Fill(ds);


            foreach (DataRow MyDataRow in ds.Tables[0].Rows)
            {

                denemes.Add(new CODENAME()
                {
                    CODE = MyDataRow["CODE"].ToString(),
                    NAME = MyDataRow["NAME"].ToString()
                });
            }
            lk.Properties.DisplayMember = "NAME";
            lk.Properties.ValueMember = "CODE";
            lk.Properties.DataSource = denemes;

            //lk_girisbolum.Properties.DisplayMember = "NAME";
            //lk_girisbolum.Properties.ValueMember = "CODE";
            //lk_girisbolum.Properties.DataSource = denemes;
        }
        public void ambarsorgudondur(string firma, RepositoryItemLookUpEdit lk, RepositoryItemLookUpEdit isyeri)
        {
            clas.Connect();
            string sqlParametre = $@"select NR AS CODE,NAME  AS NAME from L_CAPIWHOUSE where FIRMNR = '{firma}'"; /*AND DIVISNR = '{isye}*/
            SqlCommand cmd = new SqlCommand(sqlParametre, clas.Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            List<CODENAME> denemes = new List<CODENAME>();
            DataSet ds = new DataSet();
            da.Fill(ds);


            foreach (DataRow MyDataRow in ds.Tables[0].Rows)
            {

                denemes.Add(new CODENAME()
                {
                    CODE = MyDataRow["CODE"].ToString(),
                    NAME = MyDataRow["NAME"].ToString()
                });
            }
            lk.DisplayMember = "NAME";
            lk.ValueMember = "CODE";
            lk.DataSource = denemes;
        }
        public void isyerisorgudondur(string firma, RepositoryItemLookUpEdit lk)
        {
            clas.Connect();
            string sqlParametre = $@"select NR AS CODE,NAME AS NAME from L_CAPIDIV where FIRMNR = '{firma}'";
            SqlCommand cmd = new SqlCommand(sqlParametre, clas.Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            List<CODENAME> denemes = new List<CODENAME>();
            DataSet ds = new DataSet();
            da.Fill(ds);


            foreach (DataRow MyDataRow in ds.Tables[0].Rows)
            {

                denemes.Add(new CODENAME()
                {
                    CODE = MyDataRow["CODE"].ToString(),
                    NAME = MyDataRow["NAME"].ToString()
                });
            }
            lk.DisplayMember = "NAME";
            lk.ValueMember = "CODE";
            lk.DataSource = denemes;
        }
        public void fabrikasorgudondur(string firma, RepositoryItemLookUpEdit lk)
        {
            clas.Connect();
            string sqlParametre = $@"select NR AS CODE,NAME AS NAME from L_CAPIFACTORY where FIRMNR = '{firma}' ";
            SqlCommand cmd = new SqlCommand(sqlParametre, clas.Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            List<CODENAME> denemes = new List<CODENAME>();
            DataSet ds = new DataSet();
            da.Fill(ds);


            foreach (DataRow MyDataRow in ds.Tables[0].Rows)
            {

                denemes.Add(new CODENAME()
                {
                    CODE = MyDataRow["CODE"].ToString(),
                    NAME = MyDataRow["NAME"].ToString()
                });
            }
            lk.DisplayMember = "NAME";
            lk.ValueMember = "CODE";
            lk.DataSource = denemes;
        }
        public void bolumsorgudondur(string firma, RepositoryItemLookUpEdit lk)
        {
            clas.Connect();
            string sqlParametre = $@"select NR as CODE,NAME  AS NAME from L_CAPIDEPT where FIRMNR = '{firma}'";
            SqlCommand cmd = new SqlCommand(sqlParametre, clas.Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            List<CODENAME> denemes = new List<CODENAME>();
            DataSet ds = new DataSet();
            da.Fill(ds);


            foreach (DataRow MyDataRow in ds.Tables[0].Rows)
            {

                denemes.Add(new CODENAME()
                {
                    CODE = MyDataRow["CODE"].ToString(),
                    NAME = MyDataRow["NAME"].ToString()
                });
            }
            lk.DisplayMember = "NAME";
            lk.ValueMember = "CODE";
            lk.DataSource = denemes;
        }
        public void gorevsorgudondur(RepositoryItemLookUpEdit lk)
        {
            clas.Connect();
            string sqlParametre = $@"select ID AS CODE,GOREVTANIMI AS NAME from LOGO_XERO_GOREVLER";
            SqlCommand cmd = new SqlCommand(sqlParametre, clas.Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            List<CODENAME> denemes = new List<CODENAME>();
            DataSet ds = new DataSet();
            da.Fill(ds);


            foreach (DataRow MyDataRow in ds.Tables[0].Rows)
            {

                denemes.Add(new CODENAME()
                {
                    CODE = MyDataRow["CODE"].ToString(),
                    NAME = MyDataRow["NAME"].ToString()
                });
            }
            lk.DisplayMember = "NAME";
            lk.ValueMember = "CODE";
            lk.DataSource = denemes;
        }
        public void logosatiselemanisorgudondur(LookUpEdit lk, string firma)
        {
            clas.Connect();
            string sqlParametre = $@"select CODE AS CODE,DEFINITION_ AS NAME  from LG_SLSMAN WHERE FIRMNR={Convert.ToInt32(firma)}";
            SqlCommand cmd = new SqlCommand(sqlParametre, clas.Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            List<CODENAME> denemes = new List<CODENAME>();
            DataSet ds = new DataSet();
            da.Fill(ds);


            foreach (DataRow MyDataRow in ds.Tables[0].Rows)
            {

                denemes.Add(new CODENAME()
                {
                    CODE = (string)MyDataRow["CODE"],
                    NAME = (string)MyDataRow["NAME"]
                });
            }
            lk.Properties.DisplayMember = "NAME";
            lk.Properties.ValueMember = "CODE";
            lk.Properties.DataSource = denemes;
        }
        public void logosatiselemanisorgudondur(RepositoryItemLookUpEdit lk)
        {
            clas.Connect();
            string sqlParametre = $@"select CODE AS CODE,DEFINITION_ AS NAME  from LG_SLSMAN";
            SqlCommand cmd = new SqlCommand(sqlParametre, clas.Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            List<CODENAME> denemes = new List<CODENAME>();
            DataSet ds = new DataSet();
            da.Fill(ds);


            foreach (DataRow MyDataRow in ds.Tables[0].Rows)
            {

                denemes.Add(new CODENAME()
                {
                    CODE = (string)MyDataRow["CODE"],
                    NAME = (string)MyDataRow["NAME"]
                });
            }
            lk.DisplayMember = "NAME";
            lk.ValueMember = "CODE";
            lk.DataSource = denemes;
        }

        public List<LOGO_XERO_KULLANICILAR> DataSetliTumKullaniciLİstesiGetir()
        {
            List<LOGO_XERO_KULLANICILAR> kullanicilar = new List<LOGO_XERO_KULLANICILAR>();
            try
            {
                clas.Connect();
                string sql = $@"SELECT * FROM LOGO_XERO_KULLANICILAR";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        LOGO_XERO_KULLANICILAR kul = new LOGO_XERO_KULLANICILAR();
                        kul.ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"]);
                        kul.LOGOSATISELEMANIID = ds.Tables[0].Rows[i]["LOGOSATISELEMANIID"].ToString();
                        kul.KULLANICIADI = ds.Tables[0].Rows[i]["KULLANICIADI"].ToString();
                        kul.SIFRE = ds.Tables[0].Rows[i]["SIFRE"].ToString();
                        kul.TANIMLIFIRMA = ds.Tables[0].Rows[i]["TANIMLIFIRMA"].ToString();
                        kul.TANIMLIDONEM = ds.Tables[0].Rows[i]["TANIMLIDONEM"].ToString();
                        kul.ISYERI = Convert.ToInt16(ds.Tables[0].Rows[i]["ISYERI"]);
                        kul.BOLUM = Convert.ToInt16(ds.Tables[0].Rows[i]["BOLUM"]);
                        kul.FABRIKA = Convert.ToInt16(ds.Tables[0].Rows[i]["FABRIKA"]);
                        kul.AMBAR = Convert.ToInt16(ds.Tables[0].Rows[i]["AMBAR"]);
                        kullanicilar.Add(kul);

                    }
                }
            }
            catch
            {
            }
            return kullanicilar;

        }
        public List<LOGO_XERO_LISANSLAR> DataSetliLisanslistesi()
        {
            List<LOGO_XERO_LISANSLAR> lisansListesi = new List<LOGO_XERO_LISANSLAR>();
            clas.Connect();
            string sql = $@"SELECT * FROM LOGO_XERO_LISANSLAR";
            SqlCommand cmd = new SqlCommand(sql, clas.Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    LOGO_XERO_LISANSLAR yeni = new LOGO_XERO_LISANSLAR();
                    yeni.ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"]);
                    yeni.VAR = Convert.ToInt32(ds.Tables[0].Rows[i]["VAR"]);
                    yeni.MODUL = Convert.ToInt32(ds.Tables[0].Rows[i]["MODUL"]);
                    yeni.LISANSNUMARASI = ds.Tables[0].Rows[i]["LISANSNUMARASI"].ToString();
                    lisansListesi.Add(yeni);
                }
            }
            return lisansListesi;

        }
        public List<L_CAPIFIRM> DataSetlifirmalistesi()
        {
            List<L_CAPIFIRM> firmaListesi = new List<L_CAPIFIRM>();
            clas.Connect();
            string sql = $@"SELECT * FROM L_CAPIFIRM";
            SqlCommand cmd = new SqlCommand(sql, clas.Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    L_CAPIFIRM yeni = new L_CAPIFIRM();
                    yeni.NR = Convert.ToInt16(ds.Tables[0].Rows[i]["NR"]);
                    yeni.NAME = ds.Tables[0].Rows[i]["NAME"].ToString();
                    yeni.TAXNR = ds.Tables[0].Rows[i]["TAXNR"].ToString();
                    firmaListesi.Add(yeni);
                }
            }
            return firmaListesi;

        }
        public List<L_CAPIPERIOD> DataSetlidonemlistesi(string firmano)
        {
            List<L_CAPIPERIOD> donemListesi = new List<L_CAPIPERIOD>();
            clas.Connect();
            int firmnr = Convert.ToInt32(firmano);
            string sql = $@"SELECT * FROM L_CAPIPERIOD WHERE FIRMNR={firmnr}";
            SqlCommand cmd = new SqlCommand(sql, clas.Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    L_CAPIPERIOD yeni = new L_CAPIPERIOD();
                    yeni.LOGICALREF = Convert.ToInt16(ds.Tables[0].Rows[i]["LOGICALREF"]);
                    yeni.NR = Convert.ToInt16(ds.Tables[0].Rows[i]["NR"]);
                    yeni.FIRMNR = Convert.ToInt16(ds.Tables[0].Rows[i]["FIRMNR"]);
                    yeni.ACTIVE = Convert.ToInt16(ds.Tables[0].Rows[i]["ACTIVE"]);
                    yeni.PERREPCURR = Convert.ToInt16(ds.Tables[0].Rows[i]["PERREPCURR"]);
                    yeni.BEGDATE = Convert.ToDateTime(ds.Tables[0].Rows[i]["BEGDATE"]);
                    yeni.ENDDATE = Convert.ToDateTime(ds.Tables[0].Rows[i]["ENDDATE"]);
                    donemListesi.Add(yeni);
                }
            }
            return donemListesi;

        }
        public LOGO_XERO_PARAMETRELER ParametrelerGetir(string firmano)
        {
            LOGO_XERO_PARAMETRELER parametre = new LOGO_XERO_PARAMETRELER();
            clas.Connect();
            int firmnr = Convert.ToInt32(firmano);
            string sql = $@"SELECT * FROM LOGO_XERO_PARAMETRELER WHERE FIRMANO='{firmnr}'";
            SqlCommand cmd = new SqlCommand(sql, clas.Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[0]["LOGINLOGO"] != System.DBNull.Value)
                    {
                        parametre.LOGINLOGO = (byte[])ds.Tables[0].Rows[i]["LOGINLOGO"];
                    }
                }
            }
            return parametre;

        }
        public void XERO_TeklifBaslikTabloOlustur(string firma)
        {
            try
            {
                clas.Connect();
                string sql = $@"CREATE TABLE [dbo].[LOGO_XERO_TEKLIF_BASLIK_{firma}](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TRCODE] [int] NULL,
	[TARIH] [datetime] NULL,
	[SAAT] [time](7) NULL,
	[GELISTARIHI] [datetime] NULL,
	[GELISZAMANI] [time](7) NULL,
	[OPSIYONTARIHI] [datetime] NULL,
	[TEKLIFNO] [nvarchar](250) NULL,
	[BELGENO] [nvarchar](250) NULL,
	[CARIID] [int] NULL,
	[CARIKODU] [nvarchar](150) NULL,
	[CARIUNVANI] [nvarchar](150) NULL,
	[OZELKOD] [nvarchar](50) NULL,
	[YETKIKODU] [nvarchar](50) NULL,
	[TRADDINGGRP] [nvarchar](250) NULL,
	[YETKILI] [nvarchar](250) NULL,
	[TELEFON] [nvarchar](250) NULL,
	[EPOSTA] [nvarchar](250) NULL,
	[EPOSTA2] [nvarchar](250) NULL,
	[KONU] [nvarchar](250) NULL,
	[ACIKLAMA] [nvarchar](max) NULL,
	[KDVDURUMU] [bit] NULL,
	[ISYERI] [int] NULL,
	[BOLUM] [int] NULL,
	[AMBAR] [int] NULL,
	[FABRIKA] [int] NULL,
	[GENELDOVIZLIISLEMTIPI] [int] NULL,
	[SATIRLARDOVIZLIISLEMTIPI] [int] NULL,
	[SATISELEMANIKODU] [nvarchar](350) NULL,
	[HAZIRLAYANID] [int] NULL,
	[PAZARLAYANID] [int] NULL,
	[ONAYDURUMU] [int] NULL,
	[ONAYAGONDERIM] [int] NULL,
	[ONAYCEVAP] [int] NULL,
	[ONAYLAYANID] [int] NULL,
	[DURUMU] [int] NULL,
	[EFATURA] [bit] NULL,
	[ISLEMDOVIZIAYNENKALACAK] [bit] NULL,
	[FIYATLANDIRMADOVIZIAYNENKALACAK] [bit] NULL,
	[VADE] [int] NULL,
	[TANIMLIALANODEMETIPI] [int] NULL,
	[TESLIMSEKLIKODU] [nvarchar](50) NULL,
	[TASIYICIKODU] [nvarchar](50) NULL,
	[NAKLIYEBEDELI] [float] NULL,
	[PAZARLAMATIPI] [int] NULL,
	[TEVKIFATID] [bit] NULL,
	[DOVIZLIISLEMTIPI] [int] NULL,
	[ISKONTOTUTARI] [float] NULL,
	[ISKONTOLUNETTUTAR] [float] NULL,
	[KDVTUTARI] [float] NULL,
	[KDVHARICNETTUTAR] [float] NULL,
	[KDVDAHILNETTUTAR] [float] NULL,
	[DOVIZKODU] [int] NULL,
	[ISLEMDOVIZKURU] [float] NULL,
	[RAPORLAMADOVIZKURU] [float] NULL,
    [GENELACIKLAMA1] [nvarchar](51) NULL,
    [GENELACIKLAMA2] [nvarchar](51) NULL,
    [GENELACIKLAMA3] [nvarchar](51) NULL,
    [GENELACIKLAMA4] [nvarchar](51) NULL,
    [GENELACIKLAMA5] [nvarchar](51) NULL,
    [GENELACIKLAMA6] [nvarchar](51) NULL,
	[ACIKLAMA2] [nvarchar](250) NULL,
	[ACIKLAMA3] [nvarchar](250) NULL,
	[UYARIMESAJI] [int] NULL,
	[TAKIPSONUC] [nvarchar](350) NULL,
	[OZELBILGI] [nvarchar](350) NULL,
	[NOT] [nvarchar](350) NULL,
	[OZELACIKLAMA1] [nvarchar](350) NULL,
	[OZELACIKLAMA2] [nvarchar](350) NULL,
	[OZELACIKLAMA3] [nvarchar](max) NULL,
	[PROJEID] [int] NULL,
	[SEVKIYATADRESIID] [int] NULL,
	[SEVKIYATHESAPID] [int] NULL,
	[REVIZYONTEKLIFID] [int] NULL,
	[REVIZYONDURUMU] [bit] NULL,
	[REVIZYONNO] [int] NULL,
	[FATADRES1] [nvarchar](99) NULL,
	[FATADRES2] [nvarchar](99) NULL,
	[FATULKE] [nvarchar](50) NULL,
	[FATIL] [nvarchar](50) NULL,
	[FATILCE] [nvarchar](50) NULL,
	[FATPOSTAKODU] [nvarchar](50) NULL,
	[FATTEL] [nvarchar](50) NULL,
	[FATFAKS] [nvarchar](50) NULL,
	[FATVD] [nvarchar](50) NULL,
	[FATVN] [nvarchar](50) NULL,
 CONSTRAINT [PK_LOGO_XERO_TEKLIF_BASLIK_{firma}] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }

        }

        public void XERO_TeklifBaslikFaturaTipiKdvMuafiyetBilgileriEkle(string firma)
        {
            try
            {
                clas.Connect();
                string sql = $@"ALTER TABLE dbo.LOGO_XERO_TEKLIF_BASLIK_{firma} ADD [FATURATIPI] [int] DEFAULT 0 WITH VALUES;
                ALTER TABLE dbo.LOGO_XERO_TEKLIF_BASLIK_{firma} ADD [KDVMUAFIYETKODU] nvarchar(50)  DEFAULT '' WITH VALUES;
                ALTER TABLE dbo.LOGO_XERO_TEKLIF_BASLIK_{firma} ADD [KDVMUAFIYETACIKLAMA] nvarchar(MAX)  DEFAULT '' WITH VALUES;
                ALTER TABLE dbo.LOGO_XERO_TEKLIF_SATIR_{firma} ADD [KDVMUAFIYETKODU] nvarchar(50)  DEFAULT '' WITH VALUES;
                ALTER TABLE dbo.LOGO_XERO_TEKLIF_SATIR_{firma} ADD [KDVMUAFIYETACIKLAMA] nvarchar(MAX)  DEFAULT '' WITH VALUES;
                ALTER TABLE dbo.LOGO_XERO_ONAYLI_TEKLIF_SATIR_{firma} ADD [KDVMUAFIYETKODU] nvarchar(50)  DEFAULT '' WITH VALUES;
                ALTER TABLE dbo.LOGO_XERO_ONAYLI_TEKLIF_SATIR_{firma} ADD [KDVMUAFIYETACIKLAMA] nvarchar(MAX)  DEFAULT '' WITH VALUES;";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }
        }

        public void XERO_KullaniciLockTablosuOlustur(string firma, string donem)
        {
            try
            {
                clas.Connect();
                string sql = $@"CREATE TABLE [dbo].[LOGO_XERO_LOCK_{firma}_{donem}](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KULID] [int] NULL,
	[MODUL] [int] NULL,
	[REFERANS] [int] NULL,
	CONSTRAINT [PK_LOGO_XERO_LOCK_{firma}_{donem}] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)) ON [PRIMARY]
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }

        }

        public void XERO_TeklifSiparisSevkTabloOlustur(string firma)
        {
            try
            {
                clas.Connect();
                string sql = $@"CREATE TABLE [dbo].[LOGO_XERO_TEKLIF_SIPARISSEVK_TABLOSU_{firma}](
		[ID] [int] IDENTITY(1,1) NOT NULL,
	[TEKLIFID] [int] NULL,
	[TEKLIFSATIRID] [int] NOT NULL,
	[SIPARISREF] [int] NULL,
	[SIPARISSATIRREF] [int] NULL,
	[STOKREF] [int] NULL,
	[MIKTAR] [float] NULL,
	[TARIH] [datetime] NULL,
	[KULLANICIID] [int] NULL,
 CONSTRAINT [PK_LOGO_XERO_TEKLIF_SIPARISSEVK_TABLOSU_{firma}] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)) ON [PRIMARY];
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }

        }
        public void XERO_NUMARATOR_TABLOOLUSTUR()
        {
            try
            {
                clas.Connect();
                string sql = $@"CREATE TABLE [dbo].[LOGO_XERO_BELGENUMARASI_NUMARATOR](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FIRMANO] [nvarchar](3) NULL,
	[DONEMNO] [nvarchar](2) NULL,
	[SSPRS_SERI] [nvarchar](20) NULL,
	[SSPRS_SERINO] [nvarchar](20) NULL,
	[ASPRS_SERI] [nvarchar](20) NULL,
	[ASPRS_SERINO] [nvarchar](20) NULL,
	[SIRS_SERI] [nvarchar](20) NULL,
	[SIRS_SERINO] [nvarchar](20) NULL,
	[AIRS_SERI] [nvarchar](20) NULL,
	[AIRS_SERINO] [nvarchar](20) NULL,
	[SFATURA_EARSIV_SERI] [nvarchar](20) NULL,
	[SFATURA_EARSIV_SERINO] [nvarchar](20) NULL,
	[SFATURA_EFATURA_SERI] [nvarchar](20) NULL,
	[SFATURA_EFATURA_SERINO] [nvarchar](20) NULL,
	[SFATURA_KAGIT_SERI] [nvarchar](20) NULL,
	[SFATURA_KAGIT_SERINO] [nvarchar](20) NULL,
	[AFATURA_SERI] [nvarchar](20) NULL,
	[AFATURA_SERINO] [nvarchar](20) NULL,
	[ATEKLIF_SERI] [nvarchar](20) NULL,
	[ATEKLIF_SERINO] [nvarchar](20) NULL,
	[STEKLIF_SERI] [nvarchar](20) NULL,
	[STEKLIF_SERINO] [nvarchar](20) NULL,
 CONSTRAINT [PK_LOGO_XERO_BELGENUMARASI_NUMARATOR] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)) ON [PRIMARY];";

                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();
            }
            catch
            {
                clas.Conn.Close();
            }
        }
        public void XERO_Parametreler_TABLOOLUSTUR()
        {
            try
            {
                clas.Connect();
                string sql = $@"CREATE TABLE [dbo].[LOGO_XERO_PARAMETRELER](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FIRMANO] [nvarchar](3) NULL,
	[DONEMNO] [nvarchar](2) NULL,
	[FATURALOGO] [image] NULL,
	[FATURAIMZA] [image] NULL,
	[LOGINLOGO] [image] NULL,
	[EFATURALOGO] [image] NULL,
	[EARSIVLOGO] [image] NULL,
	[ARASKARGOUSERNAME] [nvarchar](50) NULL,
	[ARASKARGOPASSWORD] [nvarchar](50) NULL,
	[ARASKARGOGONDERITIPI] [nvarchar](50) NULL,
	[BANKA1] [nvarchar](50) NULL,
	[IBAN1] [nvarchar](99) NULL,
	[BANKASUBE1] [nvarchar](50) NULL,
	[BANKAHESAPNO1] [nvarchar](50) NULL,
	[BANKA2] [nvarchar](50) NULL,
	[IBAN2] [nvarchar](99) NULL,
	[BANKASUBE2] [nvarchar](50) NULL,
	[BANKAHESAPNO2] [nvarchar](50) NULL,
	[BANKA3] [nvarchar](50) NULL,
	[IBAN3] [nvarchar](99) NULL,
	[BANKASUBE3] [nvarchar](50) NULL,
	[BANKAHESAPNO3] [nvarchar](50) NULL,
	[BANKA4] [nvarchar](50) NULL,
	[IBAN4] [nvarchar](99) NULL,
	[BANKASUBE4] [nvarchar](50) NULL,
	[BANKAHESAPNO4] [nvarchar](50) NULL,
	[BANKA5] [nvarchar](50) NULL,
	[IBAN5] [nvarchar](99) NULL,
	[BANKASUBE5] [nvarchar](50) NULL,
	[BANKAHESAPNO5] [nvarchar](50) NULL,
	[SMSID] [bit] NULL,
	[SMSUSER] [nvarchar](50) NULL,
	[SMSPASSWORD] [nvarchar](50) NULL,
	[SMSHEADER] [nvarchar](50) NULL,
	[PROGRAMKATALOGDOSYAYOLU] [nvarchar](max) NULL,
	[SOZLESMELICARIDOSYAYOLU] [nvarchar](max) NULL,
	[KULLANILACAKDOVIZTURU] [int] NULL,
	[STANDARTPARABIRIMI] [int] NULL,
	[MALIMUSAVIR_TOKEN] [nvarchar](max) NULL,
	[GIBSORGULAMAYAPABILSIN] [bit] NULL,
	[GIBUSERNAME] [nvarchar](50) NULL,
	[GIBPASSWORD] [nvarchar](50) NULL,
	[FATURAALTNOT] [text] NULL,
	[TEKLIFALTNOT] [text] NULL,
	[MAILSERVER] [nvarchar](99) NULL,
	[MAILPORT] [nvarchar](99) NULL,
	[SSLGEREKLIMI] [bit] NULL,
	[LOGOBAGLANTISECIMI] [int] NULL,
	[LOGOPAKETSECIMI] [int] NULL,
	[OBJESERVISURL] [nvarchar](150) NULL,
	[OBJEKULLANICIADI] [nvarchar](150) NULL,
	[OBJEKULLANICISIFRE] [nvarchar](150) NULL,
	[RESTSERVISURL] [nvarchar](150) NULL,
	[RESTSERVISKULLANICIADI] [nvarchar](150) NULL,
	[RESTSERVISSIFRE] [nvarchar](150) NULL,
	[RESTSERVISTOKEN] [nvarchar](max) NULL,
	[OZELFIYATKARTSUTUNAD] [nvarchar](150) NULL,
	[ZC_OZELKOD1] [bit] NULL,
	[ZC_OZELKOD2] [bit] NULL,
	[ZC_OZELKOD3] [bit] NULL,
	[ZC_OZELKOD4] [bit] NULL,
	[ZC_OZELKOD5] [bit] NULL,
	[ZC_ODEMEPLANI_VADE] [bit] NULL,
	[ZC_EPOSTA1] [bit] NULL,
	[ZC_EPOSTA2] [bit] NULL,
	[ZC_EPOSTA3] [bit] NULL,
	[ZC_TICARIISLEMGRUBU] [bit] NULL,
	[ZC_MUHASEBEKODU] [bit] NULL,
	[ZC_BAGLISATISELEMANIALANI] [nvarchar](50) NULL,
	[ZC_BAGLIHAZIRLAYANALANI] [nvarchar](50) NULL,
	[ZC_BAGLIPAZARLAYANALANI] [nvarchar](50) NULL,
	[ZSTK_OZELKOD1] [bit] NULL,
	[ZSTK_OZELKOD2] [bit] NULL,
	[ZSTK_OZELKOD3] [bit] NULL,
	[ZSTK_OZELKOD4] [bit] NULL,
	[ZSTK_OZELKOD5] [bit] NULL,
	[ZSTK_MARKA] [bit] NULL,
	[ZSTK_GRUPKODU] [bit] NULL,
	[ZSTK_FIYAT] [bit] NULL,
	[Z_STKLF_HAZIRLAYANPERSONEL] [bit] NULL,
	[Z_STKLF_SATISELEMANI] [bit] NULL,
	[Z_STKLF_OZELKOD] [bit] NULL,
	[Z_STKLF_YETKIKOD] [bit] NULL,
	[Z_STKLF_PROJEKOD] [bit] NULL,
	[Z_STKLF_TICISLGRUP] [bit] NULL,
	[Z_STKLF_ODEMETIP] [bit] NULL,
	[Z_STKLF_TASIYICIKOD] [bit] NULL,
	[Z_STKLF_VADE] [bit] NULL,
	[Z_SSPRS_HAZIRLAYANPERSONEL] [bit] NULL,
	[Z_SSPRS_SATISELEMANI] [bit] NULL,
	[Z_SSPRS_OZELKOD] [bit] NULL,
	[Z_SSPRS_YETKIKOD] [bit] NULL,
	[Z_SSPRS_PROJEKOD] [bit] NULL,
	[Z_SSPRS_TICISLGRUP] [bit] NULL,
	[Z_SSPRS_ODEMETIP] [bit] NULL,
	[Z_SSPRS_VADE] [bit] NULL,
	[Z_SSPRS_TASIYICIKOD] [bit] NULL,
	[Z_SIRS_HAZIRLAYANPERSONEL] [bit] NULL,
	[Z_SIRS_SATISELEMANI] [bit] NULL,
	[Z_SIRS_OZELKOD] [bit] NULL,
	[Z_SIRS_YETKIKOD] [bit] NULL,
	[Z_SIRS_PROJEKOD] [bit] NULL,
	[Z_SIRS_TICISLGRUP] [bit] NULL,
	[Z_SIRS_ODEMETIP] [bit] NULL,
	[Z_SIRS_VADE] [bit] NULL,
	[Z_SIRS_TASIYICIKOD] [bit] NULL,
	[Z_SF_HAZIRLAYANPERSONEL] [bit] NULL,
	[Z_SF_SATISELEMANI] [bit] NULL,
	[Z_SF_OZELKOD] [bit] NULL,
	[Z_SF_YETKIKOD] [bit] NULL,
	[Z_SF_PROJEKOD] [bit] NULL,
	[Z_SF_TICISLGRUP] [bit] NULL,
	[Z_SF_ODEMETIP] [bit] NULL,
	[Z_SF_VADE] [bit] NULL,
	[Z_SF_TASIYICIKOD] [bit] NULL,
	[Z_ATKLF_HAZIRLAYANPERSONEL] [bit] NULL,
	[Z_ATKLF_SATISELEMANI] [bit] NULL,
	[Z_ATKLF_OZELKOD] [bit] NULL,
	[Z_ATKLF_YETKIKOD] [bit] NULL,
	[Z_ATKLF_PROJEKOD] [bit] NULL,
	[Z_ATKLF_TICISLGRUP] [bit] NULL,
	[Z_ATKLF_ODEMETIP] [bit] NULL,
	[Z_ATKLF_VADE] [bit] NULL,
	[Z_ATKLF_TASIYICIKOD] [bit] NULL,
	[Z_ASPRS_HAZIRLAYANPERSONEL] [bit] NULL,
	[Z_ASPRS_SATISELEMANI] [bit] NULL,
	[Z_ASPRS_OZELKOD] [bit] NULL,
	[Z_ASPRS_YETKIKOD] [bit] NULL,
	[Z_ASPRS_PROJEKOD] [bit] NULL,
	[Z_ASPRS_TICISLGRUP] [bit] NULL,
	[Z_ASPRS_ODEMETIP] [bit] NULL,
	[Z_ASPRS_VADE] [bit] NULL,
	[Z_ASPRS_TASIYICIKOD] [bit] NULL,
	[Z_AIRS_HAZIRLAYANPERSONEL] [bit] NULL,
	[Z_AIRS_SATISELEMANI] [bit] NULL,
	[Z_AIRS_OZELKOD] [bit] NULL,
	[Z_AIRS_YETKIKOD] [bit] NULL,
	[Z_AIRS_PROJEKOD] [bit] NULL,
	[Z_AIRS_TICISLGRUP] [bit] NULL,
	[Z_AIRS_ODEMETIP] [bit] NULL,
	[Z_AIRS_VADE] [bit] NULL,
	[Z_AIRS_TASIYICIKOD] [bit] NULL,
	[Z_AF_HAZIRLAYANPERSONEL] [bit] NULL,
	[Z_AF_SATISELEMANI] [bit] NULL,
	[Z_AF_OZELKOD] [bit] NULL,
	[Z_AF_YETKIKOD] [bit] NULL,
	[Z_AF_PROJEKOD] [bit] NULL,
	[Z_AF_TICISLGRUP] [bit] NULL,
	[Z_AF_ODEMETIP] [bit] NULL,
	[Z_AF_VADE] [bit] NULL,
	[Z_AF_TASIYICIKOD] [bit] NULL,
	[Z_MF_OZELKOD] [bit] NULL,
	[Z_MF_YETKIKOD] [bit] NULL,
	[MC_OTOMATIKMUHASEBEOLUSTUR] [bit] NULL,
	[MC_AMBAR_OTOTMATIKKODVER] [bit] NULL,
	[MSTK_OTOBARKODLOGICALREF] [int] NULL,
	[M_STKLF_FIYATSIZFISKAYDEDEBILMA] [bit] NULL,
	[M_STKLF_CIKTIDASECMELITASARIMKULLAN] [bit] NULL,
	[M_STKLF_CARISONBAKIYEGORUNSUN] [bit] NULL,
	[M_STKLF_COKLUSIPARISOLUSTURMA] [bit] NULL,
	[M_STKLF_MIKTARHESAPLAMAKULLAN] [bit] NULL,
	[M_SSPRS_FIYATSIZFISKAYDEDEBILME] [bit] NULL,
	[M_SSPRS_CIKTIDASECMELITASARIMKULLAN] [bit] NULL,
	[M_SSPRS_CARISONBAKIYEGORUNSUN] [bit] NULL,
	[M_SSPRS_KAYITIPTALETMECIKARMA] [bit] NULL,
	[M_SSPRS_MIKTARHESAPLAMAKULLAN] [bit] NULL,
	[M_SIRS_FIYATSIZFISKAYDEDEBILME] [bit] NULL,
	[M_SIRS_CIKTIDASECMELITASARIMKULLAN] [bit] NULL,
	[M_SIRS_CARISONBAKIYEGORUNSUN] [bit] NULL,
	[M_SIRS_KAYITIPTALETMECIKARMA] [bit] NULL,
	[M_SIRS_MIKTARHESAPLAMAKULLAN] [bit] NULL,
	[M_SF_FIYATSIZFISKAYDEDEBILME] [bit] NULL,
	[M_SF_CIKTIDASECMELITASARIMKULLAN] [bit] NULL,
	[M_SF_CARISONBAKIYEGORUNSUN] [bit] NULL,
	[M_SF_KAYITIPTALETMECIKARMA] [bit] NULL,
	[M_SF_KAGITFATURAKESIMI] [bit] NULL,
	[M_SF_NUMARATORDEISYERINEBAKILSIN] [bit] NULL,
	[M_SF_NUMARATORDEAMBARABAKILSIN] [bit] NULL,
	[M_SF_EFATURAKONTROLUYAPILSIN] [bit] NULL,
	[M_SF_MIKTARHESAPLAMAKULLAN] [bit] NULL,
	[M_ATKLF_FIYATSIZFISKAYDEDEBILME] [bit] NULL,
	[M_ATKLF_CIKTIDASECMELITASARIMKULLAN] [bit] NULL,
	[M_ATKLF_CARISONBAKIYEGORUNSUN] [bit] NULL,
	[M_ATKLF_COKLUSIPARISOLUSTURMA] [bit] NULL,
	[M_ATKLF_MIKTARHESAPLAMAKULLAN] [bit] NULL,
	[M_ASPRS_FIYATSIZFISKAYDEDEBILME] [bit] NULL,
	[M_ASPRS_CIKTIDASECMELITASARIMKULLAN] [bit] NULL,
	[M_ASPRS_CARISONBAKIYEGORUNSUN] [bit] NULL,
	[M_ASPRS_KAYITIPTALETMECIKARMA] [bit] NULL,
	[M_ASPRS_MIKTARHESAPLAMAKULLAN] [bit] NULL,
	[M_AIRS_FIYATSIZFISKAYDEDEBILME] [bit] NULL,
	[M_AIRS_CIKTIDASECMELITASARIMKULLAN] [bit] NULL,
	[M_AIRS_CARISONBAKIYEGORUNSUN] [bit] NULL,
	[M_AIRS_KAYITIPTALETMECIKARMA] [bit] NULL,
	[M_AIRS_MIKTARHESAPLAMAKULLAN] [bit] NULL,
	[M_AF_FIYATSIZFISKAYDEDEBILME] [bit] NULL,
	[M_AF_CIKTIDASECMELITASARIMKULLAN] [bit] NULL,
	[M_AF_CARISONBAKIYEGORUNSUN] [bit] NULL,
	[M_AF_KAYITIPTALETMECIKARMA] [bit] NULL,
	[M_AF_KAGITFATURAKESIMI] [bit] NULL,
	[M_AF_NUMARATORDEISYERINEBAKILSIN] [bit] NULL,
	[M_AF_NUMARATORDEAMBARABAKILSIN] [bit] NULL,
	[M_AF_EFATURAKONTROLUYAPILSIN] [bit] NULL,
	[M_AF_MIKTARHESAPLAMAKULLAN] [bit] NULL,
	[M_MF_AMBARFISINDEONDEGERKAGITGELSIN] [bit] NULL,
	[M_MF_CIKTIDASECMELITASARIMKULLAN] [bit] NULL,
	[M_MF_MIKTARHESAPLAMAKULLAN] [bit] NULL,
	[M_GNL_BARKODOKUTMAMIKTARBIRLESIMI] [bit] NULL,
	[M_GNL_KAYITLARDANSONRASAYFAKAPAT] [bit] NULL,
	[M_GNL_KAYITLARDANSONRASAYFAYENILE] [bit] NULL,
	[M_GNL_ALTERNATIFURUNONERISIAKTIF] [bit] NULL,
	[M_GNL_KULLANICIKASABAGLANTISI] [bit] NULL,
	[M_GNL_ALISFIYATININALTINDA_YAPILACAKISLEM] [int] NULL,
	[M_GNL_ALISFIYATUSTUNEKARORANI] [nvarchar](50) NULL,
	[M_GNL_LISTELERIN_GUNFARKI] [int] NULL,
	[FYTPRMT_OZELFIYATSECENEGI] [int] NULL,
	[FYTPRMT_PERAKENDEFIYATGRUBU] [nvarchar](50) NULL,
	[FYTPRMT_FIYATGRUBU] [nvarchar](50) NULL,
	[FYTPRMT_ETICARETFIYATGRUBU] [nvarchar](50) NULL,
	[MIKTARH_1ALANKULLAN] [bit] NULL,
	[MIKTARH_2ALANKULLAN] [bit] NULL,
	[MIKTARH_3ALANKULLAN] [bit] NULL,
	[MIKTARH_4ALANKULLAN] [bit] NULL,
	[MIKTARH_5ALANKULLAN] [bit] NULL,
	[MIKTARH_1ALANADI] [nvarchar](50) NULL,
	[MIKTARH_2ALANADI] [nvarchar](50) NULL,
	[MIKTARH_3ALANADI] [nvarchar](50) NULL,
	[MIKTARH_4ALANADI] [nvarchar](50) NULL,
	[MIKTARH_5ALANADI] [nvarchar](50) NULL,
	[MIKTARH_1ALANVARSDEGER] [float] NULL,
	[MIKTARH_2ALANVARSDEGER] [float] NULL,
	[MIKTARH_3ALANVARSDEGER] [float] NULL,
	[MIKTARH_4ALANVARSDEGER] [float] NULL,
	[MIKTARH_5ALANVARSDEGER] [float] NULL,
	[MIKTARH_FORMUL] [nvarchar](max) NULL,
 CONSTRAINT [PK_XERO_PARAMETRELER] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)) ON [PRIMARY]
;
ALTER TABLE [dbo].[LOGO_XERO_PARAMETRELER] ADD  CONSTRAINT [DF_XERO_PARAMETRELER_M_G_ALISFIYATININALTINDA_YAPILACAKISLEM]  DEFAULT ((1)) FOR [M_GNL_ALISFIYATININALTINDA_YAPILACAKISLEM]
;

ALTER TABLE [dbo].[LOGO_XERO_PARAMETRELER] ADD  CONSTRAINT [DF_XERO_PARAMETRELER_M_G_LISTELERIN_GUNFARKI]  DEFAULT ((30)) FOR [M_GNL_LISTELERIN_GUNFARKI]
;";

                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();
            }
            catch
            {
                clas.Conn.Close();
            }
        }
        public void VirmanAciklamaTablosuOlustur()
        {
            try
            {
                clas.Connect();
                string sql = $@"CREATE TABLE [dbo].[LOGO_XERO_VIRMAN_ACIKLAMA](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VIRMANACIKLAMA] [nvarchar](150) NULL,
 CONSTRAINT [PK_LOGO_XERO_VIRMAN_ACIKLAMA] PRIMARY KEY CLUSTERED 
(
	[ID] ASC 
)) ON [PRIMARY]
;";

                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();
            }
            catch
            {
                clas.Conn.Close();
            }
        }
        public void XERO_TeklifSatirTabloOlustur(string firma) // [TEKLIFSATIRID] [int] NOT NULL SİLİNDİ, NETFIYAT EKLENDI, TOPLAMTUTAR EKLENDİ ----- LOTKODU Eklendi
        {
            try
            {
                clas.Connect();
                string sql = $@"CREATE TABLE [dbo].[LOGO_XERO_TEKLIF_SATIR_{firma}](
	[ID] [int] IDENTITY(1,1) NOT NULL,	[SATIRTIPI] [int] NOT NULL,[TEKLIFID] [int] NOT NULL,	[SIRANO] [int] NULL,
[TRCODE] [int] NULL,	[STOKLOGICALREF] [int] NULL,[STOKKODU] [nvarchar](150) NULL,	[STOKADI] [nvarchar](250) NULL,
[FIYATGURUBU] [nvarchar](150) NULL,[BIRIM] [nvarchar](150) NULL,[MARKA] [nvarchar](150) NULL,[STOKACIKLAMA] [nvarchar](max) NULL,
[SATIRACIKLAMA] [nvarchar](max) NULL,[MIKTAR] [float] NULL,[OZELKOD1] [nvarchar](50) NULL,[OZKODACIKLAMA] [nvarchar](150) NULL,[LOTKODU] [nvarchar](150) NULL,[ORJINALISKONTO] [float] NULL,[ISKONTOYUZDESI1] [float] NULL,[ISKONTOYUZDESI2] [float] NULL,[ISKONTOYUZDESI3] [float] NULL,
[ISKONTOTUTARI1] [float] NULL,[ISKONTOTUTARI2] [float] NULL,[ISKONTOTUTARI3] [float] NULL,[KDV] [float] NULL,
[KDVTUTARI] [float] NULL,[FIYAT] [float] NULL,[NETFIYAT] [float] NULL,[DOVIZLIFIYAT] [float] NULL,
[TUTAR] [float] NULL,[TOPLAMTUTAR] [float] NULL,[ISKONTOLUTUTAR] [float] NULL,[TESLIMTARIHI] [datetime] NULL,
[TALEPEDENFIRMA] [nvarchar](250) NULL,[ISYERI] [smallint] NULL,[BOLUM] [smallint] NULL,[FABRIKA] [smallint] NULL,
[AMBAR] [smallint] NULL,[NAKLIYEBEDELI] [float] NULL,[TEVKIFATLI] [bit] NULL,[TEVKIFATKODU] [nvarchar](250) NULL,[TESLIMSURESI][nvarchar](250) NULL,
[TEVKIFATCARPAN] [float] NULL,[TEVKIFATBOLEN] [float] NULL,[BASLIKDOVIZTURU] [smallint] NULL,[SATIRDOVIZTURU] [smallint] NULL,
[RAPORLAMADOVIZI] [smallint] NULL,[RAPORLAMADOVIZKURU] [float] NULL,[ISLEMDOVIZI] [smallint] NULL,[ISLEMDOVIZKURU] [float] NULL,
[SATIRDOVIZKODU] [smallint] NULL,[SATIRDOVIZKURU] [float] NULL,[DOVIZKURUTARIHI] [datetime] NULL,[TUR] [int] NULL,
 CONSTRAINT [PK_LOGO_XERO_TEKLIF_SATIR_{firma}] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();


            }
            catch
            {
                clas.Conn.Close();
            }

        }
        public void XERO_OnayliTeklifSatirTabloOlustur(string firma)
        {
            try
            {
                clas.Connect();
                string sql = $@"CREATE TABLE [dbo].[LOGO_XERO_ONAYLI_TEKLIF_SATIR_{firma}](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SATIRTIPI] [int] NOT NULL,
	[TEKLIFID] [int] NOT NULL,
    [TEKLIFSATIRID] [int] NOT NULL,
	[SIRANO] [int] NULL,
	[TRCODE] [int] NULL,
	[STOKLOGICALREF] [int] NULL,
	[STOKKODU] [nvarchar](150) NULL,
	[STOKADI] [nvarchar](250) NULL,
	[FIYATGURUBU] [nvarchar](150) NULL,
	[BIRIM] [nvarchar](150) NULL,
	[MARKA] [nvarchar](150) NULL,
	[STOKACIKLAMA] [nvarchar](max) NULL,
	[SATIRACIKLAMA] [nvarchar](max) NULL,
	[MIKTAR] [float] NULL,
	[ONAYLIMIKTAR] [float] NULL,
	[TESLIMMIKTAR] [float] NULL,
	[KALANMIKTAR] [float] NULL,
	[ONAYLANANMIKTAR] [float] NULL,
    [OZELKOD1] [nvarchar](50) NULL,
    [OZKODACIKLAMA] [nvarchar](150) NULL,
    [LOTKODU] [nvarchar](150) NULL,
	[ORJINALISKONTO] [float] NULL,
	[ISKONTOYUZDESI1] [float] NULL,
	[ISKONTOYUZDESI2] [float] NULL,
	[ISKONTOYUZDESI3] [float] NULL,
	[ISKONTOTUTARI1] [float] NULL,
	[ISKONTOTUTARI2] [float] NULL,
	[ISKONTOTUTARI3] [float] NULL,
	[KDV] [float] NULL,
	[KDVTUTARI] [float] NULL,
	[ONAYLANANKDVTUTARI] [float] NULL,
	[FIYAT] [float] NULL,
	[NETFIYAT] [float] NULL,
	[DOVIZLIFIYAT] [float] NULL,
	[TUTAR] [float] NULL,
	[ONAYLANANTUTAR] [float] NULL,
	[TOPLAMTUTAR] [float] NULL,
	[ONAYLANANTOPLAMTUTAR] [float] NULL,
	[ISKONTOLUTUTAR] [float] NULL,
	[ONAYLANANISKONTOLUTUTAR] [float] NULL,
	[TESLIMTARIHI] [datetime] NULL,
	[TALEPEDENFIRMA] [nvarchar](250) NULL,
	[ISYERI] [smallint] NULL,
	[BOLUM] [smallint] NULL,
	[FABRIKA] [smallint] NULL,
	[AMBAR] [smallint] NULL,
	[NAKLIYEBEDELI] [float] NULL,
	[TEVKIFATLI] [bit] NULL,
	[TEVKIFATKODU] [nvarchar](250) NULL,
    [TESLIMSURESI][nvarchar](250) NULL,
	[TEVKIFATCARPAN] [float] NULL,
	[TEVKIFATBOLEN] [float] NULL,
	[BASLIKDOVIZTURU] [smallint] NULL,
	[SATIRDOVIZTURU] [smallint] NULL,
	[RAPORLAMADOVIZI] [smallint] NULL,
	[RAPORLAMADOVIZKURU] [float] NULL,
	[ISLEMDOVIZI] [smallint] NULL,
	[ISLEMDOVIZKURU] [float] NULL,
	[SATIRDOVIZKODU] [smallint] NULL,
	[SATIRDOVIZKURU] [float] NULL,
	[DOVIZKURUTARIHI] [datetime] NULL,
    [TUR] [int] NULL,
 CONSTRAINT [PK_LOGO_XERO_ONAYLI_TEKLIF_SATIR_{firma}] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }

        }
        public void LisansTablosuModulEkle()
        {
            try
            {
                clas.Connect();
                string sql = $@"IF EXISTS (SELECT MODUL FROM LOGO_XERO_LISANSLAR WHERE MODUL=1)	PRINT 'VAR'
ELSE INSERT INTO [dbo].[LOGO_XERO_LISANSLAR]  ([MODUL] ,[LISANSNUMARASI],[VAR]) VALUES (1,'',0);

IF EXISTS (SELECT MODUL FROM LOGO_XERO_LISANSLAR WHERE MODUL=2)	PRINT 'VAR'
ELSE INSERT INTO [dbo].[LOGO_XERO_LISANSLAR]  ([MODUL] ,[LISANSNUMARASI],[VAR]) VALUES (2,'',0);

IF EXISTS (SELECT MODUL FROM LOGO_XERO_LISANSLAR WHERE MODUL=3)	PRINT 'VAR'
ELSE INSERT INTO [dbo].[LOGO_XERO_LISANSLAR]  ([MODUL] ,[LISANSNUMARASI],[VAR]) VALUES (3,'',0);

IF EXISTS (SELECT MODUL FROM LOGO_XERO_LISANSLAR WHERE MODUL=4)	PRINT 'VAR'
ELSE INSERT INTO [dbo].[LOGO_XERO_LISANSLAR]  ([MODUL] ,[LISANSNUMARASI],[VAR]) VALUES (4,'',0);
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }
        }
        public void LisansTablosuOlustur()
        {
            try
            {
                clas.Connect();
                string sql = $@"CREATE TABLE [dbo].[LOGO_XERO_LISANSLAR](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VAR] [int] NULL,
	[MODUL] [int] NULL,
	[LISANSNUMARASI] [nvarchar](max) NULL,
 CONSTRAINT [PK_LOGO_XERO_LISANSLAR] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)) ON [PRIMARY] 
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }
        }
        public void TeklifDurumTablosuOlustur()
        {
            try
            {
                clas.Connect();
                string sql = $@"CREATE TABLE [dbo].[LOGO_XERO_TEKLIF_DURUMLARI](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TIP] [int] NULL,
	[DURUM] [nvarchar](150) NULL,
 CONSTRAINT [PK_LOGO_XERO_TEKLIF_DURUMLARI] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)) ON [PRIMARY]
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }
        }
        public void KullaniciTablosuOlustur()
        {
            try
            {
                clas.Connect();
                string sql = $@"CREATE TABLE [dbo].[LOGO_XERO_KULLANICILAR](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KULLANICIADI] [nvarchar](max) NULL,
	[LOGOSATISELEMANIID] [nvarchar](50) NULL,
	[SIFRE] [nvarchar](100) NULL,
	[TANIMLIFIRMA] [nvarchar](3) NULL,
	[TANIMLIDONEM] [nvarchar](2) NULL,
	[GIRISISYERI] [smallint] NULL,
	[GIRISBOLUM] [smallint] NULL,
	[GIRISAMBAR] [smallint] NULL,
	[ISYERI] [smallint] NULL,
	[BOLUM] [smallint] NULL,
	[FABRIKA] [smallint] NULL,
	[AMBAR] [smallint] NULL,
	[TELEFON] [nvarchar](max) NULL,
	[EPOSTA] [nvarchar](max) NULL,
	[ILCE] [nvarchar](max) NULL,
	[IL] [nvarchar](max) NULL,
	[ADRES] [nvarchar](max) NULL,
	[GOREV] [int] NULL,
	[TEKLIFTUTARILIMIT] [float] NULL,
	[KISITLIOZELKOD] [nvarchar](max) NULL,
	[ISKONTOLIMIT] [float] NULL,
	[YETKI] [nvarchar](max) NULL,
	[MAILSIFRE] [nvarchar](150) NULL,
 CONSTRAINT [PK_LOGO_XERO_KULLANICILAR] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)) 
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }
        }

        public void TasarimTablosuOlustur()
        {
            try
            {
                clas.Connect();
                string sql = $@"CREATE TABLE [dbo].[LOGO_XERO_TASARIMLAR](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PERSONELID] [int] NULL,
	[SAYFAADI] [nvarchar](max) NULL,
	[GRIDADI] [nvarchar](max) NULL,
	[TASARIM] [nvarchar](max) NULL,
 CONSTRAINT [PK_LOGO_XERO_TASARIMLAR] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)) 
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }
        }
        public void CariListesiViewOlustur(string firma, string donem)
        {
            try
            {
                clas.Connect();
                string sql = $@"CREATE VIEW [dbo].[LOGO_XERO_CARILISTE_{firma}]
                AS
            WITH CARILISTE AS (
SELECT C.LOGICALREF,C.CODE,DEFINITION_,C.SPECODE OZELKOD1,C.SPECODE2 OZELKOD2,C.SPECODE3 OZELKOD3,C.SPECODE4 OZELKOD4,C.SPECODE5 OZELKOD5,C.NAME ADI, C.SURNAME SOYADI,
C.ADDR1 as [ADRES1],C.ADDR2 as [ADRES2],C.TRADINGGRP TICARIISLEMGURUBU, C.TELNRS1 as [TELEFON1], C.TELNRS2 as [TELEFON2],C.COUNTRY ULKE, C.COUNTRYCODE ULKEKODU, C.CITY [SEHIR],C.TOWN ILCE, C.TAXOFFICE VERGIDAIRESI,
C.TCKNO, C.FAXNR, C.POSTCODE POSTAKODU, C.TAXNR,C.INCHARGE [YETKILISI], C.CYPHCODE YETKIKODU, ISNULL(C.ACCEPTEINV,0) EFATURA, C.EMAILADDR EPOSTA,
C.EMAILADDR2 EPOSTA2, C.EMAILADDR3 EPOSTA3 ,C.ISPERSCOMP SAHISSIRKETI,C.PAYMENTREF,C.CARDTYPE,
CAST(CAST(ISNULL((SELECT SUM(DEBIT)-SUM(CREDIT) FROM LV_{firma}_{donem}_GNTOTCL WITH (NOLOCK) WHERE CARDREF=C.LOGICALREF AND TOTTYP=1),0)AS decimal(18,3))AS float) AS [BAKIYE]
FROM LG_{firma}_CLCARD C WHERE C.ACTIVE=0 AND C.CARDTYPE<>22 )
SELECT * FROM CARILISTE
OUTER APPLY(SELECT TOP 1 EM.CODE MUHASEBEKODU FROM LG_{firma}_CRDACREF C WITH (NOLOCK)
LEFT OUTER JOIN LG_{firma}_EMUHACC EM WITH (NOLOCK) ON C.ACCOUNTREF=EM.LOGICALREF
WHERE C.CARDREF=CARILISTE.LOGICALREF AND C.TRCODE=5)MUSAHEBEBILGILERI
OUTER APPLY(SELECT TOP 1 CODE ODEMEPLANKODU,DEFINITION_ ODEMEPLANI FROM LG_{firma}_PAYPLANS P WITH (NOLOCK)
WHERE P.LOGICALREF=CARILISTE.PAYMENTREF)ODEMEBILGILERI
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }
        }

        public void CariListesiViewGuncelle(string firma, string donem)
        {
            try
            {
                clas.Connect();
                string sql = $@"ALTER VIEW [dbo].[LOGO_XERO_CARILISTE_{firma}]
                AS
            WITH CARILISTE AS (
SELECT C.LOGICALREF,C.CODE,DEFINITION_,C.SPECODE OZELKOD1,C.SPECODE2 OZELKOD2,C.SPECODE3 OZELKOD3,C.SPECODE4 OZELKOD4,C.SPECODE5 OZELKOD5,C.NAME ADI, C.SURNAME SOYADI,
C.ADDR1 as [ADRES1],C.ADDR2 as [ADRES2],C.TRADINGGRP TICARIISLEMGURUBU, C.TELNRS1 as [TELEFON1], C.TELNRS2 as [TELEFON2],C.COUNTRY ULKE, C.COUNTRYCODE ULKEKODU, C.CITY [SEHIR],C.TOWN ILCE, C.TAXOFFICE VERGIDAIRESI,
C.TCKNO, C.FAXNR, C.POSTCODE POSTAKODU, C.TAXNR,C.INCHARGE [YETKILISI], C.CYPHCODE YETKIKODU, ISNULL(C.ACCEPTEINV,0) EFATURA, C.EMAILADDR EPOSTA,
C.EMAILADDR2 EPOSTA2, C.EMAILADDR3 EPOSTA3 ,C.ISPERSCOMP SAHISSIRKETI,C.PAYMENTREF,C.CARDTYPE,
CAST(CAST(ISNULL((SELECT SUM(DEBIT)-SUM(CREDIT) FROM LV_{firma}_{donem}_GNTOTCL WITH (NOLOCK) WHERE CARDREF=C.LOGICALREF AND TOTTYP=1),0)AS decimal(18,3))AS float) AS [BAKIYE]
FROM LG_{firma}_CLCARD C WHERE C.ACTIVE=0 AND C.CARDTYPE<>22 )
SELECT * FROM CARILISTE
OUTER APPLY(SELECT TOP 1 EM.CODE MUHASEBEKODU FROM LG_{firma}_CRDACREF C WITH (NOLOCK)
LEFT OUTER JOIN LG_{firma}_EMUHACC EM WITH (NOLOCK) ON C.ACCOUNTREF=EM.LOGICALREF
WHERE C.CARDREF=CARILISTE.LOGICALREF AND C.TRCODE=5)MUSAHEBEBILGILERI
OUTER APPLY(SELECT TOP 1 CODE ODEMEPLANKODU,DEFINITION_ ODEMEPLANI FROM LG_{firma}_PAYPLANS P WITH (NOLOCK)
WHERE P.LOGICALREF=CARILISTE.PAYMENTREF)ODEMEBILGILERI
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }
        }
        public void StokListesiViewOlustur(string firma, string donem)
        {
            try
            {
                LOGO_XERO_PARAMETRELER parametree = DataSetliParametrelerGetir(firma, donem);
                string perakendefiyatfiltresi = "";
                string listefiyatParametresi = "";
                if (parametree.FYTPRMT_OZELFIYATSECENEGI == 1)
                {
                }
                else
                {
                    perakendefiyatfiltresi = $@"P.{parametree.OZELFIYATKARTSUTUNAD} = '{parametree.FYTPRMT_PERAKENDEFIYATGRUBU}' AND ";
                    listefiyatParametresi = $@"P.{parametree.OZELFIYATKARTSUTUNAD} = '{parametree.FYTPRMT_FIYATGRUBU}' AND ";
                }

                clas.Connect();
                string sql = $@"CREATE VIEW [dbo].[LOGO_XERO_STOKLISTESI_{firma}]
                AS
           SELECT I.LOGICALREF, I.SPECODE OZELKOD,I.CODE STOKKODU,I.NAME STOKCINSI, I.NAME3 ACIKLAMA3,I.NAME4 ACIKLAMA4, M.DESCR MARKA,
I.SPECODE OZELKOD1,(SELECT TOP 1 DEFINITION_ FROM LG_{firma}_SPECODES With (Nolock) WHERE SPECODE=I.SPECODE AND SPETYP1=1 AND CODETYPE=1 AND SPECODETYPE=1) OZKODACIKLAMA, 
I.SPECODE2 OZELKOD2,I.SPECODE3 OZELKOD3,I.SPECODE4 OZELKOD4,I.SPECODE5 OZELKOD5,I.CYPHCODE YETKIKODU,I.VAT [KDV],
ISNULL((SELECT SUM(ONHAND) FROM LV_{firma}_{donem}_STINVTOT WITH (NOLOCK) WHERE STOCKREF=I.LOGICALREF AND INVENNO=-1),0) STOKBAKIYE,
ISNULL((SELECT TOP 1 MINLEVEL FROM LG_{firma}_INVDEF With (Nolock) WHERE ITEMREF = I.LOGICALREF), 0) AS MINMIKTAR,I.TRACKTYPE LOTTID,
ISNULL((SELECT TOP 1 PRICE FROM LG_{firma}_PRCLIST P WHERE {perakendefiyatfiltresi} P.CARDREF=I.LOGICALREF AND P.PTYPE=2 AND P.ACTIVE=0),0)[PRKSATISFIYATI],
(SELECT TOP 1 GROSSVOLUME FROM LG_{firma}_ITMUNITA With (Nolock) WHERE ITEMREF=I.LOGICALREF) DESI,
ISNULL(I.CANDEDUCT,0) [TEVKIFAT], I.DEDUCTCODE [TEVKIFATKODU], I.SALEDEDUCTPART1 [TEVKIFATCARPAN], I.SALEDEDUCTPART2 [TEVKIFATBOLEN],I.UNITSETREF,ISNULL(KDVDURUMU,0) KDVDURUMU,DOVIZKODU, ISNULL(LISTEFIYATI,0)LISTEFIYATI, DOVIZ.DOVIZ, BARKOD,BARKOD2, BIRIM
FROM LG_{firma}_ITEMS I With (Nolock)
LEFT OUTER JOIN LG_{firma}_MARK M WITH(NOLOCK) ON I.MARKREF=M.LOGICALREF
OUTER APPLY ((SELECT TOP 1 PRICE LISTEFIYATI,INCVAT KDVDURUMU,CURRENCY DOVIZKODU FROM LG_{firma}_PRCLIST P WITH(NOLOCK) WHERE {listefiyatParametresi} P.CARDREF=I.LOGICALREF AND P.PTYPE=2 AND P.ACTIVE=0))FIYATLISTESI
OUTER APPLY ((SELECT TOP 1 CURCODE DOVIZ FROM L_CURRENCYLIST WITH(NOLOCK)  WHERE CURTYPE=FIYATLISTESI.DOVIZKODU AND FIRMNR={Convert.ToInt32(firma)}))DOVIZ
OUTER APPLY ((SELECT TOP 1 BARCODE BARKOD FROM LG_{firma}_UNITBARCODE WITH(NOLOCK)  WHERE ITEMREF=I.LOGICALREF AND LINENR=1))BARKOD1
OUTER APPLY ((SELECT TOP 1 BARCODE BARKOD2 FROM LG_{firma}_UNITBARCODE WITH(NOLOCK)  WHERE ITEMREF=I.LOGICALREF AND LINENR=2))BARKOD2
OUTER APPLY(select TOP 1 CODE BIRIM From LG_{firma}_UNITSETL WITH(NOLOCK) where LG_{firma}_UNITSETL.UNITSETREF=I.UNITSETREF AND MAINUNIT=1)BIRIM
WHERE I.ACTIVE=0 AND  I.CARDTYPE <>22
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }
        }
        public void StokListesiViewGuncelle(string firma, string donem)
        {
            try
            {
                LOGO_XERO_PARAMETRELER parametree = DataSetliParametrelerGetir(firma, donem);
                string perakendefiyatfiltresi = "";
                string listefiyatParametresi = "";
                if (parametree.FYTPRMT_OZELFIYATSECENEGI == 1)
                {
                }
                else
                {
                    perakendefiyatfiltresi = $@"P.{parametree.OZELFIYATKARTSUTUNAD} = '{parametree.FYTPRMT_PERAKENDEFIYATGRUBU}' AND ";
                    listefiyatParametresi = $@"P.{parametree.OZELFIYATKARTSUTUNAD} = '{parametree.FYTPRMT_FIYATGRUBU}' AND ";
                }

                clas.Connect();
                string sql = $@"ALTER VIEW [dbo].[LOGO_XERO_STOKLISTESI_{firma}]
                AS
           SELECT I.LOGICALREF, I.SPECODE OZELKOD,I.CODE STOKKODU,I.NAME STOKCINSI, I.NAME3 ACIKLAMA3,I.NAME4 ACIKLAMA4, M.DESCR MARKA,
I.SPECODE OZELKOD1,(SELECT TOP 1 DEFINITION_ FROM LG_{firma}_SPECODES With (Nolock) WHERE SPECODE=I.SPECODE AND SPETYP1=1 AND CODETYPE=1 AND SPECODETYPE=1) OZKODACIKLAMA, 
I.SPECODE2 OZELKOD2,I.SPECODE3 OZELKOD3,I.SPECODE4 OZELKOD4,I.SPECODE5 OZELKOD5,I.CYPHCODE YETKIKODU,I.VAT [KDV],
ISNULL((SELECT SUM(ONHAND) FROM LV_{firma}_{donem}_STINVTOT WITH (NOLOCK) WHERE STOCKREF=I.LOGICALREF AND INVENNO=-1),0) STOKBAKIYE,
ISNULL((SELECT TOP 1 MINLEVEL FROM LG_{firma}_INVDEF With (Nolock) WHERE ITEMREF = I.LOGICALREF), 0) AS MINMIKTAR,I.TRACKTYPE LOTTID,
ISNULL((SELECT TOP 1 PRICE FROM LG_{firma}_PRCLIST P WHERE {perakendefiyatfiltresi} P.CARDREF=I.LOGICALREF AND P.PTYPE=2 AND P.ACTIVE=0),0)[PRKSATISFIYATI],
(SELECT TOP 1 GROSSVOLUME FROM LG_{firma}_ITMUNITA With (Nolock) WHERE ITEMREF=I.LOGICALREF) DESI,
ISNULL(I.CANDEDUCT,0) [TEVKIFAT], I.DEDUCTCODE [TEVKIFATKODU], I.SALEDEDUCTPART1 [TEVKIFATCARPAN], I.SALEDEDUCTPART2 [TEVKIFATBOLEN],I.UNITSETREF,ISNULL(KDVDURUMU,0) KDVDURUMU,DOVIZKODU, ISNULL(LISTEFIYATI,0)LISTEFIYATI, DOVIZ.DOVIZ, BARKOD,BARKOD2, BIRIM
FROM LG_{firma}_ITEMS I With (Nolock)
LEFT OUTER JOIN LG_{firma}_MARK M WITH(NOLOCK) ON I.MARKREF=M.LOGICALREF
OUTER APPLY ((SELECT TOP 1 PRICE LISTEFIYATI,INCVAT KDVDURUMU,CURRENCY DOVIZKODU FROM LG_{firma}_PRCLIST P WITH(NOLOCK) WHERE {listefiyatParametresi} P.CARDREF=I.LOGICALREF AND P.PTYPE=2 AND P.ACTIVE=0))FIYATLISTESI
OUTER APPLY ((SELECT TOP 1 CURCODE DOVIZ FROM L_CURRENCYLIST WITH(NOLOCK)  WHERE CURTYPE=FIYATLISTESI.DOVIZKODU AND FIRMNR={Convert.ToInt32(firma)}))DOVIZ
OUTER APPLY ((SELECT TOP 1 BARCODE BARKOD FROM LG_{firma}_UNITBARCODE WITH(NOLOCK)  WHERE ITEMREF=I.LOGICALREF AND LINENR=1))BARKOD1
OUTER APPLY ((SELECT TOP 1 BARCODE BARKOD2 FROM LG_{firma}_UNITBARCODE WITH(NOLOCK)  WHERE ITEMREF=I.LOGICALREF AND LINENR=2))BARKOD2
OUTER APPLY(select TOP 1 CODE BIRIM From LG_{firma}_UNITSETL WITH(NOLOCK) where LG_{firma}_UNITSETL.UNITSETREF=I.UNITSETREF AND MAINUNIT=1)BIRIM
WHERE I.ACTIVE=0 AND  I.CARDTYPE <>22
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }
        }
        public void AmbaraBagliCariKodTablosuOlustur()
        {
            try
            {
                clas.Connect();
                string sql = $@"CREATE TABLE [dbo].[LOGO_XERO_AMBARA_BAGLI_CARI_KOD](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	 AMBARNO INT NULL,
    FIRMANO INT NULL,
    SERIBASLANGIC VARCHAR(255) NULL
 CONSTRAINT [PK_LOGO_XERO_AMBARA_BAGLI_CARI_KOD] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)) ON [PRIMARY]
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }
        }
        public void UyariMesajlariTablosuOlustur()
        {
            try
            {
                clas.Connect();
                string sql = $@"CREATE TABLE [dbo].[LOGO_XERO_UYARI_MESAJLARI](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	FIRMANO INT NULL,
    ACIKLAMA VARCHAR(255) NULL
 CONSTRAINT [PK_LOGO_XERO_UYARI_MESAJLARI] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)) ON [PRIMARY]
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }
        }
        public void DovizBilgileriTablosuOlustur()
        {
            try
            {
                clas.Connect();
                string sql = $@"CREATE TABLE [dbo].[LOGO_XERO_DOVIZ_BILGILERI](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	FIRMANO INT NULL,
    LOGICALREF INT NULL,
    DOVIZKODU SMALLINT NULL,
    DOVIZCINSI VARCHAR(255) NULL,
    ACIKLAMA VARCHAR(255) NULL,
    SEMBOL VARCHAR(50) NULL
 CONSTRAINT [PK_LOGO_XERO_DOVIZ_BILGILERI] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)) ON [PRIMARY] 
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }
        }
        public void GorevlerTablosuOlustur()
        {
            try
            {
                clas.Connect();
                string sql = $@"CREATE TABLE [dbo].[LOGO_XERO_GOREVLER](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GOREVTANIMI] [nvarchar](150) NULL,
	[YETKI] [nvarchar](max) NULL,
 CONSTRAINT [PK_LOGO_XERO_GOREVLER] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) 
) ON [PRIMARY]   

";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }

        }
        public void GorevlerTablosuDoldur()
        {
            try
            {
                clas.Connect();
                string sql = $@"declare @Toplam int
select @Toplam = count( * ) from LOGO_XERO_GOREVLER 
if(@Toplam > 0)
print 'var'
else 
insert into [LOGO_XERO_GOREVLER] (GOREVTANIMI,YETKI) 
values

('Personel',''), 
('Yönetici','1,2,3,4,5,6,7,8,9,10,11,12,13' )
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }

        }

        public void VirmanTablosuDoldur()
        {
            try
            {
                clas.Connect();
                string sql = $@"declare @Toplam int
select @Toplam = count( * ) from LOGO_XERO_VIRMAN_ACIKLAMA 
if(@Toplam > 0)
print 'var'
else 
INSERT INTO [dbo].[LOGO_XERO_VIRMAN_ACIKLAMA]
           ([VIRMANACIKLAMA])
     VALUES
           ('Virman Açıklama') 
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }

        }

        public void KurTablosuDoldur(string firma)
        {
            try
            {
                clas.Connect();
                string sql = $@"
declare @Toplam int
select @Toplam = count( * ) from LOGO_XERO_DOVIZ_BILGILERI 
if(@Toplam > 0)
print 'var'
else 
insert into [LOGO_XERO_DOVIZ_BILGILERI] ([FIRMANO]
           ,[LOGICALREF]
           ,[DOVIZKODU]
           ,[DOVIZCINSI]
           ,[ACIKLAMA]
           ,[SEMBOL])
values
('{firma}',(SELECT TOP 1 LOGICALREF FROM L_CURRENCYLIST WHERE FIRMNR={Convert.ToInt32(firma)} AND CURTYPE=1),1,'USD','USD','$'),
('{firma}',(SELECT TOP 1 LOGICALREF FROM L_CURRENCYLIST WHERE FIRMNR={Convert.ToInt32(firma)} AND CURTYPE=20),20,'EUR','Euro','€')


";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }

        }
        public void TeklifGorusmelerTablosuOlustur(string firma, string donem)
        {
            try
            {
                clas.Connect();
                string sql = $@"CREATE TABLE [dbo].[LOGO_XERO_GORUSMELER_{firma}_{donem}](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TEKLIFID] [int] NULL,
	[TIP] [int] NULL,
	[TARIH] [datetime] NULL,
	[PERSONELID] [int] NULL,
	[PERSONEL] [varchar](50) NULL,
	[ACIKLAMA] [varchar](255) NULL,
 CONSTRAINT [PK_LOGO_XERO_GORUSMELER_{firma}_{donem}] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) 
) ON [PRIMARY]
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }
        }
        public void PazarlamaTipiDoldur()
        {
            try
            {
                clas.Connect();
                string sql = $@"declare @Toplam int
select @Toplam = count( * ) from LOGO_XERO_PAZARLAMA_TIPLERI 
if(@Toplam > 0)
print 'var'
else 
insert into LOGO_XERO_PAZARLAMA_TIPLERI (PAZARLAMATIPI)
values
('PAZARLAMA TIPI')
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }
        }
        public void TeslimSureleriDoldur()
        {
            try
            {
                clas.Connect();
                string sql = $@"declare @Toplam int
select @Toplam = count( * ) from LOGO_XERO_TESLIM_SURESI 
if(@Toplam > 0)
print 'var'
else 
insert into LOGO_XERO_TESLIM_SURESI (TESLIMSURESI)
values
('STOK VAR'),('1-GÜN'),('7-10 GÜN'),('1-2 HAFTA'),('1-2 AY')
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }
        }

        public void NakliyeTuruDoldur()
        {
            try
            {
                clas.Connect();
                string sql = $@"declare @Toplam int
select @Toplam = count( * ) from LOGO_XERO_NAKLIYE_TURU 
if(@Toplam > 0)
print 'var'
else 
insert into LOGO_XERO_NAKLIYE_TURU (NAKLIYETURU)
values ('DEPOMUZDAN TESLİM'),('KENDİ ARACIMIZ İLE'),('KARGO TESLİM')
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }
        }
        public void YetkiTablosuOlustur()
        {
            try
            {
                clas.Connect();
                string sql = $@"CREATE TABLE [dbo].[LOGO_XERO_YETKILER](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[YETKIID] [int] NULL,
	[YETKI] [nvarchar](max) NULL,
	[USTYETKIID] [int] NULL,
	[KAYITTARIHI] [datetime] NULL,
 CONSTRAINT [PK_LOGO_XERO_YETKILER] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)) ON [PRIMARY] 
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }
        }

        public void YetkiTablosuDoldur()
        {
            try
            {
                clas.Connect();
                string sql = $@"IF EXISTS (SELECT YETKIID FROM LOGO_XERO_YETKILER WHERE YETKIID=1)	PRINT 'VAR'
ELSE INSERT INTO [LOGO_XERO_YETKILER] (YETKIID,YETKI,USTYETKIID,KAYITTARIHI) VALUES (1,'Finans',0,'{DateTime.Now.ToString("yyyy-MM-dd")}');

IF EXISTS (SELECT YETKIID FROM LOGO_XERO_YETKILER WHERE YETKIID=2)	PRINT 'VAR'
ELSE insert into [LOGO_XERO_YETKILER] (YETKIID,YETKI,USTYETKIID,KAYITTARIHI) VALUES (2,'Malzeme Yönetimi',0,'{DateTime.Now.ToString("yyyy-MM-dd")}');

IF EXISTS (SELECT YETKIID FROM LOGO_XERO_YETKILER WHERE YETKIID=3)	PRINT 'VAR'
ELSE insert into [LOGO_XERO_YETKILER] (YETKIID,YETKI,USTYETKIID,KAYITTARIHI) VALUES (3,'Ana Kayıtlar',1,'{DateTime.Now.ToString("yyyy-MM-dd")}');

IF EXISTS (SELECT YETKIID FROM LOGO_XERO_YETKILER WHERE YETKIID=4)	PRINT 'VAR'
ELSE insert into [LOGO_XERO_YETKILER] (YETKIID,YETKI,USTYETKIID,KAYITTARIHI) VALUES (4,'Ana Kayıtlar',2,'{DateTime.Now.ToString("yyyy-MM-dd")}');


IF EXISTS (SELECT YETKIID FROM LOGO_XERO_YETKILER WHERE YETKIID=5)	PRINT 'VAR'
ELSE insert into [LOGO_XERO_YETKILER] (YETKIID,YETKI,USTYETKIID,KAYITTARIHI) VALUES (5,'Cari Hesaplar',3,'{DateTime.Now.ToString("yyyy-MM-dd")}');


IF EXISTS (SELECT YETKIID FROM LOGO_XERO_YETKILER WHERE YETKIID=6)	PRINT 'VAR'
ELSE insert into [LOGO_XERO_YETKILER] (YETKIID,YETKI,USTYETKIID,KAYITTARIHI) VALUES (6,'Düzenleme',5,'{DateTime.Now.ToString("yyyy-MM-dd")}');


IF EXISTS (SELECT YETKIID FROM LOGO_XERO_YETKILER WHERE YETKIID=7)	PRINT 'VAR'
ELSE insert into [LOGO_XERO_YETKILER] (YETKIID,YETKI,USTYETKIID,KAYITTARIHI) VALUES (7,'Ekleme',5,'{DateTime.Now.ToString("yyyy-MM-dd")}');


IF EXISTS (SELECT YETKIID FROM LOGO_XERO_YETKILER WHERE YETKIID=8)	PRINT 'VAR'
ELSE insert into [LOGO_XERO_YETKILER] (YETKIID,YETKI,USTYETKIID,KAYITTARIHI) VALUES (8,'Sevkiyat Adresleri',5,'{DateTime.Now.ToString("yyyy-MM-dd")}');

IF EXISTS (SELECT YETKIID FROM LOGO_XERO_YETKILER WHERE YETKIID=9)	PRINT 'VAR'
ELSE insert into [LOGO_XERO_YETKILER] (YETKIID,YETKI,USTYETKIID,KAYITTARIHI) VALUES (9,'Düzenleme',8,'{DateTime.Now.ToString("yyyy-MM-dd")}');


IF EXISTS (SELECT YETKIID FROM LOGO_XERO_YETKILER WHERE YETKIID=10)	PRINT 'VAR'
ELSE insert into [LOGO_XERO_YETKILER] (YETKIID,YETKI,USTYETKIID,KAYITTARIHI) VALUES (10,'Ekleme',8,'{DateTime.Now.ToString("yyyy-MM-dd")}');


IF EXISTS (SELECT YETKIID FROM LOGO_XERO_YETKILER WHERE YETKIID=11)	PRINT 'VAR'
ELSE insert into [LOGO_XERO_YETKILER] (YETKIID,YETKI,USTYETKIID,KAYITTARIHI) VALUES (11,'Stok Kartları',4,'{DateTime.Now.ToString("yyyy-MM-dd")}');


IF EXISTS (SELECT YETKIID FROM LOGO_XERO_YETKILER WHERE YETKIID=12)	PRINT 'VAR'
ELSE insert into [LOGO_XERO_YETKILER] (YETKIID,YETKI,USTYETKIID,KAYITTARIHI) VALUES (12,'Ekleme',11,'{DateTime.Now.ToString("yyyy-MM-dd")}');


IF EXISTS (SELECT YETKIID FROM LOGO_XERO_YETKILER WHERE YETKIID=13)	PRINT 'VAR'
ELSE insert into [LOGO_XERO_YETKILER] (YETKIID,YETKI,USTYETKIID,KAYITTARIHI) VALUES (13,'Güncelleme',11,'{DateTime.Now.ToString("yyyy-MM-dd")}');
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch (Exception EX)
            {
                clas.Conn.Close();
            }
        }
        public void PazarlamaTipiTablosuOlustur()
        {
            try
            {
                clas.Connect();
                string sql = $@"CREATE TABLE [dbo].[LOGO_XERO_PAZARLAMA_TIPLERI](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PAZARLAMATIPI] [nvarchar](max) NULL,
 CONSTRAINT [PK_LOGO_XERO_PAZARLAMA_TIPLERI] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)) ON [PRIMARY]
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }
        }
        public void TeslimSuresiTablosuOlustur()
        {
            try
            {
                clas.Connect();
                string sql = $@"CREATE TABLE [dbo].[LOGO_XERO_TESLIM_SURESI](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TESLIMSURESI] [nvarchar](max) NULL,
 CONSTRAINT [PK_LOGO_XERO_TESLIM_SURESI] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)) ON [PRIMARY]
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }
        }
        public void NakliyeTuruTablosuOlustur()
        {
            try
            {
                clas.Connect();
                string sql = $@"CREATE TABLE [dbo].[LOGO_XERO_NAKLIYE_TURU](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NAKLIYETURU] [nvarchar](max) NULL,
 CONSTRAINT [PK_LOGO_XERO_NAKLIYE_TURU] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)) ON [PRIMARY]
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }
        }
        public void KullaniciAmbarIsyeriYetkiTablosuOlustur()
        {
            try
            {
                clas.Connect();
                string sql = $@"CREATE TABLE [dbo].[LOGO_XERO_KULLANICI_AMBAR_ISYERI_YETKI](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KULLANICIID] [int] NULL,
	[FIRMANO] [nvarchar](max) NULL,
	[AMBARID] [smallint] NULL,
	[ISYERIID] [smallint] NULL,
 CONSTRAINT [PK_LOGO_XERO_KULLANICI_AMBAR_ISYERI_YETKI] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)) ON [PRIMARY]
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }
        }
        public void RaporDosyalariTablosuOlustur(string firma, string donem)
        {
            try
            {
                clas.Connect();
                string sql = $@"CREATE TABLE [dbo].[LOGO_XERO_RAPOR_DOSYALARI_{firma}_{donem}](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SABLON] [int] NULL,
	[AKTIF] [bit] NULL,
	[MODUL] [nvarchar](max) NULL,
	[RAPORADI] [nvarchar](max) NULL,
	[VARSAYILAN] [bit] NULL,
	[DOSYA] [image] NULL,
	[DOVIZLI] [bit] NULL,
 CONSTRAINT [PK_LOGO_XERO_RAPOR_DOSYALARI_{firma}_{donem}] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)) 
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }
        }
        public void HizmetListesiViewOlustur(string firma, string donem)
        {
            try
            {
                clas.Connect();
                string sql = $@"CREATE VIEW [dbo].[LOGO_XERO_HIZMETLISTESI_{firma}]
                AS
                    SELECT S.LOGICALREF, S.SPECODE OZELKOD,S.CODE STOKKODU,S.DEFINITION_ STOKCINSI, S.DEFINITION2 ACIKLAMA3,'' ACIKLAMA4, '' MARKA,
S.SPECODE OZELKOD1,(SELECT TOP 1 DEFINITION_ FROM LG_{firma}_SPECODES With (Nolock) WHERE SPECODE=S.SPECODE AND SPETYP1=1 AND CODETYPE=1 AND SPECODETYPE=1) OZKODACIKLAMA, 
S.SPECODE2 OZELKOD2,S.SPECODE3 OZELKOD3,S.SPECODE4 OZELKOD4,S.SPECODE5 OZELKOD5,S.CYPHCODE YETKIKODU,S.VAT [KDV],
ISNULL((SELECT SUM(TOTALS_AMOUNT) FROM LV_{firma}_{donem}_SRVTOT WITH (NOLOCK) WHERE CARDREF=S.LOGICALREF AND INVENNO=-1),0) STOKBAKIYE,
S.CARDTYPE AS MINMIKTAR,0 LOTTID,
CAST(0 AS FLOAT )[PRKSATISFIYATI],
CAST(0 AS FLOAT ) DESI,
ISNULL(S.CANDEDUCT,0) [TEVKIFAT], S.DEDUCTCODE [TEVKIFATKODU], S.DEDUCTIONPART1 [TEVKIFATCARPAN], S.DEDUCTIONPART2 [TEVKIFATBOLEN],S.UNITSETREF,ISNULL(0,0) KDVDURUMU,CAST(0 AS SMALLINT)DOVIZKODU, CAST(0 AS FLOAT ) LISTEFIYATI, 'TL' DOVIZ, '' BARKOD,'' BARKOD2, BIRIM
FROM LG_{firma}_SRVCARD S With (Nolock)
OUTER APPLY(select TOP 1 CODE BIRIM From LG_{firma}_UNITSETL WITH(NOLOCK) where LG_{firma}_UNITSETL.UNITSETREF=S.UNITSETREF AND MAINUNIT=1)BIRIM
WHERE S.ACTIVE=0 AND S.CODE !='ÿ'
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }
        }

        public void HizmetListesiViewGuncelle(string firma, string donem)
        {
            try
            {
                clas.Connect();
                string sql = $@"ALTER VIEW [dbo].[LOGO_XERO_HIZMETLISTESI_{firma}]
                AS
                    SELECT S.LOGICALREF, S.SPECODE OZELKOD,S.CODE STOKKODU,S.DEFINITION_ STOKCINSI, S.DEFINITION2 ACIKLAMA3,'' ACIKLAMA4, '' MARKA,
S.SPECODE OZELKOD1,(SELECT TOP 1 DEFINITION_ FROM LG_{firma}_SPECODES With (Nolock) WHERE SPECODE=S.SPECODE AND SPETYP1=1 AND CODETYPE=1 AND SPECODETYPE=1) OZKODACIKLAMA, 
S.SPECODE2 OZELKOD2,S.SPECODE3 OZELKOD3,S.SPECODE4 OZELKOD4,S.SPECODE5 OZELKOD5,S.CYPHCODE YETKIKODU,S.VAT [KDV],
ISNULL((SELECT SUM(TOTALS_AMOUNT) FROM LV_{firma}_{donem}_SRVTOT WITH (NOLOCK) WHERE CARDREF=S.LOGICALREF AND INVENNO=-1),0) STOKBAKIYE,
S.CARDTYPE AS MINMIKTAR,0 LOTTID,
CAST(0 AS FLOAT )[PRKSATISFIYATI],
CAST(0 AS FLOAT ) DESI,
ISNULL(S.CANDEDUCT,0) [TEVKIFAT], S.DEDUCTCODE [TEVKIFATKODU], S.DEDUCTIONPART1 [TEVKIFATCARPAN], S.DEDUCTIONPART2 [TEVKIFATBOLEN],S.UNITSETREF,ISNULL(0,0) KDVDURUMU,CAST(0 AS SMALLINT)DOVIZKODU, CAST(0 AS FLOAT ) LISTEFIYATI, 'TL' DOVIZ, '' BARKOD,'' BARKOD2, BIRIM
FROM LG_{firma}_SRVCARD S With (Nolock)
OUTER APPLY(select TOP 1 CODE BIRIM From LG_{firma}_UNITSETL WITH(NOLOCK) where LG_{firma}_UNITSETL.UNITSETREF=S.UNITSETREF AND MAINUNIT=1)BIRIM
WHERE S.ACTIVE=0 AND S.CODE !='ÿ'
";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }
        }
        public void TeklifDurumlariEkle()
        {
            try
            {
                clas.Connect();
                string sql = $@"IF EXISTS (SELECT TIP FROM LOGO_XERO_TEKLIF_DURUMLARI WHERE TIP=1)	PRINT 'VAR'
ELSE INSERT INTO [dbo].[LOGO_XERO_TEKLIF_DURUMLARI]  ([TIP] ,[DURUM]) VALUES (1,'TEKLİF HAZIRLANDI');

IF EXISTS (SELECT TIP FROM LOGO_XERO_TEKLIF_DURUMLARI WHERE TIP=2)	PRINT 'VAR'
ELSE INSERT INTO [dbo].[LOGO_XERO_TEKLIF_DURUMLARI]  ([TIP] ,[DURUM]) VALUES (2,'İLETİLDİ');

IF EXISTS (SELECT TIP FROM LOGO_XERO_TEKLIF_DURUMLARI WHERE TIP=3)	PRINT 'VAR'
ELSE INSERT INTO [dbo].[LOGO_XERO_TEKLIF_DURUMLARI]  ([TIP] ,[DURUM]) VALUES (3,'SİPARİŞE DÖNÜŞTÜ');

IF EXISTS (SELECT TIP FROM LOGO_XERO_TEKLIF_DURUMLARI WHERE TIP=4)	PRINT 'VAR'
ELSE INSERT INTO [dbo].[LOGO_XERO_TEKLIF_DURUMLARI]  ([TIP] ,[DURUM]) VALUES (4,'FATURAYA DÖNÜŞTÜ');

IF EXISTS (SELECT TIP FROM LOGO_XERO_TEKLIF_DURUMLARI WHERE TIP=5)	PRINT 'VAR'
ELSE INSERT INTO [dbo].[LOGO_XERO_TEKLIF_DURUMLARI]  ([TIP] ,[DURUM]) VALUES (5,'İPTAL EDİLDİ');


";
                SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                clas.Conn.Open();
                cmd.ExecuteNonQuery();
                clas.Conn.Close();

            }
            catch
            {
                clas.Conn.Close();
            }
        }
        public MemoryStream StoreReportToStream(XtraReport report)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Flush();
            stream.Position = 0;
            report.SaveLayout(stream);
            return stream;
        }
        public void RaporTasarimlariKaydet()
        {
            try
            {
                using (LogoContext db = new LogoContext())
                {
                    Teklif report1 = new Teklif();
                    var dosya1 = StoreReportToStream(report1);

                    byte[] array1 = new byte[dosya1.Length];
                    array1 = dosya1.ToArray();
                    bool var1 = db.LOGO_XERO_RAPOR_DOSYALARI.Any(S => S.RAPORADI == "TL STANDART TEKLİF");
                    if (!var1)
                    {
                        LOGO_XERO_RAPOR_DOSYALARI yeni1 = new LOGO_XERO_RAPOR_DOSYALARI();
                        yeni1.SABLON = 1;
                        yeni1.MODUL = "TEKLİF";
                        yeni1.RAPORADI = "TL STANDART TEKLİF";
                        yeni1.VARSAYILAN = true;
                        yeni1.DOSYA = array1;
                        yeni1.DOVIZLI = false;
                        yeni1.AKTIF = true;
                        db.LOGO_XERO_RAPOR_DOSYALARI.Add(yeni1);
                        db.SaveChanges();
                    }

                    DovizliTeklif report2 = new DovizliTeklif();
                    var dosya2 = StoreReportToStream(report2);

                    byte[] array2 = new byte[dosya2.Length];
                    array2 = dosya2.ToArray();
                    bool var2 = db.LOGO_XERO_RAPOR_DOSYALARI.Any(S => S.RAPORADI == "DÖVİZLİ TEKLİF");
                    if (!var2)
                    {
                        LOGO_XERO_RAPOR_DOSYALARI yeni2 = new LOGO_XERO_RAPOR_DOSYALARI();
                        yeni2.SABLON = 1;
                        yeni2.MODUL = "TEKLİF";
                        yeni2.RAPORADI = "DÖVİZLİ TEKLİF";
                        yeni2.VARSAYILAN = false;
                        yeni2.DOSYA = array2;
                        yeni2.DOVIZLI = false;
                        yeni2.AKTIF = true;
                        db.LOGO_XERO_RAPOR_DOSYALARI.Add(yeni2);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}