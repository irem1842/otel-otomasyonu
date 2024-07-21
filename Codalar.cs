using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Otel_Otomasyonu
{
    internal class Codalar
    {
        private int _ID;
        private int _KAPASITE;
        private int _DURUM;
        private int _ONAY;
        private string _OdaBİlgi;

        public int ID { get => _ID; set => _ID = value; }
        public int KAPASITE { get => _KAPASITE; set => _KAPASITE = value; }
        public int DURUM { get => DURUM1; set => DURUM1 = value; }
        public int DURUM1 { get => _DURUM; set => _DURUM = value; }
        public int ONAY { get => _ONAY; set => _ONAY = value; }
        public string OdaBilgi { get => _OdaBİlgi; set => _OdaBİlgi = value; }

        Cgenel gnl = new Cgenel();
        public string oda(int state, string ODAID)
        {
            string dt = "";
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand(" Select  TARiH,ODAID from hesaplar Right Join odalar on hesaplar.ODAID=odalar.ID Where odalar.DURUM=@durum and hesaplar.Durum=0 and odalar.ID=@odaID ", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("durum", SqlDbType.Int).Value = state;
            cmd.Parameters.Add("odaID", SqlDbType.Int).Value = Convert.ToInt32(ODAID);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dt = Convert.ToDateTime(dr["TARIH"]).ToString();
                }

            }
            catch (Exception ex)
            {
                string hata = ex.Message;

                throw;

            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }
            return dt;

        }
        public int TabloNoGetir(string TableValue)
        {
            string aa = TableValue;
            int length = aa.Length;
            return Convert.ToInt32(aa.Substring(length - 1, 1));
        }
        public bool TableGetbyState(int ButtonName, int state)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select durum From odalar Where Id=@OdaId and DURUM=@state", con);
            cmd.Parameters.Add("@OdaId", SqlDbType.Int).Value = ButtonName;
            cmd.Parameters.Add("@state", SqlDbType.Int).Value = state;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                result = Convert.ToBoolean(cmd.ExecuteScalar());



            }
            catch (Exception ex)
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
        public void setChangeTableState(string ButtonName, int state)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update odalar Set DURUM=@Durum where ID=@OdaNo", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                string aa = ButtonName;
                int uzunluk = aa.Length;
                cmd.Parameters.Add("@Durum", SqlDbType.Int).Value = state;
                cmd.Parameters.Add("OdaNo", SqlDbType.Int).Value = aa.Substring(uzunluk - 1, 1);
                cmd.ExecuteNonQuery();
                con.Dispose();
                con.Close();
            }
        }
        public void OdaKapatitesiDurumGetir(ComboBox co)
        {
            co.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from odalar", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                Codalar c = new Codalar();
                string DURUM = "";
                if (c._DURUM == 2)
                    DURUM = "DOLU";
                else if (c._DURUM == 3)
                    DURUM = "REZERVE";
                c._KAPASITE =Convert.ToInt32(dr["KAPASiTE"]);
                c._OdaBİlgi = "Oda No: " + dr["ID"].ToString() + "Kapasite: " + dr["KAPASiTE"].ToString();
                c._ID = Convert.ToInt32(dr["ID"]);
                co.Items.Add(c);

            }


            con.Dispose();
            con.Close();




        }
        public override string ToString()
        {
            return _OdaBİlgi;
        }
    }
}
