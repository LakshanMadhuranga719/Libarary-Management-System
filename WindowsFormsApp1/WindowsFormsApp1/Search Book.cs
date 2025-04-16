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
    public partial class Search_Book : Form
    {
        public Search_Book()
        {
            InitializeComponent();
        }

        private void Search_Book_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-19UJ0FN\\SQLEXPRESS; database= master;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select* from NewBook";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource=ds.Tables[0];

        }
        int bid;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null) 
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

            }
            panel2.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-19UJ0FN\\SQLEXPRESS; database= master;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select* from NewBook where Bid= "+bid+"";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

            txtname.Text = ds.Tables[0].Rows[0][1].ToString();
            txtauthorname.Text= ds.Tables[0].Rows[0][2].ToString();
            txtpablication.Text= ds.Tables[0].Rows[0][3].ToString(); ;
            txtdate.Text= ds.Tables[0].Rows[0][4].ToString(); ;
            txtprice.Text= ds.Tables[0].Rows[0][5].ToString();
            txtqty.Text= ds.Tables[0].Rows[0][6].ToString();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void txtbname_TextChanged(object sender, EventArgs e)
        {
            if(txtbname.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-19UJ0FN\\SQLEXPRESS; database= master;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select* from NewBook where BName LIKE '"+txtbname.Text+"%'";
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

                cmd.CommandText = "select* from NewBook";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            txtbname.Clear();
            panel2.Visible = false;
        }

        private void blnupdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data Will be Updated. Conform?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)== DialogResult.OK)
            {

                String bname = txtname.Text;
                String bauthor = txtauthorname.Text;
                String pablication = txtpablication.Text;
                String bdate = txtdate.Text;
                Int64 bprice = Int64.Parse(txtprice.Text);
                Int64 bqty = Int64.Parse(txtqty.Text);
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-19UJ0FN\\SQLEXPRESS; database= master;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update NewBook set BName = '" + bname + "',BAuthor ='" + bauthor + "',BPablication = '" + pablication + "',BDate ='" + bdate + "' , BPrice =" + bprice + " , BQty =" + bqty + " where bid =" + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data Will be Deleted. Conform?", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                String bname = txtname.Text;
                String bauthor = txtauthorname.Text;
                String pablication = txtpablication.Text;
                String bdate = txtdate.Text;
                Int64 bprice = Int64.Parse(txtprice.Text);
                Int64 bqty = Int64.Parse(txtqty.Text);
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-19UJ0FN\\SQLEXPRESS; database= master;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete from NewBook where bid=" + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
