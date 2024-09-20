using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using LOGO_XERO.Models;
using LOGO_XERO.Moduller.Personeller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static LOGO_XERO.Moduller.Personeller.frmKullaniciEkle;
using DevExpress.XtraEditors;

namespace LOGO_XERO.Moduller.Giris_AnaForm_Ayarlar
{
    public partial class frmGorevler : DevExpress.XtraEditors.DirectXForm
    {
        SQLConnection clas = new SQLConnection();

        frmKullaniciEkle frm;

        public int gridid;
        public frmGorevler()
        {
            InitializeComponent();

        }
        public frmGorevler(frmKullaniciEkle frm1)
        {
            InitializeComponent();
            frm = frm1;
            gridctrlgorev.ContextMenuStrip = null;
        }

        private void frmGorevler_Load(object sender, EventArgs e)
        {
            GorevleriGetir();
            IslemleriGetir();
        }

        public void GorevleriGetir()
        {
            clas.Connect();
            string sqlParametre = $@"SELECT * FROM LOGO_XERO_GOREVLER";
            SqlCommand cmd = new SqlCommand(sqlParametre, clas.Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridctrlgorev.DataSource = ds.Tables[0];
            gridctrlgorev.RefreshDataSource();
            gridctrlgorev.Refresh();
        }

        public void IslemleriGetir()
        {
            clas.Connect();
            İşlemler.OptionsView.ShowCheckBoxes = true;
            İşlemler.OptionsBehavior.PopulateServiceColumns = true;

            string query = "SELECT * FROM LOGO_XERO_YETKILER";

            using (SqlDataAdapter adapter = new SqlDataAdapter(query, clas.Conn))
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                DataTable table = ds.Tables[0];

                İşlemler.DataSource = table;

                İşlemler.KeyFieldName = "YETKIID";
                İşlemler.ParentFieldName = "USTYETKIID";

                İşlemler.Columns.Clear();

                var colID = İşlemler.Columns.Add();
                colID.FieldName = "ID";
                colID.Caption = "ID";
                colID.Visible = false;

                var colYETKIID = İşlemler.Columns.Add();
                colYETKIID.FieldName = "YETKIID";
                colYETKIID.Caption = "Yetki Id";
                colYETKIID.Visible = false;

                var colYETKI = İşlemler.Columns.Add();
                colYETKI.FieldName = "YETKI";
                colYETKI.Caption = "Yetki";
                colYETKI.Visible = true;

                var colUSTYETKIID = İşlemler.Columns.Add();
                colUSTYETKIID.FieldName = "USTYETKIID";
                colUSTYETKIID.Caption = "Üst Yetki ID";
                colUSTYETKIID.Visible = false;

                var colKAYITTARIHI = İşlemler.Columns.Add();
                colKAYITTARIHI.FieldName = "KAYITTARIHI";
                colKAYITTARIHI.Caption = "Kayıt Tarihi";
                colKAYITTARIHI.Visible = false;

                İşlemler.ExpandAll();
            }
        }

        private void gv_gorev_DoubleClick(object sender, EventArgs e)
        {
            if (frm == null)
            {
                return;
            }
            try
            {
                var satir = gv_gorev.GetFocusedRow();
                if (satir != null)
                {
                    frm.gorevid = Convert.ToInt32(gv_gorev.GetFocusedRowCellValue("ID"));
                    frm.btntxt_görevi.Text = gv_gorev.GetFocusedRowCellValue("GOREVTANIMI").ToString();
                    LoadPermissionsGorevi(Convert.ToInt32(gv_gorev.GetFocusedRowCellValue("ID")),sender,e);
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:" + ex);
            }

        }

        private void LoadPermissions(int id)
        {
            İşlemler.UncheckAll();

            clas.Connect();
            clas.Conn.Open();
            try
            {
                string query = "SELECT YETKI FROM LOGO_XERO_GOREVLER WHERE ID = @GorevID";

                using (SqlCommand command = new SqlCommand(query, clas.Conn))
                {
                    command.Parameters.AddWithValue("@GorevID", id);
                    var result = command.ExecuteScalar();
                    if (result == System.DBNull.Value || result == null)
                    {
                        İşlemler.UncheckAll();
                        return;
                    }
                    var yetkiler = (string)result;
                    if (!string.IsNullOrEmpty(yetkiler))
                    {
                        var yetkiIds = yetkiler.Split(',').Select(int.Parse).ToList();
                        CheckNodes(yetkiIds);
                    }
                }
            }
            finally
            {
                if (clas.Conn != null && clas.Conn.State == ConnectionState.Open)
                {
                    clas.Conn.Close();
                }
            }
        }

        private void LoadPermissionsGorevi(int id, object sender, EventArgs e)
        {
            frm.İşlemler.UncheckAll();

            clas.Connect();
            clas.Conn.Open();
            try
            {
                string query = "SELECT YETKI FROM LOGO_XERO_GOREVLER WHERE ID = @GorevID";

                using (SqlCommand command = new SqlCommand(query, clas.Conn))
                {
                    command.Parameters.AddWithValue("@GorevID", id);
                    var result = command.ExecuteScalar();
                    if (result == System.DBNull.Value || result == null)
                    {
                        frm.İşlemler.UncheckAll();
                        return;
                    }
                    var yetkiler = (string)result;
                    if (!string.IsNullOrEmpty(yetkiler))
                    {
                        var yetkiIds = yetkiler.Split(',').Select(int.Parse).ToList();
                        CheckNodesGorevi(yetkiIds,sender,e);
                    }
                }
            }
            finally
            {
                if (clas.Conn != null && clas.Conn.State == ConnectionState.Open)
                {
                    clas.Conn.Close();
                }
            }
        }

        private void CheckNodes(List<int> yetkiIds)
        {
            foreach (var id in yetkiIds)
            {
                var node = İşlemler.FindNodeByKeyID(id);
                if (node != null)
                {
                    node.CheckState = CheckState.Checked;
                }
            }
            İşlemler.Refresh();
        }

        private void CheckNodesGorevi(List<int> yetkiIds, object sender, EventArgs e)
        {
            foreach (var id in yetkiIds)
            {
                var node = frm.İşlemler.FindNodeByKeyID(id);
                if (node != null)
                {
                    frm.İşlemler.SetNodeCheckState(node, CheckState.Checked, true);
                    //node.CheckState = CheckState.Checked;
                    //node.Checked = true;
                    //if (frm != null)
                    //{
                    //    NodeEventArgs ee =
                    //    frm.İşlemler_AfterCheckNode(sender, ee);
                    //}

                }
            }
        }

        private void İşlemler_AfterCheckNode(object sender, NodeEventArgs e)
        {
            UpdateChildNodesCheckState(e.Node, e.Node.CheckState);
            UpdateParentNodesCheckState(e.Node);

            var checkedNodes = İşlemler.GetAllCheckedNodes();
            var selectedIds = checkedNodes.Select(node => (int)node.GetValue("YETKIID")).OrderBy(id => id).ToList();

            var selectedIdsString = string.Join(",", selectedIds);
            UpdateYetkiInDatabase(selectedIdsString, gridid);

        }

        private void UpdateChildNodesCheckState(TreeListNode node, CheckState checkState)
        {
            foreach (TreeListNode childNode in node.Nodes)
            {
                childNode.CheckState = checkState;
                UpdateChildNodesCheckState(childNode, checkState);
            }
        }

        private void UpdateParentNodesCheckState(TreeListNode node)
        {
            if (node.ParentNode != null)
            {
                bool allSiblingsChecked = true;
                bool allSiblingsUnchecked = true;

                foreach (TreeListNode siblingNode in node.ParentNode.Nodes)
                {
                    if (siblingNode.CheckState != CheckState.Checked)
                    {
                        allSiblingsChecked = false;
                    }
                    if (siblingNode.CheckState != CheckState.Unchecked)
                    {
                        allSiblingsUnchecked = false;
                    }
                }

                if (allSiblingsChecked)
                {
                    node.ParentNode.CheckState = CheckState.Checked;
                }
                else if (allSiblingsUnchecked)
                {
                    node.ParentNode.CheckState = CheckState.Unchecked;
                }

                UpdateParentNodesCheckState(node.ParentNode);
            }
        }

        private void UpdateYetkiInDatabase(string selectedIds, int id)
        {
            clas.Connect();
            clas.Conn.Open();
            try
            {
                string query = "UPDATE LOGO_XERO_GOREVLER SET YETKI = @Yetki WHERE ID = @GorevID";

                using (SqlCommand command = new SqlCommand(query, clas.Conn))
                {
                    command.Parameters.AddWithValue("@Yetki", selectedIds);
                    command.Parameters.AddWithValue("@GorevID", id);

                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                if (clas.Conn != null && clas.Conn.State == ConnectionState.Open)
                {
                    clas.Conn.Close();
                }
            }
        }

        private void gridctrlgorev_Click(object sender, EventArgs e)
        {
            gridid = Convert.ToInt32(gv_gorev.GetFocusedRowCellValue("ID"));
            LoadPermissions(gridid);
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gv_gorev.GetFocusedRowCellValue("ID"));
            if (GoreveTanimliKisiSayisi(id) == 0)
            {
                if (MessageBox.Show("Görevi Silmeyi Onaylıyor Musunuz ? ", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    GorevSil(id);
                    MessageBox.Show("Görev Silme Başarılı !");
                    GorevleriGetir();
                    IslemleriGetir();
                }
            }
            else
            {
                MessageBox.Show("Göreve Tanımlı Kullanıcı Bulunmakta Görev Silinemez !");
                return;

            }
            GorevleriGetir();
            IslemleriGetir();
        }
        public void GorevSil(int id)
        {
            clas.Connect();
            clas.Conn.Open();
            try
            {
                string query = "DELETE FROM LOGO_XERO_GOREVLER WHERE ID = @GorevID";

                using (SqlCommand command = new SqlCommand(query, clas.Conn))
                {
                    command.Parameters.AddWithValue("@GorevID", id);

                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                if (clas.Conn != null && clas.Conn.State == ConnectionState.Open)
                {
                    clas.Conn.Close();
                }
            }
        }

        public int GoreveTanimliKisiSayisi(int görevid)
        {
            clas.Connect();
            string sqlParametre = $@"select COUNT(ID)  AS 'KULLANICISAYISI' from LOGO_XERO_KULLANICILAR WHERE GOREV = @gorevid";
            SqlCommand cmd = new SqlCommand(sqlParametre, clas.Conn);
            cmd.Parameters.AddWithValue("@gorevid", görevid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int kullanicisayisi = (int)Convert.ToInt32(ds.Tables[0].Rows[0]["KULLANICISAYISI"]);
            return kullanicisayisi;
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var gorevadi = XtraInputBox.Show("Görev Adı Giriniz", "Görev Adı", "Görev Adı");
            if (string.IsNullOrWhiteSpace(gorevadi))
            {
                return;
            }
            if (GorevAdiBos(gorevadi))
            {
                Gorevekle(gorevadi);
                GorevleriGetir();
                IslemleriGetir();
            }
            else
            {
                MessageBox.Show("Aynı İsimde Görev Tanımlı ");
                return;
            }
        }
        public void Gorevekle(string gorevadi)
        {
            clas.Connect();
            clas.Conn.Open();
            try
            {
                string query = $@"INSERT INTO [dbo].[LOGO_XERO_GOREVLER]
                               ([GOREVTANIMI]
                               ,[YETKI])
                         VALUES
                               (@GorevID
                               ,0)";

                using (SqlCommand command = new SqlCommand(query, clas.Conn))
                {
                    command.Parameters.AddWithValue("@GorevID", gorevadi);
                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                if (clas.Conn != null && clas.Conn.State == ConnectionState.Open)
                {
                    clas.Conn.Close();
                }
            }
        }

        public bool GorevAdiBos(string görevad)
        {
            clas.Connect();
            string sqlParametre = $@"select COUNT(ID)  AS 'GOREV' from LOGO_XERO_GOREVLER WHERE GOREVTANIMI = '{görevad}'";
            SqlCommand cmd = new SqlCommand(sqlParametre, clas.Conn);
            //cmd.Parameters.AddWithValue("@gorevad", görevad);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int gorevsayisi = (int)Convert.ToInt32(ds.Tables[0].Rows[0]["GOREV"]);
            if (gorevsayisi == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}