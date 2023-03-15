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
    public partial class labResult : System.Web.UI.Page
    {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=LAPTOP-7NF29R6C;Initial Catalog=HospitalManagment;Integrated Security=true;");
            protected void Page_Load(object sender, EventArgs e)
            {

                if (!IsPostBack)
                {
                string mainconn = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(mainconn);
                string sqlquery = "SELECT * FROM [HospitalManagment].[dbo].[PATIENT]";
                SqlDataAdapter sda = new SqlDataAdapter(sqlquery, sqlconn);
                DataTable dt1 = new DataTable();
                sda.Fill(dt1);
                ddlPatId.DataSource = dt1;
                ddlPatId.DataTextField = "PATIENT_ID";
                ddlPatId.DataBind();

                btnDeleteLab.Enabled = false;
                FillGridView();
                }
        }

            protected void btnClear_ClickGr(object sender, EventArgs e)
            {
                Clear();
            }

            public void Clear()
            {
                hfLabID.Value = "";
                //ddlPatId.SelectedValue = "";
                ddlRes.SelectedValue = "";

                lblSuccessMessage.Text = lblErrorMessage.Text = "";
                btnSaveLab.Text = "Save";
                btnDeleteLab.Enabled = false;
            }

            protected void btnSave_ClickGr(object sender, EventArgs e)
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("LabCreateResult", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
            //sqlCmd.Parameters.AddWithValue("@PatID", (hfLabID.Value == "" ? 0 : Convert.ToInt32(hfLabID.Value)));
                sqlCmd.Parameters.AddWithValue("@PatID", ddlPatId.SelectedItem.Text.ToString());
                sqlCmd.Parameters.AddWithValue("@LabRes", ddlRes.SelectedItem.Text.ToString());

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
                string InstituteID = hfLabID.Value;
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
                SqlDataAdapter sqlDa = new SqlDataAdapter("LabViewAll", sqlCon);
                
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtbl2 = new DataTable();
                sqlDa.Fill(dtbl2);
                sqlCon.Close();
                gvPatientLab.DataSource = dtbl2;
                gvPatientLab.DataBind();
            }

            protected void lnk_OnClickInst(object sender, EventArgs e)
            {
                int InstituteID = Convert.ToInt32((sender as LinkButton).CommandArgument);
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("LabViewByID", sqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("@PatID", InstituteID);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                sqlCon.Close();
                hfLabID.Value = InstituteID.ToString();
                ddlPatId.SelectedValue = dtbl.Rows[0]["PATIENT_ID"].ToString();
                ddlRes.SelectedValue = dtbl.Rows[0]["COVID_RESULT"].ToString();

                
                //btnSaveLab.Text = "Update";
                btnDeleteLab.Enabled = true;
            }

            protected void btnDelete_ClickGr(object sender, EventArgs e)
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("LabDeleteByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PatID", Convert.ToInt32(hfLabID.Value));
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
                Clear();
                FillGridView();
                lblSuccessMessage.Text = "Deleted Successfully";
            }


       
    }
}