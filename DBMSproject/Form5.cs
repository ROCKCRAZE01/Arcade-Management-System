using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using Oracle.ManagedDataAccess.Client;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DBMSproject
{
    public partial class Form5 : Form
    {
        public static int wallet_id = 0;
        OracleConnection conn;
        public Form5()
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
        
        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectDB();
            OracleCommand cmd1 = conn.CreateCommand();
            OracleCommand cmd2 = conn.CreateCommand();
            wallet_id = int.Parse(textBox5.Text);
            cmd1.CommandText = "insert into player values('"+textBox1.Text + "','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"')";
            cmd2.CommandText = "insert into wallet(wallet_id,username, amount_borrowed) values('" + textBox5.Text + "','" + textBox1.Text + "',0)";
            cmd1.CommandType= CommandType.Text;
            cmd2.CommandType = CommandType.Text;
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Submitted");
            cmd1.Dispose();
            cmd2.Dispose();
            conn.Close();
        }
    }
}
