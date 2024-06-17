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
    public partial class Form21 : Form
    {
        OracleConnection conn;
        public Form21()
        {
            InitializeComponent();
        }
        public void ConnectDB()
        {
            conn = new OracleConnection("Data Source=rockcraze01;Persist Security Info=True;User ID=system;Password=singhas");
            conn.Open();
        }
        private void Form21_Load(object sender, EventArgs e)
        {
            ConnectDB();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from transaction";
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cmd.CommandText, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "transaction");
            dataGridView1.DataSource = ds.Tables[0];
            cmd.CommandText = "select sum(amt) from dbfkus where gamename = (select gamename from machine where machine_no = 1)";
            OracleDataReader reader = cmd.ExecuteReader();
            int value = 0;
            while (reader.Read())
            {
                value = int.Parse(reader.GetString(0));
            }
            label4.Text = value.ToString();
            cmd.CommandText = "select sum(amt) from dbfkus where gamename = (select gamename from machine where machine_no = 2)";
            reader = cmd.ExecuteReader();
            value = 0;
            while (reader.Read())
            {
                value = int.Parse(reader.GetString(0));
            }
            label5.Text = value.ToString();
            cmd.CommandText = "select sum(amt) from dbfkus where gamename = (select gamename from machine where machine_no = 3)";
            reader = cmd.ExecuteReader();
            value = 0;
            while (reader.Read())
            {
                value = int.Parse(reader.GetString(0));
            }
            label6.Text = value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    }
}
