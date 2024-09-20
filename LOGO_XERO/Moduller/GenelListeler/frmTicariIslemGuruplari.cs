using DevExpress.XtraEditors;
using LOGO_XERO.Logic;
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
    public partial class frmTicariIslemGuruplari : DevExpress.XtraEditors.XtraForm
    {
        Islemler islem = new Islemler();
        frmTeklifOlustur _frmTeklifOlustur;
        frmCariKartEkle _frmCariKartEkle;
        //frmIrsaliyeOlustur _frmIrsaliyeOlustur;
        //frmFaturaOlustur _frmFaturaOlustur;

        public frmTicariIslemGuruplari(frmTeklifOlustur frmTeklifOlustur)
        {
            InitializeComponent();
            _frmTeklifOlustur = frmTeklifOlustur;
        }
        public frmTicariIslemGuruplari(frmCariKartEkle frmCariKartEkle)
        {
            InitializeComponent();
            _frmCariKartEkle = frmCariKartEkle;

        }
        //public frmTicariIslemGuruplari(frmIrsaliyeOlustur frmIrsaliyeOlustur)
        //{
        //    InitializeComponent();
        //    _frmIrsaliyeOlustur = frmIrsaliyeOlustur;
        //}
        //public frmTicariIslemGuruplari(frmFaturaOlustur frmFaturaOlustur)
        //{
        //    InitializeComponent();
        //    _frmFaturaOlustur = frmFaturaOlustur;
        //}

        private void frmTicariIslemGuruplari_Load(object sender, EventArgs e)
        {
            ListeYukle();
        }
        void ListeYukle()
        {
            List<L_TRADGRP> liste = islem.TicariIslemGruplariGetir();
            grid_TicariIslemGuruplari.DataSource = liste;
        }

        private void grid_TicariIslemGuruplari_DoubleClick(object sender, EventArgs e)
        {
            L_TRADGRP row = (L_TRADGRP)gv_TicariIslemGruplari.GetFocusedRow();
            if (row != null)
            {
                if (_frmTeklifOlustur != null)
                {
                    _frmTeklifOlustur.btn_ticariIslemGuruplari.Text = row.GCODE;
                    Close();
                }
                if (_frmCariKartEkle != null)
                {
                    _frmCariKartEkle.btn_TicariIslemGrubu.Text = row.GCODE;
                    Close();
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTicariIslemGuruplari_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                simpleButton2_Click(sender, e);
            }
        }
    }
}