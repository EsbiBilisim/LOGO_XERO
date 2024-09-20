using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using LOGO_XERO.Moduller.Giris_AnaForm_Ayarlar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LOGO_XERO.Models.GenelKullanim;

namespace LOGO_XERO.Moduller.Personeller
{
    public partial class frmKullaniciEkle : DevExpress.XtraEditors.XtraForm
    {
        SQLConnection clas = new SQLConnection();
        public int gorevid;
        Islemler islem = new Islemler();
        frmAnaForm ana;
        string firma;
        string donem;
        public int kullaniciid = 0;
        bool duzenle = false;

        public string selectedIdsString;

        IlkTabloIslemler isl = new IlkTabloIslemler();
        public frmKullaniciEkle()
        {
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            firma = ana.lk_firma.EditValue.ToString();
            donem = ana.lk_donem.EditValue.ToString();
            InitializeComponent();
            isl.isyerisorgudondur(firma, lk_isyeri);
            isl.isyerisorgudondur(firma, lk_girisisyeri);
            isl.bolumsorgudondur(firma, lk_bolum);
            isl.bolumsorgudondur(firma, lk_girisbolum);
            isl.logosatiselemanisorgudondur(lk_satiselemani, firma);

            IslemleriGetir();

            rjButton2.Visible = false;
            rjButton3.Visible = false;
        }
        public frmKullaniciEkle(int _kullaniciid)
        {
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            firma = ana.lk_firma.EditValue.ToString();
            donem = ana.lk_donem.EditValue.ToString();
            InitializeComponent();
            isl.isyerisorgudondur(firma, lk_isyeri);
            isl.isyerisorgudondur(firma, lk_girisisyeri);
            isl.bolumsorgudondur(firma, lk_bolum);
            isl.bolumsorgudondur(firma, lk_girisbolum);
            isl.logosatiselemanisorgudondur(lk_satiselemani, firma);
            kullaniciid = _kullaniciid;
            duzenle = true;

            IslemleriGetir();
            yerlerinegetir();

            rjButton2.Visible = true;
            rjButton3.Visible = true;
        }

        public void yerlerinegetir()
        {
            try
            {
                clas.Connect();
                string sqlParametre = $@"SELECT G.GOREVTANIMI,K.* FROM LOGO_XERO_KULLANICILAR K LEFT OUTER JOIN LOGO_XERO_GOREVLER G ON K.GOREV = G.ID WHERE K.ID={kullaniciid}";
                SqlCommand cmd = new SqlCommand(sqlParametre, clas.Conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                List<KULLANICILAR> denemes = new List<KULLANICILAR>();
                DataSet ds = new DataSet();
                da.Fill(ds);

                KULLANICILAR kullanici = new KULLANICILAR();

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
                    kullanici.GIRISAMBAR = (int)Convert.ToInt32(ds.Tables[0].Rows[0]["GIRISAMBAR"]);
                if (ds.Tables[0].Rows[0]["GIRISBOLUM"] != DBNull.Value)
                    kullanici.GIRISBOLUM = (int)Convert.ToInt32(ds.Tables[0].Rows[0]["GIRISBOLUM"]);
                if (ds.Tables[0].Rows[0]["GIRISISYERI"] != DBNull.Value)
                    kullanici.GIRISISYERI = (int)Convert.ToInt32(ds.Tables[0].Rows[0]["GIRISISYERI"]);
                if (ds.Tables[0].Rows[0]["GOREVTANIMI"] != DBNull.Value)
                    kullanici.GOREVTANIMI = (string)ds.Tables[0].Rows[0]["GOREVTANIMI"].ToString();

                kullaniciid = kullanici.ID;
                lk_satiselemani.EditValue = kullanici.LOGOSATISELEMANIID;
                txt_kullaniciadi.Text = kullanici.KULLANICIADI;
                txt_sifre.Text = kullanici.SIFRE;
                txt_telefon.Text = kullanici.TELEFON;
                txt_eposta.Text = kullanici.EPOSTA;
                txt_ilce.Text = kullanici.ILCE;
                txt_il.Text = kullanici.IL;
                txt_adres.Text = kullanici.ADRES; ;
                btntxt_görevi.Text = kullanici.GOREVTANIMI;
                txt_tekliftutarlimit.Text = kullanici.TEKLIFTUTARILIMIT.ToString();
                txt_kisitliozelkod.Text = kullanici.KISITLIOZELKOD;
                txt_iskontolimit.Text = kullanici.ISKONTOLIMIT.ToString();
                lk_isyeri.EditValue = kullanici.ISYERI;
                lk_fabrika.EditValue = kullanici.FABRIKA;
                lk_bolum.EditValue = kullanici.BOLUM;
                lk_ambar.EditValue = kullanici.AMBAR;
                lk_girisisyeri.EditValue = kullanici.GIRISISYERI;
                lk_girisambar.EditValue = kullanici.GIRISAMBAR;
                lk_girisbolum.EditValue = kullanici.GIRISBOLUM;
                gorevid = Convert.ToInt32(kullanici.GOREV);

                LoadPermissions(kullaniciid);
            }
            catch (Exception EX)
            {
                MessageBox.Show("Hata:" + EX);
            }
        }
        private void rjButton1_Click(object sender, EventArgs e)
        {
            if (duzenle)
            {
                frmYetkilendirme frm = new frmYetkilendirme(kullaniciid);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sadece Kayıt Edilmiş Kullanıcıların Ambarı Düzenlenebilir");
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            string desen = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            if (!string.IsNullOrWhiteSpace(txt_eposta.Text))
            {
                bool dogruMu = Regex.IsMatch(txt_eposta.Text, desen);
                if (!dogruMu)
                {
                    XtraMessageBox.Show("E-Posta Formatı Yanlış !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_eposta.Focus();
                    return;
                }
            }

            if (lk_satiselemani.EditValue == null)
            {
                XtraMessageBox.Show("LOGO Satış Elemanı Boş Bırakılamaz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lk_satiselemani.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txt_sifre.Text))
            {
                XtraMessageBox.Show("Şifre Boş Bırakılamaz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_sifre.Focus();
                return;
            }
            if (lk_isyeri.EditValue == null || lk_fabrika.EditValue == null || lk_bolum.EditValue == null || lk_ambar.EditValue == null || lk_girisisyeri.EditValue == null || lk_girisbolum.EditValue == null || lk_girisambar.EditValue == null)
            {
                XtraMessageBox.Show("Sabit Tanımlar Kısmı Boş Bırakılamaz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                groupControl1.Appearance.BorderColor = System.Drawing.Color.Red;
                groupControl1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(btntxt_görevi.Text))
            {
                XtraMessageBox.Show("Görev Kısmı Boş Bırakılamaz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btntxt_görevi.Focus();
                return;
            }

            if (duzenle)
            {
                kullaniciduzenle();
            }
            else
            {
                yenikullaniciekle();

            }
        }

        private void lk_isyeri_EditValueChanged(object sender, EventArgs e)
        {
            if (lk_isyeri.EditValue != null)
            {
                isl.ambarsorgudondur(firma, lk_ambar, lk_isyeri);
                isl.fabrikasorgudondur(firma, lk_fabrika);
            }
        }

        public void kullaniciduzenle()
        {
            try
            {
                //KULLANICI DUZENLERKEN HATA VERİYORDU
                var checkedNodes = İşlemler.GetAllCheckedNodes();
                var selectedIds = checkedNodes.Select(node => (int)node.GetValue("YETKIID")).OrderBy(id => id).ToList();

                selectedIdsString = string.Join(",", selectedIds);
                clas.Connect();

                clas.Conn.Open();
                SqlCommand VeriKaydet = new SqlCommand($@"UPDATE [dbo].[LOGO_XERO_KULLANICILAR]
      SET [KULLANICIADI] = @KULLANICIADI
      ,[LOGOSATISELEMANIID] = @LOGOSATISELEMANIID
      ,[SIFRE] = @SIFRE
      ,[TANIMLIFIRMA] = @TANIMLIFIRMA
      ,[TANIMLIDONEM] = @TANIMLIDONEM
      ,[ISYERI] =       @ISYERI
      ,[BOLUM] =        @BOLUM
      ,[FABRIKA] =      @FABRIKA
      ,[AMBAR] =        @AMBAR
      ,[TELEFON] =      @TELEFON
      ,[EPOSTA] =       @EPOSTA
      ,[ILCE] =         @ILCE
      ,[IL] =           @IL
      ,[ADRES] =        @ADRES
      ,[GOREV] =        @GOREV
      ,[TEKLIFTUTARILIMIT] = @TEKLIFTUTARILIMIT
      ,[KISITLIOZELKOD] =    @KISITLIOZELKOD
      ,[ISKONTOLIMIT] =      @ISKONTOLIMIT
      ,[GIRISAMBAR] =        @GIRISAMBAR
      ,[GIRISISYERI] =       @GIRISISYER
      ,[GIRISBOLUM] =        @GIRISBOLUM
      ,[YETKI] = @YETKI  
      WHERE ID = {kullaniciid}", clas.Conn);
                VeriKaydet.Parameters.AddWithValue("@KULLANICIADI", txt_kullaniciadi.Text);
                VeriKaydet.Parameters.AddWithValue("@SIFRE", txt_sifre.Text);
                VeriKaydet.Parameters.AddWithValue("@TANIMLIFIRMA", firma);
                VeriKaydet.Parameters.AddWithValue("@TANIMLIDONEM", donem);
                VeriKaydet.Parameters.AddWithValue("@ISYERI", Convert.ToInt16(lk_isyeri.EditValue));
                VeriKaydet.Parameters.AddWithValue("@BOLUM", Convert.ToInt16(lk_bolum.EditValue));
                VeriKaydet.Parameters.AddWithValue("@TELEFON", txt_telefon.Text);
                VeriKaydet.Parameters.AddWithValue("@EPOSTA", txt_eposta.Text);
                VeriKaydet.Parameters.AddWithValue("@ILCE", txt_ilce.Text);
                VeriKaydet.Parameters.AddWithValue("@IL", txt_il.Text);
                VeriKaydet.Parameters.AddWithValue("@ADRES", txt_adres.Text);
                VeriKaydet.Parameters.AddWithValue("@GOREV", gorevid);
                VeriKaydet.Parameters.AddWithValue("@TEKLIFTUTARILIMIT", Convert.ToInt32(txt_tekliftutarlimit.Text));
                VeriKaydet.Parameters.AddWithValue("@KISITLIOZELKOD", txt_kisitliozelkod.Text);
                VeriKaydet.Parameters.AddWithValue("@ISKONTOLIMIT", Convert.ToSingle(txt_iskontolimit.Text));
                VeriKaydet.Parameters.AddWithValue("@YETKI", selectedIdsString);


                if (lk_satiselemani.EditValue == null)
                    VeriKaydet.Parameters.AddWithValue("@LOGOSATISELEMANIID", DBNull.Value);
                else
                    VeriKaydet.Parameters.AddWithValue("@LOGOSATISELEMANIID", lk_satiselemani.EditValue);
                if (lk_fabrika.EditValue == null)
                    VeriKaydet.Parameters.AddWithValue("@FABRIKA", DBNull.Value);
                else
                    VeriKaydet.Parameters.AddWithValue("@FABRIKA", Convert.ToInt16(lk_fabrika.EditValue));
                if (lk_ambar.EditValue == null)
                    VeriKaydet.Parameters.AddWithValue("@AMBAR", DBNull.Value);
                else
                    VeriKaydet.Parameters.AddWithValue("@AMBAR", lk_ambar.EditValue);
                if (lk_girisambar.EditValue == null)
                    VeriKaydet.Parameters.AddWithValue("@GIRISAMBAR", DBNull.Value);
                else
                    VeriKaydet.Parameters.AddWithValue("@GIRISAMBAR", lk_girisambar.EditValue);
                if (lk_girisbolum.EditValue == null)
                    VeriKaydet.Parameters.AddWithValue("@GIRISBOLUM", DBNull.Value);
                else
                    VeriKaydet.Parameters.AddWithValue("@GIRISBOLUM", lk_girisbolum.EditValue);
                if (lk_girisisyeri.EditValue == null)
                    VeriKaydet.Parameters.AddWithValue("@GIRISISYER", DBNull.Value);
                else
                    VeriKaydet.Parameters.AddWithValue("@GIRISISYER", lk_girisisyeri.EditValue);
                VeriKaydet.ExecuteNonQuery();
                clas.Conn.Close();
                MessageBox.Show("Düzenleme Başarılı");
            }
            catch (Exception ex)
            {
                MessageBox.Show("KAYIT BAŞARISIZ : " + ex, "Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void yenikullaniciekle()
        {
            try
            {
                var checkedNodes = İşlemler.GetAllCheckedNodes();
                var selectedIds = checkedNodes.Select(node => (int)node.GetValue("YETKIID")).OrderBy(id => id).ToList();

                selectedIdsString = string.Join(",", selectedIds);


                clas.Connect();
                clas.Conn.Open();
                SqlCommand VeriKaydet = new SqlCommand($@"INSERT INTO [dbo].[LOGO_XERO_KULLANICILAR]
           ([KULLANICIADI]
           ,[LOGOSATISELEMANIID]
           ,[SIFRE]
           ,[TANIMLIFIRMA]
           ,[TANIMLIDONEM]
           ,[ISYERI]
           ,[BOLUM]
           ,[FABRIKA]
           ,[AMBAR]
           ,[TELEFON]
           ,[EPOSTA]
           ,[ILCE]
           ,[IL]
           ,[ADRES]
           ,[GOREV]
           ,[TEKLIFTUTARILIMIT]
           ,[KISITLIOZELKOD]
           ,[ISKONTOLIMIT]
           ,[GIRISAMBAR]
           ,[GIRISISYERI]
           ,[GIRISBOLUM]
           ,[YETKI])
     VALUES
           (@KULLANICIADI
           ,@LOGOSATISELEMANIID
           ,@SIFRE
           ,@TANIMLIFIRMA
           ,@TANIMLIDONEM
           ,@ISYERI
           ,@BOLUM
           ,@FABRIKA
           ,@AMBAR
           ,@TELEFON
           ,@EPOSTA
           ,@ILCE
           ,@IL
           ,@ADRES
           ,@GOREV
           ,@TEKLIFTUTARILIMIT
           ,@KISITLIOZELKOD
           ,@ISKONTOLIMIT
           ,@GIRISAMBAR
           ,@GIRISISYER
           ,@GIRISBOLUM
           ,@YETKI)", clas.Conn);
                VeriKaydet.Parameters.AddWithValue("@KULLANICIADI", txt_kullaniciadi.Text);
                VeriKaydet.Parameters.AddWithValue("@SIFRE", txt_sifre.Text);
                VeriKaydet.Parameters.AddWithValue("@TANIMLIFIRMA", firma);
                VeriKaydet.Parameters.AddWithValue("@TANIMLIDONEM", donem);
                VeriKaydet.Parameters.AddWithValue("@ISYERI", Convert.ToInt16(lk_isyeri.EditValue));
                VeriKaydet.Parameters.AddWithValue("@BOLUM", Convert.ToInt16(lk_bolum.EditValue));
                VeriKaydet.Parameters.AddWithValue("@TELEFON", txt_telefon.Text);
                VeriKaydet.Parameters.AddWithValue("@EPOSTA", txt_eposta.Text);
                VeriKaydet.Parameters.AddWithValue("@ILCE", txt_ilce.Text);
                VeriKaydet.Parameters.AddWithValue("@IL", txt_il.Text);
                VeriKaydet.Parameters.AddWithValue("@ADRES", txt_adres.Text);
                VeriKaydet.Parameters.AddWithValue("@GOREV", gorevid);
                VeriKaydet.Parameters.AddWithValue("@TEKLIFTUTARILIMIT", Convert.ToInt32(txt_tekliftutarlimit.Text));
                VeriKaydet.Parameters.AddWithValue("@KISITLIOZELKOD", txt_kisitliozelkod.Text);
                VeriKaydet.Parameters.AddWithValue("@YETKI", selectedIdsString);
                VeriKaydet.Parameters.AddWithValue("@ISKONTOLIMIT", Convert.ToSingle(txt_iskontolimit.Text));
             
                if (lk_satiselemani.EditValue == null)
                    VeriKaydet.Parameters.AddWithValue("@LOGOSATISELEMANIID", DBNull.Value);
                else
                    VeriKaydet.Parameters.AddWithValue("@LOGOSATISELEMANIID", lk_satiselemani.EditValue);
                if (lk_fabrika.EditValue == null)
                    VeriKaydet.Parameters.AddWithValue("@FABRIKA", DBNull.Value);
                else
                    VeriKaydet.Parameters.AddWithValue("@FABRIKA", Convert.ToInt16(lk_fabrika.EditValue));
                if (lk_ambar.EditValue == null)
                    VeriKaydet.Parameters.AddWithValue("@AMBAR", DBNull.Value);
                else
                    VeriKaydet.Parameters.AddWithValue("@AMBAR", lk_ambar.EditValue);
                if (lk_girisambar.EditValue == null)
                    VeriKaydet.Parameters.AddWithValue("@GIRISAMBAR", DBNull.Value);
                else
                    VeriKaydet.Parameters.AddWithValue("@GIRISAMBAR", lk_girisambar.EditValue);
                if (lk_girisbolum.EditValue == null)
                    VeriKaydet.Parameters.AddWithValue("@GIRISBOLUM", DBNull.Value);
                else
                    VeriKaydet.Parameters.AddWithValue("@GIRISBOLUM", lk_girisbolum.EditValue);
                if (lk_girisisyeri.EditValue == null)
                    VeriKaydet.Parameters.AddWithValue("@GIRISISYER", DBNull.Value);
                else
                    VeriKaydet.Parameters.AddWithValue("@GIRISISYER", lk_girisisyeri.EditValue);
                VeriKaydet.ExecuteNonQuery();
                clas.Conn.Close();
                MessageBox.Show("YENİ KAYIT BAŞARILI", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("KAYIT BAŞARISIZ : " + ex, "Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btntxt_görevi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmGorevler gorevler = new frmGorevler(this);
            gorevler.ShowDialog();

        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmKullaniciEkle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                simpleButton4_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                simpleButton2_Click(sender, e);
            }
        }

        private void lk_girisisyeri_EditValueChanged(object sender, EventArgs e)
        {
            girisisyeriambardegistir();
        }
        public void girisisyeriambardegistir()
        {
            clas.Connect();
            string sqlParametre = $@"select NR AS CODE ,NAME AS NAME from L_CAPIWHOUSE where FIRMNR = '{firma}' AND DIVISNR = '{lk_girisisyeri.EditValue}'";
            SqlCommand cmd = new SqlCommand(sqlParametre, clas.Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            List<CODENAME> denemes = new List<CODENAME>();
            DataSet ds = new DataSet();
            da.Fill(ds);

            foreach (DataRow MyDataRow in ds.Tables[0].Rows)
            {

                denemes.Add(new CODENAME()
                {
                    CODE = (string)MyDataRow["CODE"].ToString(),
                    NAME = (string)MyDataRow["NAME"].ToString()
                });
            }
            lk_girisambar.Properties.DisplayMember = "NAME";
            lk_girisambar.Properties.ValueMember = "CODE";
            lk_girisambar.Properties.DataSource = denemes;
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            if (duzenle)
            {
                frmKullaniciIsyeriAmbarYetkileri frm = new frmKullaniciIsyeriAmbarYetkileri(this);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sadece Kayıt Edilmiş Kullanıcıların Ambarı Düzenlenebilir");
            }
        }

        private void frmKullaniciEkle_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmKullaniciListesi kln = Application.OpenForms["frmKullaniciListesi"] as frmKullaniciListesi;
            kln.kullanicilarilistele();
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
            clas.Connect();
            clas.Conn.Open();

            string sqlParametre = $@"select YETKI from LOGO_XERO_KULLANICILAR WHERE ID = {kullaniciid}";
            SqlCommand cmd = new SqlCommand(sqlParametre, clas.Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            string YETKI = " ";
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow MyDataRow in ds.Tables[0].Rows)
            {
                YETKI = MyDataRow["YETKI"].ToString();

            }

            SqlCommand VeriKaydet = new SqlCommand($@" UPDATE [dbo].LOGO_XERO_GOREVLER
            SET 
            [YETKI] = @YETKI
            WHERE ID = @GOREVID", clas.Conn);
            VeriKaydet.Parameters.AddWithValue("@YETKI", YETKI);
            VeriKaydet.Parameters.AddWithValue("@GOREVID", gorevid);
            VeriKaydet.ExecuteNonQuery();
            clas.Conn.Close();
            XtraMessageBox.Show("İşlem Başarılı !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void IslemleriGetir()
        {
            clas.Connect();
            İşlemler.OptionsView.ShowCheckBoxes = true;
            İşlemler.OptionsBehavior.PopulateServiceColumns = true;

            string query = "SELECT * FROM LOGO_XERO_YETKILER";

            using (SqlDataAdapter adapter = new SqlDataAdapter(query, clas.Conn))
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                DataTable table = ds.Tables[0];

                İşlemler.DataSource = table;

                İşlemler.KeyFieldName = "YETKIID";
                İşlemler.ParentFieldName = "USTYETKIID";

                İşlemler.Columns.Clear();

                var colID = İşlemler.Columns.Add();
                colID.FieldName = "ID";
                colID.Caption = "ID";
                colID.Visible = false;

                var colYETKIID = İşlemler.Columns.Add();
                colYETKIID.FieldName = "YETKIID";
                colYETKIID.Caption = "Yetki Id";
                colYETKIID.Visible = false;

                var colYETKI = İşlemler.Columns.Add();
                colYETKI.FieldName = "YETKI";
                colYETKI.Caption = "Yetki";
                colYETKI.Visible = true;

                var colUSTYETKIID = İşlemler.Columns.Add();
                colUSTYETKIID.FieldName = "USTYETKIID";
                colUSTYETKIID.Caption = "Üst Yetki ID";
                colUSTYETKIID.Visible = false;

                var colKAYITTARIHI = İşlemler.Columns.Add();
                colKAYITTARIHI.FieldName = "KAYITTARIHI";
                colKAYITTARIHI.Caption = "Kayıt Tarihi";
                colKAYITTARIHI.Visible = false;

                İşlemler.ExpandAll();
            }
        }

        private void LoadPermissions(int id)
        {
            clas.Connect();
            clas.Conn.Open();
            try
            {
                string query = "SELECT YETKI FROM LOGO_XERO_KULLANICILAR WHERE ID = @KullaniciID";

                using (SqlCommand command = new SqlCommand(query, clas.Conn))
                {
                    command.Parameters.AddWithValue("@KullaniciID", id);
                    var result = command.ExecuteScalar();
                    if (result == System.DBNull.Value || result == null)
                    {
                        İşlemler.UncheckAll();
                        return;
                    }
                    var yetkiler = (string)result;
                    if (!string.IsNullOrEmpty(yetkiler))
                    {
                        var yetkiIds = yetkiler.Split(',').Select(int.Parse).ToList();
                        CheckNodes(yetkiIds);
                    }
                }
            }
            finally
            {
                if (clas.Conn != null && clas.Conn.State == ConnectionState.Open)
                {
                    clas.Conn.Close();
                }
            }
        }

        private void CheckNodes(List<int> yetkiIds)
        {
            foreach (var id in yetkiIds)
            {
                var node = İşlemler.FindNodeByKeyID(id);
                if (node != null)
                {
                    node.CheckState = CheckState.Checked;
                }
                else
                {
                    MessageBox.Show($"Node with Key ID {id} not found.");
                }
            }
        }

        public void İşlemler_AfterCheckNode(object sender, NodeEventArgs e)
        {
            if (btntxt_görevi.Text == "")
            {
                İşlemler.UncheckAll();
                XtraMessageBox.Show("Kullanıcı Yetkisi Belirlemeden Önce, Görev Giriniz!");
                btntxt_görevi.Focus();
                return;
            }
            UpdateChildNodesCheckState(e.Node, e.Node.CheckState);
            UpdateParentNodesCheckState(e.Node);

            var checkedNodes = İşlemler.GetAllCheckedNodes();
            var selectedIds = checkedNodes.Select(node => (int)node.GetValue("YETKIID")).OrderBy(id => id).ToList();

            selectedIdsString = string.Join(",", selectedIds);
        }

        private void UpdateChildNodesCheckState(TreeListNode node, CheckState checkState)
        {
            foreach (TreeListNode childNode in node.Nodes)
            {
                childNode.CheckState = checkState;
                UpdateChildNodesCheckState(childNode, checkState);
            }
        }

        private void UpdateParentNodesCheckState(TreeListNode node)
        {
            if (node.ParentNode != null)
            {
                bool allSiblingsChecked = true;
                bool allSiblingsUnchecked = true;

                foreach (TreeListNode siblingNode in node.ParentNode.Nodes)
                {
                    if (siblingNode.CheckState != CheckState.Checked)
                    {
                        allSiblingsChecked = false;
                    }
                    if (siblingNode.CheckState != CheckState.Unchecked)
                    {
                        allSiblingsUnchecked = false;
                    }
                }

                if (allSiblingsChecked)
                {
                    node.ParentNode.CheckState = CheckState.Checked;
                }
                else if (allSiblingsUnchecked)
                {
                    node.ParentNode.CheckState = CheckState.Unchecked;
                }

                UpdateParentNodesCheckState(node.ParentNode);
            }
        }

        private void frmKullaniciEkle_Load(object sender, EventArgs e)
        {

        }
    }
}