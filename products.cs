using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace POS0
{
    public partial class products : Form
    {
        private SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\source\repos\POS0_PBKK\TESTDb.mdf;Integrated Security=True");

        public products()
        {
            InitializeComponent();
            try
            {
                Con.Open();
            }
            catch (Exception e)
            {
                Con = new SqlConnection();
            }
            Con.Close();
        }

        private void products_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tESTDbDataSet.products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.tESTDbDataSet.products);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            productID.Text = dataGridView1.SelectedRows[0].ToString();
            productName.Text = dataGridView1.SelectedRows[1].ToString();
            productValue.Text = dataGridView1.SelectedRows[2].ToString();
            productDescription.Text = dataGridView1.SelectedRows[3].ToString();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query1 = "select idProduct from [dbo].[products] where productName = '" + productName.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(query1, Con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Con.Close();

                if (dt.Rows.Count == 0)
                {
                    Con.Open();
                    string query = "insert into [dbo].[products] ('productName','price','description') value('" + productName.Text + "','" + productValue.Text + "','" + productDescription.Text + "') ";
                    SqlCommand cmd = new SqlCommand(query, Con);

                    Con.Close();
                    MessageBox.Show("Produk berhasil dimasukan");
                }
                else
                {
                    MessageBox.Show("Data already in, Please try again\n");
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "update [dbo].[products] set productName='" + productName.Text +
                    "', price='" + productValue.Text +
                    "', description='" + productDescription.Text +
                    "' where idProduct='" + productID.Text +
                    "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                Con.Close();
                MessageBox.Show("Updating product complete");
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "delete from [dbo].[products] where idProduct = '" + productID.Text +
                    "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                Con.Close();
                MessageBox.Show("Delete data complete");
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void moveToProduct_Click(object sender, EventArgs e)
        {
            try
            {
                products product = new products();
                product.Show();
                this.Close();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void moveToUser_Click(object sender, EventArgs e)
        {
            try
            {
                Users user = new Users();
                user.Show();
                this.Close();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void productName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "select idProduct,price,description from [dbo].[products] where productName = '" + productName.Text + "'";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(query, Con);
                da.Fill(dt);

                productID.Text = dt.Rows[0][0].ToString();
                productValue.Text = dt.Rows[0][1].ToString();
                productDescription.Text = dt.Rows[0][2].ToString();

                Con.Close();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void productID_TextChanged(object sender, EventArgs e)
        {
        }
    }
}