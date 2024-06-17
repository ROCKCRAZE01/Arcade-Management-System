using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DBMSproject
{
    public partial class Form7 : Form
    {
        public int value = 0;
        OracleConnection conn;
        public Form7()
        {
            InitializeComponent();
        }
        public void ConnectDB()
        {
            conn = new OracleConnection("Data Source=ROCKCRAZE01;User ID=system;Password=singhas");
            try
            {
                conn.Open();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            ConnectDB();

            OracleCommand cmd = conn.CreateCommand();

            try
            {
    
                cmd.CommandText = "SELECT amount_borrowed FROM wallet where username = '" + Form4.s + "'";
                OracleDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
              
                    value = int.Parse(reader.GetString(0)); 
                }
                label9.Text = value.ToString();


                reader.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {

                cmd.Dispose();
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            this.Hide();
            form6.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConnectDB();
            OracleCommand cmd = conn.CreateCommand();
            try
            {
                cmd.CommandText = "SELECT amount_borrowed FROM wallet where username = '" + Form4.s + "'";
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    value = int.Parse(reader.GetString(0));
                }
                if (value < int.Parse(label6.Text)) { MessageBox.Show("Cannot afford"); }
                else
                {
                    int v2 = value - int.Parse(label6.Text);
                    cmd.CommandText = "UPDATE wallet SET amount_borrowed = '" + v2 + "'";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    label9.Text = v2.ToString();
                    MessageBox.Show("Purchased");
                    reader.Close();
                    OracleTransaction transaction = null;
                    transaction = conn.BeginTransaction();
                    OracleCommand f = conn.CreateCommand();
                    f.Transaction = transaction;
                    f.CommandText = "transactions";
                    f.CommandType = CommandType.StoredProcedure;
                    f.Parameters.Add("user", OracleDbType.Varchar2).Value = Form4.s;
                    f.Parameters.Add("amount", OracleDbType.Int32).Value = -(int.Parse(label6.Text));
                    f.ExecuteNonQuery();
                    f.Dispose();

    
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConnectDB();
            OracleCommand cmd = conn.CreateCommand();
            try
            {
                cmd.CommandText = "SELECT amount_borrowed FROM wallet where username = '" + Form4.s + "'";
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    value = int.Parse(reader.GetString(0));
                }
                if (value < int.Parse(label7.Text)) { MessageBox.Show("Cannot afford"); }
                else
                {
                    int v2 = value - int.Parse(label7.Text);
                    cmd.CommandText = "UPDATE wallet SET amount_borrowed = '" + v2 + "'";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    label9.Text = v2.ToString();
                    MessageBox.Show("Purchased");
                    reader.Close();
                    OracleTransaction transaction = null;
                    transaction = conn.BeginTransaction();
                    OracleCommand f = conn.CreateCommand();
                    f.Transaction = transaction;
                    f.CommandText = "transactions";
                    f.CommandType = CommandType.StoredProcedure;
                    f.Parameters.Add("user", OracleDbType.Varchar2).Value = Form4.s;
                    f.Parameters.Add("amount", OracleDbType.Int32).Value = -(int.Parse(label7.Text));
                    f.ExecuteNonQuery();
                    f.Dispose();

      
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ConnectDB();
            OracleCommand cmd = conn.CreateCommand();
            try
            {
                cmd.CommandText = "SELECT amount_borrowed FROM wallet where username = '" + Form4.s + "'";
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    value = int.Parse(reader.GetString(0));
                }
                if (value < int.Parse(label8.Text)) { MessageBox.Show("Cannot afford"); }
                else
                {
                    int v2 = value - int.Parse(label8.Text);
                    cmd.CommandText = "UPDATE wallet SET amount_borrowed = '" + v2 + "'";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    label9.Text = v2.ToString();
                    MessageBox.Show("Purchased");
                    reader.Close();
                    OracleTransaction transaction = null;
                    transaction = conn.BeginTransaction();
                    OracleCommand f = conn.CreateCommand();
                    f.Transaction = transaction;
                    f.CommandText = "transactions";
                    f.CommandType = CommandType.StoredProcedure;
                    f.Parameters.Add("user", OracleDbType.Varchar2).Value = Form4.s;
                    f.Parameters.Add("amount", OracleDbType.Int32).Value = -(int.Parse(label8.Text));
                    f.ExecuteNonQuery();
                    f.Dispose();


                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }
    }
}

