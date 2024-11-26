using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejie_s_Payroll_Management_System
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
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
