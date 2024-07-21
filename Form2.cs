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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Cmüsteriler m = new Cmüsteriler();
            m.musterilerGetir(lvmüsteriler);
            Codalar oda = new Codalar();
            oda.OdaKapatitesiDurumGetir(cboda);
            dttarih.MinDate = DateTime.Today;
            dttarih.Format = DateTimePickerFormat.Time;

        }
       

        private void txtTelefon_TextChanged(object sender, EventArgs e)
        {
           Cmüsteriler m = new Cmüsteriler();
            m.musterigetirTelefon(lvmüsteriler, txtTelefon.Text);
        }

        private void txtAdres_TextChanged(object sender, EventArgs e)
        {
            Cmüsteriler m = new Cmüsteriler();
            m.musterigetirAd(lvmüsteriler, txtAdres.Text);
        }
        void temizle()
        {
            txtAdres.Clear();
            txtTelefon.Clear();
            txtkişiSayı.Clear();
            txtoda.Clear();
            txttarih.Clear();
            txtAdres.Clear();
        }

        private void btnMüsterisec_Click_1(object sender, EventArgs e)
        {
            Crezervasyon r = new Crezervasyon();
            if (lvmüsteriler.SelectedItems.Count > 0)
            {
                bool sonuc = r.rezervasyonAcıkmıKontrol(Convert.ToInt32(lvmüsteriler.SelectedItems[0].SubItems[0].Text));
                if (!sonuc)
                {
                    if (txttarih.Text != "")
                    {
                        if (txtkişiSayı.Text != "")
                        {
                           Codalar masa = new Codalar();
                            if (masa.TableGetbyState(Convert.ToInt32(txtodaNo.Text), 1))
                            {
                                Chesap a = new Chesap();
                                a.TARIH = Convert.ToDateTime(txttarih.Text);
                                
                                a.ODAID = Convert.ToInt32(txtodaNo.Text);
                                a.PERSONELID = Cgenel._personelId;

                                r.MUSTERIID = Convert.ToInt32(Convert.ToInt32(lvmüsteriler.SelectedItems[0].SubItems[0].Text));
                                r.OdaId = Convert.ToInt32(txtodaNo.Text);
                                r.Date = Convert.ToDateTime(txttarih.Text);
                                r.CleintCount = Convert.ToInt32(txtkişiSayı.Text);
                                r.AdisyonId = a.RezervasyonHesapAc(a);
                                sonuc = r.rezervasyonAc(r);
                                masa.setChangeTableState(txtodaNo.Text, 3);
                                if (sonuc)
                                {
                                    MessageBox.Show("Rezervasyon Başarıyla Açılmıştır");
                                    temizle();

                                }
                                else
                                {
                                    MessageBox.Show("Rezervasyon Kayıtı Gerçekleşmiştir");
                                }

                            }
                            else
                            {
                                MessageBox.Show("Rezervasyon Yapılan Masa Şu An Dolu");

                            }
                        }
                        else
                        {
                            MessageBox.Show("Lütfen Kişi Sayısı Seçiniz");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Lütfen Bir Tarih Seçiniz");
                    }
                }
                else
                {
                    MessageBox.Show("Bu Müşteriye Dair Açık Bir Rezervasyon Bulunmaktadır");
                }
            }

        }

        private void dateTimePicker1_MouseEnter(object sender, EventArgs e)
        {
            dttarih.Width = 200;
        }

        private void dateTimePicker1_Enter(object sender, EventArgs e)
        {
            dttarih.Width = 200;
        }

        private void dateTimePicker1_MouseLeave(object sender, EventArgs e)
        {
            dttarih.Width = 23;
        }

        private void dateTimePicker1_Validating(object sender, CancelEventArgs e)
        {
            txttarih.Text = dttarih.Value.ToString();
        }



        private void cboda_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbKişiSayısı.Enabled = true;
            txtoda.Text = cboda.SelectedItem.ToString();
            Codalar kapasitesi = (Codalar)cboda.SelectedItem;
            int Kapasite = kapasitesi.KAPASITE;
            txtodaNo.Text = Convert.ToString(kapasitesi.ID);
            cbKişiSayısı.Items.Clear();
            for (int i = 0; i < Kapasite; i++)
            {
                cbKişiSayısı.Items.Add(i + 1);
            }

        }
        private void cbKişiSayısı_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtkişiSayı.Text = cbKişiSayısı.SelectedItem.ToString();
        }

       
        private void cboda_MouseLeave_1(object sender, EventArgs e)
        {
            cboda.Width = 23;
        }

        private void cbKişiSayısı_MouseLeave_1(object sender, EventArgs e)
        {
            cbKişiSayısı.Width = 23;
        }

        private void cbKişiSayısı_MouseEnter_1(object sender, EventArgs e)
        {
            cbKişiSayısı.Width = 100;
        }

      

        private void btnYeniMüsteri_Click(object sender, EventArgs e)
        {
            müşteri_ekle frm = new müşteri_ekle();
            Cgenel._MusteriEkle = 0;
            frm.btnMüsGüncelle.Visible = false;
            frm.btnMüşEkle.Visible = true;
            this.Close();
            frm.Show();
        }

        private void btnMütseriGüncelle_Click(object sender, EventArgs e)
        {
            if (lvmüsteriler.SelectedItems.Count > 0)
            {
                müşteri_ekle frm = new müşteri_ekle();
                Cgenel._MusteriEkle = 0;
                Cgenel._musterıId = Convert.ToInt32(lvmüsteriler.SelectedItems[0].SubItems[0].Text);
                frm.btnMüsGüncelle.Visible = true;
                frm.btnMüşEkle.Visible = false;
                this.Close();
                frm.Show();
            }

        }
     
        private void button1_Click(object sender, EventArgs e)
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

        private void cboda_MouseEnter_1(object sender, EventArgs e)
        {
            cboda.Width = 105;
        }

       

        private void cbKişiSayısı_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void txtmüsteri_TextChanged_1(object sender, EventArgs e)
        {
            Cmüsteriler m = new Cmüsteriler();
            m.musterigetirAd(lvmüsteriler, txtmüsteri.Text);
        }


        private void txtayrılış_Validating(object sender, CancelEventArgs e)
        {
            txtayrılış.Text = dateTimePicker2.Value.ToString();
        }

       
    }
}
