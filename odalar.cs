using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Otel_Otomasyonu
{
    public partial class odalar : Form
    {
        public odalar()
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
        Cgenel gnl = new Cgenel();

       

        private void odalar_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select DURUM,ID from odalar", con);
            SqlDataReader dr = null;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                foreach (Control item in this.Controls)
                {
                    if (item is Button)
                    {
                        if (item.Name == "btnOda" + dr["ID"].ToString() && dr["DURUM"].ToString() == "1")
                        {
                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.Adsız);
                        }
                        else if (item.Name == "btnOda" + dr["ID"].ToString() && dr["DURUM"].ToString() == "2")
                        {
                            Codalar ms = new Codalar();
                            DateTime dt1 = Convert.ToDateTime(ms.oda(2, dr["ID"].ToString()));
                            DateTime dt2 = DateTime.Now;
                            string st1 = Convert.ToDateTime(ms.oda(2, dr["ID"].ToString())).ToShortTimeString();
                            string st2 = DateTime.Now.ToShortTimeString();

                           
                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.DOLU);

                        }
                        else if (item.Name == "btnoda" + dr["ID"].ToString() && dr["DURUM"].ToString() == "3")
                        {
                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.REZERVE);
                        }
                        else if (item.Name == "btnoda" + dr["ID"].ToString() && dr["DURUM"].ToString() == "4")
                        {
                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.DOLU);
                        }
                    }
                    }
                }

            }

        private void btnoda2_Click(object sender, EventArgs e)
        {

            HESAPLAMA frm = new HESAPLAMA();
            int uzunluk = btnoda2.Text.Length;
            Cgenel._ButtonValue = btnoda2.Text.Substring(uzunluk - 5, 5);
            Cgenel._ButtonAd = btnoda6.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnoda1_Click(object sender, EventArgs e)
        {

            HESAPLAMA frm = new HESAPLAMA();
            int uzunluk = btnoda1.Text.Length;
            Cgenel._ButtonValue = btnoda1.Text.Substring(uzunluk -5,5);
            Cgenel._ButtonAd = btnoda1.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnoda3_Click(object sender, EventArgs e)
        {
            HESAPLAMA frm = new HESAPLAMA();
            int uzunluk = btnoda3.Text.Length;
            Cgenel._ButtonValue = btnoda3.Text.Substring(uzunluk -5,5);
            Cgenel._ButtonAd = btnoda3.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnoda4_Click(object sender, EventArgs e)
        {
            HESAPLAMA frm = new HESAPLAMA();
            int uzunluk = btnoda4.Text.Length;
            Cgenel._ButtonValue = btnoda4.Text.Substring(uzunluk - 5, 5);
            Cgenel._ButtonAd = btnoda4.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnoda5_Click(object sender, EventArgs e)
        {

            HESAPLAMA frm = new HESAPLAMA();
            int uzunluk = btnoda5.Text.Length;
            Cgenel._ButtonValue = btnoda5.Text.Substring(uzunluk - 5, 5);
            Cgenel._ButtonAd = btnoda5.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnoda6_Click(object sender, EventArgs e)
        {

            HESAPLAMA frm = new HESAPLAMA();
            int uzunluk = btnoda6.Text.Length;
            Cgenel._ButtonValue = btnoda6.Text.Substring(uzunluk - 5, 5);
            Cgenel._ButtonAd = btnoda6.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnoda7_Click(object sender, EventArgs e)
        {

            HESAPLAMA frm = new HESAPLAMA();
            int uzunluk = btnoda7.Text.Length;
            Cgenel._ButtonValue = btnoda7.Text.Substring(uzunluk - 5, 5);
            Cgenel._ButtonAd = btnoda6.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnoda8_Click(object sender, EventArgs e)
        {

            HESAPLAMA frm = new HESAPLAMA();
            int uzunluk = btnoda8.Text.Length;
            Cgenel._ButtonValue = btnoda8.Text.Substring(uzunluk - 5, 5);
            Cgenel._ButtonAd = btnoda6.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnoda9_Click(object sender, EventArgs e)
        {

            HESAPLAMA frm = new HESAPLAMA();
            int uzunluk = btnoda9.Text.Length;
            Cgenel._ButtonValue = btnoda9.Text.Substring(uzunluk - 6, 6);
            Cgenel._ButtonAd = btnoda9.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnoda10_Click(object sender, EventArgs e)
        {

            HESAPLAMA frm = new HESAPLAMA();
            int uzunluk = btnoda10.Text.Length;
            Cgenel._ButtonValue = btnoda10.Text.Substring(uzunluk - 6, 6);
            Cgenel._ButtonAd = btnoda10.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnoda11_Click(object sender, EventArgs e)
        {

            HESAPLAMA frm = new HESAPLAMA();
            int uzunluk = btnoda11.Text.Length;
            Cgenel._ButtonValue = btnoda11.Text.Substring(uzunluk - 6, 6);
            Cgenel._ButtonAd = btnoda11.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnoda12_Click(object sender, EventArgs e)
        {

            HESAPLAMA frm = new HESAPLAMA();
            int uzunluk = btnoda12.Text.Length;
            Cgenel._ButtonValue = btnoda12.Text.Substring(uzunluk - 6, 6);
            Cgenel._ButtonAd = btnoda6.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnoda13_Click(object sender, EventArgs e)
        {

            HESAPLAMA frm = new HESAPLAMA();
            int uzunluk = btnoda13.Text.Length;
            Cgenel._ButtonValue = btnoda13.Text.Substring(uzunluk - 6, 6);
            Cgenel._ButtonAd = btnoda13.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnoda14_Click(object sender, EventArgs e)
        {

            HESAPLAMA frm = new HESAPLAMA();
            int uzunluk = btnoda14.Text.Length;
            Cgenel._ButtonValue = btnoda14.Text.Substring(uzunluk - 6, 6);
            Cgenel._ButtonAd = btnoda14.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnoda15_Click(object sender, EventArgs e)
        {
            HESAPLAMA frm = new HESAPLAMA();
            int uzunluk = btnoda6.Text.Length;
            Cgenel._ButtonValue = btnoda15.Text.Substring(uzunluk - 6, 6);
            Cgenel._ButtonAd = btnoda6.Name;
            this.Close();
            frm.ShowDialog();

        }

        private void btnoda16_Click(object sender, EventArgs e)
        {

            HESAPLAMA frm = new HESAPLAMA();
            int uzunluk = btnoda6.Text.Length;
            Cgenel._ButtonValue = btnoda16.Text.Substring(uzunluk - 6, 6);
            Cgenel._ButtonAd = btnoda6.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnGeriDön_Click_1(object sender, EventArgs e)
        {
            MENÜ frm = new MENÜ();
            this.Close();
            frm.Show();
        }

        private void btnoda5_Click_1(object sender, EventArgs e)
        {
            HESAPLAMA frm = new HESAPLAMA();
            int uzunluk = btnoda5.Text.Length;
            Cgenel._ButtonValue = btnoda5.Text.Substring(uzunluk - 6, 6);
            Cgenel._ButtonAd = btnoda5.Name;
            this.Close();
            frm.ShowDialog();
        }
    }
}
