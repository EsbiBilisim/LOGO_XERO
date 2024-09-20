
namespace LOGO_XERO.Moduller.GenelListeler
{
    partial class frmTasiyiciKodlari
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
            this.grid_TasiyiciKodlari = new DevExpress.XtraGrid.GridControl();
            this.gv_TasiyiciKodlari = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ekleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.grid_TasiyiciKodlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_TasiyiciKodlari)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid_TasiyiciKodlari
            // 
            this.grid_TasiyiciKodlari.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_TasiyiciKodlari.ContextMenuStrip = this.contextMenuStrip1;
            this.grid_TasiyiciKodlari.Location = new System.Drawing.Point(3, 12);
            this.grid_TasiyiciKodlari.MainView = this.gv_TasiyiciKodlari;
            this.grid_TasiyiciKodlari.Name = "grid_TasiyiciKodlari";
            this.grid_TasiyiciKodlari.Size = new System.Drawing.Size(577, 491);
            this.grid_TasiyiciKodlari.TabIndex = 0;
            this.grid_TasiyiciKodlari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_TasiyiciKodlari});
            this.grid_TasiyiciKodlari.DoubleClick += new System.EventHandler(this.grid_TasiyiciKodlari_DoubleClick);
            // 
            // gv_TasiyiciKodlari
            // 
            this.gv_TasiyiciKodlari.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gv_TasiyiciKodlari.GridControl = this.grid_TasiyiciKodlari;
            this.gv_TasiyiciKodlari.Name = "gv_TasiyiciKodlari";
            this.gv_TasiyiciKodlari.OptionsBehavior.Editable = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Kodu";
            this.gridColumn1.FieldName = "CODE";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Açıklama";
            this.gridColumn2.FieldName = "TITLE";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ekleToolStripMenuItem,
            this.düzenleToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 48);
            // 
            // ekleToolStripMenuItem
            // 
            this.ekleToolStripMenuItem.Name = "ekleToolStripMenuItem";
            this.ekleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ekleToolStripMenuItem.Text = "Ekle";
            this.ekleToolStripMenuItem.Click += new System.EventHandler(this.ekleToolStripMenuItem_Click);
            // 
            // düzenleToolStripMenuItem
            // 
            this.düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            this.düzenleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.düzenleToolStripMenuItem.Text = "Düzenle";
            this.düzenleToolStripMenuItem.Click += new System.EventHandler(this.düzenleToolStripMenuItem_Click);
            // 
            // frmTasiyiciKodlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 507);
            this.Controls.Add(this.grid_TasiyiciKodlari);
            this.Name = "frmTasiyiciKodlari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Taşıyıcı Kodları";
            this.Load += new System.EventHandler(this.frmTasiyiciKodlari_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_TasiyiciKodlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_TasiyiciKodlari)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid_TasiyiciKodlari;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_TasiyiciKodlari;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ekleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
    }
}