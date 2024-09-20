
namespace LOGO_XERO.Moduller.Finans
{
    partial class frmCariKartListesi
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
            this.grid_CariListesi = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tasarimKaydetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelAktarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ekleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entityInstantFeedbackSource2 = new DevExpress.Data.Linq.EntityInstantFeedbackSource();
            this.gv_CariListesi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTICARIISLEMGURUBU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDEFINITION_ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSURNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colADRES1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colADRES2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTELEFON1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTELEFON2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCITY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTOWN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTAXOFFICE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTCKNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAXNR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPOSTCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTAXNR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYETKILISI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOZELKOD6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colE_FATURA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colE_POSTA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colE_POSTA2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colE_POSTA3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBAKIYE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOZELKOD1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOZELKOD2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOZELKOD3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOZELKOD4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOZELKOD5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAHISSIRKETI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMUHKOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colODEMEPLANIKODU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colODEMEPLANI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cariHareketEkstresiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.grid_CariListesi)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_CariListesi)).BeginInit();
            this.SuspendLayout();
            // 
            // grid_CariListesi
            // 
            this.grid_CariListesi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_CariListesi.ContextMenuStrip = this.contextMenuStrip1;
            this.grid_CariListesi.DataSource = this.entityInstantFeedbackSource2;
            this.grid_CariListesi.Location = new System.Drawing.Point(12, 12);
            this.grid_CariListesi.MainView = this.gv_CariListesi;
            this.grid_CariListesi.Name = "grid_CariListesi";
            this.grid_CariListesi.Padding = new System.Windows.Forms.Padding(5);
            this.grid_CariListesi.Size = new System.Drawing.Size(823, 580);
            this.grid_CariListesi.TabIndex = 1;
            this.grid_CariListesi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_CariListesi});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ekleToolStripMenuItem,
            this.düzenleToolStripMenuItem,
            this.toolStripSeparator1,
            this.cariHareketEkstresiToolStripMenuItem,
            this.toolStripSeparator2,
            this.excelAktarToolStripMenuItem,
            this.tasarimKaydetToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(182, 148);
            // 
            // tasarimKaydetToolStripMenuItem
            // 
            this.tasarimKaydetToolStripMenuItem.Name = "tasarimKaydetToolStripMenuItem";
            this.tasarimKaydetToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.tasarimKaydetToolStripMenuItem.Text = "Tasarim Kaydet";
            this.tasarimKaydetToolStripMenuItem.Click += new System.EventHandler(this.tasarimKaydetToolStripMenuItem_Click);
            // 
            // excelAktarToolStripMenuItem
            // 
            this.excelAktarToolStripMenuItem.Name = "excelAktarToolStripMenuItem";
            this.excelAktarToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.excelAktarToolStripMenuItem.Text = "Excel Aktar";
            this.excelAktarToolStripMenuItem.Click += new System.EventHandler(this.excelAktarToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // ekleToolStripMenuItem
            // 
            this.ekleToolStripMenuItem.Name = "ekleToolStripMenuItem";
            this.ekleToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.ekleToolStripMenuItem.Text = "Ekle";
            this.ekleToolStripMenuItem.Click += new System.EventHandler(this.ekleToolStripMenuItem_Click);
            // 
            // düzenleToolStripMenuItem
            // 
            this.düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            this.düzenleToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.düzenleToolStripMenuItem.Text = "Düzenle";
            this.düzenleToolStripMenuItem.Click += new System.EventHandler(this.düzenleToolStripMenuItem_Click);
            // 
            // entityInstantFeedbackSource2
            // 
            this.entityInstantFeedbackSource2.DefaultSorting = "CODE ASC";
            this.entityInstantFeedbackSource2.DesignTimeElementType = typeof(LOGO_XERO.Models.LOGO_XERO_M.LOGO_XERO_CARILISTE);
            this.entityInstantFeedbackSource2.KeyExpression = "LOGICALREF";
            this.entityInstantFeedbackSource2.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.entityInstantFeedbackSource2_GetQueryable);
            this.entityInstantFeedbackSource2.DismissQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.entityInstantFeedbackSource2_DismissQueryable);
            // 
            // gv_CariListesi
            // 
            this.gv_CariListesi.Appearance.EvenRow.BackColor = System.Drawing.Color.Azure;
            this.gv_CariListesi.Appearance.EvenRow.BackColor2 = System.Drawing.Color.Azure;
            this.gv_CariListesi.Appearance.EvenRow.Options.UseBackColor = true;
            this.gv_CariListesi.Appearance.FocusedCell.BackColor = System.Drawing.Color.Tan;
            this.gv_CariListesi.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Tan;
            this.gv_CariListesi.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gv_CariListesi.Appearance.FocusedRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gv_CariListesi.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gv_CariListesi.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gv_CariListesi.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gv_CariListesi.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gv_CariListesi.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gv_CariListesi.Appearance.SelectedRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gv_CariListesi.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gv_CariListesi.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gv_CariListesi.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.gv_CariListesi.Appearance.ViewCaption.Options.UseFont = true;
            this.gv_CariListesi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTICARIISLEMGURUBU,
            this.colCODE,
            this.colDEFINITION_,
            this.colNAME,
            this.colSURNAME,
            this.colADRES1,
            this.colADRES2,
            this.colTELEFON1,
            this.colTELEFON2,
            this.colCITY,
            this.colTOWN,
            this.colTAXOFFICE,
            this.colTCKNO,
            this.colFAXNR,
            this.colPOSTCODE,
            this.colTAXNR,
            this.colYETKILISI,
            this.colOZELKOD6,
            this.colE_FATURA,
            this.colE_POSTA,
            this.colE_POSTA2,
            this.colE_POSTA3,
            this.colBAKIYE,
            this.colOZELKOD1,
            this.colOZELKOD2,
            this.colOZELKOD3,
            this.colOZELKOD4,
            this.colOZELKOD5,
            this.colSAHISSIRKETI,
            this.colMUHKOD,
            this.colODEMEPLANIKODU,
            this.colODEMEPLANI});
            this.gv_CariListesi.FooterPanelHeight = 20;
            this.gv_CariListesi.GridControl = this.grid_CariListesi;
            this.gv_CariListesi.GroupRowHeight = 30;
            this.gv_CariListesi.IndicatorWidth = 20;
            this.gv_CariListesi.LevelIndent = 20;
            this.gv_CariListesi.Name = "gv_CariListesi";
            this.gv_CariListesi.OptionsBehavior.AllowIncrementalSearch = true;
            this.gv_CariListesi.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gv_CariListesi.OptionsSelection.MultiSelect = true;
            this.gv_CariListesi.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gv_CariListesi.OptionsView.ColumnAutoWidth = false;
            this.gv_CariListesi.OptionsView.ShowAutoFilterRow = true;
            this.gv_CariListesi.OptionsView.ShowFooter = true;
            this.gv_CariListesi.OptionsView.ShowGroupPanel = false;
            this.gv_CariListesi.OptionsView.ShowViewCaption = true;
            this.gv_CariListesi.ViewCaption = "CARİ HESAP LİSTESİ";
            this.gv_CariListesi.DoubleClick += new System.EventHandler(this.gv_CariListesi_DoubleClick);
            // 
            // colTICARIISLEMGURUBU
            // 
            this.colTICARIISLEMGURUBU.Caption = "Ticari İşlem Gurubu";
            this.colTICARIISLEMGURUBU.FieldName = "TICARIISLEMGURUBU";
            this.colTICARIISLEMGURUBU.Name = "colTICARIISLEMGURUBU";
            this.colTICARIISLEMGURUBU.Visible = true;
            this.colTICARIISLEMGURUBU.VisibleIndex = 2;
            // 
            // colCODE
            // 
            this.colCODE.Caption = "Cari Kodu";
            this.colCODE.FieldName = "CODE";
            this.colCODE.Name = "colCODE";
            this.colCODE.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "CODE", "{0}")});
            this.colCODE.Visible = true;
            this.colCODE.VisibleIndex = 0;
            this.colCODE.Width = 115;
            // 
            // colDEFINITION_
            // 
            this.colDEFINITION_.Caption = "Cari Ünvanı";
            this.colDEFINITION_.FieldName = "DEFINITION_";
            this.colDEFINITION_.Name = "colDEFINITION_";
            this.colDEFINITION_.Visible = true;
            this.colDEFINITION_.VisibleIndex = 1;
            this.colDEFINITION_.Width = 251;
            // 
            // colNAME
            // 
            this.colNAME.Caption = "Adı";
            this.colNAME.FieldName = "ADI";
            this.colNAME.Name = "colNAME";
            this.colNAME.Visible = true;
            this.colNAME.VisibleIndex = 8;
            // 
            // colSURNAME
            // 
            this.colSURNAME.Caption = "Soyadı";
            this.colSURNAME.FieldName = "SOYADI";
            this.colSURNAME.Name = "colSURNAME";
            this.colSURNAME.Visible = true;
            this.colSURNAME.VisibleIndex = 9;
            // 
            // colADRES1
            // 
            this.colADRES1.Caption = "Adres1";
            this.colADRES1.FieldName = "ADRES1";
            this.colADRES1.Name = "colADRES1";
            this.colADRES1.Visible = true;
            this.colADRES1.VisibleIndex = 10;
            // 
            // colADRES2
            // 
            this.colADRES2.Caption = "Adres2";
            this.colADRES2.FieldName = "ADRES2";
            this.colADRES2.Name = "colADRES2";
            this.colADRES2.Visible = true;
            this.colADRES2.VisibleIndex = 11;
            // 
            // colTELEFON1
            // 
            this.colTELEFON1.FieldName = "TELEFON1";
            this.colTELEFON1.Name = "colTELEFON1";
            this.colTELEFON1.Visible = true;
            this.colTELEFON1.VisibleIndex = 12;
            // 
            // colTELEFON2
            // 
            this.colTELEFON2.FieldName = "TELEFON2";
            this.colTELEFON2.Name = "colTELEFON2";
            this.colTELEFON2.Visible = true;
            this.colTELEFON2.VisibleIndex = 13;
            // 
            // colCITY
            // 
            this.colCITY.Caption = "ŞEHİR";
            this.colCITY.FieldName = "SEHIR";
            this.colCITY.Name = "colCITY";
            this.colCITY.Visible = true;
            this.colCITY.VisibleIndex = 14;
            // 
            // colTOWN
            // 
            this.colTOWN.Caption = "İlçe";
            this.colTOWN.FieldName = "ILCE";
            this.colTOWN.Name = "colTOWN";
            this.colTOWN.Visible = true;
            this.colTOWN.VisibleIndex = 15;
            // 
            // colTAXOFFICE
            // 
            this.colTAXOFFICE.Caption = "Vergi Dairesi";
            this.colTAXOFFICE.FieldName = "VERGIDAIRESI";
            this.colTAXOFFICE.Name = "colTAXOFFICE";
            this.colTAXOFFICE.Visible = true;
            this.colTAXOFFICE.VisibleIndex = 16;
            // 
            // colTCKNO
            // 
            this.colTCKNO.Caption = "Tc";
            this.colTCKNO.FieldName = "TCKNO";
            this.colTCKNO.Name = "colTCKNO";
            this.colTCKNO.Visible = true;
            this.colTCKNO.VisibleIndex = 17;
            // 
            // colFAXNR
            // 
            this.colFAXNR.Caption = "Fax";
            this.colFAXNR.FieldName = "FAXNR";
            this.colFAXNR.Name = "colFAXNR";
            this.colFAXNR.Visible = true;
            this.colFAXNR.VisibleIndex = 18;
            // 
            // colPOSTCODE
            // 
            this.colPOSTCODE.Caption = "Posta Kodu";
            this.colPOSTCODE.FieldName = "POSTAKODU";
            this.colPOSTCODE.Name = "colPOSTCODE";
            this.colPOSTCODE.Visible = true;
            this.colPOSTCODE.VisibleIndex = 19;
            // 
            // colTAXNR
            // 
            this.colTAXNR.Caption = "Vergi No";
            this.colTAXNR.FieldName = "TAXNR";
            this.colTAXNR.Name = "colTAXNR";
            this.colTAXNR.Visible = true;
            this.colTAXNR.VisibleIndex = 20;
            // 
            // colYETKILISI
            // 
            this.colYETKILISI.Caption = "Yetkli";
            this.colYETKILISI.FieldName = "YETKILISI";
            this.colYETKILISI.Name = "colYETKILISI";
            this.colYETKILISI.Visible = true;
            this.colYETKILISI.VisibleIndex = 21;
            // 
            // colOZELKOD6
            // 
            this.colOZELKOD6.Caption = "Yetki Kodu";
            this.colOZELKOD6.FieldName = "YETKIKODU";
            this.colOZELKOD6.Name = "colOZELKOD6";
            this.colOZELKOD6.Visible = true;
            this.colOZELKOD6.VisibleIndex = 22;
            // 
            // colE_FATURA
            // 
            this.colE_FATURA.Caption = "E-Fatura";
            this.colE_FATURA.FieldName = "EFATURA";
            this.colE_FATURA.Name = "colE_FATURA";
            this.colE_FATURA.Visible = true;
            this.colE_FATURA.VisibleIndex = 23;
            // 
            // colE_POSTA
            // 
            this.colE_POSTA.Caption = "E-Posta";
            this.colE_POSTA.FieldName = "EPOSTA";
            this.colE_POSTA.Name = "colE_POSTA";
            this.colE_POSTA.Visible = true;
            this.colE_POSTA.VisibleIndex = 24;
            // 
            // colE_POSTA2
            // 
            this.colE_POSTA2.Caption = "E-Posta2";
            this.colE_POSTA2.FieldName = "EPOSTA2";
            this.colE_POSTA2.Name = "colE_POSTA2";
            this.colE_POSTA2.Visible = true;
            this.colE_POSTA2.VisibleIndex = 25;
            // 
            // colE_POSTA3
            // 
            this.colE_POSTA3.Caption = "E-Posta3";
            this.colE_POSTA3.FieldName = "EPOSTA3";
            this.colE_POSTA3.Name = "colE_POSTA3";
            this.colE_POSTA3.Visible = true;
            this.colE_POSTA3.VisibleIndex = 26;
            // 
            // colBAKIYE
            // 
            this.colBAKIYE.Caption = "Bakiye";
            this.colBAKIYE.FieldName = "BAKIYE";
            this.colBAKIYE.Name = "colBAKIYE";
            this.colBAKIYE.Visible = true;
            this.colBAKIYE.VisibleIndex = 27;
            // 
            // colOZELKOD1
            // 
            this.colOZELKOD1.Caption = "Özel Kod1";
            this.colOZELKOD1.FieldName = "OZELKOD1";
            this.colOZELKOD1.Name = "colOZELKOD1";
            this.colOZELKOD1.Visible = true;
            this.colOZELKOD1.VisibleIndex = 3;
            // 
            // colOZELKOD2
            // 
            this.colOZELKOD2.Caption = "Özel Kod2";
            this.colOZELKOD2.FieldName = "OZELKOD2";
            this.colOZELKOD2.Name = "colOZELKOD2";
            this.colOZELKOD2.Visible = true;
            this.colOZELKOD2.VisibleIndex = 4;
            // 
            // colOZELKOD3
            // 
            this.colOZELKOD3.Caption = "Özel Kod3";
            this.colOZELKOD3.FieldName = "OZELKOD3";
            this.colOZELKOD3.Name = "colOZELKOD3";
            this.colOZELKOD3.Visible = true;
            this.colOZELKOD3.VisibleIndex = 5;
            // 
            // colOZELKOD4
            // 
            this.colOZELKOD4.Caption = "Özel Kod4";
            this.colOZELKOD4.FieldName = "OZELKOD4";
            this.colOZELKOD4.Name = "colOZELKOD4";
            this.colOZELKOD4.Visible = true;
            this.colOZELKOD4.VisibleIndex = 6;
            // 
            // colOZELKOD5
            // 
            this.colOZELKOD5.Caption = "Özel Kod5";
            this.colOZELKOD5.FieldName = "OZELKOD5";
            this.colOZELKOD5.Name = "colOZELKOD5";
            this.colOZELKOD5.Visible = true;
            this.colOZELKOD5.VisibleIndex = 7;
            // 
            // colSAHISSIRKETI
            // 
            this.colSAHISSIRKETI.FieldName = "SAHISSIRKETI";
            this.colSAHISSIRKETI.Name = "colSAHISSIRKETI";
            this.colSAHISSIRKETI.Visible = true;
            this.colSAHISSIRKETI.VisibleIndex = 28;
            // 
            // colMUHKOD
            // 
            this.colMUHKOD.FieldName = "MUHKOD";
            this.colMUHKOD.Name = "colMUHKOD";
            this.colMUHKOD.Visible = true;
            this.colMUHKOD.VisibleIndex = 29;
            // 
            // colODEMEPLANIKODU
            // 
            this.colODEMEPLANIKODU.FieldName = "ODEMEPLANIKODU";
            this.colODEMEPLANIKODU.Name = "colODEMEPLANIKODU";
            this.colODEMEPLANIKODU.Visible = true;
            this.colODEMEPLANIKODU.VisibleIndex = 30;
            // 
            // colODEMEPLANI
            // 
            this.colODEMEPLANI.FieldName = "ODEMEPLANI";
            this.colODEMEPLANI.Name = "colODEMEPLANI";
            this.colODEMEPLANI.Visible = true;
            this.colODEMEPLANI.VisibleIndex = 31;
            // 
            // cariHareketEkstresiToolStripMenuItem
            // 
            this.cariHareketEkstresiToolStripMenuItem.Name = "cariHareketEkstresiToolStripMenuItem";
            this.cariHareketEkstresiToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.cariHareketEkstresiToolStripMenuItem.Text = "Cari Hareket Ekstresi";
            this.cariHareketEkstresiToolStripMenuItem.Click += new System.EventHandler(this.cariHareketEkstresiToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(178, 6);
            // 
            // frmCariKartListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 604);
            this.Controls.Add(this.grid_CariListesi);
            this.Name = "frmCariKartListesi";
            this.Text = "Cari Kartlar";
            ((System.ComponentModel.ISupportInitialize)(this.grid_CariListesi)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv_CariListesi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid_CariListesi;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_CariListesi;
        private DevExpress.XtraGrid.Columns.GridColumn colTICARIISLEMGURUBU;
        private DevExpress.XtraGrid.Columns.GridColumn colCODE;
        private DevExpress.XtraGrid.Columns.GridColumn colDEFINITION_;
        private DevExpress.XtraGrid.Columns.GridColumn colNAME;
        private DevExpress.XtraGrid.Columns.GridColumn colSURNAME;
        private DevExpress.XtraGrid.Columns.GridColumn colADRES1;
        private DevExpress.XtraGrid.Columns.GridColumn colADRES2;
        private DevExpress.XtraGrid.Columns.GridColumn colTELEFON1;
        private DevExpress.XtraGrid.Columns.GridColumn colTELEFON2;
        private DevExpress.XtraGrid.Columns.GridColumn colCITY;
        private DevExpress.XtraGrid.Columns.GridColumn colTOWN;
        private DevExpress.XtraGrid.Columns.GridColumn colTAXOFFICE;
        private DevExpress.XtraGrid.Columns.GridColumn colTCKNO;
        private DevExpress.XtraGrid.Columns.GridColumn colFAXNR;
        private DevExpress.XtraGrid.Columns.GridColumn colPOSTCODE;
        private DevExpress.XtraGrid.Columns.GridColumn colTAXNR;
        private DevExpress.XtraGrid.Columns.GridColumn colYETKILISI;
        private DevExpress.XtraGrid.Columns.GridColumn colOZELKOD6;
        private DevExpress.XtraGrid.Columns.GridColumn colE_FATURA;
        private DevExpress.XtraGrid.Columns.GridColumn colE_POSTA;
        private DevExpress.XtraGrid.Columns.GridColumn colE_POSTA2;
        private DevExpress.XtraGrid.Columns.GridColumn colE_POSTA3;
        private DevExpress.XtraGrid.Columns.GridColumn colBAKIYE;
        private DevExpress.XtraGrid.Columns.GridColumn colOZELKOD1;
        private DevExpress.XtraGrid.Columns.GridColumn colOZELKOD2;
        private DevExpress.XtraGrid.Columns.GridColumn colOZELKOD3;
        private DevExpress.XtraGrid.Columns.GridColumn colOZELKOD4;
        private DevExpress.XtraGrid.Columns.GridColumn colOZELKOD5;
        private DevExpress.XtraGrid.Columns.GridColumn colSAHISSIRKETI;
        private DevExpress.XtraGrid.Columns.GridColumn colMUHKOD;
        private DevExpress.XtraGrid.Columns.GridColumn colODEMEPLANIKODU;
        private DevExpress.XtraGrid.Columns.GridColumn colODEMEPLANI;
        private DevExpress.Data.Linq.EntityInstantFeedbackSource entityInstantFeedbackSource2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tasarimKaydetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelAktarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ekleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cariHareketEkstresiToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}