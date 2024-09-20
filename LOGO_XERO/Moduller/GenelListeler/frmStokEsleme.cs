using DevExpress.XtraEditors;
using LOGO_XERO.Models;
using LOGO_XERO.Models.LOGO_XERO_M;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
using UnityObjects;

namespace LOGO_XERO.Moduller.GenelListeler
{
    public partial class frmStokEsleme : DevExpress.XtraEditors.XtraForm
    {
        List<LOGO_XERO_TEKLIF_SATIR> satirlar;
        frmTeklifOlustur _tekliffrm;
        public frmStokEsleme(List<LOGO_XERO_TEKLIF_SATIR> _satirlar,frmTeklifOlustur tekliffrm)
        {
            InitializeComponent();
            satirlar = _satirlar;
            _tekliffrm = tekliffrm;
            gridStokEsleme.DataSource = satirlar;
            gridStokEsleme.RefreshDataSource();
            gridStokEsleme.Refresh();
        }

        private void rpStokKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gvStokEsleme.GetFocusedRow() != null)
            { 
                frmStokListesi frm = new frmStokListesi(this);
                frm.seciliEslemeSatir = (LOGO_XERO_TEKLIF_SATIR)gvStokEsleme.GetFocusedRow(); 
                frm.ShowDialog();
                _tekliffrm.grid_TeklifSatirlari.RefreshDataSource();
                _tekliffrm.grid_TeklifSatirlari.Refresh();
                
            }
        }
         

        private void frmStokEsleme_FormClosing(object sender, FormClosingEventArgs e)
        {         } 

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            List<LOGO_XERO_TEKLIF_SATIR> satirlar = gridStokEsleme.DataSource as List<LOGO_XERO_TEKLIF_SATIR>;
            using (LogoContext db = new LogoContext())
            {
                satirlar.ForEach(s => db.LOGO_XERO_TEKLIF_SATIR.AddOrUpdate(s));
                db.SaveChanges();
            }
            _tekliffrm.grid_TeklifSatirlari.DataSource = _tekliffrm.satirgetir(_tekliffrm.Teklifid);
            _tekliffrm.grid_TeklifSatirlari.RefreshDataSource();
            _tekliffrm.grid_TeklifSatirlari.Refresh();
            XtraMessageBox.Show("Satırlar Kaydedildi ", "Kaydedildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Kaydetmek İstiyor Musunuz ? ", "Kaydet", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<LOGO_XERO_TEKLIF_SATIR> satirlar = gridStokEsleme.DataSource as List<LOGO_XERO_TEKLIF_SATIR>;
                using (LogoContext db = new LogoContext())
                {
                    satirlar.ForEach(s => db.LOGO_XERO_TEKLIF_SATIR.AddOrUpdate(s));
                    db.SaveChanges();
                }
            }
            _tekliffrm.grid_TeklifSatirlari.DataSource = _tekliffrm.satirgetir(_tekliffrm.Teklifid);
            _tekliffrm.grid_TeklifSatirlari.RefreshDataSource();
            _tekliffrm.grid_TeklifSatirlari.Refresh();
            this.Close();
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            simpleButton1_Click(sender, e);
            this.Close();
        }

        private void frmStokEsleme_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                simpleButton3_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                simpleButton1_Click(sender, e);
            }
        }
    }
}