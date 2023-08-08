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
    public partial class SifreUret : Form
    {
        public SifreUret()
        {
            InitializeComponent();
        }

        private void txtEski_TextChanged(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection("server= Bartu\\SQLEXPRESS ; initial catalog = bankamatik2; integrated security = sspi ");

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtTC.Text == "" || txtTel.Text == "" || txtSifre.Text == "")
            {
                MessageBox.Show("Lütfen Boş Alanları Girin !", "Şİfre Üretme işlemi");
            }
            else if (txtSifre.Text.Length < 5)
            {
                MessageBox.Show("En az 5 karakter uzunluğunda şifre belirleyiniz !", "Şİfre Üretme işlemi");

            }

            else
            {
                SqlCommand komut = new SqlCommand("update musteriler set sifre = @p1 where tcNo= @p2 and telefon = @p3 ", con);

                komut.Parameters.AddWithValue("@p1", txtSifre.Text);
                komut.Parameters.AddWithValue("@p2", txtTC.Text);
                komut.Parameters.AddWithValue("@p3", txtTel.Text);


                 
                con.Open();

                int sonuc = komut.ExecuteNonQuery();
                if (sonuc == 1)
                {
                    MessageBox.Show(" Şifre Üretme İşlemi Yapıldı ", " Şifre Üretilme İşlemi ", MessageBoxButtons.OK);
                    HareketKaydet.kaydet(Form1.mId, "Şifre Üretildi"); 


                }
                else
                {
                    MessageBox.Show("  Şifre Üretme İşlemi Yapılamadı !", "  Şifre Üretme İşlemi ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                con.Close();
                txtSifre.Text = "";
                txtTC.Text = "";
                txtTel.Text = "";
            }

        }
    }
}
