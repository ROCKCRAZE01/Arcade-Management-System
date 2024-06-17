using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace DBMSproject
{
    public partial class Form2 : Form
    {
        OracleConnection conn;
        public Form2()
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
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectDB();

                OracleCommand checkCmd = conn.CreateCommand();
                checkCmd.CommandText = "SELECT COUNT(*) FROM admins WHERE username = '"+textBox1.Text+"' AND password = '"+textBox2.Text+"'";
                

                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("Login successfully");
                    Form20 form20 = new Form20();
                    form20.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username or password does not exist");
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Oracle Exception: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }


        }
    }
}
