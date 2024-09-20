using DevExpress.XtraEditors;
using LOGO_XERO.Models;
using LOGO_XERO.Models.LOGO_XERO_M;
using System;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LOGO_XERO.Moduller.GenelListeler
{
    public partial class frmTeklifGorusmeler : DevExpress.XtraEditors.XtraForm
    {
        frmAnaForm ana;
        frmTeklifOlustur _frmTeklifOlustur;
        public int gorusmeid = 0;
        public frmTeklifGorusmeler(frmTeklifOlustur frmTeklifOlustur)
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            _frmTeklifOlustur = frmTeklifOlustur;
            if (gorusmeid == 0)
            {
                btn_Kaydet.Text = "[F2] Kaydet";
            }
            else
            {
                btn_Kaydet.Text = "[F2] Güncelle";
            }
        }

        private void frmTeklifGorusmeler_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btn_Vazgec_Click(sender, e);
            } 
            if (e.KeyCode == Keys.F2)
            {
                btn_Kaydet_Click(sender, e);
            }
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAciklama.Text))
            {
                if (gorusmeid == 0)
                {
                    using (LogoContext db = new LogoContext())
                    {
                        LOGO_XERO_GORUSMELER gorus = new LOGO_XERO_GORUSMELER();
                        gorus.ACIKLAMA = txtAciklama.Text;
                        gorus.TIP = 1;
                        gorus.PERSONEL = ana._Kullanici.KULLANICIADI;
                        gorus.PERSONELID = ana._Kullanici.ID;
                        gorus.TARIH = DateTime.Now;
                        gorus.TEKLIFID = Convert.ToInt32(txtTeklifId.Text);
                        db.LOGO_XERO_GORUSMELER.Add(gorus);
                        db.SaveChanges();
                        this.Close();
                        _frmTeklifOlustur.Gorusmeler();
                    }
                }
                else // düzenle
                {
                    using (LogoContext db = new LogoContext())
                    {
                        LOGO_XERO_GORUSMELER gorus = new LOGO_XERO_GORUSMELER();
                        gorus.ACIKLAMA = txtAciklama.Text;
                        gorus.ID = gorusmeid;
                        db.LOGO_XERO_GORUSMELER.AddOrUpdate(gorus);
                        db.SaveChanges();
                    }

                    _frmTeklifOlustur.Gorusmeler();

                }

            }
            else { XtraMessageBox.Show("Görüşme Metni Boş Kaydedilemez !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
        }

        private void btn_Vazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}