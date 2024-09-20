using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGO_XERO.Moduller._1_TeklifModul
{
    public partial class frmFaturaListesi : DevExpress.XtraEditors.XtraForm
    {

        frmAnaForm ana;
        public int tip = 0;
        Logic.GenelListeler listeler = new Logic.GenelListeler();
        Islemler islem = new Islemler();
        public frmFaturaListesi()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;

            islem.IsyeriListesiDoldur(rpİsyeri, ana.lk_firma.EditValue.ToString());
            islem.IsyeriListesiDoldur(ck_isyeri, ana.lk_firma.EditValue.ToString());
            islem.BolumListesiDoldur(rpBolum, ana.lk_firma.EditValue.ToString());
            islem.TumAmbarListesiDoldur(rpAmbar, ana.lk_firma.EditValue.ToString());
            islem.LogoSatisElemaniDoldurDinamikRef(rpKullanicilar, ana.lk_firma.EditValue.ToString());
            txtIlk.DateTime = DateTime.Now.AddDays(Convert.ToDouble(-ana.parametre.M_GNL_LISTELERIN_GUNFARKI));
            txtSon.DateTime = DateTime.Now;

            ck_isyeri.CheckAll();
            cm_secim.SelectedIndex = 0;
        }
        private void frmTeklifListesi_Load(object sender, EventArgs e)
        {
            if (tip == 8)
            {
                this.Text = "Satış Faturaları";
                islem.TasarimGetir(gv_FaturaListesi, ana._Kullanici.ID, this.Name, gridFaturaListesi.Name + "Satis");

            }
            else if (tip == 1)
            {
                this.Text = "Alış Faturaları";
                islem.TasarimGetir(gv_FaturaListesi, ana._Kullanici.ID, this.Name, gridFaturaListesi.Name + "Alis");

            }

            ListeYenile();
        }

        public void ListeYenile()
        {
            string secilenIsyeri = "";
            if (ck_isyeri.EditValue == null || string.IsNullOrWhiteSpace(ck_isyeri.EditValue.ToString()))
            {
                secilenIsyeri = "";
            }
            else
            {
                secilenIsyeri = $@"and O.BRANCH IN ({ck_isyeri.EditValue.ToString()})";
            }
            string trkodgidecek = "";
            string trkodalis = "1,4,5,6,13,26";
            string trkodsatis = "2,3,7,8,9,10,14";

            int aktifdurumu = 0;
            if (tip == 8)
            {
                trkodgidecek = trkodsatis;
                if (cm_secim.SelectedIndex == 1)
                {
                    aktifdurumu = 1;
                }
                else if (cm_secim.SelectedIndex == 2)
                {
                    trkodgidecek = "2,3";
                }
            }
            else
            {
                trkodgidecek = trkodalis;
                if (cm_secim.SelectedIndex == 1)
                {
                    aktifdurumu = 1;
                }
                else if (cm_secim.SelectedIndex == 2)
                {
                    trkodgidecek = "6";
                }
            }
            gridFaturaListesi.DataSource = listeler.FaturaGetir(ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString(), trkodgidecek, txtIlk.DateTime.ToString("yyyy-MM-dd 00:00:00"), txtSon.DateTime.ToString("yyyy-MM-dd 23:59:59"), aktifdurumu, secilenIsyeri);
            gridFaturaListesi.RefreshDataSource();
            gridFaturaListesi.Refresh();

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (ana.demomu == 1)
            {
                if (tip == 1)
                {
                    SatisFatrEkleToolStripMenuItem.Visible = false;
                    AlisFatrEkleToolStripMenuItem.Visible = true;
                    AlisFatrEkleToolStripMenuItem.Enabled = false;
                }
                if (tip == 8)
                {
                    SatisFatrEkleToolStripMenuItem.Visible = true;
                    AlisFatrEkleToolStripMenuItem.Visible = false;
                    SatisFatrEkleToolStripMenuItem.Enabled = false;
                }

                düzenleToolStripMenuItem.Enabled = false;
            }
            else
            {
                if (tip == 1)
                {
                    SatisFatrEkleToolStripMenuItem.Visible = false;
                    AlisFatrEkleToolStripMenuItem.Visible = true;
                    AlisFatrEkleToolStripMenuItem.Enabled = true;
                }
                if (tip == 8)
                {
                    SatisFatrEkleToolStripMenuItem.Visible = true;
                    AlisFatrEkleToolStripMenuItem.Visible = false;
                    SatisFatrEkleToolStripMenuItem.Enabled = true;
                }
               
                düzenleToolStripMenuItem.Enabled = true;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            ListeYenile();
        }

        private void tToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tip == 1) // Alis
            {
                islem.TasarimKaydet(gv_FaturaListesi, ana._Kullanici.ID, this.Name, gridFaturaListesi.Name + "Alis");
                XtraMessageBox.Show("TASARIM KAYIT BAŞARILI !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (tip == 8) // Satis
            {
                islem.TasarimKaydet(gv_FaturaListesi, ana._Kullanici.ID, this.Name, gridFaturaListesi.Name + "Satis");
                XtraMessageBox.Show("TASARIM KAYIT BAŞARILI !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                XtraMessageBox.Show("TİP HATASI !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void frmFaturaListesi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                ListeYenile();
            }
            if (e.KeyCode == Keys.Escape)
            {
                simpleButton4_Click(sender, e);
            }
            if (e.KeyCode == Keys.F4)
            {
                simpleButton2_Click(sender, e);
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            gridFaturaListesi.ShowPrintPreview();
        }
    }
}