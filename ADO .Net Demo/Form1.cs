using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace ADO.Net_Demo
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public Form1()
        {
            InitializeComponent();
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            con = new SqlConnection(constr);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //step 1:Write query
                string qry = "insert into employee values(@Name,@City,@Salary)";

                //step 2: Create object of command and assign the query
                cmd= new SqlCommand(qry, con);

                //step 3: Assign parameters to parameters
                cmd.Parameters.AddWithValue("@Name", txtEmpName.Text);
                cmd.Parameters.AddWithValue("@City", txtCity.Text);
                cmd.Parameters.AddWithValue("@salary", txtSalary.Text);

                //step 4:Fire the query
                con.Open();
                int result=cmd.ExecuteNonQuery();
                if (result >=1)
                {
                    MessageBox.Show("Record Inserted");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally 
            {
                con.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtEmpName.Clear();
            txtCity.Clear();
            txtSalary.Clear();
        }
    }
}
