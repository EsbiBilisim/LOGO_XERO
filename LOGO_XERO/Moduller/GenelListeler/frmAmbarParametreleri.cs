using DevExpress.CodeParser;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using LOGO_XERO.Models.GenelKullanim;
using LOGO_XERO.Models.LOGO_M;
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
    public partial class frmAmbarParametreleri : DevExpress.XtraEditors.XtraForm
    {
        frmAnaForm ana;
        int itemref = 0;
        Islemler islem = new Islemler();
        
        public frmAmbarParametreleri(int _itemref)
        {
            InitializeComponent(); 
            ana = System.Windows.Forms.Application.OpenForms["frmAnaForm"] as frmAnaForm;
            itemref = _itemref;
            //Doldur
            rpNegatifSeviyeControlDoldur();
            islem.TumAmbarListesiDoldur(rpAmbar,ana.lk_firma.EditValue.ToString()); 
            Listele(itemref);
        }
        public void rpNegatifSeviyeControlDoldur()
        {
            List<KODAD> liste = new List<KODAD>();
            liste.Add(new KODAD { CODE = 0, NAME = "İşleme Devam Edilecek" });
            liste.Add(new KODAD { CODE = 1, NAME = "Kullanıcı Uyarılacak" });
            liste.Add(new KODAD { CODE = 2, NAME = "İşlem Durdurulacak" });

            rpNegatifSeviyeControl.ValueMember = "CODE";
            rpNegatifSeviyeControl.DisplayMember = "NAME";

            rpNegatifSeviyeControl.DataSource = liste;
        }

        private void frmAmbarParametreleri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                simpleButton1_Click(sender, e);
            }
        }
        public void Listele(int _itemref) {
            using (LogoContext db = new LogoContext())
            {
                
                List<LG_INVDEF> liste = db.LG_INVDEF.Where(s=>s.ITEMREF == _itemref ).ToList(); 
                foreach (var item in liste)
                {
                    string stokbakiyesisql = $@"SELECT ISNULL(SUM(ONHAND),0) AS 'PRICE' FROM LV_{ana.lk_firma.EditValue.ToString()}_{ana.lk_donem.EditValue.ToString()}_STINVTOT  WHERE STOCKREF={_itemref} AND INVENNO={item.INVENNO}";
                    var kodad = db.Database.SqlQuery<DOUBLEAD>(stokbakiyesisql).FirstOrDefault();
                    item.STOKBAKIYESI = kodad.PRICE;
                }
                List<L_CAPIWHOUSE> ambarlar = islem.TumAmbarListesi(ana.lk_firma.EditValue.ToString());  
                foreach (var item in ambarlar)
                {
                    if (!liste.Select(s=>s.INVENNO).Contains(item.NR))
                    {
                        LG_INVDEF invDef = new LG_INVDEF();
                        invDef.ITEMREF = _itemref;
                        invDef.MINLEVEL = 0;
                        invDef.MAXLEVEL = 0;
                        invDef.SAFELEVEL = 0;
                        invDef.NEGLEVELCTRL = 0;
                        invDef.INVENNO = item.NR;
                        invDef.STOKBAKIYESI = 0;
                        db.LG_INVDEF.AddOrUpdate(invDef);
                        db.SaveChanges();
                    } 
                }
                liste = db.LG_INVDEF.Where(s => s.ITEMREF == _itemref).OrderBy(s => s.INVENNO).ToList();
                liste = liste.Where(s => ambarlar.Select(x => x.NR).Contains(s.INVENNO)).ToList();
                grid_stkambarparametreleri.DataSource = liste;
                grid_stkambarparametreleri.RefreshDataSource();
                grid_stkambarparametreleri.Refresh();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void KaydetSatir()
        {
            using (LogoContext db = new LogoContext())
            {
                LG_INVDEF row = (LG_INVDEF) gv_stkambarparametreleri.GetFocusedRow();
                if (row != null)
                {
                    db.LG_INVDEF.AddOrUpdate(row);
                    db.SaveChanges();
                }
            } 
        }

        private void gv_stkambarparametreleri_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            LG_INVDEF row = (LG_INVDEF)gv_stkambarparametreleri.GetFocusedRow();
            if (row != null)
            {
                if (e.Column.FieldName == "MINLEVEL")
                {
                    if (row.MINLEVEL > row.MAXLEVEL)
                    {
                        XtraMessageBox.Show("Minimum Seviye Maksimum Seviyeden Büyük Olamaz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Listele(itemref);
                        return;
                    }
                    else if (row.MINLEVEL > row.SAFELEVEL)
                    {
                        XtraMessageBox.Show("Minimum Seviye Güvenli Seviyeden Büyük Olamaz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Listele(itemref);
                        return;
                    }
                }
                else if (e.Column.FieldName == "MAXLEVEL")
                {
                    if (row.MAXLEVEL < row.MINLEVEL)
                    {
                        XtraMessageBox.Show("Maksimum Seviye Minimum Seviyeden Küçük Olamaz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Listele(itemref);
                        return;
                    }
                    else if (row.MAXLEVEL < row.SAFELEVEL)
                    {
                        XtraMessageBox.Show("Maksimum Seviye Güvenli Seviyeden Küçük Olamaz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Listele(itemref);
                        return;
                    }
                }
                else if (e.Column.FieldName == "SAFELEVEL") 
                {
                    if (row.SAFELEVEL < row.MINLEVEL)
                    {
                        XtraMessageBox.Show("Güvenli Seviye Minimum Seviyeden Küçük Olamaz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Listele(itemref);
                        return;
                    }
                    else if (row.SAFELEVEL > row.MAXLEVEL)
                    {
                        XtraMessageBox.Show("Güvenli Seviye Maksimum Seviyeden Büyük Olamaz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Listele(itemref);
                        return;
                    }
                }
            }
            KaydetSatir();
        }

        private void frmAmbarParametreleri_Load(object sender, EventArgs e)
        {

        }
    }
}