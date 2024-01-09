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
using JaziraBusinessLayer.BLL.Security;

namespace Jazira.Security
{
    public partial class FormMaster : System.Web.UI.Page
    {
        JaziraBusinessLayer.BLL.Security.FormMasterBLL objFormMasterBLL = new JaziraBusinessLayer.BLL.Security.FormMasterBLL();
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
                        if (objFormMasterBLL.Delete(Id))
                        {
                            alert.Visible = true;
                            lblMsgType.Text = "Data Deleted Successfully";
                            lblMsg.Text = "Well Done! ";
                            alert.Attributes["class"] = "alert alert-success";
                            Session["delAlert"] = true;
                            //setSessionMsg("alert-success alert col-md-6", "Deleted Successfully", false);
                            Response.Redirect("FormMaster.aspx?act=add", false); 
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
                if (act == "list" || act == "search")
                {
                    DGVFormMaster();
                }
            }

        }

       

        #region Function

        #region SetDataToField
        private void SetDataToField(int Id)
        {
            try
            {
                DataTable dt = new JaziraBusinessLayer.BLL.Security.FormMasterBLL().SetFromPageName(Id);
                txtFromCode.Text = dt.Rows[0]["FormCode"].ToString();
                txtPageName.Text = dt.Rows[0]["PagenName"].ToString();
                txtDescription.Text = dt.Rows[0]["DisplayName"].ToString();
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

        #region SetData function
        private FormMasterBLL SetDataForm()
        {
            objFormMasterBLL.FormId = Convert.ToInt32(Request.QueryString["Id"]);
            objFormMasterBLL.FormCode = Convert.ToInt32(txtFromCode.Text);
            objFormMasterBLL.PagenName = txtPageName.Text.Trim().Replace("'","''");
            objFormMasterBLL.DisplayName = txtDescription.Text.Trim().Replace("'","''");
            objFormMasterBLL.Status='A';
            objFormMasterBLL.LoginId = 1;
            objFormMasterBLL.LogDateTime = DateTime.Now;
            return objFormMasterBLL;
        }
        #endregion

        #endregion

        #region Save even
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFromCode.Text) == true)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Plz! Type Form Code. Not Allowed Blanks!";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Enter value", true);
                    txtFromCode.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtPageName.Text) == true)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Plz! Type Form Page Name. Not Allowed Blanks!";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Enter value", true);
                    txtPageName.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtDescription.Text) == true)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Plz! Type Form Description. Not Allowed Blanks!";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Enter value", true);
                    txtDescription.Focus();
                    return;
                }
                int Id = Convert.ToInt32(Request.QueryString["Id"]);
                if (FormMasterBLL.ValidationFormCode(txtFromCode.Text, Id) == false)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Form Code is Already Exist. Please! Enter Next Name.";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Duplicate", true);
                    txtFromCode.Focus();
                    return;
                }
                if (FormMasterBLL.ValidationPageName(txtPageName.Text, Id) == false)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Form Page Name is Already Exist. Please! Enter Next Name.";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Duplicate", true);
                    txtPageName.Focus();
                    return;
                }
                objFormMasterBLL = SetDataForm();
                if (objFormMasterBLL.Save(objFormMasterBLL))
                {
                    Clear();
                    alert.Attributes["class"] = "alert alert-success";
                    lblMsgType.Text = "Well Done! ";
                    lblMsg.Text = "Data Saved Successfully.";
                    alert.Visible = true;
                    Session["addAlert"] = true;
                    if (objFormMasterBLL.FormId > 0)
                    {
                        Session["editAlert"] = true;
                        Response.Redirect("FormMaster.aspx?act=add", false);
                    }
                    //setSessionMsg("alert-success alert col-md-6", "Saved", true);
                    Response.Redirect("FormMaster.aspx?act=add", false);
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
            txtFromCode.Text = "";
            txtPageName.Text = "";
            txtDescription.Text = "";
        }
        #endregion

        #region Search even
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DGVFormMaster();
        }
        #endregion

        #region GridView function

        #region PageIndex function
        protected void dgvForm_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvForm.PageIndex = e.NewPageIndex;
            DGVFormMaster();

        }
        #endregion

        #region DGV funtion
        private void DGVFormMaster()
        {
            try
            {
                string fcode = txtSearchFormCode.Text.Trim().Replace("'","''");
                int Id = Convert.ToInt32(Request.QueryString["Id"]);
                DataTable dt = JaziraBusinessLayer.BLL.Security.FormMasterBLL.GetFormCode(fcode);
                dgvForm.DataSource = dt;
                dgvForm.DataBind();
                if (dt.Rows.Count == 0)
                    divNoDaa.Visible = true;
                else
                    divNoDaa.Visible = false;
            }
            catch (SqlException sqlex)
            {
                alert.Attributes["Class"] = "alert alert-error";
                lblMsgType.Text = "Oh";
                lblMsg.Text = "Unexpected SQL Error. Please contact Administrator";
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