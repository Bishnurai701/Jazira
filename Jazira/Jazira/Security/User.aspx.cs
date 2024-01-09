using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using JaziraBusinessLayer.BLL.Security;
using JaziraBusinessLayer.DLL.Security;
using JaziraBusinessLayer.DLL.Security.Interface;


namespace Jazira.Security
{
    public partial class User : System.Web.UI.Page
    {
        JaziraBusinessLayer.BLL.Security.UserBLL objUserBLL = new JaziraBusinessLayer.BLL.Security.UserBLL();
        ISecurity encryptdecrypt = new EncryptDecryptDLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["editAlert"]) == true)
            {
                alert.Visible = true;
                lblMsg.Text = "Data Update Successfully! ";
                lblMsgType.Text = "Well Done! ";
                alert.Attributes["class"] = "alert alert-success";
                Session["editAlert"] = false;
            }
            if (Convert.ToBoolean(Session["delAlert"]) == true)
            {
                alert.Visible = true;
                lblMsg.Text = "Data Deleted Successfully! ";
                lblMsgType.Text = "Well done! ";
                alert.Attributes["class"] = "alert alert-success";
                Session["delAlert"] = false;
            }

            int Id = Convert.ToInt32(Request.QueryString["Id"]);
            string act = Request.QueryString["act"];
            if (!IsPostBack)
            {
                if (act == "edit" || act == "add")
                {
                    CODE.ddlGeneral.LoadUserGroup(ddlUserGroup,new JaziraBusinessLayer.BLL.Security.UserBLL().GetUserGroup());
                    if (act == "edit")
                    {
                        SetDataToField(Id);
                    }
                }
                if (act == "del")
                {
                    try
                    {
                        if (objUserBLL.Delete(Id))
                        {
                            alert.Visible = true;
                            lblMsgType.Text = "Data Deleted Successfully! ";
                            lblMsg.Text = "Well done! ";
                            alert.Attributes["class"] = "alert alert-success";
                            Session["delAlert"] = true;
                            Response.Redirect("User.aspx?act=add", false);
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
                    DGVUser();
                }
            }
           
        }

       

        #region SetDataToField function
        private void SetDataToField(int Id)
        {
            try
            {
                DataTable dt = JaziraBusinessLayer.BLL.Security.UserBLL.SetUser(Id);
                txtUserCode.Text = dt.Rows[0]["UserCode"].ToString();
                txtUserName.Text = dt.Rows[0]["UserName"].ToString();
                txtLoginName.Text = dt.Rows[0]["LoginName"].ToString();
                //txtPassword.Text = dt.Rows[0]["Password"].ToString();
                ddlUserGroup.SelectedValue = dt.Rows[0]["UserGroupId"].ToString();
                string SuperUser = Convert.ToBoolean(dt.Rows[0]["SuperUser"]).ToString();
                if (Convert.ToBoolean(SuperUser)==true)
                {
                    rbtSuperYes.Checked = true;
                }
                else
                {
                    rbtSuperYes.Checked = false;
                }

               string JobView = Convert.ToBoolean(dt.Rows[0]["JobView"]).ToString();
               if (Convert.ToBoolean(JobView) == true)
               {
                   chkJobView.Checked = true;
               }
               else
               {
                   chkJobView.Checked = false;
               }
               string GroupView = Convert.ToBoolean(dt.Rows[0]["GroupView"]).ToString();
               if (Convert.ToBoolean(GroupView) == true)
               {
                   chkGroupView.Checked = true;
               }
               else
               {
                   chkGroupView.Checked = false;
               }
               string IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]).ToString();
               if (Convert.ToBoolean(IsActive)==true)
               {
                   rbtActive.Checked = true;
               }
               else
               {
                   rbtActive.Checked = false;
               }
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

        #region Save_Click even
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUserCode.Text) == true)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Plz! Type User Code. Not Allowed Blanks!";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Enter value", true);
                    txtUserCode.Focus();
                    return; 
                }
                if (string.IsNullOrWhiteSpace(txtUserName.Text) == true)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Plz! Type User Name. Not Allowed Blanks!";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Enter value", true);
                    txtUserName.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtLoginName.Text) == true)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Plz! Type LoginID. Not Allowed Blanks!";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Enter value", true);
                    txtLoginName.Focus();
                    return;
                }
                string act = Request.QueryString["act"];
                if (act == "add")
                {
                    if (string.IsNullOrWhiteSpace(txtPassword.Text) == true)
                    {
                        alert.Visible = true;
                        alert.Attributes["class"] = "alert alert-warning";
                        lblMsg.Text = "You missed to type Password. Not Allowed Blanks!";
                        lblMsgType.Text = "Warning! ";
                        //setSessionMsg("alert-error alert col-md-6", "Enter value", true);
                        txtPassword.Focus();
                        return;
                    }
                    if ((txtPassword.Text == txtConfirmPassword.Text) == false)
                    {
                        alert.Visible = true;
                        alert.Attributes["class"] = "alert alert-warning";
                        lblMsg.Text = "Password does not match! ";
                        lblMsgType.Text = "Warning! ";
                        txtPassword.Focus();
                        return;
                    }
                }
                int Id = Convert.ToInt32(Request.QueryString["Id"]);
                if (UserBLL.ValidationUserCode(txtUserCode.Text,Id) == false)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "User Code is Already Exist. Please! Enter Unique Code.";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Duplicate", true);
                    txtUserCode.Focus();
                    return;
                }
                if (UserBLL.ValidationLoginName(txtLoginName.Text, Id) == false)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "UserID is Already Exist. Please! Enter Unique ID.";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Duplicate", true);
                    txtLoginName.Focus();
                    return;
                }
                objUserBLL = SetDataUser();
                if (objUserBLL.Save(objUserBLL))
                {
                    Clear();
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-success";
                    lblMsgType.Text = "Well Done! ";
                    lblMsg.Text = "Data Saved Successfully.";
                    if (objUserBLL.UserId > 0)
                    {
                        Session["editAlert"] = true;
                        Response.Redirect("User.aspx?act=add", false);
                    }
                    //setSessionMsg("alert-success alert col-md-6", "Saved", true);
                    Response.Redirect("User.aspx?act=add", false);
                }

            }
            catch (SqlException sqlex)
            {
                alert.Attributes["class"] = "alert alert-warning";
                lblMsgType.Text = "Oh!, Save Even sql Error ";
                lblMsg.Text = sqlex.Message + "" + sqlex.Source;
                alert.Visible = true;
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

        #region onrowcommand gridview funtion
        protected void dgvUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = ((GridViewRow)((Button)(e.CommandSource)).Parent.Parent).RowIndex;
            int id = Convert.ToInt32(dgvUser.DataKeys[index].Value);
            if (e.CommandName == "ChangePassword")
            {
                Response.Redirect("User.aspx?act=changepassword&Id=" + id);
            }
        }
        #endregion

        #region btnChangePassword even
        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["Id"];
            string password = objUserBLL.Encrypt(txtOldPassword.Text);
            if (new JaziraBusinessLayer.BLL.Security.UserBLL().ValidationOldPassword(id, password))
            {
                if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Plz! Type New Password. Not Allowed Blanks!";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Enter value", true);
                    txtNewPassword.Focus();
                    return;
                }
                if (txtNewPassword.Text == txtNewConfrim.Text)
                {
                    string newpassword = objUserBLL.Encrypt(txtNewPassword.Text);
                    if (new JaziraBusinessLayer.BLL.Security.UserBLL().ChangePassword(id, newpassword))
                    {

                        alert.Visible = true;
                        alert.Attributes["class"] = "alert alert-success";
                        lblMsgType.Text = "Well Done! ";
                        lblMsg.Text = "Password Changed Successfully.";
                        return;
                    }
                    else
                    {
                        alert.Visible = true;
                        alert.Attributes["class"] = "alert alert-warning";
                        lblMsgType.Text = "Warning! ";
                        lblMsg.Text = "Error Occur while changing Password.";
                        return;
                    }
                }
                else
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsgType.Text = "Warning! ";
                    lblMsg.Text = "New Password do not match.";
                    return;
                }
            }
            else
            {
                alert.Visible = true;
                alert.Attributes["class"] = "alert alert-warning";
                lblMsgType.Text = "Warning! ";
                lblMsg.Text = "Old Password do not match.";
                return;
            }

        }
        #endregion

        #region clear even
        private void Clear()
        {
            txtUserCode.Text = "";
            txtUserName.Text = "";
            txtLoginName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            ddlUserGroup.SelectedValue = null;
            chkGroupView.Checked = false;
            chkJobView.Checked = false;
            rbtActive.Checked = false;
            rbtInactive.Checked = false;
            rbtSuperNo.Checked = false;
            rbtSuperYes.Checked = false;

        }
        #endregion

        #region SetData function for Save
        private UserBLL SetDataUser()
        {
            string password = objUserBLL.Encrypt(txtPassword.Text);
            objUserBLL.UserId = Convert.ToInt32(Request.QueryString["Id"]);
            objUserBLL.UserCode = txtUserCode.Text.Trim().Replace("'", "''");
            objUserBLL.UserName = txtUserName.Text.Trim().Replace("'", "''");
            objUserBLL.LoginName = txtLoginName.Text.Trim().Replace("'", "''");
            objUserBLL.Password = password; //txtPassword.Text.Trim().Replace("'", "''");
            objUserBLL.IsLogin='N';
            objUserBLL.UserGroupId = Convert.ToInt32(ddlUserGroup.SelectedValue);
            if (chkJobView.Checked)
            {
                objUserBLL.JobView = true;
            }
            else
            {
                objUserBLL.JobView = false;
            }
            if (chkGroupView.Checked)
            {
                objUserBLL.GroupView = true;
            }
            else
            {
                objUserBLL.GroupView = false;
            }

            if (rbtSuperYes.Checked==true)
            {
                objUserBLL.SuperUser = true;
            }
            else
            {
                objUserBLL.SuperUser = false;
            }

            if (rbtActive.Checked == true)
            {
                objUserBLL.IsActive = true;
            }
            else
            {
                objUserBLL.IsActive = false;
            }
            objUserBLL.Status = 'A';
            objUserBLL.LoginId = 1;
            objUserBLL.LogDateTime = DateTime.Now;
            string act=Request.QueryString["act"];
            if (act == "edit")
            {
                int id = 0;
                int.TryParse(Request.QueryString["Id"], out id);
                objUserBLL.UserId = id;
            }

            return objUserBLL;
        }
        #endregion

        #region GridViewPageEven
        protected void dgvUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvUser.PageIndex = e.NewPageIndex;
            DGVUser();
        }
        #endregion

        #region DGVGridView function
        private void DGVUser()
        {
            try
            {
                string UName = txtSearchUserName.Text.Trim().Replace("'", "''");
                int UserId = Convert.ToInt32(Request.QueryString["UserId"]);
                UserBLL data = new UserBLL();
                System.Data.DataTable dt = JaziraBusinessLayer.BLL.Security.UserBLL.GetUserName(UName);
                dgvUser.DataSource = dt;
                dgvUser.DataBind();
                if (dt.Rows.Count == 0)
                    divNoData.Visible = true;
                else
                    divNoData.Visible = false;
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DGVUser();
        }

       
    }
}