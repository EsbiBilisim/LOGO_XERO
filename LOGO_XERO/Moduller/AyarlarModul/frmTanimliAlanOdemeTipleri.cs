using DevExpress.XtraEditors;
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

namespace LOGO_XERO.Moduller.GenelListeler
{
    public partial class frmTanimliAlanOdemeTipleri : DevExpress.XtraEditors.XtraForm
    {
        int id = 0;
        public frmTanimliAlanOdemeTipleri()
        {
            InitializeComponent();
        }
        private void frmTanimliAlanOdemeTipleri_Load(object sender, EventArgs e)
        {
            GetList();
        }
        public void GetList()
        {
            using (LogoContext db = new LogoContext())
            {
                grid_TanimlialanOdemeTipleri.DataSource = db.LG_CATEGLISTS.OrderBy(s => s.TAG).Where(s => s.RECORDID == 4 && s.CATEGID == 10450).ToList();
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void grid_TanimlialanOdemeTipleri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LG_CATEGLISTS ROW = (LG_CATEGLISTS)gridView1.GetFocusedRow();
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
                        LG_CATEGLISTS yeni = new LG_CATEGLISTS();

                        int logicalref = db.LG_CATEGLISTS
                            .Where(s => s.TAG == ROW.TAG && s.LINENO_ == ROW.LINENO_ && s.RECORDID == 4 && s.CATEGID == 10450)
                            .Select(s => s.LOGICALREF)
                            .SingleOrDefault();
                        if (logicalref != 0)
                        {
                            yeni.LOGICALREF = logicalref;
                            db.Entry(yeni).State = System.Data.Entity.EntityState.Deleted;
                            db.SaveChanges();
                        }
                        LG_CATEGLISTS yeni2 = new LG_CATEGLISTS();
                        int logicalref2 = db.LG_CATEGLISTS
                            .Where(s => s.TAG == ROW.TAG && s.LINENO_ == ROW.LINENO_ && s.RECORDID == 8 && s.CATEGID == 10850)
                            .Select(s => s.LOGICALREF)
                            .SingleOrDefault();
                        if (logicalref2 != 0)
                        {
                            yeni2.LOGICALREF = logicalref2;
                            db.Entry(yeni2).State = System.Data.Entity.EntityState.Deleted;
                            db.SaveChanges();
                        }

                        LG_CATEGLISTS yeni3 = new LG_CATEGLISTS();
                        int logicalref3 = db.LG_CATEGLISTS
                            .Where(s => s.TAG == ROW.TAG && s.LINENO_ == ROW.LINENO_ && s.RECORDID == 9 && s.CATEGID == 10950)
                            .Select(s => s.LOGICALREF)
                            .SingleOrDefault();
                        if (logicalref3 != 0)
                        {
                            yeni3.LOGICALREF = logicalref3;
                            db.Entry(yeni3).State = System.Data.Entity.EntityState.Deleted;
                            db.SaveChanges();
                        }
                    }
                    GetList();
                }
            }
        }
        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LG_CATEGLISTS ROW = (LG_CATEGLISTS)gridView1.GetFocusedRow();
            if (ROW != null)
            {
                txt_Numara.Text = ROW.TAG.ToString();
                txt_tanimi.Text = ROW.CATDESC;
                id = ROW.LOGICALREF;
                btn_kaydet.Text = "Güncelle";
            }
        }
        private void btn_temizle_Click(object sender, EventArgs e)
        {
            id = 0;
            txt_Numara.Text = "0";
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
            if (string.IsNullOrWhiteSpace(txt_Numara.Text))
            {
                XtraMessageBox.Show("Numara Girmeden Kayıt Ekleyemezsiniz !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Numara.Focus();
                return;
            }
            using (LogoContext db = new LogoContext())
            {
                try
                {
                    if (id == 0)
                    {
                        int sirano = Convert.ToInt16(txt_Numara.Text);
                        var varmi = db.LG_CATEGLISTS.Where(s => s.CATEGID == 10450 && s.TAG == sirano).FirstOrDefault();
                        if (varmi != null)
                        {
                            XtraMessageBox.Show("Aynı Numaralı Bir Alan Daha Var. Kayıt Ekleyemezsiniz !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txt_Numara.Focus();
                            return;
                        }
                        LG_CATEGLISTS yeni = new LG_CATEGLISTS();
                        yeni.CATEGID = 10450;
                        yeni.LINENO_ = Convert.ToInt16(txt_Numara.Text);
                        yeni.TAG = Convert.ToInt32(txt_Numara.Text);
                        yeni.CATDESC = txt_tanimi.Text;
                        yeni.CUSTOM = 1;
                        yeni.RECORDID = 4;
                        db.LG_CATEGLISTS.Add(yeni);
                        db.Entry(yeni).State = System.Data.Entity.EntityState.Added;
                        db.SaveChanges();
                        LG_CATEGLISTS yeni2 = new LG_CATEGLISTS();
                        yeni2.CATEGID = 10850;
                        yeni2.LINENO_ = Convert.ToInt16(txt_Numara.Text);
                        yeni2.TAG = Convert.ToInt32(txt_Numara.Text);
                        yeni2.CATDESC = txt_tanimi.Text;
                        yeni2.CUSTOM = 1;
                        yeni2.RECORDID = 8;
                        db.LG_CATEGLISTS.Add(yeni2);
                        db.Entry(yeni2).State = System.Data.Entity.EntityState.Added;
                        db.SaveChanges();
                        LG_CATEGLISTS yeni3 = new LG_CATEGLISTS();
                        yeni3.CATEGID = 10950;
                        yeni3.LINENO_ = Convert.ToInt16(txt_Numara.Text);
                        yeni3.TAG = Convert.ToInt32(txt_Numara.Text);
                        yeni3.CATDESC = txt_tanimi.Text;
                        yeni3.CUSTOM = 1;
                        yeni3.RECORDID = 9;
                        db.LG_CATEGLISTS.Add(yeni3);
                        db.Entry(yeni3).State = System.Data.Entity.EntityState.Added;
                        db.SaveChanges();

                    }
                    else
                    {
                        int sirano = Convert.ToInt16(txt_Numara.Text);
                        LG_CATEGLISTS varmi = db.LG_CATEGLISTS.Where(s => s.CATEGID == 10450 && s.TAG == sirano && s.LOGICALREF != id).FirstOrDefault();
                        if (varmi != null)
                        {
                            XtraMessageBox.Show("Aynı Numaralı Bir Alan Daha Var. Kayıt Ekleyemezsiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txt_Numara.Focus();
                            return;
                        }
                        LG_CATEGLISTS varolanKayit = db.LG_CATEGLISTS.Where(s => s.LOGICALREF == id).FirstOrDefault();
                        if (varolanKayit != null)
                        {
                            string sql = $@"UPDATE LG_CATEGLISTS SET CATDESC='{txt_tanimi.Text}' ,TAG={sirano},LINENO_={sirano} WHERE RECORDID=4 AND TAG={varolanKayit.TAG} AND CATEGID=10450 ;
                            UPDATE LG_CATEGLISTS SET CATDESC='{txt_tanimi.Text}' ,TAG={sirano},LINENO_={sirano} WHERE RECORDID=9 AND TAG={varolanKayit.TAG} AND CATEGID=10950 ;
                            UPDATE LG_CATEGLISTS SET CATDESC = '{txt_tanimi.Text}' ,TAG={sirano},LINENO_={sirano} WHERE RECORDID = 8 AND TAG = {varolanKayit.TAG} AND CATEGID = 10850; ";
                            db.Database.ExecuteSqlCommand(sql);
                        }
                    }
                    GetList();
                    XtraMessageBox.Show("Kayıt Tamamlandı !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    id = 0;
                    btn_kaydet.Text = "Ekle";
                    txt_Numara.Text = "";
                    txt_tanimi.Text = "";
                    txt_Numara.Focus();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("İşlem Başarısız ! HATA : " + ex.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}