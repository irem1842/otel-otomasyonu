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
    internal class Csatıs
    {
        Cgenel gnl = new Cgenel();
        private int _Id;
        private int _HesapId;
        private int _urunId;
        private int _adet;
        private int _OdaId;

        public int Id { get => _Id; set => _Id = value; }
        public int HesapId { get => _HesapId; set => _HesapId = value; }
        public int UrunId { get => _urunId; set => _urunId = value; }
        public int Adet { get => _adet; set => _adet = value; }
        public int OdaId { get => _OdaId; set => _OdaId = value; }

        public void getByOrder(ListView lv, int HesapId)
        {

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select URUNAD,FIYAT,Satislar.ID,satislar.URUNID,Satislar.ADET from satislar Inner join paket on satislar.URUNID=paket.ID  Where HESAPID=@HesapId", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@HesapId", SqlDbType.Int).Value = HesapId;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                dr = cmd.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADET"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNID"].ToString());
                    lv.Items[sayac].SubItems.Add(Convert.ToString(Convert.ToDecimal(dr["FIYAT"]) * Convert.ToDecimal(dr["ADET"])));
                    lv.Items[sayac].SubItems.Add(dr["ID"].ToString());
                    sayac++;
                }

            }
            catch (Exception ex)
            {
                string hata = ex.Message;

            }
            finally
            {
                
                con.Dispose();
                con.Close();
            }


        }
        public bool SetSAveOrder(Csatıs Bilgiler)
        {
            bool sonuc = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Satislar(HESAPID,URUNID,ADET,ODAID) values(@hesapNo,@UrunId,@Adet,@odaId)", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@hesapNo", SqlDbType.Int).Value = Bilgiler.HesapId;
                cmd.Parameters.Add("@Adet", SqlDbType.Int).Value = Bilgiler.Adet;
                cmd.Parameters.Add("@UrunId", SqlDbType.Int).Value = Bilgiler.UrunId;
                cmd.Parameters.Add("@odaId", SqlDbType.Int).Value = Bilgiler.OdaId;
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
        public void setDeleteOrder(int satisId)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Delete From Satislar Where ID=@SatisID", con);
            cmd.Parameters.Add("@SatisID", SqlDbType.Int).Value = satisId;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();

        }
        public decimal GenelToplamBul(int musterıId)
        {
            decimal geneltoplam = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            //"SELECT SUM(dbo.satislar.ADET * FIYAT) AS fiyat FROM dbo.müsteri INNER JOIN dbo.paketsiparis ON dbo.müsteri.ID = dbo.paketsiparis.MUSTERIID INNER JOIN dbo.satislar ON dbo.adisyonlar.ID = dbo.satislar.ADISYONID INNER JOIN dbo.urunler ON dbo.satislar.URUNID = dbo.urunler.ID WHERE(dbo.paketsiparis.MUSTERIID = 1) AND(dbo.paketsiparis.Durum = 0
            SqlCommand cmd = new SqlCommand("SELECT SUM(TOPLAMTUTAR)from hesapOdemeleri where MUSTERIID=@musteriId", con);
            cmd.Parameters.Add("musterId", SqlDbType.Int).Value = musterıId;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
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
            return geneltoplam;

        }
        


        }
    }
