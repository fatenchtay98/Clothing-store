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
    public partial class WomenProducts : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["databasecon"].ToString());
        string sql;
        SqlDataAdapter adapter;
        SqlCommandBuilder cmdBuilder;
        SqlCommand cmd;
        DataTable td = new DataTable();
        DataTable td1 = new DataTable();
        DataTable td2 = new DataTable();
        public WomenProducts()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                sql = "select * from Products where category_name = 1 ";
                td.Rows.Clear();

                string sql1 = "select pro_id, pro_description, pro_image from Products";
                td1.Rows.Clear();

                adapter = new SqlDataAdapter(sql, con);

                adapter.Fill(td); //Fill the SQL query results in the variable td of type table

                adapter = new SqlDataAdapter(sql1, con);
                adapter.Fill(td1);
                dataGridView1.DataSource = td;
            }
            catch (Exception msj)
            {
                MessageBox.Show("Error!");
                MessageBox.Show(msj.ToString());

            }
            try
            {

                int i;
                String sql = "select TypeID, TypeName from Type";//The Select query
                td2.Rows.Clear();//Clear the content of the variable td of type table

                //Initializes a new instance of the SqlDataAdapter class with a SelectCommand and a connection string
                adapter = new SqlDataAdapter(sql, con);

                adapter.Fill(td2); //Fill the SQL query results in the variable td of type table

                for (i = 0; i < td2.Rows.Count; i++)
                    comboBox1.Items.Add(td2.Rows[i]["TypeName"]);



            }
            catch (Exception msj)
            {
                MessageBox.Show("Error!");
                MessageBox.Show(msj.ToString());

            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {

                int i, target = -1;

                //this statement will retrieve the value in the selected cell in dataGridView1
                int x = Int32.Parse(dataGridView1.SelectedCells[0].Value.ToString());
                //     MessageBox.Show(x.ToString());

                //      MessageBox.Show(td.Rows.Count.ToString());

                //search for the image that corresponds to the selected image id stored in x
                for (i = 0; i < td.Rows.Count; i++)
                    if (Int32.Parse(td1.Rows[i]["pro_id"].ToString()) == x)
                        target = i;


                richTextBox1.Text = td1.Rows[target]["pro_description"].ToString();

                //piece of code used to convert an image in its binary representation into an image  
                byte[] imsource = (byte[])td1.Rows[target]["pro_image"];

                Bitmap image;

                using (MemoryStream stream = new MemoryStream(imsource))
                {
                    image = new Bitmap(stream);

                }
                pictureBox1.Image = image;
            }
            catch (Exception msj)
            {
                MessageBox.Show("Error: Choose a cell from the first column only!");
                MessageBox.Show(msj.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable td2 = new DataTable();
            DataTable td3 = new DataTable();
            String sql = "select TypeID from Type where TypeName like '" + comboBox1.Text + "'";
                                                                                                                 
            td2.Rows.Clear();

            //Initializes a new instance of the SqlDataAdapter class with a SelectCommand and a connection string
            adapter = new SqlDataAdapter(sql, con);

            adapter.Fill(td2); //Fill the SQL query results in the variable td of type table

            int target = Int32.Parse(td2.Rows[0]["TypeID"].ToString());

            sql = "select * from Products where pro_type = " + target;//The Select query
                                                                                                                                                                                     //   MessageBox.Show(sql);
            td3.Rows.Clear();//Clear the content of the variable td of type table

            //Initializes a new instance of the SqlDataAdapter class with a SelectCommand and a connection string
            adapter = new SqlDataAdapter(sql, con);

            adapter.Fill(td3);
           dataGridView1.DataSource = td3;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sql = "select * from Products where category_name =1 and pro_name like '%" + textBox1.Text + "%'";
            td.Rows.Clear();
            con.Open();//Open the connection
            adapter = new SqlDataAdapter(sql, con); //Initializes a new instance of the SqlDatAdapter class with the specified SqlCommand and a SqlConnection object
            adapter.Fill(td); //Fill the SQL query results in the variable td of type table
            con.Close();//Close the connection once done
            dataGridView1.DataSource = td;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            this.Close();
            homePage.Show();
        }
    }
    }

    

