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
    public partial class AdminPage : Form
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void AdminPage_Load(object sender, EventArgs e)
        {

        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ManageProducts f = new ManageProducts();
            f.Show();
            this.Hide();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ManageCategory m = new ManageCategory();
            m.Show();
            this.Hide();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ManageOrder m = new ManageOrder();
            m.Show();
            this.Hide();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ManageUser f = new ManageUser();
            f.Show();
            this.Hide();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}