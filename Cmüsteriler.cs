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
    internal class Cmüsteriler
    {
        Cgenel gnl = new Cgenel();
        private int _musteriid;
        private string _musteriAd;
        private string _musteriSoyad;
        private string _telefon;
        private string _adres;
        private string _mail;

        public int Musteriid { get => _musteriid; set => _musteriid = value; }
        public string MusteriAd { get => _musteriAd; set => _musteriAd = value; }
        public string MusteriSoyad { get => _musteriSoyad; set => _musteriSoyad = value; }
        public string Telefon { get => _telefon; set => _telefon = value; }
        public string Adres { get => _adres; set => _adres = value; }
        public string Mail { get => _mail; set => _mail = value; }
        public bool MusteriVarMı(string tlf)
        {
            bool sonuc = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "MusteriVarMı";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@telefon", SqlDbType.VarChar).Value = tlf;
            cmd.Parameters.Add("@sonuc", SqlDbType.Int);
            cmd.Parameters["@sonuc"].Direction = ParameterDirection.Output;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                cmd.ExecuteNonQuery();
                sonuc = Convert.ToBoolean(cmd.Parameters["@sonuc"].Value);

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;

            }
            finally
            {
                con.Close();

            }
            return sonuc;
        }
        public int musteriEkle(Cmüsteriler m)
        {
            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into müsteri(ad,soyad,telefon,adres,email) values(@ad,@soyad,@telefon,@adres,@email);select SCOPE_IDENTY()", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@ad", SqlDbType.VarChar).Value = m._musteriAd;
                cmd.Parameters.Add("@soyad", SqlDbType.VarChar).Value = m._musteriSoyad;
                cmd.Parameters.Add("@telefon", SqlDbType.VarChar).Value = m._telefon;
                cmd.Parameters.Add("@adres", SqlDbType.VarChar).Value = m._adres;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = m._mail;

                sonuc = Convert.ToInt32(cmd.ExecuteScalar());
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
        public bool musteriBilGüncelle(Cmüsteriler m)
        {
            bool sonuc = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update  müsteri set ad=@ad ,soyad=@soyad,telefon=@telefon,adres=@adres,email=@email where ID=@musteriId  ", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@ad", SqlDbType.VarChar).Value = m._musteriAd;
                cmd.Parameters.Add("@soyad", SqlDbType.VarChar).Value = m._musteriSoyad;
                cmd.Parameters.Add("@telefon", SqlDbType.VarChar).Value = m._telefon;
                cmd.Parameters.Add("@adres", SqlDbType.VarChar).Value = m._adres;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = m._mail;
                cmd.Parameters.Add("@musteriId", SqlDbType.Int).Value = m._musteriid;
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
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
        public void musterilerGetir(ListView lv)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from müsteri", con);
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
                        lv.Items[sayac].SubItems.Add(dr["ad"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["soyad"].ToString());

                        lv.Items[sayac].SubItems.Add(dr["telefon"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["adres"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["email"].ToString());
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
      
        public void musterigetirAd(ListView lv, string musteriAd)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from müsteri where ad like @musteriAd + '%'", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("musteriAd", SqlDbType.VarChar).Value = musteriAd;
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

                        lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["TELEFON"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["ADRES"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["EMAİL"].ToString());
                        sayac++;

                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            dr.Close();
            con.Dispose();
            con.Close();
        }
        public void musterigetirSoyad(ListView lv, string musteriSoyad)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from müsteri where soyad like @musteriSoyad + '%'", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("musteriSoyad", SqlDbType.VarChar).Value = musteriSoyad;
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

                        lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["TELEFON"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["ADRES"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["EMAİL"].ToString());
                        sayac++;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            dr.Close();
            con.Dispose();
            con.Close();
        }
        public void musterigrtirId(int musterId, TextBox ad, TextBox soyad, TextBox tlf, TextBox adres, TextBox email)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from müsteri where ID=@musterID", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("musteriID", SqlDbType.Int).Value = musterId;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ad.Text = dr["AD"].ToString();
                        ad.Text = dr["SOYAD"].ToString();
                        ad.Text = dr["TELEFON"].ToString();
                        ad.Text = dr["ADRES"].ToString();
                        ad.Text = dr["EMAİL"].ToString();
                    }

                }
            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }

            con.Dispose();
            con.Close();
        }
        public void musterigetirTelefon(ListView lv, string telefon)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from müsteri where telefon like @telefon + '%'", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("telefon", SqlDbType.VarChar).Value = telefon;
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
                       
                        lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["TELEFON"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["ADRES"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["EMAİL"].ToString());
                        sayac++;

                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            dr.Close();
            con.Dispose();
            con.Close();

        }
    }

}
