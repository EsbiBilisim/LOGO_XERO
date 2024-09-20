using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using LOGO_XERO.Models.LOGO_M;
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

namespace LOGO_XERO.Moduller.Giris_AnaForm_Ayarlar
{

    public partial class frmDovizTurleri : DevExpress.XtraEditors.XtraForm
    {
        Islemler islem = new Islemler();
        frmAnaForm ana;
        List<L_CURRENCYLIST> DovizListesi;
        List<LOGO_XERO_DOVIZ_BILGILERI> firmaninDovizListesi;
    
        int firmaNo = 0;
        public frmDovizTurleri()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            firmaNo = Convert.ToInt32(ana.lk_firma.EditValue.ToString());
        }

        private void frmDovizTurleri_Load(object sender, EventArgs e)
        {
            Liste();
        }        

        public void Liste()
        {
            DovizListesi = islem.DovizListesiGetir(firmaNo.ToString());
            using (LogoContext db = new LogoContext())
            {
                firmaninDovizListesi = db.LOGO_XERO_DOVIZ_BILGILERI.Where(s => s.FIRMANO == firmaNo).ToList();
            }
            gridControl1.DataSource = DovizListesi;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                L_CURRENCYLIST satir = (L_CURRENCYLIST)gridView1.GetRow(i);
                if (firmaninDovizListesi.Where(s => s.DOVIZKODU == satir.CURTYPE).ToList().Count > 0)
                {
                    gridView1.SelectRow(i);
                }
            }
        }
        private void btn_kapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            using (LogoContext db = new LogoContext())
            {
                string sil = $@"DELETE FROM LOGO_XERO_DOVIZ_BILGILERI WHERE FIRMANO={firmaNo}";
                db.Database.ExecuteSqlCommand(sil);
                DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                for (int i = 0; i < gridView1.GetSelectedRows().Length; i++)
                {
                    L_CURRENCYLIST satir = (L_CURRENCYLIST)gridView1.GetRow(gridView1.GetSelectedRows()[i]);
                    string ekle = $@"INSERT INTO LOGO_XERO_DOVIZ_BILGILERI(FIRMANO,LOGICALREF, DOVIZKODU, DOVIZCINSI, ACIKLAMA, SEMBOL) values ({firmaNo}, {Convert.ToInt32(satir.LOGICALREF)}, {Convert.ToInt16(satir.CURTYPE)}, '{satir.CURCODE}', '{satir.CURNAME}', '{satir.CURSYMBOL}')";
                    db.Database.ExecuteSqlCommand(ekle);

                }
                Liste();
                XtraMessageBox.Show("KAYIT TAMAMLANDI !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }
    }
}