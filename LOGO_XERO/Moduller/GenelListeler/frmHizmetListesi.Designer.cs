namespace LOGO_XERO.Moduller.GenelListeler
{
    partial class frmHizmetListesi
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
            this.grid_HizmetListesi = new DevExpress.XtraGrid.GridControl();
            this.gv_HizmetListesi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn56 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn57 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn58 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn59 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid_HizmetListesi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_HizmetListesi)).BeginInit();
            this.SuspendLayout();
            // 
            // grid_HizmetListesi
            // 
            this.grid_HizmetListesi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_HizmetListesi.Location = new System.Drawing.Point(0, 0);
            this.grid_HizmetListesi.MainView = this.gv_HizmetListesi;
            this.grid_HizmetListesi.Name = "grid_HizmetListesi";
            this.grid_HizmetListesi.Size = new System.Drawing.Size(1129, 524);
            this.grid_HizmetListesi.TabIndex = 1;
            this.grid_HizmetListesi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_HizmetListesi});
            this.grid_HizmetListesi.DoubleClick += new System.EventHandler(this.grid_HizmetListesi_DoubleClick);
            // 
            // gv_HizmetListesi
            // 
            this.gv_HizmetListesi.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.gv_HizmetListesi.Appearance.ViewCaption.Options.UseFont = true;
            this.gv_HizmetListesi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn23,
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
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn22,
            this.gridColumn56,
            this.gridColumn57,
            this.gridColumn58,
            this.gridColumn59});
            this.gv_HizmetListesi.GridControl = this.grid_HizmetListesi;
            this.gv_HizmetListesi.Name = "gv_HizmetListesi";
            this.gv_HizmetListesi.OptionsBehavior.AllowIncrementalSearch = true;
            this.gv_HizmetListesi.OptionsBehavior.Editable = false;
            this.gv_HizmetListesi.OptionsView.ColumnAutoWidth = false;
            this.gv_HizmetListesi.OptionsView.ShowAutoFilterRow = true;
            this.gv_HizmetListesi.OptionsView.ShowFooter = true;
            this.gv_HizmetListesi.OptionsView.ShowGroupPanel = false;
            this.gv_HizmetListesi.OptionsView.ShowViewCaption = true;
            this.gv_HizmetListesi.ViewCaption = "HİZMET LİSTESİ";
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "LOGICALREF";
            this.gridColumn23.FieldName = "LOGICALREF";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.AllowShowHide = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Stok Kodu";
            this.gridColumn1.FieldName = "STOKKODU";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Stok Açıklama";
            this.gridColumn2.FieldName = "STOKCINSI";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 236;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Açıklama3";
            this.gridColumn3.FieldName = "ACIKLAMA3";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Marka";
            this.gridColumn4.FieldName = "MARKA";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 8;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Özel Kod1";
            this.gridColumn5.FieldName = "OZELKOD1";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 6;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Özel Kod1 Açıklama";
            this.gridColumn6.FieldName = "OZKODACIKLAMA";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Özel Kod2";
            this.gridColumn7.FieldName = "OZELKOD2";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Özel Kod3";
            this.gridColumn8.FieldName = "OZELKOD3";
            this.gridColumn8.Name = "gridColumn8";
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Özel Kod4";
            this.gridColumn9.FieldName = "OZELKOD4";
            this.gridColumn9.Name = "gridColumn9";
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Özel Kod5";
            this.gridColumn10.FieldName = "OZELKOD5";
            this.gridColumn10.Name = "gridColumn10";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Yetki Kodu";
            this.gridColumn11.FieldName = "YETKIKODU";
            this.gridColumn11.Name = "gridColumn11";
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Kdv";
            this.gridColumn12.FieldName = "KDV";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 9;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Stok Bakiye";
            this.gridColumn13.FieldName = "STOKBAKIYE";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 10;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Ambar Bakiye";
            this.gridColumn14.FieldName = "AMBARBAKIYE";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 11;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Açıklama4";
            this.gridColumn15.FieldName = "ACIKLAMA4";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 4;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Min. Miktar";
            this.gridColumn16.FieldName = "MINMIKTAR";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 12;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Liste Fiyatı";
            this.gridColumn17.DisplayFormat.FormatString = "n2";
            this.gridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn17.FieldName = "LISTEFIYATI";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 13;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Döviz";
            this.gridColumn18.FieldName = "DOVIZ";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 14;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Barkod";
            this.gridColumn19.FieldName = "BARKOD";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 2;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Barkod2";
            this.gridColumn20.FieldName = "BARKOD2";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 16;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "Birim";
            this.gridColumn21.FieldName = "BIRIM";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 5;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "Perakende Satış Fiyatı";
            this.gridColumn22.DisplayFormat.FormatString = "n2";
            this.gridColumn22.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn22.FieldName = "PRKSATISFIYATI";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 15;
            // 
            // gridColumn56
            // 
            this.gridColumn56.Caption = "Tevkifat";
            this.gridColumn56.FieldName = "TEVKIFAT";
            this.gridColumn56.Name = "gridColumn56";
            this.gridColumn56.Visible = true;
            this.gridColumn56.VisibleIndex = 17;
            // 
            // gridColumn57
            // 
            this.gridColumn57.Caption = "Tevkifat Kodu";
            this.gridColumn57.FieldName = "TEVKIFATKODU";
            this.gridColumn57.Name = "gridColumn57";
            this.gridColumn57.Visible = true;
            this.gridColumn57.VisibleIndex = 18;
            // 
            // gridColumn58
            // 
            this.gridColumn58.Caption = "Tevkifat Çarpan";
            this.gridColumn58.FieldName = "TEVKIFATCARPAN";
            this.gridColumn58.Name = "gridColumn58";
            this.gridColumn58.Visible = true;
            this.gridColumn58.VisibleIndex = 19;
            // 
            // gridColumn59
            // 
            this.gridColumn59.Caption = "Tevkifat Bölen";
            this.gridColumn59.FieldName = "TEVKIFATBOLEN";
            this.gridColumn59.Name = "gridColumn59";
            this.gridColumn59.Visible = true;
            this.gridColumn59.VisibleIndex = 20;
            // 
            // frmHizmetListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 530);
            this.Controls.Add(this.grid_HizmetListesi);
            this.Name = "frmHizmetListesi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hizmet Listesi";
            ((System.ComponentModel.ISupportInitialize)(this.grid_HizmetListesi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_HizmetListesi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid_HizmetListesi;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_HizmetListesi;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn56;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn57;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn58;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn59;
    }
}