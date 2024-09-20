namespace LOGO_XERO.Moduller.GenelListeler
{
    partial class frmStokEsleme
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
            this.gridStokEsleme = new DevExpress.XtraGrid.GridControl();
            this.gvStokEsleme = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpStokKodu = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.btn_kaydet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridStokEsleme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStokEsleme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpStokKodu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridStokEsleme
            // 
            this.gridStokEsleme.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridStokEsleme.Location = new System.Drawing.Point(12, 12);
            this.gridStokEsleme.MainView = this.gvStokEsleme;
            this.gridStokEsleme.Name = "gridStokEsleme";
            this.gridStokEsleme.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpStokKodu});
            this.gridStokEsleme.Size = new System.Drawing.Size(924, 467);
            this.gridStokEsleme.TabIndex = 0;
            this.gridStokEsleme.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvStokEsleme});
            // 
            // gvStokEsleme
            // 
            this.gvStokEsleme.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.gvStokEsleme.GridControl = this.gridStokEsleme;
            this.gvStokEsleme.Name = "gvStokEsleme";
            this.gvStokEsleme.OptionsBehavior.ReadOnly = true;
            this.gvStokEsleme.OptionsView.ShowFooter = true;
            this.gvStokEsleme.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Stok Kodu";
            this.gridColumn1.ColumnEdit = this.rpStokKodu;
            this.gridColumn1.FieldName = "STOKKODU";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // rpStokKodu
            // 
            this.rpStokKodu.AutoHeight = false;
            this.rpStokKodu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rpStokKodu.Name = "rpStokKodu";
            this.rpStokKodu.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rpStokKodu_ButtonClick);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Stok Adı";
            this.gridColumn2.FieldName = "STOKADI";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Birim";
            this.gridColumn3.FieldName = "BIRIM";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Stok Açıklama";
            this.gridColumn4.FieldName = "STOKACIKLAMA";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Satır Açıklama";
            this.gridColumn5.FieldName = "SATIRACIKLAMA";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Miktar";
            this.gridColumn6.FieldName = "MIKTAR";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Tutar";
            this.gridColumn7.FieldName = "TUTAR";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.simpleButton3);
            this.panelControl1.Controls.Add(this.btn_kaydet);
            this.panelControl1.Location = new System.Drawing.Point(12, 485);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(923, 48);
            this.panelControl1.TabIndex = 1;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.Location = new System.Drawing.Point(807, 6);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(111, 37);
            this.simpleButton3.TabIndex = 21;
            this.simpleButton3.Text = "[Esc] Kapat";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // btn_kaydet
            // 
            this.btn_kaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_kaydet.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_kaydet.Appearance.Options.UseFont = true;
            this.btn_kaydet.Location = new System.Drawing.Point(690, 6);
            this.btn_kaydet.Name = "btn_kaydet";
            this.btn_kaydet.Size = new System.Drawing.Size(111, 37);
            this.btn_kaydet.TabIndex = 23;
            this.btn_kaydet.Text = "[F2] Kaydet";
            this.btn_kaydet.Click += new System.EventHandler(this.btn_kaydet_Click);
            // 
            // frmStokEsleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 537);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gridStokEsleme);
            this.KeyPreview = true;
            this.Name = "frmStokEsleme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stok Eşleme";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmStokEsleme_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmStokEsleme_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridStokEsleme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStokEsleme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpStokKodu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpStokKodu;
        public DevExpress.XtraGrid.GridControl gridStokEsleme;
        public DevExpress.XtraGrid.Views.Grid.GridView gvStokEsleme;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        public DevExpress.XtraEditors.SimpleButton btn_kaydet;
    }
}