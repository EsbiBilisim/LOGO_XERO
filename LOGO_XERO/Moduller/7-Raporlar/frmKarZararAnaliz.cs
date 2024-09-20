using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using LOGO_XERO.Logic;
using LOGO_XERO.Models.LOGO_M;
using LOGO_XERO.Models.LOGO_XERO_M;
using Microsoft.Win32;
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
    public partial class frmKarZararAnaliz : DevExpress.XtraEditors.XtraForm
    {
        Logic.GenelListeler listeler = new Logic.GenelListeler();
        Islemler islem = new Islemler();
        frmAnaForm ana; 
        List<LOGO_XERO_KAR_ZARAR_ANALIZ> liste;
        List<KAR_ZARAR_ANALIZ_FATURA_TURLERI> faturaturleri = new List<KAR_ZARAR_ANALIZ_FATURA_TURLERI>();
        List<LOGO_XERO_KAR_ZARAR_RENK> renklistesi;


        public frmKarZararAnaliz()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;

            islem.TasarimGetir(gv_karzararanaliz, ana._Kullanici.ID, this.Name, gridkarzararanaliz.Name);

            faturaturleri.Add(new KAR_ZARAR_ANALIZ_FATURA_TURLERI { ID = 1, NAME = "Satın Alma Faturası" });
            faturaturleri.Add(new KAR_ZARAR_ANALIZ_FATURA_TURLERI { ID = 11, NAME = "Fire Fişi" });
            faturaturleri.Add(new KAR_ZARAR_ANALIZ_FATURA_TURLERI { ID = 12, NAME = "Sarf Fişi" });
            faturaturleri.Add(new KAR_ZARAR_ANALIZ_FATURA_TURLERI { ID = 13, NAME = "Üretimden Giriş Fişi" });
            faturaturleri.Add(new KAR_ZARAR_ANALIZ_FATURA_TURLERI { ID = 14, NAME = "Devir Fişi" });
            faturaturleri.Add(new KAR_ZARAR_ANALIZ_FATURA_TURLERI { ID = 25, NAME = "Ambar Giriş Fişi" });
            faturaturleri.Add(new KAR_ZARAR_ANALIZ_FATURA_TURLERI { ID = 51, NAME = "Sayım Eksiği Fişi" });
            faturaturleri.Add(new KAR_ZARAR_ANALIZ_FATURA_TURLERI { ID = 50, NAME = "Sayım Fazlası Fişi" });
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\GooZ-II");
            cm_secim1.Properties.Items.Add(" Son Alış");
            cm_secim1.Properties.Items.Add(" Hareket Öncesi Son Alış");
            cm_secim1.Properties.Items.Add(" Maliyetlendirme");
            
             cm_secim1.SelectedIndex = 1; 

            date_ilk.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
           
            ck_fisturu.Properties.DisplayMember = "NAME";
            ck_fisturu.Properties.ValueMember = "ID";
            ck_fisturu.Properties.DataSource = faturaturleri;
            ck_fisturu.EditValue = faturaturleri.FirstOrDefault().ID;
             
             
            string firma = ana.lk_firma.EditValue.ToString();
            string donem = ana.lk_donem.EditValue.ToString();
           

            List<STRINGDEGER> marka = listeler.MarkaGetir(ana.lk_firma.EditValue.ToString());
            ck_marka.Properties.DisplayMember = "DEGER";
            ck_marka.Properties.ValueMember = "LOGICALREF";
            ck_marka.Properties.DataSource = marka;
             

            //List<L_CAPIWHOUSE> ambar1 = islem.AmbarListesi(ana.lk_firma.EditValue.ToString(),Convert.ToInt32(ana._Kullanici.ISYERI));
            List<L_CAPIWHOUSE> ambar1 = islem.TumAmbarListesi(ana.lk_firma.EditValue.ToString());
            ck_ambar.Properties.DisplayMember = "NAME";
            ck_ambar.Properties.ValueMember = "NR";
            ck_ambar.Properties.DataSource = ambar1; 

            ck_ambar.EditValue = ambar1.FirstOrDefault().NR;


            List<L_CAPIDEPT> bolumler = islem.BolumListesi(ana.lk_firma.EditValue.ToString());
            ck_bolum.Properties.DisplayMember = "NAME";
            ck_bolum.Properties.ValueMember = "NR";
            ck_bolum.Properties.DataSource = bolumler; 
                
            ck_bolum.EditValue = bolumler.FirstOrDefault().NR;

            List<LOGO_XERO_CARILISTE> cari = listeler.CariGetir(ana.lk_firma.EditValue.ToString(),ana.lk_donem.EditValue.ToString());
            lk_cari.Properties.DisplayMember = "DEFINITION_";
            lk_cari.Properties.ValueMember = "LOGICALREF";
            lk_cari.Properties.DataSource = cari;
            //lk_cari.Properties.PopulateColumns();
 

            List<STRINGDEGER> malzemegrup = listeler.MalzemeGrupKoduOzelKodListesi(ana.lk_firma.EditValue.ToString());
            ck_grupkodu.Properties.DisplayMember = "DEGER";
            ck_grupkodu.Properties.ValueMember = "DEGER";
            ck_grupkodu.Properties.DataSource = malzemegrup;
             

            List<STRINGDEGER> stokkod1 = listeler.OzelKodListesi(ana.lk_firma.EditValue.ToString(), $@"SPETYP1");
            ck_stokkod1.Properties.DisplayMember = "DEGER";
            ck_stokkod1.Properties.ValueMember = "DEGER"; 
             

            List<STRINGDEGER> stokkod2 = listeler.OzelKodListesi(ana.lk_firma.EditValue.ToString(), $@"SPETYP2");
            ck_stokkod2.Properties.DisplayMember = "DEGER";
            ck_stokkod2.Properties.ValueMember = "DEGER"; 
             

            List<STRINGDEGER> stokkod3 = listeler.OzelKodListesi(ana.lk_firma.EditValue.ToString(), $@"SPETYP3");
            ck_stokkod3.Properties.DisplayMember = "DEGER";
            ck_stokkod3.Properties.ValueMember = "DEGER"; 
             

            List<STRINGDEGER> stokkod4 = listeler.OzelKodListesi(ana.lk_firma.EditValue.ToString(), $@"SPETYP4");
            ck_stokkod4.Properties.DisplayMember = "DEGER";
            ck_stokkod4.Properties.ValueMember = "DEGER"; 
             

            List<STRINGDEGER> stokkod5 = listeler.OzelKodListesi(ana.lk_firma.EditValue.ToString(), $@"SPETYP5");
            ck_stokkod5.Properties.DisplayMember = "DEGER";
            ck_stokkod5.Properties.ValueMember = "DEGER"; 
             

            //ck_ambar.EditValue = ambar.FirstOrDefault().NR;
            date_son.DateTime = DateTime.Now;



            //yenile();
        }
        public void Yenile() 
        {
            RenkGetir();
            string[] selected = ck_fisturu.EditValue.ToString().Split(',');
            string secilen = "";
           
            for (int i = 0; i < selected.Count(); i++)
            {

                secilen += selected[i].Trim() + ",";
            }
            if (selected.Count() != 0)
            {
                secilen = secilen.Remove(secilen.Length - 1, 1);
            }

            string[] selectedbolum = ck_bolum.EditValue.ToString().Split(',');
            string secilenbolum = "";
            for (int i = 0; i < selectedbolum.Count(); i++)
            {
                secilenbolum += selectedbolum[i].Trim() + ",";
            }
            if (selectedbolum.Count() != 0)
            {
                secilenbolum = secilenbolum.Remove(secilenbolum.Length - 1, 1);
            }

            string[] selectedambar = ck_ambar.EditValue.ToString().Split(',');
            string secilenambar = "";
            for (int i = 0; i < selectedambar.Count(); i++)
            {
                secilenambar += selectedambar[i].Trim() + ",";
            }
            if (selectedambar.Count() != 0)
            {
                secilenambar = secilenambar.Remove(secilenambar.Length - 1, 1);
            }





            string stokfiltresi = "";

            if (ck_marka.EditValue != null && ck_marka.EditValue.ToString() != "")
            {
                string[] selectedMarka = ck_marka.EditValue.ToString().Split(',');
                string seciliMarka = "";
                for (int i = 0; i < selectedMarka.Count(); i++)
                {
                    seciliMarka += selectedMarka[i].Trim() + ",";
                }
                if (selectedMarka.Count() != 0)
                {
                    seciliMarka = seciliMarka.Remove(seciliMarka.Length - 1, 1);
                }

                stokfiltresi += $@"AND IT.MARKREF IN({seciliMarka})";
            }

            if (ck_grupkodu.EditValue != null && ck_grupkodu.EditValue.ToString() != "")
            {
                string[] selectedMalzemeGrup = ck_grupkodu.EditValue.ToString().Split(',');
                string seciliMalzemeGrup = "";
                for (int i = 0; i < selectedMalzemeGrup.Count(); i++)
                {
                    seciliMalzemeGrup += "'" + selectedMalzemeGrup[i].Trim() + "',";
                }
                if (selectedMalzemeGrup.Count() != 0)
                {
                    seciliMalzemeGrup = seciliMalzemeGrup.Remove(seciliMalzemeGrup.Length - 1, 1);
                }

                stokfiltresi += $@"AND IT.STGRPCODE IN({seciliMalzemeGrup})";
            }


            if (ck_stokkod1.EditValue != null && ck_stokkod1.EditValue.ToString() != "")
            {
                string[] selectedStokOzelKod1 = ck_stokkod1.EditValue.ToString().Split(',');
                string seciliStokOzelKod1 = "";
                for (int i = 0; i < selectedStokOzelKod1.Count(); i++)
                {
                    seciliStokOzelKod1 += "'" + selectedStokOzelKod1[i].Trim() + "',";
                }
                if (selectedStokOzelKod1.Count() != 0)
                {
                    seciliStokOzelKod1 = seciliStokOzelKod1.Remove(seciliStokOzelKod1.Length - 1, 1);
                }

                stokfiltresi += $@"AND IT.SPECODE IN({seciliStokOzelKod1})";
            }

            if (ck_stokkod2.EditValue != null && ck_stokkod2.EditValue.ToString() != "")
            {

                string[] selectedStokOzelKod2 = ck_stokkod2.EditValue.ToString().Split(',');
                string seciliStokOzelKod2 = "";
                for (int i = 0; i < selectedStokOzelKod2.Count(); i++)
                {
                    seciliStokOzelKod2 += "'" + selectedStokOzelKod2[i].Trim() + "',";
                }
                if (selectedStokOzelKod2.Count() != 0)
                {
                    seciliStokOzelKod2 = seciliStokOzelKod2.Remove(seciliStokOzelKod2.Length - 1, 1);
                }

                stokfiltresi += $@"AND IT.SPECODE2 IN({seciliStokOzelKod2})";
            }

            if (ck_stokkod3.EditValue != null && ck_stokkod3.EditValue.ToString() != "")
            {

                string[] selectedStokOzelKod3 = ck_stokkod3.EditValue.ToString().Split(',');
                string seciliStokOzelKod3 = "";
                for (int i = 0; i < selectedStokOzelKod3.Count(); i++)
                {
                    seciliStokOzelKod3 += "'" + selectedStokOzelKod3[i].Trim() + "',";
                }
                if (selectedStokOzelKod3.Count() != 0)
                {
                    seciliStokOzelKod3 = seciliStokOzelKod3.Remove(seciliStokOzelKod3.Length - 1, 1);
                }

                stokfiltresi += $@"AND IT.SPECODE3 IN({seciliStokOzelKod3})";
            }

            if (ck_stokkod4.EditValue != null && ck_stokkod4.EditValue.ToString() != "")
            {

                string[] selectedStokOzelKod4 = ck_stokkod4.EditValue.ToString().Split(',');
                string seciliStokOzelKod4 = "";
                for (int i = 0; i < selectedStokOzelKod4.Count(); i++)
                {
                    seciliStokOzelKod4 += "'" + selectedStokOzelKod4[i].Trim() + "',";
                }
                if (selectedStokOzelKod4.Count() != 0)
                {
                    seciliStokOzelKod4 = seciliStokOzelKod4.Remove(seciliStokOzelKod4.Length - 1, 1);
                }

                stokfiltresi += $@"AND IT.SPECODE4 IN({seciliStokOzelKod4})";
            }

            if (ck_stokkod5.EditValue != null && ck_stokkod5.EditValue.ToString() != "")
            {

                string[] selectedStokOzelKod5 = ck_stokkod5.EditValue.ToString().Split(',');
                string seciliStokOzelKod5 = "";
                for (int i = 0; i < selectedStokOzelKod5.Count(); i++)
                {
                    seciliStokOzelKod5 += "'" + selectedStokOzelKod5[i].Trim() + "',";
                }
                if (selectedStokOzelKod5.Count() != 0)
                {
                    seciliStokOzelKod5 = seciliStokOzelKod5.Remove(seciliStokOzelKod5.Length - 1, 1);
                }

                stokfiltresi += $@"AND IT.SPECODE5 IN({seciliStokOzelKod5})";
            }



            if (!string.IsNullOrWhiteSpace(secilenambar))
            {
                
                if (string.IsNullOrWhiteSpace(ck_fisturu.EditValue.ToString()))
                {
                    XtraMessageBox.Show("En Az 1 Tane Fiş Türü Seçimi Yapınız !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string filtre = "";
                if (ce_ambar_karv.Checked)
                {
                    filtre = "and  ST1.SOURCEINDEX=LISTE.SOURCEINDEX";
                }
                string carifiltre = "";
                if (lk_cari.EditValue != null)
                {
                    carifiltre = $@" AND ST.CLIENTREF={lk_cari.EditValue.ToString()}";
                }
                if (cm_secim1.SelectedIndex == 0)
                {

                    liste = listeler.karZararAnaliz(ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString(), date_ilk.DateTime.ToString("yyyy-MM-dd"), date_son.DateTime.ToString("yyyy-MM-dd"), secilenambar, stokfiltresi, "CAST(CAST(ISNULL(ENSONALISFIYATTARIH.FIYAT, 0) AS DECIMAL(18,2))AS FLOAT) * (ISNULL(LISTE.UINFO2, 1) / NULLIF(ISNULL(LISTE.UINFO1, 1), 0))", filtre, secilen, secilen, "ENSONALISFIYATTARIH.FIYAT", carifiltre, "ENSONALISFIYATTARIH.TARIH", secilenbolum);
                }
                else if (cm_secim1.SelectedIndex == 1)
                {
                    liste = listeler.karZararAnaliz(ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString(), date_ilk.DateTime.ToString("yyyy-MM-dd"), date_son.DateTime.ToString("yyyy-MM-dd"), secilenambar, stokfiltresi, "CAST(CAST(ISNULL(SONALISFIYATTARIH.FIYAT,0)AS DECIMAL(18,2))AS FLOAT)*(ISNULL(LISTE.UINFO2,1)/NULLIF(ISNULL(LISTE.UINFO1,1),0))", filtre, secilen, secilen, "SONALISFIYATTARIH.FIYAT", carifiltre, "SONALISFIYATTARIH.TARIH", secilenbolum);

                }
                else if (cm_secim1.SelectedIndex == 2)
                {
                    liste = listeler.karZararAnaliz(ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString(), date_ilk.DateTime.ToString("yyyy-MM-dd"), date_son.DateTime.ToString("yyyy-MM-dd"), secilenambar, stokfiltresi, "CAST(CAST(ISNULL(SONALISFIYATTARIH.OUTCOST,0)AS DECIMAL(18,2))AS FLOAT)", filtre, secilen, "2,3,7,8,9,10", "SONALISFIYATTARIH.OUTCOST", carifiltre, "SONALISFIYATTARIH.TARIH", secilenbolum);
                }
                if (ce_zarar.Checked)
                {
                    gridkarzararanaliz.DataSource = liste.Where(s => s.KARTUTARI < 0);
                }
                else
                {
                    gridkarzararanaliz.DataSource = liste;
                } 
                gridkarzararanaliz.RefreshDataSource();
                gridkarzararanaliz.Refresh();
            }
            else
            {
                XtraMessageBox.Show("Ambar Seçimi Yapınız !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void frmKarZararAnaliz_Load(object sender, EventArgs e)
        {  
        }
        public void RenkGetir()
        {
            renklistesi = listeler.YeniRenkGetir(1);
            //renklistesi = islem.renkGetir();
        }
        private void btn_listele_Click(object sender, EventArgs e)
        {
            Yenile();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            lk_cari.EditValue = null;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        { 
            frmKarZararAnalizRenk renk = new frmKarZararAnalizRenk(1);
            renk.ShowDialog();
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            int handleid = e.RowHandle;
            if (renklistesi == null)
            {  return; }
            try
            {
                if (handleid > -1)
                {
                    foreach (var item in renklistesi)
                    {
                        double oranaralık = 0;
                        double oranaralık2 = 0;
                        double karyuzde = Convert.ToDouble(gv_karzararanaliz.GetRowCellValue(handleid, "KARYUZDE").ToString());
                        int STLN = Convert.ToInt32(gv_karzararanaliz.GetRowCellValue(handleid, "STLOG").ToString());
                        if (STLN == 627129)
                        {
                            string mesajj = "geldi";
                        }
                        if (item.YUZDEBASLANGIC == "<")
                        {
                            if (Convert.ToDouble(item.YUZDEBITIS.ToString()) >= karyuzde)
                            {
                                string[] secRenk = item.RENK.ToString().Split(',');
                                Color secilirenk = Color.FromArgb(Convert.ToInt32(secRenk[0]), Convert.ToInt32(secRenk[1]), Convert.ToInt32(secRenk[2]));
                                e.Appearance.Options.UseBackColor = true;
                                e.Appearance.BackColor = secilirenk;
                                e.Appearance.ForeColor = Color.Black;
                            }
                        }
                        if (item.YUZDEBASLANGIC == ">")
                        {
                            if (karyuzde >= Convert.ToDouble(item.YUZDEBITIS.ToString()))
                            {
                                string[] secRenk = item.RENK.ToString().Split(',');
                                Color secilirenk = Color.FromArgb(Convert.ToInt32(secRenk[0]), Convert.ToInt32(secRenk[1]), Convert.ToInt32(secRenk[2]));
                                e.Appearance.Options.UseBackColor = true;
                                e.Appearance.BackColor = secilirenk;
                                e.Appearance.ForeColor = Color.Black;
                            }
                        }
                        if (item.YUZDEBASLANGIC == ">" || item.YUZDEBASLANGIC == "<")
                        {

                        }
                        else
                        {
                            if (Convert.ToDouble(item.YUZDEBASLANGIC.ToString()) <= karyuzde && karyuzde <= Convert.ToDouble(item.YUZDEBITIS.ToString()))
                            {
                                string[] secRenk = item.RENK.ToString().Split(',');
                                Color secilirenk = Color.FromArgb(Convert.ToInt32(secRenk[0]), Convert.ToInt32(secRenk[1]), Convert.ToInt32(secRenk[2]));
                                e.Appearance.Options.UseBackColor = true;
                                e.Appearance.BackColor = secilirenk;
                                e.Appearance.ForeColor = Color.Black;
                            }
                            else
                            { 
                            }
                        }
                       
                    }
                }
            }
            catch (Exception)
            {
            }
            e.HighPriority = true;
        }

        private void stokBilgiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gv_karzararanaliz.RowCount > 0)
            {
                LOGO_XERO_KAR_ZARAR_ANALIZ row = (LOGO_XERO_KAR_ZARAR_ANALIZ)gv_karzararanaliz.GetFocusedRow();
                string code = row.STOCKREF.ToString();
                frmDetayBilgi dt = new frmDetayBilgi();
                dt.tip = 2;
                dt.Text = row.STOKADI.ToString() + " İsimli Stoğun Bakiye Durumu ";
                dt.StokRef = code;
                dt.Yenile();
                dt.Show();

            }
        }

        private void CariBilgiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gv_karzararanaliz.RowCount > 0)
            {
                LOGO_XERO_KAR_ZARAR_ANALIZ row = (LOGO_XERO_KAR_ZARAR_ANALIZ)gv_karzararanaliz.GetFocusedRow();
                string code = row.CARILOG.ToString();
                frmDetayBilgi dt = new frmDetayBilgi();

                dt.tip = 1;
                if (row.CARIUNVANI != null)
                {
                    dt.Text = row.CARIUNVANI.ToString() + " İsimli Carinin Bakiye Durumu ";
                    dt.carikod = code;
                    dt.Yenile();
                    dt.Show();
                }
                else
                {
                    XtraMessageBox.Show("Kayıtlı Cari Bilgisi Yoktur ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void cariEkstreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gv_karzararanaliz.RowCount > 0)
            {
                LOGO_XERO_KAR_ZARAR_ANALIZ row = (LOGO_XERO_KAR_ZARAR_ANALIZ)gv_karzararanaliz.GetFocusedRow();
                frmCariEkstre dt = new frmCariEkstre(row.CARIUNVANI,row.CARIKODU);
                if (row.CARIUNVANI != null)
                {
                    string code = row.CARIKODU.ToString();
                    dt.Text = row.CARIUNVANI.ToString() + " İsimli Carinin Ekstresi ";
                    dt.carikod = code;
                    dt.Yenile();
                    dt.Show();
                }
                else
                {
                    XtraMessageBox.Show("Kayıtlı Cari Bilgisi Yoktur ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void tasarımKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            islem.TasarimKaydet(gv_karzararanaliz,ana._Kullanici.ID,this.Name,gridkarzararanaliz.Name);
            XtraMessageBox.Show("Tasarım Kaydedildi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pdfAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listeler.pdfAktar(gridkarzararanaliz);
        }

        private void excelAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listeler.excelAktar(gridkarzararanaliz);
        }

        private void tamEkranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MdiParent = null;
            this.WindowState = FormWindowState.Maximized;
        }

        private void frmKarZararAnaliz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                btn_listele_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.F4)
            {
                gridkarzararanaliz.ShowPrintPreview();
            }
        }
    }
}
