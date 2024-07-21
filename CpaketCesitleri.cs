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
    internal class CpaketCesitleri
    {
        Cgenel gnl = new Cgenel();
        private int _UrunTurNo;
        private string _KategoriAd;
        private string _Acıklama;

        public int UrunTurNo { get => _UrunTurNo; set => _UrunTurNo = value; }
        public string KategoriAd { get => _KategoriAd; set => _KategoriAd = value; }
        public string Acıklama { get => _Acıklama; set => _Acıklama = value; }

        public void getByProductTypes(ListView Cesitler, Button btn)
        {
          
            Cesitler.Items.Clear();
            SqlConnection conn = new SqlConnection(gnl.conString);
            SqlCommand comn = new SqlCommand("Select URUNAD,FIYAT,paket.ID From kategoriler Inner Join paket on kategoriler.ID=paket.KATEGORIID ", conn);
           

           
            
            
            
         
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlDataReader dr = comn.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                Cesitler.Items.Add(dr["URUNAD"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["FIYAT"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["ID"].ToString());
                i++;
            }
            dr.Close();
            conn.Dispose();
            conn.Close();
        }
        public void getByProductSearch(ListView Cesitler, int txt)
        {
            Cesitler.Items.Clear();
            SqlConnection conn = new SqlConnection(gnl.conString);
            SqlCommand comn = new SqlCommand("Select * from paket where ID=@ID", conn);


            comn.Parameters.Add("@ID", SqlDbType.Int).Value = txt;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlDataReader dr = comn.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                Cesitler.Items.Add(dr["URUNAD"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["FIYAT"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["ID"].ToString());
                i++;
            }
            dr.Close();
            conn.Dispose();
            conn.Close();
        }
        public void uruncesitlerinigetir(ComboBox cb)
        {
            cb.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from kategoriler where Durum=0", con);
            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        CpaketCesitleri uc = new CpaketCesitleri();
                        uc._UrunTurNo = Convert.ToInt32(dr["ID"]);
                        uc._KategoriAd = dr["KATEGORIADI"].ToString();
                        uc._Acıklama = dr["ACIKLAMA"].ToString();
                        cb.Items.Add(uc);


                    }
                }


            }
            catch (SqlException ex)
            {
                string hata = ex.Message;

            }
        }
        public void urunCesitGetir(ListView lv)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from kateforiler where Durum=0", con);
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
                        lv.Items[sayac].SubItems.Add(dr["KETEGORIADI"].ToString());
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
      
        
       
    }
}
