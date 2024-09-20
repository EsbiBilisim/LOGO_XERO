using DevExpress.Data.Async.Helpers;
using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using LOGO_XERO.Models.LOGO_M;
using LOGO_XERO.Moduller._7_Raporlar.BarkodTasarım;
using LOGO_XERO.Models.LOGO_XERO_M;
using LOGO_XERO.Moduller.FiltreFormlar;
using LOGO_XERO.Moduller.Giris_AnaForm_Ayarlar;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using DevExpress.Data.ODataLinq.Helpers;
using DevExpress.XtraReports.UI;
using System.Linq;
using LOGO_XERO.Models.StokEkstresi;

namespace LOGO_XERO.Moduller.GenelListeler
{
    public partial class frmStokListesi : DevExpress.XtraEditors.XtraForm
    {
        frmAnaForm ana;
        LOGO_XERO_PARAMETRELER parametre = new LOGO_XERO_PARAMETRELER();
        Logic.GenelListeler liste = new Logic.GenelListeler();
        L_CAPIFIRM firmaLogoBilgi = new L_CAPIFIRM();
        string firma;
        string donem;
        Islemler islem = new Islemler();
        frmTeklifOlustur _frmTeklifOlustur;
        frmStokEsleme frmStokEsleme;
        public LOGO_XERO_TEKLIF_SATIR seciliTeklifSatir { get; set; }
        public LOGO_XERO_TEKLIF_SATIR seciliEslemeSatir { get; set; }
        public double miktar;
        public string kod;
        public frmStokListesi(frmTeklifOlustur frmTeklifOlustur)
        {
            InitializeComponent();
            _frmTeklifOlustur = frmTeklifOlustur;
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            parametre = ana.parametre;
            firmaLogoBilgi = ana.firmaBilgisi;
            firma = ana.lk_firma.EditValue.ToString();
            islem.TasarimGetir(gv_StokListesi, ana._Kullanici.ID, this.Name, grid_StokListesi.Name);
            this.entityInstantFeedbackSource1.GetQueryable += entityInstantFeedbackSource1_GetQueryable;
            this.entityInstantFeedbackSource1.DismissQueryable += entityInstantFeedbackSource1_DismissQueryable;
        }
        public frmStokListesi(frmStokEsleme _frmStokEsleme)
        {
            InitializeComponent();
            frmStokEsleme = _frmStokEsleme;
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            parametre = ana.parametre;
            firmaLogoBilgi = ana.firmaBilgisi;
            firma = ana.lk_firma.EditValue.ToString();
            islem.TasarimGetir(gv_StokListesi, ana._Kullanici.ID, this.Name, grid_StokListesi.Name);
            this.entityInstantFeedbackSource1.GetQueryable += entityInstantFeedbackSource1_GetQueryable;
            this.entityInstantFeedbackSource1.DismissQueryable += entityInstantFeedbackSource1_DismissQueryable;
        }
        void entityInstantFeedbackSource1_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            LOGO_XERO.Models.LogoContext dataContext = new LOGO_XERO.Models.LogoContext();
            e.QueryableSource = dataContext.LOGO_XERO_STOKLISTESI;
            e.Tag = dataContext;
        }
        void entityInstantFeedbackSource1_DismissQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            ((LOGO_XERO.Models.LogoContext)e.Tag).Dispose();
        }
        private void grid_StokListesi_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ReadonlyThreadSafeProxyForObjectFromAnotherThread secilmis = (ReadonlyThreadSafeProxyForObjectFromAnotherThread)gv_StokListesi.GetRow(gv_StokListesi.FocusedRowHandle);
                if (secilmis != null)
                {
                    LOGO_XERO_STOKLISTESI stok = (LOGO_XERO_STOKLISTESI)secilmis.OriginalRow;
                    if (stok != null)
                    {
                        if (_frmTeklifOlustur != null)
                        {
                            seciliTeklifSatir.AMBARBAKIYE = liste.UrunStokBakiyeBilgisiGetir(firma, donem, Convert.ToInt32(_frmTeklifOlustur.lk_ambar.EditValue), stok.LOGICALREF);
                            seciliTeklifSatir.STOKLOGICALREF = stok.LOGICALREF;
                            seciliTeklifSatir.STOKKODU = stok.STOKKODU;
                            seciliTeklifSatir.STOKADI = stok.STOKCINSI;
                            if (_frmTeklifOlustur.ts !=null)
                            {
                                _frmTeklifOlustur.ts.Text = stok.STOKKODU; 
                            }
                             
                            seciliTeklifSatir.FIYATGURUBU = _frmTeklifOlustur.btn_ticariIslemGuruplari.Text;
                            seciliTeklifSatir.BIRIM = stok.BIRIM;
                            seciliTeklifSatir.MARKA = stok.MARKA;
                            seciliTeklifSatir.KDV = stok.KDV;
                            seciliTeklifSatir.OZELKOD1 = stok.OZELKOD1;
                            seciliTeklifSatir.OZKODACIKLAMA = stok.OZKODACIKLAMA;
                            seciliTeklifSatir.SATIRTIPI = 0;
                            seciliTeklifSatir.TEVKIFATLI = Convert.ToBoolean(stok.TEVKIFAT);
                            if (Convert.ToBoolean(stok.TEVKIFAT))
                            {
                                seciliTeklifSatir.TEVKIFATKODU = stok.TEVKIFATKODU;
                                seciliTeklifSatir.TEVKIFATBOLEN = stok.TEVKIFATBOLEN;
                                seciliTeklifSatir.TEVKIFATCARPAN = stok.TEVKIFATCARPAN;
                            }
                            else
                            {
                                seciliTeklifSatir.TEVKIFATKODU = "";
                                seciliTeklifSatir.TEVKIFATBOLEN = 0;
                                seciliTeklifSatir.TEVKIFATCARPAN = 0;
                            }
                            seciliTeklifSatir.AMBAR = Convert.ToInt16(_frmTeklifOlustur.lk_ambar.EditValue.ToString());
                            if (ck_miktarGirisi.Checked)
                            {
                                frmMiktarGirisi frmMiktarGirisi = new frmMiktarGirisi();
                                frmMiktarGirisi.ShowDialog();

                                miktar = frmMiktarGirisi.Miktar;
                                seciliTeklifSatir.MIKTAR = frmMiktarGirisi.Miktar;
                            }
                            else
                            {
                                miktar = 1;
                                seciliTeklifSatir.MIKTAR = 1;
                            }
                            seciliTeklifSatir.ISKONTOYUZDESI1 = 0;
                            seciliTeklifSatir.ISKONTOYUZDESI2 = 0;
                            seciliTeklifSatir.ISKONTOYUZDESI3 = 0;
                            seciliTeklifSatir.ISKONTOTUTARI1 = 0;
                            seciliTeklifSatir.ISKONTOTUTARI2 = 0;
                            seciliTeklifSatir.ISKONTOTUTARI3 = 0;

                            double dovizkuru = 0;
                            double tlfiyat = 0;
                            double dovizlifiyat = 0;
                            Int16 dovizkodu = 0;
                            string doviztipi = "TL";

                            if (seciliTeklifSatir.DOVIZKURUTARIHI == null)
                            {
                                seciliTeklifSatir.DOVIZKURUTARIHI = _frmTeklifOlustur.date_tarih.DateTime;
                            }
                            if (_frmTeklifOlustur.SatirlarParaBirimi.SelectedIndex == 0 || _frmTeklifOlustur.SatirlarParaBirimi.SelectedIndex == 1)
                            {
                                Int16 raporlamaDovizi = Convert.ToInt16(_frmTeklifOlustur.lk_RaporlamaDoviz.EditValue.ToString());
                                if ((raporlamaDovizi != 0 && raporlamaDovizi != 160) && (string.IsNullOrWhiteSpace(_frmTeklifOlustur.btn_raporlamakuru.Text) || _frmTeklifOlustur.btn_raporlamakuru.Text == "0"))
                                {
                                    XtraMessageBox.Show("Raporlama Döviz Kuru Giriniz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
                                }
                                else
                                {
                                    if ((string.IsNullOrWhiteSpace(_frmTeklifOlustur.btn_raporlamakuru.Text) || _frmTeklifOlustur.btn_raporlamakuru.Text == "0"))
                                    {
                                        _frmTeklifOlustur.btn_islemkuru.Text = "1";
                                    }
                                }
                                dovizkuru = Convert.ToDouble(_frmTeklifOlustur.btn_raporlamakuru.Text);
                                dovizkodu = raporlamaDovizi;
                                if (stok.DOVIZKODU == null || stok.DOVIZKODU == 0 || stok.DOVIZKODU == 160)
                                {
                                    tlfiyat = 0;
                                    if (stok.LISTEFIYATI != null)
                                    {
                                        tlfiyat = stok.LISTEFIYATI;
                                        if (_frmTeklifOlustur.ck_kdvdahil.Checked)
                                        {
                                            if (stok.KDVDURUMU == 0)
                                            {
                                                tlfiyat = tlfiyat * (1 + Convert.ToDouble(stok.KDV) / 100);
                                            }
                                        }
                                        else
                                        {
                                            if (stok.KDVDURUMU == 1)
                                            {
                                                tlfiyat = tlfiyat / (1 + Convert.ToDouble(stok.KDV) / 100);
                                            }
                                        }
                                    }
                                    dovizlifiyat = tlfiyat / dovizkuru;
                                }
                                else
                                {
                                    if (raporlamaDovizi == stok.DOVIZKODU)
                                    {
                                        tlfiyat = stok.LISTEFIYATI * dovizkuru;
                                        dovizlifiyat = stok.LISTEFIYATI;
                                        if (_frmTeklifOlustur.ck_kdvdahil.Checked)
                                        {
                                            if (stok.KDVDURUMU == 0)
                                            {
                                                tlfiyat = (stok.LISTEFIYATI * Convert.ToDouble(seciliTeklifSatir.SATIRDOVIZKURU)) * (1 + Convert.ToDouble(stok.KDV) / 100);
                                                dovizlifiyat = (stok.LISTEFIYATI) * (1 + Convert.ToDouble(stok.KDV) / 100);
                                            }
                                        }
                                        else
                                        {
                                            if (stok.KDVDURUMU == 1)
                                            {
                                                tlfiyat = (stok.LISTEFIYATI * Convert.ToDouble(seciliTeklifSatir.SATIRDOVIZKURU)) / (1 + Convert.ToDouble(stok.KDV) / 100);
                                                dovizlifiyat = (stok.LISTEFIYATI) / (1 + Convert.ToDouble(stok.KDV) / 100);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        double dovizKuru = islem.RatesTarihDovizKuruDondur(parametre, firmaLogoBilgi, stok.DOVIZKODU, _frmTeklifOlustur.date_tarih.DateTime, firma, donem);
                                        var birimf = stok.LISTEFIYATI * dovizKuru;
                                        tlfiyat = birimf;
                                        dovizlifiyat = birimf / dovizkuru;
                                        if (_frmTeklifOlustur.ck_kdvdahil.Checked)
                                        {
                                            if (stok.KDVDURUMU == 0)
                                            {
                                                birimf = (stok.LISTEFIYATI * dovizKuru) * (1 + Convert.ToDouble(stok.KDV) / 100);
                                                tlfiyat = birimf;
                                                dovizlifiyat = birimf / dovizkuru;
                                            }
                                        }
                                        else
                                        {
                                            if (stok.KDVDURUMU == 1)
                                            {
                                                birimf = (stok.LISTEFIYATI * dovizKuru) / (1 + Convert.ToDouble(stok.KDV) / 100);
                                                tlfiyat = birimf;
                                                dovizlifiyat = birimf / dovizkuru;
                                            }
                                        }
                                    }
                                }
                            }
                            else if (_frmTeklifOlustur.SatirlarParaBirimi.SelectedIndex == 2)
                            {
                                Int16 IslemDovizKodu = Convert.ToInt16(_frmTeklifOlustur.Lk_IslemDoviz.EditValue);

                                if ((IslemDovizKodu != 0 || IslemDovizKodu != 160) && (string.IsNullOrWhiteSpace(_frmTeklifOlustur.btn_islemkuru.Text) || _frmTeklifOlustur.btn_islemkuru.Text == "0"))
                                {
                                    XtraMessageBox.Show("İşlem Döviz Kuru Giriniz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
                                }
                                else
                                {
                                    if ((string.IsNullOrWhiteSpace(_frmTeklifOlustur.btn_islemkuru.Text) || _frmTeklifOlustur.btn_islemkuru.Text == "0"))
                                    {
                                        _frmTeklifOlustur.btn_islemkuru.Text = "1";
                                    }
                                }

                                dovizkuru = Convert.ToDouble(_frmTeklifOlustur.btn_islemkuru.Text);
                                dovizkodu = IslemDovizKodu;

                                seciliTeklifSatir.SATIRDOVIZKURU = Convert.ToDouble(_frmTeklifOlustur.btn_islemkuru.Text);
                                seciliTeklifSatir.SATIRDOVIZKODU = IslemDovizKodu;
                                seciliTeklifSatir.ISLEMDOVIZKURU = Convert.ToDouble(_frmTeklifOlustur.btn_islemkuru.Text);
                                if (IslemDovizKodu == 0 || IslemDovizKodu == 160)
                                {
                                    if (stok.DOVIZKODU == 0 || stok.DOVIZKODU == 160 || stok.DOVIZKODU == null)
                                    {
                                        tlfiyat = 0;
                                        if (stok.LISTEFIYATI != null)
                                        {
                                            tlfiyat = stok.LISTEFIYATI;
                                            if (_frmTeklifOlustur.ck_kdvdahil.Checked)
                                            {
                                                if (stok.KDVDURUMU == 0)
                                                {
                                                    tlfiyat = tlfiyat * (1 + Convert.ToDouble(stok.KDV) / 100);
                                                }
                                            }
                                            else
                                            {
                                                if (stok.KDVDURUMU == 1)
                                                {
                                                    tlfiyat = tlfiyat / (1 + Convert.ToDouble(stok.KDV) / 100);
                                                }
                                            }
                                        }
                                        dovizlifiyat = tlfiyat;
                                    }
                                    else
                                    {
                                        double dovizKuru = islem.RatesTarihDovizKuruDondur(parametre, firmaLogoBilgi, stok.DOVIZKODU, Convert.ToDateTime(seciliTeklifSatir.DOVIZKURUTARIHI), firma, donem);
                                        tlfiyat = 0;
                                        tlfiyat = stok.LISTEFIYATI * dovizKuru;
                                        if (_frmTeklifOlustur.ck_kdvdahil.Checked)
                                        {
                                            if (stok.KDVDURUMU == 0)
                                            {
                                                tlfiyat = tlfiyat * (1 + Convert.ToDouble(stok.KDV) / 100);
                                            }
                                        }
                                        else
                                        {
                                            if (stok.KDVDURUMU == 1)
                                            {
                                                tlfiyat = tlfiyat / (1 + Convert.ToDouble(stok.KDV) / 100);
                                            }
                                        }
                                        dovizlifiyat = tlfiyat;
                                    }
                                }
                                else
                                {
                                    if (stok.DOVIZKODU == 0 || stok.DOVIZKODU == 160 || stok.DOVIZKODU == null)
                                    {
                                        tlfiyat = 0;
                                        if (stok.LISTEFIYATI != null)
                                        {
                                            tlfiyat = stok.LISTEFIYATI;
                                            if (_frmTeklifOlustur.ck_kdvdahil.Checked)
                                            {
                                                if (stok.KDVDURUMU == 0)
                                                {
                                                    tlfiyat = tlfiyat * (1 + Convert.ToDouble(stok.KDV) / 100);
                                                }
                                            }
                                            else
                                            {
                                                if (stok.KDVDURUMU == 1)
                                                {
                                                    tlfiyat = tlfiyat / (1 + Convert.ToDouble(stok.KDV) / 100);
                                                }
                                            }
                                        }
                                        dovizlifiyat = tlfiyat / dovizkuru;
                                    }
                                    else
                                    {
                                        if (IslemDovizKodu == stok.DOVIZKODU)
                                        {
                                            tlfiyat = stok.LISTEFIYATI * dovizkuru;
                                            dovizlifiyat = stok.LISTEFIYATI;
                                            if (_frmTeklifOlustur.ck_kdvdahil.Checked)
                                            {
                                                if (stok.KDVDURUMU == 0)
                                                {
                                                    tlfiyat = (stok.LISTEFIYATI * Convert.ToDouble(seciliTeklifSatir.SATIRDOVIZKURU)) * (1 + Convert.ToDouble(stok.KDV) / 100);
                                                    dovizlifiyat = (stok.LISTEFIYATI) * (1 + Convert.ToDouble(stok.KDV) / 100);
                                                }
                                            }
                                            else
                                            {
                                                if (stok.KDVDURUMU == 1)
                                                {
                                                    tlfiyat = (stok.LISTEFIYATI * Convert.ToDouble(seciliTeklifSatir.SATIRDOVIZKURU)) / (1 + Convert.ToDouble(stok.KDV) / 100);
                                                    dovizlifiyat = (stok.LISTEFIYATI) / (1 + Convert.ToDouble(stok.KDV) / 100);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            double dovizKuru = islem.RatesTarihDovizKuruDondur(parametre, firmaLogoBilgi, stok.DOVIZKODU, Convert.ToDateTime(seciliTeklifSatir.DOVIZKURUTARIHI), firma, donem);

                                            var birimf = stok.LISTEFIYATI * dovizKuru;
                                            tlfiyat = birimf;
                                            dovizlifiyat = birimf / dovizkuru;
                                            if (_frmTeklifOlustur.ck_kdvdahil.Checked)
                                            {
                                                if (stok.KDVDURUMU == 0)
                                                {
                                                    birimf = (stok.LISTEFIYATI * dovizKuru) * (1 + Convert.ToDouble(stok.KDV) / 100);
                                                    tlfiyat = birimf;
                                                    dovizlifiyat = birimf / dovizkuru;
                                                }
                                            }
                                            else
                                            {
                                                if (stok.KDVDURUMU == 1)
                                                {
                                                    birimf = (stok.LISTEFIYATI * dovizKuru) / (1 + Convert.ToDouble(stok.KDV) / 100);
                                                    tlfiyat = birimf;
                                                    dovizlifiyat = birimf / dovizkuru;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (stok.DOVIZKODU == 0 || stok.DOVIZKODU == 160 || stok.DOVIZKODU == null)
                                {
                                    tlfiyat = 0;
                                    if (stok.LISTEFIYATI != null)
                                    {
                                        tlfiyat = stok.LISTEFIYATI;
                                        if (_frmTeklifOlustur.ck_kdvdahil.Checked)
                                        {
                                            if (stok.KDVDURUMU == 0)
                                            {
                                                tlfiyat = tlfiyat * (1 + Convert.ToDouble(stok.KDV) / 100);
                                            }
                                        }
                                        else
                                        {
                                            if (stok.KDVDURUMU == 1)
                                            {
                                                tlfiyat = tlfiyat / (1 + Convert.ToDouble(stok.KDV) / 100);
                                            }
                                        }
                                    }
                                    dovizlifiyat = tlfiyat;
                                }
                                else
                                {
                                    double dovizKuru = islem.RatesTarihDovizKuruDondur(parametre, firmaLogoBilgi, stok.DOVIZKODU, Convert.ToDateTime(seciliTeklifSatir.DOVIZKURUTARIHI), firma, donem);
                                    dovizkodu = Convert.ToInt16(stok.DOVIZKODU);
                                    dovizkuru = dovizKuru;

                                    var birimf = stok.LISTEFIYATI * dovizKuru;
                                    tlfiyat = birimf;
                                    dovizlifiyat = stok.LISTEFIYATI;
                                    if (_frmTeklifOlustur.ck_kdvdahil.Checked)
                                    {
                                        if (stok.KDVDURUMU == 0)
                                        {
                                            birimf = (stok.LISTEFIYATI * dovizKuru) * (1 + Convert.ToDouble(stok.KDV) / 100);
                                            tlfiyat = birimf;
                                            dovizlifiyat = birimf / dovizKuru;
                                        }
                                    }
                                    else
                                    {
                                        if (stok.KDVDURUMU == 1)
                                        {
                                            birimf = (stok.LISTEFIYATI * dovizKuru) / (1 + Convert.ToDouble(stok.KDV) / 100);
                                            tlfiyat = birimf;
                                            dovizlifiyat = birimf / dovizkuru;
                                        }
                                    }
                                }
                            }

                            seciliTeklifSatir.FIYAT = tlfiyat;
                            seciliTeklifSatir.NETFIYAT = tlfiyat;
                            seciliTeklifSatir.DOVIZLIFIYAT = dovizlifiyat;
                            seciliTeklifSatir.SATIRDOVIZKODU = dovizkodu;
                            seciliTeklifSatir.SATIRDOVIZKURU = dovizkuru;

                            seciliTeklifSatir.TUTAR = seciliTeklifSatir.FIYAT * seciliTeklifSatir.MIKTAR;
                            seciliTeklifSatir.ISKONTOLUTUTAR = seciliTeklifSatir.FIYAT * seciliTeklifSatir.MIKTAR;
                            seciliTeklifSatir.NETFIYAT = seciliTeklifSatir.FIYAT;
                            if (_frmTeklifOlustur.ck_kdvdahil.Checked)
                            {
                                var kdvtutari = seciliTeklifSatir.FIYAT / (1 + Convert.ToDouble(stok.KDV) / 100);
                                seciliTeklifSatir.KDVTUTARI = (seciliTeklifSatir.FIYAT - kdvtutari) * seciliTeklifSatir.MIKTAR;
                                seciliTeklifSatir.TOPLAMTUTAR = (seciliTeklifSatir.FIYAT) * seciliTeklifSatir.MIKTAR;
                            }
                            else
                            {
                                var kdvtutari = seciliTeklifSatir.FIYAT * (1 + Convert.ToDouble(stok.KDV) / 100);
                                seciliTeklifSatir.KDVTUTARI = (kdvtutari - seciliTeklifSatir.FIYAT) * seciliTeklifSatir.MIKTAR;
                                seciliTeklifSatir.TOPLAMTUTAR = (seciliTeklifSatir.FIYAT + seciliTeklifSatir.KDVTUTARI) * seciliTeklifSatir.MIKTAR;
                            }

                            gv_secilenler.AddNewRow();
                            int rowHandle = gv_secilenler.GetRowHandle(gv_secilenler.DataRowCount);
                            if (gv_secilenler.IsNewItemRow(rowHandle))
                            {
                                gv_secilenler.SetRowCellValue(gv_secilenler.FocusedRowHandle, gv_secilenler.Columns[0], stok.STOKKODU.ToString());
                                gv_secilenler.SetRowCellValue(gv_secilenler.FocusedRowHandle, gv_secilenler.Columns[1], stok.STOKCINSI.ToString());
                                gv_secilenler.SetRowCellValue(gv_secilenler.FocusedRowHandle, gv_secilenler.Columns[2], stok.ACIKLAMA3.ToString());
                                gv_secilenler.SetRowCellValue(gv_secilenler.FocusedRowHandle, gv_secilenler.Columns[3], stok.BIRIM.ToString());
                                gv_secilenler.SetRowCellValue(gv_secilenler.FocusedRowHandle, gv_secilenler.Columns[4], miktar);
                                gv_secilenler.UpdateCurrentRow();
                            }

                            seciliTeklifSatir = _frmTeklifOlustur.SatirEkle();
                            _frmTeklifOlustur.gv_TeklifSatirlari.FocusedRowHandle = _frmTeklifOlustur.gv_TeklifSatirlari.GetRowHandle(_frmTeklifOlustur.gv_TeklifSatirlari.RowCount - 1);
                            _frmTeklifOlustur.gv_TeklifSatirlari.SelectRow(_frmTeklifOlustur.gv_TeklifSatirlari.FocusedRowHandle);

                            _frmTeklifOlustur.AltToplamlariHesapla();
                            _frmTeklifOlustur.SiraNoYenile();
                        }
                        if (frmStokEsleme != null)
                        {
                            seciliEslemeSatir.STOKADI = stok.STOKCINSI;
                            seciliEslemeSatir.STOKKODU = stok.STOKKODU;
                            seciliEslemeSatir.STOKLOGICALREF = stok.LOGICALREF;
                            seciliEslemeSatir.BIRIM = stok.BIRIM;
                            frmStokEsleme.gridStokEsleme.RefreshDataSource();
                            frmStokEsleme.gridStokEsleme.Refresh();
                            this.Close();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                 
            }
            
        }
        private void frmStokListesi_Load(object sender, EventArgs e)
        {
            firma = ana.lk_firma.EditValue.ToString();
            donem = ana.lk_donem.EditValue.ToString();

            DataTable dt = new DataTable();
            dt.Columns.Add("Stok Kodu", typeof(string));
            dt.Columns.Add("Stok Adı", typeof(string));
            dt.Columns.Add("Açıklama 3", typeof(string));
            dt.Columns.Add("Birim", typeof(string));
            dt.Columns.Add("Miktar", typeof(double));
            gridSecilenler.DataSource = dt;
            gv_secilenler.OptionsBehavior.Editable = false;
            gv_secilenler.BestFitColumns();
            gv_secilenler.Columns[0].Width = 75;
            gv_secilenler.Columns[1].Width = 135;
            gv_secilenler.Columns[2].Width = 45;
            gv_secilenler.Columns[3].Width = 45;

            F10IleStokAra();
        }
        private void grid_StokListesi_Click(object sender, EventArgs e)
        {
            if (gv_StokListesi.RowCount == 0) return;
            if (gv_StokListesi.FocusedRowHandle < 0)
            {
                return;
            }
            try
            {
                LOGO_XERO_STOKLISTESI stok = (LOGO_XERO_STOKLISTESI)gv_StokListesi.GetFocusedRow();
                if (stok == null)
                {
                    return;
                }
                var view = grid_StokListesi.MainView as DevExpress.XtraGrid.Views.Grid.GridView;

                var stoklogicalref = Convert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["LOGICALREF"]));

                var depobakiye = islem.StokDepoBakiyesi(stoklogicalref, ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString());
                gridDepoBakiyeleri.DataSource = depobakiye;
                gv_depoStokBakiyeleri.OptionsBehavior.Editable = false;
                gv_depoStokBakiyeleri.BestFitColumns();

                var satisfiyati = islem.StokSatisFiyatlari(stoklogicalref, ana.lk_firma.EditValue.ToString());
                gridSatisFiyatlari.DataSource = satisfiyati;
                gv_satisFiyatlari.OptionsBehavior.Editable = false;
                gv_satisFiyatlari.BestFitColumns();

                var alishareketi = islem.StokAlisHareketleri(stoklogicalref, ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString());
                gridAlisHareketleri.DataSource = alishareketi;
                gv_alisHareketleri.OptionsBehavior.Editable = false;
                gv_alisHareketleri.BestFitColumns();

                var satishareketi = islem.StokSatisHareketleri(stoklogicalref, ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString());
                gridSatisHareketleri.DataSource = satishareketi;
                gv_satisHareketleri.OptionsBehavior.Editable = false;
                gv_satisHareketleri.BestFitColumns();

                pictureEdit1.Image = null;
                pictureEdit2.Image = null;
                var stokResmiArray = islem.StokResimGetir(stoklogicalref, ana.lk_firma.EditValue.ToString());

                if (stokResmiArray.Count > 0)
                {
                    if (stokResmiArray.Count == 1)
                    {
                        MemoryStream ms = new MemoryStream(stokResmiArray[0]);
                        pictureEdit1.Image = Image.FromStream(ms);
                    }
                    else
                    {
                        MemoryStream ms1 = new MemoryStream(stokResmiArray[0]);
                        pictureEdit1.Image = Image.FromStream(ms1);

                        MemoryStream ms2 = new MemoryStream(stokResmiArray[1]);
                        pictureEdit2.Image = Image.FromStream(ms2);
                    }
                }
            }
            catch (Exception ex)
            {
                 
            }
          
        }
        public async void F10IleStokAra()
        {
            await Task.Delay(500);
            gv_StokListesi.StartIncrementalSearch(kod);
        }
        private void uruneAitSon20AlisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gv_StokListesi.RowCount == 0) return;
            if (gv_StokListesi.FocusedRowHandle < 0)
            {
                return;
            }
            ReadonlyThreadSafeProxyForObjectFromAnotherThread secilmis = (ReadonlyThreadSafeProxyForObjectFromAnotherThread)gv_StokListesi.GetRow(gv_StokListesi.FocusedRowHandle);
            if (secilmis != null)
            {
                LOGO_XERO_STOKLISTESI stok = (LOGO_XERO_STOKLISTESI)secilmis.OriginalRow;
                if (stok != null)
                {
                    frmStokListesiUrunAlisSatisForm frm = new frmStokListesiUrunAlisSatisForm();
                    frm.lbl_StokKodu.Text = stok.STOKKODU;
                    frm.lbl_StokAdi.Text = stok.STOKCINSI;
                    frm.Text = "Alış Hareketleri";
                    frm.gv_UrunAlisSatis.ViewCaption = "Alış Hareketleri";
                    frm.Liste(stok.STOKKODU.ToString(), " S.TRCODE IN (1,13,14,15,50) ");
                    frm.ShowDialog();
                }
            }          
        }
        private void uruneAitSon20SatisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gv_StokListesi.RowCount == 0) return;
            if (gv_StokListesi.FocusedRowHandle < 0)
            {
                return;
            }
            ReadonlyThreadSafeProxyForObjectFromAnotherThread secilmis = (ReadonlyThreadSafeProxyForObjectFromAnotherThread)gv_StokListesi.GetRow(gv_StokListesi.FocusedRowHandle);
            if (secilmis != null)
            {
                LOGO_XERO_STOKLISTESI stok = (LOGO_XERO_STOKLISTESI)secilmis.OriginalRow;
                if (stok != null)
                {
                    frmStokListesiUrunAlisSatisForm frm = new frmStokListesiUrunAlisSatisForm();
                    frm.lbl_StokKodu.Text = stok.STOKKODU;
                    frm.lbl_StokAdi.Text = stok.STOKCINSI;
                    frm.Text = "Satış Faturaları";
                    frm.gv_UrunAlisSatis.ViewCaption = "Satış Faturaları";
                    frm.Liste(stok.STOKKODU.ToString(), " S.TRCODE IN (7,8) ");
                    frm.ShowDialog();
                }
            }         
        }
        private void lotBilgisiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gv_StokListesi.RowCount == 0) return;
            if (gv_StokListesi.FocusedRowHandle < 0)
            {
                return;
            }
            ReadonlyThreadSafeProxyForObjectFromAnotherThread secilmis = (ReadonlyThreadSafeProxyForObjectFromAnotherThread)gv_StokListesi.GetRow(gv_StokListesi.FocusedRowHandle);
            if (secilmis != null)
            {
                LOGO_XERO_STOKLISTESI stok = (LOGO_XERO_STOKLISTESI)secilmis.OriginalRow;
                if (stok != null)
                {
                    frmLotBilgileri frm = new frmLotBilgileri();
                    frm.lbl_StokKodu.Text = stok.STOKKODU;
                    frm.lbl_StokAdi.Text = stok.STOKCINSI;
                    frm.stokLogicalref = stok.LOGICALREF;
                    frm.Show();
                }
            }
        }
        private void satinAlmaSatisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gv_StokListesi.RowCount == 0) return;
            if (gv_StokListesi.FocusedRowHandle < 0)
            {
                return;
            }
            ReadonlyThreadSafeProxyForObjectFromAnotherThread secilmis = (ReadonlyThreadSafeProxyForObjectFromAnotherThread)gv_StokListesi.GetRow(gv_StokListesi.FocusedRowHandle);
            if (secilmis != null)
            {
                LOGO_XERO_STOKLISTESI stok = (LOGO_XERO_STOKLISTESI)secilmis.OriginalRow;
                if (stok != null)
                {
                    frmSatinAlmaSatisFiyatlari frm = new frmSatinAlmaSatisFiyatlari();
                    frm.stoklogicalref = stok.LOGICALREF;
                    frm.Text = stok.STOKKODU.ToString() + "-" + stok.STOKCINSI.ToString();
                    frm.ShowDialog();
                }
            }
        }
        private void tasarımKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            islem.TasarimKaydet(gv_StokListesi, ana._Kullanici.ID, this.Name, grid_StokListesi.Name);
            XtraMessageBox.Show("Tasarım Kaydedildi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ürünEkstresiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReadonlyThreadSafeProxyForObjectFromAnotherThread secilmis = (ReadonlyThreadSafeProxyForObjectFromAnotherThread)gv_StokListesi.GetRow(gv_StokListesi.FocusedRowHandle);
            if (secilmis != null)
            {
                LOGO_XERO_STOKLISTESI stok = (LOGO_XERO_STOKLISTESI)secilmis.OriginalRow;
                if (stok != null)
                {
                    frmUrunEkstresi eks = new frmUrunEkstresi(stok.STOKKODU,stok.STOKCINSI);
                    eks.lbl_StokKodu.Text = stok.STOKKODU;
                    eks.lbl_StokAdi.Text = stok.STOKCINSI;
                    eks.ShowDialog();

                }
            }
        }
        private void barkodBasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReadonlyThreadSafeProxyForObjectFromAnotherThread secilmis = (ReadonlyThreadSafeProxyForObjectFromAnotherThread)gv_StokListesi.GetRow(gv_StokListesi.FocusedRowHandle);
            if (secilmis != null)
            {
                LOGO_XERO_STOKLISTESI stok = (LOGO_XERO_STOKLISTESI)secilmis.OriginalRow;
                string[] stk = islem.StokKodaAitCinsVeBarkodGetir(firma, stok.STOKKODU);
                if (stok != null)
                {
                    BarkodReport barkod = new BarkodReport();
                    if (stok.BARKOD != null)
                    {
                        barkod.xrBarCode1.Text = stok.BARKOD;
                        barkod.xrLabel1.Text = stok.STOKCINSI;
                    }
                    else
                    {
                        barkod.xrBarCode1.Text = stk[2];
                        barkod.xrLabel1.Text = stk[1];
                    }

                    barkod.ShowPreview();
                }
            }
        }
        private void yeniStokKatıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStokKart stk = new frmStokKart();
            stk.ShowDialog();
        }
    }
}