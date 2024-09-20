namespace LOGO_XERO.Moduller._7_Raporlar
{
    partial class frmDetayBilgi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetayBilgi));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_alacakyaslandirma = new DevExpress.XtraEditors.SimpleButton();
            this.btn_borclasdirma = new DevExpress.XtraEditors.SimpleButton();
            this.btn_ay = new System.Windows.Forms.RadioButton();
            this.btn_yl = new System.Windows.Forms.RadioButton();
            this.kapat = new DevExpress.XtraEditors.SimpleButton();
            this.grid_detaybilgi = new DevExpress.XtraGrid.GridControl();
            this.gv_detaybilgi = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_detaybilgi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_detaybilgi)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.btn_alacakyaslandirma);
            this.panelControl1.Controls.Add(this.btn_borclasdirma);
            this.panelControl1.Controls.Add(this.btn_ay);
            this.panelControl1.Controls.Add(this.btn_yl);
            this.panelControl1.Controls.Add(this.kapat);
            this.panelControl1.Location = new System.Drawing.Point(1, 469);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1055, 30);
            this.panelControl1.TabIndex = 6;
            // 
            // btn_alacakyaslandirma
            // 
            this.btn_alacakyaslandirma.Location = new System.Drawing.Point(920, 4);
            this.btn_alacakyaslandirma.Name = "btn_alacakyaslandirma";
            this.btn_alacakyaslandirma.Size = new System.Drawing.Size(103, 23);
            this.btn_alacakyaslandirma.TabIndex = 7;
            this.btn_alacakyaslandirma.Text = "Alacak Yaşlandırma";
            this.btn_alacakyaslandirma.Visible = false;
            // 
            // btn_borclasdirma
            // 
            this.btn_borclasdirma.Location = new System.Drawing.Point(811, 4);
            this.btn_borclasdirma.Name = "btn_borclasdirma";
            this.btn_borclasdirma.Size = new System.Drawing.Size(103, 23);
            this.btn_borclasdirma.TabIndex = 5;
            this.btn_borclasdirma.Text = "Borç Yaşlandırma";
            this.btn_borclasdirma.Visible = false;
            // 
            // btn_ay
            // 
            this.btn_ay.AutoSize = true;
            this.btn_ay.Location = new System.Drawing.Point(114, 5);
            this.btn_ay.Name = "btn_ay";
            this.btn_ay.Size = new System.Drawing.Size(105, 17);
            this.btn_ay.TabIndex = 2;
            this.btn_ay.TabStop = true;
            this.btn_ay.Text = "Aya Göre Filtrele";
            this.btn_ay.UseVisualStyleBackColor = true;
            this.btn_ay.CheckedChanged += new System.EventHandler(this.btn_ay_CheckedChanged);
            // 
            // btn_yl
            // 
            this.btn_yl.AutoSize = true;
            this.btn_yl.Location = new System.Drawing.Point(6, 6);
            this.btn_yl.Name = "btn_yl";
            this.btn_yl.Size = new System.Drawing.Size(102, 17);
            this.btn_yl.TabIndex = 1;
            this.btn_yl.TabStop = true;
            this.btn_yl.Text = "Yıla Göre Filtrele";
            this.btn_yl.UseVisualStyleBackColor = true;
            this.btn_yl.CheckedChanged += new System.EventHandler(this.btn_yl_CheckedChanged);
            // 
            // kapat
            // 
            this.kapat.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.kapat.Dock = System.Windows.Forms.DockStyle.Right;
            this.kapat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("kapat.ImageOptions.Image")));
            this.kapat.Location = new System.Drawing.Point(1029, 2);
            this.kapat.Name = "kapat";
            this.kapat.Size = new System.Drawing.Size(24, 26);
            this.kapat.TabIndex = 0;
            // 
            // grid_detaybilgi
            // 
            this.grid_detaybilgi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_detaybilgi.Location = new System.Drawing.Point(1, 3);
            this.grid_detaybilgi.MainView = this.gv_detaybilgi;
            this.grid_detaybilgi.Name = "grid_detaybilgi";
            this.grid_detaybilgi.Padding = new System.Windows.Forms.Padding(3);
            this.grid_detaybilgi.Size = new System.Drawing.Size(1055, 460);
            this.grid_detaybilgi.TabIndex = 5;
            this.grid_detaybilgi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_detaybilgi});
            // 
            // gv_detaybilgi
            // 
            this.gv_detaybilgi.GridControl = this.grid_detaybilgi;
            this.gv_detaybilgi.Name = "gv_detaybilgi";
            this.gv_detaybilgi.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gv_detaybilgi.OptionsView.ColumnAutoWidth = false;
            this.gv_detaybilgi.OptionsView.EnableAppearanceEvenRow = true;
            this.gv_detaybilgi.OptionsView.ShowAutoFilterRow = true;
            this.gv_detaybilgi.OptionsView.ShowFooter = true;
            this.gv_detaybilgi.OptionsView.ShowGroupPanel = false;
            // 
            // frmDetayBilgi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 511);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.grid_detaybilgi);
            this.Name = "frmDetayBilgi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detay Bilgilendirme";
            this.Load += new System.EventHandler(this.frmDetayBilgi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_detaybilgi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_detaybilgi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_alacakyaslandirma;
        private DevExpress.XtraEditors.SimpleButton btn_borclasdirma;
        private System.Windows.Forms.RadioButton btn_ay;
        private System.Windows.Forms.RadioButton btn_yl;
        private DevExpress.XtraEditors.SimpleButton kapat;
        public DevExpress.XtraGrid.GridControl grid_detaybilgi;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_detaybilgi;
    }
}