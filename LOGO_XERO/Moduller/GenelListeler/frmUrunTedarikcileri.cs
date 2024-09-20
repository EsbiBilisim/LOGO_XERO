using DevExpress.CodeParser;
using DevExpress.DashboardWin.Design;
using DevExpress.XtraEditors;
using LOGO_XERO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGO_XERO.Moduller.GenelListeler
{
    public partial class frmUrunTedarikcileri : DevExpress.XtraEditors.XtraForm
    {
        SQLConnection clas = new SQLConnection();
        string firma = "";
        string donem = "";
        frmAnaForm ana;
        public frmUrunTedarikcileri()
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            firma = ana.lk_firma.EditValue.ToString();
            donem = ana.lk_donem.EditValue.ToString();
        }
        public void Liste(string stokKodu)
        { 
            clas.Connect();
            string SQL = string.Format($@"SELECT C.CODE [KODU], C.DEFINITION_ [UNVANI], C.TELNRS1 [TELEFON 1], C.TELNRS2 [TELEFON 2], C.EMAILADDR [EMAIL]
            FROM LG_{firma}_SUPPASGN S
            LEFT OUTER JOIN LG_{firma}_ITEMS I ON S.ITEMREF=I.LOGICALREF
            LEFT OUTER JOIN LG_{firma}_CLCARD C ON S.CLIENTREF=C.LOGICALREF
            WHERE I.CODE='{stokKodu}' AND S.LINENR=1");
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(SQL, clas.Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            grid_uruntedarikcileri.DataSource = ds.Tables[0];
            gv_uruntedarikcileri.OptionsBehavior.Editable = false;
            gv_uruntedarikcileri.BestFitColumns();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUrunTedarikcileri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                simpleButton1_Click(sender,e);
            }
        }
    }
}