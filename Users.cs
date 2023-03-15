using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace POS0
{
    public partial class Users : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\source\repos\POS0_PBKK\posDataSet.mdf;Integrated Security=True;Connect Timeout=30");
        public Users()
        {
            InitializeComponent();
            load();
            try
            {
                Con.Open();
                Con.Close();
            }
            catch // (Exception e)
            {
                Con = new SqlConnection();
                // MessageBox.Show(e.Message);

            }
            Con.Close();
        }

        private void load()
        {
            Con.Close();
            Con.Open();
            string query = "select * from [dbo].[user]";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            userName.DataSource = dt;
            userName.DisplayMember = "username";
            userName.ValueMember = "username";
            Con.Close();

        }


        private void Users_Load(object sender, System.EventArgs e)
        {
            // TODO: This line of code loads data into the 'posDataSetDataSet.user' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.posDataSetDataSet.user);

        }

        private void label3_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("HELLO THERE");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = e.RowIndex;
                userID.Text = dataGridView1.Rows[row].Cells[0].ToString();
                userName.Text = dataGridView1.Rows[row].Cells[1].ToString();
                userPassword.Text = dataGridView1.Rows[row].Cells[2].ToString();
                userEmail.Text = dataGridView1.Rows[row].Cells[3].ToString();
                userTelp.Text = dataGridView1.Rows[row].Cells[4].ToString();
                if (dataGridView1.Rows[row].Cells[5].ToString() == "1")
                {
                    userType.Text = "admin";
                }
                else
                {
                    userType.Text = "kasir";
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }

        }

        private void Add_Click(object sender, System.EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "insert into [dbo].[user] (username,password,email,notelp,usertype) values ('" + userName.Text + "','" + userPassword.Text + "','" + userEmail.Text + "','" + userTelp.Text + "','" + userType.Text + "'); ";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                Con.Close();
                MessageBox.Show("Akun berhasil masuk");

            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message + " FROM INSERT QUERY ");
            }
            load();

        }

        private void Update_Click(object sender, System.EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "update [dbo].[user] set username='" + userName.Text + "', password='" + userPassword.Text + "', email='" + userEmail.Text + "', notelp='" + userTelp.Text + "', usertype='" + userType.Text + "' where Id='" + userID.Text + "';";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                Con.Close();
                MessageBox.Show("Update Akun berhasil");
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message + " FROM UPDATE");
            }
            load();
        }

        private void Delete_Click(object sender, System.EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "delete from [dbo].[user] where Id = '" + userID.Text +
                    "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                Con.Close();
                MessageBox.Show("Delete akun berhasi;");

            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message + " FROM DELETE");
            }
            load();
        }


        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "select * from [dbo].[user] where username = '" + userName.Text +
                    "'";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(query, Con);
                da.Fill(dt);

                userID.Text = dt.Rows[0][0].ToString();
                userPassword.Text = dt.Rows[0][2].ToString();
                userEmail.Text = dt.Rows[0][3].ToString();
                userTelp.Text = dt.Rows[0][4].ToString();
                if (dt.Rows[0][5].ToString() == "1")
                {
                    userType.Text = "admin";
                }
                else
                {
                    userType.Text = "kasir";
                }
                Con.Close();

            }
            catch 
            {
                Con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            product produkform = new product();
            produkform.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bill billform = new bill();
            billform.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            login loginform = new login();
            loginform.Show();
            this.Hide();
        }

        private void moveToProduct_Click(object sender, EventArgs e)
        {

        }

        private void moveToUser_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            login loginform = new login();
            loginform.Show();
            this.Hide();
        }
    }
}
