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
    public partial class ManageCategory : Form
    {
        //Prepare the con variable
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["databasecon"].ToString());

        //This variable will be used to retrieve/update a database         
        SqlDataAdapter adapter;

        DataTable td = new DataTable();//Declare a variable td of type table
        DataTable td1 = new DataTable();//Declare a variable td of type table
        private SqlCommandBuilder cmdBuilder;

        public ManageCategory()
        {
            InitializeComponent();
        }

        private void ManageCategory_Load(object sender, EventArgs e)
        {
            try { 
            String sql2 = "select CategoryID, CategoryName FROM Category ";//The Select query
            td1.Rows.Clear();//Clear the content of the variable td of type table

            //Initializes a new instance of the SqlDataAdapter class with a SelectCommand and a connection string
            adapter = new SqlDataAdapter(sql2, con);

            adapter.Fill(td1); //Fill the SQL query results in the variable td of type table
            dataGridView1.DataSource = td1;
        }
            catch (Exception msj)
            {
                MessageBox.Show("Error!");
                MessageBox.Show(msj.ToString());

            }
       }

        

        private void update_Click_1(object sender, EventArgs e)
        {
            try
            {
                //Initializes a new instance of the SqlCommandBuilder class with the associated SqlDataAdapter object
                //Automatically generates commands that are used to reconcile changes made to a DataSet with the associated SQL Server database
                cmdBuilder = new SqlCommandBuilder(adapter);

                //Calls the respective Insert, Update and Delete statements for each inserted, updated, or deleted row in the specified table
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

        private void button1_Click(object sender, EventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            this.Close();
            adminPage.Show();
        }
    }
}
