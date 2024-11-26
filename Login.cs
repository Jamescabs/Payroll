using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejie_s_Payroll_Management_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            PasswordTb.PasswordChar = '*';
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\bryle\OneDrive\Documents\Ejie's Payroll.mdf"";Integrated Security=True;Connect Timeout=30;Encrypt=False");
        private void label9_Click(object sender, EventArgs e)
        {

        }
        //Login Button
        private void Login_Click(object sender, EventArgs e)
        {
            string username = UsernameTb.Text;
            string password = PasswordTb.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            try
            {

                Con.Open();


                string query = "SELECT COUNT(1) FROM LoginTbl WHERE Username = @username AND Password = @password";
                SqlCommand cmd = new SqlCommand(query, Con);


                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);


                int count = (int)cmd.ExecuteScalar();

                if (count == 1)
                {

                    Home homePage = new Home();
                    homePage.Show();


                    this.Hide();
                }
                else
                {

                    MessageBox.Show("Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {

                Con.Close();
            }

          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}


