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
    public partial class Form2 : Form
    {
        public static string sifre = "sifre";// sekreter kullanicisin sifresi -------
        public static string sifre2 = "sifre";// patron kullanicisinin sifresi ------

        public Form2()
        {
            InitializeComponent();
        }

        // Sunucu baglantisi bu satırda yapilmaktadir. -------------------------------
        SqlConnection baglan = new SqlConnection("Data Source =OZGRYLDZ54;Initial Catalog=emlak_yonetim_otomasyonu;Integrated Security=True");
        // ---------------------------------------------------------------------------

        // Veri tabani islemi icin olusturulan metot kullanimi asagidaki bloklardadir. içine sql sorgusu yazilir. ---
        public void verilerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglan);
            DataSet ds = new DataSet();
            da.Fill(ds);
        }
        // ---------------------------------------------------------------------------

        // İlk forma geri döner geri donuş butonudur. --------------------------------
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 pencere2 = new Form1();
            pencere2.Show();
            this.Hide();
        }
        // -----------------------------------------------------------------------------

        // Unlem olan butonun acıklamasi. ----------------------------------------------
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Şifrenizi değiştirebilmek için size verilen gizli yanıtı kullanmanız gerekmektedir.");
        }
        // -----------------------------------------------------------------------------

        // Kullanici kontrolu ve sifre degisimi. ---------------------------------------
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "sekreter")
            {
                if (textBox3.Text == "sanane")
                {
                    baglan.Open();
                    SqlCommand komut = new SqlCommand("Update sifre set patron='" + textBox2.Text + "'", baglan);
                    komut.ExecuteNonQuery();
                    verilerigoster("Select * from kayit_tablosu");
                    baglan.Close();
                    sifre = textBox2.Text;
                    MessageBox.Show("Şifreniz başarıyla değiştirildi!");
                }
                else
                    MessageBox.Show("Gizli yanıtınızı yanlış girdiniz!");
            }
            else if (textBox1.Text == "patron")
            {
                if (textBox3.Text == "sanane")
                {
                    baglan.Open();
                    SqlCommand komut = new SqlCommand("Update sifre set patron='" + textBox2.Text + "'", baglan);
                    komut.ExecuteNonQuery();
                    verilerigoster("Select * from kayit_tablosu");
                    baglan.Close();
                    sifre2 = textBox2.Text;
                    MessageBox.Show("Şifreniz başarıyla değiştirildi!");
                }
                else
                    MessageBox.Show("Gizli yanıtınızı yanlış girdiniz!");
            }
            else
                MessageBox.Show("Kullanıcı adınızı yanlış girdiniz!");
        }
        // -----------------------------------------------------------------------------------

        // textboxlari temizler. -------------------------------------------------------------
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
        // -----------------------------------------------------------------------------------
    }
}
