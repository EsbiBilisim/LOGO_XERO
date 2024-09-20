
namespace LOGO_XERO.Moduller.Giris_AnaForm_Ayarlar
{
    partial class frmAnaDashBoard
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
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel1 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.SeriesPoint seriesPoint1 = new DevExpress.XtraCharts.SeriesPoint("usd", new object[] {
            ((object)(10D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint2 = new DevExpress.XtraCharts.SeriesPoint("euro", new object[] {
            ((object)(20D))});
            DevExpress.XtraCharts.StackedAreaSeriesView stackedAreaSeriesView1 = new DevExpress.XtraCharts.StackedAreaSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            DevExpress.XtraCharts.XYDiagram xyDiagram2 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.SeriesPoint seriesPoint3 = new DevExpress.XtraCharts.SeriesPoint("Alış Fatura", new object[] {
            ((object)(15D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint4 = new DevExpress.XtraCharts.SeriesPoint("Satış Fatura", new object[] {
            ((object)(6D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint5 = new DevExpress.XtraCharts.SeriesPoint("Alış Sipariş", new object[] {
            ((object)(6D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint6 = new DevExpress.XtraCharts.SeriesPoint("Satış Sipariş", new object[] {
            ((object)(10D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint7 = new DevExpress.XtraCharts.SeriesPoint("Alış Onaylanan Teklif", new object[] {
            ((object)(0D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint8 = new DevExpress.XtraCharts.SeriesPoint("Satış Onaylanan Teklif", new object[] {
            ((object)(0D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint9 = new DevExpress.XtraCharts.SeriesPoint("Alış Teklif", new object[] {
            ((object)(0D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint10 = new DevExpress.XtraCharts.SeriesPoint("Satış Teklif", new object[] {
            ((object)(0D))});
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView1 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel2 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SeriesPoint seriesPoint11 = new DevExpress.XtraCharts.SeriesPoint("TEST", new object[] {
            ((object)(10D)),
            ((object)(15D)),
            ((object)(60D)),
            ((object)(0D)),
            ((object)(0D)),
            ((object)(0D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint12 = new DevExpress.XtraCharts.SeriesPoint("TEST2", new object[] {
            ((object)(20D)),
            ((object)(25D)),
            ((object)(50D)),
            ((object)(0D)),
            ((object)(0D)),
            ((object)(0D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint13 = new DevExpress.XtraCharts.SeriesPoint("TEST3", new object[] {
            ((object)(30D)),
            ((object)(20D)),
            ((object)(40D)),
            ((object)(0D)),
            ((object)(0D)),
            ((object)(0D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint14 = new DevExpress.XtraCharts.SeriesPoint("TEST4", new object[] {
            ((object)(40D)),
            ((object)(12D)),
            ((object)(36D)),
            ((object)(0D)),
            ((object)(0D)),
            ((object)(0D))});
            DevExpress.XtraCharts.BoxPlotSeriesView boxPlotSeriesView1 = new DevExpress.XtraCharts.BoxPlotSeriesView();
            DevExpress.XtraCharts.BoxPlotSlideAnimation boxPlotSlideAnimation1 = new DevExpress.XtraCharts.BoxPlotSlideAnimation();
            DevExpress.XtraCharts.QuinticEasingFunction quinticEasingFunction1 = new DevExpress.XtraCharts.QuinticEasingFunction();
            DevExpress.XtraCharts.XYSeriesUnwindAnimation xySeriesUnwindAnimation1 = new DevExpress.XtraCharts.XYSeriesUnwindAnimation();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_AktifMusteriSayisi = new LOGO_XERO.RjControl.RJButton();
            this.btn_onaybekleyenTeklif = new LOGO_XERO.RjControl.RJButton();
            this.btn_OnayBekleyenAlisSiparisleri = new LOGO_XERO.RjControl.RJButton();
            this.btn_onayBekleyenSatisSiparisleri = new LOGO_XERO.RjControl.RJButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grid_anadash = new DevExpress.XtraGrid.GridControl();
            this.gv_anadash = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.chartControl2 = new DevExpress.XtraCharts.ChartControl();
            this.chartControl3 = new DevExpress.XtraCharts.ChartControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_anadash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_anadash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stackedAreaSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(boxPlotSeriesView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.btn_AktifMusteriSayisi, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.btn_onaybekleyenTeklif, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btn_OnayBekleyenAlisSiparisleri, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.btn_onayBekleyenSatisSiparisleri, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(15, 12);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1206, 84);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // btn_AktifMusteriSayisi
            // 
            this.btn_AktifMusteriSayisi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_AktifMusteriSayisi.BackColor = System.Drawing.Color.Chartreuse;
            this.btn_AktifMusteriSayisi.BackgroundColor = System.Drawing.Color.Chartreuse;
            this.btn_AktifMusteriSayisi.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_AktifMusteriSayisi.BorderRadius = 20;
            this.btn_AktifMusteriSayisi.BorderSize = 0;
            this.btn_AktifMusteriSayisi.FlatAppearance.BorderSize = 0;
            this.btn_AktifMusteriSayisi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AktifMusteriSayisi.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_AktifMusteriSayisi.ForeColor = System.Drawing.Color.Black;
            this.btn_AktifMusteriSayisi.Location = new System.Drawing.Point(906, 3);
            this.btn_AktifMusteriSayisi.Name = "btn_AktifMusteriSayisi";
            this.btn_AktifMusteriSayisi.Size = new System.Drawing.Size(297, 78);
            this.btn_AktifMusteriSayisi.TabIndex = 8;
            this.btn_AktifMusteriSayisi.Text = "Aktif Müşteri Sayısı - 95623";
            this.btn_AktifMusteriSayisi.TextColor = System.Drawing.Color.Black;
            this.btn_AktifMusteriSayisi.UseVisualStyleBackColor = false;
            // 
            // btn_onaybekleyenTeklif
            // 
            this.btn_onaybekleyenTeklif.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_onaybekleyenTeklif.BackColor = System.Drawing.Color.Aqua;
            this.btn_onaybekleyenTeklif.BackgroundColor = System.Drawing.Color.Aqua;
            this.btn_onaybekleyenTeklif.BorderColor = System.Drawing.Color.DarkCyan;
            this.btn_onaybekleyenTeklif.BorderRadius = 20;
            this.btn_onaybekleyenTeklif.BorderSize = 0;
            this.btn_onaybekleyenTeklif.FlatAppearance.BorderSize = 0;
            this.btn_onaybekleyenTeklif.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_onaybekleyenTeklif.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_onaybekleyenTeklif.ForeColor = System.Drawing.Color.Black;
            this.btn_onaybekleyenTeklif.Location = new System.Drawing.Point(3, 3);
            this.btn_onaybekleyenTeklif.Name = "btn_onaybekleyenTeklif";
            this.btn_onaybekleyenTeklif.Size = new System.Drawing.Size(295, 78);
            this.btn_onaybekleyenTeklif.TabIndex = 5;
            this.btn_onaybekleyenTeklif.Text = "Onay Bekleyen Teklifler  - 1111111";
            this.btn_onaybekleyenTeklif.TextColor = System.Drawing.Color.Black;
            this.btn_onaybekleyenTeklif.UseVisualStyleBackColor = false;
            this.btn_onaybekleyenTeklif.Click += new System.EventHandler(this.btn_onaybekleyenTeklif_Click);
            // 
            // btn_OnayBekleyenAlisSiparisleri
            // 
            this.btn_OnayBekleyenAlisSiparisleri.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OnayBekleyenAlisSiparisleri.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_OnayBekleyenAlisSiparisleri.BackgroundColor = System.Drawing.Color.DarkOrange;
            this.btn_OnayBekleyenAlisSiparisleri.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_OnayBekleyenAlisSiparisleri.BorderRadius = 20;
            this.btn_OnayBekleyenAlisSiparisleri.BorderSize = 0;
            this.btn_OnayBekleyenAlisSiparisleri.FlatAppearance.BorderSize = 0;
            this.btn_OnayBekleyenAlisSiparisleri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OnayBekleyenAlisSiparisleri.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_OnayBekleyenAlisSiparisleri.ForeColor = System.Drawing.Color.Black;
            this.btn_OnayBekleyenAlisSiparisleri.Location = new System.Drawing.Point(605, 3);
            this.btn_OnayBekleyenAlisSiparisleri.Name = "btn_OnayBekleyenAlisSiparisleri";
            this.btn_OnayBekleyenAlisSiparisleri.Size = new System.Drawing.Size(295, 78);
            this.btn_OnayBekleyenAlisSiparisleri.TabIndex = 7;
            this.btn_OnayBekleyenAlisSiparisleri.Text = "Onay Bekleyen Alış Siparişler  - 95";
            this.btn_OnayBekleyenAlisSiparisleri.TextColor = System.Drawing.Color.Black;
            this.btn_OnayBekleyenAlisSiparisleri.UseVisualStyleBackColor = false;
            // 
            // btn_onayBekleyenSatisSiparisleri
            // 
            this.btn_onayBekleyenSatisSiparisleri.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_onayBekleyenSatisSiparisleri.BackColor = System.Drawing.Color.Gold;
            this.btn_onayBekleyenSatisSiparisleri.BackgroundColor = System.Drawing.Color.Gold;
            this.btn_onayBekleyenSatisSiparisleri.BorderColor = System.Drawing.Color.SlateGray;
            this.btn_onayBekleyenSatisSiparisleri.BorderRadius = 20;
            this.btn_onayBekleyenSatisSiparisleri.BorderSize = 0;
            this.btn_onayBekleyenSatisSiparisleri.FlatAppearance.BorderSize = 0;
            this.btn_onayBekleyenSatisSiparisleri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_onayBekleyenSatisSiparisleri.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_onayBekleyenSatisSiparisleri.ForeColor = System.Drawing.Color.Black;
            this.btn_onayBekleyenSatisSiparisleri.Location = new System.Drawing.Point(304, 3);
            this.btn_onayBekleyenSatisSiparisleri.Name = "btn_onayBekleyenSatisSiparisleri";
            this.btn_onayBekleyenSatisSiparisleri.Size = new System.Drawing.Size(295, 78);
            this.btn_onayBekleyenSatisSiparisleri.TabIndex = 6;
            this.btn_onayBekleyenSatisSiparisleri.Text = "Onay Bekleyen Satış Siparişleri  - 15695";
            this.btn_onayBekleyenSatisSiparisleri.TextColor = System.Drawing.Color.Black;
            this.btn_onayBekleyenSatisSiparisleri.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.grid_anadash, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chartControl1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartControl2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartControl3, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 107);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1209, 587);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // grid_anadash
            // 
            this.grid_anadash.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_anadash.Location = new System.Drawing.Point(3, 296);
            this.grid_anadash.MainView = this.gv_anadash;
            this.grid_anadash.Name = "grid_anadash";
            this.grid_anadash.Size = new System.Drawing.Size(598, 288);
            this.grid_anadash.TabIndex = 0;
            this.grid_anadash.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_anadash});
            // 
            // gv_anadash
            // 
            this.gv_anadash.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.gv_anadash.Appearance.ViewCaption.Options.UseFont = true;
            this.gv_anadash.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gv_anadash.GridControl = this.grid_anadash;
            this.gv_anadash.Name = "gv_anadash";
            this.gv_anadash.OptionsBehavior.Editable = false;
            this.gv_anadash.OptionsBehavior.ReadOnly = true;
            this.gv_anadash.OptionsView.ShowGroupPanel = false;
            this.gv_anadash.OptionsView.ShowViewCaption = true;
            this.gv_anadash.ViewCaption = "DUYURULAR";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Öncelik";
            this.gridColumn1.FieldName = "ONCELIKLI";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Açıklama";
            this.gridColumn2.FieldName = "ACIKLAMA";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Personel";
            this.gridColumn3.FieldName = "PERSONEL";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Tarih";
            this.gridColumn4.FieldName = "TARIH";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // chartControl1
            // 
            this.chartControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartControl1.BackColor = System.Drawing.Color.Transparent;
            this.chartControl1.BorderOptions.Color = System.Drawing.Color.Transparent;
            this.chartControl1.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisX.WholeRange.EndSideMargin = 0D;
            xyDiagram1.AxisX.WholeRange.StartSideMargin = 0D;
            xyDiagram1.AxisY.Interlaced = true;
            xyDiagram1.AxisY.MinorCount = 4;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartControl1.Location = new System.Drawing.Point(607, 3);
            this.chartControl1.Name = "chartControl1";
            pointSeriesLabel1.Border.Visibility = DevExpress.Utils.DefaultBoolean.True;
            pointSeriesLabel1.LineLength = 20;
            pointSeriesLabel1.LineVisibility = DevExpress.Utils.DefaultBoolean.False;
            pointSeriesLabel1.Position = DevExpress.XtraCharts.PointLabelPosition.Center;
            series1.Label = pointSeriesLabel1;
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesPoint1.ColorSerializable = "#F79646";
            seriesPoint2.ColorSerializable = "#31859B";
            series1.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] {
            seriesPoint1,
            seriesPoint2});
            stackedAreaSeriesView1.EmptyPointOptions.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Solid;
            series1.View = stackedAreaSeriesView1;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartControl1.Size = new System.Drawing.Size(599, 287);
            this.chartControl1.TabIndex = 1;
            chartTitle1.Text = "DÖVİZ \r\nKURLARI";
            chartTitle1.WordWrap = true;
            this.chartControl1.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
            // 
            // chartControl2
            // 
            this.chartControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartControl2.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram2.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram2.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram2.DefaultPane.BorderVisible = false;
            xyDiagram2.EnableAxisXScrolling = true;
            xyDiagram2.EnableAxisXZooming = true;
            xyDiagram2.EnableAxisYScrolling = true;
            xyDiagram2.EnableAxisYZooming = true;
            xyDiagram2.PaneLayout.Direction = DevExpress.XtraCharts.PaneLayoutDirection.Horizontal;
            xyDiagram2.Rotated = true;
            this.chartControl2.Diagram = xyDiagram2;
            this.chartControl2.Legend.TextVisible = false;
            this.chartControl2.Location = new System.Drawing.Point(3, 3);
            this.chartControl2.Name = "chartControl2";
            sideBySideBarSeriesLabel1.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
            series2.Label = sideBySideBarSeriesLabel1;
            series2.Name = "Series 1";
            seriesPoint3.ColorSerializable = "#F00000";
            seriesPoint4.ColorSerializable = "#FFFF00";
            seriesPoint5.ColorSerializable = "#F00000";
            seriesPoint6.ColorSerializable = "#FFFF00";
            seriesPoint7.ColorSerializable = "#F00000";
            seriesPoint8.ColorSerializable = "#FFFF00";
            seriesPoint9.ColorSerializable = "#F00000";
            seriesPoint10.ColorSerializable = "#FFFF00";
            series2.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] {
            seriesPoint3,
            seriesPoint4,
            seriesPoint5,
            seriesPoint6,
            seriesPoint7,
            seriesPoint8,
            seriesPoint9,
            seriesPoint10});
            sideBySideBarSeriesView1.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
            sideBySideBarSeriesView1.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Hatch;
            series2.View = sideBySideBarSeriesView1;
            this.chartControl2.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series2};
            sideBySideBarSeriesLabel2.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartControl2.SeriesTemplate.Label = sideBySideBarSeriesLabel2;
            this.chartControl2.Size = new System.Drawing.Size(598, 287);
            this.chartControl2.TabIndex = 2;
            // 
            // chartControl3
            // 
            this.chartControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartControl3.Location = new System.Drawing.Point(607, 296);
            this.chartControl3.Name = "chartControl3";
            series3.Name = "Series 1";
            seriesPoint11.ColorSerializable = "#C6D9F0";
            seriesPoint12.ColorSerializable = "#8DB3E2";
            seriesPoint13.ColorSerializable = "#548DD4";
            seriesPoint14.ColorSerializable = "#244061";
            series3.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] {
            seriesPoint11,
            seriesPoint12,
            seriesPoint13,
            seriesPoint14});
            boxPlotSlideAnimation1.Direction = DevExpress.XtraCharts.AnimationDirection.FromTop;
            boxPlotSlideAnimation1.EasingFunction = quinticEasingFunction1;
            boxPlotSeriesView1.Animation = boxPlotSlideAnimation1;
            boxPlotSeriesView1.MeanLineAnimation = xySeriesUnwindAnimation1;
            series3.View = boxPlotSeriesView1;
            series3.Visible = false;
            this.chartControl3.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series3};
            this.chartControl3.Size = new System.Drawing.Size(599, 288);
            this.chartControl3.TabIndex = 3;
            this.chartControl3.Click += new System.EventHandler(this.chartControl3_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmAnaDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 706);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.Name = "frmAnaDashBoard";
            this.Text = "Ana Dashboard";
            this.Load += new System.EventHandler(this.frmAnaDashBoard_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAnaDashBoard_KeyDown);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_anadash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_anadash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(stackedAreaSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(boxPlotSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevExpress.XtraGrid.GridControl grid_anadash;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_anadash;
        private DevExpress.XtraCharts.ChartControl chartControl2;
        private RjControl.RJButton btn_AktifMusteriSayisi;
        private RjControl.RJButton btn_onaybekleyenTeklif;
        private RjControl.RJButton btn_OnayBekleyenAlisSiparisleri;
        private RjControl.RJButton btn_onayBekleyenSatisSiparisleri;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private DevExpress.XtraCharts.ChartControl chartControl3;
    }
}