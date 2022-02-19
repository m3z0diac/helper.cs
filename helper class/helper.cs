using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.IO;


namespace devhelper
{
    class helper
    {

        // Author: Hamza Elansari - @m3z0diac
        // This Project Created by Hamza Elansari, Full-stack web & software developer, Cyber Security Researcher
        // DM me on my Twitter @m3z0diac, fell free to use this module or modify on it
        // I will be very happy accepting your contributes on this project
        // Description: C# class contain several methods for easy & friendly working on your c# .net projects
        //              instead repeating all sql server mechanisme and functions, you can make that short coded 
        //              with this class

        public SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public SqlDataReader dr;
        public DataTable dt = new DataTable();


        //connect to sql database
        public void Connect()
        {
            string ServerName = "localhost";
            string DbName = "company";
            if (con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
            {
                con.ConnectionString = string.Format(@"data source={0}; initial catalog={1}; integrated security=true", ServerName, DbName);
                con.Open();
            }
        }

        //deconnect from sql database
        public void Deconnect()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        //get an sql database table and convert it into datatable for load it into the datagridview
        public DataTable ShowTable(string TableName)
        {
            Deconnect();
            Connect();
            cmd.CommandText = string.Format("select * from {0}", TableName);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }

        //clear all the input text
        public void Clear(Control f)
        {
            foreach (Control ct in f.Controls)
            {
                if (ct.GetType() == typeof(TextBox))
                {
                    ct.Text = "";
                }
                if (ct.Controls.Count != 0)
                {
                    Clear(ct);
                }
            }
        }


        //refrech the datagridview for display all the add and the founded data in the database table
        public void Refrech( DataTable dt, DataGridView dgv, string TableName)
        {
            dt.Clear();
            dgv.DataSource = ShowTable(TableName);
        }


        // get the number of the rows those have the same content of a Column (for make shure the PK not repeated)
        public int number(string column, string TableName, Control idsource)
        {
            int cpt;
            cmd.CommandText = string.Format("select count({0}) from {1} where {0} = {2}", column, TableName, idsource.Text);
            cmd.Connection = con;
            cpt = (int)cmd.ExecuteScalar();
            return cpt;

        }

        // confirm a function before execute it
        public bool Confirm()
        {
            if (MessageBox.Show("Are You Sure ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }

        // function for insert into a database table, you can add and remove the number of columns ofc
        public void InsertToDb(string TableName, string id, string fname, string lname)
        {
            Deconnect();
            Connect();
            cmd.CommandText = string.Format("insert into {0} values ({1}, '{2}', '{3}')", TableName, id, fname, lname);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
        }

        // function for delete from a database table
        public void DeletetFromDb(string TableName, string pkname, string pksource)
        {
            if (Confirm() == true) {
                Deconnect();
                Connect();
                cmd.CommandText = string.Format("delete from {0} where {1} = {2}", TableName, pkname, pksource);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Removed Seccessufly");
            }
        }

        // function for Modify a database table Row, you can add and remove the number of the Rows
        public void ModifyRowDb(string TableName, string id, string fname, string lname)
        {
            if (Confirm() == true)
            {
                Deconnect();
                Connect();
                cmd.CommandText = string.Format("update {0} set prenom='{2}', nom='{3}' where id={1}", TableName, id, fname, lname);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Modified Seccessufly");
            }
        }

        // Search at sql table function (kw = key word [column name], if the key word not int put the quatation side '{2}')
        public DataTable SearchDb (string TableName, string kwname, string kwsource)
        {
            Connect();
            cmd.CommandText = string.Format("select * from {0} where {1} = {2}", TableName, kwname, kwsource);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }

        // exit the program
        public void Exit(Form f)
        {
            f.Close();
        }
    }
}
