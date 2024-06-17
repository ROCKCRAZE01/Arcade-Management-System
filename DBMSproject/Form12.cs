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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form17 form17 = new Form17();
            form17.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form18 form18 = new Form18();
            form18.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 form6 = new Form6();
            form6.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form19 form19 = new Form19();
            this.Hide();
            form19.Show();
        }
    }
}
