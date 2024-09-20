
namespace LOGO_XERO.Moduller.GenelListeler
{
    partial class frmCariKoduAmbarParametreleri
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btn_ambarsec = new DevExpress.XtraEditors.ButtonEdit();
            this.txt_onek = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.txtAmbarAdi = new DevExpress.XtraEditors.TextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_temizle = new DevExpress.XtraEditors.SimpleButton();
            this.btn_kaydet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_ambarsec.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_onek.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmbarAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Location = new System.Drawing.Point(2, 103);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(638, 493);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.düzenleToolStripMenuItem,
            this.silToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 48);
            // 
            // düzenleToolStripMenuItem
            // 
            this.düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            this.düzenleToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.düzenleToolStripMenuItem.Text = "Düzenle";
            this.düzenleToolStripMenuItem.Click += new System.EventHandler(this.düzenleToolStripMenuItem_Click);
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.silToolStripMenuItem.Text = "Sil";
            this.silToolStripMenuItem.Click += new System.EventHandler(this.silToolStripMenuItem_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "AMBAR";
            this.gridColumn1.FieldName = "AMBARADI";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "SERİ BAŞLANGIÇ";
            this.gridColumn2.FieldName = "SERIBASLANGIC";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // btn_ambarsec
            // 
            this.btn_ambarsec.Location = new System.Drawing.Point(102, 5);
            this.btn_ambarsec.Name = "btn_ambarsec";
            this.btn_ambarsec.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btn_ambarsec.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.btn_ambarsec.Size = new System.Drawing.Size(207, 20);
            this.btn_ambarsec.TabIndex = 84;
            this.btn_ambarsec.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btn_ambarsec_ButtonClick);
            // 
            // txt_onek
            // 
            this.txt_onek.Location = new System.Drawing.Point(102, 54);
            this.txt_onek.Name = "txt_onek";
            this.txt_onek.Size = new System.Drawing.Size(207, 20);
            this.txt_onek.TabIndex = 83;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 57);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(77, 13);
            this.labelControl1.TabIndex = 82;
            this.labelControl1.Text = "Cari Kodu Ön Ek";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(7, 8);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(47, 13);
            this.labelControl10.TabIndex = 81;
            this.labelControl10.Text = "Ambar No";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(7, 33);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(49, 13);
            this.labelControl11.TabIndex = 80;
            this.labelControl11.Text = "Ambar Adı";
            // 
            // txtAmbarAdi
            // 
            this.txtAmbarAdi.EditValue = "";
            this.txtAmbarAdi.Location = new System.Drawing.Point(102, 28);
            this.txtAmbarAdi.Name = "txtAmbarAdi";
            this.txtAmbarAdi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtAmbarAdi.Properties.Appearance.Options.UseFont = true;
            this.txtAmbarAdi.Properties.AutoHeight = false;
            this.txtAmbarAdi.Properties.ReadOnly = true;
            this.txtAmbarAdi.Size = new System.Drawing.Size(207, 23);
            this.txtAmbarAdi.TabIndex = 79;
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.btn_temizle);
            this.panelControl1.Controls.Add(this.btn_kaydet);
            this.panelControl1.Controls.Add(this.btn_ambarsec);
            this.panelControl1.Controls.Add(this.txt_onek);
            this.panelControl1.Controls.Add(this.labelControl10);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtAmbarAdi);
            this.panelControl1.Controls.Add(this.labelControl11);
            this.panelControl1.Location = new System.Drawing.Point(2, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(638, 85);
            this.panelControl1.TabIndex = 86;
            // 
            // btn_temizle
            // 
            this.btn_temizle.Location = new System.Drawing.Point(315, 46);
            this.btn_temizle.Name = "btn_temizle";
            this.btn_temizle.Size = new System.Drawing.Size(147, 28);
            this.btn_temizle.TabIndex = 86;
            this.btn_temizle.Text = "Temizle";
            this.btn_temizle.Click += new System.EventHandler(this.btn_temizle_Click);
            // 
            // btn_kaydet
            // 
            this.btn_kaydet.Location = new System.Drawing.Point(315, 12);
            this.btn_kaydet.Name = "btn_kaydet";
            this.btn_kaydet.Size = new System.Drawing.Size(147, 28);
            this.btn_kaydet.TabIndex = 85;
            this.btn_kaydet.Text = "Ekle";
            this.btn_kaydet.Click += new System.EventHandler(this.btn_kaydet_Click);
            // 
            // frmCariKoduAmbarParametreleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 596);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gridControl1);
            this.Name = "frmCariKoduAmbarParametreleri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cari Kodu - Ambar Parametreleri";
            this.Load += new System.EventHandler(this.frmCariKoduAmbarParametreleri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_ambarsec.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_onek.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmbarAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        public DevExpress.XtraEditors.ButtonEdit btn_ambarsec;
        private DevExpress.XtraEditors.TextEdit txt_onek;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        public DevExpress.XtraEditors.TextEdit txtAmbarAdi;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_temizle;
        private DevExpress.XtraEditors.SimpleButton btn_kaydet;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
    }
}