using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using LOGO_XERO.Models.LOGO_M;
using LOGO_XERO.Models.LOGO_XERO_M;
using LOGO_XERO.Moduller._1_TeklifModul;
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

namespace LOGO_XERO.Moduller.GenelListeler
{
    public partial class frmTeklifOnaylama : DevExpress.XtraEditors.XtraForm
    {
        public bool islemyapildimi = false;
        public bool siparisolusturuldu = false;
        public int teklifid;
        frmTeklifOlustur frm = new frmTeklifOlustur();
        Islemler islem = new Islemler();
        frmAnaForm ana;
        string firma;
        public frmTeklifOnaylama(int _teklifid, frmTeklifOlustur _frm)
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            firma = ana.lk_firma.EditValue.ToString();
            teklifid = _teklifid;
            frm = _frm;
            LookUpleriDoldur();
            GrideBas(_teklifid);
            islem.TasarimGetir(gv_teklifonayla, ana._Kullanici.ID, this.Name, gridcontrolTeklifOnayla.Name);
        }
        public void GrideBas(int teklifid)
        {
            using (LogoContext db = new LogoContext())
            {
                string sql = $@"select ISNULL((select ONAYLANANMIKTAR from LOGO_XERO_ONAYLI_TEKLIF_SATIR_{firma} where TEKLIFID = s.TEKLIFID and TEKLIFSATIRID =s.ID),0)as ONAYLANANMIKTAR,
ISNULL((select ID from LOGO_XERO_ONAYLI_TEKLIF_SATIR_{firma} where TEKLIFID = s.TEKLIFID and TEKLIFSATIRID =s.ID),0) AS ONAYID,* 
from LOGO_XERO_TEKLIF_SATIR_{firma} s where s.TEKLIFID ={teklifid}";

                gridcontrolTeklifOnayla.DataSource = db.Database.SqlQuery<MIKTARLISATIR>(sql).ToList();
                gridcontrolTeklifOnayla.RefreshDataSource();
                gridcontrolTeklifOnayla.Refresh();
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //if (ana.demomu == 1)
            //{
            //    XtraMessageBox.Show("Demo Lisansında Sadece Teklif Onaylayabilirsiniz LOGO ya Sipariş Gönderilmeyecek !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}

            if (MiktarlariSorgula() == false)
            {
                XtraMessageBox.Show("Satırlarda Onaylanan Miktar Satırdaki Miktardan Fazla Olamaz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                int[] selectedRowHandles = gv_teklifonayla.GetSelectedRows();
                if (selectedRowHandles.Count() == 0)
                {
                    XtraMessageBox.Show("Siparişe Gidecek Satırları Seçiniz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                List<MIKTARLISATIR> onaylanacaklar = new List<MIKTARLISATIR>();
                for (int i = 0; i < selectedRowHandles.Length; i++)
                {
                    MIKTARLISATIR row = (MIKTARLISATIR)gv_teklifonayla.GetRow(selectedRowHandles[i]);
                    if (row.ONAYLANANMIKTAR == 0)
                    {
                        XtraMessageBox.Show("Seçili Satırlarda Onaylanan Miktar 0 Olamaz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    onaylanacaklar.Add(row);
                }

                Kaydet(onaylanacaklar);
                islemyapildimi = true;
            }
            catch (Exception ex)
            {
                islemyapildimi = false;
                XtraMessageBox.Show("Hata Oluştu ! Hata : " + ex.ToString(), "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public bool MiktarlariSorgula()
        {
            int[] selectedRowHandles = gv_teklifonayla.GetSelectedRows();
            for (int i = 0; i < selectedRowHandles.Length; i++)
            {
                int satirmiktar = Convert.ToInt32(gv_teklifonayla.GetRowCellValue(selectedRowHandles[i], satirmiktarclm));
                int onaymiktar = Convert.ToInt32(gv_teklifonayla.GetRowCellValue(selectedRowHandles[i], OMIKTAR));
                if (onaymiktar > satirmiktar)
                {
                    return false;
                }
            }
            return true;
        }
        public void LookUpleriDoldur()
        {
            string firma = ana.firma;
            int isyeri = ana._Kullanici.ISYERI;
            islem.BolumListesiDoldur(rpBolum, firma);
            islem.IsyeriListesiDoldur(rpİsyeri, firma);
            islem.TumAmbarListesiDoldur(rpAmbar, firma);
            islem.FabrikaListesiDoldur(rpFabrika, firma);
            islem.DovizBilgileriDoldur(rpRaporlamaDovizi, firma);
        }
        public void Kaydet(List<MIKTARLISATIR> liste)
        {
            int id = 0;
            try
            {
                using (LogoContext db = new LogoContext())
                {
                    int i = 0;
                    foreach (var item in liste)
                    {
                        int satirid = item.ID;
                        LOGO_XERO_ONAYLI_TEKLIF_SATIR onaylisatir = db.LOGO_XERO_ONAYLI_TEKLIF_SATIR.Where(s => s.TEKLIFID == teklifid && s.TEKLIFSATIRID == satirid).FirstOrDefault();
                        if (onaylisatir == null)
                        {
                            id = 0;
                        }
                        else
                        {
                            id = onaylisatir.ID;
                            if (Convert.ToDouble(item.ONAYLANANMIKTAR) == 0)
                            {
                                db.LOGO_XERO_ONAYLI_TEKLIF_SATIR.Remove(onaylisatir);
                                db.SaveChanges();
                                continue;
                            }

                        }
                        LOGO_XERO_ONAYLI_TEKLIF_SATIR satir = new LOGO_XERO_ONAYLI_TEKLIF_SATIR();
                        satir.ID = id;
                        satir.SATIRTIPI = item.SATIRTIPI;
                        satir.TESLIMSURESI = item.TESLIMSURESI;
                        satir.TEKLIFSATIRID = item.ID;
                        satir.TEKLIFID = item.TEKLIFID;
                        satir.SIRANO = i + 1;
                        satir.TRCODE = item.TRCODE;
                        satir.STOKLOGICALREF = item.STOKLOGICALREF;
                        satir.STOKKODU = item.STOKKODU;
                        satir.STOKADI = item.STOKADI;
                        satir.FIYATGURUBU = item.FIYATGURUBU;
                        satir.BIRIM = item.BIRIM;
                        satir.MARKA = item.MARKA;
                        satir.STOKACIKLAMA = item.STOKACIKLAMA;
                        satir.SATIRACIKLAMA = item.SATIRACIKLAMA;
                        satir.MIKTAR = item.MIKTAR;
                        satir.TESLIMMIKTAR = 0;
                        satir.ONAYLANANMIKTAR = Convert.ToDouble(item.ONAYLANANMIKTAR);
                        satir.KALANMIKTAR = satir.MIKTAR - satir.ONAYLANANMIKTAR;
                        satir.ORJINALISKONTO = item.ORJINALISKONTO;
                        satir.ISKONTOYUZDESI1 = item.ISKONTOYUZDESI1;
                        satir.ISKONTOYUZDESI2 = item.ISKONTOYUZDESI2;
                        satir.ISKONTOYUZDESI3 = item.ISKONTOYUZDESI3;
                        satir.ISKONTOTUTARI1 = item.ISKONTOTUTARI1;
                        satir.ISKONTOTUTARI2 = item.ISKONTOTUTARI2;
                        satir.ISKONTOTUTARI3 = item.ISKONTOTUTARI3;
                        satir.KDV = item.KDV;
                        satir.KDVTUTARI = item.KDVTUTARI;
                        satir.ONAYLANANISKONTOLUTUTAR = 0;
                        satir.TUTAR = item.TUTAR;
                        satir.TESLIMTARIHI = item.TESLIMTARIHI;
                        satir.TALEPEDENFIRMA = item.TALEPEDENFIRMA;
                        satir.ISYERI = item.ISYERI;
                        satir.BOLUM = item.BOLUM;
                        satir.FABRIKA = item.FABRIKA;
                        satir.AMBAR = item.AMBAR;
                        satir.NAKLIYEBEDELI = item.NAKLIYEBEDELI;
                        satir.TEVKIFATLI = item.TEVKIFATLI;
                        satir.TEVKIFATKODU = item.TEVKIFATKODU;
                        satir.TEVKIFATCARPAN = item.TEVKIFATCARPAN;
                        satir.TEVKIFATBOLEN = item.TEVKIFATBOLEN;
                        satir.RAPORLAMADOVIZI = item.RAPORLAMADOVIZI;
                        satir.RAPORLAMADOVIZKURU = item.RAPORLAMADOVIZKURU;
                        satir.ISLEMDOVIZI = item.ISLEMDOVIZI;
                        satir.ISLEMDOVIZKURU = item.ISLEMDOVIZKURU;
                        satir.DOVIZKURUTARIHI = item.DOVIZKURUTARIHI;
                        satir.OZELKOD1 = item.OZELKOD1;
                        satir.OZKODACIKLAMA = item.OZKODACIKLAMA;
                        satir.NETFIYAT = item.NETFIYAT;
                        satir.TOPLAMTUTAR = item.TOPLAMTUTAR;
                        satir.ONAYLANANTOPLAMTUTAR = 0;
                        satir.FIYAT = item.FIYAT;
                        satir.DOVIZLIFIYAT = item.DOVIZLIFIYAT;
                        satir.SATIRDOVIZKODU = item.SATIRDOVIZKODU;
                        satir.SATIRDOVIZKURU = item.SATIRDOVIZKURU;
                        satir.TUR = item.TUR;
                        satir.LOTKODU = item.LOTKODU;
                        db.LOGO_XERO_ONAYLI_TEKLIF_SATIR.AddOrUpdate(satir);
                        db.SaveChanges();
                        i++;
                    }
                }

                XtraMessageBox.Show("Onaylı Teklif Satırları Kaydedildi !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //if (ana.demomu == 0)
                //{
                   
                    frmTeklifSiparisOlusturma frm12 = new frmTeklifSiparisOlusturma(this, frm);
                    frm12.sipariseGidecekler = liste;
                    frm12.ShowDialog();
                    this.Close();
                //}
                //else
                //{
                //    this.Close();
                //}
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Kaydetme İşlemi Başarısız ! Hata : "+ex.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tümOnaylarıKaldırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<MIKTARLISATIR> satirlar = gv_teklifonayla.DataSource as List<MIKTARLISATIR>;
            foreach (var item in satirlar)
            {
                item.ONAYLANANMIKTAR = 0;
            }
            gridcontrolTeklifOnayla.DataSource = satirlar;
            gridcontrolTeklifOnayla.RefreshDataSource();
            gridcontrolTeklifOnayla.Refresh();
        }
        public void SecilenleriKaldir()
        {
            gv_teklifonayla.ClearSelection();
        }
        public void HepsiniSec()
        {
            gv_teklifonayla.SelectAll();
        }
        private void seçilenleriKaldırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SecilenleriKaldir();
        }
        private void hepsiniSeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HepsiniSec();
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            HepsiniSec();
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SecilenleriKaldir();
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            List<MIKTARLISATIR> satirlar = gv_teklifonayla.DataSource as List<MIKTARLISATIR>;
            foreach (var item in satirlar)
            {
                item.ONAYLANANMIKTAR = item.MIKTAR;
            }
            gridcontrolTeklifOnayla.DataSource = satirlar;
            gridcontrolTeklifOnayla.RefreshDataSource();
            gridcontrolTeklifOnayla.Refresh();
        }
        private void frmTeklifOnaylama_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (islemyapildimi == true && siparisolusturuldu == true)
            {
                frm.xtraTabControl2.SelectedTabPage = frm.OnayliTeklifSatirlariTab;
                frm.OnaylanansatirlariGetir(teklifid);
            }
            else if (siparisolusturuldu == false && islemyapildimi == true)
            {
                frm.xtraTabControl2.SelectedTabPage = frm.OnayliTeklifSatirlariTab;
                frm.OnaylanansatirlariGetir(teklifid);
                frm.lk_durum.EditValue = 1;
            }
            else if (siparisolusturuldu == false && islemyapildimi == false) 
            { 
                frm.lk_durum.EditValue = 1;
            }
        }
        private void tasarımıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            islem.TasarimKaydet(gv_teklifonayla, ana._Kullanici.ID, this.Name, gridcontrolTeklifOnayla.Name);
            XtraMessageBox.Show("Tasarım Başarıyla Kaydedildi !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

}