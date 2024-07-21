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
    public partial class ÇALIŞANLAR_DÜZENLEME : Form
    {
        public ÇALIŞANLAR_DÜZENLEME()
        {
            InitializeComponent();
        }

        private void ÇALIŞANLAR_DÜZENLEME_Load(object sender, EventArgs e)
        {
            Ccalısanlar cp = new Ccalısanlar();
            Ccalısangörev cpg = new Ccalısangörev();
            string gorev = cpg.PersonelGorevTanim(Cgenel._gorevId);
            cp.personelBilGet(cbPersoneller);
            cpg.PersonelGorevGetir(cbgorev);
            cp.personelBilgileriniGetirLV(lvPersoneller);
            btnyeni.Enabled = true;
            btnsil.Enabled = false;
            btnbildeğiştir.Enabled = false;
            btnkaydet.Enabled = false;
            groupBox1.Visible = true;
            groupBox2.Visible = true;

            groupBox4.Visible = true;
            txtşifre.ReadOnly = true;
            txtşifretekrar.ReadOnly = true;
            lblBilgi.Text = "kullanıcı:" + cp.personelBilgiGetirIsım(Cgenel._personelId);
        }

        private void btnDeğiştir_Click(object sender, EventArgs e)
        {
            if (txtyeniŞifre.Text.Trim() != "" || txtYeniŞifretekrar.Text.Trim() != "")
            {
                if (txtyeniŞifre.Text == txtYeniŞifretekrar.Text)
                {
                    if (textBox1.Text != "")
                    {
                        Ccalısanlar c = new Ccalısanlar();
                        bool sonuc = c.personelŞifreDeğiştir(Convert.ToInt32(textBox1.Text), txtyeniŞifre.Text);
                        if (sonuc)
                        {
                            MessageBox.Show("Şifre Değiştirme İşlemi Başarıyla Gerçekleştirilmiştir");

                        }
                    }
                    else
                    {
                        MessageBox.Show("Personel Seçiniz");
                    }
                }
                else
                {
                    MessageBox.Show("Şifreler Aynı Değil");
                }
            }
            else
            {
                MessageBox.Show("Şifre Alanını Boş Bırakmayınız");
            }

        }

        private void btnyeni_Click(object sender, EventArgs e)
        {

            btnyeni.Enabled = false;
            btnkaydet.Enabled = true;
            btnbildeğiştir.Enabled = true;
            btnsil.Enabled = true;
            txtşifre.ReadOnly = false;
            txtşifretekrar.ReadOnly = false;
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (txtad.Text.Trim() != "" & txtsoyad.Text.Trim() != "" & txtşifre.Text.Trim() != "" & txtşifretekrar.Text.Trim() != "" & txtGorevId2.Text.Trim() != "")
            {
                if ((txtşifretekrar.Text.Trim() == txtşifre.Text.Trim() && (txtşifre.Text.Length > 4 || txtşifretekrar.Text.Length > 4)))
                {
                    Ccalısanlar c = new Ccalısanlar();
                    c.PersoneAd = txtad.Text.Trim();
                    c.PersonelSoyad = txtsoyad.Text.Trim();
                    c.PersonelParola = txtşifre.Text.Trim();
                    c.GorevId = Convert.ToInt32(txtGorevId2.Text);
                    bool sonuc = c.personelEkle(c);
                    if (sonuc)
                    {
                        MessageBox.Show("Kayıt Başarıyla Eklenmiştir");
                        c.personelBilgileriniGetirLV(lvPersoneller);
                    }
                    else
                    {
                        MessageBox.Show("Kayıt Eklernirken Bir Hata Oluştu");
                    }
                }
                else
                {
                    MessageBox.Show("Şifreler Aynı Değil");
                }
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            if (lvPersoneller.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Silmek İstediğinize Emin Misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Ccalısanlar c = new Ccalısanlar();
                    bool sonuc = c.personelSil(Convert.ToInt32(lvPersoneller.SelectedItems[0].Text));
                    if (sonuc)
                    {
                        MessageBox.Show("Kayıt Başarıyla Silinmiştir");
                        c.personelBilgileriniGetirLV(lvPersoneller);

                    }
                    else
                    {
                        MessageBox.Show("Kayıt Silinirken Bir Hata Oluştu");
                    }
                }
                else
                {
                    MessageBox.Show("Kayıt Seçiniz");
                }
            }
            {

            }
        }

        private void btnbildeğiştir_Click(object sender, EventArgs e)
        {
            if (lvPersoneller.SelectedItems.Count > 0)
            {
                if (txtad.Text.Trim() != "" || txtsoyad.Text.Trim() != "" || txtşifre.Text.Trim() != "" || txtşifretekrar.Text.Trim() != "" || txtGorevId2.Text.Trim() != "")
                {
                    if ((txtşifretekrar.Text.Trim() == txtşifre.Text.Trim() && (txtşifre.Text.Length > 5 || txtşifretekrar.Text.Length > 5)))
                    {
                        Ccalısanlar c = new Ccalısanlar();
                        c.PersoneAd = txtad.Text.Trim();
                        c.PersonelSoyad = txtsoyad.Text.Trim();
                        c.PersonelParola = txtşifretekrar.Text.Trim();
                        c.GorevId = Convert.ToInt32(txtGorevId2.Text);
                        bool sonuc = c.personelGüncelle(c, Convert.ToInt32(txtPersonelGorevId.Text));
                        if (sonuc)
                        {
                            MessageBox.Show("Kayıt Başarıyla Eklenmiştir");
                            c.personelBilgileriniGetirLV(lvPersoneller);
                        }
                        else
                        {
                            MessageBox.Show("Kayıt Eklernirken Bir Hata Oluştu");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Şifreler Aynı Değil");
                }
            }
            else
            {
                MessageBox.Show("Kayıt Seçiniz");
            }
        }

        private void lvPersoneller_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPersoneller.SelectedItems.Count > 0)
            {
                btnsil.Enabled = true;
                textBox1.Text = lvPersoneller.SelectedItems[0].SubItems[0].Text;
                cbgorev.SelectedIndex = Convert.ToInt32(lvPersoneller.SelectedItems[0].SubItems[1].Text) - 1;
                txtad.Text = lvPersoneller.SelectedItems[0].SubItems[2].Text;
                txtsoyad.Text = lvPersoneller.SelectedItems[0].SubItems[3].Text;

            }
            else
            {
                btnsil.Enabled = false;
            }
        }

        private void btnCıkıs_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Çıkmak İstediğinizden Emin Mİsiniz?", "Uyarı!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void btnGeriDön_Click_1(object sender, EventArgs e)
        {
            MENÜ frm = new MENÜ();
            this.Close();
            frm.Show();

        }

        private void btnCıkıs_Click_1(object sender, EventArgs e)
        {

            if (MessageBox.Show("Çıkmak İstediğinizden Emin Mİsiniz?", "Uyarı!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnGeriDön_Click(object sender, EventArgs e)
        {
            MENÜ frm = new MENÜ();
            this.Close();
            frm.Show();
        }

        private void cbPersoneller_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ccalısanlar c = (Ccalısanlar)cbPersoneller.SelectedItem;
            textBox1.Text = Convert.ToString(c.PersonelId);
        }

        private void cbgorev_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ccalısangörev g = (Ccalısangörev)cbgorev.SelectedItem;
            txtGorevId2.Text = Convert.ToString(g.PersonelGorevId);
        }
    }
}
   