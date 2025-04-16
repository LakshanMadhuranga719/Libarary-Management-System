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

namespace WindowsFormsApp1
{
    public partial class Add_Student : Form
    {
        public Add_Student()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("confirm?", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }

        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            txtname.Clear();
            txtno.Clear();
            txtdepartment.Clear();
            txtsemester.Clear();
            txtcontact.Clear();
            txtemail.Clear();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtname.Text != "" && txtno.Text != "" && txtdepartment.Text != "" && txtsemester.Text != "" && txtcontact.Text != "" && txtemail.Text != "")
            {



                String name = txtname.Text;
                String sno = txtno.Text;
                String dep = txtdepartment.Text;
                String sem = txtsemester.Text;
                Int64 mobile = Int64.Parse(txtcontact.Text);
                String email = txtemail.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-19UJ0FN\\SQLEXPRESS; database = master;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into NewStudent (SName,SNo,Dep,Sem,contact,email)values('" + name + "','" + sno + "','" + dep + "','" + sem + "'," + mobile + ",'" + email + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Pleace fill the Empty Fields", "Suggest", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void Add_Student_Load(object sender, EventArgs e)
        {

        }
    }
}
