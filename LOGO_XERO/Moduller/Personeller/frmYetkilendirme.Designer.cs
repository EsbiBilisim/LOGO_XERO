
namespace LOGO_XERO.Moduller.Personeller
{
    partial class frmYetkilendirme
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
            this.İşlemler = new DevExpress.XtraTreeList.TreeList();
            this.İslemler = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.İşlemler)).BeginInit();
            this.SuspendLayout();
            // 
            // İşlemler
            // 
            this.İşlemler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.İşlemler.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.İslemler});
            this.İşlemler.CustomizationFormBounds = new System.Drawing.Rectangle(428, 463, 266, 236);
            this.İşlemler.Location = new System.Drawing.Point(10, 12);
            this.İşlemler.Name = "İşlemler";
            this.İşlemler.OptionsBehavior.Editable = false;
            this.İşlemler.OptionsBehavior.PopulateServiceColumns = true;
            this.İşlemler.OptionsPrint.PrintFilledTreeIndent = true;
            this.İşlemler.OptionsPrint.PrintPageHeader = false;
            this.İşlemler.OptionsPrint.PrintReportFooter = false;
            this.İşlemler.OptionsView.ShowBandsMode = DevExpress.Utils.DefaultBoolean.True;
            this.İşlemler.OptionsView.ShowTreeLines = DevExpress.Utils.DefaultBoolean.True;
            this.İşlemler.Size = new System.Drawing.Size(617, 514);
            this.İşlemler.TabIndex = 0;
            this.İşlemler.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.İşlemler_AfterCheckNode);
            // 
            // İslemler
            // 
            this.İslemler.Caption = "İşlemler";
            this.İslemler.FieldName = "İşlemler";
            this.İslemler.Name = "İslemler";
            this.İslemler.OptionsColumn.AllowSort = true;
            this.İslemler.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.İslemler.Visible = true;
            this.İslemler.VisibleIndex = 0;
            // 
            // frmYetkilendirme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 539);
            this.Controls.Add(this.İşlemler);
            this.Name = "frmYetkilendirme";
            this.Text = "İşlem Yetkileri";
            this.Load += new System.EventHandler(this.frmYetkilendirme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.İşlemler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList İşlemler;
        private DevExpress.XtraTreeList.Columns.TreeListColumn İslemler;
    }
}