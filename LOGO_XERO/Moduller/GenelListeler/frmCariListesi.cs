using DevExpress.Data.Async.Helpers;
using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using LOGO_XERO.Models.LOGO_XERO_M;
using LOGO_XERO.Moduller._7_Raporlar;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGO_XERO.Moduller.GenelListeler
{
    public partial class frmCariListesi : DevExpress.XtraEditors.XtraForm
    {
        frmAnaForm ana;
        string firma;
        Islemler islem = new Islemler();
        public int tip = 0; //tip 1 ise cari seçimi 2 ise sevkiyat hesabi seçimi
        public string kod;
        public bool rpmi = false;
        frmTeklifOlustur frmTeklifOlustur;
        //frmSiparisOlustur _frmSiparisOlustur;
        //frmIrsaliyeOlustur _frmIrsaliyeOlustur;
        //frmFaturaOlustur _frmFaturaOlustur;

        public frmCariListesi(frmTeklifOlustur _frmTeklifOlustur)
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            firma = ana.lk_firma.EditValue.ToString();
            frmTeklifOlustur = _frmTeklifOlustur;
          
            this.entityInstantFeedbackSource2.GetQueryable += entityInstantFeedbackSource2_GetQueryable;
            this.entityInstantFeedbackSource2.DismissQueryable += entityInstantFeedbackSource2_DismissQueryable;
        }

        private void frmCariListesi_Load(object sender, EventArgs e)
        {
            F10IleCariAra();
        }

        private void grid_CariListesi_DoubleClick(object sender, EventArgs e)
        {
            ReadonlyThreadSafeProxyForObjectFromAnotherThread secilmis = (ReadonlyThreadSafeProxyForObjectFromAnotherThread)gv_CariListesi.GetRow(gv_CariListesi.FocusedRowHandle);
            if (secilmis != null)
            {
                LOGO_XERO_CARILISTE cari = (LOGO_XERO_CARILISTE)secilmis.OriginalRow;
                if (cari != null)
                {
                    if (frmTeklifOlustur != null)
                    {
                        if (frmTeklifOlustur.Trkod == 1 && cari.CARDTYPE == 1)
                        {
                            XtraMessageBox.Show("Girmiş Olduğunuz Cariye Satınalma Teklifi Girilemez! Lütfen Modülü Satış Teklifi Olarak Değiştiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        if (frmTeklifOlustur.Trkod == 8 && cari.CARDTYPE == 2)
                        {
                            XtraMessageBox.Show("Girmiş Olduğunuz Cariye Satış Teklifi Girilemez! Lütfen Modülü Satınalma Teklifi Olarak Değiştiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        if (tip == 1)
                        {
                            if (rpmi)
                            {
                                frmTeklifOlustur.gv_TeklifSatirlari.SetFocusedRowCellValue("TALEPEDENFIRMA", cari.DEFINITION_);
                                Close();
                                return;
                            }
                            frmTeklifOlustur.lbl_cariref.Text = cari.LOGICALREF.ToString();
                            frmTeklifOlustur.btn_cariKodu.Text = cari.CODE;
                            frmTeklifOlustur.btn_cariUnvani.Text = cari.DEFINITION_;
                            frmTeklifOlustur.txt_Eposta.Text = cari.EPOSTA;
                            frmTeklifOlustur.txt_Eposta2.Text = cari.EPOSTA2;
                            frmTeklifOlustur.txt_Yetkili.Text = cari.YETKILISI;
                            frmTeklifOlustur.lk_OdemeTipi.EditValue = cari.PAYMENTREF;
                            frmTeklifOlustur.txt_Adres1.Text = cari.ADRES1;
                            frmTeklifOlustur.txt_Adres2.Text = cari.ADRES2;
                            frmTeklifOlustur.txt_Ulke.Text = cari.ULKE;
                            frmTeklifOlustur.txt_Il.Text = cari.SEHIR;
                            frmTeklifOlustur.txt_Ilce.Text = cari.ILCE;
                            frmTeklifOlustur.txt_VergiDairesi.Text = cari.VERGIDAIRESI;
                            frmTeklifOlustur.txt_Telefon.Text = cari.TELEFON1;
                            frmTeklifOlustur.txt_Fax.Text = cari.FAXNR;
                            frmTeklifOlustur.txt_PostaKodu.Text = cari.POSTAKODU;
                            frmTeklifOlustur.txt_VergiNo.Text = cari.TAXNR;
                            if (cari.EFATURA == 1)
                            {
                                frmTeklifOlustur.Efatura_resim.Visible = true;
                            }
                            else
                            {
                                frmTeklifOlustur.Efatura_resim.Visible = false;
                            }
                            frmTeklifOlustur.btn_ticariIslemGuruplari.Text = cari.TICARIISLEMGURUBU;
                        }
                        if (tip == 2)
                        {
                            frmTeklifOlustur.lbl_SevkiyatHesabiRefi.Text = cari.LOGICALREF.ToString();
                            frmTeklifOlustur.btn_SevkHesabiKodu.Text = cari.CODE;
                            frmTeklifOlustur.btn_sevkiyatHesabiaciklamasi.Text = cari.DEFINITION_;
                        }
                        Close();
                    }

                    //if (_frmSiparisOlustur != null)
                    //{
                    //    if (_frmSiparisOlustur.Trkod == 1 && cari.CARDTYPE == 1)
                    //    {
                    //        XtraMessageBox.Show("Girmiş Olduğunuz Cariye Satınalma Teklifi Girilemez! Lütfen Modülü Satış Teklifi Olarak Değiştiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //        return;
                    //    }
                    //    if (_frmSiparisOlustur.Trkod == 8 && cari.CARDTYPE == 2)
                    //    {
                    //        XtraMessageBox.Show("Girmiş Olduğunuz Cariye Satış Teklifi Girilemez! Lütfen Modülü Satınalma Teklifi Olarak Değiştiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //        return;
                    //    }

                    //    if (tip == 1)
                    //    {
                    //        _frmSiparisOlustur.lbl_cariref.Text = cari.LOGICALREF.ToString();
                    //        _frmSiparisOlustur.btn_cariKodu.Text = cari.CODE;
                    //        _frmSiparisOlustur.btn_cariUnvani.Text = cari.DEFINITION_;
                    //        _frmSiparisOlustur.txt_Eposta.Text = cari.EPOSTA;
                    //        _frmSiparisOlustur.txt_Eposta2.Text = cari.EPOSTA2;
                    //        _frmSiparisOlustur.txt_Yetkili.Text = cari.YETKILISI;
                    //        _frmSiparisOlustur.lk_OdemeTipi.EditValue = cari.PAYMENTREF;
                    //        if (cari.EFATURA == 1)
                    //        {
                    //            _frmSiparisOlustur.Efatura_resim.Visible = true;
                    //        }
                    //        else
                    //        {
                    //            _frmSiparisOlustur.Efatura_resim.Visible = false;
                    //        }
                    //        _frmSiparisOlustur.btn_ticariIslemGuruplari.Text = cari.TICARIISLEMGURUBU;
                    //    }
                    //    if (tip == 2)
                    //    {
                    //        _frmSiparisOlustur.btn_SevkAdresHesapKodu.Text = cari.CODE;
                    //        _frmSiparisOlustur.btn_sevkiyatAdresiHesapAciklamasi.Text = cari.DEFINITION_;
                    //    }
                    //    Close();
                    //}

                    //if (_frmIrsaliyeOlustur != null)
                    //{
                    //    if (_frmIrsaliyeOlustur.Trkod == 1 && cari.CARDTYPE == 1)
                    //    {
                    //        XtraMessageBox.Show("Girmiş Olduğunuz Cariye Satınalma Teklifi Girilemez! Lütfen Modülü Satış Teklifi Olarak Değiştiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //        return;
                    //    }
                    //    if (_frmIrsaliyeOlustur.Trkod == 8 && cari.CARDTYPE == 2)
                    //    {
                    //        XtraMessageBox.Show("Girmiş Olduğunuz Cariye Satış Teklifi Girilemez! Lütfen Modülü Satınalma Teklifi Olarak Değiştiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //        return;
                    //    }

                    //    if (tip == 1)
                    //    {
                    //        _frmIrsaliyeOlustur.lbl_cariref.Text = cari.LOGICALREF.ToString();
                    //        _frmIrsaliyeOlustur.btn_cariKodu.Text = cari.CODE;
                    //        _frmIrsaliyeOlustur.btn_cariUnvani.Text = cari.DEFINITION_;
                    //        _frmIrsaliyeOlustur.txt_Eposta.Text = cari.EPOSTA;
                    //        _frmIrsaliyeOlustur.txt_Eposta2.Text = cari.EPOSTA2;
                    //        _frmIrsaliyeOlustur.txt_Yetkili.Text = cari.YETKILISI;
                    //        _frmIrsaliyeOlustur.lk_OdemeTipi.EditValue = cari.PAYMENTREF;
                    //        if (cari.EFATURA == 1)
                    //        {
                    //            _frmIrsaliyeOlustur.Efatura_resim.Visible = true;
                    //        }
                    //        else
                    //        {
                    //            _frmIrsaliyeOlustur.Efatura_resim.Visible = false;
                    //        }
                    //        _frmIrsaliyeOlustur.btn_ticariIslemGuruplari.Text = cari.TICARIISLEMGURUBU;
                    //    }
                    //    if (tip == 2)
                    //    {
                    //        _frmIrsaliyeOlustur.btn_SevkAdresHesapKodu.Text = cari.CODE;
                    //        _frmIrsaliyeOlustur.btn_sevkiyatAdresiHesapAciklamasi.Text = cari.DEFINITION_;
                    //    }
                    //    Close();
                    //}

                    //if (_frmFaturaOlustur != null)
                    //{
                    //    if (_frmFaturaOlustur.Trkod == 1 && cari.CARDTYPE == 1)
                    //    {
                    //        XtraMessageBox.Show("Girmiş Olduğunuz Cariye Satınalma Teklifi Girilemez! Lütfen Modülü Satış Teklifi Olarak Değiştiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //        return;
                    //    }
                    //    if (_frmFaturaOlustur.Trkod == 8 && cari.CARDTYPE == 2)
                    //    {
                    //        XtraMessageBox.Show("Girmiş Olduğunuz Cariye Satış Teklifi Girilemez! Lütfen Modülü Satınalma Teklifi Olarak Değiştiriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //        return;
                    //    }

                    //    if (tip == 1)
                    //    {
                    //        _frmFaturaOlustur.lbl_cariref.Text = cari.LOGICALREF.ToString();
                    //        _frmFaturaOlustur.btn_cariKodu.Text = cari.CODE;
                    //        _frmFaturaOlustur.btn_cariUnvani.Text = cari.DEFINITION_;
                    //        _frmFaturaOlustur.txt_Eposta.Text = cari.EPOSTA;
                    //        _frmFaturaOlustur.txt_Eposta2.Text = cari.EPOSTA2;
                    //        _frmFaturaOlustur.txt_Yetkili.Text = cari.YETKILISI;
                    //        _frmFaturaOlustur.lk_OdemeTipi.EditValue = cari.PAYMENTREF;
                    //        if (cari.EFATURA == 1)
                    //        {
                    //            _frmFaturaOlustur.Efatura_resim.Visible = true;
                    //        }
                    //        else
                    //        {
                    //            _frmFaturaOlustur.Efatura_resim.Visible = false;
                    //        }
                    //        _frmFaturaOlustur.btn_ticariIslemGuruplari.Text = cari.TICARIISLEMGURUBU;
                    //    }
                    //    if (tip == 2)
                    //    {
                    //        _frmFaturaOlustur.btn_SevkAdresHesapKodu.Text = cari.CODE;
                    //        _frmFaturaOlustur.btn_sevkiyatAdresiHesapAciklamasi.Text = cari.DEFINITION_;
                    //    }
                    //    Close();
                    //}
                }
            }
        }

        // This event is generated by Data Source Configuration Wizard
        void entityInstantFeedbackSource2_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            LOGO_XERO.Models.LogoContext dataContext = new LOGO_XERO.Models.LogoContext();
            e.QueryableSource = dataContext.LOGO_XERO_CARILISTE;
            e.Tag = dataContext;
        }

        // This event is generated by Data Source Configuration Wizard
        void entityInstantFeedbackSource2_DismissQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            // Dispose of the DataContext
            ((LOGO_XERO.Models.LogoContext)e.Tag).Dispose();
        }

        public async void F10IleCariAra()
        {
            await Task.Delay(500);
            gv_CariListesi.StartIncrementalSearch(kod);
        }

        private void cariEkstresiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gv_CariListesi.GetFocusedRow()!=null)
            {
                string carikod = gv_CariListesi.GetFocusedRowCellValue("CODE").ToString(); 
                string cariunvan = gv_CariListesi.GetFocusedRowCellValue(colDEFINITION_).ToString();  
                frmCariEkstre frmCariEkstre = new frmCariEkstre(cariunvan,carikod);
                frmCariEkstre.carikod = carikod;
                frmCariEkstre.Yenile();
                frmCariEkstre.ShowDialog();
            }
           
        }

        private void cariDövizliEkstreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCariEkstreDovizli frm = new frmCariEkstreDovizli();
            frm.txtIlk.DateTime = DateTime.Today.AddDays(-45);
            frm.txtCariKodu.Text = gv_CariListesi.GetRowCellValue(gv_CariListesi.FocusedRowHandle, "CODE").ToString();
            frm.txtUnvan.Text = gv_CariListesi.GetRowCellValue(gv_CariListesi.FocusedRowHandle, "DEFINITION_").ToString();
            frm.txtUnvan.Enabled = false;
            frm.ShowDialog();
        }
    }
}