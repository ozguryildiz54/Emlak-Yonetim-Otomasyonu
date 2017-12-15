using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emlak_Yönetim_Otomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Kullanıcı giriş dogrulamasi bu blokta yapılmaktadir. --------------------------------

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "sekreter")
            {
                if (textBox2.Text == Form2.sifre)
                {
                    Form3 pencere3 = new Form3();
                    pencere3.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Şifrenizi yanlış girdiniz!");
            }
            else if (textBox1.Text == "patron")
            {
                if (textBox2.Text == Form2.sifre)
                {
                    Form4 pencere4 = new Form4();
                    pencere4.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Şifrenizi yanlış girdiniz!");
            }
            else
                MessageBox.Show("Kullanıcı adınızı yanlış girdiniz!");
        }
        // ------------------------------------------------------------------------------------

        private void label3_Click(object sender, EventArgs e)
        {
            // Bu blokta sifre yenileme penceresi acilmaktadir.
            Form2 pencere1 = new Form2();
            pencere1.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            // Bu blokta textbox uzerinde ki veriler temizlenir.
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
