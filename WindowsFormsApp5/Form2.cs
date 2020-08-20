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

namespace WindowsFormsApp5
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin\Database21.mdf;Integrated Security=True;Connect Timeout=30 ;");

            SqlDataAdapter sda = new SqlDataAdapter(" Select count(*)  from Login where Username='" + Username.Text + "'and Password='" + Password.Text + "'", con);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Form1 ff = new Form1();
                ff.Show();
            }
            else
            {
                MessageBox.Show("Username/Password is incorrect...");
            }
            MessageBox.Show(" Login Successfully");

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
