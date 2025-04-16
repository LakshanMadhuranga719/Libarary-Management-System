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
    public partial class Search_Student : Form
    {
        public Search_Student()
        {
            InitializeComponent();
        }

        private void Search_Student_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-19UJ0FN\\SQLEXPRESS; database= master;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select* from NewStudent";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }
        int sid;
        Int64 rowid;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                sid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

            }
            panel2.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-19UJ0FN\\SQLEXPRESS; database= master;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select* from NewStudent where StuId= " + sid + "";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

            txtsname.Text = ds.Tables[0].Rows[0][1].ToString();
            txtsno.Text = ds.Tables[0].Rows[0][2].ToString();
            txtdipartment.Text = ds.Tables[0].Rows[0][3].ToString(); ;
            txtsemester.Text = ds.Tables[0].Rows[0][4].ToString(); ;
            txtcontact.Text = ds.Tables[0].Rows[0][5].ToString();
            txtemail.Text = ds.Tables[0].Rows[0][6].ToString();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void txtno_TextChanged(object sender, EventArgs e)
        {
            if (txtno.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-19UJ0FN\\SQLEXPRESS; database= master;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select* from NewStudent where SNo LIKE '" + txtno.Text + "%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-19UJ0FN\\SQLEXPRESS; database= master;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select* from NewStudent";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            txtno.Clear();
            panel2.Visible = false;
        }

        private void blnupdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data Will be Updated. Conform?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                String sname = txtsname.Text;
                String sno = txtsno.Text;
                String dipartment = txtdipartment.Text;
                String semester =txtsemester.Text;
                Int64 contact = Int64.Parse(txtcontact.Text);
                String email = txtemail.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-19UJ0FN\\SQLEXPRESS; database= master;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update NewStudent set SName = '" + sname + "',SNo ='" + sno + "',Dep = '" + dipartment + "',Sem ='" + semester + "' , contact ="+ contact + " ,email ='"+ email + "'  where StuId =" + rowid + ""  ;   
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data Will be Deleted. Conform?", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {


                String sname = txtsname.Text;
                String sno = txtsno.Text;
                String dipartment = txtdipartment.Text;
                String semester = txtsemester.Text;
                Int64 contact = Int64.Parse(txtcontact.Text);
                String email = txtemail.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-19UJ0FN\\SQLEXPRESS; database= master;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete from NewStudent where StuId=" + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }
    }
}
