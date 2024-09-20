using DevExpress.XtraEditors;
using LOGO_XERO.Models;
using LOGO_XERO.Moduller.GenelListeler;
using LOGO_XERO.Models.LOGO_M;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGO_XERO
{
    public partial class frmTasiyiciBilgileri : DevExpress.XtraEditors.XtraForm
    {
        public frmTasiyiciBilgileri()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmTasiyiciKoduEkleme frmTasiyiciKoduEkleme = new frmTasiyiciKoduEkleme(this);
            frmTasiyiciKoduEkleme.ShowDialog();
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            L_SHPAGENT row = (L_SHPAGENT)gridView1.GetFocusedRow();
            if (row != null)
            {
                frmTasiyiciKoduEkleme frmTasiyiciKoduEkleme = new frmTasiyiciKoduEkleme(this);
                frmTasiyiciKoduEkleme.guncellenecekKayit = row;
                frmTasiyiciKoduEkleme.ShowDialog();
            }
        }
        private void frmTasiyiciBilgileri_Load(object sender, EventArgs e)
        {
            Listele();
        }
        public void Listele()
        {
            using (LogoContext db = new LogoContext())
            {
                gridControl1.DataSource = db.L_SHPAGENT.ToList();
            }

        }
    }
}