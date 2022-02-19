using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace devhelper
{
    public partial class Form1 : Form
    {
        helper hlpr = new helper();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = hlpr.ShowTable("users");
            
        }

        private void refrechBtn_Click(object sender, EventArgs e)
        {
            hlpr.Refrech(hlpr.dt, dataGridView1, "users");
            hlpr.Clear(this);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (hlpr.number("id", "users", idBox) == 0)
            {
                hlpr.InsertToDb("users", idBox.Text, fnameBox.Text, lnameBox.Text);
                MessageBox.Show("Added Seccessufly");
                hlpr.Refrech(hlpr.dt, dataGridView1, "users");
                hlpr.Clear(this);
            }
            else
            {
                MessageBox.Show("Already Added");
                hlpr.Clear(this);
            }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (hlpr.number("id", "users", idBox) > 0)
            {
                hlpr.DeletetFromDb("users", "id", idBox.Text);
                hlpr.Refrech(hlpr.dt, dataGridView1, "users");
                hlpr.Clear(this);
            }
            else
            {
                MessageBox.Show("Id Not Exist");
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (hlpr.number("id", "users", idBox) == 1)
            {
                hlpr.ModifyRowDb("users", idBox.Text, fnameBox.Text, lnameBox.Text);
                hlpr.Refrech(hlpr.dt, dataGridView1, "users");
                hlpr.Clear(this);
            }
            else
            {
                MessageBox.Show("Id Not Exist");
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            hlpr.dt.Clear();
            DataTable Result = hlpr.SearchDb("users", "id", idBox.Text);
            if (Result.Rows.Count > 0)
            {
                dataGridView1.DataSource = Result;
                fnameBox.Text = hlpr.dt.Rows[0][1].ToString();
                lnameBox.Text = hlpr.dt.Rows[0][2].ToString();
            }
            else
            {
                MessageBox.Show("User Not Exist");
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            hlpr.Exit(this);
        }
    }
}
