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

namespace POS0
{
    public partial class product : Form
    {
        public product()
        {
            InitializeComponent();

        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\eric\Documents\pos.mdf;Integrated Security=True;Connect Timeout=30");

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'posDataSetDataSet.products' table. You can move, or remove it, as needed.
            this.productsTableAdapter1.Fill(this.posDataSetDataSet.products);
            //// TODO: This line of code loads data into the 'posDataSet.products' table. You can move, or remove it, as needed.
            //this.productsTableAdapter.Fill(this.posDataSet.products);
            try
            {
                Con.Open();
                Con.Close();
            }
            catch
            {
                Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\source\repos\POS0_PBKK\posDataSet.mdf;Integrated Security=True;Connect Timeout=30");
                Con.Open();
                Con.Close();
            }

        }

        private void refreshDataTable()
        {
            dataGridView1.DataSource = null;
            Con.Open();
            string query = "select * from [dbo].[products]";
            SqlDataAdapter sd = new SqlDataAdapter(query, Con);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;


            Con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "insert into [dbo].[products] (productName,quantity,price,description) values (" + "'" + textBox2.Text + "'," + numericUpDown1.Text + "," + numericUpDown2.Text + ",'" + richTextBox1.Text + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Added Successfully");
                Con.Close();
                //populate();
                //richTextBox2.Text = ""; 
                //ProdNameTb.Text = ""; ProdPriceTb.Text = ""; ProdQtyTb.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            refreshDataTable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "delete from [dbo].[products] where Id = '" + textBox1.Text +
                    "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Deleted Successfully");
                Con.Close();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
            refreshDataTable();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "update [dbo].[products] set productName='" + textBox2.Text + "', quantity=" + numericUpDown1.Text + ", price =" + numericUpDown2.Text + ", description= '" + richTextBox1.Text + "' where ID=" + textBox1.Text +"";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Product Updated Successfully");
            Con.Close();
            refreshDataTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rows = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[rows].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[rows].Cells[1].Value.ToString();
            numericUpDown1.Value = Convert.ToDecimal( dataGridView1.Rows[rows].Cells[2].Value.ToString());
            numericUpDown1.Value = Convert.ToDecimal(dataGridView1.Rows[rows].Cells[3].Value.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            login Login = new login();
            Login.Show();
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Users userform = new Users();
            userform.Show();
            // Users.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            login loginform = new login();
            loginform.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bill billform = new bill();
            billform.Show();
            this.Hide();
        }
    }
}
