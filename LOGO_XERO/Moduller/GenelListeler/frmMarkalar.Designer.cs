namespace LOGO_XERO.Moduller.GenelListeler
{
    partial class frmMarkalar
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.grid_marka = new DevExpress.XtraGrid.GridControl();
            this.gv_marka = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btn_yetkikodu = new DevExpress.XtraEditors.ButtonEdit();
            this.btn_ozelkod = new DevExpress.XtraEditors.ButtonEdit();
            this.txt_markaaciklama = new DevExpress.XtraEditors.TextEdit();
            this.txt_kod = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.güncelleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_marka)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_marka)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_yetkikodu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_ozelkod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_markaaciklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_kod.Properties)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Location = new System.Drawing.Point(12, 549);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(590, 50);
            this.panelControl1.TabIndex = 103;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.simpleButton1.Location = new System.Drawing.Point(495, 7);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(90, 37);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "[Esc] Vazgeç";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // grid_marka
            // 
            this.grid_marka.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_marka.ContextMenuStrip = this.contextMenuStrip1;
            this.grid_marka.Location = new System.Drawing.Point(12, 109);
            this.grid_marka.MainView = this.gv_marka;
            this.grid_marka.Name = "grid_marka";
            this.grid_marka.Size = new System.Drawing.Size(590, 434);
            this.grid_marka.TabIndex = 102;
            this.grid_marka.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_marka});
            this.grid_marka.DoubleClick += new System.EventHandler(this.grid_marka_DoubleClick);
            // 
            // gv_marka
            // 
            this.gv_marka.Appearance.EvenRow.BackColor = System.Drawing.Color.Azure;
            this.gv_marka.Appearance.EvenRow.BackColor2 = System.Drawing.Color.Azure;
            this.gv_marka.Appearance.EvenRow.Options.UseBackColor = true;
            this.gv_marka.Appearance.FocusedCell.BackColor = System.Drawing.Color.Tan;
            this.gv_marka.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Tan;
            this.gv_marka.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gv_marka.Appearance.FocusedRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gv_marka.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gv_marka.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gv_marka.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gv_marka.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gv_marka.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gv_marka.Appearance.SelectedRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gv_marka.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gv_marka.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gv_marka.ColumnPanelRowHeight = 30;
            this.gv_marka.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gv_marka.FooterPanelHeight = 20;
            this.gv_marka.GridControl = this.grid_marka;
            this.gv_marka.GroupRowHeight = 20;
            this.gv_marka.IndicatorWidth = 20;
            this.gv_marka.LevelIndent = 20;
            this.gv_marka.Name = "gv_marka";
            this.gv_marka.OptionsBehavior.Editable = false;
            this.gv_marka.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gv_marka.OptionsView.BestFitMaxRowCount = 30;
            this.gv_marka.OptionsView.EnableAppearanceEvenRow = true;
            this.gv_marka.OptionsView.ShowAutoFilterRow = true;
            this.gv_marka.OptionsView.ShowGroupPanel = false;
            this.gv_marka.PreviewIndent = 20;
            this.gv_marka.PreviewLineCount = 20;
            this.gv_marka.RowHeight = 20;
            this.gv_marka.ViewCaptionHeight = 20;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Kodu";
            this.gridColumn1.FieldName = "CODE";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 261;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Açıklama";
            this.gridColumn2.FieldName = "DESCR";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 349;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Özel Kod";
            this.gridColumn3.FieldName = "SPECODE";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Yetki Kodu";
            this.gridColumn4.FieldName = "CYPHCODE";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.btn_yetkikodu);
            this.groupControl1.Controls.Add(this.btn_ozelkod);
            this.groupControl1.Controls.Add(this.txt_markaaciklama);
            this.groupControl1.Controls.Add(this.txt_kod);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.simpleButton4);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(590, 91);
            this.groupControl1.TabIndex = 104;
            this.groupControl1.Text = "Marka Ekleme";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(265, 57);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(50, 13);
            this.labelControl4.TabIndex = 29;
            this.labelControl4.Text = "Yetki Kodu";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(265, 33);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(42, 13);
            this.labelControl3.TabIndex = 28;
            this.labelControl3.Text = "Özel Kod";
            // 
            // btn_yetkikodu
            // 
            this.btn_yetkikodu.Location = new System.Drawing.Point(321, 56);
            this.btn_yetkikodu.Name = "btn_yetkikodu";
            this.btn_yetkikodu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btn_yetkikodu.Properties.MaxLength = 11;
            this.btn_yetkikodu.Size = new System.Drawing.Size(135, 20);
            this.btn_yetkikodu.TabIndex = 27;
            this.btn_yetkikodu.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btn_yetkikodu_ButtonClick);
            // 
            // btn_ozelkod
            // 
            this.btn_ozelkod.Location = new System.Drawing.Point(321, 30);
            this.btn_ozelkod.Name = "btn_ozelkod";
            this.btn_ozelkod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btn_ozelkod.Properties.MaxLength = 11;
            this.btn_ozelkod.Size = new System.Drawing.Size(135, 20);
            this.btn_ozelkod.TabIndex = 26;
            this.btn_ozelkod.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btn_ozelkod_ButtonClick);
            // 
            // txt_markaaciklama
            // 
            this.txt_markaaciklama.Location = new System.Drawing.Point(57, 56);
            this.txt_markaaciklama.Name = "txt_markaaciklama";
            this.txt_markaaciklama.Properties.MaxLength = 51;
            this.txt_markaaciklama.Size = new System.Drawing.Size(202, 20);
            this.txt_markaaciklama.TabIndex = 25;
            // 
            // txt_kod
            // 
            this.txt_kod.Location = new System.Drawing.Point(57, 30);
            this.txt_kod.Name = "txt_kod";
            this.txt_kod.Properties.MaxLength = 25;
            this.txt_kod.Size = new System.Drawing.Size(202, 20);
            this.txt_kod.TabIndex = 24;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 57);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 13);
            this.labelControl2.TabIndex = 23;
            this.labelControl2.Text = "Açıklaması";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 13);
            this.labelControl1.TabIndex = 22;
            this.labelControl1.Text = "Kodu";
            // 
            // simpleButton4
            // 
            this.simpleButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.simpleButton4.Appearance.Options.UseFont = true;
            this.simpleButton4.Location = new System.Drawing.Point(474, 33);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(111, 37);
            this.simpleButton4.TabIndex = 21;
            this.simpleButton4.Text = "[F2] Kaydet";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.güncelleToolStripMenuItem,
            this.toolStripSeparator1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(121, 32);
            // 
            // güncelleToolStripMenuItem
            // 
            this.güncelleToolStripMenuItem.Name = "güncelleToolStripMenuItem";
            this.güncelleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.güncelleToolStripMenuItem.Text = "Güncelle";
            this.güncelleToolStripMenuItem.Click += new System.EventHandler(this.güncelleToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // frmMarkalar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 611);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.grid_marka);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMarkalar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Markalar";
            this.Load += new System.EventHandler(this.frmMarkalar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMarkalar_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_marka)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_marka)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_yetkikodu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_ozelkod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_markaaciklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_kod.Properties)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.GridControl grid_marka;
        public DevExpress.XtraGrid.Views.Grid.GridView gv_marka;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txt_markaaciklama;
        private DevExpress.XtraEditors.TextEdit txt_kod;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        public DevExpress.XtraEditors.ButtonEdit btn_yetkikodu;
        public DevExpress.XtraEditors.ButtonEdit btn_ozelkod;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem güncelleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}