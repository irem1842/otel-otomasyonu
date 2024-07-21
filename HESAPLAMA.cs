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
    public partial class HESAPLAMA : Form
    {
        public HESAPLAMA()
        {
            InitializeComponent();
        }
        int odaId = 0;
        int hesapId= 0;
        private void HESAPLAMA_Load(object sender, EventArgs e)
        {
            lblodanum.Text = Cgenel._ButtonValue;
            Codalar ms = new Codalar();
            odaId = ms.TabloNoGetir(Cgenel._ButtonAd);
            if (ms.TableGetbyState(odaId, 2) == true || ms.TableGetbyState(odaId, 4) == true)
            {
                Chesap Ad = new Chesap();
                hesapId = Ad.getByHesap(odaId);
                Csatıs orders = new Csatıs();
                orders.getByOrder(lvSiparişler, hesapId);
            }
            btn1.Click += new EventHandler(islem);
            btn2.Click += new EventHandler(islem);
            btn3.Click += new EventHandler(islem);
            btn4.Click += new EventHandler(islem);
            btn5.Click += new EventHandler(islem);
            btn6.Click += new EventHandler(islem);
            btn7.Click += new EventHandler(islem);
            btn8.Click += new EventHandler(islem);
            btn9.Click += new EventHandler(islem);
            btn0.Click += new EventHandler(islem);


        }

        private void btnCıkıs_Click(object sender, EventArgs e)
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
        void islem(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Name)
            {
                case "btn1":
                    txtAdet.Text += (1).ToString();
                    break;
                case "btn2":
                    txtAdet.Text += (2).ToString();
                    break;
                case "btn3":
                    txtAdet.Text += (3).ToString();
                    break;
                case "btn4":
                    txtAdet.Text += (4).ToString();
                    break;
                case "btn5":
                    txtAdet.Text += (5).ToString();
                    break;
                case "btn6":
                    txtAdet.Text += (6).ToString();
                    break;
                case "btn7":
                    txtAdet.Text += (7).ToString();
                    break;
                case "btn8":
                    txtAdet.Text += (8).ToString();
                    break;
                case "btn9":
                    txtAdet.Text += (9).ToString();
                    break;
                case "btn0":
                    txtAdet.Text += (0).ToString();
                    break;
                default:
                    MessageBox.Show("Sayı Gir");
                    break;

            }
        }
        CpaketCesitleri uc = new CpaketCesitleri();

        private void BTNKONAKLAMA_Click(object sender, EventArgs e)
        {
            uc.getByProductTypes(lvMenu, BTNKONAKLAMA);
        }

        private void btneksharcamalar_Click(object sender, EventArgs e)
        {
            uc.getByProductTypes(lvMenu, btneksharcamalar);
        }
        int sayac = 0; int sayac2 = 0;
        private void lvMenu_DoubleClick_1(object sender, EventArgs e)
        {
            if (txtAdet.Text == "")
            {
                txtAdet.Text = "1";
            }
            if (lvMenu.Items.Count > 0)
            {
                sayac = lvSiparişler.Items.Count;
                lvSiparişler.Items.Add(lvMenu.SelectedItems[0].Text);
                lvSiparişler.Items[sayac].SubItems.Add(txtAdet.Text);
                lvSiparişler.Items[sayac].SubItems.Add(lvMenu.SelectedItems[0].SubItems[2].Text);
                lvSiparişler.Items[sayac].SubItems.Add((Convert.ToDecimal(lvMenu.SelectedItems[0].SubItems[1].Text) * Convert.ToDecimal(txtAdet.Text)).ToString());

                lvSiparişler.Items[sayac].SubItems.Add("0");
                sayac2 = lvYeniEklenen.Items.Count;
                lvSiparişler.Items[sayac].SubItems.Add(sayac2.ToString());

                lvYeniEklenen.Items.Add(hesapId.ToString());
                lvYeniEklenen.Items[sayac2].SubItems.Add(lvMenu.SelectedItems[0].SubItems[2].Text);
                lvYeniEklenen.Items[sayac2].SubItems.Add(txtAdet.Text);
                lvYeniEklenen.Items[sayac2].SubItems.Add(odaId.ToString());
                lvYeniEklenen.Items[sayac2].SubItems.Add(sayac2.ToString());
                sayac2++;
                txtAdet.Text = "";

            }

        }
       
        private void lvSiparişler_DoubleClick_1(object sender, EventArgs e)
        {
            if (lvSiparişler.Items.Count > 0)
            {
                if (lvSiparişler.SelectedItems[0].SubItems[4].Text != "0")
                {
                   Csatıs saveOrder = new Csatıs();
                    saveOrder.setDeleteOrder(Convert.ToInt32(lvSiparişler.SelectedItems[0].SubItems[4].Text));


                }
                else
                {
                    for (int i = 0; i < lvYeniEklenen.Items.Count; i++)
                    {
                        if (lvYeniEklenen.Items[i].SubItems[4].Text == lvSiparişler.SelectedItems[0].SubItems[5].Text)
                        {
                            lvYeniEklenen.Items.RemoveAt(i);

                        }
                    }
                }
                lvSiparişler.Items.RemoveAt(lvSiparişler.SelectedItems[0].Index);
            }
        }
     
        private void btnÖdeme_Click_1(object sender, EventArgs e)
        {
            Cgenel._HesapId = hesapId.ToString();
            BİLGİ_EKRANI frm = new BİLGİ_EKRANI();
            this.Close();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Codalar odam = new Codalar();
            odalar ms = new odalar();
            Chesap newAdisyon = new Chesap();
            Csatıs saveorder = new Csatıs();

            bool sonuc = false;
            if (odam.TableGetbyState(odaId, 1) == true)
            {


                newAdisyon.PERSONELID = 1;
                newAdisyon.ODAID = odaId;
                newAdisyon.TARIH = DateTime.Now;
                sonuc = newAdisyon.setByAdditionNew(newAdisyon);
                odam.setChangeTableState(Cgenel._ButtonAd, 2);

                if (lvSiparişler.Items.Count > 0)
                {
                    for (int i = 0; i < lvSiparişler.Items.Count; i++)
                    {
                        saveorder.OdaId = odaId;
                        saveorder.UrunId = Convert.ToInt32(lvSiparişler.Items[i].SubItems[2].Text);
                        saveorder.HesapId = newAdisyon.getByHesap(odaId);
                        saveorder.Adet = Convert.ToInt32(lvSiparişler.Items[i].SubItems[1].Text);
                        saveorder.SetSAveOrder(saveorder);


                    }
                    this.Close();
                    ms.Show();
                }

            }
            else if (odam.TableGetbyState(odaId, 2) == true)
            {
                if (lvYeniEklenen.Items.Count > 0)
                {
                    for (int i = 0; i < lvYeniEklenen.Items.Count; i++)
                    {
                        saveorder.OdaId = odaId;
                        saveorder.UrunId = Convert.ToInt32(lvYeniEklenen.Items[i].SubItems[1].Text);
                        saveorder.HesapId = newAdisyon.getByHesap(odaId);
                        saveorder.Adet = Convert.ToInt32(lvYeniEklenen.Items[i].SubItems[2].Text);
                        saveorder.SetSAveOrder(saveorder);


                    }
                    Cgenel._HesapId = Convert.ToString(newAdisyon.getByHesap(odaId));
                    this.Close();
                    ms.Show();


                }


            }
            else if (odam.TableGetbyState(odaId, 3) == true)
            {
              
                odam.setChangeTableState(Cgenel._ButtonAd, 4);

                if (lvSiparişler.Items.Count > 0)
                {
                    for (int i = 0; i < lvSiparişler.Items.Count; i++)
                    {
                        saveorder.OdaId = odaId;
                        saveorder.UrunId = Convert.ToInt32(lvSiparişler.Items[i].SubItems[2].Text);
                        saveorder.HesapId = newAdisyon.getByHesap(odaId);
                        saveorder.Adet = Convert.ToInt32(lvSiparişler.Items[i].SubItems[1].Text);
                        saveorder.SetSAveOrder(saveorder);


                    }
                    this.Close();
                    ms.Show();
                }
            }



        }

      
    }
}

