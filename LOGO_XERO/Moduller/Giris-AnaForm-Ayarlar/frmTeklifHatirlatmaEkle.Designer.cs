namespace LOGO_XERO.Moduller.Giris_AnaForm_Ayarlar
{
    partial class frmTeklifHatirlatmaEkle
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.dttarih = new DevExpress.XtraEditors.DateEdit();
            this.txtTeklifBaslik = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dttarih.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dttarih.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTeklifBaslik.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Teklif Başlık :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(256, 27);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(85, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Hatırlatma Tarihi :";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 64);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(85, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Hatırlatma Notu : ";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(460, 320);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 8;
            this.simpleButton1.Text = "[F2] Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // memoEdit1
            // 
            this.memoEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memoEdit1.Location = new System.Drawing.Point(12, 83);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(523, 231);
            this.memoEdit1.TabIndex = 7;
            // 
            // dttarih
            // 
            this.dttarih.EditValue = null;
            this.dttarih.Location = new System.Drawing.Point(347, 23);
            this.dttarih.Name = "dttarih";
            this.dttarih.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dttarih.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dttarih.Size = new System.Drawing.Size(124, 20);
            this.dttarih.TabIndex = 5;
            // 
            // txtTeklifBaslik
            // 
            this.txtTeklifBaslik.Enabled = false;
            this.txtTeklifBaslik.Location = new System.Drawing.Point(79, 23);
            this.txtTeklifBaslik.Name = "txtTeklifBaslik";
            this.txtTeklifBaslik.Size = new System.Drawing.Size(124, 20);
            this.txtTeklifBaslik.TabIndex = 0;
            // 
            // frmTeklifHatirlatmaEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 355);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.memoEdit1);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.dttarih);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtTeklifBaslik);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frmTeklifHatirlatmaEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hatırlatma Ekle";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTeklifHatirlatmaEkle_FormClosed);
            this.Load += new System.EventHandler(this.frmTeklifHatirlatmaEkle_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTeklifHatirlatmaEkle_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dttarih.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dttarih.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTeklifBaslik.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dttarih;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        public DevExpress.XtraEditors.TextEdit txtTeklifBaslik;
    }
}