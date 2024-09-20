
namespace LOGO_XERO.Moduller._1_TeklifModul
{
    partial class frmIrsaliyeListesi
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
            this.gridIrsaliyeler = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ekleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tasarımKaydetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gv_Irsaliyeler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FISNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FISTURU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.STATU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CARILOG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CARIKOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OZELKOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CARIUNVANI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KDVTUTARI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LOGREF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TOPLAMTUTAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DURUMU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DURUMU1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EIRSALIYEDURUMU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TOTALDISCOUNTED = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NETTOTAL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GROSSTOTAL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BOLUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpbolum = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.AMBAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpambar = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ISYERI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpisyeri = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.SATISELEMANI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpsatiselemani = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.ck_isyeri = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.ck = new DevExpress.XtraEditors.CheckEdit();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.txtSon = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtIlk = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridIrsaliyeler)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Irsaliyeler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpbolum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpambar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpisyeri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpsatiselemani)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ck_isyeri.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ck.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSon.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIlk.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIlk.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridIrsaliyeler
            // 
            this.gridIrsaliyeler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridIrsaliyeler.ContextMenuStrip = this.contextMenuStrip1;
            this.gridIrsaliyeler.Location = new System.Drawing.Point(12, 12);
            this.gridIrsaliyeler.MainView = this.gv_Irsaliyeler;
            this.gridIrsaliyeler.Name = "gridIrsaliyeler";
            this.gridIrsaliyeler.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpbolum,
            this.rpambar,
            this.rpsatiselemani,
            this.rpisyeri});
            this.gridIrsaliyeler.Size = new System.Drawing.Size(1131, 455);
            this.gridIrsaliyeler.TabIndex = 0;
            this.gridIrsaliyeler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_Irsaliyeler});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ekleToolStripMenuItem,
            this.toolStripSeparator2,
            this.düzenleToolStripMenuItem,
            this.tasarımKaydetToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 98);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // ekleToolStripMenuItem
            // 
            this.ekleToolStripMenuItem.Name = "ekleToolStripMenuItem";
            this.ekleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ekleToolStripMenuItem.Text = "Ekle";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // düzenleToolStripMenuItem
            // 
            this.düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            this.düzenleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.düzenleToolStripMenuItem.Text = "Düzenle";
            // 
            // tasarımKaydetToolStripMenuItem
            // 
            this.tasarımKaydetToolStripMenuItem.Name = "tasarımKaydetToolStripMenuItem";
            this.tasarımKaydetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tasarımKaydetToolStripMenuItem.Text = "Tasarım Kaydet";
            this.tasarımKaydetToolStripMenuItem.Click += new System.EventHandler(this.tasarımKaydetToolStripMenuItem_Click);
            // 
            // gv_Irsaliyeler
            // 
            this.gv_Irsaliyeler.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TARIH,
            this.FISNO,
            this.FISTURU,
            this.STATU,
            this.CARILOG,
            this.CARIKOD,
            this.OZELKOD,
            this.CARIUNVANI,
            this.KDVTUTARI,
            this.LOGREF,
            this.TOPLAMTUTAR,
            this.DURUMU,
            this.DURUMU1,
            this.EIRSALIYEDURUMU,
            this.TOTALDISCOUNTED,
            this.NETTOTAL,
            this.GROSSTOTAL,
            this.BOLUM,
            this.AMBAR,
            this.ISYERI,
            this.SATISELEMANI});
            this.gv_Irsaliyeler.GridControl = this.gridIrsaliyeler;
            this.gv_Irsaliyeler.Name = "gv_Irsaliyeler";
            this.gv_Irsaliyeler.OptionsBehavior.Editable = false;
            this.gv_Irsaliyeler.OptionsBehavior.ReadOnly = true;
            this.gv_Irsaliyeler.OptionsView.ShowFooter = true;
            this.gv_Irsaliyeler.OptionsView.ShowGroupPanel = false;
            // 
            // TARIH
            // 
            this.TARIH.Caption = "Tarih";
            this.TARIH.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.TARIH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.TARIH.FieldName = "TARIH";
            this.TARIH.Name = "TARIH";
            this.TARIH.Visible = true;
            this.TARIH.VisibleIndex = 0;
            // 
            // FISNO
            // 
            this.FISNO.Caption = "Fiş Numarası";
            this.FISNO.FieldName = "FISNO";
            this.FISNO.Name = "FISNO";
            this.FISNO.Visible = true;
            this.FISNO.VisibleIndex = 1;
            // 
            // FISTURU
            // 
            this.FISTURU.Caption = "Fiş Türü";
            this.FISTURU.FieldName = "FISTURU";
            this.FISTURU.Name = "FISTURU";
            this.FISTURU.Visible = true;
            this.FISTURU.VisibleIndex = 2;
            // 
            // STATU
            // 
            this.STATU.Caption = "Statü";
            this.STATU.FieldName = "STATU";
            this.STATU.Name = "STATU";
            // 
            // CARILOG
            // 
            this.CARILOG.Caption = "CARILOG";
            this.CARILOG.FieldName = "CARILOG";
            this.CARILOG.Name = "CARILOG";
            this.CARILOG.OptionsColumn.AllowShowHide = false;
            this.CARILOG.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // CARIKOD
            // 
            this.CARIKOD.Caption = "Cari Kodu";
            this.CARIKOD.FieldName = "CARIKODU";
            this.CARIKOD.Name = "CARIKOD";
            this.CARIKOD.Visible = true;
            this.CARIKOD.VisibleIndex = 3;
            // 
            // OZELKOD
            // 
            this.OZELKOD.Caption = "Özel Kod";
            this.OZELKOD.FieldName = "OZELKOD";
            this.OZELKOD.Name = "OZELKOD";
            this.OZELKOD.Visible = true;
            this.OZELKOD.VisibleIndex = 4;
            // 
            // CARIUNVANI
            // 
            this.CARIUNVANI.Caption = "Cari Ünvanı";
            this.CARIUNVANI.FieldName = "CARIUNVANI";
            this.CARIUNVANI.Name = "CARIUNVANI";
            this.CARIUNVANI.Visible = true;
            this.CARIUNVANI.VisibleIndex = 5;
            // 
            // KDVTUTARI
            // 
            this.KDVTUTARI.Caption = "KDV Tutarı";
            this.KDVTUTARI.DisplayFormat.FormatString = "n2";
            this.KDVTUTARI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.KDVTUTARI.FieldName = "KDVTUTARI";
            this.KDVTUTARI.Name = "KDVTUTARI";
            this.KDVTUTARI.Visible = true;
            this.KDVTUTARI.VisibleIndex = 6;
            // 
            // LOGREF
            // 
            this.LOGREF.Caption = "LOGREF";
            this.LOGREF.FieldName = "LOGREF";
            this.LOGREF.Name = "LOGREF";
            this.LOGREF.OptionsColumn.AllowShowHide = false;
            this.LOGREF.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // TOPLAMTUTAR
            // 
            this.TOPLAMTUTAR.Caption = "Toplam Tutar";
            this.TOPLAMTUTAR.DisplayFormat.FormatString = "n2";
            this.TOPLAMTUTAR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TOPLAMTUTAR.FieldName = "TOPLAMTUTAR";
            this.TOPLAMTUTAR.Name = "TOPLAMTUTAR";
            this.TOPLAMTUTAR.Visible = true;
            this.TOPLAMTUTAR.VisibleIndex = 7;
            // 
            // DURUMU
            // 
            this.DURUMU.Caption = "Durumu";
            this.DURUMU.FieldName = "DURUMU";
            this.DURUMU.Name = "DURUMU";
            // 
            // DURUMU1
            // 
            this.DURUMU1.Caption = "Durumu";
            this.DURUMU1.FieldName = "DURUMU1";
            this.DURUMU1.Name = "DURUMU1";
            this.DURUMU1.Visible = true;
            this.DURUMU1.VisibleIndex = 10;
            // 
            // EIRSALIYEDURUMU
            // 
            this.EIRSALIYEDURUMU.Caption = "E-İrsaliye Durumu";
            this.EIRSALIYEDURUMU.FieldName = "EIRSALIYEDURUMU";
            this.EIRSALIYEDURUMU.Name = "EIRSALIYEDURUMU";
            this.EIRSALIYEDURUMU.Visible = true;
            this.EIRSALIYEDURUMU.VisibleIndex = 11;
            // 
            // TOTALDISCOUNTED
            // 
            this.TOTALDISCOUNTED.Caption = "Toplam İskonto";
            this.TOTALDISCOUNTED.DisplayFormat.FormatString = "n2";
            this.TOTALDISCOUNTED.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TOTALDISCOUNTED.FieldName = "TOTALDISCOUNTED";
            this.TOTALDISCOUNTED.Name = "TOTALDISCOUNTED";
            this.TOTALDISCOUNTED.Visible = true;
            this.TOTALDISCOUNTED.VisibleIndex = 8;
            // 
            // NETTOTAL
            // 
            this.NETTOTAL.Caption = "Net Toplam";
            this.NETTOTAL.DisplayFormat.FormatString = "n2";
            this.NETTOTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.NETTOTAL.FieldName = "NETTOTAL";
            this.NETTOTAL.Name = "NETTOTAL";
            this.NETTOTAL.Visible = true;
            this.NETTOTAL.VisibleIndex = 9;
            // 
            // GROSSTOTAL
            // 
            this.GROSSTOTAL.Caption = "GROSSTOTAL";
            this.GROSSTOTAL.DisplayFormat.FormatString = "n2";
            this.GROSSTOTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.GROSSTOTAL.FieldName = "GROSSTOTAL";
            this.GROSSTOTAL.Name = "GROSSTOTAL";
            // 
            // BOLUM
            // 
            this.BOLUM.Caption = "Bölüm ";
            this.BOLUM.ColumnEdit = this.rpbolum;
            this.BOLUM.FieldName = "BOLUM";
            this.BOLUM.Name = "BOLUM";
            this.BOLUM.Visible = true;
            this.BOLUM.VisibleIndex = 12;
            // 
            // rpbolum
            // 
            this.rpbolum.AutoHeight = false;
            this.rpbolum.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpbolum.Name = "rpbolum";
            // 
            // AMBAR
            // 
            this.AMBAR.Caption = "Ambar";
            this.AMBAR.ColumnEdit = this.rpambar;
            this.AMBAR.FieldName = "AMBAR";
            this.AMBAR.Name = "AMBAR";
            this.AMBAR.Visible = true;
            this.AMBAR.VisibleIndex = 13;
            // 
            // rpambar
            // 
            this.rpambar.AutoHeight = false;
            this.rpambar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpambar.Name = "rpambar";
            // 
            // ISYERI
            // 
            this.ISYERI.Caption = "İşyeri";
            this.ISYERI.ColumnEdit = this.rpisyeri;
            this.ISYERI.FieldName = "ISYERI";
            this.ISYERI.Name = "ISYERI";
            this.ISYERI.Visible = true;
            this.ISYERI.VisibleIndex = 14;
            // 
            // rpisyeri
            // 
            this.rpisyeri.AutoHeight = false;
            this.rpisyeri.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpisyeri.Name = "rpisyeri";
            // 
            // SATISELEMANI
            // 
            this.SATISELEMANI.Caption = "Satış Elemanı";
            this.SATISELEMANI.ColumnEdit = this.rpsatiselemani;
            this.SATISELEMANI.FieldName = "CODE";
            this.SATISELEMANI.Name = "SATISELEMANI";
            this.SATISELEMANI.Visible = true;
            this.SATISELEMANI.VisibleIndex = 15;
            // 
            // rpsatiselemani
            // 
            this.rpsatiselemani.AutoHeight = false;
            this.rpsatiselemani.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpsatiselemani.Name = "rpsatiselemani";
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.ck_isyeri);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.ck);
            this.panelControl1.Controls.Add(this.simpleButton3);
            this.panelControl1.Controls.Add(this.txtSon);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.txtIlk);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.simpleButton4);
            this.panelControl1.Location = new System.Drawing.Point(12, 473);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1131, 46);
            this.panelControl1.TabIndex = 1;
            // 
            // ck_isyeri
            // 
            this.ck_isyeri.Location = new System.Drawing.Point(406, 13);
            this.ck_isyeri.Name = "ck_isyeri";
            this.ck_isyeri.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ck_isyeri.Size = new System.Drawing.Size(100, 20);
            this.ck_isyeri.TabIndex = 116;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(373, 16);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(27, 13);
            this.labelControl3.TabIndex = 115;
            this.labelControl3.Text = "İşyeri";
            // 
            // ck
            // 
            this.ck.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ck.Location = new System.Drawing.Point(708, 12);
            this.ck.Name = "ck";
            this.ck.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ck.Properties.Appearance.Options.UseFont = true;
            this.ck.Properties.Caption = "Faturalanmış İrsaliyeleride Göster";
            this.ck.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1;
            this.ck.Size = new System.Drawing.Size(225, 22);
            this.ck.TabIndex = 113;
            this.ck.CheckedChanged += new System.EventHandler(this.ck_CheckedChanged);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.simpleButton3.Location = new System.Drawing.Point(512, 5);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(90, 37);
            this.simpleButton3.TabIndex = 89;
            this.simpleButton3.Text = "[F5] Yenile";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // txtSon
            // 
            this.txtSon.EditValue = null;
            this.txtSon.Location = new System.Drawing.Point(253, 13);
            this.txtSon.Name = "txtSon";
            this.txtSon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtSon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSon.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSon.Size = new System.Drawing.Size(100, 20);
            this.txtSon.TabIndex = 88;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(199, 17);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 13);
            this.labelControl2.TabIndex = 87;
            this.labelControl2.Text = "Bitiş Tarihi";
            // 
            // txtIlk
            // 
            this.txtIlk.EditValue = null;
            this.txtIlk.Location = new System.Drawing.Point(83, 13);
            this.txtIlk.Name = "txtIlk";
            this.txtIlk.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtIlk.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtIlk.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtIlk.Size = new System.Drawing.Size(100, 20);
            this.txtIlk.TabIndex = 86;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(73, 13);
            this.labelControl1.TabIndex = 85;
            this.labelControl1.Text = "Başlangıç Tarihi";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.simpleButton2.Location = new System.Drawing.Point(939, 5);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(90, 37);
            this.simpleButton2.TabIndex = 83;
            this.simpleButton2.Text = "[F4] Yazdır";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton4
            // 
            this.simpleButton4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.simpleButton4.Location = new System.Drawing.Point(1035, 5);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(90, 37);
            this.simpleButton4.TabIndex = 82;
            this.simpleButton4.Text = "[Esc] Kapat";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // frmIrsaliyeListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 531);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gridIrsaliyeler);
            this.KeyPreview = true;
            this.Name = "frmIrsaliyeListesi";
            this.Text = "Irsaliye Listesi";
            this.Load += new System.EventHandler(this.frmTeklifListesi_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmIrsaliyeListesi_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridIrsaliyeler)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv_Irsaliyeler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpbolum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpambar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpisyeri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpsatiselemani)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ck_isyeri.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ck.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSon.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIlk.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIlk.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridIrsaliyeler;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_Irsaliyeler;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ekleToolStripMenuItem;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.DateEdit txtSon;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit txtIlk;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.CheckEdit ck;
        private DevExpress.XtraGrid.Columns.GridColumn TARIH;
        private DevExpress.XtraGrid.Columns.GridColumn FISNO;
        private DevExpress.XtraGrid.Columns.GridColumn FISTURU;
        private DevExpress.XtraGrid.Columns.GridColumn STATU;
        private DevExpress.XtraGrid.Columns.GridColumn CARILOG;
        private DevExpress.XtraGrid.Columns.GridColumn CARIKOD;
        private DevExpress.XtraGrid.Columns.GridColumn OZELKOD;
        private DevExpress.XtraGrid.Columns.GridColumn CARIUNVANI;
        private DevExpress.XtraGrid.Columns.GridColumn KDVTUTARI;
        private DevExpress.XtraGrid.Columns.GridColumn LOGREF;
        private DevExpress.XtraGrid.Columns.GridColumn TOPLAMTUTAR;
        private DevExpress.XtraGrid.Columns.GridColumn DURUMU;
        private DevExpress.XtraGrid.Columns.GridColumn DURUMU1;
        private DevExpress.XtraGrid.Columns.GridColumn EIRSALIYEDURUMU;
        private System.Windows.Forms.ToolStripMenuItem tasarımKaydetToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn TOTALDISCOUNTED;
        private DevExpress.XtraGrid.Columns.GridColumn NETTOTAL;
        private DevExpress.XtraGrid.Columns.GridColumn GROSSTOTAL;
        private DevExpress.XtraGrid.Columns.GridColumn BOLUM;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpbolum;
        private DevExpress.XtraGrid.Columns.GridColumn AMBAR;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpambar;
        private DevExpress.XtraGrid.Columns.GridColumn ISYERI;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpisyeri;
        private DevExpress.XtraGrid.Columns.GridColumn SATISELEMANI;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpsatiselemani;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.CheckedComboBoxEdit ck_isyeri;
    }
}