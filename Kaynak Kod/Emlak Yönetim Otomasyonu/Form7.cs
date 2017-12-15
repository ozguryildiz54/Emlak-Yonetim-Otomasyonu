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
    public partial class Form7 : Form
    {
        public int kontrol = 0;
        public Form7()
        {
            InitializeComponent();
        }
        // Sunucu baglantisi acilir. ------------------------------------
        SqlConnection baglan = new SqlConnection("Data Source =OZGRYLDZ54;Initial Catalog=emlak_yonetim_otomasyonu;Integrated Security=True");
        // --------------------------------------------------------------

        // Geri butonu. -------------------------------------------
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form4 pencere = new Form4();
            pencere.Show();
            this.Hide();
        }
        // --------------------------------------------------------

        // Veritabani islemi yapabilmek icin icine sorgu yazdigimiz metotdur. --------
        public void verilerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglan);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        // ---------------------------------------------------------------------------

        // Goruntule butonu verileri gosterir. --------------------------------------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            verilerigoster("Select * from kayit_tablosu");
        }
        // --------------------------------------------------------------------------------------------

        // Sil butonu ile silme islemi yapilir. -------------------------------------------------------
        private void button4_Click(object sender, EventArgs e)
        {
            if(kontrol==1)
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("delete from kayit_tablosu where (id=@idi) or (adsoyad=@adsoyadi) or (telefon=@telefoni) or (mail=@maili) or (notlar=@notlari) or (daire_arsa=@daire_arsai) or (metrekare=@metrekarei) or (fiyat=@fiyati) or (odasayisi=@odasayisii) or (katsayisi=@katsayisii) or (satis_durumu=@satis_durumui)", baglan);
                komut.Parameters.AddWithValue("@adsoyadi", textBox1.Text);
                komut.Parameters.AddWithValue("@idi", textBox1.Text);
                komut.Parameters.AddWithValue("@telefoni", textBox1.Text);
                komut.Parameters.AddWithValue("@maili", textBox1.Text);
                komut.Parameters.AddWithValue("@notlari", textBox1.Text);
                komut.Parameters.AddWithValue("@daire_arsai", textBox1.Text);
                komut.Parameters.AddWithValue("@metrekarei", textBox1.Text);
                komut.Parameters.AddWithValue("@fiyati", textBox1.Text);
                komut.Parameters.AddWithValue("@odasayisii", textBox1.Text);
                komut.Parameters.AddWithValue("@katsayisii", textBox1.Text);
                komut.Parameters.AddWithValue("@satis_durumui", textBox1.Text);


                komut.ExecuteNonQuery();
                verilerigoster("Select * from kayit_tablosu");
                baglan.Close();
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Silme işlemi için önce neyi silmek istediğinizi sağ köşeden arayınız.");
            }
            kontrol = 0;
        }
        // -------------------------------------------------------------------------------------------------------------

        // Duzelt butonu ile duzeltme islemi yapilir. -----------------------------------------------------
        private void button3_Click(object sender, EventArgs e)
        {
            if (kontrol == 1)
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("Update kayit_tablosu set adsoyad='" + textBox3.Text + "',telefon='" + textBox4.Text + "',mail='" + textBox5.Text + "',notlar='" + textBox8.Text + "',daire_arsa='" + comboBox1.Text + "',metrekare='" + textBox6.Text + "',fiyat='" + textBox7.Text + "',odasayisi='" + comboBox2.Text + "',katsayisi='" + comboBox3.Text + "',satis_durumu='" + textBox9.Text + "' where (id like '%" + textBox1.Text + "%') or (adsoyad like '%" + textBox1.Text + "%') or (telefon like '%" + textBox1.Text + "%') or (mail like '%" + textBox1.Text + "%') or (notlar like '%" + textBox1.Text + "%') or (daire_arsa like '%" + textBox1.Text + "%') or (metrekare like '%" + textBox1.Text + "%') or (fiyat like '%" + textBox1.Text + "%') or (odasayisi like '%" + textBox1.Text + "%') or (katsayisi like '%" + textBox1.Text + "%') or (satis_durumu like '%" + textBox1.Text + "%')", baglan);
                komut.ExecuteNonQuery();
                verilerigoster("Select * from kayit_tablosu");
                baglan.Close();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
            }
            else
            {
                MessageBox.Show("Düzeltme işlemi için önce neyi düzeltmek istediğinizi sağ köşeden arayınız.");
            }
            kontrol = 0;
        }
        // ----------------------------------------------------------------------------------------------------

       // Arama textboxini temizler. ------------------------------------
        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
        // --------------------------------------------------------------

        // Kayit ara butonu ile herhangi bir nitelik degeri aranabilir. -------------------------------------------
        public void button1_Click(object sender, EventArgs e)
        {

            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from kayit_tablosu where (id like '%" + textBox1.Text + "%') or (adsoyad like '%" + textBox1.Text + "%') or (telefon like '%" + textBox1.Text + "%') or (mail like '%" + textBox1.Text + "%') or (notlar like '%" + textBox1.Text + "%') or (daire_arsa like '%" + textBox1.Text + "%') or (metrekare like '%" + textBox1.Text + "%') or (fiyat like '%" + textBox1.Text + "%') or (odasayisi like '%" + textBox1.Text + "%') or (katsayisi like '%" + textBox1.Text + "%') or (satis_durumu like '%" + textBox1.Text + "%')", baglan);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglan.Close();
            kontrol = 1;
        }
        // -----------------------------------------------------------------------------------------------------------

        // Duzeltme islemi icin kullanilir. --------------------------------------------------------------------------
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            string id = dataGridView1.Rows[secilialan].Cells[0].Value.ToString();
            string ad = dataGridView1.Rows[secilialan].Cells[1].Value.ToString();
            string telefon = dataGridView1.Rows[secilialan].Cells[2].Value.ToString();
            string mail = dataGridView1.Rows[secilialan].Cells[3].Value.ToString();
            string notlar = dataGridView1.Rows[secilialan].Cells[4].Value.ToString();
            string daire_arsa = dataGridView1.Rows[secilialan].Cells[5].Value.ToString();
            string metrekare = dataGridView1.Rows[secilialan].Cells[6].Value.ToString();
            string fiyat = dataGridView1.Rows[secilialan].Cells[7].Value.ToString();
            string odasayisi = dataGridView1.Rows[secilialan].Cells[8].Value.ToString();
            string katsayisi = dataGridView1.Rows[secilialan].Cells[9].Value.ToString();
            string satis_durumu = dataGridView1.Rows[secilialan].Cells[10].Value.ToString();

            textBox2.Text = id;
            textBox3.Text = ad;
            textBox4.Text = telefon;
            textBox5.Text = mail;
            textBox6.Text = metrekare;
            textBox7.Text = fiyat;
            textBox8.Text = notlar;
            comboBox1.Text = daire_arsa;
            comboBox2.Text = odasayisi;
            comboBox3.Text = katsayisi;
            textBox9.Text = satis_durumu;
        }
        // ---------------------------------------------------------------------------------------------------

        // Bilgilendirme (Unlem) butonu. ---------------------------------------------------------------------
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("İslem yapmak istediginiz butona tıklayarak istediginiz islemi yapabilirsiniz.");
        }
        // ---------------------------------------------------------------------------------------------------

        // Duzeltme islemi icin textboxlari temizler. --------------------------------------------------------

        private void textBox1_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            textBox6.Clear();
        }

        private void textBox9_Click(object sender, EventArgs e)
        {
            textBox9.Clear();
        }

        private void textBox7_Click(object sender, EventArgs e)
        {
            textBox7.Clear();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();

        }
        // ----------------------------------------------------------------------------------------------------
    }
}
