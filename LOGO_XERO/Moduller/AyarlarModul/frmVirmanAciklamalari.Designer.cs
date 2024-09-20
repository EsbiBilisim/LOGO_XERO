namespace LOGO_XERO.Moduller.AyarlarModul
{
    partial class frmVirmanAciklamalari
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_temizle = new DevExpress.XtraEditors.SimpleButton();
            this.btn_kaydet = new DevExpress.XtraEditors.SimpleButton();
            this.txt_virmanaciklama = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControlVirmanAciklama = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.güncelleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gv_virmanaciklama = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VIRMANACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlVirmanAciklama)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_virmanaciklama)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.btn_temizle);
            this.panelControl1.Controls.Add(this.btn_kaydet);
            this.panelControl1.Controls.Add(this.txt_virmanaciklama);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(5, 9);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(740, 85);
            this.panelControl1.TabIndex = 5;
            // 
            // btn_temizle
            // 
            this.btn_temizle.Location = new System.Drawing.Point(584, 46);
            this.btn_temizle.Name = "btn_temizle";
            this.btn_temizle.Size = new System.Drawing.Size(147, 28);
            this.btn_temizle.TabIndex = 3;
            this.btn_temizle.Text = "Temizle";
            this.btn_temizle.Click += new System.EventHandler(this.btn_temizle_Click);
            // 
            // btn_kaydet
            // 
            this.btn_kaydet.Location = new System.Drawing.Point(584, 12);
            this.btn_kaydet.Name = "btn_kaydet";
            this.btn_kaydet.Size = new System.Drawing.Size(147, 28);
            this.btn_kaydet.TabIndex = 2;
            this.btn_kaydet.Text = "Ekle";
            this.btn_kaydet.Click += new System.EventHandler(this.btn_kaydet_Click);
            // 
            // txt_virmanaciklama
            // 
            this.txt_virmanaciklama.Location = new System.Drawing.Point(5, 28);
            this.txt_virmanaciklama.Multiline = true;
            this.txt_virmanaciklama.Name = "txt_virmanaciklama";
            this.txt_virmanaciklama.Size = new System.Drawing.Size(566, 46);
            this.txt_virmanaciklama.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(90, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Virman Açıklamaları";
            // 
            // gridControlVirmanAciklama
            // 
            this.gridControlVirmanAciklama.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlVirmanAciklama.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControlVirmanAciklama.Location = new System.Drawing.Point(3, 100);
            this.gridControlVirmanAciklama.MainView = this.gv_virmanaciklama;
            this.gridControlVirmanAciklama.Name = "gridControlVirmanAciklama";
            this.gridControlVirmanAciklama.Size = new System.Drawing.Size(742, 435);
            this.gridControlVirmanAciklama.TabIndex = 4;
            this.gridControlVirmanAciklama.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_virmanaciklama});
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
            // gv_virmanaciklama
            // 
            this.gv_virmanaciklama.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.VIRMANACIKLAMA});
            this.gv_virmanaciklama.GridControl = this.gridControlVirmanAciklama;
            this.gv_virmanaciklama.Name = "gv_virmanaciklama";
            this.gv_virmanaciklama.OptionsBehavior.Editable = false;
            this.gv_virmanaciklama.OptionsBehavior.ReadOnly = true;
            this.gv_virmanaciklama.OptionsView.ShowGroupPanel = false;
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // VIRMANACIKLAMA
            // 
            this.VIRMANACIKLAMA.Caption = "Virman Açıklamaları";
            this.VIRMANACIKLAMA.FieldName = "VIRMANACIKLAMA";
            this.VIRMANACIKLAMA.Name = "VIRMANACIKLAMA";
            this.VIRMANACIKLAMA.Visible = true;
            this.VIRMANACIKLAMA.VisibleIndex = 0;
            // 
            // frmVirmanAciklamalari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 544);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gridControlVirmanAciklama);
            this.Name = "frmVirmanAciklamalari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Virman Açıklamaları";
            this.Load += new System.EventHandler(this.frmVirmanAciklamalari_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlVirmanAciklama)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv_virmanaciklama)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_temizle;
        private DevExpress.XtraEditors.SimpleButton btn_kaydet;
        private System.Windows.Forms.TextBox txt_virmanaciklama;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridControlVirmanAciklama;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_virmanaciklama;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn VIRMANACIKLAMA;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem güncelleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
    }
}