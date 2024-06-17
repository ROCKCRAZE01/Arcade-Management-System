using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMSproject
{
    public partial class Form9 : Form
    {
        OracleConnection conn;
        public Form9()
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
        private void Form9_Load(object sender, EventArgs e)
        {
            label5.Text = Form4.s;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectDB();

            OracleTransaction transaction = null;

            try
            {
      
                transaction = conn.BeginTransaction();

 
                OracleCommand checkCmd = conn.CreateCommand();
                checkCmd.Transaction = transaction;
                checkCmd.CommandText = "SELECT COUNT(*) FROM player p JOIN wallet w ON w.username = p.username WHERE w.wallet_id = :wallet_id AND p.password = :password";
                checkCmd.Parameters.Add("wallet_id", OracleDbType.Varchar2).Value = textBox2.Text;
                checkCmd.Parameters.Add("password", OracleDbType.Varchar2).Value = textBox1.Text;
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count > 0)
                {
        
                    OracleCommand updateCmd = conn.CreateCommand();
                    updateCmd.Transaction = transaction;
                    updateCmd.CommandText = "UPDATE wallet SET amount_borrowed = amount_borrowed + :amount WHERE wallet_id = :wallet_id";
                    updateCmd.Parameters.Add("amount", OracleDbType.Int32).Value = int.Parse(textBox3.Text);
                    updateCmd.Parameters.Add("wallet_id", OracleDbType.Varchar2).Value = textBox2.Text;
                    updateCmd.ExecuteNonQuery();
                    updateCmd.Dispose();

                
                    OracleCommand f = conn.CreateCommand();
                    f.Transaction = transaction;
                    f.CommandText = "transactions";
                    f.CommandType = CommandType.StoredProcedure;
                    f.Parameters.Add("user", OracleDbType.Varchar2).Value = Form4.s;
                    f.Parameters.Add("amount", OracleDbType.Int32).Value = int.Parse(textBox3.Text);
                    f.ExecuteNonQuery();
                    f.Dispose();


                    transaction.Commit();

                    MessageBox.Show("Successfully added amount");
                    Form6 form6 = new Form6();
                    form6.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username or password does not exist");
                }
            }
            catch (Exception ex)
            {
           
                if (transaction != null && transaction.Connection != null && transaction.Connection.State != ConnectionState.Closed)
                {
                    transaction.Rollback();
                }

                MessageBox.Show("An error occurred: " + ex.Message);
            }

            finally
            {

                if (transaction != null)
                    transaction.Dispose();

                conn.Close();
            }
        }


    }
}
