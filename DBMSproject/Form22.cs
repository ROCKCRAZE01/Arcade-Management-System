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
    public partial class Form22 : Form
    {
        OracleConnection conn;
        OracleTransaction transaction = null;

        public Form22()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                conn = new OracleConnection("Data Source=rockcraze01;Persist Security Info=True;User ID=system;Password=singhas");


                conn.Open();

                transaction = conn.BeginTransaction();

                OracleCommand f = conn.CreateCommand();
                f.Transaction = transaction;

                f.CommandText = "deleteplayer";
                f.CommandType = CommandType.StoredProcedure;


                f.Parameters.Add("playerName", OracleDbType.Varchar2).Value = textBox1.Text;


                f.ExecuteNonQuery();


                f.Dispose();
                MessageBox.Show("DELETED");

                transaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);


                if (transaction != null)
                {
                    transaction.Rollback();
                }
            }
            finally
            {

                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form20 form = new Form20();
            form.Show();
        }

        private void Form22_Load(object sender, EventArgs e)
        {

        }
    }
}
