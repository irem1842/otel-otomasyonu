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
    internal class Codeme
    {
        Cgenel gnl = new Cgenel();
        private int _ÖdemeId;
        private int _AdisyonId;
        private int _OdemeTurId;
        private decimal _AraToplam;
        private decimal _Indırım;
        private decimal _KdvTutarı;
        private decimal _GenelToplam;
        private DateTime _Tarih;
        private int _MusterıId;

        public int ÖdemeId { get => _ÖdemeId; set => _ÖdemeId = value; }
        public int AdisyonId { get => _AdisyonId; set => _AdisyonId = value; }
        public int OdemeTurId { get => _OdemeTurId; set => _OdemeTurId = value; }
        public decimal AraToplam { get => _AraToplam; set => _AraToplam = value; }
        public decimal Indırım { get => _Indırım; set => _Indırım = value; }
        public decimal KdvTutarı { get => _KdvTutarı; set => _KdvTutarı = value; }
        public decimal GenelToplam { get => _GenelToplam; set => _GenelToplam = value; }
        public DateTime Tarih { get => _Tarih; set => _Tarih = value; }
        public int MusterıId { get => _MusterıId; set => _MusterıId = value; }

        public bool bilKapat(Codeme bil)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into hesapOdemeleri(HESAPID,ODEMETURID,MUSTERIID, INDIRIM,ARATOPLAM,KDVTUTARI,TOPLAMTUTAR)values(@ADISYONID,@ODEMETURID,@MUSTERIID,@ARATOPLAM,@INDIRIM,@KDVTUTARI,@TOPLAMTUTAR)", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@HESAPID", SqlDbType.Int).Value = bil._AdisyonId;
                cmd.Parameters.Add("@ODEMETURID", SqlDbType.Int).Value = bil._OdemeTurId;
                cmd.Parameters.Add("@MUSTERIID", SqlDbType.Int).Value = bil._MusterıId;
                cmd.Parameters.Add("@ARATOPLAM", SqlDbType.Money).Value = bil._AraToplam;
                cmd.Parameters.Add("@KDVTUTARI", SqlDbType.Money).Value = bil._KdvTutarı;
                cmd.Parameters.Add("@INDIRIM", SqlDbType.Money).Value = bil._Indırım;
                cmd.Parameters.Add("@TOPLAMTUTAR", SqlDbType.Money).Value = bil._GenelToplam;

                result = Convert.ToBoolean(cmd.ExecuteNonQuery());

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
        public decimal müsteriToplamHar(int clientId)
        {
            decimal total = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select sum(TOPLAMTUTAR)as total from hesapOdemeleri Where MUSTERIID=@clientId", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("clientId", SqlDbType.Int).Value = clientId;
                total = Convert.ToDecimal(cmd.ExecuteScalar());

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
            return total;


        }

    }
}

