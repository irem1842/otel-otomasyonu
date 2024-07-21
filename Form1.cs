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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Cgenel gnl = new Cgenel();
        private void Form1_Load(object sender, EventArgs e)
        {
            

           
            {
                Ccalısanlar p = new Ccalısanlar();
                p.personelBilGet(cbkullanici);

            }


        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            Cgenel gnl = new Cgenel();
            Ccalısanlar p = new Ccalısanlar();

            bool result = p.personelGirisKontrol(txtsifre.Text, Cgenel._personelId);

            if (result)
            {
                CcalısanHareketleri ch = new CcalısanHareketleri();
                ch.PersonelId = Cgenel._personelId;
                ch.Islem = "Giriş Yaptı";
                ch.Tarih = DateTime.Now;
                ch.personelHareket(ch);
                this.Hide();
                MENÜ menu = new MENÜ();
                menu.Show();

            }
            else
            {
                MessageBox.Show("Yanlış Şifre");
            }
        }

        private void cbkullanici_SelectedIndexChanged(object sender, EventArgs e)
        {
           Ccalısanlar p = (Ccalısanlar)cbkullanici.SelectedItem;
            Cgenel._personelId = p.PersonelId;
            Cgenel._gorevId = p.GorevId;

        }

        private void btnCikis_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Çıkmak İstediğinizden Emin Mİsiniz?", "Uyarı!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
