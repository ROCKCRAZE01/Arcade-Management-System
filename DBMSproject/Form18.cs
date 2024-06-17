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
    public partial class Form18 : Form
    {
        OracleConnection conn;
        public Form18()
        {
            InitializeComponent();
        }
        public void ConnectDB()
        {
            conn = new OracleConnection("Data Source=rockcraze01;Persist Security Info=True;User ID=system;Password=singhas");
            conn.Open();
        }
        private void Form18_Load(object sender, EventArgs e)
        {
            ConnectDB();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from scores where machine_no = 2 AND username = '" + Form4.s + "'";
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cmd.CommandText, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "scores");
            dataGridView1.DataSource = ds.Tables[0];
            cmd.CommandText = "SELECT COUNT(*) from scores where machine_no = 2 AND username = (select username from player where username = '" + Form4.s + "')";
            OracleDataReader reader = cmd.ExecuteReader();
            int value = 0;
            while (reader.Read())
            {
                value = int.Parse(reader.GetString(0));
            }
            label3.Text = value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form12 form12 = new Form12();
            this.Hide();
            form12.Show();
        }
    }
}
