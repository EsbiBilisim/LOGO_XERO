namespace LOGO_XERO.Moduller.GenelListeler
{
    partial class frmProjeler
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
            this.grid_Projeler = new DevExpress.XtraGrid.GridControl();
            this.gv_Projeler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Projeler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Projeler)).BeginInit();
            this.SuspendLayout();
            // 
            // grid_Projeler
            // 
            this.grid_Projeler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_Projeler.Location = new System.Drawing.Point(12, 12);
            this.grid_Projeler.MainView = this.gv_Projeler;
            this.grid_Projeler.Name = "grid_Projeler";
            this.grid_Projeler.Size = new System.Drawing.Size(569, 531);
            this.grid_Projeler.TabIndex = 0;
            this.grid_Projeler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_Projeler});
            this.grid_Projeler.DoubleClick += new System.EventHandler(this.grid_Projeler_DoubleClick);
            // 
            // gv_Projeler
            // 
            this.gv_Projeler.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gv_Projeler.GridControl = this.grid_Projeler;
            this.gv_Projeler.Name = "gv_Projeler";
            this.gv_Projeler.OptionsBehavior.Editable = false;
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
            this.gridColumn2.FieldName = "NAME";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // frmProjeler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 555);
            this.Controls.Add(this.grid_Projeler);
            this.Name = "frmProjeler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Projeler";
            this.Load += new System.EventHandler(this.frmProjeler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_Projeler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Projeler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid_Projeler;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_Projeler;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}