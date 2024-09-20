
namespace LOGO_XERO.Moduller.Giris_AnaForm_Ayarlar
{
    partial class frmKullaniciMailAyari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKullaniciMailAyari));
            this.ck_sifreGoster = new DevExpress.XtraEditors.CheckEdit();
            this.btn_Guncelle = new DevExpress.XtraEditors.SimpleButton();
            this.txt_Sifre = new DevExpress.XtraEditors.TextEdit();
            this.txt_Mail = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ck_sifreGoster.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Sifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Mail.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ck_sifreGoster
            // 
            this.ck_sifreGoster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ck_sifreGoster.Location = new System.Drawing.Point(39, 105);
            this.ck_sifreGoster.Name = "ck_sifreGoster";
            this.ck_sifreGoster.Properties.Caption = "Şifre Göster";
            this.ck_sifreGoster.Size = new System.Drawing.Size(102, 19);
            this.ck_sifreGoster.TabIndex = 16;
            this.ck_sifreGoster.CheckedChanged += new System.EventHandler(this.ck_sifreGoster_CheckedChanged);
            // 
            // btn_Guncelle
            // 
            this.btn_Guncelle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Guncelle.ImageOptions.Image")));
            this.btn_Guncelle.Location = new System.Drawing.Point(292, 101);
            this.btn_Guncelle.Name = "btn_Guncelle";
            this.btn_Guncelle.Size = new System.Drawing.Size(75, 23);
            this.btn_Guncelle.TabIndex = 15;
            this.btn_Guncelle.Text = "Güncelle";
            this.btn_Guncelle.Click += new System.EventHandler(this.btn_Guncelle_Click);
            // 
            // txt_Sifre
            // 
            this.txt_Sifre.Location = new System.Drawing.Point(134, 66);
            this.txt_Sifre.Name = "txt_Sifre";
            this.txt_Sifre.Properties.PasswordChar = '*';
            this.txt_Sifre.Size = new System.Drawing.Size(233, 20);
            this.txt_Sifre.TabIndex = 13;
            // 
            // txt_Mail
            // 
            this.txt_Mail.Location = new System.Drawing.Point(134, 30);
            this.txt_Mail.Name = "txt_Mail";
            this.txt_Mail.Size = new System.Drawing.Size(233, 20);
            this.txt_Mail.TabIndex = 12;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(39, 69);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(22, 13);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Şifre";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(39, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(51, 13);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Mail Adresi";
            // 
            // frmKullaniciMailAyari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 143);
            this.Controls.Add(this.ck_sifreGoster);
            this.Controls.Add(this.btn_Guncelle);
            this.Controls.Add(this.txt_Sifre);
            this.Controls.Add(this.txt_Mail);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(419, 181);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(419, 181);
            this.Name = "frmKullaniciMailAyari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mail Bilgileri";
            this.Load += new System.EventHandler(this.frmKullaniciMailAyari_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ck_sifreGoster.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Sifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Mail.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit ck_sifreGoster;
        private DevExpress.XtraEditors.SimpleButton btn_Guncelle;
        private DevExpress.XtraEditors.TextEdit txt_Sifre;
        private DevExpress.XtraEditors.TextEdit txt_Mail;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}