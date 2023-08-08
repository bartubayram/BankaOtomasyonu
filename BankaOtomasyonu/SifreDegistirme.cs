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
    public partial class SifreDegistirme : Form
    {
        public SifreDegistirme()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server= Bartu\\SQLEXPRESS ; initial catalog = bankamatik2; integrated security = sspi ");


        private void button1_Click(object sender, EventArgs e)
        {
            if (txtEski.Text== "" || txtYeni.Text =="")
            {
                MessageBox.Show("Lütfen Boş Alanları Girin !", "Şİfre Değiştirme işlemi");
            }
            else if (txtYeni.Text.Length < 5)
            {
                MessageBox.Show("En az 5 karakter uzunluğunda şifre belirleyiniz !", "Şİfre Değiştirme işlemi");

            }

            else
            {
                SqlCommand komut = new SqlCommand("update musteriler set sifre = @p1 where sifre= @p2  ", con);

                komut.Parameters.AddWithValue("@p1", txtYeni.Text);
                komut.Parameters.AddWithValue("@p2", txtEski.Text);


                con.Open();

                int sonuc = komut.ExecuteNonQuery();
                if (sonuc == 1)
                {
                    MessageBox.Show(" Şifre Değiştirme İşlemi Yapıldı ", " Şifre Değiştirme İşlemi ", MessageBoxButtons.OK);
                    HareketKaydet.kaydet(Form1.mId, "Şifre Değiştirildi");


                }
                else
                {
                    MessageBox.Show("  Şifre Değiştirme İşlemi Yapılamadı !", "  Şifre Değiştirme İşlemi ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                con.Close();
                txtYeni.Text = "";
                txtEski.Text = "";
            }

        }

        private void txtEski_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtYeni_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
