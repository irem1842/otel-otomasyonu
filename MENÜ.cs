using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otel_Otomasyonu
{
    public partial class MENÜ : Form
    {
        public MENÜ()
        {
            InitializeComponent();
        }

        
        private void btnCıkıs_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak İstediğinizden Emin Mİsiniz?", "Uyarı!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void btnoda_Click(object sender, EventArgs e)
        {

            odalar frm = new odalar();
            this.Close();
            frm.Show();
        }

        private void btncalısanlar_Click(object sender, EventArgs e)
        {

            ÇALIŞANLAR_DÜZENLEME frm = new ÇALIŞANLAR_DÜZENLEME();
            this.Close();
            frm.Show();
        }

        private void btnMüsteriler_Click(object sender, EventArgs e)
        {
            müşteriler frm = new müşteriler();
            this.Close();
            frm.Show();
        }

        private void btnRezervasyon_Click(object sender, EventArgs e)
        {
            Form2 frm=new Form2();
            this.Close();
            frm.Show();
        }
    }
}
