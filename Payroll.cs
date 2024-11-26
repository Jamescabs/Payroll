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
    public partial class Payroll : Form
    {
        public Payroll()
        {
            InitializeComponent();
            ShowPayroll();
        }

        
        
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\bryle\OneDrive\Documents\Ejie's Payroll.mdf"";Integrated Security=True;Connect Timeout=30");
        private void Clear()
        {
            PAmountTb.Text = "";
            PayrollDTP.Value = DateTime.Now;
            PTotalEarningsTb.Text = "";
            Key = 0;
        }

        private void ShowPayroll()
        {
            Con.Open();
            string Query = "Select   *   from      PayrollTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            PayrollDGV.DataSource = ds.Tables[0];
            Con.Close();
        }










        private void PSaveBtn_Click(object sender, EventArgs e)
        {
            if (PAmountTb.Text == "" | PayrollDTP.Value == DateTime.Now | PTotalEarningsTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into PayrollTbl(TotalEarn, PayPeriod,   Amount)values( @TE, @PP, @PA)", Con);
                    cmd.Parameters.AddWithValue("@PA", PAmountTb.Text);
                    cmd.Parameters.AddWithValue("@PP", PayrollDTP.Value);
                    cmd.Parameters.AddWithValue("@TE", PTotalEarningsTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Payroll  Saved");
                    Con.Close();
                    ShowPayroll();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }










        private void PEditBtn_Click(object sender, EventArgs e)
        {
            if (PAmountTb.Text == "" | PayrollDTP.Value == DateTime.Now | PTotalEarningsTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update  AllowanceTbl    Set     AllowAmount=@AA, AllowEffectDate=@AED        where    AllowId=@AllowKey", Con);
                    cmd.Parameters.AddWithValue("@PA", PAmountTb.Text);
                    cmd.Parameters.AddWithValue("@PP", PayrollDTP.Value);
                    cmd.Parameters.AddWithValue("@TE", PTotalEarningsTb.Text);
                    cmd.Parameters.AddWithValue("@AllowKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Payroll  Updated");
                    Con.Close();
                    ShowPayroll();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }












        private void PDeleteBtn_Click(object sender, EventArgs e)
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
                    SqlCommand cmd = new SqlCommand("Delete from PayrollTbl    Where   PayId=@PayKey", Con);
                    cmd.Parameters.AddWithValue("@PayKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Payroll  Deleted");
                    Con.Close();
                    ShowPayroll();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }










        int Key = 0;
        private void PayrollDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensures that the clicked cell is within the bounds of the grid
            {
                DataGridViewRow row = PayrollDGV.Rows[e.RowIndex];

                // Assuming the columns are in this order: PayId, TotalEarn, PayPeriod, Amount
                PTotalEarningsTb.Text = row.Cells[1].Value.ToString();
                PayrollDTP.Value = Convert.ToDateTime(row.Cells[2].Value.ToString());
                PAmountTb.Text = row.Cells[3].Value.ToString();

                // Set the key for the selected row's Payroll ID
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
