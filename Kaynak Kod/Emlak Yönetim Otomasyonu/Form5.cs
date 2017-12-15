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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        // Sunucu baglantisi acilir. -------------------------------------------
        SqlConnection baglan1 = new SqlConnection("Data Source =OZGRYLDZ54;Initial Catalog=emlak_yonetim_otomasyonu;Integrated Security=True");
        // ---------------------------------------------------------------------

        // Geri butonu. --------------------------------------------------------
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form3 pencere7 = new Form3();
            pencere7.Show();
            this.Hide();
        }
        // ---------------------------------------------------------------------

        // Eger arsa ile ilgili veri girersek daire ile ilgili comboboxlar in gorunumu false olur. ------------
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "-Satılık Arsa" || comboBox1.Text == "-Kiralık Arsa")
            {
                comboBox2.Visible = false;
                comboBox3.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
            }
            else
            {
                comboBox2.Visible = true;
                comboBox3.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
            }
        }
        // ----------------------------------------------------------------------------------------------------

        // Verilerin kayit yapildiği butondur. ----------------------------------------------------------------
        public void pictureBox5_Click(object sender, EventArgs e)
        {
            Form6 nesne1 = new Form6();
            baglan1.Open();
            SqlCommand komut2 = new SqlCommand("insert into kayit_tablosu(id,adsoyad,telefon,mail,notlar,daire_arsa,metrekare,fiyat,odasayisi,katsayisi) values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox7.Text.ToString() + "','" + comboBox2.Text.ToString() + "','" + comboBox3.Text.ToString() + "')", baglan1);
            komut2.ExecuteNonQuery();
            baglan1.Close();
            MessageBox.Show("Kayıt işlemi başarılı bir şekilde yapılmıştır.");
        }
        // ----------------------------------------------------------------------------------------------------

        // textboxlari temizler. ------------------------------------------------------------------------------
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox1.Clear();
        }
        // -----------------------------------------------------------------------------------------------------

        // Sira numarasi kismina harf girmesini engeller. ------------------------------------------------------
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        // -----------------------------------------------------------------------------------------------------

        // Telefon numarasi kismina harf girmesini engeller. ---------------------------------------------------
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        // -----------------------------------------------------------------------------------------------------

        // Adsoyad kismina rakam girmesini engeller. -----------------------------------------------------------
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }
        // -----------------------------------------------------------------------------------------------------

        // Metrekare kismina sadece sayi girmeyi saglar. -------------------------------------------------------
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
        // -----------------------------------------------------------------------------------------------------

        // Fiyat kismina sadece sayi girmeyi saglar. -------------------------------------------------------
        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
        // -----------------------------------------------------------------------------------------------------
    }
}
