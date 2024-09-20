namespace LOGO_XERO.Moduller.GenelListeler
{
    partial class frmBarkodlar
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
            this.grid_barkodlar = new DevExpress.XtraGrid.GridControl();
            this.gv_barkodlar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid_barkodlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_barkodlar)).BeginInit();
            this.SuspendLayout();
            // 
            // grid_barkodlar
            // 
            this.grid_barkodlar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_barkodlar.Location = new System.Drawing.Point(12, 12);
            this.grid_barkodlar.MainView = this.gv_barkodlar;
            this.grid_barkodlar.Name = "grid_barkodlar";
            this.grid_barkodlar.Size = new System.Drawing.Size(371, 491);
            this.grid_barkodlar.TabIndex = 0;
            this.grid_barkodlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_barkodlar});
            // 
            // gv_barkodlar
            // 
            this.gv_barkodlar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gv_barkodlar.GridControl = this.grid_barkodlar;
            this.gv_barkodlar.Name = "gv_barkodlar";
            this.gv_barkodlar.OptionsView.ShowFooter = true;
            this.gv_barkodlar.OptionsView.ShowGroupPanel = false;
            this.gv_barkodlar.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gv_barkodlar_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Barkod";
            this.gridColumn1.FieldName = "BARCODE";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // frmBarkodlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 515);
            this.Controls.Add(this.grid_barkodlar);
            this.Name = "frmBarkodlar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barkodlar";
            this.Load += new System.EventHandler(this.frmBarkodlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_barkodlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_barkodlar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid_barkodlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_barkodlar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}