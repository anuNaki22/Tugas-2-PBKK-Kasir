using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace POS0
{

    public partial class Transactions : Form
    {
        private int transactionID = 0;
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\eric\Documents\pos.mdf;Integrated Security=True;Connect Timeout=30");
        public Transactions()
        {
            InitializeComponent();
            try
            {
                Con.Open();
            }
            catch (Exception e)
            {
                Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\source\repos\POS0_PBKK\TESTDb.mdf;Integrated Security=True;Connect Timeout=30");
                try
                {
                    Con.Open();
                }
                catch (Exception f)
                {
                    Console.WriteLine(f.Message);
                }
                SqlCommand cmd = new SqlCommand("select count(*) from [dbo].[transactions]", Con);
                transactionID = (int)cmd.ExecuteScalar();
            }
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
                string query = "insert into [dbo].[transactions] values ('" + comboBox1.Text + "','" + textBox2.Text + "','" + numericUpDown1.Text + "','" + numericUpDown2.Text + "','" + richTextBox1.Text + "','" + transactionID + "')";
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "delete from [dbo].[transactions] where idTransactions='" + transactionID + "' and productName='" + comboBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                MessageBox.Show("Product Deleted");
                Con.Close();
            }
            catch
            {
                MessageBox.Show("Product not Deleted? WHY");
            }
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

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tESTDbDataSet.products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.tESTDbDataSet.products);
            // TODO: This line of code loads data into the 'tESTDbDataSet.transactions' table. You can move, or remove it, as needed.
            this.transactionsTableAdapter.Fill(this.tESTDbDataSet.transactions);
            // TODO: This line of code loads data into the 'tESTDbDataSet.transactions' table. You can move, or remove it, as needed.
            this.transactionsTableAdapter.Fill(this.tESTDbDataSet.transactions);
            // TODO: This line of code loads data into the 'tESTDbDataSet.products' table. You can move, or remove it, as needed.
            this.productsTableAdapter1.Fill(this.tESTDbDataSet.products);
            // TODO: This line of code loads data into the 'tESTDbDataSet.user' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.tESTDbDataSet.user);
            //// TODO: This line of code loads data into the 'posDataSet.products' table. You can move, or remove it, as needed.
            //this.productsTableAdapter.Fill(this.posDataSet.products);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "update [dbo].[transactions] set productName='" + comboBox1.Text + "', quantity=" + numericUpDown1.Text + ", price =" + numericUpDown2.Text + ", description= '" + richTextBox1.Text + "' where productName='" + comboBox1.Text + "' and idTransactions = '" + transactionID + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Updated Successfully");
                Con.Close();
            }
            catch (Exception c)
            {
                MessageBox.Show("Product Failed to Update");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //string textBuffer = dataGridView1.SelectedRows[0].ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].ToString();
            comboBox1.Text = dataGridView1.SelectedRows[1].ToString();
            numericUpDown1.Value = Convert.ToDecimal(dataGridView1.SelectedRows[2].ToString());
            numericUpDown2.Value = Convert.ToDecimal(dataGridView1.SelectedRows[3].ToString());
            richTextBox1.Text = dataGridView1.SelectedRows[4].ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "select * from [dbo].[products] where productName='" + comboBox1.SelectedItem.ToString() + "'";
                DataTable dt = new DataTable();
                SqlDataAdapter cmd = new SqlDataAdapter(query, Con);
                cmd.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    textBox2.Text = dt.Rows[0][1].ToString();
                    numericUpDown1.Value = 1;
                    numericUpDown2.Value = Convert.ToDecimal(Convert.ToDouble(dt.Rows[0][0].ToString()) * Convert.ToDouble(numericUpDown1.Value));
                    richTextBox1.Text = dt.Rows[0][3].ToString();
                }
                else
                {
                    MessageBox.Show("THIS SHOULDN'T HAPPENED");
                }

            }
            catch (Exception c)
            {
                MessageBox.Show("THIS SHOULDN'T HAPPENED");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Struk ERROR");
            }
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }
    }
}
