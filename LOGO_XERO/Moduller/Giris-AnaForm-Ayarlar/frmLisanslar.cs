using DevExpress.XtraBars.Customization;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraReports.Design;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using LOGO_XERO.Models.LOGO_M;
using LOGO_XERO.Models.LOGO_XERO_M;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGO_XERO.Moduller.Giris_AnaForm_Ayarlar
{
    public partial class frmLisanslar : DevExpress.XtraEditors.XtraForm
    {
        SQLConnection clas = new SQLConnection();
        IlkTabloIslemler islem = new IlkTabloIslemler();
        Lisans lisans = new Lisans();

     
        public frmLisanslar()
        {
            InitializeComponent();
        }
        List<LOGO_XERO_LISANSLAR> liste;
        private void frmLisanslar_Load(object sender, EventArgs e)
        {
            ListeGetir();
            gridLisansListesi.DataSource = liste;
            //List<LOGO_XERO_LISANSLAR> lisanslar = gridLisansListesi.DataSource as List<LOGO_XERO_LISANSLAR>;
            //if (lisanslar != null)
            //{
            //    var gecerliLisanslar = lisanslar.Where(s => s.LISANSNUMARASI != "" && s.GECERLILIKDURUMU == true).ToList();
            //    if (gecerliLisanslar.Count > 0)
            //    {
            //        btn_LisansAl.Visible = true;
            //        btn_LisansYenile.Visible = true;
            //    }

            //    var hicLisansNumarasiYokIse = lisanslar.Where(s => s.LISANSNUMARASI == "" && s.GECERLILIKDURUMU == false).ToList();
            //    if (hicLisansNumarasiYokIse.Count > 0)
            //    {
            //        btn_LisansAl.Visible = true;
            //        btn_LisansYenile.Visible = false;
            //    }

            //    var suresiBitmisLisanslar = lisanslar.Where(s => s.LISANSNUMARASI != "" && s.GECERLILIKDURUMU == false).ToList();
            //    if (suresiBitmisLisanslar.Count > 0)
            //    {
            //        btn_LisansAl.Visible = true;
            //        btn_LisansYenile.Visible = true;
            //    }
            //}
        }
        List<L_CAPIFIRM> firm;
        void ListeGetir()
        {
            firm = islem.DataSetlifirmalistesi();
            liste = islem.DataSetliLisanslistesi();

            foreach (var item in liste)
            {
                if (item.MODUL == 1)
                {
                    item.MODULACIKLAMA = "TEKLİF MODÜLÜ";
                }
                else if (item.MODUL == 2)
                {
                    item.MODULACIKLAMA = "GOOZ MODÜLÜ";
                }
                else if (item.MODUL == 3)
                {
                    item.MODULACIKLAMA = "TAM PAKET";
                }
                else
                {
                    item.MODULACIKLAMA = "DEMO LİSANS";
                }
                if (!string.IsNullOrWhiteSpace(item.LISANSNUMARASI))
                {
                    LOGO_XERO_LISANS lisansli = lisans.LisansKontrolEt(item.LISANSNUMARASI);
                    if (lisansli.MODUL == item.MODUL)
                    {
                        L_CAPIFIRM lisansliFirma = firm.Where(s => s.TAXNR == lisansli.VERGIKIMLIKNO).FirstOrDefault();
                        if (lisansliFirma != null)
                        {
                            int kalanGun = lisans.KalanGunDondur(lisansli.TARIH, item.MODUL);
                            item.LISANSKALANGUNSAYISI = kalanGun;
                            if (kalanGun <= 0)
                            {
                                item.GECERLILIKDURUMU = false;
                            }
                            else
                            {
                                item.GECERLILIKDURUMU = true;
                            }

                        }
                        else
                        {
                            item.LISANSKALANGUNSAYISI = 0;
                            item.GECERLILIKDURUMU = false;
                        }
                    }

                    else
                    {
                        item.LISANSKALANGUNSAYISI = 0;
                        item.GECERLILIKDURUMU = false;
                    }


                }
                else
                {
                    item.GECERLILIKDURUMU = false;
                    item.LISANSKALANGUNSAYISI = 0;
                }
            }



        }


        private void simpleButton2_Click(object sender, EventArgs e)
        {
            List<LOGO_XERO_LISANSLAR> listeGridKontrol = gridLisansListesi.DataSource as List<LOGO_XERO_LISANSLAR>;
            bool lisansvar = false;
            foreach (var item in liste)
            {
                if (item.MODUL == 1)
                {
                    item.MODULACIKLAMA = "TEKLİF MODÜLÜ";
                }
                else if (item.MODUL == 2)
                {
                    item.MODULACIKLAMA = "GOOZ MODÜLÜ";
                }
                else if (item.MODUL == 3)
                {
                    item.MODULACIKLAMA = "TAM PAKET";
                }
                else
                {
                    item.MODULACIKLAMA = "DEMO LİSANS";
                }
                if (!string.IsNullOrWhiteSpace(item.LISANSNUMARASI))
                {

                    LOGO_XERO_LISANS lisansli = lisans.LisansKontrolEt(item.LISANSNUMARASI);

                    if (lisansli.MODUL == item.MODUL)
                    {
                        L_CAPIFIRM lisansliFirma = firm.Where(s => s.TAXNR == lisansli.VERGIKIMLIKNO).FirstOrDefault();
                        if (lisansliFirma != null)
                        {
                            int kalanGun = lisans.KalanGunDondur(lisansli.TARIH, lisansli.MODUL);
                            item.LISANSKALANGUNSAYISI = kalanGun;
                            if (kalanGun <= 0)
                            {
                                item.GECERLILIKDURUMU = false;
                            }
                            else
                            {
                                item.GECERLILIKDURUMU = true;
                            }

                        }
                        else
                        {
                            item.LISANSKALANGUNSAYISI = 0;
                            item.GECERLILIKDURUMU = false;
                        }
                    }
                    else
                    {
                        item.LISANSKALANGUNSAYISI = 0;
                        item.GECERLILIKDURUMU = false;
                    }
                    lisansvar = true;
                }
                else
                {
                    item.GECERLILIKDURUMU = false;
                    item.LISANSKALANGUNSAYISI = 0;
                }
            }
            gridLisansListesi.DataSource = listeGridKontrol;
            gridLisansListesi.RefreshDataSource();
            gridLisansListesi.Refresh();
            XtraMessageBox.Show("Lisans Kontrolü Yapılmıştır  !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            List<LOGO_XERO_LISANSLAR> listeGridKontrol = gridLisansListesi.DataSource as List<LOGO_XERO_LISANSLAR>;

            foreach (var item in liste)
            {
                if (item.MODUL == 1)
                {
                    item.MODULACIKLAMA = "TEKLİF MODÜLÜ";
                }
                else if (item.MODUL == 2)
                {
                    item.MODULACIKLAMA = "GOOZ MODÜLÜ";
                }
                else if (item.MODUL == 3)
                {
                    item.MODULACIKLAMA = "TAM PAKET";
                }
                else
                {
                    item.MODULACIKLAMA = "DEMO LİSANS";
                }
                if (!string.IsNullOrWhiteSpace(item.LISANSNUMARASI))
                {
                    LOGO_XERO_LISANS lisansli = lisans.LisansKontrolEt(item.LISANSNUMARASI);

                    if (lisansli.MODUL == item.MODUL)
                    {
                        L_CAPIFIRM lisansliFirma = firm.Where(s => s.TAXNR == lisansli.VERGIKIMLIKNO).FirstOrDefault();
                        if (lisansliFirma != null)
                        {
                            int kalanGun = lisans.KalanGunDondur(lisansli.TARIH, item.MODUL);
                            item.LISANSKALANGUNSAYISI = kalanGun;
                            if (kalanGun <= 0)
                            {
                                item.GECERLILIKDURUMU = false;
                            }
                            else
                            {
                                item.GECERLILIKDURUMU = true;
                            }

                        }
                        else
                        {
                            item.LISANSKALANGUNSAYISI = 0;
                            item.GECERLILIKDURUMU = false;
                        }
                    }
                    else
                    {
                        item.LISANSKALANGUNSAYISI = 0;
                        item.GECERLILIKDURUMU = false;
                    }
                }
                else
                {
                    item.GECERLILIKDURUMU = false;
                    item.LISANSKALANGUNSAYISI = 0;
                }
            }
            gridLisansListesi.DataSource = listeGridKontrol;
            gridLisansListesi.RefreshDataSource();
            gridLisansListesi.Refresh();

            List<LOGO_XERO_LISANSLAR> listeGrid = gridLisansListesi.DataSource as List<LOGO_XERO_LISANSLAR>;
            try
            {
                var yanlislisanslar = listeGrid.Where(s => s.GECERLILIKDURUMU == false && s.LISANSNUMARASI != "").ToList();
                if (yanlislisanslar.Count > 0)
                {
                    XtraMessageBox.Show("Yanlış Lisans Bilgileriniz Mevcuttur ! Kayıt Edemezsiniz ! Lisans Kontrolü Yaptırınız !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }

                var demolisansi = listeGrid.Where(s => s.MODUL == 4).FirstOrDefault();
                var gerceklisanslar = listeGrid.Where(s => s.MODUL != 4 && s.LISANSNUMARASI != "" && s.GECERLILIKDURUMU == true).ToList();
                if (gerceklisanslar != null)
                {
                    if (gerceklisanslar.Count > 0)
                    {
                        demolisansi.LISANSNUMARASI = "";
                        demolisansi.GECERLILIKDURUMU = false;
                        demolisansi.LISANSNUMARASI = "";
                    }
                }

                var dogrulisanslar = listeGrid.Where(s => s.GECERLILIKDURUMU == true && s.LISANSNUMARASI != "").ToList();
                if (dogrulisanslar.Count == 0)
                {
                    XtraMessageBox.Show("Lisans Bilgilerinin Hepsi Boş ! Kayıt Edemezsiniz !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }

                foreach (var item in listeGrid)
                {
                    string varvarmi = "";
                    if (!string.IsNullOrWhiteSpace(item.LISANSNUMARASI))
                    {
                        varvarmi = ", VAR=1";
                    }
                    clas.Connect();
                    string sql = $@"UPDATE LOGO_XERO_LISANSLAR SET LISANSNUMARASI='{item.LISANSNUMARASI}' {varvarmi} WHERE ID={item.ID}";
                    SqlCommand cmd = new SqlCommand(sql, clas.Conn);
                    clas.Conn.Open();
                    cmd.ExecuteNonQuery();
                    clas.Conn.Close();
                }

                XtraMessageBox.Show("Kayıt Başarılı ! Lisansların Aktif Olabilmesi İçin Program Yeniden Başlatılacaktır !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IlkTabloIslemler islem = new IlkTabloIslemler();
                islem.KullaniciTablosuOlustur();
                islem.XERO_Parametreler_TABLOOLUSTUR();
                Application.Restart();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Kayıt Başarısız. Hata : " + ex.Message.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        RepositoryItemButtonEdit GetRI(RepositoryItemButtonEdit buttonEdit)
        {
            RepositoryItemButtonEdit ri = new RepositoryItemButtonEdit();
            ri.Assign(buttonEdit);
            ri.Buttons[0].Enabled = false;

            return ri;
        }

        public string LisansNumarasi = "";
        public int Modül = 0;
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            frmDemoLisansAlma frm = new frmDemoLisansAlma(this);
            frm.almamiYenilemmi = 0;
            frm.ShowDialog();
            if (!string.IsNullOrWhiteSpace(LisansNumarasi))
            {
                List<LOGO_XERO_LISANSLAR> listeGrid = gridLisansListesi.DataSource as List<LOGO_XERO_LISANSLAR>;
                var DemoModul = listeGrid.Where(s => s.MODUL == Modül).FirstOrDefault();
                if (DemoModul != null)
                {
                    if (Modül == 4)
                    {
                        DemoModul.VAR = 1;
                    }
                    DemoModul.LISANSNUMARASI = LisansNumarasi;
                    gridLisansListesi.RefreshDataSource();
                    gridLisansListesi.Refresh();
                }
            }
        }
        private void btn_LisansYenile_Click(object sender, EventArgs e)
        {
            frmDemoLisansAlma frm = new frmDemoLisansAlma(this);
            frm.almamiYenilemmi = 1;
            frm.ShowDialog();
            if (!string.IsNullOrWhiteSpace(LisansNumarasi))
            {
                List<LOGO_XERO_LISANSLAR> listeGrid = gridLisansListesi.DataSource as List<LOGO_XERO_LISANSLAR>;
                var DemoModul = listeGrid.Where(s => s.MODUL == Modül).FirstOrDefault();
                if (DemoModul != null)
                {
                    DemoModul.LISANSNUMARASI = LisansNumarasi;
                    gridLisansListesi.RefreshDataSource();
                    gridLisansListesi.Refresh();
                }
            }
        }
    }
}