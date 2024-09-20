namespace LOGO_XERO.Moduller.GenelListeler
{
    partial class frmStokFiyatListesi
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtForm = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CARIHESSPOZELKOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.YETKIKOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KDV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DOVIZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FIYAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpStokKodu = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.rpStokCinsi = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.rpFiyat = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtForm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpStokKodu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpStokCinsi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpFiyat)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.txtForm);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Location = new System.Drawing.Point(12, 400);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(907, 59);
            this.panelControl1.TabIndex = 18;
            // 
            // txtForm
            // 
            this.txtForm.Location = new System.Drawing.Point(5, 14);
            this.txtForm.Name = "txtForm";
            this.txtForm.Size = new System.Drawing.Size(45, 20);
            this.txtForm.TabIndex = 54;
            this.txtForm.Visible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.simpleButton1.Location = new System.Drawing.Point(812, 11);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(90, 37);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "[Esc] Kapat";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.Location = new System.Drawing.Point(12, 12);
            this.grid.MainView = this.gridView1;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpStokKodu,
            this.rpStokCinsi,
            this.rpFiyat});
            this.grid.Size = new System.Drawing.Size(907, 382);
            this.grid.TabIndex = 19;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grid.DoubleClick += new System.EventHandler(this.grid_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.Azure;
            this.gridView1.Appearance.EvenRow.BackColor2 = System.Drawing.Color.Azure;
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Tan;
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.ColumnPanelRowHeight = 35;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CARIHESSPOZELKOD,
            this.YETKIKOD,
            this.ACIKLAMA,
            this.KDV,
            this.DOVIZ,
            this.FIYAT});
            this.gridView1.FooterPanelHeight = 20;
            this.gridView1.GridControl = this.grid;
            this.gridView1.GroupRowHeight = 20;
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.LevelIndent = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.BestFitMaxRowCount = 30;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PreviewIndent = 20;
            this.gridView1.PreviewLineCount = 20;
            this.gridView1.RowHeight = 20;
            this.gridView1.ViewCaptionHeight = 20;
            // 
            // CARIHESSPOZELKOD
            // 
            this.CARIHESSPOZELKOD.Caption = "Cari Hesap Özelkod";
            this.CARIHESSPOZELKOD.FieldName = "CARIHESSPOZELKOD";
            this.CARIHESSPOZELKOD.Name = "CARIHESSPOZELKOD";
            this.CARIHESSPOZELKOD.Visible = true;
            this.CARIHESSPOZELKOD.VisibleIndex = 0;
            // 
            // YETKIKOD
            // 
            this.YETKIKOD.Caption = "Yetki Kodu";
            this.YETKIKOD.FieldName = "YETKIKOD";
            this.YETKIKOD.Name = "YETKIKOD";
            this.YETKIKOD.Visible = true;
            this.YETKIKOD.VisibleIndex = 1;
            // 
            // ACIKLAMA
            // 
            this.ACIKLAMA.Caption = "Açıklama";
            this.ACIKLAMA.FieldName = "ACIKLAMA";
            this.ACIKLAMA.Name = "ACIKLAMA";
            this.ACIKLAMA.Visible = true;
            this.ACIKLAMA.VisibleIndex = 2;
            // 
            // KDV
            // 
            this.KDV.Caption = "KDV";
            this.KDV.FieldName = "KDV";
            this.KDV.Name = "KDV";
            this.KDV.Visible = true;
            this.KDV.VisibleIndex = 3;
            // 
            // DOVIZ
            // 
            this.DOVIZ.Caption = "Döviz ";
            this.DOVIZ.FieldName = "DOVIZ";
            this.DOVIZ.Name = "DOVIZ";
            this.DOVIZ.Visible = true;
            this.DOVIZ.VisibleIndex = 4;
            // 
            // FIYAT
            // 
            this.FIYAT.Caption = "Fiyat";
            this.FIYAT.FieldName = "FIYAT";
            this.FIYAT.Name = "FIYAT";
            this.FIYAT.Visible = true;
            this.FIYAT.VisibleIndex = 5;
            // 
            // rpStokKodu
            // 
            this.rpStokKodu.AutoHeight = false;
            this.rpStokKodu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rpStokKodu.Name = "rpStokKodu";
            // 
            // rpStokCinsi
            // 
            this.rpStokCinsi.AutoHeight = false;
            this.rpStokCinsi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rpStokCinsi.Name = "rpStokCinsi";
            // 
            // rpFiyat
            // 
            this.rpFiyat.AutoHeight = false;
            this.rpFiyat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rpFiyat.Name = "rpFiyat";
            // 
            // frmStokFiyatListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 468);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.grid);
            this.KeyPreview = true;
            this.Name = "frmStokFiyatListesi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fiyat Listesi";
            this.Load += new System.EventHandler(this.frmCariSonSatisFiyatListesi_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmStokFiyatListesi_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtForm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpStokKodu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpStokCinsi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpFiyat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        public DevExpress.XtraEditors.TextEdit txtForm;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.GridControl grid;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpStokKodu;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpStokCinsi;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpFiyat;
        private DevExpress.XtraGrid.Columns.GridColumn CARIHESSPOZELKOD;
        private DevExpress.XtraGrid.Columns.GridColumn YETKIKOD;
        private DevExpress.XtraGrid.Columns.GridColumn ACIKLAMA;
        private DevExpress.XtraGrid.Columns.GridColumn KDV;
        private DevExpress.XtraGrid.Columns.GridColumn DOVIZ;
        private DevExpress.XtraGrid.Columns.GridColumn FIYAT;
    }
}