using DevExpress.CodeParser;
using DevExpress.DashboardWin.Design;
using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using LOGO_XERO.Models;
using LOGO_XERO.Models.LOGO_M;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGO_XERO.Moduller.GenelListeler
{
    public partial class frmMarkalar : DevExpress.XtraEditors.XtraForm
    {
        public int Kayitid = 0;
        frmAnaForm ana;
        frmStokKart _frmStokKart;
        Islemler islem = new Islemler();
        public frmMarkalar(frmStokKart frmStokKart)
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            _frmStokKart = frmStokKart;
        }
        private void Liste()
        {
            grid_marka.DataSource = islem.MarkListesiGetir();
        }
        private void frmMarkalar_Load(object sender, EventArgs e)
        {
            Liste();
        }

        private void grid_marka_DoubleClick(object sender, EventArgs e)
        {
            LG_MARK row = (LG_MARK)gv_marka.GetFocusedRow();
            if (row != null)
            {
                if (_frmStokKart != null)
                {
                    _frmStokKart.txtMarkRef.Text = row.LOGICALREF.ToString();
                    _frmStokKart.txtMarka.Text = row.CODE;
                    _frmStokKart.txt_markaAciklama.Text = row.DESCR;
                }

                this.Close();
            }
        }
        private void frmMarkalar_KeyDown(object sender, KeyEventArgs e)
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
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_kod.Text))
            {
                XtraMessageBox.Show("Marka Kodu Yazılmadan Kayıt Ekleyemezsiniz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_kod.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txt_markaaciklama.Text))
            {
                XtraMessageBox.Show("Marka Tanımı Yazılmadan Kayıt Ekleyemezsiniz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_markaaciklama.Focus();
                return;
            }

            List<LG_MARK> markalar = grid_marka.DataSource as List<LG_MARK>;
            if (Kayitid == 0)
            {
                var listedeVarmi = markalar.Where(s => s.CODE.ToLower() == txt_kod.Text.ToLower()).FirstOrDefault();
                if (listedeVarmi != null)
                {
                    XtraMessageBox.Show("Aynı Kodlu Kayıt Var ! Ekleyemezsiniz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_markaaciklama.Focus();
                    return;
                }
            }
            else
            {
                var listedeVarmi = markalar.Where(s => s.CODE.ToLower() == txt_kod.Text.ToLower() && s.LOGICALREF!=Kayitid).FirstOrDefault();
                if (listedeVarmi != null)
                {
                    XtraMessageBox.Show("Aynı Kodlu Kayıt Var ! Ekleyemezsiniz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_markaaciklama.Focus();
                    return;
                }
            }
           
            try
            {
                using (LogoContext db = new LogoContext())
                {

                    if (Kayitid == 0)
                    {
                        LG_MARK yen = new LG_MARK();
                        yen.CAPIBLOCK_CREADEDDATE = DateTime.Now;
                        yen.CAPIBLOCK_CREATEDHOUR = Convert.ToInt16(DateTime.Now.Hour);
                        yen.CAPIBLOCK_CREATEDMIN = Convert.ToInt16(DateTime.Now.Minute);
                        yen.CAPIBLOCK_CREATEDSEC = Convert.ToInt16(DateTime.Now.Second);

                        yen.SPECODE = btn_ozelkod.Text;
                        yen.CYPHCODE = btn_yetkikodu.Text;
                        yen.DESCR = txt_markaaciklama.Text;
                        yen.CODE = txt_kod.Text;    
                        yen.ORGLOGICREF = 0;
                        yen.RECSTATUS = 1;
                        yen.SITEID = 0;
                        db.LG_MARK.Add(yen);
                    }
                    else
                    {
                        LG_MARK yen = db.LG_MARK.Where(s => s.LOGICALREF == Kayitid).FirstOrDefault();
                        if (yen != null)
                        {
                            yen.CAPIBLOCK_MODIFIEDDATE = DateTime.Now;
                            yen.CAPIBLOCK_MODIFIEDHOUR = Convert.ToInt16(DateTime.Now.Hour);
                            yen.CAPIBLOCK_MODIFIEDMIN = Convert.ToInt16(DateTime.Now.Minute);
                            yen.CAPIBLOCK_MODIFIEDSEC = Convert.ToInt16(DateTime.Now.Second);


                            yen.SPECODE = btn_ozelkod.Text;
                            yen.CYPHCODE = btn_yetkikodu.Text;
                            yen.DESCR = txt_markaaciklama.Text;
                            yen.CODE = txt_kod.Text;
                            yen.ORGLOGICREF = 0;
                            yen.RECSTATUS = 1;
                            yen.SITEID = 0;
                            db.Entry(yen).State = System.Data.Entity.EntityState.Modified;
                        }
                    }
                    db.SaveChanges();
                    XtraMessageBox.Show("Kayıt İşlemi Başarılı !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_kod.Text = "";
                    txt_markaaciklama.Text = "";
                    btn_ozelkod.Text = "";
                    btn_yetkikodu.Text = "";
                    Kayitid = 0;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Kayıt Başarız ! Hata : " + ex.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Liste();
        }

        private void btn_ozelkod_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.OzelKodListesiAc(this, 1, 1, 132, 0);
        }

        private void btn_yetkikodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            islem.OzelKodListesiAc(this, 2, 2, 132, 0);
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LG_MARK row = (LG_MARK)gv_marka.GetFocusedRow();
            if (row != null)
            {
                int logicalref = Convert.ToInt32(row.LOGICALREF);
                Kayitid = logicalref;
                txt_kod.Text = row.CODE;
                txt_markaaciklama.Text = row.DESCR;
                btn_ozelkod.Text = row.SPECODE;
                btn_yetkikodu.Text = row.CYPHCODE;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}