using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using LOGO_XERO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace LOGO_XERO.Moduller.Personeller
{
    public partial class frmYetkilendirme : DevExpress.XtraEditors.XtraForm
    {
        SQLConnection clas = new SQLConnection();
        int klnid;
        public frmYetkilendirme(int _klnid)
        {
            InitializeComponent();
            this.klnid = _klnid;
        }

        private void frmYetkilendirme_Load(object sender, EventArgs e)
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

                LoadUserPermissions(klnid);
            }
        }

        private void LoadUserPermissions(int userId)
        {
            clas.Connect();
            clas.Conn.Open();
            try
            {
                string query = "SELECT YETKI FROM LOGO_XERO_KULLANICILAR WHERE ID = @KullaniciID";

                using (SqlCommand command = new SqlCommand(query, clas.Conn))
                {
                    command.Parameters.AddWithValue("@KullaniciID", userId);

                    if (command.ExecuteScalar() == System.DBNull.Value)
                    {
                        İşlemler.UncheckAll();
                        return;
                    }
                    var yetkiler = (string)command.ExecuteScalar();
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
        }

        private void İşlemler_AfterCheckNode(object sender, NodeEventArgs e)
        {
            UpdateChildNodesCheckState(e.Node, e.Node.CheckState);
            UpdateParentNodesCheckState(e.Node);

            var checkedNodes = İşlemler.GetAllCheckedNodes();
            var selectedIds = checkedNodes.Select(node => (int)node.GetValue("YETKIID")).OrderBy(id => id).ToList();

            var selectedIdsString = string.Join(",", selectedIds);

            UpdateYetkiInDatabase(selectedIdsString);
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

        private void UpdateYetkiInDatabase(string selectedIds)
        {
            clas.Connect();
            clas.Conn.Open();
            try
            {
                string query = "UPDATE LOGO_XERO_KULLANICILAR SET YETKI = @Yetki WHERE ID = @KullaniciID";

                using (SqlCommand command = new SqlCommand(query, clas.Conn))
                {
                    command.Parameters.AddWithValue("@Yetki", selectedIds);
                    command.Parameters.AddWithValue("@KullaniciID", klnid);

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

    }
}