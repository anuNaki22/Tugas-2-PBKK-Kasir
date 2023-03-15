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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        
         SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\eric\Documents\pos.mdf;Integrated Security=True;Connect Timeout=30");

        private void login_Load(object sender, EventArgs e)
        {
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

        private void checkUserType(DataTable dt)
        {
            if(dt.Rows[0][5].ToString() == "admin" || dt.Rows[0][5].ToString() == "Admin")
            {
                Users userlist = new Users();
                userlist.Show();
                this.Hide();
            }
            else
            {
                bill billlist = new bill();
                billlist.Show();
                this.Hide();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from [dbo].[user] where username='" + textBox1.Text + "' and password='" + textBox2.Text + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            try
            {
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Correct");
                    checkUserType(dt);
  
                    Con.Close();
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password");
                }

            }
            catch
            {
                    MessageBox.Show("Wrong Username or Password");
               
            }
          
            Con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataGRID2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
