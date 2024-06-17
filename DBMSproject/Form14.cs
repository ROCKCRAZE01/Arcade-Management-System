using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMSproject
{
    public partial class Form14 : Form
    {
        OracleConnection conn;
        public Form14()
        {
            InitializeComponent();
        }

        public void ConnectDB()
        {
            conn = new OracleConnection("Data Source=rockcraze01;Persist Security Info=True;User ID=system;Password=singhas");
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectDB();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "insert into scores(username,machine_no,score) values ('"+Form4.s+"',1,"+textBox1.Text+")";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Inserted");
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide();
        }
    }
}
