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
    public partial class ParaYatir : Form
    {
        public ParaYatir()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server= Bartu\\SQLEXPRESS ; initial catalog = bankamatik2; integrated security = sspi ");

        private void button1_Click(object sender, EventArgs e)
        {

            float sayi = float.Parse(maskedTextBox1.Text);
            if (int.Parse(maskedTextBox1.Text) < 10)
            {
                MessageBox.Show("Lütfen En Az 10 TL Yatırınız !", "Para Yatırma işlemi");
            }
            else
            {
                SqlCommand komut = new SqlCommand("update musteriler set bakiye += @p1 where ID= @p2  ", con);

                komut.Parameters.AddWithValue("@p1", sayi);
                komut.Parameters.AddWithValue("@p2", Form1.mId);


                con.Open();

                int sonuc = komut.ExecuteNonQuery();
                if (sonuc == 1)
                {
                    MessageBox.Show(" Para Yatırma İşlemi Yapıldı ", " Para Yatırma İşlemi ", MessageBoxButtons.OK);
                    Form1.mBakiye += sayi;
                    HareketKaydet.kaydet(Form1.mId,( sayi +  " TL Para Yatırıldı"));
                }
                else
                {
                    MessageBox.Show(" Para Yatırma İşlemi Yapılamadı !", " Para Yatırma İşlemi ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                con.Close();
                maskedTextBox1.Text = "";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
