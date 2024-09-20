namespace LOGO_XERO.Moduller.GenelListeler
{
    partial class frmTeklifGorusmeler
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtTeklifId = new DevExpress.XtraEditors.TextEdit();
            this.txtAciklama = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_Kaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Vazgec = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTeklifId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelControl2.Controls.Add(this.txtTeklifId);
            this.panelControl2.Controls.Add(this.txtAciklama);
            this.panelControl2.Controls.Add(this.labelControl7);
            this.panelControl2.Location = new System.Drawing.Point(12, 12);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(477, 191);
            this.panelControl2.TabIndex = 104;
            // 
            // txtTeklifId
            // 
            this.txtTeklifId.Location = new System.Drawing.Point(344, 22);
            this.txtTeklifId.Name = "txtTeklifId";
            this.txtTeklifId.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTeklifId.Properties.Appearance.Options.UseFont = true;
            this.txtTeklifId.Properties.AutoHeight = false;
            this.txtTeklifId.Properties.ReadOnly = true;
            this.txtTeklifId.Size = new System.Drawing.Size(107, 21);
            this.txtTeklifId.TabIndex = 62;
            this.txtTeklifId.TabStop = false;
            this.txtTeklifId.Visible = false;
            // 
            // txtAciklama
            // 
            this.txtAciklama.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAciklama.Location = new System.Drawing.Point(25, 49);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAciklama.Properties.Appearance.Options.UseFont = true;
            this.txtAciklama.Size = new System.Drawing.Size(426, 137);
            this.txtAciklama.TabIndex = 45;
            this.txtAciklama.ToolTip = "Açıklama kutusunu büyütmek için çift tıklayın...";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(25, 29);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(82, 14);
            this.labelControl7.TabIndex = 44;
            this.labelControl7.Text = "Görüşme Metni";
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelControl1.Controls.Add(this.btn_Kaydet);
            this.panelControl1.Controls.Add(this.btn_Vazgec);
            this.panelControl1.Location = new System.Drawing.Point(12, 209);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(477, 48);
            this.panelControl1.TabIndex = 105;
            // 
            // btn_Kaydet
            // 
            this.btn_Kaydet.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_Kaydet.Location = new System.Drawing.Point(286, 6);
            this.btn_Kaydet.Name = "btn_Kaydet";
            this.btn_Kaydet.Size = new System.Drawing.Size(90, 37);
            this.btn_Kaydet.TabIndex = 3;
            this.btn_Kaydet.Text = "[F2] Kaydet";
            this.btn_Kaydet.Click += new System.EventHandler(this.btn_Kaydet_Click);
            // 
            // btn_Vazgec
            // 
            this.btn_Vazgec.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_Vazgec.Location = new System.Drawing.Point(382, 6);
            this.btn_Vazgec.Name = "btn_Vazgec";
            this.btn_Vazgec.Size = new System.Drawing.Size(90, 37);
            this.btn_Vazgec.TabIndex = 4;
            this.btn_Vazgec.Text = "[Esc] Vazgeç";
            this.btn_Vazgec.Click += new System.EventHandler(this.btn_Vazgec_Click);
            // 
            // frmTeklifGorusmeler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 263);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.KeyPreview = true;
            this.Name = "frmTeklifGorusmeler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teklif Görüşmeler";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTeklifGorusmeler_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTeklifId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        public DevExpress.XtraEditors.TextEdit txtTeklifId;
        public DevExpress.XtraEditors.MemoEdit txtAciklama;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_Kaydet;
        private DevExpress.XtraEditors.SimpleButton btn_Vazgec;
    }
}