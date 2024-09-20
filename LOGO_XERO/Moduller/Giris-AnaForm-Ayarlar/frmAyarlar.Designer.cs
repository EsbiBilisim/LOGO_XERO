
namespace LOGO_XERO
{
    partial class frmAyarlar
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
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txsfre = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txservername = new DevExpress.XtraEditors.TextEdit();
            this.txkullnciad = new DevExpress.XtraEditors.TextEdit();
            this.btn_kaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btn_lisansGirisi = new DevExpress.XtraEditors.SimpleButton();
            this.btn_baglantiKontrol = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_veritabaniAdi = new DevExpress.XtraEditors.LabelControl();
            this.lk_databaseListesi = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txsfre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txservername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txkullnciad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_databaseListesi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(60)))), ((int)(((byte)(91)))));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(23, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(130, 16);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "SERVER ADI                    :";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(60)))), ((int)(((byte)(91)))));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(22, 47);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(131, 16);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "SQL  KULLANICI ADI     :";
            // 
            // txsfre
            // 
            this.txsfre.Location = new System.Drawing.Point(179, 73);
            this.txsfre.Name = "txsfre";
            this.txsfre.Properties.PasswordChar = '*';
            this.txsfre.Size = new System.Drawing.Size(204, 20);
            this.txsfre.TabIndex = 15;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(60)))), ((int)(((byte)(91)))));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(22, 75);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(131, 16);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "SQL ŞİFRE                        :";
            // 
            // txservername
            // 
            this.txservername.Location = new System.Drawing.Point(179, 17);
            this.txservername.Name = "txservername";
            this.txservername.Size = new System.Drawing.Size(204, 20);
            this.txservername.TabIndex = 12;
            // 
            // txkullnciad
            // 
            this.txkullnciad.Location = new System.Drawing.Point(179, 45);
            this.txkullnciad.Name = "txkullnciad";
            this.txkullnciad.Size = new System.Drawing.Size(204, 20);
            this.txkullnciad.TabIndex = 14;
            // 
            // btn_kaydet
            // 
            this.btn_kaydet.Appearance.BackColor = System.Drawing.Color.Teal;
            this.btn_kaydet.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_kaydet.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_kaydet.Appearance.Options.UseBackColor = true;
            this.btn_kaydet.Appearance.Options.UseFont = true;
            this.btn_kaydet.Location = new System.Drawing.Point(307, 174);
            this.btn_kaydet.Name = "btn_kaydet";
            this.btn_kaydet.Size = new System.Drawing.Size(76, 31);
            this.btn_kaydet.TabIndex = 16;
            this.btn_kaydet.Text = "KAYDET";
            this.btn_kaydet.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btn_lisansGirisi
            // 
            this.btn_lisansGirisi.Appearance.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_lisansGirisi.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_lisansGirisi.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_lisansGirisi.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_lisansGirisi.Appearance.Options.UseBackColor = true;
            this.btn_lisansGirisi.Appearance.Options.UseBorderColor = true;
            this.btn_lisansGirisi.Appearance.Options.UseFont = true;
            this.btn_lisansGirisi.Location = new System.Drawing.Point(22, 174);
            this.btn_lisansGirisi.Name = "btn_lisansGirisi";
            this.btn_lisansGirisi.Size = new System.Drawing.Size(117, 31);
            this.btn_lisansGirisi.TabIndex = 17;
            this.btn_lisansGirisi.Text = "LİSANS GİRİŞİ";
            this.btn_lisansGirisi.Visible = false;
            this.btn_lisansGirisi.Click += new System.EventHandler(this.btn_lisansGirisi_Click);
            // 
            // btn_baglantiKontrol
            // 
            this.btn_baglantiKontrol.Appearance.BackColor = System.Drawing.Color.LightYellow;
            this.btn_baglantiKontrol.Appearance.Options.UseBackColor = true;
            this.btn_baglantiKontrol.Location = new System.Drawing.Point(261, 133);
            this.btn_baglantiKontrol.Name = "btn_baglantiKontrol";
            this.btn_baglantiKontrol.Size = new System.Drawing.Size(122, 31);
            this.btn_baglantiKontrol.TabIndex = 18;
            this.btn_baglantiKontrol.Text = "BAĞLANTI KONTROL";
            this.btn_baglantiKontrol.Click += new System.EventHandler(this.btn_baglantiKontrol_Click);
            // 
            // lbl_veritabaniAdi
            // 
            this.lbl_veritabaniAdi.Appearance.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_veritabaniAdi.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(60)))), ((int)(((byte)(91)))));
            this.lbl_veritabaniAdi.Appearance.Options.UseFont = true;
            this.lbl_veritabaniAdi.Appearance.Options.UseForeColor = true;
            this.lbl_veritabaniAdi.Location = new System.Drawing.Point(23, 103);
            this.lbl_veritabaniAdi.Name = "lbl_veritabaniAdi";
            this.lbl_veritabaniAdi.Size = new System.Drawing.Size(131, 16);
            this.lbl_veritabaniAdi.TabIndex = 19;
            this.lbl_veritabaniAdi.Text = "SQL VERİTABANI ADI   :";
            this.lbl_veritabaniAdi.Visible = false;
            // 
            // lk_databaseListesi
            // 
            this.lk_databaseListesi.Location = new System.Drawing.Point(179, 102);
            this.lk_databaseListesi.Name = "lk_databaseListesi";
            this.lk_databaseListesi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_databaseListesi.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "Database")});
            this.lk_databaseListesi.Properties.NullText = "Veritabanı Seçiniz";
            this.lk_databaseListesi.Size = new System.Drawing.Size(204, 20);
            this.lk_databaseListesi.TabIndex = 22;
            this.lk_databaseListesi.Visible = false;
            // 
            // frmAyarlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 217);
            this.Controls.Add(this.lk_databaseListesi);
            this.Controls.Add(this.lbl_veritabaniAdi);
            this.Controls.Add(this.btn_baglantiKontrol);
            this.Controls.Add(this.btn_lisansGirisi);
            this.Controls.Add(this.btn_kaydet);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txsfre);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txservername);
            this.Controls.Add(this.txkullnciad);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAyarlar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BAĞLANTI AYARLARI";
            this.Load += new System.EventHandler(this.frmAyarlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txsfre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txservername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txkullnciad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_databaseListesi.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txsfre;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.TextEdit txservername;
        private DevExpress.XtraEditors.TextEdit txkullnciad;
        private DevExpress.XtraEditors.SimpleButton btn_kaydet;
        private DevExpress.XtraEditors.SimpleButton btn_lisansGirisi;
        private DevExpress.XtraEditors.SimpleButton btn_baglantiKontrol;
        private DevExpress.XtraEditors.LabelControl lbl_veritabaniAdi;
        private DevExpress.XtraEditors.LookUpEdit lk_databaseListesi;
    }
}