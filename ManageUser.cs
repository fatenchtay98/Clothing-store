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
using System.Configuration;

namespace TEST
{
    public partial class ManageUser : Form
    {

        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["databasecon"].ToString());
        string sql;
        SqlDataAdapter adapter;
        SqlCommandBuilder cmdBuilder;
        SqlCommand cmd;
        DataTable td = new DataTable();
        string imglocation;
        string sql2;
        public ManageUser()
        {
            InitializeComponent();
        }

    

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(td);
                MessageBox.Show("updated!");
            }
            catch (Exception msj)
            {

                MessageBox.Show("Error!");
                MessageBox.Show(msj.ToString());

            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            try
            {
                string sql = "select id, username,phone  FROM Admin";
                td.Rows.Clear();
                adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(td);
                dataGridView1.DataSource = td;
            }
            catch (Exception msj)
            {

                MessageBox.Show("Error!");
                MessageBox.Show(msj.ToString());

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            this.Close();
            adminPage.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
