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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DBMSproject
{
    public partial class Form4 : Form
    {
        public static string s = "";
        OracleConnection conn;
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectDB(); 
            OracleCommand checkCmd = conn.CreateCommand();
            checkCmd.CommandText = "SELECT COUNT(*) FROM player WHERE username = :username AND password = :password";
            checkCmd.Parameters.Add("username", OracleDbType.Varchar2).Value = textBox1.Text;
            checkCmd.Parameters.Add("password", OracleDbType.Varchar2).Value = textBox2.Text;
            s = textBox1.Text;
            int count = Convert.ToInt32(checkCmd.ExecuteScalar());

            if (count > 0)
            {

                Form6 form6 = new Form6();
                this.Hide();
                form6.Show(); ;
            }
            else
            {
                MessageBox.Show("Username or password does not exist");
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.Show();
            this.Hide();
        }
    }
}
