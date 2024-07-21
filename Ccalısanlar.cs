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
    internal class Ccalısanlar
    {

       
            Cgenel gnl = new Cgenel();
            private int _PersonelId;
            private int _GorevId;
            private string _PersonelAd;
            private string _PersonelSoyad;
            private string _PersonelParola;
            private string _PersonelKullacıAdı;
            private bool _PersonelDurum;

            public int PersonelId { get => _PersonelId; set => _PersonelId = value; }
            public int GorevId { get => _GorevId; set => _GorevId = value; }
            public string PersoneAd { get => _PersonelAd; set => _PersonelAd = value; }
            public string PersonelSoyad { get => _PersonelSoyad; set => _PersonelSoyad = value; }
            public string PersonelParola { get => _PersonelParola; set => _PersonelParola = value; }
            public string PersonelKullacıAdı { get => _PersonelKullacıAdı; set => _PersonelKullacıAdı = value; }
            public bool PersonelDurum { get => _PersonelDurum; set => _PersonelDurum = value; }
            public bool personelGirisKontrol(string password, int personelId)
            {

                bool result = false;
                SqlConnection con = new SqlConnection(gnl.conString);
                SqlCommand cmd = new SqlCommand("Select * from çalışanlar where çalışanlar.ID=@Id or çalışanlar.PAROLA=@password", con);

                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = personelId;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                    }
                    result = Convert.ToBoolean(cmd.ExecuteScalar());
                }

                catch (SqlException ex)
                {
                    string hata = ex.Message;
                    throw;

                }
                return result;


            }
            public void personelBilGet(ComboBox cb)

            {

                cb.Items.Clear();
                SqlConnection con = new SqlConnection(gnl.conString);
                SqlCommand cmd = new SqlCommand("Select * from çalışanlar ", con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }



                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Ccalısanlar p = new Ccalısanlar();
                    p._PersonelId = Convert.ToInt32(dr["ID"]);
                    p._GorevId = Convert.ToInt32(dr["GOREVID"]);
                    p._PersonelAd = Convert.ToString(dr["AD"]);
                    p._PersonelSoyad = Convert.ToString(dr["SOYAD"]);
                    p._PersonelKullacıAdı = Convert.ToString(dr["KULLANICIADI"]);
                    p.PersonelParola = Convert.ToString(dr["PAROLA"]);
                    p._PersonelDurum = Convert.ToBoolean(dr["Durum"]);
                    cb.Items.Add(p);

                }


            }
            public override string ToString()
            {
                return PersoneAd + " " + PersonelSoyad;
            }
            public void personelBilgileriniGetirLV(ListView lv)
            {
                lv.Items.Clear();
                SqlConnection con = new SqlConnection(gnl.conString);
                SqlCommand cmd = new SqlCommand("Select  çalışanlar.ID,çalışanlar.AD,çalışanlar.SOYAD,çalışanlar.PAROLA,çalışanlar.KULLANICIADI ,çalışanlar.GOREVID,calısangörev.GÖREV from çalışanlar Inner Join calısangörev on calısangörev.ID=çalışanlar.GOREVID where çalışanlar.Durum=0 ", con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }



                SqlDataReader dr = cmd.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[i].SubItems.Add(dr["GOREVID"].ToString());
                    lv.Items[i].SubItems.Add(dr["GÖREV"].ToString());
                     lv.Items[i].SubItems.Add(dr["AD"].ToString());
                    lv.Items[i].SubItems.Add(dr["SOYAD"].ToString());
                    lv.Items[i].SubItems.Add(dr["KULLANICIADI"].ToString());
                    i++;
                }
                dr.Close();
                con.Close();

            }
            public void personelBilgileriniGetirfromIDLV(ListView lv, int personelId)
            {
                lv.Items.Clear();
                SqlConnection con = new SqlConnection(gnl.conString);
                SqlCommand cmd = new SqlCommand("Select  personeller.*,personelgörev.GOREV from personeller Inner Join personelgörev on personelgorev.ID=personeller.GOREVID where personeller.Durum=0 and personeller.ID=@personelId ", con);
                cmd.Parameters.Add("personelId", SqlDbType.Int).Value = personelId;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }



                SqlDataReader dr = cmd.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[i].SubItems.Add(dr["GOREVID"].ToString());
                    lv.Items[i].SubItems.Add(dr["GOREV"].ToString());
                    lv.Items[i].SubItems.Add(dr["AD"].ToString());
                    lv.Items[i].SubItems.Add(dr["SOYAD"].ToString());
                    lv.Items[i].SubItems.Add(dr["KULLANICIADI"].ToString());
                    i++;
                }
                dr.Close();
                con.Close();

            }
            public string personelBilgiGetirIsım(int personelId)
            {
                string sonuc = "";
                SqlConnection con = new SqlConnection(gnl.conString);
                SqlCommand cmd = new SqlCommand("Select AD from çalışanlar where   çalışanlar.ID=@personelId", con);
                cmd.Parameters.Add("@personelId", SqlDbType.Int).Value = personelId;
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    sonuc = Convert.ToString(cmd.ExecuteScalar());
                }
                catch (SqlException ex)
                {
                    string hata = ex.Message;
                    throw;
                }
                con.Close();
                return sonuc;
            }
            public bool personelŞifreDeğiştir(int personelID, string pass)
            {
                bool sonuc = false;
                SqlConnection con = new SqlConnection(gnl.conString);
                SqlCommand cmd = new SqlCommand("update çalışanlar set PAROLA=@pass where ID=@personelId", con);
                cmd.Parameters.Add("personelId", SqlDbType.Int).Value = personelID;
                cmd.Parameters.Add("pass", SqlDbType.VarChar).Value = pass;
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());

                }
                catch (SqlException ex)
                {
                    string hata = ex.Message;


                    throw;
                }
                con.Close();
                return sonuc;

            }
            public bool personelEkle(Ccalısanlar cp)
            {
                bool sonuc = false;
                SqlConnection con = new SqlConnection(gnl.conString);
                SqlCommand cmd = new SqlCommand("Insert into çalışanlar(AD,SOYAD,PAROLA,GOREVID)values(@AD,@SOYAD,@PAROLA,@GOREVID)", con);
                cmd.Parameters.Add("AD", SqlDbType.VarChar).Value = _PersonelAd;
                cmd.Parameters.Add("SOYAD", SqlDbType.VarChar).Value = _PersonelSoyad;

                cmd.Parameters.Add("PAROLA", SqlDbType.VarChar).Value = _PersonelParola;
                cmd.Parameters.Add("GOREVID", SqlDbType.Int).Value = _GorevId;


                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());


                }
                catch (SqlException ex)
                {
                    string hata = ex.Message;
                    throw;
                }
                con.Close();
                return sonuc;
            }
            public bool personelGüncelle(Ccalısanlar cp, int perId)
            {
                bool sonuc = false;
                SqlConnection con = new SqlConnection(gnl.conString);
                SqlCommand cmd = new SqlCommand("Insert into personeller(AD=@AD,SOYAD=@SOYAD,PAROLA=@PAROLA,GOREVID=@GOREVID where ID=@perId", con);
                cmd.Parameters.Add("perId", SqlDbType.Int).Value = perId;
                cmd.Parameters.Add("AD", SqlDbType.Int).Value = _PersonelAd;
                cmd.Parameters.Add("SOYAD", SqlDbType.VarChar).Value = _PersonelSoyad;
                cmd.Parameters.Add("PAROLA", SqlDbType.VarChar).Value = _PersonelParola;
                cmd.Parameters.Add("GOREVID", SqlDbType.Int).Value = _GorevId;


                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());

                }
                catch (SqlException ex)
                {
                    string hata = ex.Message;


                    throw;
                }
                con.Close();
                return sonuc;



            }
            public bool personelSil(int perId)
            {
                bool sonuc = false;
                SqlConnection con = new SqlConnection(gnl.conString);
                SqlCommand cmd = new SqlCommand("Update çalışanlar set Durum=1 where ID=@perId", con);
                cmd.Parameters.Add("perId", SqlDbType.Int).Value = perId;


                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());

                }
                catch (SqlException ex)
                {
                    string hata = ex.Message;


                    throw;
                }
                con.Close();
                return sonuc;
            }

        }

    }

