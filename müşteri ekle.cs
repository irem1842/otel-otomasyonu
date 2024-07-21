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
    public partial class müşteri_ekle : Form
    {
        public müşteri_ekle()
        {
            InitializeComponent();
        }

       

        private void btnMüşEkle_Click_1(object sender, EventArgs e)
        {
            if (txtTelefon.Text.Length > 6)
            {
                if (txtMüsteriAd.Text == "" || txtsoyad.Text == "")
                {
                    MessageBox.Show("Lütfen Müşterinin Ad ve Soyad Kısmını Doldurunuz.");
                }
                else
                {
                    Cmüsteriler c = new Cmüsteriler();
                    bool sonuc = c.MusteriVarMı(txtTelefon.Text);
                    if (!sonuc)
                    {
                        c.MusteriAd = txtMüsteriAd.Text;
                        c.MusteriSoyad = txtsoyad.Text;
                        c.Telefon = txtTelefon.Text;
                        c.Mail = txtMail.Text;
                        c.Adres = txtadres.Text;

                        txtmusterino.Text = c.musteriEkle(c).ToString();
                        if (txtmusterino.Text != "")
                        {
                            MessageBox.Show("Müşteri Eklendi");

                        }
                        else
                        {
                            MessageBox.Show("Müşteri Eklenemedi");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Bu İsimde Kayıt Bulunmakta");
                    }

                }
            }
            else
            {
                MessageBox.Show("Lütfen en az 7 haneli bir telefon numarası giriniz");
            }
        }

        private void btnMüsSec_Click_1(object sender, EventArgs e)
        {
            if (Cgenel._MusteriEkle == 0)
            {
                Form2 frm = new Form2();
                Cgenel._MusteriEkle = 1;
                this.Close();

                frm.Show();
            }
           
        }

        private void btnMüsGüncelle_Click_1(object sender, EventArgs e)
        {
            if (txtTelefon.Text.Length > 6)
            {
                if (txtMüsteriAd.Text == "" || txtsoyad.Text == "")
                {
                    MessageBox.Show("Lütfen Müşterinin Ad ve Soyad Kısmını Doldurunuz.");
                }
                else
                {
                   Cmüsteriler c = new Cmüsteriler();

                    c.MusteriAd = txtMüsteriAd.Text;
                    c.MusteriSoyad = txtsoyad.Text;
                    c.Telefon = txtTelefon.Text;
                    c.Mail = txtMail.Text;
                    c.Adres = txtadres.Text;
                    c.Musteriid = Convert.ToInt32(txtmusterino.Text);

                    bool sonuc = c.musteriBilGüncelle(c);
                    if (sonuc)
                    {
                        c.MusteriAd = txtMüsteriAd.Text;
                        c.MusteriSoyad = txtsoyad.Text;
                        c.Telefon = txtTelefon.Text;
                        c.Mail = txtMail.Text;
                        c.Adres = txtadres.Text;

                        txtmusterino.Text = c.musteriEkle(c).ToString();
                        if (txtmusterino.Text != "")
                        {
                            MessageBox.Show("Müşteri Güncellendi");

                        }
                        else
                        {
                            MessageBox.Show("Müşteri Güncellenemedi");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Bu İsimde Kayıt Bulunmakta");
                    }

                }
            }
            else
            {
                MessageBox.Show("Lütfen en az 7 haneli bir telefon numarası giriniz");
            }

        }

        private void frmMüşteriEkle_Load(object sender, EventArgs e)
        {
            if (Cgenel._musterıId > 0)
            {
                Cmüsteriler c = new Cmüsteriler();
                txtmusterino.Text = Cgenel._musterıId.ToString();
                c.musterigrtirId(Convert.ToInt32(txtmusterino.Text), txtMüsteriAd, txtsoyad, txtTelefon, txtadres, txtMail);
            }
        }

        private void btnCıkıs_Click_1(object sender, EventArgs e)
        {

            if (MessageBox.Show("Çıkmak İstediğinizden Emin Mİsiniz?", "Uyarı!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnGeriDön_Click_1(object sender, EventArgs e)
        {

           MENÜ  frm = new MENÜ();

            this.Close();
            frm.Show();
        }

        private void btnKapat_Click_1(object sender, EventArgs e)
        {
            müşteriler frm = new müşteriler();

            this.Close();
            frm.Show();


        }

        private void müşteri_ekle_Load(object sender, EventArgs e)
        {
            if (Cgenel._musterıId > 0)
            {
               Cmüsteriler c = new Cmüsteriler();
                txtmusterino.Text = Cgenel._musterıId.ToString();
                c.musterigrtirId(Convert.ToInt32(txtmusterino.Text), txtMüsteriAd, txtsoyad, txtTelefon, txtadres, txtMail);
            }
        }

       
    }
}
