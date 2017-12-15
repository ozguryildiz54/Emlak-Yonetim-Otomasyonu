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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        // Geri butonu. ---------------------------------------------
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1 pencere5 = new Form1();
            pencere5.Show();
            this.Hide();
        }
        // ----------------------------------------------------------

        // Yonetici islemleri penceresi acilir. ---------------------
        private void button1_Click(object sender, EventArgs e)
        {
            Form7 pencere = new Form7();
            pencere.Show();
            this.Hide();
        }
        // ----------------------------------------------------------

        // Kasa islemleri penceresi acilir. -------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            Form8 pencere = new Form8();
            pencere.Show();
            this.Hide();
        }
        // ----------------------------------------------------------
    }
}
