namespace LOGO_XERO.Moduller.Giris_AnaForm_Ayarlar
{
    partial class frmHatirlatmaListele
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
            this.grid_Hatirlatma = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hepsiniOkunduİşaretleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tasarımKaydetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gv_hatirlatma = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PERSONEL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HTARIHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEKLIFNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OKUNDU = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Hatirlatma)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_hatirlatma)).BeginInit();
            this.SuspendLayout();
            // 
            // grid_Hatirlatma
            // 
            this.grid_Hatirlatma.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_Hatirlatma.ContextMenuStrip = this.contextMenuStrip1;
            this.grid_Hatirlatma.Location = new System.Drawing.Point(12, 12);
            this.grid_Hatirlatma.MainView = this.gv_hatirlatma;
            this.grid_Hatirlatma.Name = "grid_Hatirlatma";
            this.grid_Hatirlatma.Size = new System.Drawing.Size(795, 498);
            this.grid_Hatirlatma.TabIndex = 0;
            this.grid_Hatirlatma.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_hatirlatma});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hepsiniOkunduİşaretleToolStripMenuItem,
            this.düzenleToolStripMenuItem,
            this.tasarımKaydetToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(201, 92);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // hepsiniOkunduİşaretleToolStripMenuItem
            // 
            this.hepsiniOkunduİşaretleToolStripMenuItem.Name = "hepsiniOkunduİşaretleToolStripMenuItem";
            this.hepsiniOkunduİşaretleToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.hepsiniOkunduİşaretleToolStripMenuItem.Text = "Hepsini Okundu İşaretle";
            this.hepsiniOkunduİşaretleToolStripMenuItem.Click += new System.EventHandler(this.hepsiniOkunduİşaretleToolStripMenuItem_Click);
            // 
            // düzenleToolStripMenuItem
            // 
            this.düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            this.düzenleToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.düzenleToolStripMenuItem.Text = "Düzenle";
            this.düzenleToolStripMenuItem.Click += new System.EventHandler(this.düzenleToolStripMenuItem_Click);
            // 
            // tasarımKaydetToolStripMenuItem
            // 
            this.tasarımKaydetToolStripMenuItem.Name = "tasarımKaydetToolStripMenuItem";
            this.tasarımKaydetToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.tasarımKaydetToolStripMenuItem.Text = "Tasarım Kaydet";
            this.tasarımKaydetToolStripMenuItem.Click += new System.EventHandler(this.tasarımKaydetToolStripMenuItem_Click);
            // 
            // gv_hatirlatma
            // 
            this.gv_hatirlatma.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.PERSONEL,
            this.TARIH,
            this.HTARIHI,
            this.TEKLIFNO,
            this.ACIKLAMA,
            this.OKUNDU});
            this.gv_hatirlatma.GridControl = this.grid_Hatirlatma;
            this.gv_hatirlatma.Name = "gv_hatirlatma";
            this.gv_hatirlatma.OptionsView.ShowFooter = true;
            this.gv_hatirlatma.OptionsView.ShowGroupPanel = false;
            this.gv_hatirlatma.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gv_hatirlatma_CellValueChanged);
            this.gv_hatirlatma.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gv_hatirlatma_CellValueChanging);
            // 
            // id
            // 
            this.id.Caption = "ID";
            this.id.FieldName = "ID";
            this.id.Name = "id";
            this.id.OptionsColumn.AllowShowHide = false;
            this.id.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // PERSONEL
            // 
            this.PERSONEL.Caption = "Personel";
            this.PERSONEL.FieldName = "PERSONEL";
            this.PERSONEL.Name = "PERSONEL";
            this.PERSONEL.OptionsColumn.AllowEdit = false;
            this.PERSONEL.OptionsColumn.ReadOnly = true;
            this.PERSONEL.Visible = true;
            this.PERSONEL.VisibleIndex = 0;
            // 
            // TARIH
            // 
            this.TARIH.Caption = "Tarih";
            this.TARIH.FieldName = "TARIH";
            this.TARIH.Name = "TARIH";
            this.TARIH.OptionsColumn.AllowEdit = false;
            this.TARIH.OptionsColumn.ReadOnly = true;
            this.TARIH.Visible = true;
            this.TARIH.VisibleIndex = 1;
            // 
            // HTARIHI
            // 
            this.HTARIHI.Caption = "Hatırlatma Tarihi";
            this.HTARIHI.FieldName = "HATIRLATMATARIHI";
            this.HTARIHI.Name = "HTARIHI";
            this.HTARIHI.OptionsColumn.AllowEdit = false;
            this.HTARIHI.OptionsColumn.ReadOnly = true;
            this.HTARIHI.Visible = true;
            this.HTARIHI.VisibleIndex = 2;
            // 
            // TEKLIFNO
            // 
            this.TEKLIFNO.Caption = "Teklif Numarası";
            this.TEKLIFNO.FieldName = "TEKLIFNO";
            this.TEKLIFNO.Name = "TEKLIFNO";
            this.TEKLIFNO.OptionsColumn.AllowEdit = false;
            this.TEKLIFNO.OptionsColumn.ReadOnly = true;
            this.TEKLIFNO.Visible = true;
            this.TEKLIFNO.VisibleIndex = 3;
            // 
            // ACIKLAMA
            // 
            this.ACIKLAMA.Caption = "Açıklama";
            this.ACIKLAMA.FieldName = "ACIKLAMA";
            this.ACIKLAMA.Name = "ACIKLAMA";
            this.ACIKLAMA.OptionsColumn.AllowEdit = false;
            this.ACIKLAMA.OptionsColumn.ReadOnly = true;
            this.ACIKLAMA.Visible = true;
            this.ACIKLAMA.VisibleIndex = 4;
            // 
            // OKUNDU
            // 
            this.OKUNDU.Caption = "Okundu";
            this.OKUNDU.FieldName = "OKUNDU";
            this.OKUNDU.Name = "OKUNDU";
            this.OKUNDU.Visible = true;
            this.OKUNDU.VisibleIndex = 5;
            // 
            // frmHatirlatmaListele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 522);
            this.Controls.Add(this.grid_Hatirlatma);
            this.Name = "frmHatirlatmaListele";
            this.Text = "Hatırlatma Listele";
            this.Load += new System.EventHandler(this.frmHatirlatmaListele_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_Hatirlatma)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv_hatirlatma)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid_Hatirlatma;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_hatirlatma;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tasarımKaydetToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn PERSONEL;
        private DevExpress.XtraGrid.Columns.GridColumn TARIH;
        private DevExpress.XtraGrid.Columns.GridColumn HTARIHI;
        private DevExpress.XtraGrid.Columns.GridColumn TEKLIFNO;
        private DevExpress.XtraGrid.Columns.GridColumn ACIKLAMA;
        private DevExpress.XtraGrid.Columns.GridColumn OKUNDU;
        private System.Windows.Forms.ToolStripMenuItem hepsiniOkunduİşaretleToolStripMenuItem;
    }
}