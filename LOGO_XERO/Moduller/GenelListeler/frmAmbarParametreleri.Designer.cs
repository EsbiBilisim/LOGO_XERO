namespace LOGO_XERO.Moduller.GenelListeler
{
    partial class frmAmbarParametreleri
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
            this.grid_stkambarparametreleri = new DevExpress.XtraGrid.GridControl();
            this.gv_stkambarparametreleri = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpNegatifSeviyeControl = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpAmbar = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_StokAdi = new DevExpress.XtraEditors.LabelControl();
            this.lbl_StokKodu = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grid_stkambarparametreleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_stkambarparametreleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpNegatifSeviyeControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpAmbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid_stkambarparametreleri
            // 
            this.grid_stkambarparametreleri.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_stkambarparametreleri.Location = new System.Drawing.Point(12, 60);
            this.grid_stkambarparametreleri.MainView = this.gv_stkambarparametreleri;
            this.grid_stkambarparametreleri.Name = "grid_stkambarparametreleri";
            this.grid_stkambarparametreleri.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpAmbar,
            this.rpNegatifSeviyeControl});
            this.grid_stkambarparametreleri.Size = new System.Drawing.Size(1124, 406);
            this.grid_stkambarparametreleri.TabIndex = 0;
            this.grid_stkambarparametreleri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_stkambarparametreleri});
            // 
            // gv_stkambarparametreleri
            // 
            this.gv_stkambarparametreleri.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gv_stkambarparametreleri.GridControl = this.grid_stkambarparametreleri;
            this.gv_stkambarparametreleri.Name = "gv_stkambarparametreleri";
            this.gv_stkambarparametreleri.OptionsView.ShowGroupPanel = false;
            this.gv_stkambarparametreleri.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gv_stkambarparametreleri_CellValueChanged);
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Stok Bakiyesi";
            this.gridColumn6.FieldName = "STOKBAKIYESI";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Min Miktar";
            this.gridColumn1.FieldName = "MINLEVEL";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Max Miktar";
            this.gridColumn2.FieldName = "MAXLEVEL";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Güvenli Miktar";
            this.gridColumn3.FieldName = "SAFELEVEL";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Negatif Seviye Kontrolü";
            this.gridColumn4.ColumnEdit = this.rpNegatifSeviyeControl;
            this.gridColumn4.FieldName = "NEGLEVELCTRL";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            // 
            // rpNegatifSeviyeControl
            // 
            this.rpNegatifSeviyeControl.AutoHeight = false;
            this.rpNegatifSeviyeControl.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpNegatifSeviyeControl.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", "Kontrol")});
            this.rpNegatifSeviyeControl.Name = "rpNegatifSeviyeControl";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Ambar";
            this.gridColumn5.ColumnEdit = this.rpAmbar;
            this.gridColumn5.FieldName = "INVENNO";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            // 
            // rpAmbar
            // 
            this.rpAmbar.AutoHeight = false;
            this.rpAmbar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpAmbar.Name = "rpAmbar";
            this.rpAmbar.ReadOnly = true;
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Location = new System.Drawing.Point(12, 473);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1124, 39);
            this.panelControl1.TabIndex = 1;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(1044, 5);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 29);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "[ESC] Kapat";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // lbl_StokAdi
            // 
            this.lbl_StokAdi.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl_StokAdi.Appearance.Options.UseFont = true;
            this.lbl_StokAdi.Location = new System.Drawing.Point(87, 31);
            this.lbl_StokAdi.Name = "lbl_StokAdi";
            this.lbl_StokAdi.Size = new System.Drawing.Size(0, 13);
            this.lbl_StokAdi.TabIndex = 118;
            // 
            // lbl_StokKodu
            // 
            this.lbl_StokKodu.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl_StokKodu.Appearance.Options.UseFont = true;
            this.lbl_StokKodu.Location = new System.Drawing.Point(87, 12);
            this.lbl_StokKodu.Name = "lbl_StokKodu";
            this.lbl_StokKodu.Size = new System.Drawing.Size(0, 13);
            this.lbl_StokKodu.TabIndex = 117;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 31);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(67, 13);
            this.labelControl4.TabIndex = 116;
            this.labelControl4.Text = "Stok Adı        :";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(67, 13);
            this.labelControl3.TabIndex = 115;
            this.labelControl3.Text = "Stok Kodu     :";
            // 
            // frmAmbarParametreleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 523);
            this.Controls.Add(this.lbl_StokAdi);
            this.Controls.Add(this.lbl_StokKodu);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.grid_stkambarparametreleri);
            this.KeyPreview = true;
            this.Name = "frmAmbarParametreleri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ambar Parametreleri";
            this.Load += new System.EventHandler(this.frmAmbarParametreleri_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAmbarParametreleri_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grid_stkambarparametreleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_stkambarparametreleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpNegatifSeviyeControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpAmbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid_stkambarparametreleri;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_stkambarparametreleri;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpAmbar;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpNegatifSeviyeControl;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        public DevExpress.XtraEditors.LabelControl lbl_StokAdi;
        public DevExpress.XtraEditors.LabelControl lbl_StokKodu;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}