using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;




namespace Otel_Otomasyonu
{
    internal class Cpaket
    {
        Cgenel gnl = new Cgenel();
        private int _urunId;
        private int _uruntuno;
        private string _urunad;
        private decimal _fiyat;
        private string _aciklama;

        public int UrunId { get => _urunId; set => _urunId = value; }
        public int Uruntuno { get => _uruntuno; set => _uruntuno = value; }
        public string Urunad { get => _urunad; set => _urunad = value; }
        public decimal Fiyat { get => _fiyat; set => _fiyat = value; }
        public string Aciklama { get => _aciklama; set => _aciklama = value; }

        //urun adına göre sıralama
        public void urunleriListeleByUrunAdı(ListView lv, string urunadi)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from urunler Where Durum=0 and URUNAD like '&' +@urunAdi + '%'", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@urunAdi", SqlDbType.VarChar).Value = urunadi;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    dr = cmd.ExecuteReader();
                    int sayac = 0;
                    while (dr.Read())
                    {
                        lv.Items.Add(dr["ID"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["KETEGORIID"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["ACIKLAMA"].ToString());
                        lv.Items[sayac].SubItems.Add(string.Format("{0:0#00.0}", dr["FIYAT"].ToString()));
                        sayac++;

                    }
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;

            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }
        }
        public int urunEkle(Cpaket u)
        {
            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into urunler(URUNAD,KATEGORIID,ACIKLAMA,FIYAT)values(@urunAd,@katId,@acıklama,@fiyat); select SCOPE_IDENTITY()", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@urunAd", SqlDbType.VarChar).Value = u._urunad;
                cmd.Parameters.Add("@katId", SqlDbType.Int).Value = u._uruntuno;
                cmd.Parameters.Add("@acıklama", SqlDbType.VarChar).Value = u._aciklama;
                cmd.Parameters.Add("@fiyat", SqlDbType.VarChar).Value = u._fiyat;
                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());

            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
            return sonuc;

        }
        public void urunleriListele(ListView lv)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * urunler.*, KATEGORIADI from urunler Inner Join kategoriler on kategoriler.ID=urunler.KATEGORIID where urunler.Durum=0", con);
            SqlDataReader dr = null;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    dr = cmd.ExecuteReader();
                    int sayac = 0;
                    while (dr.Read())
                    {
                        lv.Items.Add(dr["ID"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["KETEGORIID"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["KETEGORIADI"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());
                        lv.Items[sayac].SubItems.Add(string.Format("{0:0#00.0}", dr["FIYAT"].ToString()));
                        lv.Items[sayac].SubItems.Add(dr["ACIKLAMA"].ToString());

                        sayac++;

                    }
                }

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;

            }
            finally
            {

                con.Dispose();
                con.Close();
            }


        }
        public int urunBilGüncelle(Cpaket c)
        {
            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update urunler set URUNAD=@urunad,KATEGORIID=@katId,ACIKLAMA=@acıklama,FIYAT=@fiyat where ID=@urunId ", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@urunad", SqlDbType.VarChar).Value = c._urunad;
                cmd.Parameters.Add("@katId", SqlDbType.Int).Value = c._uruntuno;
                cmd.Parameters.Add("@acıklama", SqlDbType.VarChar).Value = c._aciklama;
                cmd.Parameters.Add("@fiyat", SqlDbType.Money).Value = c.Aciklama;
                cmd.Parameters.Add("@urunId", SqlDbType.Int).Value = c._fiyat;
                cmd.Parameters.Add("@musteriId", SqlDbType.Int).Value = c._urunId;
                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());

            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
            return sonuc;
        }
        public int urunSil(Cpaket u, int kat)
        {
            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            string sql = "Update urunler set Durum=1 where";
            if (kat == 0)
                sql += "KATEGORIID=@urunID";
            else
                sql += "ID=@urunID";

            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@urunID", SqlDbType.Int).Value = u._urunId;
                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());

            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
            return sonuc;
        }
        public void urunleriListeleUrunAdı(ListView lv, int urunId)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select  paket.*, KATEGORIADI from paket Inner Join kategoriler on kategoriler.ID=urunler.KATEGORIID Where urunler.Durum=0 and urunler.KATEGORIID=@urunID", con);
            cmd.Parameters.Add("urunID", SqlDbType.Int).Value = urunId;
            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    dr = cmd.ExecuteReader();
                    int sayac = 0;
                    while (dr.Read())
                    {
                        lv.Items.Add(dr["ID"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["KATEGORIID"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["KATEGORIADI"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());
                        lv.Items[sayac].SubItems.Add(string.Format("{0:0#00.0}", dr["FIYAT"].ToString()));
                        sayac++;

                    }
                }

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;

            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }


        }
        public void urunlerListeleIstatistik(ListView lv, DateTimePicker Baslangıc, DateTimePicker Bitis)
        {

            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("SELECT top 10 dbo.paket.URUNAD,sum(dbo.satislar.ADET) as adeti FROM dbo.kategoriler INNERJOİN dbo.paket on dbo.kategoriler.ID=dbo.urunler.KATEGORIID INNER JOİN dbo.satislar ON dbo.urunler.ID=dbo.satislar.URUNID INNER JOİN dbo.adisyonlar ON dbo.satislar.ADISYONID =dbo.adisyonlar.ID WHERE (CONVERT(datetime,TARIH,104) BETWEEN CONVERT (datetime, '26.12.2022',104) AND CONVERT(datetime, '26.01.2023',104)) group by dbo.urunler.URUNAD order by adeti desc", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@Baslangıc", SqlDbType.VarChar).Value = Baslangıc.Value.ToShortDateString();
            cmd.Parameters.Add("@Bitis", SqlDbType.VarChar).Value = Bitis.Value.ToShortDateString();

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    dr = cmd.ExecuteReader();
                    int sayac = 0;
                    while (dr.Read())
                    {

                        lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["adeti"].ToString());

                        sayac++;

                    }
                }

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;

            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }


        }
        public void urunlerListeleIstatistikUrunId(ListView lv, DateTimePicker Baslangıc, DateTimePicker Bitis, int urunKatId)
        {

            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("SELECT top 10 dbo.urunler.URUNAD,sum(dbo.satislar.ADET) as adeti FROM dbo.kategoriler INNERJOİN dbo.urunler on dbo.kategoriler.ID=dbo.urunler.KATEGORIID INNER JOİN dbo.satislar ON dbo.urunler.ID=dbo.satislar.URUNID INNER JOİN dbo.adisyonlar ON dbo.satislar.ADISYONID =dbo.adisyonlar.ID WHERE (CONVERT(datetime,TARIH,104) BETWEEN CONVERT (datetime, '26.12.2022',104) AND CONVERT(datetime, '26.01.2023',104)) and(dbo.urunler.KATEGORIID=@katId) group by dbo.urunler.URUNAD order by adeti desc", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@Baslangıc", SqlDbType.VarChar).Value = Baslangıc.Value.ToShortDateString();
            cmd.Parameters.Add("@Bitis", SqlDbType.VarChar).Value = Bitis.Value.ToShortDateString();
            cmd.Parameters.Add("@katId", SqlDbType.Int).Value = urunKatId;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    dr = cmd.ExecuteReader();
                    int sayac = 0;
                    while (dr.Read())
                    {

                        lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["adeti"].ToString());

                        sayac++;

                    }
                }

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;

            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }
        }
       
        


    }
}



