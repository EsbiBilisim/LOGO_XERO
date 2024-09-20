using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
using LOGO_XERO.Models.GenelKullanim;
using LOGO_XERO.Models.LOGO_M;
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
    public partial class frmBoyutIciBirimler : DevExpress.XtraEditors.XtraForm
    {
        public int _tip = 0;
        Islemler islem = new Islemler();
        frmAnaForm ana;
        frmStokKart _frmStokKart;
        ButtonEdit _buton;
        public frmBoyutIciBirimler(frmStokKart frmStokKart, int tip, ButtonEdit buton)
        {
            InitializeComponent();
            ana = Application.OpenForms["frmAnaForm"] as frmAnaForm;
            _frmStokKart = frmStokKart;
            _tip = tip;
            _buton = buton;
        }
        private void grid_BoyutBirimleri_DoubleClick(object sender, EventArgs e)
        {
            BIRIM_BOYUTLAR row = (BIRIM_BOYUTLAR)gridView1.GetFocusedRow();
            if (row != null)
            {
                if (_frmStokKart != null)
                {
                    _buton.Text = row.CODE;
                    LG_UNITSETL seciliBirim = (LG_UNITSETL)_frmStokKart.gridView1.GetFocusedRow();
                    if (_buton.Name == "btn_En")
                    {
                        seciliBirim.BUTONEN = row.CODE;
                    }
                    else if (_buton.Name == "btn_Boy")
                    {
                        seciliBirim.BUTONBOY = row.CODE;
                    }
                    else if (_buton.Name == "btn_Yukseklik")
                    {
                        seciliBirim.BUTONYUKSEKLIK = row.CODE;
                    }
                    else if (_buton.Name == "btn_alan")
                    {
                        seciliBirim.BUTONALAN = row.CODE;
                    }
                    else if (_buton.Name == "btn_netHacim")
                    {
                        seciliBirim.BUTONNETHACIM = row.CODE;
                    }
                    else if (_buton.Name == "btn_brutHacim")
                    {
                        seciliBirim.BUTONBRUTHACIM = row.CODE;
                    }
                    else if (_buton.Name == "btn_NetAgirlik")
                    {
                        seciliBirim.BUTONNETAGIRLIK = row.CODE;
                    }
                    else if (_buton.Name == "btn_BrutAgirlik")
                    {
                        seciliBirim.BUTONBRUTRAGIRLIK = row.CODE;
                    }
                    this.Close();
                }
            }
        }
        private void frmBoyutIciBirimler_Load(object sender, EventArgs e)
        {
            ListeGetir();
        }
        void ListeGetir()
        {
            grid_BoyutBirimleri.DataSource = islem.StokKartiBoyutBirimleri(ana.lk_firma.EditValue.ToString(), ana.lk_donem.EditValue.ToString(), _tip);
        }
    }
}