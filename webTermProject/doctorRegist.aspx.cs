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
    public partial class hospitalRegist : System.Web.UI.Page
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
            hfDoctorID.Value = "";
            txtFirst.Text = "";
            txtLast.Text = "";
            txtMail.Text = "";
            txtContact.Text = "";

            lblSuccessMessage.Text = lblErrorMessage.Text = "";
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
        }

        protected void btnSave_ClickThesis(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("DoctorCreateorUpdate", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@DoctorID", (hfDoctorID.Value == "" ? 0 : Convert.ToInt32(hfDoctorID.Value)));
            sqlCmd.Parameters.AddWithValue("@DOCTOR_FNAME", txtFirst.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@DOCTOR_LNAME", txtLast.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@DOCTOR_CONTACT_NUMBER", txtContact.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Doctor_E_MAIL", txtMail.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@DOCTOR_DEPARTMENT_ID", ddlDepartment.SelectedItem.Text.ToString());

            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            string InstituteID = hfDoctorID.Value;
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
            SqlDataAdapter sqlDa = new SqlDataAdapter("DoctorViewAll", sqlCon);
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
            SqlDataAdapter sqlDa = new SqlDataAdapter("DoctorViewByID", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@DoctorID", InstituteID);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            hfDoctorID.Value = InstituteID.ToString();
            txtFirst.Text = dtbl.Rows[0]["DOCTOR_FNAME"].ToString();
            txtLast.Text = dtbl.Rows[0]["DOCTOR_LNAME"].ToString();
            txtMail.Text = dtbl.Rows[0]["DOCTOR_E_MAIL"].ToString();
            txtContact.Text = dtbl.Rows[0]["DOCTOR_CONTACT_NUMBER"].ToString();
            btnSave.Text = "Update";
            btnDelete.Enabled = true;
        }

        protected void btnDelete_ClickThesis(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("DoctorDeleteByID", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@DoctorID", Convert.ToInt32(hfDoctorID.Value));
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            Clear();
            FillGridView();
            lblSuccessMessage.Text = "Deleted Successfully";
        }


    }
}