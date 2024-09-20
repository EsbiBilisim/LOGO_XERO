using DevExpress.Utils.Design;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UserDesigner;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UserDesigner;
using DevExpress.XtraReports.UI;
using LOGO_XERO.Moduller._7_Raporlar;
using LOGO_XERO.Models;
using LOGO_XERO.ext;
using DevExpress.DashboardWin.Design;
using DevExpress.Diagram.Core.Native;
using System.ComponentModel.Design;
using DevExpress.DataAccess.ObjectBinding;
using LOGO_XERO.Logic;
using LOGO_XERO.Models.LOGO_XERO_M.LOGO_XERO_M;
using LOGO_XERO.Models.LOGO_XERO_M;
using DevExpress.DashboardCommon;
using DevExpress.Data.Browsing.Design;
using DevExpress.XtraReports.Native.Data;
using DevExpress.XtraReports.Design;
using DevExpress.XtraBars.Docking;
using LOGO_XERO.LogoServis;

namespace LOGO_XERO.Moduller.Giris_AnaForm_Ayarlar
{
    public partial class frmRaporDosya : DevExpress.XtraEditors.XtraForm
    {
        SQLConnection clas = new SQLConnection();
        string dosyaAdi;
        string modul;
        int id;
        Islemler isl = new Islemler();
        frmAnaForm ana;
        string firma;
        string donem;
        public frmRaporDosya()
        {
            InitializeComponent();
            Listele();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            firma = ana.lk_firma.EditValue.ToString();
            donem = ana.lk_donem.EditValue.ToString();
            isl.TasarimGetir(gv_RaporDosyalari, ana._Kullanici.ID, this.Name, gridControlRaporDosyalari.Name);

        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LOGO_XERO_RAPOR_DOSYALARI satir =(LOGO_XERO_RAPOR_DOSYALARI) gv_RaporDosyalari.GetFocusedRow();
            if (satir != null)
            {
                using (LogoContext db =new LogoContext())
                {
                    LOGO_XERO_RAPOR_DOSYALARI rapor = db.LOGO_XERO_RAPOR_DOSYALARI.Where(s => s.ID == satir.ID).FirstOrDefault();
                    id = satir.ID;
                    Teklif report = new Teklif();
                    var dosya = rapor.DOSYA;
                    MemoryStream ms;
                    ms = new MemoryStream((byte[])dosya);
                    LOGO_XERO_TEKLIF_BASLIK bslk = new LOGO_XERO_TEKLIF_BASLIK();
                    List<LOGO_XERO_TEKLIF_SATIR> strlar = new List<LOGO_XERO_TEKLIF_SATIR>();
                    report.LoadLayout(ms);
                    report.DataSource = bslk;

                    form = new XRDesignForm();
                    XRDesignPanel panel = form.ActiveDesignPanel;
                    XRDesignBarManager bar = form.DesignBarManager;
                    XRDesignDockManager dock = form.DesignDockManager;
                    XRDesignMdiController mdiController = form.DesignMdiController;
                    mdiController.DesignPanelLoaded += new DesignerLoadedEventHandler(mdiController_DesignPanelLoaded);
                    mdiController.OpenReport(report);

                    form.ShowDialog();
                    Listele();
                }
            } 
        }
        XRDesignForm form;


        void mdiController_DesignPanelLoaded(object sender, DesignerLoadedEventArgs e)
        {
            XRDesignPanel panel1 = (XRDesignPanel)sender;

            if (id != 0)
            {
                panel1.AddCommandHandler(new SaveCommandHandler(panel1, dosyaAdi, modul, id,ana));
            }
            else
            {
                panel1.AddCommandHandler(new SaveCommandHandler(panel1, dosyaAdi, modul, 0,ana));
            }

            XRDesignDockManager dock = form.DesignDockManager;

            ObjectDataSource objectDataSource = new ObjectDataSource() { Name = "Teklif Alan Listesi", DataSource = typeof(TEKLIFYAZDIRMODEL) };
            panel1.Report.DataSource = objectDataSource;
            FieldListDockPanel fieldList = (FieldListDockPanel)dock[DesignDockPanelType.FieldList];
            IDesignerHost host = (IDesignerHost)panel1.GetService(typeof(IDesignerHost));
            fieldList.UpdateDataSource(host);
        }
        public void Listele()
        {
            using (LogoContext db = new LogoContext())
            {
                gridControlRaporDosyalari.DataSource = db.LOGO_XERO_RAPOR_DOSYALARI.Where(s => s.SABLON == 1).OrderBy(s => s.MODUL).ToList();
                gridControlRaporDosyalari.RefreshDataSource();
                gridControlRaporDosyalari.Refresh();
            }
        }

        private void tümünüSeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gv_RaporDosyalari.SelectAll();
        }

        private void seçilenleriKaldırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gv_RaporDosyalari.RowCount; i++)
            {
                gv_RaporDosyalari.UnselectRow(i);
            }
        }

        private void varsayılanYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LOGO_XERO_RAPOR_DOSYALARI satir = (LOGO_XERO_RAPOR_DOSYALARI)gv_RaporDosyalari.GetFocusedRow();
            if (satir != null)
            {
                try
                {
                    using (LogoContext db = new LogoContext())
                    {
                        string SQL = $@"UPDATE LOGO_XERO_RAPOR_DOSYALARI_{firma}_{donem} SET VARSAYILAN=0 WHERE MODUL='{satir.MODUL}';
                            UPDATE LOGO_XERO_RAPOR_DOSYALARI_{firma}_{donem} SET VARSAYILAN=1 WHERE ID={satir.ID}";
                        db.Database.ExecuteSqlCommand(SQL);
                    }

                    Listele();

                }
                catch (Exception)
                {

                }
            }
        }

        private void yeniRaporToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LOGO_XERO_RAPOR_DOSYALARI satir = (LOGO_XERO_RAPOR_DOSYALARI)gv_RaporDosyalari.GetFocusedRow();
            if (satir != null) 
            {
                modul = satir.MODUL;
                dosyaAdi = XtraInputBox.Show("Yeni Oluşturulacak Raporun Adını Giriniz : ", "Yeni Rapor , " + modul, "Yeni Rapor", XtraInputBox.Buttons.OK);
                id = 0;
                using (LogoContext db = new LogoContext())
                {
                    LOGO_XERO_RAPOR_DOSYALARI sablondosya = db.LOGO_XERO_RAPOR_DOSYALARI.Where(s => s.MODUL == modul && s.SABLON == 1).FirstOrDefault();
                    Teklif report = new Teklif();
                    MemoryStream ms;
                    var dosya = sablondosya.DOSYA;
                    ms = new MemoryStream((byte[])dosya);
                    report.LoadLayout(ms);

                    form = new XRDesignForm();

                    XRDesignBarManager bar = form.DesignBarManager;
                    XRDesignDockManager dock = form.DesignDockManager;
                    XRDesignPanel panel = form.ActiveDesignPanel;

                    XRDesignMdiController mdiController = form.DesignMdiController;
                    mdiController.DesignPanelLoaded += new DesignerLoadedEventHandler(mdiController_DesignPanelLoaded);

                    mdiController.OpenReport(report);
                    form.ShowDialog();
                    Listele();
                }
            }
            else
            {
                XtraMessageBox.Show("Tasarım Olusturmak İstediğiniz Bir Modül Üstünden İşlem Yapınız", "Uyarı");
            }
             
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LOGO_XERO_RAPOR_DOSYALARI satir = (LOGO_XERO_RAPOR_DOSYALARI) gv_RaporDosyalari.GetFocusedRow();
            if (satir!=null)
            {
                if (XtraMessageBox.Show("Silmek İstediğinize Emin Misiniz ?", "Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (LogoContext db = new LogoContext())
                        {
                            string SQL = $@"DELETE FROM LOGO_XERO_RAPOR_DOSYALARI_{firma}_{donem} WHERE ID = {satir.ID}";
                            db.Database.ExecuteSqlCommand(SQL);
                        }
                        XtraMessageBox.Show("Silme Onaylandı", "", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("AÇIKLAMA: " + ex, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } 
                    Listele();
                }
            } 

        }

        private void tasarımKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isl.TasarimKaydet(gv_RaporDosyalari, ana._Kullanici.ID, this.Name, gridControlRaporDosyalari.Name);
        }

        private void frmRaporDosya_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void frmRaporDosya_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                simpleButton1_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                simpleButton2_Click(sender, e);
            }
        }
    }
}