using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
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
using System.Windows.Forms;
using static LOGO_XERO.Moduller.Personeller.frmKullaniciEkle;

namespace LOGO_XERO.Moduller.Giris_AnaForm_Ayarlar
{
    public partial class frmKullaniciListesi : DevExpress.XtraEditors.XtraForm
    {
        SQLConnection clas = new SQLConnection();
        string firma, donem;
        IlkTabloIslemler isl = new IlkTabloIslemler();
        public frmKullaniciListesi()
        {
            InitializeComponent();
        }

        private void frmKullaniciListesi_Load(object sender, EventArgs e)
        {
          
            frmAnaForm ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            firma = ana.lk_firma.EditValue.ToString();
            donem = ana.lk_donem.EditValue.ToString();
            lkeditleridoldur();
            kullanicilarilistele();
           
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            int  kullaniciid = (int)gv_Kullanici.GetFocusedRowCellValue("ID");
            string kullaniciadi = (string)gv_Kullanici.GetFocusedRowCellValue("KULLANICIADI");
            if (MessageBox.Show(kullaniciadi + " İsimli Kullanıcı Silmek İstiyor Musunuz?", "ID :" + kullaniciid, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                KullaniciSil();
                kullanicilarilistele();
            }
        }
        public void KullaniciSil()
        {
            try
            {
               int kullaniciid = (int)gv_Kullanici.GetFocusedRowCellValue("ID");
                clas.Connect();
                string sqlParametre = $@"DELETE FROM [dbo].[LOGO_XERO_KULLANICILAR]
            WHERE  ID = {kullaniciid}";
                SqlCommand cmd = new SqlCommand(sqlParametre, clas.Conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
            catch (Exception EX)
            {
                MessageBox.Show("Hata:" + EX);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            frmKullaniciEkle frm = new frmKullaniciEkle();
            frm.ShowDialog();
            kullanicilarilistele();
        }

        private void frmKullaniciListesi_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F2)
            {
                simpleButton3_Click(sender, e);
            }
            if (e.KeyCode == Keys.F10)
            {
                simpleButton4_Click(sender, e);
            }
            if (e.KeyCode == Keys.F1)
            {
                simpleButton1_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                simpleButton2_Click(sender, e);
            }
            if (e.KeyCode == Keys.F5)
            {
                simpleButton5_Click(sender, e);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            kullanicilarilistele();
        }

        private void kullanıcıyıDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int kullaniciid = (int)gv_Kullanici.GetFocusedRowCellValue("ID");
            string kullaniciadi = (string)gv_Kullanici.GetFocusedRowCellValue("KULLANICIADI");
            frmKullaniciEkle frm = new frmKullaniciEkle(kullaniciid);
            frm.ShowDialog();
        }

        public void kullanicilarilistele()
        {
            clas.Connect();
            clas.Conn.Open();
            string sqlParametre = $@"SELECT G.GOREVTANIMI,K.* FROM LOGO_XERO_KULLANICILAR K LEFT OUTER JOIN LOGO_XERO_GOREVLER G ON K.GOREV = G.ID where K.TANIMLIFIRMA ={firma} and K.TANIMLIDONEM = {donem}";
            SqlCommand cmd = new SqlCommand(sqlParametre, clas.Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridctrlKullanici.DataSource = ds.Tables[0];
            gridctrlKullanici.RefreshDataSource();
            gridctrlKullanici.Refresh();
            clas.Conn.Close();
        }

        private void yeniKullanıcıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKullaniciEkle frm = new frmKullaniciEkle();
            frm.ShowDialog();
            kullanicilarilistele();
        }

        private void kullanıcıyıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int kullaniciid = (int)gv_Kullanici.GetFocusedRowCellValue("ID");
            string kullaniciadi = (string)gv_Kullanici.GetFocusedRowCellValue("KULLANICIADI");
            if (MessageBox.Show(kullaniciadi + " İsimli Kullanıcı Silmek İstiyor Musunuz?", "ID :" + kullaniciid, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                KullaniciSil();
                kullanicilarilistele();
            }
        }

        public void lkeditleridoldur() 
        {
            isl.ambarsorgudondur(firma,LKAMBAR,LKISYERI);
            isl.bolumsorgudondur(firma,LKBOLUM);
            isl.fabrikasorgudondur(firma,LKFABRIKA);
            isl.isyerisorgudondur(firma,LKISYERI);
            isl.logosatiselemanisorgudondur(LKLOGOSATISELEMANI);
            isl.gorevsorgudondur(LKGOREV);
        }
    }
}