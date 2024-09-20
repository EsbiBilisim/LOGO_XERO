namespace LOGO_XERO.Moduller.GenelListeler
{
    partial class frmStokListesiUrunAlisSatisForm
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
            this.grid_UrunAlisSatis = new DevExpress.XtraGrid.GridControl();
            this.gv_UrunAlisSatis = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_StokAdi = new DevExpress.XtraEditors.LabelControl();
            this.lbl_StokKodu = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tasarımıKaydetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.grid_UrunAlisSatis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_UrunAlisSatis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid_UrunAlisSatis
            // 
            this.grid_UrunAlisSatis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_UrunAlisSatis.Location = new System.Drawing.Point(12, 61);
            this.grid_UrunAlisSatis.MainView = this.gv_UrunAlisSatis;
            this.grid_UrunAlisSatis.Name = "grid_UrunAlisSatis";
            this.grid_UrunAlisSatis.Size = new System.Drawing.Size(946, 332);
            this.grid_UrunAlisSatis.TabIndex = 213;
            this.grid_UrunAlisSatis.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_UrunAlisSatis});
            // 
            // gv_UrunAlisSatis
            // 
            this.gv_UrunAlisSatis.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn25,
            this.gridColumn27,
            this.gridColumn28,
            this.gridColumn29,
            this.gridColumn30,
            this.gridColumn31,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gv_UrunAlisSatis.GridControl = this.grid_UrunAlisSatis;
            this.gv_UrunAlisSatis.Name = "gv_UrunAlisSatis";
            this.gv_UrunAlisSatis.OptionsBehavior.Editable = false;
            this.gv_UrunAlisSatis.OptionsView.ColumnAutoWidth = false;
            this.gv_UrunAlisSatis.OptionsView.ShowFooter = true;
            this.gv_UrunAlisSatis.OptionsView.ShowGroupPanel = false;
            this.gv_UrunAlisSatis.OptionsView.ShowViewCaption = true;
            this.gv_UrunAlisSatis.ViewCaption = " ";
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Tarih";
            this.gridColumn19.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.gridColumn19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn19.FieldName = "TARIH";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 0;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Tür";
            this.gridColumn20.FieldName = "FISTURU";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 1;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "Cari Kodu";
            this.gridColumn22.FieldName = "CARIKODU";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 2;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "Cari Ünvanı";
            this.gridColumn23.FieldName = "CARIUNVANI";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 3;
            this.gridColumn23.Width = 143;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "Miktar";
            this.gridColumn25.FieldName = "ADET";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 4;
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "Birim Fiyat";
            this.gridColumn27.DisplayFormat.FormatString = "n2";
            this.gridColumn27.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn27.FieldName = "FIYAT";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 8;
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "Dövizli Bir. Fiyat";
            this.gridColumn28.DisplayFormat.FormatString = "n2";
            this.gridColumn28.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn28.FieldName = "DOVIZBIRIMFIYAT";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 9;
            this.gridColumn28.Width = 96;
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "Döviz";
            this.gridColumn29.FieldName = "DOVIZTIPI";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 5;
            // 
            // gridColumn30
            // 
            this.gridColumn30.Caption = "Tutar";
            this.gridColumn30.DisplayFormat.FormatString = "n2";
            this.gridColumn30.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn30.FieldName = "TUTAR";
            this.gridColumn30.Name = "gridColumn30";
            this.gridColumn30.Visible = true;
            this.gridColumn30.VisibleIndex = 10;
            this.gridColumn30.Width = 59;
            // 
            // gridColumn31
            // 
            this.gridColumn31.Caption = "Dövizli Tutar";
            this.gridColumn31.DisplayFormat.FormatString = "n2";
            this.gridColumn31.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn31.FieldName = "DOVIZTUTAR";
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.Visible = true;
            this.gridColumn31.VisibleIndex = 11;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Kdv %";
            this.gridColumn1.FieldName = "KDV";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Kdv Tutarı";
            this.gridColumn2.DisplayFormat.FormatString = "n2";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn2.FieldName = "KDVTUTARI";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 7;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Toplam Tutar";
            this.gridColumn3.DisplayFormat.FormatString = "n2";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn3.FieldName = "TOPLAMTUTAR";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 12;
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Location = new System.Drawing.Point(12, 398);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(946, 48);
            this.panelControl1.TabIndex = 214;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.simpleButton1.Location = new System.Drawing.Point(851, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(90, 37);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "[Esc] Vazgeç";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // lbl_StokAdi
            // 
            this.lbl_StokAdi.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl_StokAdi.Appearance.Options.UseFont = true;
            this.lbl_StokAdi.Location = new System.Drawing.Point(92, 33);
            this.lbl_StokAdi.Name = "lbl_StokAdi";
            this.lbl_StokAdi.Size = new System.Drawing.Size(0, 13);
            this.lbl_StokAdi.TabIndex = 218;
            // 
            // lbl_StokKodu
            // 
            this.lbl_StokKodu.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl_StokKodu.Appearance.Options.UseFont = true;
            this.lbl_StokKodu.Location = new System.Drawing.Point(92, 14);
            this.lbl_StokKodu.Name = "lbl_StokKodu";
            this.lbl_StokKodu.Size = new System.Drawing.Size(0, 13);
            this.lbl_StokKodu.TabIndex = 217;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(17, 33);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(67, 13);
            this.labelControl4.TabIndex = 216;
            this.labelControl4.Text = "Stok Adı        :";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(17, 14);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(67, 13);
            this.labelControl3.TabIndex = 215;
            this.labelControl3.Text = "Stok Kodu     :";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tasarımıKaydetToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(157, 26);
            // 
            // tasarımıKaydetToolStripMenuItem
            // 
            this.tasarımıKaydetToolStripMenuItem.Name = "tasarımıKaydetToolStripMenuItem";
            this.tasarımıKaydetToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.tasarımıKaydetToolStripMenuItem.Text = "Tasarımı Kaydet";
            this.tasarımıKaydetToolStripMenuItem.Click += new System.EventHandler(this.tasarımıKaydetToolStripMenuItem_Click);
            // 
            // frmStokListesiUrunAlisSatisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 448);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.lbl_StokAdi);
            this.Controls.Add(this.lbl_StokKodu);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.grid_UrunAlisSatis);
            this.Name = "frmStokListesiUrunAlisSatisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Alış-Satış";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmStokListesiUrunAlisSatisForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grid_UrunAlisSatis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_UrunAlisSatis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid_UrunAlisSatis;
        public DevExpress.XtraGrid.Views.Grid.GridView gv_UrunAlisSatis;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        public DevExpress.XtraEditors.LabelControl lbl_StokAdi;
        public DevExpress.XtraEditors.LabelControl lbl_StokKodu;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tasarımıKaydetToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn30;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
    }
}