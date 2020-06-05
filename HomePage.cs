using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEST
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {

        }


       

       

        private void button7_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            LogInPage f = new LogInPage();
            f.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            ContactUs C = new ContactUs();
            C.Show();
            this.Hide();
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

            if (panel1.Height == 348 && panel1.Width == 171)
            {

                panel1.Height = 417;
                panel1.Width = 42;
            }
            else
            {
                panel1.Height = 348;
                panel1.Width = 171;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Shoes S = new Shoes();
            S.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Accessories A = new Accessories();
            A.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MenProducts f = new MenProducts();
            f.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WomenProducts f = new WomenProducts();
            f.Show();
            this.Hide();
        }
    }
}
