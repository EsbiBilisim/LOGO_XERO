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
    public partial class frmSatisTevkifatKodlari : DevExpress.XtraEditors.XtraForm
    {
        frmStokKart _frmStokKart;
        LOGO_XERO_PARAMETRELER _parametre;
        public int tip = 0;
        public frmSatisTevkifatKodlari(frmStokKart frmStokKart, LOGO_XERO_PARAMETRELER parametre)
        {
            InitializeComponent();
            _parametre = parametre;
            _frmStokKart = frmStokKart;
        }
        private void frmSatisTevkifatKodlari_Load(object sender, EventArgs e)
        {
            TevkifatListesiCek();
        }
        void TevkifatListesiCek()
        {
            string dosyayolu = "";
            if (tip == 1)
            {
                dosyayolu = _parametre.PROGRAMKATALOGDOSYAYOLU + "\\VatDeducts2.xml";
            }
            else
            {
                dosyayolu = _parametre.PROGRAMKATALOGDOSYAYOLU + "\\VatDeducts.xml";
            }
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(dosyayolu);
            DEDUCT_CODE result = new DEDUCT_CODE();
            XmlReader xmlReader = new XmlNodeReader(xmlDocument);
            XmlSerializer serializer = new XmlSerializer(typeof(LOGO_XERO.Models.LOGO_M.DosyaClaslari.DEDUCT_CODE));
            result = (LOGO_XERO.Models.LOGO_M.DosyaClaslari.DEDUCT_CODE)serializer.Deserialize(xmlReader);
            if (result.DEDUCTCODE.Count > 0)
            {
                gridControl1.DataSource = result.DEDUCTCODE;
            }
        }
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            DEDUCTCODE row = (DEDUCTCODE)gridView1.GetFocusedRow();
            if (row != null)
            {
                if (_frmStokKart != null)
                {
                    string carpan = row.DEDUCTRATE.Split('/')[0];
                    string bolen = row.DEDUCTRATE.Split('/')[1];
                    if (tip == 1)
                    {
                        _frmStokKart.btn_alisTevkifatKodu.Text = row.CODE;
                        _frmStokKart.txt_alisTevkifatOraniCarpan.Text = carpan;
                        _frmStokKart.txt_alisTevkifatOraniBolen.Text = bolen;
                    }
                    else
                    {
                        _frmStokKart.btn_SatisTevkifatKodu.Text = row.CODE;
                        _frmStokKart.txt_satisTevkifatOraniCarpan.Text = carpan;
                        _frmStokKart.txt_satisTevkifatOraniBolen.Text = bolen;
                    }
                }
                this.Close();
            }
        }
    }
}