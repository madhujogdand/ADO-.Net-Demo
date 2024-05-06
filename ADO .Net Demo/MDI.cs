using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO.Net_Demo
{
    public partial class MDI : Form
    {
        public MDI()
        {
            InitializeComponent();
        }

        private void connectedFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.MdiParent = this;
            form1.Show();
        }

        private void disconnectedFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.MdiParent = this;
            form2.Show();
        }

        private void closeWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
    }
}
