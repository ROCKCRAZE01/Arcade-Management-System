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
    public partial class Form11 : Form
    {
        OracleConnection conn;
        public Form11()
        {
            InitializeComponent();
        }

        public void ConnectDB()
        {
            conn = new OracleConnection("Data Source=rockcraze01;Persist Security Info=True;User ID=system;Password=singhas");
            conn.Open();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            ConnectDB();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from transaction where username = '" + Form4.s + "'";
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cmd.CommandText, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "transaction");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6();
            form.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
