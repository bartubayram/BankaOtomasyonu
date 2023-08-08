using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BankaOtomasyonu
{
    public partial class MusteriEkle : Form
    {
        public MusteriEkle()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("server= Bartu\\SQLEXPRESS ; initial catalog = bankamatik2; integrated security = sspi ");


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into musteriler(tcNO,adSoyad,adres,telefon,sifre,bakiye,durum) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7) ", con);
            komut.Parameters.AddWithValue("@p1", txtTcNo.Text);
            komut.Parameters.AddWithValue("@p2", txtAdSoyad.Text);
            komut.Parameters.AddWithValue("@p3", txtAdres.Text);
            komut.Parameters.AddWithValue("@p4", txtTel.Text);
            komut.Parameters.AddWithValue("@p5", txtTcNo.Text);

            komut.Parameters.AddWithValue("@p6", txtBakiye.Text);
            komut.Parameters.AddWithValue("@p7", 1);


            if (txtTcNo.Text == "" || txtAdSoyad.Text == "" || txtAdres.Text == "" || txtTel.Text == "" || txtBakiye.Text == "")
            {

                MessageBox.Show("Tüm Alanları Eksiksiz Girin !", "Müşteri Kayıt Hatası ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }   
            else
            {
                con.Open();
                  int sonuc = komut.ExecuteNonQuery();
                con.Close();
                if (sonuc == 1)
                    MessageBox.Show("Yeni Müşteri Kaydı Tamam", "Müşteri Kaydı");
                else
                    MessageBox.Show("Kayıt Yapılamadı !", "Müşteri Kayıt Hatası ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            txtTcNo.Text = "";
            txtAdSoyad.Text= "";
            txtAdres.Text  = "";
            txtTel.Text = "";
            txtBakiye.Text = "";



        }
    }
}
