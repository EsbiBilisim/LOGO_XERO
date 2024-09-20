
namespace LOGO_XERO.Moduller.GenelListeler
{
    partial class frmTeslimSekilleri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTeslimSekilleri));
            this.grid_TeslimSekli = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gv_TeslimSekli = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.txt_aciklama = new DevExpress.XtraEditors.TextEdit();
            this.txt_kodu = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grid_TeslimSekli)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_TeslimSekli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_aciklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_kodu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grid_TeslimSekli
            // 
            this.grid_TeslimSekli.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_TeslimSekli.ContextMenuStrip = this.contextMenuStrip1;
            this.grid_TeslimSekli.Location = new System.Drawing.Point(3, 121);
            this.grid_TeslimSekli.MainView = this.gv_TeslimSekli;
            this.grid_TeslimSekli.Name = "grid_TeslimSekli";
            this.grid_TeslimSekli.Size = new System.Drawing.Size(404, 449);
            this.grid_TeslimSekli.TabIndex = 1;
            this.grid_TeslimSekli.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_TeslimSekli});
            this.grid_TeslimSekli.DoubleClick += new System.EventHandler(this.grid_TeslimSekli_DoubleClick);
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
            // gv_TeslimSekli
            // 
            this.gv_TeslimSekli.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gv_TeslimSekli.GridControl = this.grid_TeslimSekli;
            this.gv_TeslimSekli.Name = "gv_TeslimSekli";
            this.gv_TeslimSekli.OptionsBehavior.Editable = false;
            this.gv_TeslimSekli.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Kodu";
            this.gridColumn1.FieldName = "SCODE";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Açıklama";
            this.gridColumn2.FieldName = "SDEF";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Location = new System.Drawing.Point(3, 576);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(404, 53);
            this.panelControl1.TabIndex = 105;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.simpleButton1.Location = new System.Drawing.Point(309, 8);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(90, 37);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "[Esc] Vazgeç";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.simpleButton2);
            this.groupControl1.Controls.Add(this.txt_aciklama);
            this.groupControl1.Controls.Add(this.txt_kodu);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.simpleButton4);
            this.groupControl1.Location = new System.Drawing.Point(3, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(404, 103);
            this.groupControl1.TabIndex = 106;
            this.groupControl1.Text = "Teslim Şekli Ekleme";
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(241, 30);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(20, 20);
            this.simpleButton2.TabIndex = 26;
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // txt_aciklama
            // 
            this.txt_aciklama.Location = new System.Drawing.Point(53, 56);
            this.txt_aciklama.Name = "txt_aciklama";
            this.txt_aciklama.Properties.MaxLength = 41;
            this.txt_aciklama.Size = new System.Drawing.Size(185, 20);
            this.txt_aciklama.TabIndex = 25;
            // 
            // txt_kodu
            // 
            this.txt_kodu.Location = new System.Drawing.Point(53, 30);
            this.txt_kodu.Name = "txt_kodu";
            this.txt_kodu.Properties.MaxLength = 41;
            this.txt_kodu.Size = new System.Drawing.Size(185, 20);
            this.txt_kodu.TabIndex = 24;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 57);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(41, 13);
            this.labelControl2.TabIndex = 23;
            this.labelControl2.Text = "Açıklama";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 13);
            this.labelControl1.TabIndex = 22;
            this.labelControl1.Text = "Kodu";
            // 
            // simpleButton4
            // 
            this.simpleButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.simpleButton4.Appearance.Options.UseFont = true;
            this.simpleButton4.Location = new System.Drawing.Point(288, 45);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(111, 37);
            this.simpleButton4.TabIndex = 21;
            this.simpleButton4.Text = "[F2] Kaydet";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // frmTeslimSekilleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 630);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.grid_TeslimSekli);
            this.KeyPreview = true;
            this.Name = "frmTeslimSekilleri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teslim Şekilleri";
            this.Load += new System.EventHandler(this.frmTeslimSekilleri_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTeslimSekilleri_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grid_TeslimSekli)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv_TeslimSekli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_aciklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_kodu.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid_TeslimSekli;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_TeslimSekli;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txt_aciklama;
        private DevExpress.XtraEditors.TextEdit txt_kodu;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}