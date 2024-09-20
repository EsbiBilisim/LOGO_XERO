namespace LOGO_XERO.Moduller._7_Raporlar
{
    partial class frmKarZararAnalizRenk
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
            this.txt_Simge = new DevExpress.XtraEditors.TextEdit();
            this.cm_aralik = new System.Windows.Forms.ComboBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txt_buyuksay = new DevExpress.XtraEditors.TextEdit();
            this.txt_kucuksay = new DevExpress.XtraEditors.TextEdit();
            this.color_sec = new DevExpress.XtraEditors.ColorPickEdit();
            this.grid_karzararrenk = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gv_karzararrenk = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btn_kaydet = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cm_oransec = new System.Windows.Forms.ComboBox();
            this.lbl_renkid = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Simge.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_buyuksay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_kucuksay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.color_sec.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_karzararrenk)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_karzararrenk)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Simge
            // 
            this.txt_Simge.Enabled = false;
            this.txt_Simge.Location = new System.Drawing.Point(261, 14);
            this.txt_Simge.Name = "txt_Simge";
            this.txt_Simge.Size = new System.Drawing.Size(63, 20);
            this.txt_Simge.TabIndex = 22;
            // 
            // cm_aralik
            // 
            this.cm_aralik.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cm_aralik.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cm_aralik.FormattingEnabled = true;
            this.cm_aralik.Location = new System.Drawing.Point(12, 12);
            this.cm_aralik.Name = "cm_aralik";
            this.cm_aralik.Size = new System.Drawing.Size(170, 22);
            this.cm_aralik.TabIndex = 21;
            this.cm_aralik.SelectedIndexChanged += new System.EventHandler(this.cm_aralik_SelectedIndexChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(334, 8);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(9, 25);
            this.labelControl3.TabIndex = 20;
            this.labelControl3.Text = "-";
            // 
            // txt_buyuksay
            // 
            this.txt_buyuksay.Location = new System.Drawing.Point(349, 13);
            this.txt_buyuksay.Name = "txt_buyuksay";
            this.txt_buyuksay.Properties.DisplayFormat.FormatString = "N0";
            this.txt_buyuksay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt_buyuksay.Properties.EditFormat.FormatString = "N0";
            this.txt_buyuksay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt_buyuksay.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            this.txt_buyuksay.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txt_buyuksay.Properties.UseMaskAsDisplayFormat = true;
            this.txt_buyuksay.Size = new System.Drawing.Size(56, 20);
            this.txt_buyuksay.TabIndex = 19;
            // 
            // txt_kucuksay
            // 
            this.txt_kucuksay.Location = new System.Drawing.Point(261, 13);
            this.txt_kucuksay.Name = "txt_kucuksay";
            this.txt_kucuksay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt_kucuksay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt_kucuksay.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txt_kucuksay.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            this.txt_kucuksay.Properties.UseMaskAsDisplayFormat = true;
            this.txt_kucuksay.Size = new System.Drawing.Size(63, 20);
            this.txt_kucuksay.TabIndex = 18;
            // 
            // color_sec
            // 
            this.color_sec.EditValue = System.Drawing.Color.Empty;
            this.color_sec.Location = new System.Drawing.Point(446, 13);
            this.color_sec.Name = "color_sec";
            this.color_sec.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.color_sec.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.color_sec.Size = new System.Drawing.Size(160, 20);
            this.color_sec.TabIndex = 17;
            // 
            // grid_karzararrenk
            // 
            this.grid_karzararrenk.ContextMenuStrip = this.contextMenuStrip1;
            this.grid_karzararrenk.Location = new System.Drawing.Point(12, 55);
            this.grid_karzararrenk.MainView = this.gv_karzararrenk;
            this.grid_karzararrenk.Name = "grid_karzararrenk";
            this.grid_karzararrenk.Size = new System.Drawing.Size(742, 397);
            this.grid_karzararrenk.TabIndex = 16;
            this.grid_karzararrenk.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_karzararrenk});
            this.grid_karzararrenk.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.silToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(87, 26);
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.silToolStripMenuItem.Text = "Sil";
            this.silToolStripMenuItem.Click += new System.EventHandler(this.silToolStripMenuItem_Click);
            // 
            // gv_karzararrenk
            // 
            this.gv_karzararrenk.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gv_karzararrenk.GridControl = this.grid_karzararrenk;
            this.gv_karzararrenk.Name = "gv_karzararrenk";
            this.gv_karzararrenk.OptionsView.ColumnAutoWidth = false;
            this.gv_karzararrenk.OptionsView.ShowGroupPanel = false;
            this.gv_karzararrenk.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView1_RowStyle);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Renk";
            this.gridColumn1.FieldName = "RENK";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Başlangıç";
            this.gridColumn2.FieldName = "YUZDEBASLANGIC";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Bitiş";
            this.gridColumn3.FieldName = "YUZDEBITIS";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // btn_kaydet
            // 
            this.btn_kaydet.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_kaydet.Appearance.Options.UseFont = true;
            this.btn_kaydet.Location = new System.Drawing.Point(663, 11);
            this.btn_kaydet.Name = "btn_kaydet";
            this.btn_kaydet.Size = new System.Drawing.Size(68, 25);
            this.btn_kaydet.TabIndex = 15;
            this.btn_kaydet.Text = "Kaydet";
            this.btn_kaydet.Click += new System.EventHandler(this.btn_kaydet_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(196, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(23, 23);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "%";
            // 
            // cm_oransec
            // 
            this.cm_oransec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cm_oransec.FormattingEnabled = true;
            this.cm_oransec.Location = new System.Drawing.Point(411, 15);
            this.cm_oransec.Name = "cm_oransec";
            this.cm_oransec.Size = new System.Drawing.Size(29, 21);
            this.cm_oransec.TabIndex = 23;
            this.cm_oransec.Visible = false;
            // 
            // lbl_renkid
            // 
            this.lbl_renkid.Location = new System.Drawing.Point(594, 36);
            this.lbl_renkid.Name = "lbl_renkid";
            this.lbl_renkid.Size = new System.Drawing.Size(63, 13);
            this.lbl_renkid.TabIndex = 24;
            this.lbl_renkid.Text = "labelControl3";
            this.lbl_renkid.Visible = false;
            // 
            // frmKarZararAnalizRenk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 461);
            this.Controls.Add(this.lbl_renkid);
            this.Controls.Add(this.cm_oransec);
            this.Controls.Add(this.txt_Simge);
            this.Controls.Add(this.cm_aralik);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txt_buyuksay);
            this.Controls.Add(this.txt_kucuksay);
            this.Controls.Add(this.color_sec);
            this.Controls.Add(this.grid_karzararrenk);
            this.Controls.Add(this.btn_kaydet);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmKarZararAnalizRenk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kar Zarar Analiz Renk";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmKarZararAnalizRenk_FormClosed);
            this.Load += new System.EventHandler(this.frmKarZararAnalizRenk_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_Simge.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_buyuksay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_kucuksay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.color_sec.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_karzararrenk)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv_karzararrenk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txt_Simge;
        private System.Windows.Forms.ComboBox cm_aralik;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txt_buyuksay;
        private DevExpress.XtraEditors.TextEdit txt_kucuksay;
        private DevExpress.XtraEditors.ColorPickEdit color_sec;
        private DevExpress.XtraGrid.GridControl grid_karzararrenk;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_karzararrenk;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.SimpleButton btn_kaydet;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ComboBox cm_oransec;
        public DevExpress.XtraEditors.LabelControl lbl_renkid;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
    }
}