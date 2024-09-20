
namespace LOGO_XERO.Moduller.Giris_AnaForm_Ayarlar
{
    partial class frmKullaniciSifreDegistirme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKullaniciSifreDegistirme));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txt_EskiSifre = new DevExpress.XtraEditors.TextEdit();
            this.txt_YeniSifre = new DevExpress.XtraEditors.TextEdit();
            this.txt_YeniSifreTekrar = new DevExpress.XtraEditors.TextEdit();
            this.btn_Guncelle = new DevExpress.XtraEditors.SimpleButton();
            this.ck_sifreGoster = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_EskiSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_YeniSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_YeniSifreTekrar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ck_sifreGoster.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(32, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(43, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Eski Şifre";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(32, 74);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(45, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Yeni Şifre";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(32, 110);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(79, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Yeni Şifre Tekrar";
            // 
            // txt_EskiSifre
            // 
            this.txt_EskiSifre.Location = new System.Drawing.Point(127, 35);
            this.txt_EskiSifre.Name = "txt_EskiSifre";
            this.txt_EskiSifre.Properties.PasswordChar = '*';
            this.txt_EskiSifre.Size = new System.Drawing.Size(233, 20);
            this.txt_EskiSifre.TabIndex = 3;
            // 
            // txt_YeniSifre
            // 
            this.txt_YeniSifre.Location = new System.Drawing.Point(127, 71);
            this.txt_YeniSifre.Name = "txt_YeniSifre";
            this.txt_YeniSifre.Properties.PasswordChar = '*';
            this.txt_YeniSifre.Size = new System.Drawing.Size(233, 20);
            this.txt_YeniSifre.TabIndex = 4;
            // 
            // txt_YeniSifreTekrar
            // 
            this.txt_YeniSifreTekrar.Location = new System.Drawing.Point(127, 107);
            this.txt_YeniSifreTekrar.Name = "txt_YeniSifreTekrar";
            this.txt_YeniSifreTekrar.Properties.PasswordChar = '*';
            this.txt_YeniSifreTekrar.Size = new System.Drawing.Size(233, 20);
            this.txt_YeniSifreTekrar.TabIndex = 5;
            // 
            // btn_Guncelle
            // 
            this.btn_Guncelle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Guncelle.ImageOptions.Image")));
            this.btn_Guncelle.Location = new System.Drawing.Point(285, 148);
            this.btn_Guncelle.Name = "btn_Guncelle";
            this.btn_Guncelle.Size = new System.Drawing.Size(75, 23);
            this.btn_Guncelle.TabIndex = 6;
            this.btn_Guncelle.Text = "Güncelle";
            this.btn_Guncelle.Click += new System.EventHandler(this.btn_Guncelle_Click);
            // 
            // ck_sifreGoster
            // 
            this.ck_sifreGoster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ck_sifreGoster.Location = new System.Drawing.Point(32, 150);
            this.ck_sifreGoster.Name = "ck_sifreGoster";
            this.ck_sifreGoster.Properties.Caption = "Şifreleri Göster";
            this.ck_sifreGoster.Size = new System.Drawing.Size(102, 19);
            this.ck_sifreGoster.TabIndex = 8;
            this.ck_sifreGoster.CheckedChanged += new System.EventHandler(this.ck_sifreGoster_CheckedChanged);
            // 
            // frmKullaniciSifreDegistirme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 196);
            this.Controls.Add(this.ck_sifreGoster);
            this.Controls.Add(this.btn_Guncelle);
            this.Controls.Add(this.txt_YeniSifreTekrar);
            this.Controls.Add(this.txt_YeniSifre);
            this.Controls.Add(this.txt_EskiSifre);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(422, 234);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(422, 234);
            this.Name = "frmKullaniciSifreDegistirme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Şifre Değiştirme";
            this.Load += new System.EventHandler(this.frmKullaniciSifreDegistirme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_EskiSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_YeniSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_YeniSifreTekrar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ck_sifreGoster.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txt_EskiSifre;
        private DevExpress.XtraEditors.TextEdit txt_YeniSifre;
        private DevExpress.XtraEditors.TextEdit txt_YeniSifreTekrar;
        private DevExpress.XtraEditors.SimpleButton btn_Guncelle;
        private DevExpress.XtraEditors.CheckEdit ck_sifreGoster;
    }
}