using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin\Database21.mdf;Integrated Security=True;Connect Timeout=30 ;");

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {



                int practiceId = Convert.ToInt32(txtPracticeId.Text);
                string lastName = txtLastName.Text;
                string firstName = txtFirstName.Text;
                string city = txtCity.Text;
                string state = txtState.Text;
                string gender = comboGender.SelectedItem.ToString();

                DateTime date1 = Convert.ToDateTime(txtBirthDate.Text);
                //string dt = txtBirthDate.Text;
                //DateTime date1 = DateTime.ParseExact(dt, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                int age = CalculateAge(date1);

                string ageGroup = "";
                if (age < 18)
                {
                    ageGroup = "Minor";
                }
                else
                {
                    ageGroup = "Adult";
                }

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Database21;Integrated Security=True;Pooling=False;";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Insert into patient(practiceId,lastName,firstName,city,state,gender,date1,age,ageGroup) values (" + practiceId + ",'" + lastName + "','" + firstName + "','" + city + "','" + state + "','" + gender + "','" + date1 + "'," + age + ",'" + ageGroup + "')";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Data Format");
            }
            MessageBox.Show("Data Saved");



        }
        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin\Database21.mdf;Integrated Security=True;Connect Timeout=30 ;");
            con.Open();
            string query = "Select * From patient ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }
        public void Clear()
        {
            comboGender.ResetText();
            txtLastName.Clear();
            txtFirstName.Clear();
            txtCity.Clear();
            txtPracticeId.Clear();
            txtState.Clear();
            txtBirthDate.Clear();
        }
        private static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
        SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin\Database21.mdf;Integrated Security=True;Connect Timeout=30 ;");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin\Database21.mdf;Integrated Security=True;Connect Timeout=30 ;");
                con1.Open();
                string query = "Insert into Appointment (PID,ApptID,ApptDate,Operatory,Provider,ApptTime,ApptLength,Amount,ClinicId) VALUES ('" + txtPatientID.Text + "','" + txtAppointmentID.Text + "','" +txtADate.Text+ "','" + txtOperatory.Text + "','" + txtProvider.Text + "','" + txtAppointmentTime.Text + "','" + txtAppointmentLength.Text + "','" + txtAmount.Text + "','" + txtClinicID.Text + "')";

                SqlDataAdapter sda = new SqlDataAdapter(query, con1);
                sda.SelectCommand.ExecuteNonQuery();
                con1.Close();
                MessageBox.Show(" Appointment Data Inserted Successfuly");
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            };



        }

        private void btnView_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin\Database21.mdf;Integrated Security=True;Connect Timeout=30 ;");
            con.Open();
            String query = "Select * From Appointment ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();

        }

        private void FixedAppointments_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin\Database21.mdf;Integrated Security=True;Connect Timeout=30 ;");
            con.Open();
            string query = "Delete from Appointment where Amount<50";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            con.Close();
        }
        public void Clearr()
        {
            txtPatientID.Clear();
            txtAppointmentID.Clear();
            txtAmount.Clear();
            txtAppointmentLength.Clear();
            txtAppointmentTime.Clear();
            txtOperatory.Clear();
            txtAmount.Clear();
            txtProvider.Clear();
            txtClinicID.Clear();

        }

        public void button2_Click(object sender, EventArgs e)
        {
            Clearr();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            
            con.Open();
            string query = "insert into trans values( '" + textTransactionID.Text + "','" + textPatientID.Text + "','" + textProcedureType.Text + "','" + textProDate.Text + "','" + textProvider.Text + "','" + textAmount.Text + "','" + textClinicID.Text + "')";
            SqlDataAdapter saa = new SqlDataAdapter(query, con);
            saa.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(" Transaction Data Inserted Successfully....");


        }

        private void View_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = " Select *From trans";
            SqlDataAdapter sa = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            dataGridView3.DataSource = dt;
            con.Close();
        }

        private void SaveClinic_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@" Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin\Database21.mdf;Integrated Security=True;Connect Timeout=30;");
            con.Open();
            string que = "insert into Clinic values('" + txtCliniID.Text + "','" + txtCName.Text + "','" + txtCityy.Text + "','" + txtStatee.Text + "') ";
            SqlDataAdapter sdaa = new SqlDataAdapter(que, con);
            sdaa.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Clinic Data Inserted Successfully");
        }

        private void ClinicDetails_Enter(object sender, EventArgs e)
        {

        }

        private void ViewClinicData_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin\Database21.mdf;Integrated Security=True;Connect Timeout=30 ;");
            con.Open();
            string query = " Select *From Clinic";
            SqlDataAdapter sa = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            dataGridView4.DataSource = dt;
            con.Close();
        }
        public void ClinicCancel()
        {
            txtCliniID.Clear();
            txtCName.Clear();
            txtCityy.Clear();
            txtStatee.Clear();
        }
        private void CancelData_Click(object sender, EventArgs e)
        {
            ClinicCancel();
        }

        private void DoctorSave_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "insert into Doctor values('" + DID.Text + "','" + DLName.Text + "','" + DFName.Text + "','" + DCity.Text + "','" + DState.Text + "','" + DClinicID.Text + "')";
            SqlDataAdapter saa = new SqlDataAdapter(query, con);
            saa.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Doctor Details Inserted Successfully....");

        }

        private void DoctorView_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = " Select *From Doctor";
            SqlDataAdapter sa = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            dataGridView5.DataSource = dt;
            con.Close();
        }

        private void DCancel_Click(object sender, EventArgs e)
        {
            DID.Clear();
            DLName.Clear();
            DFName.Clear();
            DCity.Clear();
            DState.Clear();
            DClinicID.Clear();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin\Database21.mdf;Integrated Security=True;Connect Timeout=30 ;");
            con.Open();
            string query = "select distinct t.procedureType as ProcedureTypes,c.ClinicName,p.providerName as ProviderName,year(t.proceduredate) as Year,month(t.proceduredate) as Month,t.Amount as Amounts";
            query += " from Clinic c inner";
            query += " join trans t";
            query += " ON c.ClinicID = t.ClinicID inner";
            query += " join Provider p";
            query += " on p.prov_id = t.provider  ";
            SqlDataAdapter sa = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            dataGridView3.DataSource = dt;
            con.Close();
        }

        private void CountAPPT_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin\Database21.mdf;Integrated Security=True;Connect Timeout=30 ;");
            con.Open();
            string query = "select  count(clinicid) as Clinic, count(year(ApptDate)) as Year,count(Month(ApptDate)) as Month from Appointment";

            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
            
        }
    }
}
