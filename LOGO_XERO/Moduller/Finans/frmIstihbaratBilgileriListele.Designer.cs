
namespace LOGO_XERO.Moduller.Finans
{
    partial class frmIstihbaratBilgileriListele
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
            this.grid_IstihbaratBilgileri = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid_IstihbaratBilgileri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grid_IstihbaratBilgileri
            // 
            this.grid_IstihbaratBilgileri.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_IstihbaratBilgileri.Location = new System.Drawing.Point(4, 12);
            this.grid_IstihbaratBilgileri.MainView = this.gridView1;
            this.grid_IstihbaratBilgileri.Name = "grid_IstihbaratBilgileri";
            this.grid_IstihbaratBilgileri.Size = new System.Drawing.Size(532, 514);
            this.grid_IstihbaratBilgileri.TabIndex = 109;
            this.grid_IstihbaratBilgileri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.Azure;
            this.gridView1.Appearance.EvenRow.BackColor2 = System.Drawing.Color.Azure;
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Tan;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.ColumnPanelRowHeight = 25;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5});
            this.gridView1.FooterPanelHeight = 25;
            this.gridView1.GridControl = this.grid_IstihbaratBilgileri;
            this.gridView1.GroupRowHeight = 25;
            this.gridView1.IndicatorWidth = 25;
            this.gridView1.LevelIndent = 25;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.BestFitMaxRowCount = 30;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PreviewIndent = 25;
            this.gridView1.PreviewLineCount = 25;
            this.gridView1.RowHeight = 25;
            this.gridView1.ViewCaptionHeight = 25;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Açıklama";
            this.gridColumn5.FieldName = "INTELLINE";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 1372;
            // 
            // frmIstihbaratBilgileriListele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 544);
            this.Controls.Add(this.grid_IstihbaratBilgileri);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIstihbaratBilgileriListele";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İstihbarat Bilgileri";
            this.Load += new System.EventHandler(this.frmIstihbaratBilgileriListele_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmIstihbaratBilgileriListele_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grid_IstihbaratBilgileri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl grid_IstihbaratBilgileri;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
    }
}