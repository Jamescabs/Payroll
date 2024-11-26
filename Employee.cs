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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
            ShowEmployee();
        }

        SqlConnection  Con      =        new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\bryle\OneDrive\Documents\Ejie's Payroll.mdf"";Integrated Security=True;Connect Timeout=30");
        private void Clear()
        {
            EnameTb.Text = "";
            ContactNumberTb.Text = "";
            Key = 0;
        }

        private void ShowEmployee()
        {
                    Con.Open();
                    string Query = "Select   *   from      EmployeeTbl";
                    SqlDataAdapter          sda =   new SqlDataAdapter (Query, Con);
                    SqlCommandBuilder    Builder    = new SqlCommandBuilder (sda);
                    var     ds      =       new DataSet();
                    sda.Fill (ds);
                    EmployeeDGV.DataSource = ds.Tables[0];
                    Con.Close();
        }


        private void SaveBtn_Click(object sender, EventArgs e)
        {
                                            if (EnameTb.Text == "" | ContactNumberTb.Text == "")
                                            {
                                                MessageBox.Show("Missing Information");
                                            }
                                            else
                                            {
                                                try
                                                {
                                                             Con.Open();
                                                    SqlCommand  cmd =   new SqlCommand("insert into EmployeeTbl(EmpName, EmpContactNum)values( @EN, @ECN)",      Con);
                                                        cmd.Parameters.AddWithValue("@EN", EnameTb.Text);
                                                        cmd.Parameters.AddWithValue("@ECN", ContactNumberTb.Text);
                                                        cmd.ExecuteNonQuery();
                                                        MessageBox.Show("Employee  Saved");
                                                    Con.Close();
                                                    ShowEmployee ();
                                                    Clear();
                                                }
                                                            catch   (Exception  Ex)
                                                {
                                                            MessageBox.Show(Ex.Message);
                                                }
                                            }
        }




        private void EditBtn_Click(object sender, EventArgs e)
        {
                                                if (EnameTb.Text == "" | ContactNumberTb.Text == "")
                                                {
                                                    MessageBox.Show("Missing Information");
                                                }
                                                else
                                                {
                                                    try
                                                    {
                                                        Con.Open();
                                                        SqlCommand cmd = new SqlCommand("Update  EmployeeTbl    Set     EmpName=@EN, EmpContactNum=@ECN        where    EmpId=@EmpKey",     Con);
                                                        cmd.Parameters.AddWithValue("@EN", EnameTb.Text);
                                                        cmd.Parameters.AddWithValue("@ECN", ContactNumberTb.Text);
                                                        cmd.Parameters.AddWithValue("@EmpKey",  Key);
                                                        cmd.ExecuteNonQuery();
                                                        MessageBox.Show("Employee  Updated");
                                                        Con.Close();
                                                        ShowEmployee();
                                                        Clear();
                                                    }
                                                    catch (Exception Ex)
                                                    {
                                                        MessageBox.Show(Ex.Message);
                                                    }
                                                }
        }




        private void DeleteBtn_Click(object sender, EventArgs e)
        {
                                                if (Key ==  0)
                                                {
                                                    MessageBox.Show("Missing Information");
                                                }
                                                else
                                                {
                                                    try
                                                    {
                                                        Con.Open();
                                                        SqlCommand cmd = new SqlCommand("Delete from EmployeeTbl    Where   EmpId=@EmpKey", Con);
                                                        cmd.Parameters.AddWithValue("@EmpKey",  Key);
                                                        cmd.ExecuteNonQuery();
                                                        MessageBox.Show("Employee  Deleted");
                                                        Con.Close();
                                                        ShowEmployee();
                                                    }
                                                    catch (Exception Ex)
                                                    {
                                                        MessageBox.Show(Ex.Message);
                                                    }
                                                }
        }







        int Key = 0;
        private void EmployeeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                        EnameTb.Text   = EmployeeDGV.SelectedRows[0].Cells[1].Value.ToString();
                        ContactNumberTb.Text    = EmployeeDGV.SelectedRows[0].Cells[2].Value.ToString();
                        if (EnameTb.Text  ==  "")
            {
                         Key = 0;
            }else
            {
                          Key = Convert.ToInt32(EmployeeDGV.SelectedRows[0].Cells [0].Value.ToString());
            }
        }










        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Employee_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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
