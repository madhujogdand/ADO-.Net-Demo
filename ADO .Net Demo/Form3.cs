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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "admin" && txtPassword.Text == "admin123")
            {
                MessageBox.Show("Login Succesful");
                MDI mdi = new MDI();
                mdi.Show();
                this.Hide();
            }
            else 
            {
                MessageBox.Show("Login Fail");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtPassword.Clear();
        }
    }
}
