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
using static System.Net.Mime.MediaTypeNames;

namespace BankaOtomasyonu
{
    public partial class MüsteriAra : Form
    {
        public MüsteriAra()
        {
            InitializeComponent();
        }

        private void MüsteriAra_Load(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection("server= Bartu\\SQLEXPRESS ; initial catalog = bankamatik2; integrated security = sspi ");
        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select* from musteriler where ID=@p1 or tcNo = @p2 ", con);
            komut.Parameters.AddWithValue("@p1", txtAra.Text);
            komut.Parameters.AddWithValue("@p2", txtAra.Text);


            con.Open();
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                txtId.Text = dr["ID"].ToString();
                txtTcNo.Text = dr["tcNo"].ToString();
                txtAdSoyad.Text = dr["adSoyad"].ToString();
                txtAdres.Text = dr["adres"].ToString();
                txtTel.Text = dr["telefon"].ToString();
                txtBakiye.Text = dr["bakiye"].ToString();


            }
            else
            {
                MessageBox.Show(txtId.Text + "Numaralı Kayıt Bulunamadı !", " Kayıt Arama ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtId.Text = "";
                txtTcNo.Text = "";
                txtAdres.Text = "";
                txtAdSoyad.Text = "";
                txtBakiye.Text = "";
                txtTel.Text = "";
                txtId.Text = "";
            }
                    con.Close ();   

           


        }
    }
}
