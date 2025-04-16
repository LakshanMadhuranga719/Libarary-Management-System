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
    public partial class Return_book : Form
    {
        public Return_book()
        {
            InitializeComponent();
        }

        private void btnSearchStudent_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-19UJ0FN\\SQLEXPRESS; database = master;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from IRBook where Std_no = '" +TxtSNO.Text+ "'and Book_return_date is null";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Invalid ID or No Book", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Return_book_Load(object sender, EventArgs e)
        {
            panel3.Visible = false;
            TxtSNO.Clear();
        }
        String bname;
        String bdate;
        Int64 rowid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel3.Visible = true;
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                rowid = Int64.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                bname = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                bdate = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

            }
            txtBName.Text = bname;
            txtIssueDate.Text = bdate;

        }

        private void btnreturn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-19UJ0FN\\SQLEXPRESS; database = master;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd.CommandText = "update IRBook set Book_return_date = '" +dataGridView1.Text+ "' where Std_no = '"+TxtSNO.Text+"'and id = "+rowid+"";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("return Succesfull.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Return_book_Load(this, null);


        }

        private void TxtSNO_TextChanged(object sender, EventArgs e)
        {
            if (TxtSNO.Text != "") 
            {
                panel2.Visible = true;
                dataGridView1.DataSource = null;

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            TxtSNO.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btncansel_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }
    }
}
