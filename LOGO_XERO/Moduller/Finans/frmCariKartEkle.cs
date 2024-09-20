using DevExpress.CodeParser;
using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using LOGO_XERO.Models.CariSorgulama;
using LOGO_XERO.Models.LOGO_M;
using LOGO_XERO.Models.LogoObje;
using LOGO_XERO.Moduller.GenelListeler;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LOGO_XERO.Moduller.Finans
{
    public partial class frmCariKartEkle : DevExpress.XtraEditors.XtraForm
    {
        string firma, donem;
        frmAnaForm ana;
        Islemler islem = new Islemler();
        LogoObjeAktar obj;
        public int cariReferans = 0;
        List<L_COUNTRY> ulkeler;
        List<L_CITY> sehirler;
        List<L_TOWN> ilceler;
        List<L_DISTRICT> mahalleler;
        LG_TRGPAR riskParametreleri;
        public List<L_FIRMPARAMS> FirmaLogoParametre;
        public frmCariKartEkle()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            firma = ana.lk_firma.EditValue.ToString();
            donem = ana.lk_donem.EditValue.ToString();
            obj = new LogoObjeAktar(ana.parametre);
            if (cariReferans == 0)
            {
                btn_IstihabatBilgisi.Visible = false;
            }
            else
            {
                btn_IstihabatBilgisi.Visible = true;
            }
        }
        private void frmCariKartEkle_Load(object sender, EventArgs e)
        {
            FirmaLogoParametre = islem.FirmaLogoTumParametreleriGetir(ana.lk_firma.EditValue.ToString());
            riskParametreleri = islem.RiskParametreleriLogo();

            islem.UlkeListesiDoldur(lk_Ulke);
            ulkeler = islem.UlkeListesiGetir();
            sehirler = islem.TumSehirListesiGetir();
            ilceler = islem.TumIlceListesiGetir();
            mahalleler = islem.TumMahalleListesiGetir();


            if (cariReferans == 0)
            {
                btn_IstihabatBilgisi.Visible = false;
                cm_caritipi.SelectedIndex = 0;
                //vade takibi Yapilacak İşlemler
                L_FIRMPARAMS BankaIslemi = FirmaLogoParametre.Where(s => s.GROUPNR == 162 && s.MODULENR == 11 && s.CODE == "FIN_DUEDATECONTBANKBATCH").FirstOrDefault();
                L_FIRMPARAMS cariHesapIslemleri = FirmaLogoParametre.Where(s => s.GROUPNR == 162 && s.MODULENR == 11 && s.CODE == "FIN_DUEDATECONTCHBATCH").FirstOrDefault();
                L_FIRMPARAMS Ihracat = FirmaLogoParametre.Where(s => s.GROUPNR == 162 && s.MODULENR == 11 && s.CODE == "FIN_DUEDATECONTEXIM").FirstOrDefault();
                L_FIRMPARAMS KasaIslemleri = FirmaLogoParametre.Where(s => s.GROUPNR == 162 && s.MODULENR == 11 && s.CODE == "FIN_DUEDATECONTKSBATCH").FirstOrDefault();
                L_FIRMPARAMS SatisFaturalari = FirmaLogoParametre.Where(s => s.GROUPNR == 162 && s.MODULENR == 11 && s.CODE == "FIN_DUEDATECONTSALINV").FirstOrDefault();
                L_FIRMPARAMS SatisSiparisi = FirmaLogoParametre.Where(s => s.GROUPNR == 162 && s.MODULENR == 11 && s.CODE == "FIN_DUEDATECONTSALORD").FirstOrDefault();
                L_FIRMPARAMS VadeTakibiYapilacakGunSayisi = FirmaLogoParametre.Where(s => s.GROUPNR == 163 && s.MODULENR == 11 && s.CODE == "FIN_DUEDATECOUNT").FirstOrDefault();
                L_FIRMPARAMS VadeTakibiLimiti = FirmaLogoParametre.Where(s => s.GROUPNR == 164 && s.MODULENR == 11 && s.CODE == "FIN_DUEDATELIMIT").FirstOrDefault();
                L_FIRMPARAMS vadeTakibiYapildiginda = FirmaLogoParametre.Where(s => s.GROUPNR == 165 && s.MODULENR == 11 && s.CODE == "FIN_DUEDATETRACK").FirstOrDefault();
                L_FIRMPARAMS acikHesapRiskLimiti = FirmaLogoParametre.Where(s => s.GROUPNR == 382 && s.MODULENR == 11 && s.CODE == "FIN_ACCRISKLIMIT").FirstOrDefault();

                txt_VadeTakibiYapilacakGunSayisi.Text = VadeTakibiYapilacakGunSayisi.VALUE;
                txt_VadeTakibiYapilacakTutar.Text = VadeTakibiLimiti.VALUE;
                cm_vadeTakibiYapildiginda.SelectedIndex = Convert.ToInt32(vadeTakibiYapildiginda.VALUE);
                txt_acikhesaplimit.Text = acikHesapRiskLimiti.VALUE;

                string vadetakibiYapilacakIslemler = "";
                if (BankaIslemi.VALUE == "1")
                {
                    vadetakibiYapilacakIslemler += "6,";
                }
                if (cariHesapIslemleri.VALUE == "1")
                {
                    vadetakibiYapilacakIslemler += "5,";
                }
                if (Ihracat.VALUE == "1")
                {
                    vadetakibiYapilacakIslemler += "7,";
                }
                if (KasaIslemleri.VALUE == "1")
                {
                    vadetakibiYapilacakIslemler += "4,";
                }
                if (SatisFaturalari.VALUE == "1")
                {
                    vadetakibiYapilacakIslemler += "2,";
                }
                if (SatisSiparisi.VALUE == "1")
                {
                    vadetakibiYapilacakIslemler += "3,";
                }
                vadetakibiYapilacakIslemler = vadetakibiYapilacakIslemler.Substring(0, vadetakibiYapilacakIslemler.Length - 1);
                cm_VadeTakibiYapilacakIslemler.EditValue = vadetakibiYapilacakIslemler;


                cm_acikhesap.SelectedIndex = Convert.ToInt32(riskParametreleri.ACCRISKOVER);
                cm_kendiceksenet.SelectedIndex = Convert.ToInt32(riskParametreleri.MYCSRISKOVER);
                cm_mustericeksenet.SelectedIndex = Convert.ToInt32(riskParametreleri.CSTCSRISKOVER);
                cm_ciroceksenet.SelectedIndex = Convert.ToInt32(riskParametreleri.CSTCSCIRORISKOVER);
                cm_siparis.SelectedIndex = Convert.ToInt32(riskParametreleri.RISKTYPE);
                cm_siparisoneri.SelectedIndex = Convert.ToInt32(riskParametreleri.ORDRISKOVERSUGG);
                cm_irsaliye.SelectedIndex = Convert.ToInt32(riskParametreleri.DESPRISKOVER);
                cm_irsaliyeoneri.SelectedIndex = Convert.ToInt32(riskParametreleri.DESPRISKOVERSUGG);


                //risk toplamı alanlari
                L_FIRMPARAMS acikHesap = FirmaLogoParametre.Where(s => s.GROUPNR == 109 && s.MODULENR == 11 && s.CODE == "FIN_RISKTYPES1").FirstOrDefault();
                L_FIRMPARAMS kendiCekSenet = FirmaLogoParametre.Where(s => s.GROUPNR == 109 && s.MODULENR == 11 && s.CODE == "FIN_RISKTYPES2").FirstOrDefault();
                L_FIRMPARAMS musteriCekSenet = FirmaLogoParametre.Where(s => s.GROUPNR == 109 && s.MODULENR == 11 && s.CODE == "FIN_RISKTYPES3").FirstOrDefault();
                L_FIRMPARAMS irsaliye = FirmaLogoParametre.Where(s => s.GROUPNR == 109 && s.MODULENR == 11 && s.CODE == "FIN_RISKTYPES4").FirstOrDefault();
                L_FIRMPARAMS siparisSevkedilebilir = FirmaLogoParametre.Where(s => s.GROUPNR == 109 && s.MODULENR == 11 && s.CODE == "FIN_RISKTYPES5").FirstOrDefault();
                L_FIRMPARAMS siparisOneri = FirmaLogoParametre.Where(s => s.GROUPNR == 109 && s.MODULENR == 11 && s.CODE == "FIN_RISKTYPES6").FirstOrDefault();
                L_FIRMPARAMS ciroCekSenet = FirmaLogoParametre.Where(s => s.GROUPNR == 109 && s.MODULENR == 11 && s.CODE == "FIN_RISKTYPES7").FirstOrDefault();
                L_FIRMPARAMS irsaliyeOneri = FirmaLogoParametre.Where(s => s.GROUPNR == 109 && s.MODULENR == 11 && s.CODE == "FIN_RISKTYPES8").FirstOrDefault();


                ck_acikHesap.Checked = Convert.ToBoolean(Convert.ToInt32(acikHesap.VALUE));
                ck_KendiCekSenet.Checked = Convert.ToBoolean(Convert.ToInt32(kendiCekSenet.VALUE));
                ck_musteriCekSenet.Checked = Convert.ToBoolean(Convert.ToInt32(musteriCekSenet.VALUE));
                ck_CiroCekSenet.Checked = Convert.ToBoolean(Convert.ToInt32(ciroCekSenet.VALUE));
                ck_Sipariste.Checked = Convert.ToBoolean(Convert.ToInt32(siparisSevkedilebilir.VALUE));
                ck_OneriSipariste.Checked = Convert.ToBoolean(Convert.ToInt32(siparisOneri.VALUE));
                ck_Irsaliyede.Checked = Convert.ToBoolean(Convert.ToInt32(irsaliye.VALUE));
                ck_OneriIrsaliyede.Checked = Convert.ToBoolean(Convert.ToInt32(irsaliyeOneri.VALUE));
            }
            else
            {
                btn_IstihabatBilgisi.Visible = true;
                LG_CLCARD gelencari = islem.cariBilgi(cariReferans);
                if (gelencari.CARDTYPE == 3)
                {
                    cm_caritipi.SelectedIndex = 0;
                }
                else if (gelencari.CARDTYPE == 1)
                {
                    cm_caritipi.SelectedIndex = 1;
                }
                else
                {
                    cm_caritipi.SelectedIndex = 2;
                }
                cm_caritipi.Enabled = false;
                txtCariKodu.Text = gelencari.CODE;
                txtUnvan.Text = gelencari.DEFINITION_;
                txtAdres.Text = gelencari.ADDR1;
                txtAdres2.Text = gelencari.ADDR2;

                lk_Ulke.EditValue = ulkeler.Where(s => s.NAME == gelencari.COUNTRY).FirstOrDefault() != null ? ulkeler.Where(s => s.NAME == gelencari.COUNTRY).FirstOrDefault().LOGICALREF : 0;
                txt_UlkeKodu.Text = gelencari.COUNTRYCODE;


                lk_sehir.EditValue = sehirler.Where(s => s.NAME == gelencari.CITY).FirstOrDefault() != null ? sehirler.Where(s => s.NAME == gelencari.CITY).FirstOrDefault().LOGICALREF : 0;
                txt_SehirKodu.Text = gelencari.CITYCODE;


                lk_ilce.EditValue = ilceler.Where(s => s.NAME == gelencari.TOWN).FirstOrDefault() != null ? ilceler.Where(s => s.NAME == gelencari.TOWN).FirstOrDefault().LOGICALREF : 0;
                txt_ilceKodu.Text = gelencari.TOWNCODE;


                lk_Mahalle.EditValue = mahalleler.Where(s => s.NAME == gelencari.DISTRICT).FirstOrDefault() != null ? mahalleler.Where(s => s.NAME == gelencari.DISTRICT).FirstOrDefault().LOGICALREF : 0;
                txt_mahalleKodu.Text = gelencari.DISTRICTCODE;


                txt_postakodu.Text = gelencari.POSTCODE;

                btn_OzelKod1.Text = gelencari.SPECODE;
                btn_OzelKod2.Text = gelencari.SPECODE2;
                btn_OzelKod3.Text = gelencari.SPECODE3;
                btn_OzelKod4.Text = gelencari.SPECODE4;
                btn_OzelKod5.Text = gelencari.SPECODE5;
                btn_TicariIslemGrubu.Text = gelencari.TRADINGGRP;
                btn_yetkiKodu.Text = gelencari.CYPHCODE;

                txtYetkili.Text = gelencari.INCHARGE;
                txtYetkili2.Text = gelencari.INCHARGE2;
                txtYetkili3.Text = gelencari.INCHARGE3;


                txtEPosta.Text = gelencari.EMAILADDR;
                txtEPosta2.Text = gelencari.EMAILADDR2;
                txtEPosta3.Text = gelencari.EMAILADDR3;


                txt_yetkilitel1.Text = gelencari.INCHTELNRS1;
                txt_yetkilitel2.Text = gelencari.INCHTELNRS2;
                txt_yetkilitel3.Text = gelencari.INCHTELNRS3;


                txt_CariTel1.Text = gelencari.TELNRS1;
                txt_CariTel2.Text = gelencari.TELNRS2;
                txt_faks.Text = gelencari.FAXNR;

                txt_VadeTakibiYapilacakGunSayisi.Text = gelencari.DUEDATECOUNT.ToString();
                txt_VadeTakibiYapilacakTutar.Text = gelencari.DUEDATELIMIT.ToString();
                cm_vadeTakibiYapildiginda.SelectedIndex = Convert.ToInt32(gelencari.DUEDATETRACK);

                string vadetakibiYapilacakIslemler = "";
                if (gelencari.DUEDATECONTROL2 == 1)
                {
                    vadetakibiYapilacakIslemler += "2,";
                }
                if (gelencari.DUEDATECONTROL3 == 1)
                {
                    vadetakibiYapilacakIslemler += "3,";
                }
                if (gelencari.DUEDATECONTROL4 == 1)
                {
                    vadetakibiYapilacakIslemler += "4,";
                }
                if (gelencari.DUEDATECONTROL5 == 1)
                {
                    vadetakibiYapilacakIslemler += "5,";
                }
                if (gelencari.DUEDATECONTROL6 == 1)
                {
                    vadetakibiYapilacakIslemler += "6,";
                }
                if (gelencari.DUEDATECONTROL7 == 1)
                {
                    vadetakibiYapilacakIslemler += "7,";
                }
                if (vadetakibiYapilacakIslemler.Length > 0)
                {
                    vadetakibiYapilacakIslemler = vadetakibiYapilacakIslemler.Substring(0, vadetakibiYapilacakIslemler.Length - 1);
                }
                cm_VadeTakibiYapilacakIslemler.EditValue = vadetakibiYapilacakIslemler;



                ckSahis.Checked = Convert.ToBoolean(gelencari.ISPERSCOMP);
                txtTcNo.Text = gelencari.TCKNO;
                txtAdi.Text = gelencari.NAME;
                txtSoyadi.Text = gelencari.SURNAME;

                btn_VergiDairesi.Text = gelencari.TAXOFFICE;
                btn_VergiDairesiKodu.Text = gelencari.TAXOFFCODE;
                txtVn.Text = gelencari.TAXNR;

                ckEFatura.Checked = Convert.ToBoolean(gelencari.ACCEPTEINV);
                txtGelenPosta.Text = gelencari.POSTLABELCODE;
                txtGidenPosta.Text = gelencari.SENDERLABELCODE;
                LG_EMUHACC muhasebe = islem.cariMuhasebeBilgi(firma, donem, gelencari.LOGICALREF);

                if (muhasebe != null)
                {
                    txt_MuhasebeKodu.Text = muhasebe.CODE;
                }
                LG_CLRNUMS cariRiskBilgi = islem.CariRiskBilgileriGetir(gelencari.LOGICALREF);
                if (cariRiskBilgi != null)
                {
                    cm_acikhesap.SelectedIndex = Convert.ToInt32(cariRiskBilgi.ACCRISKOVER);
                    cm_kendiceksenet.SelectedIndex = Convert.ToInt32(cariRiskBilgi.MYCSRISKOVER);
                    cm_mustericeksenet.SelectedIndex = Convert.ToInt32(cariRiskBilgi.CSTCSRISKOVER);
                    cm_ciroceksenet.SelectedIndex = Convert.ToInt32(cariRiskBilgi.CSTCSCIRORISKOVER);
                    cm_siparis.SelectedIndex = Convert.ToInt32(cariRiskBilgi.ORDRISKOVER);
                    cm_siparisoneri.SelectedIndex = Convert.ToInt32(cariRiskBilgi.ORDRISKOVERSUGG);
                    cm_irsaliye.SelectedIndex = Convert.ToInt32(cariRiskBilgi.DESPRISKOVER);
                    cm_irsaliyeoneri.SelectedIndex = Convert.ToInt32(cariRiskBilgi.DESPRISKOVERSUG);

                    txt_acikhesaplimit.Text = cariRiskBilgi.ACCRISKLIMIT.ToString();
                    txt_ciroCekSenetLiimti.Text = cariRiskBilgi.CSTCSCIRORISKLIMIT.ToString();
                    txt_IrsaliyeLimit.Text = cariRiskBilgi.DESPRISKLIMIT.ToString();
                    txt_IrsaliyeOneriLimit.Text = cariRiskBilgi.DESPRISKLIMITSUG.ToString();
                    txt_kendiCeksenetLimit.Text = cariRiskBilgi.MYCSRISKLIMIT.ToString();
                    txt_musteriCekSenetLimit.Text = cariRiskBilgi.CSTCSRISKLIMIT.ToString();
                    txt_siparisLimit.Text = cariRiskBilgi.ORDRISKLIMIT.ToString();
                    txt_SiparisOneriLimiti.Text = cariRiskBilgi.ORDRISKLIMITSUGG.ToString();



                    ck_acikHesap.Checked = Convert.ToBoolean(cariRiskBilgi.RISKTYPE);
                    ck_KendiCekSenet.Checked = Convert.ToBoolean(cariRiskBilgi.RISKTYPES2);
                    ck_musteriCekSenet.Checked = Convert.ToBoolean(cariRiskBilgi.RISKTYPES3);
                    ck_Irsaliyede.Checked = Convert.ToBoolean(cariRiskBilgi.RISKTYPES4);
                    ck_Sipariste.Checked = Convert.ToBoolean(cariRiskBilgi.RISKTYPES5);
                    ck_OneriSipariste.Checked = Convert.ToBoolean(cariRiskBilgi.RISKTYPES6);
                    ck_CiroCekSenet.Checked = Convert.ToBoolean(cariRiskBilgi.RISKTYPES7);
                    ck_OneriIrsaliyede.Checked = Convert.ToBoolean(cariRiskBilgi.RISKTYPES8);
                }
                if (gelencari.PAYMENTREF > 0)
                {
                    LG_PAYPLANS odemeBilgi = islem.OdemeBilgiGetir(firma, Convert.ToInt32(gelencari.PAYMENTREF));
                    if (odemeBilgi != null)
                    {
                        txt_OdemePlanKodu.Text = odemeBilgi.CODE;
                        txt_OdemePlanAciklama.Text = odemeBilgi.DEFINITION_;
                    }
                }

            }
        }
        private void btn_TicariIslemGrubu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.TicariIslemGruplariAc(this);
        }
        private void btn_OzelKod1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.OzelKodListesiAc(this, 1, 1, 26, 1);
        }
        private void btn_yetkiKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.OzelKodListesiAc(this, 2, 2, 26, 0);
        }
        private void btn_OzelKod2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.OzelKodListesiAc(this, 1, 1, 26, 2);
        }
        private void btn_OzelKod3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.OzelKodListesiAc(this, 1, 1, 26, 3);
        }
        private void btn_OzelKod4_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.OzelKodListesiAc(this, 1, 1, 26, 4);
        }
        private void lk_Ulke_EditValueChanged(object sender, EventArgs e)
        {
            if (lk_Ulke.EditValue != null)
            {
                if (lk_Ulke.EditValue.ToString() != "Seçiniz")
                {
                    txt_UlkeKodu.Text = "";
                    txt_SehirKodu.Text = "";
                    txt_ilceKodu.Text = "";
                    txt_mahalleKodu.Text = "";
                    txt_postakodu.Text = "";
                    int ulkeref = Convert.ToInt32(lk_Ulke.EditValue);
                    var varmi = ulkeler.Where(s => s.LOGICALREF == ulkeref).FirstOrDefault();
                    if (varmi != null)
                    {
                        txt_UlkeKodu.Text = varmi.CODE;
                    }
                    islem.SehirListesiDoldur(lk_sehir, ulkeref);
                    lk_sehir.EditValue = null;
                    lk_ilce.EditValue = null;
                    lk_ilce.Properties.DataSource = null;
                    lk_Mahalle.EditValue = null;
                    lk_Mahalle.Properties.DataSource = null;
                }
            }
            else
            {
                txt_UlkeKodu.Text = "";
                txt_SehirKodu.Text = "";
                txt_ilceKodu.Text = "";
                txt_mahalleKodu.Text = "";
                txt_postakodu.Text = "";
            }
        }

        private void lk_sehir_EditValueChanged(object sender, EventArgs e)
        {
            if (lk_sehir.EditValue != null)
            {
                if (lk_sehir.EditValue.ToString() != "Seçiniz" && lk_sehir.EditValue.ToString() != "")
                {
                    txt_SehirKodu.Text = "";
                    txt_ilceKodu.Text = "";
                    txt_mahalleKodu.Text = "";
                    txt_postakodu.Text = "";
                    int ulkeref = Convert.ToInt32(lk_Ulke.EditValue);
                    int sehirref = Convert.ToInt32(lk_sehir.EditValue);
                    var varmi = sehirler.Where(s => s.LOGICALREF == sehirref).FirstOrDefault();
                    if (varmi != null)
                    {
                        txt_SehirKodu.Text = varmi.CODE;
                    }

                    islem.IlceListesiDoldur(lk_ilce, ulkeref, sehirref);
                    lk_ilce.EditValue = null;
                    lk_Mahalle.EditValue = null;
                    lk_Mahalle.Properties.DataSource = null;
                }
            }
            else
            {
                txt_SehirKodu.Text = "";
                txt_ilceKodu.Text = "";
                txt_mahalleKodu.Text = "";
                txt_postakodu.Text = "";
            }
        }

        private void lk_ilce_EditValueChanged(object sender, EventArgs e)
        {
            if (lk_ilce.EditValue != null)
            {
                if (lk_ilce.EditValue.ToString() != "Seçiniz")
                {
                    txt_ilceKodu.Text = "";
                    txt_mahalleKodu.Text = "";
                    txt_postakodu.Text = "";
                    int ilceref = Convert.ToInt32(lk_ilce.EditValue);
                    islem.MahalleListesiDoldur(lk_Mahalle, ilceref);
                    var varmi = ilceler.Where(s => s.LOGICALREF == ilceref).FirstOrDefault();
                    if (varmi != null)
                    {
                        txt_ilceKodu.Text = varmi.CODE;
                    }


                }
            }
            else
            {
                txt_ilceKodu.Text = "";
                txt_mahalleKodu.Text = "";
                txt_postakodu.Text = "";
            }
        }

        private void lk_Mahalle_EditValueChanged(object sender, EventArgs e)
        {
            if (lk_Mahalle.EditValue != null)
            {
                if (lk_Mahalle.EditValue.ToString() != "Seçiniz")
                {
                    txt_mahalleKodu.Text = "";
                    int mahalleref = Convert.ToInt32(lk_Mahalle.EditValue);
                    var varmi = mahalleler.Where(s => s.LOGICALREF == mahalleref).FirstOrDefault();
                    if (varmi != null)
                    {
                        txt_mahalleKodu.Text = varmi.CODE;
                        txt_postakodu.Text = varmi.POSTCODE;
                    }
                    else
                    {
                        txt_postakodu.Text = "";
                    }


                }
            }
            else
            {
                txt_mahalleKodu.Text = "";
                txt_postakodu.Text = "";
            }
        }

        private void txt_OdemePlanKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.OdemeTipiAc(this);
        }

        private void btn_VergiDairesi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmVergiDaireleri frm = new frmVergiDaireleri(this);
            frm.ShowDialog();
        }

        private void btn_VergiDairesiKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmVergiDaireleri frm = new frmVergiDaireleri(this);
            frm.ShowDialog();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTcNo.Text))
            {
                XtraMessageBox.Show("TcNo Boş Bırakılamaz! ");
                return;
            }
            var sor = islem.CariSorgula(ana.parametre, 2, txtTcNo.Text);
            if (sor.sonuc == false)
            {
                XtraMessageBox.Show(sor.sonucAciklama, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                txtAdi.Text = sor.adi ?? "";
                txtSoyadi.Text = sor.soyadi ?? "";
                btn_VergiDairesi.Text = sor.vergiDairesiAdi ?? "";
                txtVn.Text = sor.vKN ?? "";
                txtUnvan.Text = sor.unvan ?? txtAdi.Text + " " + txtSoyadi.Text;
                if (sor.ikametgahAdresi != null)
                {
                    txtAdres.Text = sor.ikametgahAdresi.mahalleSemt ?? "" +
                        " " + sor.ikametgahAdresi.caddeSokak ?? "" +
                        " Kapı No:" + sor.ikametgahAdresi.kapiNO ?? "" +
                        " Daire No:" + sor.ikametgahAdresi.daireNO ?? "";

                    lk_ilce.Text = sor.ikametgahAdresi.ilceAdi ?? "";
                    lk_sehir.Text = sor.ikametgahAdresi.ilAdi ?? "";
                }
                simpleButton4_Click(sender, e);
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVn.Text))
            {
                XtraMessageBox.Show("Vergi No Boş Bırakılamaz! ");
                return;
            }

            var sor = islem.CariSorgula(ana.parametre, 1, txtVn.Text);
            if (sor.sonuc == true)
            {
                txtAdi.Text = sor.adi ?? "";
                txtSoyadi.Text = sor.soyadi ?? "";
                //txtb.Text = sor.babaAdi;
                btn_VergiDairesi.Text = sor.vergiDairesiAdi ?? "";
                txtVn.Text = sor.vKN ?? "";
                txtUnvan.Text = sor.unvan ?? txtAdi.Text + " " + txtSoyadi.Text;
                if (sor.ikametgahAdresi != null)
                {
                    txtAdres.Text = sor.ikametgahAdresi.mahalleSemt + " " + sor.ikametgahAdresi.caddeSokak + " Kapı No:" + sor.ikametgahAdresi.kapiNO + " Daire No:" + sor.ikametgahAdresi.daireNO;
                    lk_Ulke.EditValue = ulkeler.Where(s => s.CODE == "TR").FirstOrDefault() != null ? ulkeler.Where(s => s.CODE == "TR").FirstOrDefault().LOGICALREF : 0;
                    lk_sehir.EditValue = sehirler.Where(s => s.NAME.ToUpper() == sor.ikametgahAdresi.ilAdi.ToUpper()).FirstOrDefault() != null ? sehirler.Where(s => s.NAME.ToUpper() == sor.ikametgahAdresi.ilAdi.ToUpper()).FirstOrDefault().LOGICALREF : 0;
                    lk_ilce.EditValue = ilceler.Where(s => s.NAME.ToUpper() == sor.ikametgahAdresi.ilceAdi.ToUpper()).FirstOrDefault() != null ? ilceler.Where(s => s.NAME.ToUpper() == sor.ikametgahAdresi.ilceAdi.ToUpper()).FirstOrDefault().LOGICALREF : 0;
                    lk_Mahalle.EditValue = mahalleler.Where(s => s.NAME.ToUpper() == sor.ikametgahAdresi.mahalleSemt.ToUpper()).FirstOrDefault() != null ? mahalleler.Where(s => s.NAME.ToUpper() == sor.ikametgahAdresi.mahalleSemt.ToUpper()).FirstOrDefault().LOGICALREF : 0;
                }


                simpleButton4_Click(sender, e);
            }
            else
            {
                XtraMessageBox.Show(sor.sonucAciklama, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        EfaturaKontrol fat = new EfaturaKontrol();
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            fat.firmano = firma;
            fat.donemno = donem;
            fat.baglan();
            string sorgula;
            if (ckSahis.Checked)
            {
                sorgula = txtTcNo.Text;
            }
            else
            {
                sorgula = txtVn.Text;
            }

            var donen = fat.Giris(sorgula);
            if (donen.dolumu == true)
            {
                if (donen.EFatura == true)
                {
                    ckEFatura.Checked = donen.EFatura;
                    txtGelenPosta.Text = donen.GelenPosta;
                    txtGidenPosta.Text = donen.GelenPosta;
                }
                else
                {
                    ckEFatura.Checked = false;
                    txtGelenPosta.Text = "";
                    txtGidenPosta.Text = "";
                    XtraMessageBox.Show("E-FATURA MÜKELLEFİ DEĞİLDİR!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                ckEFatura.Checked = false;
                txtGelenPosta.Text = "";
                txtGidenPosta.Text = "";
                XtraMessageBox.Show("E-FATURA MÜKELLEFİ DEĞİLDİR!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmCariKartEkle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                simpleButton1_Click(sender, e);
            }
            if (e.KeyCode == Keys.F2)
            {
                simpleButton2_Click(sender, e);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCariKodu.Text))
            {
                XtraMessageBox.Show("Cari Kodu Olmadan Kayıt Ekleyemezsiniz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCariKodu.Focus();
                return;
            }
            if (ckSahis.Checked)
            {
                if (txtTcNo.Text == "" || txtTcNo.Text.Length < 11)
                {
                    XtraMessageBox.Show("TCK NO GİRİNİZ !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (txtAdi.Text == "")
                {
                    XtraMessageBox.Show("AD GİRİNİZ !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (txtSoyadi.Text == "")
                {
                    XtraMessageBox.Show("SOYADI GİRİNİZ !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if (!ckSahis.Checked)
            {
                if (btn_VergiDairesi.Text == "")
                {
                    XtraMessageBox.Show("VERGİ DAİRESİ GİRİNİZ !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (txtVn.Text == "" || txtVn.Text.Length < 10)
                {
                    XtraMessageBox.Show("VERGİ NO GİRİNİZ !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            int tip = 0;
            if (cm_caritipi.SelectedIndex == 0)
            {
                tip = 3;
            }
            else if (cm_caritipi.SelectedIndex == 1)
            {
                tip = 1;
            }
            else
            {
                tip = 2;
            }

            using (LogoContext db = new LogoContext())
            {
                var parametreler = db.LOGO_XERO_PARAMETRELER.Where(s => s.FIRMANO == firma && s.DONEMNO == donem).FirstOrDefault();
                if (parametreler != null)
                {
                    bool ozelKod1 = (bool)parametreler.ZC_OZELKOD1;
                    bool ozelKod2 = (bool)parametreler.ZC_OZELKOD2;
                    bool ozelKod3 = (bool)parametreler.ZC_OZELKOD3;
                    bool ozelKod4 = (bool)parametreler.ZC_OZELKOD4;
                    bool ozelKod5 = (bool)parametreler.ZC_OZELKOD5;
                    bool odemePlaniVade = (bool)parametreler.ZC_ODEMEPLANI_VADE;
                    bool ePosta1 = (bool)parametreler.ZC_EPOSTA1;
                    bool ePosta2 = (bool)parametreler.ZC_EPOSTA2;
                    bool ePosta3 = (bool)parametreler.ZC_EPOSTA3;
                    bool ticariIslemGrubu = (bool)parametreler.ZC_TICARIISLEMGRUBU;
                    bool muhasebeKodu = (bool)parametreler.ZC_MUHASEBEKODU;

                    if (ozelKod1 && string.IsNullOrEmpty(btn_OzelKod1.Text))
                    {
                        XtraMessageBox.Show("ÖZEL KOD 1 ALANI ZORUNLU ALAN !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btn_OzelKod1.Focus();
                        return;
                    }

                    if (ozelKod2 && string.IsNullOrEmpty(btn_OzelKod2.Text))
                    {
                        XtraMessageBox.Show("ÖZEL KOD 2 ALANI ZORUNLU ALAN !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btn_OzelKod2.Focus();
                        return;
                    }

                    if (ozelKod3 && string.IsNullOrEmpty(btn_OzelKod3.Text))
                    {
                        XtraMessageBox.Show("ÖZEL KOD 3 ALANI ZORUNLU ALAN !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btn_OzelKod3.Focus();
                        return;
                    }

                    if (ozelKod4 && string.IsNullOrEmpty(btn_OzelKod4.Text))
                    {
                        XtraMessageBox.Show("ÖZEL KOD 4 ALANI ZORUNLU ALAN !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btn_OzelKod4.Focus();
                        return;
                    }

                    if (ozelKod5 && string.IsNullOrEmpty(btn_OzelKod5.Text))
                    {
                        XtraMessageBox.Show("ÖZEL KOD 5 ALANI ZORUNLU ALAN !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btn_OzelKod5.Focus();
                        return;
                    }

                    if (odemePlaniVade && string.IsNullOrEmpty(txt_OdemePlanKodu.Text))
                    {
                        XtraMessageBox.Show("ÖDEME PLANI ALANI ZORUNLU ALAN !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txt_OdemePlanKodu.Focus();
                        return;
                    }

                    if (ePosta1 && string.IsNullOrEmpty(txtEPosta.Text))
                    {
                        XtraMessageBox.Show("E-POSTA 1 ALANI ZORUNLU ALAN !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtEPosta.Focus();
                        return;
                    }

                    if (ePosta2 && string.IsNullOrEmpty(txtEPosta2.Text))
                    {
                        XtraMessageBox.Show("E-POSTA 2 ALANI ZORUNLU ALAN !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtEPosta2.Focus();
                        return;
                    }

                    if (ePosta3 && string.IsNullOrEmpty(txtEPosta3.Text))
                    {
                        XtraMessageBox.Show("E-POSTA 3 ALANI ZORUNLU ALAN !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtEPosta3.Focus();
                        return;
                    }

                    if (ticariIslemGrubu && string.IsNullOrEmpty(btn_TicariIslemGrubu.Text))
                    {
                        XtraMessageBox.Show("TİCARİ İŞLEM GRUBU ALANI ZORUNLU ALAN !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btn_TicariIslemGrubu.Focus();
                        return;
                    }

                    if (muhasebeKodu && string.IsNullOrEmpty(txt_MuhasebeKodu.Text))
                    {
                        XtraMessageBox.Show("MUHASEBE KODU ALANI ZORUNLU ALAN !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txt_MuhasebeKodu.Focus();
                        return;
                    }
                }
            }

            Logo.CARI.Root cari = new Logo.CARI.Root();
            cari.INTERNAL_REFERENCE = cariReferans;
            cari.ACCOUNT_TYPE = tip;
            cari.CODE = txtCariKodu.Text;
            cari.TITLE = txtUnvan.Text;
            cari.AUXIL_CODE = btn_OzelKod1.Text;
            cari.AUXIL_CODE2 = btn_OzelKod2.Text;
            cari.AUXIL_CODE3 = btn_OzelKod3.Text;
            cari.AUXIL_CODE4 = btn_OzelKod4.Text;
            cari.AUXIL_CODE5 = btn_OzelKod5.Text;
            cari.TRADING_GRP = btn_TicariIslemGrubu.Text;
            cari.AUTH_CODE = btn_yetkiKodu.Text;
            cari.PAYMENT_CODE = txt_OdemePlanKodu.Text;
            cari.ADDRESS1 = txtAdres.Text;
            cari.ADDRESS2 = txtAdres2.Text;
            cari.COUNTRY_CODE = txt_UlkeKodu.Text;
            cari.COUNTRY = lk_Ulke.Text;
            cari.CITY_CODE = txt_SehirKodu.Text;
            cari.CITY = lk_sehir.Text;
            cari.TOWN_CODE = txt_ilceKodu.Text;
            cari.TOWN = lk_ilce.Text;
            cari.DISTRICT_CODE = txt_mahalleKodu.Text;
            cari.DISTRICT = lk_Mahalle.Text;
            cari.POSTAL_CODE = txt_postakodu.Text;

            cari.CONTACT = txtYetkili.Text;
            cari.CONTACT2 = txtYetkili2.Text;
            cari.CONTACT3 = txtYetkili3.Text;
            cari.E_MAIL = txtEPosta.Text;
            cari.E_MAIL2 = txtEPosta2.Text;
            cari.E_MAIL3 = txtEPosta3.Text;
            cari.CONTACT1_TEL = txt_yetkilitel1.Text;
            cari.CONTACT2_TEL = txt_yetkilitel2.Text;
            cari.CONTACT3_TEL = txt_yetkilitel3.Text;
            cari.TELEPHONE1 = txt_CariTel1.Text;
            cari.TELEPHONE2 = txt_CariTel2.Text;



            cari.FAX = txt_faks.Text;
            cari.PURCHBRWS = 1;
            cari.SALESBRWS = 1;
            cari.IMPBRWS = 1;
            cari.EXPBRWS = 1;
            cari.FINBRWS = 1;


            cari.RISK_TYPE1 = Convert.ToInt32(ck_acikHesap.Checked);
            cari.RISK_TYPE2 = Convert.ToInt32(ck_KendiCekSenet.Checked);
            cari.RISK_TYPE3 = Convert.ToInt32(ck_musteriCekSenet.Checked);
            cari.RISK_TYPE4 = Convert.ToInt32(ck_Irsaliyede.Checked);
            cari.RISK_TYPE5 = Convert.ToInt32(ck_Sipariste.Checked);
            cari.RISK_TYPE6 = Convert.ToInt32(ck_OneriSipariste.Checked);
            cari.RISK_TYPE7 = Convert.ToInt32(ck_CiroCekSenet.Checked);
            cari.RISK_TYPE8 = Convert.ToInt32(ck_OneriIrsaliyede.Checked);


            cari.ACC_RISK_LIMIT = Convert.ToDouble(txt_acikhesaplimit.Text);
            cari.ACTION_CREDHOLD_ACC = cm_acikhesap.SelectedIndex;

            cari.MY_CS_RISK_LIMIT = Convert.ToDouble(txt_kendiCeksenetLimit.Text);
            cari.ACTION_CREDHOLD_MY_CS = cm_kendiceksenet.SelectedIndex;

            cari.CST_CS_RISK_LIMIT = Convert.ToDouble(txt_musteriCekSenetLimit.Text);
            cari.ACTION_CREDHOLD_CST_CS = cm_mustericeksenet.SelectedIndex;

            cari.DESP_RISK_LIMIT = Convert.ToDouble(txt_IrsaliyeLimit.Text);
            cari.ACTION_CREDHOLD_DESP = cm_irsaliye.SelectedIndex;

            cari.ORD_RISK_LIMIT = Convert.ToDouble(txt_siparisLimit.Text);
            cari.ACTION_CREDHOLD_ORD = cm_siparis.SelectedIndex;

            cari.CST_CS_CIRO_RISK_LIMIT = Convert.ToDouble(txt_ciroCekSenetLiimti.Text);
            cari.CST_CS_CIRO_RISK_OVER = cm_ciroceksenet.SelectedIndex;

            cari.DESP_RISK_LIMIT_SUGG = Convert.ToDouble(txt_IrsaliyeOneriLimit.Text);
            cari.DESP_RISK_OVER_SUGG = cm_irsaliyeoneri.SelectedIndex;

            cari.ORD_RISK_LIMIT_SUGG = Convert.ToDouble(txt_SiparisOneriLimiti.Text);
            cari.ORD_RISK_OVER_SUGG = cm_siparisoneri.SelectedIndex;



            cari.DUE_DATE_COUNT = Convert.ToInt32(Convert.ToDouble(txt_VadeTakibiYapilacakGunSayisi.Text));
            cari.DUE_DATE_LIMIT = Convert.ToDouble(txt_VadeTakibiYapilacakTutar.Text);
            cari.DUE_DATE_TRACK = cm_vadeTakibiYapildiginda.SelectedIndex;


            if (cm_VadeTakibiYapilacakIslemler.EditValue.ToString().Contains("2"))
            {
                cari.DUE_DATE_CONTOL2 = 1;
            }
            else
            {
                cari.DUE_DATE_CONTOL2 = 0;
            }

            if (cm_VadeTakibiYapilacakIslemler.EditValue.ToString().Contains("3"))
            {
                cari.DUE_DATE_CONTOL3 = 1;
            }
            else
            {
                cari.DUE_DATE_CONTOL3 = 0;
            }
            if (cm_VadeTakibiYapilacakIslemler.EditValue.ToString().Contains("4"))
            {
                cari.DUE_DATE_CONTOL4 = 1;
            }
            else
            {
                cari.DUE_DATE_CONTOL4 = 0;
            }

            if (cm_VadeTakibiYapilacakIslemler.EditValue.ToString().Contains("5"))
            {
                cari.DUE_DATE_CONTOL5 = 1;
            }
            else
            {
                cari.DUE_DATE_CONTOL5 = 0;
            }
            if (cm_VadeTakibiYapilacakIslemler.EditValue.ToString().Contains("6"))
            {
                cari.DUE_DATE_CONTOL6 = 1;
            }
            else
            {
                cari.DUE_DATE_CONTOL6 = 0;
            }
            if (cm_VadeTakibiYapilacakIslemler.EditValue.ToString().Contains("7"))
            {
                cari.DUE_DATE_CONTOL7 = 1;
            }
            else
            {
                cari.DUE_DATE_CONTOL7 = 0;
            }

            cari.PERSCOMPANY = Convert.ToInt32(ckSahis.Checked);
            cari.TCKNO = txtTcNo.Text;
            cari.NAME = txtAdi.Text;
            cari.SURNAME = txtSoyadi.Text;
            cari.TAX_OFFICE = btn_VergiDairesi.Text;
            cari.TAX_OFFICE_CODE = btn_VergiDairesiKodu.Text;
            cari.TAX_ID = txtVn.Text;
            cari.ACCEPT_EINV = Convert.ToInt32(ckEFatura.Checked);
            cari.POST_LABEL = txtGelenPosta.Text;
            cari.SENDER_LABEL = txtGidenPosta.Text;
            cari.GL_CODE = txt_MuhasebeKodu.Text;

            if (cariReferans == 0)
            {
                cari.DATE_CREATED = DateTime.Now;
                cari.HOUR_CREATED = DateTime.Now.Hour;
                cari.MIN_CREATED = DateTime.Now.Minute;
                cari.SEC_CREATED = DateTime.Now.Second;
            }
            else
            {
                cari.DATE_MODIFIED = DateTime.Now;
                cari.HOUR_MODIFIED = DateTime.Now.Hour;
                cari.MIN_MODIFIED = DateTime.Now.Minute;
                cari.SEC_MODIFIED = DateTime.Now.Second;
            }

            if (ana.parametre.LOGOBAGLANTISECIMI == 1)
            {
                if (string.IsNullOrWhiteSpace(ana.parametre.RESTSERVISURL) || string.IsNullOrWhiteSpace(ana.parametre.RESTSERVISKULLANICIADI) || string.IsNullOrWhiteSpace(ana.parametre.RESTSERVISSIFRE))
                {
                    XtraMessageBox.Show("Rest Servis Ayarları Eksik ! Sistem Parametrelerinden Rest Servis Alanlarını Girip Programı Yeniden Başlatınız !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string[] sonuc = new string[3];
                try
                {
                v:
                    var request = new RestRequest(RestSharp.Method.POST);
                    var client1 = new RestClient(ana.parametre.RESTSERVISURL + "/api/v1/Arps");
                    if (cariReferans > 0)
                    {
                        client1 = new RestClient(ana.parametre.RESTSERVISURL + "/api/v1/Arps/" + cariReferans);
                        request = new RestRequest(RestSharp.Method.PUT);
                    }
                    client1.Timeout = -1;
                    string jbody = Newtonsoft.Json.JsonConvert.SerializeObject(cari);
                    request.AddHeader("Authorization", $@"Bearer {ana.parametre.RESTSERVISTOKEN}");
                    request.AddParameter("application/json", jbody, ParameterType.RequestBody);
                    try
                    {
                        IRestResponse response = client1.Execute(request);
                        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        {
                            string tok = islem.tokenAl(ana.parametre, firma);
                            ana.parametre.RESTSERVISTOKEN = tok;
                            goto v;
                        }
                        if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                        {
                            Obje.Hata.Root sonuc1 = Newtonsoft.Json.JsonConvert.DeserializeObject<Obje.Hata.Root>(response.Content);
                            string mesaj = "";
                            if (sonuc1.ModelState.ValError0 != null)
                            {
                                if (sonuc1.ModelState.ValError0.Count > 0)
                                {
                                    mesaj += string.Join(",", sonuc1.ModelState.ValError0);
                                }
                            }
                            if (sonuc1.ModelState.ValError1 != null)
                            {
                                if (sonuc1.ModelState.ValError1.Count > 0)
                                {
                                    mesaj += string.Join(",", sonuc1.ModelState.ValError1);
                                }
                            }
                            if (sonuc1.ModelState.LOError != null)
                            {
                                if (sonuc1.ModelState.LOError.Count > 0)
                                {
                                    mesaj += string.Join(",", sonuc1.ModelState.LOError);
                                }
                            }
                            if (sonuc1.ModelState.ValError2 != null)
                            {
                                if (sonuc1.ModelState.ValError2.Count > 0)
                                {
                                    mesaj += string.Join(",", sonuc1.ModelState.ValError2);
                                }
                            }
                            if (sonuc1.ModelState.ValError3 != null)
                            {
                                if (sonuc1.ModelState.ValError3.Count > 0)
                                {
                                    mesaj += string.Join(",", sonuc1.ModelState.ValError3);
                                }
                            }
                            if (sonuc1.ModelState.ValError4 != null)
                            {
                                if (sonuc1.ModelState.ValError4.Count > 0)
                                {
                                    mesaj += string.Join(",", sonuc1.ModelState.ValError4);
                                }
                            }
                            if (sonuc1.ModelState.ValError5 != null)
                            {
                                if (sonuc1.ModelState.ValError5.Count > 0)
                                {
                                    mesaj += string.Join(",", sonuc1.ModelState.ValError5);
                                }
                            }
                            if (sonuc1.ModelState.OtherError != null)
                            {
                                if (sonuc1.ModelState.OtherError.Count > 0)
                                {
                                    mesaj += string.Join(",", sonuc1.ModelState.OtherError);
                                }
                            }
                            if (sonuc1.ModelState.DBError != null)
                            {
                                if (sonuc1.ModelState.DBError.Count > 0)
                                {
                                    mesaj += string.Join(",", sonuc1.ModelState.DBError);
                                }
                            }
                            XtraMessageBox.Show("Hata : " + mesaj, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            Obje.Basarili.Rootobject sonuc1 = Newtonsoft.Json.JsonConvert.DeserializeObject<Obje.Basarili.Rootobject>(response.Content);

                            int cariref = Convert.ToInt32(sonuc1.INTERNAL_REFERENCE);
                            cariReferans = cariref;
                            btn_IstihabatBilgisi.Visible = true;
                            XtraMessageBox.Show("İşlem Başarılı !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        }
                        if (response.StatusCode == 0)
                        {

                            XtraMessageBox.Show("Hata : " + response.ErrorMessage, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Kayıt Başarısız ! Hata= " + ex.ToString());
                    }


                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Kayıt Başarısız ! Hata=!" + ex.Message.ToString());

                    return;

                }

            }
            else if (ana.parametre.LOGOBAGLANTISECIMI == 2)
            {
                if (string.IsNullOrWhiteSpace(ana.parametre.OBJEKULLANICIADI) || string.IsNullOrWhiteSpace(ana.parametre.OBJEKULLANICISIFRE))
                {
                    XtraMessageBox.Show("Obje Kullanıcı Adı Şifre Boş ! Sistem Parametrelerinden Logo Obje Kullanıcı Adı-Şifre Bilgilerini Girip Programı Yeniden Başlatınız !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                LogoObjeAktar obje = new LogoObjeAktar(ana.parametre);


                string[] sonuc;
                if (cariReferans > 0)
                {
                    sonuc = obje.CariKartiDuzenle(cari);
                }
                else
                {
                    sonuc = obje.CariKartiEkle(cari);
                }
                if (sonuc[0] == "true")
                {
                    int cariref = Convert.ToInt32(sonuc[1]);
                    cariReferans = cariref;
                    btn_IstihabatBilgisi.Visible = true;
                    XtraMessageBox.Show("İşlem Başarılı !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
                else
                {
                    XtraMessageBox.Show("Hata : " + sonuc[0].ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            else
            {
                XtraMessageBox.Show("Logo Bağlantı Ayarı Yapılmamış ! Sistem Parametrelerinden Logo Bağlantı Seçimi Ayarını Düzenleyiniz ! Programı Tekrar Başlatınız ! ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btn_IstihabatBilgisi_Click(object sender, EventArgs e)
        {
            frmIstihbaratBilgileri frm = new frmIstihbaratBilgileri();
            frm.cariref = cariReferans;
            frm.ShowDialog();
        }

        private void btn_MuhasebeKodu_Click(object sender, EventArgs e)
        {
            frmCariMuhasebeKodlari frm = new frmCariMuhasebeKodlari(this);
            frm.ShowDialog();
        }

        private void txtCariKodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtCariKodu.Text))
                {
                    txtSonCariKodu.Text = "";
                    return;
                }
                using (LogoContext db = new LogoContext())
                {
                    if (txtCariKodu.Text != "*")
                    {
                        string sql1 = $@"SELECT TOP 1 CODE FROM LG_{firma}_CLCARD WHERE CODE LIKE '{txtCariKodu.Text}%' ORDER BY CODE DESC";
                        var sonuc1 = db.Database.SqlQuery<string>(sql1).FirstOrDefault();
                        if (sonuc1 != null)
                        {
                            txtSonCariKodu.Text = sonuc1;
                        }
                        else
                        {
                            txtSonCariKodu.Text = "Serbest giriş algılandı!";
                        }
                    }
                    else
                    {
                        string sql2 = $@"SELECT MAX(CAST(CODE AS INT)) FROM LG_{firma}_CLCARD WHERE ISNUMERIC(CODE)>0 AND ACTIVE=0";
                        var sonuc2 = db.Database.SqlQuery<int>(sql2).FirstOrDefault();

                        if (sonuc2 != 0)
                        {
                            int kod;
                            txtSonCariKodu.Text = sonuc2.ToString();

                            if (!string.IsNullOrEmpty(txtSonCariKodu.Text))
                            {
                                kod = Convert.ToInt32(txtSonCariKodu.Text);
                                kod++;
                                txtCariKodu.Text = kod.ToString();
                            }
                            else
                            {
                                txtSonCariKodu.Text = "Serbest giriş algılandı!";
                            }
                        }
                        else
                        {
                            txtSonCariKodu.Text = "Serbest giriş algılandı!";
                        }
                    }
                }
            }
        }

        private void btn_OzelKod5_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.OzelKodListesiAc(this, 1, 1, 26, 5);
        }
    }
}