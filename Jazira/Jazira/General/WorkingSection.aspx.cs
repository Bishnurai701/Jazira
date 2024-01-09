using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Configuration;
using System.Globalization;
using JaziraBusinessLayer.BLL.General;

namespace Jazira.General
{
    public partial class WorkingSection : System.Web.UI.Page
    {
        JaziraBusinessLayer.BLL.General.WorkingSectionBLL objWorkingSectionBLL =new JaziraBusinessLayer.BLL.General.WorkingSectionBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["editAlert"]) == true)
            {
                alert.Visible = true;
                lblMsg.Text = "Data Updated Successfully.";
                lblMsgType.Text = "Well done! ";
                alert.Attributes["class"] = "alert alert-success";
                Session["editAlert"] = false;
            }
            if (Convert.ToBoolean(Session["delAlert"]) == true)
            {
                alert.Visible = true;
                lblMsg.Text = "Data Deleted Successfully";
                lblMsgType.Text = "Well Done! ";
                alert.Attributes["class"] = "alert alert-success";
                Session["delAlert"] = false;
            }
            if (Convert.ToBoolean(Session["addAlert"]) == true)
            {
                alert.Visible = true;
                lblMsg.Text = "Data Saved Successfully";
                lblMsgType.Text = "Well Done! ";
                alert.Attributes["class"] = "alert alert-success";
                Session["addAlert"] = false;
            }

            int Id = Convert.ToInt32(Request.QueryString["Id"]);
            increaseWSectionId(Id);
            string act = Request.QueryString["act"];
            if (!IsPostBack)
            {
                if (act == "add" || act == "edit")
                {
                    if (act == "edit")
                    {
                        SetDataToField(Id);
                    }
                }
                if (act == "del")
                {
                    try
                    {
                        if (objWorkingSectionBLL.Delete(Id))
                        {
                            alert.Visible = true;
                            lblMsgType.Text = "Data Deleted Successfully";
                            lblMsg.Text = "Well Done! ";
                            alert.Attributes["class"] = "alert alert-success";
                            Session["delAlert"] = true;
                            //setSessionMsg("alert-success alert col-md-6", "Deleted Successfully", false);
                            Response.Redirect("WorkingSection.aspx?act=add", false); 
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        alert.Attributes["class"] = "alert alert-error";
                        lblMsgType.Text = "Oh,DeletesqlEx! ";
                        alert.Visible = true;
                        lblMsg.Text = sqlex.Message + "" + sqlex.Source;
                    }
                    catch (Exception ex)
                    {
                        alert.Attributes["class"] = "alert alert-error";
                        lblMsgType.Text = "Oh, delete errorEx! ";
                        lblMsg.Text = ex.Message + "" + ex.Source;
                        alert.Visible = true;   
                    }
                }
                if (act == "search" || act == "list")
                {
                    DGVWSection();
                }
            }

        }
       
        #region fuction

        #region SetDataToField function
        private void SetDataToField(int Id)
        {
            try
            {
                DataTable dt = new JaziraBusinessLayer.BLL.General.WorkingSectionBLL().SetWorkingSectionName(Id);
                txtWorkingSectionCode.Text = dt.Rows[0]["WorkingSectionCode"].ToString();
                txtWorkingSectionName.Text = dt.Rows[0]["WorkingSectionName"].ToString();
                btnSave.Text = "Update";
            }
            catch (SqlException sqlex)
            {
                alert.Attributes["class"] = "alert alert-error";
                lblMsgType.Text = "Oh,SetaDatatofieldsql! ";
                alert.Visible = true;
                lblMsg.Text = "sql error";
                lblMsg.Text = sqlex.Message + "" + sqlex.Source;  
            }
            catch (Exception ex)
            {
                alert.Attributes["class"] = "alert alert-error";
                lblMsgType.Text = "Oh, SetDataToFieldEx! ";
                lblMsg.Text = ex.Message + "" + ex.Source;
                alert.Visible = true; 
            }
        }
        #endregion

        #region IncreaseId funtion
        private void increaseWSectionId(int Id)
        {
            int wscode;
          
            SqlConnection connWSec = new SqlConnection(@"Data Source=PC\SQLEXPRESS;Initial Catalog=Jaziradb;Persist Security Info=True;User ID=admin; Password=adminn");
            if (txtWorkingSectionCode.Text == "")
            {
                connWSec.Open();
                string sql = "select WorkingSectionCode from Tbl_WorkingSection";
                SqlDataAdapter sqlda = new SqlDataAdapter(sql,connWSec);
                DataSet ds = new DataSet();
                sqlda.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    wscode = ds.Tables[0].Rows.Count;
                    wscode = (wscode-1);
                    wscode += 1;
                    txtWorkingSectionCode.Text = Convert.ToString(wscode);
                    txtWorkingSectionName.Focus();
                   
                }
                else
                {
                    txtWorkingSectionCode.Text = "0";
                    txtWorkingSectionName.Focus();
                }
            }
            connWSec.Close();
        }
        #endregion

        #region SetData function
        private WorkingSectionBLL SetDataWorkingSection()
        {
            objWorkingSectionBLL.WorkingSectionId = Convert.ToInt32(Request.QueryString["Id"]);
            objWorkingSectionBLL.WorkingSectionCode = Convert.ToInt32(txtWorkingSectionCode.Text);
            objWorkingSectionBLL.WorkingSectionName = txtWorkingSectionName.Text.Trim().Replace("'","''");
            objWorkingSectionBLL.Status='A';
            objWorkingSectionBLL.LoginId = 1;
            objWorkingSectionBLL.LogDateTime = DateTime.Now;
            return objWorkingSectionBLL;
        }
        #endregion

        #endregion

        #region Save Even
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtWorkingSectionName.Text) == true)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Plz! Type Working Section Name. Not Allowed Blanks!";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Enter value", true);
                    txtWorkingSectionName.Focus();
                    return;
                }
                int Id = Convert.ToInt32(Request.QueryString["Id"]);
                if (WorkingSectionBLL.ValidationWorkingSectionName(txtWorkingSectionName.Text, Id) == false)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Working Section Name is Already Exist. Please! Enter Next Name.";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Duplicate", true);
                    txtWorkingSectionName.Focus();
                    return;
                }
                objWorkingSectionBLL=SetDataWorkingSection();
                if (objWorkingSectionBLL.Save(objWorkingSectionBLL))
                {
                    Clear();
                    alert.Attributes["class"] = "alert alert-success";
                    lblMsgType.Text = "Well Done! ";
                    lblMsg.Text = "Data Saved Successfully.";
                    alert.Visible = true;
                    Session["addAlert"] = true;
                    if (objWorkingSectionBLL.WorkingSectionId > 0)
                    {
                        Session["editAlert"] = true;
                        Response.Redirect("WorkingSection.aspx?act=add", false);
                    }
                    //setSessionMsg("alert-success alert col-md-6", "Saved", true);
                    Response.Redirect("WorkingSection.aspx?act=add", false);
                }
            }
            catch (SqlException sqlex)
            {
                alert.Attributes["class"] = "alert alert-warning";
                lblMsgType.Text = "Oh!, Save Even sql Error ";
                lblMsg.Text = sqlex.Message + "" + sqlex.Source;
                alert.Visible = true;
                //setSessionMsg("alert-success alert col-md-6", "" + exe + "", true);
            }
            catch (Exception ex)
            {
                alert.Attributes["Class"] = "alert alert-warning";
                lblMsgType.Text = "Oh, Save Even Exception Error ";
                lblMsg.Text = ex.Message + " " + ex.Source;
                alert.Visible = true;
                //setSessionMsg("alert-success alert col-md-6", "" + ex + "", true);
            }
        }
        #endregion

        #region Clear Even
        private void Clear()
        {
            txtWorkingSectionName.Text = "";
        }
        #endregion

        #region Search even

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DGVWSection();
        }

        #endregion

        #region GridView funtion

        #region PageIndex function
        protected void dgvWorkingSection_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvWorkingSection.PageIndex = e.NewPageIndex;
            DGVWSection();
        }
        #endregion

        #region DGV function
        private void DGVWSection()
        {
            try
            {
                string wsectioncode = txtSearchFormCode.Text.Trim().Replace("'","''");
                int Id = Convert.ToInt32(Request.QueryString["Id"]);
                DataTable dt = JaziraBusinessLayer.BLL.General.WorkingSectionBLL.GetWSectionCode(wsectioncode);
                dgvWorkingSection.DataSource = dt;
                dgvWorkingSection.DataBind();
                if (dt.Rows.Count == 0)
                    divNoDaa.Visible = true;
                else
                    divNoDaa.Visible = false;
            }
            catch (SqlException sqlex)
            {
                alert.Attributes["Class"] = "alert alert-error";
                lblMsgType.Text = "Oh";
                lblMsg.Text = "Unexpected SQL Error. Please contact adminnistrator";
                alert.Visible = true;
                lblMsg.Text = sqlex.Message + " " + sqlex.Source;  
            }
            catch (Exception ex)
            {
                alert.Attributes["Class"] = "alert alert-error";
                lblMsgType.Text = "Oh! GridView Exception! ";
                lblMsg.Text = ex.Message + " " + ex.Source;
                alert.Visible = true;
            }
        }

        #endregion

        #endregion
    }
}