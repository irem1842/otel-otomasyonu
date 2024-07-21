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
    internal class Crezervasyon
    {
        Cgenel gnl = new Cgenel();
        private int _ID;
        private int _OdaId;
        private int _MUSTERIID;
        private DateTime _Date;
        private int _CleintCount;
        private string _Description;
        private int _HesapId;

        public int ID { get => _ID; set => _ID = value; }
        
        public int OdaId { get => _OdaId ; set => _OdaId = value; }

        public DateTime Date { get => _Date; set => _Date = value; }
        public int CleintCount { get => _CleintCount; set => _CleintCount = value; }
        public string Description { get => _Description; set => _Description = value; }
        public int AdisyonId { get => _HesapId; set => _HesapId = value; }
        public int MUSTERIID { get => _MUSTERIID; set => _MUSTERIID = value; }

        public int getByClientIdFromRezervasyon(int odaId)
        {
            int clientId = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select top 1 MUSTERIID from Rezervasyonlar where ODAID=@odaId order by MUSTERIID desc", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("odaId", SqlDbType.Int).Value = odaId;

                clientId = Convert.ToInt32(cmd.ExecuteScalar());
            }

            catch (SqlException ex)
            {
                string hata = ex.Message;

                throw;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
            return clientId;


        }
        public bool rezervasyonKapatma(int adisyonID)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update rezervasyon set DURUM=1 where HESAPID=@HESAPId", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("HESAPId", SqlDbType.Int).Value = _HesapId;
                result = Convert.ToBoolean(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
            return result;
        }
        public void musteriGrtirFromRezervasyon(ListView lv)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select rezervasyon.MUSTERID,(AD + SOYAD) as musteri from rezervasyon Inner Join müsteri on rzervasyon.MUSTERIID=müsteri.ID where rezervasyon.DURUM=0", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;

            while (dr.Read())
            {
                lv.Items.Add(dr["MUSTERIID"].ToString());
                lv.Items[i].SubItems.Add(dr["musteri"].ToString());
                i++;
            }
            dr.Close();
            con.Dispose();
            con.Close();

        }
        //En son rezervasyon tarihini getir
        public void eskirezervasyonlarıGetir(ListView lv, int mId)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select rezervasyon.MUSTERID, AD, SOYAD ADISYONID,Tarih from  Rezervasyonlar Inner Join musteriler on Rezervasyonlar.MUSTERIID=musteriler.ID where Rezervasyonlar.MUSTERIID=@mId and Rezervasyonlar.Durum0 order by rezervasyonlar.ID Desc ", con);
            cmd.Parameters.Add("mId", SqlDbType.Int).Value = mId;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;

            while (dr.Read())
            {
                lv.Items.Add(dr["MUSTERIID"].ToString());
                lv.Items[i].SubItems.Add(dr["AD"].ToString());
                lv.Items[i].SubItems.Add(dr["SOYAD"].ToString());
                lv.Items[i].SubItems.Add(dr["TARIH"].ToString());
                lv.Items[i].SubItems.Add(dr["HESAPID"].ToString());
                i++;
            }
            dr.Close();
            con.Dispose();
            con.Close();

        }
        public DateTime EnSonRezervasyonTarih(int mId)
        {
            DateTime tar = new DateTime();
            tar = DateTime.Now;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select TARIH from Rezervasyonlar where Rezervasyonlar.MUSTERIID=@mId and Rezervasyonlar.Durum=1 order by rezervasyonlar.ID Desc", con);
            cmd.Parameters.Add("mId", SqlDbType.Int).Value = mId;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }
            tar = Convert.ToDateTime(cmd.ExecuteScalar());
            con.Dispose();
            con.Close();
            return tar;

        }
        public int AcıkRezervasyonSayısı()
        {
            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select count(*) from Rezervasyonlar where Rezervasyonlar.Durum=0", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {

                throw;
            }
            con.Dispose();
            con.Close();
            return sonuc;

        }
        public bool rezervasyonAcıkmıKontrol(int mId)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select top 1 Rezervasyonlar.ID from Rezervasyonlar where MUSTERIID=mId and Durum=1 order by ID desc", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("mId", SqlDbType.Int).Value = mId;
                result = Convert.ToBoolean(cmd.ExecuteScalar());
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
            return result;
        }

        public bool rezervasyonAc(Crezervasyon r)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Rezervasyonlar(MUSTERIID,MASAID,ADISYONID,KISISAYISI,TARIH,ACIKLAMA,Durum) values(@MUSTERIID,@MASAID,@ADISYONID,@KISISAYISI,@TARIH,@ACIKLAMA,1)", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("MUSTERIID", SqlDbType.Int).Value = r._MUSTERIID;
                cmd.Parameters.Add("MASAID", SqlDbType.Int).Value = r.OdaId;
                cmd.Parameters.Add("ADISYONID", SqlDbType.Int).Value = r._HesapId;
                cmd.Parameters.Add("KISISAYISI", SqlDbType.Int).Value = r._CleintCount;
                cmd.Parameters.Add("TARIH", SqlDbType.Date).Value = r._Date;
                cmd.Parameters.Add("ACIKLAMA", SqlDbType.VarChar).Value = r._Description;
                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
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
            return result;
        }

        public int RezerveMasaIdGetir(int mId)
        {
            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select Rezervasyonlar.MASAID from Rezervasyonlar INNER JOIN adisyonlar on Rezervasyonlar.ADISYONID=adisyonlar.ID where(Rezervasyonlar.Durum=1) and adisyonlar.Durum=0 and Rezervasyonlar.MUSTERIID=@mId", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                cmd.Parameters.Add("mId", SqlDbType.Int).Value = mId;
                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {

                throw;
            }
            con.Dispose();
            con.Close();
            return sonuc;

        }
    }
}
