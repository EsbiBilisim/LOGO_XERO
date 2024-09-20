using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using LOGO_XERO.Models;
using LOGO_XERO.Models.LOGO_XERO_M;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGO_XERO.ext
{
    public class SaveCommandHandler : DevExpress.XtraReports.UserDesigner.ICommandHandler
    {
        XRDesignPanel panel;
        string dosyaadi, modul;
        int id;
        frmAnaForm ana;
        string firma;
        string donem;

        public SaveCommandHandler(XRDesignPanel panel, string dosyaadi, string modul, int id, frmAnaForm ana)
        {
            this.panel = panel;
            this.dosyaadi = dosyaadi;
            this.modul = modul;
            this.id = id;
            this.ana = ana;
            firma = ana.lk_firma.EditValue.ToString();
            donem = ana.lk_donem.EditValue.ToString();
        }

        public void HandleCommand(DevExpress.XtraReports.UserDesigner.ReportCommand command,
        object[] args)
        {
            Save();
        }

        public bool CanHandleCommand(DevExpress.XtraReports.UserDesigner.ReportCommand command,
        ref bool useNextHandler)
        {
            useNextHandler = !(command == ReportCommand.SaveFile ||
                command == ReportCommand.SaveFileAs);
            return !useNextHandler;
        }

        void Save()
        {
            try
            {
                using (LogoContext db = new LogoContext())
                {
                    var dosya = StoreReportToStream(panel.Report);

                    byte[] array = new byte[dosya.Length];
                    array = dosya.ToArray();

                    string SQL = string.Empty;

                    if (id > 0)
                    {
                        LOGO_XERO_RAPOR_DOSYALARI rapordosya = db.LOGO_XERO_RAPOR_DOSYALARI.Where(s => s.ID == id).FirstOrDefault();
                        if (rapordosya != null)
                        {
                            rapordosya.DOSYA = array;
                            db.Entry(rapordosya);
                            db.SaveChanges();
                        } 
                    }
                    else
                    {
                        LOGO_XERO_RAPOR_DOSYALARI rapordosya = new LOGO_XERO_RAPOR_DOSYALARI();
                        rapordosya.MODUL = modul;
                        rapordosya.RAPORADI = dosyaadi;
                        rapordosya.DOSYA = array;
                        rapordosya.SABLON = 1;
                        rapordosya.AKTIF = true;
                        rapordosya.DOVIZLI =false;
                        rapordosya.VARSAYILAN =false;
                        db.LOGO_XERO_RAPOR_DOSYALARI.Add(rapordosya);
                        db.SaveChanges();
                    } 
                    panel.ReportState = ReportState.Saved;
                }
                XtraMessageBox.Show("Rapor Kaydedildi", "Kaydedildi");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Rapor Kaydederken Hata :" + ex, "HATA");
            }

        }
        private MemoryStream StoreReportToStream(XtraReport report)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Flush();
            stream.Position = 0;
            report.SaveLayout(stream);
            return stream;
        }
    }
}

