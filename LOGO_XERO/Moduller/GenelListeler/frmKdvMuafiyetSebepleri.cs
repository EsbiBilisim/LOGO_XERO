using DevExpress.XtraEditors;
using LOGO_XERO.Models.LOGO_M.DosyaClaslari;
using LOGO_XERO.Models.LOGO_XERO_M;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace LOGO_XERO.Moduller.GenelListeler
{
    public partial class frmKdvMuafiyetSebepleri : DevExpress.XtraEditors.XtraForm
    {
        frmTeklifOlustur _frmTeklifOlustur;
        LOGO_XERO_PARAMETRELER _parametre;
        public int _tip = 0;
        public frmKdvMuafiyetSebepleri(frmTeklifOlustur frmTeklifOlustur, LOGO_XERO_PARAMETRELER parametre,int tip)
        {
            InitializeComponent();
            _parametre = parametre;
            _frmTeklifOlustur = frmTeklifOlustur;
            _tip = tip;
        }

        private void frmKdvMuafiyetSebepleri_Load(object sender, EventArgs e)
        {
            KdvMuafiyetListesiCek();
        }

        void KdvMuafiyetListesiCek()
        {
            string dosyayolu = _parametre.PROGRAMKATALOGDOSYAYOLU + "\\VatExcepts.xml";

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(dosyayolu);
            VATEXCEPT_REASON result = new VATEXCEPT_REASON();
            XmlReader xmlReader = new XmlNodeReader(xmlDocument);
            XmlSerializer serializer = new XmlSerializer(typeof(LOGO_XERO.Models.LOGO_M.DosyaClaslari.VATEXCEPT_REASON));
            result = (LOGO_XERO.Models.LOGO_M.DosyaClaslari.VATEXCEPT_REASON)serializer.Deserialize(xmlReader);
            if (result.VATEXCEPTREASON.Count > 0)
            {
                gridControl1.DataSource = result.VATEXCEPTREASON;
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            VATEXCEPTREASON row = (VATEXCEPTREASON)gridView1.GetFocusedRow();
            if (row != null)
            {
                if (_frmTeklifOlustur != null)
                {
                    if (_tip == 0)
                    {
                        _frmTeklifOlustur.btn_KdvMuafiyetSebebiKodu.Text = row.CODE;
                        _frmTeklifOlustur.txt_KdvMuafiyetSebebiAciklamasi.Text = row.NAME;
                        if (MessageBox.Show("Fiş Satırları KDV Muafiyet Bilgileri Güncellenecek !", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            List<LOGO_XERO_TEKLIF_SATIR> TeklifsatirListe = _frmTeklifOlustur.grid_TeklifSatirlari.DataSource as List<LOGO_XERO_TEKLIF_SATIR>;

                            if (TeklifsatirListe != null)
                            {
                                foreach (var item in TeklifsatirListe)
                                {
                                    item.KDVMUAFIYETKODU = row.CODE;
                                    item.KDVMUAFIYETACIKLAMA = row.NAME;
                                }
                                _frmTeklifOlustur.grid_TeklifSatirlari.Refresh();
                            }
                        }
                    }
                    else
                    {
                        _frmTeklifOlustur.gv_TeklifSatirlari.SetFocusedRowCellValue("KDVMUAFIYETKODU", row.CODE);
                        _frmTeklifOlustur.gv_TeklifSatirlari.SetFocusedRowCellValue("KDVMUAFIYETACIKLAMA", row.NAME);
                    }
                  
                }
                this.Close();
            }
        }
    }
}