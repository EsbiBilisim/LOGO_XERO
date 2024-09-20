
namespace LOGO_XERO.Moduller.GenelListeler
{
    partial class frmTicariIslemGuruplari
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
            this.grid_TicariIslemGuruplari = new DevExpress.XtraGrid.GridControl();
            this.gv_TicariIslemGruplari = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grid_TicariIslemGuruplari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_TicariIslemGruplari)).BeginInit();
            this.SuspendLayout();
            // 
            // grid_TicariIslemGuruplari
            // 
            this.grid_TicariIslemGuruplari.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_TicariIslemGuruplari.Location = new System.Drawing.Point(12, 12);
            this.grid_TicariIslemGuruplari.MainView = this.gv_TicariIslemGruplari;
            this.grid_TicariIslemGuruplari.Name = "grid_TicariIslemGuruplari";
            this.grid_TicariIslemGuruplari.Size = new System.Drawing.Size(564, 425);
            this.grid_TicariIslemGuruplari.TabIndex = 0;
            this.grid_TicariIslemGuruplari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_TicariIslemGruplari});
            this.grid_TicariIslemGuruplari.DoubleClick += new System.EventHandler(this.grid_TicariIslemGuruplari_DoubleClick);
            // 
            // gv_TicariIslemGruplari
            // 
            this.gv_TicariIslemGruplari.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gv_TicariIslemGruplari.GridControl = this.grid_TicariIslemGuruplari;
            this.gv_TicariIslemGruplari.Name = "gv_TicariIslemGruplari";
            this.gv_TicariIslemGruplari.OptionsBehavior.Editable = false;
            this.gv_TicariIslemGruplari.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Kodu";
            this.gridColumn1.FieldName = "GCODE";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 113;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Açıklama";
            this.gridColumn2.FieldName = "GDEF";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 311;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Location = new System.Drawing.Point(465, 443);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(111, 37);
            this.simpleButton2.TabIndex = 19;
            this.simpleButton2.Text = "[Esc] Kapat";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // frmTicariIslemGuruplari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 482);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.grid_TicariIslemGuruplari);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTicariIslemGuruplari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ticari İşlem Gurupları";
            this.Load += new System.EventHandler(this.frmTicariIslemGuruplari_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTicariIslemGuruplari_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grid_TicariIslemGuruplari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_TicariIslemGruplari)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid_TicariIslemGuruplari;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_TicariIslemGruplari;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}