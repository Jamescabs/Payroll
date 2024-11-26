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
    public partial class Allowance : Form
    {
        public Allowance()
        {
            InitializeComponent();
            ShowAllowance();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\bryle\OneDrive\Documents\Ejie's Payroll.mdf"";Integrated Security=True;Connect Timeout=30""C:\Users\bryle\OneDrive\Documents\Ejie's Payroll.mdf""");
        private void Clear()
        {
            AAmountTb.Text = "";
            AllowanceDTP.Value = DateTime.Now;
            Key = 0;
        }

        private void ShowAllowance()
        {
            Con.Open();
            string Query = "Select   *   from      AllowanceTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            AllowanceDGV.DataSource = ds.Tables[0];
            Con.Close();
        }





        private void ASaveBtn_Click(object sender, EventArgs e)
        {
            if (AAmountTb.Text == "" | AllowanceDTP.Value == DateTime.Now)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into AllowanceTbl(AllowAmount, AllowEffectDate)values( @AA, @AED)", Con);
                    cmd.Parameters.AddWithValue("@AA", AAmountTb.Text);
                    cmd.Parameters.AddWithValue("@AED", AllowanceDTP.Value);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Allowance  Saved");
                    Con.Close();
                    ShowAllowance();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }









        private void AEditBtn_Click(object sender, EventArgs e)
        {
            if (AAmountTb.Text == "" | AllowanceDTP.Value == DateTime.Now)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update  AllowanceTbl    Set     AllowAmount=@AA, AllowEffectDate=@AED        where    AllowId=@AllowKey", Con);
                    cmd.Parameters.AddWithValue("@AA", AAmountTb.Text);
                    cmd.Parameters.AddWithValue("@AED", AllowanceDTP.Value);
                    cmd.Parameters.AddWithValue("@AllowKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Allowance  Updated");
                    Con.Close();
                    ShowAllowance();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }














        private void ADeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from AllowanceTbl    Where   AllowId=@AllowKey", Con);
                    cmd.Parameters.AddWithValue("@AllowKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Allowance  Deleted");
                    Con.Close();
                    ShowAllowance();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }










                    int Key = 0;

                    private void AllowanceDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
                    {

            if (e.RowIndex >= 0 && AllowanceDGV.Rows.Count > 0)
            {
               
                DataGridViewRow selectedRow = AllowanceDGV.Rows[e.RowIndex];

                
                AAmountTb.Text = selectedRow.Cells[1].Value?.ToString() ?? string.Empty;

               
                if (DateTime.TryParse(selectedRow.Cells[2].Value?.ToString(), out DateTime selectedDate))
                {
                    AllowanceDTP.Value = selectedDate;
                }
                else
                {
                    MessageBox.Show("Invalid date format.");
                }

                
                Key = Convert.ToInt32(selectedRow.Cells[0].Value); 
            }
        }















                    private void panel1_Paint(object sender, PaintEventArgs e)
                    {

                    }

                    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
                    {

                    }

        private void label1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DTR dtr = new DTR();
            dtr.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Allowance allowance = new Allowance();
            allowance.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Payroll payroll = new Payroll();
            payroll.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Deductory deductory = new Deductory();
            deductory.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Salary salary = new Salary();
            salary.Show();
            this.Hide();
        }
    }
            }

