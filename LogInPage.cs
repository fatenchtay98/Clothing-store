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
    public partial class LogInPage : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["databasecon"].ToString());
        string sql;
        SqlDataAdapter adapter;
        SqlCommandBuilder cmdBuilder;
        DataTable td = new DataTable();

        public LogInPage()
        {
            InitializeComponent();
        }



        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Form x in Application.OpenForms)
            {
                if (x is LogInPage)
                {
                    x.Show();
                    break;
                }
            }
            this.Close();
        }


        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Exit_Click_1(object sender, EventArgs e)
        {
            HomePage homepage = new HomePage();
            this.Close();
            homepage.Show();
        }



        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try

            {

                int t;
                String sql = "select * from Admin where username like '" + textBox1.Text + "' and password like '" + textBox2.Text + "'";//The Select query

                td.Rows.Clear();

                //Initializes a new instance of the SqlDataAdapter class with a SelectCommand and a connection string
                adapter = new SqlDataAdapter(sql, con);

                adapter.Fill(td); //Fill the SQL query results in the variable td of type table

                if (td.Rows.Count == 0)
                    MessageBox.Show("Ivalid Username/Password!");
                else
                {
                        AdminPage f = new AdminPage();
                        f.Show();
                        this.Hide();

                    }
                  
                textBox1.Clear();
                textBox2.Clear();

            }

            catch (Exception msj)
            {
                MessageBox.Show("Error!");
                MessageBox.Show(msj.ToString());

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Exit_Click_2(object sender, EventArgs e)
        {

        }
    }
}

    

