using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using LOGO_XERO.Models.LOGO_M;
using LOGO_XERO.Moduller.Finans;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGO_XERO.Moduller.GenelListeler
{
    public partial class frmOzelKodlar : DevExpress.XtraEditors.XtraForm
    {

        public int specodetype = 0;
        public int SPETYPE = 0;
        public int codetype = 0;
        public int Kayitid = 0;
        frmAnaForm ana;
        Islemler islem = new Islemler();
        frmTeklifOlustur _frmTeklifOlustur;
        frmSevkiyatAdresiEkleme _frmSevkiyatAdresiEkleme;
        frmMarkalar _frmMarkalar;
        frmStokKart _frmStokKart;
        frmCariKartEkle _frmCariKartEkle;
        frmMuhasebeKoduEkleme _frmMuhasebeKoduEkleme;
        public int tip = 0;//1 ise özelkod 2 ise yetkikodu
        public frmOzelKodlar(frmMarkalar frmMarkalar)
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            _frmMarkalar = frmMarkalar;

        }
        public frmOzelKodlar(frmTeklifOlustur frmTeklifOlustur)
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            _frmTeklifOlustur = frmTeklifOlustur;

        }
        public frmOzelKodlar(frmSevkiyatAdresiEkleme frmSevkiyatAdresiEkleme)
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            _frmSevkiyatAdresiEkleme = frmSevkiyatAdresiEkleme;

        }
        public frmOzelKodlar(frmStokKart frmStokKart)
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            _frmStokKart = frmStokKart;
        }
        public frmOzelKodlar(frmCariKartEkle frmCariKartEkle)
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            _frmCariKartEkle = frmCariKartEkle;
        } 
        public frmOzelKodlar(frmMuhasebeKoduEkleme frmMuhasebeKoduEkleme)
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            _frmMuhasebeKoduEkleme = frmMuhasebeKoduEkleme;
        }
        private void frmOzelKodlar_Load(object sender, EventArgs e)
        {
            if (tip == 1)
            {
                groupControl1.Text = "Özel Kod Ekleme";
                this.Text = "Özel Kodlar";
            }
            if (tip == 2)
            {
                groupControl1.Text = "Yetki Kodu Ekleme";
                this.Text = "Yetki Kodları";
            }
            if (tip == 4)
            {
                groupControl1.Text = "Grup Kodu Ekleme";
                this.Text = "Grup Kodları";
            }
            Liste();
        }
        void Liste()
        {
            grid_OzelKodlar.DataSource = islem.OzelKodlarGetir(ana.lk_firma.EditValue.ToString(), codetype, specodetype,SPETYPE);
        }

        private void grid_OzelKodlar_DoubleClick(object sender, EventArgs e)
        {
            LG_SPECODES ozelkod = (LG_SPECODES)gv_OzelKodlar.GetFocusedRow();
            if (ozelkod != null)
            {
                if (_frmMarkalar != null)
                {
                    if (tip == 1)
                    {
                        _frmMarkalar.btn_ozelkod.Text = ozelkod.SPECODE;
                    }
                    if (tip == 2)
                    {
                        _frmMarkalar.btn_yetkikodu.Text = ozelkod.SPECODE;
                    }

                    Close();
                }
                if (_frmTeklifOlustur != null)
                {
                    if (tip == 1)
                    {
                        _frmTeklifOlustur.btn_OzelKod.Text = ozelkod.SPECODE;
                    }
                    if (tip == 2)
                    {
                        _frmTeklifOlustur.btn_YetkiKodu.Text = ozelkod.SPECODE;
                    }

                    Close();
                }
                if (_frmSevkiyatAdresiEkleme != null)
                {
                    if (tip == 1)
                    {
                        _frmSevkiyatAdresiEkleme.btn_ozelkod.Text = ozelkod.SPECODE;
                    }
                    if (tip == 2)
                    {
                        _frmSevkiyatAdresiEkleme.btn_yetkikodu.Text = ozelkod.SPECODE;
                    }

                    Close();
                }
                if (_frmStokKart != null)
                {
                    if (tip == 1)
                    {
                        if (SPETYPE == 1)
                        {
                            _frmStokKart.txtOzelKod1.Text = ozelkod.SPECODE;
                        }
                        if (SPETYPE == 2)
                        {
                            _frmStokKart.txtOzelKod2.Text = ozelkod.SPECODE;
                        }
                        if (SPETYPE == 3)
                        {
                            _frmStokKart.txtOzelKod3.Text = ozelkod.SPECODE;
                        }
                        if (SPETYPE == 4)
                        {
                            _frmStokKart.txtOzelKod4.Text = ozelkod.SPECODE;
                        }
                        if (SPETYPE == 5)
                        {
                            _frmStokKart.txtOzelKod5.Text = ozelkod.SPECODE;
                        }

                    }
                    if (tip == 2)
                    {
                        _frmStokKart.btn_yetkikodu.Text = ozelkod.SPECODE;
                    }
                    if (tip == 4)
                    {
                        _frmStokKart.txtGrupKodu.Text = ozelkod.SPECODE;
                    }
                    Close();
                }
                if (_frmCariKartEkle != null)
                {
                    if (tip == 1)
                    {
                        if (SPETYPE == 1)
                        {
                            _frmCariKartEkle.btn_OzelKod1.Text = ozelkod.SPECODE;
                        }
                        if (SPETYPE == 2)
                        {
                            _frmCariKartEkle.btn_OzelKod2.Text = ozelkod.SPECODE;
                        }
                        if (SPETYPE == 3)
                        {
                            _frmCariKartEkle.btn_OzelKod3.Text = ozelkod.SPECODE;
                        }
                        if (SPETYPE == 4)
                        {
                            _frmCariKartEkle.btn_OzelKod4.Text = ozelkod.SPECODE;
                        }
                        if (SPETYPE == 5)
                        {
                            _frmCariKartEkle.btn_OzelKod5.Text = ozelkod.SPECODE;
                        }

                    }
                    if (tip == 2)
                    {
                        _frmCariKartEkle.btn_yetkiKodu.Text = ozelkod.SPECODE;
                    }
                    Close();
                }
                if (_frmMuhasebeKoduEkleme != null)
                {
                    if (tip == 1)
                    {
                        if (SPETYPE == 1)
                        {
                            _frmMuhasebeKoduEkleme.btn_Ozelkod.Text = ozelkod.SPECODE;
                        }
                        if (SPETYPE == 2)
                        {
                            _frmMuhasebeKoduEkleme.btn_Ozelkod2.Text = ozelkod.SPECODE;
                        }
                        if (SPETYPE == 3)
                        {
                            _frmMuhasebeKoduEkleme.btn_Ozelkod3.Text = ozelkod.SPECODE;
                        }
                        if (SPETYPE == 4)
                        {
                            _frmMuhasebeKoduEkleme.btn_Ozelkod4.Text = ozelkod.SPECODE;
                        }
                        if (SPETYPE == 5)
                        {
                            _frmMuhasebeKoduEkleme.btn_Ozelkod5.Text = ozelkod.SPECODE;
                        }

                    }
                    if (tip == 2)
                    {
                        _frmMuhasebeKoduEkleme.btn_yetkiKodu.Text = ozelkod.SPECODE;
                    }
                    Close();
                }
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_OzelKod.Text))
            {
                XtraMessageBox.Show("Özel Kod Yazılmadan Kayıt Ekleyemezsiniz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_OzelKod.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txt_ozelkodTanimi.Text))
            {
                XtraMessageBox.Show("Özel Kod Tanımı Yazılmadan Kayıt Ekleyemezsiniz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_ozelkodTanimi.Focus();
                return;
            }

            List<LG_SPECODES> ozelkodListesi = grid_OzelKodlar.DataSource as List<LG_SPECODES>;
            var listedeVarmi = ozelkodListesi.Where(s => s.SPECODE == txt_OzelKod.Text).FirstOrDefault();
            if (listedeVarmi != null)
            {
                XtraMessageBox.Show("Aynı Kodlu Kayıt Var ! Ekleyemezsiniz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_ozelkodTanimi.Focus();
                return;
            }
            try
            {
                using (LogoContext db = new LogoContext())
                {

                    if (Kayitid == 0)
                    {
                        LG_SPECODES yen = new LG_SPECODES();
                        yen.SPECODETYPE = Convert.ToInt16(specodetype);
                        yen.SPECODE = txt_OzelKod.Text;
                        yen.DEFINITION_ = txt_ozelkodTanimi.Text;
                        if (SPETYPE > 0)
                        {
                            if (SPETYPE == 1)
                            {
                                yen.SPETYP1 = 1;
                                yen.SPETYP2 = 0;
                                yen.SPETYP3 = 0;
                                yen.SPETYP4 = 0;
                                yen.SPETYP5 = 0;
                            }
                            if (SPETYPE == 2)
                            {
                                yen.SPETYP1 = 0;
                                yen.SPETYP2 = 1;
                                yen.SPETYP3 = 0;
                                yen.SPETYP4 = 0;
                                yen.SPETYP5 = 0;
                            }
                            if (SPETYPE == 3)
                            {
                                yen.SPETYP1 = 0;
                                yen.SPETYP2 = 0;
                                yen.SPETYP3 = 1;
                                yen.SPETYP4 = 0;
                                yen.SPETYP5 = 0;
                            }
                            if (SPETYPE == 4)
                            {
                                yen.SPETYP1 = 0;
                                yen.SPETYP2 = 0;
                                yen.SPETYP3 = 0;
                                yen.SPETYP4 = 1;
                                yen.SPETYP5 = 0;
                            }
                            if (SPETYPE == 5)
                            {
                                yen.SPETYP1 = 0;
                                yen.SPETYP2 = 0;
                                yen.SPETYP3 = 0;
                                yen.SPETYP4 = 0;
                                yen.SPETYP5 = 1;
                            }
                        }
                        else
                        {
                            yen.SPETYP1 = 0;
                            yen.SPETYP2 = 0;
                            yen.SPETYP3 = 0;
                            yen.SPETYP4 = 0;
                            yen.SPETYP5 = 0;
                        }
                        yen.DEFINITION2 = "";
                        yen.DEFINITION3 = "";
                        yen.GLOBALID = "";
                        yen.ORGLOGICREF = 0;
                        yen.RECSTATUS = 1;
                        yen.SITEID = 0;
                        yen.CODETYPE = Convert.ToInt16(codetype);
                        db.LG_SPECODES.Add(yen);
                    }
                    else
                    {
                        LG_SPECODES yen = db.LG_SPECODES.Where(s => s.LOGICALREF == Kayitid).FirstOrDefault();
                        if (yen != null)
                        {
                            yen.SPECODETYPE = Convert.ToInt16(specodetype);
                            yen.SPECODE = txt_OzelKod.Text;
                            yen.DEFINITION_ = txt_ozelkodTanimi.Text;
                            if (SPETYPE > 0)
                            {
                                if (SPETYPE == 1)
                                {
                                    yen.SPETYP1 = 1;
                                    yen.SPETYP2 = 0;
                                    yen.SPETYP3 = 0;
                                    yen.SPETYP4 = 0;
                                    yen.SPETYP5 = 0;
                                }
                                if (SPETYPE == 2)
                                {
                                    yen.SPETYP1 = 0;
                                    yen.SPETYP2 = 1;
                                    yen.SPETYP3 = 0;
                                    yen.SPETYP4 = 0;
                                    yen.SPETYP5 = 0;
                                }
                                if (SPETYPE == 3)
                                {
                                    yen.SPETYP1 = 0;
                                    yen.SPETYP2 = 0;
                                    yen.SPETYP3 = 1;
                                    yen.SPETYP4 = 0;
                                    yen.SPETYP5 = 0;
                                }
                                if (SPETYPE == 4)
                                {
                                    yen.SPETYP1 = 0;
                                    yen.SPETYP2 = 0;
                                    yen.SPETYP3 = 0;
                                    yen.SPETYP4 = 1;
                                    yen.SPETYP5 = 0;
                                }
                                if (SPETYPE == 5)
                                {
                                    yen.SPETYP1 = 0;
                                    yen.SPETYP2 = 0;
                                    yen.SPETYP3 = 0;
                                    yen.SPETYP4 = 0;
                                    yen.SPETYP5 = 1;
                                }
                            }
                            else
                            {
                                yen.SPETYP1 = 0;
                                yen.SPETYP2 = 0;
                                yen.SPETYP3 = 0;
                                yen.SPETYP4 = 0;
                                yen.SPETYP5 = 0;
                            }
                            yen.CODETYPE = Convert.ToInt16(codetype);
                            yen.DEFINITION2 = "";
                            yen.DEFINITION3 = "";
                            yen.GLOBALID = "";
                            yen.ORGLOGICREF = 0;
                            yen.RECSTATUS = 1;
                            yen.SITEID = 0;
                            db.Entry(yen).State = System.Data.Entity.EntityState.Modified;
                        }
                    }
                    db.SaveChanges();
                    XtraMessageBox.Show("Kayıt İşlemi Başarılı !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_OzelKod.Text = "";
                    txt_ozelkodTanimi.Text = "";
                    Kayitid = 0;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Kayıt Başarız ! Hata : " + ex.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Liste();
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LG_SPECODES row = (LG_SPECODES)gv_OzelKodlar.GetFocusedRow();
            if (row != null)
            {
                int logicalref = Convert.ToInt32(row.LOGICALREF);
                Kayitid = logicalref;
                txt_ozelkodTanimi.Text = row.DEFINITION_;
                txt_OzelKod.Text = row.SPECODE;
            }
        }
        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LG_SPECODES row = (LG_SPECODES)gv_OzelKodlar.GetFocusedRow();
            if (row != null)
            {
                int logicalref = Convert.ToInt32(row.LOGICALREF);
                using (LogoContext db = new LogoContext())
                {
                    LG_SPECODES OZELKOD = db.LG_SPECODES.Where(s => s.LOGICALREF == logicalref).FirstOrDefault();
                    if (OZELKOD != null)
                    {
                        DialogResult dr = XtraMessageBox.Show("Seçili Özel Kod Silinecektir ! Emin Misiniz ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {
                            try
                            {
                                db.LG_SPECODES.Remove(OZELKOD);
                                db.SaveChanges();
                                XtraMessageBox.Show("Kayıt Silme Başarılı !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Liste();
                            }
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show("Kayıt Silme Başarısız ! Hata : " + ex.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
        }

        private void frmOzelKodlar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.F2)
            {
                simpleButton4_Click(sender, e);
            }          
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}