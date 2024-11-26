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
    public partial class Salary : Form
    {
        public Salary()
        {
            InitializeComponent();
            ShowSalary();
        }



        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\bryle\OneDrive\Documents\Ejie's Payroll.mdf"";Integrated Security=True;Connect Timeout=30");
        private void Clear()
        {
            SAmountTb.Text = "";
            SalaryDTP.Value = DateTime.Now;
            Key = 0;
        }

        private void ShowSalary()
        {
            Con.Open();
            string Query = "Select   *   from      SalaryTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SalaryDGV.DataSource = ds.Tables[0];
            Con.Close();
        }



        private void SSaveBtn_Click(object sender, EventArgs e)
        {
            if (SAmountTb.Text == "" | SalaryDTP.Value == DateTime.Now)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into SalaryTbl(Amount, EffectDate)values( @SA, @SED)", Con);
                    cmd.Parameters.AddWithValue("@SA", SAmountTb.Text);
                    cmd.Parameters.AddWithValue("@SED", SalaryDTP.Value);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Salary  Saved");
                    Con.Close();
                    ShowSalary();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }









        private void SEditBtn_Click(object sender, EventArgs e)
        {
            if (SAmountTb.Text == "" | SalaryDTP.Value == DateTime.Now)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update  SalaryTbl    Set     Amoount=@SA, EffectDate=@SED        where    SalaryId=@SalaryKey", Con);
                    cmd.Parameters.AddWithValue("@SA", SAmountTb.Text);
                    cmd.Parameters.AddWithValue("@SED", SalaryDTP.Value);
                    cmd.Parameters.AddWithValue("@SalaryKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Salary  Updated");
                    Con.Close();
                    ShowSalary();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }









        private void SDeleteBtn_Click(object sender, EventArgs e)
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
                    SqlCommand cmd = new SqlCommand("Delete from SalaryTbl    Where   SalaryId=@SalaryKey", Con);
                    cmd.Parameters.AddWithValue("@SalaryKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Salary  Deleted");
                    Con.Close();
                    ShowSalary();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }









        int Key = 0;
        private void SalaryDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure the clicked cell is within bounds
            {
                DataGridViewRow row = SalaryDGV.Rows[e.RowIndex];

                // Assuming the columns are in order: SalaryId, Amount, EffectDate
                SAmountTb.Text = row.Cells[1].Value.ToString();
                SalaryDTP.Value = Convert.ToDateTime(row.Cells[2].Value);

                // Set the Key for the selected Salary ID
                Key = Convert.ToInt32(row.Cells[0].Value.ToString());
            }
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
