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


namespace BankaOtomasyonu
{
    public partial class Havale : Form
    {
        public Havale()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server= Bartu\\SQLEXPRESS ; initial catalog = bankamatik2; integrated security = sspi ");

        private void button1_Click(object sender, EventArgs e)
        {

            float sayi = float.Parse(txtMiktar.Text);

            if (sayi > Form1.mBakiye)
            {
                MessageBox.Show("Yetersiz Bakiye !", "Havale işlemi");

            }
            else
            {
                SqlCommand komut = new SqlCommand("update musteriler set bakiye = bakiye - @p1  where ID= @p2  ", con);
                komut.Parameters.AddWithValue("@p1", sayi);
                komut.Parameters.AddWithValue("@p2", Form1.mId);

                SqlCommand komut2 = new SqlCommand("update musteriler set bakiye =bakiye + @p3  where ID= @p4  ", con);
                komut2.Parameters.AddWithValue("@p3", txtMiktar.Text);
                komut2.Parameters.AddWithValue("@p4", TxtNo.Text);


                if (sayi < 10)
                {
                    MessageBox.Show("Lütfen 10 TL ve üzeri giriniz !", "Eksik Kayıt Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    con.Open();

                    int sonuc1 = komut2.ExecuteNonQuery();
                    con.Close();
                    if (sonuc1 == 1)
                    {
                        con.Open();
                        komut.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("havale işlemi gerçekleştirildi", "Havale / EFT ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form1.mBakiye -= sayi;
                        HareketKaydet.kaydet(Form1.mId, (sayi + " TL Havale Gönderildi"));
                        HareketKaydet.kaydet(int.Parse(TxtNo.Text) , (sayi + " TL Havale Alındı"));



                    }
                    else
                    {
                        MessageBox.Show("Alıcı HEsap NO Hatalı !", "Havale/EFT Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }





            }
            txtMiktar.Text = "";
            TxtNo.Text = "";
        }

        private void Havale_Load(object sender, EventArgs e)
        {

        }
    }
}
