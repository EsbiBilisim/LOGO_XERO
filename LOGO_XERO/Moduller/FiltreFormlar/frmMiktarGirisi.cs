using System.Windows.Forms;

namespace LOGO_XERO.Moduller.FiltreFormlar
{
    public partial class frmMiktarGirisi : DevExpress.XtraEditors.XtraForm
    {
        public double Miktar { get; private set; }
        public frmMiktarGirisi()
        {
            InitializeComponent();
        }      
        private void txt_miktar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double parsedValue;
                if (!double.TryParse(txt_miktar.Text, out parsedValue))
                {
                    MessageBox.Show("Lütfen geçerli bir sayı giriniz!");
                    return;
                }
                if (parsedValue <= 0)
                {
                    MessageBox.Show("Miktar 0'dan büyük olmalıdır!");
                    return;
                }

                Miktar = parsedValue;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}