using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure you want to Exit?", "Conform", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
         
        }

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBook AB = new AddBook();
            AB.Show();

        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void searchBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search_Student SSt = new Search_Student();
            SSt.Show();
        }

        private void searchStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search_Book SB = new Search_Book();
            SB.Show();
        }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addABookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Student ASt = new Add_Student();
            ASt.Show();
        }

        private void issueBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Issue_books IB = new Issue_books ();
            IB.Show();
        }

        private void returnBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Return_book rb = new Return_book();
            rb.Show();
        }
    }
}
