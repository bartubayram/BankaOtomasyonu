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
    public partial class HesapHareket : Form
    {
        public HesapHareket()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server= Bartu\\SQLEXPRESS ; initial catalog = bankamatik2; integrated security = sspi ");

        private void HesapHareket_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from hareketler where musteriId = @p1  ", con);
            komut.Parameters.AddWithValue("@p1", Form1.mId);



            SqlDataAdapter da = new SqlDataAdapter( komut );
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;

            
        }
    }
}
