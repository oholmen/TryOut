using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyMemoryCache
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Store the message in the cache:
            GlobalCachingProvider.Instance.AddItem("MyValue", richTextBox1.Text);
            MessageBox.Show("Values are stored..!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 Frm = new Form2();
            Frm.Show();
        }
    }
}
