using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using LOGO_XERO.Models.GenelKullanim;
using LOGO_XERO.Models.LOGO_XERO_M;
using LOGO_XERO.Moduller.Giris_AnaForm_Ayarlar;
using Microsoft.Win32;
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

namespace LOGO_XERO
{
    public partial class frmAyarlar : DevExpress.XtraEditors.XtraForm
    {
        public frmAyarlar()
        {
            InitializeComponent();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txservername.Text == string.Empty || txservername.Text == string.Empty || txkullnciad.Text == string.Empty || lk_databaseListesi.EditValue == null)
            {
                XtraMessageBox.Show("Lütfen Tüm Alanları Doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string sorgu = $@"Data Source={txservername.Text};uid={txkullnciad.Text};pwd={txsfre.Text};database={lk_databaseListesi.EditValue.ToString()};Connect Timeout=10;";
                try
                {
                    using (SqlConnection connection = new SqlConnection())
                    {
                        connection.ConnectionString = sorgu;
                        connection.Open();

                        if (connection.State == ConnectionState.Broken)
                        {
                            XtraMessageBox.Show("Bağlantı Bilgileri Yanlıştır !");
                            return;
                        }
                    }
                }
                catch (Exception)
                {
                    XtraMessageBox.Show("Bağlantı Bilgileri Yanlıştır !");
                    return;
                }
                RegistryKey rsk = Registry.CurrentUser.CreateSubKey("Software\\EsbiSetting\\LOGO_XERO");
                rsk.SetValue("SERVERNAME", txservername.Text, RegistryValueKind.String);
                rsk.SetValue("DBNAME", lk_databaseListesi.EditValue.ToString(), RegistryValueKind.String);
                rsk.SetValue("USERNAME", txkullnciad.Text, RegistryValueKind.String);
                rsk.SetValue("PASSWORD", txsfre.Text, RegistryValueKind.String);
                MessageBox.Show("Kaydedilmiştir !");

                IlkTabloIslemler Tablo = new IlkTabloIslemler();
                Tablo.LisansTablosuOlustur();
                Tablo.LisansTablosuModulEkle();


               
                btn_lisansGirisi.Visible = true;

            }
        }

        private void frmAyarlar_Load(object sender, EventArgs e)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\EsbiSetting\\LOGO_XERO");

            if (rk != null)
            {
                txservername.Text = rk.GetValue("SERVERNAME").ToString();

                txkullnciad.Text = rk.GetValue("USERNAME").ToString();
                txsfre.Text = rk.GetValue("PASSWORD").ToString();
                string sorgu = $@"Data Source={txservername.Text};uid={txkullnciad.Text};pwd={txsfre.Text};Connect Timeout=10;";
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = sorgu;
                    connection.Open();

                    if (connection.State == ConnectionState.Broken)
                    {
                        XtraMessageBox.Show("Kayıtlı Bağlantı Bilgileri Yanlıştır !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    lbl_veritabaniAdi.Visible = true;
                    lk_databaseListesi.Visible = true;
                    btn_kaydet.Visible = true;
                    List<DATABASE_LISTESI> databaseListesi = new List<DATABASE_LISTESI>();
                    string sql = $@"SELECT * FROM sys.databases WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb') ";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            DATABASE_LISTESI yeni = new DATABASE_LISTESI();
                            yeni.name = ds.Tables[0].Rows[i]["name"].ToString();
                            yeni.database_id = ds.Tables[0].Rows[i]["database_id"].ToString();
                            databaseListesi.Add(yeni);
                        }
                    }

                    lk_databaseListesi.Properties.DisplayMember = "name";
                    lk_databaseListesi.Properties.ValueMember = "name";
                    lk_databaseListesi.Properties.DataSource = databaseListesi;
                }
                lk_databaseListesi.EditValue = rk.GetValue("DBNAME").ToString();
                btn_lisansGirisi.Visible = true;

            }
            else
            {
                btn_kaydet.Visible = false;
                btn_lisansGirisi.Visible = false;
            }
        }

        private void btn_lisansGirisi_Click(object sender, EventArgs e)
        {
            frmLisanslar frm = new frmLisanslar();
            frm.ShowDialog();
        }

        private void btn_baglantiKontrol_Click(object sender, EventArgs e)
        {
            string sorgu = $@"Data Source={txservername.Text};uid={txkullnciad.Text};pwd={txsfre.Text};Connect Timeout=10;";
            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = sorgu;
                    connection.Open();

                    if (connection.State == ConnectionState.Broken)
                    {
                        XtraMessageBox.Show("Bağlantı Bilgileri Yanlıştır !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    XtraMessageBox.Show("Bağlantı Başarılı !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lbl_veritabaniAdi.Visible = true;
                    lk_databaseListesi.Visible = true;
                    btn_kaydet.Visible = true;
                    List<DATABASE_LISTESI> databaseListesi = new List<DATABASE_LISTESI>();
                    string sql = $@"SELECT * FROM sys.databases WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb') ";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            DATABASE_LISTESI yeni = new DATABASE_LISTESI();
                            yeni.name = ds.Tables[0].Rows[i]["name"].ToString();
                            yeni.database_id = ds.Tables[0].Rows[i]["database_id"].ToString();
                            databaseListesi.Add(yeni);
                        }
                    }

                    lk_databaseListesi.Properties.DisplayMember = "name";
                    lk_databaseListesi.Properties.ValueMember = "name";
                    lk_databaseListesi.Properties.DataSource = databaseListesi;
                }
            }
            catch (Exception sa)
            {
                XtraMessageBox.Show("Bağlantı Bilgileri Yanlıştır !");
                return;
            }
        }
    }
}