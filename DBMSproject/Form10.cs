using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace DBMSproject
{
    public partial class Form10 : Form
    {
        OracleConnection conn;
        public Form10()
        {
            InitializeComponent();
        }

        public void ConnectDB()
        {
            conn = new OracleConnection("Data Source=rockcraze01;Persist Security Info=True;User ID=system;Password=singhas");
            try 
            {
                conn.Open();
            }
            catch (Exception e) 
            {
                MessageBox.Show(e.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ConnectDB();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM PLAYER WHERE USERNAME = '"+textBox1.Text+"'";
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                cmd.CommandText = "SELECT COUNT(*) FROM PLAYER WHERE USERNAME = '" + textBox1.Text + "' AND ANS_1 = '" + textBox2.Text + "' AND ANS_2 ='" + textBox3.Text + "'";
                int count2 = Convert.ToInt32(cmd.ExecuteScalar());
                if (count2 > 0)
                {
                    cmd.CommandText = "SELECT PASSWORD FROM PLAYER WHERE USERNAME = '" + textBox1.Text + "'";
                    string p = cmd.ExecuteScalar().ToString();
                    MessageBox.Show(p);
                }
                else
                {
                    MessageBox.Show("Could not verify account");
                }
            }
            else
            {
                MessageBox.Show("No such user found");
            }
        }
    }
}
