namespace LOGO_XERO.Moduller.Giris_AnaForm_Ayarlar
{
    partial class frmDuyurular
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.btn_temizle = new DevExpress.XtraEditors.SimpleButton();
            this.btn_kaydet = new DevExpress.XtraEditors.SimpleButton();
            this.txt_duyuruaciklama = new System.Windows.Forms.TextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.gridDuyuru = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.güncelleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gv_duyuru = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.DUYURUACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDuyuru)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_duyuru)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.Controls.Add(this.checkEdit1);
            this.panelControl2.Controls.Add(this.btn_temizle);
            this.panelControl2.Controls.Add(this.btn_kaydet);
            this.panelControl2.Controls.Add(this.txt_duyuruaciklama);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Location = new System.Drawing.Point(12, 12);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(724, 85);
            this.panelControl2.TabIndex = 10;
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(502, 2);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Appearance.Options.UseTextOptions = true;
            this.checkEdit1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.checkEdit1.Properties.Caption = "Öncelikli";
            this.checkEdit1.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.checkEdit1.Size = new System.Drawing.Size(69, 19);
            this.checkEdit1.TabIndex = 4;
            // 
            // btn_temizle
            // 
            this.btn_temizle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_temizle.Location = new System.Drawing.Point(584, 46);
            this.btn_temizle.Name = "btn_temizle";
            this.btn_temizle.Size = new System.Drawing.Size(135, 28);
            this.btn_temizle.TabIndex = 3;
            this.btn_temizle.Text = "Temizle";
            this.btn_temizle.Click += new System.EventHandler(this.btn_temizle_Click);
            // 
            // btn_kaydet
            // 
            this.btn_kaydet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_kaydet.Location = new System.Drawing.Point(584, 12);
            this.btn_kaydet.Name = "btn_kaydet";
            this.btn_kaydet.Size = new System.Drawing.Size(135, 28);
            this.btn_kaydet.TabIndex = 2;
            this.btn_kaydet.Text = "Ekle";
            this.btn_kaydet.Click += new System.EventHandler(this.btn_kaydet_Click);
            // 
            // txt_duyuruaciklama
            // 
            this.txt_duyuruaciklama.Location = new System.Drawing.Point(5, 28);
            this.txt_duyuruaciklama.Multiline = true;
            this.txt_duyuruaciklama.Name = "txt_duyuruaciklama";
            this.txt_duyuruaciklama.Size = new System.Drawing.Size(566, 46);
            this.txt_duyuruaciklama.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(79, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Duyuru Açıklama";
            // 
            // gridDuyuru
            // 
            this.gridDuyuru.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDuyuru.ContextMenuStrip = this.contextMenuStrip1;
            this.gridDuyuru.Location = new System.Drawing.Point(12, 103);
            this.gridDuyuru.MainView = this.gv_duyuru;
            this.gridDuyuru.Name = "gridDuyuru";
            this.gridDuyuru.Size = new System.Drawing.Size(724, 435);
            this.gridDuyuru.TabIndex = 9;
            this.gridDuyuru.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_duyuru});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.güncelleToolStripMenuItem,
            this.toolStripSeparator1,
            this.silToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 54);
            // 
            // güncelleToolStripMenuItem
            // 
            this.güncelleToolStripMenuItem.Name = "güncelleToolStripMenuItem";
            this.güncelleToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.güncelleToolStripMenuItem.Text = "Düzenle";
            this.güncelleToolStripMenuItem.Click += new System.EventHandler(this.güncelleToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(113, 6);
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.silToolStripMenuItem.Text = "Sil";
            this.silToolStripMenuItem.Click += new System.EventHandler(this.silToolStripMenuItem_Click);
            // 
            // gv_duyuru
            // 
            this.gv_duyuru.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.DUYURUACIKLAMA,
            this.gridColumn1});
            this.gv_duyuru.GridControl = this.gridDuyuru;
            this.gv_duyuru.Name = "gv_duyuru";
            this.gv_duyuru.OptionsBehavior.Editable = false;
            this.gv_duyuru.OptionsBehavior.ReadOnly = true;
            this.gv_duyuru.OptionsView.ShowGroupPanel = false;
            // 
            // DUYURUACIKLAMA
            // 
            this.DUYURUACIKLAMA.Caption = "Duyuru Açıklaması";
            this.DUYURUACIKLAMA.FieldName = "ACIKLAMA";
            this.DUYURUACIKLAMA.Name = "DUYURUACIKLAMA";
            this.DUYURUACIKLAMA.Visible = true;
            this.DUYURUACIKLAMA.VisibleIndex = 0;
            this.DUYURUACIKLAMA.Width = 1389;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Öncelik";
            this.gridColumn1.FieldName = "ONCELIKLI";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 233;
            // 
            // frmDuyurular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 544);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.gridDuyuru);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDuyurular";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Duyurular";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDuyurular_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDuyuru)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv_duyuru)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btn_temizle;
        private DevExpress.XtraEditors.SimpleButton btn_kaydet;
        private System.Windows.Forms.TextBox txt_duyuruaciklama;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl gridDuyuru;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_duyuru;
        private DevExpress.XtraGrid.Columns.GridColumn DUYURUACIKLAMA;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem güncelleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}