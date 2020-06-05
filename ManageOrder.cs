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
using System.Data.OleDb; //printing prop
using TEST.Properties;

namespace TEST
{
    public partial class ManageOrder : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["databasecon"].ToString());
        string sql;
        string Size;
        SqlDataAdapter adapter;
        SqlCommandBuilder cmdBuilder;
        SqlCommand cmd;
        DataTable td = new DataTable();
        DataTable td1 = new DataTable();
        public ManageOrder()
        {
            InitializeComponent();
        }

        private void ManageOrder_Load(object sender, EventArgs e)
        {
            try
            {

                int i;
                String sql = "select pro_name, pro_price from Products ";
                td.Rows.Clear();


                adapter = new SqlDataAdapter(sql, con);

                adapter.Fill(td);

                for (i = 0; i < td.Rows.Count; i++)
                    comboBox1.Items.Add(td.Rows[i]["pro_name"]);



            }
            catch (Exception msj)
            {
                MessageBox.Show("Error!");
                MessageBox.Show(msj.ToString());

            }
           

            textBox3.Enabled = false;
            textBox5.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox7.Text = "10%";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        public void CalculateTotalPrice()
        {

            if (textBox4.Text != "" && textBox2.Text != "")
            {
                int quantity = Convert.ToInt32(textBox4.Text);
                int price = Convert.ToInt32(textBox2.Text);

                int totalprice = quantity * price;

                textBox5.Text = "" + totalprice;


                textBox8.Text = "" + ((totalprice / 10) + totalprice);

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            String sql = "select pro_quantity from Products where pro_name ='"+ comboBox1.SelectedItem.ToString()  +"'";
            td.Rows.Clear();


            adapter = new SqlDataAdapter(sql, con);

            adapter.Fill(td);

            textBox3.Text = td.Rows[0]["pro_quantity"].ToString();
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com;

            //updates quantity
            int newquantity = Convert.ToInt32(textBox3.Text);
            newquantity--;
            String sql = "update Products  set pro_quantity =" + newquantity + "where pro_name = '" + comboBox1.SelectedItem.ToString() + "'";
            com = new SqlCommand(sql, con);
            com.ExecuteNonQuery();

            DateTime x = DateTime.Now;
            string order_date = x.ToString();

            string payby = "";

            if (radioButton1.Checked)
                payby = radioButton1.Text;
            else
                payby = radioButton2.Text; 


           
    
            //updates oders
           com = new SqlCommand("INSERT INTO Orders(order_date, ClientName, Quantity, item, TotalToPay, PaymentType ) VALUES('" + order_date + "','" + textBox1.Text + "','" + textBox4.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + textBox8.Text + "','" + payby + "')", con);
            com.ExecuteNonQuery();
            MessageBox.Show("Item added to the cart");

            con.Close();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Image image = Resources.logoo;
            e.Graphics.DrawImage(image, 0, 0, image.Width, image.Height);
            e.Graphics.DrawString("Date:" + DateTime.Now.ToShortDateString(), new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(300, 100));
            e.Graphics.DrawString("Client Name:" + textBox1.Text.Trim(), new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(25, 450));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(25, 480));
            e.Graphics.DrawString("Item Name", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(5, 500));
            e.Graphics.DrawString("Quantity" , new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(200, 500));
            e.Graphics.DrawString("Unit price" , new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(400, 500));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(25, 525));
          
           e.Graphics.DrawString(comboBox1.Text, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(5, 550));
            e.Graphics.DrawString(textBox4.Text, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(200, 550));
            e.Graphics.DrawString(textBox2.Text, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(400, 550));
           
            e.Graphics.DrawString("Total payment", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(25, 900));
            e.Graphics.DrawString("$" + textBox8.Text, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(600, 900));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(25, 870));

            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(25, 930));

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            comboBox1.SelectedIndex = 0;
            textBox4.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            this.Close();
            adminPage.Show();
        }
    }
}
