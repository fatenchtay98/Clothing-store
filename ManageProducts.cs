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
using System.IO;


namespace TEST
{
    public partial class ManageProducts : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["databasecon"].ToString());
        string sql;
        SqlDataAdapter adapter;
        SqlCommandBuilder cmdBuilder;
        SqlCommand cmd;
        DataTable td = new DataTable();
        public ManageProducts()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewProduct f = new NewProduct();
            this.Close();
            f.Show();
        }


        private void ManageProducts_Load(object sender, EventArgs e)
        {
            sql = "select * from Products";
            td.Rows.Clear();
            con.Open();
            adapter = new SqlDataAdapter(sql, con);

            adapter.Fill(td);

            con.Close();

            dataGridView1.DataSource = td;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sql = "select pro_id, pro_name, pro_quantity, pro_price, category_name,  pro_description, pro_image FROM Products WHERE pro_name like '%" + textBox1.Text + "%'";
            td.Rows.Clear();
            con.Open();//Open the connection
            adapter = new SqlDataAdapter(sql, con); //Initializes a new instance of the SqlDatAdapter class with the specified SqlCommand and a SqlConnection object
            adapter.Fill(td); //Fill the SQL query results in the variable td of type table
            con.Close();//Close the connection once done
            dataGridView1.DataSource = td;
        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
              
                cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(td);
                MessageBox.Show("Update Done Successfully");

            }
            catch (Exception msj)
            {
                MessageBox.Show("Error!");
                MessageBox.Show(msj.ToString());

            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            this.Close();
            adminPage.Show();

        }
    }
}
       
    

