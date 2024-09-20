namespace LOGO_XERO.Moduller.Giris_AnaForm_Ayarlar
{
    partial class frmGorevler
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.directXFormContainerControl1 = new DevExpress.XtraEditors.DirectXFormContainerControl();
            this.İşlemler = new DevExpress.XtraTreeList.TreeList();
            this.İslemler = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.gridctrlgorev = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ekleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gv_gorev = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GOREVTANIMI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.directXFormContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.İşlemler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridctrlgorev)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_gorev)).BeginInit();
            this.SuspendLayout();
            // 
            // directXFormContainerControl1
            // 
            this.directXFormContainerControl1.Controls.Add(this.İşlemler);
            this.directXFormContainerControl1.Controls.Add(this.gridctrlgorev);
            this.directXFormContainerControl1.Location = new System.Drawing.Point(8, 30);
            this.directXFormContainerControl1.Name = "directXFormContainerControl1";
            this.directXFormContainerControl1.Size = new System.Drawing.Size(1120, 465);
            this.directXFormContainerControl1.TabIndex = 0;
            // 
            // İşlemler
            // 
            this.İşlemler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.İşlemler.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.İslemler});
            this.İşlemler.CustomizationFormBounds = new System.Drawing.Rectangle(428, 463, 266, 236);
            this.İşlemler.Location = new System.Drawing.Point(566, 0);
            this.İşlemler.Name = "İşlemler";
            this.İşlemler.OptionsBehavior.Editable = false;
            this.İşlemler.OptionsBehavior.PopulateServiceColumns = true;
            this.İşlemler.OptionsPrint.PrintFilledTreeIndent = true;
            this.İşlemler.OptionsPrint.PrintPageHeader = false;
            this.İşlemler.OptionsPrint.PrintReportFooter = false;
            this.İşlemler.OptionsView.ShowBandsMode = DevExpress.Utils.DefaultBoolean.True;
            this.İşlemler.OptionsView.ShowTreeLines = DevExpress.Utils.DefaultBoolean.True;
            this.İşlemler.Size = new System.Drawing.Size(550, 464);
            this.İşlemler.TabIndex = 1;
            this.İşlemler.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.İşlemler_AfterCheckNode);
            // 
            // İslemler
            // 
            this.İslemler.Caption = "İşlemler";
            this.İslemler.FieldName = "İşlemler";
            this.İslemler.Name = "İslemler";
            this.İslemler.OptionsColumn.AllowSort = true;
            this.İslemler.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.İslemler.Visible = true;
            this.İslemler.VisibleIndex = 0;
            // 
            // gridctrlgorev
            // 
            this.gridctrlgorev.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gridctrlgorev.ContextMenuStrip = this.contextMenuStrip1;
            this.gridctrlgorev.Location = new System.Drawing.Point(0, 0);
            this.gridctrlgorev.MainView = this.gv_gorev;
            this.gridctrlgorev.Name = "gridctrlgorev";
            this.gridctrlgorev.Size = new System.Drawing.Size(550, 464);
            this.gridctrlgorev.TabIndex = 0;
            this.gridctrlgorev.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_gorev});
            this.gridctrlgorev.Click += new System.EventHandler(this.gridctrlgorev_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ekleToolStripMenuItem,
            this.silToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 70);
            // 
            // ekleToolStripMenuItem
            // 
            this.ekleToolStripMenuItem.Name = "ekleToolStripMenuItem";
            this.ekleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ekleToolStripMenuItem.Text = "Ekle";
            this.ekleToolStripMenuItem.Click += new System.EventHandler(this.ekleToolStripMenuItem_Click);
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.silToolStripMenuItem.Text = "Sil";
            this.silToolStripMenuItem.Click += new System.EventHandler(this.silToolStripMenuItem_Click);
            // 
            // gv_gorev
            // 
            this.gv_gorev.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.GOREVTANIMI});
            this.gv_gorev.GridControl = this.gridctrlgorev;
            this.gv_gorev.Name = "gv_gorev";
            this.gv_gorev.OptionsBehavior.Editable = false;
            this.gv_gorev.OptionsBehavior.ReadOnly = true;
            this.gv_gorev.OptionsView.ShowGroupPanel = false;
            this.gv_gorev.DoubleClick += new System.EventHandler(this.gv_gorev_DoubleClick);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // GOREVTANIMI
            // 
            this.GOREVTANIMI.Caption = "Görev Tanımı";
            this.GOREVTANIMI.FieldName = "GOREVTANIMI";
            this.GOREVTANIMI.Name = "GOREVTANIMI";
            this.GOREVTANIMI.Visible = true;
            this.GOREVTANIMI.VisibleIndex = 0;
            // 
            // frmGorevler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 503);
            this.Controls.Add(this.directXFormContainerControl1);
            this.DoubleBuffered = true;
            this.Name = "frmGorevler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Görevler";
            this.Load += new System.EventHandler(this.frmGorevler_Load);
            this.directXFormContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.İşlemler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridctrlgorev)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv_gorev)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DirectXFormContainerControl directXFormContainerControl1;
        private DevExpress.XtraGrid.GridControl gridctrlgorev;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_gorev;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn GOREVTANIMI;
        private DevExpress.XtraTreeList.TreeList İşlemler;
        private DevExpress.XtraTreeList.Columns.TreeListColumn İslemler;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ekleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
    }
}