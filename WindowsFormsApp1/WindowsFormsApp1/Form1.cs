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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bln01_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void txt01_MouseEnter(object sender, EventArgs e)
        {

        }

        private void txt01_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtUsername_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                
            }
        }

        private void txtPassword_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Clear();
                txtPassword.PasswordChar = '*';
            }
        }
        
     
        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = " data source = DESKTOP-19UJ0FN\\SQLEXPRESS; Initial Catalog=master;Integrated Security=True";
            SqlCommand cmd =new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from logintable where username = '"+txtUsername.Text+"'and pass='"+txtPassword.Text+"' ";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                this.Hide();
                home h = new home();
                h.Show();
                
            }
            else
            {
                MessageBox.Show("Wrong Username OR Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            {
             
            }
            
        }


        private void txtPassword_TextChanged(object sender, EventArgs e) 
        {

        }
    }
}
