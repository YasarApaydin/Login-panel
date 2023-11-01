using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace panel
{
    public partial class Login : Form
    {
        Metot metot = new Metot();
            public Login()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            textParola.Focus();

        }

        private void Login_Load(object sender, EventArgs e)
        {
            #region Combo Üyelerini Cektik
            string ConStr = "Server=localhost;DATABASE=ogrenci;UID=root;PWD=12345";
            using (var baglan =new MySqlConnection(ConStr))
            {
                using (var komut = new MySqlCommand("SELECT ad FROM ogrenci ORDER BY ad ASC", baglan))
                {
                    try
                    {
                        komut.Connection.Open();
                        MySqlDataReader dr = komut.ExecuteReader();
                        while (dr.Read())
                        {
                            comboUyeler.Items.Add(dr["ad"].ToString());
                        }

                        comboUyeler.SelectedIndex = 0;
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show(hata.Message );

                    }

                }


              /*  try {
                    baglan.Open();
                    MessageBox.Show("Veritabanına Bağlandı");
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message + "Veritabanına Bağlanamdı: Hata: ");

                }*/
            }


            #endregion
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (metot.KullaniciKontol(comboUyeler.SelectedItem.ToString(), textParola.Text) == 1)
            {
                // MessageBox.Show("Giriş Başarılı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AnaForm af = new AnaForm();
                af.lbrKullanici.Text = this.comboUyeler.Text.ToString();
                af.Text= "Merhaba "+ this.comboUyeler.Text.ToString();
                this.Hide();
                af.Show();
            }
            else
            {
                MessageBox.Show("Giriş Yapılamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }


}
