using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using System;
using System.Windows.Forms;

namespace LOGO_XERO.Moduller._1_TeklifModul
{
    public partial class frmSiparisListesi : DevExpress.XtraEditors.XtraForm
    {
        frmAnaForm ana;
        public int tip = 0; 
        Logic.GenelListeler listeler = new Logic.GenelListeler();
        Islemler islem = new Islemler();
        public frmSiparisListesi()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            islem.IsyeriListesiDoldur(rpİsyeri, ana.lk_firma.EditValue.ToString());
            islem.DovizBilgileriDoldur(rpDoviz,ana.lk_firma.EditValue.ToString());
            islem.BolumListesiDoldur(rpBolum, ana.lk_firma.EditValue.ToString());
            AmbarListesiDoldur();
            GruplariDoldur();
            islem.OdemeTipleriDoldur(rpOdemeTipi,ana.lk_firma.EditValue.ToString());
            islem.IsyeriListesiDoldur(ck_isyeri, ana.lk_firma.EditValue.ToString());
            ck_isyeri.CheckAll();
            txtIlk.DateTime = DateTime.Now.AddDays(Convert.ToDouble(-ana.parametre.M_GNL_LISTELERIN_GUNFARKI));
            txtSon.DateTime = DateTime.Now; 
        } 
        public void AmbarListesiDoldur()
        {
            rpAmbar.DataSource = islem.TumAmbarListesi(ana.lk_firma.EditValue.ToString());
            rpAmbar.DisplayMember = "NAME";
            rpAmbar.ValueMember = "NR";
        }
        public void GruplariDoldur() 
        {
            rpGrupAciklama.DataSource =  islem.TicariIslemGruplariGetir();
            rpGrupAciklama.DisplayMember = "GDEF";
            rpGrupAciklama.ValueMember = "LOGICALREF";

        }
        private void frmSiparisListesi_Load(object sender, EventArgs e)
        {
            ListeYenile();
            if (tip == 1)
            {
                this.Text = "Satış Siparişleri";
                gridSiparisListesi.RefreshDataSource();
                gridSiparisListesi.Refresh();
                islem.TasarimGetir(gv_SiparisListesi, ana._Kullanici.ID, this.Name, gridSiparisListesi.Name+"Satis");
            }
            else if (tip == 2)
            {
                this.Text = "Alış Siparişleri"; 
                gridSiparisListesi.RefreshDataSource();
                gridSiparisListesi.Refresh();
                islem.TasarimGetir(gv_SiparisListesi, ana._Kullanici.ID, this.Name, gridSiparisListesi.Name+"Alis");
            }
        }
         

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            ListeYenile();
        }

        private void tasarımKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tip == 1) // Satış
            {
                islem.TasarimKaydet(gv_SiparisListesi,ana._Kullanici.ID,this.Name,gridSiparisListesi.Name+"Satis");
                XtraMessageBox.Show("TASARIM KAYIT BAŞARILI !", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (tip == 2) // Alış
            {
                islem.TasarimKaydet(gv_SiparisListesi, ana._Kullanici.ID, this.Name, gridSiparisListesi.Name + "Alis");
                XtraMessageBox.Show("TASARIM KAYIT BAŞARILI !", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                XtraMessageBox.Show("TİP HATASI !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        public void ListeYenile() {
            string secilenIsyeri = "";
            if (ck_isyeri.EditValue == null || string.IsNullOrWhiteSpace(ck_isyeri.EditValue.ToString()))
            {
                secilenIsyeri = "";
            }
            else
            {
                secilenIsyeri = $@"and ORF.BRANCH IN ({ck_isyeri.EditValue.ToString()})";
            }
            gridSiparisListesi.DataSource = listeler.SiparisGetir(ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString(), " ", txtIlk.DateTime.ToString("yyyy-MM-dd 00:00:00"), txtSon.DateTime.ToString("yyyy-MM-dd 23:59:59"), secilenIsyeri, tip);
            gridSiparisListesi.RefreshDataSource();
            gridSiparisListesi.Refresh();
        }

        private void frmSiparisListesi_KeyDown(object sender, KeyEventArgs e)
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
            gridSiparisListesi.ShowPrintPreview();
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ana.demomu == 1)
            {
                ekleToolStripMenuItem.Enabled = false;
                duzenleToolStripMenuItem.Enabled = false;
            }
            else
            {
                ekleToolStripMenuItem.Enabled = true;
                duzenleToolStripMenuItem.Enabled = true;
            }
        }
    }
}