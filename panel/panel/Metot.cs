using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace panel
{
    public class Metot
    {
        #region kullanıcı kontrol
        string ConStr = "Server=localhost;DATABASE=ogrenci;UID=root;PWD=12345";

        public int KullaniciKontol(string kAd, string kSifre) {
            int sonuc = 0;
            using (var con = new MySqlConnection(ConStr))
            {
                using (var cmd = new MySqlCommand($"SELECT ad, parola FROM ogrenci WHERE ad='{kAd}' and parola='{kSifre}' ", con)) {


                    try
                    {
                        cmd.Connection.Open();
                        MySqlDataReader dtr = cmd.ExecuteReader();
                        if (dtr.Read()) {
                            string d_k = dtr["ad"].ToString();
                            string d_s = dtr["parola"].ToString();
                            if (d_k==kAd && d_s == kSifre)
                            {

                                sonuc = 1;
                            }else
                            {
                                sonuc = 0;
                            }
                        }


                    }catch
                    {
                        sonuc = 0;
                    }
                }
            
            }



            return sonuc;

                }




        #endregion
    }
}