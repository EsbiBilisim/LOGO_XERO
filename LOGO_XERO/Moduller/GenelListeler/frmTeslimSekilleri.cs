using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using LOGO_XERO.Models.LOGO_M;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGO_XERO.Moduller.GenelListeler
{
    public partial class frmTeslimSekilleri : DevExpress.XtraEditors.XtraForm
    {
        frmTeklifOlustur _frmTeklifOlustur;
        Islemler islem = new Islemler();
        public frmTeslimSekilleri(frmTeklifOlustur frmTeklifOlustur)
        {
            InitializeComponent();
            _frmTeklifOlustur = frmTeklifOlustur;
        }
        private void frmTeslimSekilleri_Load(object sender, EventArgs e)
        {
            ListeGetir();
        }
        void ListeGetir()
        {
            grid_TeslimSekli.DataSource = islem.TeslimSekliListesi();
        }
        private void grid_TeslimSekli_DoubleClick(object sender, EventArgs e)
        {
            L_SHPTYPES teslim = (L_SHPTYPES)gv_TeslimSekli.GetFocusedRow();
            if (teslim != null)
            {
                if (_frmTeklifOlustur != null)
                {
                    _frmTeklifOlustur.btn_TeslimSekliKodu.Text = teslim.SCODE;
                    _frmTeklifOlustur.btn_TeslimSekliAciklamasi.Text = teslim.SDEF;
                    Close();
                }
            }
        }
        int id = 0;
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_aciklama.Text) || string.IsNullOrWhiteSpace(txt_kodu.Text))
            {
                XtraMessageBox.Show("Kod veya Açıklama Kısmı Boş Bırakılamaz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                    

                using (LogoContext db = new LogoContext())
                {
                    var varmi = db.L_SHPTYPES.Where(s => s.SCODE == txt_kodu.Text).FirstOrDefault();
                    if (varmi == null)
                    {
                        L_SHPTYPES sekil = new L_SHPTYPES();
                        sekil.LOGICALREF = id;
                        sekil.PRICELEVEL = 1;
                        sekil.SCODE = txt_kodu.Text;
                        sekil.SDEF = txt_aciklama.Text;
                        db.L_SHPTYPES.AddOrUpdate(sekil);
                        db.SaveChanges();
                        txt_aciklama.Text = "";
                        txt_kodu.Text = "";
                        ListeGetir();
                    }
                    else
                    {
                        XtraMessageBox.Show("Aynı Koda Ait Teslim Şekli Bulunmakta", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    
                }
            } 
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            L_SHPTYPES satir = (L_SHPTYPES) gv_TeslimSekli.GetFocusedRow();
            if (satir != null)
            {
                id = satir.LOGICALREF;
                txt_kodu.Text = satir.SCODE;
                txt_aciklama.Text = satir.SDEF;
            } 
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            id = 0;
            txt_kodu.Text = "";
            txt_aciklama.Text = "";
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            L_SHPTYPES satir = (L_SHPTYPES)gv_TeslimSekli.GetFocusedRow();
            if (satir != null)
            {
                if (XtraMessageBox.Show("Seçilen Teslim Şekli Silinecektir Onaylıyor Musunuz ?", satir.SCODE, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (LogoContext db = new LogoContext())
                    {
                        L_SHPTYPES satir1 = db.L_SHPTYPES.Where(s => s.LOGICALREF == satir.LOGICALREF).FirstOrDefault();
                        db.L_SHPTYPES.Remove(satir1);
                        db.SaveChanges();
                    }
                    ListeGetir();
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTeslimSekilleri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                simpleButton1_Click(sender, e);
            }
        }
    }
}