using DevExpress.XtraEditors;
using LOGO_XERO.Models;
using LOGO_XERO.Models.GenelKullanim;
using LOGO_XERO.Models.LOGO_XERO_M;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGO_XERO.Moduller.GenelListeler
{
    public partial class frmCariKoduAmbarParametreleri : DevExpress.XtraEditors.XtraForm
    {
        frmAnaForm ana;
        int firma = 0;
        public frmCariKoduAmbarParametreleri()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            firma = Convert.ToInt32(ana.lk_firma.EditValue);
        }

        private void btn_ambarsec_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmAmbarlar frm = new frmAmbarlar(this);
            frm.ShowDialog();
        }

        public void ListeGetir()
        {
            using (LogoContext db = new LogoContext())
            {
                string sql = $@"select CK.*,CP.NAME AMBARADI from LOGO_XERO_AMBARA_BAGLI_CARI_KOD CK
                LEFT OUTER JOIN L_CAPIWHOUSE CP ON CK.AMBARNO=CP.NR AND CP.FIRMNR={firma} WHERE CK.FIRMANO={firma}";
                List<AMBARA_BAGLI_CARI_KOD_W> liste = db.Database.SqlQuery<AMBARA_BAGLI_CARI_KOD_W>(sql).ToList();
                gridControl1.DataSource = liste;
            }
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(btn_ambarsec.Text))
            {
                XtraMessageBox.Show($"Ambar Boş Olamaz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btn_ambarsec.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txt_onek.Text))
            {
                XtraMessageBox.Show($"Cari Kodu Ön Eki Boş Bırakılamaz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_onek.Focus();
                return;
            }
            try
            {
                using (LogoContext db = new LogoContext())
                {
                    int ambarno = Convert.ToInt32(btn_ambarsec.Text);
                    LOGO_XERO_AMBARA_BAGLI_CARI_KOD varmi = db.LOGO_XERO_AMBARA_BAGLI_CARI_KOD.Where(s => s.AMBARNO == ambarno && s.FIRMANO==firma).FirstOrDefault();
                    if (varmi == null)
                    {
                        LOGO_XERO_AMBARA_BAGLI_CARI_KOD yeni = new LOGO_XERO_AMBARA_BAGLI_CARI_KOD();
                        yeni.AMBARNO = Convert.ToInt32(btn_ambarsec.Text);
                        yeni.FIRMANO = Convert.ToInt32(firma);
                        yeni.SERIBASLANGIC = txt_onek.Text;
                        db.LOGO_XERO_AMBARA_BAGLI_CARI_KOD.Add(yeni);
                        db.SaveChanges();
                    }
                    else
                    {
                        varmi.SERIBASLANGIC = txt_onek.Text;
                        db.Entry(varmi).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    XtraMessageBox.Show($"İşlem Başarılı !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_ambarsec.Text = "";
                    txtAmbarAdi.Text = "";
                    txt_onek.Text = "";
                    ListeGetir();
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show($"İŞLEM BAŞARISIZ !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AMBARA_BAGLI_CARI_KOD_W row = (AMBARA_BAGLI_CARI_KOD_W)gridView1.GetFocusedRow();
            if (row != null)
            {
                btn_ambarsec.Text = row.AMBARNO.ToString();
                txtAmbarAdi.Text = row.AMBARADI;
                txt_onek.Text = row.SERIBASLANGIC;
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = XtraMessageBox.Show("Kayıt Silinecektir ! Emin Misiniz ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {

                    using (LogoContext db = new LogoContext())
                    {
                        AMBARA_BAGLI_CARI_KOD_W row = (AMBARA_BAGLI_CARI_KOD_W)gridView1.GetFocusedRow();
                        if (row != null)
                        {
                            LOGO_XERO_AMBARA_BAGLI_CARI_KOD varmi = db.LOGO_XERO_AMBARA_BAGLI_CARI_KOD.Where(s => s.ID == row.ID && s.FIRMANO==firma).FirstOrDefault();
                            if (varmi != null)
                            {
                                db.LOGO_XERO_AMBARA_BAGLI_CARI_KOD.Remove(varmi);
                                db.SaveChanges();
                            }
                        }
                    }
                    ListeGetir();
                }
                else
                {
                }
                XtraMessageBox.Show($"İşlem Başarılı !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                XtraMessageBox.Show($"İŞLEM BAŞARISIZ !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCariKoduAmbarParametreleri_Load(object sender, EventArgs e)
        {
            ListeGetir();
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            btn_ambarsec.Text = "";
            txtAmbarAdi.Text = "";
            txt_onek.Text = "";
        }
    }
}