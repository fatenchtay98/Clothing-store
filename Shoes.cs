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
    public partial class Shoes : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["databasecon"].ToString());
        string sql;
        SqlDataAdapter adapter;
        SqlCommandBuilder cmdBuilder;
        SqlCommand cmd;
        DataTable td = new DataTable();
        DataTable td1 = new DataTable();
        DataTable td2 = new DataTable();

        public Shoes()
        {
            InitializeComponent();
        }

        private void Shoes_Load(object sender, EventArgs e)
        {
            try
            {
                sql = "select * from Products where category_name = 4 ";
                td.Rows.Clear();

                string sql1 = "select pro_id, pro_image from Products";
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



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sql = "select * from Products where pro_name like '%" + textBox1.Text + "%'";
            td.Rows.Clear();
            con.Open();//Open the connection
            adapter = new SqlDataAdapter(sql, con); //Initializes a new instance of the SqlDatAdapter class with the specified SqlCommand and a SqlConnection object
            adapter.Fill(td); //Fill the SQL query results in the variable td of type table
            con.Close();//Close the connection once done
            dataGridView1.DataSource = td;
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            this.Close();
            homePage.Show();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}

