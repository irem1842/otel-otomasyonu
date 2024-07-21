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
    public partial class BİLGİ_EKRANI : Form
    {
        public BİLGİ_EKRANI()
        {
            InitializeComponent();
        }
        Csatıs cs = new Csatıs(); int odemeTuru = 0;
        private void BİLGİ_EKRANI_Load(object sender, EventArgs e)
        {
            lblhesap.Text = Cgenel._HesapId;
            txtindirim.TextChanged += new EventHandler(txtindirim_TextChanged);
            cs.getByOrder(lvurunler, Convert.ToInt32(lblhesap.Text));
           
            if (lvurunler.Items.Count > 0)
            {
                decimal toplam = 0;
                for (int i = 0; i < lvurunler.Items.Count; i++)
                {
                    toplam += Convert.ToDecimal(lvurunler.Items[i].SubItems[3].Text);
                }
                lblFiyat.Text = String.Format("{0:0.000}", toplam);
                lblÖdenecek.Text = String.Format("{0:0.000}", toplam);

                decimal kdv = Convert.ToDecimal(lblÖdenecek.Text) * 18 / 100;
                lblkdv.Text = String.Format("{0:0.000}", kdv);

            }
            if (chkİndirim.Checked)
                grpİndirim.Visible = false;
            else
                grpİndirim.Visible = true;


            txtindirim.Clear();

            if (odemeTuru == 1)
            {
                rbKart.Checked = true;

            }
            else if (odemeTuru == 2)
            {
                rbNakit.Checked = true;
            }
        }

        private void btnÖzet_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();

        }
        Font Baslik = new Font("Verdana", 15, FontStyle.Bold);
        Font altBaslik = new Font("Verdana", 12, FontStyle.Bold);
        Font İcerik = new Font("Verdana", 10);
        SolidBrush sb = new SolidBrush(Color.Black);

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
        }

        private void btnGeriDön_Click_1(object sender, EventArgs e)
        {

            MENÜ frm = new MENÜ();
            this.Close();
            frm.Show();
        }
        Codalar oda = new Codalar();
        Crezervasyon rezerve = new Crezervasyon();
        private void btnHesapKapat_Click(object sender, EventArgs e)
        {

            int odaID = oda.TabloNoGetir(Cgenel._ButtonAd);
            int musterıID = 0;
            if (oda.TableGetbyState(odaID, 4) == true)
            {
                musterıID = rezerve.getByClientIdFromRezervasyon(odaID);
            }
            else
            {
                musterıID = 1;

            }
            int odemeTurId = 0;
            if (rbNakit.Checked)
            {
                odemeTurId = 1;
            }
            if (rbKart.Checked)
            {
                odemeTurId = 2;
            }
            Codeme odeme = new Codeme();
            odeme.AdisyonId = Convert.ToInt32(lblhesap.Text);
            odeme.OdemeTurId = odemeTurId;
            odeme.MusterıId = musterıID;
            odeme.AraToplam = Convert.ToDecimal(lblÖdenecek.Text);
            odeme.KdvTutarı = Convert.ToDecimal(lblkdv.Text);
            odeme.GenelToplam = Convert.ToDecimal(lblFiyat.Text);
            odeme.Indırım = Convert.ToDecimal(lblİndirim.Text);
            bool result = odeme.bilKapat(odeme);
            if (result)
            {
                MessageBox.Show("Hesap Kapatılmıştır.");
                oda.setChangeTableState(Convert.ToString(odaID), 1);
                Crezervasyon c = new Crezervasyon();
                c.rezervasyonKapatma(Convert.ToInt32(lblhesap.Text));
                Chesap a = new Chesap();
                a.hesapKapatma(Convert.ToInt32(lblhesap.Text), 0);
                this.Close();
                odalar frm = new odalar();
                frm.Show();

            }
            else
            {
                MessageBox.Show("Hesap Kapatılırken Bir Hata Oluştu");
            }
        }
        private void lblindirim_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(lblindirim.Text) > 0)
            {
                decimal odenecek = 0;
                lblÖdenecek.Text = lblFiyat.Text;
                odenecek = Convert.ToDecimal(lblÖdenecek.Text) - Convert.ToDecimal(lblindirim.Text);
                lblÖdenecek.Text = String.Format("{0:0.000}", odenecek);

            }
            decimal kdv = Convert.ToDecimal(lblÖdenecek.Text) * 18 / 100;
            lblkdv.Text = String.Format("{0:0.000}", kdv);
        }
        private void chkİndirim_CheckedChanged(object sender, EventArgs e)
        {
            if (chkİndirim.Checked)
            {
                grpİndirim.Visible = true;
                txtindirim.Clear();

            }
            else
            {
                grpİndirim.Visible = false;
                txtindirim.Clear();
            }
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

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringFormat st = new StringFormat();
            st.Alignment = StringAlignment.Near;
            e.Graphics.DrawString("", Baslik, sb, 350, 100, st);
            e.Graphics.DrawString("...................... ", altBaslik, sb, 350, 120, st);
            e.Graphics.DrawString(" PAKET ADI              ADET                FİYAT ", altBaslik, sb, 150, 250, st);
            e.Graphics.DrawString("....................................................... ", altBaslik, sb, 150, 180, st);
            for (int i = 0; i < lvurunler.Items.Count; i++)
            {
                e.Graphics.DrawString(lvurunler.Items[i].SubItems[0].Text, İcerik, sb, 150, 300 + i * 30, st);
                e.Graphics.DrawString(lvurunler.Items[i].SubItems[1].Text, İcerik, sb, 350, 300 + i * 30, st);
                e.Graphics.DrawString(lvurunler.Items[i].SubItems[3].Text, İcerik, sb, 420, 300 + i * 30, st);
            }
            e.Graphics.DrawString("HAYAL OTEL...............................", altBaslik, sb, 150, 300 + 30 * lvurunler.Items.Count, st);
            e.Graphics.DrawString("İndirim Tutarı   :................" + lblindirim.Text + "TL", altBaslik, sb, 250, 300 + 30 * (lvurunler.Items.Count + 1), st);
            e.Graphics.DrawString("KDV Tutarı   :................" + lblkdv.Text + "TL", altBaslik, sb, 250, 300 + 30 * (lvurunler.Items.Count + 2), st);
            e.Graphics.DrawString("Toplam Tutar   :................" + lblFiyat.Text + "TL", altBaslik, sb, 250, 300 + 30 * (lvurunler.Items.Count + 3), st);
            e.Graphics.DrawString("Ödediğiniz Tutar   :................" + lblÖdenecek.Text + "TL", altBaslik, sb, 250, 300 + 30 * (lvurunler.Items.Count + 4), st);
        }

        private void lblİndirim_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(lblindirim.Text) > 0)
            {
                decimal odenecek = 0;
                lblÖdenecek.Text = lblFiyat.Text;
                odenecek = Convert.ToDecimal(lblÖdenecek.Text) - Convert.ToDecimal(lblindirim.Text);
                lblÖdenecek.Text = String.Format("{0:0.000}", odenecek);

            }
            decimal kdv = Convert.ToDecimal(lblÖdenecek.Text) * 18 / 100;
            lblkdv.Text = String.Format("{0:0.000}", kdv);
        }

        private void txtindirim_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtindirim.Text) < Convert.ToDecimal(lblFiyat.Text))
                {
                    try
                    {
                        lblindirim.Text = String.Format("{0:0.000}", Convert.ToDecimal(txtindirim.Text));

                    }
                    catch (Exception)
                    {
                        lblindirim.Text = String.Format("{0:0.000}", 0);

                        throw;
                    }
                }
                else
                {
                    MessageBox.Show("İndirim Tutarı Toplam Tutardan Fazla Olamaz");
                }

            }
            catch (Exception)
            {

                lblindirim.Text = String.Format("{0:0.000}", 0);
            }

        }

        private void btnCıkıs_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak İstediğinizden Emin Mİsiniz?", "Uyarı!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void btnGeriDön_Click_2(object sender, EventArgs e)
        {
            MENÜ frm = new MENÜ();
            this.Close();
            frm.Show();
        }
    }
}
   
