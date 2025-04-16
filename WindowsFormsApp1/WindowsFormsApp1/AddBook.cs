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
    public partial class AddBook : Form
    {
        public AddBook()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtBookName.Text!= "" && txtAuthor.Text!= "" && txtpablication.Text!= "" && txtprice.Text!= "" && txtQuantity.Text!= "" ) 
            {
                String BName = txtBookName.Text;
                String BAuthor = txtAuthor.Text;
                String BPublication = txtpablication.Text;
                String BDate = dateTimePicker1.Text;
                Int64 BPrice = Int64.Parse(txtprice.Text);
                Int64 BQty = Int64.Parse(txtQuantity.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-19UJ0FN\\SQLEXPRESS; database = master;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into NewBook(BName,BAuthor,BPablication,BDate,BPrice,BQty)values('" + BName + "','" + BAuthor + "','" + BPublication + "','" + BDate + "'," + BPrice + "," + BQty + ")";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBookName.Clear();
                txtAuthor.Clear();
                txtpablication.Clear();
                txtprice.Clear();
                txtQuantity.Clear();
            }
            else
            {
                MessageBox.Show("Emty Feild Not Allowed", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will DELETE your Unsaved DATA.", "Are you Sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                this.Close();

           
             
        }

        private void AddBook_Load(object sender, EventArgs e)
        {

        }
    }
}
