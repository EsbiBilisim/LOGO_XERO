using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using LOGO_XERO.Models.LOGO_M;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGO_XERO.Moduller.Finans
{
    public partial class frmIstihbaratBilgileri : DevExpress.XtraEditors.XtraForm
    {
        int id = 0;
        public int cariref = 0;
        Islemler islem = new Islemler();
        public frmIstihbaratBilgileri()
        {
            InitializeComponent();
        }

        private void frmIstihbaratBilgileri_Load(object sender, EventArgs e)
        {
            GetList();
        }
        public void GetList()
        {
            grid_IstihbaratBilgileri.DataSource = islem.IstihbaratBilgileriGetir(cariref);
        }

        private void frmIstihbaratBilgileri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LG_CLINTEL ROW = (LG_CLINTEL)gridView1.GetFocusedRow();
            if (ROW != null)
            {
                DialogResult dr = XtraMessageBox.Show("Seçili Kayıt Silinecek ! Onaylıyor Musunuz ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                {
                    return;
                }
                else
                {

                    using (LogoContext db = new LogoContext())
                    {
                        LG_CLINTEL kay = db.LG_CLINTEL.Where(s => s.LOGICALREF == ROW.LOGICALREF).FirstOrDefault();
                        if (kay != null)
                        {
                            db.LG_CLINTEL.Remove(kay);
                            db.SaveChanges();
                        }
                    }
                    GetList();
                }
            }
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LG_CLINTEL ROW = (LG_CLINTEL)gridView1.GetFocusedRow();
            if (ROW != null)
            {
                txt_tanimi.Text = ROW.INTELLINE;
                id = ROW.LOGICALREF;
                btn_kaydet.Text = "Güncelle";
            }
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            id = 0;
            txt_tanimi.Text = "";
            btn_kaydet.Text = "Ekle";
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_tanimi.Text))
            {
                XtraMessageBox.Show("Açıklama Girmeden Kayıt Ekleyemezsiniz !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_tanimi.Focus();
                return;
            }
            using (LogoContext db = new LogoContext())
            {
                try
                {
                    if (id == 0)
                    {
                        LG_CLINTEL yeni = new LG_CLINTEL();
                        yeni.CLIENTREF = cariref;
                        yeni.LINENUM = 1;
                        yeni.INTELLINE = txt_tanimi.Text;
                        db.LG_CLINTEL.Add(yeni);
                        db.SaveChanges();
                    }
                    else
                    {
                        LG_CLINTEL varolanKayit = db.LG_CLINTEL.Where(s => s.LOGICALREF == id).FirstOrDefault();
                        if (varolanKayit != null)
                        {
                            varolanKayit.INTELLINE = txt_tanimi.Text;
                            db.Entry(varolanKayit);
                            db.SaveChanges();
                        }
                    }
                    GetList();
                    XtraMessageBox.Show("Kayıt Tamamlandı !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    id = 0;
                    btn_kaydet.Text = "Ekle";
                    txt_tanimi.Text = "";
                    txt_tanimi.Focus();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("İşlem Başarısız ! HATA : " + ex.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}