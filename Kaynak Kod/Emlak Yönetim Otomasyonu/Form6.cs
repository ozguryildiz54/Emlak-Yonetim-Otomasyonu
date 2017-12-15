using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Emlak_Yönetim_Otomasyonu
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        // Sunucu baglantisi acilir. ------------------------
        SqlConnection baglan = new SqlConnection("Data Source =OZGRYLDZ54;Initial Catalog=emlak_yonetim_otomasyonu;Integrated Security=True");
        // --------------------------------------------------

        // Form5 formuna erisebilmek icin nesne turettik. ---
        Form5 nesne = new Form5();
        // --------------------------------------------------

        // Verilerin gosterildigi metotdur. -----------------
        public void verilerigoster()
        {   
            listView1.Items.Clear();
            baglan.Open();

            SqlCommand komut = new SqlCommand("Select *From kayit_tablosu",baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while(oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["adsoyad"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["mail"].ToString());
                ekle.SubItems.Add(oku["notlar"].ToString());
                ekle.SubItems.Add(oku["daire_arsa"].ToString());
                ekle.SubItems.Add(oku["metrekare"].ToString());
                ekle.SubItems.Add(oku["fiyat"].ToString());
                ekle.SubItems.Add(oku["odasayisi"].ToString());
                ekle.SubItems.Add(oku["katsayisi"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }
        // ---------------------------------------------------

        // Geri butonu. ------------------------------------------------
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form3 pencere9 = new Form3();
            pencere9.Show();
            this.Hide();
        }
        // -------------------------------------------------------------

        // Goruntule butonu. --------------------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            // Veriler gosterilir. --------------------------------------
            verilerigoster();
        }
    }
}
