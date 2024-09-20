namespace LOGO_XERO.Moduller.GenelListeler
{
    partial class frmBirimler
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridBirimler = new DevExpress.XtraGrid.GridControl();
            this.gv_birimler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBirimler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_birimler)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.gridBirimler);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(385, 363);
            this.panelControl1.TabIndex = 0;
            // 
            // gridBirimler
            // 
            this.gridBirimler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridBirimler.Location = new System.Drawing.Point(5, 5);
            this.gridBirimler.MainView = this.gv_birimler;
            this.gridBirimler.Name = "gridBirimler";
            this.gridBirimler.Size = new System.Drawing.Size(375, 353);
            this.gridBirimler.TabIndex = 0;
            this.gridBirimler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_birimler});
            this.gridBirimler.DoubleClick += new System.EventHandler(this.gridBirimler_DoubleClick);
            // 
            // gv_birimler
            // 
            this.gv_birimler.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gv_birimler.GridControl = this.gridBirimler;
            this.gv_birimler.Name = "gv_birimler";
            this.gv_birimler.OptionsBehavior.Editable = false;
            this.gv_birimler.OptionsView.ColumnAutoWidth = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Kodu";
            this.gridColumn1.FieldName = "BIRIMKODU";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 89;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Açıklama";
            this.gridColumn2.FieldName = "BIRIMACIKLAMA";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 155;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Katsayı 1";
            this.gridColumn3.FieldName = "CONVFACT1";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 54;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Katsayı 2";
            this.gridColumn4.FieldName = "CONVFACT2";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 59;
            // 
            // frmBirimler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 387);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmBirimler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Birimler";
            this.Load += new System.EventHandler(this.frmBirimler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBirimler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_birimler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridBirimler;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_birimler;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}