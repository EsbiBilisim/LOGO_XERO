
namespace LOGO_XERO.Moduller.Giris_AnaForm_Ayarlar
{
    partial class frmDemoLisansAlma
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
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txt_VergiKimlikNo = new DevExpress.XtraEditors.TextEdit();
            this.txt_DemoLisansi = new DevExpress.XtraEditors.MemoEdit();
            this.txt_CariUnvani = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.ck_LisansModülü = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_VergiKimlikNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DemoLisansi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CariUnvani.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ck_LisansModülü.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 22);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(145, 16);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Vergi Kimlik Numarası :";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 122);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(103, 16);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Lisans Numarası";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(392, 232);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(86, 34);
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "Oluştur";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(12, 48);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(146, 16);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Firma Ünvanı               :";
            // 
            // txt_VergiKimlikNo
            // 
            this.txt_VergiKimlikNo.Location = new System.Drawing.Point(163, 21);
            this.txt_VergiKimlikNo.Name = "txt_VergiKimlikNo";
            this.txt_VergiKimlikNo.Size = new System.Drawing.Size(315, 20);
            this.txt_VergiKimlikNo.TabIndex = 0;
            // 
            // txt_DemoLisansi
            // 
            this.txt_DemoLisansi.Enabled = false;
            this.txt_DemoLisansi.Location = new System.Drawing.Point(163, 122);
            this.txt_DemoLisansi.Name = "txt_DemoLisansi";
            this.txt_DemoLisansi.Size = new System.Drawing.Size(315, 104);
            this.txt_DemoLisansi.TabIndex = 7;
            // 
            // txt_CariUnvani
            // 
            this.txt_CariUnvani.EditValue = "";
            this.txt_CariUnvani.Location = new System.Drawing.Point(163, 47);
            this.txt_CariUnvani.Name = "txt_CariUnvani";
            this.txt_CariUnvani.Properties.DisplayFormat.FormatString = "\\\\p{Lu}+";
            this.txt_CariUnvani.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txt_CariUnvani.Size = new System.Drawing.Size(315, 44);
            this.txt_CariUnvani.TabIndex = 8;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(12, 97);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(143, 16);
            this.labelControl4.TabIndex = 10;
            this.labelControl4.Text = "Lisans Modülü            :";
            // 
            // ck_LisansModülü
            // 
            this.ck_LisansModülü.Location = new System.Drawing.Point(163, 96);
            this.ck_LisansModülü.Name = "ck_LisansModülü";
            this.ck_LisansModülü.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ck_LisansModülü.Properties.Items.AddRange(new object[] {
            "",
            "Tam Paket",
            "Teklif Modülü",
            "GOOZ Modülü",
            "Demo Lisansı (6 Aylık)"});
            this.ck_LisansModülü.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.ck_LisansModülü.Size = new System.Drawing.Size(315, 20);
            this.ck_LisansModülü.TabIndex = 11;
            // 
            // frmDemoLisansAlma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 278);
            this.Controls.Add(this.ck_LisansModülü);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txt_CariUnvani);
            this.Controls.Add(this.txt_DemoLisansi);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txt_VergiKimlikNo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDemoLisansAlma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lisans İşlemi";
            this.Load += new System.EventHandler(this.frmDemoLisansAlma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_VergiKimlikNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DemoLisansi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CariUnvani.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ck_LisansModülü.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txt_VergiKimlikNo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.MemoEdit txt_DemoLisansi;
        private DevExpress.XtraEditors.MemoEdit txt_CariUnvani;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.ComboBoxEdit ck_LisansModülü;
    }
}