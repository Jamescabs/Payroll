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
    public partial class DTR : Form
    {
        public DTR()
        {
            InitializeComponent();
            ShowDTR();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\bryle\OneDrive\Documents\Ejie's Payroll.mdf"";Integrated Security=True;Connect Timeout=30");
        private void Clear()
        {
            TimeInTb.Text = "";
            TimeOutTb.Text = "";
            Key = 0;
        }

        private void ShowDTR()
        {
            Con.Open();
            string Query = "Select   *   from      DTRTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DtrDGV.DataSource = ds.Tables[0];
            Con.Close();
        }










        private void DSaveBtn_Click(object sender, EventArgs e)
        {
            if (TimeInTb.Text == "" | TimeOutTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into DTRTbl(TimeIn, TimeOut)values( @TI, @TO)", Con);
                    cmd.Parameters.AddWithValue("@TI", TimeInTb.Text);
                    cmd.Parameters.AddWithValue("@TO", TimeOutTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("DTR  Saved");
                    Con.Close();
                    ShowDTR();
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
            if (TimeInTb.Text == "" || TimeOutTb.Text == "" || Key == 0)
            {
                MessageBox.Show("Missing Information or No Record Selected");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update DTRTbl Set TimeIn=@TI, TimeOut=@TO where DtrId=@DtrKey", Con);
                    cmd.Parameters.AddWithValue("@TI", TimeInTb.Text);
                    cmd.Parameters.AddWithValue("@TO", TimeOutTb.Text);
                    cmd.Parameters.AddWithValue("@DtrKey", Key); // Use the Key (DtrId)
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("DTR Updated");
                    Con.Close();
                    ShowDTR();
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
                MessageBox.Show("Select a record to delete");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from DTRTbl where DtrId=@DtrKey", Con);
                    cmd.Parameters.AddWithValue("@DtrKey", Key); // Use the Key (DtrId)
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("DTR Deleted");
                    Con.Close();
                    ShowDTR();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }








        int Key = 0;
            private void DtrDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TimeInTb.Text = DtrDGV.SelectedRows[0].Cells[1].Value.ToString();
            TimeOutTb.Text = DtrDGV.SelectedRows[0].Cells[2].Value.ToString();
            if (TimeInTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(DtrDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }













        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
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
