namespace LOGO_XERO.Moduller.GenelListeler
{
    partial class frmKampanyaFiyat
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
            this.grid_kampanyafiyatlist = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tasarımKaydetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gv_kampanyafiyatlist = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grid_kampanyafiyatlist)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_kampanyafiyatlist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid_kampanyafiyatlist
            // 
            this.grid_kampanyafiyatlist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_kampanyafiyatlist.ContextMenuStrip = this.contextMenuStrip1;
            this.grid_kampanyafiyatlist.Location = new System.Drawing.Point(12, 12);
            this.grid_kampanyafiyatlist.MainView = this.gv_kampanyafiyatlist;
            this.grid_kampanyafiyatlist.Name = "grid_kampanyafiyatlist";
            this.grid_kampanyafiyatlist.Size = new System.Drawing.Size(817, 537);
            this.grid_kampanyafiyatlist.TabIndex = 0;
            this.grid_kampanyafiyatlist.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_kampanyafiyatlist});
            this.grid_kampanyafiyatlist.DoubleClick += new System.EventHandler(this.grid_kampanyafiyatlist_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tasarımKaydetToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(154, 26);
            // 
            // tasarımKaydetToolStripMenuItem
            // 
            this.tasarımKaydetToolStripMenuItem.Name = "tasarımKaydetToolStripMenuItem";
            this.tasarımKaydetToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.tasarımKaydetToolStripMenuItem.Text = "Tasarım Kaydet";
            this.tasarımKaydetToolStripMenuItem.Click += new System.EventHandler(this.tasarımKaydetToolStripMenuItem_Click);
            // 
            // gv_kampanyafiyatlist
            // 
            this.gv_kampanyafiyatlist.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.gv_kampanyafiyatlist.GridControl = this.grid_kampanyafiyatlist;
            this.gv_kampanyafiyatlist.Name = "gv_kampanyafiyatlist";
            this.gv_kampanyafiyatlist.OptionsBehavior.Editable = false;
            this.gv_kampanyafiyatlist.OptionsBehavior.ReadOnly = true;
            this.gv_kampanyafiyatlist.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Kampanya Kodu";
            this.gridColumn1.FieldName = "KAMPANYAKODU";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Döviz";
            this.gridColumn2.FieldName = "DOVIZ";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Döviz Kodu";
            this.gridColumn3.FieldName = "DOVIZKODU";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowShowHide = false;
            this.gridColumn3.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Liste Fiyatı";
            this.gridColumn4.FieldName = "LISTEFIYATI";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "İskonto Oranı";
            this.gridColumn5.FieldName = "ISKONTOORANI";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Kampanya TL Fiyatı";
            this.gridColumn6.FieldName = "KAMPANYATLFIYATI";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Kampanya Fiyatı";
            this.gridColumn7.FieldName = "KAMPANYAFIYATI";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Location = new System.Drawing.Point(12, 555);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(817, 52);
            this.panelControl1.TabIndex = 107;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.simpleButton1.Location = new System.Drawing.Point(722, 8);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(90, 37);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "[Esc] Vazgeç";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmKampanyaFiyat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 619);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.grid_kampanyafiyatlist);
            this.KeyPreview = true;
            this.Name = "frmKampanyaFiyat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kampanya Fiyat Listesi";
            this.Load += new System.EventHandler(this.frmKampanyaFiyat_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmKampanyaFiyat_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grid_kampanyafiyatlist)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv_kampanyafiyatlist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid_kampanyafiyatlist;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_kampanyafiyatlist;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tasarımKaydetToolStripMenuItem;
    }
}