namespace LOGO_XERO.Moduller.GenelListeler
{
    partial class frmLotBilgileri
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
            this.grid_LotBilgileri = new DevExpress.XtraGrid.GridControl();
            this.gv_LotBilgileri = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdKod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdGiris = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdStokBakiyesi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_StokAdi = new DevExpress.XtraEditors.LabelControl();
            this.lbl_StokKodu = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grid_LotBilgileri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_LotBilgileri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid_LotBilgileri
            // 
            this.grid_LotBilgileri.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_LotBilgileri.Location = new System.Drawing.Point(12, 60);
            this.grid_LotBilgileri.MainView = this.gv_LotBilgileri;
            this.grid_LotBilgileri.Name = "grid_LotBilgileri";
            this.grid_LotBilgileri.Size = new System.Drawing.Size(943, 347);
            this.grid_LotBilgileri.TabIndex = 1;
            this.grid_LotBilgileri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_LotBilgileri});
            this.grid_LotBilgileri.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_LotBilgileri_KeyDown);
            // 
            // gv_LotBilgileri
            // 
            this.gv_LotBilgileri.Appearance.EvenRow.BackColor = System.Drawing.Color.Azure;
            this.gv_LotBilgileri.Appearance.EvenRow.BackColor2 = System.Drawing.Color.Azure;
            this.gv_LotBilgileri.Appearance.EvenRow.Options.UseBackColor = true;
            this.gv_LotBilgileri.Appearance.FocusedRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gv_LotBilgileri.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gv_LotBilgileri.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gv_LotBilgileri.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gv_LotBilgileri.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gv_LotBilgileri.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gv_LotBilgileri.Appearance.SelectedRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gv_LotBilgileri.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gv_LotBilgileri.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gv_LotBilgileri.ColumnPanelRowHeight = 20;
            this.gv_LotBilgileri.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdKod,
            this.grdAciklama,
            this.grdGiris,
            this.grdStokBakiyesi,
            this.gridColumn1});
            this.gv_LotBilgileri.FooterPanelHeight = 20;
            this.gv_LotBilgileri.GridControl = this.grid_LotBilgileri;
            this.gv_LotBilgileri.GroupRowHeight = 30;
            this.gv_LotBilgileri.IndicatorWidth = 20;
            this.gv_LotBilgileri.LevelIndent = 20;
            this.gv_LotBilgileri.Name = "gv_LotBilgileri";
            this.gv_LotBilgileri.OptionsBehavior.AllowIncrementalSearch = true;
            this.gv_LotBilgileri.OptionsBehavior.Editable = false;
            this.gv_LotBilgileri.OptionsView.BestFitMaxRowCount = 30;
            this.gv_LotBilgileri.OptionsView.EnableAppearanceEvenRow = true;
            this.gv_LotBilgileri.OptionsView.ShowGroupPanel = false;
            this.gv_LotBilgileri.PreviewIndent = 20;
            this.gv_LotBilgileri.PreviewLineCount = 20;
            this.gv_LotBilgileri.RowHeight = 20;
            this.gv_LotBilgileri.ViewCaptionHeight = 20;
            // 
            // grdKod
            // 
            this.grdKod.Caption = "Kodu";
            this.grdKod.FieldName = "KOD";
            this.grdKod.Name = "grdKod";
            this.grdKod.OptionsColumn.AllowEdit = false;
            this.grdKod.OptionsColumn.AllowFocus = false;
            this.grdKod.Visible = true;
            this.grdKod.VisibleIndex = 0;
            this.grdKod.Width = 148;
            // 
            // grdAciklama
            // 
            this.grdAciklama.Caption = "Açıklama";
            this.grdAciklama.FieldName = "ACIKLAMA";
            this.grdAciklama.Name = "grdAciklama";
            this.grdAciklama.OptionsColumn.AllowEdit = false;
            this.grdAciklama.OptionsColumn.AllowFocus = false;
            this.grdAciklama.Visible = true;
            this.grdAciklama.VisibleIndex = 1;
            this.grdAciklama.Width = 372;
            // 
            // grdGiris
            // 
            this.grdGiris.AppearanceCell.Options.UseTextOptions = true;
            this.grdGiris.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdGiris.Caption = "Giriş";
            this.grdGiris.FieldName = "GIRIS";
            this.grdGiris.Name = "grdGiris";
            this.grdGiris.OptionsColumn.AllowEdit = false;
            this.grdGiris.OptionsColumn.AllowFocus = false;
            this.grdGiris.Visible = true;
            this.grdGiris.VisibleIndex = 2;
            this.grdGiris.Width = 114;
            // 
            // grdStokBakiyesi
            // 
            this.grdStokBakiyesi.AppearanceCell.Options.UseTextOptions = true;
            this.grdStokBakiyesi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdStokBakiyesi.Caption = "Stok Bakiyesi";
            this.grdStokBakiyesi.FieldName = "STOKBAKIYESI";
            this.grdStokBakiyesi.Name = "grdStokBakiyesi";
            this.grdStokBakiyesi.OptionsColumn.AllowEdit = false;
            this.grdStokBakiyesi.OptionsColumn.AllowFocus = false;
            this.grdStokBakiyesi.Visible = true;
            this.grdStokBakiyesi.VisibleIndex = 3;
            this.grdStokBakiyesi.Width = 94;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Ambar";
            this.gridColumn1.FieldName = "AMBARADI";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Location = new System.Drawing.Point(12, 413);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(943, 48);
            this.panelControl1.TabIndex = 106;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.simpleButton1.Location = new System.Drawing.Point(848, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(90, 37);
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "[Esc] Vazgeç";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // lbl_StokAdi
            // 
            this.lbl_StokAdi.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl_StokAdi.Appearance.Options.UseFont = true;
            this.lbl_StokAdi.Location = new System.Drawing.Point(91, 32);
            this.lbl_StokAdi.Name = "lbl_StokAdi";
            this.lbl_StokAdi.Size = new System.Drawing.Size(0, 13);
            this.lbl_StokAdi.TabIndex = 156;
            // 
            // lbl_StokKodu
            // 
            this.lbl_StokKodu.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl_StokKodu.Appearance.Options.UseFont = true;
            this.lbl_StokKodu.Location = new System.Drawing.Point(91, 13);
            this.lbl_StokKodu.Name = "lbl_StokKodu";
            this.lbl_StokKodu.Size = new System.Drawing.Size(0, 13);
            this.lbl_StokKodu.TabIndex = 155;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(16, 32);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(67, 13);
            this.labelControl6.TabIndex = 154;
            this.labelControl6.Text = "Stok Adı        :";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(16, 13);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(67, 13);
            this.labelControl7.TabIndex = 153;
            this.labelControl7.Text = "Stok Kodu     :";
            // 
            // frmLotBilgileri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 467);
            this.Controls.Add(this.grid_LotBilgileri);
            this.Controls.Add(this.lbl_StokAdi);
            this.Controls.Add(this.lbl_StokKodu);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmLotBilgileri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lot Bilgileri";
            this.Load += new System.EventHandler(this.frmLotBilgileri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_LotBilgileri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_LotBilgileri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl grid_LotBilgileri;
        public DevExpress.XtraGrid.Views.Grid.GridView gv_LotBilgileri;
        private DevExpress.XtraGrid.Columns.GridColumn grdKod;
        private DevExpress.XtraGrid.Columns.GridColumn grdAciklama;
        private DevExpress.XtraGrid.Columns.GridColumn grdGiris;
        private DevExpress.XtraGrid.Columns.GridColumn grdStokBakiyesi;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        public DevExpress.XtraEditors.LabelControl lbl_StokAdi;
        public DevExpress.XtraEditors.LabelControl lbl_StokKodu;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
    }
}