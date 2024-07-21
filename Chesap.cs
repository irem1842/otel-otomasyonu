using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Otel_Otomasyonu
{
    internal class Chesap
    {
        Cgenel gnl = new Cgenel();
        private int _ID;
        private Decimal _TUTAR;
        private int _PERSONELID;
        private DateTime _TARIH;
        private int _DURUM;
        private int _ODAID;

        public int ID { get => _ID; set => _ID = value; }
        public Decimal KAPASITE { get => _TUTAR; set => _TUTAR = value; }
        public int DURUM1 { get => _DURUM; set => _DURUM = value; }

        public int ODAID { get => _ODAID; set => _ODAID = value; }
        public int PERSONELID { get => _PERSONELID; set => _PERSONELID = value; }
        public DateTime TARIH { get => _TARIH; set => _TARIH = value; }

        public int getByHesap(int OdaId)
        {

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select top 1 ID From hesaplar Where ODAID=@OdaId Order by ID desc", con);

            cmd.Parameters.Add("@OdaId", SqlDbType.Int).Value =OdaId;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                OdaId = Convert.ToInt32(cmd.ExecuteScalar());


            }
            catch (Exception ex)
            {
                string hata = ex.Message;

            }
            finally
            {

                con.Close();
            }
            return OdaId;
        }

        public bool setByAdditionNew(Chesap Bilgiler)
        {
            bool sonuc = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into hesaplar(,TARIH,PERSONELID,ODAID,Durum) values(@Tarih,@PersonelID,@OdaId,@Durum)", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
            
                cmd.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = Bilgiler.TARIH;
                cmd.Parameters.Add("@PersonelID", SqlDbType.Int).Value = Bilgiler.PERSONELID;
                cmd.Parameters.Add("@OdaId", SqlDbType.Int).Value = Bilgiler.ODAID;
                cmd.Parameters.Add("@Durum", SqlDbType.Int).Value = 0;
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
        public void hesapKapatma(int adisyonID, int durum)
        {

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update hesaplar set Durum=0 where ID=@adisyonId", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("adisyonId", SqlDbType.Int).Value = adisyonID;
                cmd.Parameters.Add("durum", SqlDbType.Int).Value = durum;
                cmd.ExecuteNonQuery();

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


        }
      
      
        
        public int RezervasyonHesapAc(Chesap bilgiler)
        {
            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into hesaplar(,TARIH,PERSONELID,MASAID) values (@TARIH,@PERSONELID,@MASAID);select scope_IDENTITY()", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                
                cmd.Parameters.Add("@TARIH", SqlDbType.DateTime).Value = bilgiler._TARIH;
                cmd.Parameters.Add("@PERSONELID", SqlDbType.Int).Value = bilgiler._PERSONELID;
                cmd.Parameters.Add("@MASAID", SqlDbType.Int).Value = bilgiler._ODAID;

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
    }
}
