namespace LOGO_XERO.Moduller._7_Raporlar
{
    partial class frmCariEkstre
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gv_cariekstredetay = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grid_cariekstre = new DevExpress.XtraGrid.GridControl();
            this.gv_cariekstre = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.ck = new DevExpress.XtraEditors.CheckEdit();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.lblOrtalamaVadeTarihi = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtCariKodu = new DevExpress.XtraEditors.TextEdit();
            this.txtUnvan = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtSon = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.txtIlk = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gv_cariekstredetay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_cariekstre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_cariekstre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ck.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCariKodu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnvan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSon.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIlk.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIlk.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gv_cariekstredetay
            // 
            this.gv_cariekstredetay.GridControl = this.grid_cariekstre;
            this.gv_cariekstredetay.Name = "gv_cariekstredetay";
            this.gv_cariekstredetay.OptionsBehavior.ReadOnly = true;
            // 
            // grid_cariekstre
            // 
            this.grid_cariekstre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            gridLevelNode1.LevelTemplate = this.gv_cariekstredetay;
            gridLevelNode1.RelationName = "Level1";
            this.grid_cariekstre.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grid_cariekstre.Location = new System.Drawing.Point(12, 12);
            this.grid_cariekstre.MainView = this.gv_cariekstre;
            this.grid_cariekstre.Name = "grid_cariekstre";
            this.grid_cariekstre.Size = new System.Drawing.Size(1275, 522);
            this.grid_cariekstre.TabIndex = 2;
            this.grid_cariekstre.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_cariekstre,
            this.gv_cariekstredetay});
            this.grid_cariekstre.DoubleClick += new System.EventHandler(this.grid_cariekstre_DoubleClick);
            // 
            // gv_cariekstre
            // 
            this.gv_cariekstre.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15});
            this.gv_cariekstre.GridControl = this.grid_cariekstre;
            this.gv_cariekstre.Name = "gv_cariekstre";
            this.gv_cariekstre.OptionsView.ColumnAutoWidth = false;
            this.gv_cariekstre.OptionsView.EnableAppearanceEvenRow = true;
            this.gv_cariekstre.OptionsView.ShowAutoFilterRow = true;
            this.gv_cariekstre.OptionsView.ShowGroupPanel = false;
            this.gv_cariekstre.MasterRowExpanded += new DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventHandler(this.gv_cariekstre_MasterRowExpanded);
            this.gv_cariekstre.MasterRowGetChildList += new DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventHandler(this.gv_cariekstre_MasterRowGetChildList);
            this.gv_cariekstre.MasterRowGetRelationCount += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventHandler(this.gv_cariekstre_MasterRowGetRelationCount);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Cari Kodu";
            this.gridColumn1.FieldName = "BAYIKODU";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Client Ref";
            this.gridColumn2.FieldName = "CLIENTREF";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Sref";
            this.gridColumn3.FieldName = "SREF";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Tarih";
            this.gridColumn4.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn4.FieldName = "TARIH";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Fiş No";
            this.gridColumn5.FieldName = "FISNO";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Fiş Türü";
            this.gridColumn6.FieldName = "FISTURU";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Belge No";
            this.gridColumn7.FieldName = "BELGENO";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Açıklama";
            this.gridColumn8.FieldName = "ACIKLAMA";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Borç";
            this.gridColumn9.DisplayFormat.FormatString = "n2";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn9.FieldName = "BORC";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BORC", "{0:n2}")});
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Alacak";
            this.gridColumn10.DisplayFormat.FormatString = "n2";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn10.FieldName = "ALACAK";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ALACAK", "{0:n2}")});
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Bakiye";
            this.gridColumn11.DisplayFormat.FormatString = "n2";
            this.gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn11.FieldName = "BAKIYE";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 10;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "TrKod";
            this.gridColumn12.FieldName = "TRKOD";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Cari Ünvanı";
            this.gridColumn13.FieldName = "CARIUNVANI";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Proje Kodu";
            this.gridColumn14.FieldName = "PROJEKODU";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 5;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Proje";
            this.gridColumn15.FieldName = "PROJE";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 6;
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.ck);
            this.panelControl1.Controls.Add(this.simpleButton4);
            this.panelControl1.Controls.Add(this.lblOrtalamaVadeTarihi);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.txtCariKodu);
            this.panelControl1.Controls.Add(this.txtUnvan);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.txtSon);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.simpleButton3);
            this.panelControl1.Controls.Add(this.txtIlk);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Location = new System.Drawing.Point(12, 540);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1275, 79);
            this.panelControl1.TabIndex = 21;
            // 
            // ck
            // 
            this.ck.Location = new System.Drawing.Point(627, 47);
            this.ck.Name = "ck";
            this.ck.Properties.Caption = "Tüm Listeyi Göster";
            this.ck.Size = new System.Drawing.Size(124, 19);
            this.ck.TabIndex = 104;
            // 
            // simpleButton4
            // 
            this.simpleButton4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.simpleButton4.Location = new System.Drawing.Point(920, 17);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(105, 46);
            this.simpleButton4.TabIndex = 103;
            this.simpleButton4.Text = "[F6] Detaylı Yazdır";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // lblOrtalamaVadeTarihi
            // 
            this.lblOrtalamaVadeTarihi.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblOrtalamaVadeTarihi.Appearance.Options.UseFont = true;
            this.lblOrtalamaVadeTarihi.Location = new System.Drawing.Point(557, 17);
            this.lblOrtalamaVadeTarihi.Name = "lblOrtalamaVadeTarihi";
            this.lblOrtalamaVadeTarihi.Size = new System.Drawing.Size(64, 14);
            this.lblOrtalamaVadeTarihi.TabIndex = 102;
            this.lblOrtalamaVadeTarihi.Text = "00.00.0000";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(412, 17);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(134, 14);
            this.labelControl4.TabIndex = 101;
            this.labelControl4.Text = "Ortalama Vade Tarihi :";
            // 
            // txtCariKodu
            // 
            this.txtCariKodu.Location = new System.Drawing.Point(73, 43);
            this.txtCariKodu.Name = "txtCariKodu";
            this.txtCariKodu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtCariKodu.Properties.Appearance.Options.UseFont = true;
            this.txtCariKodu.Properties.AutoHeight = false;
            this.txtCariKodu.Properties.ReadOnly = true;
            this.txtCariKodu.Size = new System.Drawing.Size(22, 25);
            this.txtCariKodu.TabIndex = 99;
            this.txtCariKodu.Visible = false;
            // 
            // txtUnvan
            // 
            this.txtUnvan.Location = new System.Drawing.Point(101, 43);
            this.txtUnvan.Name = "txtUnvan";
            this.txtUnvan.Properties.AutoHeight = false;
            this.txtUnvan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtUnvan.Properties.ReadOnly = true;
            this.txtUnvan.Size = new System.Drawing.Size(298, 25);
            this.txtUnvan.TabIndex = 42;
            this.txtUnvan.TabStop = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(8, 49);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(59, 14);
            this.labelControl3.TabIndex = 41;
            this.labelControl3.Text = "Cari Ünvanı";
            // 
            // txtSon
            // 
            this.txtSon.EditValue = null;
            this.txtSon.Location = new System.Drawing.Point(292, 12);
            this.txtSon.Name = "txtSon";
            this.txtSon.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtSon.Properties.Appearance.Options.UseFont = true;
            this.txtSon.Properties.AutoHeight = false;
            this.txtSon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSon.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSon.Size = new System.Drawing.Size(107, 25);
            this.txtSon.TabIndex = 40;
            this.txtSon.TabStop = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(225, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(54, 14);
            this.labelControl1.TabIndex = 39;
            this.labelControl1.Text = "Bitiş Tarihi";
            // 
            // simpleButton3
            // 
            this.simpleButton3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.Location = new System.Drawing.Point(412, 44);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(209, 25);
            this.simpleButton3.TabIndex = 38;
            this.simpleButton3.Text = "[F5] Filtrele";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // txtIlk
            // 
            this.txtIlk.EditValue = null;
            this.txtIlk.Location = new System.Drawing.Point(101, 12);
            this.txtIlk.Name = "txtIlk";
            this.txtIlk.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtIlk.Properties.Appearance.Options.UseFont = true;
            this.txtIlk.Properties.AutoHeight = false;
            this.txtIlk.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtIlk.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtIlk.Size = new System.Drawing.Size(107, 25);
            this.txtIlk.TabIndex = 37;
            this.txtIlk.TabStop = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(8, 17);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(81, 14);
            this.labelControl2.TabIndex = 36;
            this.labelControl2.Text = "Başlangıç Tarihi";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.simpleButton2.Location = new System.Drawing.Point(1044, 17);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(105, 46);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "[F4] Yazdır";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.simpleButton1.Location = new System.Drawing.Point(1165, 17);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(105, 46);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "[Esc] Kapat";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmCariEkstre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 631);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.grid_cariekstre);
            this.Name = "frmCariEkstre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cari Ekstre";
            this.Load += new System.EventHandler(this.frmCariEkstre_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gv_cariekstredetay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_cariekstre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_cariekstre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ck.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCariKodu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnvan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSon.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIlk.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIlk.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid_cariekstre;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_cariekstre;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        public DevExpress.XtraEditors.TextEdit txtCariKodu;
        public DevExpress.XtraEditors.ButtonEdit txtUnvan;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.DateEdit txtSon;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.SimpleButton simpleButton3;
        public DevExpress.XtraEditors.DateEdit txtIlk;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl lblOrtalamaVadeTarihi;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.CheckEdit ck;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_cariekstredetay;
    }
}