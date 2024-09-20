namespace LOGO_XERO.Moduller.Giris_AnaForm_Ayarlar
{
    partial class frmRaporDosya
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
            this.gridControlRaporDosyalari = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.yeniRaporToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.varsayılanYapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tasarımKaydetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gv_RaporDosyalari = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.sablon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AKTIF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Modul1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RAPORADI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VARSAYILAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DOSYA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DOVIZLI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRaporDosyalari)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_RaporDosyalari)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlRaporDosyalari
            // 
            this.gridControlRaporDosyalari.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlRaporDosyalari.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControlRaporDosyalari.Location = new System.Drawing.Point(12, 12);
            this.gridControlRaporDosyalari.MainView = this.gv_RaporDosyalari;
            this.gridControlRaporDosyalari.Name = "gridControlRaporDosyalari";
            this.gridControlRaporDosyalari.Size = new System.Drawing.Size(1139, 504);
            this.gridControlRaporDosyalari.TabIndex = 1;
            this.gridControlRaporDosyalari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_RaporDosyalari});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yeniRaporToolStripMenuItem,
            this.düzenleToolStripMenuItem,
            this.varsayılanYapToolStripMenuItem,
            this.silToolStripMenuItem,
            this.tasarımKaydetToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(154, 114);
            // 
            // yeniRaporToolStripMenuItem
            // 
            this.yeniRaporToolStripMenuItem.Image = global::LOGO_XERO.Properties.Resources.ok;
            this.yeniRaporToolStripMenuItem.Name = "yeniRaporToolStripMenuItem";
            this.yeniRaporToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.yeniRaporToolStripMenuItem.Text = "Yeni Rapor";
            this.yeniRaporToolStripMenuItem.Click += new System.EventHandler(this.yeniRaporToolStripMenuItem_Click);
            // 
            // düzenleToolStripMenuItem
            // 
            this.düzenleToolStripMenuItem.Image = global::LOGO_XERO.Properties.Resources.Ribbon_Save_16x16;
            this.düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            this.düzenleToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.düzenleToolStripMenuItem.Text = "Düzenle";
            this.düzenleToolStripMenuItem.Click += new System.EventHandler(this.düzenleToolStripMenuItem_Click);
            // 
            // varsayılanYapToolStripMenuItem
            // 
            this.varsayılanYapToolStripMenuItem.Image = global::LOGO_XERO.Properties.Resources.ok_trnc;
            this.varsayılanYapToolStripMenuItem.Name = "varsayılanYapToolStripMenuItem";
            this.varsayılanYapToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.varsayılanYapToolStripMenuItem.Text = "Varsayılan Yap";
            this.varsayılanYapToolStripMenuItem.Click += new System.EventHandler(this.varsayılanYapToolStripMenuItem_Click);
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.Image = global::LOGO_XERO.Properties.Resources.Ribbon_Exit_16x16;
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.silToolStripMenuItem.Text = "Sil";
            this.silToolStripMenuItem.Click += new System.EventHandler(this.silToolStripMenuItem_Click);
            // 
            // tasarımKaydetToolStripMenuItem
            // 
            this.tasarımKaydetToolStripMenuItem.Image = global::LOGO_XERO.Properties.Resources.Ribbon_SaveAs_16x16;
            this.tasarımKaydetToolStripMenuItem.Name = "tasarımKaydetToolStripMenuItem";
            this.tasarımKaydetToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.tasarımKaydetToolStripMenuItem.Text = "Ayarları Kaydet";
            this.tasarımKaydetToolStripMenuItem.Click += new System.EventHandler(this.tasarımKaydetToolStripMenuItem_Click);
            // 
            // gv_RaporDosyalari
            // 
            this.gv_RaporDosyalari.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.sablon,
            this.AKTIF,
            this.Modul1,
            this.RAPORADI,
            this.VARSAYILAN,
            this.DOSYA,
            this.DOVIZLI});
            this.gv_RaporDosyalari.GridControl = this.gridControlRaporDosyalari;
            this.gv_RaporDosyalari.Name = "gv_RaporDosyalari";
            this.gv_RaporDosyalari.OptionsBehavior.Editable = false;
            this.gv_RaporDosyalari.OptionsBehavior.ReadOnly = true;
            this.gv_RaporDosyalari.OptionsView.ShowFooter = true;
            this.gv_RaporDosyalari.OptionsView.ShowGroupPanel = false;
            // 
            // sablon
            // 
            this.sablon.Caption = "Şablon";
            this.sablon.FieldName = "SABLON";
            this.sablon.Name = "sablon";
            this.sablon.Visible = true;
            this.sablon.VisibleIndex = 0;
            // 
            // AKTIF
            // 
            this.AKTIF.Caption = "Aktif";
            this.AKTIF.FieldName = "AKTIF";
            this.AKTIF.Name = "AKTIF";
            this.AKTIF.Visible = true;
            this.AKTIF.VisibleIndex = 1;
            // 
            // Modul1
            // 
            this.Modul1.Caption = "Modül";
            this.Modul1.FieldName = "MODUL";
            this.Modul1.Name = "Modul1";
            this.Modul1.Visible = true;
            this.Modul1.VisibleIndex = 2;
            // 
            // RAPORADI
            // 
            this.RAPORADI.Caption = "Rapor Adı";
            this.RAPORADI.FieldName = "RAPORADI";
            this.RAPORADI.Name = "RAPORADI";
            this.RAPORADI.Visible = true;
            this.RAPORADI.VisibleIndex = 3;
            // 
            // VARSAYILAN
            // 
            this.VARSAYILAN.Caption = "Varsayılan";
            this.VARSAYILAN.FieldName = "VARSAYILAN";
            this.VARSAYILAN.Name = "VARSAYILAN";
            this.VARSAYILAN.Visible = true;
            this.VARSAYILAN.VisibleIndex = 4;
            // 
            // DOSYA
            // 
            this.DOSYA.Caption = "Dosya";
            this.DOSYA.FieldName = "DOSYA";
            this.DOSYA.Name = "DOSYA";
            this.DOSYA.Visible = true;
            this.DOSYA.VisibleIndex = 5;
            // 
            // DOVIZLI
            // 
            this.DOVIZLI.Caption = "Dovizli";
            this.DOVIZLI.FieldName = "DOVIZLI";
            this.DOVIZLI.Name = "DOVIZLI";
            this.DOVIZLI.Visible = true;
            this.DOVIZLI.VisibleIndex = 6;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Location = new System.Drawing.Point(1040, 522);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(111, 37);
            this.simpleButton2.TabIndex = 20;
            this.simpleButton2.Text = "[Esc] Kapat";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(923, 522);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(111, 37);
            this.simpleButton1.TabIndex = 21;
            this.simpleButton1.Text = "[F5] Yenile";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmRaporDosya
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 569);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.gridControlRaporDosyalari);
            this.KeyPreview = true;
            this.Name = "frmRaporDosya";
            this.Text = "Rapor Dosyaları";
            this.Load += new System.EventHandler(this.frmRaporDosya_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRaporDosya_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRaporDosyalari)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv_RaporDosyalari)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlRaporDosyalari;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_RaporDosyalari;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem yeniRaporToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem varsayılanYapToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn sablon;
        private DevExpress.XtraGrid.Columns.GridColumn AKTIF;
        private DevExpress.XtraGrid.Columns.GridColumn Modul1;
        private DevExpress.XtraGrid.Columns.GridColumn RAPORADI;
        private DevExpress.XtraGrid.Columns.GridColumn VARSAYILAN;
        private DevExpress.XtraGrid.Columns.GridColumn DOSYA;
        private DevExpress.XtraGrid.Columns.GridColumn DOVIZLI;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tasarımKaydetToolStripMenuItem;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}