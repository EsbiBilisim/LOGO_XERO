
namespace LOGO_XERO.Moduller.Giris_AnaForm_Ayarlar
{
    partial class frmLisanslar
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
            this.gridLisansListesi = new DevExpress.XtraGrid.GridControl();
            this.gvLisansListesi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_LisansYenile = new DevExpress.XtraEditors.SimpleButton();
            this.btn_LisansAl = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridLisansListesi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLisansListesi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridLisansListesi
            // 
            this.gridLisansListesi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridLisansListesi.Location = new System.Drawing.Point(12, 12);
            this.gridLisansListesi.MainView = this.gvLisansListesi;
            this.gridLisansListesi.Name = "gridLisansListesi";
            this.gridLisansListesi.Size = new System.Drawing.Size(861, 407);
            this.gridLisansListesi.TabIndex = 0;
            this.gridLisansListesi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLisansListesi});
            // 
            // gvLisansListesi
            // 
            this.gvLisansListesi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gvLisansListesi.GridControl = this.gridLisansListesi;
            this.gvLisansListesi.Name = "gvLisansListesi";
            this.gvLisansListesi.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Geçerlilik Durumu";
            this.gridColumn1.FieldName = "GECERLILIKDURUMU";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 90;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Kalan Gün Sayısı";
            this.gridColumn2.FieldName = "LISANSKALANGUNSAYISI";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 93;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Lisans Numarası";
            this.gridColumn3.FieldName = "LISANSNUMARASI";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 561;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Modül";
            this.gridColumn4.FieldName = "MODULACIKLAMA";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 99;
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.btn_LisansYenile);
            this.panelControl1.Controls.Add(this.btn_LisansAl);
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Location = new System.Drawing.Point(12, 425);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(861, 48);
            this.panelControl1.TabIndex = 1;
            // 
            // btn_LisansYenile
            // 
            this.btn_LisansYenile.Location = new System.Drawing.Point(97, 7);
            this.btn_LisansYenile.Name = "btn_LisansYenile";
            this.btn_LisansYenile.Size = new System.Drawing.Size(86, 34);
            this.btn_LisansYenile.TabIndex = 3;
            this.btn_LisansYenile.Text = "Lisans Yenile";
            this.btn_LisansYenile.Click += new System.EventHandler(this.btn_LisansYenile_Click);
            // 
            // btn_LisansAl
            // 
            this.btn_LisansAl.Location = new System.Drawing.Point(5, 7);
            this.btn_LisansAl.Name = "btn_LisansAl";
            this.btn_LisansAl.Size = new System.Drawing.Size(86, 34);
            this.btn_LisansAl.TabIndex = 2;
            this.btn_LisansAl.Text = "Lisans Al";
            this.btn_LisansAl.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.Location = new System.Drawing.Point(674, 7);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(86, 34);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "Lisans Kontrol";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Location = new System.Drawing.Point(766, 7);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(86, 34);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmLisanslar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 476);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gridLisansListesi);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLisanslar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lisans Listesi";
            this.Load += new System.EventHandler(this.frmLisanslar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridLisansListesi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLisansListesi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridLisansListesi;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLisansListesi;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        public DevExpress.XtraEditors.SimpleButton btn_LisansYenile;
        public DevExpress.XtraEditors.SimpleButton btn_LisansAl;
    }
}