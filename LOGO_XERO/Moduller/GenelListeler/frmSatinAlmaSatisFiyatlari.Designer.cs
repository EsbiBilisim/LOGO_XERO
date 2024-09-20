namespace LOGO_XERO.Moduller.GenelListeler
{
    partial class frmSatinAlmaSatisFiyatlari
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grid_satisfiyatlari = new DevExpress.XtraGrid.GridControl();
            this.gv_SatisFiy = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grid_satinalmafiyatlari = new DevExpress.XtraGrid.GridControl();
            this.gv_SatinAlmaFiy = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tasarımKaydetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_satisfiyatlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_SatisFiy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_satinalmafiyatlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_SatinAlmaFiy)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.grid_satisfiyatlari, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.grid_satinalmafiyatlari, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 9);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1083, 608);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // grid_satisfiyatlari
            // 
            this.grid_satisfiyatlari.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_satisfiyatlari.Location = new System.Drawing.Point(544, 9);
            this.grid_satisfiyatlari.MainView = this.gv_SatisFiy;
            this.grid_satisfiyatlari.Name = "grid_satisfiyatlari";
            this.grid_satisfiyatlari.Size = new System.Drawing.Size(530, 590);
            this.grid_satisfiyatlari.TabIndex = 0;
            this.grid_satisfiyatlari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_SatisFiy});
            // 
            // gv_SatisFiy
            // 
            this.gv_SatisFiy.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14});
            this.gv_SatisFiy.GridControl = this.grid_satisfiyatlari;
            this.gv_SatisFiy.Name = "gv_SatisFiy";
            this.gv_SatisFiy.OptionsBehavior.Editable = false;
            this.gv_SatisFiy.OptionsView.ColumnAutoWidth = false;
            this.gv_SatisFiy.OptionsView.ShowGroupPanel = false;
            this.gv_SatisFiy.OptionsView.ShowViewCaption = true;
            this.gv_SatisFiy.ViewCaption = "TANIMLI SATINALMA FİYATLARI";
            // 
            // grid_satinalmafiyatlari
            // 
            this.grid_satinalmafiyatlari.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_satinalmafiyatlari.Location = new System.Drawing.Point(9, 9);
            this.grid_satinalmafiyatlari.MainView = this.gv_SatinAlmaFiy;
            this.grid_satinalmafiyatlari.Name = "grid_satinalmafiyatlari";
            this.grid_satinalmafiyatlari.Size = new System.Drawing.Size(529, 590);
            this.grid_satinalmafiyatlari.TabIndex = 1;
            this.grid_satinalmafiyatlari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_SatinAlmaFiy});
            // 
            // gv_SatinAlmaFiy
            // 
            this.gv_SatinAlmaFiy.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.gv_SatinAlmaFiy.GridControl = this.grid_satinalmafiyatlari;
            this.gv_SatinAlmaFiy.Name = "gv_SatinAlmaFiy";
            this.gv_SatinAlmaFiy.OptionsBehavior.Editable = false;
            this.gv_SatinAlmaFiy.OptionsView.ColumnAutoWidth = false;
            this.gv_SatinAlmaFiy.OptionsView.ShowGroupPanel = false;
            this.gv_SatinAlmaFiy.OptionsView.ShowViewCaption = true;
            this.gv_SatinAlmaFiy.ViewCaption = "TANIMLI SATINALMA FİYATLARI";
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
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Yetki Kodu";
            this.gridColumn1.FieldName = "YETKIKODU";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 70;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Cari Hes. Özel Kod";
            this.gridColumn2.FieldName = "CARIHESAPOZELKOD";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 98;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Açıklama";
            this.gridColumn3.FieldName = "ACIKLAMA";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 79;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Kdv";
            this.gridColumn4.FieldName = "KDV";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 48;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Kdv D/H";
            this.gridColumn5.FieldName = "KDVDAHIL";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 61;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Döviz";
            this.gridColumn6.FieldName = "DOVIZ";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 48;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Fiyat";
            this.gridColumn7.DisplayFormat.FormatString = "n2";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "FIYAT";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 76;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Yetki Kodu";
            this.gridColumn8.FieldName = "YETKIKODU";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            this.gridColumn8.Width = 70;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Cari Hes. Özel Kod";
            this.gridColumn9.FieldName = "CARIHESAPOZELKOD";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            this.gridColumn9.Width = 98;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Açıklama";
            this.gridColumn10.FieldName = "ACIKLAMA";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 2;
            this.gridColumn10.Width = 79;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Kdv";
            this.gridColumn11.FieldName = "KDV";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 3;
            this.gridColumn11.Width = 48;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Kdv D/H";
            this.gridColumn12.FieldName = "KDVDAHIL";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 4;
            this.gridColumn12.Width = 61;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Döviz";
            this.gridColumn13.FieldName = "DOVIZ";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 5;
            this.gridColumn13.Width = 48;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Fiyat";
            this.gridColumn14.DisplayFormat.FormatString = "n2";
            this.gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn14.FieldName = "FIYAT";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 6;
            this.gridColumn14.Width = 76;
            // 
            // frmSatinAlmaSatisFiyatlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 626);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmSatinAlmaSatisFiyatlari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FİYAT LİSTESİ";
            this.Load += new System.EventHandler(this.frmSatinAlmaSatisFiyatlari_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_satisfiyatlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_SatisFiy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_satinalmafiyatlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_SatinAlmaFiy)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl grid_satisfiyatlari;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_SatisFiy;
        private DevExpress.XtraGrid.GridControl grid_satinalmafiyatlari;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_SatinAlmaFiy;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tasarımKaydetToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
    }
}