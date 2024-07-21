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
    public partial class müşteriler : Form
    {
        public müşteriler()
        {
            InitializeComponent();
        }

        private void müşteriler_Load(object sender, EventArgs e)
        {

            Cmüsteriler c = new Cmüsteriler();
            c.musterilerGetir(lvMüsteriler);
        }

        private void btnGeriDön_Click(object sender, EventArgs e)
        {
            MENÜ frm = new MENÜ();
            this.Close();
            frm.Show();
        }

        private void btnCıkıs_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Çıkmak İstediğinizden Emin Mİsiniz?", "Uyarı!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnmüsteriEkle_Click(object sender, EventArgs e)
        {
            müşteri_ekle m = new müşteri_ekle();
            Cgenel._MusteriEkle = 1;
            btnMüsteriGüncelle.Visible = false;
            m.btnMüşEkle.Visible = true; 

            m.Show();
        }

        private void btnMüsteriGüncelle_Click(object sender, EventArgs e)
        {
            if (lvMüsteriler.SelectedItems.Count > 0)
            {
                müşteri_ekle frm = new müşteri_ekle();
                Cgenel._MusteriEkle = 1;

                Cgenel._musterıId = Convert.ToInt32(lvMüsteriler.SelectedItems[0].SubItems[0].Text);
                frm.btnMüşEkle.Visible = false;
                frm.btnMüsGüncelle.Visible = true;
                this.Close();
                frm.Show();
            }
        }
        private void txtMüsteriAd_TextChanged_1(object sender, EventArgs e)
        {
            Cmüsteriler c = new Cmüsteriler();
            c.musterigetirAd(lvMüsteriler, txtMüsteriAd.Text);
        }

        private void txtMüsteriSoyad_TextChanged_1(object sender, EventArgs e)
        {
            Cmüsteriler c = new Cmüsteriler();
            c.musterigetirSoyad(lvMüsteriler, txtMüsteriSoyad.Text);

        }

        private void txtMüsTelefon_TextChanged_1(object sender, EventArgs e)
        {
            Cmüsteriler c = new Cmüsteriler();
            c.musterigetirTelefon(lvMüsteriler, txtMüsTelefon.Text);
        }

        private void btnmüsterisec_Click(object sender, EventArgs e)
        {

        }

      
    }
}