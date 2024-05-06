using System;

using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ADO.Net_Demo
{
    public partial class Form2 : Form
    {

        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommandBuilder scb;
        public Form2()
        {
            InitializeComponent();
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            con = new SqlConnection(constr);
        }

        // Fetch data from DB & load into DataSet
        private DataSet GetAllEmployees()
        {
            string qry = "select * from employee";
            da = new SqlDataAdapter(qry, con);
            //Add pk to the column which is in the DataSet
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //SqlCommandBuilder will track the DataSet & generate the qry-assign to adapter
            scb = new SqlCommandBuilder(da);
            ds = new DataSet();
            //emp is the name given to the table which is in the DataSet
            da.Fill(ds, "emp");

          return ds;
        }
        private void clearFields()
        { 
        txtEmpId.Clear();
            txtEmpName.Clear();
            txtCity.Clear();
            txtSalary.Clear();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ds=GetAllEmployees();
                //create new row to add record
                DataRow row = ds.Tables["emp"].NewRow(); 
                row["name"]=txtEmpName.Text;
                row["city"]=txtCity.Text;
                row["salary"]=txtSalary.Text;

                //attach row to the emp table
                ds.Tables["emp"].Rows.Add(row);
                int result = da.Update(ds.Tables["emp"]);
                if (result >= 1)
                {
                    MessageBox.Show("Record Inserted");
                    clearFields();
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAllEmployees();
                DataRow row = ds.Tables["emp"].Rows.Find(txtEmpId.Text);
                if (row != null)
                {
                    txtEmpName.Text = row["name"].ToString();
                    txtCity.Text = row["city"].ToString();
                    txtSalary.Text = row["salary"].ToString();
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtEmpId.Clear();
            txtEmpName.Clear();
            txtCity.Clear();
            txtSalary.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAllEmployees();
                DataRow row = ds.Tables["emp"].Rows.Find(txtEmpId.Text);
                if (row != null)
                {
                    //override the value from textbox to row
                    row["name"] = txtEmpName.Text;
                    row["city"]=txtCity.Text;
                    row["salary"] = txtSalary.Text;

                    int result = da.Update(ds.Tables["emp"]);
                    if (result >= 1)
                    {
                        MessageBox.Show("Record Updated");
                    }
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
             ds=GetAllEmployees();
             DataRow row = ds.Tables["emp"].Rows.Find(txtEmpId.Text);
                if (row != null)
                {
                    row.Delete();
                    int result = da.Update(ds.Tables["emp"]);
                    if (result >= 1)
                    {
                        MessageBox.Show("Record Deleted");
                        clearFields();
                    }
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnShoAllList_Click(object sender, EventArgs e)
        {
            ds=GetAllEmployees();
            dataGridView1.DataSource = ds.Tables["emp"];
        }
    }
}
