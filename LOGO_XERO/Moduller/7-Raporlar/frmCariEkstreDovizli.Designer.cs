namespace LOGO_XERO.Moduller._7_Raporlar
{
    partial class frmCariEkstreDovizli
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
            this.gvDetay = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grid_CariHesapDovizliEkstre = new DevExpress.XtraGrid.GridControl();
            this.gv_CarihesapDovizliEkstre = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lkk_kurbilgi = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl53 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.lblOrtalamaVadeTarihi = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.ck = new DevExpress.XtraEditors.CheckEdit();
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
            ((System.ComponentModel.ISupportInitialize)(this.gvDetay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_CariHesapDovizliEkstre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_CarihesapDovizliEkstre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkk_kurbilgi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ck.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCariKodu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnvan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSon.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIlk.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIlk.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gvDetay
            // 
            this.gvDetay.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8F);
            this.gvDetay.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.gvDetay.ColumnPanelRowHeight = 25;
            this.gvDetay.GridControl = this.grid_CariHesapDovizliEkstre;
            this.gvDetay.Name = "gvDetay";
            // 
            // grid_CariHesapDovizliEkstre
            // 
            this.grid_CariHesapDovizliEkstre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            gridLevelNode1.LevelTemplate = this.gvDetay;
            gridLevelNode1.RelationName = "Level1";
            this.grid_CariHesapDovizliEkstre.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grid_CariHesapDovizliEkstre.Location = new System.Drawing.Point(12, 12);
            this.grid_CariHesapDovizliEkstre.MainView = this.gv_CarihesapDovizliEkstre;
            this.grid_CariHesapDovizliEkstre.Name = "grid_CariHesapDovizliEkstre";
            this.grid_CariHesapDovizliEkstre.Size = new System.Drawing.Size(1142, 471);
            this.grid_CariHesapDovizliEkstre.TabIndex = 19;
            this.grid_CariHesapDovizliEkstre.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_CarihesapDovizliEkstre,
            this.gvDetay});
            // 
            // gv_CarihesapDovizliEkstre
            // 
            this.gv_CarihesapDovizliEkstre.Appearance.EvenRow.BackColor = System.Drawing.Color.Azure;
            this.gv_CarihesapDovizliEkstre.Appearance.EvenRow.BackColor2 = System.Drawing.Color.Azure;
            this.gv_CarihesapDovizliEkstre.Appearance.EvenRow.Options.UseBackColor = true;
            this.gv_CarihesapDovizliEkstre.Appearance.FocusedCell.BackColor = System.Drawing.Color.Tan;
            this.gv_CarihesapDovizliEkstre.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Tan;
            this.gv_CarihesapDovizliEkstre.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gv_CarihesapDovizliEkstre.Appearance.FocusedRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gv_CarihesapDovizliEkstre.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gv_CarihesapDovizliEkstre.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gv_CarihesapDovizliEkstre.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gv_CarihesapDovizliEkstre.Appearance.FocusedRow.Options.UseFont = true;
            this.gv_CarihesapDovizliEkstre.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gv_CarihesapDovizliEkstre.Appearance.FooterPanel.Options.UseFont = true;
            this.gv_CarihesapDovizliEkstre.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gv_CarihesapDovizliEkstre.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gv_CarihesapDovizliEkstre.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gv_CarihesapDovizliEkstre.Appearance.SelectedRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gv_CarihesapDovizliEkstre.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gv_CarihesapDovizliEkstre.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gv_CarihesapDovizliEkstre.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 7F);
            this.gv_CarihesapDovizliEkstre.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.gv_CarihesapDovizliEkstre.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 7F);
            this.gv_CarihesapDovizliEkstre.AppearancePrint.Row.Options.UseFont = true;
            this.gv_CarihesapDovizliEkstre.ColumnPanelRowHeight = 30;
            this.gv_CarihesapDovizliEkstre.FooterPanelHeight = 20;
            this.gv_CarihesapDovizliEkstre.GridControl = this.grid_CariHesapDovizliEkstre;
            this.gv_CarihesapDovizliEkstre.GroupRowHeight = 20;
            this.gv_CarihesapDovizliEkstre.IndicatorWidth = 20;
            this.gv_CarihesapDovizliEkstre.LevelIndent = 20;
            this.gv_CarihesapDovizliEkstre.Name = "gv_CarihesapDovizliEkstre";
            this.gv_CarihesapDovizliEkstre.OptionsCustomization.AllowColumnMoving = false;
            this.gv_CarihesapDovizliEkstre.OptionsCustomization.AllowGroup = false;
            this.gv_CarihesapDovizliEkstre.OptionsCustomization.AllowSort = false;
            this.gv_CarihesapDovizliEkstre.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gv_CarihesapDovizliEkstre.OptionsView.BestFitMaxRowCount = 30;
            this.gv_CarihesapDovizliEkstre.OptionsView.EnableAppearanceEvenRow = true;
            this.gv_CarihesapDovizliEkstre.OptionsView.ShowAutoFilterRow = true;
            this.gv_CarihesapDovizliEkstre.OptionsView.ShowFooter = true;
            this.gv_CarihesapDovizliEkstre.OptionsView.ShowGroupPanel = false;
            this.gv_CarihesapDovizliEkstre.PreviewIndent = 20;
            this.gv_CarihesapDovizliEkstre.PreviewLineCount = 20;
            this.gv_CarihesapDovizliEkstre.RowHeight = 20;
            this.gv_CarihesapDovizliEkstre.ViewCaptionHeight = 20;
            this.gv_CarihesapDovizliEkstre.MasterRowExpanded += new DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventHandler(this.gv_CarihesapDovizliEkstre_MasterRowExpanded);
            this.gv_CarihesapDovizliEkstre.MasterRowGetChildList += new DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventHandler(this.gv_CarihesapDovizliEkstre_MasterRowGetChildList);
            this.gv_CarihesapDovizliEkstre.MasterRowGetRelationCount += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventHandler(this.gv_CarihesapDovizliEkstre_MasterRowGetRelationCount);
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.lkk_kurbilgi);
            this.panelControl1.Controls.Add(this.labelControl53);
            this.panelControl1.Controls.Add(this.simpleButton4);
            this.panelControl1.Controls.Add(this.lblOrtalamaVadeTarihi);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.ck);
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
            this.panelControl1.Location = new System.Drawing.Point(12, 489);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1142, 78);
            this.panelControl1.TabIndex = 20;
            // 
            // lkk_kurbilgi
            // 
            this.lkk_kurbilgi.Location = new System.Drawing.Point(446, 45);
            this.lkk_kurbilgi.Name = "lkk_kurbilgi";
            this.lkk_kurbilgi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkk_kurbilgi.Properties.NullText = "Kur Seçiniz";
            this.lkk_kurbilgi.Properties.PopupView = this.gridLookUpEdit1View;
            this.lkk_kurbilgi.Size = new System.Drawing.Size(100, 20);
            this.lkk_kurbilgi.TabIndex = 105;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Kur";
            this.gridColumn2.FieldName = "CURCODE";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "gridColumn3";
            this.gridColumn3.FieldName = "CURTYPE";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            // 
            // labelControl53
            // 
            this.labelControl53.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl53.Appearance.Options.UseFont = true;
            this.labelControl53.Location = new System.Drawing.Point(411, 48);
            this.labelControl53.Name = "labelControl53";
            this.labelControl53.Size = new System.Drawing.Size(28, 14);
            this.labelControl53.TabIndex = 104;
            this.labelControl53.Text = "Döviz";
            // 
            // simpleButton4
            // 
            this.simpleButton4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.simpleButton4.Location = new System.Drawing.Point(840, 22);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(105, 37);
            this.simpleButton4.TabIndex = 103;
            this.simpleButton4.Text = "[F6] Detaylı Yazdır";
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
            // ck
            // 
            this.ck.Location = new System.Drawing.Point(648, 45);
            this.ck.Name = "ck";
            this.ck.Properties.Caption = "Tüm Listeyi Göster";
            this.ck.Size = new System.Drawing.Size(124, 19);
            this.ck.TabIndex = 100;
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
            this.simpleButton3.Location = new System.Drawing.Point(552, 42);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(90, 25);
            this.simpleButton3.TabIndex = 38;
            this.simpleButton3.Text = "[F5] Listele";
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
            this.simpleButton2.Location = new System.Drawing.Point(951, 22);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(90, 37);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "[F4] Yazdır";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.simpleButton1.Location = new System.Drawing.Point(1047, 22);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(90, 37);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "[Esc] Kapat";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmCariEkstreDovizli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 579);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.grid_CariHesapDovizliEkstre);
            this.Name = "frmCariEkstreDovizli";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cari Hesap Dövizli Ekstre";
            ((System.ComponentModel.ISupportInitialize)(this.gvDetay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_CariHesapDovizliEkstre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_CarihesapDovizliEkstre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkk_kurbilgi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
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

        private DevExpress.XtraGrid.GridControl grid_CariHesapDovizliEkstre;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetay;
        public DevExpress.XtraGrid.Views.Grid.GridView gv_CarihesapDovizliEkstre;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        public DevExpress.XtraEditors.GridLookUpEdit lkk_kurbilgi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.LabelControl labelControl53;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.LabelControl lblOrtalamaVadeTarihi;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.CheckEdit ck;
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
    }
}