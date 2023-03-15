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
    public partial class deparmentInsert : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=LAPTOP-7NF29R6C;Initial Catalog=HospitalManagment;Integrated Security=true;");
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
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
            hfDepartID.Value = "";
            txtDepart.Text = "";


            lblSuccessMessage.Text = lblErrorMessage.Text = "";
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
        }

        protected void btnSave_ClickThesis(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("DepartmentCreateorUpdate", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@DepartID", (hfDepartID.Value == "" ? 0 : Convert.ToInt32(hfDepartID.Value)));
            sqlCmd.Parameters.AddWithValue("@DepName", txtDepart.Text.Trim());


            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            string InstituteID = hfDepartID.Value;
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
            SqlDataAdapter sqlDa = new SqlDataAdapter("DepartViewAll", sqlCon);
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
            SqlDataAdapter sqlDa = new SqlDataAdapter("DepartViewByID", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@DepartID", InstituteID);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            hfDepartID.Value = InstituteID.ToString();
            txtDepart.Text = dtbl.Rows[0]["DEPARTMENT_NAME"].ToString();
            
            btnSave.Text = "Update";
            btnDelete.Enabled = true;
        }

        protected void btnDelete_ClickThesis(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("DepartDeleteByID", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@DepartID", Convert.ToInt32(hfDepartID.Value));
            sqlCmd.ExecuteNonQuery();   
            sqlCon.Close();
            Clear();
            FillGridView();
            lblSuccessMessage.Text = "Deleted Successfully";
        }
    }
}