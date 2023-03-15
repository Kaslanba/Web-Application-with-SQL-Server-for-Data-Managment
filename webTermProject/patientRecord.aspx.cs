using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace webTermProject
{
    public partial class patientRecord : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=LAPTOP-7NF29R6C;Initial Catalog=HospitalManagment;Integrated Security=true;");
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string mainconn = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(mainconn);
                string sqlquery = "SELECT * FROM [HospitalManagment].[dbo].[HOSPITAL_DEPARTMENT]";
                SqlDataAdapter sda = new SqlDataAdapter(sqlquery, sqlconn);
                DataTable dt1 = new DataTable();
                sda.Fill(dt1);
                ddlDepartment.DataSource = dt1;
                ddlDepartment.DataTextField = "DEPARTMENT_ID";
                ddlDepartment.DataBind();
                
                btnDelete.Enabled = false;
                FillGridView();
            }
        }

        protected void btnClear_ClickThesis(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            hfPatientID.Value = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtMedicine.Text = "";
            txtContact.Text = "";
            txtEmail.Text = "";
            txtEmail.Text = "";
            txtIll.Text = "";
            txtDia.Text = "";
            txtGiven.Text = "";

            lblSuccessMessage.Text = lblErrorMessage.Text = "";
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
        }

        protected void btnSave_ClickThesis(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("PatientCreateorUpdate", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@PatientID", (hfPatientID.Value == "" ? 0 : Convert.ToInt32(hfPatientID.Value)));
            sqlCmd.Parameters.AddWithValue("@PATIENT_FNAME", txtFirstName.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@PATIENT_LNAME", txtLastName.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@PATIENT_MEDICINES", txtMedicine.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@PATIENT_EMERGENCY_CONTACT_NUMBER", txtContact.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@E_MAIL", txtEmail.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@DEPARTMENT_ID", ddlDepartment.SelectedItem.Text.ToString());
            sqlCmd.Parameters.AddWithValue("@EXAMINATION_ILNESS", txtIll.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@EXAMINATION_DIAGNOSIS", txtDia.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@EXAMINATION_GIVEN_MEDICINES", txtGiven.Text.Trim());


            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            string InstituteID = hfPatientID.Value;
            Clear();
            if (InstituteID == "")
                lblSuccessMessage.Text = "Saved Successfully";
            else
                lblSuccessMessage.Text = "Updated Successfully";
            FillGridView();
        }
        
        void FillGridView()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("PatientViewAll", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl2 = new DataTable();
            sqlDa.Fill(dtbl2);
            sqlCon.Close();
            gvInst.DataSource = dtbl2;
            gvInst.DataBind();
        }

        protected void lnk_OnClickInst(object sender, EventArgs e)
        {
            int InstituteID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("PatientViewByID", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@PatientID", InstituteID);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            hfPatientID.Value = InstituteID.ToString();
            txtFirstName.Text = dtbl.Rows[0]["PATIENT_FNAME"].ToString();
            txtLastName.Text = dtbl.Rows[0]["PATIENT_LNAME"].ToString();
            txtMedicine.Text = dtbl.Rows[0]["PATIENT_MEDICINES"].ToString();
            txtContact.Text = dtbl.Rows[0]["PATIENT_EMERGENCY_CONTACT_NUMBER"].ToString();
            txtEmail.Text = dtbl.Rows[0]["PATIENT_E_MAIL"].ToString();
            ddlDepartment.SelectedValue = dtbl.Rows[0]["DEPARTMENT_ID"].ToString();
            txtIll.Text = dtbl.Rows[0]["PATIENT_EXAMINATION_ILNESS"].ToString();
            txtDia.Text = dtbl.Rows[0]["PATIENT_EXAMINATION_DIAGNOSIS"].ToString();
            txtGiven.Text = dtbl.Rows[0]["PATIENT_EXAMINATION_GIVEN_MEDICINES"].ToString();
            
            btnSave.Text = "Update";
            btnDelete.Enabled = true;
        }

        protected void btnDelete_ClickThesis(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("PatientDeleteByID", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@PatientID", Convert.ToInt32(hfPatientID.Value));
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            Clear();
            FillGridView();
            lblSuccessMessage.Text = "Deleted Successfully";
        }
    }
}