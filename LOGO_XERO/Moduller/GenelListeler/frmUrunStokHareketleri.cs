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

namespace LOGO_XERO.Moduller.GenelListeler
{
    public partial class frmUrunStokHareketleri : DevExpress.XtraEditors.XtraForm
    {
        Islemler islem = new Islemler();
        frmAnaForm ana;
        string _stokkodu;
        string firma, donem;
        public frmUrunStokHareketleri(string stokkodu)
        {
            InitializeComponent();
           
            _stokkodu = stokkodu;
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            firma = ana.lk_firma.EditValue.ToString();
            donem = ana.lk_donem.EditValue.ToString();
            date_Ilk.DateTime = new DateTime(DateTime.Now.Year, 1, 1);
            date_Son.DateTime = DateTime.Today;
            islem.TasarimGetir(gv_UrunStokHareketleri, ana._Kullanici.ID, this.Name, gridStokHareketleri.Name);
            islem.TasarimGetir(gv_AlisHareketleri, ana._Kullanici.ID, this.Name, gridAlis.Name);
            islem.TasarimGetir(gv_SatisHareketleri, ana._Kullanici.ID, this.Name, gridSatis.Name);
        }

        private void ayarlarıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            islem.TasarimKaydet(gv_UrunStokHareketleri, ana._Kullanici.ID, this.Name, gridStokHareketleri.Name);
            islem.TasarimKaydet(gv_AlisHareketleri, ana._Kullanici.ID, this.Name, gridAlis.Name);
            islem.TasarimKaydet(gv_SatisHareketleri, ana._Kullanici.ID, this.Name, gridSatis.Name);
            XtraMessageBox.Show("Tasarım Başarıyla Kaydedildi");
        }

        private void frmUrunStokHareketleri_Load(object sender, EventArgs e)
        {
            gridStokHareketleri.DataSource = islem.UrunStokHareketleriYuruyen(firma,donem, _stokkodu, date_Ilk.DateTime,date_Son.DateTime);
            gridAlis.DataSource = islem.UrunAlisSatisHareketleri(firma,donem,_stokkodu, "1,2,3", date_Ilk.DateTime,date_Son.DateTime);
            gridSatis.DataSource = islem.UrunAlisSatisHareketleri(firma,donem,_stokkodu, "6,7,8", date_Ilk.DateTime,date_Son.DateTime);
        }
    }
}