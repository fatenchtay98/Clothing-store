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
    public partial class NewProduct : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["databasecon"].ToString());
        string sql;
        string size;
        SqlDataAdapter adapter;
        SqlCommandBuilder cmdBuilder;
        SqlCommand cmd;
        DataTable td = new DataTable();
        DataTable td1 = new DataTable();
        public NewProduct()
        {
            InitializeComponent();

        }
        private void browse_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "jpg |*.jpg";
                DialogResult res = openFileDialog1.ShowDialog();
                if (res == DialogResult.OK)
                {
                    pic.Image = Image.FromFile(openFileDialog1.FileName);
                }
            }
            catch (Exception msj)
            {
                MessageBox.Show("Error!");
                MessageBox.Show(msj.ToString());

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {


            int i, id = 1;
            for (i = 0; i < td.Rows.Count; i++)
                if (CategoryBox.Text.Equals(td.Rows[i]["CategoryName"].ToString()))
                    id = Int32.Parse(td.Rows[i]["CategoryID"].ToString());
            int j, id1 = 1;
            for (j = 0; j < td1.Rows.Count; j++)
                if (TypeBox.Text.Equals(td1.Rows[j]["TypeName"].ToString()))
                    id1 = Int32.Parse(td1.Rows[j]["TypeID"].ToString());


            con.Open();
            try
            {
                SqlCommand com = new SqlCommand("INSERT INTO Products(pro_name, pro_quantity, pro_price, category_name,  pro_date, pro_type,pro_color, pro_description, pro_size, pro_image) VALUES('" + ProductName.Text + "','" + ProductQuantity.Text + "','" + ProductPrice.Text + "','" + id + "','" + Convert.ToString(Date.Value.ToShortDateString()) + "', '" + id1 + "','" + textBox2.Text + "','" + ProductDescription.Text + "','" + size + "',@pro_image)", con);
                MemoryStream stream = new MemoryStream();
                pic.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] picc = stream.ToArray();
                com.Parameters.AddWithValue("@pro_image", picc);
                i = com.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("succes insert" + i);

                }
                con.Close();
            }
            catch (Exception msj)
            {
                MessageBox.Show("Error!");
                MessageBox.Show(msj.ToString());

            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            try
            {

                int i;
                String sql = "select CategoryID, CategoryName from Category";
                td.Rows.Clear();


                adapter = new SqlDataAdapter(sql, con);

                adapter.Fill(td);

                for (i = 0; i < td.Rows.Count; i++)
                    CategoryBox.Items.Add(td.Rows[i]["CategoryName"]);



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
                td1.Rows.Clear();//Clear the content of the variable td of type table

                //Initializes a new instance of the SqlDataAdapter class with a SelectCommand and a connection string
                adapter = new SqlDataAdapter(sql, con);

                adapter.Fill(td1); //Fill the SQL query results in the variable td of type table

                for (i = 0; i < td1.Rows.Count; i++)
                    TypeBox.Items.Add(td1.Rows[i]["TypeName"]);



            }
            catch (Exception msj)
            {
                MessageBox.Show("Error!");
                MessageBox.Show(msj.ToString());

            }
        
    }

      
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            size = "S";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            size = "M";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            size = "L";
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            adminPage.Show();
            this.Hide();
        }

        private void Exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimize_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}

    

