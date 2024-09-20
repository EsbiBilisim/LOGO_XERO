namespace LOGO_XERO.Moduller.Giris_AnaForm_Ayarlar
{
    partial class frmKullaniciListesi
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
            this.gridctrlKullanici = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.kullanıcıyıDüzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gv_Kullanici = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SUTUNID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.kullanıcıad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LOGOKULLANICIID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LKLOGOSATISELEMANI = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ISYERI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LKISYERI = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.BOLUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LKBOLUM = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.FABRIKA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LKFABRIKA = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.AMBAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LKAMBAR = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.TELEFON = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EPOSTA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ILÇE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SEHIR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ADRES = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GOREV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LKGOREV = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.KISITLIOZELKOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEKLIFTUTARILIMIT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ISKONTOLIMIT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.yeniKullanıcıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kullanıcıyıSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridctrlKullanici)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Kullanici)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LKLOGOSATISELEMANI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LKISYERI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LKBOLUM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LKFABRIKA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LKAMBAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LKGOREV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridctrlKullanici
            // 
            this.gridctrlKullanici.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridctrlKullanici.ContextMenuStrip = this.contextMenuStrip1;
            this.gridctrlKullanici.Location = new System.Drawing.Point(12, 12);
            this.gridctrlKullanici.MainView = this.gv_Kullanici;
            this.gridctrlKullanici.Name = "gridctrlKullanici";
            this.gridctrlKullanici.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.LKISYERI,
            this.LKBOLUM,
            this.LKFABRIKA,
            this.LKAMBAR,
            this.LKGOREV,
            this.LKLOGOSATISELEMANI});
            this.gridctrlKullanici.Size = new System.Drawing.Size(1062, 545);
            this.gridctrlKullanici.TabIndex = 37;
            this.gridctrlKullanici.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_Kullanici});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kullanıcıyıDüzenleToolStripMenuItem,
            this.yeniKullanıcıToolStripMenuItem,
            this.kullanıcıyıSilToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(174, 70);
            // 
            // kullanıcıyıDüzenleToolStripMenuItem
            // 
            this.kullanıcıyıDüzenleToolStripMenuItem.Name = "kullanıcıyıDüzenleToolStripMenuItem";
            this.kullanıcıyıDüzenleToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.kullanıcıyıDüzenleToolStripMenuItem.Text = "Kullanıcıyı Düzenle";
            this.kullanıcıyıDüzenleToolStripMenuItem.Click += new System.EventHandler(this.kullanıcıyıDüzenleToolStripMenuItem_Click);
            // 
            // gv_Kullanici
            // 
            this.gv_Kullanici.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SUTUNID,
            this.kullanıcıad,
            this.LOGOKULLANICIID,
            this.ISYERI,
            this.BOLUM,
            this.FABRIKA,
            this.AMBAR,
            this.TELEFON,
            this.EPOSTA,
            this.ILÇE,
            this.SEHIR,
            this.ADRES,
            this.GOREV,
            this.KISITLIOZELKOD,
            this.TEKLIFTUTARILIMIT,
            this.ISKONTOLIMIT});
            this.gv_Kullanici.GridControl = this.gridctrlKullanici;
            this.gv_Kullanici.Name = "gv_Kullanici";
            this.gv_Kullanici.OptionsBehavior.Editable = false;
            this.gv_Kullanici.OptionsBehavior.ReadOnly = true;
            this.gv_Kullanici.OptionsView.ShowGroupPanel = false;
            // 
            // SUTUNID
            // 
            this.SUTUNID.Caption = "ID";
            this.SUTUNID.FieldName = "ID";
            this.SUTUNID.Name = "SUTUNID";
            // 
            // kullanıcıad
            // 
            this.kullanıcıad.Caption = "Kullanıcı Adı";
            this.kullanıcıad.FieldName = "KULLANICIADI";
            this.kullanıcıad.Name = "kullanıcıad";
            this.kullanıcıad.Visible = true;
            this.kullanıcıad.VisibleIndex = 0;
            // 
            // LOGOKULLANICIID
            // 
            this.LOGOKULLANICIID.Caption = "Logo Personel ID";
            this.LOGOKULLANICIID.ColumnEdit = this.LKLOGOSATISELEMANI;
            this.LOGOKULLANICIID.FieldName = "LOGOSATISELEMANIID";
            this.LOGOKULLANICIID.Name = "LOGOKULLANICIID";
            this.LOGOKULLANICIID.Visible = true;
            this.LOGOKULLANICIID.VisibleIndex = 2;
            // 
            // LKLOGOSATISELEMANI
            // 
            this.LKLOGOSATISELEMANI.AutoHeight = false;
            this.LKLOGOSATISELEMANI.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LKLOGOSATISELEMANI.Name = "LKLOGOSATISELEMANI";
            // 
            // ISYERI
            // 
            this.ISYERI.Caption = "İşyeri";
            this.ISYERI.ColumnEdit = this.LKISYERI;
            this.ISYERI.FieldName = "ISYERI";
            this.ISYERI.Name = "ISYERI";
            this.ISYERI.Visible = true;
            this.ISYERI.VisibleIndex = 1;
            // 
            // LKISYERI
            // 
            this.LKISYERI.AutoHeight = false;
            this.LKISYERI.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LKISYERI.Name = "LKISYERI";
            // 
            // BOLUM
            // 
            this.BOLUM.Caption = "Bölüm";
            this.BOLUM.ColumnEdit = this.LKBOLUM;
            this.BOLUM.FieldName = "BOLUM";
            this.BOLUM.Name = "BOLUM";
            this.BOLUM.Visible = true;
            this.BOLUM.VisibleIndex = 3;
            // 
            // LKBOLUM
            // 
            this.LKBOLUM.AutoHeight = false;
            this.LKBOLUM.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LKBOLUM.Name = "LKBOLUM";
            // 
            // FABRIKA
            // 
            this.FABRIKA.Caption = "Fabrika";
            this.FABRIKA.ColumnEdit = this.LKFABRIKA;
            this.FABRIKA.FieldName = "FABRIKA";
            this.FABRIKA.Name = "FABRIKA";
            this.FABRIKA.Visible = true;
            this.FABRIKA.VisibleIndex = 4;
            // 
            // LKFABRIKA
            // 
            this.LKFABRIKA.AutoHeight = false;
            this.LKFABRIKA.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LKFABRIKA.Name = "LKFABRIKA";
            // 
            // AMBAR
            // 
            this.AMBAR.Caption = "Ambar";
            this.AMBAR.ColumnEdit = this.LKAMBAR;
            this.AMBAR.FieldName = "AMBAR";
            this.AMBAR.Name = "AMBAR";
            this.AMBAR.Visible = true;
            this.AMBAR.VisibleIndex = 5;
            // 
            // LKAMBAR
            // 
            this.LKAMBAR.AutoHeight = false;
            this.LKAMBAR.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LKAMBAR.Name = "LKAMBAR";
            // 
            // TELEFON
            // 
            this.TELEFON.Caption = "Telefon";
            this.TELEFON.FieldName = "TELEFON";
            this.TELEFON.Name = "TELEFON";
            this.TELEFON.Visible = true;
            this.TELEFON.VisibleIndex = 6;
            // 
            // EPOSTA
            // 
            this.EPOSTA.Caption = "E-Posta";
            this.EPOSTA.FieldName = "EPOSTA";
            this.EPOSTA.Name = "EPOSTA";
            this.EPOSTA.Visible = true;
            this.EPOSTA.VisibleIndex = 7;
            // 
            // ILÇE
            // 
            this.ILÇE.Caption = "İlçe";
            this.ILÇE.FieldName = "ILCE";
            this.ILÇE.Name = "ILÇE";
            this.ILÇE.Visible = true;
            this.ILÇE.VisibleIndex = 8;
            // 
            // SEHIR
            // 
            this.SEHIR.Caption = "Şehir";
            this.SEHIR.FieldName = "SEHIR";
            this.SEHIR.Name = "SEHIR";
            this.SEHIR.Visible = true;
            this.SEHIR.VisibleIndex = 9;
            // 
            // ADRES
            // 
            this.ADRES.Caption = "Adres";
            this.ADRES.FieldName = "ADRES";
            this.ADRES.Name = "ADRES";
            this.ADRES.Visible = true;
            this.ADRES.VisibleIndex = 10;
            // 
            // GOREV
            // 
            this.GOREV.Caption = "Görev";
            this.GOREV.ColumnEdit = this.LKGOREV;
            this.GOREV.FieldName = "GOREV";
            this.GOREV.Name = "GOREV";
            this.GOREV.Visible = true;
            this.GOREV.VisibleIndex = 11;
            // 
            // LKGOREV
            // 
            this.LKGOREV.AutoHeight = false;
            this.LKGOREV.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LKGOREV.Name = "LKGOREV";
            // 
            // KISITLIOZELKOD
            // 
            this.KISITLIOZELKOD.Caption = "Kısıtlı Özel Kod";
            this.KISITLIOZELKOD.FieldName = "KISITLIOZELKOD";
            this.KISITLIOZELKOD.Name = "KISITLIOZELKOD";
            this.KISITLIOZELKOD.Visible = true;
            this.KISITLIOZELKOD.VisibleIndex = 12;
            // 
            // TEKLIFTUTARILIMIT
            // 
            this.TEKLIFTUTARILIMIT.Caption = "Teklif Tutarı Limit";
            this.TEKLIFTUTARILIMIT.FieldName = "TEKLIFTUTARILIMIT";
            this.TEKLIFTUTARILIMIT.Name = "TEKLIFTUTARILIMIT";
            this.TEKLIFTUTARILIMIT.Visible = true;
            this.TEKLIFTUTARILIMIT.VisibleIndex = 13;
            // 
            // ISKONTOLIMIT
            // 
            this.ISKONTOLIMIT.Caption = "İskonto % Limit";
            this.ISKONTOLIMIT.FieldName = "ISKONTOLIMIT";
            this.ISKONTOLIMIT.Name = "ISKONTOLIMIT";
            this.ISKONTOLIMIT.Visible = true;
            this.ISKONTOLIMIT.VisibleIndex = 14;
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.simpleButton5);
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Location = new System.Drawing.Point(12, 563);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1062, 45);
            this.panelControl1.TabIndex = 38;
            // 
            // simpleButton5
            // 
            this.simpleButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton5.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.simpleButton5.Appearance.Options.UseFont = true;
            this.simpleButton5.Location = new System.Drawing.Point(829, 4);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(111, 37);
            this.simpleButton5.TabIndex = 26;
            this.simpleButton5.Text = "[F5] Yenile";
            this.simpleButton5.Click += new System.EventHandler(this.simpleButton5_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Location = new System.Drawing.Point(946, 4);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(111, 37);
            this.simpleButton2.TabIndex = 22;
            this.simpleButton2.Text = "[Esc] Kapat";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // yeniKullanıcıToolStripMenuItem
            // 
            this.yeniKullanıcıToolStripMenuItem.Name = "yeniKullanıcıToolStripMenuItem";
            this.yeniKullanıcıToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.yeniKullanıcıToolStripMenuItem.Text = "Yeni Kullanıcı ";
            this.yeniKullanıcıToolStripMenuItem.Click += new System.EventHandler(this.yeniKullanıcıToolStripMenuItem_Click);
            // 
            // kullanıcıyıSilToolStripMenuItem
            // 
            this.kullanıcıyıSilToolStripMenuItem.Name = "kullanıcıyıSilToolStripMenuItem";
            this.kullanıcıyıSilToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.kullanıcıyıSilToolStripMenuItem.Text = "Kullanıcıyı Sil";
            this.kullanıcıyıSilToolStripMenuItem.Click += new System.EventHandler(this.kullanıcıyıSilToolStripMenuItem_Click);
            // 
            // frmKullaniciListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 620);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gridctrlKullanici);
            this.Name = "frmKullaniciListesi";
            this.Text = "Kullanıcı Listesi";
            this.Load += new System.EventHandler(this.frmKullaniciListesi_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmKullaniciListesi_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridctrlKullanici)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv_Kullanici)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LKLOGOSATISELEMANI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LKISYERI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LKBOLUM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LKFABRIKA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LKAMBAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LKGOREV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridctrlKullanici;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_Kullanici;
        private DevExpress.XtraGrid.Columns.GridColumn SUTUNID;
        private DevExpress.XtraGrid.Columns.GridColumn kullanıcıad;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kullanıcıyıDüzenleToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn ISYERI;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit LKISYERI;
        private DevExpress.XtraGrid.Columns.GridColumn BOLUM;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit LKBOLUM;
        private DevExpress.XtraGrid.Columns.GridColumn FABRIKA;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit LKFABRIKA;
        private DevExpress.XtraGrid.Columns.GridColumn AMBAR;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit LKAMBAR;
        private DevExpress.XtraGrid.Columns.GridColumn TELEFON;
        private DevExpress.XtraGrid.Columns.GridColumn EPOSTA;
        private DevExpress.XtraGrid.Columns.GridColumn ILÇE;
        private DevExpress.XtraGrid.Columns.GridColumn SEHIR;
        private DevExpress.XtraGrid.Columns.GridColumn ADRES;
        private DevExpress.XtraGrid.Columns.GridColumn GOREV;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit LKGOREV;
        private DevExpress.XtraGrid.Columns.GridColumn KISITLIOZELKOD;
        private DevExpress.XtraGrid.Columns.GridColumn TEKLIFTUTARILIMIT;
        private DevExpress.XtraGrid.Columns.GridColumn ISKONTOLIMIT;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit LKLOGOSATISELEMANI;
        private DevExpress.XtraGrid.Columns.GridColumn LOGOKULLANICIID;
        private System.Windows.Forms.ToolStripMenuItem yeniKullanıcıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kullanıcıyıSilToolStripMenuItem;
    }
}