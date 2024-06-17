using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMSproject
{
    public partial class Form8 : Form
    {
        public int value = 0;
        OracleConnection conn;
        public Form8()
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

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            this.Hide();
            form6.Show();
        }

        private void Form8_Load(object sender, EventArgs e)
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
                label7.Text = value.ToString();


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
        private void OpenUrlInDefaultBrowser(string url)
        {
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
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
                if (value < int.Parse(label2.Text)) { MessageBox.Show("Cannot afford"); }
                else
                {
                    OpenUrlInDefaultBrowser("https://www.google.com/logos/2010/pacman10-i.html");
                    int v2 = value - int.Parse(label2.Text);
                    cmd.CommandText = "UPDATE wallet SET amount_borrowed = '" + v2 + "'";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    label7.Text = v2.ToString();
                    MessageBox.Show("Purchased");
                    reader.Close();
                    OracleTransaction transaction = null;
                    transaction = conn.BeginTransaction();
                    OracleCommand f = conn.CreateCommand();
                    f.Transaction = transaction;
                    f.CommandText = "transactions";
                    f.CommandType = CommandType.StoredProcedure;
                    f.Parameters.Add("user", OracleDbType.Varchar2).Value = Form4.s;
                    f.Parameters.Add("amount", OracleDbType.Int32).Value = -(int.Parse(label2.Text));
                    f.ExecuteNonQuery();
                    f.Dispose();

        
                    transaction.Commit();
                    cmd.CommandText = "INSERT INTO dbfkus(gamename,amt) values ('Lack Man',150)";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    this.Hide();
                    Form14 form14 = new Form14();
                    form14.Show();
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
                if (value < int.Parse(label3.Text)) { MessageBox.Show("Cannot afford"); }
                else
                {
                    OpenUrlInDefaultBrowser("https://www.retrogames.cz/play_001-NES.php");
                    int v2 = value - int.Parse(label3.Text);
                    cmd.CommandText = "UPDATE wallet SET amount_borrowed = '" + v2 + "'";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    label7.Text = v2.ToString();
                    MessageBox.Show("Purchased");
                    reader.Close();
                    OracleTransaction transaction = null;
                    transaction = conn.BeginTransaction();
                    OracleCommand f = conn.CreateCommand();
                    f.Transaction = transaction;
                    f.CommandText = "transactions";
                    f.CommandType = CommandType.StoredProcedure;
                    f.Parameters.Add("user", OracleDbType.Varchar2).Value = Form4.s;
                    f.Parameters.Add("amount", OracleDbType.Int32).Value = -(int.Parse(label3.Text));
                    f.ExecuteNonQuery();
                    f.Dispose();

                    transaction.Commit();
                    cmd.CommandText = "INSERT INTO dbfkus(gamename,amt) values ('Kong a Doodle Doo',200)";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    this.Hide();
                    Form15 form15 = new Form15();
                    form15.Show();
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
                if (value < int.Parse(label4.Text)) { MessageBox.Show("Cannot afford"); }
                else
                {
                    OpenUrlInDefaultBrowser("https://www.allsonicgames.net/sonic-the-hedgehog-3.php");
                    int v2 = value - int.Parse(label4.Text);
                    cmd.CommandText = "UPDATE wallet SET amount_borrowed = '" + v2 + "'";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    label7.Text = v2.ToString();
                    reader.Close();
                    OracleTransaction transaction = null;
                    transaction = conn.BeginTransaction();
                    OracleCommand f = conn.CreateCommand();
                    f.Transaction = transaction;
                    f.CommandText = "transactions";
                    f.CommandType = CommandType.StoredProcedure;
                    f.Parameters.Add("user", OracleDbType.Varchar2).Value = Form4.s;
                    f.Parameters.Add("amount", OracleDbType.Int32).Value = -(int.Parse(label4.Text));
                    f.ExecuteNonQuery();
                    f.Dispose();

                    transaction.Commit();
                    cmd.CommandText = "INSERT INTO dbfkus(gamename,amt) values ('Sanic the Hedgehog',250)";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    this.Hide();
                    Form16 form16 = new Form16();
                    form16.Show();
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

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
