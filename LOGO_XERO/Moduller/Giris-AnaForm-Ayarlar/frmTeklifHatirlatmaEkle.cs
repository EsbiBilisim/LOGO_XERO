using DevExpress.XtraEditors;
using LOGO_XERO.Models;
using LOGO_XERO.Models.LOGO_XERO_M;
using LOGO_XERO.Moduller._7_Raporlar;
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

namespace LOGO_XERO.Moduller.Giris_AnaForm_Ayarlar
{
    public partial class frmTeklifHatirlatmaEkle : DevExpress.XtraEditors.XtraForm
    {
        frmAnaForm ana;
        frmHatirlatmaListele list;
        public int id;
        public frmTeklifOlustur teklif;
        public int tip = 0;
        public frmTeklifHatirlatmaEkle(int _tip,frmTeklifOlustur tklf = null)
        {
            InitializeComponent();
            tip = _tip;
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;       
            list = Application.OpenForms["frmHatirlatmaListele"] as frmHatirlatmaListele;
            teklif = tklf;
            dttarih.DateTime = DateTime.Now;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(memoEdit1.Text) && dttarih.DateTime != DateTime.MinValue)
            {
                if (id == 0)
                {
                    Kaydet();
                }
                else
                {
                    Guncelle();
                }
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Tarih Ve Hatırlatma Notu Kısmı Boş Kaydedilemez ! ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
           
            
        }

        public void Doldur() 
        {
            using (LogoContext db = new LogoContext())
            {
                LOGO_XERO_HATIRLATMA htrlt = db.LOGO_XERO_HATIRLATMA.Where(s => s.ID == id).FirstOrDefault();
                if (htrlt != null)
                {
                    txtTeklifBaslik.Text = htrlt.TEKLIFNO;
                    dttarih.DateTime = htrlt.HATIRLATMATARIHI;
                    memoEdit1.Text = htrlt.ACIKLAMA; 
                }
            }
        }
        public void Guncelle() {
            try
            {
                using (LogoContext db = new LogoContext())
                {
                    LOGO_XERO_HATIRLATMA yeni = new LOGO_XERO_HATIRLATMA();
                    yeni.ID = id;
                    yeni.PERSONEL = ana._Kullanici.KULLANICIADI;
                    yeni.HATIRLATMATARIHI = dttarih.DateTime;
                    yeni.TARIH = DateTime.Now;
                    yeni.TEKLIFNO = txtTeklifBaslik.Text;
                    yeni.ACIKLAMA = memoEdit1.Text;
                    yeni.OKUNDU = false;
                    yeni.TIP = tip;
                    if (teklif != null)
                    {
                        yeni.TEKLIFID = teklif.Teklifid;
                    } 
                    db.LOGO_XERO_HATIRLATMA.AddOrUpdate(yeni);
                    db.SaveChanges();
                }
                XtraMessageBox.Show("Kayıt Başarılıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Hata : " + ex);
            }
        }
        public void Kaydet() 
        {
            try
            {
                using (LogoContext db = new LogoContext())
                {
                    LOGO_XERO_HATIRLATMA yeni = new LOGO_XERO_HATIRLATMA();
                    yeni.PERSONEL = ana._Kullanici.KULLANICIADI;
                    yeni.HATIRLATMATARIHI = dttarih.DateTime;
                    yeni.TARIH = DateTime.Now;
                    yeni.TEKLIFNO = txtTeklifBaslik.Text;
                    yeni.ACIKLAMA = memoEdit1.Text;
                    yeni.OKUNDU = false;
                    yeni.TIP = tip;
                    yeni.TEKLIFID = teklif.Teklifid;
                    db.LOGO_XERO_HATIRLATMA.Add(yeni);
                    db.SaveChanges();
                }
                XtraMessageBox.Show("Kayıt Başarılıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Hata : " + ex);
            }
        }

        private void frmTeklifHatirlatmaEkle_Load(object sender, EventArgs e)
        {
            if (id != 0)
            {
                Doldur();
            }
        }

        private void frmTeklifHatirlatmaEkle_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (list != null)
            {
                list.Listele();
            }
            if (teklif != null)
            {
                teklif.HatirlatmalariGetir(teklif.Teklifid);
            }
        }

        private void frmTeklifHatirlatmaEkle_KeyDown(object sender, KeyEventArgs e)
        { 
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.F2)
            {
                simpleButton1_Click(sender, e);
            }
        }
    }
}