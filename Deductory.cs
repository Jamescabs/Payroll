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
    public partial class Deductory : Form
    {
        public Deductory()
        {
            InitializeComponent();
            ShowDeductory();
        }


        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\bryle\OneDrive\Documents\Ejie's Payroll.mdf"";Integrated Security=True;Connect Timeout=30");
        private void Clear()
        {
            TODTb.Text = "";
            DAmountTb.Text = "";
            Key = 0;
        }

        private void ShowDeductory()
        {
            Con.Open();
            string Query = "Select   *   from      DeductoryTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DeductoryDGV.DataSource = ds.Tables[0];
            Con.Close();
        }




        private void DSaveBtn_Click(object sender, EventArgs e)
        {
            if (TODTb.Text == "" | DAmountTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into DeductoryTbl(TypeOfDeduct, Amount)values( @TOD, @DA)", Con);
                    cmd.Parameters.AddWithValue("@TOD", TODTb.Text);
                    cmd.Parameters.AddWithValue("@DA", DAmountTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Deductory  Saved");
                    Con.Close();
                    ShowDeductory();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }









        private void DEditBtn_Click(object sender, EventArgs e)
        {
            if (TODTb.Text == "" | DAmountTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update  DeductoryTbl    Set     TypeOfDeduct=@TOD, Amount=@DA        where    DeductoryId=@DeductoryKey", Con);
                    cmd.Parameters.AddWithValue("@TOD", TODTb.Text);
                    cmd.Parameters.AddWithValue("@DA", DAmountTb.Text);
                    cmd.Parameters.AddWithValue("@DeductoryKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Deductory  Updated");
                    Con.Close();
                    ShowDeductory();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }








        private void DDeleteBtn_Click(object sender, EventArgs e)
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
                    SqlCommand cmd = new SqlCommand("Delete from DeductoryTbl    Where   DeductoryId=@DeductoryKey", Con);
                    cmd.Parameters.AddWithValue("@DeductoryKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Deductory  Deleted");
                    Con.Close();
                    ShowDeductory();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }









        int Key = 0;
        private void DeductoryDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = DeductoryDGV.Rows[e.RowIndex];

                TODTb.Text = row.Cells[1].Value.ToString();
                DAmountTb.Text = row.Cells[2].Value.ToString();

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
