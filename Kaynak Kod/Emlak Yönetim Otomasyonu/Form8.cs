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
    public partial class Form8 : Form
    {
        public int kontrol = 0;

        public Form8()
        {
            InitializeComponent();
            //Form acildigi anda veriler gosterilir. ---
            verilerigoster("Select * from kasa");
            // -----------------------------------------
        }

        // Sunucu baglantisi acilir. ---------------------------------------
        SqlConnection baglan = new SqlConnection("Data Source =OZGRYLDZ54;Initial Catalog=emlak_yonetim_otomasyonu;Integrated Security=True");
        // -----------------------------------------------------------------

        // Verileri gosterebilmek icin sorgu yazabildigimiz metot. ---------
        public void verilerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglan);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        // -----------------------------------------------------------------

        // Geri butonu. ----------------------------------------------------
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form4 pencere = new Form4();
            pencere.Show();
            this.Hide();
        }
        // -----------------------------------------------------------------

        // Kayit ara butonu ile kayit aranir. ------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from kasa where (numara like '%" + textBox1.Text + "%') or (gelir_gider like '%" + textBox1.Text + "%') or (tutar like '%" + textBox1.Text + "%') or (notlar like '%" + textBox1.Text + "%')", baglan);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglan.Close();
            kontrol = 1;
        }
        // -----------------------------------------------------------------

        // Sil butonu ile silme islemi yapilir. ----------------------------
        private void button4_Click(object sender, EventArgs e)
        {
            if (kontrol == 1)
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("delete from kasa where (numara=@no) or (gelir_gider=@gelir_gideri) or (tutar=@tutari) or (notlar=@notlari)", baglan);
                komut.Parameters.AddWithValue("@no", textBox1.Text);
                komut.Parameters.AddWithValue("@gelir_gideri", textBox1.Text);
                komut.Parameters.AddWithValue("@tutari", textBox1.Text);
                komut.Parameters.AddWithValue("@notlari", textBox1.Text);

                komut.ExecuteNonQuery();
                verilerigoster("Select * from kasa");
                baglan.Close();
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Silme işlemi için önce neyi silmek istediğinizi sağ köşeden arayınız.");
            }
            kontrol = 0;
        }
        // ------------------------------------------------------------------

        // Veritabanina veri girisi yapar. ----------------------------------
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut2 = new SqlCommand("insert into kasa(numara,gelir_gider,tutar,notlar) values('"  + textBox2.Text.ToString() + "','" + comboBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox8.Text.ToString() +  "')", baglan);
            komut2.ExecuteNonQuery();
            baglan.Close();
            dataGridView1.Refresh();
            verilerigoster("Select * from kasa");
            MessageBox.Show("Kayıt işlemi başarılı bir şekilde yapılmıştır.");
            textBox2.Clear();
            textBox3.Clear();
            textBox8.Clear();
            comboBox2.Text = "";
        }
        // ------------------------------------------------------------------

        // Numara textboxina sadece sayi girmeyi saglar.
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
        // ------------------------------------------------------------------

        // Bilgilendirme (unlem) butonu. --------------------------------------------
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu pencerede her turlu gelir gider kaydı yapabilirsiniz.");
        }

        // Odeme tutari textboxina sadece sayi girmeyi saglar. -----------------------
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
        // ----------------------------------------------------------------------------
    }
}
