using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

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
                    clearFields();
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

        private void clearFields()
        {
            txtEmpId.Clear();
            txtEmpName.Clear();
            txtCity.Clear();
            txtSalary.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //step1-write query
                string qry = "select * from employee where id=@id";

                //step2-assign values to command
                cmd=new SqlCommand(qry, con);

                //step 3-assign values to parameters
                cmd.Parameters.AddWithValue("@id", txtEmpId.Text);

                //step 4- Execute query
                con.Open();
                dr=cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while (dr.Read())
                    {
                        //read column
                        txtEmpName.Text = dr["name"].ToString();
                        txtCity.Text = dr["city"].ToString();
                        txtSalary.Text = dr["salary"].ToString() ;
                    }
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("ex.Message");
            }
            finally
            {
                con.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //step 1:Write query
                string qry = "update employee set name=@name, city=@city, salary=@salary where id=@id";

                //step 2: Create object of command and assign the query
                cmd = new SqlCommand(qry, con);

                //step 3: Assign parameters to parameters
                cmd.Parameters.AddWithValue("@Name", txtEmpName.Text);
                cmd.Parameters.AddWithValue("@City", txtCity.Text);
                cmd.Parameters.AddWithValue("@salary", txtSalary.Text);
                cmd.Parameters.AddWithValue("@id", txtEmpId.Text);

                //step 4:Fire the query
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result >= 1)
                {
                    MessageBox.Show("Record Updated");
                    clearFields();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //step 1:Write query
                string qry = "delete from employee where id=@id";

                //step 2: Create object of command and assign the query
                cmd = new SqlCommand(qry, con);

                //step 3: Assign parameters to parameters
              
                cmd.Parameters.AddWithValue("@id", txtEmpId.Text);

                //step 4:Fire the query
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result >= 1)
                {
                    MessageBox.Show("Record Deleted");
                    clearFields();
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

        private void btnShoAllList_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "select * from employee";
                cmd = new SqlCommand(qry, con);
                con.Open();
                dr= cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(dr);
                dataGridView1.DataSource = table;
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

    }
}
