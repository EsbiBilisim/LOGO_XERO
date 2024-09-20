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

namespace LOGO_XERO.Moduller._7_Raporlar
{
    public partial class frmKarZararAnalizRenk : DevExpress.XtraEditors.XtraForm
    {
        Logic.GenelListeler listeler = new Logic.GenelListeler();
        LOGO_XERO_KAR_ZARAR_RENK liste;
        int tip;
        public frmKarZararAnalizRenk(int _tip)
        {
            InitializeComponent();
            tip = _tip;

           // listeler.RenkTablosuOlustur();

            cm_aralik.Items.Add("Arasında");
            cm_aralik.Items.Add("Daha Büyük");
            cm_aralik.Items.Add("Daha Küçük");
            cm_aralik.SelectedIndex = 0;

            Yenile();
        }
        public void Yenile()
        {

            grid_karzararrenk.DataSource = listeler.YeniRenkGetir(tip); 

        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            if (btn_kaydet.Text == "Kaydet")
            {
                double ilksayi = 0;
                double buyuksayi = 0;
                if (!string.IsNullOrWhiteSpace(txt_buyuksay.Text) && !string.IsNullOrWhiteSpace(txt_kucuksay.Text))
                {
                    if (txt_Simge.Text == "<")
                    {
                        buyuksayi = Convert.ToDouble(txt_buyuksay.Text);
                    }
                    else if (txt_Simge.Text == ">")
                    {
                        buyuksayi = Convert.ToDouble(txt_buyuksay.Text);
                    }
                    else
                    {
                        ilksayi = Convert.ToDouble(txt_kucuksay.Text);
                        buyuksayi = Convert.ToDouble(txt_buyuksay.Text);
                        if (ilksayi > buyuksayi)
                        {
                            MessageBox.Show("Aralığı doğru giriniz !");
                            txt_buyuksay.Focus();
                            return;
                        }
                    }
                    List<LOGO_XERO_KAR_ZARAR_RENK> renlerliste = listeler.YeniRenkGetir(tip);
                    if (cm_aralik.SelectedIndex == 0)
                    {
                        LOGO_XERO_KAR_ZARAR_RENK deg = renlerliste.Where(s => s.YUZDEBASLANGIC != "<" && s.YUZDEBASLANGIC != ">").ToList().
                           Where(s => (Convert.ToDouble(s.YUZDEBASLANGIC) <= ilksayi && Convert.ToDouble(s.YUZDEBITIS) >= ilksayi) || (Convert.ToDouble(s.YUZDEBASLANGIC) <= buyuksayi && Convert.ToDouble(s.YUZDEBITIS) >= buyuksayi)).FirstOrDefault();


                        if (deg != null)
                        {
                            MessageBox.Show("Oran Aralığı Kayıt Eklemek İçin uygun değildir. Listedeki oranlarınızı kontrol ediniz !");
                            return;
                        }
                    }
                    if (cm_aralik.SelectedIndex == 1)
                    {
                        LOGO_XERO_KAR_ZARAR_RENK deg = renlerliste.Where(s => (Convert.ToDouble(s.YUZDEBITIS) >= buyuksayi)).FirstOrDefault();

                        if (deg != null)
                        {
                            MessageBox.Show("Oran Aralığı Kayıt Eklemek İçin uygun değildir. Listedeki oranlarınızı kontrol ediniz !");
                            return;
                        }
                    }
                    if (cm_aralik.SelectedIndex == 2)
                    {
                        LOGO_XERO_KAR_ZARAR_RENK deg = renlerliste.Where(s => (Convert.ToDouble(s.YUZDEBITIS) <= buyuksayi)).FirstOrDefault();

                        if (deg != null)
                        {
                            MessageBox.Show("Oran Aralığı Kayıt Eklemek İçin uygun değildir. Listedeki oranlarınızı kontrol ediniz !");
                            return;
                        }
                    }

                    Color renk = color_sec.Color;
                    if (!string.IsNullOrWhiteSpace(renk.ToString()))
                    {
                        string kayitedilecekrenk = renk.R.ToString() + "," + renk.G.ToString() + "," + renk.B.ToString();
                        if (txt_kucuksay.Enabled == false)
                        {
                            listeler.yenirenkekle(txt_Simge.Text, kayitedilecekrenk, txt_buyuksay.Text,tip);

                        }
                        else
                        {
                            listeler.yenirenkekle(txt_kucuksay.Text, kayitedilecekrenk, txt_buyuksay.Text,tip);

                        }
                        MessageBox.Show("Kayıt Eklenmiştir");
                        txt_buyuksay.Text = "";
                        txt_kucuksay.Text = "";
                        Yenile();
                    }
                    else
                    {
                        MessageBox.Show("Renk Seçimi Yapınız !");
                    }
                }
                else
                {
                    MessageBox.Show("Yüzdelik Oran Girilmesi Zorunludur !");
                }
            }
            if (btn_kaydet.Text == "Güncelle")
            {
                if (!string.IsNullOrWhiteSpace(txt_buyuksay.Text) && !string.IsNullOrWhiteSpace(txt_kucuksay.Text))
                {
                    double ilksayi = 0;
                    double buyuksayi = 0;
                    if (txt_Simge.Text == "<")
                    {
                        buyuksayi = Convert.ToDouble(txt_buyuksay.Text);
                    }
                    else if (txt_Simge.Text == ">")
                    {
                        buyuksayi = Convert.ToDouble(txt_buyuksay.Text);
                    }
                    else
                    {
                        ilksayi = Convert.ToDouble(txt_kucuksay.Text);
                        buyuksayi = Convert.ToDouble(txt_buyuksay.Text);
                        if (ilksayi > buyuksayi)
                        {
                            MessageBox.Show("Aralığı doğru giriniz !");
                            txt_buyuksay.Focus();
                            return;
                        }
                    }
                    List<LOGO_XERO_KAR_ZARAR_RENK> renlerliste = listeler.YeniRenkGetir(tip);
                    if (cm_aralik.SelectedIndex == 0)
                    {
                        LOGO_XERO_KAR_ZARAR_RENK deg = renlerliste.Where(s => (Convert.ToDouble(s.YUZDEBASLANGIC) <= ilksayi && Convert.ToDouble(s.YUZDEBITIS) >= ilksayi) || (Convert.ToDouble(s.YUZDEBASLANGIC) <= buyuksayi && Convert.ToDouble(s.YUZDEBITIS) >= buyuksayi)).FirstOrDefault();
                        if (deg != null && deg.ID != Convert.ToInt32(lbl_renkid.Text))
                        {
                            MessageBox.Show("Oran Aralığı Kayıt Eklemek İçin uygun değildir. Listedeki oranlarınızı kontrol ediniz !");
                            return;
                        }
                    }
                    if (cm_aralik.SelectedIndex == 1)
                    {
                        LOGO_XERO_KAR_ZARAR_RENK deg = renlerliste.Where(s => (Convert.ToDouble(s.YUZDEBITIS) >= buyuksayi)).FirstOrDefault();

                        if (deg != null && deg.ID != Convert.ToInt32(lbl_renkid.Text))
                        {
                            MessageBox.Show("Oran Aralığı Kayıt Eklemek İçin uygun değildir. Listedeki oranlarınızı kontrol ediniz !");
                            return;
                        }
                    }
                    if (cm_aralik.SelectedIndex == 2)
                    {
                        LOGO_XERO_KAR_ZARAR_RENK deg = renlerliste.Where(s => (Convert.ToDouble(s.YUZDEBITIS) <= buyuksayi)).FirstOrDefault();

                        if (deg != null && deg.ID != Convert.ToInt32(lbl_renkid.Text))
                        {
                            MessageBox.Show("Oran Aralığı Kayıt Eklemek İçin uygun değildir. Listedeki oranlarınızı kontrol ediniz !");
                            return;
                        }
                    }
                    Color renk = color_sec.Color;
                    if (!string.IsNullOrWhiteSpace(renk.ToString()))
                    {
                        string yuzde = cm_oransec.Text;
                        string kayitedilecekrenk = renk.R.ToString() + "," + renk.G.ToString() + "," + renk.B.ToString();
                        listeler.seciliiyenirenkguncelle(Convert.ToInt32(lbl_renkid.Text), txt_kucuksay.Text, kayitedilecekrenk, txt_buyuksay.Text,tip);
                        MessageBox.Show("Kayıt Güncellenmiştir");
                        cm_aralik.SelectedIndex = 0;
                        btn_kaydet.Text = "Kaydet";
                        txt_buyuksay.Text = "";
                        txt_kucuksay.Text = "";
                        Yenile();
                    }
                    else
                    {
                        MessageBox.Show("Renk Seçimi Yapınız !");
                    }

                }
                else
                {
                    MessageBox.Show("Yüzdelik Oran Girilmesi Zorunludur !");
                }
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        { 
            LOGO_XERO_KAR_ZARAR_RENK row = (LOGO_XERO_KAR_ZARAR_RENK)gv_karzararrenk.GetFocusedRow();
            liste = listeler.secilirenkGetirYeni(row.ID); 
             
            txt_Simge.Text = liste.YUZDEBASLANGIC;

            txt_buyuksay.Text = liste.YUZDEBITIS;
            if (row.YUZDEBASLANGIC == "<")
            {
                //txt_kucuksay.Text = "";
                txt_Simge.Text = row.YUZDEBASLANGIC;

                cm_aralik.SelectedIndex = 2;
            }
            if (row.YUZDEBASLANGIC == ">")
            {
                //txt_kucuksay.Text = "";
                txt_Simge.Text = row.YUZDEBASLANGIC;

                cm_aralik.SelectedIndex = 1;
            }
            if (row.YUZDEBASLANGIC == "<" || row.YUZDEBASLANGIC == ">")
            {

            }
            else
            {
                cm_aralik.SelectedIndex = 0;
                txt_kucuksay.Text = liste.YUZDEBASLANGIC;

            }
            string[] secRenk = liste.RENK.Split(',');
            Color secilirenk = Color.FromArgb(Convert.ToInt32(secRenk[0]), Convert.ToInt32(secRenk[1]), Convert.ToInt32(secRenk[2]));
            color_sec.Color = secilirenk;
            lbl_renkid.Text = row.ID.ToString();
            btn_kaydet.Text = "Güncelle";
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            int handleid = e.RowHandle;
            if (handleid != -1)
            {
                string[] secRenk = gv_karzararrenk.GetRowCellValue(handleid, "RENK").ToString().Split(',');
                Color secilirenk = Color.FromArgb(Convert.ToInt32(secRenk[0]), Convert.ToInt32(secRenk[1]), Convert.ToInt32(secRenk[2]));
                e.Appearance.Options.UseBackColor = true;
                e.Appearance.BackColor = secilirenk;
                e.Appearance.ForeColor = Color.Black;
            }
        }

        private void frmKarZararAnalizRenk_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (tip == 1)
            {
                frmKarZararAnaliz form = Application.OpenForms["frmKarZararAnaliz"] as frmKarZararAnaliz;
                form.Yenile();
            }
            else
            {
                frmAlisKarZararAnaliz form = Application.OpenForms["frmAlisKarZararAnaliz"] as frmAlisKarZararAnaliz;
                form.Getir();
            }
         
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LOGO_XERO_KAR_ZARAR_RENK row = (LOGO_XERO_KAR_ZARAR_RENK)gv_karzararrenk.GetFocusedRow();
            DialogResult dialogResult = MessageBox.Show("Seçili renk tanımlaması silinecektir. Emin misiniz? ?", "Uyarı", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                listeler.secilirenksilyeni(row.ID); 
                Yenile();
                MessageBox.Show("İşlem Başarılı !");
            } 
        }

        private void cm_aralik_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cm_aralik.SelectedIndex == 0)
            {
                txt_kucuksay.Text = "";
                txt_kucuksay.Visible = true;
                txt_kucuksay.Enabled = true;
                txt_buyuksay.Enabled = true;

                txt_Simge.Text = "";
                txt_Simge.Visible = false;

            }
            if (cm_aralik.SelectedIndex == 1)
            {
                txt_kucuksay.Enabled = false;
                txt_kucuksay.Visible = false;
                 
                txt_buyuksay.Enabled = true;
                txt_buyuksay.Focus();

                txt_Simge.Text = ">";
                txt_Simge.Visible = true;
                txt_Simge.Enabled = false;

            }
            if (cm_aralik.SelectedIndex == 2)
            {
                txt_kucuksay.Enabled = false;
                txt_kucuksay.Visible = false;

                //txt_kucuksay.Text = "<";
                txt_buyuksay.Enabled = true;
                txt_buyuksay.Focus();

                txt_Simge.Text = "<";
                txt_Simge.Visible = true;
                txt_Simge.Enabled = false;

            }
        }

        private void frmKarZararAnalizRenk_Load(object sender, EventArgs e)
        {

        }
    }
}