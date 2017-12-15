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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        // Unlem (bilgilendirme) butonu aciklamasi. ----------------------------------------------
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Daire veya Arsa Kaydı yap butonuna tıklayarak yeni\ndaire veya arsa kaydı yapabilirsiniz.\nKayıt göster butonuna tıklayarak kayıtlı daire ve arsaların\ntanıtımını müşterilere yapabilirsiniz.");
        }
        // ---------------------------------------------------------------------------------------

        // Geri butonu. --------------------------------------------------------------------------
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1 pencere4 = new Form1();
            pencere4.Show();
            this.Hide();
        }
        // ----------------------------------------------------------------------------------------

        // Kayitlarin gosterildigi pencere acilir. ------------------------------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            Form5 pencere6 = new Form5();
            pencere6.Show();
            this.Hide();
        }
        // ----------------------------------------------------------------------------------------

        // Kayitlarin yapildigi pencere acilir. ---------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            Form6 pencere8 = new Form6();
            pencere8.Show();
            this.Hide();
        }
        // ----------------------------------------------------------------------------------------
    }
}
