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
    public partial class Issue_books : Form
    {
        public Issue_books()
        {
            InitializeComponent();
        }

        private void Issue_books_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-19UJ0FN\\SQLEXPRESS; database = master;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd = new SqlCommand("select BName from NewBook", con);
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read()) 
            {
            for(int i=0; i< sdr.FieldCount; i++)
                {
                    comboBoxBName.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
            con.Close();
        }
        int count;
        private void btnSearchStudent_Click(object sender, EventArgs e)
        {
            if (TxtSNO.Text != "")
            {
                String sn = TxtSNO.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-19UJ0FN\\SQLEXPRESS; database = master;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewStudent where SNo = '" + sn + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                //--------------------------------------------------------------------
                //Code to cound how many book has been issued on this student number
                cmd.CommandText = "select count(Std_no) from IRBook where Std_no = '" + sn + "' and Book_return_date is null ";
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);

                count = int.Parse(ds1.Tables[0].Rows[0][0].ToString());
                //--------------------------------------------------------------------

                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtSName.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtDepartment.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtSSemester.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtSContact.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0][6].ToString();
                }
                else 
                {
                    txtSName.Clear();
                    txtDepartment.Clear();
                    txtSSemester.Clear();
                    txtSContact.Clear();
                    txtEmail.Clear();
                    MessageBox.Show("Invalid Student Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                

                }

            }

        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            if (txtSName.Text != "")
            {
                if (comboBoxBName.SelectedIndex != -1 && count <= 2)
                {
                    String stdno = TxtSNO.Text;
                    String sname = txtSName.Text;
                    String sdep = txtDepartment.Text;
                    String sem = txtSSemester.Text;
                    Int64 contact = Int64.Parse(txtSContact.Text);
                    String email = txtEmail.Text;
                    String bookname = comboBoxBName.Text;
                    String bookissuedate = dateTimePicker1.Text;


                    String sn = TxtSNO.Text;
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source = DESKTOP-19UJ0FN\\SQLEXPRESS; database = master;integrated security=True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();

                    cmd.CommandText = cmd.CommandText = "Insert into IRBook(Std_no,std_name,Std_dep,Std_sem,Std_contact,Std_email,Book_name,Book_issue_date) values ('" + stdno + "','" + sname + "','" + sdep + "','" + sem + "'," + contact + ",'" + email + "','" + bookname + "','" + bookissuedate + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Book Issued.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Select Book. OR Maximum nmumber of books has been ISSUED", "No Book Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Enter valid Student no", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            TxtSNO.Clear();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure?", "confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK) 
            {
                this.Close();
            }
        }
    }
}
